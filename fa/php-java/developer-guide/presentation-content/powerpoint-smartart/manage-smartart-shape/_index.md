---
title: مدیریت گرافیک‌های SmartArt در ارائه‌ها با استفاده از PHP
linktitle: گرافیک‌های SmartArt
type: docs
weight: 20
url: /fa/php-java/manage-smartart-shape/
keywords:
- شیء SmartArt
- گرافیک SmartArt
- سبک SmartArt
- رنگ SmartArt
- ایجاد SmartArt
- افزودن SmartArt
- ویرایش SmartArt
- تغییر SmartArt
- دسترسی به SmartArt
- نوع چیدمان SmartArt
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد، ویرایش و استایل‌دار کردن خودکار SmartArt در PowerPoint با PHP با استفاده از Aspose.Slides، شامل نمونه کدهای مختصر و راهنمایی‌های متمرکز بر عملکرد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد گرافیک‌های SmartArt را به‌صورت برنامه‌نویسی در ارائه‌های PowerPoint ایجاد و مدیریت کنید. این مقاله توضیح می‌دهد چگونه یک شکل SmartArt به اسلاید اضافه کنید، به شکل‌های SmartArt موجود دسترسی پیدا کنید، SmartArt را با نوع چیدمان خاصی پیدا کنید و ظاهر آن را با تغییر سبک SmartArt یا سبک رنگی به‌روز کنید.

نمونه‌ها نشان می‌دهند چگونه با شکل‌های SmartArt از طریق مجموعه اشکال اسلاید ارائه کار کنید، بررسی کنید آیا یک شکل SmartArt است و سپس ویژگی‌های آن را تغییر یا بررسی کنید.

## **ایجاد یک شکل SmartArt**
Aspose.Slides for PHP via Java یک API برای ایجاد شکل‌های SmartArt فراهم کرده است. برای ایجاد یک شکل SmartArt در اسلاید، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. با استفاده از Index آن، مرجع یک اسلاید را دریافت کنید.
1. با تنظیم [LayoutType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArtLayoutType) یک [اضافه کردن یک شکل SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addSmartArt) اضافه کنید.
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```php
  # ایجاد نمونه از کلاس Presentation
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن شکل Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # ذخیره‌سازی ارائه
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**تصویر: شکل SmartArt اضافه شده به اسلاید**|

## **دسترسی به یک شکل SmartArt روی اسلاید**
کد زیر برای دسترسی به شکل‌های SmartArt اضافه‌شده در اسلاید ارائه استفاده خواهد شد. در کد نمونه ما از همه اشکال داخل اسلاید عبور می‌کنیم و بررسی می‌کنیم آیا شکل یک شکل [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt) است یا خیر. اگر شکل از نوع SmartArt باشد، آن را به نمونهٔ [**SmartArt**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt) تبدیل می‌کنیم.

```php
  # بارگذاری ارائهٔ مورد نظر
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # گردش در تمام اشکال داخل اولین اسلاید
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # بررسی کنید آیا شکل از نوع SmartArt می‌باشد
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دسترسی به یک شکل SmartArt با نوع چیدمان خاص**
کد نمونه زیر به شما کمک می‌کند تا به شکل [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt) با LayoutType خاص دسترسی پیدا کنید. لطفاً توجه داشته باشید که نمی‌توانید LayoutType را تغییر دهید زیرا فقط برای خواندن است و تنها هنگام اضافه شدن شکل [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt) تنظیم می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
1. با استفاده از Index آن، مرجع اولین اسلاید را دریافت کنید.
1. از همه اشکال داخل اولین اسلاید عبور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt) است و اگر بود، آن را به SmartArt تبدیل کنید.
1. شکل SmartArt را با LayoutType خاص بررسی کنید و سپس کار مورد نیاز را انجام دهید.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # عبور از تمام اشکال داخل اولین اسلاید
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # بررسی کنید آیا شکل از نوع SmartArt است
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArtEx
        $smart = $shape;
        # بررسی چیدمان SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغییر سبک شکل SmartArt**
در این مثال، می‌آموزیم چگونه سبک سریع یک شکل SmartArt را تغییر دهیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
1. با استفاده از Index آن، مرجع اولین اسلاید را دریافت کنید.
1. از همه اشکال داخل اولین اسلاید عبور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt) است و اگر بود، آن را به SmartArt تبدیل کنید.
1. شکل SmartArt را با سبک خاص پیدا کنید.
1. سبک جدید را برای شکل SmartArt تنظیم کنید.
1. ارائه را ذخیره کنید.

```php
  # ایجاد نمونه از کلاس Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # دریافت اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # گردش در تمام اشکال داخل اولین اسلاید
    foreach($slide->getShapes() as $shape) {
      # بررسی کنید آیا شکل از نوع SmartArt است
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArtEx
        $smart = $shape;
        # بررسی سبک SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # تغییر سبک SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # ذخیره‌سازی ارائه
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**تصویر: شکل SmartArt با سبک تغییر یافته**|

## **تغییر سبک رنگی شکل SmartArt**
در این مثال، می‌آموزیم چگونه سبک رنگی یک شکل SmartArt را تغییر دهیم. در کد نمونه زیر به شکل SmartArt با سبک رنگی خاص دسترسی پیدا می‌کنیم و سبک آن را تغییر می‌دهیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
1. با استفاده از Index آن، مرجع اولین اسلاید را دریافت کنید.
1. از همه اشکال داخل اولین اسلاید عبور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt) است و اگر بود، آن را به SmartArt تبدیل کنید.
1. شکل SmartArt را با سبک رنگی خاص پیدا کنید.
1. سبک رنگی جدید را برای شکل SmartArt تنظیم کنید.
1. ارائه را ذخیره کنید.

```php
  # ایجاد نمونه از کلاس Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # دریافت اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # گردش در تمام اشکال داخل اولین اسلاید
    foreach($slide->getShapes() as $shape) {
      # بررسی کنید آیا شکل از نوع SmartArt است
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArtEx
        $smart = $shape;
        # بررسی نوع رنگ SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # تغییر نوع رنگ SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # ذخیره‌سازی ارائه
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**تصویر: شکل SmartArt با سبک رنگی تغییر یافته**|

## **پرسش‌های متداول**

**آیا می‌توانم SmartArt را به‌عنوان یک شیء واحد انیمیشن کنم؟**

بله. SmartArt یک شکل است، بنابراین می‌توانید همانند سایر اشکال، از طریق API انیمیشن‌ها [انیمیشن‌های استاندارد](/slides/fa/php-java/powerpoint-animation/) (ورودی، خروجی، تأکید، مسیرهای حرکتی) را اعمال کنید.

**چگونه می‌توانم یک SmartArt خاص را روی اسلاید پیدا کنم اگر شناسه داخلی آن را ندانم؟**

متن جایگزین (AltText) را تنظیم و استفاده کنید و با جستجوی شکل بر اساس آن مقدار، شکل هدف را پیدا کنید—این روش توصیه‌شده برای مکان‌یابی شکل است.

**آیا می‌توانم SmartArt را با سایر اشکال گروه‌بندی کنم؟**

بله. می‌توانید SmartArt را با سایر اشکال (تصاویر، جداول و غیره) گروه‌بندی کنید و سپس [گروه را دستکاری کنید](/slides/fa/php-java/group/).

**چگونه می‌توانم تصویر یک SmartArt خاص را دریافت کنم (مثلاً برای پیش‌نمایش یا گزارش)؟**

یک تصویر کوچک/عکس از شکل را صادر کنید؛ کتابخانه می‌تواند [اشکال منفرد را به فایل‌های رستر (PNG/JPG/TIFF) رندر کند](/slides/fa/php-java/create-shape-thumbnails/).

**آیا ظاهر SmartArt هنگام تبدیل کل ارائه به PDF حفظ می‌شود؟**

بله. موتور رندر هدف خود را حفظ بالای دقت برای [صادرات PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) قرار داده است، همراه با مجموعه‌ای از گزینه‌های کیفیت و سازگاری.