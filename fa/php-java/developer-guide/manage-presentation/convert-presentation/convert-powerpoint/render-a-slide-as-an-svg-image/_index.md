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
description: "اسلایدهای PowerPoint را به‌صورت تصاویر SVG در PHP صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **نمای کلی**

SVG یک فرمت تصویری XML‑مبتنی مقیاس‌پذیر است که برای انتشار وب، نمایش اسلاید، جریان‌های دسترس‌پذیری و پردازش پس‌زمینه خودکار عملکرد خوبی دارد. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) استفاده کنید هنگامی که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر بین مرورگرها یا برای استفاده تعاملی آماده باشد.

## **صدور یک اسلاید به صورت SVG**

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

نام فایل از [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) استفاده می‌کند نه از شاخص حلقه. همچنین می‌توانید یک شکل فرد را با [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) صادر کنید هنگامی که یک نمایشگر اسلاید یا صفحه وب تنها به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای قاب‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) قاب متن را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) تعیین می‌کند آیا چرخش قاب اعمال شود یا نه. وقتی متن باید بدون لیگاتورهای قلم رندر شود، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) را روی `true` تنظیم کنید.

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

## **کنترل برش انتهای خط در سرهای فلش**

SVG 1.1 تنظیمی برای مشخص کردن نقطه توقف خط زیر سر فلش ندارد. به طور پیش‌فرض، Aspose.Slides خط صادر شده را کوتاه می‌کند تا خط اشکال به‌داخل نشانگر نفذ نشود. با فراخوانی [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) با مقدار `true`، خط تا نقطه انتهایی اصلی خود کشیده می‌شود. این تنظیم فقط بر خروجی SVG تاثیر دارد؛ موقعیت و طول خط در اسلاید ثابت می‌ماند.

مثال سرهای فلش مثلثی و الماسی را بر خطوط ۲ و ۱۰ نقطه‌ای رسم می‌کند. همان اسلاید دو بار صادر می‌شود و فقط گزینه برش تغییر می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

مقایسه نشان می‌دهد سر فلش مثلثی بر خط ۱۰‑نقطه‌ای. با فعال بودن برش، نوک تیز است. با غیرفعال بودن برش، خط از طرف‌های شیب‌دار نشانگر بیرون می‌آید و انتهایی مسطح می‌ماند.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

در خطوط دیگر مثال، خط بیرون آمده کمتر در مثلث ۲‑نقطه‌ای قابل مشاهده است. الماس پر شده انتهای خط را در هر دو عرض پوشش می‌دهد.

## **کنترل متن و قلم‌ها**

هنگام صدور اسلایدها به SVG، می‌توانید تعیین کنید آیا متن به صورت متن باقی بماند یا به گرافیک برداری تبدیل شود و چگونگی درج یا ارجاع به قلم‌های خارجی. گزینه‌های زیر به شما کمک می‌کند تعادل بین سازگاری بصری، قابلیت انتخاب متن و وابستگی‌های قلم در SVG صادر شده را حفظ کنید.

### **بردارسازی تمام متن**

با تنظیم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) روی `true` تمام متن اسلاید را به گرافیک برداری می‌نویسد. این کار وابستگی به قلم‌ها را حذف می‌کند و نتیجه بصری را بین مرورگرها یکسان‌تر می‌سازد، اما متن دیگر قابل انتخاب یا جستجو به‌عنوان متن SVG نیست.

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

### **انتخاب نحوهٔ پردازش قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) از یک مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) برای قلم‌های بارگذاری‌شده به‌صورت خارجی استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه، `Embed` را برای درج داده‌های قلم در SVG یا `Vectorize` را برای رندر کردن متن‌های استفاده‌کننده از قلم‌های خارجی به‌صورت گرافیک انتخاب کنید. قبل از درج قلم‌ها، مجوز استفاده از آن‌ها را بررسی کنید.

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

## **کاهش اندازهٔ تصویر جاسازی‌شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) برای حذف نواحی تصویر برش‑خورده و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را در ازای کاهش دقت تصویر یا داده‌های تصویر نگهداری‌شده کاهش می‌دهند.

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

## **کنترل وضوح رستری‌سازی متافایل**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) حد پایین رزولوشن رستری‌سازی متافایل‌ها را در هنگام صادر کردن SVG تنظیم می‌کند. از آن برای تعادل بین جزئیات و حجم فایل هنگام رستری‌سازی یک تصویر EMF یا WMF استفاده کنید. این مقدار DPI سراسری برای کل SVG نیست و هر شیء را به تصویر رستری تبدیل نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل شامل یک تصویر EMF با خطوط قطری نزدیک به هم است. مثال زیر اولین اسلاید آن را با سه وضوح رستری‌سازی مختلف از طریق [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) صادر می‌کند. سایر تنظیمات صادرات یکسان باقی می‌مانند تا نتایج قابل مقایسه باشند.

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

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل می‌شود. اندازه‌گیری‌های زیر برای ارائهٔ ارائه‌شده است؛ این‌ها فرمول عمومی برای تبدیل DPI به ابعاد پیکسل نیستند.

| DPI رستری‌سازی متافایل | ابعاد PNG جاسازی شده | حجم فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستری‌سازی شدهٔ جاسازی‌شده را با همان اندازه نمایش بزرگ‌شده نشان می‌دهد. خطوط قطری در DPI 72 پیکسل‌گذاری واضح دارد و در وضوح‌های بالاتر لبه‌های نرم‌تری دارد، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً تمام جزئیات را بهبود نمی‌بخشد یا هر تصویر صادرشده‌ای را تغییر نمی‌دهد.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) وضوح تصویر را کاهش می‌دهد و می‌تواند اثر تغییر وضوح رستری‌سازی متافایل را مخفی کند. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) کیفیت رمزگذاری JPEG را کنترل می‌کند، نه وضوح رستری‌سازی متافایل.

## **تخصیص شناسه‌های ثابت به اشکال و متن**

یک فراخوانی قالب‌بندی به [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) ارائه دهید تا برای هر شکل SVG [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) تنظیم شود. این فراخوانی می‌تواند مقادیر [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) را برای عناصر `tspan` متن نیز تنظیم کند.

PhpJavaBridge نمی‌تواند یک فراخوانی PHP را از `writeAsSvg` در حالت جریان صدا بزند. منطق قالب‌بندی را در یک کلاس کمکی کوچک جاوا قرار دهید، آن را کامپایل کنید و فایل JAR حاصل را به مسیر کلاس‌پث پل اضافه کنید. این کمکی می‌تواند از [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) که برای طول عمر شکل ثابت است، و یک شمارندهٔ تکرارپذیر برای بازه‌های متنی استفاده کند. نگاه کنید به [Java implementation of `StableSvgIdController`](/slides/fa/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) برای کد کمکی.

پس از افزودن کلاس کامپایل‌شده `com.example.slides.StableSvgIdController` به مسیر کلاس‌پث پل، آن را از PHP نمونه‌سازی کرده و به `SVGOptions` اختصاص دهید:

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

## **افزودن کنترل‌کننده‌های رویداد SVG**

در یک فراخوانی قالب‌بندی، با [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) یک مقدار [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) فراخوانی کنید تا یک کنترل‌کنندهٔ JavaScript به شکل صادرشده اضافه شود. فراخوانی را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) انتساب دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند، تعریف کنید.

همانند شناسه‌های ثابت، فراخوانی را در یک کمکی جاوا هنگامی که PhpJavaBridge از حالت جریان استفاده می‌کند، پیاده‌سازی کنید. [Java implementation of `SvgEventController`](/slides/fa/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) یک شناسه و یک کنترل‌کنندهٔ `OnClick` به شکلی به نام `ActionButton` اختصاص می‌دهد. آن کمکی را کامپایل کنید، به مسیر کلاس‌پث پل به عنوان `com.example.slides.SvgEventController` اضافه کنید و از PHP به شکل زیر استفاده کنید:

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

صفحهٔ میزبان می‌تواند تابع JavaScript اشاره‌شده توسط کنترل‌کننده را تعریف کند. اختصاص شناسه‌ها و کنترل‌کننده‌های رویداد، امکان استفاده از نمایشگرهای اسلاید، بهبود دسترس‌پذیری و سایر گردش‌کارهای تعاملی SVG را فراهم می‌آورد.

## **سوالات متداول**

**چه زمانی باید به‌جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) استفاده کنم؟**

وقتی تمام متن باید مستقل از قلم‌ها باشد، از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) استفاده کنید. وقتی فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند باید به گرافیک تبدیل شوند، از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) استفاده کنید.

**بهترین راه برای کوچک‌تر کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی تصویر برش‑خورده و انتخاب فایل‌های قلم پیوندی که محیط هدف می‌تواند سرویس‌دهی کند، شروع کنید. نتیجه را آزمایش کنید زیرا کاهش وضوح تصویر، کاهش کیفیت JPEG و بردارسازی متن هر کدام تعادلات متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم پس از صادر شدن عناصر SVG را تغییر دهم؟**

بله. با استفاده از یک فراخوانی قالب‌بندی شناسه‌ها را اختصاص دهید، سپس عناصر SVG مطابقت‌دار را در ابزار پس‌پردازش یا اسکریپت مرورگر خود انتخاب کنید.