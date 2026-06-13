---
title: مدیریت نگهدارنده‌های ارائه در PHP
linktitle: مدیریت نگهدارنده‌ها
type: docs
weight: 10
url: /fa/php-java/manage-placeholder/
keywords:
- نگهدارنده
- نگهدارنده متن
- نگهدارنده تصویر
- نگهدارنده نمودار
- متن اعلان
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "به‌راحتی نگهدارنده‌ها را در Aspose.Slides برای PHP از طریق Java مدیریت کنید: متن را جایگزین کنید، اعلان‌ها را سفارشی کنید و شفافیت تصویر را در PowerPoint و OpenDocument تنظیم کنید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد نگهدارنده‌های ارائه را به‌صورت برنامه‌نویسی مدیریت کنید. این مقاله توضیح می‌دهد چگونه نگهدارنده‌ها را روی اسلایدها پیدا کنید و متن آنها را تغییر دهید، متن اعلان سفارشی برای طرح‌های نگهدارنده تنظیم کنید و شفافیت تصویری که به‌عنوان پس‌زمینه نگهدارنده استفاده می‌شود را تنظیم کنید. همچنین شامل یک بخش کوتاه پرسش‌های متداول است که تفاوت بین نگهدارنده‌های پایه و اشکال محلی را روشن می‌کند، نحوه اعمال تغییرات نگهدارنده از طریق طرح‌ها یا مسترها را شرح می‌دهد و به مدیریت نگهدارنده‌های سرصفحه و پانویس اشاره می‌کند.

## **تغییر متن در یک نگهدارنده**
با استفاده از [Aspose.Slides for PHP via Java](/slides/fa/php-java/)، می‌توانید نگهدارنده‌ها را در اسلایدهای یک ارائه پیدا کرده و اصلاح کنید. Aspose.Slides به شما اجازه می‌دهد متن موجود در یک نگهدارنده را تغییر دهید.

**پیش‌نیاز**: شما به یک ارائه‌ای نیاز دارید که حاوی یک نگهدارنده باشد. می‌توانید چنین ارائه‌ای را با برنامه استاندارد Microsoft PowerPoint ایجاد کنید.

این نحوه استفاده از Aspose.Slides برای جایگزینی متن در نگهدارنده آن ارائه است:

1. کلاس [`Presentation`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) را نمونه‌سازی کنید و ارائه را به‌عنوان آرگومان پاس دهید.
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.
3. در میان اشکال مرور کنید تا نگهدارنده را پیدا کنید.
4. شکل نگهدارنده را به یک [`AutoShape`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/AutoShape) تبدیل کنید و متن را با استفاده از [`TextFrame`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/TextFrame) مرتبط با [`AutoShape`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/AutoShape) تغییر دهید.
5. ارائه اصلاح‌شده را ذخیره کنید.

این کد PHP نشان می‌دهد چطور متن در یک نگهدارنده را تغییر دهید:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # به اسلاید اول دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # از طریق اشکال پیمایش می‌کند تا نگهدارنده را پیدا کند
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # متن هر نگهدارنده را تغییر می‌دهد
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # ارائه را روی دیسک ذخیره می‌کند
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم متن اعلان در یک نگهدارنده**
طرح‌های استاندارد و پیش‌ساخته شامل متن‌های اعلان نگهدارنده مانند ***Click to add a title*** یا ***Click to add a subtitle*** هستند. با استفاده از Aspose.Slides می‌توانید متن‌های اعلان دلخواه خود را در طرح‌های نگهدارنده وارد کنید.

این کد PHP نشان می‌دهد چطور متن اعلان را در یک نگهدارنده تنظیم کنید:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # پیمایش اسلاید
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint پیغام "Click to add title" را نمایش می‌دهد
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // زیرعنوان را اضافه می‌کند
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم شفافیت تصویر نگهدارنده**

Aspose.Slides به شما اجازه می‌دهد شفافیت تصویر پس‌زمینه در یک نگهدارنده متن را تنظیم کنید. با تنظیم شفافیت تصویر داخل چنین قاب‌ایی، می‌توانید متن یا تصویر را برجسته کنید (بسته به رنگ‌های متن و تصویر).

این کد PHP نشان می‌دهد چطور شفافیت پس‌زمینه تصویر (درون یک شکل) را تنظیم کنید:

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **پرسش‌های متداول**

**نگهدارنده پایه چیست و چه تفاوتی با شکل محلی روی اسلاید دارد؟**

نگهدارنده پایه شکل اصلی روی یک طرح یا مستر است که شکل اسلاید از آن به‌عنوان نوع، موقعیت و برخی قالب‌بندی‌ها ارث می‌برد. یک شکل محلی مستقل است؛ اگر نگهدارنده پایه‌ای وجود نداشته باشد، ارث‌بری اعمال نمی‌شود.

**چگونه می‌توان تمام عناوین یا توضیح‌نامه‌ها را در یک ارائه به‌روزرسانی کرد بدون اینکه بر هر اسلاید پیمایش کنم؟**

نگهدارنده مربوطه را در طرح یا مستر ویرایش کنید. اسلایدهایی که بر پایه آن طرح‌ها/مسترها ساخته شده‌اند به‌صورت خودکار تغییر را دریافت می‌کنند.

**چگونه می‌توان نگهدارنده‌های استاندارد سرصفحه/پانویس—تاریخ و زمان، شماره اسلاید و متن پانویس—را کنترل کرد؟**

از مدیران HeaderFooter در سطح مناسب (اسلایدهای عادی، طرح‌ها، مستر، یادداشت‌ها/برگه‌های توزیع) استفاده کنید تا این نگهدارنده‌ها را روشن یا خاموش کرده و محتوای آنها را تنظیم نمایید.