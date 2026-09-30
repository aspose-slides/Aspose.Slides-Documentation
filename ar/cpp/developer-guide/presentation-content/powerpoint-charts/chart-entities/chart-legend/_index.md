---
title: تخصيص أساطير المخططات في العروض باستخدام C++
linktitle: أسطورة المخطط
type: docs
url: /ar/cpp/chart-legend/
keywords:
- أسطورة المخطط
- موضع الأسطورة
- حجم الخط
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "تخصيص أساطير المخططات باستخدام Aspose.Slides for C++ لتحسين عروض PowerPoint مع تنسيق أسطورة مخصص."
---
## **نظرة عامة**

توفر Aspose.Slides for C++ خيارات لتخصيص أساطير المخططات في عروض PowerPoint. توضح هذه المقالة كيفية تحديد موضع وحجم الأسطورة، وتعيين حجم الخط لجميع الأسطورة، وتنسيق مدخل أسطورة فردي، وإخفاء أو استعادة المدخلات المحددة.

تغطي الأسئلة الشائعة السلوكيات المرتبطة، بما في ذلك حجز مساحة للأسطورة، وعرض تسميات متعددة الأسطر، ووراثة التنسيق من سمة العرض.

## **موضع الأسطورة**

استخدم طرق الأسطورة [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/)، [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/)، [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/)، و[set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) لتحديد موضعها وحجمها كنسب من أبعاد المخطط.

هذا المثال ينشئ عرضًا تقديميًا ويضيف مخطط أعمدة متجمع مع بيانات افتراضية إلى الشريحة الأولى. تقسيم إزاحات الأسطورة المطلوبة وأبعادها على عرض وارتفاع المخطط يحولها إلى قيم نسبية: يتم إزاحة الأسطورة بمقدار 50 نقطة من الزاوية العلوية اليسرى للمخطط وتحديد حجمها بـ 100 × 100 نقطة.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// التعبير عن موضع الأسطورة وحجمها نسبةً إلى المخطط.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **تعيين حجم الخط للأسطورة**

استخدم [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) الخاص بالأسطورة للوصول إلى تنسيق النص واستخدم [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) لتعيين حجم الخط بالنقاط.

هذا المثال ينشئ مخططًا ببيانات افتراضية ويضبط نص الأسطورة إلى 20 نقطة. كما يوقف الحدود التلقائية للمحور العمودي ويحدد نطاقه من -5 إلى 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **تعيين حجم الخط لمدخل أسطورة فردي**

استخدم المجموعة التي تُرجعها طريقة الأسطورة [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) للوصول إلى تنسيق مدخل محدد. فهارس المدخلات تبدأ من الصفر، لذا يشير الفهرس `1` إلى المدخل الثاني.

هذا المثال ينشئ مخطط أعمدة متجمع تتضمن بياناته الافتراضية على الأقل سلسلتين. يقوم بتنسيق المدخل الثاني من الأسطورة بخط عريض ومائل ونص أزرق بحجم 20 نقطة.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **إخفاء مدخلات الأسطورة الفردية**

لإستبعاد سلسلة مساعدة من الأسطورة مع إبقاء بياناتها مرئية، استدعِ [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) بـ `true` عبر [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). هذا يخفي فقط المدخل المحدد من الأسطورة؛ لا يزيل السلسلة أو نقاط بياناتها. بالمقابل، استدعاء [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) بـ `false` يخفي الأسطورة بأكملها.

المثال أدناه ينشئ مخطط أعمدة متجمع مع عدة سلاسل باستخدام البيانات الافتراضية. يخفي مدخل الأسطورة للسلسلة الثانية (الفهرس `1`) ويحفظ العرض. ثم يستعيد المدخل باستدعاء `set_Hide` بـ `false` ويحفظ نسخة ثانية. تظل الأعمدة مرئية في كلا الملفين.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// استعادة نفس المدخل دون تغيير بيانات المخطط.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

المقارنة أدناه تُظهر نفس المخطط مع جميع المدخلات مرئية ومع إخفاء المدخل الثاني. تبقى أعمدة السلسلة الثانية دون تغيير.

![مقارنة مخطط مع جميع مدخلات الأسطورة مرئية ومع إخفاء السلسلة 2 من الأسطورة؛ جميع الأعمدة تبقى مرئية.](hide-legend-entry.png)

في مخططات الأعمدة، الأشرطة، والخطوط، تُحدد مدخلات الأسطورة السلاسل. بالنسبة لمخططات الدائرة، تُحدد المدخلات نقاط البيانات الفردية (الشرائح)، لذا استخدم [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) على الشريحة المحددة بدلاً من ذلك. تُوثق الـ API طريقة نقطة البيانات هذه لأنواع المخططات `Pie`، `Pie3D`، `ExplodedPie`، `ExplodedPie3D`، `PieOfPie`، و`BarOfPie`. لا تفترض أنها تنطبق على مخططات الدونات، التي لا تُدرج في تلك القائمة.

## **الأسئلة الشائعة**

**هل يمكنني جعل المخطط يحجز مساحة للأسطورة بدلاً من تغطيتها؟**

نعم. استدعِ [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) بـ `false` لحجز مساحة للأسطورة بدلاً من السماح لها بتغطية منطقة الرسم.

**هل يمكنني إنشاء تسميات أسطورة متعددة الأسطر؟**

نعم. يمكن أن تُلف التسميات الطويلة عندما يكون العرض المتاح غير كافٍ. يمكنك أيضًا استخدام أحرف سطر جديد في أسماء السلاسل لطلب فواصل أسطر.

**كيف أجعل الأسطورة تتبع مخطط ألوان سمة العرض؟**

اترك ألوان الأسطورة، وملئها، وخطوطها غير معرفّة بحيث يمكنها وراثة تنسيق السمة. أي تنسيق صريح سيتجاوز إعدادات السمة المقابلة.