---
title: 管理 C# 中的上标和下标
linktitle: 上标和下标
type: docs
weight: 80
url: /zh/net/superscript-and-subscript/
keywords:
- 上标
- 下标
- 添加上标
- 添加下标
- PowerPoint
- OpenDocument
- 演示文稿
- C#
- Csharp
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中精通上标和下标，并通过专业的文本格式提升演示文稿的最大影响力。"
---

## **概述**

Aspose.Slides for .NET 提供将上标和下标文本集成到 PowerPoint (PPT、PPTX) 和 OpenDocument (ODP) 演示文稿中的功能。无论是需要突出显示化学式、数学公式，还是使用脚注对内容进行注释，这些专用的格式选项都有助于保持清晰和精准。本文将教您如何无缝应用上标和下标样式，并在每张幻灯片中实现专业效果。

## **添加上标和下标文本**

您可以在演示文稿中的任意段落内添加上标和下标文本。使用 Aspose.Slides 时，需要使用 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) 类的 `Escapement` 属性。

该属性允许您设置上标或下标文本，取值范围为 -100%（下标）到 100%（上标）。

实现步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 向幻灯片添加一个类型为 `Rectangle` 的 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。
1. 访问与 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 关联的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。
1. 清除现有段落。
1. 创建一个用于上标文本的新的 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)，并将其添加到 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 的段落集合中。
1. 创建一个新的文本片段对象。
1. 将文本片段的 `Escapement` 属性设置为 0 到 100 之间，以应用上标（0 表示不使用上标）。
1. 为 [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) 设置一些文本，并将其添加到段落的片段集合中。
1. 创建另一个用于下标文本的 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)，并将其添加到段落集合中。
1. 创建一个新的文本片段对象。
1. 将文本片段的 `Escapement` 属性设置为 0 到 -100 之间，以应用下标（0 表示不使用下标）。
1. 为 [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) 设置一些文本，并将其添加到段落的片段集合中。
1. 将演示文稿保存为 PPTX 文件。

以下 C# 代码实现了上述步骤：
```c#
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 创建文本框。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // 为上标文本创建段落。
    IParagraph superPar = new Paragraph();

    // 创建普通文本片段。
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // 创建上标文本片段。
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // 为下标文本创建段落。
    IParagraph paragraph2 = new Paragraph();

    // 创建普通文本片段。
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // 创建下标文本片段。
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // 将段落添加到文本框。
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


结果：

![上标和下标](superscript_and_subscript.png)

## **常见问题**

**在导出为 PDF 或其他格式时，上标和下标会被保留吗？**

是的，Aspose.Slides for .NET 在将演示文稿导出为 PDF、PPT/PPTX、图像以及其他受支持的格式时，会正确保留上标和下标的格式。专用的格式在所有输出文件中保持完整。

**上标和下标可以与加粗、斜体等其他格式样式组合使用吗？**

可以，Aspose.Slides 允许在同一个文本片段中混合多种文本样式。您可以通过设置 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) 中的相应属性，同时启用加粗、斜体、下划线以及上标或下标。

**上标和下标格式在表格、图表或 SmartArt 中的文本是否同样有效？**

可以，Aspose.Slides for .NET 支持在大多数对象中进行格式设置，包括表格和图表元素。对于 SmartArt，需要访问相应的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)）及其文本容器，然后以类似方式配置 [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) 属性。