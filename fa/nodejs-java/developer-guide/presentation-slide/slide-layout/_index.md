---
title: "اعمال یا تغییر طرح اسلاید در جاوااسکریپت"
linktitle: "طرح اسلاید"
type: docs
weight: 60
url: /fa/nodejs-java/slide-layout/
keywords:
- "طرح اسلاید"
- "طرح محتوا"
- "جای‌گیر"
- "طراحی ارائه"
- "طراحی اسلاید"
- "طرح استفاده‌نشده"
- "قابلیت نمایش پابرگ"
- "اسلاید عنوان"
- "عنوان و محتوا"
- "سربرگ بخش"
- "دو محتوا"
- "مقایسه"
- "فقط عنوان"
- "طرح خالی"
- "محتوا با عنوان فرعی"
- "تصویر با عنوان فرعی"
- "عنوان و متن عمودی"
- "عنوان عمودی و متن"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "اعمال، ایجاد و اصلاح طرح‌های اسلاید در Aspose.Slides برای Node.js از طریق Java، اضافه‌کردن جای‌گیرها، حذف طرح‌های استفاده‌نشده، و کنترل نمایش پابرگ."
---
## **نمای کلی**

یک طرح اسلاید موقعیت‌ها و قالب‌بندی جای‌گیرها مانند عنوان‌ها، متن، تصاویر، نمودارها و جدول‌ها را تعریف می‌کند. اعمال یک طرح به اسلایدها ساختاری سازگار می‌بخشد در حالی که اجازه می‌دهد هر اسلاید محتوای خود را داشته باشد.

رایج‌ترین طرح‌ها شامل:

- **Title Slide**: شامل جای‌گیرهای عنوان و زیرعنوان است.
- **Title and Content**: شامل یک جای‌گیر عنوان و یک جای‌گیر محتوای عمومی است.
- **Blank**: هیچ جای‌گیر محتوایی ندارد و زمانی مفید است که هر شکل به‌صورت دستی قرار داده شود.

## **درک ارث‌بری طرح**

یک ارائه سه سطح مرتبط دارد:

1. یک [master slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیای عمومی را تعریف می‌کند.
1. یک [layout slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) به یک master تعلق دارد و ترتیب خاصی از جای‌گیرها را تعریف می‌کند.
1. یک [normal slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/) از یک طرح استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌کند.

یک normal slide تم و قالب‌بندی را از طرح خود به ارث می‌برد و طرح نیز از master ارث می‌برد. مقدار تعیین‌شده به‌صورت مستقیم بر یک normal slide مقدار ارث‌بری در همان سطح را بازنویسی می‌کند. هنگام ایجاد یک normal slide، شکل‌های جای‌گیر آن از طرح منتخب تولید می‌شوند، در حالی که محتوای وارد شده در آن جای‌گیرها متعلق به normal slide است.

پیش از ایجاد اسلایدها از یک طرح، جای‌گیرهای مورد نیاز را به آن اضافه کنید. افزودن جای‌گیر دیگر به یک طرح بعداً به‌صورت خودکار شکل جای‌گیر متناظر را به اسلایدهای normal موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی ارث‌بری یا هندسه جای‌گیرهای موجود در یک layout می‌تواند تمام اسلایدهای وابسته به آن را به‌روز کند. پیش از ویرایش یک layout که هم‌اکنون استفاده می‌شود، اسلایدهای وابسته به آن را بررسی کنید و ارائه حاصل را مرور نمایید.
- یک layout که هنوز توسط اسلایدی استفاده می‌شود نمی‌تواند حذف شود. ابتدا اسلایدهای وابسته آن را به layout دیگری اختصاص دهید یا فقط layoutهای بدون استفاده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالایی این سلسله‌مراتب، به [Slide Master](/slides/fa/nodejs-java/slide-master/) مراجعه کنید.

## **انتخاب و اعمال یک طرح اسلاید**

هنگامی که ارائه از تعریف‌های استاندارد طرح PowerPoint پیروی می‌کند، از مقدار [SlideLayoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidelayouttype/) استفاده کنید. نام‌های طرح قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر اساس نام کمتر قابل اطمینان است مگر این‌که الگوی منبع را کنترل کنید.

مثال زیر به دنبال **Title and Content** در اولین master می‌گردد. اگر آن layout در دسترس نباشد، عمداً به **Blank** باز می‌گردد. بررسی null دوم ضروری است چون یک ارائه می‌تواند فقط شامل layoutهای سفارشی باشد. سپس layout انتخاب‌شده از طریق متد [Slide.setLayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#setLayoutSlide) به اولین normal slide اعمال می‌شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تغییر layout یک اسلاید اشکال عادی اضافه‌شده مستقیماً به اسلید را حذف نمی‌کند. با این حال، موقعیت‌های جای‌گیر، قالب‌بندی ارث‌بری و تطابق بین جای‌گیرهای موجود و layout جدید می‌توانند تغییر کنند، بنابراین هنگام جابجایی بین layoutهای به‌طور قابل‌توجه متفاوت، خروجی را بررسی کنید.

## **افزودن یک Layout Slide**

انتخاب و ایجاد عملیات جداگانه‌ای هستند. مثال قبلی یک layout موجود را انتخاب می‌کند؛ آن را ایجاد نمی‌کند. برای ایجاد یک layout، متد [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) را بر روی مجموعه layoutهای master هدف صدا بزنید.

مثال زیر همیشه یک layout جدید **Title and Content** با نام `Report Title and Content` اضافه می‌کند، سپس یک normal slide بر پایه آن می‌افزاید. نام‌های layout باید درون مجموعه یکتا باشند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

فقط زمانی layout اضافه کنید که الگو واقعا به یک ساختار قابل‌استفاده دیگر نیاز داشته باشد. اگر یک layout مناسب از پیش وجود دارد، آن را انتخاب و دوباره استفاده کنید به‌جای ایجاد یک نسخهٔ مشابه.

## **افزودن جای‌گیرها به یک Layout Slide**

متد [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) یک [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/) را برای افزودن شکل‌های جای‌گیر به یک layout ارائه می‌دهد.

| جای‌گیر PowerPoint | `LayoutPlaceholderManager` متد |
| ----------------------------------- | --------------------------------- |
| ![محتوا](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![محتوا (عمودی)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![متن](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![متن (عمودی)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![عکس](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![نمودار](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![جدول](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![رسانه](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![تصویر آنلاین](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

مثال زیر بررسی می‌کند که layout **Blank** وجود دارد، چهار جای‌گیر به آن اضافه می‌کند و سپس یک normal slide که از layout اصلاح‌شده استفاده می‌کند ایجاد می‌نماید. ترتیب به‌صورت عمدی است: جای‌گیرها قبل از ایجاد normal slide اضافه می‌شوند، بنابراین Aspose.Slides می‌تواند شکل‌های جای‌گیر مربوطه را بر آن اسلاید تولید کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![جای‌گیرها بر اسلاید layout](add_placeholders.png)

{{% alert color="warning" title="هشدار" %}}
تغییر قالب‌بندی ارث‌بری یا هندسهٔ جای‌گیرهای موجود در layout می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. یک جای‌گیر جدید به layout به‌صورت خودکار به اسلایدهای normal موجود اضافه نمی‌شود. تغییرات layout را روی یک نسخهٔ کپی از ارائه تست کنید و هر اسلاید وابسته را بررسی نمایید.
{{% /alert %}}

## **حذف اسلایدهای Layout استفاده‌نشده**

از متد [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) برای حذف layoutهایی که هیچ اسلاید normal ارجاعی به آن ندارند استفاده کنید. این متد layoutهای هنوز در استفاده را دست‌نخورده می‌گذارد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حذف یک layout خاص، ابتدا از متدهای [hasDependingSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) یا [getDependingSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) آن استفاده کنید. پیش از فراخوانی [LayoutSlide.remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#remove) اسلایدهای وابسته را مجدداً اختصاص دهید. تلاش برای حذف یک layout استفاده‌شده منجر به پرتاب [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پابرگ در یک Layout Slide**

یک layout دارای پابرگ، شماره اسلاید و جای‌گیرهای تاریخ‑زمان خود است. برای کنترل این جای‌گیرها برای یک layout از متد [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) استفاده کنید. این کار زمانی مفید است که مثلاً layoutهای محتوا باید پابرگ‌ها را نشان دهند ولی layoutهای عنوان نه.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل نمایش پابرگ در یک Master و Layoutهای فرزند آن**

برای اعمال تنظیمات پابرگ یکسان در کل سلسله‌مراتب master، از متد [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) استفاده کنید. متدهای انتشار [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslideheaderfootermanager/) بر روی master و layout slideهای وابسته و اسلایدهای normal اعمال می‌شود؛ آن‌ها فقط یک اسلاید normal را هدف قرار نمی‌دهند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**تفاوت بین Master Slide و Layout Slide چیست؟**

یک master slide تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. یک layout slide به یک master تعلق دارد و یک ترتیب قابل‌استفاده مجدد از جای‌گیرها را تعریف می‌کند. اسلایدهای normal از این layoutها استفاده می‌کنند و محتوای خاص هر اسلاید را ذخیره می‌نمایند.

**آیا می‌توانم یک Layout Slide را از یک ارائه به ارائه دیگری کپی کنم؟**

بله. یک کپی را با متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) به مجموعه مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصاویر و سایر منابع استفاده‌شده توسط layout منبع را نیز بررسی کنید.

**چه اتفاقی می‌افتد وقتی یک Layout که در حال استفاده است را تغییر می‌دهم؟**

اسلایدهای وابسته تغییرات layout را به‌ارث می‌برند مگر این‌که قالب‌بندی یا اشیای مؤثر را به‌صورت محلی بازنویسی کنند. هندسهٔ جای‌گیرها و سبک‌های ارث‌بری می‌تواند بر چندین اسلاید به‌طور همزمان تغییر کند. قبل از ویرایش layout از [getDependingSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) برای شناسایی اسلایدهای تحت‌تاثیر استفاده کنید.

**چه اتفاقی می‌افتد اگر یک Layout که هنوز در استفاده است را حذف کنم؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را مجدداً اختصاص دهید، یا از [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) برای حذف تنها layoutهای بدون ارجاع استفاده کنید.