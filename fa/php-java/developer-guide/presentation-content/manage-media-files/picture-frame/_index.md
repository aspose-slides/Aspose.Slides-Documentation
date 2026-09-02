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
- تصویر جاسازی‌شده
- تصویر لینک‌شده
- استخراج تصویر
- تصویر رستر
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قاب تصویر قالب‌بندی
- مقیاس نسبی
- افکت تصویر
- نسبت ابعاد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قاب‌های تصویر را در ارائه‌ها ایجاد، قالب‌بندی، لینک، برش، استخراج و فشرده کنید با Aspose.Slides برای PHP از طریق Java."
---
## **نمای کلی**

قاب تصویر (Picture Frame) یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد به صورت اشیاء جداگانه هستند: یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) از طریق [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) خود، منابع تصویر جاسازی شده را مالک می‌شود، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) موقعیت، اندازه، فرمت خط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی زمانی مفید است که یک تصویر بیش از یک بار نمایش داده شود. تصویر را یک بار به ارائه اضافه کنید، شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) بازگشتی را نگه دارید و هنگام ایجاد قاب‌های تصویر از آن منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند شامل تصاویر رستر مانند PNG یا JPEG و تصاویر SVG برداری باشند. همچنین می‌توانند به تصاویر لینک‌شده اشاره کنند به جای ذخیره بایت‌های تصویر در ارائه. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین مفید است پیش از اعمال فرمت‌بندی یا بهینه‌سازی تصمیم بگیرید که تصویر چگونه ذخیره شود.

## **افزودن و فرمت‌بندی یک تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و با [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addpictureframe/) یک قاب تصویر ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین ارائه هنگام انتقال به کامپیوتر دیگری خودکفا می‌ماند.

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

قاب تصویر هندسهٔ نمایش داده شده را کنترل می‌کند؛ تغییر اندازهٔ قاب ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییر نمی‌دهد. این تمایز زمانی مهم می‌شود که بعداً بخواهید تصویر را برش یا فشرده کنید.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) مقیاس عرض و ارتفاع نسبی برای قاب را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/setrelativescalewidth/) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/setrelativescaleheight/) افشا می‌کند. مقدار `1.0` معادل 100٪ اندازهٔ اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز به حفظ رابطهٔ اندازهٔ تصویر منبع داشته باشد نه اینکه ابعاد نهایی را به‌صورت دستی محاسبه کند.

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

مقیاس نسبی تنظیمات مقیاس‌بندی قاب را تغییر می‌دهد؛ تصویر جاسازی‌شده را دوباره‌نمونه‌برداری یا فشرده نمی‌کند.

## **تصاویر جاسازی‌شده و لینک‌شده**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین ایمن‌ترین انتخاب برای قابلیت حمل و رندر پیش‌بینی‌پذیر است. یک تصویر لینک‌شده مسیر خارجی را از طریق متد [Picture::setLinkPathLong](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picture/setlinkpathlong/) ذخیره می‌کند به جای جاسازی داده‌های تصویر به همان شکل.

تصاویر لینک‌شده می‌توانند مقدار دادهٔ تصویر ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل لینک‌شده باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس بماند. اگر مسیر تغییر کند، فایل جابه‌جا شود یا منبع در دسترس نباشد، تصویر لینک‌شده ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اعتمادتر هستند.

### **افزودن یک تصویر لینک‌شده**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی ارجاع می‌دهد. این مثال فقط به لینک‌گذاری تصویر می‌پردازد؛ لینک‌گذاری ویدیو یک جریان کاری رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

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

از لینک‌ها زمانی استفاده کنید که مدیریت فایل‌های خارجی به‌صورت عمدی باشد. از آن‌ها صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های شکسته معمولاً کمتر مفید است نسبت به یک ارائهٔ بزرگتر و خودکفا.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج یک تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) است و حاوی تصویر جاسازی‌شده می‌باشد. قاب‌های تصویر لینک‌شده ممکن است بایت‌های تصویری که به همان شکل قابل استخراج هستند، نداشته باشند.

### **استخراج یک تصویر رستر**

API مدرن تصویر از [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) به‌صورت مستقیم استفاده می‌کند. مثال زیر اولین تصویر رستر جاسازی‌شده را در یک اسلاید پیدا می‌کند و به‌صورت PNG ذخیره می‌نماید:

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

ذخیره از طریق [IImage::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/#save) تصویر استخراج‌شده را به فرمت خروجی درخواستی تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده‌ای که در ارائه ذخیره شده‌اند به‌جای یک فایل رستر تبدیل‌شده نیاز دارید، به جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) یک شیء [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) را افشا می‌کند. این به شما امکان می‌دهد داده‌های SVG را به‌صورت مستقیم دریافت کنید به‌جای اینکه ابتدا تصویر را رستر کنید.

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

نگه داشتن محتوای SVG به‌صورت SVG، منبع برداری را داخل ارائه حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG مجبور به رندر کردن آن محتوای برداری به پیکسل هستند. خروجی اسلاید به PDF یا SVG نیز عملیاتی رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان یک کپی بایت‌به‌بایت از SVG جاسازی‌شده اصلی در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از دادهٔ [SvgImage::getSvgData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/getsvgdata/) استفاده کنید.

## **برش یک تصویر**

برش تعیین می‌کند کدام بخش از تصویر داخل قاب قابل مشاهده است. مقادیر برش در [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش به‌طور اولیه پیکسل‌های مخفی را از تصویر جاسازی‌شده حذف نمی‌کند؛ فقط ناحیهٔ قابل مشاهده را تغییر می‌دهد.

مثال زیر یک قاب تصویر را به‌صورت ایمن پیدا می‌کند و مقادیر برش را اعمال می‌نماید:

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

از آنجا که داده‌های تصویر مخفی هنوز حضور دارند، می‌توان برش را در آینده بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگشت باشد، می‌توان نواحی برش‌خورده را همان‌طور که در بخش بعدی توضیح داده شده فیزیکاً حذف کرد.

## **حذف داده‌های تصویر برش‌خورده**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) داده‌های تصویری خارج از مستطیل برش فعلی را حذف می‌کند و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیرهٔ ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات «باز‑برش» در دسترس نیستند.

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

این متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط دیگر قاب‌های تصویر نیز استفاده شود، آن قاب‌ها هنوز به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتوای WMF یا EMF با این روش نتیجهٔ برش‌خورده را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستر**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. متد زمانی که تصویر تغییر اندازه یا برش یافت `true` و در غیر این صورت `false` باز می‌گرداند.

زمانی که یک وضوح هدف استاندارد کافی باشد، از مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturescompression/) استفاده کنید:

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

در صورت نیاز به هدف خاصی می‌توان مقدار DPI مثبت سفارشی را به جای مقدار پیش‌تعریف‌شده پاس داد.

فشرده‌سازی برای تصاویر رستر منظور شده است. محتوای SVG و متافایل توسط این جریان کاری فشرده‌سازی رستر کاهش نمی‌یابد. همچنین به‌خاطر داشته باشید که وضوح پایین‌تر و نواحی برش‌خورده حذف‌شده را نمی‌توان از ارائهٔ بهینه‌شده بازیابی کرد. هدف وضوح را بر پایهٔ بزرگ‌ترین اندازه‌ای که تصویر در آن واقعاً مشاهده یا خروجی می‌شود، انتخاب کنید نه اینکه DPI پایین‌ترین مقدار را به‌صورت سراسری اعمال کنید.

## **مدیریت افکت‌های تبدیل تصویر**

برای یک جریان کاری کامل شامل روشنایی، کنتراست، تبدیل رنگ، تاری، افکت‌های آلفا، زنجیره‌های مرتب‌شده، بازرسی، حذف و تأیید دورانی، به [Image Transform Effects](/slides/fa/php-java/image-transform-effects/) مراجعه کنید.

## **قفل‌کردن هندسهٔ قاب تصویر**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframelock/) مشخص می‌کند کدام عملیات‌های ویرایشی برای یک قاب تصویر غیرفعال هستند. به عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) نسبت ابعاد شکل را هنگام تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل قاب تصویر اعمال می‌شود. این امر تصویر منبع را مجبور به نمونه‌برداری یا تغییر دائم نسبت ابعاد نمی‌کند.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پر کردن تصویر «stretch» باشد، مقادیر stretch‑offset در [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) مستطیل پر کردن را نسبت به جعبهٔ محصور قاب تصویر تعریف می‌کند. درصدهای مثبت یک تورفتگی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک خروجی ایجاد می‌کنند.

این متفاوت از برش است. مقادیر برش تعیین می‌کنند کدام بخش از تصویر منبع قابل مشاهده است؛ stretch‑offset ها مستطیلی که پر کردن تصویر قابل مشاهده در آن کشیده می‌شود را تغییر می‌دهند.

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

از stretch‑offset برای جایگذاری پر کردن استفاده کنید. وقتی هدف مخفی کردن لبه‌های تصویر منبع باشد، از ویژگی‌های برش استفاده کنید.

## **نگهداری، حجم فایل و ملاحظات خروجی**

معامله‌های اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیرهٔ تصویر و فرمت‌بندی قاب‑تصویر به‌صورت جداگانه رفتار شوند:

- **تصاویر جاسازی‌شده** ارائه را خودکفا می‌سازند و برای به‌اشتراک‌گذاری و رندر سمت سرور قابل اطمینانترین گزینه هستند، اما تصاویر رستر بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر لینک‌شده** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده یا مکان‌های مشخص وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی برش‌شده صراحتاً حذف یا در طول فشرده‌سازی حذف نشوند، جاسازی می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستر بیش‌حجم به‌طور قابل توجهی کاهش دهد، اما وضوح منبع را از بین می‌برد. این کار باید پس از تعیین اندازهٔ نهایی تصویر روی اسلاید انجام شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند هنگامی که حفظ بردار مهم است. SVG جاسازی‌شده را به‌صورت مستقیم استخراج کنید وقتی به منبع برداری خود نیاز دارید. خروجی‌های اسلاید رستری همیشه اسلاید رندر شده را به پیکسل تبدیل می‌کند.
- **تصاویر تکراری** باید در صورت امکان از یک منبع [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) موجود استفاده کنند نه اینکه فایل یکسان را بارها به جریان کاری ارائه بارگذاری کنند.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولا زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتوی برداری نگه دارید، عکس‌ها را بر اساس اندازهٔ واقعی نمایششان فشرده کنید، پیکسل‌های برش‌خورده را فقط زمانی حذف کنید که ویرایش‌های بعدی لازم نباشد و از لینک‌های خارجی تنها زمانی استفاده کنید که مدیریت وابستگی بخشی از طراحی استقرار باشد.

## **ســوالات متداول**

**تفاوت بین قاب تصویر و منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) نمایانگر یک منبع تصویر مرتبط با ارائه است. یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) شکلی روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و فرمت‌بندی سطح قاب مانند اندازه، چرخش، مقادیر برش، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**کدامیک را باید جاسازی یا لینک کنم؟**

تصاویر را هنگامی که ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، جاسازی کنید. تصاویر را فقط هنگامی لینک کنید که نگهداری فایل‌های تصویر خارج از PPTX عمدی باشد و مکان‌های خارجی به‌صورت قابل اطمینان مدیریت شوند.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را انجام نمی‌دهد. تنظیمات برش عادی قسمت‌هایی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای کاهش حجم باید از [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) یا فشرده‌سازی تصویر با حذف نواحی برش‌شده استفاده کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

نه. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش‌شده دادهٔ تصویر را از بین می‌برد. اگر بعداً به ویرایش با وضوح بالا نیاز دارید، تصویر اصلی را خارج از ارائه نگه دارید.

**تصاویر SVG چگونه باید مدیریت شوند؟**

محتوای SVG را به‌عنوان SVG نگه دارید وقتی که دقت برداری مهم است. می‌توان [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) جاسازی‌شده را به‌صورت مستقیم استخراج کرد. رندر یک اسلاید به فرمت رستری مانند PNG یا JPEG، SVG را به بخشی از تصویر اسلاید رستر می‌کند.

**چگونه می‌توان از castهای ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای مخصوص قاب تصویر، نوع شکل را بررسی کنید. یک بررسی `java_instanceof` در برابر [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) از castهای نامعتبر جلوگیری می‌کند و اجازه می‌دهد کد اسلایدهایی را که حاوی قاب تصویر نیستند به‌درستی پردازش کند.