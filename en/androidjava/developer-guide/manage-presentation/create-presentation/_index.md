---
title: Create Presentations on Android
linktitle: Create Presentation
type: docs
weight: 10
url: /androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Create presentations in Java with Aspose.Slides for Android—produce PPT, PPTX, and ODP files, benefit from OpenDocument support, and save them programmatically for reliable results."
---

## **Overview**

This article shows how to create a presentation in Aspose.Slides for Android via Java, add a text box to its first slide, and save the result as a file in your app's storage. To open an existing presentation or save it in another format, see [Open Presentation](/slides/androidjava/open-presentation/) and [Save Presentation](/slides/androidjava/save-presentation/). A short FAQ at the end covers common questions about formats, templates, slide sizing, units, memory usage, threading, licensing, digital signatures, and VBA support.

Before you begin, add Aspose.Slides to your Android project from Aspose's Maven repository. See [Installation](/slides/androidjava/install-aspose-slides-for-android-via-java/).

## **Create a PowerPoint Presentation**

To create a presentation and put a text box on its first slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class. A new presentation already contains one empty slide.
1. Get that slide from the [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) by its index, 0.
1. Add a rectangle with the [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) method of the [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) and set the text of its [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) with the [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) method.
1. Save the presentation as a PPTX file with the [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) method, in the [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/) format.

The code runs inside an `Activity`, for example in its `onCreate` method. It saves the file to the directory returned by the [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) method: your app's private storage, which it can write to without requesting any permission.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The rectangle's top-left corner is 50 points from the left edge and 50 points from the top edge of the slide, and the rectangle is 400 points wide and 100 points high. The saved file contains one slide with that rectangle and its text. Without a license, Aspose.Slides also adds an evaluation watermark to every slide it saves; see [Licensing](/slides/androidjava/licensing/).

To look at the file, open Android Studio's [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) and find *hello.pptx* under *data/data/*, in the *files* folder of your app. In a real app, process presentations on a background thread so that the user interface stays responsive.

## **FAQ**

### What formats can I save a new presentation to?

You can save to [PPTX, PPT, and ODP](/slides/androidjava/save-presentation/), and export to [PDF](/slides/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/androidjava/convert-powerpoint-to-html/), [SVG](/slides/androidjava/render-a-slide-as-an-svg-image/), and [images](/slides/androidjava/convert-powerpoint-to-png/), among others.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/androidjava/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

Set the [slide size](/slides/androidjava/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

### In what units are sizes and coordinates measured?

In points: 1 inch equals 72 units.

### How do I handle very large presentations (with many media files) to reduce memory usage?

Use [BLOB management strategies](/slides/androidjava/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

### Can I create/save presentations in parallel?

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) instance from [multiple threads](/slides/androidjava/multithreading/). Run separate, isolated instances per thread or process.

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/androidjava/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

### Can I digitally sign the PPTX I create?

Yes. [Digital signatures](/slides/androidjava/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

### Are macros (VBA) supported in created presentations?

Yes. You can [create/edit VBA projects](/slides/androidjava/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
