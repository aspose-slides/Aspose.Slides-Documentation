---
title: Create PowerPoint Presentation in JavaScript
linktitle: Create Presentation
type: docs
weight: 10
url: /nodejs-java/create-presentation/
keywords: create ppt java, create ppt presentation, create pptx java
description: Learn how to create PowerPoint Presentations e.g. PPT, PPTX using JavaScript from scratch.
---

## **Create PowerPoint Presentation**

To add a simple plain line to a selected slide of the presentation, please follow the steps below:

1. Create an instance of Presentation class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Line type using addAutoShape method exposed by Shapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```javascript
// Instantiate a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var slide = pres.getSlides().get_Item(0);
    // Add an autoshape of type line
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**What formats can I save a new presentation to?**

You can save to [PPTX, PPT, and ODP](/slides/nodejs-java/save-presentation/), and export to [PDF](/slides/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/nodejs-java/convert-powerpoint-to-png/), and [images](/slides/nodejs-java/convert-powerpoint-to-png/), among others.

**Can I start from a template (POTX/POTM) and save as a regular PPTX?**

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/nodejs-java/supported-file-formats/).

**How do I control slide size/aspect ratio when creating a presentation?**

Set the [slide size](/slides/nodejs-java/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

**In what units are sizes and coordinates measured?**

In points: 1 inch equals 72 units.

**How do I handle very large presentations (with many media files) to reduce memory usage?**

Use [BLOB management strategies](/slides/nodejs-java/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

**Can I create/save presentations in parallel?**

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) instance from [multiple threads](/slides/nodejs-java/multithreading/). Run separate, isolated instances per thread or process.

**How do I remove the trial watermark and limitations?**

[Apply a license](/slides/nodejs-java/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

**Can I digitally sign the PPTX I create?**

Yes. [Digital signatures](/slides/nodejs-java/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

**Are macros (VBA) supported in created presentations?**

Yes. You can [create/edit VBA projects](/slides/nodejs-java/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
