---
title: "C++ में प्रस्तुति चार्ट फ़ॉर्मेट करें"
linktitle: "चार्ट फ़ॉर्मेटिंग"
type: docs
weight: 60
url: /hi/cpp/chart-formatting/
keywords:
- "चार्ट फॉर्मेट"
- "चार्ट फ़ॉर्मेटिंग"
- "चार्ट इकाई"
- "चार्ट गुण"
- "चार्ट सेटिंग्स"
- "चार्ट विकल्प"
- "फ़ॉन्ट गुण"
- "गोल किनारा"
- PowerPoint
- "प्रस्तुति"
- C++
- Aspose.Slides
description: "Aspose.Slides के लिए C++ में चार्ट फ़ॉर्मेटिंग सीखें और कस्टम अक्ष, फ़ॉन्ट, संख्या फ़ॉर्मेट और गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने के तरीकों को समझाता है। यह अक्ष, ग्रिड लाइन्स, शीर्षक, लेजेंड, प्लॉट एरिया और वॉल फ़िल्स जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को सुधारने का तरीका दर्शाता है।

यह भी दर्शाता है कि चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण कैसे सेट करें, चार्ट डेटा पर प्रीसेट संख्यात्मक फ़ॉर्मेट कैसे लागू करें, और चार्ट एरिया के कोने कैसे गोल करें। ये उदाहरण मिलकर दिखाते हैं कि प्रस्तुति में चार्ट के दृश्य शैली और डेटा प्रस्तुति दोनों को कैसे नियंत्रित किया जा सकता है।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**

चार्ट शीर्षक, अक्ष, ग्रिड लाइन्स, लेजेंड और प्लॉट एरिया को फ़ॉर्मेट करने के लिए [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) का उपयोग करें। यह उदाहरण मार्कर के साथ एक लाइन चार्ट बनाता है और उसके वैल्यू तथा कैटेगोरी अक्षों पर अलग-अलग टेक्स्ट और लाइन स्टाइल लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट्स में निर्दिष्ट की गई है; कैटेगोरी लेबल 45 डिग्री घुमाए गए हैं।

वैल्यू अक्ष स्रोत कोशिकाओं से स्वतंत्र रूप से [get_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_numberformat/) का उपयोग करता है। इसका स्केल -2 से 15 तक है, प्रमुख अंतराल 2 और गौण अंतराल 0.5 है। यह उदाहरण प्रतिशत फ़ॉर्मेट को [get_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_displayunit/) के साथ हजारों पर सेट करके संयोजित करता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार समायोजित करें। लेजेंड प्लॉट एरिया के बाहर रहता है क्योंकि [get_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegend/get_overlay/) निष्क्रिय है। बैक-वाल और फ़्लोर फ़िल्स [get_BackWall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) और [get_Floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) के माध्यम से कॉन्फ़िगर किए गए हैं, लेकिन ये सतहें केवल 3D चार्ट में दिखती हैं।

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

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**

[Chart::get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_textformat/) के द्वारा चार्ट टेक्स्ट के डिफ़ॉल्ट फ़ॉन्ट आकार को सेट करें। यह उदाहरण 20‑पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और पहली सीरीज़ के लिए [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) के माध्यम से वैल्यू लेबल सक्षम करता है। अपने स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट एलिमेंट्स चार्ट की डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

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

## **संख्यात्मक फ़ॉर्मेट सेट करें**

चार्ट वर्कबुक कोशिकाओं पर बिल्ट‑इन नंबर फ़ॉर्मेट लागू करने के लिए [IChartDataCell::set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) का प्रयोग करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक सीरीज़ वैल्यू सेल पर फ़ॉर्मेट इंडेक्स 10 (`0.00%`) लागू करता है। यह वर्कबुक में मानों को बदले बिना उनके प्रदर्शन को बदल देता है; उदाहरण के लिए, 0.25 को 25.00% दिखाया जाता है। अक्ष और डेटा‑लेबल फ़ॉर्मेट को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

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

निम्न तालिका इंग्लिश (United States) लोकेल के लिए प्रतिनिधि Excel फ़ॉर्मेट्स के साथ बिल्ट‑इन नंबर फ़ॉर्मेट इंडेसेस को सूचीबद्ध करती है। वास्तविक फ़ॉर्मेट स्ट्रिंग्स और उनका प्रदर्शन एप्लिकेशन और लोकेल के अनुसार बदल सकता है, विशेषकर मुद्रा और तिथियों के लिए। कुछ Excel फ़ॉर्मेट्स OOXML मानक की डिफ़ॉल्ट्स से भी अलग होते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

| सूचकांक | प्रारूप |
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

## **चार्ट एरिया के गोल किनारे सेट करें**

[ IChart::set_HasRoundedCorners](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasroundedcorners/) को सक्रिय करके चार्ट एरिया के कोनों को गोल करें। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और उसके अनुकूल को [get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) का उपयोग करके ठोस ग्रे रंग तथा सिंगल‑लाइन स्टाइल देता है, फिर प्रस्तुति को सहेजता है।

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

## **मौजूदा चार्ट एनोटेशन संपादित करें**

एक चार्ट में कस्टम शैप्स हो सकते हैं, जैसे कि रिपोर्ट की स्थिति बताने वाला टेक्स्ट एनोटेशन। इन शैप्स को [IChart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_usershapes/) के माध्यम से एक्सेस किया जा सकता है, जो [Chart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_usershapes/) के अंतर्गत भी सूचीबद्ध है। इसका [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) संग्रह चार्ट‑स्वामित्व वाले शैप्स को रखता है।

एक साधारण टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा गया है, वह स्लाइड का हिस्सा होता है, भले ही वह चार्ट का हिस्सा लग रहा हो। [Slide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) के माध्यम से इटरेट करने पर चार्ट और सामान्य स्लाइड शैप्स मिलते हैं, परंतु चार्ट के भीतर के व्यक्तिगत शैप्स की सूची नहीं मिलती। चार्ट शीर्षक और डेटा लेबल अलग‑अलग चार्ट एलिमेंट होते हैं, न कि इस संग्रह में कस्टम एनोटेशन।

[chart-annotations.pptx](chart-annotations.pptx) को डाउनलोड करके एप्लिकेशन की कार्य निर्देशिका में रखें। उसकी पहली स्लाइड में एक चार्ट है जिसमें "Preliminary results" लिखा अनग्रुप्ड एनोटेशन, एक चार्ट‑स्वामित्व वाली लाइन, और "Slide overlay" लिखा साधारण स्लाइड टेक्स्ट बॉक्स है। यह उदाहरण उस स्लाइड पर पहला चार्ट ढूँढता है और रिपोर्ट प्रकाशित होने पर एनोटेशन को "Final results" में बदल देता है। यह खाली संग्रह की जाँच करता है और केवल उस [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) को संपादित करता है जिसके पास नॉन‑नल [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) और अपेक्षित टेक्स्ट है।

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

लाइन और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहते हैं। नीचे की तस्वीरें इनपुट और सहेजे गए, फिर से खोले गए परिणाम को दिखाती हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल शीर्ष‑स्तर के चार्ट‑स्वामित्व वाले शैप्स को ही जांचता है। यदि कोई एनोटेशन एक [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/) के भीतर है, तो उस समूह की [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) संग्रह को भी जांचें। नेस्टेड समूहों के लिए इसे पुनरावर्ती रूप से दोहराएँ, और उनके चाइल्ड शैप्स पर समान टेक्स्ट जाँच लागू करें। एक समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में नहीं मानें।
{{% /alert %}}

## **FAQ**

**क्या मैं कॉलम/एरिया के लिए अर्ध‑पारदर्शी फ़िल्स सेट कर सकता हूँ जबकि बॉर्डर अपारदर्शी रहे?**

हां। फ़िल ट्रांसपरेंसी और आउटलाइन को अलग‑अलग कॉन्फ़िगर किया जाता है। यह ग्रिड और डेटा की पठनीयता को सुधारने में मददगार है।

**डेटा लेबल्स ओवरलैप होने पर मैं क्या करूँ?**

फ़ॉन्ट आकार कम करें, गैर‑आवश्यक लेबल घटकों (जैसे कैटेगरीज) को निष्क्रिय करें, लेबल की स्थिति समायोजित करें, आवश्यक होने पर केवल चयनित पॉइंट्स के लिए लेबल दिखाएँ, या फ़ॉर्मेट को "value + legend" में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल्स लागू कर सकता हूँ?**

हां। सीरीज़ सॉलिड, ग्रेडिएंट और पैटर्न फ़िल्स को सपोर्ट करती हैं। व्यावहारिक रूप से, ग्रेडिएंट का सीमित प्रयोग करें और ऐसी संयोजन से बचें जो ग्रिड और टेक्स्ट के कंट्रास्ट को कम कर दें।