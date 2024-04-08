using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MessagingStandards.Entities.SWIFT;
using MessagingStandards.SWIFT;

namespace MessagingStandards.Tests
{
    public class CheckTags1Series
    {
        string sample103 = @"./Sample_103.txt";
        string sample101 = @"./TEST_CH10.fin";

        [Fact]
        public void Check_Tag23B()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "23B")
                {
                    value = block.Value;
                }
            }


            Assert.Equal("CRED", value);
        }


        [Fact]
        public void Check_Tag28D()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample101))
            {
                str = sr.ReadToEnd();
            }

            str = str.ConvertFromUnix();
            

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "28D")
                {
                    value = block.Value;
                }
            }

            
            Assert.Equal("1", value);
        }

        [Fact]
        public void Check_Tag33B()
        {

            string str;
            string value = "";
            string valuetype = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "33B")
                {
                    valuetype = block.Code;
                    value = block.Value;
                }
            }


            Assert.Equal("3520000,", value);
            Assert.Equal("JPY", valuetype);
        }

        [Fact]
        public void Check_Tag50K()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "50K")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.Equal("EUROXXXEI", value);
        }

        [Fact]
        public void Check_Tag52A()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "52A")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.Equal("FEBXXXM1", value);
        }

        [Fact]
        public void Check_Tag53A()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "53A")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.Equal("MHCXXXJT", value);
        }

        [Fact]
        public void Check_Tag54A()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "54A")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.Equal("FOOBICXX", value);
        }

        [Fact]
        public void Check_Tag59()
        {

            string str;
            string value = "";
            string description = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "59")
                {
                    value = block.Value;
                    description = block.Description;
                }
            }

            Assert.Equal("13212312", value);
            Assert.Equal("RECEIVER NAME S.A", description);
        }

        [Fact]
        public void Check_Tag70()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "70")
                {
                    value = block.Value;
                }
            }


            Assert.Equal("FUTURES", value);
        }

        [Fact]
        public void Check_Tag71A()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "71A")
                {
                    value = block.Value;
                }
            }


            Assert.Equal("SHA", value);
        }

        [Fact]
        public void Check_Tag71F()
        {

            string str;
            string value = "";
            string currency = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "71F")
                {
                    value = block.Value;
                    currency = block.Code;
                }
            }


            Assert.Equal("2,34", value);
            Assert.Equal("EUR", currency);
        }

        [Fact]
        public void Check_Tag71G()
        {

            string str;
            string value = "";
            string currency = "";

            using (StreamReader sr = File.OpenText(sample103))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "71G")
                {
                    value = block.Value;
                    currency = block.Code;
                }
            }


            Assert.Equal("12,00", value);
            Assert.Equal("EUR", currency);
        }
    }
}
