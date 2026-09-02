---
title: การดำเนินการพรีเซนเทชันแบบ Low-Code ใน C++
linktitle: API Low-Code
type: docs
weight: 50
url: /th/cpp/low-code-presentation-operations/
keywords:
- API พรีเซนเทชัน Low-Code
- แปลงพรีเซนเทชัน
- รวมพรีเซนเทชัน
- วนซ้ำสไลด์
- วนซ้ำรูปร่าง
- วนซ้ำข้อความ
- เก็บรวบรวมรูปร่าง
- บีบอัดพรีเซนเทชัน
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ที่ฝังไว้
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน C++ เพื่อแปลงและรวมพรีเซนเทชัน, วนซ้ำเนื้อหา, เก็บรวบรวมรูปร่าง, และลดขนาดพรีเซนเทชัน."
---
## **ภาพรวม**

The [Aspose::Slides::LowCode](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/th/cpp/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| ตัวช่วย | การใช้ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/convert/) | แปลงพรีเซนเทชันเป็นรูปแบบอื่นด้วยการเรียกไฟล์ต่อไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/merger/) | รวมไฟล์พรีเซนเทชันเต็มรูปแบบที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/) | ดำเนินการทำงานสำหรับแต่ละสไลด์, รูปร่าง, ย่อหน้า หรือส่วนของข้อความ |
| [Collect](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/collect/) | ดึงรูปร่างจากพรีเซนเทชันทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) | ลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังไว้ |

## **แปลงพรีเซนเทชัน**

Use [Convert::AutoByExtension](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

The [Convert](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [แปลงพรีเซนเทชัน](/slides/th/cpp/convert-presentation/) for format-specific workflows and options.

## **รวมพรีเซนเทชัน**

Use [Merger::Process](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [รวมพรีเซนเทชัน](/slides/th/cpp/merge-presentation/) for those scenarios.

## **วนรอบผ่านองค์ประกอบพรีเซนเทชัน**

The [ForEach](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach::Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/paragraph/), and [ForEach::Portion](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

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

## **เก็บรวบรวมรูปร่าง**

Use [Collect::Shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach::Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **บีบอัดเนื้อหาพรีเซนเทชัน**

The [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/th/cpp/slide-master/) and [Embedded Font](/slides/th/cpp/embedded-font/).

## **FAQ**

**เมื่อใดที่ฉันควรใช้ Low-code API แทนโมเดลอ็อบเจกต์เต็ม?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger สามารถรวมพรีเซนเทชันที่มีรูปแบบไฟล์ต่างกันได้หรือไม่?**

No. [Merger::Process](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert::AutoByExtension](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/convert/autobyextension/), and then merge the converted files.

**ForEach ประมวลผลมาสเตอร์, เลย์เอาต์, และสไลด์โน้ตหรือไม่?**

[ForEach::Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/slide/) iterates through normal presentation slides. Presentation-wide [ForEach::Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/paragraph/), and [ForEach::Portion](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/portion/) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**ความแตกต่างระหว่าง ForEach::Shape กับ Collect::Shapes คืออะไร?**

Use [ForEach::Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/shape/) to process each shape immediately through a callback. Use [Collect::Shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/collect/shapes/) when you need an enumerable result that can be retained, filtered, counted, or traversed multiple times.

**Compress ทำให้ไฟล์พรีเซนเทชันเล็กลงเสมอหรือไม่?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) operations may not reduce the file size.

**การเปลี่ยนแปลงโดย ForEach หรือ Compress จะถูกบันทึกโดยอัตโนมัติหรือไม่?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/) callback or running [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/), call [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) to write the result.

## **บทความที่เกี่ยวข้อง**

- [แปลงพรีเซนเทชัน](/slides/th/cpp/convert-presentation/)
- [รวมพรีเซนเทชัน](/slides/th/cpp/merge-presentation/)
- [Slide Master](/slides/th/cpp/slide-master/)
- [Manage Text Box](/slides/th/cpp/manage-textbox/)
- [Embedded Font](/slides/th/cpp/embedded-font/)