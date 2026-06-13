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
- نمودار نقشه درختی
- نمودار سهام
- نمودار جعبه‌ای و ویسکر
- نمودار قیفی
- نمودار خورشیدشکل
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java ایجاد و سفارشی کنید. نمودارها را با مثال‌های کد عملی اضافه، قالب‌بندی و ویرایش کنید.
---
## **بررسی کلی**

این مقاله راهنمای جامعی برای ایجاد و سفارشی‌سازی نمودارها با استفاده از Aspose.Slides فراهم می‌کند. شما یاد خواهید گرفت که چگونه به صورت برنامه‌نویسی یک نمودار را به اسلاید اضافه کنید، آن را با داده پر کنید و گزینه‌های قالب‌بندی مختلفی را برای مطابقت با نیازهای طراحی خاص خود اعمال کنید. در طول مقاله، مثال‌های کد مفصل هر گام را نشان می‌دهند، از مقداردهی اولیه ارائه و شی نمودار تا پیکربندی سَرِی‌ها، محور‌ها و افسانه‌ها. با دنبال کردن این راهنما، درک محکمی از نحوه ادغام تولید نمودارهای پویا در برنامه‌های خود به دست خواهید آورد و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد نمودار**

نمودارها به افراد کمک می‌کنند تا به سرعت داده‌ها را به تصویر بکشند و بینش‌هایی به دست آورند که ممکن است از یک جدول یا صفحه‌گسترده به‌صورت فوری واضح نباشد.

**چرا نمودارها ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید

* تجمع، فشرده‌سازی یا خلاصه‌سازی حجم عظیمی از داده‌ها در یک اسلاید واحد در یک ارائه
* افشا کردن الگوها و روندها در داده‌ها
* استنتاج جهت و شتاب داده‌ها در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص
* شناسایی نقاط دورافتاده، انحرافات، خطاها، داده‌های بی‌معنا و غیره
* ارتباط یا ارائه داده‌های پیچیده

در PowerPoint می‌توانید نمودارها را از طریق عملکرد درج ایجاد کنید، که قالب‌هایی را برای طراحی انواع مختلف نمودارها ارائه می‌دهد. با استفاده از Aspose.Slides می‌توانید نمودارهای عادی (بر پایه انواع محبوب نمودار) و نمودارهای سفارشی ایجاد کنید.

{{% alert color="primary" %}}  
برای امکان‌ساز شدن ایجاد نمودارها، Aspose.Slides کلاس [ChartType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ChartType) را ارائه می‌دهد. فیلدهای این کلاس به انواع مختلف نمودارها مربوط می‌شوند.  
{{% /alert %}}

### **ایجاد نمودارهای عادی**

_مراحل: ایجاد نمودار_

- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>مراحل:</em> ایجاد نمودار PowerPoint </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>مراحل:</em> ایجاد نمودار ارائه </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>مراحل:</em> ایجاد نمودار ارائه PowerPoint </strong></a>

مراحل کد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. نموداری با برخی داده‌ها اضافه کنید و نوع نمودار مورد نظر خود را مشخص کنید.  
4. عنوانی برای نمودار اضافه کنید.  
5. به ورک‌شیت داده‌های نمودار دسترسی پیدا کنید.  
6. تمام سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
7. سری‌ها و دسته‌های جدید اضافه کنید.  
8. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.  
9. رنگ پر شدن برای سری‌های نمودار اضافه کنید.  
10. برچسب‌ها برای سری‌های نمودار اضافه کنید.  
11. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه یک نمودار عادی ایجاد کنید:

```php
  # یک نمونه از کلاس ارائه ایجاد می‌کند که نمایانگر فایل PPTX است
  $pres = new Presentation();
  try {
    # به اولین اسلاید دسترسی می‌یابد
    $sld = $pres->getSlides()->get_Item(0);
    # یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # عنوان نمودار را تنظیم می‌کند
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # سری اول را تنظیم می‌کند تا مقادیر را نشان دهد
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # ایندکس شیت داده‌های نمودار را تنظیم می‌کند
    $defaultWorksheetIndex = 0;
    # شیت کاری داده‌های نمودار را دریافت می‌کند
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # سری‌های جدید اضافه می‌کند
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # دسته‌های جدید اضافه می‌کند
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # سری اول نمودار را می‌گیرد
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # اکنون داده‌های سری را پر می‌کند
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # رنگ پر کردن سری را تنظیم می‌کند
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # سری دوم نمودار را می‌گیرد
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # داده‌های سری را پر می‌کند
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # رنگ پر کردن سری را تنظیم می‌کند
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # برچسب‌های سفارشی برای هر دسته در سری جدید ایجاد می‌کند
    # اولین برچسب را تنظیم می‌کند تا نام دسته را نشان دهد
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # مقدار را برای برچسب سوم نشان می‌دهد
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # ارائه را همراه با نمودار ذخیره می‌کند
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای پراکنده**

نمودارهای پراکنده (که به عنوان نمودارهای پراکنده یا گراف‌های x-y نیز شناخته می‌شوند) معمولاً برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

شما ممکن است هنگام موارد زیر از یک نمودار پراکنده استفاده کنید:

* داده‌های عددی جفت‌دار دارید
* ۲ متغیر دارید که به‌خوبی با هم جفت می‌شوند
* می‌خواهید تعیین کنید آیا دو متغیر مرتبط هستند یا نه
* یک متغیر مستقل دارید که برای یک متغیر وابسته مقادیر متعددی دارد

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکنده </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکنده PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>مراحل:</em> ایجاد نمودار پراکنده ارائه PowerPoint </strong></a>

1. لطفاً مراحل ذکر شده در [ایجاد نمودارهای عادی](#creating-normal-charts) را دنبال کنید  
2. برای گام سوم، یک نمودار با برخی داده‌ها اضافه کنید و نوع نمودار خود را یکی از موارد زیر مشخص کنید  
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _نمودار پراکنده را نشان می‌دهد._  
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _نمودار پراکنده متصل به منحنی‌ها، با نشانگرهای داده._  
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _نمودار پراکنده متصل به منحنی‌ها، بدون نشانگرهای داده._  
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _نمودار پراکنده متصل به خطوط مستقیم، با نشانگرهای داده._  
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _نمودار پراکنده متصل به خطوط مستقیم، بدون نشانگرهای داده._  

این کد PHP نشان می‌دهد که چگونه نمودارهای پراکنده با سری‌های مختلف نشانگر ایجاد کنید:

```php
  # یک نمونه از کلاس ارائه ایجاد می‌کند که نمایانگر فایل PPTX است
  $pres = new Presentation();
  try {
    # به اولین اسلاید دسترسی می‌یابد
    $slide = $pres->getSlides()->get_Item(0);
    # نمودار پیش‌فرض را ایجاد می‌کند
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # ایندکس شیت کاری داده‌های پیش‌فرض نمودار را دریافت می‌کند
    $defaultWorksheetIndex = 0;
    # شیت کاری داده‌های نمودار را دریافت می‌کند
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # سری نمونه‌ای را حذف می‌کند
    $chart->getChartData()->getSeries()->clear();
    # سری‌های جدید را اضافه می‌کند
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # اولین سری نمودار را می‌گیرد
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # نقطه جدید (1:3) را به سری اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # نقطه جدید (2:10) را اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # نوع سری را تغییر می‌دهد
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # نشانگر سری نمودار را تغییر می‌دهد
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # سری دوم نمودار را می‌گیرد
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # نقطه جدید (5:2) را در آن اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # نقطه جدید (3:1) را اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # نقطه جدید (2:2) را اضافه می‌کند
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # نقطه جدید (5:1) را اضافه می‌کند
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

نمودارهای دایره‌ای بهترین استفاده برای نشان دادن رابطهٔ بخش به کل در داده‌ها هستند، به‌ویژه زمانی که داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی باشد. با این حال، اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بهتر باشد به‌جای آن از نمودار ستونی استفاده کنید.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>مراحل:</em> ایجاد نمودار دایره‌ای ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر (در این حالت، [ChartType].Pie) اضافه کنید.  
4. به [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.  
8. نقاط جدید برای نمودارها اضافه کنید و رنگ‌های سفارشی برای بخش‌های نمودار دایره‌ای تعیین کنید.  
9. برچسب‌ها برای سری‌ها تنظیم کنید.  
10. خطوط راهنمای برای برچسب‌های سری تنظیم کنید.  
11. زاویهٔ چرخش اسلایدهای نمودار دایره‌ای را تنظیم کنید.  
12. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه یک نمودار دایره‌ای ایجاد کنید:

```php
  # یک نمونه از کلاس ارائه ایجاد می‌کند که نمایانگر فایل PPTX است
  $pres = new Presentation();
  try {
    # به اولین اسلاید دسترسی می‌یابد
    $slides = $pres->getSlides()->get_Item(0);
    # یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # عنوان نمودار را تنظیم می‌کند
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # سری اول را تنظیم می‌کند تا مقادیر را نشان دهد
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # ایندکس شیت کاری داده‌های نمودار را تنظیم می‌کند
    $defaultWorksheetIndex = 0;
    # شیت کاری داده‌های نمودار را دریافت می‌کند
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # دسته‌های جدید اضافه می‌کند
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # سری‌های جدید اضافه می‌کند
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # داده‌های سری را پر می‌کند
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # در نسخه جدید کار نمی‌کند
    # اضافه کردن نقاط جدید و تنظیم رنگ قطعات
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # مرز قطعه را تنظیم می‌کند
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # مرز قطعه را تنظیم می‌کند
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # مرز قطعه را تنظیم می‌کند
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # برچسب‌های سفارشی برای هر دسته در سری جدید ایجاد می‌کند
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
    # خطوط رهنما برای نمودار نشان داده می‌شود
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # زاویهٔ چرخش قطعات نمودار دایره‌ای را تنظیم می‌کند
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

نمودارهای خطی (که به عنوان گراف‌های خطی نیز شناخته می‌شوند) بهترین استفاده را در موقعیت‌هایی دارند که می‌خواهید تغییرات مقدار در طول زمان را نشان دهید. با استفاده از یک نمودار خطی، می‌توانید مقدار زیادی داده را به‌صورت همزمان مقایسه کنید، تغییرات و روندها را در طول زمان ردیابی کنید، ناهنجاری‌ها در سری‌های داده را برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر (در این حالت، `ChartType::Line`) اضافه کنید.  
4. به IChartDataWorkbook داده‌های نمودار دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.  
8. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه یک نمودار خطی ایجاد کنید:

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

به‌طور پیش‌فرض، نقاط در یک نمودار خطی با خطوط مستقیم و پیوسته به‌هم متصل هستند. اگر می‌خواهید نقاط به‌جای خطوط پیوسته با خط نقطه‌خطی (dash) به‌هم متصل شوند، می‌توانید نوع dash دلخواه خود را به این شکل مشخص کنید:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **ایجاد نمودارهای نقشه درختی**

نمودارهای نقشه درختی بهترین استفاده برای داده‌های فروش را دارند زمانی که می‌خواهید اندازهٔ نسبی دسته‌های داده را نشان دهید و (به‌همین‌صورت) به‌سرعت توجه را به مواردی که سهم بزرگی در هر دسته دارند جلب کنید.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه درختی </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه درختی PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه درختی ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر (در این حالت، [ChartType].TreeMap) اضافه کنید.  
4. به [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.  
8. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه یک نمودار نقشه درختی ایجاد کنید:

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

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>مراحل:</em> ایجاد نمودار سهام </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>مراحل:</em> ایجاد نمودار سهام PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>مراحل:</em> ایجاد نمودار سهام ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را بر اساس ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType].OpenHighLowClose) اضافه کنید.  
4. به [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.  
8. قالب خطوط HiLowLines را مشخص کنید.  
9. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

نمونه کد PHP برای ایجاد یک نمودار سهام:

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
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای جعبه‌ای و ویسکر**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار جعبه‌ای و ویسکر </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار جعبه‌ای و ویسکر PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>مراحل:</em> ایجاد نمودار جعبه‌ای و ویسکر ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType].BoxAndWhisker) اضافه کنید.  
4. به [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.  
8. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه یک نمودار جعبه‌ای و ویسکر ایجاد کنید:

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

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>مراحل:</em> ایجاد نمودار قیفی </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>مراحل:</em> ایجاد نمودار قیفی PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>مراحل:</em> ایجاد نمودار قیفی ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType].Funnel) اضافه کنید.  
4. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

کد PHP نشان می‌دهد که چگونه یک نمودار قیفی ایجاد کنید:

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

### **ایجاد نمودارهای خورشیدشکل**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار خورشیدشکل </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار خورشیدشکل PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>مراحل:</em> ایجاد نمودار خورشیدشکل ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر (در این حالت، [ChartType].sunburst) اضافه کنید.  
4. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه یک نمودار خورشیدشکل ایجاد کنید:

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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>مراحل:</em> ایجاد نمودار هیستوگرام </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>مراحل:</em> ایجاد نمودار هیستوگرام PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>مراحل:</em> ایجاد نمودار هیستوگرام ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType].Histogram) اضافه کنید.  
4. به [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه یک نمودار هیستوگرام ایجاد کنید:

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

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار رادار </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار رادار PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>مراحل:</em> ایجاد نمودار رادار ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار با برخی داده‌ها و نوع موردنظر (`ChartType::Radar`) اضافه کنید.  
4. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه یک نمودار رادار ایجاد کنید:

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

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>مراحل:</em> ایجاد نمودار چنددسته‌ای </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>مراحل:</em> ایجاد نمودار چنددسته‌ای PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>مراحل:</em> ایجاد نمودار چنددسته‌ای ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار با داده‌های پیش‌فرض و نوع موردنظر ([ChartType].ClusteredColumn) اضافه کنید.  
4. به [ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/) دسترسی پیدا کنید.  
5. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
6. سری‌ها و دسته‌های جدید اضافه کنید.  
7. داده‌های جدیدی برای سری‌های نمودار اضافه کنید.  
8. ارائهٔ اصلاح شده را به صورت فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه یک نمودار چنددسته‌ای ایجاد کنید:

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
    # افزودن سری‌ها
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # ذخیرهٔ ارائه با نمودار
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ایجاد نمودارهای نقشه**

نمودار نقشه تصویری از یک منطقه حاوی داده‌ها است. نمودارهای نقشه بهترین استفاده برای مقایسه داده‌ها یا مقادیر در سرتاسر مناطق جغرافیایی دارند.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>مراحل:</em> ایجاد نمودار نقشه ارائه PowerPoint </strong></a>

این کد PHP نشان می‌دهد که چگونه یک نمودار نقشه ایجاد کنید:

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

نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا نکات برجسته، مقایسه یا بررسی اختلافات بین دو یا چند مجموعه داده را انجام دهید و به شناسایی روابط بین آن‌ها کمک کند.

![نمودار ترکیبی](combination_chart.png)

کد PHP زیر نشان می‌دهد که چگونه نمودار ترکیبی نشان داده‌شده در بالا را در یک ارائه PowerPoint ایجاد کنید:

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
    
    // افسانه نمودار را تنظیم می‌کند.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // دسته‌های جدید اضافه می‌کند.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // اولین سری را اضافه می‌کند.
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

    // رنگ خطوط شبکهٔ عمودی اصلی را تنظیم می‌کند.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // محور افقی ثانویه را تنظیم می‌کند.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // محور عمودی ثانویه را تنظیم می‌کند.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>مراحل:</em> به‌روزرسانی نمودار PowerPoint </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>مراحل:</em> به‌روزرسانی نمودار ارائه </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>مراحل:</em> به‌روزرسانی نمودار ارائه PowerPoint </strong></a>

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید که نمایانگر ارائه‌ای است که شامل نموداری است که می‌خواهید به‌روزرسانی کنید.  
2. مرجع یک اسلاید را با استفاده از ایندکس آن به دست آورید.  
3. در تمام اشکال پیمایش کنید تا نمودار موردنظر را پیدا کنید.  
4. به ورک‌شیت داده‌های نمودار دسترسی پیدا کنید.  
5. داده‌های سری‌های نمودار را با تغییر مقادیر سری‌ها اصلاح کنید.  
6. یک سری جدید اضافه کنید و داده‌ها را در آن پر کنید.  
7. ارائه اصلاح‌شده را به صورت فایل PPTX بنویسید.  

```php
  $pres = new Presentation();
  try {
    # دسترسی به اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # دریافت نمودار با داده‌های پیش‌فرض
    $chart = $sld->getShapes()->get_Item(0);
    # تنظیم ایندکس شیت کاری داده‌های نمودار
    $defaultWorksheetIndex = 0;
    # دریافت شیت کاری داده‌های نمودار
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # تغییر نام دسته‌بندی نمودار
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # گرفتن اولین سری نمودار
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # حالا به‌روزرسانی داده‌های سری
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1"); // در حال تغییر نام سری
    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # گرفتن سری دوم نمودار
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # حالا به‌روزرسانی داده‌های سری
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2"); // در حال تغییر نام سری
    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # حالا، افزودن یک سری جدید
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # گرفتن سری سوم نمودار
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # حالا پر کردن داده‌های سری
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # ذخیرهٔ ارائه با نمودار
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم محدوده داده برای نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید که نمایانگر ارائه‌ای است که شامل نمودار است.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. در تمام اشکال پیمایش کنید تا نمودار موردنظر را پیدا کنید.  
4. به داده‌های نمودار دسترسی پیدا کنید و محدوده را تنظیم کنید.  
5. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.  

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

هنگامی که از نشانگر پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌طور خودکار نماد نشانگر پیش‌فرض متفاوتی دریافت می‌کند.

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
    # دریافت سری دوم نمودار
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

## **سوالات متداول**

**کدام انواع نمودار توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides طیف گسترده‌ای از [انواع نمودار](https://reference.aspose.com/slides/fa/php-java/aspose.slides/charttype/) را پشتیبانی می‌کند، از جمله نوار، خط، دایره‌ای، مساحت، پراکنده، هیستوگرام، رادار و بسیاری دیگر. این انعطاف‌پذیری به شما اجازه می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای تصویری‌سازی داده‌هایتان انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن یک نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد می‌کنید، اسلاید موردنظر را با استفاده از ایندکس آن دریافت می‌کنید و سپس متدی را برای افزودن نمودار فراخوانی می‌کنید که نوع نمودار و داده‌های اولیه را مشخص می‌کند. این فرآیند نمودار را به‌صورت مستقیم در ارائه شما ادغام می‌نماید.

**چگونه می‌توانم داده‌های نمایش‌ داده‌شده در یک نمودار را به‌روز کنم؟**

می‌توانید داده‌های یک نمودار را با دسترسی به ورک‌شیت داده‌های آن ([ChartDataWorkbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdataworkbook/))، حذف سری‌ها و دسته‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود به‌روزرسانی کنید. این امکان را می‌دهد تا نمودار را برای بازتاب جدیدترین داده‌ها تازه کنید.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر [عناصر قالب‌بندی](/slides/fa/php-java/chart-entities/) را تغییر دهید تا ظاهر نمودار را مطابق نیازهای طراحی خاص خود تنظیم کنید.