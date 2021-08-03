using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Function
{
    public class Handler
    {
        public string FunctionHandler(string json)
        {
            AliceRequest request = JsonConvert.DeserializeObject<AliceRequest>(json);

            var response = new AliceResponse()
            {
                Version = "1.0",
                Response = new ResponseModel()
            };

            Solution solution = new Solution();

            if (request.Session.New)
            {
                response.Response.Text = "Приветствую вас в игре Быки, коровы и слова. Правила следующие. Я буду загадывать пятибуквенное слова, все буквы которого уникальны и не повторяются. Тебе необходимо угадать слово. Результат выражается в Быках или Коровах. Бык - буква стоит на своем месте, Корова - буква в загаданном слове есть, но стоит на чужом месте. Таким образом тебе надо отгадать загаданное мной слово";
            }
            else if (request.Request.Command.ToLower() == "помощь")
            {
                response.Response.Text = "Правила следующие. Я буду загадывать пятибуквенное слова, все буквы которого уникальны и не повторяются. Тебе необходимо угадать слово. Результат выражается в Быках или Коровах. Бык - буква стоит на своем месте, Корова - буква в загаданном слове есть, но стоит на чужом месте. Таким образом тебе надо отгадать загаданное мной слово";
            }
            else if (request.Request.Command.ToLower() == "что ты умеешь")
            {
                response.Response.Text = "Я умею играть в модифицированную версию игры Быки и коровы. Правила следующие. Я буду загадывать пятибуквенное слова, все буквы которого уникальны и не повторяются. Тебе необходимо угадать слово. Результат выражается в Быках или Коровах. Бык - буква стоит на своем месте, Корова - буква в загаданном слове есть, но стоит на чужом месте. Таким образом тебе надо отгадать загаданное мной слово";
            }
            else
            {
                if (request.State.Session.BullCow is null)
                {
                    (string word, int id) = solution.TakeRandom();
                    response.Response.Text = "Слово загадано!";
                    response.State = new SessionStateModel()
                    {
                        BullCow = new BullCowModel()
                        {
                            GuessedWord = word,
                            Score = 0,
                            Id = id
                        }

                    };
                    response.Response.EndSession = false;
                }
                else
                {
                    (bool isAnswer, int bulls, int cows) = solution.Get(request.Request.Command.ToLower(), request.State.Session.BullCow.GuessedWord);
                    if (isAnswer)
                    {
                        response.Response.Text = $"Верно! Ты угадал с попытки №{request.State.Session.BullCow.Score}! Произнеси любую фразу, чтобы продолжить";
                    }
                    else
                    {
                        response.State = new SessionStateModel()
                        {
                            BullCow = request.State.Session.BullCow
                        };
                        response.State.BullCow.Score++;
                        response.Response.Text = $"В твоем слове количество быков - {bulls}, коров - {cows}!";
                    }
                }

            }

            return JsonConvert.SerializeObject(response);
        }
    }
}
