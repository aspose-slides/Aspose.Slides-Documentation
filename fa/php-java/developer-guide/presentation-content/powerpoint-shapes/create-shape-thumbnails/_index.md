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
- مرزهای بصری
- مرزهای شکل
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "تصویرهای بندانگشتی با کیفیت بالا از اشکال اسلایدهای PowerPoint را با Aspose.Slides برای PHP از طریق Java ایجاد کنید – به راحتی تصویرهای بندانگشتی ارائه را بسازید و صادر کنید."
---
## **معرفی**

Aspose.Slides برای ایجاد فایل‌های ارائه استفاده می‌شود که هر صفحه‌ای یک اسلاید است. این اسلایدها را می‌توان با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده کرد. اما گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند تصاویر اشکال را به‌صورت جداگانه در یک برنامهٔ نمایش تصویر ببینند. در چنین مواردی، Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی از اشکال اسلاید تولید کنید. نحوهٔ استفاده از این ویژگی در این مقاله توضیح داده شده است.

این مقاله توضیح می‌دهد که چگونه تصاویر بندانگشتی اسلایدها را به روش‌های مختلف تولید کنید:

- تولید تصویر بندانگشتی یک شکل درون یک اسلاید.
- تولید تصویر بندانگشتی یک شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید تصویر بندانگشتی در محدودهٔ ظاهر شکل.

## **تولید تصویر بندانگشتی یک شکل از یک اسلاید**

برای تولید تصویر بندانگشتی یک شکل از هر اسلاید با استفاده از Aspose.Slides برای PHP از طریق Java، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
2. مرجع هر اسلایدی را با استفاده از شناسه یا ایندکس آن به‌دست آورید.
3. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage) اسلاید مرجع با مقیاس پیش‌فرض.
4. تصویر بندانگشتی را در قالب تصویر دلخواه خود ذخیره کنید.

```php
  # یک کلاس Presentation را نمونه‌سازی کنید که فایل ارائه را نشان می‌دهد
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # یک تصویر با مقیاس کامل ایجاد کنید
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # تصویر را در قالب PNG روی دیسک ذخیره کنید
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

## **تولید تصویر بندانگشت​ی با مقیاس کاربر-تعریف‌شده**

برای تولید تصویر بندانگشتی شکل یک اسلاید با استفاده از Aspose.Slides برای PHP از طریق Java، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
2. مرجع هر اسلایدی را با استفاده از شناسه یا ایندکس آن به‌دست آورید.
3. [دریافت تصویر بندانگشتی شکل](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage) اسلاید مرجع با ابعاد تعریف‌شده توسط کاربر.
4. تصویر بندانگشتی را در قالب تصویر دلخواه خود ذخیره کنید.

```php
  # یک کلاس Presentation را نمونه‌سازی کنید که فایل ارائه را نشان می‌دهد
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # یک تصویر با مقیاس کامل ایجاد کنید
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # تصویر را در قالب PNG روی دیسک ذخیره کنید
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

## **ایجاد تصویر بندانگشتی ظاهر شکل بر پایهٔ مرزها**

این روش ایجاد تصاویر بندانگشتی برای اشکال، به توسعه‌دهندگان امکان می‌دهد تا تصویر بندانگشتی‌ای را در محدودهٔ ظاهر شکل تولید کنند. تمام اثرات شکل در نظر گرفته می‌شود. تصویر بندانگشتی تولید شده توسط محدودهٔ اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی یک شکل اسلاید در محدودهٔ ظاهر آن، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
2. مرجع هر اسلایدی را با استفاده از شناسه یا ایندکس آن به‌دست آورید.
3. دریافت تصویر بندانگشتی اسلاید مرجع با مرزهای شکل به‌عنوان ظاهر.
4. تصویر بندانگشتی را در قالب تصویر دلخواه خود ذخیره کنید.

```php
  # یک کلاس Presentation را نمونه‌سازی کنید که فایل ارائه را نشان می‌دهد
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # یک تصویر با مقیاس کامل ایجاد کنید
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # تصویر را در قالب PNG روی دیسک ذخیره کنید
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

## **دریافت مرزهای بصری واقعی یک شکل**

ویژگی‌های قاب [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/)—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()`, and `Shape::getHeight()`—مستطیل ذخیره‌شده در مدل ارائه را توصیف می‌کنند. محتوایی که واقعاً رندر می‌شود می‌تواند فراتر از آن قاب گسترش یابد یا مستطیل محور‑محور متفاوتی را اشغال کند. چرخش، خطوط بیرونی، سرهای پیکان، چیدمان و سرریز متن، هندسهٔ تولید شدهٔ SmartArt و سایر اثرات رندر می‌توانند منطقهٔ اشغالی را تغییر دهند.

از [Shape::getVisualBounds](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getVisualBounds) برای محاسبهٔ آن منطقهٔ اشغالی بدون ایجاد تصویر استفاده کنید. این متد یک [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) در مختصات اسلاید بر می‌گرداند. مستطیل برگردانده شده به اسلاید برش داده نشده است، بنابراین مختصات آن می‌تواند وقتی محتوا فراتر از مبدأ اسلاید می‌رود منفی باشد.

مثال زیر قاب و مرزهای بصری را دریافت و مقایسه می‌کند:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

همان [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) می‌تواند برای هم‌ترازی اشکال نزدیک به لبهٔ چپ، راست، بالا یا پایین آن، رزرو فضای کافی در یک چیدمان تولیدی یا تشخیص محتوا خارج از ناحیهٔ مجاز استفاده شود. مرزهای بصری به‌خصوص برای SmartArt، جعبه‌های متن، پیکان‌ها، تصاویر، اشکال چرخان و گروه‌های شکل مفید هستند، جایی که قاب ذخیره‌شده ممکن است نمای کامل رندر شده را نشان ندهد.

از [Shape::getVisualBounds](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getVisualBounds) زمانی که به مختصات برای چیدمان یا اعتبارسنجی نیاز دارید و به بیت‌مپ نیازی ندارید استفاده کنید. از [Shape::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage) وقتی که نیاز به رندر شکل دارید استفاده کنید. با [ShapeThumbnailBounds](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapethumbnailbounds/)، `ShapeThumbnailBounds::Shape` تصویر را از مرزهای شکل، شامل تنظیمات خطوط بیرونی، اندازه می‌دهد، در حالی که `ShapeThumbnailBounds::Appearance` تصویر را از ظاهر شکل اندازه می‌کند و نتیجه را به مرزهای اسلاید محدود می‌سازد. بر خلاف آن، `Shape::getVisualBounds` فقط مستطیل محاسبه‌شده را بر می‌گرداند و آن را به اسلاید برش نمی‌دهد.

## **سؤالات متداول**

**چه فرمت‌های تصویری می‌توان هنگام ذخیره‌سازی تصاویر بندانگشتی شکل استفاده کرد؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imageformat/)، و دیگران. اشکال همچنین می‌توانند به عنوان SVG برداری [صادر شوند](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/writeassvg/) با ذخیرهٔ محتوای شکل به‌صورت SVG.

**تفاوت بین مرزهای Shape و Appearance هنگام رندر یک تصویر بندانگشتی چیست؟**

`Shape` از هندسهٔ شکل استفاده می‌کند؛ `Appearance` [اثرهای بصری](/slides/fa/php-java/shape-effect/) (سایه‌ها، درخشش و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا همچنان به‌عنوان تصویر بندانگشتی رندر می‌شود؟**

یک شکل مخفی بخشی از مدل باقی می‌ماند و می‌تواند رندر شود؛ پرچم مخفی فقط نمایش در اسلایدشو را تحت تأثیر قرار می‌دهد اما از تولید تصویر شکل جلوگیری نمی‌کند.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیاء پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌عنوان [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) نمایش داده می‌شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/)) می‌تواند به‌صورت تصویر بندانگشتی یا SVG ذخیره شود.

**آیا فونت‌های نصب‌شده بر سیستم بر کیفیت تصاویر بندانگشتی اشکال متنی تأثیر می‌گذارد؟**

بله. شما باید [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/php-java/custom-font/) (یا [پیکربندی جایگزینی فونت‌ها](/slides/fa/php-java/font-substitution/)) تا از بازگشت‌های ناخواسته و تغییر قالب متن جلوگیری کنید.