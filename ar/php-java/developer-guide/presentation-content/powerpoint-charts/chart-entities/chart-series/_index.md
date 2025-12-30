---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام PHP
linktitle: سلاسل البيانات
type: docs
url: /ar/php-java/chart-series/
keywords:
- سلاسل المخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة البيانات
- فجوة السلسلة
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل بيانات المخطط في PHP لبرنامج PowerPoint (PPT/PPTX) مع أمثلة عملية على الشيفرة وأفضل الممارسات لتحسين عروض البيانات الخاصة بك."
---

المجموعة هي صف أو عمود من الأرقام يتم رسمه في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلاسل المخطط**

مع خاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) يمكنك تحديد مقدار تداخل الأشرطة والأعمدة في مخطط ثنائي الأبعاد (النطاق: -100 إلى 100). تنطبق هذه الخاصية على جميع سلاسل مجموعة السلسلة الأصلية: هذه نسخة من خاصية المجموعة المناسبة. وبالتالي، هذه الخاصية للقراءة فقط.

استخدم الخاصية القابلة للقراءة والكتابة `ParentSeriesGroup.Overlap` لتعيين القيمة المفضلة لـ `Overlap`.

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف مخطط أعمدة مجمّع إلى شريحة.
1. احصل على أول سلسلة مخطط.
1. احصل على `ParentSeriesGroup` للسلسلة واضبط قيمة التداخل المفضلة للسلسلة.
1. احفظ العرض المعدل إلى ملف PPTX.

هذا الكود PHP يوضح لك كيفية تعيين التداخل لسلسلة مخطط:
```php
  $pres = new Presentation();
  try {
    # يضيف المخطط
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
تتيح لك Aspose.Slides for PHP via Java تغيير لون السلسلة بهذه الطريقة:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف مخططًا إلى الشريحة.
1. احصل على السلسلة التي تريد تغيير لونها.
1. اضبط نوع التعبئة ولون التعبئة المفضلين.
1. احفظ العرض المعدل.

هذا الكود PHP يوضح لك كيفية تغيير لون السلسلة:
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
تتيح لك Aspose.Slides for PHP via Java تغيير لون فئة السلسلة بهذه الطريقة:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. أضف مخططًا إلى الشريحة.
1. احصل على فئة السلسلة التي تريد تغيير لونها.
1. اضبط نوع التعبئة ولون التعبئة المفضلين.
1. احفظ العرض المعدل.

هذا الكود يوضح لك كيفية تغيير لون فئة السلسلة:
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

افتراضيًا، تكون أسماء وسيلة الإيضاح للمخطط هي محتويات الخلايا فوق كل عمود أو صف من البيانات.

في مثالنا (الصورة النموذجية)،

* الأعمدة هي *Series 1* و *Series 2* و *Series 3*؛
* الصفوف هي *Category 1* و *Category 2* و *Category 3* و *Category 4*.

تتيح لك Aspose.Slides for PHP via Java تحديث أو تغيير اسم السلسلة في بيانات المخطط والوسيلة الإيضاحية.

هذا الكود PHP يوضح لك كيفية تغيير اسم السلسلة في بيانات مخططها `ChartDataWorkbook`:
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


هذا الكود PHP يوضح لك كيفية تغيير اسم السلسلة في وسيلة الإيضاح عبر `Series`:
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


## **تعيين لون تعبئة سلسلة المخطط**

تتيح لك Aspose.Slides for PHP via Java تعيين لون التعبئة التلقائي لسلاسل المخطط داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على مرجع الشريحة بواسطة فهرسها.
1. أضف مخططًا ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. احصل على سلسلة المخطط واضبط لون التعبئة إلى Automatic.
1. احفظ العرض إلى ملف PPTX.

هذا الكود PHP يوضح لك كيفية تعيين لون التعبئة التلقائي لسلسلة مخطط:
```php
  $pres = new Presentation();
  try {
    # ينشئ مخطط أعمدة مجموعة
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


## **تعيين تعبئة معكوسة لسلسلة مخطط**
تتيح لك Aspose.Slides تعيين تعبئة معكوسة لسلاسل المخطط داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على مرجع الشريحة بواسطة فهرسها.
1. أضف مخططًا ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. احصل على سلسلة المخطط واضبط لون التعبئة إلى Invert.
1. احفظ العرض إلى ملف PPTX.

هذا الكود PHP يوضح العملية:
```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # يضيف سلاسل جديدة وفئات
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # يأخذ أول سلسلة في المخطط ويملأ بيانات السلسلة.
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


## **تعيين عكس للسلسلة عندما تكون القيمة سالبة**
تتيح لك Aspose.Slides تعيين العكس عبر الخاصيتين `IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative`. عندما يتم تعيين العكس باستخدام هاتين الخاصيتين، يعكس نقطة البيانات ألوانها عندما تحصل على قيمة سالبة.

هذا الكود PHP يوضح العملية:
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


## **مسح بيانات نقطة معينة**
تتيح لك Aspose.Slides for PHP via Java مسح بيانات `DataPoints` لسلسلة مخطط معينة بهذه الطريقة:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع شريحة عبر فهرستها.
3. احصل على مرجع مخطط عبر فهرسته.
4. تكرار عبر جميع `DataPoints` للمخطط واضبط `XValue` و `YValue` إلى null.
5. مسح جميع `DataPoints` للسلسلة المحددة.
6. احفظ العرض المعدل إلى ملف PPTX.

هذا الكود PHP يوضح العملية:
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
تتيح لك Aspose.Slides for PHP via Java تعيين عرض الفجوة لسلسلة عبر خاصية **`GapWidth`** بهذه الطريقة:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على الشريحة الأولى.
1. أضف مخططًا ببيانات افتراضية.
1. احصل على أي سلسلة مخطط.
1. اضبط الخاصية `GapWidth`.
1. احفظ العرض المعدل إلى ملف PPTX.

هذا الكود يوضح لك كيفية تعيين عرض الفجوة لسلسلة:
```php
  # ينشئ عرض تقديمي فارغ
  $pres = new Presentation();
  try {
    # يصل إلى الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # يضيف مخططًا ببيانات افتراضية
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # يحدد فهرس صفحة بيانات المخطط
    $defaultWorksheetIndex = 0;
    # يحصل على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # يضيف سلسلة
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # يضيف فئات
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # يأخذ السلسلة الثانية في المخطط
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # يملأ بيانات السلسلة
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


## **الأسئلة المتكررة**

**هل هناك حد لعدد السلاسل التي يمكن لمخطط واحد أن يحتويها؟**

لا تفرض Aspose.Slides حدًا ثابتًا لعدد السلاسل التي تضيفها. الحد العملي يحدده وضوح المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة واحدة متقاربة جدًا أو متباعدة جدًا؟**

اضبط إعداد `GapWidth` لتلك السلسلة (أو مجموعة السلسلة الأصلية). زيادة القيمة توسّع المسافة بين الأعمدة، بينما تقليلها تقربها من بعضها.