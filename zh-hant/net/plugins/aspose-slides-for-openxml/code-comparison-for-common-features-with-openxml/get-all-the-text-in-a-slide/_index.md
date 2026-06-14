---
title: 取得投影片中的所有文字
type: docs
weight: 110
url: /zh-hant/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// 取得投影片中的所有文字。

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // 以唯讀方式開啟簡報。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 傳遞簡報與投影片索引

        // 給下一個 GetAllTextInSlide 方法，並

        // 然後回傳它所回傳的字串陣列。

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // 驗證簡報文件是否存在。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 驗證投影片索引未超出範圍。

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // 取得簡報文件的簡報部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 驗證簡報部分與簡報是否存在。

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // 從簡報部分取得 Presentation 物件。

        Presentation presentation = presentationPart.Presentation;

        // 驗證投影片 ID 列表是否存在。

        if (presentation.SlideIdList != null)

        {

            // 從投影片 ID 列表取得投影片 ID 集合。

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // 若投影片 ID 在範圍內...

            if (slideIndex < slideIds.Count)

            {

                // 取得投影片的關聯 ID。

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // 從關聯 ID 取得指定的投影片部分。

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // 把投影片部分傳遞給下一個方法，並

                // 然後回傳該方法回傳的字串陣列

                // 給前一個方法。

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // 否則，回傳 null。

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // 驗證投影片部分是否存在。

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // 建立一個新的字串鏈結串列。

    LinkedList<string> texts = new LinkedList<string>();

    // 若投影片存在...

    if (slidePart.Slide != null)

    {

        // 遍歷投影片中的所有段落。

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // 建立一個新的 StringBuilder。                    

            StringBuilder paragraphText = new StringBuilder();

            // 遍歷段落中的文字行。

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // 將每行文字附加到先前的行。

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // 把每個段落加入鏈結串列。

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // 回傳字串陣列。

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// 取得投影片中的所有文字。

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// 建立新的字串鏈結串列。

List<string> texts = new List<string>();

// 實例化代表 PPTX 的 PresentationEx 類別

using (Presentation pres = new Presentation(presentationFile))

{

    // 存取投影片

    ISlide sld = pres.Slides[slideIndex];

    // 遍歷圖形以尋找佔位元

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // 取得每個佔位元的文字

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// 回傳字串陣列。

return texts;

}

``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)