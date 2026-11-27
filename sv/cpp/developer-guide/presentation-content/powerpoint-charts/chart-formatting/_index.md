---
title: Formatera presentationsdiagram i C++
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/cpp/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensnittsegenskaper
- rundade kanter
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för C++ och förbättra din PowerPoint-presentation med anpassade axlar, teckensnitt, talformat och rundade diagramkanter."
---
## **Översikt**

Denna artikel förklarar hur du formaterar diagram i PowerPoint-presentationer med hjälp av Aspose.Slides. Den visar hur du anpassar viktiga diagelement såsom axlar, rutnätslinjer, titlar, förklaringar, plotområdet och väggfyllningar för att förbättra utseendet och läsbarheten för diagramdata.

Den visar också hur du ställer in teckensnittsegenskaper för diagramtext, tillämpar fördefinierade numeriska format på diagramdata och aktiverar rundade hörn för diagramområdet. Tillsammans visar dessa exempel hur du styr både den visuella stilen och datapräsentationen av diagram i en presentation.

För separata fyllningar och konturer på stigande och fallande intervaller, se [exempel på aktiediagram](/slides/sv/cpp/create-chart/#create-stock-charts).

## **Formatera diagramobjekt**

Använd [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) för att formatera diagramtitlar, axlar, rutnätslinjer, förklaringar och plotområdet. Detta exempel skapar ett linjediagram med markörer och standarddata, och tillämpar sedan separata text- och linjestilar på dess värde- och kategoriaxlar. Typsnittsstorlekar och linjebreddar anges i punkter; kategorietiketter roteras 45 grader.

Värdeaxeln använder [get_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_numberformat/) oberoende av källcellerna. Dess skala går från -2 till 15, med huvudintervall på 2 och delintervall på 0.5. Exemplet kombinerar också procentformatering med [get_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_displayunit/) satt till tusental, så anpassa dessa inställningar efter betydelsen och storleken på dina data. Förklaringen förblir utanför plotområdet eftersom [get_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegend/get_overlay/) är inaktiverad. Bakväggs- och golvfyllningar konfigureras via [get_BackWall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) och [get_Floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/), men dessa ytor är endast synliga i 3D-diagram.

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

## **Ställ in teckensnittsegenskaper för ett diagram**

Ställ in standardteckensnittsstorleken för diagramtext via [Chart::get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_textformat/). Exemplet skapar ett staplat kolumndiagram med ett 20-punkts teckensnitt och aktiverar värdetiketter för den första serien via [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/). Textelement med egna explicita teckensnittinställningar kan åsidosätta diagrammets standard.

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

## **Återanvänd textramformatering för en diagramförklaring**

För att matcha en förklaring till en bildrubrik, ställ in teckensnittet i det första styckets standarddelformat via [get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/). Använd [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iformattedtextcontainer/get_textformat/) för att komma åt förklaringens textformat, och anropa sedan [CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyfrom/) med rubrikens textram. Detta kopierar textrammens inställningar, det första styckets formatering och styckets standardteckensnittsegenskaper. Formatering som appliceras direkt på enskilda delar eller på senare stycken förblir lokal för källan.

Exemplet använder en fet, 26-punkts Calibri-rubrik i marinblå som mall. Efter att ha stylat förklaringen använder det [CopyTo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyto/) för att applicera samma formatering på en separat bildtext.

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

I den sparade presentationen matchar förklaringen och bildtexten rubriken i storlek, tjocklek och färg. Förklaringen visar fortfarande serienamnen, och bildtexten behåller sin egen text. Om en del i bildtexten redan har en explicit teckensnittsstorlek, har den storleken företräde framför den kopierade stycke‑standardinställningen.

| Före kopiering | Efter kopiering |
| --- | --- |
| ![Kvartalsförsäljningsdiagram med vanliga svarta förklaringsetiketter och en svart bildtext](legend-formatting-before.png) | ![Samma diagram med större, fet marinblå förklaringsetiketter och en matchande bildtext](legend-formatting.png) |

## **Ställ in numeriskt format**

Använd [IChartDataCell::set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) för att tillämpa ett inbyggt talformat på diagrammets arbetsboks-celler. Detta exempel skapar ett staplat kolumndiagram med standard, cellstödd data och tillämpar formatindex 10 (`0.00%`) på varje serievärdecell. Detta ändrar hur värdena visas i arbetsboken utan att ändra de underliggande siffrorna; till exempel visas 0,25 som 25,00 %. Axel- och datalabelformat kan konfigureras separat.

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
        dataPoint->get_Value()->get_AsCell()->set_PresetNumberFormat(10); // 0,00%
    }
}

presentation->Save(u"PresetNumberFormat_out.pptx", SaveFormat::Pptx);
```

Följande tabell listar inbyggda talformatindex med representativa Excel-format för den engelska (USA) lokalen. De exakta formatsträngarna och deras visning kan variera beroende på program och lokal, särskilt för valuta och datum. Vissa Excel-format skiljer sig också från standardvärdena i OOXML-standarden, enligt [Microsofts anteckningar om implementering av talformat](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Format |
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

## **Ställ in rundade kanter för diagramområdet**

Aktivera [IChart::set_HasRoundedCorners](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasroundedcorners/) för att runda hörnen på diagramområdet. Exemplet skapar ett staplat kolumndiagram och använder [get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) för att ge dess kontur en solid grå färg och en enkel linjestil innan presentationen sparas.

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

## **Redigera befintliga diagramkommentarer**

Ett diagram kan innehålla anpassade former, som en textkommentar som förklarar statusen för en rapport. Åtkomst till dessa former sker via [IChart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_usershapes/), även listade under [Chart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_usershapes/) i Diagram‑API‑referensen. Dess [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)‑samling innehåller de diagramägda formerna.

En vanlig textruta placerad över ett diagram tillhör bilden, även om den ser ut som en del av diagrammet. Genom att iterera över [Slide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) hittar man diagrammet och vanliga bildformer, men enumererar inte de enskilda formerna inne i diagrammet. Diagramtitlar och datalabels är separata diagramelement, inte anpassade kommentarer i denna samling.

Ladda ner [chart-annotations.pptx](chart-annotations.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller ett diagram med en ogrupperad kommentar som säger "Preliminary results", en diagramägd linje och en vanlig bildtextruta som säger "Slide overlay". Exemplet hittar det första diagrammet på den bilden och ändrar kommentaren till "Final results" när rapporten är redo att publiceras. Det kontrollerar om samlingen är tom och redigerar endast en [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) med en icke‑null [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) och den förväntade texten.

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

Linjen och bildtextrutan förblir oförändrade. Följande bilder visar indata och det sparade, återöppnade resultatet:

| Före redigering | Efter redigering |
| --- | --- |
| ![Diagramkommentar med texten Preliminary results](chart-annotations-before.png) | ![Diagramkommentar med texten Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Exemplet undersöker endast diagramets övergripande former. Om en kommentar är inuti en [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), inspektera även den gruppens [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)‑samling. Upprepa detta rekursivt för nästlade grupper och tillämpa samma textkontroller på deras barnformer. En grupp i sig är en behållare; behandla den inte som en textruta.
{{% /alert %}}

## **Vanliga frågor**

**Kan jag ställa in halvtransparenta fyllningar för kolumner/områden samtidigt som kanten förblir opak?**

Ja. Fyllnadens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten av rutnätet och data i täta visualiseringar.

**Hur kan jag hantera datalabels när de överlappar?**

Minska teckensnittsstorleken, inaktivera icke‑nödvändiga labelkomponenter (t.ex. kategorier), justera labelpositionen, visa label endast för utvalda punkter om det behövs, eller byt formatet till "värde + förklaring".

**Kan jag tillämpa gradient‑ eller mönsterfyllningar på serier?**

Ja. Serier stödjer solida, gradient‑ och mönsterfyllningar. I praktiken bör gradienter användas sparsamt och kombinationer som minskar kontrasten mot rutnätet och texten undvikas.