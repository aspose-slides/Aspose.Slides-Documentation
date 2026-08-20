---
title: مدیریت قاب‌های تصویر در ارائه‌ها با استفاده از PHP
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/php-java/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- تصویر تعبیه‌شده
- تصویر لینک‌دار
- استخراج تصویر
- تصویر رستر
- تصویر SVG
- قلم‌برداری تصویر
- حذف نواحی قلم‌برداری‌شده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی قاب تصویر
- مقیاس نسبی
- افکت تصویر
- نسبت عرض به ارتفاع
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قاب‌های تصویر را در ارائه‌ها ایجاد، قالب‌بندی، لینک‌گذاری، قلم‌برداری، استخراج و فشرده‌سازی کنید با Aspose.Slides برای PHP از طریق Java."
---
## **مرور کلی**

قاب تصویر یک شکل اسلاید است که تصویری را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد اشیای جداگانه‌ای هستند: یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) منابع تصویر تعبیه‌شده را از طریق [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) خود در اختیار دارد، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) موقعیت، اندازه، فرمت خط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح‑قاب را کنترل می‌کند.

این جداسازی وقتی مفید است که همان تصویر بیش از یک بار نشان داده شود. تصویر را یک بار به ارائه اضافه کنید، شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) بازگردانده‌شده را نگه دارید و هنگام ایجاد قاب‌های تصویر از آن منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند تصاویر رستر مانند PNG یا JPEG و تصاویر برداری SVG را شامل شوند. همچنین می‌توانند به تصاویر لینک‌دار اشاره کنند به‌جای این‌که بایت‌های تصویر را در ارائه ذخیره کنند. انتخاب بین این دو بر قابلیت حمل، حجم فایل، استخراج و رفتار صادرات تأثیر می‌گذارد، بنابراین قبل از اعمال فرمت‌بندی یا بهینه‌سازی تصمیم‌گیری در مورد نحوه ذخیره‌سازی تصویر مفید است.

## **افزودن و فرمت‌بندی یک تصویر تعبیه‌شده**

برای یک تصویر تعبیه‌شده، داده‌های تصویر را به ارائه اضافه کنید و با استفاده از [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addpictureframe/) یک قاب تصویر بسازید. تصویر جزو بسته ارائه می‌شود، به‌طوری که ارائه هنگام جابجایی به رایانه دیگر خود‑کافی می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، قاب را با ابعاد اصلی تصویر می‌سازد و فرمت خط و چرخش را اعمال می‌کند:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

قاب تصویر هندسه نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازه قاب باعث تغییر ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر تعبیه‌شده نمی‌شود. این تمایز هنگام برش یا فشرده‌سازی تصویر در مراحل بعدی مهم می‌شود.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) مقیاس عرض و ارتفاع نسبی قاب را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/setrelativescalewidth/) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/setrelativescaleheight/) فراهم می‌کند. مقدار `1.0` متناظر با 100٪ اندازه اصلی تصویر است. مقیاس نسبی زمانی مفید است که گردش کاری نیاز داشته باشد نسبت به اندازه منبع تصویر حفظ شود نه اینکه ابعاد نهایی به‌صورت دستی محاسبه شود.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ تصویر تعبیه‌شده را دوباره‌نمونه‌گیری یا فشرده نمی‌کند.

## **تصاویر تعبیه‌شده و لینک‌دار**

یک تصویر تعبیه‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین امن‌ترین گزینه برای قابلیت حمل و رندر پیش‌بینی‌پذیر است. یک تصویر لینک‌دار مسیر خارجی را از طریق متد [Picture::setLinkPathLong](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picture/setlinkpathlong/) ذخیره می‌کند به‌جای این‌که داده‌های تصویر را به همان شکل تعبیه کند.

تصاویر لینک‌دار می‌توانند میزان داده‌های تصویری ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل لینک‌شده باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس بماند. اگر مسیر تغییر کند، فایل منتقل شود یا منبع در دسترس نباشد، تصویر لینک‌شده ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر تعبیه‌شده معمولاً قابل اعتمادترند.

### **افزودن یک تصویر لینک‌دار**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی ارجاع می‌دهد. این مثال فقط به لینک‌گذاری تصویر می‌پردازد؛ لینک‌گذاری ویدئو یک گردش کاری رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

از لینک‌ها زمانی استفاده کنید که مدیریت فایل‌های خارجی هدفمند باشد. فقط برای جایگزینی فشرده‌سازی از آن‌ها استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر شکسته معمولاً کمتر مفید است نسبت به یک ارائه بزرگ خود‑کافی.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) است و حاوی تصویر تعبیه‌شده می‌باشد. قاب‌های تصویر لینک‌دار ممکن است بایت‌های تصویری نداشته باشند که بتوان به همان روش استخراج کرد.

### **استخراج یک تصویر رستر**

API مدرن تصویر از [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) به‌صورت مستقیم استفاده می‌کند. مثال زیر اولین تصویر رستر تعبیه‌شده روی یک اسلاید را پیدا می‌کند و به‌صورت PNG ذخیره می‌نماید:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

ذخیره‌سازی از طریق [IImage::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/#save) تصویر استخراج‌شده را به فرمت خروجی موردنظر تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده‌ای که در ارائه ذخیره شده‌اند نیاز دارید نه به یک فایل رستر تبدیل‌شده، به جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) شیء [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) را در اختیار می‌گذارد. این به شما اجازه می‌دهد داده‌های SVG را مستقیماً بازیابی کنید به‌جای اینکه ابتدا تصویر را رستر کنید.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

نگه‌داشتن محتوای SVG به‌صورت SVG، منبع برداری را داخل ارائه حفظ می‌کند. صادرات رستری مانند PNG یا JPEG به‌ضرورت آن محتوا را به پیکسل تبدیل می‌کند. صادرات اسلاید به PDF یا SVG نیز یک عملیات رندرینگ است، بنابراین گرافیک‌های خروجی نباید به‌عنوان نسخه بایت‑به‑بایت SVG تعبیه‌شده اصلی در نظر گرفته شوند؛ وقتی منبع برداری اصلی موردنیاز است از داده‌ی [SvgImage::getSvgData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/getsvgdata/) استفاده کنید.

## **قلم‌برداری تصویر**

قلم‌برداری بخشی از تصویر را که داخل قاب قابل مشاهده است تغییر می‌دهد. مقادیر قلم‌برداری در [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) به‌صورت درصدی از ابعاد تصویر منبع هستند. قلم‌برداری در ابتدا پیکسل‌های مخفی را از تصویر تعبیه‌شده حذف نمی‌کند؛ فقط ناحیه قابل مشاهده را تغییر می‌دهد.

مثال زیر یک قاب تصویر را به‌صورت ایمن پیدا می‌کند و مقادیر قلم‌برداری را اعمال می‌نماید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

از آنجا که داده‌های تصویر مخفی هنوز موجود‌اند، می‌توان قلم‌برداری را بعداً بدون از دست رفتن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگشت باشد، می‌توان نواحی قلم‌برداری را همان‌طور که در بخش بعدی شرح داده شد، به‌صورت فیزیکی حذف کرد.

## **حذف داده‌های تصویر قلم‌برداری‌شده**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) داده‌های تصویری خارج از مستطیل قلم‌برداری فعلی را حذف می‌کند و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیره‌سازی ارائه، پیکسل‌های حذف‌شده دیگر برای یک عملیات «غیرقلم‌برداری» در دسترس نیستند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
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
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

این متد ممکن است منبع تصویر جدیدی به ارائه اضافه کند. اگر تصویر اصلی توسط قاب‌های تصویر دیگری نیز استفاده شود، آن قاب‌ها هنوز به منبع موجود خود نیاز دارند، بنابراین حذف نواحی قلم‌برداری لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. قلم‌برداری محتویات WMF یا EMF با این متد نتیجه را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستر**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی قلم‌برداری را در همان عملیات حذف کند. این متد زمانی که تصویر تغییر اندازه یا قلم‌برداری شده باشد `true` و در غیر این صورت `false` برمی‌گرداند.

زمانی که یک رزولوشن هدف استاندارد کافی است، از مقدار پیش‌تعریف‌شده [PicturesCompression](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturescompression/) استفاده کنید:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

به‌جای مقدار پیش‌تعریف‌شده می‌توان مقدار DPI مثبت سفارشی را زمانی که هدف خاصی موردنیاز است، ارسال کرد.

فشرده‌سازی برای تصاویر رستر در نظر گرفته شده است. محتوای SVG و متافایل توسط این جریان فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به یاد داشته باشید که رزولوشن پایین‌تر و نواحی قلم‌برداری حذف‌شده قابل بازیابی از ارائه بهینه‌شده نیستند. رزولوشن هدف را بر پایه بزرگ‌ترین اندازه‌ای که تصویر واقعاً مشاهده یا صادر خواهد شد، انتخاب کنید نه اینکه کم‌ترین DPI را به‌صورت سراسری اعمال کنید.

## **بازرسی اثرات تصویر**

افکت‌های تصویر بر روی تصویری که توسط قاب استفاده می‌شود ذخیره می‌شوند. مجموعه تبدیل تصویر می‌تواند افکت‌هایی مانند مدولاسیون آلفای ثابت برای شفافیت و روشنایی برای تنظیم روشنایی و کنتراست داشته باشد. مثال زیر به‌صورت ایمن هر دو نوع افکت را از اولین قاب تصویر روی یک اسلاید می‌خواند:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
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
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

این افکت‌ها نحوه رندر تصویر در قاب را تغییر می‌دهند؛ بایت‌های تصویر تعبیه‌شده اصلی را بازنویسی نمی‌کنند.

## **قفل کردن هندسه قاب تصویر**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframelock/) کنترل می‌کنند که کدام عملیات ویرایشی برای یک قاب تصویر غیرفعال باشد. به عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) نسبت عرض به ارتفاع شکل را هنگام تغییر اندازه حفظ می‌کند.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

قفل بر روی شکل قاب تصویر اعمال می‌شود. این به‌معنای آن نیست که تصویر منبع باید دوباره‌نمونه‌گیری یا به‌صورت دائمی به همان نسبت عرض به ارتفاع تغییر یابد.

## **تنظیم مقادیر StretchOffset**

هنگامی که حالت پر کردن تصویر «stretch» باشد، مقادیر stretch‑offset در [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) مستطیل پر را نسبت به جعبه محدودهٔ قاب تصویر تعریف می‌کنند. درصدهای مثبت یک توریب از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک بیرون‌زدن ایجاد می‌کند.

این متفاوت از قلم‌برداری است. مقادیر قلم‌برداری تعیین می‌کنند کدام بخش از تصویر منبع قابل مشاهده است؛ offsetهای کشی مستطیلی را تغییر می‌دهند که تصویر قابل مشاهده داخل آن کشیده می‌شود.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

از offsetهای کشی برای جای‌گذاری پر استفاده کنید. هنگامی که هدف مخفی کردن لبه‌های تصویر منبع است، از خصوصیات قلم‌برداری استفاده کنید.

## **نگهداری، حجم فایل و ملاحظات صادرات**

تجارت‌های اصلی زمانی راحت‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و فرمت‌بندی قاب‑تصویر جداگانه در نظر گرفته شوند:

- **تصاویر تعبیه‌شده** ارائه را خود‑کافی می‌کنند و برای اشتراک‌گذاری و رندر سمت سرور قابل اعتمادترین گزینه هستند، اما تصاویر رستر بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر لینک‌دار** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی وابسته می‌شود که باید در مسیرهای ذخیره‌شده یا مکان‌ها در دسترس بمانند.
- **قلم‌برداری** در ابتدا غیر مخرب است. پیکسل‌های مخفی تا زمانی که نواحی قلم‌برداری به‌صورت صریح حذف یا در طول فشرده‌سازی حذف نشوند، همچنان تعبیه می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستر بزرگ به‌طور قابل توجهی کاهش دهد، اما وضوح منبع را فدا می‌کند. باید پس از دانستن اندازه نهایی تصویر روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌صورت SVG باقی بمانند وقتی حفظ بردار مهم است. هنگامی که به خود منبع برداری نیاز دارید، SVG تعبیه‌شده را مستقیماً استخراج کنید. صادرات اسلاید رستری همواره اسلاید رندرشده را به پیکسل تبدیل می‌کند.
- **تصاویر تکراری** باید در صورت امکان از منبع [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) موجود استفاده شوند نه اینکه فایل یکسان را به‌صورت مکرر به جریان کاری ارائه بارگذاری کنند.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتویات برداری حفظ کنید، عکس‌ها را بر اساس اندازه نمایش واقعی فشرده کنید، پیکسل‌های قلم‌برداری را فقط زمانی حذف کنید که ویرایش‌های بعدی موردنیاز نباشند و از لینک‌های خارجی صرف‌نظر کنید مگر اینکه مدیریت وابستگی بخشی از طراحی استقرار باشد.

## **سوالات متداول**

**تفاوت بین قاب تصویر و منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) نمایانگر منبع تصویر مرتبط با ارائه است. یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) شکلی روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و فرمت‌بندی سطح‑قاب مانند اندازه، چرخش، مقادیر قلم‌برداری، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**کدامیک را باید تعبیه یا لینک کنم؟**

وقتی ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، تصاویر را تعبیه کنید. تصاویر را فقط زمانی لینک کنید که نگهداری فایل‌های تصویری خارج از PPTX عمدی باشد و مکان‌های خارجی به‌صورت قابل اطمینان مدیریت شوند.

**آیا قلم‌برداری حجم فایل PPTX را کاهش می‌دهد؟**

خود قلم‌برداری این کار را انجام نمی‌دهد. تنظیمات قلم‌برداری معمولی قسمت‌های تصویر منبع را مخفی می‌کند اما پیکسل‌های پشت آن را نگه می‌دارد. برای حذف دائمی پیکسل‌ها می‌توانید از [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) یا فشرده‌سازی تصویر با حذف نواحی قلم‌برداری استفاده کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

نه. فشرده‌سازی می‌تواند رزولوشن رستر ذخیره‌شده را کاهش دهد و حذف نواحی قلم‌برداری داده‌های تصویر را از بین می‌برد. اگر احتمال ویرایش با وضوح بالا پس از آن وجود داشته باشد، تصویر اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG رفتار کرد؟**

وقتی دقت برداری مهم است، محتوا را به‌عنوان SVG نگه دارید. می‌توانید [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) تعبیه‌شده را مستقیماً استخراج کنید. رندر اسلاید به فرمت رستری مانند PNG یا JPEG SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از castهای ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای خاص قاب تصویر، نوع شکل را بررسی کنید. یک چک `java_instanceof` در برابر [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) از castهای نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی را که قاب تصویر ندارند، به‌درستی مدیریت کند.