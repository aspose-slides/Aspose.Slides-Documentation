---
title: Low-Code Presentation Operations in C++
linktitle: Low-Code API
type: docs
weight: 50
url: /cpp/low-code-presentation-operations/
keywords:
- low-code presentation API
- convert presentation
- merge presentations
- iterate slides
- iterate shapes
- iterate text
- collect shapes
- compress presentation
- remove unused master slides
- remove unused layout slides
- compress embedded fonts
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Use the Aspose.Slides low-code API in C++ to convert and merge presentations, iterate through content, collect shapes, and reduce presentation size."
---

## **Overview**

The [Aspose::Slides::LowCode](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/cpp/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/convert/) | Converting a presentation to another format with a direct file-to-file call. |
| [Merger](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/merger/) | Combining complete presentation files of the same format. |
| [ForEach](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/) | Running an action for every slide, shape, paragraph, or text portion. |
| [Collect](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/collect/) | Retrieving shapes from the entire presentation for repeated processing or analysis. |
| [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) | Removing unused masters and layouts and reducing embedded font data. |

## **Convert a Presentation**

Use [Convert::AutoByExtension](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

The [Convert](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/cpp/convert-presentation/) for format-specific workflows and options.

## **Merge Presentations**

Use [Merger::Process](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/cpp/merge-presentation/) for those scenarios.

## **Iterate Through Presentation Elements**

The [ForEach](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach::Slide](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/paragraph/), and [ForEach::Portion](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **Collect Shapes**

Use [Collect::Shapes](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Use [ForEach::Shape](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Compress Presentation Content**

The [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/cpp/slide-master/) and [Embedded Font](/slides/cpp/embedded-font/).

## **FAQ**

**When should I use the low-code API instead of the full object model?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Can Merger combine presentations in different file formats?**

No. [Merger::Process](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert::AutoByExtension](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/convert/autobyextension/), and then merge the converted files.

**Does ForEach process master, layout, and notes slides?**

[ForEach::Slide](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/slide/) iterates through normal presentation slides. Presentation-wide [ForEach::Shape](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/paragraph/), and [ForEach::Portion](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/portion/) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**What is the difference between ForEach::Shape and Collect::Shapes?**

Use [ForEach::Shape](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/shape/) to process each shape immediately through a callback. Use [Collect::Shapes](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/collect/shapes/) when you need an enumerable result that can be retained, filtered, counted, or traversed multiple times.

**Does Compress always make the presentation file smaller?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) operations may not reduce the file size.

**Are changes made by ForEach or Compress saved automatically?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/foreach/) callback or running [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/), call [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) to write the result.

## **Related Articles**

- [Convert Presentation](/slides/cpp/convert-presentation/)
- [Merge Presentations](/slides/cpp/merge-presentation/)
- [Slide Master](/slides/cpp/slide-master/)
- [Manage Text Box](/slides/cpp/manage-textbox/)
- [Embedded Font](/slides/cpp/embedded-font/)
