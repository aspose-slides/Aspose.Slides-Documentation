---
title: كيفية إنشاء الرسوم البيانية في عرض تقديمي
type: docs
weight: 30
url: /ar/net/how-to-create-charts-in-a-presentation/
---

{{% alert color="primary" %}} 

تم إصدار [Aspose.Slides for .NET API](/slides/ar/net/) جديدة والآن يدعم هذا المنتج الوحيد القدرة على توليد مستندات PowerPoint من الصفر وتحرير المستندات الموجودة.

{{% /alert %}} 
## **دعم الكود القديم**
لاستخدام الكود القديم المطور باستخدام Aspose.Slides for .NET الإصدارات السابقة لـ 13.x، تحتاج إلى إجراء بعض التغييرات الطفيفة في كودك وسنعمل كالسابق. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديمة تحت مساحات أسماء Aspose.Slide و Aspose.Slides.Pptx قد تم دمجها الآن في مساحة أسماء Aspose.Slides واحدة. يرجى إلقاء نظرة على مقتطف الكود البسيط التالي لإنشاء رسم بياني عادي من الصفر في العرض التقديمي باستخدام واجهة برمجة التطبيقات القديمة لـ Aspose.Slides واتباع الخطوات التي تصف كيفية الانتقال إلى واجهة برمجة التطبيقات الجديدة المدمجة.
## **نهج Aspose.Slides القديم لـ .NET**
```c#
//إنشاء فئة PresentationEx التي تمثل ملف PPTX
using (PresentationEx pres = new PresentationEx())
{
	//الوصول إلى الشريحة الأولى
	SlideEx sld = pres.Slides[0];

	// إضافة رسم بياني مع بيانات افتراضية
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//تعيين عنوان الرسم البياني
	chart.ChartTitle.Text.Text = "عنوان العينة";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//تعيين السلسلة الأولى لعرض القيم
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//تعيين فهرس ورقة البيانات للرسم البياني 
	int defaultWorksheetIndex = 0;

	//الحصول على ورقة البيانات للرسم البياني
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//حذف السلاسل والفئات المولدة افتراضياً
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//إضافة سلاسل جديدة
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "السلسلة 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "السلسلة 2"), chart.Type);

	//إضافة فئات جديدة
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "الفئة 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "الفئة 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "الفئة 3"));

	//أخذ السلسلة الأولى من الرسم البياني
	ChartSeriesEx series = chart.ChartData.Series[0];

	//الآن نقوم بتعبئة بيانات السلسلة
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//تعيين لون التعبئة للسلسلة
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//أخذ السلسلة الثانية من الرسم البياني
	series = chart.ChartData.Series[1];

	//الآن نقوم بتعبئة بيانات السلسلة
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//تعيين لون التعبئة للسلسلة
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//إنشاء تسميات مخصصة لكل فئة للسلاسل الجديدة

	//ستظهر التسمية الأولى اسم الفئة
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//عرض اسم السلسلة للتسمية الثانية
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//عرض القيمة للتسمية الثالثة
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//عرض القيمة والنص المخصص
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "نص كالمعتاد";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//حفظ العرض التقديمي مع الرسم البياني
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **نهج Aspose.Slides الجديد لـ .NET 13.x**
``` csharp
//إنشاء فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();

//الوصول إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

// إضافة رسم بياني مع بيانات افتراضية
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//تعيين عنوان الرسم البياني
//chart.ChartTitle.TextFrameForOverriding.Text = "عنوان العينة";
chart.ChartTitle.AddTextFrameForOverriding("عنوان العينة");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//تعيين السلسلة الأولى لعرض القيم
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//تعيين فهرس ورقة البيانات للرسم البياني
int defaultWorksheetIndex = 0;

//الحصول على ورقة البيانات للرسم البياني
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//حذف السلاسل والفئات المولدة افتراضياً
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//إضافة سلاسل جديدة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "السلسلة 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "السلسلة 2"), chart.Type);

//إضافة فئات جديدة
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "الفئة 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "الفئة 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "الفئة 3"));

//أخذ السلسلة الأولى من الرسم البياني
IChartSeries series = chart.ChartData.Series[0];

//الآن نقوم بتعبئة بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//تعيين لون التعبئة للسلسلة
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//أخذ السلسلة الثانية من الرسم البياني
series = chart.ChartData.Series[1];

//الآن نقوم بتعبئة بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//تعيين لون التعبئة للسلسلة
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//إنشاء تسميات مخصصة لكل من الفئات للسلسلة الجديدة

//ستظهر التسمية الأولى اسم الفئة
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//عرض القيمة للتسمية الثالثة
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//حفظ العرض التقديمي مع الرسم البياني
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

يرجى إلقاء نظرة على مقتطف الكود البسيط التالي لإنشاء رسم بياني مبعثر من الصفر في العرض التقديمي باستخدام واجهة برمجة التطبيقات القديمة لـ Aspose.Slides وكيفية تحقيق ذلك باستخدام واجهة برمجة التطبيقات الجديدة المدمجة.

## **نهج Aspose.Slides القديم لـ .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //إنشاء الرسم البياني الافتراضي
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //الحصول على فهرس ورقة بيانات الرسم البياني الافتراضية
    int defaultWorksheetIndex = 0;

    //الوصول إلى ورقة بيانات الرسم البياني
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //حذف السلاسل التجريبية
    chart.ChartData.Series.Clear();

    //إضافة سلاسل جديدة
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "السلسلة 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "السلسلة 2"), chart.Type);

    //أخذ السلسلة الأولى من الرسم البياني
    ChartSeriesEx series = chart.ChartData.Series[0];

    //إضافة نقطة جديدة (1:3) هناك.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //إضافة نقطة جديدة (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //تحرير نوع السلسلة
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //تغيير علامة سلسلة الرسم البياني
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //أخذ السلسلة الثانية من الرسم البياني
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

    //تغيير علامة سلسلة الرسم البياني
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **نهج Aspose.Slides الجديد لـ .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//إنشاء الرسم البياني الافتراضي
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//الحصول على فهرس ورقة بيانات الرسم البياني الافتراضية
int defaultWorksheetIndex = 0;

//الوصول إلى ورقة بيانات الرسم البياني
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//حذف السلاسل التجريبية
chart.ChartData.Series.Clear();

//إضافة سلاسل جديدة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "السلسلة 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "السلسلة 2"), chart.Type);

//أخذ السلسلة الأولى من الرسم البياني
IChartSeries series = chart.ChartData.Series[0];

//إضافة نقطة جديدة (1:3) هناك.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//إضافة نقطة جديدة (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//تحرير نوع السلسلة
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//تغيير علامة سلسلة الرسم البياني
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//أخذ السلسلة الثانية من الرسم البياني
series = chart.ChartData.Series[1];

//إضافة نقطة جديدة (5:2) هناك.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//إضافة نقطة جديدة (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//إضافة نقطة جديدة (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//إضافة نقطة جديدة (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//تغيير علامة سلسلة الرسم البياني
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```