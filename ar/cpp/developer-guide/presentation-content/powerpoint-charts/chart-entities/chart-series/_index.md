---
title: إدارة بيانات سلسلة المخطط في العروض التقديمية باستخدام C++
linktitle: سلسلة البيانات
type: docs
url: /ar/cpp/chart-series/
keywords:
- سلسلة المخططات
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
description: "تعلم كيفية إدارة سلاسل المخططات في C++ لبرنامج PowerPoint (PPT/PPTX) مع أمثلة عملية على الشيفرات وأفضل الممارسات لتعزيز عروض البيانات الخاصة بك."
---
## **نظرة عامة**

هذه المقالة تصف دور ChartSeries في Aspose.Slides، مع التركيز على كيفية تنظيم البيانات وتصويرها داخل العروض التقديمية. توفر هذه الكائنات العناصر الأساسية التي تحدد مجموعات نقاط البيانات والفئات ومعلمات المظهر في المخطط. من خلال العمل مع ChartSeries، يمكن للمطوِّرين دمج مصادر البيانات الأساسية بسلاسة والحفاظ على التحكم الكامل في طريقة عرض المعلومات، مما ينتج عروض تقديمية ديناميكية تعتمد على البيانات وتوضح الأفكار والتحليل بوضوح.

السلسلة هي صف أو عمود من الأرقام يتم رسمه في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تحديد تداخل سلسلة البيانات**

باستخدام طريقة IChartSeries::get_Overlap() يمكنك تحديد مقدار تداخل الأعمدة والشرائط في مخطط ثنائي الأبعاد (النطاق: -100 إلى 100). تنطبق هذه الخاصية على جميع السلاسل في مجموعة السلاسل الأصلية: هذا عبارة عن إسقاط لخاصية المجموعة المناسبة.

استخدم طريقة `get_ParentSeriesGroup()::set_Overlap()` لتعيين القيمة المفضلة للخاصية `Overlap`.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
1. إضافة مخطط عمودي متجمع إلى شريحة.
1. الوصول إلى أول سلسلة مخطط.
1. الوصول إلى خاصية `ParentSeriesGroup` لسلسلة المخطط وتعيين قيمة التداخل المفضلة للسلسلة.
1. كتابة العرض المعدَّل إلى ملف PPTX.

هذا الكود C++ يوضح كيفية تعيين التداخل لسلسلة مخطط:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// يضيف مخطط
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // يحدد تداخل السلسلة
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// يحفظ ملف العرض التقديمي إلى القرص
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **تغيير لون سلسلة البيانات**
يسمح Aspose.Slides للغة C++ بتغيير لون السلسلة بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
1. إضافة مخطط إلى الشريحة.
1. الوصول إلى السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة ولون التعبئة المفضّل.
1. حفظ العرض المعدَّل.

هذا الكود C++ يوضح كيفية تغيير لون السلسلة:

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
يسمح Aspose.Slides للغة C++ بتغيير لون فئة السلسلة بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
1. إضافة مخطط إلى الشريحة.
1. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة ولون التعبئة المفضّل.
1. حفظ العرض المعدَّل.

هذا الكود C++ يوضح كيفية تغيير لون فئة السلسلة:

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

افتراضيًا، تكون أسماء وسيلة الإيضاح للمخطط هي محتويات الخلايا فوق كل عمود أو صف من البيانات.

في مثالنا (الصورة النموذجية)،

* الأعمدة هي *Series 1, Series 2,* و*Series 3*;
* الصفوف هي *Category 1, Category 2, Category 3,* و*Category 4*.

يسمح Aspose.Slides للغة C++ بتحديث أو تغيير اسم السلسلة في بيانات المخطط ووسيلة الإيضاح.

هذا الكود C++ يوضح كيفية تغيير اسم السلسلة في بيانات المخطط `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

هذا الكود C++ يوضح كيفية تغيير اسم السلسلة في وسيلة الإيضاح عبر `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **تحديد لون تعبئة سلسلة البيانات**

يسمح Aspose.Slides للغة C++ بتحديد لون التعبئة التلقائي لسلاسل المخطط داخل مساحة الرسم بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
1. الحصول على مرجع الشريحة حسب الفهرس.
1. إضافة مخطط ببيانات افتراضية بناءً على النوع المفضّل (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى Automatic.
1. حفظ العرض إلى ملف PPTX.

هذا الكود C++ يوضح كيفية تعيين لون تعبئة تلقائي لسلسلة مخطط:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// ينشئ مخطط عمودي متجمع
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// يحدد تنسيق تعبئة السلسلة إلى تلقائي
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// يكتب ملف العرض التقديمي إلى القرص
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **تحديد تعبئة عكسية لسلسلة البيانات**
يسمح Aspose.Slides بتحديد تعبئة عكسية لسلاسل المخطط داخل مساحة الرسم بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
1. الحصول على مرجع الشريحة حسب الفهرس.
1. إضافة مخطط ببيانات افتراضية بناءً على النوع المفضّل (في المثال أدناه، استخدمنا `ChartType::ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى invert.
1. حفظ العرض إلى ملف PPTX.

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

## **تحديد تعبئة عكسية لسلسلة مخطط**
يمكنك تعيين العكس عبر طريقتي `IChartDataPoint::set_InvertIfNegative()` و `ChartDataPoint.set_InvertIfNegative()`. عندما يتم تعيين العكس باستخدام هاتين الطريقتين، ينقلب لون نقطة البيانات عندما تحصل على قيمة سلبية.

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

## **مسح قيم نقاط البيانات المحددة**
يسمح Aspose.Slides للغة C++ بمسح بيانات `DataPoints` لسلسلة مخطط محددة بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع شريحة عبر الفهرس.
3. الحصول على مرجع مخطط عبر الفهرس.
4. تكرار جميع `DataPoints` في المخطط وتعيين `XValue` و `YValue` إلى null.
5. مسح جميع `DataPoints` للسلسلة المحددة.
6. كتابة العرض المعدَّل إلى ملف PPTX.

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

## **تحديد عرض الفجوة لسلسلة البيانات**
يسمح Aspose.Slides للغة C++ بتحديد عرض الفجوة لسلسلة عبر طريقة **`set_GapWidth()`** بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الوصول إلى أي سلسلة مخطط.
1. تعيين خاصية `GapWidth`.
1. كتابة العرض المعدَّل إلى ملف PPTX.

هذا الكود C++ يوضح كيفية تعيين عرض الفجوة لسلسلة:

```cpp
// ينشئ عرض تقديمي فارغ
auto presentation = System::MakeObject<Presentation>();

// يصل إلى الشريحة الأولى في العرض التقديمي
auto slide = presentation->get_Slides()->idx_get(0);

// يضيف مخططًا ببيانات افتراضية
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// يحدد فهرس ورقة بيانات المخطط
int32_t worksheetIndex = 0;

// يحصل على ورقة عمل بيانات المخطط
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// يضيف سلاسل
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// يضيف فئات
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// يأخذ السلسلة الثانية في المخطط
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// يملأ بيانات السلسلة
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// يحدد قيمة GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// يحفظ العرض التقديمي إلى القرص
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **الأسئلة المتداولة**

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها مخطط واحد؟**

Aspose.Slides لا يفرض حدًا ثابتًا على عدد السلاسل التي تضيفها. السقف العملي يحدده وضوح المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة متقاربة جدًا أو متباعدة جدًا؟**

قم بضبط إعداد عرض الفجوة لتلك السلسلة (أو مجموعة السلاسل الأصلية). زيادة القيمة توسّع الفجوة بين الأعمدة، بينما تقليلها يقتربها من بعضها.