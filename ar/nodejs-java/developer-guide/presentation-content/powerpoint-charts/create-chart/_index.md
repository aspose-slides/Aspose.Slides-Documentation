---
title: إنشاء أو تحديث مخططات عرض PowerPoint في JavaScript
linktitle: إنشاء أو تحديث المخططات
type: docs
weight: 10
url: /ar/nodejs-java/create-chart/
keywords:
- إضافة مخطط
- إنشاء مخطط
- تعديل مخطط
- تغيير مخطط
- تحديث مخطط
- مخطط مبعثر
- مخطط دائري
- مخطط خطي
- مخطط شجرة خريطة
- مخطط أسهم
- مخطط صندوق وشارب
- مخطط قمع
- مخطط شمسية
- مخطط هيستوجرام
- مخطط رادار
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint باستخدام Aspose.Slides للـ Node.js. إضافة، تنسيق، وتعديل المخططات مع أمثلة عملية للشفرة في JavaScript."
---
## **نظرة عامة**

توفر هذه المقالة دليلاً شاملاً حول كيفية إنشاء المخططات وتخصيصها باستخدام Aspose.Slides. ستتعلم كيفية إضافة مخطط إلى شريحة برمجيًا، ملئه بالبيانات، وتطبيق خيارات تنسيق مختلفة لتتناسب مع متطلبات التصميم الخاصة بك. خلال المقالة، تُظهر أمثلة الشيفرة التفصيلية كل خطوة، بدءًا من تهيئة العرض وكائن المخطط إلى ضبط السلاسل والمحاور والوسائل الإيضاحية. باتباع هذا الدليل، ستحصل على فهم قوي لكيفية دمج إنشاء المخططات الديناميكية في تطبيقاتك، مما يُسهل عملية إنشاء عروض تقديمية مدفوعة بالبيانات.

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واستخلاص رؤى قد لا تكون واضحة فورًا من جدول أو ورقة عمل.

**لماذا إنشاء المخططات؟**

* تجميع، تكثيف، أو تلخيص كميات كبيرة من البيانات في شريحة واحدة داخل عرض تقديمي  
* كشف الأنماط والاتجاهات في البيانات  
* استنتاج اتجاه وزخم البيانات بمرور الوقت أو بالنسبة لوحدة قياس معينة  
* اكتشاف القيم المتطرفة، الشذوذ، الانحرافات، الأخطاء، البيانات غير المنطقية، إلخ  
* نقل أو عرض البيانات المعقدة  

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة *Insert*، التي توفر قوالب لتصميم أنواع عديدة من المخططات. باستخدام Aspose.Slides، يمكنك إنشاء كل من المخططات العادية (المستندة إلى أنواع المخططات الشائعة) والمخططات المخصصة.

{{% alert color="info" title="Note" %}}
لإنشاء المخططات، استخدم الفئة [ChartType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/) . الحقول في هذه الفئة تتطابق مع أنواع المخططات المختلفة.
{{% /alert %}}

### **إنشاء مخططات الأعمدة المتجمعة**

يوضح هذا القسم كيفية إنشاء مخططات الأعمدة المتجمعة باستخدام Aspose.Slides. ستتعلم كيفية تهيئة عرض تقديمي، إضافة مخطط، وتخصيص عناصره مثل العنوان، البيانات، السلاسل، الفئات، والأنماط. اتبع الخطوات أدناه لرؤية كيفية إنشاء مخطط عمود متجمع قياسي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. إضافة مخطط مع بعض البيانات وتحديد النوع `ChartType.ClusteredColumn` .
4. إضافة عنوان إلى المخطط.
5. الوصول إلى ورقة بيانات المخطط.
6. مسح جميع السلاسل والفئات الافتراضية.
7. إضافة سلاسل وفئات جديدة.
8. إضافة بيانات مخطط جديدة لسلسلة المخطط.
9. تطبيق لون تعبئة على سلسلة المخطط.
10. إضافة تسميات إلى سلسلة المخطط.
11. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// يُنشئ كائن فئة عرض تقديمي تمثّل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var sld = pres.getSlides().get_Item(0);
    // إضافة مخطط مع بياناته الافتراضية
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // تعيين عنوان المخطط
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // تعيين السلسلة الأولى لعرض القيم
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // تعيين الفهرس لورقة بيانات المخطط
    var defaultWorksheetIndex = 0;
    // الحصول على ورقة عمل بيانات المخطط
    var fact = chart.getChartData().getChartDataWorkbook();
    // حذف السلاسل والفئات المُنشأة افتراضيًا
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // إضافة سلاسل جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // إضافة فئات جديدة
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // أخذ السلسلة الأولى للمخطط
    var series = chart.getChartData().getSeries().get_Item(0);
    // الآن يتم تعبئة بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // تعيين لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // أخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1);
    // تعبئة بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // تعيين لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // إنشاء تسميات مخصصة لكل فئة للسلسلة الجديدة
    // تعيين التسمية الأولى لعرض اسم الفئة
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // عرض القيمة للتسمية الثالثة
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // حفظ العرض التقديمي مع المخطط
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات التشتت**

مخططات التشتت (المعروفة أيضًا بمخططات التناثر أو رسوم x‑y) تُستخدم غالبًا للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

استخدم مخطط التشتت عندما:

* لديك بيانات عددية مزدوجة  
* لديك متغيران يتناسقان معًا  
* ترغب في تحديد ما إذا كان المتغيران مرتبطين  
* لديك متغير مستقل يحتوي على قيم متعددة للمتغير التابع  

1. اتبع الخطوات في [Create Clustered Column Charts](#create-clustered-column-charts).  
2. في الخطوة الثالثة، أضف مخططًا مع بعض البيانات وحدد نوع المخطط كأحد الأنواع التالية:  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _يمثل مخطط تشتت._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _يمثل مخطط تشتت متصل بمنحنيات، مع علامات بيانات._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _يمثل مخطط تشتت متصل بمنحنيات، بدون علامات بيانات._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _يمثل مخطط تشتت متصل بخطوط، مع علامات بيانات._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _يمثل مخطط تشتت متصل بخطوط، بدون علامات بيانات._

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// يُنشئ كائن فئة عرض تقديمي يمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إنشاء المخطط الافتراضي
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // الحصول على فهرس ورقة عمل بيانات المخطط الافتراضية
    var defaultWorksheetIndex = 0;
    // الحصول على ورقة عمل بيانات المخطط
    var fact = chart.getChartData().getChartDataWorkbook();
    // حذف السلسلة التجريبية
    chart.getChartData().getSeries().clear();
    // إضافة سلاسل جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // أخذ السلسلة الأولى للمخطط
    var series = chart.getChartData().getSeries().get_Item(0);
    // إضافة نقطة جديدة (1:3) إلى السلسلة
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // إضافة نقطة جديدة (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // تغيير نوع السلسلة
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // تغيير علامة سلسلة المخطط
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // أخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1);
    // إضافة نقطة جديدة (5:2) هناك
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // إضافة نقطة جديدة (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // إضافة نقطة جديدة (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // إضافة نقطة جديدة (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // تغيير علامة سلسلة المخطط
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات الفطيرة**

تُستخدم مخططات الفطيرة بشكل أفضل لإظهار العلاقة بين الجزء والكل في البيانات، خاصةً عندما تحتوي البيانات على تسميات فئوية مع قيم عددية. ومع ذلك، إذا احتوت بياناتك على العديد من الأجزاء أو التسميات، قد ترغب في التفكير باستخدام مخطط شريطي بدلاً من ذلك.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Pie](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#Pie) .
4. الوصول إلى دفتر عمل بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. إضافة نقاط جديدة للمخطط وتطبيق ألوان مخصصة لقطاعات مخطط الفطيرة.
9. تعيين تسميات للسلسلة.
10. تمكين خطوط ربط لتسميات السلسلة.
11. تعيين زاوية الدوران لقطاعات مخطط الفطيرة.
12. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// يُنشئ فئة عرض تقديمي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slides = pres.getSlides().get_Item(0);
    // إضافة مخطط مع البيانات الافتراضية
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // تعيين عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // تعيين السلسلة الأولى لعرض القيم
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // تعيين الفهرس لورقة بيانات المخطط
    var defaultWorksheetIndex = 0;
    // الحصول على ورقة عمل بيانات المخطط
    var fact = chart.getChartData().getChartDataWorkbook();
    // حذف السلسلة والفئات التي تم إنشاؤها افتراضيًا
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // إضافة فئات جديدة
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // إضافة سلاسل جديدة
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // تعبئة بيانات السلسلة
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // لا يعمل في الإصدار الجديد
    // إضافة نقاط جديدة وتعيين لون القطاع
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // تعيين حد القطاع
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // تعيين حد القطاع
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // تعيين حد القطاع
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // إنشاء تسميات مخصصة لكل فئة للسلسلة الجديدة
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // إظهار خطوط القائد للمخطط
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // تعيين زاوية الدوران لقطاعات مخطط الفطيرة
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // حفظ العرض التقديمي مع مخطط
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات الخط**

مخططات الخط (المعروفة أيضًا بخرائط الخط) تُستخدم بشكل أفضل في الحالات التي تريد فيها إظهار تغير القيم بمرور الوقت. باستخدام مخطط الخط، يمكنك مقارنة كمية كبيرة من البيانات مرة واحدة، تتبع التغييرات والاتجاهات بمرور الوقت، إبراز الشذوذ في سلاسل البيانات، وأكثر من ذلك.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Line](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#Line) .
4. الوصول إلى دفتر عمل بيانات المخطط ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/)) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

افتراضيًا، يتم ربط نقاط مخطط الخط بخطوط مستقيمة مستمرة. إذا رغبت في ربط النقاط بخطوط متقطعة بدلاً من ذلك، يمكنك تحديد نوع الخط المتقطع المفضل كالتالي:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات شجرة الخريطة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Treemap](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#Treemap) .
4. الوصول إلى دفتر عمل بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // الفرع 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
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
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات الأسهم**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) .
4. الوصول إلى دفتر عمل بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. تحديد تنسيق خطوط الارتفاع‑الانخفاض.
9. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات الصندوق والشارب**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) .
4. الوصول إلى دفتر عمل بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
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
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات القمع**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Funnel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#Funnel) .
4. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات Sunburst**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Sunburst](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#Sunburst) .
4. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // الفرع 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
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
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات الهيستوجرام**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Histogram](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#Histogram) .
4. الوصول إلى دفتر عمل بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **إنشاء مخططات الرادار**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببعض البيانات وحدد نوع المخطط المفضل ([ChartType.Radar](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#Radar) في هذه الحالة).
4. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات متعددة الفئات**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) .
2. الحصول على مرجع لشريحة باستخدام فهرسها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/#ClusteredColumn) .
4. الوصول إلى دفتر عمل بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة لسلسلة المخطط.
8. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    // إضافة سلسلة
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // حفظ العرض التقديمي مع المخطط
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات الخريطة**

مخططات الخريطة تُظهر البيانات الجغرافية وتساعد في مقارنة القيم عبر المناطق.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **إنشاء مخططات مركبة**

مخطط مركب (أو مخطط مزيج) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح لك هذا المخطط إبراز، مقارنة، أو فحص الفروق بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![مخطط مركب](combination_chart.png)

الشيفرة التالية بلغة JavaScript توضح كيفية إنشاء مخطط المركب المعروض أعلاه في عرض PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // تعيين عنوان المخطط.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // تعيين وسيلة إيضاح المخطط.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // إضافة فئات جديدة.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // إضافة السلسلة الأولى.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // تعيين المحور الأفقي.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // تعيين المحور العمودي.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // تعيين لون خطوط الشبكة العمودية الرئيسية.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // تعيين المحور الأفقي الثانوي.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // تعيين المحور العمودي الثانوي.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **تحديث المخططات**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) التي تمثل العرض التقديمي الذي يحتوي على المخطط الذي تريد تحديثه.  
2. الحصول على مرجع لشريحة باستخدام فهرسها.  
3. التنقل عبر جميع الأشكال للعثور على المخطط المطلوب.  
4. الوصول إلى ورقة بيانات المخطط.  
5. تعديل سلاسل بيانات المخطط عن طريق تغيير قيم السلسلة.  
6. إضافة سلسلة جديدة وتعبئة بياناتها.  
7. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // الوصول إلى أول شريحة
    var sld = pres.getSlides().get_Item(0);
    // الحصول على المخطط مع البيانات الافتراضية
    var chart = sld.getShapes().get_Item(0);
    // تعيين فهرس ورقة بيانات المخطط
    var defaultWorksheetIndex = 0;
    // الحصول على ورقة عمل بيانات المخطط
    var fact = chart.getChartData().getChartDataWorkbook();
    // تغيير اسم فئة المخطط
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // استخراج السلسلة الأولى للمخطط
    var series = chart.getChartData().getSeries().get_Item(0);
    // الآن يتم تحديث بيانات السلسلة
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // تعديل اسم السلسلة
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // استخراج السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1);
    // الآن يتم تحديث بيانات السلسلة
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // تعديل اسم السلسلة
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // الآن، إضافة سلسلة جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // استخراج السلسلة الثالثة للمخطط
    series = chart.getChartData().getSeries().get_Item(2);
    // الآن يتم تعبئة بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // حفظ العرض التقديمي مع المخطط
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تحديد نطاق البيانات لمخطط**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) التي تمثل العرض التقديمي الذي يحتوي على المخطط.  
2. الحصول على مرجع لشريحة باستخدام فهرسها.  
3. التنقل عبر جميع الأشكال للعثور على المخطط المطلوب.  
4. الوصول إلى بيانات المخطط وتحديد النطاق.  
5. حفظ العرض المعدل كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **استخدام العلامات الافتراضية في المخططات**

عند استخدام العلامات الافتراضية في المخططات، يحصل كل سلسلة مخطط تلقائيًا على رمز علامة مختلف.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // استخراج السلسلة الثانية للمخطط
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // الآن يتم تعبئة بيانات السلسلة
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **الأسئلة المتكررة**

**ما هي أنواع المخططات التي يدعمها Aspose.Slides؟**

Aspose.Slides يدعم مجموعة واسعة من [أنواع المخططات](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/charttype/)، بما في ذلك الشريطية، الخطية، الدائرية، المساحية، التشتت، الهيستوجرام، الرادار، والعديد غيرها. تتيح لك هذه المرونة اختيار النوع الأنسب لتصور بياناتك.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، أولاً أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، احصل على الشريحة المطلوبة باستخدام فهرسها، ثم استدعِ الطريقة لإضافة مخطط، مع تحديد نوع المخطط والبيانات الأولية. يدمج هذا العملية المخطط مباشرةً في عرضك التقديمي.

**كيف يمكنني تحديث البيانات المعروضة في مخطط؟**

يمكنك تحديث بيانات المخطط عن طريق الوصول إلى دفتر عمل البيانات الخاص به ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdataworkbook/))، مسح أي سلاسل وفئات افتراضية، ثم إضافة البيانات المخصصة الخاصة بك. يتيح لك ذلك تجديد المخطط برمجيًا لتظهر أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، يوفر Aspose.Slides خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، الوسائل الإيضاحية، وغيرها من [عناصر التنسيق](/slides/ar/nodejs-java/chart-entities/) لتلائم متطلبات التصميم الخاصة بك.