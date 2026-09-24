---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام C++
linktitle: سلسلة البيانات
type: docs
url: /ar/cpp/chart-series/
keywords:
- سلسلة المخطط
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
description: "تعرّف على كيفية إدارة سلاسل المخطط، نقاط البيانات، خلايا دفتر العمل، التنسيق، التداخل، عرض الفجوة، والقيم السالبة في العروض التقديمية باستخدام C++."
---
## **نظرة عامة**

يخزن المخطط بياناته المرسومة في دفتر عمل بيانات المخطط. تمثل [IChartSeries](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/) مجموعة واحدة من القيم ذات الصلة، ويشير كل [IChartDataPoint](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/) في السلسلة إلى خلية أو أكثر في دفتر العمل. توفر كائنات [IChartCategory](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartcategory/) التسميات أو قيم التجميع المشتركة بين السلاسل. لذلك يتم ربط اسم السلسلة، الفئات، وقيم النقاط بكائنات [IChartDataCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/) بدلاً من تخزينها كنص عرض فقط.

في مخطط فئة نمطي، يستخدم دفتر العمل الافتراضي الصف 0 لأسماء السلاسل، والعمود 0 لأسماء الفئات، والخلايا المتبقية لقيم السلاسل. مؤشرات ورقة العمل، الصف، والعمود التي تُمرَّر إلى [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) تبدأ من الصفر. يُفيد هذا التخطيط عند إنشاء مخطط ببيانات افتراضية، لكن لا تفترض أن كل مخطط موجود يستخدمه. بالنسبة للعرض التقديمي المحمَّل، افحص الخلايا التي تشير إليها السلاسل والفئات ونقاط البيانات قبل تعديل قيم دفتر العمل.

لإعدادات المخطط ثلاث نطاقات مختلفة:

- إعدادات على مستوى السلسلة، مثل [IChartSeries::get_Format](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/get_format/)، تُحدد المظهر الافتراضي لجميع النقاط في سلسلة واحدة.
- إعدادات نقطة البيانات، مثل [IChartDataPoint::get_Format](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/get_format/)، تتجاوز مظهر السلسلة لنقطة واحدة.
- إعدادات المجموعة تنطبق على السلاسل المتوافقة التي تنتمي إلى نفس [IChartSeriesGroup](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseriesgroup/). يمكن الوصول إلى المجموعة عبر [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) عندما تحتاج لتعيين خيارات مثل التداخل أو عرض الفجوة.

عندما لا يتم تحديد تعبئة صريحة للنقطة أو السلسلة، يحدِّد نمط المخطط والموضوع المظهر التلقائي. عندما تكون كل من تنسيقات السلسلة والنقطة موجودة، تُعطى تنسيق النقطة الأولوية لتلك النقطة.

![سلسلة المخطط-PowerPoint](chart-series-powerpoint.png)

## **تعيين تداخل سلاسل المخطط**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/get_overlap/) يُبلغ عن مقدار تداخل الأعمدة أو الأشرطة في مخطط ثنائي الأبعاد، من -100 إلى 100 بالمئة. هو إسقاط قراءة‑فقط للإعداد على مجموعة السلسلة الأصلية. استدعِ [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) لتحديث كل السلاسل المتوافقة في تلك المجموعة. يُطبق هذا الخيار على أنواع المخططات التي تُظهر أعمدة أو أشرطة مجموعية؛ لا يؤثر على مجموعات السلاسل غير المرتبطة في مخطط مركب.

المثال التالي يحدد التداخل للمجموعة التي تحتوي على السلسلة الأولى:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// المخطط الجديد يحتوي على سلاسل وعينات وفئات وقيم.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تداخل السلسلة](series_overlap.png)

## **تغيير لون تعبئة السلسلة**

استخدم [IChartSeries::get_Format](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/get_format/) لتعيين التعبئة الافتراضية لسلسلة كاملة. إذا كان للّقطة تعبئة صريحة، فإن إعداد [IChartDataPoint::get_Format](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/get_format/) يتجاوز تعبئة السلسلة لتلك اللقطة.

المثال التالي يطبق تعبئة صلبة زرقاء على السلسلة الأولى:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![لون السلسلة](series_color.png)

## **تغيير اسم السلسلة**

يُخزن اسم السلسلة في دفتر عمل بيانات المخطط وعادةً ما يُعرض في المفتاح. في دفتر العمل الافتراضي المُنشأ لمخطط عمودي مجموعة، الخلية B1 هي الصف 0، العمود 1 وتحتوي على اسم السلسلة الأولى. الثوابت المسماة في المثال التالي تجعل هذا الهيكل واضحًا:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يمكنك أيضًا تحديث الخلية التي يُشير إليها [IChartSeries::get_Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/get_name/). يَتَجنَّب هذا الأسلوب الافتراض بوجود صف أو عمود معين في مخطط موجود:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![اسم السلسلة](series_name.png)

## **الحصول على لون تعبئة السلسلة التلقائي**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) يُعيد اللون المحسوب من فهرس السلسلة ونمط المخطط. هذا هو اللون المستخدم عندما لم تُحدَّد تعبئة السلسلة صراحةً. قراءة الطريقة تُعيد اللون المحسوب؛ لا تُعيّن تعبئة جديدة.

المثال التالي يطبع اللون التلقائي لكل سلسلة افتراضية:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

مثال على الإخراج لنمط المخطط الافتراضي:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

الألوان الدقيقة تعتمد على نمط المخطط والموضوع.

## **تعيين لون تعبئة معكوس لسلسلة المخطط**

بالنسبة لسلاسل الأشرطة، الأعمدة، والفقاعات، يمكن لـ [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) عرض القيم السالبة بتعبئة مختلفة. عيّن تعبئة السلسلة العادية إلى صلبة، فعّل العكس، وعيّن لون القيمة السالبة عبر [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). تبقى الأرقام السالبة غير متغيرة في دفتر العمل؛ يتغيّر لون عرضها فقط.

المثال التالي يستبدل بيانات المخطط الافتراضية بسلسلة واحدة. الصف 0 يحتوي اسم السلسلة، العمود 0 يحتوي أسماء الفئات، والعمود 1 يحتوي القيم:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![لون التعبئة الصلبة المعكوس](inverted_solid_fill_color.png)

يمكنك تفعيل العكس لنقطة واحدة عبر [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). في المثال التالي، يُعطَّل العكس للسلسلة ويُفعَّل فقط للنقطة المحددة. تُعطى النقطة أيضًا قيمة سالبة لتظهر التأثير:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **مسح قيمة نقطة بيانات محددة**

لجعل نقطة واحدة فارغة دون حذف باقي النقاط، عيّن خلية دفتر العمل الداعمة لها إلى `nullptr`. بالنسبة لمخطط عمودي، القيمة المرسومة متوفرة عبر [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). تبقى نقطة البيانات في نفس موضع الفئة، لكن المخطط يتعامل مع قيمتها كفراغ وفقًا لإعدادات القيم الفارغة للمخطط.

المثال التالي يمسح النقطة الثانية فقط في السلسلة الأولى:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تستخدم مخططات التشتت خلايا X وY منفصلة، وتستخدم مخططات الفقاعات خلية حجم أيضًا. امسح فقط الخلية التي تمثل القيمة التي تنوي إزالتها. لا تستدعي [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) عندما تريد الإبقاء على النقاط الأخرى، لأن هذه الطريقة تزيل جميع نقاط البيانات من المجموعة.

## **التحكم في عرض الخلايا الفارغة**

الخلية الفارغة في دفتر العمل تمثل بيانات مفقودة؛ الخلية التي تحتوي على `0` تمثل قيمة عددية معروفة. استدعِ [IChartDataCell::set_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/set_value/) مع `nullptr` لجعل الخلية فارغة. الصفر العددي يظل صفرًا بغض النظر عن إعداد خلية الفارغ.

استخدم [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/set_displayblanksas/) لاختيار طريقة عرض المخطط للخلايا الفارغة. ينطبق هذا الإعداد على المخطط بأكمله. يغيّر طريقة رسم الفراغات دون ملء الخلية الفارغة بالصفر أو قيمة مُستنتجة.

المثال التالي المستقل يخلق مخطط خطي بسلسلة واحدة، يمسح قيمة اليوم 3، ويحفظ المخطط نفسه بكل وضعية. لا يلزم ملف إدخال. يستخدم [IChartDataWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/) ورقة عمل 0، العمود 0 لتسميات الفئات، والعمود 1 للقيم؛ الصف 0 يحمل اسم السلسلة. البيانات النهائية هي `10, 20, empty, 30, 40`.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

كل ملف ناتج يُخزن الوضع المُعيّن قبل الحفظ: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx`، و`empty_cells_Span.pptx`. لحفظ نسخة واحدة فقط، عيّن الوضع المطلوب واحفظ العرض التقديمي مرة واحدة بدلًا من التكرار على جميع الأوضاع.

المقارنة أدناه تُظهر نفس البيانات في جميع الملفات الثلاثة. اليوم 3 فارغ في دفتر العمل في كل حالة:

![مخططات الخط مع بيانات مطابقة: الفجوة تقطع الخط عند اليوم 3، الصفر يخرِّج الخط إلى الصفر، والامتداد يربط اليوم 2 باليوم 4.](display_blanks_as.png)

التأثير المرئي يعتمد على نوع المخطط. يُسهِّل مخطط الخط مقارنة جميع الأوضاع الثلاثة. مخططات الأشرطة والأعمدة لا تحتوي على خط للربط عبر فئة مفقودة، لذا لا يمكن لـ `Span` إنتاج القطعة الموصلة كما في الأعلى؛ قد يبدو العمود المفقود والعمود صفر الارتفاع متشابهين. بالمثل، مخطط التشتت مع العلامات فقط لا يحتوي على خط ربط. لا تتوقع ثلاث نتائج مميزة لكل نوع مخطط؛ تحقق من النتيجة للنوع الذي تستخدمه.

## **تعيين عرض الفجوة بين السلاسل**

عرض الفجوة هو المسافة بين مجموعات الأشرطة أو الأعمدة المتجاورة، يُعبَّر عنها كنسبة مئوية من عرض الشريط أو العمود. مشابهًا للتداخل، ينتمي إلى مجموعة السلسلة الأصلية بدلاً من سلسلة واحدة. استدعِ [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) مرة واحدة للمجموعة. قيمة أكبر تُنشئ مساحة أكبر بين المجموعات؛ قيمة أصغر تجعلها أكثر كثافة.

المثال التالي يغيّر عرض الفجوة ويحفظ العرض التقديمي النهائي فقط:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![عرض الفجوة](gap_width.png)

## **الأسئلة الشائعة**

**ما أنواع المخططات التي تدعم سلاسل البيانات؟**

جميع أنواع المخططات الممثَّلة في تعداد [ChartType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/charttype/) تستخدم بيانات المخطط، لكن سلاسلتها لا تشترك دائمًا في بنية القيم أو الإعدادات. على سبيل المثال، تستخدم مخططات الفئات الفئات والقيم، وتستخدم مخططات التشتت قيم X وY، وتضيف مخططات الفقاعات أحجام الفقاعات. استخدم طريقة إنشاء نقطة البيانات التي تتطابق مع نوع السلسلة. تنطبق خيارات مثل التداخل وعرض الفجوة فقط على مجموعات الأشرطة أو الأعمدة المتوافقة.

**ما هي مجموعة سلاسل المخطط؟**

تحتوي [IChartSeriesGroup](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseriesgroup/) على سلاسل متوافقة تشترك في إعدادات الرسم على مستوى المجموعة. يمكن لمخطط مركب أن يحتوي على أكثر من مجموعة، لذا قد لا يؤدي تغيير المجموعة التي تُوصل عبر سلسلة واحدة إلى تغيير كل السلاسل في المخطط.

**هل يحتوي المخطط الذي تم إنشاؤه حديثًا على بيانات افتراضية؟**

نعم. بشكل افتراضي، تُنشئ [IShapeCollection::AddChart](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addchart/) سلاسل، فئات، وقيم نموذجية. يمكنك تحرير تلك الخلايا أو مسح كل من مجموعات السلاسل والفئات قبل إضافة مجموعة بيانات مخصصة بالكامل. يمكن أيضًا وجود نسخة زائدة تُنشئ مخططًا بدون بيانات افتراضية.

**كيف يتم ربط كائنات المخطط بخلايا دفتر العمل؟**

تشير أسماء السلاسل، تسميات الفئات، وقيم نقاط البيانات إلى خلايا في [IChartDataWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/). يؤدي تغيير خلية مُشار إليها إلى تحديث العنصر المقابل في المخطط. عند بناء بيانات مخصصة، احرص على محاذاة صفوف الفئات وصفوف قيم السلسلة بحيث تُرسم كل نقطة تحت الفئة المقصودة.

**كيف يمكن مسح نقطة واحدة بدلاً من سلاسة كاملة؟**

عيّن خلية القيمة ذات الصلة إلى `nullptr` للاحتفاظ بموقع الفئة للنقطة كقطة فارغة. استدعِ [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) فقط عندما تنوي إزالة جميع النقاط من تلك السلسلة. إذا أزلت الفئات أيضًا، حدّث كل السلاسل بحيث تظل قيمها متماشية مع مجموعة الفئات.

**كيف يتم عرض النقاط الفارغة؟**

يعتمد النتيجة على نوع المخطط و[IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/get_displayblanksas/). يمكن للمخططات المدعومة عرض الفراغات كفجوات، كقيم صفرية، أو بربط النقاط المجاورة. اختر الإعداد الذي يتطابق مع معنى البيانات المفقودة في عرضك. راجع قسم [التحكم في عرض الخلايا الفارغة](#control-the-display-of-empty-cells) للحصول على مثال كامل ومقارنة مرئية.

**كيف يتم تنسيق القيم السالبة؟**

بالنسبة لسلاسل الأشرطة، الأعمدة، والفقاعات المدعومة، استدعِ [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) وعيّن اللون عبر [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). يمكنك تجاوز السلوك لنقطة فردية باستخدام [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). هذه الطرق تؤثر على التنسيق، لا على القيم الرقمية المخزَّنة.

**أي تنسيق ينتصر عندما يتم تنسيق كل من السلسلة والنقطة؟**

تأخذ تنسيق نقطة البيانات الصريحة الأولوية لتلك النقطة. تستمر النقاط الأخرى في استخدام تنسيق السلسلة الصريح أو، إذا لم يُحدَّد تنسيق السلسلة، النمط والموضوع التلقائي للمخطط. إعدادات المجموعة مثل التداخل وعرض الفجوة تتحكم في التخطيط ولا تُعتبر تنسيقات تتجاوز مستوى النقطة.

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها المخطط؟**

لا يفرض Aspose.Slides حدًا ثابتًا منفصلًا لعدد السلاسل. عمليًا، تُحدَّد القدرة العملية بقيود ملف العرض التقديمي، الذاكرة المتاحة، وقت التصيير، وقابلية قراءة المخطط.

**ماذا ينبغي تعديل عندما تكون الأعمدة قريبة جدًا أو متباعدة كثيرًا؟**

استدعِ [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) على مجموعة السلسلة الأصلية المناسبة. زِد القيمة لزيادة المسافة بين المجموعات، أو قلِّلها لجعل المجموعات أقرب إلى بعضها.