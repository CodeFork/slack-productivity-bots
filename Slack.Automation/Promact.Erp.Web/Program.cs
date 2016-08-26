﻿using Autofac;
using Promact.Core.Repository.Bot;
using Promact.Core.Repository.Client;
using Promact.Core.Repository.ScrumRepository;
using Promact.Erp.DomainModel.ApplicationClass.Bot;
using SlackAPI;
using System;

namespace Promact.Erp.Web
{
    public class Program
    {
      //  private static BotClient _client;
        private static IScrumBotRepository _scrumBotRepository;
        //    private static SlackAPI.SlackClient _client;
        private static SlackSocketClient client;
        public static void Main(IComponentContext container)
        {
            _scrumBotRepository = container.Resolve<IScrumBotRepository>();
            ////working old
            ////create a new slack client
            //_client = new BotClient("xoxb-61375498279-ZBxCBFUkvnlR4muKNiUh7tCG");//tsakmail

            ////connect to the slack service
            //_client.ConnectClientThread();

            //_client.Message += new BotClient.MessageEventHandler(ClientMessage);
            ////working old





            //_client = new SlackAPI.SlackClient("xoxb-61375498279-ZBxCBFUkvnlR4muKNiUh7tCG");//tsakmail
            //_client.Connect();

            //SlackAPI.SlackSocketClient _sd;
            //_sd = new SlackAPI.SlackSocketClient("xoxb-61375498279-ZBxCBFUkvnlR4muKNiUh7tCG");//tsakmail
            ////_sd.ConnectSocket();
            ////MessageReceived dsf = new MessageReceived();
            ////dsf.ts = DateTime.UtcNow;
            ////dsf.text = "hello";
            //Action<MessageReceived> msg = ((x) =>
            //{
            //    MessageReceived dsf = new MessageReceived();
            //    dsf.ts = DateTime.UtcNow;
            //    dsf.text = "hello";
            //});

            //_sd.SendMessage(msg, "G070PPR7U", "heyyya");



            //client = new SlackSocketClient("xoxp-4652768210-6777564806-63945169157-4b5b10871d");//julie
            SlackSocketClient client = new SlackSocketClient("xoxb-61375498279-ZBxCBFUkvnlR4muKNiUh7tCG");//tsakmail
            client.Connect((connected) =>
            {
                
                //This is called once the client has emitted the RTM start command
            }, () =>
            {
                
                //This is called once the RTM client has connected to the end point
            });
            client.OnMessageReceived += (message) =>
            {
                
                //Handle each message as you receive them
            };

        }


        private static void ClientMessage(MessageEventArgs e)
        {
            try
            {
                if (e.User == null)
                {
                    return;
                }
                if (e.GroupInfo != null)
                {
                    if (e.UserInfo.Name != "tsakmail")
                    {
                        var simpleText = e.Text.Split(null);
                        if (e.Text.ToLower().Equals("scrum time"))
                            _scrumBotRepository.StartScrum(e.GroupInfo.name);
                        else if (simpleText[0].ToLower().Equals("leave") && simpleText.Length == 2)
                            _scrumBotRepository.Leave(e.GroupInfo.name, e.Text);
                        else
                            _scrumBotRepository.AddScrumAnswer(e.UserInfo.Name, e.Text, e.GroupInfo.name);
                    }
                }
                // else
                //Taskmail bot
                //ProcessMessage(e.UserInfo.Name, e.GroupInfo.name, e.Text);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        ////This example method processes commands from users and optionally sends a message back to the user
        //private static void ProcessMessage(string userName, string channel, string text)
        //{
        //    try
        //    {
        //        // const Int32 MAX_NEWS_ITEMS = 10;
        //        PostMessageArguments args = new PostMessageArguments();
        //        args.Channel = channel;
        //        args.Username = userName;
        //        //args.as_user = true;
        //        text = text.Trim().ToLower();
        //        if (args.Username != "tsakmail")
        //        {
        //            switch (text)
        //            {
        //                case "scrum meeting":
        //                    //if (questionCount == 0)
        //                    //    args.text = "What did you do yesterday ?" + questionCount;
        //                    //else if (questionCount == 1)
        //                    //    args.text = "What will you do today ?" + questionCount;
        //                    //else if (questionCount == 2)
        //                    //    args.text = "Any Roadblock ?" + questionCount;
        //                    //client.Chat.PostMessage(args);
        //                    //questionCount++;
        //                    break;
        //                default:
        //                    //if (questionCount == 0)
        //                    //    args.text = "What did you do yesterday ?" + questionCount;
        //                    //else if (questionCount == 1)
        //                    //    args.text = "What will you do today ?" + questionCount;
        //                    //else if (questionCount == 2)
        //                    //    args.text = "Any Roadblock ?" + questionCount;
        //                    //if (!(string.IsNullOrEmpty(args.text)))
        //                    //{
        //                    //    client.Chat.PostMessage(args);
        //                    //    questionCount++;
        //                    //}
        //                    break;
        //            }
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}