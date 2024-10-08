---
title: سلسلة الرسم البياني
type: docs
url: /ar/net/chart-series/
keywords: "سلسلة الرسم البياني, لون السلسلة, عرض تقديمي في PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "سلاسل الرسم البياني في عروض PowerPoint بلغة C# أو .NET"
---

السلسلة هي صف أو عمود من الأرقام يتم رسمه في الرسم البياني.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة الرسم البياني**

باستخدام خاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) ، يمكنك تحديد مقدار تداخل الأشرطة والأعمدة في الرسم البياني ثنائي الأبعاد (النطاق: -100 إلى 100). تنطبق هذه الخاصية على جميع السلاسل في مجموعة السلاسل الأم: هذه هي إسقاط لخاصية المجموعة المناسبة. لذلك، هذه الخاصية للقراءة فقط.

استخدم خاصية `ParentSeriesGroup.Overlap` القابلة للقراءة/الكتابة لتعيين القيمة المفضلة لديك لـ `Overlap`.

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. أضف رسمًا بيانيًا عموديًا متراصًا على شريحة.
3. الوصول إلى أول سلسلة رسم بياني.
4. الوصول إلى `ParentSeriesGroup` لسلسلة الرسم البياني وتعيين قيمة التداخل المفضلة لديك للسلسلة.
5. قم بكتابة العرض التقديمي المعدل إلى ملف PPTX.

هذا الكود بلغة C# يوضح لك كيفية تعيين التداخل لسلسلة الرسم البياني:

```c#
using (Presentation presentation = new Presentation())
{
    // إضافة الرسم البياني
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.ChartData.Series;
    if (series[0].Overlap == 0)
    {
        // تعيين تداخل السلسلة
        series[0].ParentSeriesGroup.Overlap = -30;
    }

    // كتابة ملف العرض التقديمي إلى القرص
    presentation.Save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
}
```

## **تغيير لون السلسلة**
Aspose.Slides for .NET يسمح لك بتغيير لون سلسلة بهذه الطريقة:

1. أنشئ مثيل من فئة `Presentation`.
2. أضف رسمًا بيانيًا على الشريحة.
3. الوصول إلى السلسلة التي تريد تغيير لونها.
4. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
5. حفظ العرض التقديمي المعدل.

هذا الكود بلغة C# يوضح لك كيفية تغيير لون سلسلة:

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[1];
	
	point.Explosion = 30;
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **تغيير لون فئة السلسلة**
Aspose.Slides for .NET يسمح لك بتغيير لون فئة سلسلة بهذه الطريقة:

1. أنشئ مثيل من فئة `Presentation`.
2. أضف رسمًا بيانيًا على الشريحة.
3. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
4. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
5. حفظ العرض التقديمي المعدل.

هذا الكود بلغة C# يوضح لك كيفية تغيير لون فئة سلسلة:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];
	
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **تغيير اسم السلسلة** 

بشكل افتراضي، أسماء الأسطورة لرسم بياني هي محتويات الخلايا الموجودة فوق كل عمود أو صف من البيانات. 

في مثالنا (صورة عينة)، 

* الأعمدة هي *السلسلة 1، السلسلة 2،* و *السلسلة 3*؛
* الصفوف هي *الفئة 1، الفئة 2، الفئة 3،* و *الفئة 4.* 

Aspose.Slides for .NET يسمح لك بتحديث أو تغيير اسم سلسلة في بيانات رسمه البياني وأسطورته.

هذا الكود بلغة C# يوضح لك كيفية تغيير اسم سلسلة في بيانات رسمه البياني `ChartDataWorkbook`:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = "اسم جديد";
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

هذا الكود بلغة C# يوضح لك كيفية تغيير اسم سلسلة في أسطورته من خلال `Series`:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.ChartData.Series[0];
    
    IStringChartValue name = series.Name;
    name.AsCells[0].Value = "اسم جديد";   
}
```

## **تعيين لون التعبئة لسلسلة الرسم البياني**

Aspose.Slides for .NET يسمح لك بتعيين لون التعبئة التلقائي لسلسلة الرسم البياني داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيل من فئة `Presentation`.
2. احصل على مرجع لشريحة بواسطة فهرسها.
3. أضف رسمًا بيانيًا مع بيانات افتراضية بناءً على نوعك المفضل (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
4. الوصول إلى سلسلة الرسم البياني وتعيين لون التعبئة ليكون تلقائيًا.
5. حفظ العرض التقديمي إلى ملف PPTX.

هذا الكود بلغة C# يوضح لك كيفية تعيين لون التعبئة التلقائي لسلسلة الرسم البياني:

```c#
using (Presentation presentation = new Presentation())
{
    // إنشاء رسم بياني عمودي متراص
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // تعيين تنسيق تعبئة السلسلة ليكون تلقائيًا
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series[i].GetAutomaticSeriesColor();
    }

    // كتابة ملف العرض التقديمي إلى القرص
    presentation.Save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
}
```

## **تعيين عكس ألوان التعبئة لسلسلة الرسم البياني**
Aspose.Slides يسمح لك بتعيين عكس لون التعبئة لسلسلة الرسم البياني داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيل من فئة `Presentation`.
2. احصل على مرجع لشريحة بواسطة فهرسها.
3. أضف رسمًا بيانيًا ببيانات افتراضية بناءً على نوعك المفضل (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
4. الوصول إلى سلسلة الرسم البياني وتعيين لون التعبئة ليصبح معكوسًا.
5. حفظ العرض التقديمي إلى ملف PPTX.

هذا الكود بلغة C# يوضح العملية:

```c#
Color inverColor = Color.Red;
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // إضافة سلاسل وفئات جديدة
    chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "السلسلة 1"), chart.Type);
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "الفئة 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "الفئة 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "الفئة 3"));

    // أخذ السلسلة الأولى وملء بياناتها.
    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;
    pres.Save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);               
}
```

## **تعيين السلسلة لتكون معكوسة عندما تكون القيمة سالبة**
Aspose.Slides يسمح لك بتعيين العكس من خلال خصائص `IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative`. عندما يتم تعيين عكس باستخدام الخصائص، تعكس نقطة البيانات ألوانها عندما تحصل على قيمة سالبة.

هذا الكود بلغة C# يوضح لك العملية:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
	IChartSeriesCollection series = chart.ChartData.Series;
	chart.ChartData.Series.Clear();

	series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -2));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

	series[0].InvertIfNegative = false;

	series[0].DataPoints[2].InvertIfNegative = true;

	pres.Save("out.pptx", SaveFormat.Pptx);
}
```

## **مسح بيانات نقاط البيانات المحددة**
Aspose.Slides for .NET يسمح لك بمسح بيانات `DataPoints` لسلسلة رسم بياني محددة بهذه الطريقة:

1. أنشئ مثيل من فئة `Presentation`.
2. احصل على مرجع لشريحة من خلال فهرسها.
3. احصل على مرجع لرسم بياني من خلال فهرسه.
4. ت iter عبر جميع `DataPoints` للرسم البياني وتعيين `XValue` و `YValue` إلى null.
5. امسح جميع `DataPoints` لسلسلة رسم بياني معينة.
6. كتابة العرض التقديمي المعدل إلى ملف PPTX.

هذا الكود بلغة C# يوضح العملية:

```c#
using (Presentation pres = new Presentation("TestChart.pptx"))
{
	ISlide sl = pres.Slides[0];

	IChart chart = (IChart)sl.Shapes[0];

	foreach (IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
	{
		dataPoint.XValue.AsCell.Value = null;
		dataPoint.YValue.AsCell.Value = null;
	}

	chart.ChartData.Series[0].DataPoints.Clear();

	pres.Save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
}
```

## **تعيين عرض الفجوة للسلسلة**
Aspose.Slides for .NET يسمح لك بتعيين عرض الفجوة لسلسلة من خلال خاصية **`GapWidth`** بهذه الطريقة:

1. أنشئ مثيل من فئة `Presentation`.
2. الوصول إلى الشريحة الأولى.
3. أضف رسمًا بيانيًا ببيانات افتراضية.
4. الوصول إلى أي سلسلة رسم بياني.
5. تعيين خاصية `GapWidth`.
6. كتابة العرض التقديمي المعدل إلى ملف PPTX.

هذا الكود بلغة C# يوضح لك كيفية تعيين عرض فجوة لسلسلة:

```c#
// يقوم بإنشاء عرض تقديمي فارغ 
Presentation presentation = new Presentation();

// الوصول إلى الشريحة الأولى من العرض التقديمي
ISlide slide = presentation.Slides[0];

// إضافة رسم بياني ببيانات افتراضية
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 0, 0, 500, 500);

// تعيين فهرس ورقة البيانات للرسم البياني
int defaultWorksheetIndex = 0;

// الحصول على ورقة بيانات الرسم البياني
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// إضافة السلاسل
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "السلسلة 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "السلسلة 2"), chart.Type);

// إضافة الفئات
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "الفئة 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "الفئة 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "الفئة 3"));

// أخذ السلسلة الثانية
IChartSeries series = chart.ChartData.Series[1];

// ملء بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// تعيين قيمة GapWidth
series.ParentSeriesGroup.GapWidth = 50;

// حفظ العرض التقديمي إلى القرص
presentation.Save("GapWidth_out.pptx", SaveFormat.Pptx);
```