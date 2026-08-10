---
title: مدیریت اشیای جوهر ارائه در PHP
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/php-java/manage-ink/
keywords:
- جوهر
- شیء جوهر
- ردپای جوهر
- مدیریت جوهر
- رسم جوهر
- نقاشی
- صادر کردن جوهر
- رندر جوهر
- پنهان‌سازی جوهر
- InkOptions
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت اشیای جوهر PowerPoint، ویرایش ردپاها و خصوصیات براش، و کنترل ظاهر جوهر در زمان خروجی به PDF، HTML، SVG، TIFF و تصویر با Aspose.Slides برای PHP از طریق Java."
---
## **معرفی**

PowerPoint یک ویژگی جوهر (ink) را فراهم می‌کند که به شما امکان رسم ضربه‌های آزاد شکل را می‌دهد. جوهر می‌تواند برای برجسته‌سازی اشیای دیگر، نمایش ارتباطات و فرآیندها، و جلب توجه به موارد خاص در یک اسلاید استفاده شود.

Aspose.Slides انواع مورد نیاز برای کار با اشیای جوهر را فراهم می‌کند. برای مثال، کلاس [Ink](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ink/) یک شیء جوهر را روی اسلاید نشان می‌دهد.

## **تفاوت‌های اشیای معمولی و اشیای جوهر**

اشیای یک اسلاید PowerPoint معمولاً توسط اشیای [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) نشان داده می‌شوند. در ساده‌ترین شکل، یک شکل یک محفظه است که ناحیهٔ خود شیء (قاب آن) را به همراه خصوصیتی مانند اندازهٔ محفظه، شکل و پس‌زمینه تعریف می‌کند. برای اطلاعات بیشتر، به [Shape Layout Format](https://docs.aspose.com/slides/fa/php-java/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

اما هنگامی که PowerPoint یک شیء جوهر را مدیریت می‌کند، تمام خصوصیات قاب شیء (محفظه) به جز اندازهٔ آن را نادیده می‌گیرد. اندازهٔ ناحیهٔ محفظه توسط متدهای استاندارد [Shape.getWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getWidth) و [Shape.getHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getHeight) تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردپای جوهر**

یک ردپای جوهر عنصر پایه‌ای است که برای ضبط مسیر قلم هنگام نوشتن جوهر دیجیتال استفاده می‌شود. یک ردپا توالی‌ای از نقاط متصل را ذخیره می‌کند.

ساده‌ترین شکل رمزگذاری مختصات X و Y هر نقطهٔ نمونه را مشخص می‌کند. هنگامی که تمام نقاط متصل رندر می‌شوند، تصویری مانند این تولید می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصوصیات براش برای رسم**

یک براش برای رسم خطوطی که نقاط یک ردپای جوهر را به هم متصل می‌کند، استفاده می‌شود. براش رنگ و اندازهٔ مخصوص خود را دارد که توسط متدهای [InkBrush.getColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkbrush/#getColor) و [InkBrush.getSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkbrush/#getSize) نمایان می‌شود.

### **تنظیم رنگ براش جوهر**

این کد PHP نشان می‌دهد چگونه رنگ یک براش جوهر را تنظیم کنید:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **تنظیم اندازه براش جوهر**

این کد PHP نشان می‌دهد چگونه اندازهٔ یک براش جوهر را تنظیم کنید:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

عموماً عرض و ارتفاع یک براش برابر نیستند، بنابراین PowerPoint اندازهٔ براش را نمایش نمی‌دهد (بخش دادهٔ مربوطه خاکستری است). وقتی عرض و ارتفاع براش برابر شوند، PowerPoint اندازهٔ آن را به این شکل نشان می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را بررسی می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

محفظه (قاب) اندازهٔ براش‌ها را در نظر نمی‌گیرد — همیشه فرض می‌کند ضخامت خط صفر است (به تصویر قبلی مراجعه کنید).

بنابراین برای تعیین ناحیهٔ قابل مشاهدهٔ کل شیء جوهر، باید اندازهٔ براش ردپاهای آن در نظر گرفته شود. در اینجا، شیء هدف (ردپای متن دستنویس) به اندازهٔ محفظه (قاب) مقیاس داده شده است. وقتی اندازهٔ محفظه تغییر می‌کند، اندازهٔ براش ثابت می‌ماند و بالعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint رفتار مشابهی برای اشیای متن به کار می‌برد:

![ink_powerpoint6](ink_powerpoint6.png)

## **کنترل ظاهر جوهر هنگام خروجی و رندرینگ**

Aspose.Slides کلاس [InkOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/) را برای کنترل نحوهٔ نمایش اشیای جوهر در خروجی یا رندر شده فراهم می‌کند. می‌توانید از خصوصیات آن برای مخفی‌کردن کامل جوهر یا تغییر نحوهٔ تفسیر عملیات ماسک براش جوهر استفاده کنید.

گزینه‌های جوهر از طریق گزینه‌های خروجی یا رندرینگ برای چندین نوع خروجی در دسترس هستند:

| خروجی | ویژگی گزینه‌های جوهر |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| تصویر اسلاید | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/#getInkOptions) |

متدهای زیر از کلاس [InkOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/) دو تنظیم مشابه را ارائه می‌دهند:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/#getHideInk) تعیین می‌کند آیا اشیای جوهر در خروجی گنجانده شوند یا نه. مقدار پیش‌فرض آن `false` است.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) تعیین می‌کند آیا یک عملیات ماسک هنگام رندرینگ یک براش جوهر به عنوان شفافیت تفسیر شود. مقدار پیش‌فرض آن `true` است؛ برای استفاده از عملیات ROP به جای آن، [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) را با `false` فراخوانی کنید.

### **پنهان کردن اشیای جوهر در خروجی PDF**

به‌طور پیش‌فرض، اشیای جوهر هنگام خروجی قابل مشاهده هستند. برای ایجاد یک خروجی پاک بدون حاشیه‌نویسی‌های دست‌نویس یا سایر محتوای جوهر، [InkOptions.setHideInk](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/#setHideInk) را با `true` فراخوانی کنید.

این مثال PHP ارائه را به PDF صادر می‌کند و تمام اشیای جوهر را مخفی می‌سازد:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **پنهان کردن اشیای جوهر هنگام رندر اسلاید به عنوان تصویر**

برای مخفی کردن اشیای جوهر هنگام رندر اسلایدها به عنوان تصاویر بیت‌مپ، [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/#getInkOptions) را پیکربندی کنید و گزینه‌های رندرینگ را به متد [Slide.getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) پاس دهید.

این مثال PHP اولین اسلاید را به تصویر PNG بدون اشیای جوهر رندر می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **کنترل رندر ماسک جوهر**

تنظیم [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) نحوهٔ تفسیر عملیات ماسک هنگام رندرینگ براش‌های جوهر را کنترل می‌کند. مقدار پیش‌فرض `true` است که از شفافیت استفاده می‌کند. برای استفاده از عملیات ROP به جای آن، [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) را با `false` فراخوانی کنید.

این مثال PHP یک اسلاید را به SVG صادر می‌کند و برای عملیات ماسک جوهر از رندرینگ مبتنی بر ROP استفاده می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

همین تنظیم می‌تواند از طریق [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#getInkOptions) هنگام خروجی یک ارائه یا رندر یک اسلاید به TIFF اعمال شود.

### **انتخاب اینکه جوهر مخفی یا حفظ شود**

زمانی که به نسخهٔ پاکی از یک ارائه حاشیه‌دار برای توزیع بدون علامت‌های بررسی نیاز دارید، در زمان خروجی [InkOptions.setHideInk](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/#setHideInk) را با `true` فراخوانی کنید.

وقتی حاشیه‌نویسی‌های جوهر بخشی از محتوای مورد نظر هستند—مانند نظرات بررسی، یادداشت‌های دست‌نویس، برجسته‌سازی‌ها یا خطوطی که باید در نتیجهٔ خروجی قابل مشاهده باشند—[InkOptions.getHideInk](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/#getHideInk) را در مقدار پیش‌فرض `false` بگذارید. این امکان را می‌دهد تا برنامه‌ها خروجی‌های جداگانهٔ بررسی و نهایی را از همان ارائه بدون تغییر در اشیای جوهر منبع تولید کنند.

## **سوالات متداول**

**آیا می‌توانم رنگ یا اندازهٔ یک ضربهٔ جوهر موجود را تغییر دهم؟**

بله. ردپا را از [Ink.getTraces](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ink/#getTraces) دریافت کنید، سپس [InkTrace.getBrush](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inktrace/#getBrush) آن را تغییر دهید. برای تغییر رنگ براش از [InkBrush.setColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkbrush/#setColor) و برای تغییر اندازه از [InkBrush.setSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkbrush/#setSize) استفاده کنید.

**آیا پنهان کردن جوهر منبع ارائه را تغییر می‌دهد؟**

خیر. فراخوانی [InkOptions.setHideInk](https://reference.aspose.com/slides/fa/php-java/aspose.slides/inkoptions/#setHideInk) تنها بر نتیجهٔ رندر شده یا خروجی تأثیر می‌گذارد؛ اشیای جوهر در ارائهٔ منبع حذف یا اصلاح نمی‌شوند.

**کدام فرمت‌های خروجی از گزینه‌های جوهر پشتیبانی می‌کنند؟**

می‌توانید گزینه‌های جوهر را برای PDF، HTML، SVG، TIFF و تصاویر بیت‌مپ اسلاید از طریق گزینه‌های خروجی یا رندرینگ مربوطه که در بالا نشان داده شده است، پیکربندی کنید.

**مطالعات بیشتر**

* برای اطلاعات کلی دربارهٔ شکل‌ها، بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/php-java/powerpoint-shapes/) را ببینید.
* برای اطلاعات بیشتر دربارهٔ مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/php-java/shape-effective-properties/#get-effective-font-height-value) مراجعه کنید.
* برای جزئیات خروجی PDF، به [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fa/php-java/convert-powerpoint-to-pdf/) نگاه کنید.
* برای جزئیات خروجی HTML، به [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fa/php-java/convert-powerpoint-to-html/) مراجعه کنید.
* برای جزئیات خروجی SVG، به [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fa/php-java/render-a-slide-as-an-svg-image/) نگاه کنید.
* برای جزئیات خروجی TIFF، به [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fa/php-java/convert-powerpoint-to-tiff/) مراجعه کنید.
* برای جزئیات رندر اسلاید به تصویر، به [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fa/php-java/convert-slide/) نگاه کنید.