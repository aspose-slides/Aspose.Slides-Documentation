---
title: كيفية إنشاء المخططات في العروض التقديمية في .NET
linktitle: إنشاء مخطط
type: docs
weight: 30
url: /ar/net/how-to-create-charts-in-a-presentation/
keywords:
- ترحيل
- إنشاء مخطط
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء المخططات في عروض PowerPoint (PPT, PPTX) و ODP في .NET باستخدام Aspose.Slides من خلال كل من واجهات برمجة التطبيقات للرسوم البيانية القديمة والحديثة."
---

{{% alert color="primary" %}} 

تم إصدار واجهة برمجة تطبيقات Aspose.Slides for .NET الجديدة الآن ، وتدعم هذه الوحدة القدرة على إنشاء مستندات PowerPoint من الصفر وتعديل المستندات الموجودة.

{{% /alert %}} 
## **دعم الشيفرة القديمة**
من أجل استخدام الشيفرة القديمة التي تم تطويرها باستخدام Aspose.Slides for .NET بالإصدارات السابقة لـ 13.x، تحتاج إلى إجراء بعض التعديلات الطفيفة في الشيفرة الخاصة بك وسيستمر عملها كما كان. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديمة تحت مساحتي الاسم Aspose.Slide و Aspose.Slides.Pptx تم دمجها الآن في مساحة الاسم الوحيدة Aspose.Slides. يرجى إلقاء نظرة على المقتطف البرمجي البسيط التالي لإنشاء مخطط عادي من الصفر في العرض باستخدام واجهة Aspose.Slides القديمة واتباع الخطوات التي توضح كيفية الت迁ية إلى واجهة البرمجة المدمجة الجديدة.
## **نهج Aspose.Slides for .NET القديم**
```c#
//إنشاء مثيل لفئة PresentationEx التي تمثل ملف PPTX
using (PresentationEx pres = new PresentationEx())
{
	//الوصول إلى الشريحة الأولى
	SlideEx sld = pres.Slides[0];

	// إضافة مخطط ببيانات افتراضية
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//تعيين عنوان المخطط
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//ضبط السلسلة الأولى لعرض القيم
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//تعيين فهرس ورقة بيانات المخطط 
	int defaultWorksheetIndex = 0;

	//استرداد ورقة عمل بيانات المخطط
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//إضافة سلاسل جديدة
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//إضافة فئات جديدة
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//أخذ سلسلة المخطط الأولى
	ChartSeriesEx series = chart.ChartData.Series[0];

	//الآن يتم تعبئة بيانات السلسلة
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//تعيين لون التعبئة للسلسلة
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//أخذ سلسلة المخطط الثانية
	series = chart.ChartData.Series[1];

	//الآن يتم تعبئة بيانات السلسلة
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//تعيين لون التعبئة للسلسلة
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//إنشاء تسميات مخصصة لكل فئة في السلسلة الجديدة

	//التسمية الأولى ستظهر اسم الفئة
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//إظهار اسم السلسلة للتسمية الثانية
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//إظهار القيمة للتسمية الثالثة
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//إظهار القيمة والنص المخصص
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//حفظ العرض التقديمي مع المخطط
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **نهج Aspose.Slides for .NET 13.x الجديد**
``` csharp
//إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX//إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();

//الوصول إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة مخطط ببيانات افتراضية
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//تعيين عنوان المخطط
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//ضبط السلسلة الأولى لعرض القيم
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//تعيين فهرس ورقة بيانات المخطط
int defaultWorksheetIndex = 0;

//الحصول على ورقة عمل بيانات المخطط
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//إضافة سلاسل جديدة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//إضافة فئات جديدة
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//أخذ سلسلة المخطط الأولى
IChartSeries series = chart.ChartData.Series[0];

//الآن يتم تعبئة بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//تعيين لون التعبئة للسلسلة
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//أخذ سلسلة المخطط الثانية
series = chart.ChartData.Series[1];

//الآن يتم تعبئة بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//تعيين لون التعبئة للسلسلة
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//إنشاء تسميات مخصصة لكل فئة في السلسلة الجديدة

//التسمية الأولى ستظهر اسم الفئة
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//إظهار القيمة للتسمية الثالثة
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//حفظ العرض التقديمي مع المخطط
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


يرجى إلقاء نظرة على المقتطف البرمجي البسيط التالي لإنشاء مخطط مبعثر من الصفر في العرض باستخدام واجهة Aspose.Slides القديمة وكيفية تحقيق ذلك باستخدام الواجهة المدمجة الجديدة.

## **نهج Aspose.Slides for .NET القديم**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //إنشاء المخطط الافتراضي
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //الحصول على فهرس ورقة بيانات المخطط الافتراضية
    int defaultWorksheetIndex = 0;

    //الوصول إلى ورقة بيانات المخطط
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //حذف السلسلة التجريبية
    chart.ChartData.Series.Clear();

    //إضافة سلسلة جديدة
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //أخذ أول سلسلة مخطط
    ChartSeriesEx series = chart.ChartData.Series[0];

    //إضافة نقطة جديدة (1:3) هناك.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //إضافة نقطة جديدة (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //تعديل نوع السلسلة
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //تغيير علامة سلسلة المخطط
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //أخذ سلسلة المخطط الثانية
    series = chart.ChartData.Series[1];

    //إضافة نقطة جديدة (5:2) هناك.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //إضافة نقطة جديدة (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //إضافة نقطة جديدة (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //إضافة نقطة جديدة (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //تغيير علامة سلسلة المخطط
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **نهج Aspose.Slides for .NET 13.x الجديد**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//إنشاء المخطط الافتراضي
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//الحصول على فهرس ورقة بيانات المخطط الافتراضية
int defaultWorksheetIndex = 0;

//الوصول إلى ورقة بيانات المخطط
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//حذف سلسلة التجربة
chart.ChartData.Series.Clear();

//إضافة سلسلة جديدة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//أخذ أول سلسلة مخطط
IChartSeries series = chart.ChartData.Series[0];

//إضافة نقطة جديدة (1:3) هناك.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//إضافة نقطة جديدة (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//تعديل نوع السلسلة
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//تغيير علامة سلسلة المخطط
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//أخذ سلسلة المخطط الثانية
series = chart.ChartData.Series[1];

//إضافة نقطة جديدة (5:2) هناك.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//إضافة نقطة جديدة (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//إضافة نقطة جديدة (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//إضافة نقطة جديدة (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//تغيير علامة سلسلة المخطط
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
