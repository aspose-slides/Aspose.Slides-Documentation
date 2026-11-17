---
title: مدیریت اثرهای تبدیل تصویر در ارائه‌ها با PHP
linktitle: اثرهای تبدیل تصویر
type: docs
weight: 11
url: /fa/php-java/image-transform-effects/
keywords:
- تبدیل تصویر
- اثر تصویر
- روشنایی
- کنتراست
- تبدیل به خاکستری
- دو‑تن
- رنگ‌زدایی
- HSL
- جایگزینی رنگ
- تاری
- شفافیت
- اثر آلفا
- زنجیره اثر
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "اعمال، زنجیره‌بندی، بازرسی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویر با Aspose.Slides برای PHP از طریق Java."
---
## **نمای کلی**

Aspose.Slides تنظیمات تصویر را به‌عنوان یک مجموعهٔ مرتب از عملیات تبدیل تصویر نمایش می‌دهد. برای یک فریم تصویر، ابتدا از [تصویر](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) فریم شروع کنید و به [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/) دسترسی پیدا کنید. مجموعه بازگردانده‌شدهٔ [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) به شما اجازه می‌دهد تا اثرها را اضافه، شمارش، بازرسی، حذف و پاک کنید بدون اینکه بایت‌های تصویر اصلی بازنویسی شوند.

این مقاله یک جریان کار کامل برای روشنایی و کنتراست، تبدیل‌های رنگ، تاری، شفافیت، زنجیره‌های اثر مرتب، مقادیر مؤثر، حذف و تأیید دورانی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و استفاده مجدد از تصویر**

یک منبع تصویر و تصویری که آن را نشان می‌دهد، اشیای متفاوتی هستند:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) ذخیره یا مرجع داده‌های تصویر منبع که متعلق به ارائه است.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) به پر کردن تصویر تعلق دارد و به منبع تصویر ارجاع می‌دهد در حالی که مجموعهٔ تبدیل تصویر را ذخیره می‌کند.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) شکل اسلایدی است که پر کردن تصویر مربوطه، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح فریم را داراست.

بنابراین، عملیات تبدیل تصویر بایت‌های موجود در [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) را تغییر نمی‌دهند. وقتی همان `PPImage` بیش از یک بار به [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) پاس داده شود، هر فریم تصویر جدید یک `Picture` و یک مجموعهٔ تبدیل مخصوص به خود دریافت می‌کند. اعمال خاکستری به یک فریم باعث نمی‌شود فریم‌های دیگر نیز خاکستری شوند، حتی اگر همهٔ آن‌ها از همان منبع تصویر جاسازی‌شده استفاده کنند.

همان مدل `Picture::getImageTransform` همچنین توسط پر کردن‌های تصویری دیگر، مانند یک شکل یا پس‌زمینهٔ اسلاید، استفاده می‌شود. مثال‌های زیر بر فریم‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای معتبر پارامترها**

روش‌های نمایش داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. مقادیر را در این بازه‌ها نگه دارید حتی اگر نسخهٔ خاصی از کتابخانه بلافاصله هر مقدار خارج از بازه را رد نکند؛ قالب هدف ارائه ممکن است داده‌های نامعتبر را در حین ذخیره‌سازی یا هنگام باز کردن فایل توسط PowerPoint نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه معتبر و واحد |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` جزء را بدون تغییر می‌گذارد. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | هیچ‌کدام. بدون پارامتر عددی. آلفا بدون تغییر می‌ماند. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | دو رنگ برای پیکسل‌های تاریک و روشن. کانال‌های RGB و آلفا در `java.awt.Color` از `0` تا `255` استفاده می‌کنند. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | hue از `0` شامل تا `360` غیرشامل، بر حسب درجه؛ amount از `-100` تا `100`، درصد. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | hue از `0` شامل تا `360` غیرشامل، بر حسب درجه؛ saturation و luminance از `-100` تا `100`، درصد. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | رنگ جایگزین مقادیر کانال را از `0` تا `255` استفاده می‌کند. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | شعاع غیرمنفی است و بر حسب پوینت اندازه‌گیری می‌شود؛ `grow` یک Boolean است که تعیین می‌کند آیا محتوی تار شده می‌تواند خارج از مرزهای اصلی گسترش یابد. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | درصد غیرمنفی. از `0` تا `100` برای مقیاس‌گذاری معمولی شفافیت استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` تا `100`، درصد شفافیت. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` تا `100`، درصد آستانه آلفا. مقادیر زیر این آستانه شفاف می‌شوند؛ مقادیر برابر یا بالاتر از آن مات می‌شوند. |

برای مدولاسیون ثابت آلفا، شفافیت و مات بودن مکمل یکدیگر هستند. به‌عنوان مثال، 35٪ شفافیت متناظر با مقدار مدولاسیون آلفا 65٪ است.

## **اعمال روشنایی و کنتراست**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) یک عملیات [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/) برمی‌گرداند. تنظیمات اسکالر هنگام ایجاد عملیات فراهم می‌شوند. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) مقادیر محاسبه‌شدهٔ فقط‑خواندنی را برمی‌گرداند که می‌توان آن‌ها را بازرسی یا لاگ کرد.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد، سپس پیش‌نمایشی بدون تغییر تصویر جاسازی‌شده رندر می‌کند:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` اثر استاندارد DrawingML برای روشنایی و کنتراست است. وقتی این تنظیمات باید پس از یک دورانی PPTX قابل ویرایش باقی بمانند، ارائهٔ ذخیره‌شده را باز کنید و هم نوع عمل و هم مقادیر مؤثر آن را تأیید کنید.

## **اعمال تبدیل‌های رنگ**

اثرهای رنگی می‌توانند به‌صورت مستقل بر فریم‌های تصویری متفاوتی که از یک منبع تصویر استفاده می‌کنند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب خاکستری، دو‑تن، رنگ‌زدایی، تنظیم HSL و جایگزینی رنگ را اعمال می‌کند.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) دو پارامتر رنگی مستقل‌قابل ویرایشی دارد: `color1` پیکسل‌های تاریک را نقشه می‌کند، در حالی که `color2` پیکسل‌های روشن را نقشه می‌کند. این یک مثال مفید از اثری است که تنظیمات آن پیچیده‌تر از یک مقدار اسکالر واحد است.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) رنگ هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌کند. این با [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) متفاوت است که یک رنگ منبع را به رنگ دیگری نقشه می‌کند و هر دو قالب رنگ منبع و هدف را نشان می‌دهد.

### **اعمال آستانه روشنایی**

آستانه روشنایی می‌تواند علامت‌های ضعیف روی یک صفحهٔ اسکن‌شده را از پس‌زمینه قابل تمایزتر کند. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) سایه‌های میانی خاکستری را حفظ می‌کند. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) روشنایی را به سیاه یا سفید نگاشت می‌کند، در حالی که [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) آستانه‌ای بر شفافیت اعمال می‌کند.

آستانه روشنایی از 0٪ تا 100٪، شامل است. پیکسل‌های زیر آستانه سیاه می‌شوند. پیکسل‌های برابر یا بالای آستانه سفید می‌شوند. افزایش آستانه باعث می‌شود سایه‌های بیشتری سیاه شوند زیرا بیشتر آن‌ها زیر حد قطع قرار می‌گیرند.

فایل [grayscale-swatches.png](grayscale-swatches.png) را در پوشهٔ حاوی اسکریپت PHP دانلود کنید. هر برچسب سطح خاکستری اصلی را روی مقیاسی از 0 تا 255 نشان می‌دهد. مثال اصل را در کنار دو نسخهٔ کپی قرار می‌دهد و آستانهٔ هر کپی را در ارائه ذخیره می‌کند.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

خروجی ارائه را در PowerPoint باز کنید تا سه فریم را مقایسه کنید. نمونهٔ با برچسب 96 تقریباً 38٪ روشنایی دارد (96 از 255). در آستانهٔ 20٪ سفید می‌شود و در آستانهٔ 60٪ سیاه می‌شود.

![نمونه‌های خاکستری اصلی در کنار نتایج سیاه‑سفید در آستانه‌های روشنایی 20٪ و 60٪](luminance-threshold.png)

## **افزودن تاری، شفافیت و اثرات آلفا**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) تمام کانال‌های رنگی، شامل آلفا، را تحت تأثیر قرار می‌دهد. وقتی لبهٔ تاری ممکن است خارج از مرزهای تصویر اصلی گسترش یابد، `grow` را به `true` تنظیم کنید.

برای شفافیت یکنواخت، از [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) استفاده کنید. این اثر هر مقدار آلفای موجود را ضرب می‌کند، به‌طوری که پیکسل‌های نیمه‑شفاف به‌صورت نسبی متفاوت باقی می‌مانند. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) به‌جای آن یک مقدار آلفا واحد را به تمام پیکسل‌ها اختصاص می‌دهد. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) آلفا را بر پایهٔ یک آستانه به دو سطح تبدیل می‌کند.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

سایر عملیات آلفا بدون پارامتر شامل [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/)، که هر آلفای غیر صفر را کاملاً مات می‌کند؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/)، که هر آلفای زیر 100٪ را کاملاً شفاف می‌کند؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/)، که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت زنجیره اثر مرتب**

هر متد `add...Effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرکننده مجموعه را به‌عنوان یک خط لولهٔ مرتب استفاده می‌کند: خروجی عملیات 0 به عنوان ورودی عملیات 1 و به همین ترتیب ادامه می‌یابد. بنابراین، همان عملیات‌ها با ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به‌عنوان مثال، خاکستری شدن سپس رنگ‌زدایی ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتیجهٔ روشنایی را رنگ می‌دهد. رنگ‌زدایی سپس خاکستری شدن رنگ‌زدایی را دوباره حذف می‌کند. به همین ترتیب، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات‌های قبلی را نادیده بگیرد، در حالی که مدولاسیون آلفا تفاوت‌های نسبی آن‌ها را حفظ می‌کند.

مثال زیر زنجیره‌ای با چهار عملیات می‌سازد، آن را به صورت PPTX ذخیره می‌کند، ارائه را دوباره باز می‌کند، هر دو نوع عملیات و ترتیب آن‌ها را بررسی می‌کند و نتیجهٔ بازگشایی‌شده را رندر می‌کند:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

مجموعه محدودیتی برای ترکیب رنگ، آلفا و عملیات‌های تاری در زنجیره‌های جداگانه اعمال نمی‌کند. می‌توان آن‌ها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. جایگزینی رنگ ثابت، تغییرات RGB ایجاد شده توسط اثرهای رنگی پیشین را حذف می‌کند؛ خاکستری پس از دو‑تن، دو رنگ انتخابی را حذف می‌کند؛ و عملیات‌های آلفا سقف، کف، جایگزینی یا دو‑سطح می‌توانند جزئیات آلفا ایجاد شده پیشتر را از دست بدهند. زنجیره را بر اساس توالی پردازش پیکسل دلخواه بسازید نه به عنوان پرچم‌های قالب‌بندی نامرتب.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **بازرسی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش همان شیء ذخیره‌شده در `Picture::getImageTransform` است. بسته به اثر، ممکن است اعضای قابل نوشتن به‌صورت مستقیم در دسترس باشد. برای مثال، [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) مقادیر `radius` و `grow` را قابل نوشتن می‌کند، [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) `amount` را قابل نوشتن می‌کند، و [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) `threshold` را قابل نوشتن می‌کند. اثرهای رنگی مانند [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) اشیای [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) قابل تغییر را نشان می‌دهند.

برخی عملیات‌ها، از جمله [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/)، [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/)، [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/)، و [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/)، اسکالرهای ایجادشان را به‌عنوان ویژگی‌های قابل نوشتن نشان نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کنید و به‌موقع در موقعیت موردنظر یک عملیات جایگزین اضافه کنید.

داده‌های مؤثر بازگردانده‌شده توسط `getEffective()` محاسبه‌شده و فقط‑خواندنی هستند. این داده‌ها برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرکننده استفاده می‌کند مفیدند، اما سطح ویرایشی دیگری نیستند. مثال زیر زنجیره را شمارش می‌کند و مقادیر مؤثر را در جاهایی که API مربوطه آن‌ها را فراهم می‌کند، بازرسی می‌کند:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

اثرهای بدون پارامتر مانند خاکستری، سقف آلفا و معکوس آلفا همچنان یک شیء دادهٔ مؤثر دارند، اما اسکالرهایی برای چاپ وجود ندارند. حضور و موقعیت آن‌ها در مجموعه اطلاعات مهم است.

## **حذف یا پاک کردن تبدیل‌های تصویر**

از [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) برای حذف یک عملیات بر پایهٔ شاخص استفاده کنید. چون شاخص‌ها پس از حذف جابجا می‌شوند، ابتدا هدف را پیدا کنید و سپس پس از شمارش آن را حذف کنید. از [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) برای حذف کل زنجیره استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

حذف یا پاک کردن تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این کار منبع [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) مورد استفاده را حذف، فشرده‌سازی یا به‌صورت دیگری تغییر نمی‌دهد.

## **در نظر گرفتن فرمت‌های ارائه و هدف‌های خروجی**

تبدیل‌های تصویر از DrawingML سرچشمه می‌گیرند، بنابراین PPTX قالب ویرایشی ترجیحی برای زنجیره‌های اثر است. حتی با PPTX، همهٔ عملیات‌ها قابلیت انتقال یکسانی ندارند:

- عملیات‌های استاندارد DrawingML مانند luminance، grayscale، duotone، tint، HSL، blur و عملیات‌های رایج آلفا بهترین شانس برای بقا پس از یک دورانی PPTX را دارند. همیشه فایل تولیدی را باز کنید و مجموعه را هنگام نیاز به حفظ بررسی کنید.
- قالب باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT ممکن است عملیات‌های نامپشتیبانی‌شده را حذف کند، زنجیره را به زیرمجموعه‌ای پشتیبانی‌شده تقلیل دهد یا ظاهر را تقریب بزند. برای تأیید یک زنجیرهٔ ویرایشی پیچیده از PPT استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا خروجی‌های بصری دیگر زنجیرهٔ پشتیبانی‌شده را بر ظاهر رندر شده اعمال می‌کند. این خروجی‌ها یک `ImageTransformOperationCollection` ویرایشی ندارند؛ قالب‌های رستر نتیجه را به پیکسل‌ها فلت می‌کنند و خروجی‌های سند یا وکتور نمایش خود را ذخیره می‌کنند.
- اثرها تصویر پیوست‌شده را خودکفا نمی‌سازند. رندر یک تصویر پیوست‌شده همچنان به در دسترس بودن منبع پیوست‌شده هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه‌ای را به‌صورت متفاوتی رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگی ترکیب می‌شوند. برای خروجی بحرانی، هر دو دورانی ویرایشی و قالب خروجی نهایی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود آزمون کنید.

## **سوالات متداول**

**آیا اثرهای تبدیل تصویر داده‌های تصویر جاسازی‌شده را تغییر می‌دهند؟**

نه. عملیات‌ها متعلق به `Picture` استفاده‌شده توسط پر کردن تصویر هستند. بایت‌های زیرین `PPImage` بدون تغییر می‌مانند.

**آیا دو فریم تصویر که از یک تصویر یکسان استفاده می‌کنند اثرهای خود را به‌اشتراک می‌گذارند؟**

نه. استفادهٔ مجدد از یک `PPImage` از تکرار دادهٔ تصویر جلوگیری می‌کند، اما هر فریم تصویر معمولاً یک `Picture` و مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا می‌توان اثرهای رنگ، تاری و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ مرتب می‌پذیرد. به این نکته توجه کنید که هر عملیات چه تاثیری بر خروجی عملیات قبلی دارد، زیرا عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

داده‌های مؤثر مقادیر محاسبه‌شده‌ای هستند که برای رندر استفاده می‌شوند، شامل رنگ‌های حل‌شده. عملیات را در مجموعه تبدیل ویرایش کنید جایی که اعضای قابل نوشتن وجود دارند؛ در غیر این صورت آن را حذف کنید و با پارامترهای جدید یک عملیات جایگزین اضافه کنید.

**کدام قالب برای حفظ زنجیرهٔ تبدیل مناسب است؟**

از PPTX استفاده کنید و فایل را با بازگشایی مجدد تأیید کنید. PPT قدیمی نمی‌تواند مدل کامل اثر DrawingML را نشان دهد و قالب‌های خروجی رندر شده فقط ظاهر را حفظ می‌کنند، نه عملیات تبدیل ویرایشی.