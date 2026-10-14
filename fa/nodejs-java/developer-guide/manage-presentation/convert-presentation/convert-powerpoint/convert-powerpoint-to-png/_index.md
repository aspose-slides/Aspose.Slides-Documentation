---
title: تبدیل اسلایدهای PowerPoint به PNG در JavaScript
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/nodejs-java/convert-powerpoint-to-png/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به عنوان PNG
- ذخیره PPTX به عنوان PNG
- صادر کردن PPT به PNG
- صادر کردن PPTX به PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به تصاویر PNG با کیفیت بالا در JavaScript به‌سرعت با Aspose.Slides برای Node.js، تضمین‌کننده نتایج دقیق و خودکار."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه اسلایدهای ارائه را به تصاویر PNG تبدیل کنید با استفاده از Aspose.Slides برای Node.js از طریق Java. می‌توانید ارائه‌ها را در قالب‌هایی مانند PPT، PPTX و ODP بارگذاری کنید، هر اسلاید را رندر کنید و به‌عنوان یک تصویر PNG جداگانه ذخیره کنید.

مثال‌های زیر نشان‌دهنده رندر در مقیاس پیش‌فرض، افزایش مقیاس، تعیین ابعاد خروجی به پیکسل، و انتخاب سبک رندر گرادیان هستند.

## **تبدیل PowerPoint به PNG**

یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) بارگذاری کنید و اسلایدهای آن را از طریق مجموعه [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) دسترسی پیدا کنید. مثال هر اسلاید را با [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) بدون پارامتر رندر می‌کند تا یک تصویر بندانگشتی ایجاد شود. سپس [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) را با [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) فراخوانی می‌کند تا هر اسلاید رندر شده به عنوان تصویر PNG ذخیره شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
بارگذاری بدون پارامتر [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) در مقیاس 0.2 رندر می‌کند. به‌عنوان مثال، اسلایدی با اندازه 720 × 540 نقطه یک تصویر بندانگشتی 144 × 108 پیکسل تولید می‌کند. برای کنترل ابعاد خروجی، از بارگذاری‌های با فاکتورهای مقیاس یا اندازه تصویر صریح نشان‑داده‌شده در زیر استفاده کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

فاکتورهای مقیاس افقی و عمودی را به [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) پاس دهید تا ابعاد رندر شده را کنترل کنید. در این مثال هر دو فاکتور برابر 2 هستند، بنابراین اسلایدی با اندازه 720 × 540 نقطه تصویر 1440 × 1080 پیکسل تولید می‌کند. فاکتورهای مساوی نسبت تصویر اسلاید را حفظ می‌کنند. هر تصویر با فرمت PNG توسط [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) ذخیره می‌شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

برای تعیین ابعاد خروجی به پیکسل، به جای فاکتورهای مقیاس یک اندازه را به [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) پاس دهید. این مثال هر اسلاید را با ابعاد 960 × 720 پیکسل رندر می‌کند و نتیجه را با [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) ذخیره می‌کند. برای جلوگیری از کشیده شدن تصویر، ابعادی را انتخاب کنید که نسبت تصویر اسلاید را حفظ کنند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **انتخاب سبک رندر گرادیان**

فرض کنید اسلایدی شامل پرکننده‌های گرادیان باشد، اما انتقال‌ها در PNG استخراج‌شده روشن‌تر یا متفاوت از آنچه در PowerPoint می‌بینید باشد. می‌توانید از متد [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) که توسط [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) به ارث برده شده است، برای انتخاب نحوه رندر گرادیان‌ها استفاده کنید.

فایل [gradient‑styles.pptx](gradient-styles.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل دو گرادیان خطی است: از فیروزه‌ای به نارنجی در بالا و از آبی به زرد در پایین. هر گرادیان دو نقطه توقف دارد، در 0% و 100%.

مثال زیر این ارائه را بارگذاری می‌کند و همان اسلاید اول را در هر دو حالت با [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) رندر می‌نماید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

تصاویر زیر خروجی همان اسلاید را نشان می‌دهند، با هر دو گرادیان در هر تصویر:

| Default | PowerPointUI |
| --- | --- |
| ![گرادیان‌های فیروزه‌ای‑به‑نارنجی و آبی‑به‑زرد رندر شده با Default](gradient-Default.png) | ![همان گرادیان‌ها رندر شده با PowerPointUI](gradient-PowerPointUI.png) |

در این مثال، `Default` رنگ‌های میانی روشن‌تری تولید می‌کند، در حالی که `PowerPointUI` رنگ‌های میانی تیره‌تری می‌دهد. این تفاوت به رنگ‌ها و نقاط توقف در گرادیان بستگی دارد.

`Default` را زمانی انتخاب کنید که خروجی استاندارد Aspose.Slides برای نیازهای شما کافی باشد. `PowerPointUI` را وقتی امتحان کنید که اولویت شما تطبیق ظاهر با PowerPoint باشد. هر دو خروجی را با نتیجه مورد نظر خود مقایسه کنید؛ هیچ‌یک به‌طور کلی بر دیگری برتری ندارند.

## **سوالات متداول**

**چگونه می‌توان یک شکل خاص، مانند نمودار یا تصویر، را به‌جای تمام اسلاید استخراج کرد؟**

Aspose.Slides از [تولید تصویر بندانگشتی برای اشکال منفرد](/slides/fa/nodejs-java/create-shape-thumbnails/) پشتیبانی می‌کند، به‌طوری که می‌توانید یک شکل را به صورت تصویر PNG رندر کنید.

**آیا تبدیل همزمان بر روی سرور پشتیبانی می‌شود؟**

بله. برای هر نخ یا پردازش یک نمونهٔ جداگانهٔ ارائه استفاده کنید؛ [یک نمونهٔ واحد را بین نخ‌ها به‌اشتراک نگذارید](/slides/fa/nodejs-java/multithreading/).

**محدودیت‌های ارزیابی هنگام استخراج به PNG چیست؟**

حالت ارزیابی به تصاویر خروجی یک واترمارک اضافه می‌کند و تا زمانی که لایسنس اعمال شود، [محدودیت‌های دیگری](/slides/fa/nodejs-java/licensing/) اعمال می‌شود.