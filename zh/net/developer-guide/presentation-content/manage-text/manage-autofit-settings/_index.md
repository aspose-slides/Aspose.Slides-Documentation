---
title: 使用 C# 的 AutoFit 提升您的演示文稿
linktitle: 管理 Autofit 设置
type: docs
weight: 30
url: /zh/net/manage-autofit-settings/
keywords:
- 文本框
- 自动适应
- 不自动适应
- 适配文本
- 收缩文本
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

默认情况下，当你添加文本框时，Microsoft PowerPoint 使用 **Resize shape to fit text** 设置——它会自动调整文本框的大小，以确保其中的文本始终能够完全适配。

![PowerPoint 中的文本框](textbox-in-powerpoint.png)

* 当文本框中的文字变长或变大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文字。
* 当文本框中的文字变短或变小的时，PowerPoint 会自动缩小文本框——降低其高度——以清除多余的空间。

在 PowerPoint 中，以下四个重要参数或选项控制文本框的自动适应行为：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![PowerPoint 中的 Autofit 选项](autofit-options-powerpoint.png)

Aspose.Slides for .NET 提供了类似的选项——位于 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类下的属性——允许你在演示文稿中控制文本框的自动适应行为。

## **将形状大小调整以适应文本**

如果希望文本框中的文字在任何修改后始终能够完全适配该框，需要使用 **Resize shape to fit text** 选项。要指定此设置，请将来自 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `AutofitType` 属性设置为 `Shape`。

![将形状大小调整以适应文本](alwaysfit-setting-powerpoint.png)

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


如果文字变长或变大，文本框将自动（在高度上）增大，以确保所有文字都能容纳进去。文字变短时则相反。

## **不自动适应**

如果希望文本框或形状在文字内容变化后仍保持其尺寸，需要使用 **Do not Autofit** 选项。要指定此设置，请将来自 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `AutofitType` 属性设置为 `None`。

![PowerPoint 中的 “Do not Autofit” 设置](donotautofit-setting-powerpoint.png)

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


当文字超出框的范围时，文字会溢出。

## **文字溢出时收缩文本**

如果文字超出框的范围，可以通过 **Shrink text on overflow** 选项让文字的大小和间距被缩小，以适配框的大小。要指定此设置，请将来自 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `AutofitType` 属性设置为 `Normal`。

![PowerPoint 中的 “Shrink text on overflow” 设置](shrinktextonoverflow-setting-powerpoint.png)

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
使用 **Shrink text on overflow** 选项时，仅在文字超出框的范围时才会应用此设置。
{{% /alert %}}

## **换行文本**

如果希望文字在超出形状的宽度时在形状内部换行，需要使用 **Wrap text in shape** 参数。要指定此设置，请将来自 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `WrapText` 属性设置为 `NullableBool.True`。

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
如果将 `WrapText` 属性设置为 `NullableBool.False`，当形状内部的文字长度超过形状宽度时，文字会沿单行超出形状边界。
{{% /alert %}}

## **常见问题**

**文本框的内部边距会影响 AutoFit 吗？**

会。内部边距（Padding）会减少可用的文字区域，因此 AutoFit 会更早触发——会更早地缩小字体或调整形状大小。请在调节 AutoFit 之前检查并调整边距。

**AutoFit 如何与手动换行和软换行交互？**

强制换行会保持原位，AutoFit 会在这些换行点周围调整字体大小和间距。删除不必要的换行通常可以减少 AutoFit 的收缩力度。

**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**

会。替换为字形度量不同的字体会改变文字的宽高，从而可能改变最终的字体大小和换行方式。任何字体更改或替换后，都应重新检查幻灯片的显示效果。