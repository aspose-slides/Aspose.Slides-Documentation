---
title: Create Presentations in .NET
linktitle: Create Presentation
type: docs
weight: 10
url: /net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Create presentations in .NET with Aspose.Slides—produce PPT, PPTX, and ODP files, benefit from OpenDocument support, and save them programmatically for reliable results."
---

## **Overview**

This article shows how to create a presentation in Aspose.Slides, add a text box to its first slide, and save the result as a file. It also shows how to create and save an empty presentation, and how to open an existing presentation in a supported format and save it in another format. A short FAQ at the end covers common questions about formats, templates, slide sizing, units, memory usage, threading, licensing, digital signatures, and VBA support.

Before you begin, add Aspose.Slides to your project from NuGet. See [Installation](/slides/net/installation/) for the package to use on Windows, Linux, and macOS.

## **Create a PowerPoint Presentation**

To create a presentation and put a text box on its first slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. A new presentation already contains one empty slide.
1. Get that slide from the [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection by its index, 0.
1. Add a rectangle with the [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) method and set its [text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/).
1. Save the presentation as a PPTX file with the [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

The rectangle's top-left corner is 50 points from the left edge and 50 points from the top edge of the slide, and the rectangle is 400 points wide and 100 points high. The saved file contains one slide with that rectangle and its text. Without a license, Aspose.Slides also adds an evaluation watermark to every slide it saves; see [Licensing](/slides/net/licensing/).

## **Create and Save a Presentation**

<a name="csharp-create-save-presentation"></a>

To create an empty presentation and save it, create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and save it in any format of the [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) enumeration. The result is a presentation with one empty slide.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Open and Save a Presentation**

<a name="csharp-open-save-presentation"></a>

To convert a presentation from one format to another, open it by passing its path to the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) constructor, then save it in the target format. Aspose.Slides detects the input format, such as PPT, PPTX, or ODP, from the file itself.

The example below expects an OpenDocument presentation named *Sample.odp* in the working directory and saves it as PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### What formats can I save a new presentation to?

You can save to [PPTX, PPT, and ODP](/slides/net/save-presentation/), and export to [PDF](/slides/net/convert-powerpoint-to-pdf/), [XPS](/slides/net/convert-powerpoint-to-xps/), [HTML](/slides/net/convert-powerpoint-to-html/), [SVG](/slides/net/render-a-slide-as-an-svg-image/), and [images](/slides/net/convert-powerpoint-to-png/), among others.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/net/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

Set the [slide size](/slides/net/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

### In what units are sizes and coordinates measured?

In points: 1 inch equals 72 units.

### How do I handle very large presentations (with many media files) to reduce memory usage?

Use [BLOB management strategies](/slides/net/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

### Can I create/save presentations in parallel?

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance from [multiple threads](/slides/net/multithreading/). Run separate, isolated instances per thread or process.

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/net/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

### Can I digitally sign the PPTX I create?

Yes. [Digital signatures](/slides/net/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

### Are macros (VBA) supported in created presentations?

Yes. You can [create/edit VBA projects](/slides/net/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
