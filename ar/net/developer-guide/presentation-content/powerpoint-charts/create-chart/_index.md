---
title: إنشاء أو تحديث رسوم بيانية في عروض PowerPoint باستخدام C# أو .NET
linktitle: إنشاء أو تحديث الرسم البياني
type: docs
weight: 10
url: /net/create-chart/
keywords: "إنشاء رسم بياني، رسم بياني متناثر، رسم بياني دائري، رسم بياني خريطة شجرية، رسم بياني للأسهم، رسم بياني للصندوق والشعيرات، رسم بياني هيستوجرام، رسم بياني قمع، رسم بياني شمسية، رسم بياني متعدد الفئات، عرض PowerPoint، C#، Csharp، Aspose.Slides ل .NET"
description: "إنشاء رسم بياني في عرض PowerPoint باستخدام C# أو .NET"
---

## **إنشاء رسم بياني**
تساعد الرسوم البيانية الأشخاص في تصور البيانات بسرعة والحصول على رؤى قد لا تكون واضحة على الفور من جدول أو جدول بيانات.

**لماذا إنشاء رسوم بيانية؟**

باستخدام الرسوم البيانية، يمكنك

* تجميع أو تلخيص كميات كبيرة من البيانات في شريحة واحدة في العرض
* كشف الأنماط والاتجاهات في البيانات
* استنتاج الاتجاه والحركة للبيانات مع مرور الوقت أو بالنسبة لوحدة قياس محددة
* اكتشاف القيم الشاذة والأخطاء والبيانات غير المنطقية، إلخ
* التواصل أو عرض البيانات المعقدة

في PowerPoint، يمكنك إنشاء الرسوم البيانية من خلال وظيفة الإدراج، التي توفر قوالب مستخدمة لتصميم العديد من أنواع الرسوم البيانية. باستخدام Aspose.Slides، يمكنك إنشاء رسوم بيانية عادية (استنادًا إلى أنواع الرسوم البيانية الشهيرة) ورسوم بيانية مخصصة.

{{% alert color="primary" %}} 

للسماح لك بإنشاء الرسوم البيانية، يوفر Aspose.Slides تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) تحت مساحة اسم [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). القيم تحت هذا التعداد تتوافق مع أنواع الرسوم البيانية المختلفة.

{{% /alert %}} 

### **إنشاء رسوم بيانية عادية**
1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني ببعض البيانات وتحديد نوع الرسم البياني المفضل لديك.
1. إضافة عنوان للرسم البياني.
1. الوصول إلى ورقة بيانات الرسم البياني.
1. مسح جميع السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بعض البيانات الجديدة للرسم البياني للسلاسل.
1. إضافة لون تعبئة لسلاسل الرسم البياني.
1. إضافة تسميات لسلاسل الرسم البياني.
1. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني عادي:

```c#
// يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();

// الوصول إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة رسم بياني ببياناته الافتراضية
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

// تعيين عنوان الرسم البياني
chart.ChartTitle.AddTextFrameForOverriding("عنوان عينة");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// تعيين السلسلة الأولى لعرض القيم
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// تعيين الفهرس لورقة بيانات الرسم البياني
int defaultWorksheetIndex = 0;

// الحصول على ورقة بيانات الرسم البياني
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// حذف السلاسل والفئات الافتراضية المزودة
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

// إضافة سلاسل جديدة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "السلسلة 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "السلسلة 2"), chart.Type);

// إضافة فئات جديدة
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "الفئة 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "الفئة 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "الفئة 3"));

// أخذ السلسلة الأولى من الرسم البياني
IChartSeries series = chart.ChartData.Series[0];

// ملء بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// تعيين اللون التعبوي للسلسلة
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// أخذ السلسلة الثانية من الرسم البياني
series = chart.ChartData.Series[1];

// ملء بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// تعيين اللون التعبوي للسلسلة
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

// تعيين الصLabel لإظهار اسم الفئة
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

// تعيين السلسلة لإظهار القيمة للتسمية الثالثة
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

// حفظ ملف PPTX على القرص
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **إنشاء رسوم بيانية متناثرة**
تستخدم الرسوم البيانية المتناثرة (المعروفة أيضًا بالرسوم البيانية المتناثرة أو графики x-y) غالبًا للتحقق من الأنماط أو لإظهار العلاقات بين متغيرين.

قد ترغب في استخدام رسم بياني متناثر عندما 

* يكون لديك بيانات رقمية متزاوجة
* لديك متغيرين يتناسبان جيدًا معًا
* تريد تحديد ما إذا كان يوجد علاقة بين متغيرين
* لديك متغير مستقل له قيم متعددة لمتغير تابع

هذا الكود C# يوضح لك كيفية إنشاء رسوم بيانية متناثرة مع سلسلة مختلفة من العلامات:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// إنشاء الرسم البياني الافتراضي
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// الحصول على الفهرس الافتراضي لورقة بيانات الرسم البياني
int defaultWorksheetIndex = 0;

// الحصول على ورقة بيانات الرسم البياني
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// حذف السلسلة التجريبية
chart.ChartData.Series.Clear();

// إضافة سلاسل جديدة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "السلسلة 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "السلسلة 2"), chart.Type);

// أخذ السلسلة الأولى من الرسم البياني
IChartSeries series = chart.ChartData.Series[0];

// إضافة نقطة جديدة (1:3) إلى السلسلة
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// إضافة نقطة جديدة (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// تغيير نوع السلسلة
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// تغيير علامة السلسلة البيانية
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// أخذ السلسلة الثانية من الرسم البياني
series = chart.ChartData.Series[1];

// إضافة نقطة جديدة (5:2) إلى سلسلة الرسم البياني
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// إضافة نقطة جديدة (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// إضافة نقطة جديدة (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// إضافة نقطة جديدة (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// تغيير علامة السلسلة البيانية
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

// حفظ ملف PPTX على القرص
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **إنشاء رسوم بيانية دائريّة**

تُستخدم الرسوم البيانية الدائريّة بشكل أفضل لإظهار علاقة الجزء بالكل في البيانات، خاصةً عند احتواء البيانات على تسميات فئوية مع قيم عددية. ومع ذلك، إذا كانت بياناتك تحتوي على أجزاء أو تسميات عديدة، قد ترغب في استخدام رسم بياني عمودي بدلاً من ذلك.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني مع البيانات الافتراضية بالإضافة إلى النوع المطلوب (في هذه الحالة، `ChartType.Pie`).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات جديدة للرسم البياني لسلسلة البيانات.
1. إضافة نقاط جديدة للرسوم البيانية وإضافة ألوان مخصصة لقطاعات الرسم البياني الدائري.
1. تعيين تسميات للسلاسل.
1. تعيين خطوط القيادة لتسميات السلسلة.
1. تعيين زاوية الدوران لشريحة الرسم البياني الدائري.
1. كتابة العرض المعدل إلى ملف PPTX

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني دائري:

```c#
// يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation();

// الوصول إلى الشريحة الأولى
ISlide slides = presentation.Slides[0];

// إضافة رسم بياني مع بياناته الافتراضية
IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// تعيين عنوان الرسم البياني
chart.ChartTitle.AddTextFrameForOverriding("عنوان عينة");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// تعيين السلسلة الأولى لإظهار القيم
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// تعيين الفهرس لورقة بيانات الرسم البياني
int defaultWorksheetIndex = 0;

// الحصول على ورقة بيانات الرسم البياني
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// حذف السلاسل والفئات الافتراضية المزودة
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

// إضافة فئات جديدة
chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "الربع الأول"));
chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "الربع الثاني"));
chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "الربع الثالث"));

// إضافة سلاسل جديدة
IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "السلسلة 1"), chart.Type);

// ملء بيانات السلسلة
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// لا تعمل في الإصدار الجديد 
// إضافة نقاط جديدة وتعيين لون القطاع
// series.IsColorVaried = true;
chart.ChartData.SeriesGroups[0].IsColorVaried = true;

IChartDataPoint point = series.DataPoints[0];
point.Format.Fill.FillType = FillType.Solid;
point.Format.Fill.SolidFillColor.Color = Color.Cyan;
// تعيين حدود القطاع
point.Format.Line.FillFormat.FillType = FillType.Solid;
point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
point.Format.Line.Width = 3.0;
point.Format.Line.Style = LineStyle.ThinThick;
point.Format.Line.DashStyle = LineDashStyle.DashDot;

IChartDataPoint point1 = series.DataPoints[1];
point1.Format.Fill.FillType = FillType.Solid;
point1.Format.Fill.SolidFillColor.Color = Color.Brown;

// تعيين حدود القطاع
point1.Format.Line.FillFormat.FillType = FillType.Solid;
point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
point1.Format.Line.Width = 3.0;
point1.Format.Line.Style = LineStyle.Single;
point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

IChartDataPoint point2 = series.DataPoints[2];
point2.Format.Fill.FillType = FillType.Solid;
point2.Format.Fill.SolidFillColor.Color = Color.Coral;

// تعيين حدود القطاع
point2.Format.Line.FillFormat.FillType = FillType.Solid;
point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
point2.Format.Line.Width = 2.0;
point2.Format.Line.Style = LineStyle.ThinThin;
point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

// إنشاء تسميات مخصصة لكل من الفئات للسلسلة الجديدة
IDataLabel lbl1 = series.DataPoints[0].Label;

// lbl.ShowCategoryName = true;
lbl1.DataLabelFormat.ShowValue = true;

IDataLabel lbl2 = series.DataPoints[1].Label;
lbl2.DataLabelFormat.ShowValue = true;
lbl2.DataLabelFormat.ShowLegendKey = true;
lbl2.DataLabelFormat.ShowPercentage = true;

IDataLabel lbl3 = series.DataPoints[2].Label;
lbl3.DataLabelFormat.ShowSeriesName = true;
lbl3.DataLabelFormat.ShowPercentage = true;

// تعيين السلسلة لعرض خطوط القيادة للرسم البياني
series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

// تعيين زاوية الدوران لقطاعات الرسم البياني الدائري
chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

// حفظ ملف PPTX على القرص
presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
```

### **إنشاء رسوم بيانية خطية**

تُستخدم الرسوم البيانية الخطية (المعروفة أيضًا باسم الرسوم البيانية الخطية) بشكل أفضل في المواقف التي تريد فيها إظهار التغييرات في القيمة مع مرور الوقت. باستخدام رسم بياني خطي، يمكنك مقارنة الكثير من البيانات دفعة واحدة، وتتبع التغييرات والاتجاهات بمرور الوقت، وإبراز الشذوذ في السلاسل البيانية، إلخ.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني مع بيانات افتراضية بالإضافة إلى النوع المطلوب (في هذه الحالة، `ChartType.Line`).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات جديدة للرسم البياني لسلسلة البيانات.
1. كتابة العرض المعدل إلى ملف PPTX

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني خطي:

```c#
using (Presentation pres = new Presentation())
{
    IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);
    
    pres.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

افتراضيًا، يتم ربط النقاط على الرسم البياني الخطّي بواسطة خطوط مستقيمة متواصلة. إذا كنت ترغب في ربط النقاط بواسطة خطوط متقطعة، يمكنك تحديد نوع الخط المتقطع المفضل لديك بهذه الطريقة:

```c#
IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);

foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

### **إنشاء رسوم بيانية خريطة شجرية**

تُستخدم رسوم بيانية الخريطة الشجرية بشكل أفضل لبيانات المبيعات عند ترغب في إظهار الحجم النسبي لفئات البيانات وفي الوقت نفسه جذب الانتباه بسرعة للأشياء التي تساهم بشكل كبير في كل فئة.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني مع بيانات افتراضية بالإضافة إلى النوع المطلوب (في هذه الحالة، `ChartType.TreeMap`).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات جديدة للرسم البياني لسلسلة البيانات.
1. كتابة العرض المعدل إلى ملف PPTX

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني خريطة شجرية:

```c#
using (Presentation presentation = new Presentation())
{
	IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	// الفرع 1
	IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "ورقة1"));
	leaf.GroupingLevels.SetGroupingItem(1, "جذع1");
	leaf.GroupingLevels.SetGroupingItem(2, "فرع1");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "ورقة2"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "ورقة3"));
	leaf.GroupingLevels.SetGroupingItem(1, "جذع2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "ورقة4"));


	// الفرع 2
	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "ورقة5"));
	leaf.GroupingLevels.SetGroupingItem(1, "جذع3");
	leaf.GroupingLevels.SetGroupingItem(2, "فرع2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "ورقة6"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "ورقة7"));
	leaf.GroupingLevels.SetGroupingItem(1, "جذع4");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "ورقة8"));

	IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
	series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 5));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 3));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 6));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 3));

	series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

	presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

### **إنشاء رسوم بيانية للأسهم**

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني مع بيانات افتراضية بالإضافة إلى النوع المطلوب (ChartType.OpenHighLowClose).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات جديدة للرسم البياني لسلسلة البيانات.
1. تحديد تنسيق HiLowLines.
1. كتابة العرض المعدل إلى ملف PPTX

يتضمن الكود C# نموذجًا لإنشاء رسم بياني للأسهم:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);
    
	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "A"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "B"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "C"));

	chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "فتح"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 2, "مرتفع"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 3, "منخفض"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 4, "إغلاق"), chart.Type);

	IChartSeries series = chart.ChartData.Series[0];

	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 1, 72));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 1, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 1, 38));

	series = chart.ChartData.Series[1];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 2, 172));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 2, 57));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 2, 57));

	series = chart.ChartData.Series[2];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 3, 13));

	series = chart.ChartData.Series[3];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 4, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 4, 38));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 4, 50));

	chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
	chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

	foreach (IChartSeries ser in chart.ChartData.Series)
	{
		ser.Format.Line.FillFormat.FillType = FillType.NoFill;
	}

	pres.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

### **إنشاء رسوم بيانية للصندوق والشعيرات**
1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني مع بيانات افتراضية بالإضافة إلى النوع المطلوب (ChartType.BoxAndWhisker).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات جديدة للرسم البياني لسلسلة البيانات.
1. كتابة العرض المعدل إلى ملف PPTX

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني للصندوق والشعيرات:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "الفئة 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "الفئة 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "الفئة 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "الفئة 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "الفئة 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "الفئة 1"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

		series.QuartileMethod = QuartileMethodType.Exclusive;
		series.ShowMeanLine = true;
		series.ShowMeanMarkers = true;
		series.ShowInnerPoints = true;
		series.ShowOutlierPoints = true;

		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B1", 15));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B2", 41));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B3", 16));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B4", 10));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B5", 23));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B6", 16));

		pres.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
	}
}
```

### **إنشاء رسوم بيانية قمعية**
1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني مع بيانات افتراضية بالإضافة إلى النوع المطلوب (ChartType.Funnel).
1. كتابة العرض المعدل إلى ملف PPTX

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني قمعي:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "الفئة 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "الفئة 2"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "الفئة 3"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "الفئة 4"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "الفئة 5"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "الفئة 6"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B1", 50));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B2", 100));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B3", 200));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B4", 300));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B5", 400));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B6", 500));

		pres.Save("Funnel.pptx", SaveFormat.Pptx);
	}
}
```

### **إنشاء رسوم بيانية شمسية**
1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني مع بيانات افتراضية بالإضافة إلى النوع المطلوب (في هذه الحالة، `ChartType.sunburst`).
1. كتابة العرض المعدل إلى ملف PPTX

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني شمسي:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		// الفرع 1
		IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "ورقة1"));
		leaf.GroupingLevels.SetGroupingItem(1, "جذع1");
		leaf.GroupingLevels.SetGroupingItem(2, "فرع1");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "ورقة2"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "ورقة3"));
		leaf.GroupingLevels.SetGroupingItem(1, "جذع2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "ورقة4"));

		// الفرع 2
		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "ورقة5"));
		leaf.GroupingLevels.SetGroupingItem(1, "جذع3");
		leaf.GroupingLevels.SetGroupingItem(2, "فرع2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "ورقة6"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "ورقة7"));
		leaf.GroupingLevels.SetGroupingItem(1, "جذع4");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "ورقة8"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
		series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D1", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D2", 5));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D3", 3));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D4", 6));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D5", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D6", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D7", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D8", 3));

		pres.Save("Sunburst.pptx", SaveFormat.Pptx);
	}
}
```

### **إنشاء رسوم بيانية هيستوجرام**
1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة بعض الرسم البياني ببعض البيانات وتحديد نوع الرسم البياني المفضل لديك (`ChartType.Histogram` في هذه الحالة).
1. الوصول إلى بيانات الرسم البياني `IChartDataWorkbook`.
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. كتابة العرض المعدل إلى ملف PPTX

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني هيستوجرام:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Histogram, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A1", 15));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A2", -41));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A3", 16));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A4", 10));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A5", -23));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A6", 16));

		chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

		pres.Save("Histogram.pptx", SaveFormat.Pptx);
	}
}
```

### **إنشاء رسوم بيانية رادارية**

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني مع بعض البيانات وتحديد نوع الرسم البياني المفضل لديك (`ChartType.Radar` في هذه الحالة).
1. كتابة العرض المعدل إلى ملف PPTX

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني راداري:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 400, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

### **إنشاء رسوم بيانية متعددة الفئات**

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني مع بيانات افتراضية بالإضافة إلى النوع المطلوب (ChartType.ClusteredColumn).
1. الوصول إلى بيانات الرسم البياني IChartDataWorkbook.
1. مسح السلاسل والفئات الافتراضية.
1. إضافة سلاسل وفئات جديدة.
1. إضافة بيانات جديدة للرسم البياني لسلسلة البيانات.
1. كتابة العرض المعدل إلى ملف PPTX.

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني متعدد الفئات:

```c#
Presentation pres = new Presentation();
ISlide slide = pres.Slides[0];

IChart ch = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
ch.ChartData.Series.Clear();
ch.ChartData.Categories.Clear();

IChartDataWorkbook fact = ch.ChartData.ChartDataWorkbook;
fact.Clear(0);
int defaultWorksheetIndex = 0;

IChartCategory category = ch.ChartData.Categories.Add(fact.GetCell(0, "c2", "A"));
category.GroupingLevels.SetGroupingItem(1, "مجموعة 1");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c3", "B"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c4", "C"));
category.GroupingLevels.SetGroupingItem(1, "مجموعة 2");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c5", "D"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c6", "E"));
category.GroupingLevels.SetGroupingItem(1, "مجموعة 3");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c7", "F"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c8", "G"));
category.GroupingLevels.SetGroupingItem(1, "مجموعة 4");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c9", "H"));

// إضافة السلاسل
IChartSeries series = ch.ChartData.Series.Add(fact.GetCell(0, "D1", "السلسلة 1"),
    ChartType.ClusteredColumn);

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D2", 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D3", 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D4", 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D5", 40));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D6", 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D7", 60));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D8", 70));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D9", 80));
// حفظ العرض مع الرسم البياني
pres.Save("AsposeChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **إنشاء رسوم بيانية خريطة**

رسم بياني الخريطة هو تصور لمنطقة تحتوي على بيانات. تُستخدم رسوم بيانية الخريطة بشكل أفضل لمقارنة البيانات أو القيم عبر المناطق الجغرافية.

هذا الكود C# يوضح لك كيفية إنشاء رسم بياني خريطة:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Map, 50, 50, 500, 400);
    pres.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

### **إنشاء رسوم بيانية تركيبة**

رسم بياني التركيبة (أو رسم بياني المزيج) هو رسم بياني يجمع بين اثنين أو أكثر من الرسوم البيانية على رسم بياني واحد. يسمح هذا النوع من الرسم بمقارنة أو مراجعة الفروق بين مجموعتين من البيانات أو أكثر. بهذه الطريقة، يمكنك رؤية العلاقة (إذا وجدت) بين مجموعات البيانات.

![combination-chart-ppt](combination-chart-ppt.png)

هذا الكود C# يوضح كيفية إنشاء رسم بياني تركيبي في PowerPoint:

```c#
private static void CreateComboChart()
{
    using (Presentation pres = new Presentation())
    {
        IChart chart = CreateChart(pres.Slides[0]);
        AddFirstSeriesToChart(chart);
        AddSecondSeriesToChart(chart);
        pres.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChart(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "السلسلة 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "السلسلة 2"), chart.Type);
    
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "الفئة 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "الفئة 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "الفئة 3"));

    IChartSeries series = chart.ChartData.Series[0];

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));
    
    series = chart.ChartData.Series[1];
    
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    return chart;
}

private static void AddFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "السلسلة 3"), ChartType.ScatterWithSmoothLines);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 0, 1, 3),
        workbook.GetCell(worksheetIndex, 0, 2, 5));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 10),
        workbook.GetCell(worksheetIndex, 1, 4, 13));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 3, 20),
        workbook.GetCell(worksheetIndex, 2, 4, 15));

    series.PlotOnSecondAxis = true;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 5, "السلسلة 4"),
        ChartType.ScatterWithStraightLinesAndMarkers);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 5),
        workbook.GetCell(worksheetIndex, 1, 4, 2));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 5, 10),
        workbook.GetCell(worksheetIndex, 1, 6, 7));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 5, 15),
        workbook.GetCell(worksheetIndex, 2, 6, 12));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 3, 5, 12),
        workbook.GetCell(worksheetIndex, 3, 6, 9));
    
    series.PlotOnSecondAxis = true;
}
```

## **تحديث الرسوم البيانية**

1. اثنين من مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تمثل العرض الذي يحتوي على الرسم البياني.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. استعرض جميع الأشكال للعثور على الرسم البياني المطلوب.
4. الوصول إلى ورقة بيانات الرسم البياني.
5. تعديل بيانات السلاسل بيانات الرسم البياني عن طريق تغيير قيم السلسلة.
6. إضافة سلسلة جديدة وملأ البيانات بها.
7. كتابة العرض المعدل كملف PPTX.

يوضح هذا الكود C# كيفية تحديث رسم بياني:

```c#
// يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("ExistingChart.pptx");

// الوصول إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة رسم بياني مع بياناته الافتراضية
IChart chart = (IChart)sld.Shapes[0];

// تعيين الفهرس لورقة بيانات الرسم البياني
int defaultWorksheetIndex = 0;

// الحصول على ورقة بيانات الرسم البياني
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// تغيير اسم الفئة للرسم البياني
fact.GetCell(defaultWorksheetIndex, 1, 0, "الفئة المعدلة 1");
fact.GetCell(defaultWorksheetIndex, 2, 0, "الفئة المعدلة 2");

// أخذ السلسلة الأولى من الرسم البياني
IChartSeries series = chart.ChartData.Series[0];

// تحديث بيانات السلسلة
fact.GetCell(defaultWorksheetIndex, 0, 1, "New_Series1");// تعديل اسم السلسلة
series.DataPoints[0].Value.Data = 90;
series.DataPoints[1].Value.Data = 123;
series.DataPoints[2].Value.Data = 44;

// أخذ السلسلة الثانية من الرسم البياني
series = chart.ChartData.Series[1];

// تحديث بيانات السلسلة الآن
fact.GetCell(defaultWorksheetIndex, 0, 2, "New_Series2");// تعديل اسم السلسلة
series.DataPoints[0].Value.Data = 23;
series.DataPoints[1].Value.Data = 67;
series.DataPoints[2].Value.Data = 99;

// الآن، إضافة سلسلة جديدة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 3, "السلسلة 3"), chart.Type);

// أخذ السلسلة الثالثة من الرسم البياني
series = chart.ChartData.Series[2];

// ملء بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 3, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 30));

chart.Type = ChartType.ClusteredCylinder;

// حفظ العرض المعدل مع الرسم البياني
pres.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
```

## **تعيين نطاق البيانات للرسوم البيانية**

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تمثل العرض الذي يحتوي على الرسم البياني.
2. احصل على مرجع الشريحة من خلال فهرسها.
3. استعرض جميع الأشكال للعثور على الرسم البياني المطلوب.
4. الوصول إلى بيانات الرسم البياني وتحديد النطاق.
5. حفظ العرض المعدل كملف PPTX.

يوضح هذا الكود C# كيفية تعيين نطاق البيانات لرسم بياني:

```c#
// يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
Presentation presentation = new Presentation("ExistingChart.pptx");

// الوصول إلى الشريحة الأولى ويضاف رسم بياني مع بياناته الافتراضية
ISlide slide = presentation.Slides[0];
IChart chart = (IChart)slide.Shapes[0];
chart.ChartData.SetRange("Sheet1!A1:B4");
presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
```

## **استخدام علامات افتراضية في الرسوم البيانية**
عند استخدام علامة افتراضية في الرسوم البيانية، تحصل كل سلسلة من الرسوم البيانية على رموز علامات افتراضية مختلفة بشكل تلقائي.

يوضح هذا الكود C# كيفية تعيين علامة سلسلة الرسم البياني تلقائيًا:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
    chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "السلسلة 1"), chart.Type);
    IChartSeries series = chart.ChartData.Series[0];

    chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 1, 24));
    chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 1, 23));
    chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 1, -10));
    chart.ChartData.Categories.Add(fact.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 1, null));

    chart.ChartData.Series.Add(fact.GetCell(0, 0, 2, "السلسلة 2"), chart.Type);
    // أخذ السلسلة الثانية من الرسم البياني
    IChartSeries series2 = chart.ChartData.Series[1];

    // ملء بيانات السلسلة
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    pres.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```