using Newtonsoft.Json;
using System;

namespace Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Handler handler = new Handler();
            var r = handler.FunctionHandler("{" +
                "\"meta\": {" +
                    "\"locale\": \"ru-RU\"," +
                    "\"timezone\": \"UTC\"," +
                    "\"client_id\": \"ru.yandex.searchplugin/7.16 (none none; android 4.4.2)\"," +
                    "\"interfaces\": {" +
                        "\"screen\": { }," +
                        "\"payments\": { }," +
                        "\"account_linking\": { }}}," +
                    "\"session\": {" +
                        "\"message_id\": 0," +
                        "\"session_id\": \"0308ca49-33a9-42e1-8a41-753a343f594a\"," +
                        "\"skill_id\": \"499d0009-46fc-44d5-8ea6-4230b29ff8ed\"," +
                        "\"user\": {" +
                            "\"user_id\": \"BC230A1251BAA30F01467C984331DD31D1D577BDCFD5F625FD3AFDF67F054D98\"}," +
                        "\"application\": {" +
                            "\"application_id\": \"39D0EAA66A75B619DC7FDC4CA2B7A870DAC210C4174C1BBB99395060F05A782E\"}," +
                        "\"user_id\": \"39D0EAA66A75B619DC7FDC4CA2B7A870DAC210C4174C1BBB99395060F05A782E\"," +
                        "\"new\": false}," +
                    "\"request\": {" +
                        "\"command\": \"[fq\"," +
                        "\"original_utterance\": \"\"," +
                        "\"nlu\": {" +
                            "\"tokens\": []," +
                            "\"entities\": []," +
                            "\"intents\": { }}," +
                        "\"markup\": {" +
                            "\"dangerous_context\": false}," +
                        "\"type\": \"SimpleUtterance\"}," +
                        "\"state\": {" +
                            "\"session\": { }," +
                            "\"user\": { }," +
                            "\"application\": { }}," +
                        "\"version\": \"1.0\"}");
            var rr = JsonConvert.DeserializeObject(r);
            Console.ReadLine();
        }
    }
}
