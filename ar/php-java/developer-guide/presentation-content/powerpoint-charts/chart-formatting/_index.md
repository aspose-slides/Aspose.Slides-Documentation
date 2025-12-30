---
title: تنسيق مخططات العرض التقديمي في PHP
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/php-java/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخطط
- كائن المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حد مستدير
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides for PHP عبر Java وارتقِ بعرض PowerPoint التقديمي الخاص بك بأسلوب احترافي وجذاب."
---

## **تنسيق كائنات المخطط**
Aspose.Slides for PHP عبر Java يتيح للمطورين إضافة مخططات مخصصة إلى الشرائح من الصفر. يوضح هذا المقال كيفية تنسيق مختلف كائنات المخطط بما في ذلك محور الفئات ومحور القيم.

Aspose.Slides for PHP عبر Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة كائنات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء نسخة من فئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. الحصول على مرجع الشريحة بحسب الفهرس.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (في هذا المثال سنستخدم ChartType::LineWithMarkers).
1. الوصول إلى محور القيم في المخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور القيم
   1. تعيين **Line format** لخطوط الشبكة الثانوية لمحور القيم
   1. تعيين **Number Format** لمحور القيم
   1. تعيين **Min, Max, Major and Minor units** لمحور القيم
   1. تعيين **Text Properties** لبيانات محور القيم
   1. تعيين **Title** لمحور القيم
   1. تعيين **Line Format** لمحور القيم
1. الوصول إلى محور الفئات في المخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور الفئات
   1. تعيين **Line format** لخطوط الشبكة الثانوية لمحور الفئات
   1. تعيين **Text Properties** لبيانات محور الفئات
   1. تعيين **Title** لمحور الفئات
   1. تعيين **Label Positioning** لمحور الفئات
   1. تعيين **Rotation Angle** لتسميات محور الفئات
1. الوصول إلى وسيلة إيضاح المخطط وتعيين **Text Properties** لها
1. إظهار وسيلة إيضاح المخطط دون تداخل مع المخطط
1. الوصول إلى **Secondary Value Axis** في المخطط وتعيين الخصائص التالية:
   1. تمكين **Value Axis** الثانوي
   1. تعيين **Line Format** لمحور القيم الثانوي
   1. تعيين **Number Format** لمحور القيم الثانوي
   1. تعيين **Min, Max, Major and Minor units** لمحور القيم الثانوي
1. الآن رسم سلسلة المخطط الأولى على محور القيم الثانوي
1. تعيين لون تعبئة الجدار الخلفي للمخطط
1. تعيين لون تعبئة منطقة رسم المخطط
1. كتابة العرض المعدل إلى ملف PPTX
```php
  # إنشاء نسخة من فئة Presentation class
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
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين تنسيق خطوط الشبكة الرئيسية لمحور القيم
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # تعيين تنسيق خطوط الشبكة الثانوية لمحور القيم
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # تعيين تنسيق الأرقام لمحور القيم
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
    # تعيين خصائص نص محور القيم
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # تعيين عنوان محور القيم
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين تنسيق خطوط الشبكة الرئيسية لمحور الفئات
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # تعيين تنسيق خطوط الشبكة الثانوية لمحور الفئات
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # تعيين خصائص نص محور الفئات
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
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين موضع تسمية محور الفئات
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # تعيين زاوية دوران تسمية محور الفئات
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # تعيين خصائص نص وسيلة الإيضاح
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # تعيين إظهار وسيلة إيضاح المخطط دون تداخل مع المخطط
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # تعيين محور القيم الثانوي
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # تعيين تنسيق أرقام محور القيم الثانوي
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
    # تعيين لون منطقة الرسم للمخطط
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # حفظ العرض التقديمي
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين خصائص الخط لمخطط**
Aspose.Slides for PHP عبر Java يدعم تعيين خصائص الخط للمخطط. يرجى اتباع الخطوات أدناه لتعيين خصائص الخط للمخطط.

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- إضافة مخطط إلى الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض المعدل.

فيما يلي مثال توضيحي.
```php
  # إنشاء نسخة من فئة Presentation class
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


## **تعيين صيغة الأرقام**
Aspose.Slides for PHP عبر Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة صيغة بيانات المخطط:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. الحصول على مرجع الشريحة بحسب الفهرس.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (هذا المثال يستخدم **ChartType::ClusteredColumn**).
1. تعيين صيغة الرقم المسبقة من القيم المسبقة المتاحة.
1. المرور عبر خلايا بيانات المخطط في كل سلسلة وتعيين صيغة الرقم للبيانات.
1. حفظ العرض.
1. تعيين صيغة رقم مخصصة.
1. المرور عبر خلايا بيانات المخطط داخل كل سلسلة وتعيين صيغة رقم مختلفة للبيانات.
1. حفظ العرض.
```php
  # إنشاء نسخة من فئة Presentation class
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى للعرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة مخطط عمودي متجمع افتراضي
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # الوصول إلى مجموعة سلاسل المخطط
    $series = $chart->getChartData()->getSeries();
    # التجول في كل سلسلة مخطط
    foreach($series as $ser) {
      # التجول في كل خلية بيانات في السلسلة
      foreach($ser->getDataPoints() as $cell) {
        # تعيين تنسيق الرقم
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%
      }
    }
    # حفظ العرض التقديمي
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


القيم المسبقة لصيغة الرقم المتاحة مع الفهرس المسبق والتي يمكن استخدامها موضحة أدناه:

|**0**|General|
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

## **تعيين حدود مستديرة لمنطقة المخطط**
Aspose.Slides for PHP عبر Java يدعم ضبط منطقة المخطط. تم إضافة الطريقتين [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#hasRoundedCorners--) و[**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#setRoundedCorners-boolean-) إلى واجهة [IChart](https://reference.aspose.com/slides/php-java/aspose.slides/IChart) وفئة [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart).

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. إضافة مخطط إلى الشريحة.
1. تعيين نوع التعبئة ولون تعبئة المخطط
1. تعيين خاصية الزوايا المستديرة إلى True.
1. حفظ العرض المعدل.

فيما يلي مثال توضيحي.
```php
  # إنشاء نسخة من فئة Presentation class
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


## **الأسئلة المتكررة**

**هل يمكنني ضبط تعبئة شبه شفافة للأعمدة/المساحات مع الحفاظ على الحدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل مكونات التسمية غير الضرورية (مثل الفئات)، اضبط إزاحة/موضع التسمية، عرض التسميات للنقاط المحددة فقط إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + المفتاح".

**هل يمكنني تطبيق تعبئة متدرجة أو نمطية للسلسلة؟**

نعم. تتوفر عادةً كل من التعبئة الصلبة والمتدرجة/النمطية. في الممارسة، استخدم التدرجات بشكل مقتصد وتجنب التركيبات التي تقلل التباين مع الشبكة والنص.