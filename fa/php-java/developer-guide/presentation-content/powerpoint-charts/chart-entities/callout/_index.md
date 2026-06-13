---
title: مدیریت حاشیه‌نویسی‌ها در نمودارهای ارائه با PHP
linktitle: حاشیه‌نویسی
type: docs
url: /fa/php-java/callout/
keywords:
- حاشیه‌نویسی نمودار
- استفاده از حاشیه‌نویسی
- برچسب داده
- قالب برچسب
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و استایل‌بندی حاشیه‌نویسی‌ها در Aspose.Slides برای PHP از طریق Java با مثال‌های کد مختصر، سازگار با PPT و PPTX برای خودکارسازی جریان کار ارائه."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با حاشیه‌نویسی‌ها برای برچسب‌های دادهٔ نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه از متد `setShowLabelAsDataCallout` برای نمایش برچسب‌ها به صورت حاشیه‌نویسی استفاده شود، چگونه تنظیمات برچسب‌های مربوط به حاشیه‌نویسی برای یک نمودار دونات پیکربندی شود، و اشاره می‌کند که حاشیه‌نویسی‌ها و ظاهر آنها هنگام صادر کردن ارائه‌ها به فرمت‌های PDF، HTML5، SVG و تصاویر رستر حفظ می‌شوند.

## **استفاده از حاشیه‌نویسی‌ها**
متدهای جدید [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) و [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) به کلاس [DataLabelFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/datalabelformat) اضافه شده‌اند. این متدها تعیین می‌کنند که آیا برچسب دادهٔ نمودار مشخص شده به صورت حاشیه‌نویسی یا به صورت برچسب داده نمایش داده شود.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 500, 400);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowLabelAsDataCallout(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->get_Item(2)->getDataLabelFormat()->setShowLabelAsDataCallout(false);
    $pres->save("DisplayCharts.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم حاشیه‌نویسی برای یک نمودار دونات**
Aspose.Slides برای PHP از طریق Java پشتیبانی از تنظیم شکل حاشیه‌نویسی برچسب دادهٔ سِری برای یک نمودار دونات را فراهم می‌کند. نمونهٔ زیر ارائه شده است.  

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Doughnut, 10, 10, 500, 500, false);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(false);
    $seriesIndex = 0;
    while ($seriesIndex < 15) {
      $series = $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, $seriesIndex + 1, "SERIES " . $seriesIndex), $chart->getType());
      $series->setExplosion(0);
      $series->getParentSeriesGroup()->setDoughnutHoleSize(20);
      $series->getParentSeriesGroup()->setFirstSliceAngle(351);
      $seriesIndex++;
    } 
    $categoryIndex = 0;
    while ($categoryIndex < 15) {
      $chart->getChartData()->getCategories()->add($workBook->getCell(0, $categoryIndex + 1, 0, "CATEGORY " . $categoryIndex));
      $i = 0;
      while ($i < java_values($chart->getChartData()->getSeries()->size())) {
        $iCS = $chart->getChartData()->getSeries()->get_Item($i);
        $dataPoint = $iCS->getDataPoints()->addDataPointForDoughnutSeries($workBook->getCell(0, $categoryIndex + 1, $i + 1, 1));
        $dataPoint->getFormat()->getFill()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
        $dataPoint->getFormat()->getLine()->setWidth(1);
        $dataPoint->getFormat()->getLine()->setStyle(LineStyle->Single);
        $dataPoint->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
        if ($i == java_values($chart->getChartData()->getSeries()->size()) - 1) {
          $lbl = $dataPoint->getLabel();
          $lbl->getTextFormat()->getTextBlockFormat()->setAutofitType(TextAutofitType::Shape);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setLatinFont(new FontData("DINPro-Bold"));
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(12);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
          $lbl->getDataLabelFormat()->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
          $lbl->getDataLabelFormat()->setShowValue(false);
          $lbl->getDataLabelFormat()->setShowCategoryName(true);
          $lbl->getDataLabelFormat()->setShowSeriesName(false);
          $lbl->getDataLabelFormat()->setShowLeaderLines(true);
          $lbl->getDataLabelFormat()->setShowLabelAsDataCallout(false);
          $chart->validateChartLayout();
          $lbl->setX($lbl->getX() + 0.5);
          $lbl->setY($lbl->getY() + 0.5);
        }
        $i++;
      } 
      $categoryIndex++;
    } 
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا حاشیه‌نویسی‌ها هنگام تبدیل ارائه به PDF، HTML5، SVG یا تصاویر حفظ می‌شوند؟**

بله. حاشیه‌نویسی‌ها بخشی از رندر نمودار هستند، بنابراین هنگام خروجی‌گیری به [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)، [HTML5](/slides/fa/php-java/export-to-html5/)، [SVG](/slides/fa/php-java/render-a-slide-as-an-svg-image/)، یا [تصاویر رستر](/slides/fa/php-java/convert-powerpoint-to-png/)، همراه با فرمت اسلاید حفظ می‌شوند.

**آیا فونت‌های سفارشی در حاشیه‌نویسی‌ها کار می‌کنند و آیا ظاهر آنها می‌تواند در هنگام خروجی‌گیری حفظ شود؟**

بله. Aspose.Slides از [قراردادن فونت‌ها](/slides/fa/php-java/embedded-font/) در ارائه پشتیبانی می‌کند و در زمان خروجی‌گیری مثل [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) کنترل می‌کند که فونت‌ها تعبیه شوند، به‌طوری‌که حاشیه‌نویسی‌ها در سیستم‌های مختلف یک شکل یکسان داشته باشند.