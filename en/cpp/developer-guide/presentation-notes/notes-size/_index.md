---
title: Change Notes Page Size and Orientation in C++
linktitle: Notes Page Size
type: docs
weight: 10
url: /cpp/notes-size/
keywords:
- notes page size
- notes orientation
- landscape notes
- portrait notes
- handout size
- PowerPoint
- presentation
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Read and change notes page dimensions in Aspose.Slides for C++, switch orientation, verify saved sizes, and export notes or handouts to PDF and images."
---

## **Overview**

Use [Presentation::get_NotesSize](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_notessize/) to access the presentation's notes page settings. It returns an [INotesSize](https://reference.aspose.com/slides/cpp/aspose.slides/inotessize/) object whose [set_Size](https://reference.aspose.com/slides/cpp/aspose.slides/inotessize/set_size/) method sets the dimensions. Although the notes settings object cannot be replaced, you can change its size.

Width and height are specified in **points**, with 72 points per inch. For example, 900 × 600 points is 12.5 × 8⅓ inches. These settings apply to the presentation, rather than to an individual slide's notes.

| Setting | Purpose |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_notessize/) | Controls notes page dimensions and the page dimensions used for handout export. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slidesize/) | Controls regular presentation slide dimensions through [ISlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/). |

Changing either setting does not automatically change the other. Changing the notes page orientation also does not rotate the regular slides. See [Slide Size](/slides/cpp/slide-size/) to resize regular slides.

The examples below use an existing `sample.pptx`. For the export examples, use a presentation with at least one slide containing speaker notes. Each example can be run independently.

## **Read the Notes Page Size and Orientation**

Read the width and height and compare them to determine the orientation: a wider page is landscape, a taller page is portrait, and equal dimensions describe a square page. This example prints the actual dimensions in points, without assuming a standard paper size.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Switch to Landscape Without Changing the Paper Size**

To change only the orientation, swap the existing width and height. This preserves the lengths of both sides, including those of a custom paper size. The condition below prevents an already-landscape page from being switched back to portrait and leaves a square page unchanged.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

For portrait orientation, use the same assignment when `size.get_Width() > size.get_Height()`. Do not substitute A4 or Letter dimensions unless you also want to change the paper size.

## **Set and Verify a Custom Notes Page Size**

Assign both dimensions together, then use [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) to write the presentation. This example sets a 900 × 600-point landscape page, saves it as PPTX, and opens the saved file again to check the persisted values. The comparison allows a 0.01-point tolerance for floating-point values; it is not a guarantee of precision for every file format.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

The expected result is `900 x 600 points` and `Size preserved: True`. Checking a newly opened presentation verifies the saved file, rather than only the in-memory settings.

## **Export Notes and Handouts**

The page dimensions define the available area for notes or handout layouts. They do not enable those layouts by themselves: configure the export options as well. Regular slide export continues to use the slide dimensions.

### **Export Notes to PDF and PNG**

Assign [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) to [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) to include notes in the PDF. This example also renders the first slide with notes to PNG using [Slide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/slide/getimage/) and [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/).

The [BottomTruncated](https://reference.aspose.com/slides/cpp/aspose.slides.export/notespositions/) mode keeps the notes on one page; notes that do not fit can be truncated. The PDF uses 900 × 600-point pages. At the image scale of 1 × 1 used below, the PNG is 900 × 600 pixels. Points describe the page geometry; pixels describe the raster output, whose dimensions also depend on the rendering scale.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

For PDF export with long notes, [BottomFull](https://reference.aspose.com/slides/cpp/aspose.slides.export/notespositions/) allows additional pages as needed. Do not use that mode with the single-slide image call above, which does not support it. After resizing, inspect the output for clipped notes and the placement of existing notes-master objects; changing page dimensions alone should not be treated as a guarantee that all content will fit. See [Convert PowerPoint to PDF with Notes](/slides/cpp/convert-powerpoint-to-pdf-with-notes/) for more about notes export.

### **Export Handouts to PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/) for multiple slide thumbnails on one page. The following example sets a 900 × 600-point page and uses [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) to arrange up to four slides per page. The horizontal preset controls slide ordering; the page orientation comes from its width and height.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Changing the page size changes the area available for the handout grid without changing the source slides' dimensions. For handout images, use [Presentation::GetImages](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getimages/) with the handout layout, rather than an individual slide's image method. In Aspose.Slides, presentation-level handout rendering uses the notes page dimensions, while the individual slide image call does not produce the handout page. See [Handout Mode](/slides/cpp/convert-powerpoint-in-handout-mode/) for layout options.

## **Page Size in Viewers, Export, and Printing**

Keep the stored presentation size, the exported page size, and the printed paper size distinct:

- **Presentation viewers:** A viewer can display or print notes using its own layout rules. If another application saves the file, reopen it and check the dimensions again; that application's format conversion may normalize them.
- **Export formats:** The notes and handout PDF examples above use the configured page dimensions. Raster images use integer pixel dimensions and a rendering scale, so fractional point values can be rounded in the image output. Exporting regular slides does not apply the notes page size.
- **Printer drivers:** Paper selection, automatic rotation, and fit-to-page settings can change the physical output without changing the dimensions stored in the presentation or PDF. For a specific paper size, match the printer settings and inspect the print preview.

## **FAQ**

**Can I set the notes size for just one slide?**

The notes page size is a presentation-level setting. Individual slides can have different notes content, but this property does not provide a separate page size for each slide.

**Why did changing notes orientation not change my slides?**

Notes pages and regular slides have independent dimensions. Use the regular slide size settings when you want to resize the slides themselves.

**Why does my saved or printed result have a different size?**

First reopen the saved presentation and compare its notes dimensions. If those changed, check whether saving or converting the file in another application changed the page settings. If they did not, check the export layout, image scale, viewer settings, and printer paper selection.
