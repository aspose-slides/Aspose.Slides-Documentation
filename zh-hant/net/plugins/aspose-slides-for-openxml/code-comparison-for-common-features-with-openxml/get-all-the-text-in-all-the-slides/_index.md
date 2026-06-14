---
title: 取得所有投影片中的所有文字
type: docs
weight: 100
url: /zh-hant/net/get-all-the-text-in-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // 以唯讀方式開啟簡報。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 將簡報傳遞給下一個 CountSlides 方法

        // 並回傳投影片數量。

        return CountSlides(presentationDocument);

    }

}

// 計算簡報中的投影片數量。
public static int CountSlides(PresentationDocument presentationDocument)

{

    // 檢查文件物件是否為 null。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 取得文件的簡報部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 從 SlideParts 取得投影片數量。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 將投影片數量回傳給先前的方法。

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // 取得第一張投影片的關聯 ID。

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // 依關聯 ID 取得投影片部分。

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // 建立 StringBuilder 物件。

        StringBuilder paragraphText = new StringBuilder();

        // 取得投影片的內部文字：

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //實例化表示 PPTX 的 PresentationEx 類別

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //實例化表示 PPTX 的 PresentationEx 類別

    using (Presentation pres = new Presentation(docName))

    {

        //存取投影片

        ISlide sld = pres.Slides[index];

        //迭代形狀以尋找佔位符

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //取得每個佔位符的文字

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)