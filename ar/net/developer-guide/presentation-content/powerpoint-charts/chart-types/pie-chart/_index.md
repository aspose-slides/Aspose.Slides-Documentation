---
title: الرسم البياني الدائري
type: docs
url: /net/pie-chart/
keywords: "رسم بياني دائري، خيارات الرسم، ألوان الشرائح، عرض باوربوينت، C#، Csharp، Aspose.Slides لـ .NET"
description: "خيارات رسم الرسم البياني الدائري وألوان الشرائح في عرض باوربوينت باستخدام C# أو .NET"
---

## **خيارات الرسم الثانية للرسم البياني الدائري من الدائري والرسم البياني الشريطي من الدائري**
يدعم Aspose.Slides لـ .NET الآن خيارات الرسم الثانية للرسم البياني الدائري من الدائري أو الرسم البياني الشريطي من الدائري. في هذا الموضوع، سنرى مع مثال كيفية تحديد هذه الخيارات باستخدام Aspose.Slides. من أجل تحديد الخصائص. يرجى اتباع الخطوات أدناه:

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. أضف رسمًا بيانيًا على الشريحة.
1. حدد خيارات الرسم الثانية للرسم البياني.
1. اكتب العرض التقديمي على القرص.

في المثال المذكور أدناه، قمنا بتعيين خصائص مختلفة للرسم البياني الدائري من الدائري.

```c#
// إنشاء كائن من فئة Presentation
Presentation presentation = new Presentation();

// إضافة رسم بياني على الشريحة
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// تعيين خصائص مختلفة
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// كتابة العرض التقديمي على القرص
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **تعيين ألوان الشرائح تلقائيًا للرسم البياني الدائري**
يقدم Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة لتعيين ألوان الشرائح التلقائية للرسم البياني الدائري. يطبق نموذج الشيفرة تعيين الخصائص المذكورة أعلاه.

1. قم بإنشاء كائن من فئة Presentation.
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني ببيانات افتراضية.
1. تعيين عنوان الرسم البياني.
1. تعيين السلسلة الأولى لعرض القيم.
1. تعيين فهرس ورقة بيانات الرسم البياني.
1. الحصول على ورقة العمل لبيانات الرسم البياني.
1. حذف السلاسل والفئات المتولدة افتراضيًا.
1. إضافة فئات جديدة.
1. إضافة سلاسل جديدة.

قم بكتابة العرض التقديمي المعدل إلى ملف PPTX.

```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
	// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
	Presentation presentation = new Presentation();

	// الوصول إلى الشريحة الأولى
	ISlide slides = presentation.Slides[0];

	// إضافة رسم بياني ببيانات افتراضية
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// تعيين عنوان الرسم البياني
	chart.ChartTitle.AddTextFrameForOverriding("عنوان نموذج");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// تعيين السلسلة الأولى لعرض القيم
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// تعيين فهرس ورقة بيانات الرسم البياني
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة العمل لبيانات الرسم البياني
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// حذف السلاسل والفئات المتولدة افتراضيًا
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// إضافة فئات جديدة
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "الربع الأول"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "الربع الثاني"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "الربع الثالث"));

	// إضافة سلاسل جديدة
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "السلسلة 1"), chart.Type);

	// الآن تعبئة بيانات السلسلة
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```