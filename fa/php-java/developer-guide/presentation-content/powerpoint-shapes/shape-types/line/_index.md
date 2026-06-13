---
title: اضافه کردن اشکال خط به ارائه‌ها در PHP
linktitle: خط
type: docs
weight: 50
url: /fa/php-java/Line/
keywords:
- خط
- ایجاد خط
- افزودن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط‌چکیده
- سر پیکان
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یادگیری دستکاری فرمت‌بندی خط در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java. کشف ویژگی‌ها، متدها و مثال‌ها."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد که به‌صورت برنامه‌نویسی خطوط شکل را به اسلایدهای PowerPoint اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کنید و چگونه خطی را سفارشی کنید تا به شکل یک پیکان ظاهر شود.

شما خواهید آموخت چگونه یک خط شکل را به یک اسلاید اضافه کنید، ظاهر بصری آن را تنظیم کنید و ارائه به‌روزشده را ذخیره کنید. مثال‌ها بر تنظیمات عملی فرمت‌بندی خط مانند سبک، عرض، الگوی خط‌شکسته، گزینه‌های سرپیکان و رنگ پر کردن تمرکز دارند.

## **ایجاد خط ساده**

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
- با استفاده از Index اسلاید، مرجع آن را دریافت کنید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addAutoShape) موجود در شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/)، یک AutoShape از نوع Line اضافه کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

در مثال زیر، ما یک خط را به اولین اسلاید ارائه اضافه کرده‌ایم.

```php
  # نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن AutoShape از نوع خط
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # نوشتن فایل PPTX بر روی دیسک
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ایجاد خط به شکل پیکان**

Aspose.Slides for PHP via Java همچنین به توسعه‌دهندگان اجازه می‌دهد برخی از خصوصیات خط را تنظیم کنند تا ظاهر جذاب‌تری داشته باشد. بیایید چند ویژگی خط را طوری تنظیم کنیم که شبیه یک پیکان باشد. لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
- با استفاده از Index اسلاید، مرجع آن را دریافت کنید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addAutoShape) موجود در شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/)، یک AutoShape از نوع Line اضافه کنید.
- ویژگی [Line Style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineStyle) را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for PHP via Java تنظیم کنید.
- عرض خط را تنظیم کنید.
- ویژگی [Dash Style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineDashStyle) خط را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for PHP via Java تنظیم کنید.
- سبک [Arrow Head Style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineArrowheadLength) نقطهٔ شروع خط را تنظیم کنید.
- سبک [Arrow Head Style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineArrowheadLength) نقطهٔ انتهای خط را تنظیم کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```php
  # نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن AutoShape از نوع خط
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # اعمال برخی قالب‌بندی‌ها بر روی خط
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # نوشتن فایل PPTX بر روی دیسک
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا می‌توانم یک خط عادی را به یک connector تبدیل کنم تا به شکل‌ها «چسبیده» شود؟**

نه. یک خط عادی (یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapetype/)) به‌طور خودکار به یک connector تبدیل نمی‌شود. برای چسباندن آن به شکل‌ها، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/) و [corresponding APIs](/slides/fa/php-java/connector/) برای ارتباطات استفاده کنید.

**اگر ویژگی‌های یک خط از تم ارث‌بری شده باشد و تعیین مقادیر نهایی دشوار باشد، چه کاری باید انجام دهم؟**

[مراجعه به ویژگی‌های مؤثر](/slides/fa/php-java/shape-effective-properties/) از طریق `LineFormatEffectiveData`/`LineFillFormatEffectiveData`—این‌ها قبلاً وراثت و سبک‌های تم را در نظر گرفته‌اند.

**آیا می‌توانم یک خط را در برابر ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. اشکال [lock objects](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/getautoshapelock/) را ارائه می‌دهند که امکان جلوگیری از عملیات ویرایش را به شما می‌دهند.