---
title: إنشاء أو تعديل مخططات عروض PowerPoint التقديمية على Android
linktitle: إنشاء أو تعديل المخططات
type: docs
weight: 10
url: /ar/androidjava/create-chart/
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
- مخطط صندوق وشوكة
- مخطط قمعي
- مخطط شمسية
- مخطط هيستوجرام
- مخطط راداري
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android. إضافة، تنسيق، وتحرير المخططات مع أمثلة عملية على شفرة Java."
---
## **نظرة عامة**

توفر هذه المقالة دليلًا شاملًا حول كيفية إنشاء المخططات وتخصيصها باستخدام Aspose.Slides. ستتعلم كيف تضيف مخططًا إلى شريحة برمجيًا، وتملأه بالبيانات، وتطبق خيارات تنسيق مختلفة لتتناسب مع متطلبات التصميم الخاصة بك. طوال المقالة، توضح أمثلة التعليمات البرمجية المفصلة كل خطوة، بدءًا من تهيئة العرض التقديمي وكائن المخطط إلى تكوين السلاسل والمحاور والوسائل الإيضاحية. باتباع هذا الدليل، ستحصل على فهم رصين لكيفية دمج إنشاء المخططات الديناميكية في تطبيقاتك، مما يبسط عملية إنشاء عروض تقديمية مدفوعة بالبيانات.

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واستخلاص رؤى قد لا تكون واضحة على الفور من جدول أو جدول بيانات.

**لماذا إنشاء المخططات؟**

* تجميع أو تكثيف أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في العرض التقديمي
* إظهار الأنماط والاتجاهات في البيانات
* استنتاج الاتجاه والزخم للبيانات مع مرور الوقت أو بالنسبة لوحدة قياس محددة
* اكتشاف القيم المتطرفة أو الشذوذ أو الانحرافات أو الأخطاء أو البيانات غير المنطقية، إلخ.
* تواصل أو عرض البيانات المعقدة

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة *Insert*، التي توفر قوالب لتصميم العديد من أنواع المخططات. باستخدام Aspose.Slides، يمكنك إنشاء مخططات قياسية (مستندة إلى أنواع المخططات الشائعة) ومخططات مخصصة.

{{% alert color="info" title="Note" %}}
لإنشاء المخططات، استخدم الفئة [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). الحقول في هذه الفئة تتوافق مع أنواع المخططات المختلفة.
{{% /alert %}}

### **إنشاء مخططات عمودية متجمعة**

تشرح هذه القسم كيفية إنشاء مخططات عمودية متجمعة باستخدام Aspose.Slides. ستتعلم تهيئة عرض تقديمي، إضافة مخطط، وتخصيص عناصره مثل العنوان والبيانات والسلاسل والفئات والتنسيق. اتبع الخطوات أدناه لرؤية كيفية إنشاء مخطط عمودي متجمع قياسي:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) .
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
1. إضافة مخطط مع بعض البيانات وتحديد النوع `ChartType.ClusteredColumn` .
1. إضافة عنوان إلى المخطط.
1. الوصول إلى ورقة بيانات المخطط.
1. مسح جميع السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات مخطط جديدة لسلسلة المخطط.
1. تطبيق لون تعبئة على سلسلة المخطط.
1. إضافة تسميات إلى سلسلة المخطط.
1. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود C# كيفية إنشاء مخطط عمودي متجمع:

```java
import com.aspose.slides.*;
import java.awt.Color;

// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
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
    
    // يأخذ سلسلة المخطط الأولى
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // يملأ الآن بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // يضبط لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // يأخذ سلسلة المخطط الثانية
    series = chart.getChartData().getSeries().get_Item(1);
    
    // يملاً بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // يضبط لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //أنشئ تسميات مخصصة لكل فئة للسلسلة الجديدة
    // يضبط التسمية الأولى لإظهار اسم الفئة
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // يعرض القيمة للتسمية الثالثة
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // يحفظ العرض التقديمي مع المخطط
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات التبعثر**

مخططات التبعثر (المعروفة أيضًا بمخططات النشر أو الرسوم البيانية x‑y) تُستخدم غالبًا للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

استخدم مخطط التبعثر عندما:

* لديك بيانات رقمية مُقترنة
* لديك متغيران يتكاملان معًا
* ترغب في تحديد ما إذا كان المتغيران مرتبطين
* لديك متغير مستقل له قيم متعددة لمتغير تابع

1. اتبع الخطوات في [Create Clustered Column Charts](#create-clustered-column-charts).
2. للخطوة الثالثة، أضف مخططًا مع بعض البيانات وحدد نوع المخطط كواحد من التالي:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _يمثل مخطط تبعثر._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _يمثل مخطط تبعثر متصل بمنحنيات، مع علامات البيانات._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _يمثل مخطط تبعثر متصل بمنحنيات، دون علامات البيانات._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _يمثل مخطط تبعثر متصل بخطوط، مع علامات البيانات._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _يمثل مخطط تبعثر متصل بخطوط، دون علامات البيانات._

يعرض هذا الكود Java كيفية إنشاء مخطط تبعثر بعلامات مختلفة لكل سلسلة:

```java
import com.aspose.slides.*;

// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // ينشئ المخطط الافتراضي
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // يحصل على فهرس ورقة عمل بيانات المخطط الافتراضي
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
    
    // يغير نوع السلسلة
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // يغير علامة سلسلة المخطط
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
    
    // يغير علامة سلسلة المخطط
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات دائرية**

تُستخدم المخططات الدائرية لإظهار علاقة الجزء بالكل في البيانات، خصوصًا عندما تحتوي البيانات على تسميات فئوية مع قيم رقمية. ومع ذلك، إذا كانت بياناتك تحتوي على العديد من الأجزاء أو التسميات، قد ترغب في استخدام مخطط شريطي بدلاً من ذلك.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType.Pie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Pie) .
4. الوصول إلى دفتر بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. إضافة نقاط جديدة للمخطط وتطبيق ألوان مخصصة لشرائح المخطط الدائري.
9. تعيين تسميات للسلاسل.
10. تمكين خطوط القادة لتسميات السلاسل.
11. تعيين زاوية الدوران لشرائح المخطط الدائري.
12. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط دائري:

```java
import com.aspose.slides.*;
import java.awt.Color;

// ينشئ فئة عرض تقديمي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide slides = pres.getSlides().get_Item(0);
    
    // يضيف مخططًا ببيانات افتراضية
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
    
    // يملأ بيانات السلسلة
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // لا يعمل في الإصدارة الجديدة
    // إضافة نقاط جديدة وتعيين لون القطاع
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
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    // ينشئ تسميات مخصصة لكل فئة لسلسلة جديدة
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
    
    // يظهر خطوط القادة للمخطط
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // يضبط زاوية الدوران لشرائح المخطط الدائري
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // يحفظ العرض التقديمي مع المخطط
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات خطية**

تُستخدم المخططات الخطية (المعروفة أيضًا بالرسوم البيانية الخطية) في الحالات التي تريد فيها توضيح تغيّر القيم مع مرور الوقت. باستخدام مخطط خطي، يمكنك مقارنة كمية كبيرة من البيانات مرة واحدة، تتبع التغييرات والاتجاهات مع الزمن، إبراز الشذوذ في سلاسل البيانات، وأكثر.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
1. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType.Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Line) .
1. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط خطي:

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

افتراضياً، تُربط نقاط المخطط الخطي بخطوط مستمرة مستقيمة. إذا رغبت في ربط النقاط بخطوط متقطعة، يمكنك تحديد نوع الخط المتقطع المفضل كما يلي:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء مخططات شجرة خرائط**

تُستخدم مخططات شجرة الخرائط لبيانات المبيعات عندما تريد إظهار الحجم النسبي لفئات البيانات وجذب الانتباه بسرعة إلى العناصر التي تُساهم بشكل كبير داخل كل فئة.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType.Treemap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Treemap) .
4. الوصول إلى دفتر بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط شجرة خريطة:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
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

### **إنشاء مخططات أسهم**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#OpenHighLowClose) .
4. الوصول إلى دفتر بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. تحديد تنسيق خطوط الارتفاع‑الانخفاض.
9. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط أسهم:

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

### **إنشاء مخططات صندوقي وشوكي**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#BoxAndWhisker) .
4. الوصول إلى دفتر بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط صندوقي وشوكي:

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

### **إنشاء مخططات قمعية**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType.Funnel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Funnel) .
4. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط قمعي:

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

### **إنشاء مخططات شمسية**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType.Sunburst](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Sunburst) .
4. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط شمسية:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    // الفرع 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    // الفرع 2
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

### **إنشاء مخططات هيستوجرام**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType.Histogram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Histogram) .
4. الوصول إلى دفتر بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط هيستوجرام:

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

### **إنشاء مخططات رادارية**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط ببيانات معينة وتحديد نوع المخطط المفضَّل ([ChartType.Radar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Radar) في هذه الحالة).
4. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط راداري:

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

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية وتحديد النوع [ChartType.ClusteredColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ClusteredColumn) .
4. الوصول إلى دفتر بيانات المخطط [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية إنشاء مخطط متعدد الفئات:

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

تُظهر مخططات الخريطة بيانات جغرافية وتساعد في مقارنة القيم عبر المناطق.

يعرض هذا الكود Java كيفية إنشاء مخطط خريطة:

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

مخطط مركب (أو مخطط مزيج) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح لك هذا المخطط تسليط الضوء، مقارنة، أو فحص الفروقات بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![المخطط المركب](combination_chart.png)

يعرض الكود Java التالي كيفية إنشاء المخطط المركب المعروض أعلاه في عرض PowerPoint:

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

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) التي تمثل العرض التقديمي الذي يحتوي على المخطط المراد تحديثه.
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. استعراض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى ورقة بيانات المخطط.
5. تعديل سلاسل بيانات المخطط بتغيير قيم السلاسل.
6. إضافة سلسلة جديدة وتعبئة بياناتها.
7. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية تحديث مخطط:

```java
import com.aspose.slides.*;

// يفتح العرض التقديمي الذي يحتوي على المخطط المراد تحديثه
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // الحصول على المخطط من الشريحة
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // تعيين فهرس ورقة بيانات المخطط
    int defaultWorksheetIndex = 0;

    // الحصول على ورقة عمل بيانات المخطط
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

## **تعيين نطاق البيانات لمخطط**

لتفحص النطاق المستخدم بالفعل بواسطة مخطط موجود، راجع [Retrieve a Chart's Data Range](/slides/ar/androidjava/chart-workbook/#retrieve-a-charts-data-range).

لتعيين نطاق البيانات لمخطط، نفّذ ما يلي:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) التي تمثل العرض التقديمي الذي يحتوي على المخطط.
2. الحصول على مرجع إلى شريحة باستخدام الفهرس الخاص بها.
3. استعراض جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى بيانات المخطط وتعيين النطاق.
5. حفظ العرض التقديمي المُعدَّل كملف PPTX.

يعرض هذا الكود Java كيفية تعيين نطاق البيانات لمخطط:

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

يعرض هذا الكود Java كيفية تعيين علامة سلسلة مخطط تلقائيًا:

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

    // الآن يتم ملء بيانات السلسلة
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

## **الأسئلة الشائعة**

**ما هي أنواع المخططات التي تدعمها Aspose.Slides؟**

تدعم Aspose.Slides مجموعة واسعة من [chart types](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/)، بما في ذلك المخططات الشريطية، الخطية، الدائرية، المساحية، التبعثر، الهيستوجرام، الرادارية، والعديد غيرها. تتيح لك هذه المرونة اختيار النوع الأنسب لتصوير بياناتك.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، أولاً أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، احصل على الشريحة المطلوبة باستخدام الفهرس، ثم استدعِ الطريقة لإضافة مخطط مع تحديد نوع المخطط والبيانات الأولية. يدمج هذا العملية المخطط مباشرةً في عرضك التقديمي.

**كيف يمكنني تحديث البيانات المعروضة في مخطط؟**

يمكنك تحديث بيانات المخطط بالوصول إلى دفتر بياناته ([IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/))، مسح أي سلاسل وفئات افتراضية، ثم إضافة بياناتك المخصصة. يتيح لك ذلك تحديث المخطط ليعكس أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، توفر Aspose.Slides خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، الأساطير، وعناصر [formatting elements](/slides/ar/androidjava/chart-entities/) الأخرى لتلائم مظهر المخطط مع متطلبات التصميم الخاصة بك.