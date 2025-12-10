---
title: 使用 .NET 中的 AutoFit 提升您的演示文稿
linktitle: AutoFit 设置
type: docs
weight: 30
url: /zh/net/manage-autofit-settings/
keywords:
- 文本框
- 自动适配
- 不自动适配
- 适配文本
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

默认情况下，当您添加文本框时，Microsoft PowerPoint 对该文本框使用 **Resize shape to fit text** 设置——它会自动调整文本框的大小，以确保文本始终适配。

![PowerPoint 中的文本框](textbox-in-powerpoint.png)

* 当文本框中的文字变长或变大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文字。  
* 当文本框中的文字变短或变小时，PowerPoint 会自动缩小文本框——降低其高度——以清除多余空间。

在 PowerPoint 中，以下四个重要参数或选项用于控制文本框的自动适配行为：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![PowerPoint 中的自动适配选项](autofit-options-powerpoint.png)

Aspose.Slides for .NET 在 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类下提供了类似的属性，帮助您在演示文稿中控制文本框的自动适配行为。

## **将形状大小调整以适应文本**

如果希望文本框中的文字在任何修改后始终适配该框，需要使用 **Resize shape to fit text** 选项。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `AutofitType` 属性设为 `Shape`。

![始终适配设置的 PowerPoint 示例](alwaysfit-setting-powerpoint.png)

```csharp
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

```

当文字变长或变大时，文本框会自动调整大小（增高），以确保所有文字都能容纳其中。文字变短时则相反。

## **不自动适配**

如果希望文本框或形状无论文字如何变化都保持原始尺寸，需要使用 **Do not Autofit** 选项。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `AutofitType` 属性设为 `None`。

![PowerPoint 中的 “Do not Autofit” 设置](donotautofit-setting-powerpoint.png)

```csharp
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

```

当文字超出文本框宽度时，会溢出显示。

## **文字溢出时缩小**

若文字超出文本框宽度，可通过 **Shrink text on overflow** 选项让文字的大小和间距自动缩小以适配框体。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `AutofitType` 属性设为 `Normal`。

![PowerPoint 中的 “Shrink text on overflow” 设置](shrinktextonoverflow-setting-powerpoint.png)

```csharp
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

```

{{% alert title="Info" color="info" %}}
使用 **Shrink text on overflow** 选项时，仅在文字超出文本框时才会应用此设置。
{{% /alert %}}

## **换行文字**

如果希望文字在超出形状边界（仅宽度）时在形状内部换行，需要使用 **Wrap text in shape** 参数。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类的 `WrapText` 属性设为 `NullableBool.True`。

```csharp
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

```

{{% alert title="Note" color="warning" %}} 
如果将 `WrapText` 属性设为 `NullableBool.False`，当形状内部的文字长度超过形状宽度时，文字会在单行上超出形状边界。
{{% /alert %}}

## **常见问题**

**文本框的内部边距会影响 AutoFit 吗？**  
会。内边距会减少可用的文字区域，因此 AutoFit 会更早触发——先缩小字体或先调整形状大小。请在调节 AutoFit 前检查并修改边距。

**AutoFit 如何与手动换行和软换行交互？**  
强制换行会保持原位，AutoFit 会围绕这些换行点调整字体大小和间距。删除不必要的换行通常可以减少 AutoFit 对文字的缩小力度。

**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**  
会。替换为字形度量不同的字体会改变文字的宽高，从而可能改变最终的字体大小和换行方式。任何字体更改或替换后，请重新检查幻灯片的呈现效果。