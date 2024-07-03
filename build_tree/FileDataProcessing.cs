using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.IO;

namespace FromApp1
{
    class load_data
    {
        #region using System.IO;
        public string ReadStringFromFile(string id)
        {
            string text;
            using (System.IO.StreamReader text_sr =
                new System.IO.StreamReader(id, System.Text.Encoding.Default))
                text = text_sr.ReadToEnd(); //設中斷點, 看 text 內容找分行及分欄符號
            return text;
        }
        public string ReadStringFromFile_HTML(string id)
        {
                        var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            string text;
            using (System.IO.StreamReader text_sr =
                new System.IO.StreamReader(id, utf8WithoutBom))
                text = text_sr.ReadToEnd(); //設中斷點, 看 text 內容找分行及分欄符號
            return text;
        }
        public string[] ReadStringArrayFromFile(string id)
        {
            string text;
            using (System.IO.StreamReader text_sr =
                new System.IO.StreamReader(id, System.Text.Encoding.Default))
                text = text_sr.ReadToEnd(); //設中斷點, 看 text 內容找分行及分欄符號
            string lineDelimitor = "\r\n";
            string[] text_line = text.Split(new string[] { lineDelimitor }, StringSplitOptions.None); //先分行
            return text_line;
        }


        public string[] SplitString(string content,string spliter)
        {
            string text = content;
            string lineDelimitor = spliter;
            string[] text_line = text.Split(new string[] { lineDelimitor }, StringSplitOptions.None); //先分行
            return text_line;
        }


        public string[] String2Array(string input, string split_text)
        {
            if (input.IndexOf(split_text) == -1)
            {
                return new string[] { "格式錯誤", "" };
            }
            else
            {
                string[] text_line = input.Split(new string[] { split_text }, StringSplitOptions.None); //先分行
                return text_line;
            }

        }
        public string[,] Read2DStringArrayFromFile(string id, char separator)//取得字串並分割二維陣列
        {
            string[] line = ReadStringArrayFromFile(id);//取出行
            int NumOfStateType = line.Length;//行數
            int NumOfStateIndex = line[0].Split(separator).Length;//個數

            string[,] StringArray_2D = new string[NumOfStateType - 1, NumOfStateIndex];

            for (int i = 0; i < NumOfStateType - 1; i++)
            {
                for (int j = 0; j < NumOfStateIndex; j++)
                {
                    StringArray_2D[i, j] = line[i].Split(separator)[j];
                }
            }
            return StringArray_2D;
        }
        public void WriteStringtoFile_HTML(string Path, string Content)
        {
            var utf8WithoutBom = new System.Text.UTF8Encoding(false);
            System.IO.File.WriteAllText(Path, Content, utf8WithoutBom);
        }
        public void WriteStringtoFile(string Path, string Content)
        {
            System.IO.File.WriteAllText(Path, Content, Encoding.ASCII);
        }
        public void WriteStringtoFile_add(string Path, string Content)
        {
            System.IO.File.AppendAllText(Path, Content, Encoding.ASCII);
        }
        #endregion

        #region using System.Net;
        /// <summary>
        ///
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string GetStringFromHTML(string strUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            HttpWebResponse webresponse = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(webresponse.GetResponseStream(),
                               Encoding.GetEncoding("UTF-8")); //可改不同編碼
            string HTML = streamReader.ReadToEnd();
            return HTML;
        }
        public string GetStringFromHTML(string strUrl, Encoding tag)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            HttpWebResponse webresponse = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(webresponse.GetResponseStream(), tag); //可改不同編碼
            string HTML = streamReader.ReadToEnd();
            return HTML;
        }

        public string[] GetStringArrayFromHTML(string strUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            HttpWebResponse webresponse = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(webresponse.GetResponseStream(),
                               Encoding.GetEncoding("UTF-8")); //可改不同編碼
            string HTML = streamReader.ReadToEnd();

            string lineDelimitor = "\r\n";
            string[] text_line = HTML.Split(new string[] { lineDelimitor }, StringSplitOptions.None); //先分行
            return text_line;
        }
        #endregion

        #region HTML Processing

        public string HTMLSpliter(string html, string start_tag, string end_tag)
        {
            string output = "X";
            output = output + html;
            output = output.Replace(start_tag, "＠").Replace(end_tag, "＠").Split('＠')[1];
            return output;
        }

        public string GetHTMLinner(string html)
        {
            string output = string.Empty;
            output = output.Split('>')[1].Split('<')[0];
            return output;
        }

        #endregion

    }

}

