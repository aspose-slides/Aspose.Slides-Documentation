---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در C++
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/cpp/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- برگه چاپی
- یادداشت‌ها
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه متغیرهای پاورقی، تاریخ‑زمان، شماره اسلاید و سرصفحه را در اسلایدها، صفحات یادداشت و برگه‌های چاپی با Aspose.Slides برای C++ مدیریت کنید."
---
## **مرور کلی**

PowerPoint بسته به نوع صفحه از متغیرهای سرصفحه و پاورقی متفاوتی استفاده می‌کند. Aspose.Slides for C++ به شما امکان کنترل متن و نمایش این متغیرها را از طریق رابط‌های مدیر سرصفحه/پاورقی می‌دهد.

متغیرهای موجود بسته به محدوده متفاوت هستند:

| دامنه | سرصفحه | پاورقی | تاریخ/زمان | شماره اسلاید/صفحه |
|---|---|---|---|---|
| اسلاید عادی | خیر | بلی | بلی | بلی |
| مستر یادداشت | بلی | بلی | بلی | بلی |
| اسلاید یادداشت | بلی | بلی | بلی | بلی |
| مستر خروجی | بلی | بلی | بلی | بلی |

یک اسلاید ارائه عادی متغیر سرصفحه ندارد. سرصفحه‌ها در صفحات یادداشت و خروجی وجود دارند. برای اسلایدهای عادی از متغیرهای پاورقی، تاریخ/زمان و شماره اسلاید استفاده کنید.

محدودهٔ تغییر بسته به مدیر (manager) مورد استفاده متفاوت است. رابط [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideheaderfootermanager/) یک اسلاید عادی را کنترل می‌کند. رابط [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inotesslideheaderfootermanager/) یک اسلاید یادداشت را کنترل می‌کند. مدیران مستر و لایوت می‌توانند تنظیمات را به اسلایدهای وابسته منتقل کنند، در حالی که رابط [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) مستر خروجی را کنترل می‌کند.

## **تنظیم پاورقی، تاریخ/زمان و شماره اسلاید در اسلایدهای عادی**

برای اسلایدهای عادی، جریان کاری پایه این است که به مدیر سرصفحه/پاورقی هر اسلاید دسترسی پیدا کنید، متن پاورقی و تاریخ/زمان را تنظیم کنید، متغیرهای مورد نیاز را فعال کنید و ارائه را ذخیره کنید. شماره اسلایدها توسط ارائه تولید می‌شوند، بنابراین فقط باید نمایش آن‌ها را کنترل کنید.

از [`SetFooterText`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) و [`SetDateTimeText`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) برای تنظیم متن استفاده کنید و از [`SetFooterVisibility`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/)، [`SetDateTimeVisibility`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) و [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) برای نمایش متغیرهای مربوطه بهره ببرید.

مثال کامل زیر، همان پاورقی، متن تاریخ/زمان و نمایش شماره اسلاید را برای تمام اسلایدهای عادی اعمال می‌کند:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

اگر فقط می‌خواهید یک اسلاید را به‌روزرسانی کنید، به‌جای پیمایش تمام مجموعه اسلایدها، مستقیماً از طریق [`Presentation::get_Slide`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slide/) به آن اسلاید دسترسی پیدا کنید.

## **تنظیم سرصفحه و پاورقی در مستر یادداشت**

مستر یادداشت قالب‌بندی مشترک و رفتار متغیرهای صفحات یادداشت را تعریف می‌کند. هنگامی که می‌خواهید فقط مستر یادداشت را تغییر دهید، از رابط [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/) استفاده کنید.

مثال زیر سرصفحه، پاورقی و متن تاریخ/زمان را در مستر یادداشت تنظیم می‌کند و تمام متغیرهای پشتیبانی شده را در آن مستر قابل مشاهده می‌سازد:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

متد [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) زمانی که ارائه مستر یادداشت نداشته باشد، `nullptr` برمی‌گرداند.

## **اعمال تنظیمات مستر یادداشت به اسلایدهای فرزند یادداشت**

یک مستر یادداشت می‌تواند تنظیمات سرصفحه و پاورقی را به خود و تمام اسلایدهای یادداشت وابسته اعمال کند. هنگام نیاز به اعمال یکسان تنظیمات در سراسر سلسله‌مراتب یادداشت‌ها، از متدهای انتقال اختصاصی روی [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/) استفاده کنید.

به عنوان مثال، متدهای [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) و [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) سرصفحهٔ مستر یادداشت و تمام سرصفحه‌های فرزند را به‌روزرسانی می‌کنند. متدهای معادل برای پاورقی، تاریخ/زمان و شماره اسلاید نیز موجود است.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

متدهای انتقال استفاده‌شده در بالا عبارتند از [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/)، [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)، [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)، [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) و [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **تنظیم سرصفحه و پاورقی در یک اسلاید یادداشت منفرد**

یک اسلاید یادداشت به یک اسلاید عادی خاص تعلق دارد. زمانی که می‌خواهید فقط همان صفحهٔ یادداشت را سفارشی کنید، از رابط [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inotesslideheaderfootermanager/) استفاده کنید.

متد [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inotesslidemanager/addnotesslide/) اسلاید یادداشت مربوط به اسلاید فعلی را برمی‌گرداند و در صورت عدم وجود، یک اسلاید جدید ایجاد می‌کند. مثال زیر صفحهٔ یادداشت مرتبط با اولین اسلاید ارائه را پیکربندی می‌کند:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

اگر ابتدا تنظیمات را از مستر یادداشت انتقال دهید و سپس یک اسلاید یادداشت منفرد را تغییر دهید، تنظیمات بعدی به‌صورت مستقل بر آن صفحهٔ یادداشت اعمال می‌شود.

## **تنظیم سرصفحه و پاورقی در مستر خروجی**

صفحات خروجی از مستر خروجی برای متغیرهای سرصفحه، پاورقی، تاریخ/زمان و شماره صفحه استفاده می‌کنند. بر خلاف صفحات یادداشت، تنظیمات خروجی از طریق مستر خروجی مدیریت می‌شود نه از طریق اسلایدهای خروجی منفرد.

از [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) برای دسترسی به مستر خروجی استفاده کنید. اگر موجود نباشد، با فراخوانی [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) مستر خروجی پیش‌فرض را ایجاد کنید.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **درک محدوده و وراثت**

مدیری را انتخاب کنید که با محدودهٔ مورد نظر شما مطابقت داشته باشد:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islideheaderfootermanager/) تنظیمات پاورقی، تاریخ/زمان و شماره اسلاید را برای یک اسلاید عادی تغییر می‌دهد.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslideheaderfootermanager/) یک اسلاید لایوت را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته منتقل کند.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslideheaderfootermanager/) یک مستر اسلاید عادی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته منتقل کند.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslideheaderfootermanager/) مستر یادداشت را کنترل می‌کند و می‌تواند تنظیمات را به تمام اسلایدهای یادداشت وابسته منتقل کند.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inotesslideheaderfootermanager/) یک اسلاید یادداشت را تغییر می‌دهد و علاوه بر پاورقی، تاریخ/زمان و شماره اسلاید، یک متغیر سرصفحه را نیز پشتیبانی می‌کند.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) مستر خروجی را تغییر می‌دهد و از چهار نوع متغیر پشتیبانی می‌کند.

از انتقال از یک مستر یا لایوت استفاده کنید وقتی تنظیم یکسان باید در تمام سطوح سلسله‌مراتب آن اعمال شود. برای تنظیم محلی یک صفحه، از مدیر اسلاید یا اسلاید‑یادداشت منفرد بهره ببرید.

## **سؤالات متداول**

**آیا می‌توانم سرصفحه‌ای به اسلاید عادی اضافه کنم؟**

خیر. PowerPoint برای اسلایدهای عادی متغیر سرصفحه‌ای تعریف نمی‌کند. در اسلایدهای عادی از متغیرهای پاورقی، تاریخ/زمان و شماره اسلاید استفاده کنید. سرصفحه‌ها فقط در صفحات یادداشت و خروجی موجود هستند.

**اگر متغیر پاورقی، تاریخ/زمان یا شماره اسلاید دیده نشود چه کار کنم؟**

از مدیر سرصفحه/پاورقی مربوطه برای بررسی وضعیت نمایش آن استفاده کنید و در صورت نیاز آن را فعال کنید. به عنوان مثال، متد [`get_IsFooterVisible`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) نشان می‌دهد آیا متغیر پاورقی موجود است و متد [`SetFooterVisibility`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) وضعیت نمایش آن را تغییر می‌دهد.

**چگونه می‌توانم شماره‌گذاری اسلایدها را از عددی غیر از ۱ شروع کنم؟**

از متد [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/set_firstslidenumber/) برای تعیین شمارهٔ اولین اسلاید استفاده کنید. سپس متغیرهای شماره اسلاید از دنبالهٔ به‌روزرسانی شده استفاده می‌کنند.

**در هنگام خروجی گرفتن به PDF، تصویر یا HTML، سرصفحه و پاورقی چه اتفاقی می‌افتند؟**

عناصر قابل مشاهدهٔ سرصفحه و پاورقی همراه با بقیهٔ محتوای ارائه در فرمت خروجی رندر می‌شوند. نمایش آن‌ها بستگی به نوع صفحه‌ای که خروجی گرفته می‌شود و تنظیمات مربوط به متغیرهای قابل مشاهده دارد.