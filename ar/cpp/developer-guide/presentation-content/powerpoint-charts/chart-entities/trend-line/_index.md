---
title: إضافة خطوط الاتجاه إلى مخططات العروض التقديمية في C++
linktitle: خط الاتجاه
type: docs
url: /ar/cpp/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسّي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه المتوسط المتحرك
- خط الاتجاه متعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "أضف وقم بتخصيص خطوط الاتجاه بسرعة في مخططات PowerPoint باستخدام Aspose.Slides للغة C++ — دليل عملي لجذب جمهورك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إضافة خطوط الاتجاه إلى مخططات العروض التقديمية باستخدام Aspose.Slides. وتظهر كيفية إنشاء مخطط، وإضافة خطوط الاتجاه إلى سلاسل المخطط، والعمل مع عدة أنواع من خطوط الاتجاه، بما في ذلك الأسية، والخطية، واللوغاريتمية، والمتوسط المتحرك، والمتعددة الحدود، والقوة.

كما يصف كيفية إضافة خط مخصص إلى مخطط عن طريق إدراج شكل خط، ويتضمن قسم أسئلة شائعة قصيرة حول قيم إسقاط خط الاتجاه إلى الأمام وإلى الخلف وما إذا كانت خطوط الاتجاه تُحفظ أثناء التصدير إلى PDF أو SVG وعند تصيير المخططات كصور.

## **إضافة خط اتجاه**

استخدم [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) لإضافة خط اتجاه إلى سلسلة مخطط، مع اختيار نوعه باستخدام [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). مثال يخلق مخطط أعمدة متكتل ببيانات افتراضية ويضيف خطي اتجاه إلى كل من سلاسل الثلاثة.

يخفي خط الاتجاه الأسي معادلته وقيمة R‑squared من خلال [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) و[ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/)، بينما يكون خط الاتجاه الخطي أحمر. يستخدم خط الاتجاه اللوغاريتمي [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) لإنشاء تسمية مخصصة. يستخدم المتوسط المتحرك [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) لتوسيط ثلاث نقاط بيانات و[ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) لتعيين اسم مخصص.

يستخدم خط الاتجاه المتعدد الحدود [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) لتعيين درجته إلى ثلاثة ويمدد فئة واحدة إلى الأمام عبر [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). يمتد خط الاتجاه القوي فئة واحدة إلى الخلف عبر [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **تعيين تقاطع خط الاتجاه**

استخدم [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) لتثبيت قيمة Y لخط الاتجاه عند X = 0. هذا الإعداد مدعوم لخطوط الاتجاه الخطية، والأسية، والمتعددة الحدود.

على سبيل المثال، قد يحتاج نموذج تكلفة الإنتاج إلى البدء بتكاليف ثابتة معروفة مقدارها 100، حتى عندما تشير القياسات عند أحجام إنتاج غير صفرية إلى قاعدة مختلفة. بالنسبة لخط الاتجاه الخطي، فإن تثبيت التقاطع يحد من المعادلة `y = ax + b` إلى `b = 100`؛ ويتم ملاءمة المنحدر للبيانات تحت هذا القيد. هذا لا يُحرك ببساطة خطًا مُناسبًا مسبقًا. إعدادات تقاطع المحاور تتحكم في موضع التقاء محاور المخطط، وليس في معاملات خط الاتجاه المُناسب.

المثال التالي ينشئ مخططًا مبعثرًا (XY) بأحجام إنتاج من 1 إلى 4 وتكاليف 170، 200، 230، و260. يحفظ المخطط بالتقاطع التلقائي الافتراضي، ثم يضبط التقاطع إلى 100، ويحفظ ملف PPTX ثاني. الملفان يختلفان فقط في إعداد التقاطع. يعرض خط الاتجاه معادلته ويمتد إلى X = 0.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

مع الحساب التلقائي، تنتج هذه البيانات المعادلة `y = 30x + 140`. ضبط التقاطع إلى 100 ينتج تقريبًا `y = 43.33x + 100`: القيمة المُناسبة عند الصفر تتطابق مع القاعدة المعروفة، بينما لا يمر الخط بعد الآن عبر كل نقطة بيانات.

| تقاطع تلقائي | تقاطع ثابت 100 |
| --- | --- |
| ![خط اتجاه خطي مع تقاطع محسوب تلقائيًا بقيمة 140](intercept-automatic.png) | ![خط اتجاه خطي مع تقاطع ثابت بقيمة 100](intercept-fixed.png) |

كلا الصورتين تستخدمان نفس البيانات ومقاييس المحاور. يتم إطالة خطوط الاتجاه إلى X = 0 لإظهار تقاطعاتها.

بشكل افتراضي، تحتوي الخاصية على `std::numeric_limits<double>::quiet_NaN()`, والتي تمثل تقاطعًا غير محدد بدلاً من الصفر. ثم يتم حساب التقاطع تلقائيًا من البيانات.

## **إضافة خط مخصص**

الخط المخصص هو شكل يُرسم فوق المخطط بدلاً من أن يكون خط اتجاه محسوبًا من بيانات السلسلة. يستخدم هذا المثال [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) لإضافة خط أفقي إلى الشريحة فوق المخطط. يتم تحديد موضع الخط في إحداثيات الشريحة، مقاسًا بالنقاط، لذا يبدأ عند الحافة اليسرى للمخطط ويقع في منتصف ارتفاع المخطط. عرضه يطابق عرض المخطط. التنسيق الرفعي الذي تُرجعه [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) يمنح الخط لونًا أحمر صلب.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **الأسئلة المتكررة**

**ماذا يعني 'الأمام' و'الخلف' لخط الاتجاه؟**

إنهما طولان لخط الاتجاه المُسقط إلى الأمام أو الخلف: بالنسبة لمخططات المبعثر (XY) — بوحدات المحور؛ بالنسبة للمخططات غير المبعثرة — بعدد الفئات. يُسمح بالقيم غير السالبة فقط.

**هل سيتم حفظ خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تصيير شريحة كصورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) أو [SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/) وتصدير المخططات إلى صور؛ تُحفظ خطوط الاتجاه، كجزء من المخطط، أثناء هذه العمليات. هناك طريقة أيضًا لتقوم بـ [تصدير صورة للمخطط](/slides/ar/cpp/shape-thumbnails/) نفسه.