---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در جاوا
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/java/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- توزیع
- یادداشت‌ها
- پاورپوینت
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه جایگاه‌گیرهای پاورقی، تاریخ-زمان، شماره اسلاید و سرصفحه را در اسلایدها، صفحات یادداشت و توزیع‌ها با Aspose.Slides برای جاوا مدیریت کنید."
---
## **بررسی کلی**

PowerPoint بسته به نوع صفحه از جایگاه‌گیرهای سرصفحه و پاورقی متفاوتی استفاده می‌کند. Aspose.Slides for Java به شما امکان کنترل متن و قابلیت نمایش این جایگاه‌گیرها را از طریق واسط‌های مدیر سرصفحه/پاورقی می‌دهد.

جایگاه‌گیرهای موجود بسته به دامنه متفاوت هستند:

| دامنه | سرصفحه | پاورقی | تاریخ/زمان | شماره اسلاید/صفحه |
|---|---|---|---|---|
| اسلاید عادی | خیر | بله | بله | بله |
| نقشه اصلی یادداشت‌ها | بله | بله | بله | بله |
| اسلاید یادداشت | بله | بله | بله | بله |
| نقشه اصلی توزیع | بله | بله | بله | بله |

یک اسلاید ارائهٔ عادی دارای جایگاه‌گیر سرصفحه نیست. سرصفحه‌ها در صفحات یادداشت و توزیع موجود هستند. برای اسلایدهای عادی، به جای سرصفحه از جایگاه‌گیرهای پاورقی، تاریخ/زمان و شماره اسلاید استفاده کنید.

دامنهٔ تغییری که اعمال می‌کنید به مدیری که استفاده می‌کنید بستگی دارد. واسط [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideheaderfootermanager/) یک اسلاید عادی را کنترل می‌کند. واسط [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/inotesslideheaderfootermanager/) یک اسلاید یادداشت را کنترل می‌کند. مدیران نقشه و چینش می‌توانند تنظیمات را به اسلایدهای وابسته منتشر کنند، در حالی که واسط [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) نقشهٔ توزیع را کنترل می‌کند.

## **تنظیم پاورقی، تاریخ/زمان و شماره اسلاید در اسلایدهای عادی**

برای اسلایدهای عادی، روند پایه این است که به مدیر سرصفحه/پاورقی هر اسلاید دسترسی پیدا کنید، متن پاورقی و تاریخ/زمان را تنظیم کنید، جایگاه‌گیرهای مورد نیاز را فعال کنید و ارائه را ذخیره کنید. شماره اسلایدها توسط ارائه تولید می‌شوند، بنابراین فقط نیاز به کنترل نمایش آن‌ها دارید.

از [`setFooterText`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) و [`setDateTimeText`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) برای تنظیم متن استفاده کنید و از [`setFooterVisibility`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-)، [`setDateTimeVisibility`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-)، و [`setSlideNumberVisibility`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) برای نمایش جایگاه‌گیرهای مربوطه استفاده کنید.

مثال پایان‑به‑پایان زیر همان پاورقی، متن تاریخ/زمان و نمایش شماره اسلاید را برای تمام اسلایدهای عادی اعمال می‌کند:

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

اگر فقط نیاز دارید یک اسلاید را به‌روز کنید، به‌جای پیمایش کل مجموعه از متد [`getSlides`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSlides--) آن اسلاید را مستقیماً دریافت کنید.

## **تنظیم سرصفحه و پاورقی در نقشهٔ اصلی یادداشت‌ها**

نقشهٔ اصلی یادداشت‌ها قالب‌بندی مشترک و رفتار جایگاه‌گیرهای صفحات یادداشت را تعریف می‌کند. وقتی می‌خواهید فقط نقشهٔ اصلی یادداشت‌ها را تغییر دهید، از واسط [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/) استفاده کنید.

مثال زیر سرصفحه، پاورقی و متن تاریخ/زمان را در نقشهٔ اصلی یادداشت‌ها تنظیم می‌کند و تمام جایگاه‌گیرهای پشتیبانی‌شده را در آن نقشه قابل مشاهده می‌سازد:

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

متد [`getMasterNotesSlide`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) زمانی که ارائه شامل نقشهٔ اصلی یادداشت‌ها نباشد، `null` برمی‌گرداند.

## **اعمال تنظیمات نقشهٔ اصلی یادداشت‌ها به اسلایدهای فرزند یادداشت**

نقشهٔ اصلی یادداشت‌ها می‌تواند تنظیمات سرصفحه و پاورقی را هم بر خود و هم بر تمام اسلایدهای یادداشت وابسته اعمال کند. وقتی همان تنظیمات باید در سرتاسر سلسله‌مراتب یادداشت‌ها اعمال شود، از روش‌های انتشار اختصاصی واسط [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/) استفاده کنید.

به عنوان مثال، متدهای [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) و [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) سرصفحهٔ نقشهٔ اصلی و تمام سرصفحه‌های فرزند را به‌روزرسانی می‌کنند. روش‌های معادل برای پاورقی، تاریخ/زمان و شماره اسلاید نیز موجود است.

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

روش‌های انتشار استفاده‑شده در بالا عبارتند از [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-)، [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-)، [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-)، [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-)، و [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **تنظیم سرصفحه و پاورقی در یک اسلاید یادداشت منفرد**

یک اسلاید یادداشت به یک اسلاید عادی خاص تعلق دارد. وقتی می‌خواهید فقط همان صفحهٔ یادداشت را سفارشی کنید، از واسط [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/inotesslideheaderfootermanager/) آن استفاده کنید.

متد [`addNotesSlide`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) اسلاید یادداشت مربوط به اسلاید فعلی را برمی‌گرداند و در صورت عدم وجود، یکی را ایجاد می‌کند. مثال زیر صفحهٔ یادداشت مرتبط با اولین اسلاید ارائه را پیکربندی می‌کند:

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

اگر ابتدا تنظیمات را از نقشهٔ اصلی یادداشت‌ها منتشر کنید و سپس یک اسلاید یادداشت منفرد را تغییر دهید، تنظیمات پس از انتشار به شما اجازه می‌دهد آن صفحهٔ یادداشت را به‌صورت مستقل سفارشی کنید.

## **تنظیم سرصفحه و پاورقی در نقشهٔ اصلی توزیع**

صفحات توزیع از نقشهٔ اصلی توزیع برای جایگاه‌گیرهای سرصفحه، پاورقی، تاریخ/زمان و شماره صفحه استفاده می‌کنند. بر خلاف صفحات یادداشت، تنظیمات توزیع از طریق نقشهٔ اصلی توزیع مدیریت می‌شوند نه از طریق اسلایدهای توزیع منفرد.

از متد [`getMasterHandoutSlide`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) برای دسترسی به نقشهٔ اصلی توزیع استفاده کنید. اگر وجود نداشت، با فراخوانی [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) نقشهٔ پیش‌فرض توزیع را ایجاد کنید.

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

مدیری را که با دامنهٔ موردنظر شما مطابقت دارد، انتخاب کنید:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islideheaderfootermanager/) پاورقی، تاریخ/زمان و تنظیمات شماره اسلاید را برای یک اسلاید عادی تغییر می‌دهد.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslideheaderfootermanager/) یک اسلاید چینش را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته منتشر کند.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslideheaderfootermanager/) یک نقشهٔ اسلاید معمولی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته منتشر کند.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslideheaderfootermanager/) نقشهٔ اصلی یادداشت‌ها را کنترل می‌کند و می‌تواند تنظیمات را به تمام اسلایدهای یادداشت وابسته منتشر کند.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/inotesslideheaderfootermanager/) یک اسلاید یادداشت را تغییر می‌دهد و علاوه بر پاورقی، تاریخ/زمان و شماره اسلاید، یک جایگاه‌گیر سرصفحه را نیز پشتیبانی می‌کند.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) نقشهٔ اصلی توزیع را تغییر می‌دهد و از چهار نوع جایگاه‌گیر پشتیبانی می‌کند.

وقتی همان تنظیم باید در سرتاسر یک سلسله‌مراتب اعمال شود، از انتشار از یک نقشه یا چینش استفاده کنید. وقتی نیاز به تنظیم محلی برای یک صفحه دارید، از مدیر اسلاید یا اسلاید‑یادداشت منفرد بهره بگیرید.

## **پرسش‌های متداول**

**آیا می‌توانم یک سرصفحه به اسلاید عادی اضافه کنم؟**

خیر. PowerPoint برای اسلایدهای عادی جایگاه‌گیر سرصفحه تعریف نمی‌کند. در اسلایدهای عادی از جایگاه‌گیرهای پاورقی، تاریخ/زمان و شماره اسلاید استفاده کنید. جایگاه‌گیرهای سرصفحه در صفحات یادداشت و توزیع موجود هستند.

**اگر جایگاه‌گیر پاورقی، تاریخ/زمان یا شماره اسلاید قابل مشاهده نباشد چه می‌شود؟**

با استفاده از مدیر سرصفحه/پاورقی مربوطه، قابلیت مشاهده آن را بررسی و در صورت نیاز فعال کنید. به عنوان مثال، متد [`isFooterVisible`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) نشان می‌دهد آیا یک جایگاه‌گیر پاورقی موجود است و متد [`setFooterVisibility`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) نمایش آن را تغییر می‌دهد.

**چگونه می‌توانم شماره‌گذاری اسلایدها را از مقداری غیر از ۱ شروع کنم؟**

متد [`setFirstSlideNumber`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ارائه را فراخوانی کنید. پس از آن، جایگاه‌گیرهای شماره اسلاید از توالی شماره‌گذاری به‌روز شده استفاده می‌کنند.

**در هنگام خروجی گرفتن به PDF، تصویر یا HTML، سرصفحه‌ها و پاورقی‌ها چه اتفاقی می‌افتند؟**

عناصر قابل مشاهدهٔ سرصفحه و پاورقی همراه با بقیهٔ محتوای ارائه در قالب خروجی رندر می‌شوند. ظاهر آن‌ها بسته به نوع صفحهٔ خروجی و تنظیمات قابلیت مشاهدهٔ جایگاه‌گیر مربوطه متفاوت است.