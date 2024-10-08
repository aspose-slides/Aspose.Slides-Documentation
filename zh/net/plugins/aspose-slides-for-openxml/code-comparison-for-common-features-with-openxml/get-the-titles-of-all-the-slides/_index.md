---
title: 获取所有幻灯片的标题
type: docs
weight: 120
url: /zh/net/get-the-titles-of-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "获取所有幻灯片的标题.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// 获取演示文稿中所有幻灯片的标题列表。

public static IList<string> GetSlideTitles(string presentationFile)

{

    // 以只读方式打开演示文稿。

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// 获取演示文稿中所有幻灯片的标题列表。

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 从PresentationDocument对象获取PresentationPart对象。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // 从PresentationPart对象获取Presentation对象。

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // 按幻灯片顺序获取每个幻灯片的标题。

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // 获取幻灯片标题。

                string title = GetSlideTitle(slidePart);

                // 也可以添加一个空标题。

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// 获取幻灯片的标题字符串。

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 声明一个段落分隔符。

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // 查找所有标题形状。

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // 获取此形状每个段落中的文本。

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // 添加换行符。

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// 确定形状是否为标题形状。

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // 任何标题形状。

            case PlaceholderValues.Title:

            // 居中标题。

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "获取幻灯片中的所有文本.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("幻灯片数量 = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("幻灯片 #{0} 包含: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // 以只读方式打开演示文稿。

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 将演示文稿传递给下一个CountSlides方法

        // 并返回幻灯片计数。

        return CountSlides(presentationDocument);

    }

}

// 计算演示文稿中的幻灯片。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // 检查文档对象是否为null。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 获取文档的演示文稿部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 从SlideParts中获取幻灯片数量。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 将幻灯片数量返回给上一个方法。

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // 获取第一张幻灯片的关系ID。

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // 根据关系ID获取幻灯片部分。

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // 构建一个StringBuilder对象。

        StringBuilder paragraphText = new StringBuilder();

        // 获取幻灯片的内部文本：

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **下载示例代码**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/获取所有幻灯片的标题%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/获取所有幻灯片的标题%20\(Aspose.Slides\).zip)