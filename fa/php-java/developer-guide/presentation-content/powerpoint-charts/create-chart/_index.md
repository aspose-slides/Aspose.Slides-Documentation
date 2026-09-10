---
title: ایجاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در PHP
linktitle: ایجاد یا به‌روزرسانی نمودارها
type: docs
weight: 10
url: /fa/php-java/create-chart/
keywords:
- افزودن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به‌روزرسانی نمودار
- نمودار پراکنده
- نمودار دایره‌ای
- نمودار خطی
- نمودار درخت-نقشه
- نمودار سهام
- نمودار جعبه‌ای و ویسکری
- نمودار قیفی
- نمودار خورشیدی
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارها در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java. افزودن، قالب‌بندی و ویرایش نمودارها با مثال‌های کد کاربردی."
---
## **بررسی کلی**

این مقاله راهنمای جامع‌ای برای ایجاد و سفارشی‌سازی نمودارها با استفاده از Aspose.Slides ارائه می‌دهد. شما یاد خواهید گرفت که چگونه به‌صورت برنامه‌نویسی یک نمودار به اسلاید اضافه کنید، آن را با داده پر کنید و گزینه‌های قالب‌بندی مختلفی را به‌کار بگیرید تا با نیازهای طراحی خاص شما مطابقت داشته باشد. در طول مقاله، مثال‌های کد جزئیات هر گام را نشان می‌دهند، از مقداردهی اولیهٔ ارائه و شیء نمودار تا پیکربندی سری‌ها، محورها و افسانه‌ها. با دنبال کردن این راهنما، درک محکمی از چگونگی ادغام تولید پویا نمودار در برنامه‌های خود به‌دست می‌آورید و فرایند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد نمودار**

نمودارها به افراد کمک می‌کنند تا به‌سرعت داده‌ها را تجسم کنند و بینش‌هایی به‌دست آورند که ممکن است از یک جدول یا صفحه‌گسترده به‌وضوح دیده نشود.

**چرا نمودار ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید:

* حجم زیادی از داده را در یک اسلاید ارائه جمع‌آوری، فشرده یا خلاصه کنید
* الگوها و گرایش‌های داده را نمایان کنید
* جهت و شتاب داده را در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص استنتاج کنید
* نقاط دور افتاده، انحرافات، خطاها، داده‌های نادرست و غیره را شناسایی کنید
* داده‌های پیچیده را ارتباط یا ارائه دهید

در PowerPoint می‌توانید نمودارها را از طریق عملکرد *Insert* ایجاد کنید که قالب‌های متنوعی برای طراحی انواع نمودارها فراهم می‌کند. با Aspose.Slides می‌توانید هم نمودارهای معمولی (بر پایهٔ انواع مشهور نمودار) و هم نمودارهای سفارشی ایجاد کنید.

{{% alert color="info" title="Note" %}}
برای ایجاد نمودارها از کلاس [ChartType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) استفاده کنید. فیلدهای این کلاس به انواع مختلف نمودارها متناظر هستند.
{{% /alert %}}

### **ایجاد نمودارهای ستونی خوشه‌ای**

این بخش توضیح می‌دهد چگونه نمودارهای ستونی خوشه‌ای را با Aspose.Slides ایجاد کنید. شما یاد می‌گیرید که یک ارائه را مقداردهی اولیه کنید، یک نمودار اضافه کنید و عناصر آن مانند عنوان، داده، سری‌ها، دسته‌ها و استایل را سفارشی کنید. مراحل زیر را دنبال کنید تا ببینید یک نمودار ستونی خوشه‌ای استاندارد چگونه تولید می‌شود:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
1. یک نمودار با برخی داده اضافه کنید و نوع `ChartType::ClusteredColumn` را مشخص کنید.
1. یک عنوان به نمودار اضافه کنید.
1. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
1. همهٔ سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.
1. رنگ پر کردن را برای سری‌های نمودار اعمال کنید.
1. برچسب‌ها را به سری‌های نمودار اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار ستونی خوشه‌ای ایجاد شود:

```php
  # یک شیء ارائه ایجاد می‌کند که نمایانگر یک فایل PPTX است
  $pres = new Presentation();
  try {
    # به اسلاید اول دسترسی پیدا می‌کند
    $sld = $pres->getSlides()->get_Item(0);
    # نمودار را با داده‌های پیش‌فرض اضافه می‌کند
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # عنوان نمودار را تنظیم می‌کند
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # سری اول را برای نمایش مقادیر تنظیم می‌کند
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # شاخص برگه داده‌های نمودار را تنظیم می‌کند
    $defaultWorksheetIndex = 0;
    # برگه کاری داده‌های نمودار را دریافت می‌کند
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # سری‌های جدید را اضافه می‌کند
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # دسته‌های جدید را اضافه می‌کند
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # سری اول نمودار را می‌گیرد
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # اکنون داده‌های سری را پر می‌کند
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # رنگ پر کردن برای سری را تنظیم می‌کند
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # سری دوم نمودار را می‌گیرد
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # داده‌های سری را پر می‌کند
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # رنگ پر کردن برای سری را تنظیم می‌کند
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # برچسب‌های سفارشی برای هر دسته برای سری جدید ایجاد می‌کند
    # برچسب اول را برای نمایش نام دسته تنظیم می‌کند
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # نمایش مقدار برای برچسب سوم
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # ارائه همراه با نمودار را ذخیره می‌کند
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای پراکنده**

نمودارهای پراکنده (که به‌عنوان scatter plot یا نمودار x‑y نیز شناخته می‌شوند) اغلب برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

از نمودار پراکنده زمانی استفاده کنید که:

* داده‌های عددی جفت‌جایی داشته باشید
* دو متغیر که به‌خوبی با هم جفت می‌شوند داشته باشید
* بخواهید تعیین کنید آیا دو متغیر مرتبط هستند یا نه
* یک متغیر مستقل با مقادیر متعدد برای یک متغیر وابسته داشته باشید

1. مراحل موجود در [Create Clustered Column Charts](#create-clustered-column-charts) را دنبال کنید.
2. در گام سوم، یک نمودار با برخی داده اضافه کنید و نوع نمودار خود را یکی از موارد زیر انتخاب کنید:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _نمایان‌گر یک نمودار پراکنده._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _نمایان‌گر یک نمودار پراکنده متصل به‌وسیلهٔ منحنی‌ها، با نشانگرهای داده._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _نمایان‌گر یک نمودار پراکنده متصل به‌وسیلهٔ منحنی‌ها، بدون نشانگرهای داده._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _نمایان‌گر یک نمودار پراکنده متصل به‌وسیلهٔ خطوط مستقیم، با نشانگرهای داده._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _نمایان‌گر یک نمودار پراکیده متصل به‌وسیلهٔ خطوط مستقیم، بدون نشانگرهای داده._

این کد PHP نشان می‌دهد چگونه یک نمودار پراکنده با نشانگرهای مختلف برای هر سری ایجاد شود:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
  $pres = new Presentation();
  try {
    # به اسلاید اول دسترسی می‌یابد
    $slide = $pres->getSlides()->get_Item(0);
    # نمودار پیش‌فرض را ایجاد می‌کند
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # شاخص برگه‌کاری داده‌های پیش‌فرض نمودار را دریافت می‌کند
    $defaultWorksheetIndex = 0;
    # برگه‌کاری داده‌های نمودار را دریافت می‌کند
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # سری نمایشی را حذف می‌کند
    $chart->getChartData()->getSeries()->clear();
    # سری‌های جدید را اضافه می‌کند
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # سری اول نمودار را می‌گیرد
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # یک نقطه جدید (1:3) را به سری اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # یک نقطه جدید (2:10) را اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # نوع سری را تغییر می‌دهد
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # نشانگر سری نمودار را تغییر می‌دهد
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # سری دوم نمودار را می‌گیرد
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # یک نقطه جدید (5:2) را در آن اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # یک نقطه جدید (3:1) را اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # یک نقطه جدید (2:2) را اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # یک نقطه جدید (5:1) را اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # نشانگر سری نمودار را تغییر می‌دهد
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای بهترین استفاده را برای نمایش رابطهٔ بخش‑به‑کل در داده‌ها دارند، به‌ویژه زمانی که داده‌ها شامل برچسب‌های دسته‌بندی با مقادیر عددی باشند. با این حال، اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیاد باشد، ممکن است بخواهید به‌جای آن از نمودار میله‌ای استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType::Pie](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#Pie) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. نقاط جدید برای نمودار اضافه کنید و رنگ‌های سفارشی برای بخش‌های نمودار دایره‌ای اعمال کنید.
9. برچسب‌ها را برای سری‌ها تنظیم کنید.
10. خطوط راهنما را برای برچسب‌های سری فعال کنید.
11. زاویهٔ چرخش برای بخش‌های نمودار دایره‌ای تنظیم کنید.
12. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد شود:

```php
  # یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
  $pres = new Presentation();
  try {
    # به اسلاید اول دسترسی پیدا می‌کند
    $slides = $pres->getSlides()->get_Item(0);
    # نمودار را با داده‌های پیش‌فرض اضافه می‌کند
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # عنوان نمودار را تنظیم می‌کند
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # سری اول را برای نمایش مقادیر تنظیم می‌کند
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # شاخص برگه داده‌های نمودار را تنظیم می‌کند
    $defaultWorksheetIndex = 0;
    # برگه کاری داده‌های نمودار را دریافت می‌کند
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # دسته‌های جدید را اضافه می‌کند
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # سری‌های جدید را اضافه می‌کند
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # داده‌های سری را پر می‌کند
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # در نسخه جدید کار نمی‌کند
    # افزودن نقاط جدید و تنظیم رنگ بخش
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # مرزر بخش را تنظیم می‌کند
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # مرزر بخش را تنظیم می‌کند
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # مرزر بخش را تنظیم می‌کند
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # برچسب‌های سفارشی برای هر دسته برای سری جدید ایجاد می‌کند
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # خطوط راهنما را برای نمودار نمایش می‌دهد
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # زاویه چرخش بخش‌های نمودار دایره‌ای را تنظیم می‌کند
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # ارائه را همراه با نمودار ذخیره می‌کند
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به‌عنوان line graph نیز شناخته می‌شوند) بهترین استفاده را در موقعیت‌هایی دارند که می‌خواهید تغییر مقدار در طول زمان را نشان دهید. با یک نمودار خطی می‌توانید مقدار زیادی داده را به‌صورت همزمان مقایسه کنید، تغییرات و گرایش‌ها را در طول زمان پیگیری کنید، ناهنجاری‌های سری داده را برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType::Line](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#Line) را مشخص کنید.
1. به کاربرگ داده‌های نمودار ([ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/)) دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار خطی ایجاد شود:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

به‌طور پیش‌فرض، نقاط در یک نمودار خطی توسط خطوط مستقیم پیوسته به‌هم وصل می‌شوند. اگر می‌خواهید نقاط به‌جای خطوط مستقیم توسط نقطه‌چین‌ها وصل شوند، می‌توانید نوع خط نقطه‌چین دلخواه خود را به‌صورت زیر مشخص کنید:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای درخت‑نقشه**

نمودارهای درخت‑نقشه بهترین استفاده را برای داده‌های فروش دارند وقتی می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و به‌سرعت توجه را به مواردی که سهم بزرگ‌تری در هر دسته دارند جلب کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType::Treemap](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#Treemap) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار درخت‑نقشه ایجاد شود:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # شاخه 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # شاخه 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای سهام**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#OpenHighLowClose) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. قالب خطوط high‑low را مشخص کنید.
9. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار سهام ایجاد شود:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای جعبه‌ای و ویسكری**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#BoxAndWhisker) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار جعبه‌ای و ویسکری ایجاد شود:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای قیفی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType::Funnel](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#Funnel) را مشخص کنید.
4. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار قیفی ایجاد شود:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای خورشیدی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType::Sunburst](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#Sunburst) را مشخص کنید.
4. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار خورشیدی ایجاد شود:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # شاخه 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # شاخه 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای هیستوگرام**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType::Histogram](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#Histogram) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد شود:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **ایجاد نمودارهای رادار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با برخی داده اضافه کنید و نوع نمودار دلخواه خود (در این مثال [ChartType::Radar](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#Radar)) را مشخص کنید.
4. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار رادار ایجاد شود:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای چنددسته‌ای**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع [ChartType::ClusteredColumn](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ClusteredColumn) را مشخص کنید.
4. به کاربرگ داده‌های نمودار [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
6. سری‌ها و دسته‌های جدید اضافه کنید.
7. داده‌های جدید برای سری‌های نمودار اضافه کنید.
8. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار چنددسته‌ای ایجاد شود:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # افزودن سری
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # ذخیره ارائه با نمودار
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای نقشه**

نقشه‌ها داده‌های جغرافیایی را تجسم می‌کنند و به مقایسه مقادیر بین مناطق کمک می‌نمایند.

این کد PHP نشان می‌دهد چگونه یک نمودار نقشه ایجاد شود:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای ترکیبی**

نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا تفاوت‌ها یا شباهت‌های بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید و روابط بین آن‌ها را شناسایی نمایید.

![The combination chart](combination_chart.png)

کد PHP زیر نشان می‌دهد چگونه نمودار ترکیبی نشان‌داده‌شده در بالا را در یک ارائهٔ PowerPoint ایجاد کنید:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // عنوان نمودار را تنظیم می‌کند.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // راهنما (legend) نمودار را تنظیم می‌کند.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // دسته‌های جدید را اضافه می‌کند.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // سری اول را اضافه می‌کند.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // محور افقی را تنظیم می‌کند.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // محور عمودی را تنظیم می‌کند.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // رنگ خطوط شبکه اصلی عمودی را تنظیم می‌کند.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // محور افقی ثانوی را تنظیم می‌کند.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // محور عمودی ثانوی را تنظیم می‌کند.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **به‌روزرسانی نمودارها**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید که نمایانگر ارائه‌ای است که نمودار موردنظر برای به‌روزرسانی در آن قرار دارد.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. از میان تمام اشکال عبور کنید تا نمودار دلخواه را بیابید.
4. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
5. سری داده‌های نمودار را با تغییر مقادیر سری اصلاح کنید.
6. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.
7. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک نمودار را به‌روزرسانی کنید:

```php
  $pres = new Presentation();
  try {
    # دسترسی به اولین slideMarker
    $sld = $pres->getSlides()->get_Item(0);
    # دریافت نمودار با داده‌های پیش‌فرض
    $chart = $sld->getShapes()->get_Item(0);
    # تنظیم شاخص برگه داده‌های نمودار
    $defaultWorksheetIndex = 0;
    # دریافت برگه کاری داده‌های نمودار
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # تغییر نام دسته‌بندی نمودار
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # گرفتن سری اول نمودار
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # در حال به‌روزرسانی داده‌های سری
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// تغییر نام سری

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # گرفتن سری دوم نمودار
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # در حال به‌روزرسانی داده‌های سری
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// تغییر نام سری

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # حالا، افزودن یک سری جدید
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # گرفتن سری سوم نمودار
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # در حال پر کردن داده‌های سری
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # ذخیره ارائه به همراه نمودار
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم بازهٔ داده برای یک نمودار**

برای تنظیم بازهٔ داده برای یک نمودار، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید که نمایانگر ارائه‌ای است که نمودار در آن قرار دارد.
2. با استفاده از اندیس‌اش به یک اسلاید ارجاع پیدا کنید.
3. از میان تمام اشکال عبور کنید تا نمودار دلخواه را بیابید.
4. به داده‌های نمودار دسترسی پیدا کنید و بازه را تنظیم کنید.
5. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه بازهٔ داده برای یک نمودار تنظیم شود:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استفاده از نشانگرهای پیش‌فرض در نمودارها**

زمانی که از نشانگرهای پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار یک نماد نشانگر متفاوت دریافت می‌کند.

این کد PHP نشان می‌دهد چگونه نشانگر یک سری نمودار به‌صورت خودکار تنظیم شود:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # گرفتن سری دوم نمودار
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # در حال پر کردن داده‌های سری
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**کدام انواع نمودارها توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides مجموعه‌ی گسترده‌ای از [chart types](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) را پشتیبانی می‌کند، از جمله میله‌ای، خطی، دایره‌ای، مساحتی، پراکنده، هیستوگرام، رادار و بسیاری دیگر. این انعطاف‌پذیری به شما اجازه می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای تجسم داده‌های خود انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن یک نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید، اسلاید موردنظر را با استفاده از اندیس‌اش بازیابی کنید و سپس متد افزودن نمودار را صدا بزنید، نوع نمودار و داده‌های اولیه را مشخص کنید. این فرآیند نمودار را مستقیماً در ارائهٔ شما یکپارچه می‌سازد.

**چگونه می‌توان داده‌های نمایش‌داده‌شده در یک نمودار را به‌روزرسانی کرد؟**

می‌توانید داده‌های یک نمودار را با دسترسی به کتاب کار داده‌های آن ([ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/))، پاک‌کردن سری‌ها و دسته‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود، به‌روزرسانی کنید. این کار به شما امکان می‌دهد نمودار را برای نمایش آخرین داده‌ها تازه کنید.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر [formatting elements](/slides/fa/php-java/chart-entities/) را تغییر دهید تا ظاهر نمودار را با الزامات طراحی خاص خود هم‌راستا کنید.