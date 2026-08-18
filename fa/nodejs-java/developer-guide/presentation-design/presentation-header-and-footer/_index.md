---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در JavaScript
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/nodejs-java/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- سند‑پیش‌نمایش
- یادداشت
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه مکان‌نگهدارهای پاورقی، تاریخ‑زمان، شماره اسلاید و سرصفحه را در اسلایدها، صفحات یادداشت و سند‑پیش‌نمایش با Aspose.Slides برای Node.js از طریق Java مدیریت کنید."
---
## **نمایش کلی**

PowerPoint بسته به نوع صفحه از مکان‌نگهدارهای سرصفحه و پاورقی متفاوتی استفاده می‌کند. Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد متن و قابلیت مشاهده این مکان‌نگهدارها را از طریق کلاس‌های مدیریت سرصفحه/پاورقی کنترل کنید.

مکان‌نگهدارهای موجود بسته به دامنه متفاوت هستند:

| دامنه | سرصفحه | پاورقی | تاریخ/زمان | شماره اسلاید/صفحه |
|---|---|---|---|---|
| اسلاید معمولی | خیر | بله | بله | بله |
| یادداشت‑مستری | بله | بله | بله | بله |
| اسلاید یادداشت | بله | بله | بله | بله |
| سند‑پیش‌نمایش مستری | بله | بله | بله | بله |

یک اسلاید ارائهٔ معمولی سرصفحه ندارد. سرصفحه‌ها فقط در صفحات یادداشت و سند‑پیش‌نمایش موجود هستند. برای اسلایدهای معمولی از مکان‌نگهدارهای پاورقی، تاریخ/زمان و شمارهٔ اسلاید استفاده کنید.

دامنهٔ تغییر بستگی به مدیری دارد که استفاده می‌کنید. کلاس [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideheaderfootermanager/) یک اسلاید معمولی را کنترل می‌کند. کلاس [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notesslideheaderfootermanager/) یک اسلاید یادداشت را کنترل می‌کند. مدیران مستر و طرح‌بند نیز می‌توانند تنظیمات را به اسلایدهای وابستهٔ خود propagate کنند، در حالی که کلاس [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) مستر سند‑پیش‌نمایش را کنترل می‌کند.

## **تنظیم پاورقی، تاریخ/زمان و شمارهٔ اسلاید در اسلایدهای معمولی**

برای اسلایدهای معمولی، جریان کار پایه این است که به هر اسلاید دسترسی پیدا کنید، مدیر سرصفحه/پاورقی آن را فراخوانی کنید، متن پاورقی و تاریخ/زمان را تنظیم کنید، مکان‌نگهدارهای مورد نیاز را فعال کنید و ارائه را ذخیره کنید. شمارهٔ اسلایدها توسط ارائه تولید می‌شوند، بنابراین تنها کافی است قابلیت مشاهده آن‌ها را کنترل کنید.

از [`setFooterText`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) و [`setDateTimeText`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) برای تنظیم متن استفاده کنید و از [`setFooterVisibility`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)، [`setDateTimeVisibility`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) و [`setSlideNumberVisibility`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) برای نمایش مکان‌نگهدارهای مربوطه بهره بگیرید.

مثال انتها‑به‑انتها زیر همان پاورقی، متن تاریخ/زمان و قابلیت مشاهده شماره اسلاید را برای همهٔ اسلایدهای معمولی اعمال می‌کند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر فقط می‌خواهید یک اسلاید را به‌روز کنید، به جای پیمایش کل مجموعه از متد [`getSlides`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslides/) برای دسترسی مستقیم به آن اسلاید استفاده کنید.

## **تنظیم سرصفحه و پاورقی در مستر یادداشت‌ها**

مستر یادداشت‌ها قالب‌بندی مشترک و رفتار مکان‌نگهدارهای صفحات یادداشت را تعریف می‌کند. زمانی که می‌خواهید فقط مستر یادداشت‌ها را تغییر دهید، از کلاس [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) استفاده کنید.

مثال زیر سرصفحه، پاورقی و متن تاریخ/زمان را در مستر یادداشت‌ها تنظیم می‌کند و تمام مکان‌نگهدارهای پشتیبانی‌شده را در آن مستر قابل مشاهده می‌سازد:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متد [`getMasterNotesSlide`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) هنگام عدم حضور مستر یادداشت‌ها مقدار `null` برمی‌گرداند.

## **اعمال تنظیمات مستر یادداشت‌ها به اسلایدهای یادداشت فرزند**

یک مستر یادداشت می‌تواند تنظیمات سرصفحه و پاورقی را خود و همهٔ اسلایدهای یادداشت وابسته اعمال کند. هنگامی که می‌خواهید همان تنظیمات در سرتاسر سلسله مراتب یادداشت‌ها اعمال شود، از متدهای propagation موجود در [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) استفاده کنید.

به عنوان مثال، متدهای [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) و [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) سرصفحهٔ مستر یادداشت و تمام سرصفحه‌های فرزند را به‌روزرسانی می‌کنند. متدهای معادل برای پاورقی، تاریخ/زمان و شمارهٔ اسلاید نیز موجود هستند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متدهای propagation مورد استفاده در بالا عبارتند از [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText)، [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility)، [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText)، [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) و [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **تنظیم سرصفحه و پاورقی در یک اسلاید یادداشت تک‌تکه**

یک اسلاید یادداشت متعلق به یک اسلاید معمولی خاص است. زمانی که می‌خواهید فقط آن صفحهٔ یادداشت را سفارشی کنید، از کلاس [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notesslideheaderfootermanager/) استفاده کنید.

متد [`addNotesSlide`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) اسلاید یادداشت مرتبط با اسلاید جاری را برمی‌گرداند و در صورت عدم وجود یک اسلاید جدید ایجاد می‌کند. مثال زیر صفحهٔ یادداشت مرتبط با اولین اسلاید ارائه را پیکربندی می‌کند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر ابتدا تنظیمات را از مستر یادداشت‌ها propagate کنید و سپس یک اسلاید یادداشت تک‌تکه را تغییر دهید، تنظیمات پس‌از‑اسلاید به شما امکان می‌دهد آن صفحهٔ یادداشت را به‌صورت مستقل سفارشی کنید.

## **تنظیم سرصفحه و پاورقی در مستر سند‑پیش‌نمایش**

صفحات سند‑پیش‌نمایش از مستر سند‑پیش‌نمایش برای سرصفحه، پاورقی، تاریخ/زمان و مکان‌نگهدار شمارهٔ صفحه استفاده می‌کنند. بر خلاف صفحات یادداشت، تنظیمات سند‑پیش‌نمایش از طریق مستر سند‑پیش‌نمایش مدیریت می‌شوند، نه اسلایدهای تک‌تکهٔ سند‑پیش‌نمایش.

برای دسترسی به مستر سند‑پیش‌نمایش از متد [`getMasterHandoutSlide`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) استفاده کنید. اگر موجود نبود، با فراخوانی [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) مستر پیش‌فرض را ایجاد کنید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **درک دامنه و وراثت**

مدیری سرصفحه/پاورقی را انتخاب کنید که با دامنهٔ مورد نظر شما مطابقت دارد:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slideheaderfootermanager/) تنظیمات پاورقی، تاریخ/زمان و شماره اسلاید را برای یک اسلاید معمولی تغییر می‌دهد.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) یک اسلاید طرح‌بندی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته propagate کند.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslideheaderfootermanager/) مستر اسلایدهای معمولی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته propagate کند.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) مستر یادداشت‌ها را کنترل می‌کند و می‌تواند تنظیمات را به همهٔ اسلایدهای یادداشت وابسته propagate کند.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notesslideheaderfootermanager/) یک اسلاید یادداشت را تغییر می‌دهد و علاوه بر پاورقی، تاریخ/زمان و شماره اسلاید، یک سرصفحه را نیز پشتیبانی می‌کند.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) مستر سند‑پیش‌نمایش را تغییر می‌دهد و تمام چهار نوع مکان‌نگهدار را پشتیبانی می‌کند.

زمانی که همان تنظیم باید در سرتاسر سلسله مراتب مستر یا طرح‌بندی اعمال شود، از propagation استفاده کنید. هنگامی که نیاز به تنظیم محلی برای یک صفحه دارید، از مدیر اسلاید یا اسلاید‑یادداشت تک‌تکه استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم سرصفحه‌ای به یک اسلاید معمولی اضافه کنم؟**

خیر. PowerPoint برای اسلایدهای معمولی مکان‌نگهدار سرصفحه تعریف نمی‌کند. در اسلایدهای معمولی از مکان‌نگهدارهای پاورقی، تاریخ/زمان و شمارهٔ اسلاید استفاده کنید. مکان‌نگهدارهای سرصفحه فقط در صفحات یادداشت و سند‑پیش‌نمایش موجود هستند.

**اگر مکان‌نگهدار پاورقی، تاریخ/زمان یا شمارهٔ اسلاید قابل مشاهده نباشد چه کار کنم؟**

از مدیر سرصفحه/پاورقی مربوطه استفاده کنید تا قابلیت مشاهده آن را بررسی و در صورت نیاز فعال کنید. به عنوان مثال، متد [`isFooterVisible`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) نشان می‌دهد آیا مکان‌نگهدار پاورقی موجود است و متد [`setFooterVisibility`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) قابلیت مشاهده آن را تغییر می‌دهد.

**چگونه شماره‌گذاری اسلایدها را از مقداری غیر از 1 شروع کنم؟**

متد [`setFirstSlideNumber`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) ارائه را فراخوانی کنید. پس از آن مکان‌نگهدارهای شماره اسلاید از توالی شماره‌گذاری به‌روزرسانی‌شده استفاده می‌کنند.

**هنگام خروجی گرفتن به PDF، تصویر یا HTML، سرصفحه و پاورقی چه می‌شوند؟**

عناصر قابل مشاهدهٔ سرصفحه و پاورقی همراه با بقیهٔ محتوای ارائه در قالب خروجی رندر می‌شوند. ظاهر آن‌ها به نوع صفحه‌ای که صادر می‌شود و تنظیمات قابلیت مشاهده مکان‌نگهدار مربوطه وابسته است.