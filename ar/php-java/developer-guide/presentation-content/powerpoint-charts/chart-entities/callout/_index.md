---
title: إدارة الملاحظات الجانبية في مخططات العرض التقديمي باستخدام PHP
linktitle: ملاحظة جانبية
type: docs
url: /ar/php-java/callout/
keywords:
- ملاحظة جانبية للمخطط
- استخدام ملاحظة جانبية
- تسمية البيانات
- تنسيق التسمية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتنسيق الملاحظات الجانبية في Aspose.Slides لل PHP عبر Java مع أمثلة شفرة مختصرة، متوافقة مع PPT و PPTX لأتمتة سير عمل العروض التقديمية."
---

## **استخدام الملاحظات الجانبية**
تمت إضافة طريقتين جديدتين [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) و [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/php-java/aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) إلى الفئة [DataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat) والواجهة [IDataLabelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/idatalabelformat). تحدد هذه الطرق ما إذا كانت تسمية البيانات للمخطط المحدد ستُعرض كـ callout للبيانات أو كتسمية بيانات.
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


## **تعيين ملاحظة جانبية لمخطط الدونات**
توفر مكتبة Aspose.Slides لـ PHP عبر Java دعمًا لتعيين شكل ملاحظة جانبية لتسمية بيانات السلسلة لمخطط الدونات. المثال التالي موضح أدناه.
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


## **الأسئلة المتكررة**

**هل يتم الحفاظ على الملاحظات الجانبية عند تحويل العرض التقديمي إلى PDF أو HTML5 أو SVG أو صور؟**

نعم. الملاحظات الجانبية هي جزء من عرض المخطط، لذلك عند تصدير إلى [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، [HTML5](/slides/ar/php-java/export-to-html5/)، [SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/)، أو [صور نقطية](/slides/ar/php-java/convert-powerpoint-to-png/)، يتم الحفاظ عليها مع تنسيق الشريحة.

**هل تعمل الخطوط المخصصة في الملاحظات الجانبية، وهل يمكن الحفاظ على مظهرها عند التصدير؟**

نعم. تدعم Aspose.Slides [تضمين الخطوط](/slides/ar/php-java/embedded-font/) في العرض التقديمي وتتحكم في تضمين الخطوط أثناء عمليات التصدير مثل [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، مما يضمن أن تبدو الملاحظات الجانبية متطابقة عبر الأنظمة المختلفة.