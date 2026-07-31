---
title: "افزودن اشکال خط به ارائه‌ها در PHP"
linktitle: "خط"
type: docs
weight: 50
url: /fa/php-java/line/
keywords:
- "خط"
- "ایجاد خط"
- "اضافه کردن خط"
- "خط ساده"
- "پیکربندی خط"
- "سفارشی‌سازی خط"
- "سبک خط تیره"
- "سر پیکان"
- "پاورپوینت"
- "ارائه"
- "PHP"
- "Aspose.Slides"
description: "یاد بگیرید چگونه قالب‌بندی خطوط را در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java مدیریت کنید. ویژگی‌ها، متدها و مثال‌ها را کشف کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا اشکال خط را به اسلایدهای PowerPoint به صورت برنامه‌نویسی اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کنید و چگونه یک خط را سفارشی کنید تا به شکل یک پیکان ظاهر شود.

شما می‌آموزید چگونه یک شکل خط را به یک اسلاید اضافه کنید، ظاهر بصری آن را تنظیم کنید و ارائه به‌روزشده را ذخیره نمایید. مثال‌ها بر تنظیمات عملی قالب‌بندی خط مانند سبک، عرض، الگوی خط تیره، گزینه‌های سرپیکان و رنگ پرش تمرکز دارند.

## **ایجاد خط ساده**

برای افزودن یک خط ساده به اسلاید انتخابی ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از شاخص آن به دست آورید.
- یک AutoShape از نوع Line را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addAutoShape) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) ارائه شده، اضافه کنید.
- ارائه اصلاح‌شده را به صورت یک فایل PPTX ذخیره کنید.

در مثال زیر، ما یک خط را به اولین اسلاید ارائه اضافه کرده‌ایم.

```php
  # نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # اضافه کردن AutoShape از نوع خط
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # نوشتن PPTX بر روی دیسک
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ایجاد خط به شکل پیکان**

Aspose.Slides for PHP via Java همچنین به توسعه‌دهندگان امکان می‌دهد برخی از خصوصیات خط را پیکربندی کنند تا ظاهر جذاب‌تری داشته باشد. بیایید چند خصوصیت خط را تنظیم کنیم تا شبیه یک پیکان شود. لطفاً برای انجام این کار مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از شاخص آن به دست آورید.
- یک AutoShape از نوع Line را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addAutoShape) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) ارائه شده، اضافه کنید.
- خصوصیت [Line Style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineStyle) را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for PHP via Java تنظیم کنید.
- عرض خط را تنظیم کنید.
- خصوصیت [Dash Style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineDashStyle) خط را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for PHP via Java تنظیم کنید.
- خصوصیت‌های [Arrow Head Style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineArrowheadLength) نقطهٔ شروع خط را تنظیم کنید.
- خصوصیت‌های [Arrow Head Style](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineArrowheadStyle) و [Length](https://reference.aspose.com/slides/fa/php-java/aspose.slides/LineArrowheadLength) نقطهٔ انتهای خط را تنظیم کنید.
- ارائه اصلاح‌شده را به صورت یک فایل PPTX ذخیره کنید.

```php
  # نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # اضافه کردن AutoShape از نوع خط
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
    # نوشتن PPTX بر روی دیسک
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا می‌توانم یک خط معمولی را به یک کانکتور تبدیل کنم تا به اشکال «چسبیده» شود؟**

خیر. یک خط معمولی (یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapetype/)) به‌صورت خودکار تبدیل به یک کانکتور نمی‌شود. برای چسباندن آن به اشکال، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/) و [APIهای مربوطه](/slides/fa/php-java/connector/) برای اتصالات استفاده کنید.

**اگر خصوصیات یک خط از تم به ارث برده شده باشد و تعیین مقادیر نهایی آن دشوار باشد، چه کاری باید انجام دهم؟**

[مراجعه به خصوصیات مؤثر](/slides/fa/php-java/shape-effective-properties/) از طریق `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — اینها قبلاً وراثت و سبک‌های تم را در نظر گرفته‌اند.

**آیا می‌توانم یک خط را در برابر ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. شکل‌ها [قفل‌اشیاء](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/getautoshapelock/) را فراهم می‌کنند که به شما اجازه می‌دهند عملیات ویرایشی را ممنوع کنید.