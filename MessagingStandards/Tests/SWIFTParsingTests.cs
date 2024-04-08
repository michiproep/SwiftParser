using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MessagingStandards.SWIFT;
using MessagingStandards.Entities.SWIFT;
using MessagingStandards.Entities.SWIFT.MT.Tags;

namespace MessagingStandards.Tests
{
    public class SWIFTParsingTests
    {
        string samplemessagelocation = @"./Sample_548_Updated.txt";
        string samplemessagelocationlongstring = @"./Sample_548_LongString.txt";
        

        [Fact]
        public void SeperateStringIntoSWIFTBlocks()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string,string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());

            Assert.Equal(4, swiftBlocks.Count());
        }

        [Fact]
        public void FindSenderBIC()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());
            BasicHeader Sender = new BasicHeader(swiftBlocks);
            


            Assert.Equal("TOMSMSGS", Sender.SenderBIC);
        }

        [Fact]
        public void FindBranchCode()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());
            BasicHeader Sender = new BasicHeader(swiftBlocks);


            Assert.Equal("JPX", Sender.BranchCode);
        }

        [Fact]
        public void FindReceiverBIC()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());
            ApplicationHeader Receiver = new ApplicationHeader(swiftBlocks);



            Assert.Equal("CITIJPJT", Receiver.ReceiverBIC);
        }

        [Fact]
        public void FindMessageType()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());
            ApplicationHeader Receiver = new ApplicationHeader(swiftBlocks);



            Assert.Equal("548", Receiver.MessageType);
        }

        [Fact]
        public void SeperateTagsByColon()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());

            List<string> listOfTags = new List<string>();

            var Block4 = swiftBlocks["TextBlock"];
            listOfTags = message.Block4ToList(Block4);

            Assert.Equal(33, listOfTags.Count);
            
        }

        [Fact]
        public void SeperateTagsByColonFromSwiftString()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            MTParser message = new MTParser();
            Dictionary<string, string> swiftBlocks = message.SeperateSWIFTFile(str.Trim());

            List<string> listOfTags = new List<string>();

            var Block4 = swiftBlocks["TextBlock"];

            listOfTags = message.Block4ToList(Block4);

            Assert.Equal(33, listOfTags.Count);

        }

        [Fact]
        public void FormatSwiftTagsToMoneyValues()
        {

            string str;

            using (StreamReader sr = File.OpenText(samplemessagelocation))
            {
                str = sr.ReadToEnd();
            }

            List<string> listOfTags = new List<string>();

            TagFormatter formatter = new TagFormatter();
            SwiftMessage message = new SwiftMessage();

            message.ParseSwiftMessage(str.Trim());
            message.Block4 = formatter.MoneyFormatter(message.Block4);

            foreach (var swiftTag in message.Block4)
            {
                if (swiftTag.TagName == "19A")
                {
                    Assert.Equal("25858462.23", swiftTag.Value);
                }
            }

        }

   }

}

