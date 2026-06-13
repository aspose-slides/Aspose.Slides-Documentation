---
title: "مدیریت سری‌های داده نمودار در ارائه‌ها با استفاده از PHP"
linktitle: "سری‌های داده"
type: docs
url: /fa/php-java/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- رنگ دسته
- نام سری
- نقطه داده
- فاصله سری
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یادگیری نحوه مدیریت سری‌های داده نمودار در PHP برای پاورپوینت (PPT/PPTX) با مثال‌های کد عملی و بهترین روش‌ها برای ارتقای ارائه‌های داده‌ای شما."
---
## **مرور کلی**

این مقاله نقش ChartSeries را در Aspose.Slides توضیح می‌دهد و بر نحوه ساختاردهی و تجسم داده‌ها در ارائه‌ها تمرکز می‌کند. این اشیاء عناصر پایه‌ای را فراهم می‌آورند که مجموعه‌های منفرد نقاط داده، دسته‌ها و پارامترهای ظاهر در یک نمودار را تعریف می‌کنند. با کار با ChartSeries، توسعه‌دهندگان می‌توانند به‌صورت یکپارچه منابع داده زیرساختی را ادغام کرده و کنترل کامل بر نحوه نمایش اطلاعات داشته باشند، به‌طوری که ارائه‌های دینامیک و مبتنی بر داده ایجاد شود که بینش‌ها و تحلیل‌ها را به‌وضوح منتقل کنند.

یک سری ردیف یا ستونی از اعداد است که در یک نمودار ترسیم می‌شود.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

با استفاده از متد getParentSeriesGroup می‌توانید مقدار همپوشانی میله‌ها و ستون‌ها در یک نمودار دو‌بعدی را مشخص کنید (محدوده: -100 تا 100). این ویژگی برای تمام سری‌های گروه سری والد اعمال می‌شود: این یک بازتاب از ویژگی مربوطه گروه است. از این رو، این ویژگی فقط خواندنی است.

از متد `ChartSeriesGroup::setOverlap` برای تنظیم مقدار مورد نظر خود برای `Overlap` استفاده کنید.

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. یک نمودار ستونی خوشه‌ای بر روی اسلاید اضافه کنید.
1. به اولین سری نمودار دسترسی پیدا کنید.
1. به `ParentSeriesGroup` سری نمودار دسترسی پیدا کرده و مقدار همپوشانی دلخواه خود را برای سری تنظیم کنید.
1. ارائه اصلاح‌شده را در یک فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد که چگونه همپوشانی یک سری نمودار را تنظیم کنید:

```php
  $pres = new Presentation();
  try {
    # نمودار را اضافه می‌کند
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # همپوشانی سری را تنظیم می‌کند
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # فایل ارائه را روی دیسک می‌نویسد
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغییر رنگ سری**

Aspose.Slides for PHP via Java به این صورت می‌توانید رنگ یک سری را تغییر دهید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. نمودار را بر روی اسلاید اضافه کنید.
1. به سری‌ای که می‌خواهید رنگ آن را تغییر دهید دسترسی پیدا کنید.
1. نوع پر کردن و رنگ دلخواه خود را تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

این کد PHP نشان می‌دهد که چگونه رنگ یک سری را تغییر دهید:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغییر رنگ دسته‌بندی سری**

Aspose.Slides for PHP via Java به این صورت می‌توانید رنگ دسته‌بندی یک سری را تغییر دهید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. نمودار را بر روی اسلاید اضافه کنید.
1. به دسته‌بندی سری که می‌خواهید رنگ آن را تغییر دهید دسترسی پیدا کنید.
1. نوع پر کردن و رنگ دلخواه خود را تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد که چگونه رنگ دسته‌بندی یک سری را تغییر دهید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغییر نام سری**

به‌صورت پیش‌فرض، نام‌های legend برای یک نمودار محتویات سلول‌های بالای هر ستون یا ردیف داده هستند.

در مثال ما (تصویر نمونه)،

* ستون‌ها *Series 1, Series 2,* و *Series 3* هستند;
* ردیف‌ها *Category 1, Category 2, Category 3,* و *Category 4* هستند.

Aspose.Slides for PHP via Java به شما امکان می‌دهد نام یک سری را در داده‌های نمودار و legend آن به‌روزرسانی یا تغییر دهید.

این کد PHP نشان می‌دهد که چگونه نام یک سری را در داده‌های نمودار `ChartDataWorkbook` تغییر دهید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

این کد PHP نشان می‌دهد که چگونه نام یک سری را از طریق `Series` در legend آن تغییر دهید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم رنگ پر کردن سری نمودار**

به این صورت می‌توانید رنگ پر کردن خودکار برای سری‌های نمودار در داخل ناحیه رسم تنظیم کنید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. مرجع یک اسلاید را بر حسب ایندکس آن به‌دست آورید.
1. یک نمودار با داده‌های پیش‌فرض بر پایه نوع موردنظر خود اضافه کنید (در مثال زیر از `ChartType::ClusteredColumn` استفاده کردیم).
1. به سری نمودار دسترسی پیدا کنید و رنگ پر کردن را روی Automatic تنظیم کنید.
1. ارائه را در یک فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد که چگونه رنگ پر کردن خودکار برای یک سری نمودار را تنظیم کنید:

```php
  $pres = new Presentation();
  try {
    # یک نمودار ستونی خوشه‌ای ایجاد می‌کند
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # قالب پر کردن سری را به حالت خودکار تنظیم می‌کند
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # فایل ارائه را روی دیسک می‌نویسد
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم رنگ پراکنده معکوس برای سری نمودار**

به این صورت می‌توانید رنگ پر کردن معکوس برای سری‌های نمودار در داخل ناحیه رسم تنظیم کنید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. مرجع یک اسلاید را بر حسب ایندکس آن به‌دست آورید.
1. یک نمودار با داده‌های پیش‌فرض بر پایه نوع موردنظر خود اضافه کنید (در مثال زیر از `ChartType::ClusteredColumn` استفاده کردیم).
1. به سری نمودار دسترسی پیدا کنید و رنگ پر کردن را روی invert تنظیم کنید.
1. ارائه را در یک فایل PPTX ذخیره کنید.

این کد PHP عملیات را نشان می‌دهد:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # سری‌ها و دسته‌های جدید را اضافه می‌کند
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # اولین سری نمودار را می‌گیرد و داده‌های سری آن را پر می‌کند.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم معکوس شدن سری هنگام مقدار منفی**

Aspose.Slides به شما امکان می‌دهد معکوس‌سازی را از طریق ویژگی‌های `IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative` تنظیم کنید. هنگامی که معکوس‌سازی با استفاده از این ویژگی‌ها تنظیم شود، نقطه داده رنگ‌های خود را هنگام دریافت مقدار منفی معکوس می‌کند.

این کد PHP عملیات را نشان می‌دهد:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پاک‌سازی داده‌های نقطه خاص**

به این صورت می‌توانید داده‌های `DataPoints` یک سری خاص از نمودار را پاک کنید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. با استفاده از ایندکس، مرجع اسلاید را به‌دست آورید.
3. با استفاده از ایندکس، مرجع یک نمودار را به‌دست آورید.
4. تمام `DataPoints` نمودار را مرور کنید و `XValue` و `YValue` را به مقدار null تنظیم کنید.
5. تمام `DataPoints` برای سری خاص نمودار را پاک کنید.
6. ارائه اصلاح‌شده را در یک فایل PPTX ذخیره کنید.

این کد PHP عملیات را نشان می‌دهد:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم عرض فاصله سری**

به این صورت می‌توانید عرض فاصله (Gap Width) یک سری را از طریق ویژگی **`GapWidth`** تنظیم کنید:

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. نمودار با داده‌های پیش‌فرض اضافه کنید.
1. به هر سری از نمودار دسترسی پیدا کنید.
1. ویژگی `GapWidth` را تنظیم کنید.
1. ارائه اصلاح‌شده را در یک فایل PPTX ذخیره کنید.

این کد نشان می‌دهد که چگونه عرض فاصله یک سری را تنظیم کنید:

```php
  # یک ارائه خالی ایجاد می‌کند
  $pres = new Presentation();
  try {
    # به اسلاید اول ارائه دسترسی پیدا می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    # یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # اندیس شیت داده‌های نمودار را تنظیم می‌کند
    $defaultWorksheetIndex = 0;
    # کاربرگ داده‌های نمودار را دریافت می‌کند
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # سری‌ها را اضافه می‌کند
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # دسته‌ها را اضافه می‌کند
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # سری دوم نمودار را می‌گیرد
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # داده‌های سری را پر می‌کند
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # مقدار GapWidth را تنظیم می‌کند
    $series->getParentSeriesGroup()->setGapWidth(50);
    # ارائه را بر روی دیسک ذخیره می‌کند
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا محدودیتی برای تعداد سری‌هایی که یک نمودار می‌تواند داشته باشد وجود دارد؟**

Aspose.Slides هیچ سقف ثابتی برای تعداد سری‌های اضافه‌شده اعمال نمی‌کند. محدودیت عملی توسط قابلیت خواندن نمودار و حافظه موجود برای برنامه شما تعیین می‌شود.

**اگر ستون‌های یک خوشه بیش از حد نزدیک یا دور از هم باشند چه‌کار کنیم؟**

تنظیم مقدار `GapWidth` برای آن سری (یا گروه سری والد آن) را تغییر دهید. افزایش مقدار، فاصله بین ستون‌ها را گسترده‌تر می‌کند، در حالی که کاهش مقدار، آن‌ها را به هم نزدیک‌تر می‌سازد.