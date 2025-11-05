---
title: Manage Superscript and Subscript in C#
linktitle: Superscript and Subscript
type: docs
weight: 80
url: /net/superscript-and-subscript/
keywords:
- superscript
- subscript
- add superscript
- add subscript
- PowerPoint
- OpenDocument
- presentation
- C#
- Csharp
- Aspose.Slides
description: "Master superscript and subscript in Aspose.Slides for .NET and elevate your presentations with professional text formatting for maximum impact."
---

## **Overview**

Aspose.Slides for .NET provides features for integrating superscript and subscript text into your PowerPoint (PPT, PPTX) and OpenDocument (ODP) presentations. Whether you need to highlight chemical formulas, mathematical equations, or annotate content with footnotes, these specialized formatting options help maintain clarity and precision. In this article, you'll learn how to seamlessly apply superscript and subscript styles and ensure professional results in every slide.

## **Add Superscript and Subscript Text**

You can add superscript and subscript text inside any paragraph in a presentation. To achieve this with Aspose.Slides, you must use the `Escapement` property of the [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) class.

This property allows you to set superscript or subscript text, with values ranging from -100% (subscript) to 100% (superscript).

Implementation steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Get a reference to a slide using its index.
1. Add an [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) of type `Rectangle` to the slide.
1. Access the [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) associated with the [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Clear existing paragraphs.
1. Create a new [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) for superscript text and add it to the paragraph collection of the [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
1. Create a new text portion object.
1. Set the `Escapement` property for the text portion between 0 to 100 to apply superscript (0 means no superscript).
1. Set some text for the [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) and add it to the paragraph's portion collection.
1. Create another [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) for subscript text and add it to the paragraph collection.
1. Create a new text portion object.
1. Set the `Escapement` property for the text portion between 0 to -100 to apply subscript (0 means no subscript).
1. Set some text for the [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) and add it to the paragraph's portion collection.
1. Save the presentation as a PPTX file.

The following C# code implements these steps:

```c#
using (Presentation presentation = new Presentation())
{
    // Get the first slide.
    ISlide slide = presentation.Slides[0];

    // Create a text box.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Create a paragraph for superscript text.
    IParagraph superPar = new Paragraph();

    // Create a text portion with regular text.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Create a text portion with superscript text.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Create a paragraph for subscript text.
    IParagraph paragraph2 = new Paragraph();

    // Create a text portion with regular text.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Create a text portion with subscript text.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Add the paragraphs to the text box.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

The result:

![Superscript and Subscript](superscript_and_subscript.png)

## **FAQ**

**Will superscript and subscript be preserved when exporting to PDF or other formats?**

Yes, Aspose.Slides for .NET properly retains superscript and subscript formatting when exporting presentations to PDF, PPT/PPTX, images, and other supported formats. The specialized formatting remains intact in all output files.

**Can superscript and subscript be combined with other formatting styles such as bold or italics?**

Yes, Aspose.Slides allows you to mix various text styles within a single portion of text. You can enable bold, italics, underline, and simultaneously apply superscript or subscript by configuring the corresponding properties in [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/).

**Do superscript and subscript formatting work for text inside tables, charts, or SmartArt?**

Yes, Aspose.Slides for .NET supports formatting within most objects, including tables and chart elements. When working with SmartArt, you need to access the appropriate elements (such as [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)) and their text containers, and then configure the [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) properties in a similar manner.
