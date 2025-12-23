---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام PHP
linktitle: تسمية البيانات
type: docs
url: /ar/php-java/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موقع التسمية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java للحصول على شرائح أكثر جاذبية."
---

تُظهر تسميات البيانات في المخطط تفاصيل حول سلاسل بيانات المخطط أو النقاط البيانية الفردية. فهي تتيح للقراء تحديد سلاسل البيانات بسرعة وتُسهل فهم المخططات.

## **تحديد دقة البيانات في تسميات بيانات المخطط**

يعرض لك هذا الكود PHP كيفية تحديد دقة البيانات في تسمية بيانات المخطط:
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


## **عرض النسبة المئوية كتسميات**

تمكنك Aspose.Slides for PHP عبر Java من ضبط تسميات النسبة المئوية على المخططات المعروضة. يوضح لك هذا الكود PHP العملية:
```php
  # إنشاء مثال من فئة Presentation
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
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
    # يحفظ العرض التقديمي الذي يحتوي على المخطط
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **تعيين علامة النسبة المئوية مع تسميات بيانات المخطط**

يُظهر لك هذا الكود PHP كيفية تعيين علامة النسبة المئوية لتسمية بيانات المخطط:
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على مرجع الشريحة عبر الفهرس الخاص بها
    $slide = $pres->getSlides()->get_Item(0);
    # إنشاء مخطط PercentsStackedColumn على شريحة
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # تعيين NumberFormatLinkedToSource إلى false
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة العمل الخاصة ببيانات المخطط
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # إضافة سلسلة جديدة
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # تعيين لون التعبئة للسلسلة
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # تعيين خصائص LabelFormat
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # إضافة سلسلة جديدة
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # تعيين نوع التعبئة واللون
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # كتابة العرض التقديمي إلى القرص
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحديد مسافة التسمية من المحور**

يعرض لك هذا الكود PHP كيفية تحديد مسافة التسمية من المحور الفئوي عندما تتعامل مع مخطط مرسوم من المحاور:
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على مرجع الشريحة
    $sld = $pres->getSlides()->get_Item(0);
    # إنشاء مخطط على الشريحة
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # تعيين مسافة التسمية من المحور
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # كتابة العرض التقديمي إلى القرص
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ضبط موقع التسمية**

عندما تنشئ مخططًا لا يعتمد على أي محور مثل مخطط الفطيرة، قد تكون تسميات بيانات المخطط قريبة جدًا من حافته. في هذه الحالة، يجب ضبط موقع تسمية البيانات بحيث تُظهر خطوط الربط بوضوح.

يعرض لك هذا الكود PHP كيفية ضبط موقع التسمية في مخطط الفطيرة:
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

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات المكتظة؟**

استخدم وضعية التسمية التلقائية، خطوط الربط، وتقليل حجم الخط؛ وإذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للنقاط المتطرفة/الرئيسية.

**كيف يمكنني تعطيل التسميات للقيم صفر أو السلبية أو الفارغة فقط؟**

قم بفلترة نقاط البيانات قبل تفعيل التسميات واغلق العرض للقيم الصفرية أو السلبية أو القيم المفقودة وفق قاعدة محددة.

**كيف يمكنني ضمان تناسق نمط التسميات عند التصدير إلى PDF/الصور؟**

حدد الخطوط بوضوح (العائلة، الحجم) وتأكد من توفر الخط على جانب التجسيد لتجنب اللجوء إلى الخط الاحتياطي.