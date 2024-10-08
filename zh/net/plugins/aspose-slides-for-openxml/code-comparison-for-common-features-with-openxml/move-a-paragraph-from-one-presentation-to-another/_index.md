---
title: 从一个演示文稿移动段落到另一个演示文稿
type: docs
weight: 130
url: /net/move-a-paragraph-from-one-presentation-to-another/
---

## **OpenXML 演示文稿**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "从一个演示文稿移动段落到另一个演示文稿 1.pptx";

string DestFileName = FilePath + "从一个演示文稿移动段落到另一个演示文稿 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// 将源文档中的 TextBody 形状中的段落范围移动到目标文档中的另一个 TextBody 形状。

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// 以读写方式打开源文件。

using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // 以读写方式打开目标文件。

    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // 获取源演示文稿中的第一张幻灯片。

        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // 获取其中的第一种 TextBody 形状。

        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // 获取 TextBody 形状中的第一段。

        // 注意：“Drawing”是 DocumentFormat.OpenXml.Drawing 命名空间的别名

        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // 获取目标演示文稿中的第一张幻灯片。

        SlidePart slide2 = GetFirstSlide(targetDoc);

        // 获取其中的第一种 TextBody 形状。

        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // 克隆源段落并将克隆的段落插入目标 TextBody 形状中。

        // 传递“true”会创建深度克隆，这会创建段落对象及其直接或间接引用的所有内容的副本。

        textBody2.Append(p1.CloneNode(true));

        // 从源文件中移除源段落。

        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // 用占位符替换移除的段落。

        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // 保存源文件中的幻灯片。

        slide1.Slide.Save();

        // 保存目标文件中的幻灯片。

        slide2.Slide.Save();

    }

}

}

// 获取演示文档中第一张幻灯片的幻灯片部分。

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// 获取第一张幻灯片的关系 ID

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// 通过关系 ID 获取幻灯片部分。

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
开发人员提取演示文稿中的文本并不罕见。为此，您需要从演示文稿中的所有幻灯片上的所有形状中提取文本。本文解释了如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。无论是从单个幻灯片提取文本还是从整个演示文稿提取文本，Aspose.Slides 都使用 PresentationScanner 类及其暴露的静态方法。它们都打包在命名空间 [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil) 下。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "从一个演示文稿移动段落到另一个演示文稿 1.pptx";

string DestFileName = FilePath + "从一个演示文稿移动段落到另一个演示文稿 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// 将源文档中的 TextBody 形状中的段落范围移动到目标文档中的另一个 TextBody 形状。

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    // 实例化表示 PPTX 的 Presentation 类

    Presentation sourcePres = new Presentation(sourceFile);

    // 访问第一张幻灯片中的第一个形状

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        // 从占位符中获取文本

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    // 访问第一张幻灯片中的第一个形状

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        // 从占位符中获取文本

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   

``` 
## **下载运行代码示例**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **示例代码**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Move a Paragraph/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)