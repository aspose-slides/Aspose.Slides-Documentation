---
title: تخصيص مخططات الفطيرة في العروض التقديمية في .NET
linktitle: مخطط الفطيرة
type: docs
url: /ar/net/pie-chart/
keywords:
- مخطط الفطيرة
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتخصيص مخططات الفطيرة في .NET باستخدام Aspose.Slides، القابلة للتصدير إلى PowerPoint، مما يعزز سرد بياناتك في ثوانٍ."
---

## **خيارات الرسم الثانوي لمخططات فطيرة داخل فطيرة وشريط داخل فطيرة**
تدعم Aspose.Slides for .NET الآن خيارات الرسم الثانوي لمخططات فطيرة داخل فطيرة أو شريط داخل فطيرة. في هذا الموضوع، سنرى من خلال مثال كيفية تحديد هذه الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إضافة مخطط إلى الشريحة.
1. تحديد خيارات الرسم الثانوي للمخطط.
1. كتابة العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتعيين خصائص مختلفة لمخطط فطيرة داخل فطيرة.
```c#
// إنشاء نسخة من فئة Presentation
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





## **تعيين ألوان شرائح مخطط الفطيرة تلقائيًا**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح مخطط الفطيرة تلقائيًا. يطبق الكود النموذجي إعداد الخصائص المذكورة أعلاه.

1. إنشاء نسخة من فئة Presentation.
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. تعيين عنوان المخطط.
1. تعيين السلسلة الأولى لإظهار القيم.
1. تعيين فهرس ورقة بيانات المخطط.
1. الحصول على ورقة بيانات المخطط.
1. حذف السلاسل والفئات التي تم توليدها افتراضيًا.
1. إضافة فئات جديدة.
1. إضافة سلسلة جديدة.

اكتب العرض التقديمي المعدل إلى ملف PPTX.
```c#
// إنشاء نسخة من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
	// إنشاء نسخة من فئة Presentation التي تمثل ملف PPTX
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

	// حذف السلاسل والفئات المُنشأة افتراضيًا
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// إضافة فئات جديدة
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// إضافة سلسلة جديدة
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// الآن ملء بيانات السلسلة
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **الأسئلة المتداولة**

**هل يتم دعم تنويعات 'فطيرة داخل فطيرة' و'شريط داخل فطيرة'؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) رسمًا ثانويًا لمخططات الفطيرة، بما في ذلك النوعين 'فطيرة داخل فطيرة' و'شريط داخل فطيرة'.

**هل يمكنني تصدير المخطط فقط كصورة (مثلاً PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (مثل PNG) دون الحاجة إلى تصدير العرض التقديمي بالكامل.