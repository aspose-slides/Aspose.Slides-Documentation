---
title: 获取幻灯片中的所有文本
type: docs
weight: 110
url: /zh/net/get-all-the-text-in-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "获取幻灯片中的所有文本.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// 获取幻灯片中的所有文本。

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // 以只读方式打开演示文稿。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 将演示文稿和幻灯片索引传递给下一个 GetAllTextInSlide 方法，并返回它所返回的字符串数组。 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // 验证演示文档是否存在。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 验证幻灯片索引是否超出范围。

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // 获取演示文稿文档的演示文稿部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 验证演示部分和演示文稿是否存在。

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // 从演示部分获取演示文稿对象。

        Presentation presentation = presentationPart.Presentation;

        // 验证幻灯片 ID 列表是否存在。

        if (presentation.SlideIdList != null)

        {

            // 从幻灯片 ID 列表中获取幻灯片 ID 集合。

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // 如果幻灯片 ID 在范围内...

            if (slideIndex < slideIds.Count)

            {

                // 获取幻灯片的关系 ID。

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // 从关系 ID 获取指定的幻灯片部分。

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // 将幻灯片部分传递给下一个方法，然后返回该方法返回的字符串数组。

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // 否则，返回 null。

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // 验证幻灯片部分是否存在。

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // 创建一个新的字符串双向链表。

    LinkedList<string> texts = new LinkedList<string>();

    // 如果幻灯片存在...

    if (slidePart.Slide != null)

    {

        // 遍历幻灯片中的所有段落。

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // 创建一个新的字符串构造器。                    

            StringBuilder paragraphText = new StringBuilder();

            // 遍历段落中的每一行。

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // 将每一行追加到之前的行。

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // 将每个段落添加到链表中。

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // 返回字符串数组。

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

string FileName = FilePath + "获取幻灯片中的所有文本.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// 获取幻灯片中的所有文本。

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// 创建一个新的字符串列表。

List<string> texts = new List<string>();

// 实例化表示 PPTX 的 PresentationEx 类

using (Presentation pres = new Presentation(presentationFile))

{

    // 访问幻灯片

    ISlide sld = pres.Slides[slideIndex];

    // 遍历形状以查找占位符

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // 获取每个占位符的文本

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// 返回字符串数组。

return texts;

}

``` 
## **下载示例代码**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/获取幻灯片中的所有文本%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/获取幻灯片中的所有文本%20\(Aspose.Slides\).zip)