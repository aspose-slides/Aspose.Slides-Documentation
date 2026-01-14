---
title: "تحسين حسابات المخطط للعروض التقديمية في PHP"
linktitle: "حسابات المخطط"
type: docs
weight: 50
url: /ar/php-java/chart-calculations/
keywords:
- "حسابات المخطط"
- "عناصر المخطط"
- "موضع العنصر"
- "الموضع الفعلي"
- "العنصر الفرعي"
- "العنصر الأصلي"
- "قيم المخطط"
- "القيمة الفعلية"
- "PowerPoint"
- "عرض تقديمي"
- "PHP"
- "Aspose.Slides"
description: "افهم حسابات المخطط وتحديثات البيانات والتحكم في الدقة في Aspose.Slides لـ PHP عبر Java لملفات PPT و PPTX، مع أمثلة شفرة عملية."
---

## **حساب القيم الفعلية لعناصر المخطط**
توفر Aspose.Slides for PHP عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر طرق الفئة [Axis](https://reference.aspose.com/slides/php-java/aspose.slides/axis/) معلومات حول الموضع الفعلي لعنصر محور المخطط ([getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)). من الضروري استدعاء الطريقة [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) مسبقًا لملء الخصائص بالقيم الفعلية.
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


## **حساب الموضع الفعلي لعناصر المخطط الأصلية**
توفر Aspose.Slides for PHP عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر طرق الفئة `ActualLayout` معلومات حول الموضع الفعلي لعنصر المخطط الأصل (`getActualX`، `getActualY`، `getActualWidth`، `getActualHeight`). من الضروري استدعاء الطريقة [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) مسبقًا لملء الخصائص بالقيم الفعلية.
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


## **إخفاء عناصر المخطط**
يساعدك هذا الموضوع على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for PHP عبر Java يمكنك إخفاء **العنوان، المحور الرأسي، المحور الأفقي** و **خطوط الشبكة** من المخطط. يوضح مثال الشيفرة أدناه كيفية استخدام هذه الخصائص.
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # إخفاء عنوان المخطط
    $chart->setTitle(false);
    # /إخفاء محور القيم
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # إظهار محور الفئة
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # إخفاء وسيلة الإيضاح
    $chart->setLegend(false);
    # إخفاء خطوط الشبكة الرئيسية
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # تعيين لون خط السلسلة
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


## **الأسئلة المتكررة**

**هل تعمل دفاتر Excel الخارجية كمصدر للبيانات، وكيف يؤثر ذلك على إعادة الحساب؟**

نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عند الاتصال بالمصدر الخارجي أو تحديثه، تُؤخذ الصيغ والقيم من ذلك الدفتر، ويعكس المخطط التحديثات أثناء عمليات الفتح/التعديل. تسمح لك الواجهة البرمجية [تحديد دفتر العمل الخارجي](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) بتحديد مسار دفتر العمل الخارجي وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**

نعم. [Trendlines](/slides/ar/php-java/trend-line/) (خطية، أسية، وغيرها) يتم إضافتها وتحديثها بواسطة Aspose.Slides؛ يتم إعادة حساب معلماتها تلقائيًا من بيانات السلسلة، لذا لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض التقديمي يحتوي على مخططات متعددة بروابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**

نعم. يمكن لكل مخطط الإشارة إلى [دفتر عمل خارجي](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) خاص به، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.