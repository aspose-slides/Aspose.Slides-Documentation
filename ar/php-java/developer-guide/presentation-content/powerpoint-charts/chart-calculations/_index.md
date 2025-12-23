---
title: تحسين حسابات المخطط للعروض التقديمية في PHP
linktitle: حسابات المخطط
type: docs
weight: 50
url: /ar/php-java/chart-calculations/
keywords:
- حسابات المخطط
- عناصر المخطط
- موضع العنصر
- الموضع الفعلي
- العنصر الفرعي
- العنصر الأصلي
- قيم المخطط
- القيمة الفعلية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "فهم حسابات المخطط وتحديثات البيانات والتحكم في الدقة في Aspose.Slides للـ PHP عبر Java لعروض PPT و PPTX، مع أمثلة عملية على الشيفرة."
---

## **حساب القيم الفعلية لعناصر المخطط**
توفر Aspose.Slides للـ PHP عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص الواجهة [IAxis](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis) معلومات حول الموضع الفعلي لعنصر محور المخطط ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnitScale--)). من الضروري استدعاء طريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.
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
توفر Aspose.Slides للـ PHP عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص الواجهة [IActualLayout](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout) معلومات حول الموضع الفعلي لعنصر المخطط الأصل ( [IActualLayout.getActualX](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualHeight--) ). من الضروري استدعاء طريقة [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.
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
يساعدك هذا الموضوع على فهم طريقة إخفاء المعلومات من المخطط. باستخدام Aspose.Slides للـ PHP عبر Java يمكنك إخفاء **Title**، **Vertical Axis**، **Horizontal Axis** و**Grid Lines** من المخطط. يُظهر مثال الشيفرة أدناه كيفية استخدام هذه الخصائص.
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # إخفاء عنوان المخطط
    $chart->setTitle(false);
    # /إخفاء محور القيم
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # إظهار محور الفئات
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

**هل يمكن لدفاتر Excel الخارجية أن تعمل كمصدر بيانات، وكيف يؤثر ذلك على إعادة الحساب؟**  
نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عند الاتصال بالمصدر الخارجي أو تحديثه، تُؤخذ الصيغ والقيم من ذلك الدفتر، ويعكس المخطط التحديثات أثناء عمليات الفتح/التعديل. تتيح لك الواجهة البرمجية [specify the external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) تحديد مسار الدفتر الخارجي وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**  
نعم. تُضاف وتُحدَّث [Trendlines](/slides/ar/php-java/trend-line/) (خطية، أسية، وغيرها) تلقائيًا بواسطة Aspose.Slides؛ تُعاد حساب معلماتها من بيانات السلاسل تلقائيًا، لذا لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض يحتوي على مخططات متعددة ذات روابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**  
نعم. يمكن لكل مخطط الإشارة إلى دفتر عمل خارجي خاص به، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.