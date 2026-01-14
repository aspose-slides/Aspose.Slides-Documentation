---
title: تنسيق مخططات العرض التقديمي في PHP
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/php-java/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخططات
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حد مستدير
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides لـ PHP عبر Java وارتقِ بعرض PowerPoint الخاص بك بتنسيق احترافي وجذاب."
---

## **تنسيق كيانات المخطط**
Aspose.Slides for PHP عبر Java يتيح للمطورين إضافة مخططات مخصصة إلى الشرائح من الصفر. تشرح هذه المقالة كيفية تنسيق كيانات المخطط المختلفة بما في ذلك محور الفئة ومحور القيمة.

Aspose.Slides for PHP عبر Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة كيانات المخطط المختلفة وتنسيقها باستخدام قيم مخصصة:

1. إنشاء مثيل من الفئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. الحصول على إشارة الشريحة بحسب فهرسها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (في هذا المثال سنستخدم ChartType::LineWithMarkers).
1. الوصول إلى محور القيمة للمخطط وتعيين الخصائص التالية:
   1. ضبط **Line format** لخطوط شبكة المحور القيمة الرئيسية
   1. ضبط **Line format** لخطوط شبكة المحور القيمة الثانوية
   1. ضبط **Number Format** للمحور القيمة
   1. ضبط **Min, Max, Major and Minor units** للمحور القيمة
   1. ضبط **Text Properties** لبيانات محور القيمة
   1. ضبط **Title** للمحور القيمة
   1. ضبط **Line Format** للمحور القيمة
1. الوصول إلى محور الفئة للمخطط وتعيين الخصائص التالية:
   1. ضبط **Line format** لخطوط شبكة محور الفئة الرئيسية
   1. ضبط **Line format** لخطوط شبكة محور الفئة الثانوية
   1. ضبط **Text Properties** لبيانات محور الفئة
   1. ضبط **Title** لمحور الفئة
   1. ضبط **Label Positioning** لمحور الفئة
   1. ضبط **Rotation Angle** لملصقات محور الفئة
1. الوصول إلى وسيلة الإيضاح للمخطط وضبط **Text Properties** لها
1. إظهار وسيلة الإيضاح للمخطط دون تداخل مع المخطط
1. الوصول إلى **Secondary Value Axis** للمخطط وتعيين الخصائص التالية:
   1. تمكين **Value Axis** الثانوي
   1. ضبط **Line Format** للمحور الثانوي للقيمة
   1. ضرب **Number Format** للمحور الثانوي للقيمة
   1. ضبط **Min, Max, Major and Minor units** للمحور الثانوي للقيمة
1. الآن ارسم سلسلة المخطط الأولى على محور القيمة الثانوي
1. تعيين لون تعبئة جدار الخلفية للمخطط
1. تعيين لون تعبئة منطقة الرسم للمخطط
1. كتابة العرض المعدل إلى ملف PPTX
```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة المخطط التجريبي
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
    # تعيين القيم العظمى والصغرى للمخطط
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
    # تعيين تنسيق خطوط الشبكة الرئيسية لمحور الفئة
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # تعيين تنسيق خطوط الشبكة الثانوية لمحور الفئة
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # تعيين خصائص نص محور الفئة
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
    # تعيين موضع تسمية محور الفئة
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # تعيين زاوية دوران تسمية محور الفئة
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # تعيين خصائص نص مفتاح الرسم البياني
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # إظهار مفتاح الرسم البياني دون تداخل مع المخطط
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # تعيين محور القيم الثانوي
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # تعيين تنسيق الأرقام لمحور القيم الثانوي
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # تعيين القيم العظمى والصغرى للمخطط
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
    # تعيين لون مساحة الرسم
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


## **تعيين خصائص الخط للمخطط**
Aspose.Slides for PHP عبر Java يوفر دعمًا لتعيين خصائص الخط المتعلقة بالمخطط. يرجى اتباع الخطوات أدناه لتعيين خصائص الخط للمخطط.

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- إضافة مخطط إلى الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض المعدل.

مثال العينة التالي موضح.
```php
  # إنشاء مثيل من فئة Presentation
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


## **تعيين التنسيق الرقمي**
Aspose.Slides for PHP عبر Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة تنسيق بيانات المخطط:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. الحصول على إشارة الشريحة بحسب فهرسها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم **ChartType::ClusteredColumn**).
1. ضبط تنسيق الرقم المسبق من القيم المسبقة المتاحة.
1. المرور عبر خلايا بيانات المخطط في كل سلسلة وضبط تنسيق رقم البيانات.
1. حفظ العرض.
1. تعيين تنسيق رقم مخصص.
1. المرور عبر خلايا بيانات المخطط داخل كل سلسلة وضبط تنسيق رقم مختلف.
1. حفظ العرض.
```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # الوصول إلى أول شريحة عرض تقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة مخطط عمودي مجموعات افتراضي
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # الوصول إلى مجموعة سلاسل المخطط
    $series = $chart->getChartData()->getSeries();
    # التجول عبر كل سلسلة مخطط
    foreach($series as $ser) {
      # التجول عبر كل خلية بيانات في السلسلة
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


القيم الممكنة لتنسيق الأرقام المسبق مع فهرسها التي يمكن استخدامها موضحة أدناه:

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

## **تعيين حدود دائرية لمنطقة المخطط**
Aspose.Slides for PHP عبر Java يوفر دعمًا لتعيين منطقة المخطط. تم إضافة الطريقتين [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasroundedcorners/) و [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setroundedcorners/) إلى فئة [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart) class.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. إضافة مخطط إلى الشريحة.
1. تعيين نوع التعبئة ولون التعبئة للمخطط
1. تعيين خاصية الزاوية المستديرة إلى True.
1. حفظ العرض المعدل.

```php
  # إنشاء مثيل من فئة Presentation
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

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على الحدود صلبة؟**  
نعم. شفافية التعبئة والحد الخارجي يتم تكوينهما بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصويرات المكثفة.

**كيف يمكنني التعامل مع ملصقات البيانات عندما تتداخل؟**  
قلل حجم الخط، عطل المكونات غير الضرورية للملصقات (مثل الفئات)، اضبط إزاحة/موضع الملصق، اعرض الملصقات فقط للنقاط المختارة إذا لزم الأمر، أو غيّر الصيغة إلى "القيمة + الأسطورة".

**هل يمكنني تطبيق تعبئات تدرجية أو نقشية على السلسلة؟**  
نعم. عادةً ما تكون كل من التعبئات الصلبة وتعبئات التدرج/النقش متاحة. في الممارسة العملية، استخدم التدرجات بشكل مقتصد وتجنب التركيب الذي يقلل من التباين مع الشبكة والنص.