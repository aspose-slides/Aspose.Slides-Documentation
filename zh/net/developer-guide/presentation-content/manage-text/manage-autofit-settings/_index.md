---
title: 使用 .NET 中的 AutoFit 增强您的演示文稿
linktitle: AutoFit 设置
type: docs
weight: 30
url: /zh/net/manage-autofit-settings/
keywords:
- 文本框
- 自动适应
- 不自动适应
- 适合文本
- 缩小文本
- 换行文本
- 调整形状大小
- PowerPoint
- 演示文稿
- C#
- .NET
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中管理 AutoFit 设置，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本显示并提升内容可读性。"
---

## **概述**

默认情况下，当您添加文本框时，Microsoft PowerPoint 使用 **Resize shape to fit text** 设置——它会自动调整文本框的大小，以确保文本始终能够适应其中。

![PowerPoint 中的文本框](textbox-in-powerpoint.png)

* 当文本框中的文本变长或变大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文本。
* 当文本框中的文本变短或变小，PowerPoint 会自动缩小文本框——减少其高度——以清除多余空间。

在 PowerPoint 中，有四个重要的参数或选项用于控制文本框的自动适应行为：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![PowerPoint 中的自动适应选项](autofit-options-powerpoint.png)

Aspose.Slides for .NET 提供了类似的选项——位于 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类下的属性——可以让您控制演示文稿中文本框的自动适应行为。

## **Resize Shape to Fit Text**

如果您希望文本在修改后始终适应所在的框，需要使用 **Resize shape to fit text** 选项。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `AutofitType` 属性设为 `Shape`。

![Resize shape to fit text](alwaysfit-setting-powerpoint.png)

以下 C# 代码示例展示了如何在 PowerPoint 演示文稿中指定文本必须始终适应其框：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


如果文本变长或变大，文本框会自动调整大小（增加高度），以确保所有文本都能容纳进去。若文本变短，则相反。

## **Do Not Autofit**

如果您希望文本框或形状在文本内容变化时保持其尺寸不变，需要使用 **Do not Autofit** 选项。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `AutofitType` 属性设为 `None`。

!["Do not Autofit" setting in PowerPoint](donotautofit-setting-powerpoint.png)

以下 C# 代码示例展示了如何在 PowerPoint 演示文稿中指定文本框必须始终保持其尺寸：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


当文本过长而超出其框时，会溢出显示。

## **Shrink Text on Overflow**

如果文本过长而超出其框，可以通过 **Shrink text on overflow** 选项指定将文本的大小和间距缩小以适应框内。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `AutofitType` 属性设为 `Normal`。

!["Shrink text on overflow" setting in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

以下 C# 代码示例展示了如何在 PowerPoint 演示文稿中指定文本在溢出时进行缩小：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Info" color="info" %}}

使用 **Shrink text on overflow** 选项时，仅在文本超出其框时才会应用该设置。

{{% /alert %}}

## **Wrap Text**

如果您希望当文本超出形状边界（仅宽度）时在形状内部换行，需要使用 **Wrap text in shape** 参数。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `WrapText` 属性设为 `NullableBool.True`。

以下 C# 代码示例展示了如何在 PowerPoint 演示文稿中使用换行设置：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Note" color="warning" %}} 

如果将形状的 `WrapText` 属性设置为 `NullableBool.False`，当形状内部的文本长度超过形状宽度时，文本会在单行上延伸超出形状边界。

{{% /alert %}}

## **FAQ**

**文本框的内部边距会影响 AutoFit 吗？**

会。内部边距（Padding）会减小可用的文本区域，因此 AutoFit 会更早触发——更快地缩小字体或调整形状大小。请在调节 AutoFit 之前检查并调整边距。

**AutoFit 与手动换行和软换行如何交互？**

强制换行会保留原位，AutoFit 会在其周围调整字体大小和间距。删除不必要的换行通常可以降低 AutoFit 的收缩力度。

**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**

会。替换为字形度量不同的字体会改变文本的宽高，从而影响最终的字体大小和换行方式。任何字体更改或替换后，请重新检查幻灯片。