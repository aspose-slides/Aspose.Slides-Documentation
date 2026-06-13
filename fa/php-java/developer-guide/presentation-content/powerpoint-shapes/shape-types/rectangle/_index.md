---
title: افزودن مستطیل‌ها به ارائه‌ها در PHP
linktitle: مستطیل
type: docs
weight: 80
url: /fa/php-java/rectangle/
keywords:
- افزودن مستطیل
- ایجاد مستطیل
- شکل مستطیل
- مستطیل ساده
- مستطیل قالب‌بندی‌شده
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "با افزودن مستطیل‌ها با Aspose.Slides برای PHP از طریق Java، ارائه‌های PowerPoint خود را بهبود دهید — به راحتی شکل‌ها را به صورت برنامه‌نویسی طراحی و تغییر دهید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه اشکال مستطیلی را به اسلایدهای PowerPoint با استفاده از Aspose.Slides اضافه کنید. این مقاله ایجاد یک مستطیل ساده، ایجاد یک مستطیل قالب‌بندی‌شده و ذخیره ارائه بروز شده به صورت فایل PPTX را پوشش می‌دهد.

همچنین خواهید دید چگونه قالب‌بندی پایه‌ای مستطیل را اعمال کنید، از جمله رنگ پر کردن یکدست، رنگ خط و عرض خط. علاوه بر این، بخش پرسش‌های متداول مقاله به وظایف مرتبط با مستطیل اشاره می‌کند، شامل گوشه‌های گرد، پر کردن با تصویر، افکت‌های بصری، پیوندهای ابرمتن، قفل‌های شکل، گزینه‌های خروجی و ویژگی‌های مؤثر.

## **افزودن یک مستطیل به اسلاید**
برای افزودن یک مستطیل ساده به اسلاید انتخابی ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index، مرجع یک اسلاید را به دست آورید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) از نوع Rectangle را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addAutoShape) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) ارائه می‌شود، اضافه کنید.
- ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک مستطیل ساده به اولین اسلاید ارائه اضافه کرده‌ایم.

```php
  # نمونه‌سازی کلاس Prseetation که نمایانگر PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن AutoShape از نوع بیضی
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # نوشتن فایل PPTX به دیسک
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **افزودن یک مستطیل قالب‌بندی‌شده به اسلاید**
برای افزودن یک مستطیل قالب‌بندی‌شده به اسلاید، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index، مرجع یک اسلاید را به دست آورید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) از نوع Rectangle را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addAutoShape) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) ارائه می‌شود، اضافه کنید.
- نوع [Fill Type](https://reference.aspose.com/slides/fa/php-java/aspose.slides/FillType) مستطیل را به Solid تنظیم کنید.
- رنگ مستطیل را با استفاده از متد [ColorFormat::setColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorformat/#setColor) که توسط شیء [FillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) مرتبط با شیء [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) ارائه می‌شود، تنظیم کنید.
- رنگ خطوط مستطیل را تنظیم کنید.
- عرض خطوط مستطیل را تنظیم کنید.
- ارائه تغییر یافته را به صورت فایل PPTX ذخیره کنید.

مراحل بالا در مثال زیر پیاده‌سازی شده‌اند.

```php
  # نمونه‌سازی کلاس Prseetation که نمایانگر PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن AutoShape از نوع بیضی
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # اعمال برخی قالب‌بندی‌ها به شکل بیضی
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # اعمال برخی قالب‌بندی‌ها به خط بیضی
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # نوشتن فایل PPTX به دیسک
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**چگونه مستطیلی با گوشه‌های گرد اضافه کنم؟**  
از [shape type](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapetype/) با گوشه‌های گرد استفاده کنید و شعاع گوشه را در ویژگی‌های شکل تنظیم کنید؛ گرد کردن می‌تواند به‌صورت جداگانه برای هر گوشه از طریق تنظیمات هندسی نیز اعمال شود.

**چگونه مستطیلی را با یک تصویر (بافت) پر کنم؟**  
[fill type](https://reference.aspose.com/slides/fa/php-java/aspose.slides/filltype/) تصویر را انتخاب کنید، منبع تصویر را فراهم کنید و حالت‌های [stretching/tiling](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillmode/) را پیکربندی کنید.

**آیا یک مستطیل می‌تواند سایه و تاب داشته باشد؟**  
بله. [Outer/inner shadow, glow, and soft edges](/slides/fa/php-java/shape-effect/) با پارامترهای قابل تنظیم در دسترس هستند.

**آیا می‌توانم مستطیل را به دکمه‌ای با پیوند ابرمتن تبدیل کنم؟**  
بله. با کلیک روی شکل می‌توانید یک [Assign a hyperlink](/slides/fa/php-java/manage-hyperlinks/) تنظیم کنید (به اسلاید، فایل، آدرس وب یا ایمیل پرش کنید).

**چگونه می‌توانم از جابه‌جایی و تغییرات مستطیل محافظت کنم؟**  
از قفل‌های شکل استفاده کنید: می‌توانید جابه‌جایی، تغییر اندازه، انتخاب یا ویرایش متن را ممنوع کنید تا چیدمان حفظ شود.

**آیا می‌توانم مستطیل را به تصویر پیکسل یا SVG تبدیل کنم؟**  
بله. می‌توانید [render the shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage) را به تصویری با اندازه/مقیاس مشخص تبدیل کنید یا آن را به عنوان SVG [export it as SVG](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/writeassvg/) برای استفاده برداری خروجی بگیرید.

**چگونه به‌سرعت ویژگی‌های واقعی (effective) مستطیل را با در نظر گرفتن تم و وراثت دریافت کنم؟**  
[Use the shape’s effective properties](/slides/fa/php-java/shape-effective-properties/): API مقادیر محاسبه‌شده را برمی‌گرداند که سبک‌های تم، چیدمان و تنظیمات محلی را در بر می‌گیرد و تجزیه و تحلیل قالب‌بندی را ساده می‌کند.