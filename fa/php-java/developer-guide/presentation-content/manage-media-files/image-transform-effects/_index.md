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
- مقیاس‌سوزی
- دو‑تن
- رنگ‌نقش
- HSL
- جایگزینی رنگ
- تار شدن
- شفافیت
- اثر آلفا
- زنجیره اثر
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "اعمال، زنجیره‌سازی، بازرسی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویری با Aspose.Slides برای PHP از طریق Java."
---
## **مروری کلی**

Aspose.Slides تنظیمات تصویر را به صورت مجموعه‌ای ترتیبی از عملیات تبدیل تصویر نمایش می‌دهد. برای یک فریم تصویر، با [Picture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picture/) فریم شروع کنید و به [Picture::getImageTransform](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picture/getimagetransform/) دسترسی پیدا کنید. مجموعه بازگشتی [ImageTransformOperationCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/) به شما امکان می‌دهد اثرات را اضافه، مرور، بازرسی، حذف و پاک کنید بدون این که بایت‌های تصویر اصلی بازنویسی شوند.

این مقاله یک جریان کاری کامل برای روشنایی و کنتراست، تبدیل‌های رنگی، تار کردن، شفافیت، زنجیره اثرات ترتیبی، مقادیر مؤثر، حذف و بررسی صحت دورانداز PPTX را نشان می‌دهد.

## **درک مالکیت اثر و استفاده مجدد از تصویر**

یک منبع تصویر و تصویری که آن را نمایش می‌دهد، اشیاء متفاوتی هستند:

- [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) داده‌های تصویر منبع را که به ارائه تعلق دارد، ذخیره یا ارجاع می‌دهد.
- [Picture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picture/) به پرشدن تصویر تعلق دارد و به یک منبع تصویر ارجاع می‌دهد در حالی که مجموعه تبدیل تصویر را ذخیره می‌کند.
- [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) شکل اسلایدی است که پرشدن تصویر مربوطه، هندسه، تنظیمات برش و دیگر قالب‌بندی‌های سطح فریم را در اختیار دارد.

به همین دلیل، عملیات تبدیل تصویر بایت‌های موجود در [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) را تغییر نمی‌دهند. وقتی یک `PPImage` یک‌باره به [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addpictureframe/) بیشتر از یک بار پاس داده می‌شود، هر فریم تصویر جدید یک `Picture` و مجموعه تبدیل جداگانه دریافت می‌کند. اعمال مقیاس‌سوزی (grayscale) بر یک فریم، فریم‌های دیگر را مقیاس‌سوزی نمی‌کند، حتی اگر همه آن‌ها از همان منبع تصویر توکار استفاده کنند.

مدل `Picture::getImageTransform` یکسان توسط سایر پرشدن‌های تصویری نیز استفاده می‌شود، مانند شکل یا پس‌زمینه اسلاید. مثال‌های زیر بر فریم‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای معتبر پارامترها**

روش‌های معرفی‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر یک نسخه خاص از کتابخانه بازه‌های خارج از محدوده را بلافاصله رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ قالب هدف ممکن است در زمان ذخیره یا هنگام باز شدن توسط PowerPoint داده‌های نامعتبر را نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه معتبر و واحد |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | از `-100` تا `100` درصد؛ مقدار `0` مؤلفه را بدون تغییر می‌گذارد. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | بدون پارامتر عددی. آلفا تغییر نمی‌کند. |
| [addDuotoneEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | دو رنگ برای پیکسل‌های تاریک و روشن. مقادیر کانال‌های RGB و آلفا در `java.awt.Color` از `0` تا `255`. |
| [addTintEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` از `0` شامل تا `360` غیرفعال درجه؛ `amount` از `-100` تا `100` درصد. |
| [addHSLEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` از `0` شامل تا `360` غیرفعال درجه؛ `saturation` و `luminance` از `-100` تا `100` درصد. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | مقادیر کانال جایگزین از `0` تا `255`. مقدارهای آلفای موجود تغییر نمی‌کنند. |
| [addBlurEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` غیر منفی و بر حسب پوینت؛ `grow` یک Boolean است که تعیین می‌کند آیا محتوی تار شده می‌تواند خارج از مرزهای اصلی گسترش یابد یا نه. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | درصد غیر منفی. برای مقیاس‌گذاری معمول شفافیت از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | از `0` تا `100` درصد شفافیت. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | از `0` تا `100` درصد آلفا آستانه. مقادیر زیر آن شفاف می‌شوند؛ مقادیر برابر یا بالاتر کاملاً مات می‌شوند. |

برای تنظیم ثابت آلفا، شفافیت و مات بودن مکمل یکدیگر هستند. به عنوان مثال، 35% شفافیت معادل مقدار مدولاسیون آلفا 65% است.

## **اعمال روشنایی و کنتراست**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) یک عمل [Luminance](https://reference.aspose.com/slides/fa/php-java/aspose.slides/luminance/) برمی‌گرداند. تنظیمات عددی آن هنگام ایجاد عملیات تأمین می‌شوند. [Luminance::getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/luminance/geteffective/) مقادیر محاسبه‌شده فقط‑خواندنی را که می‌توان بازرسی یا ثبت کرد، برمی‌گرداند.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد، سپس یک پیش‌نمایش رندر می‌کند بدون اینکه تصویر توکار تغییر کند:

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

`Luminance` اثر استاندارد DrawingML برای روشنایی و کنتراست است. وقتی این تنظیمات باید پس از یک دورانداز PPTX قابل ویرایش بمانند، ارائه ذخیره‌شده را دوباره باز کنید و هم نوع عملیات و هم مقادیر مؤثر آن را تأیید کنید.

## **اعمال تبدیل‌های رنگی**

اثرهای رنگی می‌توانند به طور مستقل بر فریم‌های تصویری مختلف که یک منبع تصویر را به‌کار می‌برند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب مقیاس‌سوزی، دو‑تن، رنگ‌نقش، تنظیم HSL و جایگزینی رنگ را اعمال می‌کند.

[Duotone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/duotone/) شامل دو پارامتر رنگی مستقل‌قابل‑ویرایش است: `color1` پیکسل‌های تاریک و `color2` پیکسل‌های روشن را نقشه‌برداری می‌کند. این مثال مفیدی برای اثری است که تنظیماتش پیچیده‌تر از یک مقدار عددی تک‌متغیره است.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) هر رنگ پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌کند. این متفاوت از [addColorChangeEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) است که یک رنگ منبع را به رنگ هدفی دیگر نقشه‌برداری می‌کند و هر دو قالب رنگ منبع و هدف را نمایان می‌سازد.

## **افزودن تار، شفافیت و اثرهای آلفا**

[addBlurEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) تمام کانال‌های رنگی، از جمله آلفا را تحت تأثیر قرار می‌دهد. وقتی لبه‌های تار ممکن است از مرزهای تصویر اصلی فراتر بروند، `grow` را برابر `true` تنظیم کنید.

برای شفافیت یکنواخت، از [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) استفاده کنید. این اثر همه مقدارهای آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های نیمه‑شفاف به نسبت متفاوت باقی می‌مانند. [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) به‌جای اینکه ضرب کند، یک مقدار آلفای واحد را به همه پیکسل‌ها اختصاص می‌دهد. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) آلفا را بر اساس یک آستانه به دو سطح تبدیل می‌کند.

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

سایر عملیات آلفا بدون پارامتر شامل [addAlphaCeilingEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/) است که تمام آلفا‌های غیرصفر را کاملاً مات می‌کند؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/) که تمام آلفا‌های زیر 100٪ را کاملاً شفاف می‌کند؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/) که آلفا را به `100% - alpha` تبدیل می‌کند.

## **ساخت زنجیره اثر ترتیبی**

هر متد `add...Effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرکننده مجموعه را به عنوان یک خط لوله ترتیبی استفاده می‌کند: خروجی عملیات ۰ به عنوان ورودی عملیات ۱ و به همین ترتیب. بنابراین، اجرای همان عملیات‌ها به ترتیب متفاوت می‌تواند تصویر متفاوتی تولید کند.

به عنوان مثال، مقیاس‌سوزی سپس رنگ‌نقش ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتیجه‌ی روشنایی را رنگ‌آمیزی می‌کند. رنگ‌نقش سپس مقیاس‌سوزی دوباره اثر رنگ‌نقش را از بین می‌برد. به همان ترتیب، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات‌های قبلی را بازنویسی کند، در حالی که مدولاسیون آلفا اختلافات نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیره چهار عملیاتی می‌سازد، آن را به عنوان PPTX ذخیره می‌کند، ارائه را دوباره باز می‌کند، هم نوع عملیات‌ها و هم ترتیب آن‌ها را بررسی می‌کند و نتیجه بازگشایی‌شده را رندر می‌کند:

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

مجموعه محدودیتی برای ترکیب رنگ، آلفا و عملیات تار نمی‌گذارد که در زنجیره‌های جداگانه قرار گیرند. می‌توان آن‌ها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. یک جایگزینی رنگ ثابت تنوع RGB تولید شده توسط اثرهای رنگی قبلی را حذف می‌کند؛ مقیاس‌سوزی پس از دو‑تن دو رنگ انتخاب‌شده را از بین می‌برد؛ و عملیات‌های آلفا سقف، کف، جایگزینی یا دو‑سطح می‌توانند جزئیات آلفا ایجاد‌شده قبلی را از دست بدهند. زنجیره را بر اساس ترتیب پردازش پیکسل دلخواه بسازید نه به‌عنوان پرچم‌های قالب‌بندی نامرتب.

## **بازبینی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش همان شیء ذخیره‌شده در `Picture::getImageTransform` است. بسته به اثر، ممکن است اعضای نوشتنی را مستقیماً نشان دهد. برای مثال، [Blur](https://reference.aspose.com/slides/fa/php-java/aspose.slides/blur/) مقادیر نوشتنی `radius` و `grow` را ارائه می‌دهد، [AlphaModulateFixed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/alphamodulatefixed/) مقدار نوشتنی `amount`، و [AlphaBiLevel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/alphabilevel/) مقدار نوشتنی `threshold`. اثرهای رنگی مانند [Duotone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/duotone/) اشیاء [ColorFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorformat/) قابل تغییر را نشان می‌دهند.

برخی عملیات‌ها، از جمله [Luminance](https://reference.aspose.com/slides/fa/php-java/aspose.slides/luminance/)، [HSL](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tint/)، و [AlphaReplace](https://reference.aspose.com/slides/fa/php-java/aspose.slides/alphareplace/)، مقیاس‌های ایجاد خود را به عنوان ویژگی‌های نوشتنی نشان نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کنید و جایگزینی در موقعیت مورد نیاز اضافه کنید.

داده‌های مؤثر بازگردانده‌شده توسط `getEffective()` محاسبه‌شده و فقط‑خواندنی‌اند. این داده‌ها برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرکننده استفاده می‌کند مفید هستند، اما سطح ویرایش دیگری نیستند. مثال زیر زنجیره را مرور می‌کند و مقادیر مؤثر را در جایی که API مربوطه آن‌ها را فراهم می‌کند، بررسی می‌کند:

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

اثرهای بدون پارامتر مانند مقیاس‌سوزی، سقف آلفا و وارون آلفا نیز یک شیء داده‑موثر دارند، اما مقدار عددی برای چاپ ندارند. حضور و موقعیت آن‌ها در مجموعه، اطلاعات مهم است.

## **حذف یا پاک کردن تبدیل‌های تصویر**

برای حذف یک عملیات با استفاده از ایندکس، از [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/removeat/) استفاده کنید. چون ایندکس‌ها پس از حذف جابه‌جا می‌شوند، ابتدا هدف را جستجو کنید و پس از مرور آن را حذف کنید. برای حذف کل زنجیره از [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagetransformoperationcollection/clear/) استفاده کنید.

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

حذف یا پاک کردن تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این کار منبع [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) استفاده‌شده را حذف، فشرده‌سازی یا به‌طور دیگری تغییر نمی‌دهد.

## **در نظر گرفتن فرمت‌های ارائه و هدف‌های خروجی**

تبدیل‌های تصویر در DrawingML زاییده می‌شوند، بنابراین PPTX قالب قابل ویرایش ترجیحی برای زنجیره‌های اثر است. حتی در PPTX نیز همه عملیات‌ها قابلیت انتقال یکسانی ندارند:

- عملیات‌های استاندارد DrawingML مانند luminance، grayscale، duotone، tint، HSL، blur و عملیات‌های عمومی آلفا بیشترین شانس بقا پس از یک دورانداز PPTX را دارند. همیشه فایل تولیدشده را دوباره باز کنید و مجموعه را هنگام نیاز به حفظ بررسی کنید.
- فرمت باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT می‌تواند عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعه‌ای پشتیبانی‌شده محدود کند یا ظاهر را تقریب بزند. برای یک زنجیره پیچیده ویرایش‌پذیر از PPT به‌عنوان قالب تأیید استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا خروجی‌های بصری دیگر زنجیره پشتیبانی‌شده را بر ظاهر رندر شده اعمال می‌کند. این خروجی‌ها `ImageTransformOperationCollection` ویرایش‌پذیری ندارند؛ فرمت‌های رستر نتیجه را به پیکسل‌ها مسطح می‌کنند و صادرات‌های سند یا برداری نمای رندر خودشان را ذخیره می‌کنند.
- اثرها تصویر پیوندی را خودکفا نمی‌سازند. رندر یک تصویر پیوندی همچنان به در دسترس بودن منبع پیوندی هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه‌ای را به‌طور متفاوتی رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگ‑کوانتیزه ترکیب می‌شوند. برای خروجی‌های بحرانی، هر دو دورانداز ویرایش‌پذیر و قالب خروجی نهایی را با همان نسخه Aspose.Slides که در تولید استفاده می‌شود، تست کنید.

## **پرسش‌های متداول**

**آیا اثرهای تبدیل تصویر داده‌های تصویر توکار را تغییر می‌دهند؟**

خیر. عملیات‌ها به `Picture` استفاده‌شده توسط پرشدن تصویر تعلق دارند. بایت‌های زیرین `PPImage` بدون تغییر می‌مانند.

**آیا دو فریم تصویر که از یک تصویر استفاده می‌کنند اثرهای خود را به‌اشتراک می‌گذارند؟**

خیر. استفاده مجدد از یک `PPImage` از تکرار داده‌های تصویر جلوگیری می‌کند، اما هر فریم تصویر معمولاً دارای `Picture` و مجموعه تبدیل تصویر جداگانه‌ای است.

**آیا می‌توان اثرهای رنگ، تار و آلفا را ترکیب کرد؟**

بله. مجموعه این اثرها را در یک زنجیره ترتیبی می‌پذیرد. به این‌که هر عملیات چه تاثیری بر خروجی عملیات قبلی دارد توجه کنید، چون عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

داده‌های مؤثر مقادیر محاسبه‌شده‌ای هستند که برای رندر استفاده می‌شوند، از جمله رنگ‌های حل‌شده. عملیات ذخیره‌شده در مجموعه تبدیل را جایی ویرایش کنید که اعضای نوشتنی وجود داشته باشند؛ در غیر این‌صورت آن را حذف کنید و با پارامترهای جدید جایگزین نمایید.

**کدام قالب بهتر است برای حفظ زنجیره تبدیل؟**

از PPTX استفاده کنید و فایل را با باز کردن مجدد تأیید کنید. PPT قدیمی نمی‌تواند مدل کامل اثر DrawingML را نمایش دهد و قالب‌های خروجی رندر‌شده ظاهر را حفظ می‌کنند نه عملیات‌های تبدیل قابل ویرایش.