---
title: مدیریت مسترهای اسلاید ارائه در جاوااسکریپت
linktitle: مستر اسلاید
type: docs
weight: 70
url: /fa/nodejs-java/slide-master/
keywords:
- مستر اسلاید
- اسلاید مستر
- اسلاید مستر PPT
- چندین اسلاید مستر
- مقایسه اسلایدهای مستر
- پس‌زمینه
- جای‌گیر
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکراری کردن اسلاید مستر
- اسلاید مستر بدون استفاده
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت مسترهای اسلاید در Aspose.Slides برای Node.js از طریق Java: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

یک **Slide Master** تنظیمات طراحی مشترک برای یک گروه از اسلایدها را تعریف می‌کند. می‌تواند شامل اشکال عمومی، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات قالب و تنظیمات پاورقی باشد. در PowerPoint، ویرایش یک Slide Master راه معمول برای حفظ یکپارچگی ارائه بدون تکرار همان قالب‌بندی در هر اسلاید است.

Aspose.Slides for Node.js via Java از همین مدل پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند اسلاید مستر داشته باشد و هر اسلاید مستر می‌تواند چندین اسلاید چیدمان را در بر داشته باشد. اسلایدهای معمولی معمولاً مستقیماً به اسلاید مستر ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از یک اسلاید چیدمان استفاده می‌کند و آن اسلاید چیدمان به یک اسلاید مستر تعلق دارد.

سلسله مراتب به شرح زیر است:

1. **Slide master** – تنظیمات طراحی و قالب مشترک را تعریف می‌کند.  
1. **Layout slide** – ترتیب خاصی از جای‌گیرها و قالب‌بندی سطح چیدمان را تعریف می‌کند.  
1. **Normal slide** – محتویات واقعی ارائه را شامل می‌شود و از یک اسلاید چیدمان استفاده می‌کند.

![سلسله مراتب اسلایدهای مستر، اسلایدهای چیدمان و اسلایدهای معمولی](slide-master_2.jpg)

در Aspose.Slides، یک Slide Master توسط کلاس [MasterSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) نشان داده می‌شود. تمام اسلایدهای مستر در یک ارائه از طریق مجموعه `Presentation.getMasters()` در دسترس هستند.

{{% alert color="info" title="ارث‌بری" %}}
زمانی که یک ویژگی در بیش از یک سطح تعریف شود، سطح خاص‌تر برتری دارد. به عنوان مثال، اگر یک اسلاید مستر و یک اسلاید چیدمان هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن چیدمان از پس‌زمینهٔ چیدمان استفاده می‌کنند. برای اطلاعات بیشتر دربارهٔ اسلایدهای چیدمان، به [Apply or Change Slide Layouts](/nodejs-java/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به Slide Masters**

در PowerPoint، می‌توانید نمای Slide Master را از **View** > **Slide Master** باز کنید.

![دستور Slide Master در برگه View برنامه PowerPoint](slide-master_3.jpg)

در Aspose.Slides، برای دسترسی به اسلایدهای مستر از مجموعه `getMasters()` استفاده کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید اسلاید مستری که یک اسلاید معمولی از طریق چیدمان خود استفاده می‌کند، به دست آورید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **چه چیزی در یک Slide Master وجود دارد**

یک اسلاید مستر یک شیء شبیه به اسلاید است. این شیء رفتارهای عمومی اسلاید را از [BaseSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/) ارث می‌برد، بنابراین بسیاری از خصوصیات اسلایدهای معمولی و چیدمان را در اختیار می‌گذارد. اعضای خاص مستر در صفحه API [MasterSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/) فهرست شده‌اند.

اعضای معمولاً استفاده‌شدهٔ اسلاید مستر عبارتند از:

| عضو | هدف |
| --- | --- |
| `getBackground()` | پس‌زمینهٔ سطح مستر اسلاید را تنظیم می‌کند. |
| `getShapes()` | اشکالی که روی مستر قرار گرفته‌اند، مانند لوگوها، قاب‌های تصویر و متن‌های مشترک، را ذخیره می‌کند. |
| `getLayoutSlides()` | اسلایدهای چیدمان متعلق به مستر را ذخیره می‌کند. |
| `getThemeManager()` | دسترسی به APIهای تم مستر را فراهم می‌کند. |
| `getHeaderFooterManager()` | سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شماره اسلایدها را برای مستر و چیدمان‌های فرزند آن کنترل می‌کند. |
| `getDependingSlides()` | اسلایدهای معمولی که از طریق چیدمان‌های خود به مستر وابسته هستند را برمی‌گرداند. |

## **افزودن تصویر به یک Slide Master**

زمانی که یک تصویر را به یک اسلاید مستر اضافه کنید، بر روی اسلایدهایی که از چیدمان‌های آن مستر استفاده می‌کنند ظاهر می‌شود. این کار برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین اسلاید مستر اضافه می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای اطلاعات بیشتر دربارهٔ قاب‌های تصویر، به [Picture Frame](/nodejs-java/picture-frame/) مراجعه کنید.

## **کنترل قابلیت مشاهده گرافیک‌های مستر**

از [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) برای مخفی کردن گرافیک‌های ارث‌برداری مستر، مانند لوگوها یا اشکال تزئینی، بدون حذف آنها از مستر استفاده کنید. مقدار `false` را به [Slide.setShowMasterShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#setShowMasterShapes) در اسلایدی که باید این گرافیک‌ها حذف شوند، پاس دهید و در اسلایدهایی که باید نمایش داده شوند مقدار `true` را حفظ کنید.

مثال زیر یک نوار تزئینی آبی رنگ بر روی یک مستر و دو اسلاید که از همان چیدمان خالی استفاده می‌کنند، ایجاد می‌کند. نوار در اولین اسلاید قابل مشاهده و در دومین اسلاید مخفی است. نیازی به ارائه ورودی یا تصویر نیست.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این مثال از چیدمان **Blank** که همراه یک ارائهٔ جدید ارائه می‌شود استفاده می‌کند و جای‌گیرهای خود اسلاید اولیه را حذف می‌کند.

### **انتخاب دامنهٔ تنظیم**

یک اسلاید معمولی از مستر خود از طریق [Slide.getLayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getLayoutSlide) و [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getMasterSlide) استفاده می‌کند. تنظیم این ویژگی بر روی یک اسلاید منفرد تنها بر همان اسلاید اثر می‌گذارد. پاس دادن `false` به [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) گرافیک‌های مستر را برای اسلایدهایی که از آن چیدمان مشترک استفاده می‌کنند مخفی می‌کند، حتی اگر تنظیم شخصی آنها `true` باشد. برای مخفی کردن گرافیک تنها در یک اسلاید، ویژگی اسلاید را تغییر دهید و چیدمان مشترک را دست‌نخورده نگه دارید.

این تنظیم به عنوان کنترل قابلیت مشاهده برای خود اسلاید مستر پشتیبانی نمی‌شود. در یک مستر، [getShowMasterShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) همیشه `false` برمی‌گرداند و پاس دادن `true` به [setShowMasterShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) باعث ایجاد استثنا می‌شود. به جای آن این ویژگی را بر روی اسلاید معمولی یا چیدمان اعمال کنید.

### **تمییز گرافیک‌ها از پس‌زمینه**

| عملیات | تأثیر |
| --- | --- |
| مخفی کردن گرافیک‌های مستر | قابلیت مخفی کردن اشکال ارث‌برداری مستر را بدون حذف یا تغییر اشکال خود اسلاید کنترل می‌کند. |
| تغییر پر پس‌زمینهٔ اسلاید | رنگ، گرادیان یا تصویر پس‌زمینه اسلاید را تغییر می‌دهد. اشکال مستر شکل‌های جداگانه‌ای هستند و می‌توانند روی آن پس‌زمینه قابل مشاهده بمانند. برای اطلاعات بیشتر به [Presentation Background](/slides/fa/nodejs-java/presentation-background/) مراجعه کنید. |
| حذف یک شکل از مستر | شکل منبع مشترک را حذف می‌کند؛ بنابراین برای هیچ اسلایدی که از آن مستر استفاده می‌کند دیگر در دسترس نیست. |

## **کار با جای‌گیرها**

جای‌گیرها به‌طور معمول در اسلایدهای چیدمان تعریف می‌شوند. اسلاید مستر سبک و تم مشترکی را که آن چیدمان‌ها به ارث می‌برند، فراهم می‌کند، در حالی که هر چیدمان تصمیم می‌گیرد کدام جای‌گیرها در دسترس هستند و در کجا قرار می‌گیرند.

در PowerPoint، دستورات جای‌گیر در نمای Slide Master در دسترس هستند.

![دستورات Insert Placeholder در نمای Slide Master برنامه PowerPoint](slide-master_5.png)

برای افزودن جای‌گیرهای جدید با Aspose.Slides، با اسلاید چیدمانی که به مستر تعلق دارد کار کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید اشکال جای‌گیر که قبلاً بر روی یک اسلاید مستر وجود دارند را قالب‌بندی کنید. مثال زیر جای‌گیر عنوان را پیدا کرده و یک پرشدن گرادیان خطی به آن اعمال می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![جای‌گیر عنوان قالب‌بندی‌شده که توسط اسلایدهای معمولی به ارث می‌رسد](slide-master_8.png)

برای گزینه‌های بیشتر قالب‌بندی جای‌گیر و متن، به [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) و [Text Formatting](/nodejs-java/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینهٔ Slide Master**

یک پس‌زمینهٔ مستر توسط چیدمان‌ها و اسلایدهایی که آن را بازنویسی نمی‌کنند، به ارث برده می‌شود. مثال زیر یک رنگ پس‌زمینهٔ ثابت برای اولین اسلاید مستر تنظیم می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای موضوعات مرتبط، به [Presentation Background](/nodejs-java/presentation-background/) و [Presentation Theme](/nodejs-java/presentation-theme/) مراجعه کنید.

## **کلون کردن یک Slide Master به ارائه دیگر**

از `MasterSlideCollection.addClone` برای کپی کردن یک اسلاید مستر به ارائهٔ دیگری استفاده کنید. مستر کپی‌شده سپس می‌تواند توسط چیدمان‌ها و اسلایدهای موجود در ارائه مقصد استفاده شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

اگر نیاز به کلون کردن اسلایدهای معمولی به همراه مسترشان دارید، به [Clone Slides](/nodejs-java/clone-slides/) مراجعه کنید.

## **افزودن چندین Slide Master**

یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. این موضوع زمانی مفید است که بخش‌های متفاوت نیاز به برندسازی، ساختار صفحه یا تنظیمات تم متفاوتی داشته باشند.

![دستورات PowerPoint برای افزودن و مدیریت اسلایدهای مستر](slide-master_9.jpg)

مثال زیر مستر پیش‌فرض را کلون می‌کند، پس‌زمینهٔ متفاوتی به کلون می‌دهد، یک چیدمان زیر آن مستر کلون‌شده ایجاد می‌کند و یک اسلاید جدید بر پایهٔ آن چیدمان اضافه می‌نماید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مقایسهٔ Slide Masters**

اسلایدهای مستر می‌توانند با روش `equals` که از [BaseSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/) ارث می‌برند، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های یکتا مانند شناسهٔ اسلاید یا مقادیر پویا مثل تاریخ جاری در مقایسه در نظر گرفته نمی‌شوند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

برای اطلاعات بیشتر، به [Compare Presentation Slides](/slides/fa/nodejs-java/compare-slides/) مراجعه کنید.

## **تنظیم نمای Slide Master به عنوان نمای پیش‌فرض**

از متد `setLastView` در [ViewProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای Slide Master باز می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای تنظیمات بیشتر نمای، به [Save Presentation](/slides/fa/nodejs-java/save-presentation/) مراجعه کنید.

## **حذف اسلایدهای مستر بدون استفاده**

گاهی اوقات ارائه‌ها شامل اسلایدهای مستری می‌شوند که دیگر توسط هیچ اسلاید معمولی استفاده نمی‌شوند. حذف مسترهای بلااستفاده می‌تواند حجم فایل را کاهش داده و نگهداری قالب‌ها را ساده‌تر کند.

از `removeUnused` برای حذف مسترهای بلااستفاده از مجموعه `getMasters()` استفاده کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید از متد کم‌کد `Compress.removeUnusedMasterSlides` بهره بگیرید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**تفاوت بین Slide Master و Layout Slide چیست؟**

Slide Master تنظیمات طراحی مشترک مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متن را تعریف می‌کند. Layout Slide به یک Slide Master تعلق دارد و ترتیب خاصی از جای‌گیرها را تعریف می‌کند. یک اسلاید معمولی از یک Layout Slide استفاده می‌کند، بنابراین از هر دو، چیدمان و مستر، ارث می‌برد.

**آیا یک ارائه می‌تواند چندین Slide Master داشته باشد؟**

بله. یک ارائه می‌تواند چندین Slide Master داشته باشد. زمانی که بخش‌های مختلف نیاز به سیستم‌های بصری یا برندسازی متفاوتی دارند، از مسترهای متعدد استفاده کنید.

**آیا باید جای‌گیرها را به Slide Master اضافه کنم یا به Layout Slide؟**

در بیشتر موارد، جای‌گیرها را به Layout Slideها اضافه کنید. عناصر بصری مشترک و قالب‌بندی مشترک را روی Slide Master قرار دهید و سپس جای‌گیرهای محتوا را روی Layoutهایی که اسلایدهای معمولی از آنها استفاده می‌کنند، بگذارید.

**آیا می‌توانم یک Slide Master که هنوز استفاده می‌شود را حذف کنم؟**

خیر. یک Slide Master که اسلایدهای وابسته دارد، نمی‌تواند به‌صورت مستقیم حذف شود. ابتدا آن اسلایدها را به چیدمان‌های تحت یک مستر دیگر منتقل کنید یا از روشی برای حذف تنها مسترهای بلااستفاده استفاده کنید.