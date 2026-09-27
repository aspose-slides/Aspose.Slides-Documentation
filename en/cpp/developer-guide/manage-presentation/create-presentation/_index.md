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

## **Overview**

This article shows how to create a presentation in Aspose.Slides, add a text box to its first slide, and save the result as a file. A short FAQ at the end covers common questions about formats, templates, slide sizing, units, memory usage, threading, licensing, digital signatures, and VBA support.

Before you begin, add Aspose.Slides to your project: from NuGet in a Visual Studio project on Windows, or from the ZIP package with CMake on Linux. See [Installation](/slides/cpp/installation/).

## **Create a PowerPoint Presentation**

To create a presentation and put a text box on its first slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class. A new presentation already contains one empty slide.
1. Get that slide with the [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) method and its index, 0.
1. Add a rectangle with the [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) method, and set its text with the [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/) method.
1. Save the presentation as a PPTX file with the [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

The rectangle's top-left corner is 50 points from the left edge and 50 points from the top edge of the slide, and the rectangle is 400 points wide and 100 points high. The program saves *hello.pptx* in its working directory, with one slide that holds the rectangle and its text. Without a license, Aspose.Slides also adds an evaluation watermark to every slide it saves; see [Licensing](/slides/cpp/licensing/).

## **FAQ**

### What formats can I save a new presentation to?

You can save to [PPTX, PPT, and ODP](/slides/cpp/save-presentation/), and export to [PDF](/slides/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/cpp/convert-powerpoint-to-xps/), [HTML](/slides/cpp/convert-powerpoint-to-html/), [SVG](/slides/cpp/render-a-slide-as-an-svg-image/), and [images](/slides/cpp/convert-powerpoint-to-png/), among others.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/cpp/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

Set the [slide size](/slides/cpp/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

### In what units are sizes and coordinates measured?

In points: 1 inch equals 72 units.

### How do I handle very large presentations (with many media files) to reduce memory usage?

Use [BLOB management strategies](/slides/cpp/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

### Can I create/save presentations in parallel?

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) instance from [multiple threads](/slides/cpp/multithreading/). Run separate, isolated instances per thread or process.

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/cpp/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

### Can I digitally sign the PPTX I create?

Yes. [Digital signatures](/slides/cpp/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

### Are macros (VBA) supported in created presentations?

Yes. You can [create/edit VBA projects](/slides/cpp/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
