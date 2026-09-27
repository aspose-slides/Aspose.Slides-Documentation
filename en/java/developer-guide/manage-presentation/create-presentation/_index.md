---
title: Create Presentations in Java
linktitle: Create Presentation
type: docs
weight: 10
url: /java/create-presentation/
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
- Java
- Aspose.Slides
description: "Create presentations in Java with Aspose.Slides—produce PPT, PPTX, and ODP files, benefit from OpenDocument support, and save them programmatically for reliable results."
---

## **Overview**

This article shows how to create a presentation in Aspose.Slides, add a shape with text to its first slide, and save the result as a PPTX file. To open an existing presentation and save it in another format, see [Open Presentations](/slides/java/open-presentation/) and [Save Presentations](/slides/java/save-presentation/). A short FAQ at the end covers common questions about formats, templates, slide sizing, units, memory usage, threading, licensing, digital signatures, and VBA support.

Before you begin, add Aspose.Slides for Java to your project from Aspose's Maven repository. See [Installation](/slides/java/installation/) for the Maven setup and for what Linux needs in addition.

## **Create a Presentation**

Creating a PowerPoint file from scratch in Aspose.Slides for Java starts with an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class. The constructor supplies a blank presentation with a single slide, ready for shapes, text, charts, or any other content your application needs. Once you modify that slide, or add new ones, you can save the result to PPTX, legacy PPT, or OpenDocument formats.

To create a presentation and put a shape with text on its first slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class. A new presentation already contains one empty slide.
1. Get that slide by its index, 0, from the collection that [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) returns.
1. Add an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) of the `Cloud` type with the [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) method, and set its text with [setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-).
1. Save the presentation as a PPTX file with the [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) method.

The example below is a complete program. In the Maven project from [Installation](/slides/java/installation/), save it as *src/main/java/HelloSlides.java* and run `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Create a presentation. It already contains one empty slide.
        Presentation presentation = new Presentation();
        try {
            // Get the first slide.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Add a cloud shape and put text in it.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Save the presentation as a PPTX file.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

The cloud's top-left corner is 20 points from the left edge and 20 points from the top edge of the slide, and the shape is 200 points wide and 80 points high. The program saves *new_presentation.pptx* with one slide that holds the cloud and its text. Without a license, Aspose.Slides also adds an evaluation watermark to every slide it saves; see [Licensing](/slides/java/licensing/).

The result:

![The new presentation](new_presentation.png)

## **FAQ**

### What formats can I save a new presentation to?

You can save to [PPTX, PPT, and ODP](/slides/java/save-presentation/), and export to [PDF](/slides/java/convert-powerpoint-to-pdf/), [XPS](/slides/java/convert-powerpoint-to-xps/), [HTML](/slides/java/convert-powerpoint-to-html/), [SVG](/slides/java/render-a-slide-as-an-svg-image/), and [images](/slides/java/convert-powerpoint-to-png/), among others.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/java/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

Set the [slide size](/slides/java/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

### In what units are sizes and coordinates measured?

In points: 1 inch equals 72 units.

### How do I handle very large presentations (with many media files) to reduce memory usage?

Use [BLOB management strategies](/slides/java/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

### Can I create/save presentations in parallel?

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance from [multiple threads](/slides/java/multithreading/). Run separate, isolated instances per thread or process.

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/java/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

### Can I digitally sign the PPTX I create?

Yes. [Digital signatures](/slides/java/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

### Are macros (VBA) supported in created presentations?

Yes. You can [create/edit VBA projects](/slides/java/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
