---
title: مدیریت اشیاء جوهر ارائه در جاوا اسکریپت
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/nodejs-java/manage-ink/
keywords:
- جوهر
- شیء جوهر
- رد‌گیری جوهر
- مدیریت جوهر
- رسم جوهر
- رسم
- صادرات جوهر
- رندرینگ جوهر
- مخفی کردن جوهر
- InkOptions
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت اشیاء جوهر PowerPoint، ویرایش رد‌گیری‌ها و ویژگی‌های قلم، و کنترل ظاهر جوهر هنگام خروجی PDF، HTML، SVG، TIFF و تصویر با Aspose.Slides برای Node.js از طریق Java."
---
## **معرفی**

PowerPoint ویژگی «جوهر» (ink) را فراهم می‌کند که به شما اجازه می‌دهد خطوط آزاد رسم کنید. می‌توانید از جوهر برای هایلایت کردن اشیاء دیگر، نشان دادن ارتباط‌ها و فرآیندها و جلب توجه به موارد خاص در یک اسلاید استفاده کنید.

Aspose.Slides انواع مورد نیاز برای کار با اشیاء جوهر را ارائه می‌دهد. به عنوان مثال، کلاس [Ink](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ink/) نمایانگر یک شیء جوهر روی اسلاید است.

## **تفاوت بین اشیاء معمولی و اشیاء جوهر**

اشیاء روی یک اسلاید PowerPoint معمولاً توسط اشیاء شکل (shape) نمایش داده می‌شوند. در ساده‌ترین شکل، یک shape یک ظرف است که ناحیه خود شیء (قاب آن) را به همراه ویژگی‌هایی مثل اندازه ظرف، شکل و پس‌زمینه تعریف می‌کند. برای اطلاعات بیشتر به [Shape Layout Format](https://docs.aspose.com/slides/fa/nodejs-java/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

اما وقتی PowerPoint یک شیء جوهر را مدیریت می‌کند، تمام ویژگی‌های قاب شیء (ظرف) به جز اندازه‌اش را نادیده می‌گیرد. اندازهٔ ناحیهٔ ظرف توسط متدهای استاندارد [Shape.getWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getWidth--) و [Shape.getHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getHeight--) تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیابی‌های جوهر**

یک رد‌گیری جوهر (ink trace) عنصر پایه‌ای است که مسیر حرکت قلم را هنگام نوشتن جوهر دیجیتال ثبت می‌کند. یک رد‌گیری مجموعه‌ای از نقاط متصل را ذخیره می‌کند.

ساده‌ترین شکل رمزگذاری، مختصات X و Y هر نقطه نمونه را مشخص می‌کند. هنگامی که تمام نقاط متصل رندر شوند، تصویر زیر به‌دست می‌آید:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های قلم برای رسم**

یک قلم (brush) برای رسم خطوطی که نقاط یک رد‌گیری جوهر را به هم وصل می‌کند، استفاده می‌شود. قلم دارای رنگ و اندازهٔ خود است که توسط متدهای [InkBrush.getColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkbrush/#getColor--) و [InkBrush.getSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkbrush/#getSize--) در دسترس است.

### **تنظیم رنگ قلم جوهر**

این کد JavaScript نشان می‌دهد چگونه رنگ یک قلم جوهر تنظیم شود:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **تنظیم اندازه قلم جوهر**

این کد JavaScript نشان می‌دهد چگونه اندازهٔ یک قلم جوهر تنظیم شود:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

به‌طور کلی، عرض و ارتفاع یک قلم یکی نیستند، بنابراین PowerPoint اندازهٔ قلم را نمایش نمی‌دهد (بخش مربوطه خاکستری می‌شود). وقتی عرض و ارتفاع قلم برابر باشد، PowerPoint اندازهٔ آن را به این شکل نشان می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را مرور می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

قاب (frame) اندازهٔ قلم‌ها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر قبلی نگاه کنید).

بنابراین، برای تعیین ناحیهٔ قابل مشاهدهٔ کل شیء جوهر، باید اندازهٔ قلم‌های رد‌گیری‌های آن محاسبه شود. در اینجا، شیء هدف (ردیابی متن دست‌نویس) به اندازهٔ ظرف (قاب) مقیاس‌بندی شده است. وقتی اندازهٔ ظرف تغییر می‌کند، اندازهٔ قلم ثابت می‌ماند و برعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint رفتار مشابهی برای اشیاء متنی اعمال می‌کند:

![ink_powerpoint6](ink_powerpoint6.png)

## **کنترل ظاهر جوهر هنگام خروجی و رندرینگ**

Aspose.Slides کلاس [InkOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/) را برای کنترل نحوهٔ نمایش اشیاء جوهر در خروجی یا رندر ارائه می‌دهد. می‌توانید با استفاده از ویژگی‌های آن، جوهر را به‌طور کامل مخفی کنید یا نحوهٔ تفسیر عملیات ماسک قلم جوهر را تغییر دهید.

گزینه‌های جوهر از طریق گزینه‌های خروجی یا رندر برای انواع خروجی‌های زیر در دسترس هستند:

| خروجی | ویژگی‌های گزینهٔ جوهر |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| تصویر اسلاید | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

روش‌های زیر از کلاس [InkOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/) دو تنظیم مشابه را ارائه می‌دهند:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/#getHideInk--) تعیین می‌کند آیا اشیاء جوهر در خروجی گنجانده شوند یا نه. مقدار پیش‌فرض آن `false` است.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) تعیین می‌کند آیا عملیات ماسک به‌عنوان ناشفافی تفسیر شود یا نه. مقدار پیش‌فرض `true` است؛ برای استفاده از عملیات ROP به جای آن، متد [`InkOptions.setInterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) را با مقدار `false` صدا بزنید.

### **مخفی کردن اشیاء جوهر در خروجی PDF**

به‌طور پیش‌فرض، اشیاء جوهر هنگام خروجی قابل مشاهده هستند. برای ایجاد خروجی تمیز بدون حاشیه‌نویسی‌های دست‌نویس یا محتوای جوهر دیگر، متد [`InkOptions.setHideInk`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) را با مقدار `true` صدا بزنید.

مثال زیر به‌زبان JavaScript یک ارائه را به PDF صادر می‌کند و تمام اشیاء جوهر را مخفی می‌سازد:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **مخفی کردن اشیاء جوهر هنگام رندر اسلاید به‌صورت تصویر**

برای مخفی کردن اشیاء جوهر هنگام رندر اسلایدها به‌صورت تصاویر نقطه‌گرا، ویژگی‌های [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) را پیکربندی کنید و گزینه‌های رندر را به متد [Slide.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-) منتقل کنید.

مثال زیر به‌زبان JavaScript اولین اسلاید را به تصویر PNG رندر می‌کند بدون اشیاء جوهر:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **کنترل رندر ماسک جوهر**

تنظیم [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) نحوهٔ تفسیر عملیات ماسک را هنگام رندر قلم جوهر کنترل می‌کند. مقدار پیش‌فرض `true` است که از شفافیت استفاده می‌کند. برای استفاده از عملیات ROP به جای آن، متد [`InkOptions.setInterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) را با `false` فراخوانی کنید.

مثال زیر به‌زبان JavaScript یک اسلاید را به SVG صادر می‌کند و برای عملیات ماسک جوهر از رندر مبتنی بر ROP استفاده می‌نماید:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

همین تنظیم می‌تواند از طریق [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) هنگام صادرات ارائه یا رندر اسلاید به TIFF اعمال شود.

### **انتخاب مخفی یا حفظ جوهر**

زمانی که به نسخهٔ پاک‌سازی‌شده‌ای از ارائه حاوی حاشیه‌نویسی‌ها برای توزیع بدون نشانه‌گذاری‌های مرور نیاز دارید، در طول خروجی متد [`InkOptions.setHideInk`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) را با `true` صدا بزنید.

وقتی حاشیه‌نویسی‌های جوهر بخشی از محتوای هدف هستند (مثلاً نظرات مرور، یادداشت‌های دست‌نویس، هایلایت‌ها یا نقاشی‌هایی که باید در خروجی دیده شوند)، مقدار پیش‌فرض `false` برای [InkOptions.getHideInk](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/#getHideInk--) را حفظ کنید. این امکان به برنامه‌ها اجازه می‌دهد خروجی‌های مرور و نهایی را از یک ارائه بدون تغییر اشیاء جوهر منبع تولید کنند.

## **سؤال‌های متداول**

**آیا می‌توانم رنگ یا اندازهٔ یک خط جوهر موجود را تغییر دهم؟**

بله. رد‌گیری را از طریق [Ink.getTraces](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ink/#getTraces--) دریافت کنید و سپس [InkTrace.getBrush](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inktrace/#getBrush--) آن را تغییر دهید. برای تغییر رنگ از [InkBrush.setColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) و برای تغییر اندازه از [InkBrush.setSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) استفاده کنید.

**آیا مخفی کردن جوهر منبع ارائه را تغییر می‌دهد؟**

خیر. فراخوانی [InkOptions.setHideInk](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) فقط بر نتایج رندر یا خروجی تأثیر می‌گذارد؛ اشیاء جوهر در ارائه منبع حذف یا تغییر نمی‌شوند.

**کدام فرمت‌های خروجی از گزینه‌های جوهر پشتیبانی می‌کنند؟**

می‌توانید گزینه‌های جوهر را برای PDF، HTML، SVG، TIFF و تصاویر بیت‌مپ اسلاید از طریق گزینه‌های خروجی یا رندر مربوطه که در جدول بالا نشان داده شده‌اند، تنظیم کنید.

**مطالعهٔ بیشتر**

* برای آشنایی با اشکال به‌طور کلی، بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/nodejs-java/powerpoint-shapes/) را ببینید.
* برای اطلاعات بیشتر دربارهٔ مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/nodejs-java/shape-effective-properties/#get-effective-font-height-value) مراجعه کنید.
* برای جزئیات خروجی PDF، به [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) نگاه کنید.
* برای جزئیات خروجی HTML، به [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fa/nodejs-java/convert-powerpoint-to-html/) مراجعه کنید.
* برای جزئیات خروجی SVG، به [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/) مراجعه کنید.
* برای جزئیات خروجی TIFF، به [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fa/nodejs-java/convert-powerpoint-to-tiff/) نگاه کنید.
* برای جزئیات رندر اسلاید به تصویر، به [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fa/nodejs-java/convert-slide/) مراجعه کنید.