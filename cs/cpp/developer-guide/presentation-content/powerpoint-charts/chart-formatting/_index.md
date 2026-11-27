---
title: Formátování grafů v prezentaci v C++
linktitle: Formátování grafu
type: docs
weight: 60
url: /cs/cpp/chart-formatting/
keywords:
- formát grafu
- formátování grafu
- entita grafu
- vlastnosti grafu
- nastavení grafu
- možnosti grafu
- vlastnosti písma
- zaoblený okraj
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se formátovat grafy v Aspose.Slides pro C++ a vylepšete svou PowerPoint prezentaci pomocí vlastních os, písem, číselných formátů a zaoblených okrajů grafu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides formátovat grafy v prezentacích PowerPoint. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, mřížkové čáry, názvy, legendy, plocha grafu a výplně stěn, aby se zlepšil vzhled a čitelnost dat v grafu.

Také ukazuje, jak nastavit vlastnosti písma pro text grafu, použít předdefinované číselné formáty na data grafu a povolit zaoblené rohy oblasti grafu. Společně tyto příklady ukazují, jak řídit jak vizuální styl, tak prezentaci dat grafů v prezentaci.

Pro samostatné výplně a obrysy na rostoucích a klesajících intervalech viz [příklad akciového grafu](/slides/cs/cpp/create-chart/#create-stock-charts).

## **Formátovat entity grafu**

Použijte [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) k formátování názvů grafů, os, mřížkových čar, legend a plochy grafu. Tento příklad vytváří čárový graf s značkami a výchozími daty, pak aplikuje samostatné styly textu a čar na jeho hodnotovou a kategoriální osu. Velikosti písma a šířky čar jsou určeny v bodech; popisky kategorií jsou otočeny o 45 stupňů.

Hodnotová osa používá [get_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_numberformat/) nezávisle na zdrojových buňkách. Její měřítko jde od -2 do 15, s hlavními intervaly 2 a menšími intervaly 0,5. Příklad také kombinuje formátování procent s [get_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_displayunit/) nastaveným na tisíce, takže tyto nastavení přizpůsobte významu a rozsahu vašich dat. Legenda zůstává mimo plochu grafu, protože [get_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegend/get_overlay/) je zakázáno. Výplně zadní stěny a podlahy jsou konfigurovány pomocí [get_BackWall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) a [get_Floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/), ale tyto povrchy jsou viditelné pouze v 3D grafech.

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

## **Nastavit vlastnosti písma pro graf**

Nastavte výchozí velikost písma pro text grafu pomocí [Chart::get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_textformat/). Příklad vytváří seskupený sloupcový graf s 20‑bodovým písmem a povoluje popisky hodnot pro první řadu pomocí [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/). Textové prvky s vlastními explicitními nastaveními písma mohou přepsat výchozí nastavení grafu.

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

## **Znovu použít formátování textového rámce pro legendu grafu**

Pro sladění legendy s nadpisem snímku nastavte písmo v výchozím formátu úseku prvního odstavce pomocí [get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/). Použijte [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iformattedtextcontainer/get_textformat/) pro přístup k formátu textu legendy, pak zavolejte [CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyfrom/) s textovým rámcem nadpisu. Tím se zkopírují nastavení textového rámce, formátování prvního odstavce a výchozí vlastnosti písma tohoto odstavce. Formátování aplikované přímo na jednotlivé úseky nebo na pozdější odstavce zůstává lokální pro zdroj.

Příklad používá tučný, 26‑bodový Calibri nadpis v námořnické barvě jako šablonu. Po stylování legendy použije [CopyTo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextformat/copyto/) k aplikaci stejného formátu na samostatný popisek.

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

V uložené prezentaci se legenda a popisek shodují s nadpisem ve velikosti, tloušťce a barvě. Legenda stále zobrazuje názvy řad a popisek si ponechává vlastní text. Pokud má úsek v popisku již explicitně nastavenou velikost písma, tato velikost má přednost před výchozím nastavením zkopírovaného odstavce.

| Před kopírováním | Po kopírování |
| --- | --- |
| ![Čtvrtletní prodejní graf s běžnými černými popisky legendy a černým popiskem](legend-formatting-before.png) | ![Stejný graf s většími, tučnými námořnickými popisky legendy a odpovídajícím popiskem](legend-formatting.png) |

## **Nastavit číselný formát**

Použijte [IChartDataCell::set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) k aplikaci vestavěného číselného formátu na buňky pracovního sešitu grafu. Tento příklad vytváří seskupený sloupcový graf s výchozími, buňkou podloženými daty a aplikuje formát index 10 (`0.00%`) na buňku hodnoty každé řady. Tím se změní způsob zobrazení hodnot v sešitu, aniž by se změnily podkladové číslice; například 0.25 se zobrazí jako 25,00 %. Formáty os a popisků dat lze konfigurovat samostatně.

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

Následující tabulka uvádí vestavěné indexy číselných formátů s reprezentativními formáty Excelu pro anglické (USA) národní prostředí. Přesné řetězce formátu a jejich zobrazení se mohou lišit podle aplikace a národního prostředí, zejména pro měny a datumy. Některé formáty Excelu se také liší od výchozích v standardu OOXML, jak je popsáno v [poznámkách o implementaci číselného formátu od Microsoftu](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Formát |
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

## **Nastavit zaoblené okraje oblasti grafu**

Povolte [IChart::set_HasRoundedCorners](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasroundedcorners/) pro zaoblení rohů oblasti grafu. Příklad vytváří seskupený sloupcový graf a používá [get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) k nastavení jeho obrysu na plnou šedou barvu a jednostrunný styl před uložením prezentace.

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

## **Upravit stávající anotace grafu**

Graf může obsahovat vlastní tvary, například textovou anotaci vysvětlující stav zprávy. Přístup k těmto tvarům získáte přes [IChart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_usershapes/), také uvedený pod [Chart::get_UserShapes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_usershapes/) v referenci API grafu. Jeho kolekce [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) obsahuje tvary vlastněné grafem.

Obyčejný textový rámec umístěný nad grafem patří do snímku, i když vypadá jako součást grafu. Iterací přes [Slide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) se najde graf a obyčejné tvary snímku, ale neenumerují se jednotlivé tvary uvnitř grafu. Názvy grafů a popisky dat jsou samostatné prvky grafu, ne vlastní anotace v této kolekci.

Stáhněte [chart-annotations.pptx](chart-annotations.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje graf s negroupovanou anotací s textem „Předběžné výsledky“, čárou vlastněnou grafem a obyčejným textovým rámcem snímku s textem „Vrstva snímku“. Příklad najde první graf na tomto snímku a změní anotaci na „Konečné výsledky“, když je zpráva připravena k publikaci. Kontroluje, zda je kolekce prázdná, a upravuje pouze [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) s nenulovým [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) a očekávaným textem.

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

Čára a textový rámec snímku zůstávají nezměněny. Následující obrázky ukazují vstup a uložený, znovu otevřený výsledek:

| Před úpravou | Po úpravě |
| --- | --- |
| ![Anotace grafu čtoucí Předběžné výsledky](chart-annotations-before.png) | ![Anotace grafu čtoucí Konečné výsledky](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
V příkladu jsou kontrolovány pouze tvary na nejvyšší úrovni vlastněné grafem. Pokud je anotace uvnitř [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), zkontrolujte také kolekci [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) této skupiny. Opakujte to rekurzivně pro vnořené skupiny a použijte stejné kontroly textu na jejich podřízené tvary. Skupina sama je kontejner; nechte ji jako textový rámec.
{{% /alert %}}

## **Často kladené otázky**

**Mohu nastavit poloprůhledné výplně pro sloupce/oblasti a přitom zachovat okraj neprůhledný?**

Ano. Průhlednost výplně a obrys jsou konfigurovány samostatně. To je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu řešit popisky dat, když se překrývají?**

Zmenšete velikost písma, vypněte nepodstatné komponenty popisků (například kategorie), upravte pozici popisku, zobrazte popisky jen pro vybrané body, pokud je to nutné, nebo přepněte formát na „hodnota + legenda“.

**Mohu aplikovat gradientní nebo vzorové výplně na řady?**

Ano. Řady podporují plné, gradientní a vzorové výplně. V praxi používejte gradienty střídmě a vyhýbejte se kombinacím, které snižují kontrast s mřížkou a textem.