---
title: إنشاء أو تحديث مخططات عروض PowerPoint في Java
linktitle: إنشاء أو تحديث المخططات
type: docs
weight: 10
url: /ar/java/create-chart/
keywords:
- إضافة مخطط
- إنشاء مخطط
- تحرير مخطط
- تغيير مخطط
- تحديث مخطط
- مخطط مبعثر
- مخطط دائري
- مخطط خطي
- مخطط شجرة خريطة
- مخطط أسهم
- مخطط صندوق وشوارب
- مخطط قمع
- مخطط أشعة شمسية
- مخطط مدرج تكراري
- مخطط رادار
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: إنشاء وتخصيص المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ Java. إضافة، تنسيق، وتحرير المخططات مع أمثلة شفرة عملية في Java.
---
## **نظرة عامة**

توفر هذه المقالة دليلًا شاملًا حول كيفية إنشاء وتخصيص المخططات باستخدام Aspose.Slides. ستتعلم كيفية إضافة مخطط إلى شريحة برمجيًا، وتعبئته بالبيانات، وتطبيق خيارات تنسيق مختلفة لتتماشى مع متطلبات التصميم الخاصة بك. طوال المقالة، توضح أمثلة الشيفرة المفصلة كل خطوة، بدءًا من تهيئة العرض وكائن المخطط إلى تكوين السلاسل والمحاور والوساطات. باتباع هذا الدليل، ستحصل على فهم قوي لكيفية دمج إنشاء مخططات ديناميكية في تطبيقاتك، مما يبسط عملية إنشاء عروض تقديمية مدفوعة بالبيانات.

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واكتساب رؤى قد لا تكون واضحة على الفور من جدول أو جدول بيانات.

**لماذا إنشاء المخططات؟**

* تجميع أو تلخيص أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في العرض التقديمي  
* كشف الأنماط والاتجاهات في البيانات  
* استنتاج اتجاه وزخم البيانات مع مرور الوقت أو بالنسبة إلى وحدة قياس معينة  
* اكتشاف القيم المتطرفة، الشذوذ، الانحرافات، الأخطاء، البيانات غير المنطقية، إلخ.  
* التواصل أو عرض البيانات المعقدة  

في PowerPoint، يمكنك إنشاء مخططات عبر وظيفة *Insert*، التي توفر قوالب لتصميم العديد من أنواع المخططات. باستخدام Aspose.Slides، يمكنك إنشاء كل من المخططات العادية (المستندة إلى أنواع المخططات الشائعة) والمخططات المخصصة.

{{% alert color="info" title="Note" %}}
لإنشاء المخططات، استخدم فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) . الحقول في هذه الفئة تتطابق مع أنواع المخططات المختلفة.
{{% /alert %}}

### **إنشاء مخططات عمودية مُجمّعة**

تشرح هذه الفقرة كيفية إنشاء مخططات عمودية مُجمّعة باستخدام Aspose.Slides. ستتعلم تهيئة عرض تقديمي، إضافة مخطط، وتخصيص عناصره مثل العنوان، البيانات، السلاسل، الفئات، والتنسيق. اتبع الخطوات أدناه لمعرفة كيفية إنشاء مخطط عمودي مُجمّع قياسي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا مع بعض البيانات وحدد النوع `ChartType.ClusteredColumn` .
4. أضف عنوانًا إلى المخطط.
5. الوصول إلى جدول بيانات مخطط البيانات.
6. امسح جميع السلاسل والفئات الافتراضية.
7. أضف سلاسل وفئات جديدة.
8. أضف بيانات مخطط جديدة لسلسلة المخطط.
9. تطبيق لون تعبئة على سلسلة المخطط.
10. أضف تسميات إلى سلسلة المخطط.
11. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;
import java.awt.Color;

// ينشئ كائن فئة العرض التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);
    
    // يضيف مخططًا ببياناته الافتراضية
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // يضبط عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // يضبط الفهرس لورقة بيانات المخطط
    int defaultWorksheetIndex = 0;
    
    // يحصل على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // يحذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // يضيف سلاسل جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // يضيف فئات جديدة
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // يأخذ السلسلة الأولى للمخطط
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // الآن يملء بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // يضبط لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // يأخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1);
    
    // يملء بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // يضبط لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //إنشاء تسميات مخصصة لكل فئة للسلسلة الجديدة
    // يضبط التسمية الأولى لإظهار اسم الفئة
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // يظهر القيمة للتسمية الثالثة
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // يحفظ العرض مع المخطط
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات مبعثرة**

المخططات المبعثرة (المعروفة أيضًا باسم مخططات التبعثر أو الرسوم البيانية x-y) تُستخدم غالبًا للتحقق من الأنماط أو توضيح الارتباطات بين متغيرين.

استخدم مخططًا مبعثراً عندما:

* لديك بيانات عددية مزدوجة  
* لديك متغيران يتطابقان معًا بشكل جيد  
* ترغب في تحديد ما إذا كان المتغيران مرتبطين  
* لديك متغير مستقل له قيم متعددة للمتغير التابع  

1. اتبع الخطوات في [إنشاء مخططات عمودية مُجمّعة](#create-clustered-column-charts).  
2. للخطوة الثالثة، أضف مخططًا مع بعض البيانات وحدد نوع المخطط كواحد من التالي:  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _يمثل مخططًا مبعثراً._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _يمثل مخططًا مبعثراً متصلًا بمنحنيات، مع علامات البيانات._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _يمثل مخططًا مبعثراً متصلًا بمنحنيات، بدون علامات البيانات._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _يمثل مخططًا مبعثراً متصلًا بخطوط، مع علامات البيانات._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _يمثل مخططًا مبعثراً متصلًا بخطوط، بدون علامات البيانات._

```java
import com.aspose.slides.*;

// ينشئ كائن فئة عرض تمثّل ملف PPTX
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
    
    // يحذف سلسلة العرض التجريبية
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

تُعد المخططات الدائرية مثالية لإظهار العلاقة بين الجزء والكامل في البيانات، خاصةً عندما تحتوي البيانات على تسميات فئوية مع قيم عددية. ومع ذلك، إذا كان لديك العديد من الأجزاء أو التسميات، قد تفضّل استخدام مخطط شريطي بدلاً من ذلك.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Pie](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Pie) .
4. الوصول إلى دفتر عمل بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) .
5. امسح السلاسل والفئات الافتراضية.
6. أضف سلاسل وفئات جديدة.
7. أضف بيانات مخطط جديدة لسلسلة المخطط.
8. أضف نقاطًا جديدة للمخطط وطبق ألوانًا مخصصة لشرائح المخطط الدائري.
9. اضبط التسميات للسلاسل.
10. تمكين خطوط القائد لتسميات السلسلة.
11. ضبط زاوية الدوران لشرائح المخطط الدائري.
12. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;
import java.awt.Color;

// ينشئ كائن فئة عرض تمثّل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slides = pres.getSlides().get_Item(0);
    
    // يضيف مخططًا ببياناته الافتراضية
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // يضبط عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // يضبط الفهرس لورقة بيانات المخطط
    int defaultWorksheetIndex = 0;
    
    // يحصل على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // يحذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // يضيف فئات جديدة
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // يضيف سلاسل جديدة
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // يملء بيانات السلسلة
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // لا يعمل في النسخة الجديدة
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // يضبط حد القطاع
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // يضبط حد القطاع
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // يضبط حد القطاع
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // ينشئ تسميات مخصصة لكل فئة للسلسلة الجديدة
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
    
    // يظهر خطوط القائد للمخطط
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // يضبط زاوية الدوران لشرائح المخطط الدائري
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // يحفظ العرض مع المخطط
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات خطية**

تُستخدم المخططات الخطية (المعروفة أيضًا بمخططات الخطوط) بشكل أساسي عندما تريد إظهار تغيّر القيم مع مرور الوقت. باستخدام مخطط خطي، يمكنك مقارنة كمية كبيرة من البيانات مرة واحدة، تتبع التغيّرات والاتجاهات مع الوقت، إبراز الشذوذ في سلاسل البيانات، وأكثر.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Line](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Line) .
4. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

بشكل افتراضي، يتم ربط النقاط في مخطط خطي بخطوط مستمرة مستقيمة. إذا أردت ربط النقاط بخطوط متقطعة بدلاً من ذلك، يمكنك تحديد نوع الخط المتقطع المفضّل كما يلي:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات شجرة الخريطة**

تُعد مخططات شجرة الخريطة مثالية لبيانات المبيعات عندما تريد إظهار الحجم النسبي لفئات البيانات وجذب الانتباه بسرعة إلى العناصر التي تشكل مساهمات كبيرة داخل كل فئة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Treemap](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Treemap) .
4. الوصول إلى دفتر عمل بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) .
5. امسح السلاسل والفئات الافتراضية.
6. أضف سلاسل وفئات جديدة.
7. أضف بيانات مخطط جديدة لسلسلة المخطط.
8. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    // فرع 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    // فرع 2
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

### **إنشاء مخططات الأسهم**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#OpenHighLowClose) .
4. الوصول إلى دفتر عمل بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) .
5. امسح السلاسل والفئات الافتراضية.
6. أضف سلاسل وفئات جديدة.
7. أضف بيانات مخطط جديدة لسلسلة المخطط.
8. حدد تنسيق خطوط الارتفاع‑الانخفاض.
9. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

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

### **إنشاء مخططات الصندوق والشارب**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#BoxAndWhisker) .
4. الوصول إلى دفتر عمل بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) .
5. امسح السلاسل والفئات الافتراضية.
6. أضف سلاسل وفئات جديدة.
7. أضف بيانات مخطط جديدة لسلسلة المخطط.
8. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

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

### **إنشاء مخططات القمع**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Funnel](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Funnel) .
4. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

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

### **إنشاء مخططات أشعة الشمس**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Sunburst](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Sunburst) .
4. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    // فرع 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    // فرع 2
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

### **إنشاء مخططات المدرج التكراري**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Histogram](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Histogram) .
4. الوصول إلى دفتر عمل بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) .
5. امسح السلاسل والفئات الافتراضية.
6. أضف سلاسل وفئات جديدة.
7. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات الرادار**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببعض البيانات وحدد نوع المخطط المفضَّل ([ChartType.Radar](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Radar) في هذه الحالة).
4. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات متعددة الفئات**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.ClusteredColumn](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ClusteredColumn) .
4. الوصول إلى دفتر عمل بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) .
5. امسح السلاسل والفئات الافتراضية.
6. أضف سلاسل وفئات جديدة.
7. أضف بيانات مخطط جديدة لسلسلة المخطط.
8. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

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
    
    // حفظ العرض التقديمي مع المخطط
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات خريطة**

تُظهر مخططات الخريطة البيانات الجغرافية وتساعد على مقارنة القيم عبر المناطق.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات مركبة**

مخطط مركب (أو مخطط مزيج) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح لك هذا المخطط إبراز أو مقارنة أو فحص الفروق بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![مخطط مركب](combination_chart.png)

الكود الجافا التالي يوضح كيفية إنشاء المخطط المركب المعروض أعلاه في عرض PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // ضبط عنوان المخطط.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // ضبط وسيلة إيضاح المخطط.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا.
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
    // ضبط المحور الأفقي.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // ضبط المحور الرأسي.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // ضبط لون خطوط الشبكة العمودية الرئيسية.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // ضبط المحور الأفقي الثانوي.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // ضبط المحور الرأسي الثانوي.
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

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) التي تمثل العرض الذي يحتوي على المخطط الذي تريد تحديثه.
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. استعرض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى ورقة عمل بيانات المخطط.
5. تعديل سلاسل بيانات المخطط عن طريق تغيير قيم السلسلة.
6. إضافة سلسلة جديدة وتعبئة بياناتها.
7. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

// يفتح العرض التقديمي الذي يحتوي على المخطط لتحديثه
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // احصل على المخطط من الشريحة
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // تحديد فهرس ورقة بيانات المخطط
    int defaultWorksheetIndex = 0;

    // الحصول على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // تغيير اسم فئة المخطط
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // أخذ السلسلة الأولى للمخطط
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // تحديث بيانات السلسلة الآن
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// تعديل اسم السلسلة
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // أخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1);

    // تحديث بيانات السلسلة الآن
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// تعديل اسم السلسلة
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // الآن، إضافة سلسلة جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // أخذ السلسلة الثالثة للمخطط
    series = chart.getChartData().getSeries().get_Item(2);

    // ملء بيانات السلسلة الآن
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

## **تعيين نطاق البيانات لمخطط**

لتفقد النطاق المستخدم بالفعل من قبل مخطط موجود، راجع [استرجاع نطاق بيانات المخطط](/slides/ar/java/chart-workbook/#retrieve-a-charts-data-range).

لتعيين نطاق البيانات لمخطط، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) التي تمثل العرض الذي يحتوي على المخطط.
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. استعرض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى بيانات المخطط وتعيين النطاق.
5. احفظ العرض المعدل كملف PPTX .

```java
import com.aspose.slides.*;

// يفتح العرض التقديمي الذي يحتوي على المخطط
Presentation pres = new Presentation("ExistingChart.pptx");
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

عند استخدام العلامات الافتراضية في المخططات، يحصل كل سلسلة مخطط تلقائيًا على رمز علامة مختلف.

```java
import com.aspose.slides.*;

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
    // أخذ السلسلة الثانية للمخطط
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // الآن تعبئة بيانات السلسلة
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

## **الأسئلة المتكررة**

**ما هي أنواع المخططات المدعومة من قبل Aspose.Slides؟**

يدعم Aspose.Slides مجموعة واسعة من [أنواع المخططات](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)، بما في ذلك المخطط العمودي، المخطط الخطي، المخطط الدائري، المخطط المساحي، المخطط المبعثر، المدرج التكراري، الرادار، وغيرها الكثير. تتيح لك هذه المرونة اختيار نوع المخطط الأنسب لاحتياجات تصور بياناتك.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، تحتاج أولًا إلى إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ، استرجاع الشريحة المطلوبة باستخدام فهرستها، ثم استدعاء الطريقة لإضافة مخطط، محددًا نوع المخطط والبيانات الأولية. يدمج هذا العملية المخطط مباشرة في عرضك.

**كيف يمكنني تحديث البيانات المعروضة في مخطط؟**

يمكنك تحديث بيانات المخطط عن طريق الوصول إلى دفتر عمل البيانات الخاص به ([IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/))، مسح أي سلاسل وفئات افتراضية، ثم إضافة بياناتك المخصصة. يتيح لك ذلك تجديد المخطط ليعكس أحدث البيانات.

**هل من الممكن تخصيص مظهر المخطط؟**

نعم، توفر Aspose.Slides خيارات تخصيص شاملة. يمكنك تعديل الألوان، الخطوط، التسميات، الوساطات، و[عناصر التنسيق](/slides/ar/java/chart-entities/) لتكييف مظهر المخطط وفقًا لمتطلبات التصميم الخاصة بك.