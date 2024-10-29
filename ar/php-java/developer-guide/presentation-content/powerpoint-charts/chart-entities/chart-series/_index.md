---
title: سلسلة الرسم البياني
type: docs
url: /ar/php-java/chart-series/
keywords: "سلسلة الرسم البياني، لون السلسلة، عرض تقديمي PowerPoint، Java، Aspose.Slides ل PHP عبر Java"
description: "سلسلة الرسم البياني في عروض PowerPoint "
---

السلسلة هي صف أو عمود من الأرقام موضوع في رسم بياني.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة الرسم البياني**

مع خاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap)، يمكنك تحديد مقدار تداخل الأعمدة والصفوف في رسم بياني ثنائي الأبعاد (مدى: -100 إلى 100). تنطبق هذه الخاصية على جميع السلاسل في مجموعة السلاسل الأصلية: هذه هي إسقاط للخاصية المناسبة للمجموعة. لذلك، هذه الخاصية للقراءة فقط.

استخدم خاصية `ParentSeriesGroup.Overlap` للقراءة/الكتابة لتعيين القيمة المفضلة لديك لـ `Overlap`.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف رسمًا بيانيًا عمودياً متجمعًا على شريحة.
1. الوصول إلى أول سلسلة رسم بياني.
1. الوصول إلى `ParentSeriesGroup` لسلسلة الرسم البياني وتعيين قيمة التداخل المفضلة لديك للسلسلة.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يوضح هذا الرمز PHP كيفية تعيين التداخل لسلسلة الرسم البياني:

```php
  $pres = new Presentation();
  try {
    # يضيف الرسم البياني
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # يحدد تداخل السلسلة
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # يكتب ملف العرض التقديمي إلى القرص
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغيير لون السلسلة**
يسمح Aspose.Slides ل PHP عبر Java بتغيير لون سلسلة بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف رسمًا بيانيًا على الشريحة.
1. الوصول إلى السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
1. حفظ العرض التقديمي المعدل.

يوضح هذا الرمز PHP كيفية تغيير لون سلسلة:

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

## **تغيير لون فئة السلسلة**
يسمح Aspose.Slides ل PHP عبر Java بتغيير لون فئة السلسلة بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف رسمًا بيانيًا على الشريحة.
1. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
1. حفظ العرض التقديمي المعدل.

يوضح هذا الرمز كيفية تغيير لون فئة السلسلة:

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

## **تغيير اسم السلسلة** 

بشكل افتراضي، أسماء الأسطورة للرسم البياني هي محتويات الخلايا فوق كل عمود أو صف من البيانات.

في مثالنا (صورة نموذجية)، 

* الأعمدة هي *السلسلة 1، السلسلة 2،* و *السلسلة 3*؛
* الصفوف هي *الفئة 1، الفئة 2، الفئة 3،* و *الفئة 4.* 

يسمح Aspose.Slides ل PHP عبر Java بتحديث أو تغيير اسم سلسلة في بيانات الرسم البياني والأسطورة.

يوضح هذا الرمز PHP كيفية تغيير اسم سلسلة في بيانات الرسم البياني `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("اسم جديد");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

يوضح هذا الرمز PHP كيفية تغيير اسم سلسلة في أسطورتها من خلال `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("اسم جديد");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين لون تعبئة سلسلة الرسم البياني**

يسمح Aspose.Slides ل PHP عبر Java بتعيين لون التعبئة التلقائي لسلسلة الرسم البياني داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على مرجع شريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا ببيانات افتراضية بناءً على نوعك المفضل (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. الوصول إلى سلسلة الرسم البياني وتعيين لون التعبئة إلى تلقائي.
1. حفظ العرض التقديمي إلى ملف PPTX.

يوضح هذا الرمز PHP كيفية تعيين لون التعبئة التلقائي لسلسلة الرسم البياني:

```php
  $pres = new Presentation();
  try {
    # ينشئ رسمًا بيانيًا عمودياً متجمعًا
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # يحدد تنسيق تعبئة السلسلة إلى تلقائي
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # يكتب ملف العرض التقديمي إلى القرص
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين ألوان تعبئة السلسلة المنعكسة**
يسمح Aspose.Slides بتعيين لون التعبئة المنعكسة لسلسلة الرسم البياني داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على مرجع شريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا ببيانات افتراضية بناءً على نوعك المفضل (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. الوصول إلى سلسلة الرسم البياني وتعيين لون التعبئة إلى الانعكاس.
1. حفظ العرض التقديمي إلى ملف PPTX.

يوضح هذا الرمز PHP العملية:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # يضيف سلاسل وفئات جديدة
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "السلسلة 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "الفئة 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "الفئة 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "الفئة 3"));
    # يأخذ السلسلة الأولى ويملأ بيانات سلسلة.
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

## **تعيين السلسلة للانعكاس عندما تكون القيمة سالبة**
يسمح Aspose.Slides بتعيين الانعكاسات من خلال الخصائص `IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative`. عند تعيين الانعكاس باستخدام الخصائص، يقوم نقطة البيانات بعكس ألوانها عندما تتلقى قيمة سالبة.

يوضح هذا الرمز PHP العملية:

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

## **مسح بيانات نقاط البيانات المحددة**
يسمح Aspose.Slides ل PHP عبر Java بمسح بيانات `DataPoints` لسلسلة الرسم البياني المحددة بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع شريحة من خلال فهرسها.
3. احصل على مرجع لرسم بياني من خلال فهرسه.
4. قم بالتكرار عبر جميع `DataPoints` للرسم البياني وحدد `XValue` و `YValue` على null.
5. امسح جميع `DataPoints` لسلسلة الرسم البياني المحددة.
6. اكتب العرض التقديمي المعدل إلى ملف PPTX.

يوضح هذا الرمز PHP العملية:

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

## **تعيين عرض الفجوة للسلسلة**
يسمح Aspose.Slides ل PHP عبر Java بتعيين عرض فجوة السلسلة من خلال خاصية **`GapWidth`** بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني مع بيانات افتراضية.
1. الوصول إلى أي سلسلة رسم بياني.
1. تعيين خاصية `GapWidth`.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يوضح هذا الرمز كيفية تعيين عرض فجوة سلسلة:

```php
  # ينشئ عرض تقديمي فارغ
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # يضيف رسمًا بيانيًا ببيانات افتراضية
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # يحدد فهرس ورقة بيانات الرسم البياني
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة بيانات الرسم البياني
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # إضافة السلاسل
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "السلسلة 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "السلسلة 2"), $chart->getType());
    # إضافة الفئات
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "الفئة 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "الفئة 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "الفئة 3"));
    # يأخذ السلسلة الثانية
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # يمتلئ بيانات السلسلة
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # يحدد قيمة GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # يحفظ العرض التقديمي إلى القرص
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```