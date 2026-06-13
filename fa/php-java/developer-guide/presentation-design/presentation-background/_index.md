---
title: مدیریت پس‌زمینه‌های ارائه در PHP
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/php-java/presentation-background/
keywords:
- پس‌زمینه ارائه
- پس‌زمینه اسلاید
- رنگ ثابت
- رنگ گرادیان
- پس‌زمینه تصویر
- شفافیت پس‌زمینه
- ویژگی‌های پس‌زمینه
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه پس‌زمینه‌های پویا را در فایل‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java تنظیم کنید، همراه با نکات کدنویسی برای ارتقای ارائه‌های خود."
---
## **مقدمه**

رنگ‌های ثابت، گرادیان‌ها و تصاویر معمولاً برای پس‌زمینه اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه را برای یک **اسلاید عادی** (یک اسلاید تک) یا یک **اسلاید مستر** (که برای چندین اسلاید به‌طور همزمان اعمال می‌شود) تنظیم کنید.

![پس‌زمینه PowerPoint](powerpoint-background.png)

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید عادی**

Aspose.Slides به شما اجازه می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینه اسلاید خاصی در یک ارائه تنظیم کنید — حتی اگر ارائه از اسلاید مستر استفاده کند. این تغییر فقط به اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. مقدار BackgroundType اسلاید را به `OwnBackground` تنظیم کنید.
3. مقدار FillType پس‌زمینه اسلاید را به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/#getSolidFillColor) در [FillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) برای تعیین رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائه تغییر یافته را ذخیره کنید.

مثال PHP زیر نشان می‌دهد چگونه یک رنگ ثابت آبی را به‌عنوان پس‌زمینه اسلاید عادی تنظیم کنید:

```php
// یک نمونه از کلاس Presentation ایجاد کنید.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // رنگ پس‌زمینه اسلاید را به آبی تنظیم کنید.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // ارائه را روی دیسک ذخیره کنید.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید مستر**

Aspose.Slides به شما اجازه می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینه اسلاید مستر در یک ارائه تنظیم کنید. اسلاید مستر به‌عنوان قالبی عمل می‌کند که قالب‌بندی تمام اسلایدها را کنترل می‌کند، بنابراین وقتی یک رنگ ثابت را برای پس‌زمینه اسلاید مستر انتخاب می‌کنید، برای هر اسلاید اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. مقدار BackgroundType اسلاید مستر (از طریق `getMasters`) را به `OwnBackground` تنظیم کنید.
3. مقدار FillType پس‌زمینه اسلاید مستر را به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/#getSolidFillColor) برای تعیین رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائه تغییر یافته را ذخیره کنید.

مثال PHP زیر نشان می‌دهد چگونه یک رنگ ثابت (سبز) را به‌عنوان پس‌زمینه اسلاید مستر تنظیم کنید:

```php
// یک نمونه از کلاس Presentation ایجاد کنید.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // رنگ پس‌زمینه اسلاید مستر را به سبز جنگلی تنظیم کنید.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // ارائه را روی دیسک ذخیره کنید.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم پس‌زمینه گرادیان برای اسلاید**

گرادیان یک اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. هنگامی که به‌عنوان پس‌زمینه اسلاید استفاده می‌شود، می‌تواند ارائه‌ها را هنری‌تر و حرفه‌ای‌تر نشان دهد. Aspose.Slides به شما اجازه می‌دهد یک رنگ گرادیان را به‌عنوان پس‌زمینه اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. مقدار BackgroundType اسلاید را به `OwnBackground` تنظیم کنید.
3. مقدار FillType پس‌زمینه اسلاید را به `Gradient` تنظیم کنید.
4. از متد [getGradientFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/#getGradientFormat) در [FillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) برای پیکربندی تنظیمات دلخواه گرادیان استفاده کنید.
5. ارائه تغییر یافته را ذخیره کنید.

مثال PHP زیر نشان می‌دهد چگونه یک رنگ گرادیان را به‌عنوان پس‌زمینه اسلاید تنظیم کنید:

```php
// یک نمونه از کلاس Presentation ایجاد کنید.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // یک افکت گرادیان به پس‌زمینه اعمال کنید.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // ارائه را روی دیسک ذخیره کنید.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تنظیم تصویر به‌عنوان پس‌زمینه اسلاید**

علاوه بر پرکننده‌های ثابت و گرادیان، Aspose.Slides به شما اجازه می‌دهد از تصاویر به‌عنوان پس‌زمینه اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. مقدار BackgroundType اسلاید را به `OwnBackground` تنظیم کنید.
3. مقدار FillType پس‌زمینه اسلاید را به `Picture` تنظیم کنید.
4. تصویر موردنظر برای پس‌زمینه اسلاید را بارگیری کنید.
5. تصویر را به‌مجموعه تصاویر ارائه اضافه کنید.
6. از متد [getPictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/#getPictureFillFormat) در [FillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) برای اختصاص تصویر به‌عنوان پس‌زمینه استفاده کنید.
7. ارائه تغییر یافته را ذخیره کنید.

مثال PHP زیر نشان می‌دهد چگونه یک تصویر را به‌عنوان پس‌زمینه اسلاید تنظیم کنید:

```php
// یک نمونه از کلاس Presentation ایجاد کنید.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // تنظیم ویژگی‌های تصویر پس‌زمینه.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // بارگذاری تصویر.
    $image = Images::fromFile("Tulips.jpg");
    // تصویر را به مجموعه تصاویر ارائه اضافه کنید.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // ارائه را روی دیسک ذخیره کنید.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نمونه کد زیر نشان می‌دهد چگونه نوع پرکننده پس‌زمینه را به تصویر کاشی‌شده تنظیم کرده و ویژگی‌های کاشی را اصلاح کنید:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // تنظیم تصویری که برای پر کردن پس‌زمینه استفاده می‌شود.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // حالت پر کردن تصویر را روی کاشی تنظیم کنید و ویژگی‌های کاشی را تنظیم کنید.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
بیشتر بخوانید: [**کاشی تصویر به عنوان بافت**](/slides/fa/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینه اسلاید را تنظیم کنید تا محتویات اسلاید برجسته‌تر شوند. کد PHP زیر نحوه تغییر شفافیت تصویر پس‌زمینه اسلاید را نشان می‌دهد:

```php
$transparencyValue = 30; // برای مثال.

// Get the collection of picture transform operations.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Find an existing fixed-percentage transparency effect.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Set the new transparency value.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **دریافت مقدار پس‌زمینه اسلاید**

Aspose.Slides کلاس `BackgroundEffectiveData` را برای دریافت مقادیر مؤثر پس‌زمینه اسلاید فراهم می‌کند. این کلاس `FillFormat` و `EffectFormat` مؤثر را در دسترس قرار می‌دهد.

با استفاده از متد `getBackground` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/) می‌توانید پس‌زمینه مؤثر یک اسلاید را به‌دست آورید.

مثال PHP زیر نشان می‌دهد چگونه مقدار پس‌زمینه مؤثر یک اسلاید را دریافت کنید:

```php
// یک نمونه از کلاس Presentation ایجاد کنید.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // دریافت پس‌زمینه مؤثر، با در نظر گرفتن مستر، طرح‌بندی و تم.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم پس‌زمینه سفارشی را بازنشانی کرده و پس‌زمینه تم/طرح‌بندی را بازیابی کنم؟**

بله. پرکننده سفارشی اسلاید را حذف کنید و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/php-java/slide-layout/)/[master](/slides/fa/php-java/slide-master/) مربوطه (یعنی [theme background](/slides/fa/php-java/presentation-theme/)) به ارث برده می‌شود.

**اگر بعدها تم ارائه را تغییر دهم، چه اتفاقی برای پس‌زمینه می‌افتد؟**

اگر اسلاید پرکنندهٔ خود را داشته باشد، آن‌را بدون تغییر می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/php-java/slide-layout/)/[master](/slides/fa/php-java/slide-master/) به ارث برده شده باشد، با تم جدید به‌روزرسانی می‌شود.