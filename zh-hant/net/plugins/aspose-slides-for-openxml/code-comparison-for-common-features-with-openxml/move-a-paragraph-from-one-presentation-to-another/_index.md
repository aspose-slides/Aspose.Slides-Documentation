---
title: 將段落從一個簡報移動到另一個簡報
type: docs
weight: 130
url: /zh-hant/net/move-a-paragraph-from-one-presentation-to-another/
---
## **OpenXML 簡報**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// 將來源文件中 TextBody 形狀內的段落範圍移動
// 到目標文件中另一個 TextBody 形狀。

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    // 以讀寫模式開啟來源檔案。

    using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

    {

        // 以讀寫模式開啟目標檔案。

        using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

        {

            // 取得來源簡報的第一張投影片。

            SlidePart slide1 = GetFirstSlide(sourceDoc);

            // 取得其中的第一個 TextBody 形狀。

            TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

            // 取得 TextBody 形狀中的第一個段落。

            // 註："Drawing" 是命名空間 DocumentFormat.OpenXml.Drawing 的別名

            Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

            // 取得目標簡報的第一張投影片。

            SlidePart slide2 = GetFirstSlide(targetDoc);

            // 取得其中的第一個 TextBody 形狀。

            TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

            // 複製來源段落並將複製的段落插入目標 TextBody 形狀。

            // 傳入 "true" 會建立深層複製，該複製會產生

            // Paragraph 物件以及所有直接或間接被該物件參照的內容的副本。

            textBody2.Append(p1.CloneNode(true));

            // 從來源檔案中移除來源段落。

            textBody1.RemoveChild<Drawing.Paragraph>(p1);

            // 以佔位符取代已移除的段落。

            textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

            // 將投影片存回來源檔案。

            slide1.Slide.Save();

            // 將投影片存回目標檔案。

            slide2.Slide.Save();

        }

    }

}

// 取得簡報文件中第一張投影片的 SlidePart。

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

    // 取得第一張投影片的關係 ID

    PresentationPart part = presentationDocument.PresentationPart;

    SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

    string relId = slideId.RelationshipId;

    // 依關係 ID 取得 SlidePart。

    SlidePart slidePart = (SlidePart)part.GetPartById(relId);

    return slidePart;

}
``` 
## **Aspose.Slides**
開發人員需要從簡報中提取文字的情況並不罕見。為此，您需要從簡報中所有投影片的所有圖形中提取文字。本文說明如何使用 Aspose.Slides 從 Microsoft PowerPoint PPTX 簡報中提取文字。無論是從單一投影片還是整個簡報提取文字，Aspose.Slides 都使用 PresentationScanner 類別以及它公開的靜態方法。這些全部位於命名空間 [Aspose.Slides.Util](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil)。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// 在來源文件的 TextBody 形狀中移動段落範圍

// 到目標文件的另一個 TextBody 形狀。

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //實例化代表 PPTX 的 Presentation 類別//實例化代表 PPTX 的 Presentation 類別

    Presentation sourcePres = new Presentation(sourceFile);

    //存取第一張投影片的第一個形狀

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //取得 placeholder 的文字

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //存取第一張投影片的第一個形狀

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //取得 placeholder 的文字

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **下載執行範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)