---
title: ایجاد تصویرهای بندانگشتی از اشکال ارائه در PHP
linktitle: تصویرهای بندانگشتی شکل
type: docs
weight: 70
url: /fa/php-java/create-shape-thumbnails/
keywords:
- تصویر بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد تصویرهای بندانگشتی با کیفیت بالا از اشکال اسلایدهای PowerPoint با Aspose.Slides برای PHP از طریق Java – به‌راحتی تصویرهای بندانگشتی ارائه را ایجاد و صادر کنید."
---
## **مقدمه**

Aspose.Slides برای ایجاد فایل‌های ارائه استفاده می‌شود که هر صفحه‌ای یک اسلاید است. این اسلایدها می‌توانند با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده شوند. اما گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند تصاویر اشکال را به‌صورت جداگانه در یک مشاهده‌گر تصویر ببینند. در چنین مواردی، Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی از اشکال اسلاید ایجاد کنید. نحوه استفاده از این ویژگی در این مقاله توضیح داده شده است.

این مقاله توضیح می‌دهد که چگونه می‌توانید تصاویر بندانگشتی اسلاید را به روش‌های مختلف تولید کنید:

- تولید یک تصویر بندانگشتی شکل داخل یک اسلاید.
- تولید یک تصویر بندانگشتی شکل برای یک شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید یک تصویر بندانگشتی شکل در مرزهای ظاهر یک شکل.

## **تولید تصویر بندانگشتی شکل از یک اسلاید**
برای تولید تصویر بندانگشتی شکل از هر اسلاید با استفاده از Aspose.Slides برای PHP از طریق Java، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلایدی را با استفاده از شناسه یا اندیس آن دریافت کنید.
1. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage) با مقیاس پیش‌فرض از اسلاید مرجع.
1. تصویر بندانگشتی را در قالب تصویر مورد نظرتان ذخیره کنید.

```php
  # یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است را ایجاد کنید
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # یک تصویر با مقیاس کامل ایجاد کنید
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # تصویر را در قالب PNG بر روی دیسک ذخیره کنید
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تولید تصویر بندانگشتی با فاکتور مقیاس‌گذاری تعریف‌شده توسط کاربر**
برای تولید تصویر بندانگشتی شکل یک اسلاید با استفاده از Aspose.Slides برای PHP از طریق Java، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلایدی را با استفاده از شناسه یا اندیس آن دریافت کنید.
1. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage) با ابعاد تعریف‌شده توسط کاربر.
1. تصویر بندانگشتی را در قالب تصویر مورد نظرتان ذخیره کنید.

```php
  # یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است را ایجاد کنید
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # یک تصویر با مقیاس کامل ایجاد کنید
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # تصویر را در قالب PNG بر روی دیسک ذخیره کنید
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ایجاد تصویر بندانگشتی ظاهر شکل بر پایه مرزها**
این روش ایجاد تصاویر بندانگشتی اشکال به توسعه‌دهندگان امکان می‌دهد تا تصویری بندانگشتی در مرزهای ظاهر شکل ایجاد کنند. این روش تمام اثرات شکل را در نظر می‌گیرد. تصویر بندانگشتی شکل ایجاد شده توسط مرزهای اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی یک شکل اسلاید در مرز ظاهر آن، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلایدی را با استفاده از شناسه یا اندیس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با مرزهای شکل به عنوان ظاهر دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویر مورد نظرتان ذخیره کنید.

```php
  # یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است را ایجاد کنید
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # یک تصویر با مقیاس کامل ایجاد کنید
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # تصویر را در قالب PNG بر روی دیسک ذخیره کنید
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**چه فرمت‌های تصویری می‌توان هنگام ذخیره‌سازی تصاویر بندانگشتی شکل استفاده کرد؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imageformat/)، و سایر فرمت‌ها. اشکال همچنین می‌توانند با ذخیره محتویات شکل به‌صورت SVG، [به‌صورت SVG برداری صادر شوند](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/writeassvg/).

**تفاوت بین مرزهای Shape و Appearance هنگام رندر تصویر بندانگشتی چیست؟**

`Shape` از هندسه شکل استفاده می‌کند؛ `Appearance` اثرات بصری [اثرات بصری](/slides/fa/php-java/shape-effect/) (سایه‌ها، تابش‌ها و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا همچنان به‌صورت تصویر بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان جزو مدل می‌ماند و می‌تواند رندر شود؛ فلگ مخفی فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد اما از ایجاد تصویر شکل جلوگیری نمی‌کند.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌عنوان [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) نمایش داده می‌شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/) و [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/)) می‌تواند به‌صورت تصویر بندانگشتی یا SVG ذخیره شود.

**آیا فونت‌های نصب‌شده در سیستم بر کیفیت تصاویر بندانگشتی اشکال متنی تأثیر می‌گذارند؟**

بله. شما باید [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/php-java/custom-font/) (یا [جایگزینی فونت‌ها را پیکربندی کنید](/slides/fa/php-java/font-substitution/)) تا از بازگشت ناخواسته و تغییر قالب متن جلوگیری شود.