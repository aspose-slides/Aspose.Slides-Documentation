---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام PHP
linktitle: محور المخطط
type: docs
url: /ar/php-java/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
- المحور الأفقي
- تخصيص المحور
- تعديل المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides للـ PHP عبر Java لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصورات."
---

## **الحصول على القيم القصوى على المحور العمودي في المخططات**
Aspose.Slides for PHP via Java يتيح لك الحصول على القيم الدنيا والعليا على محور عمودي. اتبع هذه الخطوات:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الحصول على القيمة القصوى الفعلية للمحور.
1. الحصول على القيمة الدنيا الفعلية للمحور.
1. الحصول على الوحدة الرئيسية الفعلية للمحور.
1. الحصول على الوحدة الفرعية الفعلية للمحور.
1. الحصول على مقياس الوحدة الرئيسية الفعلي للمحور.
1. الحصول على مقياس الوحدة الفرعية الفعلي للمحور.

يعرض هذا المثال البرمجي—تنفيذ للخطوات السابقة—كيفية الحصول على القيم المطلوبة:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # يحفظ العرض التقديمي
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تبديل البيانات بين المحاور**
Aspose.Slides يتيح لك تبديل البيانات بين المحاور بسرعة—البيانات المعروضة على المحور العمودي (y-axis) تنتقل إلى المحور الأفقي (x-axis) والعكس بالعكس.

يظهر لك هذا الكود PHP كيفية تنفيذ مهمة تبديل البيانات بين المحاور في مخطط:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # يبدل الصفوف والأعمدة
    $chart->getChartData()->switchRowColumn();
    # يحفظ العرض التقديمي
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعطيل المحور العمودي لمخططات الخط**
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


## **تعطيل المحور الأفقي لمخططات الخط**
يظهر لك هذا الكود كيفية إخفاء المحور الأفقي لمخطط خط:
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
باستخدام الخاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). يُظهر هذا الكود العملية:
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


## **تعيين تنسيق التاريخ لقيم محور الفئة**
Aspose.Slides for PHP via Java يتيح لك تعيين تنسيق التاريخ لقيمة محور الفئة. يتم توضيح العملية في هذا الكود PHP:
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


## **تعيين زاوية الدوران لعنوان محور المخطط**
Aspose.Slides for PHP via Java يتيح لك تعيين زاوية الدوران لعنوان محور المخطط. يوضح هذا الكود PHP العملية:
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


## **تعيين موضع المحور على محور الفئة أو القيمة**
Aspose.Slides for PHP via Java يتيح لك تعيين موضع المحور في محور الفئة أو القيمة. يُظهر هذا الكود PHP كيفية تنفيذ المهمة:
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


## **تمكين تسمية وحدة العرض على محور قيمة المخطط**
Aspose.Slides for PHP via Java يتيح لك تكوين مخطط لعرض تسمية وحدة على محور قيمة المخطط. يوضح هذا الكود PHP العملية:
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


## **الأسئلة المتكررة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها أحد المحاور مع الآخر (تقاطع المحور)؟**

توفر المحاور [إعداد التقاطع](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/): يمكنك اختيار التقاطع عند الصفر، عند أقصى فئة/قيمة، أو عند قيمة عددية محددة. وهذا مفيد لتحريك محور X للأعلى أو الأسفل أو لتأكيد خط الأساس.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور (بجانبه، خارجه، داخله)؟**

قم بتعيين [موضع التسمية](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) إلى "cross" أو "outside" أو "inside". يؤثر هذا على قابلية القراءة ويساعد في توفير المساحة، خاصةً في المخططات الصغيرة.