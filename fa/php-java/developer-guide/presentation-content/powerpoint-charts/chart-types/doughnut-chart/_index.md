---
title: سفارشی‌سازی نمودارهای دونات در ارائه‌ها با استفاده از PHP
linktitle: نمودار دونات
type: docs
weight: 30
url: /fa/php-java/doughnut-chart/
keywords:
- نمودار دونات
- فاصله مرکزی
- اندازه سوراخ
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید نمودارهای دونات را در Aspose.Slides برای PHP از طریق Java ایجاد و سفارشی کنید و از قالب‌های PowerPoint برای ارائه‌های پویا پشتیبانی نمایید."
---
## **بررسی اجمالی**

این مقاله نشان می‌دهد که چگونه با نمودار دونات در Aspose.Slides کار کنید؛ با افزودن نمودار به یک اسلاید، تنظیم اندازهٔ سوراخ مرکزی آن و ذخیره ارائه. این مقاله بر متد `setDoughnutHoleSize` تمرکز دارد و مراحل پایهٔ لازم برای سفارشی‌سازی این نوع نمودار را در کد نشان می‌دهد.

همچنین شامل یک بخش پرسش‌های متداول کوتاه است که سناریوهای مرتبط با نمودار دونات را پوشش می‌دهد، از جمله استفاده از چندین سری برای ایجاد چندین حلقه، کار با نمودارهای دونات منفجر شده و استخراج نمودار به صورت تصویر رستر یا SVG.

## **مشخص کردن فاصلهٔ مرکزی در نمودار دونات**

برای مشخص کردن اندازهٔ سوراخ در یک نمودار دونات، لطفاً مراحل زیر را دنبال کنید:

1. یک شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) را نمونه‌سازی کنید.
1. نمودار دونات را به اسلاید اضافه کنید.
1. اندازهٔ سوراخ در نمودار دونات را مشخص کنید.
1. ارائه را بر روی دیسک ذخیره کنید.

در مثال زیر، اندازهٔ سوراخ در نمودار دونات تنظیم شده است.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # ارائه را بر روی دیسک ذخیره کنید
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا می‌توانم یک دونات چندسطحی با چندین حلقه ایجاد کنم؟**

بله. چندین سری را به یک نمودار دونات اضافه کنید؛ هر سری تبدیل به یک حلقه جداگانه می‌شود. ترتیب حلقه‌ها توسط ترتیب سری‌ها در مجموعه تعیین می‌شود.

**آیا دونات «منفجر شده» (تکه‌های جداشده) پشتیبانی می‌شود؟**

بله. یک نوع نمودار [Exploded Doughnut](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) وجود دارد و یک ویژگی انفجار بر روی نقاط داده؛ می‌توانید تکه‌های جداگانه را جدا کنید.

**چگونه می‌توانم تصویر یک نمودار دونات (PNG/SVG) برای گزارش دریافت کنم؟**

نمودار یک شکل است؛ می‌توانید آن را به یک [raster image](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage) رندر کنید یا نمودار را به یک [SVG image](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#writeAsSvg) صادر کنید.