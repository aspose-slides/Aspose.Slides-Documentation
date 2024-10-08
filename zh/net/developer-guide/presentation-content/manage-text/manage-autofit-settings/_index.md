---
title: 管理自动适应设置
type: docs
weight: 30
url: /zh/net/manage-autofit-settings/
keywords: "文本框, 自动适应, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中设置 PowerPoint 中文本框的自动适应设置"
---

默认情况下，当你添加一个文本框时，Microsoft PowerPoint 使用 **调整形状以适应文本** 设置——它会自动调整文本框大小以确保文本始终适合其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变得更长或更大时，PowerPoint 会自动增大文本框——增加其高度——以便容纳更多文本。
* 当文本框中的文本变得更短或更小，PowerPoint 会自动缩小文本框——减少其高度——以清除多余的空间。

在 PowerPoint 中，有以下 4 个重要参数或选项控制文本框的自动适应行为：

* **不自动适应**
* **溢出时缩小文本**
* **调整形状以适应文本**
* **在形状中换行文本。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET 提供类似的选项——一些属性在 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类下——允许你控制演示文稿中文本框的自动适应行为。

## **调整形状以适应文本**

如果你希望文本框中的文本在更改后始终适合该框，你必须使用 **调整形状以适应文本** 选项。要指定此设置，将 [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类）设置为 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 C# 代码展示了如何在 PowerPoint 演示文稿中指定文本必须始终适合其框：

```c#
 using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

如果文本变得更长或更大，文本框将自动调整大小（高度增加），以确保所有文本适合其中。如果文本变得更短，则会发生相反的情况。

## **不自动适应**

如果你希望文本框或图形在文本内容变化时保持其尺寸，你必须使用 **不自动适应** 选项。要指定此设置，将 [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) 属性 （来自 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类）设置为 `None`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 C# 代码展示了如何在 PowerPoint 演示文稿中指定文本框始终保持其尺寸：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

当文本变得过长以适应其框时，它将溢出。

## **溢出时缩小文本**

如果文本对其框来说过长，使用 **溢出时缩小文本** 选项，你可以指定文本的大小和间距必须减少，以便适合其框。要指定此设置，将 [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) 属性 （来自 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类）设置为 `Normal`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 C# 代码展示了如何在 PowerPoint 演示文稿中指定文本在溢出时必须缩小：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="信息" color="info" %}}

当使用 **溢出时缩小文本** 选项时，该设置仅在文本变得过长时应用。

{{% /alert %}}

## **换行文本**

如果你希望文本框中的文本在超出形状边界（仅宽度）时发生换行，则必须使用 **在形状中换行文本** 参数。要指定此设置，你需要将 [WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/wraptext) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) 类）设置为 `true`。

以下 C# 代码展示了如何在 PowerPoint 演示文稿中使用换行文本设置：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="注意" color="warning" %}} 

如果你将 `WrapText` 属性设置为 `False`，当形状内部的文本变得比形状的宽度更长时，文本将沿着一条单行延伸到形状的边界之外。

{{% /alert %}}