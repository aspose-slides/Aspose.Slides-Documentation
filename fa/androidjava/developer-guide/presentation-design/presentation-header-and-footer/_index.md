---
title: "مدیریت سربرگ‌ها و پابرگ‌های ارائه در اندروید"
linktitle: "سربرگ و پابرگ"
type: docs
weight: 140
url: /fa/androidjava/presentation-header-and-footer/
keywords:
- سربرگ
- متن سربرگ
- پابرگ
- متن پابرگ
- تنظیم سربرگ
- تنظیم پابرگ
- جزوه
- یادداشت
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "دریابید چگونه فضاهای نگهدارندهٔ پابرگ، تاریخ‑زمان، شماره اسلاید و سربرگ را در اسلایدها، صفحات یادداشت و جزوه‌ها با Aspose.Slides برای اندروید از طریق جاوا مدیریت کنید."
---
## **نمای کلی**

PowerPoint بسته به نوع صفحه از فضاهای نگهدارنده (placeholder) مختلف سربرگ و پابرگ استفاده می‌کند. Aspose.Slides برای Android از طریق Java به شما امکان کنترل متن و نمایش این فضاهای نگهدارنده را از طریق رابط‌های مدیریت سربرگ/پابرگ می‌دهد.

فضاهای نگهدارنده موجود بسته به دامنه متفاوت هستند:

| دامنه | سربرگ | پابرگ | تاریخ/زمان | شماره اسلاید/صفحه |
|---|---|---|---|---|
| اسلاید معمولی | خیر | بله | بله | بله |
| نقشه یادداشت | بله | بله | بله | بله |
| اسلاید یادداشت | بله | بله | بله | بله |
| نقشه جزوه | بله | بله | بله | بله |

یک اسلاید معمولی ارائه دارای فضا نگهدارندهٔ سربرگ نیست. سربرگ‌ها در صفحات یادداشت و جزوه‌ها موجود هستند. برای اسلایدهای معمولی، به جای آن از فضاهای نگهدارندهٔ پابرگ، تاریخ/زمان و شمارهٔ اسلاید استفاده کنید.

دامنهٔ یک تغییر بستگی به مدیری دارد که استفاده می‌کنید. اینترفیس [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideheaderfootermanager/) یک اسلید معمولی را کنترل می‌کند. اینترفیس [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) یک اسلاید یادداشت را کنترل می‌کند. مدیران مستر و چیدمان می‌توانند تنظیمات را به اسلایدهای وابسته propagate کنند، در حالی که اینترفیس [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) مستر جزوه را کنترل می‌کند.

## **تنظیم پابرگ، تاریخ/زمان و شماره اسلایدها در اسلایدهای معمولی**

برای اسلایدهای معمولی، جریان کاری پایه این است که مدیر سربرگ/پابرگ هر اسلاید را دسترسی پیدا کنید، متن پابرگ و تاریخ/زمان را تنظیم کنید، فضاهای نگهدارندهٔ مورد نیاز را فعال کنید و ارائه را ذخیره نمایید. شمارهٔ اسلایدها توسط ارائه تولید می‌شوند، بنابراین فقط نیاز به کنترل نمایش آن‌ها دارید.

از [`setFooterText`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) و [`setDateTimeText`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) برای تنظیم متن استفاده کنید، و از [`setFooterVisibility`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), و [`setSlideNumberVisibility`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) برای نمایش فضاهای نگهدارندهٔ مربوطه استفاده کنید.

مثال انتها به انتهای زیر همان پابرگ، متن تاریخ/زمان و نمایش شماره اسلاید را برای تمام اسلایدهای معمولی اعمال می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر نیاز به به‌روزرسانی فقط یک اسلاید دارید، به جای مرور کل مجموعه، مستقیم از طریق متد [`getSlides`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlides--) به آن اسلاید دسترسی پیدا کنید.

## **تنظیم سربرگ و پابرگ در مستر یادداشت‌ها**

مستر یادداشت‌ها قالب‌بندی مشترک و رفتار فضاهای نگهدارنده برای صفحات یادداشت را تعریف می‌کند. وقتی فقط می‌خواهید مستر یادداشت‌ها را تغییر دهید، از اینترفیس [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) استفاده کنید.

مثال زیر سربرگ، پابرگ و متن تاریخ/زمان را در مستر یادداشت‌ها تنظیم می‌کند و تمام فضاهای نگهدارندهٔ پشتیبانی‌شده را در آن مستر قابل مشاهده می‌سازد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متد [`getMasterNotesSlide`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) زمانی که ارائه حاوی مستر یادداشت‌ها نباشد، `null` برمی‌گرداند.

## **اعمال تنظیمات مستر یادداشت‌ها بر اسلایدهای فرزند یادداشت**

مستر یادداشت‌ها می‌تواند تنظیمات سربرگ و پابرگ را به خود و تمام اسلایدهای یادداشت وابسته اعمال کند. وقتی تنظیمات یکسان باید در سراسر سلسله‌مراتب یادداشت‌ها اعمال شود، از روش‌های propagation اختصاصی در [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) استفاده کنید.

برای مثال، [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) و [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) سربرگ مستر یادداشت‌ها و تمام سربرگ‌های فرزند را به‌روز می‌کند. روش‌های معادل برای پابرگ‌ها، تاریخ/زمان و شماره اسلایدها نیز موجود است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

روش‌های propagation استفاده‌شده در بالا عبارتند از [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), و [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **تنظیم سربرگ و پابرگ در یک اسلاید یادداشت تک‌فردی**

یک اسلاید یادداشت به یک اسلاید معمولی خاص تعلق دارد. وقتی می‌خواهید فقط آن صفحهٔ یادداشت را سفارشی کنید، از اینترفیس [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) آن استفاده کنید.

متد [`addNotesSlide`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) اسلاید یادداشت مربوط به اسلاید جاری را برمی‌گرداند و در صورتی که وجود نداشته باشد، یک اسلاید جدید ایجاد می‌کند. مثال زیر صفحهٔ یادداشت مرتبط با اولین اسلاید ارائه را پیکربندی می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر ابتدا تنظیمات را از مستر یادداشت‌ها propagation کنید و سپس یک اسلاید یادداشت تک‌فردی را تغییر دهید، تنظیمات بعدی برای هر اسلاید به شما امکان می‌دهد آن صفحهٔ یادداشت را به‌صورت مستقل سفارشی کنید.

## **تنظیم سربرگ و پابرگ در مستر جزوه**

صفحات جزوه از مستر جزوه برای فضاهای نگهدارندهٔ سربرگ، پابرگ، تاریخ/زمان و شمارهٔ صفحه استفاده می‌کنند. بر خلاف صفحات یادداشت، تنظیمات جزوه از طریق مستر جزوه مدیریت می‌شود نه از طریق اسلایدهای جزوهٔ تک‌تک.

از متد [`getMasterHandoutSlide`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) برای دسترسی به مستر جزوه استفاده کنید. اگر موجود نباشد، با فراخوانی [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) مستر جزوهٔ پیش‌فرض را ایجاد کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **درک دامنه و ارث‌بری**

مدیر سربرگ/پابرگی را انتخاب کنید که با دامنه‌ای که می‌خواهید تغییر دهید مطابقت داشته باشد:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islideheaderfootermanager/) تنظیمات پابرگ، تاریخ/زمان و شماره اسلاید را برای یک اسلاید معمولی تغییر می‌دهد.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) یک اسلاید چیدمان را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته propagate کند.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) یک مستر اسلاید عادی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته propagate کند.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) مستر یادداشت‌ها را کنترل می‌کند و می‌تواند تنظیمات را به تمام اسلایدهای یادداشت وابسته propagate کند.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) یک اسلاید یادداشت را تغییر می‌دهد و علاوه بر پابرگ، تاریخ/زمان و شماره اسلاید، یک فضا نگهدارندهٔ سربرگ را نیز پشتیبانی می‌کند.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) مستر جزوه را تغییر می‌دهد و از چهار نوع فضا نگهدارنده پشتیبانی می‌کند.

وقتی تنظیم یکسان باید در سراسر سلسله‌مراتب یک مستر یا چیدمان اعمال شود، از propagation استفاده کنید. وقتی نیاز به تنظیم محلی برای یک صفحه دارید، از مدیر اسلاید تک‌فرد یا notes‑slide استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم سربرگ به یک اسلاید معمولی اضافه کنم؟**

خیر. PowerPoint فضا نگهدارندهٔ سربرگ برای اسلایدهای معمولی تعریف نکرده است. در اسلایدهای معمولی، از فضاهای نگهدارندهٔ پابرگ، تاریخ/زمان و شماره اسلاید استفاده کنید. فضاهای نگهدارندهٔ سربرگ در صفحات یادداشت و جزوه موجود هستند.

**اگر فضا نگهدارندهٔ پابرگ، تاریخ/زمان یا شماره اسلاید قابل مشاهده نباشد چه؟**

از مدیر مربوط به سربرگ/پابرگ برای بررسی قابلیت نمایش آن استفاده کنید و در صورت نیاز آن را فعال کنید. برای مثال، [`isFooterVisible`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) گزارش می‌دهد که آیا فضا نگهدارندهٔ پابرگ موجود است یا نه، و [`setFooterVisibility`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) قابلیت نمایش آن را تغییر می‌دهد.

**چگونه شماره‌گذاری اسلایدها را از مقداری غیر از ۱ شروع کنم؟**

متد [`setFirstSlideNumber`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ارائه را صدا بزنید. سپس فضاهای نگهدارندهٔ شماره اسلاید از دنباله شماره‌گذاری به‌روز شده استفاده می‌کنند.

**وقتی به PDF، تصویر یا HTML صادر می‌شود، چه اتفاقی برای سربرگ‌ها و پابرگ‌ها می‌افتد؟**

عناصر قابل مشاهدهٔ سربرگ و پابرگ همراه با بقیه محتوای ارائه در قالب خروجی رندر می‌شوند. ظاهر آن‌ها بسته به نوع صفحه‌ای که صادر می‌شود و تنظیمات قابلیت نمایش فضاهای نگهدارندهٔ مرتبط متفاوت است.