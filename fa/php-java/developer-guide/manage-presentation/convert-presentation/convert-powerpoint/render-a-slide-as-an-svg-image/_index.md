---
title: اسلایدهای ارائه را به عنوان تصاویر SVG در PHP رندر کنید
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
description: "اسلایدهای PowerPoint را به عنوان تصاویر SVG در PHP صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **نمای کلی**

SVG یک فرمت تصویر مبتنی بر XML با قابلیت مقیاس‌پذیری است که برای انتشار وب، نمایش اسلاید، گردش کار دسترس‌پذیری و پردازش پس‌پردازشی خودکار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما اجازه می‌دهد نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) وقتی که SVG خروجی باید فشرده، پیش‌بینی‌پذیر در مرورگرها یا آماده استفاده تعاملی باشد، استفاده کنید.

## **صادرات یک اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را با [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به صورت یک فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) استفاده می‌کند نه از اندیس حلقه. همچنین می‌توانید یک شکل تکین را با [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) صادر کنید وقتی که یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) فریم متنی را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) تعیین می‌کند آیا چرخش فریم اعمال شود یا نه. برای رندر متن بدون لیگاتور، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) را روی `true` تنظیم کنید.

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

زمانی که اسلایدها را به SVG صادر می‌کنید، می‌توانید کنترل کنید که متن به عنوان متن باقی بماند یا به گرافیک برداری تبدیل شود و چطور قلم‌های خارجی گنجانده یا ارجاع داده شوند. گزینه‌های زیر به شما کمک می‌کند تعادل بین ثبات بصری، قابلیت انتخاب متن و وابستگی‌های قلم در SVG خروجی را برقرار کنید.

### **بردارسازی تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) را روی `true` تنظیم کنید تا تمام متن اسلاید به صورت گرافیک برداری نوشته شود. این کار وابستگی‌های قلم را حذف می‌کند و نتیجه بصری را در مرورگرها یکدست‌تر می‌سازد، اما متن دیگر قابل انتخاب یا جستجو به عنوان متن SVG نیست.

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

### **انتخاب نحوه مدیریت قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه، `Embed` را برای گنجاندن داده‌های قلم در SVG، یا `Vectorize` را برای رندر تنها متنی که از قلم‌های خارجی استفاده می‌کند به صورت گرافیک انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوزهای مربوطه را بررسی کنید.

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

## **کاهش حجم تصویر جاسازی‌شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) برای کاهش وضوح تصاویر جاسازی‌شده، از [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) برای حذف نواحی برش‌خورده منبع، و از [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) برای کنترل کیفیت کدگذاری JPEG استفاده کنید. این تنظیمات حجم پرونده را کاهش می‌دهند به هزینهٔ وفاداری تصویر یا داده‌های تصویر نگه‌داشته‌شده.

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

## **کنترل وضوح رستر‌سازی متافایل**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) حد پایین رزولوشن برای رستر‌سازی متافایل‌ها در زمان خروجی SVG را تعیین می‌کند. از آن برای تعادل بین جزئیات و حجم پرونده هنگام رستر‌سازی تصویر EMF یا WMF استفاده کنید. این تنظیم یک DPI کلی برای SVG تعریف نمی‌کند و همهٔ اشیاء اسلاید را به تصویر رستری تبدیل نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل شامل یک تصویر EMF با خطوط مورب نزدیک به هم است. مثال زیر اولین اسلاید آن را در سه وضوح رستر‌سازی مختلف با استفاده از [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) صادر می‌کند. تمام تنظیمات دیگر صادرات همانند باقی می‌مانند تا نتایج قابل مقایسه باشند.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ ارائه شده است؛ اینها یک فرمول عمومی برای تبدیل DPI به ابعاد پیکسل نیستند.

| وضوح رستر‌سازی متافایل DPI | ابعاد PNG جاسازی‌شده | اندازهٔ فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستری جاسازی‌شده را در اندازهٔ نمایش بزرگ‌شده یکسان نشان می‌دهد. خطوط مورب در 72 DPI پیکسل‌گذاری قابل رؤیتی دارند و در وضوح‌های بالاتر لبه‌های نرم‌تری دارند، در حالی که حجم SVG افزایش می‌یابد. افزایش مقدار لزوماً همهٔ جزئیات را بهبود نمی‌بخشد یا هر تصویر صادراتی را تغییر نمی‌دهد.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) کنترل کاهش وضوح تصویر را انجام می‌دهد و می‌تواند اثر تغییر وضوح رستر‌سازی متافایل را مخفی کند. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) کیفیت کدگذاری JPEG را کنترل می‌کند، نه وضوح رستر‌سازی متافایل.

## **اختصاص شناسه‌های ثابت به شکل‌ها و متن**

یک کال‌بک قالب‌بندی به [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) ارائه دهید تا برای هر شکل SVG، [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) تنظیم شود. این کال‌بک می‌تواند مقادیر [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) را روی عناصر `tspan` متنی تنظیم کند.

PhpJavaBridge نمی‌تواند یک کال‌بک PHP را از `writeAsSvg` هنگام اجرای در حالت جریان فراخوانی کند. منطق قالب‌بندی را در یک کلاس کمکی کوچک جاوا قرار دهید، آن را کامپایل کنید و فایل JAR حاصل را به مسیر کلاس پل اضافه کنید. این کمکی می‌تواند از [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) استفاده کند که برای طول عمر شکل ثابت است، و یک شمارندهٔ قابل تکرار برای spanهای متنی آن داشته باشد. به [Java implementation of `StableSvgIdController`](/slides/fa/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) برای کد کمکی مراجعه کنید.

پس از افزودن کلاس کامپایل‌شده `com.example.slides.StableSvgIdController` به مسیر کلاس پل، آن را از PHP نمونه‌سازی کنید و به `SVGOptions` اختصاص دهید:

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

در یک کال‌بک قالب‌بندی، با [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) یک مقدار [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) برای اضافه کردن هندلر JavaScript به یک شکل صادر شده فراخوانی کنید. کال‌بک را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

همانند شناسه‌های ثابت، کال‌بک را در یک کمکی جاوا پیاده‌سازی کنید وقتی PhpJavaBridge در حالت جریان استفاده می‌شود. [Java implementation of `SvgEventController`](/slides/fa/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) یک شناسه و یک هندلر `OnClick` به شکلی به نام `ActionButton` اختصاص می‌دهد. آن کمکی را کامپایل کنید، به مسیر کلاس پل به عنوان `com.example.slides.SvgEventController` اضافه کنید و از PHP به صورت زیر استفاده کنید:

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

صفحهٔ میزبان می‌تواند تابع JavaScript اشاره‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان مشاهده‌کننده‌های اسلاید، بهبودهای دسترس‌پذیری و سایر گردش کارهای SVG تعاملی را فراهم می‌کند.

## **سؤالات متداول**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) به جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) زمانی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) زمانی استفاده کنید که فقط متنی که از قلم‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود.

**بهترین روش برای کوچک کردن SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خورده تصویر و انتخاب فایل‌های قلم پیوندی زمانی که محیط هدف می‌تواند آنها را سرویس دهد، شروع کنید. نتیجه را تست کنید زیرا کاهش وضوح تصویر، کاهش کیفیت JPEG و بردارسازی متن هرکدام تعادل متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم عناصر SVG صادرشده را پس از صادرات تغییر دهم؟**

بله. شناسه‌ها را از طریق کال‌بک قالب‌بندی اختصاص دهید، سپس عناصر SVG مطابق را در ابزار پس‌پردازش یا اسکریپت مرورگر خود انتخاب کنید.