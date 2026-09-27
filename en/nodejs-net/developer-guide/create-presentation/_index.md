---
title: Create Presentations in Node.js via .NET
linktitle: Create Presentation
type: docs
weight: 10
url: /nodejs-net/create-presentation/
keywords:
- create presentation
- new presentation
- create PowerPoint
- create PPTX
- add text box
- add slide
- slide size
- widescreen
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Create PowerPoint presentations in JavaScript with Aspose.Slides for Node.js via .NET: add a text box and slides, set a 16:9 slide size, and save the result as PPTX."
---

## **Overview**

This article shows how to create a presentation with Aspose.Slides for Node.js via .NET, add a text box to its first slide, and save the result as a PPTX file. It also shows how to add more slides and how to switch the presentation to widescreen (16:9) slides.

The examples need a project set up as described in [Installation](/slides/nodejs-net/installation/). Save each example as a `.js` file in the project folder and run it from that folder with `node`, for example `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET has no API reference of its own. It mirrors the Aspose.Slides for .NET API with camelCase names, so the API links in this article lead to the matching classes and members in the [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Create a Presentation with a Text Box**

To create a presentation and put a text box on its first slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. A new presentation already contains one empty slide.
1. Get that slide from the [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection. Collections in this package are read with `get(index)`, and indexes start at 0.
1. Add a rectangle with the [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) method and set the [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) of its [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/).
1. Save the presentation with the [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method and the `SaveFormat.Pptx` value.
1. Call `dispose` in a `finally` block to release the .NET resources that back the presentation.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // The position (x, y) and the size (width, height) are in points.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

The script writes `new-presentation.pptx` to the project folder. The file has one slide with a filled rectangle whose top-left corner is 50 points from the left and top edges of the slide. The rectangle is 400 points wide and 100 points high, and its text is centered. A point is 1/72 inch. Without a license, Aspose.Slides also adds an evaluation watermark to the slide; see [Licensing](/slides/nodejs-net/licensing/).

## **Add Slides**

A new presentation has one slide. To add more, pass a layout slide to the [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) method of the `slides` collection. The [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) method of the [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) collection returns the first layout of a given [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/).

The following example adds two slides with the Blank layout:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The script prints `Slide count: 3` and writes `three-slides.pptx`. The new slides are appended after the first one and contain no shapes. A new presentation always has a Blank layout, but a presentation that you open from a file may not have a layout of the requested type; in that case `getByType` returns `null`, so check the result before you pass it on.

## **Set the Slide Size**

A new presentation uses 4:3 slides that are 720 × 540 points (10 × 7.5 inches). To create widescreen slides instead, call the [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) method of the presentation's [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) with a [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) value and a [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) value. The scale type tells Aspose.Slides what to do with shapes that are already on the slides; `DoNotScale` leaves them as they are, which is the right choice for a presentation that has no content yet.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The script prints `Slide size: 960 x 540 points`, which is 13.33 × 7.5 inches, and writes `widescreen.pptx`. `SlideSizeType.OnScreen16x9` has the same 16:9 aspect ratio but is smaller: 720 × 405 points.

## **FAQ**

**In what units are positions and sizes measured?**

In points. One inch is 72 points, so the default 4:3 slide is 720 × 540 points, and a 16:9 widescreen slide is 960 × 540 points.

**Which formats can I save a new presentation to?**

Any value of the [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) enumeration, for example `SaveFormat.Ppt` for PowerPoint 97–2003, `SaveFormat.Odp` for OpenDocument, or `SaveFormat.Pdf`. For PDF output, see [Convert PowerPoint to PDF](/slides/nodejs-net/convert-powerpoint-to-pdf/).

**Why does the saved presentation contain "Evaluation only" text?**

Without a license, Aspose.Slides adds an evaluation watermark to the slides it saves. Apply a license as described in [Licensing](/slides/nodejs-net/licensing/) to remove it.

**Why should I call `dispose`?**

A `Presentation` object is backed by a .NET object that holds memory and other resources. Calling `dispose` releases them as soon as you no longer need the presentation, and calling it in a `finally` block releases them even when an error occurs.
