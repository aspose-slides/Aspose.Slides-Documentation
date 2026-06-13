---
title: بهینه‌سازی محاسبات نمودار برای ارائه‌ها در PHP
linktitle: محاسبات نمودار
type: docs
weight: 50
url: /fa/php-java/chart-calculations/
keywords:
- محاسبه نمودار
- عناصر نمودار
- موقعیت عنصر
- موقعیت واقعی
- عنصر فرزند
- عنصر والد
- مقدارهای نمودار
- مقدار واقعی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "محاسبات نمودار، به‌روزرسانی داده‌ها و کنترل دقت را در Aspose.Slides برای PHP از طریق Java برای فایل‌های PPT و PPTX درک کنید، همراه با مثال‌های کد عملی."
---
## **نمای کلی**

Aspose.Slides APIهایی برای کار با محاسبات نمودار و داده‌های چیدمان در ارائه‌ها فراهم می‌کند. این مقاله نشان می‌دهد چگونه مقادیر واقعی عناصر نمودار، از جمله موقعیت و اندازه واقعی عناصر و مقادیر واقعی محورها را بازیابی کنید. همچنین توضیح می‌دهد که این مقادیر پس از اعتبارسنجی چیدمان نمودار پر می‌شوند.

علاوه بر این، مقاله نحوه دریافت موقعیت واقعی عناصر والد نمودار و نحوه پنهان کردن اجزای نمودار مانند عنوان، محورها، راهنما و خطوط توری را نشان می‌دهد. این مثال‌ها به شما کمک می‌کنند تا اطلاعات چیدمان نمودار را بررسی کنید و به‌صورت برنامه‌نویسی قابلیت دیده شدن عناصر نمودار را در ارائه‌های PowerPoint کنترل کنید.

## **محاسبه مقادیر واقعی عناصر نمودار**
Aspose.Slides for PHP via Java یک API ساده برای دریافت این ویژگی‌ها فراهم می‌کند. متدهای کلاس [Axis](https://reference.aspose.com/slides/fa/php-java/aspose.slides/axis/) اطلاعاتی درباره موقعیت واقعی عنصر محور نمودار ارائه می‌دهند ([getActualMaxValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/axis/getactualmaxvalue/)، [getActualMinValue](https://reference.aspose.com/slides/fa/php-java/aspose.slides/axis/getactualminvalue/)، [getActualMajorUnit](https://reference.aspose.com/slides/fa/php-java/aspose.slides/axis/getactualmajorunit/)، [getActualMinorUnit](https://reference.aspose.com/slides/fa/php-java/aspose.slides/axis/getactualminorunit/)، [getActualMajorUnitScale](https://reference.aspose.com/slides/fa/php-java/aspose.slides/axis/getactualmajorunitscale/)، [getActualMinorUnitScale](https://reference.aspose.com/slides/fa/php-java/aspose.slides/axis/getactualminorunitscale/)). برای پر کردن این ویژگی‌ها با مقادیر واقعی، باید پیشاپیش متد [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/validatechartlayout/) را فراخوانی کنید.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **محاسبه موقعیت واقعی عناصر والد نمودار**
Aspose.Slides for PHP via Java یک API ساده برای دریافت این ویژگی‌ها فراهم می‌کند. متدهای کلاس `ActualLayout` اطلاعاتی درباره موقعیت واقعی عنصر والد نمودار ارائه می‌دهند (`getActualX`، `getActualY`، `getActualWidth`، `getActualHeight`). برای پر کردن این ویژگی‌ها با مقادیر واقعی، باید پیشاپیش متد [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/validatechartlayout/) را فراخوانی کنید.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پنهان کردن عناصر نمودار**
این بخش به شما کمک می‌کند تا نحوه پنهان کردن اطلاعات از نمودار را درک کنید. با استفاده از Aspose.Slides for PHP via Java می‌توانید **عنوان، محور عمودی، محور افقی** و **خطوط توری** را از نمودار پنهان کنید. مثال کد زیر نشان می‌دهد چگونه از این ویژگی‌ها استفاده کنید.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # پنهان کردن عنوان نمودار
    $chart->setTitle(false);
    # /پنهان کردن محور مقادیر
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # قابلیت نمایش محور دسته‌بندی
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # پنهان کردن راهنما
    $chart->setLegend(false);
    # پنهان کردن خطوط توری اصلی
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # تنظیم رنگ خط سری
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا کتاب‌های کاری خارجی Excel به عنوان منبع داده عمل می‌کنند و این بر محاسبه مجدد چه تأثیری دارد؟**

بله. یک نمودار می‌تواند به یک کتاب‌کاری خارجی ارجاع دهد: وقتی منبع خارجی را متصل یا تازه می‌کنید، فرمول‌ها و مقادیر از همان کتاب‌کار گرفته می‌شود و نمودار در حین عملیات باز/ویرایش به‌روزرسانی‌ها را منعکس می‌کند. API به شما اجازه می‌دهد مسیر کتاب‌کار خارجی را با متد [specify the external workbook](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/setexternalworkbook/) مشخص کنید و داده‌های پیوند‌شده را مدیریت کنید.

**آیا می‌توانم خطوط روند را بدون پیاده‌سازی رگرسیون به‌صورت دستی محاسبه و نمایش دهم؟**

بله. [Trendlines](/slides/fa/php-java/trend-line/) (خطی، نمایی و سایر انواع) توسط Aspose.Slides اضافه و به‌روزرسانی می‌شوند؛ پارامترهای آن‌ها به‌صورت خودکار از داده‌های سری‌ها محاسبه می‌شوند، بنابراین نیازی به پیاده‌سازی محاسبات خودتان نیست.

**اگر یک ارائه شامل چندین نمودار با لینک‌های خارجی باشد، آیا می‌توانم کنترل کنم که هر نمودار از کدام کتاب‌کار خارجی برای مقادیر محاسبه‌شده استفاده کند؟**

بله. هر نمودار می‌تواند به کتاب‌کار خارجی خاص خود ارجاع دهد، یا می‌توانید برای هر نمودار به‌صورت مستقل یک کتاب‌کار خارجی را ایجاد یا جایگزین کنید بدون اینکه بر دیگران تأثیر بگذارد.