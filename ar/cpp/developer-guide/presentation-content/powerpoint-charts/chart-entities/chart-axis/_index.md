---
title: المحور البياني
type: docs
url: /ar/cpp/chart-axis/
keywords: "محور الرسم البياني في باوربوينت، رسومات باوربوينت، C++، التحكم في محور الرسم البياني، بيانات الرسم البياني"
description: "كيفية تعديل محور الرسم البياني في باوربوينت باستخدام C++"
---


## **الحصول على القيم القصوى على المحور العمودي في الرسوم البيانية**
يسمح لك Aspose.Slides لـ C++ بالحصول على القيم الدنيا والقصوى على المحور العمودي. اتبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني ببيانات افتراضية.
1. الحصول على القيمة القصوى الفعلية على المحور.
1. الحصول على القيمة الدنيا الفعلية على المحور.
1. الحصول على وحدة المحور الكبرى الفعلية.
1. الحصول على وحدة المحور الصغرى الفعلية.
1. الحصول على مقياس وحدة المحور الكبرى الفعلية.
1. الحصول على مقياس وحدة المحور الصغرى الفعلية.

يوضح لك هذا الكود المثال—تنفيذ الخطوات أعلاه—كيفية الحصول على القيم المطلوبة باستخدام C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Saves the presentation
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```


## **تبديل البيانات بين المحاور**
يسمح لك Aspose.Slides بتبديل البيانات بسرعة بين المحاور—البيانات الممثلة على المحور العمودي (محور y) تنتقل إلى المحور الأفقي (محور x) والعكس صحيح.

يظهر لك هذا الكود بلغة C++ كيفية تنفيذ مهمة تبديل البيانات بين المحاور على رسم بياني:

``` cpp
// Creates empty presentation
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Switches rows and columns
chart->get_ChartData()->SwitchRowColumn();

// Saves presentation
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **تعطيل المحور العمودي لرسوم البيانية الخطية**

يظهر لك هذا الكود بلغة C++ كيفية إخفاء المحور العمودي لرسم بياني خطي:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **تعطيل المحور الأفقي لرسوم البيانية الخطية**

يظهر لك هذا الكود كيفية إخفاء المحور الأفقي لرسم بياني خطي:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **تغيير محور الفئة**

باستخدام الطريقة **set_CategoryAxisType()**، يمكنك تحديد نوع محور الفئة المفضل لديك (**تاريخ** أو **نص**). يوضح هذا الكود بلغة C++ العملية:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **تعيين تنسيق التاريخ لقيمة محور الفئة**
يسمح لك Aspose.Slides لـ C++ بتعيين تنسيق التاريخ لقيمة محور الفئة. يتم توضيح العملية في هذا الكود بلغة C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **تعيين زاوية الدوران لعنوان المحور البياني**
يسمح لك Aspose.Slides لـ C++ بتعيين زاوية الدوران لعنوان المحور البياني. يوضح هذا الكود بلغة C++ العملية:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **تعيين محور الموقع في محور فئة أو قيمة**
يسمح لك Aspose.Slides لـ C++ بتعيين محور الموقع في محور فئة أو قيمة. يوضح لك هذا الكود بلغة C++ كيفية تنفيذ المهمة:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **تمكين عرض تسمية وحدة على محور قيمة الرسم البياني**
يسمح لك Aspose.Slides لـ C++ بتكوين رسم بياني ليظهر تسمية وحدة على محور القيمة الخاص به. يوضح هذا الكود بلغة C++ العملية:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```