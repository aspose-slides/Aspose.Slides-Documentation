---
title: إنشاء أو تحديث مخططات عرض PowerPoint في PHP
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
- مخطط صندوق وشوكة
- مخطط قمع
- مخطط شكل شمسية
- مخطط هيستوغرام
- مخطط رادار
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java. إضافة، تنسيق، وتحرير المخططات مع أمثلة عملية على الشيفرة."
---

## **نظرة عامة**

تصف هذه المقالة كيفية **إنشاء مخططات PowerPoint في Java**. يمكنك أيضًا **تحديث المخططات**. يغطي هذا المحتوى المواضيع التالية.

_Chart_: **Normal**
- [Java إنشاء مخطط PowerPoint](#java-create-powerpoint-chart)
- [Java إنشاء مخطط عرض تقديمي](#java-create-presentation-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي](#java-create-powerpoint-presentation-chart)

_Chart_: **Scattered**
- [Java إنشاء مخطط مبعثر](#java-create-scattered-chart)
- [Java إنشاء مخطط PowerPoint مبعثر](#java-create-powerpoint-scattered-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي مبعثر](#java-create-powerpoint-presentation-scattered-chart)

_Chart_: **Pie**
- [Java إنشاء مخطط دائري](#java-create-pie-chart)
- [Java إنشاء مخطط PowerPoint دائري](#java-create-powerpoint-pie-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي دائري](#java-create-powerpoint-presentation-pie-chart)

_Chart_: **Tree Map**
- [Java إنشاء مخطط خريطة شجرية](#java-create-tree-map-chart)
- [Java إنشاء مخطط PowerPoint خريطة شجرية](#java-create-powerpoint-tree-map-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي خريطة شجرية](#java-create-powerpoint-presentation-tree-map-chart)

_Chart_: **Stock**
- [Java إنشاء مخطط أسهم](#java-create-stock-chart)
- [Java إنشاء مخطط PowerPoint أسهم](#java-create-powerpoint-stock-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي أسهم](#java-create-powerpoint-presentation-stock-chart)

_Chart_: **Box and Whisker**
- [Java إنشاء مخطط صندوق وشوكة](#java-create-box-and-whisker-chart)
- [Java إنشاء مخطط PowerPoint صندوق وشوكة](#java-create-powerpoint-box-and-whisker-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي صندوق وشوكة](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Chart_: **Funnel**
- [Java إنشاء مخطط قمع](#java-create-funnel-chart)
- [Java إنشاء مخطط PowerPoint قمع](#java-create-powerpoint-funnel-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي قمع](#java-create-powerpoint-presentation-funnel-chart)

_Chart_: **Sunburst**
- [Java إنشاء مخطط شكل شمسية](#java-create-sunburst-chart)
- [Java إنشاء مخطط PowerPoint شكل شمسية](#java-create-powerpoint-sunburst-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي شكل شمسية](#java-create-powerpoint-presentation-sunburst-chart)

_Chart_: **Histogram**
- [Java إنشاء مخطط هيستوغرام](#java-create-histogram-chart)
- [Java إنشاء مخطط PowerPoint هيستوغرام](#java-create-powerpoint-histogram-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي هيستوغرام](#java-create-powerpoint-presentation-histogram-chart)

_Chart_: **Radar**
- [Java إنشاء مخطط رادار](#java-create-radar-chart)
- [Java إنشاء مخطط PowerPoint رادار](#java-create-powerpoint-radar-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي رادار](#java-create-powerpoint-presentation-radar-chart)

_Chart_: **Multi Category**
- [Java إنشاء مخطط متعدد الفئات](#java-create-multi-category-chart)
- [Java إنشاء مخطط PowerPoint متعدد الفئات](#java-create-powerpoint-multi-category-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي متعدد الفئات](#java-create-powerpoint-presentation-multi-category-chart)

_Chart_: **Map**
- [Java إنشاء مخطط خريطة](#java-create-map-chart)
- [Java إنشاء مخطط PowerPoint خريطة](#java-create-powerpoint-map-chart)
- [Java إنشاء مخطط PowerPoint للعرض التقديمي خريطة](#java-create-powerpoint-presentation-map-chart)

_Action_: **Update Chart**
- [Java تحديث مخطط PowerPoint](#java-update-powerpoint-chart)
- [Java تحديث مخطط عرض تقديمي](#java-update-presentation-chart)
- [Java تحديث مخطط PowerPoint للعرض التقديمي](#java-update-powerpoint-presentation-chart)


## **إنشاء مخطط**
تساعد المخططات الأشخاص على تصور البيانات بسرعة واستخلاص رؤى قد لا تكون واضحة فورًا من جدول أو ورقة عمل.

**لماذا إنشاء مخططات؟**

باستخدام المخططات، يمكنك:

* تجميع أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في العرض التقديمي
* إظهار الأنماط والاتجاهات في البيانات
* استنتاج اتجاه وزخم البيانات عبر الزمن أو بالنسبة لوحدة قياس معينة
* اكتشاف القيم الشاذة أو الأخطاء أو البيانات غير المنطقية
* نقل أو عرض بيانات معقدة

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة الإدراج التي توفر قوالب لتصميم أنواع متعددة من المخططات. باستخدام Aspose.Slides، يمكنك إنشاء مخططات عادية (مستندة إلى أنواع مخططات شائعة) ومخططات مخصصة.

{{% alert color="primary" %}} 
لتتمكن من إنشاء المخططات، توفر Aspose.Slides الصنف [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType). الحقول داخل هذا الصنف تمثل أنواع المخططات المختلفة.
{{% /alert %}} 

### **إنشاء مخططات عادية**

_خطوات: إنشاء مخطط_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>الخطوات:</em> إنشاء مخطط عرض تقديمي</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي</strong></a>

_خطوات الشفرة:_

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات معينة وتحديد نوع المخطط المفضل.
4. إضافة عنوان للمخطط.
5. الوصول إلى ورقة بيانات المخطط.
6. مسح جميع السلاسل والفئات الافتراضية.
7. إضافة سلاسل وفئات جديدة.
8. إضافة بيانات مخطط جديدة للسلسلة.
9. إضافة لون تعبئة لسلسلة المخطط.
10. إضافة تسميات لسلسلة المخطط.
11. كتابة العرض المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط عادي:
```php
  # ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يضيف مخططًا مع بياناته الافتراضية
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # يضبط عنوان المخطط
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # يضبط السلسلة الأولى لإظهار القيم
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # يضبط الفهرس لورقة بيانات المخطط
    $defaultWorksheetIndex = 0;
    # يحصل على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # يحذف السلاسل والفئات الافتراضية المُولدة
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # يضيف سلاسل جديدة
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # يضيف فئات جديدة
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # يأخذ السلسلة الأولى للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # يملأ الآن بيانات السلسلة
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # يضبط لون التعبئة للسلسلة
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # يأخذ السلسلة الثانية للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # يملأ بيانات السلسلة
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # يضبط لون التعبئة للسلسلة
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # إنشاء تسميات مخصصة لكل فئة للسلسلة الجديدة
    # يضبط التسمية الأولى لإظهار اسم الفئة
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # يظهر القيمة للتسمية الثالثة
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # يحفظ العرض التقديمي مع المخطط
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **إنشاء مخططات مبعثرة**
المخططات المبثّرة (المعروفة أيضًا بالمخططات النقطية أو مخططات X‑Y) تُستخدم غالبًا للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

قد تحتاج إلى مخطط مبعثَر عندما:

* لديك بيانات عددية مزدوجة
* لديك متغيران يتماشىان معًا
* تريد تحديد ما إذا كان المتغيران مرتبطين
* لديك متغير مستقل له قيم متعددة للمتغير التابع

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>الخطوات:</em> إنشاء مخطط مبعثَر</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint مبعثَر</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي مبعثَر</strong></a>

1. يرجى اتباع الخطوات المذكورة أعلاه في [إنشاء مخططات عادية](#creating-normal-charts)
2. للخطوة الثالثة، أضف مخططًا ببيانات معينة وحدد نوع المخطط كأحد الأنواع التالية
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _يمثل مخطط مبعثَر بالعلامات._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _يمثل مخطط مبعثَر بخطوط ناعمة وعلامات._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _يمثل مخطط مبعثَر بخطوط ناعمة بدون علامات._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _يمثل مخطط مبعثَر بخطوط مستقيمة وعلامات._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _يمثل مخطط مبعثَر بخطوط مستقيمة بدون علامات._

يعرض هذا الكود PHP كيفية إنشاء مخططات مبعثرة مع مجموعة مختلفة من العلامات:
```php
  # ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # ينشئ المخطط الافتراضي
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # يحصل على فهرس ورقة عمل بيانات المخطط الافتراضية
    $defaultWorksheetIndex = 0;
    # يحصل على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # يحذف السلسلة التجريبية
    $chart->getChartData()->getSeries()->clear();
    # يضيف سلاسل جديدة
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # يأخذ السلسلة الأولى للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # يضيف نقطة جديدة (1:3) إلى السلسلة
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # يضيف نقطة جديدة (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # يغيّر نوع السلسلة
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # يغيّر علامة سلسلة المخطط
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # يأخذ السلسلة الثانية للمخطط
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # يضيف نقطة جديدة (5:2) هناك
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # يضيف نقطة جديدة (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # يضيف نقطة جديدة (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # يضيف نقطة جديدة (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # يغيّر علامة سلسلة المخطط
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

المخططات الدائرية تُظهر علاقة الجزء إلى الكل في البيانات، خاصة عندما تحتوي البيانات على تسميات فئوية مع قيم عددية. إذا كانت البيانات تحتوي على العديد من الأجزاء أو التسميات، قد تفضل استخدام مخطط شريطي بدلًا من ذلك.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>الخطوات:</em> إنشاء مخطط دائري</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint دائري</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي دائري</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب (في هذه الحالة، [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Pie).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. إضافة نقاط جديدة للمخطط وتخصيص ألوان للقطاعات الدائرية.
9. ضبط تسميات السلاسل.
10. ضبط خطوط المؤشر لتسميات السلاسل.
11. ضبط زاوية الدوران لشرائح المخطط الدائري.
12. كتابة العرض المعدل إلى ملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط دائري:
```php
  # ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slides = $pres->getSlides()->get_Item(0);
    # يضيف مخططًا ببيانات افتراضية
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # يضبط عنوان المخطط
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # يضبط السلسلة الأولى لإظهار القيم
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # يضبط الفهرس لورقة بيانات المخطط
    $defaultWorksheetIndex = 0;
    # يحصل على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # يحذف السلاسل والفئات الافتراضية المُولَّدة
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # يضيف فئات جديدة
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # يضيف سلاسل جديدة
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # يملأ بيانات السلسلة
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # لا يعمل في الإصدار الجديد
    # إضافة نقاط جديدة وتعيين لون القطاع
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # يضبط حدود القطاع
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # يضبط حدود القطاع
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # يضبط حدود القطاع
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # ينشئ تسميات مخصصة لكل فئة للسلسلة الجديدة
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
    # يعرض خطوط القائد للمخطط
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # يضبط زاوية التدوير لقطاعات مخطط الفطيرة
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # يحفظ العرض التقديمي مع المخطط
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **إنشاء مخططات خطية**

المخططات الخطية (المعروفة أيضًا بمخططات الخط) تُستخدم لتوضيح تغير القيم عبر الزمن. باستخدام مخطط خطي، يمكنك مقارنة الكثير من البيانات في آن واحد، تتبع التغييرات والاتجاهات عبر الزمن، وتسليط الضوء على الشذوذ في السلاسل، إلخ.

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع شريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية والنوع المطلوب (`ChartType::Line`).
1. الوصول إلى ورقة بيانات المخطط IChartDataWorkbook.
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة للسلسلة.
1. كتابة العرض المعدل إلى ملف PPTX.

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


بشكل افتراضي، يتم ربط النقاط على المخطط الخطي بخطوط مستقيمة مستمرة. إذا رغبت في ربط النقاط بخطوط متقطعة، يمكنك تحديد نوع الخط المتقطع بهذه الطريقة:
```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```


### **إنشاء مخططات خريطة شجرية**

تُستخدم مخططات الخريطة الشجرية لبيانات المبيعات عندما تريد إظهار الحجم النسبي لفئات البيانات وفي الوقت نفسه جذب الانتباه إلى العناصر التي تمثل مساهمات كبيرة لكل فئة.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>الخطوات:</em> إنشاء مخطط خريطة شجرية</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint خريطة شجرية</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي خريطة شجرية</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب (في هذه الحالة، [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).TreeMap).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. كتابة العرض المعدل إلى ملف PPTX.

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

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>الخطوات:</em> إنشاء مخطط أسهم</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint أسهم</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي أسهم</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).OpenHighLowClose).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. تحديد تنسيق خطوط HiLowLines.
9. كتابة العرض المعدل إلى ملف PPTX.

كود PHP النموذجي لإنشاء مخطط أسهم:
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
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **إنشاء مخططات صندوق وشوكة**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>الخطوات:</em> إنشاء مخطط صندوق وشوكة</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint صندوق وشوكة</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي صندوق وشوكة</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).BoxAndWhisker).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. كتابة العرض المعدل إلى ملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط صندوق وشوكة:
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

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>الخطوات:</em> إنشاء مخطط قمع</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint قمع</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي قمع</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Funnel).
4. كتابة العرض المعدل إلى ملف PPTX.

يعرض الكود PHP كيفية إنشاء مخطط قمع:
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


### **إنشاء مخططات شكل شمسية**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>الخطوات:</em> إنشاء مخطط شكل شمسية</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint شكل شمسية</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي شكل شمسية</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب (في هذه الحالة، [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).sunburst).
4. كتابة العرض المعدل إلى ملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء مخطط شكل شمسية:
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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>الخطوات:</em> إنشاء مخطط هيستوغرام</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint هيستوغرام</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي هيستوغرام</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Histogram).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. كتابة العرض المعدل إلى ملف PPTX.

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

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>الخطوات:</em> إنشاء مخطط رادار</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint رادار</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي رادار</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات معينة وتحديد نوع المخطط المفضل (`ChartType::Radar` في هذه الحالة).
4. كتابة العرض المعدل إلى ملف PPTX.

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

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>الخطوات:</em> إنشاء مخطط متعدد الفئات</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint متعدد الفئات</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي متعدد الفئات</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).ClusteredColumn).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. كتابة العرض المعدل إلى ملف PPTX.

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

مخطط الخريطة هو تمثيل بياني لمنطقة تحتوي على بيانات. تُستخدم مخططات الخريطة غالبًا لمقارنة البيانات أو القيم عبر المناطق الجغرافية.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>الخطوات:</em> إنشاء مخطط خريطة</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint خريطة</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>الخطوات:</em> إنشاء مخطط PowerPoint للعرض التقديمي خريطة</strong></a>

يعرض هذا الكود PHP كيفية إنشاء مخطط خريطة:
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

المخطط المركب (أو مخطط الجمع) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح لك هذا المخطط إبراز أو مقارنة أو فحص الفروقات بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![مخطط الجمع](combination_chart.png)

يعرض الكود PHP التالي كيفية إنشاء مخطط الجمع الموضح أعلاه في عرض PowerPoint:
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

    // ضبط عنوان المخطط.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // ضبط وسيلة إيضاح المخطط.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // حذف السلاسل والفئات الافتراضية التي تم إنشاؤها.
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
    // ضبط المحور الأفقي.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // ضبط المحور الرأسي.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // ضبط لون خطوط الشبكة العمودية الرئيسية.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // ضبط المحور الأفقي الثانوي.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // ضبط المحور الرأسي الثانوي.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>الخطوات:</em> تحديث مخطط PowerPoint</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>الخطوات:</em> تحديث مخطط عرض تقديمي</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>الخطوات:</em> تحديث مخطط PowerPoint للعرض التقديمي</strong></a>

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي يمثل العرض التقديمي المحتوي على المخطط الذي تريد تحديثه.
2. الحصول على مرجع شريحة عبر فهرستها.
3. استعراض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى ورقة بيانات المخطط.
5. تعديل بيانات سلسلة المخطط عن طريق تغيير قيم السلسلة.
6. إضافة سلسلة جديدة وتعبئة البيانات فيها.
7. كتابة العرض المعدل إلى ملف PPTX.

يعرض هذا الكود PHP كيفية تحديث مخطط:
```php
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # الحصول على المخطط بالبيانات الافتراضية
    $chart = $sld->getShapes()->get_Item(0);
    # تعيين فهرس ورقة بيانات المخطط
    $defaultWorksheetIndex = 0;
    # الحصول على ورقة عمل بيانات المخطط
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # تغيير اسم فئة المخطط
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
    # الآن تعبئة بيانات السلسلة
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

لتعيين نطاق البيانات لمخطط، قم بما يلي:

1. إنشاء مثيل من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي يمثل العرض التقديمي المحتوي على المخطط.
2. الحصول على مرجع شريحة عبر فهرستها.
3. استعراض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى بيانات المخطط وتحديد النطاق.
5. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية تعيين نطاق البيانات لمخطط:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **استخدام العلامات الافتراضية في المخططات**
عند استخدام علامة افتراضية في المخططات، يحصل كل سلسلة مخطط على رمز علامة افتراضي مختلف تلقائيًا.

يعرض هذا الكود PHP كيفية تعيين علامة سلسلة مخطط تلقائيًا:
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
    #   أخذ السلسلة الثانية للمخطط
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    #   الآن يتم تعبئة بيانات السلسلة
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

يدعم Aspose.Slides مجموعة واسعة من [أنواع المخططات](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)، بما في ذلك الشريطي، الخطي، الدائري، المساحي، النقطي، الهيستوغرام، الرادار، والعديد غيرها. يتيح لك ذلك اختيار النوع الأنسب لتصور بياناتك.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، أنشئ أولاً مثيلًا من الصنف [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ثم احصل على الشريحة المطلوبة عبر فهرستها، بعد ذلك استدعِ الطريقة لإضافة مخطط مع تحديد نوع المخطط والبيانات الأولية. يدمج ذلك المخطط مباشرة في عرضك التقديمي.

**كيف يمكنني تحديث البيانات المعروضة في مخطط؟**

يمكنك تحديث بيانات المخطط بالوصول إلى دفتر عمل البيانات الخاص به ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/))، مسح السلاسل والفئات الافتراضية، ثم إضافة بياناتك المخصصة. يتيح لك ذلك تجديد المخطط لعرض أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، يوفر Aspose.Slides خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، وسيلة الإيضاح، وعناصر [التنسيق](/slides/ar/php-java/chart-entities/) الأخرى لتناسب التصميم المطلوب.