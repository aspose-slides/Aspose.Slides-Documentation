---
title: تنسيق مخططات العروض التقديمية في C++
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/cpp/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخطط
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حدود مستديرة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides للغة C++ وارتقِ بعرض PowerPoint التقديمي باستخدام محاور مخصصة، خطوط، تنسيقات رقمية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. وتظهر كيفية تخصيص العناصر الرئيسية للمخطط مثل المحاور وخطوط الشبكة والعناوين والوسائط ومنطقة الرسم وملء الجدران لتحسين مظهر البيانات القابلة للقراءة. كما توضح كيفية تعيين خصائص الخط لنص المخطط، وتطبيق تنسيقات رقمية مسبقة على بيانات المخطط، وتمكين الزوايا المستديرة لمنطقة المخطط. معًا، تُظهر هذه الأمثلة كيفية التحكم في كل من النمط البصري وعرض البيانات للمخططات في العرض التقديمي.  
للحصول على ملء وحدود منفصلة على الفترات الصاعدة والهابطة، راجع [مثال المخطط السهمي](/slides/ar/cpp/create-chart/#create-stock-charts).

## **تنسيق كيانات المخطط**

استخدم [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) لتنسيق عناوين المخطط، والمحاور، وخطوط الشبكة، والوسائط، ومنطقة الرسم. يخلق هذا المثال مخططًا خطيًا مع علامات وبيانات افتراضية، ثم يطبق أنماط نص وخط منفصلة على محوري القيم والفئات. يتم تحديد أحجام الخطوط وعروض الخطوط بالنقاط؛ وتُدوّر تسميات الفئات بزاوية 45 درجة.  
يستخدم محور القيم الدالة [get_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_numberformat/) بشكل مستقل عن خلايا المصدر. يمتد مقياسه من -2 إلى 15، مع فواصل رئيسية تبلغ 2 وفواصل فرعية 0.5. يدمج المثال أيضًا تنسيق النسبة المئوية مع الدالة [get_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_displayunit/) المضبوطة على الآلاف، لذا يجب تعديل هذه الإعدادات وفقًا لمعنى وحجم بياناتك. يبقى الوسيط خارج منطقة الرسم لأن الدالة [get_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegend/get_overlay/) معطلة. تم تكوين ملء الجدار الخلفي والأرضية من خلال [get_BackWall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) و[get_Floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/)، لكن هذه الأسطح لا تظهر إلا في المخططات ثلاثية الأبعاد.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <drawing/color.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortion.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/DisplayUnitType.h>
#include <DOM/Chart/TickLabelPositionType.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IChartPlotArea.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"");
auto chartTitle = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
chartTitle->set_Text(u"Sample Chart");
chartTitle->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
chartTitle->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
chartTitle->get_PortionFormat()->set_FontHeight(20);
chartTitle->get_PortionFormat()->set_FontBold(NullableBool::True);
chartTitle->get_PortionFormat()->set_FontItalic(NullableBool::True);

chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->set_Width(5);
chart->get_Axes()->get_VerticalAxis()->get_MajorGridLinesFormat()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
chart->get_Axes()->get_VerticalAxis()->get_MinorGridLinesFormat()->get_Line()->set_Width(3);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Thousands);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.0%");

chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinorUnit(false);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);

chart->get_Axes()->get_VerticalAxis()->set_MaxValue(15.0f);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-2.0f);
chart->get_Axes()->get_VerticalAxis()->set_MinorUnit(0.5f);
chart->get_Axes()->get_VerticalAxis()->set_MajorUnit(2.0f);

auto valueAxisText = chart->get_Axes()->get_VerticalAxis()->get_TextFormat()->get_PortionFormat();
valueAxisText->set_FontBold(NullableBool::True);
valueAxisText->set_FontHeight(16);
valueAxisText->set_FontItalic(NullableBool::True);
valueAxisText->get_FillFormat()->set_FillType(FillType::Solid);
valueAxisText->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkGreen());
auto valueAxisFont = System::MakeObject<FontData>(u"Times New Roman");
valueAxisText->set_LatinFont(valueAxisFont);

chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"");
auto valueAxisTitle = chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
valueAxisTitle->set_Text(u"Primary Axis");
valueAxisTitle->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
valueAxisTitle->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
valueAxisTitle->get_PortionFormat()->set_FontHeight(20);
valueAxisTitle->get_PortionFormat()->set_FontBold(NullableBool::True);
valueAxisTitle->get_PortionFormat()->set_FontItalic(NullableBool::True);

chart->get_Axes()->get_HorizontalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_HorizontalAxis()->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
chart->get_Axes()->get_HorizontalAxis()->get_MajorGridLinesFormat()->get_Line()->set_Width(5);

chart->get_Axes()->get_HorizontalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_Axes()->get_HorizontalAxis()->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
chart->get_Axes()->get_HorizontalAxis()->get_MinorGridLinesFormat()->get_Line()->set_Width(3);

auto categoryAxisText = chart->get_Axes()->get_HorizontalAxis()->get_TextFormat()->get_PortionFormat();
categoryAxisText->set_FontBold(NullableBool::True);
categoryAxisText->set_FontHeight(16);
categoryAxisText->set_FontItalic(NullableBool::True);
categoryAxisText->get_FillFormat()->set_FillType(FillType::Solid);
categoryAxisText->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
auto categoryAxisFont = System::MakeObject<FontData>(u"Arial");
categoryAxisText->set_LatinFont(categoryAxisFont);

chart->get_Axes()->get_HorizontalAxis()->set_HasTitle(true);
chart->get_Axes()->get_HorizontalAxis()->get_Title()->AddTextFrameForOverriding(u"");

auto categoryAxisTitle = chart->get_Axes()->get_HorizontalAxis()->get_Title()->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
categoryAxisTitle->set_Text(u"Sample Category");
categoryAxisTitle->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
categoryAxisTitle->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
categoryAxisTitle->get_PortionFormat()->set_FontHeight(20);
categoryAxisTitle->get_PortionFormat()->set_FontBold(NullableBool::True);
categoryAxisTitle->get_PortionFormat()->set_FontItalic(NullableBool::True);

chart->get_Axes()->get_HorizontalAxis()->set_TickLabelPosition(TickLabelPositionType::Low);
chart->get_Axes()->get_HorizontalAxis()->set_TickLabelRotationAngle(45);

auto legendText = chart->get_Legend()->get_TextFormat()->get_PortionFormat();
legendText->set_FontBold(NullableBool::True);
legendText->set_FontHeight(16);
legendText->set_FontItalic(NullableBool::True);
legendText->get_FillFormat()->set_FillType(FillType::Solid);
legendText->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkRed());

chart->get_Legend()->set_Overlay(false);

chart->get_BackWall()->set_Thickness(1);
chart->get_BackWall()->get_Format()->get_Fill()->set_FillType(FillType::Solid);
chart->get_BackWall()->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Orange());

chart->get_Floor()->get_Format()->get_Fill()->set_FillType(FillType::Solid);
chart->get_Floor()->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

chart->get_PlotArea()->get_Format()->get_Fill()->set_FillType(FillType::Solid);
chart->get_PlotArea()->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_LightCyan());

presentation->Save(u"FormattedChart_out.pptx", SaveFormat::Pptx);
```

## **تعيين خصائص الخط للمخطط**

عيّن حجم الخط الافتراضي لنص المخطط عبر [Chart::get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_textformat/). ينشئ المثال مخطط أعمدة مجمع بحجم خط 20 نقطة ويفعل تسميات القيم للسلسلة الأولى عبر [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/). يمكن لعناصر النص التي لها إعدادات خط صريحة خاصة بها تجاوز الإعداد الافتراضي للمخطط.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
chart->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_ChartData()->get_Series()->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"FontPropertiesForChart.pptx", SaveFormat::Pptx);
```

## **إعادة استخدام تنسيق إطار النص لوسائط المخطط**

لمطابقة الوسيط مع عنوان الشريحة، عيّن الخط في تنسيق الجزء الافتراضي للفقرة الأولى عبر [get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/). استخدم [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iformattedtextcontainer/get_textformat/) للوصول إلى تنسيق نص الوسيط، ثم استدعِ [CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyfrom/) مع إطار النص الخاص بالعنوان. يقوم ذلك بنسخ إعدادات إطار النص، وتنسيق الفقرة الأولى، وخصائص الخط الافتراضية لتلك الفقرة. يبقى التنسيق المطبق مباشرة على أجزاء فردية أو على فقرات لاحقة محليًا إلى المصدر.  
يستخدم المثال عنوانًا بخط Calibri عريض بحجم 26 نقطة ولونه أزرق بحري كقالب. بعد تنسيق الوسيط، يستخدم [CopyTo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyto/) لتطبيق التنسيق نفسه على تسمية توضيحية منفصلة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ShapeType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/StyleType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/LegendPositionType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto heading = shapes->AddAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
auto sourceTextFrame = heading->AddTextFrame(u"Quarterly sales");
auto font = sourceTextFrame->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
font->set_LatinFont(MakeObject<FontData>(u"Calibri"));
font->set_FontHeight(26);
font->set_FontBold(NullableBool::True);
font->get_FillFormat()->set_FillType(FillType::Solid);
font->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::FromArgb(32, 64, 96));

auto chart = shapes->AddChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
chart->set_Style(StyleType::Style3);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Retail"));
workbook->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Online"));
workbook->GetCell(0, 0, 3, ObjectExt::Box<String>(u"Wholesale"));
for (auto quarter = 1; quarter <= 4; ++quarter)
{
    auto label = String::Format(u"Q{0}", quarter);
    workbook->GetCell(0, quarter, 0, ObjectExt::Box<String>(label));
}

chart->set_HasLegend(true);
auto legend = chart->get_Legend();
legend->set_Position(LegendPositionType::Bottom);
auto legendTextFormat = legend->get_TextFormat();
legendTextFormat->CopyFrom(sourceTextFrame);

auto caption = shapes->AddAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
auto captionTextFrame = caption->AddTextFrame(u"Sales in millions of dollars");
legendTextFormat->CopyTo(captionTextFrame);

presentation->Save(u"legend-formatting.pptx", SaveFormat::Pptx);
```

في العرض التقديمي المحفوظ، يتطابق الوسيط والتسمية التوضيحية مع العنوان من حيث الحجم والسمك واللون. لا يزال الوسيط يعرض أسماء السلاسل، وتحتفظ التسمية التوضيحية بنصها الخاص. إذا كان هناك جزء في التسمية التوضيحية يمتلك حجم خط صريحًا بالفعل، فإن ذلك الحجم يتفوق على حجم الفقرة المنسوخ الافتراضي.

| قبل النسخ | بعد النسخ |
| --- | --- |
| ![مخطط مبيعات ربع السنوي مع تسميات وسائط سوداء عادية وتسمية توضيحية سوداء](legend-formatting-before.png) | ![نفس المخطط مع تسميات وسائط زرقاء داكنة أكبر وعريضة وتسمية توضيحية مطابقة](legend-formatting.png) |

## **تعيين التنسيق الرقمي**

استخدم [IChartDataCell::set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) لتطبيق تنسيق رقمي مدمج على خلايا دفتر عمل المخطط. ينشئ هذا المثال مخطط أعمدة مجمع ببيانات افتراضية مدعومة بالخلايا ويطبق فهرس التنسيق 10 (`0.00%`) على كل خلية قيمة للسلسلة. يغيّر ذلك طريقة عرض القيم في دفتر العمل دون تغيير الأرقام الأساسية؛ على سبيل المثال، يتم عرض 0.25 كـ 25.00٪. يمكن تكوين تنسيقات المحور وتسمية البيانات بشكل منفصل.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IChartDataCell.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series();

for (auto chartSeries : series)
{
    for (auto dataPoint : chartSeries->get_DataPoints())
    {
        dataPoint->get_Value()->get_AsCell()->set_PresetNumberFormat(10); // 0.00%
    }
}

presentation->Save(u"PresetNumberFormat_out.pptx", SaveFormat::Pptx);
```

القائمة التالية تعرض فهارس تنسيقات الأرقام المدمجة مع صيغ Excel تمثيلية للغة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق الدقيقة وعرضها حسب التطبيق واللغة، خاصةً للعملات والتواريخ. بعض صيغ Excel تختلف أيضًا عن الإعدادات الافتراضية في معيار OOXML، كما هو موضح في [ملاحظات تنفيذ تنسيق الأرقام من Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| الفهرس | التنسيق |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تعيين حدود مستديرة لمنطقة المخطط**

فعّل [IChart::set_HasRoundedCorners](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasroundedcorners/) لتقويس زوايا منطقة المخطط. ينشئ المثال مخطط أعمدة مجمع ويستخدم [get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) لمنح حدوده لونًا رماديًا صلبًا ونمط خط واحد قبل حفظ العرض التقديمي.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/IPortionFormat.h>
#include <drawing/color.h>
#include <DOM/FillType.h>
#include <DOM/LineStyle.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
chart->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
chart->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
chart->get_LineFormat()->set_Style(LineStyle::Single);
chart->set_HasRoundedCorners(true);

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **تحرير توضيحات المخطط الحالية**

يمكن أن يحتوي المخطط على أشكال مخصصة، مثل توضيح نصي يشرح حالة التقرير. يمكن الوصول إلى هذه الأشكال عبر [IChart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_usershapes/)، المذكورة أيضًا تحت [Chart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_usershapes/) في مرجع API للمخطط. تحتوي مجموعة [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) الخاصة به على الأشكال المملوكة للمخطط.  
صندوق النص العادي الموضوع فوق المخطط ينتمي إلى الشريحة، حتى وإن بدا وكأنه جزء من المخطط. يـُـظهر التكرار عبر [Slide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) المخطط والأشكال العادية للشريحة، لكنه لا يُدرج الأشكال الفردية داخل المخطط. عناوين المخطط وتسمية البيانات هي عناصر مخطط منفصلة، ليست توضيحات مخصصة في هذه المجموعة.  
حمّل [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل عمل التطبيق. يحتوي الشريحة الأولى على مخطط مع توضيح غير مجمع نصه "Preliminary results"، وخط مملوك للمخطط، وصندوق نص عادي للشريحة نصه "Slide overlay". يجد المثال المخطط الأول على تلك الشريحة ويغيّر التوضيح إلى "Final results" عندما يكون التقرير جاهزًا للنشر. يتحقق من وجود مجموعة فارغة ولا يحرّر سوى [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) الذي يحتوي على [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) غير فارغ والنص المتوقع.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <DOM/IGroupShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"chart-annotations.pptx");
auto slide = presentation->get_Slide(0);

System::SharedPtr<IChart> chart;
for (auto shape : slide->get_Shapes())
{
    auto candidate = System::DynamicCast<IChart>(shape);
    if (candidate != nullptr)
    {
        chart = candidate;
        break;
    }
}

if (chart == nullptr || chart->get_UserShapes()->get_Shapes()->get_Count() == 0)
{
    System::Console::WriteLine(u"No chart or chart-owned shapes found.");
    return;
}

auto updated = false;
for (auto shape : chart->get_UserShapes()->get_Shapes())
{
    auto annotation = System::DynamicCast<IAutoShape>(shape);
    if (annotation != nullptr &&
        annotation->get_TextFrame() != nullptr &&
        annotation->get_TextFrame()->get_Text() == u"Preliminary results")
    {
        annotation->get_TextFrame()->set_Text(u"Final results");
        updated = true;
        break;
    }
}

if (updated)
{
    presentation->Save(u"chart-annotations-updated.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"No matching text annotation found.");
}
```

يبقى الخط وصندوق النص على الشريحة دون تغيير. تُظهر الصور التالية الإدخال والنتيجة المحفوظة التي أُعيد فتحها:

| قبل التعديل | بعد التعديل |
| --- | --- |
| ![توضيح المخطط يقرأ Preliminary results](chart-annotations-before.png) | ![توضيح المخطط يقرأ Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
يفحص المثال فقط الأشكال المملوكة للمخطط على المستوى الأعلى. إذا كان التوضيح داخل [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/)، فافحص مجموعة [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) الخاصة بها أيضًا. كرّر ذلك بصورة متكررة للمجموعات المتداخلة، مع تطبيق نفس فحوصات النص على الأشكال التابعة لها. المجموعة نفسها عبارة عن حاوية؛ لا تعاملها كصندوق نص.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المساحات مع الحفاظ على الحد غير شفاف؟**  
نعم. يتم تكوين شفافية التعبئة والحد بشكل منفصل. هذا مفيد لتحسين قابلية القراءة للشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**  
قلّل حجم الخط، أو عطل مكونات التسمية غير الضرورية (مثل الفئات)، أو اضبط موضع التسمية، أو اعرض التسميات للنقاط المحددة فقط إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + الوسيط".

**هل يمكنني تطبيق تعبئات تدرجية أو بنمط على السلاسل؟**  
نعم. تدعم السلاسل تعبئات صلبة وتدرجية ونمطية. عمليًا، استخدم التدرجات باعتدال وتجنب الجمع بينهما بما يقلل التباين مع الشبكة والنص.