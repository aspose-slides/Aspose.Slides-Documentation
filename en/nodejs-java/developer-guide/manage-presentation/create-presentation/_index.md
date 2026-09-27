---
title: Create Presentations in JavaScript
linktitle: Create Presentation
type: docs
weight: 10
url: /nodejs-java/create-presentation/
keywords:
- create presentation
- new presentation
- create PPT
- new PPT
- create PPTX
- new PPTX
- create ODP
- new ODP
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Create presentations with Aspose.Slides—produce PPT, PPTX, and ODP files, benefit from OpenDocument support, and save them programmatically for reliable results."
---

## **Overview**

This article shows how to create a presentation in Aspose.Slides, add a text box to its first slide, and save the result as a file.

Before you begin, install the `aspose.slides.via.java` package from npm, together with the JDK, Python, and C++ build tools it needs. See [Installation](/slides/nodejs-java/installation/).

## **Create a PowerPoint Presentation**

To create a presentation and put a text box on its first slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class. A new presentation already contains one empty slide.
1. Get that slide from the [slide collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) by its index, 0.
1. Add a rectangle with the [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) method and set its text with [setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/).
1. Save the presentation as a PPTX file with the [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) method.
1. Release the presentation with the [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/) method, and end the process.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides runs in a Java virtual machine that keeps Node.js running, so end the process explicitly.
process.exit(0);
```

The rectangle's top-left corner is 50 points from the left edge and 50 points from the top edge of the slide, and the rectangle is 400 points wide and 100 points high. Save the code as *hello.js* in your project folder and run `node hello.js`: it saves *hello.pptx*, with one slide holding that rectangle and its text, in the current folder.

Aspose.Slides runs in a Java virtual machine that the `java` package starts inside the Node.js process. That virtual machine keeps Node.js from exiting on its own after the script finishes, so the example ends with `process.exit(0)`.

Without a license, Aspose.Slides also adds an evaluation watermark to every slide it saves; see [Licensing](/slides/nodejs-java/licensing/).

## **FAQ**

### What formats can I save a new presentation to?

You can save to [PPTX, PPT, and ODP](/slides/nodejs-java/save-presentation/), and export to [PDF](/slides/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/nodejs-java/render-a-slide-as-an-svg-image/), and [images](/slides/nodejs-java/convert-powerpoint-to-png/), among others.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/nodejs-java/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

Set the [slide size](/slides/nodejs-java/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

### In what units are sizes and coordinates measured?

In points: 1 inch equals 72 units.

### How do I handle very large presentations (with many media files) to reduce memory usage?

Use [BLOB management strategies](/slides/nodejs-java/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

### Can I create/save presentations in parallel?

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) instance from [multiple threads](/slides/nodejs-java/multithreading/). Run separate, isolated instances per thread or process.

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/nodejs-java/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

### Can I digitally sign the PPTX I create?

Yes. [Digital signatures](/slides/nodejs-java/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

### Are macros (VBA) supported in created presentations?

Yes. You can [create/edit VBA projects](/slides/nodejs-java/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
