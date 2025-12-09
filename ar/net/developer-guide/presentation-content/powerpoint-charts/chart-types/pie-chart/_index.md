---
title: تخصيص المخططات الدائرية في العروض التقديمية في .NET
linktitle: مخطط دائري
type: docs
url: /ar/net/pie-chart/
keywords:
- مخطط دائري
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون القطاع
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص المخططات الدائرية في .NET باستخدام Aspose.Slides، قابلة للتصدير إلى PowerPoint، مما يعزز سرد البيانات الخاص بك في ثوانٍ."
---

## **خيارات الرسم الثاني لمخطط Pie of Pie و Bar of Pie**
Aspose.Slides for .NET الآن يدعم خيارات الرسم الثاني لمخطط Pie of Pie أو Bar of Pie. في هذا الموضوع، سنرى من خلال مثال كيفية تحديد هذه الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إضافة مخطط إلى الشريحة.
1. تحديد خيارات الرسم الثاني للمخطط.
1. كتابة العرض إلى القرص.

في المثال المعطى أدناه، قمنا بتعيين خصائص مختلفة لمخطط Pie of Pie.
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

// كتابة العرض إلى القرص
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```


## **ضبط ألوان شرائح مخطط الفطيرة التلقائي**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لضبط ألوان شرائح مخطط الفطيرة التلقائية. يطبق كود المثال إعداد الخصائص المذكورة أعلاه.

1. إنشاء كائن من الفئة Presentation.
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. تعيين عنوان المخطط.
1. تعيين السلسلة الأولى لإظهار القيم.
1. تعيين فهرس ورقة بيانات المخطط.
1. الحصول على ورقة عمل بيانات المخطط.
1. حذف السلسلات والفئات التي تم إنشاؤها افتراضيًا.
1. إضافة فئات جديدة.
1. إضافة سلسلة جديدة.

كتابة العرض المعدل إلى ملف PPTX.
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
	// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
	Presentation presentation = new Presentation();

	// الوصول إلى الشريحة الأولى
	ISlide slides = presentation.Slides[0];

	// إضافة مخطط ببيانات افتراضية
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

	// الآن يتم ملء بيانات السلسلة
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يتم دعم تنوعات 'Pie of Pie' و 'Bar of Pie'؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) الرسم الثانوي لمخططات الفطيرة، بما في ذلك نوعي 'Pie of Pie' و 'Bar of Pie'.

**هل يمكنني تصدير المخطط فقط كصورة (مثلاً PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (مثل PNG) دون الحاجة إلى تصدير العرض بالكامل.