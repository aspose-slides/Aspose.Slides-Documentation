---
title: "اعمال یا تغییر طرح‌بندی اسلایدها در جاوا"
linktitle: "طرح‌بندی اسلاید"
type: docs
weight: 60
url: /fa/java/slide-layout/
keywords:
- "طرح‌بندی اسلاید"
- "طرح‌بندی محتوا"
- "جای‌گذار"
- "طراحی ارائه"
- "طراحی اسلاید"
- "طرح‌بندی استفاده‌نشده"
- "قابلیت نمایش پانوشت"
- "اسلاید عنوان"
- "عنوان و محتوا"
- "سرصفحه بخش"
- "دو محتوا"
- "مقایسه"
- "فقط عنوان"
- "طرح‌بندی خالی"
- "محتوا با زیرنویس"
- "تصویر با زیرنویس"
- "عنوان و متن عمودی"
- "عنوان عمودی و متن"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Java"
- "Aspose.Slides"
description: "اعمال، ایجاد و اصلاح طرح‌بندی اسلایدها در Aspose.Slides برای Java، افزودن جای‌گذارها، حذف طرح‌بندی‌های استفاده‌نشده و کنترل نمایش پانوشت."
---
## **بررسی کلی**

یک طرح‌بندی اسلاید موقعیت‌ها و قالب‌بندی جای‌گذاران مانند عنوان، متن، تصویر، نمودار و جدول را تعریف می‌کند. اعمال یک طرح‌بندی به اسلایدها ساختار ثابت‌تری می‌بخشد در حالی که هر اسلاید می‌تواند محتوای خود را داشته باشد.

پرکاربردترین طرح‌بندی‌ها عبارتند از:

- **اسلاید عنوان**: شامل جای‌گذارهای عنوان و زیرعنوان.
- **عنوان و محتوا**: شامل یک جای‌گذار عنوان و یک جای‌گذار محتوای عمومی.
- **خالی**: هیچ جای‌گذار محتوایی ندارد و زمانی مفید است که تمام اشکال به‌صورت دستی موقعیت‌یابی شوند.

## **درک ارث‌بری طرح‌بندی**

یک ارائه دارای سه سطح مرتبط است:

1. یک [اسلاید اصلی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) تم، قالب‌بندی مشترک، پس‌زمینه و اشیای عمومی را تعریف می‌کند.
1. یک [اسلاید طرح‌بندی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/) متعلق به یک اسلاید اصلی است و ترتیب خاصی از جای‌گذاران را تعیین می‌کند.
1. یک [اسلاید عادی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) از یک طرح‌بندی استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌کند.

یک اسلاید عادی قالب‌بندی و تم را از طرح‌بندی خود ارث می‌برد و طرح‌بندی نیز از اسلاید اصلی ارث می‌برد. مقداری که مستقیماً بر روی اسلاید عادی تنظیم شود، مقدار ارث‌بری را در همان سطح بازنویسی می‌کند. هنگام ایجاد یک اسلاید عادی، اشکال جای‌گذار آن از طرح‌بندی انتخاب شده تولید می‌شوند، در حالی که محتوای وارد شده در این جای‌گذارها متعلق به اسلاید عادی است.

قبل از ایجاد اسلایدها، جای‌گذاران مورد نیاز را به طرح‌بندی اضافه کنید. افزودن یک جای‌گذار دیگر به طرح‌بندی پس از ایجاد اسلایدهای عادی، به‌صورت خودکار به‌عنوان شکل جای‌گذار در اسلایدهای موجود اضافه نمی‌شود.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی ارث‌بری یا هندسه‌ی جای‌گذارهای موجود در یک طرح‌بندی می‌تواند همه اسلایدهایی را که به آن وابسته‌اند به‌روزرسانی کند. قبل از ویرایش طرح‌بندی‌ای که در حال استفاده است، اسلایدهای وابسته را بررسی و ارائه نهایی را مرور کنید.
- یک طرح‌بندی که هنوز توسط اسلایدی استفاده می‌شود، نمی‌تواند حذف شود. ابتدا اسلایدهای وابسته را به طرح‌بندی دیگری منتقل کنید یا فقط طرح‌بندی‌های بدون استفاده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالای این سلسله‌مراتب، به [اسلاید مستر](/slides/fa/java/slide-master/) مراجعه کنید.

## **انتخاب و اعمال یک طرح‌بندی اسلاید**

زمانی که ارائه از تعاریف استاندارد طرح‌بندی پاورپوینت پیروی می‌کند، از یک نوع طرح‌بندی استفاده کنید. نام‌های طرح‌بندی قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر پایه نام تا زمانی که کنترل الگوی منبع را داشته باشید، قابل اطمینان نیست.

مثال زیر به دنبال **عنوان و محتوا** در اولین اسلاید اصلی می‌گردد. اگر آن طرح‌بندی موجود نباشد، عمداً به **خالی** بازمی‌گردد. بررسی دوم null ضروری است زیرا یک ارائه می‌تواند تنها شامل طرح‌بندی‌های سفارشی باشد. طرح‌بندی انتخاب‌شده سپس از طریق متد [ISlide.setLayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) به اولین اسلاید عادی اعمال می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تغییر طرح‌بندی یک اسلاید، اشکال عادی افزوده‌شده مستقیم به اسلاید را حذف نمی‌کند. با این حال، موقعیت‌های جای‌گذار، قالب‌بندی ارث‌بری و تطابق بین جای‌گذارهای موجود و طرح‌بندی جدید می‌توانند تغییر کنند؛ بنابراین هنگام جابجایی بین طرح‌بندی‌های به‌طور قابل‌توجه متفاوت، خروجی را بررسی کنید.

## **افزودن یک اسلاید طرح‌بندی**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک طرح‌بندی موجود را انتخاب می‌کرد؛ آن را ایجاد نمی‌کرد. برای ساخت یک طرح‌بندی، متد [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) را روی مجموعهٔ طرح‌بندی‌های اسلاید اصلی هدف صدا بزنید.

مثال زیر همیشه یک طرح‌بندی جدید **عنوان و محتوا** به نام `Report Title and Content` اضافه می‌کند، سپس یک اسلاید عادی مبتنی بر آن ایجاد می‌کند. نام‌های طرح‌بندی باید درون مجموعه یکتان باشند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

فقط وقتی الگوی واقعی نیاز به یک ساختار قابل‌استفادهٔ دیگر دارد، یک طرح‌بندی اضافه کنید. اگر یک طرح‌بندی مناسب موجود است، به‌جای ایجاد یک کپی، آن را انتخاب و بازاستفاده کنید.

## **افزودن جای‌گذارها به یک اسلاید طرح‌بندی**

متد [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) یک [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/) برای افزودن اشکال جای‌گذار به یک طرح‌بندی فراهم می‌کند.

| نشانگر پاورپوینت | متد `ILayoutPlaceholderManager` |
| ---------------- | -------------------------------- |
| ![محتوا](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![محتوا (عمودی)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![متن](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![متن (عمودی)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![تصویر](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![نمودار](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![جدول](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![رسانه](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![تصویر آنلاین](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

مثال زیر بررسی می‌کند که طرح‌بندی **خالی** وجود دارد، چهار جای‌گذار به آن اضافه می‌کند و سپس یک اسلاید عادی که از طرح‌بندی اصلاح‌شده استفاده می‌کند، می‌سازد. ترتیب به‌صورت عمدی است: ابتدا جای‌گذارها اضافه می‌شوند و سپس اسلاید عادی ایجاد می‌شود تا Aspose.Slides بتواند اشکال جای‌گذار متناظر را روی آن اسلاید تولید کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![جای‌گذارهای موجود بر روی اسلاید طرح‌بندی](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی ارث‌بری یا هندسهٔ جای‌گذارهای موجود در طرح‌بندی می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. یک جای‌گذار جدید به‌صورت خودکار در اسلایدهای عادی موجود پر نمی‌شود. تغییرات طرح‌بندی را روی یک کپی از ارائه تست کنید و هر اسلاید وابسته را بررسی کنید.
{{% /alert %}}

## **حذف اسلایدهای طرح‌بندی بدون استفاده**

از متد [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) برای حذف طرح‌بندی‌هایی که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد، استفاده کنید. این متد طرح‌بندی‌های هنوز در استفاده را دست‌نخورده می‌گذارد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حذف یک طرح‌بندی خاص، ابتدا از متد [hasDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) یا [getDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) آن استفاده کنید. قبل از فراخوانی متد [ILayoutSlide.remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#remove--)، اسلایدهای وابسته را انتقال دهید. تلاش برای حذف یک طرح‌بندی مورد استفاده منجر به بوجود آمدن [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پانوشت در یک اسلاید طرح‌بندی**

یک طرح‌بندی پانوشت، شمارهٔ اسلاید و نشانگر تاریخ‑زمان خود را دارد. از متد [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) برای کنترل این نشانگرها برای یک طرح‌بندی استفاده کنید. این رویکرد زمانی مفید است که به‌عنوان مثال طرح‌بندی‌های محتوا باید پانوشت نشان دهند اما طرح‌بندی‌های عنوان نه.

مثال زیر یک طرح‌بندی را به‑صورت ایمن انتخاب می‌کند و عناصر پانوشت آن را قابل‌دید می‌سازد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل نمایش پانوشت در یک اسلاید اصلی و طرح‌بندی‌های فرزند آن**

برای اعمال تنظیمات یکسان پانوشت در سرتاسر سلسله‌مراتب اسلاید اصلی، از متد [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) استفاده کنید. متدهای انتشار [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslideheaderfootermanager/) بر روی اسلاید اصلی و اسلایدهای طرح‌بندی وابسته و اسلایدهای عادی اعمال می‌شوند؛ نه فقط یک اسلاید عادی واحد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سؤالات متداول**

**تفاوت اسلاید اصلی و اسلاید طرح‌بندی چیست؟**

اسلاید اصلی تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. اسلاید طرح‌بندی متعلق به یک اسلاید اصلی است و یک ترتیب قابل‌استفادهٔ جای‌گذارها را مشخص می‌کند. اسلایدهای عادی از این طرح‌بندی‌ها استفاده می‌کنند و محتوای خاص خود را ذخیره می‌نمایند.

**آیا می‌توانم یک اسلاید طرح‌بندی را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله. با استفاده از متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) یک کپی به مجموعهٔ مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، قلم‌ها، تم‌ها، تصاویر و سایر منابع استفاده‌شده توسط طرح‌بندی منبع را نیز بررسی کنید.

**اگر یک طرح‌بندی که در حال استفاده است را تغییر دهم چه می‌شود؟**

اسلایدهای وابسته تغییرات طرح‌بندی را به ارث می‌برند مگر این‌که قالب‌بندی یا اشیای مورد تأثیر را به‌صورت محلی بازنویسی کرده باشند. بنابراین هندسهٔ جای‌گذارها و استایل‌های ارث‌بری می‌توانند یک‌باره در اسلایدهای متعدد تغییر کنند. قبل از ویرایش طرح‌بندی، از متد [getDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) برای شناسایی اسلایدهای تحت‌تأثیر استفاده کنید.

**اگر یک طرح‌بندی که هنوز استفاده می‌شود را حذف کنم چه می‌شود؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را به طرح‌بندی دیگری منتقل کنید یا از متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) برای حذف فقط طرح‌بندی‌های غیر ارجاع‌شده استفاده کنید.