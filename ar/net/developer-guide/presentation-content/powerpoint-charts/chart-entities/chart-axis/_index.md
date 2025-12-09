---
title: تخصيص محاور المخططات في العروض التقديمية في .NET
linktitle: محور المخطط
type: docs
url: /ar/net/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
- المحور الأفقي
- تخصيص المحور
- تعديل المحور
- إدارة المحور
- خصائص المحور
- القيمة العظمى
- القيمة الصغرى
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides for .NET لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصورات."
---

## **الحصول على القيم العظمى للمحور العمودي في المخططات**
Aspose.Slides for .NET يسمح لك بالحصول على القيم الدنيا والعظمى للمحور العمودي. اتبع هذه الخطوات:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الحصول على القيمة العظمى الفعلية للمحور.
1. الحصول على القيمة الدنيا الفعلية للمحور.
1. الحصول على الوحدة الرئيسية الفعلية للمحور.
1. الحصول على الوحدة الفرعية الفعلية للمحور.
1. الحصول على مقياس الوحدة الرئيسية الفعلي للمحور.
1. الحصول على مقياس الوحدة الفرعية الفعلي للمحور.

هذا الكود النموذجي—تنفيذ للخطوات أعلاه—يوضح لك كيفية الحصول على القيم المطلوبة في C#:
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
Aspose.Slides يسمح لك بتبديل البيانات بين المحاور بسرعة—البيانات الموجودة على المحور العمودي (محور y) تنتقل إلى المحور الأفقي (محور x) والعكس بالعكس.

هذا الكود C# يوضح لك كيفية تنفيذ عملية تبديل البيانات بين المحاور في مخطط:
```c#
// إنشاء عرض تقديمي فارغ
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//تبديل الصفوف والأعمدة
		   
	// حفظ العرض التقديمي
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **إلغاء تفعيل المحور العمودي للمخططات الخطية**
هذا الكود C# يوضح لك كيفية إخفاء المحور العمودي لمخطط خطي:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **إلغاء تفعيل المحور الأفقي للمخططات الخطية**
هذا الكود يوضح لك كيفية إخفاء المحور الأفقي لمخطط خطي:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **تغيير محور الفئات**
باستخدام الخاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئات المفضل لديك (**date** أو **text**). هذا الكود في C# يوضح العملية:
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


## **تعيين تنسيق التاريخ لقيمة محور الفئات**
Aspose.Slides for .NET يسمح لك بتعيين تنسيق التاريخ لقيمة محور الفئات. يتم توضيح العملية في هذا الكود C#:
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
Aspose.Slides for .NET يسمح لك بتعيين زاوية الدوران لعنوان محور المخطط. هذا الكود C# يوضح العملية:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **تعيين موضع المحور في محور الفئات أو القيمة**
Aspose.Slides for .NET يسمح لك بتعيين موضع المحور في محور الفئات أو القيمة. هذا الكود C# يوضح كيفية تنفيذ المهمة:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **تمكين تسمية وحدة العرض على محور قيمة المخطط**
Aspose.Slides for .NET يسمح لك بتهيئة مخطط لعرض تسمية وحدة على محور قيمة المخطط. هذا الكود C# يوضح العملية:
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

المحاور توفر [إعداد التقاطع](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)؛ يمكنك اختيار التقاطع عند الصفر، أو عند الفئة/القيمة القصوى، أو عند قيمة رقمية محددة. يُستخدم ذلك لتعديل موضع المحور السيني صعودًا أو هبوطًا أو لتسليط الضوء على خط الأساس.

**كيف يمكنني وضع تسميات العلامات بالنسبة إلى المحور (بجانب، خارج، داخل)؟**

قم بتعيين [موضع التسمية](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) إلى "cross" أو "outside" أو "inside". يؤثر ذلك على قابلية القراءة ويساعد في توفير المساحة، خاصة في المخططات الصغيرة.