---
title: Enhance Your Presentations with AutoFit in C#
linktitle: Manage Autofit Settings
type: docs
weight: 30
url: /net/manage-autofit-settings/
keywords:
- textbox
- autofit
- do not autofit
- fit text
- shrink text
- wrap text
- resize shape
- PowerPoint
- presentation
- C#
- .NET
- Aspose.Slides
description: "Learn how to manage AutoFit settings in Aspose.Slides for .NET to optimize text display in your PowerPoint and OpenDocument presentations and improve content readability."
---

## **Overview**

By default, when you add a textbox, Microsoft PowerPoint uses the **Resize shape to fit text** setting for the textbox—it automatically resizes the textbox to ensure its text always fits into it.

![A textbox in PowerPoint](textbox-in-powerpoint.png)

* When the text in the textbox becomes longer or bigger, PowerPoint automatically enlarges the textbox—increasing its height—to allow it to hold more text.
* When the text in the textbox becomes shorter or smaller, PowerPoint automatically reduces the textbox—decreasing its height—to clear redundant space.

In PowerPoint, these are the four important parameters or options that control the autofit behavior for a textbox:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Autofit options in PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET provides similar options—properties under the [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) class—that allow you to control the autofit behavior for textboxes in presentations.

## **Resize Shape to Fit Text**

If you want the text in a box to always fit into that box after changes are made to the text, you have to use the **Resize shape to fit text** option. To specify this setting, set the `AutofitType` property from the [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) class to `Shape`.

![Resize shape to fit text](alwaysfit-setting-powerpoint.png)

This C# code shows how to specify that text must always fit into its box in a PowerPoint presentation:

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

If the text becomes longer or bigger, the textbox will be automatically resized (increased in height) to ensure all the text fits into it. If the text becomes shorter, the reverse occurs.

## **Do Not Autofit**

If you want a textbox or shape to retain its dimensions no matter the changes made to the text it contains, you have to use the **Do not Autofit** option. To specify this setting, set the `AutofitType` property from the [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) class to `None`.

!["Do not Autofit" setting in PowerPoint](donotautofit-setting-powerpoint.png)

This C# code shows how to specify that a textbox must always retain its dimensions in a PowerPoint presentation:

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

When the text becomes too long for its box, it spills out.

## **Shrink Text on Overflow**

If the text becomes too long for its box, through the **Shrink text on overflow** option, you can specify that the text's size and spacing must be reduced to make it fit into its box. To specify this setting, set the `AutofitType` property from the [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) class to `Normal`.

!["Shrink text on overflow" setting in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

This C# code shows how to specify that text must be shrunk on overflow in a PowerPoint presentation:

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

When the **Shrink text on overflow** option is used, the setting is applied only when the text becomes too long for its box.

{{% /alert %}}

## **Wrap Text**

If you want the text in a shape to be wrapped inside that shape when the text goes beyond the shape's border (width only), you have to use the **Wrap text in shape** parameter. To specify this setting, you have to set the `WrapText` property from the [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) class to `NullableBool.True`.

This C# code shows how to use the Wrap Text setting in a PowerPoint presentation:

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

If you set the `WrapText` property to `NullableBool.False` for a shape, when the text inside the shape becomes longer than the shape's width, the text extends beyond the shape's borders along a single line.

{{% /alert %}}

## **FAQ**

**Do the text frame’s internal margins affect AutoFit?**

Yes. Padding (internal margins) reduces the usable area for text, so AutoFit will kick in earlier—shrinking the font or resizing the shape sooner. Check and adjust margins before tuning AutoFit.

**How does AutoFit interact with manual and soft line breaks?**

Forced breaks remain in place, and AutoFit adapts font size and spacing around them. Removing unnecessary breaks often reduces how aggressively AutoFit needs to shrink the text.

**Does changing the theme font or triggering font substitution affect AutoFit results?**

Yes. Substituting to a font with different glyph metrics changes text width/height, which can alter final font size and line wrapping. After any font change or substitution, re-check the slides.
