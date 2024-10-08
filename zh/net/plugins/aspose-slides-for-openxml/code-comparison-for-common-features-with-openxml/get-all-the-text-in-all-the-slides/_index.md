---
title: 获取所有幻灯片中的所有文本
type: docs
weight: 100
url: /zh/net/get-all-the-text-in-all-the-slides/
---

## **OpenXML SDK**
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

        // 将演示文稿传递到下一个 CountSlides 方法

        // 并返回幻灯片数量。

        return CountSlides(presentationDocument);

    }

}

// 计算演示文稿中的幻灯片。

public static int CountSlides(PresentationDocument presentationDocument)

{

    // 检查文档对象是否为 null。

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 获取文档的演示部分。

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 从 SlideParts 获取幻灯片数量。

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 返回幻灯片数量给上一个方法。

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // 获取第一张幻灯片的关系 ID。

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // 根据关系 ID 获取幻灯片部分。

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // 创建一个 StringBuilder 对象。

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
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "获取幻灯片中的所有文本.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("幻灯片数量 = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("幻灯片 #{0} 包含: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // 实例化 PresentationEx 类，该类代表 PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    // 实例化 PresentationEx 类，该类代表 PPTX

    using (Presentation pres = new Presentation(docName))

    {

        // 访问幻灯片

        ISlide sld = pres.Slides[index];

        // 遍历形状以寻找占位符

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                // 获取每个占位符的文本

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **下载示例代码**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip)