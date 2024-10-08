---
title: محور الرسم البياني
type: docs
url: /ar/net/chart-axis/
keywords: "محور الرسم البياني في PowerPoint, الرسوم البيانية التقديمية, C#, .NET, التعامل مع محور الرسم البياني, بيانات الرسم البياني"
description: "تعديل محور الرسم البياني في PowerPoint باستخدام C# أو .NET"
---


## **الحصول على القيم القصوى على المحور العمودي في الرسوم البيانية**
يسمح لك Aspose.Slides لشركة .NET بالحصول على القيم الدنيا والقصوى على محور عمودي. اتبع هذه الخطوات:

1. قم بإنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني باستخدام بيانات افتراضية.
1. الحصول على القيمة القصوى الفعلية على المحور.
1. الحصول على القيمة الدنيا الفعلية على المحور.
1. الحصول على الوحدة الرئيسية الفعلية للمحور.
1. الحصول على الوحدة الثانوية الفعلية للمحور.
1. الحصول على مقياس الوحدة الرئيسية الفعلية للمحور.
1. الحصول على مقياس الوحدة الثانوية الفعلية للمحور.

يظهر هذا الكود المصدري - تنفيذ للخطوات أعلاه - كيف تحصل على القيم المطلوبة في C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// حفظ العرض التقديمي
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **تبادل البيانات بين المحاور**
يسمح لك Aspose.Slides بسرعة بتبادل البيانات بين المحاور - البيانات الموجودة على المحور العمودي (المحور الصادي) تنتقل إلى المحور الأفقي (المحور السيني) والعكس بالعكس.

يظهر هذا الكود C# كيف تقوم بأداء مهمة تبادل البيانات بين المحاور على الرسم البياني:

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

## **تعطيل المحور العمودي للرسوم البيانية الخطية**

يظهر هذا الكود C# كيف تخفي المحور العمودي لرسم بياني خطي:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **تعطيل المحور الأفقي للرسوم البيانية الخطية**

يظهر هذا الكود كيف تخفي المحور الأفقي لرسم بياني خطي:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **تغيير محور الفئة**

باستخدام خاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**تاريخ** أو **نص**). يُظهر هذا الكود في C# العملية:

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
يسمح لك Aspose.Slides لشركة .NET بتعيين تنسيق التاريخ لقيمة محور الفئة. تُظهر هذه العملية في كود C#:

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

## **تعيين زاوية التدوير لعنوان محور الرسم البياني**
يسمح لك Aspose.Slides لشركة .NET بتعيين زاوية التدوير لعنوان محور الرسم البياني. يُظهر كود C# هذا العملية:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **تعيين محور الموقع في محور الفئة أو القيمة**
يسمح لك Aspose.Slides لشركة .NET بتعيين محور الموقع في محور الفئة أو القيمة. يُظهر كود C# هذا كيف تقوم بأداء المهمة:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **تفعيل عرض علامة وحدة على محور قيمة الرسم البياني**
يسمح لك Aspose.Slides لشركة .NET بتكوين رسم بياني ليظهر علامة وحدة على محور قيمة الرسم البياني الخاص به. تُظهر كود C# هذا العملية:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```