---
title: تنسيق المخططات
type: docs
weight: 60
url: /ar/php-java/chart-formatting/
---

## **تنسيق كائنات المخططات**
Aspose.Slides لـ PHP عبر Java يسمح للمطورين بإضافة مخططات مخصصة إلى شرائحهم من الصفر. توضح هذه المقالة كيفية تنسيق كائنات المخططات المختلفة بما في ذلك فئة المخطط ومحور القيمة.

يقدم Aspose.Slides لـ PHP عبر Java API بسيط لإدارة كائنات المخطط المختلفة وتنسيقها باستخدام القيم المخصصة:

1. إنشاء مثيل من [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. الحصول على مرجع الشريحة حسب فهرسها.
1. إضافة مخطط مع بيانات افتراضية مع أي نوع مطلوب (في هذا المثال سنستخدم ChartType::LineWithMarkers).
1. الوصول إلى محور قيمة المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط شبكة المحور الرئيسى
   1. تعيين **تنسيق الخط** لخطوط شبكة المحور الثانوي
   1. تعيين **تنسيق الرقم** للمحور القيمة
   1. تعيين **الوحدات الدنيا والقصوى والرئيسية والثانوية** للمحور القيمة
   1. تعيين **خصائص النص** لبيانات المحور القيمة
   1. تعيين **العنوان** للمحور القيمة
   1. تعيين **تنسيق الخط** للمحور القيمة
1. الوصول إلى محور فئة المخطط وتعيين الخصائص التالية:
   1. تعيين **تنسيق الخط** لخطوط شبكة المحور الرئيسى
   1. تعيين **تنسيق الخط** لخطوط شبكة المحور الثانوي
   1. تعيين **خصائص النص** لبيانات المحور الفئة
   1. تعيين **العنوان** للمحور الفئة
   1. تعيين **موضع التسميات** للمحور الفئة
   1. تعيين **زاوية التدوير** لعلامات المحور الفئة
1. الوصول إلى أسطورة المخطط وتعيين **خصائص النص** لها
1. تعيين عرض أساطير المخططات دون تداخل المخطط
1. الوصول إلى **محور القيمة الثانوي** للمخطط وتعيين الخصائص التالية:
   1. تفعيل **محور القيمة الثانوي**
   1. تعيين **تنسيق الخط** لمحور القيمة الثانوي
   1. تعيين **تنسيق الرقم** لمحور القيمة الثانوي
   1. تعيين **الوحدات الدنيا والقصوى والرئيسية والثانوية** لمحور القيمة الثانوي
1. الآن قم برسم سلسلة المخطط الأولى على محور القيمة الثانوي
1. تعيين لون تعبئة الجدار الخلفي للمخطط
1. تعيين لون تعبئة منطقة الرسم للمخطط
1. كتابة العرض المعدل إلى ملف PPTX

```php
  # إنشاء مثيل من كلاس Presentation
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة المخطط النموذجي
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # تعيين عنوان المخطط
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("مخطط نموذجي");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين تنسيق خطوط الشبكة الرئيسية للمحور القيمي
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # تعيين تنسيق خطوط الشبكة الثانوية للمحور القيمي
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # تعيين تنسيق الرقم للمحور القيمي
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # تعيين القيم القصوى والدنيا للمخطط
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # تعيين خصائص نص المحور القيمي
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # تعيين عنوان المحور القيمي
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("المحور الرئيسي");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين تنسيق خطوط الشبكة الرئيسية للمحور الفئوي
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # تعيين تنسيق خطوط الشبكة الثانوية للمحور الفئوي
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # تعيين خصائص نص المحور الفئوي
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # تعيين عنوان الفئة
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("فئة نموذجية");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين موضع التسميات للمحور الفئوي
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # تعيين زاوية دوران تسميات المحور الفئوي
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # تعيين خصائص نص الأساطير
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # تعيين عرض الأساطير دون تداخل المخطط
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # تعيين محور القيمة الثانوي
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # تعيين تنسيق الرقم لمحور القيمة الثانوي
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # تعيين القيم القصوى والدنيا للمخطط
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # تعيين لون الجدار الخلفي للمخطط
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # تعيين لون منطقة الرسم
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # حفظ العرض
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين خصائص الخط للمخطط**
Aspose.Slides لـ PHP عبر Java يوفر دعمًا لتعيين الخصائص المتعلقة بالخط للمخطط. يرجى اتباع الخطوات أدناه لتعيين خصائص الخط للمخطط.

- إنشاء كائن من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- إضافة مخطط على الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض المعدل.

تم إعطاء مثال نموذجي أدناه.

```php
  # إنشاء مثيل من كلاس Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين تنسيق الأرقام**
Aspose.Slides لـ PHP عبر Java يقدم API بسيط لإدارة تنسيق بيانات المخطط:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. الحصول على مرجع الشريحة حسب فهرسها.
1. إضافة مخطط مع بيانات افتراضية مع أي نوع مطلوب (هذا المثال يستخدم **ChartType::ClusteredColumn**).
1. تعيين تنسيق الرقم المسبق من القيم المسبقة الممكنة.
1. التجول خلال خلية بيانات المخطط في كل سلسلة مخطط وتعيين تنسيق رقم بيانات المخطط.
1. حفظ العرض.
1. تعيين تنسيق رقم مخصص.
1. التجول خلال خلية بيانات المخطط داخل كل سلسلة مخطط وتعيين تنسيق رقم مخطط مختلف.
1. حفظ العرض.

```php
  # إنشاء مثيل من كلاس Presentation
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى للعرض
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة مخطط عمودي متراص افتراضي
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # الوصول إلى مجموعة سلسلة المخطط
    $series = $chart->getChartData()->getSeries();
    # التجول عبر كل سلسلة مخطط
    foreach($series as $ser) {
      # التجول عبر كل خلية بيانات في السلسلة
      foreach($ser->getDataPoints() as $cell) {
        # تعيين تنسيق الرقم
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # حفظ العرض
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

قيم تنسيق الرقم المسبق الممكنة مع فهرسها المسبق والتي يمكن استخدامها موضحة أدناه:

|**0**|عام|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **تعيين زوايا حدود منطقة المخطط**
Aspose.Slides لـ PHP عبر Java يدعم تعيين منطقة المخطط. تم إضافة طرق [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#hasRoundedCorners--) و [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#setRoundedCorners-boolean-) إلى واجهة [IChart](https://reference.aspose.com/slides/php-java/aspose.slides/IChart) وكلاس [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart).

1. إنشاء كائن من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إضافة مخطط على الشريحة.
1. تعيين نوع التعبئة ولون التعبئة للمخطط
1. تعيين خاصية الزوايا الدائرية إلى True.
1. حفظ العرض المعدل.

تم إعطاء مثال نموذجي أدناه.

```php
  # إنشاء مثيل من كلاس Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```