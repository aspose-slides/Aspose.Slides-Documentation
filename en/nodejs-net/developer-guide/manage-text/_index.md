---
title: Manage Presentation Text in Node.js via .NET
linktitle: Manage Text
type: docs
weight: 50
url: /nodejs-net/manage-text/
keywords:
- text
- text box
- add text
- change text
- format text
- font size
- bold text
- text frame
- paragraph
- portion
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Add a text box to a slide, then change its text, font size, and bold style in JavaScript with Aspose.Slides for Node.js via .NET."
---

## **Overview**

In Aspose.Slides, text on a slide belongs to a shape. An auto shape, such as a rectangle, has a text frame; the text frame contains paragraphs, and each paragraph contains portions, which are runs of text with the same formatting. You change the text through the text frame and the font through the format of a portion.

This article adds a text box to a slide and saves the presentation. It then opens the saved file and changes the text box's text, font size, and bold style.

The examples need a project set up as described in [Installation](/slides/nodejs-net/installation/). Save each example as a `.js` file in the project folder and run it from that folder with `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET has no API reference of its own. It mirrors the Aspose.Slides for .NET API with camelCase names, so the API links in this article lead to the matching classes and members in the [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Add a Text Box**

To add a text box, add an auto shape to a slide with the [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) method and give it text with the [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/) method. The following example adds a rectangle to the first slide of a new presentation and saves the presentation as `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // The position (x, y) and the size (width, height) are in points.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

The slide in `text-box.pptx` contains a rectangle, 500 points wide and 80 points high, with the text "Quarterly report" in the default font and size. The next example changes this text box.

## **Change the Text and Its Formatting**

The following example opens `text-box.pptx`, which the previous example created, and gets the first shape on the first slide. Shapes such as pictures and tables have no text frame, so the example checks that the shape is an [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) before it uses the shape's [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/). It then does the following:

1. It replaces the text through the [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) property of the text frame. After that, the text frame contains one paragraph with one portion.
1. It gets that portion from the [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) and [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) collections and reads its [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/).
1. It sets [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/), the font size in points, and [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/), which takes a [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) value.

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

In `text-box-updated.pptx`, the text box shows "Quarterly report: third quarter" in bold 32-point type. Because the new text is a single portion, the two formatting properties apply to all of it. Without a license, every save adds an evaluation watermark. Because `text-box.pptx` was itself saved in evaluation mode, `text-box-updated.pptx` contains two; see [Evaluate Aspose.Slides](/slides/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Why does `fontBold` take a `NullableBool` value instead of `true` or `false`?**

A portion can leave a property undefined and inherit it from the paragraph, the shape, or the slide's layout and master. `NullableBool.NotDefined` means "inherit", while `NullableBool.True` and `NullableBool.False` override the inherited value. Assigning `true` or `false` throws an error. For the same reason, `fontHeight` returns `NaN` when the portion inherits its font size.

**How do I change the text color?**

Set the fill of the portion format: assign `FillType.Solid` to `portionFormat.fillFormat.fillType`, and then assign a color such as `"#FF0000"` to `portionFormat.fillFormat.solidFillColor.color`. Add `FillType` to the names that you import from the package.

**How do I format only part of the text?**

Formatting belongs to portions, so put that part of the text in a portion of its own. Create the portion with `Portion.CreatePortionFromText`, append it to a paragraph with the `add` method of the paragraph's `portions` collection, and then set the new portion's `portionFormat`. Add `Portion` to the names that you import from the package.

**Why does reading text return "... text has been truncated due to evaluation version limitation"?**

Without a license, Aspose.Slides returns only the first five characters of any longer text that you read, such as `textFrame.text`, followed by this notice. Text that you write is saved in full. Apply a license as described in [Licensing](/slides/nodejs-net/licensing/) to read the complete text.
