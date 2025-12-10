---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام C++
linktitle: سلسلة البيانات
type: docs
url: /ar/cpp/chart-series/
keywords:
- سلسلة مخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة البيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخطط في C++ لبرنامج PowerPoint (PPT/PPTX) من خلال أمثلة عملية وكأفضل الممارسات لتحسين عروض بياناتك."
---

السلسلة هي صف أو عمود من الأرقام يتم رسمه في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة البيانات**

باستخدام طريقة [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) يمكنك تحديد مقدار التداخل بين الأعمدة والشدود في مخطط ثنائي الأبعاد (النطاق: -100 إلى 100). تنطبق هذه الخاصية على جميع سلاسل مجموعة السلسلة الأصلية: وهو تمثيل للخاصية المناسبة للمجموعة.

استخدم طريقة `get_ParentSeriesGroup()::set_Overlap()` لتعيين القيمة المفضلة لـ `Overlap`.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. إضافة مخطط عمودي مجمع إلى شريحة.
1. الوصول إلى أول سلسلة في المخطط.
1. الوصول إلى `ParentSeriesGroup` لسلسلة المخطط وتعيين قيمة التداخل المفضلة للسلسلة.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

هذا الكود C++ يوضح لك كيفية تعيين التداخل لسلسلة مخطط:
```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// إضافة مخطط
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // تعيين تداخل السلسلة
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// كتابة ملف العرض التقديمي إلى القرص
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```


## **تغيير لون سلسلة البيانات**
تسمح لك Aspose.Slides for C++ بتغيير لون سلسلة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. إضافة مخطط إلى الشريحة.
1. الوصول إلى السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة واللون المفضل.
1. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح لك كيفية تغيير لون سلسلة:
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


## **تغيير لون فئة سلسلة البيانات**
تسمح لك Aspose.Slides for C++ بتغيير لون فئة السلسلة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. إضافة مخطط إلى الشريحة.
1. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة واللون المفضل.
1. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح لك كيفية تغيير لون فئة السلسلة:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **تغيير اسم سلسلة البيانات** 

افتراضيًا، تكون أسماء وسيلة الإيضاح للمخطط هي محتويات الخلايا الموجودة فوق كل عمود أو صف من البيانات.

في مثالنا (الصورة النموذجية):

* الأعمدة هي *Series 1, Series 2,* و *Series 3*؛
* الصفوف هي *Category 1, Category 2, Category 3,* و *Category 4*.

تسمح لك Aspose.Slides for C++ بتحديث أو تغيير اسم سلسلة في بيانات المخطط ووسيلة الإيضاح.

هذا الكود C++ يوضح لك كيفية تغيير اسم سلسلة في بيانات المخطط `ChartDataWorkbook`:
```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


هذا الكود C++ يوضح لك كيفية تغيير اسم سلسلة في وسيلة الإيضاح عبر `Series`:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```


## **تعيين لون تعبئة سلسلة البيانات**

تسمح لك Aspose.Slides for C++ بتعيين لون التعبئة التلقائي لسلسلة المخطط داخل منطقة الرسم بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية بناءً على النوع المفضل (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى Automatic.
1. حفظ العرض التقديمي إلى ملف PPTX.

هذا الكود C++ يوضح لك كيفية تعيين لون التعبئة التلقائي لسلسلة مخطط:
```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// إنشاء مخطط عمود مجمع
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// تعيين تنسيق تعبئة السلسلة إلى تلقائي
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// كتابة ملف العرض التقديمي إلى القرص
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```


## **تعيين عكس ألوان تعبئة سلسلة البيانات**
تسمح لك Aspose.Slides بتعيين عكس لون التعبئة لسلسلة المخطط داخل منطقة الرسم بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الحصول على مرجع الشريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية بناءً على النوع المفضل (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى invert.
1. حفظ العرض التقديمي إلى ملف PPTX.

هذا الكود C++ يوضح العملية:
```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// إضافة سلاسل وفئات جديدة
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// يأخذ السلسلة الأولى في المخطط ويملأ بيانات السلسلة.
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


## **تعيين عكس لون التعبئة لسلسلة مخطط**
يمكنك تعيين العكس عبر `IChartDataPoint::set_InvertIfNegative()` و `ChartDataPoint.set_InvertIfNegative()` . عندما يتم تعيين العكس باستخدام هذه الطرق، يعكس نقطة البيانات ألوانها عندما تحصل على قيمة سالبة.

هذا الكود C++ يوضح العملية:
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


## **مسح قيم نقاط بيانات محددة**
تسمح لك Aspose.Slides for C++ بمسح بيانات `DataPoints` لسلسلة مخطط معينة بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع شريحة عبر فهرستها.
3. الحصول على مرجع مخطط عبر فهرستها.
4. التنقل عبر جميع `DataPoints` للمخطط وتعيين `XValue` و `YValue` إلى null.
5. مسح جميع `DataPoints` لسلسلة المخطط المحددة.
6. كتابة العرض التقديمي المعدل إلى ملف PPTX.

هذا الكود C++ يوضح العملية:
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


## **تعيين عرض الفجوة لسلسلة البيانات**
تسمح لك Aspose.Slides for C++ بتعيين عرض الفجوة لسلسلة عبر طريقة **`set_GapWidth()`** بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الوصول إلى أي سلسلة مخطط.
1. تعيين خاصية `GapWidth`.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

هذا الكود C++ يوضح لك كيفية تعيين عرض الفجوة لسلسلة:
```cpp
// إنشاء عرض تقديمي فارغ
auto presentation = System::MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى في العرض التقديمي
auto slide = presentation->get_Slides()->idx_get(0);

// إضافة مخطط ببيانات افتراضية
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// ضبط فهرس ورقة بيانات المخطط
int32_t worksheetIndex = 0;

// الحصول على ورقة عمل بيانات المخطط
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// إضافة سلاسل
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// إضافة فئات
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// أخذ السلسلة الثانية للمخطط
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// ملء بيانات السلسلة
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// ضبط قيمة GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// حفظ العرض التقديمي إلى القرص
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```


## **الأسئلة الشائعة**

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها مخطط واحد؟**

لا تفرض Aspose.Slides حدًا ثابتًا على عدد السلاسل التي تضيفها. الحد العملي يحدده وضوح المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة ماقربة جدًا أو متباعدة جدًا؟**

قم بضبط إعداد عرض الفجوة لتلك السلسلة (أو مجموعة السلاسل الأصلية). زيادة القيمة توسع المسافة بين الأعمدة، بينما تقليلها تقربها من بعضها.