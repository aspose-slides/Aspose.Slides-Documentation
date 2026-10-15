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
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides للـ C++ لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والمرئيات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides للـ C++. تغطي القيم المحسوبة للمحاور، تبديل صفوف وأعمدة المخطط، إظهار المحور، فواصل تسميات الفئات وعلامات الفواصل، الفئات التاريخية وتنسيقها، تدوير العنوان، تموضع المحور، وحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم القصوى على المحور الرأسي في المخططات**

أنشئ [العرض](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وأضف مخطط منطقة ببيانات افتراضية. استدعِ [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحاور لضمان أن تخطيط المخطط محدث.

اقرأ [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) و[get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) للحصول على حدود المحور، و[get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) و[get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) لفواصل العلامات. يوفر [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) و[get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) مقاييس زمنية ذات صلة بالمحاور التاريخية. المثال يخزن هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغيّر كيفية تجميع البيانات؛ لا يبدل المحاور الأفقية والرأسية. المثال يستخدم [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا بأربع سلاسل وثلاث فئات.

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

استخدم [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) لعكس محور الفئة أو القيمة. على سبيل المثال، يمكن لمخطط شريطي أفقي إظهار مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ لا يرتّب أو يعيد ترتيب بيانات المصنف. بالمقابل، [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) يبدّل أدوار السلاسل والفئات.

المثال التالي ينشئ مخطط شريطي أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرضاً تقديميًا بثلاث شرائح: الترتيب الطبيعي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم نفس مجموعة البيانات، ويتم عكس محور واحد فقط في كل نسخة.

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
// الإبقاء على محور القيمة الأفقي في الأسفل.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// الشريحة 3: عكس المقياس الرقمي الأفقي فقط.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

عكس المحور يمكن أن ينقل المحور المتقاطع إلى الجانب المقابل من المخطط. يتحكم [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) في مكان عبور المحور الآخر مع المحور المُكوَّن. في الشريحة 2، ضبطه على `Maximum` على محور الفئة المعكوس يترك محور القيمة الأفقي في الأسفل. لتحديد نقطة عبور معينة، استخدم [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). تفقد إعدادات العبور عند تغيير الاتجاه، خاصة إذا كان للمخطط نقطة عبور مخصصة. استدعِ `set_IsPlotOrderReversed` مع `false` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات العبور مستقلة.

| الترتيب الطبيعي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريطي أفقي بترتيب الفئة والمحور القيمي الطبيعي](axis-order-normal.png) | ![مخطط شريطي أفقي مع عرض الفئات من أعلى إلى أسفل](axis-order-categories-reversed.png) | ![مخطط شريطي أفقي مع محور قيم معكوس والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تمتد من الأعلى إلى الأسفل. القيم وترتيب صفوف المصنف لا يتغير. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. محور الفئة يعبر عند الصفر على اليمين. |

## **إلغاء إظهار المحور الرأسي لمخططات الخط**

استخدم [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) مع `false` على المحور الرأسي لإخفائه. المثال ينشئ مخطط خط ببيانات افتراضية ويحفظه مع إخفاء المحور الرأسي.

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

## **إلغاء إظهار المحور الأفقي لمخططات الخط**

استخدم [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) مع `false` على المحور الأفقي لإخفائه. المثال ينشئ مخطط خط ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

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

## **تغيير محور الفئة**

استخدم [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال ملف `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا فئة تحتوي على قيم تاريخية عددية من Excel. يغيّر المحور الأفقي إلى محور تاريخي. استدعِ [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) مع `false`، ثم [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) مع `1`، و[set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) مع الشهور لتضع العلامات الرئيسية بفواصل شهرية.

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

## **التحكم في فواصل تسميات محور الفئة**

عند وجود الكثير من الفئات في المخطط، قلل عدد التسميات المرئية للمحور دون إزالة الفئات أو نقاط البيانات. استخدم [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) مع `false`، ثم [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) مع الفاصل المطلوب بين الفئات. بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1, الفئة 2, الفئة 3, ... الفئة 24 |
| `2` | الفئة 1, الفئة 3, الفئة 5, ... الفئة 23 |
| `3` | الفئة 1, الفئة 4, الفئة 7, ... الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، تاركًا تسمينتين مخفيتين بين كل تسمية مرئية. لا يزال يحذف الأعمدة المقابلة. يختار التباعد التلقائي الفاصل بناءً على المساحة المتاحة؛ لا يضمن عرض كل تسمية.

علامات الفواصل لها تحكم منفصل. استخدم [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) مع `false` ثم [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) لتعيين فاصلها. على سبيل المثال، `1` يبقي علامة فاصل عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استخدم [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) بنمط مرئي لتتمكن من رؤية النتيجة. إعادة تعيين أي من خصائص التباعد التلقائي إلى `true` يسمح للمخطط باختيار الفاصل مرة أخرى.

المثال المستقل التالي ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي لتسمية الفئات مع علامات فواصل مستقلة، واستعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم عرض تقديمي إدخال. يوضح نص التسمية الأفقي الفرق في الكثافة بوضوح.

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

// الشريحة 3: السماح للمخطط باختيار كلا الفاصلين مرة أخرى.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**تباعد تلقائي (الشريحة 1):** في هذا العرض، تُظهر كل تسمية فئة ثانية وتلتف إلى سطرين. قد تختلف النتيجة التلقائية حسب حجم المخطط والخطوط ومنفذ العرض.

![تباعد تلقائي لتسمية الفئات مع جميع الأعمدة الـ24 مرئية](category-axis-automatic.png)

**تباعد يدوي (الشريحة 2):** تُظهر كل تسمية فئة ثالثة في سطر واحد، بينما تظل علامات الفواصل عند كل فاصل فئة. جميع الأعمدة الـ24، بما فيها التي لا تحمل تسميات، تظل مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي المعروض أعلاه.

![فاصل يدوي لتسمية الفئات بثلاثة مع جميع الأعمدة الـ24 مرئية](category-axis-manual.png)

### **اختر المحور والـفاصل الصحيح**

استخدم هذا الفاصل لعدد الفئات لمحور فئة نصية، مثل محور الفئة في مخطط عمود، خط، منطقة، أو شريطي. في مخطط العمود، يكون هو المحور الأفقي. في مخطط شريطي أفقي، يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). ينطبق تباعد علامات الفواصل أيضًا على محور سلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئات لضبط المقياس الرقمي لمحور القيمة. على محور القيمة، يحدد [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) فرق القيم: على سبيل المثال، وحدة رئيسية بقيمة `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسميات الفئات `3` يحسب مواضع الفئات بغض النظر عن قيمها. تستخدم مخططات التبعثر والفقاعات محاور قيم بدلًا من محور فئة نصية. لمحور تاريخي، استخدم وحدات زمنية رئيسية ومقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربع قيم سنوية. تُخزن التواريخ كأرقام سلسلة OLE Automation في ورقة العمل الأولى (الفهرس `0`). استخدم [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) لاختيار محور تاريخي، عطل تنسيق المصدر المرتبط باستخدام [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/)، وعيّن `yyyy` باستخدام [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) ليظهر تسميات الفئة بأربع سنوات رقمية مستقلة عن تنسيق الخلية.

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

## **تعيين زاوية تدوير لعنوان محور المخطط**

فعّل عنوان المحور الرأسي باستخدام [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/)، قدم نص العنوان، واستخدم [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ هذا المثال مخطط عمود بعنوان محور القيمة مدوَّرًا بـ 90 درجة.

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

استخدم [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) للتحكم فيما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفئة. هذه الخاصية تنطبق على محاور الفئة. يضبط المثال الخاصية إلى `true` على محور الفئة الأفقي في مخطط عمود ويحفظ النتيجة.

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

## **تعيين وحدة العرض على محور قيمة المخطط**

استخدم [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) لتكبير التسميات على محور القيمة دون تغيير البيانات الأساسية. مع ضبط [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) إلى `Millions`، يُعرض القيمة 60 000 000 كـ 60. المثال ينشئ مخطط عمود ويطبّق وحدة العرض بالملايين على محوره الرأسي.

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

## **تهيئة محور قيمة لوغاريتمي**

محور قيمة لوغاريتمي يكون مفيدًا عندما تمتد القيم الموجبة عبر عدة أوامر من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1 000، 10 000، و100 000 طلبًا خلال خمس فترات. على مقياس خطي، تُظهر القيم الصغيرة قريبًا من الصفر. المقياس اللوغاريتمي يجعل النمو النسبي أسهل للمقارنة: المسافات المتساوية تمثل نسبًا متساوية بدلاً من فرقًا متساوية.

استدعِ [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) مع `true` على محور القيمة واستخدم [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) لاختيار القاعدة. يغيّر هذا كيفية عرض القيم الحالية؛ لا يغيّر البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُناسبة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والأساس**

لمخطط خط أو عمود، يكون محور القيمة هو [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). لمخطط شريطي أفقي، يكون هو [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). مخططات التبعثر والفقاعات لها محوران للقيمة، لذا اختر المحور الأفقي لقيم X، والمحور الرأسي لقيم Y، أو كليهما. لا تُطبق المقياس اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. لمخططات PPTX، يمكن استخدام قاعدة من `2` إلى `1000` شاملة؛ القواعد الجزئية مثل `2.5` مدعومة أيضًا. مع القاعدة `10`، تُبعد القوى المتتالية مثل 10، 100، 1 000، و10 000 بمسافات متساوية.

### **قارن بين القياس الخطي واللوغاريتمي**

المثال المستقل التالي ينشئ مخطط خط بالعدّ الخمسي للطلبات في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعّل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

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

// احتفظ بالشريحة الأولى خطيًا وغير مقياس محور القيمة في النسخة فقط.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**مقياس خطي (الشريحة 1):** المسافات الرأسية المتساوية تمثل اختلافات عددية متساوية في عدد الطلبات. القيمة الأكبر تهيمن على المخطط، مما يصعّب تمييز القيم الأصغر.

![مخطط خط في PowerPoint يظهر خمس عدادات طلب على محور قيمة خطي](value-axis-linear.png)

**مقياس لوغاريتمي (الشريحة 2):** المسافات الرأسية المتساوية تمثل نسبًا متساوية. كل فترة تحتوي على عشر مرات الطلبات مقارنةً بالفترة السابقة، لذا تشكل النقاط خطًا مستقيمًا صاعدًا على مقياس قاعدة 10. لا تزال تسميات المحور تعرض عدد الطلبات الأصلي.

![نفس الخمس عدادات طلب في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة الصفر والقيم السالبة**

المقياس اللوغاريتمي يمكنه عرض قيم موجبة صريحة فقط. تحقق من البيانات قبل تفعيله. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بمقياس خطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فاشرح السبب. لا تستبدلها صمتًا بأرقام صغيرة موجبة، لأن ذلك يغيّر معنى البيانات. أي حد أدنى أو أقصى يُحدد يدويًا لمحور لوغاريتمي يجب أن يكون إيجابيًا أيضًا.

## **الأسئلة المتكررة**

**كيف يمكنني تعيين القيمة التي يعبر عندها محور مع الآخر (تقاطع المحور)؟**

استخدم [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات الفواصل بالنسبة إلى المحور؟**

استخدم [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) مع قيمة من [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات الفواصل نفسها، استخدم [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) أو [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); هذه الخيارات منفصلة عن تموضع التسميات.