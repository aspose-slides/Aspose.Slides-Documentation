---
title: Manage Autofit Settings
type: docs
weight: 30
url: /net/manage-autofit-settings/
keywords: "Textbox, Autofit, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Set the autofit settings for textbox in PowerPoint in C# or .NET"
---

By default, when you add a textbox, Microsoft PowerPoint uses the **Resize shape to fix text** setting for the textbox—it automatically resizes the textbox to ensure its text always fits into it. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* When the text in the textbox becomes longer or bigger, PowerPoint automatically enlarges the textbox—increases its height—to allow it to hold more text. 
* When the text in the textbox becomes shorter or smaller, PowerPoint automatically reduces the textbox—decreases its height—to clear redundant space. 

In PowerPoint, these are the 4 important parameters or options that control the autofit behavior for a textbox: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET provides similar options—some properties under the [TextFrameFormat](https://apireference.aspose.com/slides/net/aspose.slides/textframeformat) class—that allow you to control the autofit behavior for textboxes in presentations. 

## **Resize Shape to Fit Text**

If you want the text in a box to always fit into that box after changes are made to the text, you have to use the **Resize shape to fix text** option. To specify this setting, set the [AutofitType](https://apireference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) property (from the [TextFrameFormat](https://apireference.aspose.com/slides/net/aspose.slides/textframeformat) class) to `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

This C# code shows you how to specify that a text must always fit into its box:

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

If the text becomes longer or bigger, the textbox will be automatically resized (increase in height) to ensure all the text fits into it. If the text becomes shorter, the reverse occurs. 

## **Do Not Autofit**

If you want a textbox or shape to retain its dimensions no matter the changes made to the text it contains, you have to use the **Do not autofit** option. To specify this setting, set the [AutofitType](https://apireference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) property (from the [TextFrameFormat](https://apireference.aspose.com/slides/net/aspose.slides/textframeformat) class) to `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

This C# code shows you how to specify that a textbox must always retain its dimensions:

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

When the text becomes too long for its box, it spills out. 

## **Shrink Text on Overflow**

If a text becomes too long for its box, through the **Shrink text on overflow** option, you can specify that the text's size and spacing must be reduced to make it fit into its box. To specify this setting, set the [AutofitType](https://apireference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) property (from the [TextFrameFormat](https://apireference.aspose.com/slides/net/aspose.slides/textframeformat) class) to `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

This C# code shows you how to specify that a text must be shrunk on overflow:

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
    textFrameFormat.AutofitType = TextAutofitType .Normal;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}

When the **Shrink text on overflow** option is used, the setting gets applied only when the text becomes too long for its box. 

{{% /alert %}}

## **Wrap Text**

If you want the text in a shape to get wrapped inside that shape when the text goes beyond the shape's border (width only), you have to use the **Wrap text in shape** parameter. To specify this setting, you have to set the [WrapText](https://apireference.aspose.com/slides/net/aspose.slides/textframeformat/properties/wraptext) property (from the [TextFrameFormat](https://apireference.aspose.com/slides/net/aspose.slides/textframeformat) class) to `true`. 

This C# code shows you how to use the Wrap Text setting:

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

{{% alert title="Note" color="warning" %}} 

If you set the `WrapText` property to `False` for a shape, when the text inside the shape becomes longer than the shape's width, the text gets extended beyond the shape's borders along a single line. 

{{% /alert %}}





