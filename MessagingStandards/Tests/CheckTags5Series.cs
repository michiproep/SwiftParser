using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MessagingStandards.Entities.SWIFT;
using MessagingStandards.Entities.SWIFT.MT.Tags;

namespace MessagingStandards.Tests
{
    public class CheckTags5Series
    {
        string sample22HAlternatelocation = @"./Sample_548_22F.txt";
        string samplemessagelocationlongstring = @"./Sample_548_LongString.txt";
        string sample548 = @"./Sample_548_negative.txt";
        string sample548_23G = @"./Sample_548_23G.txt";
        string sample515 = @"./Sample_515.txt";
        string sample515_90B = @"./Sample_515_90B.txt";

        [Fact]
        public void Check_Tag13A()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());


            foreach (var block in message.Block4)
            {
                if (block.TagName == "13A")
                {
                    value = block.Value;
                }
            }

            Assert.Equal("541", value);
        }

        [Fact]
        public void Check_Tag19A()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample548))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "19A")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("-25858462,",  value);
            Assert.Equal("SETT", valueType);
        }

        [Fact]
        public void Check_Tag22F()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample22HAlternatelocation))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "22F")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("TRAD", value);
            Assert.Equal("REDI", valueType);
        }


        [Fact]
        public void Check_Tag22H()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "22H")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("APMT", value);
            Assert.Equal("PAYM", valueType);
        }

        [Fact]
        public void Check_Tag20C_SEME()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "20C" && block.Qualifier == "SEME")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("3640190172704", value);
        }

        [Fact]
        public void Check_Tag23G()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample548_23G))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "23G")
                {
                    value = block.Value;
                    valueType = block.Code;
                }
            }


            Assert.Equal("INST", value);
            Assert.Equal("DUPL", valueType);
        }

        [Fact]
        public void Check_Tag25D()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "25D")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("MACH", value);
        }


        [Fact]
        public void Check_Tag36B()
        {

            string str;
            string value = "";
            string valueType = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "36B")
                {
                    value = block.Value;
                    valueType = block.Type;
                    qualifier = block.Qualifier;
                }
            }


            Assert.Equal("13300,", value);
            Assert.Equal("UNIT", valueType);
            Assert.Equal("SETT", qualifier);
        }

        [Fact]
        public void Check_Tag35B()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "35B")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("JP3843250006", value);
            Assert.Equal("ISIN", valueType);
        }

        [Fact]
        public void Check_Tag35B_CountryCode()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample515_90B))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "35B")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("78764HAD6", value);
            Assert.Equal("US", valueType);
        }

        [Fact]
        public void Check_Tag70C()
        {

            string str;
            string value = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "70C")
                {
                    qualifier = block.Qualifier;
                    value = block.Value;
                }
            }


             Assert.Equal("PACO", qualifier);
             Assert.Equal("GSCC/TDIDAJ101", value);
         }

        [Fact]
        public void Check_Tag70E()
        {

            string str;
            string value = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515_90B))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "70E")
                {
                    qualifier = block.Qualifier;
                    value = block.Value;
                }
            }


            Assert.Equal("TPRO", qualifier);
            Assert.Equal("GSCC/DEST01/DEST02/YIEL5,6 and MSRB / Yield", value);
        }


        [Fact]
        public void Check_Tag90A()
        {

            string str;
            string value = "";
            string valueType = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "90A")
                {
                    qualifier = block.Qualifier;
                    valueType = block.Type;
                    value = block.Value;
                }
            }


            Assert.Equal("0,", value);
            Assert.Equal("DEAL", qualifier);
            Assert.Equal("PRCT", valueType);
        }

        [Fact]
        public void Check_Tag90B()
        {

            string str;
            string value = "";
            string valueType = "";
            string qualifier = "";
            string currency = "";

            using (StreamReader sr = File.OpenText(sample515_90B))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "90B")
                {
                    qualifier = block.Qualifier;
                    valueType = block.Type;
                    value = block.Value;
                    currency = block.Code;
                }
            }


            Assert.Equal("10206,89", value);
            Assert.Equal("DEAL", qualifier);
            Assert.Equal("ACTU", valueType);
            Assert.Equal("USD", currency);
        }

        [Fact]
        public void Check_Tag94B()
        {

            string str;
            string value = "";
            string valueType = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "94B")
                {
                    qualifier = block.Qualifier;
                    valueType = block.Code;
                    value = block.Value;
                }
            }


            
            Assert.Equal("TRAD", qualifier);
            Assert.Equal("GSCC", valueType);
            Assert.Equal("OTMU", value);
        }

        [Fact]
        public void Check_Tag95P()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "95P")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("JJSDJPJT", value);
            Assert.Equal("PSET", valueType);
        }

        [Fact]
        public void Check_Tag95Q()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(sample515_90B))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "95Q")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }

            Assert.Equal("SELL", valueType);
            Assert.Equal("Goldman Sachs Treasury", value);
        }

        [Fact]
        public void Check_Tag95R()
        {

            string str;
            string value = "";
            string code = "";
            string qualifier = "";

            using (StreamReader sr = File.OpenText(sample515))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "95R")
                {
                    value = block.Value;
                    qualifier = block.Qualifier;
                    code = block.Code;
                }
            }


            Assert.Equal("SELL", qualifier);
            Assert.Equal("GSCC", code);
            Assert.Equal("PART1563", value);
        }

        [Fact]
        public void Check_Tag97A()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "97A")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("009-043068-313", value);
            Assert.Equal("SAFE", valueType);
        }

        [Fact]
        public void Check_Tag98A_SettlementDate()
        {

            string str;
            string value = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "98A" && block.Qualifier == "SETT")
                {
                    value = block.Value;
                }
            }


            Assert.Equal("20140115", value);
        }

        [Fact]
        public void Check_Tag98C()
        {

            string str;
            string value = "";
            string valueType = "";

            using (StreamReader sr = File.OpenText(samplemessagelocationlongstring))
            {
                str = sr.ReadToEnd();
            }

            SwiftMessage message = new SwiftMessage();
            message.ParseSwiftMessage(str.Trim());

            foreach (var block in message.Block4)
            {
                if (block.TagName == "98C")
                {
                    value = block.Value;
                    valueType = block.Qualifier;
                }
            }


            Assert.Equal("20140114133539", value);
        }
    }


}
