---
title: محور المخطط
type: docs
url: /php-java/chart-axis/
keywords: "محور المخطط في PowerPoint، المخططات التقديمية، Java، التلاعب بمحور المخطط، بيانات المخطط"
description: "كيفية تعديل محور المخطط في PowerPoint"
---


## **استخراج القيم القصوى على المحور العمودي في المخططات**
يسمح لك Aspose.Slides ل PHP عبر Java بالحصول على القيم الدنيا والقصوى على محور عمودي. اتبع هذه الخطوات:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الحصول على القيمة القصوى الفعلية على المحور.
1. الحصول على القيمة الدنيا الفعلية على المحور.
1. الحصول على الوحدة الكبرى الفعلية على المحور.
1. الحصول على الوحدة الصغرى الفعلية على المحور.
1. الحصول على مقياس الوحدة الكبرى الفعلي على المحور.
1. الحصول على مقياس الوحدة الصغرى الفعلي على المحور.

هذا الكود النموذجي—تنفيذ الخطوات أعلاه—يوضح لك كيفية الحصول على القيم المطلوبة:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # حفظ العرض التقديمي
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تبديل البيانات بين المحاور**
يسمح لك Aspose.Slides بتبديل البيانات بسرعة بين المحاور—البيانات represented على المحور العمودي (محور y) تنتقل إلى المحور الأفقي (محور x) والعكس صحيح.

يظهر لك هذا الكود PHP كيفية إجراء مهمة تبديل البيانات بين المحاور على مخطط:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # يبدل الصفوف والأعمدة
    $chart->getChartData()->switchRowColumn();
    # حفظ العرض التقديمي
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إلغاء تنشيط المحور العمودي لمخططات الخطوط**

يظهر لك هذا الكود PHP كيفية إخفاء المحور العمودي لمخطط خط:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إلغاء تنشيط المحور الأفقي لمخططات الخطوط**

يعرض هذا الكود كيفية إخفاء المحور الأفقي لمخطط خط:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغيير محور الفئة**

باستخدام خاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**تاريخ** أو **نص**). يوضح هذا الكود العملية:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **تعيين تنسيق التاريخ لقيمة محور الفئة**
يسمح لك Aspose.Slides ل PHP عبر Java بتعيين تنسيق التاريخ لقيمة محور الفئة. يتم توضيح العملية في هذا الكود PHP:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **تعيين زاوية الدوران لعناوين محاور المخطط**
يسمح لك Aspose.Slides ل PHP عبر Java بتعيين زاوية الدوران لعنوان محور المخطط. يوضح هذا الكود PHP العملية:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين محور الوضع في محور الفئة أو القيمة**
يسمح لك Aspose.Slides ل PHP عبر Java بتعيين محور الوضع في محور الفئة أو القيمة. يُظهر لك هذا الكود PHP كيفية إجراء المهمة:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تمكين عرض وحدة التسمية على محور قيم المخطط**
يسمح لك Aspose.Slides ل PHP عبر Java بتكوين مخطط لإظهار وحدة تسمية على محور قيم المخطط. يوضح هذا الكود PHP العملية:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```