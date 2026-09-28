---
title: اعمال یا تغییر طرح‌های اسلاید در جاوااسکریپت
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/nodejs-java/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- نگهدارنده
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌نشده
- قابلیت نمایش پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با زیرنویس
- عکس با زیرنویس
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "اعمال، ایجاد و اصلاح طرح‌های اسلاید در Aspose.Slides برای Node.js از طریق Java، افزودن نگهدارنده‌ها، حذف طرح‌های استفاده‌نشده و کنترل نمایش پاورقی."
---
## **مرور کلی**

یک طرح اسلاید موقعیت‌ها و قالب‌بندی نگهدارنده‌ها مانند عناوین، متن، تصاویر، نمودارها و جداول را تعریف می‌کند. اعمال یک طرح به اسلایدها ساختاری یکپارچه می‌بخشد در حالی که به هر اسلاید امکان داشتن محتوای خود را می‌دهد.

پراست‌ترین طرح‌ها شامل:

- **اسلاید عنوان**: شامل نگهدارنده‌های عنوان و زیرعنوان است.
- **عنوان و محتوا**: شامل یک نگهدارنده عنوان و یک نگهدارنده محتوای عمومی است.
- **خالی**: هیچ نگهدارنده محتوایی ندارد و زمانی مفید است که تمام اشکال به‌صورت دستی موقعیت‌یابی شوند.

## **درک وراثت طرح**

یک ارائه دارای سه سطح مرتبط است:

1. A [اسلاید اصلی](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) تعریف‌کنندهٔ تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیای عمومی است.
1. A [اسلاید طرح](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/) متعلق به اسلاید اصلی است و چینش خاصی از نگهدارنده‌ها را تعیین می‌کند.
1. A [اسلاید معمولی](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/) از یک طرح استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌نماید.

یک اسلاید معمولی تم و قالب‌بندی را از طرح خود به ارث می‌برد و طرح نیز از اسلاید اصلی وراثت می‌گیرد. مقداری که مستقیماً روی اسلاید معمولی تنظیم شود، مقدار به‌ارث‌برده را در همان سطح بازنویسی می‌کند. هنگامی که یک اسلاید معمولی ایجاد می‌شود، اشکال نگهدارنده آن از طرح انتخابی تولید می‌شوند، در حالی که محتوای وارد شده به آن نگهدارنده‌ها متعلق به اسلاید معمولی است.

قبل از ایجاد اسلایدها، نگهدارنده‌های لازم را به طرح اضافه کنید. افزودن نگهدارندهٔ دیگر به یک طرح پس از آن، به‌صورت خودکار شکل نگهدارندهٔ متناظر را به اسلایدهای معمولی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی یا هندسهٔ نگهدارنده‌های موجود در یک طرح می‌تواند تمام اسلایدهایی که به آن وابسته هستند را به‌روز کند. پیش از ویرایش طرحی که در حال استفاده است، اسلایدهای وابسته را بررسی و ارائهٔ نهایی را بازبینی کنید.
- طرحی که هنوز توسط اسلایدی استفاده می‌شود نمی‌تواند حذف شود. ابتدا اسلایدهای وابسته را به طرح دیگری منتقل کنید یا فقط طرح‌های بدون استفاده را حذف نمایید.

برای اطلاعات بیشتر دربارهٔ سطح بالایی این سلسله‌مراتب، به [اسلاید اصلی](/slides/fa/nodejs-java/slide-master/) مراجعه کنید.

برای مخفی کردن لوگوهای به‌ارث‌برده یا اشکال تزئینی اسلاید اصلی در یک اسلاید یا از طریق طرح مشترک، به [کنترل نمایش گرافیک‌های اسلاید اصلی](/slides/fa/nodejs-java/slide-master/) نگاهی بیندازید. این مثال دو اسلاید با استفاده از یک اسلاید اصلی را مقایسه می‌کند.

## **انتخاب و اعمال یک طرح اسلاید**

از مقدار [SlideLayoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidelayouttype/) زمانی استفاده کنید که ارائه از تعاریف استاندارد طرح PowerPoint پیروی می‌کند. نام‌های طرح قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر پایهٔ نام کمتر قابل اطمینان است مگر این‌که الگوی منبع را کنترل کنید.

مثال زیر به دنبال **Title and Content** در اولین اسلاید اصلی می‌گردد. اگر آن طرح موجود نباشد، عمداً به **Blank** باز می‌گردد. بررسی null دوم ضروری است زیرا یک ارائه می‌تواند فقط شامل طرح‌های سفارشی باشد. سپس طرح انتخاب‌شده از طریق متد [Slide.setLayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#setLayoutSlide) بر اولین اسلاید معمولی اعمال می‌شود.

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

تغییر طرح یک اسلاید، اشکال معمولی اضافه‌شده مستقیماً به اسلاید را حذف نمی‌کند. با این حال، موقعیت‌های نگهدارنده، قالب‌بندی‌های به‌ارث‌برده و تطابق بین نگهدارنده‌های موجود و طرح جدید ممکن است تغییر کند، بنابراین هنگام جابجایی بین طرح‌های به‌اطلاعات متفاوت، خروجی را با دقت بررسی کنید.

## **افزودن یک اسلاید طرح**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک طرح موجود را انتخاب کرد؛ طرحی ایجاد نکرد. برای ایجاد یک طرح، متد [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) را روی مجموعهٔ طرح‌های اسلاید اصلی هدف فراخوانی کنید.

مثال زیر همیشه یک طرح **Title and Content** جدید به نام `Report Title and Content` اضافه می‌کند، سپس یک اسلاید معمولی بر پایهٔ آن می‌سازد. نام‌های طرح درون مجموعه باید یکتا باشند.

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

فقط وقتی الگو به‌طور واقعی نیاز به ساختار قابل استفادهٔ دیگری دارد، طرح اضافه کنید. اگر طرح مناسبی پیش‌اپ پیش موجود باشد، به‌جای ایجاد نسخهٔ تکراری، آن را انتخاب و مجدداً استفاده کنید.

## **افزودن نگهدارنده‌ها به اسلاید طرح**

متد [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) یک [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/) برای افزودن اشکال نگهدارنده به طرح فراهم می‌کند.

| نگهدارنده PowerPoint | `LayoutPlaceholderManager` Method |
| --------------------- | --------------------------------- |
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

مثال زیر موجود بودن طرح **Blank** را تأیید می‌کند، چهار نگهدارنده به آن اضافه می‌نماید و سپس یک اسلاید معمولی که از طرح اصلاح‌شده استفاده می‌کند، می‌سازد. ترتیب کار عمدی است: ابتدا نگهدارنده‌ها افزوده می‌شوند و سپس اسلاید معمولی ساخته می‌شود تا Aspose.Slides بتواند اشکال نگهدارندهٔ متناظر را روی آن اسلاید تولید کند.

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

![نگهدارنده‌ها روی اسلاید طرح](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی به‌ارث‌برده یا هندسهٔ نگهدارنده‌های موجود در طرح می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. یک نگهدارندهٔ طرح تازه اضافه‌شده به‌صورت خودکار به اسلایدهای معمولی موجود بازنگری نمی‌شود. تغییرات طرح را روی یک کپی از ارائه آزمایش کنید و هر اسلاید وابسته را بررسی نمایید.
{{% /alert %}}

## **حذف اسلایدهای طرح استفاده‌نشده**

از متد [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) برای حذف طرح‌هایی که هیچ اسلاید معمولی به آن‌ها ارجاع نمی‌دهد، استفاده کنید. این متد طرح‌های هنوز در استفاده را دست‌نخورده می‌گذارد.

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

برای حذف یک طرح خاص، ابتدا از متدهای [hasDependingSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) یا [getDependingSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) آن استفاده کنید. پیش از فراخوانی [LayoutSlide.remove](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#remove) اسلایدهای وابسته را مجدداً تخصیص دهید. تلاش برای حذف یک طرح در حال استفاده یک استثنای [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxeditexception/) را برمی‌انگیزد.

## **کنترل نمایش پاورقی در اسلاید طرح**

یک طرح دارای پاورقی، شماره اسلاید و نگهدارنده‌های تاریخ‑زمان مخصوص به خود است. برای کنترل این نگهدارنده‌ها در یک طرح، از متد [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) استفاده کنید. این کار زمانی مفید است که برای مثال طرح‌های محتوا باید پاورقی نشان دهند ولی طرح‌های عنوان نباید.

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

## **کنترل نمایش پاورقی در اسلاید اصلی و طرح‌های فرزند آن**

برای اعمال تنظیمات یکنواخت پاورقی در سراسر سلسله‌مراتب اسلاید اصلی، از متد [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) استفاده کنید. متدهای انتشار [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslideheaderfootermanager/) بر روی اسلاید اصلی و اسلایدهای طرح وابسته و اسلایدهای معمولی آن عمل می‌کنند؛ هدف آن‌ها فقط یک اسلاید معمولی نیست.

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

## **سوالات متداول**

**تفاوت بین اسلاید اصلی و اسلاید طرح چیست؟**

اسلاید اصلی تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. اسلاید طرح متعلق به یک اسلاید اصلی است و یک چینش قابل استفادهٔ مجدد از نگهدارنده‌ها را مشخص می‌کند. اسلایدهای معمولی از این طرح‌ها استفاده می‌کنند و محتوای خاص خود را ذخیره می‌نمایند.

**آیا می‌توانم یک اسلاید طرح را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله. با استفاده از متد [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) یک کپی به مجموعهٔ مقصد اضافه کنید. هنگام کپی‌کردن بین ارائه‌ها، فونت‌ها، تم‌ها، تصاویر و سایر منابع مورد استفادهٔ طرح منبع را نیز بررسی کنید.

**وقتی یک طرح که در حال استفاده است را تغییر می‌دهم چه می‌شود؟**

اسلایدهای وابسته تغییرات طرح را به‌ارث می‌برند مگر این‌که قالب‌بندی یا اشیای مرتبط را به‌صورت محلی بازنویسی کرده باشند. بنابراین هندسهٔ نگهدارنده‌ها و شیوه‌های به‌ارث‌برده می‌تواند به‌طور همزمان بر بسیاری از اسلایدها تغییر کند. قبل از ویرایش طرح، با استفاده از [getDependingSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) اسلایدهای تحت تأثیر را شناسایی کنید.

**اگر یک طرح هنوز در استفاده باشد را حذف کنم چه اتفاقی می‌افتد؟**

Aspose.Slides یک استثنای [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را به طرح دیگری منتقل کنید یا از متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) برای حذف فقط طرح‌های بدون ارجاع استفاده کنید.