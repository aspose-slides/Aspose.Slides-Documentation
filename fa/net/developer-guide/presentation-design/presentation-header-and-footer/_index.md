---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در .NET
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/net/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- جزوه
- یادداشت‌ها
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نحوه مدیریت مکان-نگهدارنده‌های پاورقی، تاریخ-زمان، شماره اسلاید و سرصفحه در اسلایدها، صفحات یادداشت و جزوه‌ها با Aspose.Slides برای .NET را بیاموزید."
---
## **بررسی کلی**

PowerPoint بسته به نوع صفحه از مکان‌نگهدارنده‌های متفاوت سرصفحه و پاورقی استفاده می‌کند. Aspose.Slides for .NET به شما اجازه می‌دهد متن و قابلیت نمایش این مکان‌نگهدارنده‌ها را از طریق رابط‌های مدیر سرصفحه/پاورقی کنترل کنید.

مکان‌نگهدارنده‌های موجود بسته به دامنه متفاوت است:

| دامنه | سرصفحه | پاورقی | تاریخ/زمان | شمارهٔ اسلاید/صفحه |
|---|---|---|---|---|
| اسلاید معمولی | خیر | بله | بله | بله |
| مستر یادداشت‌ها | بله | بله | بله | بله |
| اسلاید یادداشت | بله | بله | بله | بله |
| مستر جزوه | بله | بله | بله | بله |

یک اسلاید معمولی ارائه سرصفحه‌ای ندارد. سرصفحه‌ها در صفحات یادداشت و جزوه‌ها موجود هستند. برای اسلایدهای معمولی، به‌جای سرصفحه از مکان‌نگهدارنده‌های پاورقی، تاریخ/زمان و شمارهٔ اسلاید استفاده کنید.

دامنهٔ یک تغییر بستگی به مدیری دارد که استفاده می‌کنید. اینترفیس [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/islideheaderfootermanager/) یک اسلاید معمولی را کنترل می‌کند. اینترفیس [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/inotesslideheaderfootermanager/) یک اسلاید یادداشت را کنترل می‌کند. مدیران مستر و طرح‌بندی نیز می‌توانند تنظیمات را به اسلایدهای وابسته منتقل کنند، در حالی که اینترفیس [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterhandoutslideheaderfootermanager/) مستر جزوه را کنترل می‌کند.

## **تنظیم پاورقی، تاریخ/زمان و شماره اسلایدها در اسلایدهای معمولی**

برای اسلایدهای معمولی، جریان کاری پایه این است که به مدیر سرصفحه/پاورقی هر اسلاید دسترسی پیدا کنید، متن پاورقی و تاریخ/زمان را تنظیم کنید، مکان‌نگهدارنده‌های مورد نیاز را فعال کنید و ارائه را ذخیره کنید. شماره اسلایدها توسط ارائه تولید می‌شوند، بنابراین فقط نیاز به کنترل قابلیت نمایش آن‌ها دارید.

از [`SetFooterText`](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) و [`SetDateTimeText`](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) برای تنظیم متن استفاده کنید و از [`SetFooterVisibility`](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/)، [`SetDateTimeVisibility`](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) و [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) برای نمایش مکان‌نگهدارنده‌های مربوطه بهره بگیرید.

مثال پایان‑به‑پایان زیر همان پاورقی، متن تاریخ/زمان و قابلیت نمایش شماره اسلاید را برای همه اسلایدهای معمولی اعمال می‌کند:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

اگر فقط نیاز به به‌روزرسانی یک اسلاید دارید، به‌جای پیمایش کل مجموعه از مجموعهٔ [`Slides`](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) مستقیماً به آن اسلاید دسترسی پیدا کنید.

## **تنظیم سرصفحه و پاورقی در مستر یادداشت‌ها**

مستر یادداشت‌ها قالب‌بندی مشترک و رفتار مکان‌نگهدارنده‌ها برای صفحات یادداشت را تعریف می‌کند. هنگامیکه می‌خواهید فقط مستر یادداشت‌ها را تغییر دهید، از اینترفیس [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/imasternotesslideheaderfootermanager/) استفاده کنید.

مثال زیر سرصفحه، پاورقی و متن تاریخ/زمان را در مستر یادداشت‌ها تنظیم می‌کند و تمام مکان‌نگهدارنده‌های پشتیبانی‌شده را در آن مستر قابل مشاهده می‌سازد:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

ویژگی [`MasterNotesSlide`](https://reference.aspose.com/slides/fa/net/aspose.slides/imasternotesslidemanager/masternotesslide/) هنگام عدم وجود مستر یادداشت‌ها مقدار `null` برمی‌گرداند.

## **اعمال تنظیمات مستر یادداشت‌ها بر اسلایدهای یادداشت فرزند**

یک مستر یادداشت می‌تواند تنظیمات سرصفحه و پاورقی را بر خود و تمام اسلایدهای یادداشت وابسته اعمال کند. هنگامیکه تنظیمات یکسان باید در تمام سلسله‌مراتب یادداشت‌ها اعمال شود، از متدهای انتشار اختصاصی اینترفیس [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/imasternotesslideheaderfootermanager/) استفاده کنید.

به‌عنوان مثال، متدهای [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fa/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) و [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fa/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) سرصفحهٔ مستر یادداشت و تمام سرصفحه‌های فرزند را به‌روزرسانی می‌کنند. متدهای معادل برای پاورقی‌ها، تاریخ/زمان و شماره اسلایدها نیز موجود است.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

متدهای انتشار استفاده شده در بالا عبارتند از [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/fa/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/)، [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fa/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)، [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fa/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)، [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fa/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) و [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fa/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **تنظیم سرصفحه و پاورقی در یک اسلاید یادداشت تک تکی**

یک اسلاید یادداشت به یک اسلاید معمولی خاص تعلق دارد. هنگامی که می‌خواهید فقط همان صفحهٔ یادداشت را سفارشی کنید، از اینترفیس [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/inotesslideheaderfootermanager/) استفاده کنید.

متد [`AddNotesSlide`](https://reference.aspose.com/slides/fa/net/aspose.slides/inotesslidemanager/addnotesslide/) اسلاید یادداشت مربوط به اسلاید جاری را برمی‌گرداند و در صورت عدم وجود، یکی ایجاد می‌کند. مثال زیر صفحهٔ یادداشت مرتبط با اولین اسلاید ارائه را پیکربندی می‌کند:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

اگر ابتدا تنظیمات را از مستر یادداشت‌ها منتشر کنید و سپس یک اسلاید یادداشت تک تکی را تغییر دهید، تنظیمات پس‌از‑اسلاید به شما امکان می‌دهد آن صفحهٔ یادداشت را به‌صورت مستقل سفارشی کنید.

## **تنظیم سرصفحه و پاورقی در مستر جزوه**

صفحات جزوه از مستر جزوه برای مکان‌نگهدارنده‌های سرصفحه، پاورقی، تاریخ/زمان و شمارهٔ صفحه استفاده می‌کنند. برخلاف صفحات یادداشت، تنظیمات جزوه از طریق مستر جزوه مدیریت می‌شوند نه از طریق اسلایدهای جزوهٔ تک تکی.

از ویژگی [`MasterHandoutSlide`](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) برای دسترسی به مستر جزوه استفاده کنید. اگر موجود نباشد، با فراخوانی [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) مستر جزوه پیش‌فرض را ایجاد کنید.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **درک دامنه و ارث‌بری**

مدیر سرصفحه/پاورقی مناسب با دامنه‌ای که می‌خواهید تغییر دهید، انتخاب کنید:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/islideheaderfootermanager/) پاورقی، تاریخ/زمان و تنظیمات شماره اسلاید را برای یک اسلاید معمولی تغییر می‌دهد.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslideheaderfootermanager/) یک اسلاید طرح‌بندی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته منتقل کند.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslideheaderfootermanager/) یک مستر اسلاید معمولی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته منتقل کند.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/imasternotesslideheaderfootermanager/) مستر یادداشت‌ها را کنترل می‌کند و می‌تواند تنظیمات را به تمام اسلایدهای یادداشت وابسته منتقل کند.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/inotesslideheaderfootermanager/) یک اسلاید یادداشت را تغییر می‌دهد و علاوه بر پاورقی، تاریخ/زمان و شماره اسلاید، امکان استفاده از سرصفحه را نیز دارد.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterhandoutslideheaderfootermanager/) مستر جزوه را تغییر می‌دهد و از چهار نوع مکان‌نگهدارنده پشتیبانی می‌کند.

هنگامی که یک تنظیم باید در سراسر سلسله‌مراتب مستر یا طرح‌بندی اعمال شود، از انتشار استفاده کنید. برای تنظیمات محلی یک صفحه، از مدیر اسلاید یا اسلاید‑یادداشت تک تکی استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم سرصفحه‌ای به اسلاید معمولی اضافه کنم؟**

خیر. PowerPoint برای اسلایدهای معمولی مکان‌نگهدارندهٔ سرصفحه تعریف نمی‌کند. در اسلایدهای معمولی از مکان‌نگهدارنده‌های پاورقی، تاریخ/زمان و شماره اسلاید استفاده کنید. سرصفحه‌ها در صفحات یادداشت و جزوه‌ها موجود هستند.

**اگر مکان‌نگهدارندهٔ پاورقی، تاریخ/زمان یا شماره اسلاید قابل مشاهده نباشد چه کاری باید انجام دهم؟**

از مدیر سرصفحه/پاورقی مرتبط استفاده کنید تا قابلیت نمایش آن را بررسی کرده و در صورت نیاز فعال کنید. به‌عنوان مثال، متد [`IsFooterVisible`](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) نشان می‌دهد آیا مکان‌نگهدارندهٔ پاورقی وجود دارد و متد [`SetFooterVisibility`](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) قابلیت نمایش آن را تغییر می‌دهد.

**چگونه می‌توانم شماره‌گذاری اسلایدها را از مقداری غیر از ۱ شروع کنم؟**

ویژگی [`FirstSlideNumber`](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/firstslidenumber/) ارائه را تنظیم کنید. سپس مکان‌نگهدارنده‌های شماره اسلاید از دنبالهٔ به‌روزرسانی‌شده استفاده می‌کنند.

**زمانی که به PDF، تصویر یا HTML صادر می‌شود، سرصفحه و پاورقی چه می‌شود؟**

عناصر قابل مشاهدهٔ سرصفحه و پاورقی همراه با بقیهٔ محتوای ارائه در قالب خروجی رندر می‌شوند. ظاهر آن‌ها بستگی به نوع صفحه‌ای دارد که صادر می‌شود و تنظیمات قابلیت نمایش مکان‌نگهدارندهٔ مربوطه.