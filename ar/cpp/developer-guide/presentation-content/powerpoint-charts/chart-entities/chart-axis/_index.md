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
- العرض التقديمي
- C++
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides لـ C++ لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for C++. تغطي القيم المحسوبة للمحاور، وتبديل صفوف وأعمدة المخطط، وإمكانية رؤية المحاور، وفواصل تسميات الفئات وعلامات الفواصل، وفئات التاريخ وتنسيقها، وتدوير العنوان، ووضع المحور، ووحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم القصوى على المحور الرأسي في المخططات**

إنشاء [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وإضافة مخطط مساحي ببيانات افتراضية. استدعِ [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) قبل قراءة القيم المحسوبة للمحاور لضمان تحديث تخطيط المخطط.

اقرأ [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) و [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) للحصول على حدود المحور، و [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) و [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) لفواصل العلامات. توفر [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) و [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) مقاييس الوحدات الزمنية، والتي تكون ذات صلة بمحاور التاريخ. يقوم المثال بتخزين هذه القيم في متغيرات محلية ويقوم بحفظ المخطط.

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

استخدم [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) لتبديل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. يغيّر هذا طريقة تجميع البيانات؛ لا يبدل المحاور الأفقية والرأسية. يستخدم المثال [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. يقوم بحفظ مخطط يحتوي على أربع سلاسل وثلاث فئات.

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

## **تعطيل المحور الرأسي للرسوم الخطية**

استخدم [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) مع القيمة `false` على المحور الرأسي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الرأسي.

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

## **تعطيل المحور الأفقي للرسوم الخطية**

استخدم [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) مع القيمة `false` على المحور الأفقي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

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

استخدم [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) لاختيار محور فئة تاريخي أو نصي. يتطلب هذا المثال ملف `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا الفئة التي تحتوي على قيم تواريخ إكسل رقمية. يغيّر هذا المثال المحور الأفقي إلى محور تاريخ. استدعاء [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) مع القيمة `false`، و [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) مع `1`، و [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) مع الشهور يضع العلامات الرئيسية على فواصل شهرية.

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

عند وجود مخطط يحتوي على العديد من الفئات، قلل عدد تسميات المحور المرئية دون إزالة الفئات أو نقاط البيانات. استخدم [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) مع القيمة `false`، ثم استخدم [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) مع الفاصل الفئوي المطلوب. بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1, الفئة 2, الفئة 3, ... الفئة 24 |
| `2` | الفئة 1, الفئة 3, الفئة 5, ... الفئة 23 |
| `3` | الفئة 1, الفئة 4, الفئة 7, ... الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، مع إخفاء تسميتين بين كل تسمية معروضة. لا يزيل هذا الأعمدة المقابلة. يختار التباعد التلقائي فاصلًا بناءً على المساحة المتاحة؛ ولا يضمن عرض كل تسمية.

للعلامات الفاصلة تحكمات منفصلة. استخدم [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) مع القيمة `false` واستخدم [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) لتعيين فاصلها. على سبيل المثال، القيمة `1` تحافظ على وجود علامة فاصلة عند كل فاصل فئة بينما تظهر التسميات فقط كل فئة ثالثة. استخدم [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) بنمط مرئي لتتمكن من رؤية النتيجة. إعادة ضبط أي من خاصية التباعد التلقائي إلى `true` تسمح للمخطط باختيار ذلك الفاصل مرة أخرى.

المثال التالي المستقل يخلق 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي للتسميات مع علامات فاصلة مستقلة، وإعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم أي عرض تقديمي إدخالي. يجعل نص التسمية الأفقية فرق الكثافة واضحًا.

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

// الشريحة 2: إظهار كل تسمية ثالثة، مع الحفاظ على علامة فاصلة لكل فئة.
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

**التباعد التلقائي (الشريحة 1):** في هذا العرض، يتم عرض تسمية الفئة كل ثانية وتلتف إلى سطرين. قد يختلف الناتج التلقائي وفقًا لحجم المخطط، الخطوط، وواجهة العرض.

![تباعد تسميات الفئة تلقائيًا مع جميع الأعمدة الـ24 مرئية](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** كل تسمية ثالثة تُعرض على سطر واحد، بينما تبقى العلامات الفاصلة عند كل فاصل فئة. جميع الأعمدة الـ24، بما في ذلك تلك التي لا تحتوي على تسميات، تظل مرئية بنفس القيم. تعيد الشريحة 3 الشكل التلقائي المعروض أعلاه.

![فاصل تسميات الفئة يدويًا بمقدار ثلاثة مع جميع الأعمدة الـ24 مرئية](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل بناءً على عدد الفئات لمحور الفئة النصية، مثل محور الفئة في مخطط عمودي أو خطي أو مساحي أو شريطي. في المخطط العمودي، يكون هو المحور الأفقي. في المخطط الشريطي الأفقي، يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). ينطبق تباعد علامات الفاصل أيضًا على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لتعيين مقياس رقمي لمحور القيم. في محور القيم، يحدد [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) فرق القيم: على سبيل المثال، وحدة رئيسية قيمتها `10` تنتج علامات عند 0، 10، 20، وما إلى ذلك عندما يبدأ المحور من الصفر. بينما فاصل تسميات الفئة `3` يُعد مواضع الفئات بغض النظر عن قيم البيانات. تستخدم المخططات النقطية والفقاعية محاور قيم بدلاً من محور فئة نصية. بالنسبة لمحور التاريخ، استخدم وحدات رئيسية ومقاييس زمنية كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربعة قيم سنوية. تُخزن التواريخ كأرقام تسلسلية لـ OLE Automation في ورقة العمل الأولى (الفهرس `0`). استخدم [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) لاختيار محور تاريخ، وعطل تنسيق الربط بالمصدر باستخدام [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/)، وعيّن `yyyy` باستخدام [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) لكي تعرض تسميات الفئة سنوات بأربعة أرقام بشكل مستقل عن تنسيق الخلية.

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

## **تعيين زاوية دوران لعنوان محور المخطط**

فعّل عنوان المحور الرأسي باستخدام [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/)، وزد نص العنوان، واستخدم [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) لتدوير العنوان. تُقاس الزاوية بالدرجات؛ يحفظ هذا المثال مخططًا عموديًا مع عنوان محور القيم مدورًا بزاوية 90 درجة.

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

## **تعيين موقع المحور على محور الفئة أو القيم**

استخدم [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) للتحكم فيما إذا كان محور القيم يعبر محور الفئة بين الفئات أو عند علامات الفئة. تنطبق هذه الخاصية على محاور الفئة. يضبط المثال هذا الإعداد إلى `true` على محور الفئة الأفقي في مخطط عمودي ويحفظ النتيجة.

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

## **تعيين وحدة العرض على محور قيم المخطط**

استخدم [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) لتقليص حجم التسميات على محور القيم دون تغيير البيانات الأساسية. عند تعيين [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) إلى `Millions`, يتم عرض قيمة 60,000,000 كـ 60. ينشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره الرأسي.

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

## **تكوين محور قيم لوغاريتمي**

يكون محور القيم اللوغاريتمي مفيدًا عندما تمتد القيم الموجبة عبر عدة مرات من القدر. على سبيل المثال، قد تتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا خلال خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة بالقرب من الصفر. يجعل المقياس اللوغاريتمي نموها النسبي أسهل للمقارنة: تمثل المسافات المتساوية نسبًا متساوية بدلاً من فروقًا متساوية.

استدعِ [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) مع القيمة `true` على محور القيم واستخدم [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) لاختيار القاعدة. يغيّر هذا طريقة عرض القيم الموجودة؛ لا يغير البيانات ولا يضيف خط اتجاه لوغاريتمي. يمثل خط الاتجاه علاقة مُناسبة في البيانات وهو ميزة منفصلة.

### **اختر محور القيم والقاعدة**

في مخطط خطي أو عمودي، يكون محور القيم هو [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). في مخطط شريطي أفقي، يكون هو [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). تحتوي المخططات النقطية والفقاعية على محورين للقيم، لذا اختر المحور الأفقي لقيم X، والمحور الرأسي لقيم Y، أو كليهما. لا تُطبق المقياس اللوغاريتمي على محور فئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. بالنسبة لمخططات PPTX، استخدم قاعدة تتراوح من `2` إلى `1000` بما في ذلك; وتدعم القواعد الكسرية مثل `2.5`. مع القاعدة `10`, تكون القواسم المتتالية مثل 10، 100، 1,000، و10,000 متباعدة بالتساوي.

### **قارن بين المقياس الخطّي واللوغاريتمي**

المثال التالي المستقل ينشئ مخططًا خطيًا يحتوي على خمسة حسابات طلبات في الشريحة الأولى، ثم ينسخ تلك الشريحة ويُمكّن محور قيم لوغاريتمي بالقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

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

// احتفظ بالشريحة الأولى خطية وغير مقياس محور القيم في النسخة فقط.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**المقياس الخطي (الشريحة 1):** تمثل المسافات الرأسية المتساوية فروقًا متساوية في عدد الطلبات. القيمة الأكبر تهيمن على المخطط، مما يصعب تمييز القيم الأصغر.

![مخطط خطي في PowerPoint يُظهر خمسة طلبات على محور قيم خطي](value-axis-linear.png)

**المقياس اللوغاريتمي (الشريحة 2):** تمثل المسافات الرأسية المتساوية نسبًا متساوية. كل فترة لديها عشرة أضعاف عدد الطلبات عن الفترة السابقة، لذا تشكل النقاط خطًا مستقيمًا صاعدًا على مقياس القاعدة 10. لا تزال تسميات المحور تعرض عدد الطلبات الأصلي.

![نفس الطلبات الخمسة في PowerPoint على محور قيم لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسالبة**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة فقط. تحقق من البيانات قبل تمكينه. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بمقياس خطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فوضح سبب الإزالة. لا تستبدلها صامتًا بأعداد موجبة صغيرة، لأن ذلك يغيّر معنى البيانات. يجب أن تكون أي قيمة دنيا أو عظمى معدّلة يدويًا لمحور لوغاريتمي موجبة أيضًا.

## **الأسئلة المتكررة**

**كيف أضبط القيمة التي يقطع عندها محور واحد الآخر (تقاطع المحاور)؟**  
استخدم [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) لاختيار سلوك التقاطع. لتحديد قيمة تقاطع عددية، استخدم [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). تتيح لك هذه الإعدادات نقل تقاطع المحاور إلى خط أساسي مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور؟**  
استخدم [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) مع قيمة من [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, أو `None`. للتحكم في علامات الفاصل نفسها، استخدم [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) أو [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); هذه منفصلة عن وضع التسميات.