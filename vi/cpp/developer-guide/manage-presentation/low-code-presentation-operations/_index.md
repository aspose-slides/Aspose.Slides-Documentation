---
title: Các thao tác trình chiếu low-code trong C++
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/cpp/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- duyệt qua các slide
- duyệt qua các shape
- duyệt qua văn bản
- thu thập shape
- nén trình chiếu
- xóa master slide không dùng
- xóa layout slide không dùng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- C++
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trong C++ để chuyển đổi và hợp nhất các trình chiếu, duyệt qua nội dung, thu thập shape và giảm kích thước của trình chiếu."
---
## **Tổng quan**

The [Aspose::Slides::LowCode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/vi/cpp/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Trợ giúp | Sử dụng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/convert/) | Chuyển đổi một bản trình chiếu sang định dạng khác bằng lời gọi trực tiếp file‑to‑file. |
| [Merger](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/merger/) | Kết hợp các tệp bản trình chiếu hoàn chỉnh cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/) | Thực hiện một hành động cho mỗi slide, shape, đoạn văn hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/collect/) | Lấy các shape từ toàn bộ bản trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/) | Xóa các master và layout không dùng và giảm dữ liệu phông chữ nhúng. |

## **Chuyển đổi một bản trình chiếu**

Use [Convert::AutoByExtension](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

The [Convert](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/cpp/convert-presentation/) for format-specific workflows and options.

## **Hợp nhất các bản trình chiếu**

Use [Merger::Process](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/cpp/merge-presentation/) for those scenarios.

## **Duyệt qua các phần tử trình chiếu**

The [ForEach](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach::Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/paragraph/), and [ForEach::Portion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

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

## **Thu thập Shapes**

Use [Collect::Shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach::Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Nén nội dung bản trình chiếu**

The [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/cpp/slide-master/) and [Embedded Font](/cpp/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng API low-code thay vì mô hình đối tượng đầy đủ?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger có thể kết hợp các bản trình chiếu ở các định dạng tệp khác nhau không?**

No. [Merger::Process](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert::AutoByExtension](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/convert/autobyextension/), and then merge the converted files.

**ForEach có xử lý các slide master, layout và ghi chú không?**

[ForEach::Slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/slide/) duyệt qua các slide trình chiếu bình thường. Các thao tác [ForEach::Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/paragraph/), và [ForEach::Portion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/portion/) trên toàn bộ bản trình chiếu bao gồm các slide bình thường, master và layout theo mặc định. Sử dụng các overload của chúng với `includeNotes` được đặt thành `true` để bao gồm các slide ghi chú.

**Sự khác biệt giữa ForEach::Shape và Collect::Shapes là gì?**

Use [ForEach::Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/shape/) to process each shape immediately through a callback. Use [Collect::Shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/collect/shapes/) when you need an enumerable result that can be retained, filtered, counted, or traversed multiple times.

**Compress luôn làm tệp bản trình chiếu nhỏ hơn không?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/) operations may not reduce the file size.

**Các thay đổi do ForEach hoặc Compress thực hiện có được lưu tự động không?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/foreach/) callback or running [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/), call [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) to write the result.

## **Bài viết liên quan**

- [Chuyển đổi bản trình chiếu](/cpp/convert-presentation/)
- [Hợp nhất các bản trình chiếu](/cpp/merge-presentation/)
- [Master slide](/cpp/slide-master/)
- [Quản lý hộp văn bản](/cpp/manage-textbox/)
- [Phông chữ nhúng](/cpp/embedded-font/)