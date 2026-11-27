---
title: Grafieken in presentaties opmaken in C++
linktitle: Grafiekopmaak
type: docs
weight: 60
url: /nl/cpp/chart-formatting/
keywords:
- grafiek opmaken
- grafiekopmaak
- grafiekonderdeel
- grafiek eigenschappen
- grafiek instellingen
- grafiek opties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer grafiekopmaak in Aspose.Slides voor C++ en til uw PowerPoint-presentatie naar een hoger niveau met aangepaste assen, lettertypen, getalformaten en afgeronde grafiekranden."
---
## **Overzicht**

Dit artikel legt uit hoe je diagrammen in PowerPoint‑presentaties kunt opmaken met behulp van Aspose.Slides. Het laat zien hoe je belangrijke diagramonderdelen zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en wandsvullingen kunt aanpassen om het uiterlijk en de leesbaarheid van diagramgegevens te verbeteren.

Het toont ook hoe je lettertype‑eigenschappen voor diagramtekst kunt instellen, vooraf gedefinieerde numerieke opmaak op diagramgegevens kunt toepassen en afgeronde hoeken voor het diagramgebied kunt inschakelen. Samen laten deze voorbeelden zien hoe je zowel de visuele stijl als de weergave van gegevens van diagrammen in een presentatie kunt beheersen.

Voor aparte vullingen en contouren op stijgende en dalende intervallen, zie het [voorbeeld van een aandelengrafiek](/slides/nl/cpp/create-chart/#create-stock-charts).

## **Diagramonderdelen opmaken**

Gebruik [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) om diagramtitels, assen, rasterlijnen, legenda’s en het plotgebied op te maken. Dit voorbeeld maakt een lijndiagram met markers en standaardgegevens, en past vervolgens afzonderlijke tekst‑ en lijnstijlen toe op de waarden‑ en categorisatie‑assen. Lettergrootten en lijndiktes worden in punten gespecificeerd; categorielabels worden 45 graad gedraaid.

De waardenas gebruikt [get_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_numberformat/) onafhankelijk van de broncellen. De schaal loopt van -2 tot 15, met hoofdintervallen van 2 en subintervallen van 0,5. Het voorbeeld combineert procent‑opmaak met [get_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_displayunit/) ingesteld op duizenden, dus pas deze instellingen aan op de betekenis en omvang van jouw gegevens. De legenda blijft buiten het plotgebied omdat [get_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegend/get_overlay/) uitgeschakeld is. Achter‑wand‑ en vloer‑vullingen worden geconfigureerd via [get_BackWall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) en [get_Floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/), maar deze oppervlakken zijn alleen zichtbaar in 3D‑diagrammen.

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

## **Lettertype‑eigenschappen instellen voor een diagram**

Stel de standaardlettergrootte voor diagramtekst in via [Chart::get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_textformat/). Het voorbeeld maakt een gegroepeerd kolomdiagram met een lettergrootte van 20 punten en schakelt waardenlabels voor de eerste serie in via [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/). Tekstelementen met hun eigen expliciete lettertype‑instellingen kunnen de standaard van het diagram overschrijven.

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

## **Tekstkaderopmaak hergebruiken voor een diagramlegenda**

Om een legenda af te stemmen op een dia‑kop, stel je het lettertype in van het standaardgedeelte‑formaat van de eerste alinea via [get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/). Gebruik [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iformattedtextcontainer/get_textformat/) om toegang te krijgen tot de tekstopmaak van de legenda, en roep vervolgens [CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyfrom/) aan met het tekstkader van de kop. Dit kopieert de instellingen van het tekstkader, de opmaak van de eerste alinea en de standaardlettertype‑eigenschappen van die alinea. Opmaak die direct op individuele gedeelten of op latere alinea’s wordt toegepast, blijft lokaal bij de bron.

Het voorbeeld gebruikt een vet, 26‑punt Calibri‑kop in marineblauw als sjabloon. Na het opmaken van de legenda wordt [CopyTo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyto/) gebruikt om dezelfde opmaak toe te passen op een apart bijschrift.

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

In de opgeslagen presentatie komen de legenda en het bijschrift overeen met de kop in grootte, gewicht en kleur. De legenda toont nog steeds de serienaam, en het bijschrift behoudt zijn eigen tekst. Als een gedeelte in het bijschrift al een expliciete lettergrootte heeft, heeft die grootte voorrang op de gekopieerde alinea‑standaard.

| Voor het kopiëren | Na het kopiëren |
| --- | --- |
| ![Kwartaalverkoopgrafiek met gewone zwarte legende‑labels en een zwart bijschrift](legend-formatting-before.png) | ![Dezelfde grafiek met grotere, vette marineblauwe legende‑labels en een bijpassend bijschrift](legend-formatting.png) |

## **Numerieke opmaak instellen**

Gebruik [IChartDataCell::set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) om een ingebouwde getalopmaak toe te passen op diagram‑werkboekcellen. Dit voorbeeld maakt een gegroepeerd kolomdiagram met standaard, cel‑ondersteunde gegevens en past formaat‑index 10 (`0.00%`) toe op elke seriewaardecel. Hiermee verandert de weergave van de waarden in het werkboek zonder de onderliggende cijfers te wijzigen; bijvoorbeeld, 0,25 wordt weergegeven als 25,00 %. As‑ en gegevens‑label‑formaten kunnen apart worden geconfigureerd.

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

De volgende tabel geeft ingebouwde getalopmaak‑indices weer met representatieve Excel‑formaten voor de Engelse (Verenigde Staten) locale. De exacte format‑strings en hun weergave kunnen per toepassing en locale verschillen, met name voor valuta en datums. Sommige Excel‑formaten wijken ook af van de standaarden in de OOXML‑specificatie, zoals beschreven in [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Formaat |
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

## **Afgeronde randen voor diagramgebied instellen**

Schakel [IChart::set_HasRoundedCorners](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasroundedcorners/) in om de hoeken van het diagramgebied af te ronden. Het voorbeeld maakt een gegroepeerd kolomdiagram en gebruikt [get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) om de omtrek een effen grijze kleur en een enkele lijnstijl te geven voordat de presentatie wordt opgeslagen.

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

## **Bestaande diagramannotaties bewerken**

Een diagram kan aangepaste vormen bevatten, zoals een tekstaanduiding die de status van een rapport uitlegt. Toegang tot deze vormen krijg je via [IChart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_usershapes/), ook vermeld onder [Chart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_usershapes/) in de Diagram‑API‑referentie. De [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)‑collectie bevat de diagram‑eigen vormen.

Een gewone tekstvak geplaatst boven een diagram behoort tot de dia, zelfs als het eruitziet als onderdeel van het diagram. Itereren over [Slide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) vindt zowel het diagram als gewone dia‑vormen, maar geeft de individuele vormen binnen het diagram niet weer. Diagramtitels en gegevens‑labels zijn afzonderlijke diagramonderdelen, geen aangepaste annotaties in deze collectie.

Download [chart-annotations.pptx](chart-annotations.pptx) en plaats het in de werkmap van de applicatie. De eerste dia bevat een diagram met een niet‑gegroepeerde annotatie met de tekst “Preliminary results”, een diagram‑eigen lijn, en een gewoon tekstvak op de dia met de tekst “Slide overlay”. Het voorbeeld vindt het eerste diagram op die dia en wijzigt de annotatie naar “Final results” zodra het rapport klaar is om te publiceren. Het controleert of de collectie leeg is en bewerkt alleen een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) met een niet‑null [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) en de verwachte tekst.

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

De lijn en het tekstvak op de dia blijven ongewijzigd. De volgende afbeeldingen tonen de invoer en het opgeslagen, opnieuw geopende resultaat:

| Voor het bewerken | Na het bewerken |
| --- | --- |
| ![Diagramannotatie met de tekst Preliminary results](chart-annotations-before.png) | ![Diagramannotatie met de tekst Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}

Het voorbeeld inspecteert alleen de diagram‑eigen vormen op het hoogste niveau. Als een annotatie zich binnen een [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/) bevindt, inspecteer dan ook de [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/)‑collectie van die groep. Herhaal dit recursief voor geneste groepen en pas dezelfde tekstcontroles toe op hun onderliggende vormen. Een groep zelf is een container; behandel het niet als een tekstvak.

{{% /alert %}}

## **FAQ**

**Kan ik half‑transparante vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. Vullings‑transparantie en de omtrek worden apart geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe kan ik omgaan met gegevenslabels die overlappen?**

Verminder de lettergrootte, schakel niet‑essentiële label‑componenten uit (bijvoorbeeld categorieën), pas de labelpositie aan, toon alleen labels voor geselecteerde punten indien nodig, of schakel over naar het formaat “waarde + legenda”.

**Kan ik verloop‑ of patroonvullingen toepassen op series?**

Ja. Series ondersteunen solide, verloop‑ en patroon‑vullingen. Gebruik in de praktijk verlopen spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.