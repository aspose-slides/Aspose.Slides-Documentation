---
title: نمایش اسلایدهای ارائه به‌صورت تصاویر SVG در PHP
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint به SVG
- ارائه به SVG
- اسلاید به SVG
- PPT به SVG
- PPTX به SVG
- گزینه‌های خروجی SVG
- SVG تعاملی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدهای PowerPoint را به‌صورت تصاویر SVG در PHP صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل نمایید."
---
## **نمای کلی**

SVG یک فرمت تصویری مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایشگرهای اسلاید، گردش‌های کاری دسترس‌پذیری و پردازش خودکار پس از تولید مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/) استفاده کنید وقتی که SVG صادر شده باید فشرده، قابل پیش‌بینی در مرورگرهای مختلف یا آماده برای استفاده تعاملی باشد.

## **صادرات یک اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و با [Slide.writeAsSvg](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#writeAsSvg) آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به صورت یک فایل SVG جداگانه صادر می‌کند.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

نام فایل از [Slide.getSlideNumber](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getSlideNumber) به جای اندیس حلقه استفاده می‌کند. همچنین می‌توانید یک شکل منفرد را با [Shape.writeAsSvg](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#writeAsSvg) صادر کنید وقتی که یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/) رندرینگ SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setUseFrameSize) فریم متن را در ناحیه رندرینگ گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setUseFrameRotation) تعیین می‌کند که آیا چرخش فریم اعمال شود یا نه. وقتی متن باید بدون لیگچرها رندر شود، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) را روی `true` تنظیم کنید.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **کنترل متن و قلم‌ها**

### **وکتوریزه کردن تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setVectorizeText) را روی `true` تنظیم کنید تا تمام متن اسلاید به صورت گرافیک‌های وکتور نوشته شود. این کار وابستگی‌های قلم را حذف می‌کند و نتیجه بصری را در مرورگرهای مختلف سازگارتر می‌کند، اما متن دیگر قابل انتخاب یا جستجو به عنوان متن SVG نیست.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **انتخاب نحوه پردازش قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgexternalfontshandling/) برای قلم‌های بارگذاری‌شده به صورت خارجی استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه انتخاب کنید، `Embed` برای گنجاندن داده‌های قلم در SVG، یا `Vectorize` برای رندر کردن فقط متنی که از قلم‌های خارجی استفاده می‌کند به صورت گرافیک. قبل از جاسازی قلم‌ها، مجوزهای آن‌ها را بررسی کنید.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **کاهش اندازه تصویر جاسازی‌شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setPicturesCompression) برای کاهش وضوح تصاویر جاسازی‌شده استفاده کنید، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) برای حذف نواحی برش‌خورده منبع، و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setJpegQuality) برای کنترل کیفیت رمزگذاری JPEG. این تنظیمات حجم فایل را به قیمت کاهش دقت تصویر یا داده‌های نگهداری شده کاهش می‌دهند.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **اختصاص شناسه‌های ثابت به اشکال و متن**

یک callback قالب‌بندی به [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setShapeFormattingController) ارائه دهید تا برای هر شکل SVG [SvgShape.setId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgshape/#setId) تنظیم شود. این callback می‌تواند مقادیر [SvgTSpan.setId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgtspan/#setId) را نیز بر روی عناصر متن `tspan` تنظیم کند.

PhpJavaBridge نمی‌تواند یک callback PHP را از `writeAsSvg` فراخوانی کند هنگامی که در حالت جریان اجرا می‌شود. منطق قالب‌بندی را در یک کلاس کمکی کوچک جاوا قرار دهید، آن را کامپایل کنید و فایل JAR حاصل را به مسیر کلاس‌های پل اضافه کنید. این کمک‌رسان می‌تواند از [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getOfficeInteropShapeId) استفاده کند که برای طول عمر شکل ثابت است و یک شمارنده تکرارپذیر برای `tspan`های متنی آن دارد. برای کد کمکی به [Java implementation of `StableSvgIdController`](/slides/fa/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) مراجعه کنید.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **افزودن هندلرهای رویداد SVG**

در یک callback قالب‌بندی، با یک مقدار [SvgEvent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgevent/) به [SvgShape.setEventHandler](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgshape/#setEventHandler) فراخوانی کنید تا یک هندلر رویداد JavaScript به شکل صادر شده اضافه شود. callback را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setShapeFormattingController) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

همانند شناسه‌های ثابت، هنگام استفاده از PhpJavaBridge در حالت جریان، callback را در یک کمک‌رسان جاوا پیاده‌سازی کنید. [Java implementation of `SvgEventController`](/slides/fa/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) یک شناسه و هندلر `OnClick` را به شکلی به نام `ActionButton` اختصاص می‌دهد. آن کمک‌رسان را کامپایل کنید، به مسیر کلاس‌های پل به عنوان `com.example.slides.SvgEventController` اضافه کنید و از PHP به شکل زیر استفاده کنید:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

صفحه میزبان می‌تواند تابع JavaScript اشاره‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد، نمایشگرهای اسلاید، بهبودهای دسترس‌پذیری و دیگر گردش‌های کاری تعاملی SVG را ممکن می‌سازد.

## **پرسش‌های متداول**

**چه وقت باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setVectorizeText) به جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/#setVectorizeText) وقتی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgexternalfontshandling/) زمانی استفاده کنید که فقط متنی که از قلم‌های خارجی استفاده می‌کند به گرافیک تبدیل شود.

**بهترین راه برای کوچک‌تر کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش خورده تصویر و انتخاب فایل‌های قلم مرتبط شروع کنید وقتی که محیط هدف قادر به سرو کردن آنها باشد. نتیجه را آزمایش کنید زیرا کاهش وضوح تصویر، کاهش کیفیت JPEG و متن وکتوریزه هر کدام تعادلات متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم عناصر SVG صادر شده را پس از صادرات تغییر دهم؟**

بله. با استفاده از یک callback قالب‌بندی شناسه‌ها را اختصاص دهید، سپس عناصر SVG مربوطه را در ابزار پس‌پردازش یا اسکریپت مرورگر خود انتخاب کنید.