---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام C++
linktitle: محور المخطط
type: docs
url: /ar/cpp/chart-axis/
keywords:
- محور المخطط
- المحور الرأسي
- المحور الأفقي
- تخصيص المحور
- معالجة المحور
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
- C++
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides للغة C++ لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides للـ C++. تغطي القيم المحسوبة للمحاور، تبديل صفوف وأعمدة المخطط، إظهار/إخفاء المحور، فترات تسميات الفئات وعلامات الفواصل، فئات التاريخ والتنسيق، دوران العنوان، موضع المحور، وحدات العرض، والتحجيم اللوغاريتمي.

## **الحصول على القيم القصوى على المحور الرأسي في المخططات**

أنشئ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وأضف مخطط مساحة بالبيانات الافتراضية. استدعِ [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحاور لضمان أن تخطيط المخطط محدث.

اقرأ [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) و[ get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) للحصول على حدود المحور، و[get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) و[get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) لفواصل العلامات. توفر [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) و[get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) مقاييس الوحدات الزمنية، وهي ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **تبديل البيانات بين المحاور**

استخدم [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. يغيّر ذلك طريقة تجميع البيانات؛ لكنه لا يبدل المحاور الأفقية والرأسية. يستخدم المثال [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا بأربع سلاسل وثلاث فئات.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **عكس ترتيب الرسم للمحور**

استخدم [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) لعكس محور الفئة أو القيمة. على سبيل المثال، يمكن لمخطط شريطي أفقي أن يظهر مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: Planning, Development, Testing. عكس المحور يغيّر اتجاه الرسم؛ لكنه لا يقوم بفرز أو إعادة ترتيب بيانات المصنف. بالمقارنة، [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) يبدل أدوار السلاسل والفئات.

المثال التالي ينشئ مخططًا شريطيًا أفقيًا بثلاث مراحل وسلسلة واحدة. يحفظ عرض تقديمي بـ ثلاث شرائح: الترتيب الطبيعي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم نفس مجموعة البيانات، ولا يتم عكس سوى محور واحد في كل نسخة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// الشريحة 2: عرض الفئة الأولى في الأعلى.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// ابقِ محور القيمة الأفقي في الأسفل.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// الشريحة 3: عكس مقياس الأرقام الأفقي فقط.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

عكس المحور يمكن أيضًا أن ينقل المحور العمودي إلى الجانب المقابل من الرسم. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) يحدد موضع تقاطع المحور الآخر مع المحور الجاري تكوينه. في الشريحة 2، ضبطه على `Maximum` على محور الفئة المعكوس يحافظ على وجود محور القيمة الأفقي في الأسفل. لتحديد نقطة تقاطع معينة، استخدم [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). تحقق من إعدادات التقاطع عند تغيير الاتجاه، خاصة إذا كان المخطط يحتوي بالفعل على نقطة تقاطع مخصصة. استدعِ `set_IsPlotOrderReversed` مع `false` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع منفصلة.

| الترتيب الطبيعي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريطي أفقي بترتيب الفئة والمحور القيمي الطبيعي](axis-order-normal.png) | ![مخطط شريطي أفقي مع عرض الفئات من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريطي أفقي بمحور قيم معكوس وصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | Planning, Development, and Testing تمتد من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف غير متغير. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. محور الفئة يلتقي عند الصفر على اليمين. |

## **تعطيل المحور الرأسي لمخططات الخط**

استخدم [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) مع `false` على المحور الرأسي لإخفائه. ينشئ المثال مخطط خط بالبيانات الافتراضية ويحفظه مع إخفاء المحور الرأسي.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **تعطيل المحور الأفقي لمخططات الخط**

استخدم [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) مع `false` على المحور الأفقي لإخفائه. ينشئ المثال مخطط خط بالبيانات الافتراضية ويحفظه مع إخفاء المحور الأفقي.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **إظهار أو إخفاء خطوط الشبكة في المخطط**

استخدم [get_ShowMajorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showmajorgridlines/) و[get_ShowMinorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showminorgridlines/) للتحقق من الخطوط التي يعرضها المحور. كلا الخاصيتين للقراءة فقط. لإظهار خطوط الشبكة الصغيرة، استخدم [get_MinorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_minorgridlinesformat/) واضبط تعبئة الخط إلى لون صلب مرئي. لإخفائها، اضبط التعبئة إلى [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/). استخدم [get_MajorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_majorgridlinesformat/) لتغيير خطوط الشبكة الكبيرة بنفس الطريقة. تغيير تعبئة الخط يحافظ على ظهور المحور وعلامات الفواصل.

المحور الرأسي لهذا المخطط العمودي المجمّع يظهر في البداية خطوط الشبكة الكبيرة فقط. يعرض المثال خطوط الشبكة الصغيرة باللون البرتقالي، ثم يخفيها مرة أخرى قبل حفظ العرض التقديمي.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
auto axis = chart->get_Axes()->get_VerticalAxis();
std::cout << std::boolalpha << "Initial: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

auto minorFill = axis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat();
minorFill->set_FillType(FillType::Solid);
minorFill->get_SolidFillColor()->set_Color(Color::get_DarkOrange());
std::cout << "Enabled: minor=" << axis->get_ShowMinorGridLines() << '\n';

minorFill->set_FillType(FillType::NoFill);
std::cout << "Hidden: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

presentation->Save(u"ChartGridlines.pptx", SaveFormat::Pptx);
```

| خطوط الشبكة الصغيرة مفعلة | خطوط الشبكة الصغيرة مخفية |
| --- | --- |
| ![خطوط شبكة صغيرة برتقالية بين خطوط الشبكة الكبيرة على المحور الرأسي](minor-gridlines-enabled.png) | ![مخطط الأعمدة نفسه مع إظهار خطوط الشبكة الكبيرة فقط](minor-gridlines-hidden.png) |

## **تغيير محور الفئة**

استخدم [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) لاختيار محور فئة تاريخي أو نصي. يتطلب هذا المثال ملف `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا الفئة تحتوي على قيم تاريخ إكسل رقمية. يغيّر المحور الأفقي إلى محور تاريخ. استدعِ [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) مع `false`، و[set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) مع `1`، و[set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) مع الأشهر لتضع العلامات الرئيسية بفواصل شهرية.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

### **تحديد نوع محور الفئة من البيانات**

Call [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) after populating the categories, then call [get_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_categoryaxistype/) to inspect the selection. This is useful when the same chart receives either text labels or numeric date values. The method determines the type when called; it does not enable a persistent mode that reevaluates later data changes. Call it again after replacing the categories.

The following example creates a chart with text categories and prints `Text`. It then replaces the category cell values with dates and calls the method again, which prints `Date`. Dates are stored as numeric OLE Automation values returned by [System::DateTime::ToOADate](https://reference.aspose.com/slides/cpp/system/datetime/tooadate/), rather than date strings. [set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) controls how those values are displayed; it does not convert text into numeric dates. For more on category cells, see [دفتر عمل المخطط](/slides/ar/cpp/chart-workbook/).

Use automatic determination when the input is known to contain text categories or numeric dates, as in this example. For ordinary numeric labels, mixed categories, or empty data, explicitly call [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_categoryaxistype/) to match the intended meaning. Numeric values alone do not establish that the categories represent dates.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/date_time.h>
#include <system/console.h>
#include <system/enum.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto seriesName = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());
auto labels = std::array<System::String, 3>{u"First", u"Second", u"Third"};

for (auto i = 0; i < labels.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(labels[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box((i + 1) * 10));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // نص

auto dates = std::array<System::DateTime, 3>{System::DateTime(2026, 1, 1), System::DateTime(2026, 1, 2), System::DateTime(2026, 2, 1)};

for (auto i = 0; i < dates.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0);
    categoryCell->set_Value(System::ObjectExt::Box(dates[i].ToOADate()));
    categoryCell->set_CustomNumberFormat(u"yyyy-mm-dd");
}

axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // تاريخ

presentation->Save(u"AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
```

## **التحكم في فواصل تسميات محور الفئة**

عند وجود many categories في مخطط، قلل عدد تسميات المحور الظاهرة دون إزالة الفئات أو نقاط البيانات. استخدم [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) مع `false`، ثم استخدم [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) مع الفاصل المطلوب بين الفئات. للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1, الفئة 2, الفئة 3, ... الفئة 24 |
| `2` | الفئة 1, الفئة 3, الفئة 5, ... الفئة 23 |
| `3` | الفئة 1, الفئة 4, الفئة 7, ... الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، مع إخفاء اثنتين بين كل تسمية ظاهرة. لا يتم حذف الأعمدة المقابلة. التباعد التلقائي يختار الفاصل بناءً على المساحة المتاحة؛ لا يعرض بالضرورة كل تسمية.

علامات الفواصل لها تحكم منفصل. استخدم [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) مع `false` واستخدم [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) لتحديد فاصلها. على سبيل المثال، `1` يبقي علامة فاصل عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استخدم [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) بنمط مرئي لتتمكن من رؤية النتيجة. ضبط أي من خاصيتي التباعد التلقائي إلى `true` يسمح للمخطط باختيار الفاصل مرة أخرى.

المثال التالي المستقل ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي لتسميات الفئات مع علامات فواصل مستقلة، واستعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم وجود عرض تقديمي مدخل. يجعل النص الأفقي للتسمية الفرق في الكثافة واضحًا.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// الشريحة 2: عرض كل تسمية ثالثة، مع الحفاظ على علامة فاصل لكل فئة.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// الشريحة 3: دع المخطط يختار كلا الفاصلين مرة أخرى.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**التباعد التلقائي (الشريحة 1):** في هذا العرض، يتم عرض كل تسمية فئة ثانية وتلتف إلى سطرين. قد تختلف النتيجة التلقائية حسب حجم المخطط، الخطوط، والمحرك.

![التباعد التلقائي لتسميات الفئات مع جميع الأعمدة الـ24 ظاهرة](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** يتم عرض كل تسمية ثالثة في سطر واحد، بينما تظل علامات الفواصل عند كل فاصل فئة. جميع الأعمدة الـ24، بما في ذلك التي لا تحمل تسميات، تظل ظاهرة بنفس القيم. تستعيد الشريحة 3 المظهر التلقائي المعروض أعلاه.

![تباعد يدوي لتسمية الفئة بمقدار ثلاثة مع جميع الأعمدة الـ24 ظاهرة](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل لعدد الفئات لمحور فئة نصية، مثل محور فئة عمود، خط، مساحة، أو مخطط شريطي. في مخطط عمود يكون هو المحور الأفقي. في مخطط شريطي أفقي يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). يطبق تباعد علامات الفواصل أيضًا على محور سلاسل في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لضبط المقياس الرقمي لمحور القيمة. على محور قيمة، يحدد [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) فرق القيم: على سبيل المثال، وحدة رئيسية `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` يعد مواضع الفئات بغض النظر عن قيم البيانات. تستخدم مخططات التشتت والفقاعات محاور قيمة بدلاً من محور فئة نصية. لمحور تاريخ، استخدم وحدات زمنية رئيسية ومقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال البيانات الافتراضية للمخطط بأربع قيم سنوية. تُحفظ التواريخ كأرقام مسلسل OLE Automation في ورقة العمل الأولى (الفهرس `0`). استخدم [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) لاختيار محور تاريخ، عطل تنسيق المصدر المرتبط عبر [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/)، وعين `yyyy` عبر [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) لتظهر تسميات الفئة سنوات بأربعة أعداد مستقلة عن تنسيق الخلية.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **تحديد زاوية الدوران لعنوان محور المخطط**

فعّل عنوان المحور الرأسي عبر [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/)، زود النص العنواني، واستخدم [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ هذا المثال مخطط عموديًّا مع دوران عنوان محور القيمة بمقدار 90 درجة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **تعيين موضع المحور على محور الفئة أو القيمة**

استخدم [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) للتحكم فيما إذا كان محور القيمة يلتقِي بمحور الفئة بين الفئات أو عند علامات الفئات. تنطبق هذه الخاصية على محاور الفئة. المثال يضبطها على `true` على محور الفئة الأفقي لمخطط عمود ويحفظ النتيجة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **تعيين وحدة العرض على محور القيمة في المخطط**

استخدم [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) لتقليص تسميات محور القيمة دون تغيير البيانات الأساسية. عند ضبط [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) إلى `Millions`, تُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخطط عمود ويطبق وحدة العرض بالملايين على محوره الرأسي.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **تهيئة محور القيمة اللوغاريتمي**

محور قيمة لوغاريتمي مفيد عندما تتراوح القيم الموجبة عبر عدة أوامر من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا عبر خمس فترات. على مقياس خطي، تظهر القيم الصغيرة متقاربة قرب الصفر. يسهّل المقياس اللوغاريتمي مقارنة النمو النسبي: تمثل المسافات المتساوية نسبًا متساوية وليس فروقًا متساوية.

استدعِ [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) مع `true` على محور القيمة واستخدم [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) لاختيار الأساس. يغيّر ذلك طريقة عرض القيم الحالية؛ لا يغير البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُطابقة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والأساس**

للخط أو مخطط العمود، يكون محور القيمة هو [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). للمخطط الشريطي الأفقي، يكون هو [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). للمخططات التشتتية والفقاعية يتوفر محوران للقيمة، لذا اختر المحور الأفقي للقيم X، والمحور الرأسي للقيم Y، أو كليهما. لا تطبق التحجيم اللوغاريتمي على محور فئة.

الأساس اللوغاريتمي الافتراضي هو `10`. للمخططات PPTX يمكن اختيار أساس بين `2` و`1000` شاملًا؛ الأسس الكسرية مثل `2.5` مدعومة أيضًا. مع الأساس `10`، تكون القوى المتتالية مثل 10، 100، 1,000، و10,000 متساوية التباعد.

### **قارن بين التحجيم الخطي واللوغاريتمي**

المثال المستقل التالي ينشئ مخطط خط مع عدد الطلبات الخمسة في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بالأساس 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// احتفظ بالشريحة الأولى خطية وغيّر فقط مقياس محور القيم في النسخة.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**التحجيم الخطي (الشريحة 1):** تمثل المسافات الرأسية المتساوية فروقًا متساوية في عدد الطلبات. تهيمن القيمة الأكبر على المخطط، ما يجعل القيم الأصغر صعوبة في التمييز.

![مخطط خط في PowerPoint يظهر خمس عدد طلبات على محور قيمة خطي](value-axis-linear.png)

**التحجيم اللوغاريتمي (الشريحة 2):** تمثل المسافات الرأسية المتساوية نسبًا متساوية. كل فترة لديها عشرة أضعاف عدد الطلبات من السابقة، لذا تشكل النقاط خطًا مستقيمًا صاعدًا على مقياس الأساس 10. لا تزال تسميات المحور تظهر عدد الطلبات الأصلي.

![نفس خمس عدد طلبات في PowerPoint على محور قيمة لوغاريتمي بالأساس 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسلبية**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة فقط. تحقّق من البيانات قبل تفعيله. إذا كانت القيم الصفرية أو السلبية ذات معنى، احفظ المقياس الخطي أو اعرضها منفصلًا. إذا كان استبعاد تلك القيم مناسبًا للتحليل، ففسِّر السبب. لا تستبدلها صمتًا بأرقام موجبة صغيرة، لأن ذلك يغيّر معنى البيانات. أي حد أدنى أو أقصى يدوياً لمحور لوغاريتمي يجب أن يكون إيجابيًا أيضًا.

## **الأسئلة الشائعة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحاور)؟**

استخدم [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساسي مناسب.

**كيف يمكنني تموضع تسميات العلامات بالنسبة للمحور؟**

استخدم [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) مع قيمة من [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, أو `None`. للتحكم في علامات الفواصل نفسها، استخدم [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) أو [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); هذه مستقلة عن تموضع التسميات.