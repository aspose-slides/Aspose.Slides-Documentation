---
title: حسابات الرسم البياني
type: docs
weight: 50
url: /ar/php-java/chart-calculations/
---

## **حساب القيم الفعلية لعناصر الرسم البياني**
يوفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص واجهة [IAxis](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis) معلومات عن الموضع الفعلي لعنصر المحور في الرسم البياني ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnitScale--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) سابقًا لملء الخصائص بالقيم الفعلية.

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

## **حساب الموضع الفعلي لعناصر الرسم البياني الأب**
يوفر Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص واجهة [IActualLayout](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout) معلومات عن الموضع الفعلي لعنصر الرسم البياني الأب ([IActualLayout.getActualX](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualHeight--)). من الضروري استدعاء الطريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) سابقًا لملء الخصائص بالقيم الفعلية.

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

## **إخفاء المعلومات من الرسم البياني**
تساعدك هذه الموضوعات على فهم كيفية إخفاء المعلومات من الرسم البياني. باستخدام Aspose.Slides لـ PHP عبر Java يمكنك إخفاء **العنوان، المحور العمودي، المحور الأفقي** و**خطوط الشبكة** من الرسم البياني. مثال الشفرة أدناه يوضح كيفية استخدام هذه الخصائص.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # إخفاء عنوان الرسم البياني
    $chart->setTitle(false);
    # /إخفاء المحور القيمي
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # رؤية محور الفئات
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # إخفاء السرد
    $chart->setLegend(false);
    # إخفاء خطوط الشبكة الكبرى
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # ضبط لون خط السلسلة
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