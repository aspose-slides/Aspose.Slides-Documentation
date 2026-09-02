---
title: مدیریت قاب‌های تصویر در ارائه‌ها با استفاده از PHP
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/php-java/picture-frame/
keywords:
- قاب تصویر
- اضافه کردن قاب تصویر
- ایجاد قاب تصویر
- تصویر توکار
- تصویر پیوندی
- استخراج تصویر
- تصویر رستری
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌شده
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
description: "قاب‌های تصویر را در ارائه‌ها ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی کنید با Aspose.Slides برای PHP از طریق جاوا."
---
## **نمای کلی**

قاب تصویر یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد، اشیاء جداگانه‌ای هستند: یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) منابع تصویر توکار را از طریق [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) خود مدیریت می‌کند، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) موقعیت، اندازه، قالب‌بندی خط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیشتر از یک بار نمایش داده شود. تصویر را یک بار به ارائه اضافه کنید، [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) بازگشتی را نگه دارید و هنگام ایجاد قاب‌های تصویر از همان منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند شامل تصاویر رستری مانند PNG یا JPEG و تصاویر وکتوری SVG باشند. همچنین می‌توانند به تصاویر پیوندی اشاره کنند به جای ذخیره بایت‌های تصویر در ارائه. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار صادرات تأثیر می‌گذارد، بنابراین قبل از اعمال قالب‌بندی یا بهینه‌سازی، تصمیم‌گیری درباره روش ذخیره‌سازی تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر توکار**

برای یک تصویر توکار، داده‌های تصویر را به ارائه اضافه کنید و با استفاده از [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addpictureframe/) یک قاب تصویر ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین وقتی ارائه به کامپیوتر دیگری منتقل می‌شود، خودکفا می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، یک قاب با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خط و چرخش را اعمال می‌‌نماید:

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

قاب تصویر هندسه نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازهٔ قاب تصویر ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر توکار را تغییر نمی‌دهد. این تمایز زمانی مهم می‌شود که بعداً بخواهید تصویر را برش یا فشرده کنید.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) مقیاس عرض و ارتفاع نسبی را برای قاب از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/setrelativescalewidth/) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/setrelativescaleheight/) افشا می‌کند. مقدار `1.0` معادل 100٪ اندازهٔ اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک گردش کار نیاز داشته باشد نسبت به اندازهٔ منبع تصویر حفظ شود به جای محاسبهٔ دستی ابعاد نهایی.

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

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ تصویر توکار را بازنمونه‌گیری یا فشرده نمی‌کند.

## **تصاویر توکار و پیوندی**

یک تصویر توکار داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین ایمن‌ترین گزینه برای قابلیت حمل و رندر پیش‌بینی‌شدنی است. یک تصویر پیوندی مکان بیرونی را از طریق متد [Picture::setLinkPathLong](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picture/setlinkpathlong/) ذخیره می‌کند به جای اینکه داده‌های تصویر را به همان شکل توکار کند.

تصاویر پیوندی می‌توانند حجم دادهٔ تصویر ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند، در دسترس بماند. اگر مسیر تغییر کند، فایل جابجا شود یا منبع در دسترس نباشد، ممکن است تصویر پیوندی همان‌طور که انتظار می‌رود نشان داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر توکار معمولاً قابل اطمینان‌تر هستند.

### **افزودن یک تصویر پیوندی**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به پیوند تصویر می‌پردازد؛ پیوند ویدیو یک گردش کار رسانه‌ای جداگانه است و عمدتاً در این مثال ترکیب نشده است.

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

از پیوندها وقتی مدیریت فایل‌های بیرونی عمدی باشد استفاده کنید. از آن‌ها صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر خراب معمولاً کمتر مفید است نسبت به یک ارائهٔ خودکفا و بزرگ‌تر.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج یک تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) باشد و حاوی تصویر توکار باشد. قاب‌های تصویر پیوندی ممکن است بایت‌های تصویری که به همان شکل قابل استخراج هستند، نداشته باشند.

### **استخراج یک تصویر رستری**

API مدرن تصویر از [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) به‌طور مستقیم استفاده می‌کند. مثال زیر اولین تصویر رستری توکار موجود در یک اسلاید را یافته و به صورت PNG ذخیره می‌کند:

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

ذخیره‌سازی از طریق [IImage::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/#save) تصویر استخراج‌شده را به فرمت خروجی درخواستی تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شدهٔ ذخیره‌شده در ارائه نیاز دارید نه به یک فایل رستری تبدیل‌شده، به جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) یک شیء [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) را افشا می‌کند. این امکان را می‌دهد که دادهٔ SVG را به‌صورت مستقیم بازیابی کنید به‌جای آنکه ابتدا تصویر را رستری کنید.

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

نگه داشتن محتوای SVG به صورت SVG، منبع وکتوری داخل ارائه را حفظ می‌کند. صادرات رستری مانند PNG یا JPEG لزوماً آن محتوای وکتور را به پیکسل تبدیل می‌کند. صادرات اسلاید به PDF یا SVG نیز عملیاتی رندر است، بنابراین گرافیک‌های صادرشده نباید به‌عنوان یک کپی بایت به بایت از SVG توکار اصلی در نظر گرفته شوند؛ در صورتی که منبع وکتور اصلی مورد نیاز باشد، از دادهٔ [SvgImage::getSvgData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/getsvgdata/) توکار استفاده کنید.

## **برش یک تصویر**

برش بخشی از تصویر را که داخل قاب قابل مشاهده است تغییر می‌دهد. مقادیر برش در [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) به‌صورت درصدی از ابعاد تصویر منبع بیان می‌شوند. برش در ابتدا پیکسل‌های مخفی را از تصویر توکار حذف نمی‌کند؛ فقط ناحیهٔ قابل مشاهده را تغییر می‌دهد.

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

از آنجا که دادهٔ تصویر مخفی هنوز حاضر است، می‌توان برش را بعدها بدون از دست رفتن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگردانی باشد، می‌توان مناطق برش را همان‌طور که در بخش بعدی توضیح داده شده فیزیکی حذف کرد.

## **حذف داده‌های تصویر برش‌خورده**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) داده‌های تصویری خارج از مستطیل برش فعلی را حذف کرده و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیره ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات باز‑برش در دسترس نیستند.

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

این متد ممکن است منبع تصویر جدیدی به ارائه اضافه کند. اگر تصویر اصلی توسط قاب‌های تصویر دیگر نیز استفاده شده باشد، آن قاب‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتوای WMF یا EMF با این متد نتیجهٔ برش‌شده را به PNG رستری می‌کند.

## **فشرده‌سازی تصاویر رستری**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) وضوح تصویر رستری را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود، کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. این متد وقتی تصویر تغییر اندازه یا برش داده شد `true` و وقتی نیازی به تغییر نبود `false` برمی‌گرداند.

هنگامی که رزولوشن هدف استاندارد کافی باشد، می‌توانید از مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturescompression/) استفاده کنید:

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

به‌جای مقدار پیش‌تعریف‌شده می‌توان یک مقدار DPI مثبت سفارشی را پاس کرد وقتی هدف خاصی مورد نیاز است.

فشرده‌سازی برای تصاویر رستری در نظر گرفته شده است. محتوای SVG و متافایل توسط این کاریاری فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به یاد داشته باشید که رزولوشن پایین‌تر و نواحی برش‌خورده حذف‌شده نمی‌توانند از ارائهٔ بهینه‌شده بازیابی شوند. هدف رزولوشن را بر اساس بزرگ‌ترین اندازه‌ای که تصویر در واقع مشاهده یا صادر خواهد شد، انتخاب کنید نه اینکه به‌صورت سراسری کمترین DPI را اعمال کنید.

## **مدیریت اثرات تبدیل تصویر**

برای یک گردش کار کامل شامل روشنایی، کنتراست، تبدیل رنگ، تار شدن، اثرات آلفا، زنجیره‌های مرتب‌شده، بررسی، حذف و تأیید دور‌به‑دور، به [Image Transform Effects](/php-java/image-transform-effects/) مراجعه کنید.

## **قفل کردن هندسهٔ قاب تصویر**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframelock/) تعیین می‌کند که کدام عملیات‌های ویرایشی برای یک قاب تصویر غیرفعال باشند. به‌عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) نسبت ابعاد شکل را هنگام مقیاس‌دهی حفظ می‌کند.

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

قفل بر روی شکل قاب تصویر اعمال می‌شود. این مجبور به این نیست که تصویر منبع بازنمونه‌گیری یا به‌صورت دائمی به همان نسبت ابعاد تغییر کند.

## **تنظیم مقادیر StretchOffset**

هنگامی که حالت پر شدن تصویر stretch است، مقادیر stretch‑offset در [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) مستطیل پر شدن را نسبت به کادر محصور کنندهٔ قاب تصویر تعریف می‌کند. درصدهای مثبت حاشیه‌ای از لبه ایجاد می‌کند، در حالی که درصدهای منفی پیشرویی ایجاد می‌کند.

این متفاوت از برش است. مقادیر برش تعیین می‌کند کدام بخش از تصویر منبع قابل مشاهده است؛ مقادیر stretch‑offset مستطیلی را تغییر می‌دهند که پر شدن تصویر درون آن کشیده می‌شود.

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

از stretch‑offset برای موقعیت‌یابی پر شدن استفاده کنید. از ویژگی‌های برش زمانی استفاده کنید که هدف پنهان کردن لبه‌های تصویر منبع باشد.

## **نگهداری، حجم فایل و ملاحظات صادرات**

معامله‌های اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی قاب‑تصویر جداگانه در نظر گرفته شوند:

- **تصاویر توکار** ارائه را خودکفا می‌سازند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستری بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده یا مکان‌ها وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی برش‌شده صراحتاً حذف یا در طول فشرده‌سازی حذف نشوند، توکار می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستری بزرگ به‌طور چشمگیری کاهش دهد، اما رزولوشن منبع را از میان می‌برد. بهتر است پس از دانستن اندازهٔ نهایی تصویر بر روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌صورت SVG باقی بمانند وقتی حفظ ویژگی وکتور مهم است. هنگام نیاز به خود منبع وکتور، SVG توکار را مستقیماً استخراج کنید. صادرات اسلاید رستری همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کند.
- **تصاویر تکراری** باید در صورت امکان از یک منبع [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) موجود استفاده کنند به جای بارگذاری مکرر همان فایل در جریان کاری ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و دیاگرام‌ها را به‌عنوان محتوای وکتور نگه دارید، عکس‌ها را بر اساس اندازهٔ واقعی نمایش آنها فشرده کنید، پیکسل‌های برش‌خورده را فقط زمانی حذف کنید که ویرایش بعدی لازم نباشد و از پیوندهای خارجی تا زمانی که مدیریت وابستگی بخشی از طراحی استقرار باشد، اجتناب کنید.

## **FAQ**

**تفاوت بین قاب تصویر و منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) نمایانگر منبع تصویری است که با ارائه مرتبط است. یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) شکل روی اسلایدی است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح قاب مانند اندازه، چرخش، مقادیر برش، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را توکار یا پیوندی کنم؟**

وقتی ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع بیرونی رندر شود، تصاویر را توکار کنید. فقط وقتی نگه‌داشتن فایل‌های تصویر خارج از PPTX هدفمند است و مکان‌های بیرونی می‌توانند به‌صورت قابل اطمینان مدیریت شوند، از پیوند استفاده کنید.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را نمی‌کند. تنظیمات برش عادی بخش‌های تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای حذف دائمی آن پیکسل‌ها می‌توانید از [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) یا فشرده‌سازی تصویر با حذف نواحی برش‌شده استفاده کنید.

**آیا می‌توان بعد از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

نه. فشرده‌سازی می‌تواند وضوح رستری ذخیره‌شده را کاهش دهد و حذف نواحی برش‌شده داده‌های تصویر را از بین می‌برد. اگر بعداً به ویرایش با وضوح بالا نیاز دارید، تصویر اصلی را خارج از ارائه نگهداری کنید.

**چگونه باید با تصاویر SVG رفتار کرد؟**

هنگامی که حفظ دقت وکتور مهم است، محتویات SVG را به‌صورت SVG نگه دارید. می‌توانید از [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) توکار به‌صورت مستقیم استخراج کنید. رندر اسلاید به فرمت رستری مانند PNG یا JPEG، SVG را به بخشی از تصویر اسلاید تبدیل می‌کند.

**چگونه می‌توان از cast نا‌ایمن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای خاص قاب تصویر، نوع شکل را بررسی کنید. یک بررسی `java_instanceof` در برابر [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) از castهای نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که شامل قاب تصویر نیستند را به‌صورت مناسب مدیریت کند.