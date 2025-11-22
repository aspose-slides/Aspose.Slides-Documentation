---
title: مخطط الفطيرة
type: docs
url: /ar/net/pie-chart/
keywords: "مخطط الفطيرة, خيارات الرسم, ألوان الشرائح, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "خيارات رسم مخطط الفطيرة وألوان الشرائح في عرض تقديمي PowerPoint بلغة C# أو .NET"
---

## **خيارات المخطط الثانوي لفطيرة داخل فطيرة وشريط فطيرة**
Aspose.Slides for .NET الآن تدعم خيارات المخطط الثانوي لفطيرة داخل فطيرة أو شريط فطيرة. في هذا الموضوع سنرى من خلال مثال كيفية تحديد هذه الخيارات باستخدام Aspose.Slides. لتحديد الخصائص يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إضافة مخطط إلى الشريحة.
1. تحديد خيارات المخطط الثانوي للمخطط.
1. كتابة العرض التقديمي إلى القرص.

في المثال الموضح أدناه قمنا بتعيين خصائص مختلفة لمخطط فطيرة داخل فطيرة.
```c#
// إنشاء كائن من الفئة Presentation
Presentation presentation = new Presentation();

// إضافة مخطط إلى الشريحة
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// تعيين خصائص مختلفة
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// كتابة العرض التقديمي إلى القرص
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```


## **تعيين ألوان شرائح مخطط الفطيرة التلقائية**
Aspose.Slides for .NET توفر واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح مخطط الفطيرة تلقائيًا. يطبق كود العينة تعيين الخصائص المذكورة أعلاه.

1. إنشاء مثال من فئة Presentation.
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط بالبيانات الافتراضية.
1. تعيين عنوان المخطط.
1. تعيين السلسلة الأولى لإظهار القيم.
1. تعيين فهرس ورقة بيانات المخطط.
1. الحصول على ورقة عمل بيانات المخطط.
1. حذف السلاسل والفئات المولدة افتراضيًا.
1. إضافة فئات جديدة.
1. إضافة سلاسل جديدة.

اكتب العرض التقديمي المعدل إلى ملف PPTX.
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
	// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
	Presentation presentation = new Presentation();

	// الوصول إلى الشريحة الأولى
	ISlide slides = presentation.Slides[0];

	// إضافة مخطط بالبيانات الافتراضية
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// تعيين عنوان المخطط
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// تعيين السلسلة الأولى لإظهار القيم
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// تعيين فهرس ورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة عمل بيانات المخطط
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// إضافة فئات جديدة
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// إضافة سلسلة جديدة
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// الآن يتم تعبئة بيانات السلسلة
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**هل يتم دعم تنويعات 'فطيرة داخل فطيرة' و'شريط فطيرة'؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) مخططًا ثانويًا لمخططات الفطيرة، بما في ذلك الأنواع 'فطيرة داخل فطيرة' و'شريط فطيرة'.

**هل يمكنني تصدير المخطط فقط كصورة (على سبيل المثال، PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (مثل PNG) دون العرض التقديمي كاملًا.