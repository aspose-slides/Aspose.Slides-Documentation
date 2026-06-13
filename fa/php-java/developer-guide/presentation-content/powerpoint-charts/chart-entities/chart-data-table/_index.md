---
title: سفارشی‌سازی جداول داده نمودار در ارائه‌ها با استفاده از PHP
linktitle: جدول داده
type: docs
url: /fa/php-java/chart-data-table/
keywords:
- داده‌های نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "جداول داده نمودار را برای فایل‌های PPT و PPTX با استفاده از Aspose.Slides برای PHP از طریق Java سفارشی کنید تا بهره‌وری و جذابیت در ارائه‌ها افزایش یابد."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با جداول داده‌های نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه یک جدول داده برای نمودار نمایش داده شود و قالب‌بندی متن آن را با تنظیم ویژگی‌های قلم مانند سبک بولد و ارتفاع قلم سفارشی کنید. مثال بارگذاری یک ارائه، افزودن یک نمودار، فعال‌سازی جدول داده‌های نمودار، اعمال تنظیمات قلم و ذخیره ارائه بروز شده را نشان می‌دهد.

همچنین پاسخ‌های مختصری به سؤالات رایج در مورد نمایش کلیدهای نشانگر در جدول داده‌های نمودار، حفظ جدول داده در هنگام خروجی، کار با نمودارهایی که از ارائه‌ها یا قالب‌های موجود بارگذاری شده‌اند، و شناسایی نمودارهایی که جدول داده در آن‌ها فعال است، شامل می‌شود.

## **تنظیم ویژگی‌های قلم برای جدول داده‌های نمودار**
Aspose.Slides برای PHP از طریق Java پشتیبانی از تغییر رنگ دسته‌ها در رنگ یک سری را فراهم می‌کند. 

1. یک شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) را ایجاد کنید.
1. نموداری را روی اسلاید اضافه کنید.
1. جدول نمودار را تنظیم کنید.
1. ارتفاع قلم را تنظیم کنید.
1. ارائه‌ی اصلاح‌شده را ذخیره کنید.

یک مثال نمونه در زیر آورده شده است. 

```php
  # ایجاد ارائه خالی
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا می‌توانم کلیدهای نشانگر کوچک را در کنار مقادیر در جدول داده‌های نمودار نمایش دهم؟**

بله. جدول داده از [کلیدهای نشانگر](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datatable/setshowlegendkey/) پشتیبانی می‌کند و می‌توانید آنها را روشن یا خاموش کنید.

**آیا جدول داده هنگام خروجی ارائه به PDF، HTML یا تصاویر حفظ می‌شود؟**

بله. Aspose.Slides نمودار را به‌عنوان بخشی از اسلاید رندر می‌کند، بنابراین استخراج [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/fa/php-java/convert-powerpoint-to-html/)/[تصویر](/slides/fa/php-java/convert-powerpoint-to-png/) شامل نمودار با جدول داده آن است.

**آیا جداول داده برای نمودارهایی که از یک فایل قالب آمده‌اند پشتیبانی می‌شوند؟**

بله. برای هر نموداری که از یک ارائه یا قالب موجود بارگذاری می‌شود، می‌توانید با استفاده از ویژگی‌های نمودار، بررسی و تغییر کنید که آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/hasdatatable/) یا نه.

**چگونه می‌توانم به سرعت یافتن کنم که کدام نمودارها در یک فایل جدول داده را فعال دارند؟**

هر ویژگی هر نمودار را که نشان می‌دهد آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/hasdatatable/) بررسی کنید و در اسلایدها مرور کنید تا نمودارهایی که فعال هستند شناسایی شوند.