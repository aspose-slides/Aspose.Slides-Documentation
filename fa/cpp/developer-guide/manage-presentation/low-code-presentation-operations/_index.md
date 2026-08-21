---
title: عملیات ارائه کم‌کد در C++
linktitle: API کم‌کد
type: docs
weight: 50
url: /fa/cpp/low-code-presentation-operations/
keywords:
- API ارائه کم‌کد
- تبدیل ارائه
- ادغام ارائه‌ها
- تکرار اسلایدها
- تکرار اشکال
- تکرار متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف مسترهای استفاده‌نشده
- حذف لایه‌های استفاده‌نشده
- فشرده‌سازی فونت‌های توکار
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "از API کم‌کد Aspose.Slides در C++ برای تبدیل و ادغام ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش حجم ارائه استفاده کنید."
---
## **بررسی کلی**

The [Aspose::Slides::LowCode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/fa/cpp/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/convert/) | تبدیل یک ارائه به قالبی دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/merger/) | ترکیب کامل فایل‌های ارائه با فرمت یکسان. |
| [ForEach](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/) | اجرای یک عمل برای هر اسلاید، شکل، پاراگراف یا بخش متنی. |
| [Collect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/collect/) | استخراج اشکال از کل ارائه برای پردازش یا تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) | حذف مسترها و لایه‌های استفاده‌نشده و کاهش داده‌های فونت‌های توکار. |

## **تبدیل یک ارائه**

Use [Convert::AutoByExtension](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

The [Convert](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/cpp/convert-presentation/) for format-specific workflows and options.

## **ادغام ارائه‌ها**

Use [Merger::Process](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/cpp/merge-presentation/) for those scenarios.

## **تکرار در عناصر ارائه**

The [ForEach](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach::Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/paragraph/), and [ForEach::Portion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

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

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent‑child control is important.

## **جمع‌آوری اشکال**

Use [Collect::Shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach::Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **فشرده‌سازی محتوای ارائه**

The [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

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

## **سوالات متداول**

**چه زمانی باید به جای استفاده از مدل کامل شیء، از API کم‌کد استفاده کنم؟**

از راهنماهای کم‌کد زمانی استفاده کنید که یک عملیات استاندارد بر روی یک فایل یا ارائه کامل اعمال می‌شود و نیازی به کنترل دقیق بر عناصر تک‌تک نیست. وقتی نیاز به انتخاب اسلایدهای خاص، کنترل روابط مستر و لایه، بازرسی وضعیت میانی یا پیکربندی رفتاری که راهنما آن را در اختیار نمی‌گذارد، از مدل کامل شیء استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را با فرمت‌های متفاوت ترکیب کند؟**

خیر. [Merger::Process](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/merger/process/) نیاز دارد که ورودی‌ها در همان فرمت باشند. ابتدا فایل‌های ورودی را با روش‌هایی نظیر [Convert::AutoByExtension](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/convert/autobyextension/) به فرمت مشترک تبدیل کنید و سپس فایل‌های تبدیل‌شده را ادغام کنید.

**آیا ForEach مستر، لایه و اسلایدهای یادداشت را پردازش می‌کند؟**

[ForEach::Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/slide/) فقط بر اسلایدهای معمولی ارائه پیمایش می‌کند. عملیات‌های سطح‑کل مانند [ForEach::Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/shape/)، [ForEach::Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/paragraph/) و [ForEach::Portion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/portion/) به‌طور پیش‌فرض شامل اسلایدهای معمولی، مستر و لایه هستند. برای شامل کردن اسلایدهای یادداشت از overloadهای آنها با `includeNotes` برابر `true` استفاده کنید.

**فرق بین ForEach::Shape و Collect::Shapes چیست؟**

از [ForEach::Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/shape/) برای پردازش فوری هر شکل از طریق یک callback استفاده کنید. وقتی به یک مجموعه قابل تکرار نیاز دارید که بتوان آن را نگه‌دارید، فیلتر کرد، شمارش یا چند بار مرور کرد، از [Collect::Shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/collect/shapes/) بهره ببرید.

**آیا Compress همیشه اندازه فایل ارائه را کوچک می‌کند؟**

لزومی نیست. نتیجه به این بستگی دارد که آیا در ارائه لایه‌ها یا مسترهای استفاده‌نشده یا فونت‌های توکار با کاراکترهای استفاده‌نشده وجود دارد یا خیر. در صورت عدم وجود این موارد، عملیات‌های مربوطه ممکن است اندازه فایل را کاهش ندهند.

**آیا تغییرات انجام‌شده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شود؟**

خیر. این راهنماها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) در حافظه عمل می‌کنند. پس از اعمال تغییرات در یک callback از [ForEach](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/)، برای نوشتن نتیجه باید [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) را صدا بزنید.

## **مقالات مرتبط**

- [Convert Presentation](/cpp/convert-presentation/)
- [Merge Presentations](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)