using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;


namespace TGBot
{
    class Telegram
    {
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient("1305495277:AAGlAxNzukQ190g0ysHZtSLYhbQx5XbIplk");
            client.OnMessage += BotOnMessageReceived;
            client.OnMessageEdited += BotOnMessageReceived;
            client.StartReceiving();
            Console.WriteLine("Server has been started...");
            Console.WriteLine("Press Enter to stop");
            Console.ReadLine();
            client.StopReceiving();
        }
        public static string anime()
        {
            {
                String URLString = "https://animevost.am/rss.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(URLString);
                XmlElement root = doc.DocumentElement;
                string text = null;
                XmlNodeList elemListTitle = root.GetElementsByTagName("title");
                XmlNodeList elemListDate = root.GetElementsByTagName("pubDate");
                XmlNodeList elemListGuid = root.GetElementsByTagName("guid");
                for (int i = 0; i < elemListDate.Count; i++)
                {
                    text += " 🌸 " + (i + 1) + " " + elemListTitle[i + 1].InnerXml + "\n"
                    + "📆 " + elemListDate[i].InnerXml + elemListGuid[i].InnerXml + "\n" + "\n";
                }
                return text + "https://a73.agorov.org/";

            }
        }
        private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (e.Message.Text == "/command1")
            {
                await client.SendTextMessageAsync(message.Chat.Id, Db.printAllList());
                await client.SendTextMessageAsync(message.Chat.Id, "enter id anime\n list: 1 2 3");
            }
            if (e.Message.Text.Contains("list:"))
            {
                Db.createList(message.Chat.Id, e.Message.Text);
                await client.SendTextMessageAsync(message.Chat.Id, "correct");
            }
            if (e.Message.Text == "/command2")
            {
                await client.SendTextMessageAsync(message.Chat.Id, Db.printAllList());

            }
               if (e.Message.Text == "/command3")
                {
                  await client.SendTextMessageAsync(message.Chat.Id, Db.printList(message.Chat.Id));

                }

                if (e.Message.Text == "hi")
            {
                await client.SendTextMessageAsync(message.Chat.Id, message.Text);
                //await client.SendStickerAsync(message.Chat.Id, "CAACAgIAAxkBAAI_r1 -Ybt8xEUS0AAFBldDnEkgi2IYUZAACDSMAAuCjggeXsvhpxp-R4xsE");
                await client.SendTextMessageAsync(message.Chat.Id, anime());
                await client.SendTextMessageAsync(message.Chat.Id, @"https://animevost.org/page/5/");
                await client.SendPhotoAsync(message.Chat.Id, @"https://i.pinimg.com/564x/40/90/cf/4090cf733c863ac75d7c545bdb25b39e.jpg");
            }
            if (e.Message.Text == "how are you?")
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Fine");
                await client.SendStickerAsync(message.Chat.Id, "CAACAgIAAxkBAAI_u1-YdLryTelO5qHopBrcbIPuinU3AAIaIwAC4KOCB3IDQ3fHtpa2GwQ");
            }
            if (message?.Type == MessageType.Sticker)
            {
                await client.SendPhotoAsync(message.Chat.Id, @"https://i.pinimg.com/originals/f4/d2/96/f4d2961b652880be432fb9580891ed62.png");
            }
        }
    }
}
