---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها با استفاده از PHP
linktitle: نمودار دایره‌ای
type: docs
url: /fa/php-java/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های ترسیم
- رنگ برش
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "بیاموزید چگونه نمودارهای دایره‌ای را با Aspose.Slides برای PHP از طریق Java ایجاد و سفارشی کنید، قابل صادرات به PowerPoint، و در چند ثانیه روایت داده‌های خود را تقویت کنید."
---
## **بررسی کلی**

این مقاله نحوه کار با نمودارهای دایره‌ای در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه گزینه‌های نمودار دوم را برای نمودارهای Pie of Pie و Bar of Pie پیکربندی کنید و چگونه رنگ خودکار برش‌ها را برای یک نمودار دایره‌ای استاندارد فعال کنید.

مثال‌ها بر گام‌های عملی سفارشی‌سازی نمودار متمرکز هستند، از جمله افزودن نمودار به یک اسلاید، تنظیم سری‌ها و برچسب‌ها، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره‌ی ارائه به‌روزشده.

## **گزینه‌های نمودار دوم برای نمودارهای Pie of Pie و Bar of Pie**
Aspose.Slides for PHP via Java اکنون گزینه‌های نمودار دوم را برای نمودارهای Pie of Pie یا Bar of Pie پشتیبانی می‌کند. در این بخش، نحوهٔ مشخص کردن این گزینه‌ها با استفاده از Aspose.Slides را نشان می‌دهیم. برای تعیین ویژگی‌ها، مراحل زیر را انجام دهید:

1. یک شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) را ایجاد کنید.
1. نمودار را به اسلاید اضافه کنید.
1. گزینه‌های نمودار دوم را مشخص کنید.
1. ارائه را بر روی دیسک بنویسید.

در مثال زیر، ویژگی‌های مختلف نمودار Pie of Pie تنظیم شده‌اند.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    # نمودار را به اسلاید اضافه کنید
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # ویژگی‌های مختلف را تنظیم کنید
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # ارائه را بر روی دیسک بنویسید
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم رنگ‌های خودکار برش‌های نمودار دایره‌ای**
Aspose.Slides for PHP via Java یک API ساده برای تنظیم رنگ‌های خودکار برش‌های نمودار دایره‌ای فراهم می‌کند. کد نمونه ویژگی‌های ذکر شده را اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. نمودار را با داده‌های پیش‌فرض اضافه کنید.
1. عنوان نمودار را تنظیم کنید.
1. اولین سری را به «نمایش مقادیر» تنظیم کنید.
1. شاخص صفحه داده‌های نمودار را تنظیم کنید.
1. ورق‌کار داده‌های نمودار را دریافت کنید.
1. سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف کنید.
1. دسته‌های جدید را اضافه کنید.
1. سری‌های جدید را اضافه کنید.

ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

```php
  # یک نمونه از کلاس Presentation ایجاد کنید
  $pres = new Presentation();
  try {
    # افزودن نمودار با داده‌های پیش‌فرض
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # تنظیم عنوان نمودار
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # تنظیم اولین سری برای نمایش مقادیر
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # تنظیم شاخص صفحه‌کار داده‌های نمودار
    $defaultWorksheetIndex = 0;
    # دریافت صفحه‌کار داده‌های نمودار
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # حذف سری‌ها و دسته‌های پیش‌فرض تولید شده
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # افزودن دسته‌های جدید
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # افزودن سری جدید
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # اکنون پر کردن داده‌های سری
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا انواع 'Pie of Pie' و 'Bar of Pie' پشتیبانی می‌شوند؟**

بله، کتابخانه [پشتیبانی می‌کند](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) از نمودار ثانویه برای نمودارهای دایره‌ای، از جمله انواع 'Pie of Pie' و 'Bar of Pie'.

**آیا می‌توانم تنها نمودار را به‌عنوان تصویر (مثلاً PNG) صادر کنم؟**

بله، می‌توانید خود نمودار را به‌عنوان تصویر (مانند PNG) بدون کل ارائه صادر کنید.