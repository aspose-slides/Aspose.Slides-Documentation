---
title: إنشاء أو تحديث مخططات عرض تقديمي PowerPoint في Java
linktitle: إنشاء مخطط
type: docs
weight: 10
url: /ar/java/create-chart/
keywords: "إنشاء مخطط، مخطط متناثر، مخطط دائري، مخطط خريطة شجرية، مخطط مخزون، مخطط صندوق ووشيك، مخطط مدرج تكراري، مخطط قمع، مخطط انفجار الشمس، مخطط متعدد الفئات، عرض تقديمي PowerPoint، Java، Aspose.Slides for Java"
description: "إنشاء مخطط في عرض تقديمي PowerPoint في Java"
---

## نظرة عامة

تصف هذه المقالة كيفية **إنشاء مخططات عرض تقديمي PowerPoint في Java**. يمكنك أيضًا **تحديث المخططات في Java**. تغطي هذه المواضيع.

_المخطط_: **عادي**
- [إنشاء مخطط PowerPoint في Java](#java-create-powerpoint-chart)
- [إنشاء مخطط عرض تقديمي في Java](#java-create-presentation-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint في Java](#java-create-powerpoint-presentation-chart)

_المخطط_: **متناثر**
- [إنشاء مخطط متناثر في Java](#java-create-scattered-chart)
- [إنشاء مخطط PowerPoint متناثر في Java](#java-create-powerpoint-scattered-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint متناثر في Java](#java-create-powerpoint-presentation-scattered-chart)

_المخطط_: **دائري**
- [إنشاء مخطط دائري في Java](#java-create-pie-chart)
- [إنشاء مخطط PowerPoint دائري في Java](#java-create-powerpoint-pie-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint دائري في Java](#java-create-powerpoint-presentation-pie-chart)

_المخطط_: **خريطة شجرية**
- [إنشاء مخطط خريطة شجرية في Java](#java-create-tree-map-chart)
- [إنشاء مخطط PowerPoint خريطة شجرية في Java](#java-create-powerpoint-tree-map-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint خريطة شجرية في Java](#java-create-powerpoint-presentation-tree-map-chart)

_المخطط_: **مخزون**
- [إنشاء مخطط مخزون في Java](#java-create-stock-chart)
- [إنشاء مخطط PowerPoint مخزون في Java](#java-create-powerpoint-stock-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint مخزون في Java](#java-create-powerpoint-presentation-stock-chart)

_المخطط_: **صندوق ووشيك**
- [إنشاء مخطط صندوق ووشيك في Java](#java-create-box-and-whisker-chart)
- [إنشاء مخطط PowerPoint صندوق ووشيك في Java](#java-create-powerpoint-box-and-whisker-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint صندوق ووشيك في Java](#java-create-powerpoint-presentation-box-and-whisker-chart)

_المخطط_: **قمع**
- [إنشاء مخطط قمع في Java](#java-create-funnel-chart)
- [إنشاء مخطط PowerPoint قمع في Java](#java-create-powerpoint-funnel-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint قمع في Java](#java-create-powerpoint-presentation-funnel-chart)

_المخطط_: **انفجار الشمس**
- [إنشاء مخطط انفجار الشمس في Java](#java-create-sunburst-chart)
- [إنشاء مخطط PowerPoint انفجار الشمس في Java](#java-create-powerpoint-sunburst-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint انفجار الشمس في Java](#java-create-powerpoint-presentation-sunburst-chart)

_المخطط_: **مدرج تكراري**
- [إنشاء مخطط مدرج تكراري في Java](#java-create-histogram-chart)
- [إنشاء مخطط PowerPoint مدرج تكراري في Java](#java-create-powerpoint-histogram-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint مدرج تكراري في Java](#java-create-powerpoint-presentation-histogram-chart)

_المخطط_: **رادار**
- [إنشاء مخطط رادار في Java](#java-create-radar-chart)
- [إنشاء مخطط PowerPoint رادار في Java](#java-create-powerpoint-radar-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint رادار في Java](#java-create-powerpoint-presentation-radar-chart)

_المخطط_: **متعدد الفئات**
- [إنشاء مخطط متعدد الفئات في Java](#java-create-multi-category-chart)
- [إنشاء مخطط PowerPoint متعدد الفئات في Java](#java-create-powerpoint-multi-category-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint متعدد الفئات في Java](#java-create-powerpoint-presentation-multi-category-chart)

_المخطط_: **خريطة**
- [إنشاء مخطط خريطة في Java](#java-create-map-chart)
- [إنشاء مخطط PowerPoint خريطة في Java](#java-create-powerpoint-map-chart)
- [إنشاء مخطط عرض تقديمي PowerPoint خريطة في Java](#java-create-powerpoint-presentation-map-chart)

_الإجراء_: **تحديث المخطط**
- [تحديث مخطط PowerPoint في Java](#java-update-powerpoint-chart)
- [تحديث مخطط عرض تقديمي في Java](#java-update-presentation-chart)
- [تحديث مخطط عرض تقديمي PowerPoint في Java](#java-update-powerpoint-presentation-chart)


## **إنشاء مخطط**
تساعد المخططات الأشخاص على تصور البيانات بسرعة واستخلاص رؤى قد لا تكون واضحة فورًا من جدول أو ورقة عمل.

**لماذا إنشاء المخططات؟**

باستخدام المخططات، يمكنك

* تجميع أو تلخيص كميات كبيرة من البيانات في شريحة واحدة من العرض التقديمي
* كشف الأنماط والاتجاهات في البيانات
* استنتاج اتجاه وزخم البيانات مع مرور الوقت أو بالنسبة لوحدة قياس معينة
* اكتشاف القيم الشاذة أو الأخطاء أو البيانات غير المنطقية
* توضيح أو تقديم بيانات معقدة

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة الإدراج التي توفر قوالب لتصميم أنواع متعددة من المخططات. باستخدام Aspose.Slides، يمكنك إنشاء مخططات عادية (مستندة إلى أنواع المخططات الشائعة) ومخططات مخصصة.

{{% alert color="primary" %}} 
لإنشاء المخططات، توفر Aspose.Slides الفئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType). الحقول داخل هذه الفئة تت对应 لأنواع المخططات المختلفة. 
{{% /alert %}} 

### **إنشاء مخططات عادية**

- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint في Java</em></strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي في Java</em></strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint في Java</em></strong></a>

**خطوات الكود:**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات معينة وتحديد نوع المخطط المفضل.
4. إضافة عنوان للمخطط.
5. الوصول إلى ورقة بيانات المخطط.
6. مسح جميع السلاسل والفئات الافتراضية.
7. إضافة سلاسل وفئات جديدة.
8. إضافة بيانات جديدة للسلسلة.
9. إضافة لون تعبئة للسلسلة.
10. إضافة تسميات للسلسلة.
11. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية إنشاء مخطط عادي:
```java
// ينشئ كائن عرض تقديمي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // إضافة مخطط ببياناته الافتراضية
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // تعيين عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // تعيين السلسلة الأولى لعرض القيم
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // تعيين الفهرس لورقة بيانات المخطط
    int defaultWorksheetIndex = 0;
    
    // الحصول على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // حذف السلاسل والفئات الافتراضية المولدة
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // إضافة سلاسل جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // إضافة فئات جديدة
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // أخذ السلسلة الأولى للمخطط
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // الآن ملء بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // تعيين لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // أخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1);
    
    // ملء بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // تعيين لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //إنشاء تسميات مخصصة لكل فئة للسلسلة الجديدة
    // تعيين التسمية الأولى لعرض اسم الفئة
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // عرض القيمة للتسمية الثالثة
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // حفظ العرض التقديمي مع المخطط
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات متناثر**
المخططات المتنثرة (المعروفة أيضًا برسوم التشتت أو مخططات x‑y) تُستخدم غالبًا للتحقق من الأنماط أو إظهار الارتباط بين متغيرين.

قد تحتاج إلى مخطط متناثر عندما

* لديك بيانات عددية مزدوجة
* يوجد متغيران مرتبطان بشكل جيد
* تريد تحديد ما إذا كان المتغيران مرتبطين
* لديك متغير مستقل له قيم متعددة للمتغير المعتمد

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>الخطوات: إنشاء مخطط متناثر في Java</em></strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint متناثر في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint متناثر في Java</em></strong></a>

1. يرجى اتباع الخطوات المذكورة أعلاه في [إنشاء مخططات عادية](#creating-normal-charts)
2. في الخطوة الثالثة، أضف مخططًا ببيانات معينة وحدد نوع المخطط كواحد من التالي
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _يمثل مخطط تشتت مع علامات._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _يمثل مخطط تشتت بخطوط ملساء وعلامات._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _يمثل مخطط تشتت بخطوط ملساء دون علامات._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _يمثل مخطط تشتت بخطوط مستقيمة وعلامات._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _يمثل مخطط تشتت بخطوط مستقيمة دون علامات._

هذا الكود Java يوضح كيفية إنشاء مخططات متنثرة بسلسلة مختلفة من العلامات:
```java
// ينشئ كائن عرض تقديمي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // ينشئ المخطط الافتراضي
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // يحصل على فهرس ورقة عمل بيانات المخطط الافتراضية
    int defaultWorksheetIndex = 0;
    
    // يحصل على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // يحذف السلسلة التجريبية
    chart.getChartData().getSeries().clear();
    
    // يضيف سلاسل جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // يأخذ السلسلة الأولى للمخطط
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // يضيف نقطة جديدة (1:3) إلى السلسلة
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // يضيف نقطة جديدة (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // يغيّر نوع السلسلة
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // يغيّر علامة سلسلة المخطط
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // يأخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1);
    
    // يضيف نقطة جديدة (5:2) هناك
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // يضيف نقطة جديدة (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // يضيف نقطة جديدة (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // يضيف نقطة جديدة (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // يغيّر علامة سلسلة المخطط
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات دائرية**

المخططات الدائرية تُستخدم لإظهار علاقة الجزء إلى الكل في البيانات، خاصة عندما تحتوي البيانات على تسميات فئوية مع قيم رقمية. إذا كانت البيانات تحتوي على أجزاء أو تسميات كثيرة، قد تفضل استخدام مخطط شريطي بدلاً من ذلك.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>الخطوات: إنشاء مخطط دائري في Java</em></strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint دائري في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint دائري في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب (في هذه الحالة، [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Pie).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للسلسلة.
8. إضافة نقاط جديدة للمخطط وإعطاء ألوان مخصصة لقطاعات المخطط الدائري.
9. تعيين تسميات للسلسلة.
10. تعيين خطوط ربط للسلسلة.
11. ضبط زاوية الدوران للشرائح الدائرية.
12. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية إنشاء مخطط دائري:
```java
// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slides = pres.getSlides().get_Item(0);
    
    // يضيف مخططًا ببيانات افتراضية
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // تعيين عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // تعيين السلسلة الأولى لإظهار القيم
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // تعيين الفهرس لورقة بيانات المخطط
    int defaultWorksheetIndex = 0;
    
    // الحصول على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // إضافة فئات جديدة
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // إضافة سلاسل جديدة
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // ملء بيانات السلسلة
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // غير فعال في الإصدار الجديد
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // تعيين حدود القطاع
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // تعيين حدود القطاع
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // تعيين حدود القطاع
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // إنشاء تسميات مخصصة لكل فئة للسلسلة الجديدة
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // إظهار خطوط القائد للمخطط
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // تعيين زاوية الدوران لقطاعات المخطط الدائري
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // حفظ العرض التقديمي مع المخطط
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات خطية**

المخططات الخطية (المعروفة أيضًا بمخططات الخط) تُستخدم لعرض تغير القيم مع مرور الوقت. باستخدام مخطط خطي، يمكنك مقارنة بيانات كثيرة في آنٍ واحد، تتبع التغييرات والاتجاهات مع الوقت، وإبراز الشذوذ في السلاسل، وغيرها.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة عبر فهرسها.
1. إضافة مخطط ببيانات افتراضية والنوع المطلوب (في هذه الحالة، `ChartType.Line`).
1. الوصول إلى ورقة بيانات المخطط IChartDataWorkbook.
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات جديدة للسلسلة.
1. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية إنشاء مخطط خطي:
```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


بشكلٍ افتراضي، تُربط نقاط المخطط الخطي بخطوط مستقيمة مستمرة. إذا رغبت في ربط النقاط بخطوط متقطعة، يمكنك تحديد نوع الخط المتقطع بهذه الطريقة:
```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```


### **إنشاء مخططات خريطة شجرية**

تُعد مخططات الخريطة الشجرية مثالية لبيانات المبيعات عندما تريد إظهار حجم الفئات النسبية وفي الوقت نفسه جذب الانتباه إلى العناصر التي تساهم كثيرًا في كل فئة.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>الخطوات: إنشاء مخطط خريطة شجرية في Java</em></strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint خريطة شجرية في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint خريطة شجرية في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب (في هذه الحالة، [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).TreeMap).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للسلسلة.
8. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية إنشاء مخطط خريطة شجرية:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //فرع 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //فرع 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات مخزون**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>الخطوات: إنشاء مخطط مخزون في Java</em></strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint مخزون في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint مخزون في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للسلسلة.
8. تحديد تنسيق خطوط HiLowLines.
9. كتابة العرض المعدل كملف PPTX.

الكود Java النموذجي لإنشاء مخطط مخزون:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));

    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));

    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));

    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات صندوق ووشيك**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>الخطوات: إنشاء مخطط صندوق ووشيك في Java</em></strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint صندوق ووشيك في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint صندوق ووشيك في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للسلسلة.
8. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية إنشاء مخطط صندوق ووشيك:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات قمع**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>الخطوات: إنشاء مخطط قمع في Java</em></strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint قمع في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint قمع في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Funnel).
4. كتابة العرض المعدل كملف PPTX.

الكود Java يوضح كيفية إنشاء مخطط قمع:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات انفجار الشمس**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>الخطوات: إنشاء مخطط انفجار الشمس في Java</em></strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint انفجار الشمس في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint انفجار الشمس في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب (في هذه الحالة، [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).sunburst).
4. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية إنشاء مخطط انفجار الشمس:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //الفرع 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //الفرع 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات مدرج تكراري**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>الخطوات: إنشاء مخطط مدرج تكراري في Java</em></strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint مدرج تكراري في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint مدرج تكراري في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Histogram).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية إنشاء مخطط مدرج تكراري:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات رادار**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>الخطوات: إنشاء مخطط رادار في Java</em></strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint رادار في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint رادار في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات معينة وتحديد النوع المفضل (`ChartType.Radar` في هذه الحالة).
4. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية إنشاء مخطط رادار:
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات متعدد الفئات**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>الخطوات: إنشاء مخطط متعدد الفئات في Java</em></strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint متعدد الفئات في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint متعدد الفئات في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مخطط ببيانات افتراضية والنوع المطلوب ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).ClusteredColumn).
4. الوصول إلى ورقة بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للسلسلة.
8. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية إنشاء مخطط متعدد الفئات:
```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // إضافة السلسلة
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Save presentation with chart
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات خريطة**

المخطط الخريطي هو تصور لمنطقة تحتوي على بيانات. تُستخدم مخططات الخريطة للمقارنة بين البيانات أو القيم عبر المناطق الجغرافية.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>الخطوات: إنشاء مخطط خريطة في Java</em></strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>الخطوات: إنشاء مخطط PowerPoint خريطة في Java</em></strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>الخطوات: إنشاء مخطط عرض تقديمي PowerPoint خريطة في Java</em></strong></a>

هذا الكود Java يوضح كيفية إنشاء مخطط خريطة:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء مخططات مركبة**

المخطط المركب (أو مخطط كومبو) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح لك هذا المخطط إبراز أو مقارنة أو فحص الفروقات بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![The combination chart](combination_chart.png)

الكود Java التالي يوضح كيفية إنشاء المخطط المركب الموضح أعلاه في عرض تقديمي PowerPoint:
```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // تعيين عنوان المخطط.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // تعيين وسيلة إيضاح المخطط.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // حذف السلاسل والفئات الافتراضية التي تم إنشاؤها.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // إضافة فئات جديدة.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // إضافة السلسلة الأولى.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // تعيين المحور الأفقي.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // تعيين المحور الرأسي.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // تعيين لون خطوط الشبكة الرئيسية العمودية.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // تعيين المحور الأفقي الثانوي.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // تعيين المحور الرأسي الثانوي.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```


## **تحديث المخططات**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>الخطوات: تحديث مخطط PowerPoint في Java</em></strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>الخطوات: تحديث مخطط عرض تقديمي في Java</em></strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>الخطوات: تحديث مخطط عرض تقديمي PowerPoint في Java</em></strong></a>

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تمثل العرض التقديمي المحتوي على المخطط الذي تريد تحديثه.
2. الحصول على مرجع شريحة باستخدام فهرستها.
3. استعراض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى ورقة بيانات المخطط.
5. تعديل بيانات سلسلة المخطط بتغيير قيم السلسلة.
6. إضافة سلسلة جديدة وتعبئة البيانات فيها.
7. كتابة العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية تحديث مخطط:
```java
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // الحصول على المخطط مع البيانات الافتراضية
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // تعيين فهرس ورقة بيانات المخطط
    int defaultWorksheetIndex = 0;

    // جلب ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // تغيير اسم فئة المخطط
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // أخذ السلسلة الأولى للمخطط
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // الآن يتم تحديث بيانات السلسلة
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// تعديل اسم السلسلة
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // أخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1);

    // الآن يتم تحديث بيانات السلسلة
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// تعديل اسم السلسلة
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // الآن، إضافة سلسلة جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // أخذ السلسلة الثالثة للمخطط
    series = chart.getChartData().getSeries().get_Item(2);

    // الآن يتم ملء بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // حفظ العرض التقديمي مع المخطط
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحديد نطاق البيانات للمخططات**

لتحديد نطاق البيانات لمخطط، قم بما يلي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تمثل العرض التقديمي المحتوي على المخطط.
2. الحصول على مرجع شريحة عبر فهرستها.
3. استعراض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى بيانات المخطط وتحديد النطاق.
5. حفظ العرض المعدل كملف PPTX.

هذا الكود Java يوضح كيفية تحديد نطاق البيانات لمخطط:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **استخدام العلامات الافتراضية في المخططات**
عند استخدام علامة افتراضية في المخططات، يحصل كل سلسلة مخطط على رموز علامات افتراضية مختلفة تلقائيًا.

هذا الكود Java يوضح كيفية تعيين علامة سلسلة مخطط تلقائيًا:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    //أخذ السلسلة الثانية للمخطط
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //الآن يتم ملء بيانات السلسلة
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
