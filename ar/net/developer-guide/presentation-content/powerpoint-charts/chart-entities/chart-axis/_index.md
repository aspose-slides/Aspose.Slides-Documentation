---
title: محور المخطط
type: docs
url: /ar/net/chart-axis/
keywords: "محور مخطط PowerPoint, مخططات العرض, C#, .NET, تعديل محور المخطط, بيانات المخطط"
description: "تحرير محور مخطط PowerPoint في C# أو .NET"
---

## **الحصول على القيم القصوى على المحور العمودي في المخططات**
يسمح لك Aspose.Slides for .NET بالحصول على القيم الدنيا والقصوى على المحور العمودي. اتبع هذه الخطوات:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. الحصول على القيمة القصوى الفعلية على المحور.
5. الحصول على القيمة الدنيا الفعلية على المحور.
6. الحصول على وحدة المحور الرئيسية الفعلية.
7. الحصول على وحدة المحور الثانوية الفعلية.
8. الحصول على مقياس الوحدة الرئيسية الفعلي للمحور.
9. الحصول على مقياس الوحدة الثانوية الفعلي للمحور.

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// يحفظ العرض التقديمي
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **تبديل البيانات بين المحاور**
يتيح لك Aspose.Slides تبديل البيانات بين المحاور بسرعة — يتم نقل البيانات المعروضة على المحور العمودي (محور y) إلى المحور الأفقي (محور x) والعكس بالعكس.

```c#
 // إنشاء عرض تقديمي فارغ
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// تبديل الصفوف والأعمدة
	chart.ChartData.SwitchRowColumn();
		   
	// حفظ العرض التقديمي
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **إلغاء تمكين المحور العمودي لمخططات الخط**
يعرض لك هذا الكود بلغة C# كيفية إخفاء المحور العمودي لمخطط خط:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **إلغاء تمكين المحور الأفقي لمخططات الخط**
يعرض لك هذا الكود كيفية إخفاء المحور الأفقي لمخطط خط:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **تغيير محور الفئة**
باستخدام الخاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). يوضح هذا الكود بلغة C# العملية:
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```


## **تعيين تنسيق التاريخ لقيمة محور الفئة**
يسمح لك Aspose.Slides for .NET بتعيين تنسيق التاريخ لقيمة محور الفئة. يتم توضيح العملية في هذا الكود بلغة C#:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **تعيين زاوية الدوران لعنوان محور المخطط**
يسمح لك Aspose.Slides for .NET بتعيين زاوية الدوران لعنوان محور المخطط. يوضح هذا الكود بلغة C# العملية:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **تعيين موضع المحور في محور الفئة أو محور القيمة**
يسمح لك Aspose.Slides for .NET بتعيين موضع المحور في محور الفئة أو محور القيمة. يوضح هذا الكود بلغة C# كيفية تنفيذ المهمة:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **تمكين تسمية وحدة العرض على محور قيمة المخطط**
يسمح لك Aspose.Slides for .NET بتكوين مخطط لإظهار تسمية الوحدة على محور قيمة المخطط. يوضح هذا الكود بلغة C# العملية:
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

توفر المحاور خيار [تقاطع المحاور](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/): يمكنك اختيار التقاطع عند الصفر، أو عند أقصى فئة/قيمة، أو عند قيمة رقمية محددة. هذا مفيد لتحريك محور X لأعلى أو لأسفل أو لتأكيد خط الأساس.

**كيف يمكنني تموضع تسميات العلامات بالنسبة إلى المحور (جانبية، خارجية، داخلية)؟**

قم بضبط [موضع التسمية](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) إلى "cross" أو "outside" أو "inside". هذا يؤثر على قابلية القراءة ويساعد في توفير المساحة، خصوصًا في المخططات الصغيرة.