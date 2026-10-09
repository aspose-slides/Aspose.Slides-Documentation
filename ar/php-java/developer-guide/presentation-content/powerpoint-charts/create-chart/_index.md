---
title: إنشاء أو تحديث مخططات عروض PowerPoint في PHP
linktitle: إنشاء أو تحديث المخططات
type: docs
weight: 10
url: /ar/php-java/create-chart/
keywords:
- إضافة مخطط
- إنشاء مخطط
- تحرير مخطط
- تغيير مخطط
- تحديث مخطط
- مخطط مبعثر
- مخطط دائري
- مخطط خطي
- مخطط خريطة شجرية
- مخطط أسهم
- مخطط صندوق وحذاء
- مخطط قمع
- مخطط شمسية
- مخطط هيستوغرام
- مخطط رادار
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. إضافة، تنسيق، وتحرير المخططات مع أمثلة عملية على الشيفرة."
---
## **نظرة عامة**

توفر هذه المقالة دليلًا شاملًا حول كيفية إنشاء وتخصيص المخططات باستخدام Aspose.Slides. ستتعلم كيفية إضافة مخطط برمجيًا إلى شريحة، وتعبئته بالبيانات، وتطبيق خيارات تنسيق مختلفة لتتناسب مع متطلبات التصميم الخاصة بك. طوال المقالة، تُظهر أمثلة التعليمات البرمجية المفصلة كل خطوة، بدءًا من تهيئة العرض التقديمي وكائن المخطط وحتى تكوين السلاسل والمحاور والوسائط. باتباع هذا الدليل، ستحصل على فهم قوي لكيفية دمج إنشاء المخططات الديناميكية في تطبيقاتك، مما يبسط عملية إنشاء عروض تقديمية مدفوعة بالبيانات.

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واستخلاص رؤى قد لا تكون واضحة فورًا من جدول أو ورقة عمل.

**لماذا إنشاء مخططات؟**

* تجميع أو تكثيف أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في عرض تقديمي
* كشف الأنماط والاتجاهات في البيانات
* استنتاج اتجاه وزخم البيانات بمرور الوقت أو بالنسبة لوحدة قياس محددة
* اكتشاف القيم المتطرفة، الشذوذات، الانحرافات، الأخطاء، البيانات غير المنطقية، وما إلى ذلك
* نقل أو عرض البيانات المعقدة

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة *Insert* التي توفر قوالب لتصميم أنواع متعددة من المخططات. باستخدام Aspose.Slides، يمكنك إنشاء كل من المخططات العادية (المستندة إلى أنواع المخططات الشائعة) والمخططات المخصصة.

{{% alert color="info" title="Note" %}}
لإنشاء المخططات، استخدم الفئة [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) . الحقول في هذه الفئة تتطابق مع أنواع مختلفة من المخططات.
{{% /alert %}}

### **إنشاء مخططات الأعمدة المتكتلة**

يشرح هذا القسم كيفية إنشاء مخططات الأعمدة المتكتلة باستخدام Aspose.Slides. ستتعلم تهيئة عرض تقديمي، إضافة مخطط، وتخصيص عناصره مثل العنوان، البيانات، السلاسل، الفئات، والتنسيق. اتبع الخطوات أدناه لرؤية كيفية توليد مخطط عمودي متكتل قياسي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط مع بعض البيانات وتحديد النوع `ChartType::ClusteredColumn` .
4. إضافة عنوان إلى المخطط.
5. الوصول إلى ورقة بيانات المخطط.
6. مسح جميع السلاسل والفئات الافتراضية.
7. إضافة سلاسل وفئات جديدة.
8. إضافة بيانات مخطط جديدة لسلسلة المخطط.
9. تطبيق لون تعبئة على سلسلة المخطط.
10. إضافة تسميات إلى سلسلة المخطط.
11. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود C# كيفية إنشاء مخطط عمودي متكتل:

```php
  # ينشئ كائن فئة عرض تقديمي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة مخطط ببياناته الافتراضية
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # تعيين عنوان المخطط
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # تعيين السلسلة الأولى لإظهار القيم
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # تعيين الفهرس لورقة بيانات المخطط
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # إضافة سلاسل جديدة
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # إضافة فئات جديدة
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # أخذ السلسلة الأولى للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # الآن يتم ملء بيانات السلسلة
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # تعيين لون التعبئة للسلسلة
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # أخذ السلسلة الثانية للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # ملء بيانات السلسلة
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # تعيين لون التعبئة للسلسلة
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # إنشاء تسميات مخصصة لكل فئة للسلسلة الجديدة
    # تعيين التسمية الأولى لإظهار اسم الفئة
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # إظهار القيمة للتسمية الثالثة
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # حفظ العرض التقديمي مع المخطط
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات مبعثرة**

تُستخدم مخططات المبعثر (المعروفة أيضًا بالمخططات النقطية أو الرسوم البيانية x‑y) غالبًا للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

استخدم مخطط مبعثر عندما:

* لديك بيانات رقمية متزاوجة
* لديك متغيران يتكاملان معًا
* ترغب في تحديد ما إذا كان المتغيران مرتبطين
* لديك متغير مستقل له قيم متعددة للمتغير التابع

1. اتبع الخطوات في [Create Clustered Column Charts](#create-clustered-column-charts).
2. في الخطوة الثالثة، أضف مخططًا مع بعض البيانات وحدد نوع المخطط كأحد الأنواع التالية:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _يمثل مخططًا مبعثراً._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _يمثل مخططًا مبعثراً متصلًا بأقواس مع علامات البيانات._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _يمثل مخططًا مبعثراً متصلًا بأقواس بدون علامات البيانات._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _يمثل مخططًا مبعثراً متصلًا بخطوط مستقيمة مع علامات البيانات._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _يمثل مخططًا مبعثراً متصلًا بخطوط مستقيمة بدون علامات البيانات._

يعرض هذا الكود PHP كيفية إنشاء مخطط مبعثر مع علامات مختلفة لكل سلسلة:

```php
  # ينشئ كائن فئة عرض تقديمي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إنشاء المخطط الافتراضي
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # الحصول على فهرس ورقة عمل بيانات المخطط الافتراضية
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # حذف السلسلة التجريبية
    $chart->getChartData()->getSeries()->clear();
    # إضافة سلاسل جديدة
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # أخذ السلسلة الأولى للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # إضافة نقطة جديدة (1:3) إلى السلسلة
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # إضافة نقطة جديدة (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # تغيير نوع السلسلة
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # تغيير علامة السلسلة في المخطط
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # أخذ السلسلة الثانية للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # إضافة نقطة جديدة (5:2) هناك
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # إضافة نقطة جديدة (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # إضافة نقطة جديدة (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # إضافة نقطة جديدة (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # تغيير علامة السلسلة في المخطط
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات دائرية**

تُعد مخططات الدائرة الأنسب لإظهار علاقة الجزء إلى الكل في البيانات، خاصة عندما تحتوي البيانات على تسميات تصنيفية مع قيم رقمية. ومع ذلك، إذا كانت بياناتك تحتوي على العديد من الأجزاء أو التسميات، قد ترغب في استخدام مخطط شريطي بدلاً من ذلك.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType::Pie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Pie) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. إضافة نقاط جديدة للمخطط وتطبيق ألوان مخصصة لقطاعات مخطط الدائرة.
9. تعيين تسميات للسلسلة.
10. تمكين خطوط القادة لتسميات السلسلة.
11. تعيين زاوية الدوران لقطاعات مخطط الدائرة.
12. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط دائري:

```php
  # ينشئ كائن فئة عرض تقديمي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slides = $pres->getSlides()->get_Item(0);
    # إضافة مخطط ببيانات افتراضية
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # تعيين عنوان المخطط
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # تعيين السلسلة الأولى لإظهار القيم
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # تعيين الفهرس لورقة بيانات المخطط
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # إضافة فئات جديدة
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # إضافة سلاسل جديدة
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # ملء بيانات السلسلة
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # غير فعّال في الإصدار الجديد
    # إضافة نقاط جديدة وتعيين لون القطاع
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # تعيين حد القطاع
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # تعيين حد القطاع
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # تعيين حد القطاع
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # إنشاء تسميات مخصصة لكل فئة للسلسلة الجديدة
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # إظهار خطوط القادة للمخطط
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # تعيين زاوية الدوران لقطاعات المخطط الدائري
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # حفظ العرض التقديمي مع المخطط
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات خطية**

تُعد مخططات الخط (المعروفة أيضًا بالرسوم البيانية الخطية) الأنسب في الحالات التي ترغب فيها بإظهار تغيّر القيمة مع مرور الوقت. باستخدام مخطط خطي، يمكنك مقارنة كمية كبيرة من البيانات في آنٍ واحد، وتتبع التغيّرات والاتجاهات مع مرور الوقت، وإبراز الشذوذ في سلاسل البيانات، وأكثر من ذلك.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType::Line](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Line) .
4. الوصول إلى دفتر بيانات المخطط ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) ).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط خطي:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

بشكل افتراضي، يتم ربط نقاط مخطط الخط بخطوط مستقيمة مستمرة. إذا رغبت في ربط النقاط بخطوط متقطعة بدلاً من ذلك، يمكنك تحديد نوع الخط المتقطع المفضل كما يلي:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات خريطة شجرية**

تُعد مخططات خريطة الشجرة الأنسب لبيانات المبيعات عندما ترغب في إظهار الحجم النسبي لفئات البيانات وجذب الانتباه بسرعة إلى العناصر التي تساهم بشكل كبير ضمن كل فئة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType::Treemap](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Treemap) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط خريطة شجرية:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # الفرع 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # الفرع 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات أسهم**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#OpenHighLowClose) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. تحديد تنسيق خطوط العليا-السفلى.
9. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط أسهم:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات صندوق وحذية**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#BoxAndWhisker) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط صندوق وحذية:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات قمع**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType::Funnel](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Funnel) .
4. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط قمع:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات شمسية**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType::Sunburst](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Sunburst) .
4. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط شمسي:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # الفرع 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # الفرع 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات هيستوغرام**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType::Histogram](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Histogram) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط هيستوغرام:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **إنشاء مخططات رادار**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط مع بعض البيانات وتحديد نوع المخطط المفضل ([ChartType::Radar](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Radar) في هذه الحالة).
4. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط رادار:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات متعددة الفئات**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType::ClusteredColumn](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ClusteredColumn) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط متعدد الفئات:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # إضافة سلسلة
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # حفظ العرض التقديمي مع المخطط
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات خريطة**

تُظهر مخططات الخريطة البيانات الجغرافية وتساعد في مقارنة القيم عبر المناطق.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **إنشاء مخططات مركبة**

مخطط مركب (أو مخطط مزيج) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح لك هذا المخطط إبراز أو مقارنة أو فحص الفروقات بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![The combination chart](combination_chart.png)

يظهر الكود PHP التالي كيفية إنشاء المخطط المركب المعروض أعلاه في عرض PowerPoint:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // تعيين عنوان المخطط.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // تعيين وسيلة إيضاح المخطط.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // إضافة فئات جديدة.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // إضافة السلسلة الأولى.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // تعيين المحور الأفقي.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // تعيين المحور العمودي.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // تعيين لون خطوط الشبكة العمودية الرئيسية.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // تعيين المحور الأفقي الثانوي.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // تعيين المحور العمودي الثانوي.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **تحديث المخططات**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) التي تمثل العرض الذي يحتوي على المخطط المراد تحديثه.
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. استعراض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى ورقة بيانات المخطط.
5. تعديل سلسلة بيانات المخطط عن طريق تغيير قيم السلسلة.
6. إضافة سلسلة جديدة وتعبئة بياناتها.
7. حفظ العرض التقديمي المعدل كملف PPTX.

```php
  $pres = new Presentation();
  try {
    # الوصول إلى أول شريحة
    $sld = $pres->getSlides()->get_Item(0);
    # الحصول على المخطط مع بيانات افتراضية
    $chart = $sld->getShapes()->get_Item(0);
    # تعيين فهرس ورقة بيانات المخطط
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # تعديل اسم فئة المخطط
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # أخذ السلسلة الأولى للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # الآن يتم تحديث بيانات السلسلة
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// تعديل اسم السلسلة

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # أخذ السلسلة الثانية للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # الآن يتم تحديث بيانات السلسلة
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// تعديل اسم السلسلة

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # الآن، إضافة سلسلة جديدة
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # أخذ السلسلة الثالثة للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # الآن يتم ملء بيانات السلسلة
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # حفظ العرض التقديمي مع المخطط
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين نطاق البيانات لمخطط**

للبحث عن النطاق المستخدم بالفعل في مخطط موجود، انظر إلى [استرجاع نطاق بيانات المخطط](/slides/ar/php-java/chart-workbook/#retrieve-a-charts-data-range).

لتعيين نطاق البيانات لمخطط، نفّذ ما يلي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) التي تمثل العرض الذي يحتوي على المخطط.
2. الحصول على مرجع إلى شريحة باستخدام الفهرس.
3. استعراض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى بيانات المخطط وتحديد النطاق.
5. حفظ العرض التقديمي المعدل كملف PPTX.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is0448java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استخدام العلامات الافتراضية في المخططات**

عند استخدام العلامات الافتراضية في المخططات، تحصل كل سلسلة مخطط تلقائيًا على رمز علامة مختلف.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # أخذ السلسلة الثانية للمخطط
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # الآن يتم ملء بيانات السلسلة
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الأسئلة المتكررة**

**ما هي أنواع المخططات التي يدعمها Aspose.Slides؟**

يدعم Aspose.Slides مجموعة واسعة من [أنواع المخططات](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)، بما في ذلك المخططات الشريطية، الخطية، الدائرية، المساحية، المبعثرة، الهيستوغرام، الرادار، والعديد غيرها. تتيح لك هذه المرونة اختيار نوع المخطط الأنسب لاحتياجاتك في تصور البيانات.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، تقوم أولاً بإنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، ثم تسترجع الشريحة المطلوبة باستخدام الفهرس، ثم تستدعي الطريقة لإضافة مخطط، مع تحديد نوع المخطط والبيانات الأولية. يدمج هذا العملية المخطط مباشرةً في عرضك التقديمي.

**كيف يمكنني تحديث البيانات المعروضة في المخطط؟**

يمكنك تحديث بيانات المخطط عبر الوصول إلى دفتر بياناته ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/))، مسح أي سلاسل وفئات افتراضية، ثم إضافة بياناتك المخصصة. يتيح لك ذلك تجديد المخطط ليعكس أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، يوفر Aspose.Slides خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، الوسائط، و[عناصر التنسيق](/slides/ar/php-java/chart-entities/) لتلائم مظهر المخطط متطلبات التصميم الخاصة بك.