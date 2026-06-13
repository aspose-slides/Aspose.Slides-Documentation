---
title: مدیریت برچسب‌های داده نمودار در ارائه‌ها با استفاده از PHP
linktitle: برچسب داده
type: docs
url: /fa/php-java/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- مکان برچسب
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده در یک نمودار جزئیات مربوط به سری‌های داده نمودار یا نقاط داده جداگانه را نشان می‌دهند. آنها به خوانندگان امکان می‌دهند سری‌های داده را به سرعت شناسایی کنند و همچنین فهم نمودارها را آسان‌تر می‌سازند.

## **تنظیم دقت داده در برچسب‌های داده نمودار**

این کد PHP به شما نشان می‌دهد چگونه دقت داده را در یک برچسب داده نمودار تنظیم کنید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **نمایش درصد به عنوان برچسب‌ها**

Aspose.Slides for PHP via Java به شما امکان می‌دهد برچسب‌های درصدی را روی نمودارهای نمایش داده‌شده تنظیم کنید. این کد PHP عملیات را نشان می‌دهد:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation();
  try {
    # اسلاید اول را دریافت می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # ارائه حاوی نمودار را ذخیره می‌کند
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم علامت درصد در برچسب‌های داده نمودار**

این کد PHP به شما نشان می‌دهد چگونه علامت درصد را برای یک برچسب داده نمودار تنظیم کنید:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation();
  try {
    # مرجع اسلاید را از طریق شاخص آن دریافت می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    # نمودار PercentsStackedColumn را بر روی اسلاید ایجاد می‌کند
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # NumberFormatLinkedToSource را روی false تنظیم می‌کند
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # ورک‌شیت داده‌های نمودار را دریافت می‌کند
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # سری جدیدی اضافه می‌کند
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # رنگ پرشدن سری را تنظیم می‌کند
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # ویژگی‌های LabelFormat را تنظیم می‌کند
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # سری جدیدی اضافه می‌کند
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # نوع پرشدن و رنگ را تنظیم می‌کند
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # ارائه را روی دیسک ذخیره می‌کند
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم فاصله برچسب از محور**

این کد PHP به شما نشان می‌دهد چگونه فاصله برچسب را از یک محور دسته‌بندی زمانی که با نموداری که بر پایه محورها ترسیم شده کار می‌کنید، تنظیم کنید:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation();
  try {
    # مرجع یک اسلاید را دریافت می‌کند
    $sld = $pres->getSlides()->get_Item(0);
    # یک نمودار بر روی اسلاید ایجاد می‌کند
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # فاصله برچسب را از یک محور تنظیم می‌کند
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # ارائه را روی دیسک ذخیره می‌کند
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم مکان برچسب**

وقتی نموداری ایجاد می‌کنید که به محوری وابسته نیست مانند نمودار دایره‌ای، ممکن است برچسب‌های داده نمودار بسیار نزدیک به لبه آن شوند. در چنین حالتی، باید مکان برچسب را تنظیم کنید تا خطوط راهنما به وضوح نمایش داده شوند.

این کد PHP به شما نشان می‌دهد چگونه مکان برچسب را در یک نمودار دایره‌ای تنظیم کنید:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **پرسش‌های متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای پر تراکم جلوگیری کنم؟**

از ترکیب قراردهی خودکار برچسب‌ها، خطوط راهنما و کاهش اندازه قلم استفاده کنید؛ در صورت نیاز، برخی فیلدها (مانند دسته) را مخفی کنید یا برچسب‌ها را تنها برای نقاط حاشیه‌ای/کلیدی نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده را پیش از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش مقادیر صفر، مقادیر منفی یا مقادیر گمشده را بر اساس یک قانون تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک ثابت برچسب را هنگام خروجی به PDF/تصاویر تضمین کنم؟**

قلم‌ها (خانواده، اندازه) را به‌صورت صریح تنظیم کنید و اطمینان حاصل کنید که فونت روی سمت رندرینگ موجود است تا از استفادهٔ جایگزین جلوگیری شود.