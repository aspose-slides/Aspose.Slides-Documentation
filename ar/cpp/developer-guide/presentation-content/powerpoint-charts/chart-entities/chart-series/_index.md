---
title: سلسلة المخطط
type: docs
url: /ar/cpp/chart-series/
---

السلسلة هي صف أو عمود من الأرقام مرسومة في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

باستخدام طريقة [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb)، يمكنك تحديد مقدار تداخل الأشرطة والأعمدة في مخطط ثنائي الأبعاد (نطاق: -100 إلى 100). تنطبق هذه الخاصية على جميع السلاسل في مجموعة السلسلة الأصلية: هذه إسقاط للخاصية المناسبة للمجموعة.

استخدم طريقة `get_ParentSeriesGroup()::set_Overlap()` لتعيين القيمة المفضلة لديك لـ `Overlap`.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. أضف مخطط عمودي مجمع على شريحة.
1. الوصول إلى أول سلسلة مخطط.
1. الوصول إلى `ParentSeriesGroup` لسلسلة المخطط وضبط قيمة التداخل المفضلة للسلسلة.
1. اكتب العرض المعدل في ملف PPTX.

يوضح هذا الكود بلغة C++ كيفية ضبط التداخل لسلسلة المخطط:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Sets series overlap
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Writes the presentation file to disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **تغيير لون السلسلة**
تسمح Aspose.Slides لـ C++ بتغيير لون السلسلة بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. أضف مخططًا على الشريحة.
1. الوصول إلى السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
1. حفظ العرض المعدل.

يوضح هذا الكود بلغة C++ كيفية تغيير لون السلسلة:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **تغيير لون فئة السلسلة**
تسمح Aspose.Slides لـ C++ بتغيير لون فئة السلسلة بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. أضف مخططًا على الشريحة.
1. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
1. حفظ العرض المعدل.

يوضح هذا الكود بلغة C++ كيفية تغيير لون فئة السلسلة:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **تغيير اسم السلسلة**

بشكل افتراضي، الأسماء الأسطورية لمخطط هي محتويات الخلايا الموجودة فوق كل عمود أو صف من البيانات.

في مثالنا (صورة عينة)،

* الأعمدة هي *السلسلة 1، السلسلة 2،* و *السلسلة 3*؛
* الصفوف هي *الفئة 1، الفئة 2، الفئة 3،* و *الفئة 4.* 

تسمح Aspose.Slides لـ C++ بتحديث أو تغيير اسم السلسلة في بيانات مخططها والأسطورة.

يوضح هذا الكود بلغة C++ كيفية تغيير اسم سلسلة في بيانات المخطط `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"اسم جديد"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

يوضح هذا الكود بلغة C++ كيفية تغيير اسم سلسلة في أسطورتها من خلال `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"اسم جديد"));
```

## **تعيين لون تعبئة سلسلة المخطط**

تسمح Aspose.Slides لـ C++ بتعيين لون التعبئة التلقائي لسلاسل المخطط داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. احصل على مرجع شريحة من خلال فهرسها.
1. أضف مخططًا ببيانات افتراضية بناءً على نوعك المفضل (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وضبط لون التعبئة ليكون تلقائيًا.
1. حفظ العرض في ملف PPTX.

يوضح هذا الكود بلغة C++ كيفية تعيين لون التعبئة التلقائي لسلسلة المخطط:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Creates a clustered column chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Sets series fill format to automatic
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Writes the presentation file to disk
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **تعيين ألوان تعبئة السلسلة إلى عكس**
تسمح Aspose.Slides لك بتعيين لون التعبئة العكسية لسلسلة المخطط داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. احصل على مرجع شريحة من خلال فهرسها.
1. أضف مخططًا ببيانات افتراضية بناءً على نوعك المفضل (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وضبط لون التعبئة ليكون عكسياً.
1. حفظ العرض في ملف PPTX.

يوضح هذا الكود بلغة C++ العملية:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```


## **تعيين السلسلة للعكس عند القيمة السلبية**
تسمح Aspose.Slides لك بتعيين العكس من خلال الطرق `IChartDataPoint::set_InvertIfNegative()` و `ChartDataPoint.set_InvertIfNegative()` . عندما يتم تعيين العكس باستخدام الطرق، يقوم نقطة البيانات بعكس ألوانها عندما تحصل على قيمة سلبية.

يوضح هذا الكود بلغة C++ العملية:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **مسح بيانات نقاط البيانات المحددة**
تسمح Aspose.Slides لـ C++ بمسح بيانات `DataPoints` لسلسلة مخطط محددة بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع شريحة من خلالها فهرسها.
3. احصل على مرجع لمخطط من خلال فهرسه.
4. تكرار جميع `DataPoints` الخاصة بالمخطط وضبط `XValue` و `YValue` إلى null.
5. مسح جميع `DataPoints` لعدد معين من سلاسل المخطط.
6. اكتب العرض المعدل إلى ملف PPTX.

يوضح هذا الكود بلغة C++ العملية:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **تعيين عرض الفجوة للسلسلة**
تسمح Aspose.Slides لـ C++ بتعيين عرض الفجوة لسلسلة من خلال طريقة **`set_GapWidth()`** بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الوصول إلى الشريحة الأولى.
1. أضف مخططًا ببيانات افتراضية.
1. الوصول إلى أي سلسلة مخطط.
1. تعيين خاصية `GapWidth`.
1. اكتب العرض المعدل إلى ملف PPTX.

يوضح هذا الكود بلغة C++ كيفية تعيين عرض الفجوة لسلسلة:

```cpp
// Creates empty presentation 
auto presentation = System::MakeObject<Presentation>();

// Accesses the presentation's first slide
auto slide = presentation->get_Slides()->idx_get(0);

// Adds a chart with default data
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Sets the index of the chart data sheet
int32_t worksheetIndex = 0;

// Gets the chart data worksheet
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Adds series
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Adds Categories
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the second chart series
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Populates the series data
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Sets GapWidth value
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Saves presentation to disk
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```