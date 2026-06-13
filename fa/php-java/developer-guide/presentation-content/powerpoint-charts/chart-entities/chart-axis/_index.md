---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها با استفاده از PHP
linktitle: محور نمودار
type: docs
url: /fa/php-java/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
- مدیریت محور
- ویژگی‌های محور
- حداکثر مقدار
- حداقل مقدار
- خط محور
- فرمت تاریخ
- عنوان محور
- موقعیت محور
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای PHP از طریق Java برای سفارشی‌سازی محورهای نمودار در ارائه‌های پاورپوینت برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **بررسی کلی**

این مقاله نحوه سفارشی‌سازی محورهای نمودار در Aspose.Slides را توضیح می‌دهد. در آن نشان داده می‌شود چگونه مقادیر واقعی محور را دریافت کنید، داده‌ها را بین محورها جابجا کنید، محور عمودی یا افقی را برای نمودارهای خطی مخفی کنید، نوع محور دسته‌بندی را تغییر دهید، فرمت تاریخ برای مقادیر محور دسته‌بندی را تنظیم کنید، عنوان محوری را چرخانید، موقعیت محور را تنظیم کنید و برچسب واحد را بر روی محور مقادیر نمایش دهید.

## **دریافت مقادیر بیشینه بر روی محور عمودی در نمودارها**
Aspose.Slides for PHP via Java به شما امکان می‌دهد حداقل و حداکثر مقادیر یک محور عمودی را به دست آورید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
1. مقدار حداکثر واقعی محور را دریافت کنید.
1. مقدار حداقل واقعی محور را دریافت کنید.
1. واحد اصلی واقعی محور را دریافت کنید.
1. واحد فرعی واقعی محور را دریافت کنید.
1. مقیاس واحد اصلی واقعی محور را دریافت کنید.
1. مقیاس واحد فرعی واقعی محور را دریافت کنید.

این کد نمونه — پیاده‌سازی مراحل بالا — نشان می‌دهد چگونه مقادیر مورد نیاز را دریافت کنید :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # ذخیرهٔ ارائه
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **جابه‌جایی داده‌ها بین محورها**
Aspose.Slides به شما امکان می‌دهد به سرعت داده‌ها بین محورها جابه‌جا شوند — داده‌های نمایش داده شده بر روی محور عمودی (محور y) به محور افقی (محور x) منتقل می‌شوند و بالعکس.

این کد PHP نشان می‌دهد چگونه عمل جابه‌جایی داده‌ها بین محورها را در یک نمودار انجام دهید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # سطرها و ستون‌ها را جابجا می‌کند
    $chart->getChartData()->switchRowColumn();
    # ذخیرهٔ ارائه
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

این کد PHP نشان می‌دهد چگونه محور عمودی یک نمودار خطی را مخفی کنید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

این کد نشان می‌دهد چگونه محور افقی یک نمودار خطی را مخفی کنید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغییر محور دسته‌بندی**

با استفاده از ویژگی **CategoryAxisType** می‌توانید نوع محور دسته‌بندی دلخواه خود را ( **date** یا **text** ) مشخص کنید. این کد عمل را نشان می‌دهد:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **تنظیم فرمت تاریخ برای مقادیر محور دسته‌بندی**
Aspose.Slides for PHP via Java به شما امکان می‌دهد فرمت تاریخ برای یک مقدار محور دسته‌بندی را تنظیم کنید. عملیات در این کد PHP نشان داده شده است:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **تنظیم زاویه چرخش برای عنوان محور نمودار**
Aspose.Slides for PHP via Java به شما امکان می‌دهد زاویه چرخش برای عنوان محور یک نمودار را تنظیم کنید. این کد PHP عملیات را نشان می‌دهد:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم موقعیت محور در محور دسته‌بندی یا مقدار**
Aspose.Slides for PHP via Java به شما امکان می‌دهد موقعیت محور را در یک محور دسته‌بندی یا مقدار تنظیم کنید. این کد PHP نشان می‌دهد چگونه این کار را انجام دهید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **فعال‌سازی نمایش برچسب واحد بر روی محور مقدار نمودار**
Aspose.Slides for PHP via Java به شما امکان می‌دهد یک نمودار را طوری پیکربندی کنید که برچسب واحد را بر روی محور مقدار خود نشان دهد. این کد PHP عملیات را نشان می‌دهد:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**چگونه مقدار تقاطعی که یک محور با دیگری می‌گذرد (تقاطع محور) را تنظیم کنم؟**

محورها یک [تنظیم عبور](https://reference.aspose.com/slides/fa/php-java/aspose.slides/axis/setcrosstype/) فراهم می‌کنند: می‌توانید انتخاب کنید که در صفر، حداکثر دسته/مقدار یا مقدار عددی مشخصی عبور کنند. این گزینه برای جابجایی محور X به بالا یا پایین یا برجسته‌سازی خط پایه مفید است.

**چگونه می‌توان برچسب‌های تیک را نسبت به محور موقعیت‌گذاری کرد (کناری، بیرونی، داخلی)؟**

[موقعیت برچسب](https://reference.aspose.com/slides/fa/php-java/aspose.slides/axis/setmajortickmark/) را به "cross"، "outside" یا "inside" تنظیم کنید. این تنظیم خوانایی را تحت تأثیر قرار می‌دهد و به ویژه در نمودارهای کوچک به صرفه‌جویی در فضا کمک می‌کند.