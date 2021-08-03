using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Function
{
    public class BullCowModel
    {
        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("guessed_word")]
        public string GuessedWord { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
    
    public class SessionModel
    {
        [JsonProperty("new")]
        public bool New { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("message_id")]
        public int MessageId { get; set; }

        [JsonProperty("skill_id")]
        public string SkillId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }

    public class ResponseModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("tts")]
        public string Tts { get; set; }

        [JsonProperty("end_session")]
        public bool EndSession { get; set; }

        [JsonProperty("buttons")]
        public ButtonModel[] Buttons { get; set; }
    }

    public class StateModel
    {
        [JsonProperty("session")]
        public SessionStateModel Session { get; set; }
    }

    public class SessionStateModel
    {
        [JsonProperty("value")]
        public BullCowModel BullCow { get; set; }
    }

    public class ButtonModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("payload")]
        public object Payload { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("hide")]
        public bool Hide { get; set; }
    }

    public class MetaModel
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }

    public class AliceRequest
    {
        [JsonProperty("meta")]
        public MetaModel Meta { get; set; }

        [JsonProperty("request")]
        public RequestModel Request { get; set; }

        [JsonProperty("session")]
        public SessionModel Session { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("state")]
        public StateModel State { get; set; }
    }

    public enum RequestType
    {
        SimpleUtterance,
        ButtonPressed
    }

    public class RequestModel
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("type")]
        public RequestType Type { get; set; }

        [JsonProperty("original_utterance")]
        public string OriginalUtterance { get; set; }

        [JsonProperty("payload")]
        public JObject Payload { get; set; }
    }

    public class AliceResponse
    {
        [JsonProperty("response")]
        public ResponseModel Response { get; set; }

        [JsonProperty("session")]
        public SessionModel Session { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; } = "1.0";

        [JsonProperty("session_state")]
        public SessionStateModel State { get; set; }
    }
}
