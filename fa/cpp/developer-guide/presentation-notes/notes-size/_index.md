---
title: تغییر اندازه و جهت صفحه یادداشت‌ها در C++
linktitle: اندازه صفحه یادداشت‌ها
type: docs
weight: 10
url: /fa/cpp/notes-size/
keywords:
- اندازه صفحه یادداشت
- جهت یادداشت
- یادداشت‌های افقی
- یادداشت‌های عمودی
- اندازه جزوه
- PowerPoint
- ارائه
- PPT
- PPTX
- C++
- Aspose.Slides
description: "در Aspose.Slides برای C++ ابعاد صفحه یادداشت‌ها را بخوانید و تغییر دهید، جهت را تغییر دهید، اندازه‌های ذخیره‌شده را تأیید کنید و یادداشت‌ها یا جزوه‌ها را به PDF و تصاویر صادر کنید."
---
## **مروری کلی**

از [Presentation::get_NotesSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_notessize/) برای دسترسی به تنظیمات صفحه یادداشت‌های ارائه استفاده کنید. این متد یک شیء [INotesSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inotessize/) را بر می‌گرداند که روش [set_Size](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inotessize/set_size/) آن ابعاد را تنظیم می‌کند. اگرچه شیء تنظیمات یادداشت‌ها قابل جایگزینی نیست، می‌توانید اندازه آن را تغییر دهید.

عرض و ارتفاع بر حسب **نقطه** (points) مشخص می‌شوند و هر اینچ شامل ۷۲ نقطه است. به عنوان مثال، 900 × 600 نقطه برابر است با 12.5 × 8⅓ اینچ. این تنظیمات به کل ارائه اعمال می‌شوند، نه به یادداشت‌های یک اسلاید جداگانه.

| تنظیم | هدف |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_notessize/) | ابعاد صفحه یادداشت‌ها و ابعاد صفحه‌ای را که برای صادرات جزوات استفاده می‌شود کنترل می‌کند. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slidesize/) | ابعاد اسلایدهای عادی ارائه را از طریق [ISlideSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidesize/) کنترل می‌کند. |

تغییر هر یک از تنظیمات به‌طور خودکار تنظیم دیگر را تغییر نمی‌دهد. تغییر جهت صفحه یادداشت‌ها همچنین اسلایدهای عادی را چرخانده نمی‌کند. برای تغییر اندازه اسلایدهای عادی به [Slide Size](/slides/fa/cpp/slide-size/) مراجعه کنید.

مثال‌های زیر از یک فایل `sample.pptx` موجود استفاده می‌کنند. برای مثال‌های صادرات، از یک ارائه حاوی حداقل یک اسلاید با یادداشت‌های گوینده استفاده کنید. هر مثال می‌تواند به‌صورت مستقل اجرا شود.

## **خواندن اندازه و جهت صفحه یادداشت‌ها**

عرض و ارتفاع را بخوانید و برای تعیین جهت آن‌ها را مقایسه کنید: صفحه‌ای که عریض‌تر باشد به حالت افقی (landscape) است، صفحه‌ای که بلندتر باشد به حالت عمودی (portrait) و ابعاد برابر یک صفحه مربع را توصیف می‌کند. این مثال ابعاد واقعی را به‌صورت نقطه چاپ می‌کند، بدون این‌که یک اندازه کاغذ استاندارد فرض شود.

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

## **تغییر به حالت افقی بدون تغییر اندازه کاغذ**

برای تغییر تنها جهت، عرض و ارتفاع موجود را جابجا کنید. این کار طول هر دو طرف، از جمله اندازه‌های یک کاغذ سفارشی، را حفظ می‌کند. شرط زیر از تغییر یک صفحه‌ی در حالت افقی به حالت عمودی جلوگیری می‌کند و صفحه‌ی مربعی را بدون تغییر می‌گذارد.

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

برای جهت عمودی، زمانی که `size.get_Width() > size.get_Height()` از همان انتساب استفاده کنید. مگر اینکه بخواهید اندازه کاغذ را نیز تغییر دهید، ابعاد A4 یا Letter را جایگزین نکنید.

## **تنظیم و تأیید اندازه سفارشی صفحه یادداشت‌ها**

هر دو بعد را به‌صورت همزمان انتساب دهید، سپس از [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) برای نوشتن ارائه استفاده کنید. این مثال یک صفحه افقی 900 × 600‑نقطه‌ای تنظیم می‌کند، آن را به‌صورت PPTX ذخیره می‌سازد و فایل ذخیره‌شده را دوباره باز می‌کند تا مقادیر حفظ‌شده را بررسی کند. مقایسه tolerance 0.01‑نقطه برای مقادیر عددی شناور را می‌پذیرد؛ این به‌معنی تضمین دقت برای هر فرمت فایل نیست.

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

نتیجه‌ی مورد انتظار `900 x 600 points` و `Size preserved: True` است. بررسی یک ارائه‌ی تازه بازشده فایل ذخیره‌شده را تأیید می‌کند، نه فقط تنظیمات حافظه‌ای.

## **صادر کردن یادداشت‌ها و جزوات**

ابعاد صفحه ناحیه‌ی موجود برای طرح‌های یادداشت یا جزوه را تعریف می‌کند. این‌ها به‌تنهایی آن قالب‌ها را فعال نمی‌کنند: گزینه‌های صادرات را نیز پیکربندی کنید. صادرات اسلایدهای عادی همچنان از ابعاد اسلاید استفاده می‌کند.

### **صادر کردن یادداشت‌ها به PDF و PNG**

برای گنجاندن یادداشت‌ها در PDF، [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) را به [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) انتساب دهید. این مثال همچنین اولین اسلاید همراه با یادداشت‌ها را با استفاده از [Slide::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/getimage/) و [RenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/renderingoptions/) به PNG رندر می‌کند.

حالت [BottomTruncated](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notespositions/) یادداشت‌ها را در یک صفحه نگه می‌دارد؛ یادداشت‌های بیش از حد می‌توانند کوتاه شوند. PDF از صفحات 900 × 600‑نقطه‌ای استفاده می‌کند. در مقیاس تصویر 1 × 1 که در زیر استفاده شده، PNG دارای 900 × 600 پیکسل است. نقاط توصیف‌گر هندسه صفحه‌اند؛ پیکسل‌ها خروجی رستر را توصیف می‌کنند که ابعاد آن نیز به مقیاس رندر بستگی دارد.

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

برای صادرات PDF با یادداشت‌های طولانی، [BottomFull](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notespositions/) صفحات اضافه‌ای را در صورت نیاز امکان‌پذیر می‌سازد. از این حالت با فراخوانی تصویر تک‌اسلاید در بالا استفاده نکنید، زیرا آن را پشتیبانی نمی‌کند. پس از تغییر اندازه، خروجی را برای یادداشت‌های قطع‌شده و محل اشیای notes‑master موجود بررسی کنید؛ فقط تغییر ابعاد صفحه نباید ضمانت کند که تمام محتوا جا می‌شود. برای اطلاعات بیشتر درباره صادرات یادداشت‌ها به [Convert PowerPoint to PDF with Notes](/slides/fa/cpp/convert-powerpoint-to-pdf-with-notes/) مراجعه کنید.

### **صادر کردن جزوات به PDF**

برای چندین تصویر بندانگشتی اسلاید در یک صفحه از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handoutlayoutingoptions/) استفاده کنید. مثال زیر یک صفحه 900 × 600‑نقطه‌ای تنظیم می‌کند و از [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handouttype/) برای چیدمان تا چهار اسلاید در هر صفحه استفاده می‌کند. پیش‌تنظیم افقی ترتیب اسلایدها را کنترل می‌کند؛ جهت صفحه از عرض و ارتفاع آن ناشی می‌شود.

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

تغییر اندازه صفحه ناحیه‌ای را که برای شبکه جزوات در دسترس است تغییر می‌دهد بدون این‌که ابعاد اسلایدهای منبع تغییر کند. برای تصاویر جزوه، از [Presentation::GetImages](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/getimages/) همراه با چیدمان جزوه استفاده کنید، نه روش تصویر‌گیری یک اسلاید جداگانه. در Aspose.Slides، رندر جزوه در سطح ارائه از ابعاد صفحه یادداشت‌ها استفاده می‌کند، در حالی که فراخوانی تصویر یک اسلاید منفرد صفحه جزوه را تولید نمی‌کند. برای گزینه‌های چیدمان به [Handout Mode](/slides/fa/cpp/convert-powerpoint-in-handout-mode/) مراجعه کنید.

## **اندازه صفحه در نمایشگرها، صادرات و چاپ**

اندازه ذخیره‌شده ارائه، اندازه صفحه صادراتی و اندازه کاغذ چاپی را جداگانه نگه دارید:

- **نمایشگرهای ارائه:** یک نمایشگر می‌تواند یادداشت‌ها را با قوانین چیدمان خود نمایش یا چاپ کند. اگر برنامه‌ی دیگری فایل را ذخیره کند، آن را مجدداً باز کنید و دوباره ابعاد را بررسی کنید؛ تبدیل فرمت آن برنامه ممکن است آنها را نرمال‌سازی کند.
- **قالب‌های صادرات:** مثال‌های PDF یادداشت‌ها و جزوه در بالا از ابعاد صفحه پیکربندی‌شده استفاده می‌کنند. تصاویر رستر از ابعاد پیکسل صحیح و مقیاس رندر استفاده می‌کنند، بنابراین مقادیر نقطه‌ای کسری ممکن است در خروجی تصویر گرد شوند. صادرات اسلایدهای عادی از اندازه صفحه یادداشت‌ها استفاده نمی‌کند.
- **درایورهای چاپگر:** انتخاب کاغذ، چرخش خودکار و تنظیمات مقیاس به صفحه می‌توانند خروجی فیزیکی را بدون تغییر ابعاد ذخیره‌شده در ارائه یا PDF تغییر دهند. برای یک اندازه کاغذ خاص، تنظیمات چاپگر را منطبق کنید و پیش‌نمایش چاپ را بررسی نمایید.

## **FAQ**

**آیا می‌توانم اندازه یادداشت‌ها را فقط برای یک اسلاید تنظیم کنم؟**

اندازه صفحه یادداشت‌ها یک تنظیم در سطح ارائه است. اسلایدهای جداگانه می‌توانند محتوای یادداشت متفاوتی داشته باشند، اما این ویژگی اندازه صفحه جداگانه‌ای برای هر اسلاید فراهم نمی‌کند.

**چرا تغییر جهت یادداشت‌ها اسلایدهای من را تغییر نداد؟**

صفحات یادداشت‌ها و اسلایدهای عادی ابعاد مستقل دارند. زمانی که می‌خواهید خود اسلایدها را تغییر اندازه دهید، از تنظیمات اندازه اسلایدهای عادی استفاده کنید.

**چرا نتیجه‌ی ذخیره‌شده یا چاپ‌شده من اندازه متفاوتی دارد؟**

اولین بار ارائه ذخیره‌شده را دوباره باز کنید و ابعاد یادداشت‌های آن را مقایسه کنید. اگر آن‌ها تغییر کرده‌اند، بررسی کنید آیا ذخیره یا تبدیل فایل در برنامه‌ی دیگری تنظیمات صفحه را تغییر داده است. اگر نه، چیدمان صادرات، مقیاس تصویر، تنظیمات نمایشگر و انتخاب کاغذ چاپگر را بررسی کنید.