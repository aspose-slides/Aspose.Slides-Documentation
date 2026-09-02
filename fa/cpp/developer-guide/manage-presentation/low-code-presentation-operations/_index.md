---
title: عملیات ارائه با کد-کم در C++
linktitle: API کد-کم
type: docs
weight: 50
url: /fa/cpp/low-code-presentation-operations/
keywords:
- API ارائه کد-کم
- تبدیل ارائه
- ترکیب ارائه‌ها
- پیمایش اسلایدها
- پیمایش اشکال
- پیمایش متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف اسلایدهای الگوی بلااستفاده
- حذف اسلایدهای چیدمان بلااستفاده
- فشرده‌سازی فونت‌های تعبیه‌شده
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "از API کد-کم Aspose.Slides در C++ برای تبدیل و ترکیب ارائه‌ها، پیمایش محتوا، جمع‌آوری اشکال و کاهش حجم ارائه استفاده کنید."
---
## **بررسی کلی**

فضای نام [Aspose::Slides::LowCode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/) کلاس‌های کمکی استاتیک برای عملیات متداول ارائه فراهم می‌کند. این کمکی‌ها جریان‌های کاری مدلسازی شیء را که به‌صورت مکرر استفاده می‌شوند، در روش‌های متمرکز بسته‌بندی می‌کنند، بنابراین می‌توانید فایل‌ها را تبدیل یا ترکیب کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای بلااستفاده را با کد کمتر حذف کنید.

کمک‌کننده‌های کد‑کم زمانی مفید هستند که عملیات بر روی یک فایل یا ارائه کامل اعمال می‌شود و گردش کار پیش‌فرض با نیازهای شما همخوانی دارد. هنگامی که به کنترل دقیق بر اسلایدهای فردی، الگوها، چیدمان‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه نیاز دارید، از مدل شیء کامل [Aspose.Slides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/) استفاده کنید.

جدول زیر خلاصه‌ای از کمک‌کننده‌های موجود را ارائه می‌دهد:

| کمک‌کننده | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/convert/) | تبدیل ارائه به قالب دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/merger/) | ترکیب کامل فایل‌های ارائه‌ای با همان قالب. |
| [ForEach](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/) | اجرای یک عمل برای هر اسلاید، شکل، پاراگراف یا بخش متنی. |
| [Collect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/collect/) | بازیابی اشکال از کل ارائه برای پردازش یا تجزیه و تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) | حذف الگوها و چیدمان‌های بلااستفاده و کاهش داده‌های فونت تعبیه‌شده. |

## **تبدیل یک ارائه**

از [Convert::AutoByExtension](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/convert/autobyextension/) استفاده کنید وقتی پسوند فایل خروجی به‌تنهایی کافی باشد تا قالب خروجی را انتخاب کند. این متد ارائه منبع را باز می‌کند، قالب مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/convert/) همچنین روش‌های اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF ارائه می‌دهد. هنگامی که قبل از خروجی بررسی یا تغییر ارائه لازم است یا گزینهٔ خروجی‌ای که توسط کمک‌کننده در دسترس نیست را پیکربندی می‌کنید، از مدل شیء کامل استفاده کنید. برای گردش کارها و گزینه‌های خاص هر قالب، به بخش [تبدیل ارائه](/slides/fa/cpp/convert-presentation/) مراجعه کنید.

## **ترکیب ارائه‌ها**

از [Merger::Process](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/merger/process/) برای ترکیب کامل فایل‌های ارائه‌ای با یک فراخوانی استفاده کنید. ارائه‌های ورودی باید همان قالب فایل را داشته باشند.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

این کمک‌کننده زمانی مناسب است که تمام اسلایدها باید بدون انتخاب یا بازنگری جداگانه به یک نتیجهٔ نهایی اضافه شوند. هنگامی که نیاز به ترکیب اسلایدهای منتخب، اعمال الگوی مقصد یا چیدمان، حفظ بخش‌ها به‌صورت صریح یا تطبیق اندازه‌های مختلف اسلاید دارید، از مدل شیء کامل استفاده کنید. برای این سناریوها به بخش [ترکیب ارائه‌ها](/slides/fa/cpp/merge-presentation/) نگاه کنید.

## **پیمایش عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/) برای هر نوع عنصر درخواست‌شده از ارائه یک فراخوانی بازخوردی اجرا می‌کند. این کار از حلقه‌های تو در توی جمع‌آوری جلوگیری می‌کند و برای بازرسی یا تغییر فرمت سراسری ارائه مناسب است.

مثال زیر از [ForEach::Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/slide/)، [ForEach::Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/shape/)، [ForEach::Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/paragraph/) و [ForEach::Portion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/portion/) برای بازرسی عناصر مربوطه استفاده می‌کند:

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

به طور پیش‌فرض، پیمایش شکل‌ها و متن سراسری ارائه شامل اسلایدهای عادی، الگو و چیدمان می‌شود. overloadهایی با پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. وقتی ترتیب پیمایش، خروج زودهنگام، فیلتر قبل از فراخوانی بازخورد یا کنترل دقیق والد‑فرزند مهم باشد، از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

## **جمع‌آوری اشکال**

وقتی به یک مجموعهٔ تمام اشکال موجود در یک ارائه نیاز دارید نه یک بازخورد برای هر شکل، از [Collect::Shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/collect/shapes/) استفاده کنید. این کار زمانی مفید است که همان مجموعه برای فیلتر، شمارش یا پردازش چندبار استفاده شود.

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

اگر می‌توانید هر شکل را بلافاصله پردازش کنید و نیازی به نگه داشتن نتیجهٔ جمع‌آوری‌شده ندارید، به جای آن از [ForEach::Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/shape/) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) می‌تواند عناصر ساختاری بلااستفاده را حذف کرده و داده‌های فونت تعبیه‌شده را کاهش دهد:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) اسلایدهای چیدمان را که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد، حذف می‌کند.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) اسلایدهای الگو را که دیگر استفاده نمی‌شوند، حذف می‌کند.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) کاراکترهای بلااستفاده را از فونت‌های تعبیه‌شده حذف می‌کند.

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

ابتدا چیدمان‌های بلااستفاده را حذف کنید و سپس الگوهای بلااستفاده را؛ به‌طوری‌که الگوی حذف‌شده پس از پاک‌سازی چیدمان‌ها نیز می‌تواند حذف شود. برای ذخیرهٔ ارائهٔ بهینه‌شده در فایلی جدید اقدام کنید اگر ممکن است در آینده به الگوها، چیدمان‌ها یا داده‌های کامل فونت‌های تعبیه‌شدهٔ اصلی نیاز داشته باشید. برای جزئیات بیشتر، به بخش‌های [اسلاید الگو](/slides/fa/cpp/slide-master/) و [فونت تعبیه‌شده](/slides/fa/cpp/embedded-font/) مراجعه کنید.

## **سؤالات متداول**

**چه زمانی باید به‌جای مدل شیء کامل از API کد‑کم استفاده کنم؟**

وقتی یک عملیات استاندارد بر روی یک فایل یا ارائه کامل اعمال می‌شود و نیازی به کنترل دقیق بر عناصر فردی نیست، از کمک‌کننده‌های کد‑کم استفاده کنید. وقتی باید اسلایدهای خاصی را انتخاب کنید، روابط الگو و چیدمان را کنترل کنید، وضعیت میانی را بازرسی کنید یا رفتارهایی را پیکربندی کنید که توسط کمک‌کننده در دسترس نیست، از مدل شیء کامل بهره ببرید.

**آیا Merger می‌تواند ارائه‌ها را با قالب‌های فایل متفاوت ترکیب کند؟**

خیر. [Merger::Process](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/merger/process/) نیاز دارد که ارائه‌های ورودی همگی در یک قالب باشند. ابتدا فایل‌های ورودی را با استفاده از [Convert::AutoByExtension](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/convert/autobyextension/) به قالب مشترک تبدیل کنید و سپس فایل‌های تبدیل‌شده را ترکیب کنید.

**آیا ForEach اسلایدهای الگو، چیدمان و یادداشت‌ها را پردازش می‌کند؟**

[ForEach::Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/slide/) بر اسلایدهای عادی ارائه پیمایش می‌کند. عملیات سراسری [ForEach::Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/shape/)، [ForEach::Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/paragraph/) و [ForEach::Portion](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/portion/) به‌طور پیش‌فرض اسلایدهای عادی، الگو و چیدمان را شامل می‌شوند. برای شامل کردن اسلایدهای یادداشت‌ها، overloadهای آن‌ها را با مقدار `includeNotes` برابر `true` فراخوانی کنید.

**تفاوت بین ForEach::Shape و Collect::Shapes چیست؟**

وقتی می‌خواهید هر شکل را بلافاصله از طریق یک بازخورد پردازش کنید، از [ForEach::Shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/shape/) استفاده کنید. وقتی نیاز به نتیجه‌ای قابل پیمایش دارید که بتوان آن را نگه داشت، فیلتر کرد یا چندبار شمارش کرد، از [Collect::Shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/collect/shapes/) بهره ببرید.

**آیا Compress همیشه اندازهٔ فایل ارائه را کوچک می‌کند؟**

لزومی ندارد. نتیجه بستگی دارد به اینکه آیا ارائه شامل چیدمان‌های بلااستفاده، الگوهای بلااستفاده یا فونت‌های تعبیه‌شده با کاراکترهای بلااستفاده باشد یا نه. اگر هیچ‌یک از این موارد موجود نباشد، عملیات‌های مربوط به [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/) ممکن است اندازهٔ فایل را کاهش ندهند.

**آیا تغییرات اعمال‌شده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شوند؟**

خیر. این کمک‌کننده‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری‌شده در حافظه عمل می‌کنند. پس از تغییر عناصر در بازخورد [ForEach](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/)، برای نوشتن نتیجه باید [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) را فراخوانی کنید.

## **مقالات مرتبط**

- [Convert Presentation](/slides/fa/cpp/convert-presentation/)
- [Merge Presentations](/slides/fa/cpp/merge-presentation/)
- [Slide Master](/slides/fa/cpp/slide-master/)
- [Manage Text Box](/slides/fa/cpp/manage-textbox/)
- [Embedded Font](/slides/fa/cpp/embedded-font/)