---
title: Create Presentations in C++
linktitle: Create Presentation
type: docs
weight: 10
url: /cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "Create presentations in C++ with Aspose.Slides—produce PPT, PPTX, and ODP files, benefit from OpenDocument support, and save them programmatically for reliable results."
---

## **Create a PowerPoint Presentation**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Line type using the AddAutoShape method exposed by Shapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**What formats can I save a new presentation to?**

You can save to [PPTX, PPT, and ODP](/slides/cpp/save-presentation/), and export to [PDF](/slides/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/cpp/convert-powerpoint-to-xps/), [HTML](/slides/cpp/convert-powerpoint-to-html/), [SVG](/slides/cpp/convert-powerpoint-to-png/), and [images](/slides/cpp/convert-powerpoint-to-png/), among others.

**Can I start from a template (POTX/POTM) and save as a regular PPTX?**

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/cpp/supported-file-formats/).

**How do I control slide size/aspect ratio when creating a presentation?**

Set the [slide size](/slides/cpp/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

**In what units are sizes and coordinates measured?**

In points: 1 inch equals 72 units.

**How do I handle very large presentations (with many media files) to reduce memory usage?**

Use [BLOB management strategies](/slides/cpp/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

**Can I create/save presentations in parallel?**

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance from [multiple threads](/slides/cpp/multithreading/). Run separate, isolated instances per thread or process.

**How do I remove the trial watermark and limitations?**

[Apply a license](/slides/cpp/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

**Can I digitally sign the PPTX I create?**

Yes. [Digital signatures](/slides/cpp/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

**Are macros (VBA) supported in created presentations?**

Yes. You can [create/edit VBA projects](/slides/cpp/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
