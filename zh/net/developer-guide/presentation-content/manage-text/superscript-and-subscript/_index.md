---
title: 上标和下标
type: docs
weight: 80
url: /net/superscript-and-subscript/
keywords: "上标, 下标, 添加上标文本, 添加下标文本, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加上标和下标文本"
---

## **管理上标和下标文本**
您可以在任何段落部分添加上标和下标文本。要在 Aspose.Slides 文本框中添加上标或下标文本，必须使用**Escapement**属性的 PortionFormat 类。

该属性返回或设置上标或下标文本（值范围从 -100%（下标）到 100%（上标））。例如：

- 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 向幻灯片添加一个矩形类型的 IAutoShape。
- 访问与 IAutoShape 关联的 ITextFrame。
- 清除现有段落。
- 创建一个新的段落对象以保存上标文本，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的部分对象。
- 为部分设置 Escapement 属性，值在 0 到 100 之间以添加上标。（0 表示没有上标）
- 设置部分的文本，然后将其添加到段落的部分集合中。
- 创建一个新的段落对象以保存下标文本，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的部分对象。
- 为部分设置 Escapement 属性，值在 0 到 -100 之间以添加下标。（0 表示没有下标）
- 设置部分的文本，然后将其添加到段落的部分集合中。
- 将演示文稿另存为 PPTX 文件。

上述步骤的实现如下所示。

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    // 获取幻灯片
    ISlide slide = presentation.Slides[0];

    // 创建文本框
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // 创建上标文本的段落
    IParagraph superPar = new Paragraph();

    // 创建普通文本的部分
    IPortion portion1 = new Portion();
    portion1.Text = "SlideTitle";
    superPar.Portions.Add(portion1);

    // 创建上标文本的部分
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // 创建下标文本的段落
    IParagraph paragraph2 = new Paragraph();

    // 创建普通文本的部分
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // 创建下标文本的部分
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // 将段落添加到文本框
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("TestOut.pptx", SaveFormat.Pptx);
    System.Diagnostics.Process.Start("TestOut.pptx");
 } 
```