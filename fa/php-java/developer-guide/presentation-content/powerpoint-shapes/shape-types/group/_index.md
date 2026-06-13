---
title: اشکال ارائه گروهی در PHP
linktitle: گروه شکل
type: docs
weight: 40
url: /fa/php-java/group/
keywords:
- شکل گروهی
- گروه شکل
- افزودن گروه
- متن جایگزین
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در دسته‌های پاورپوینت با استفاده از Aspose.Slides برای PHP از طریق Java گروه‌بندی و جداسازی کنید — راهنمای سریع گام‌به‌گام با کد رایگان."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با اشکال گروهی در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه یک شکل گروهی را به یک اسلاید اضافه کنید، اشکال را درون آن قرار دهید و ارائه به‌روزشده را ذخیره کنید. همچنین نحوه دسترسی به اشکال ذخیره‌شده درون یک گروه و خواندن مقادیر `AlternativeText` آن‌ها را نشان می‌دهد. علاوه بر این، مقاله به‌اختصار قابلیت‌های مرتبط با شکل‌های گروهی مانند گروه‌های تو در تو، ترتیب Z و گزینه‌های قفل‌گذاری را پوشش می‌دهد.

## **افزودن یک شکل گروهی**
Aspose.Slides از کار با اشکال گروهی در اسلایدها پشتیبانی می‌کند. این ویژگی به توسعه‌دهندگان کمک می‌کند تا ارائه‌های غنی‌تری داشته باشند. Aspose.Slides برای PHP از طریق Java امکان افزودن یا دسترسی به اشکال گروهی را فراهم می‌کند. می‌توانید اشکال را به یک شکل گروهی اضافه‌شده برای پر کردن آن یا دسترسی به هر ویژگی از شکل گروهی اضافه کنید. برای افزودن یک شکل گروهی به اسلاید با استفاده از Aspose.Slides برای PHP از طریق Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از Index آن به‌دست آورید
1. یک شکل گروهی را به اسلاید اضافه کنید.
1. اشکال را به شکل گروهی اضافه‌شده اضافه کنید.
1. ارائهٔ اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

مثال زیر یک شکل گروهی را به اسلاید اضافه می‌کند.

```php
  # نمونه‌سازی کلاس Presentation
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # دسترسی به مجموعهٔ اشکال اسلایدها
    $slideShapes = $sld->getShapes();
    # افزودن یک شکل گروهی به اسلاید
    $groupShape = $slideShapes->addGroupShape();
    # افزودن اشکال به داخل شکل گروهی اضافه‌شده
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # افزودن قاب شکل گروهی
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # نوشتن فایل PPTX بر روی دیسک
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دسترسی به ویژگی AltText**
این موضوع گام‌های ساده‌ای را همراه با مثال‌های کد، برای افزودن یک شکل گروهی و دسترسی به ویژگی AltText اشکال گروهی در اسلایدها نشان می‌دهد. برای دسترسی به AltText یک شکل گروهی در اسلاید با استفاده از Aspose.Slides برای PHP از طریق Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) که نمایانگر فایل PPTX است، ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از Index آن به‌دست آورید.
1. به مجموعهٔ اشکال اسلایدها دسترسی پیدا کنید.
1. به شکل گروهی دسترسی پیدا کنید.
1. به ویژگی [Alternative Text](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getAlternativeText) دسترسی پیدا کنید.

مثال زیر به متن جایگزین شکل گروهی دسترسی پیدا می‌کند.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
  $pres = new Presentation("AltText.pptx");
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # دسترسی به مجموعهٔ اشکال اسلایدها
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # دسترسی به شکل گروهی.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # دسترسی به ویژگی AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا گروه‌بندی تو در تو (یک گروه درون گروه دیگر) پشتیبانی می‌شود؟**

بله. [GroupShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/groupshape/) دارای متد [getParentGroup](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getparentgroup/) است که به‌طور مستقیم پشتیبانی از سلسله‌مراتب را نشان می‌دهد (یک گروه می‌تواند فرزند گروه دیگری باشد).

**چگونه می‌توانم ترتیب Z گروه را نسبت به سایر اشیاء روی اسلاید کنترل کنم؟**

از متد [getZOrderPosition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getzorderposition/) شکل [GroupShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/groupshape/) استفاده کنید تا موقعیت آن را در پشتهٔ نمایش بررسی کنید.

**آیا می‌توانم از جابجایی/ویرایش/لغو گروه‌بندی جلوگیری کنم؟**

بله. بخش قفل گروه از طریق [GroupShapeLock](https://reference.aspose.com/slides/fa/php-java/aspose.slides/groupshape/getgroupshapelock/) در دسترس است که به شما امکان محدود کردن عملیات بر روی شیء را می‌دهد.