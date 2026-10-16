---
title: Beheer grafiekgegevenslabels in presentaties met C++
linktitle: Gegevenslabel
type: docs
url: /nl/cpp/chart-data-label/
keywords:
- grafiek
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labelpositie
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer grafiekgegevenslabels toe te voegen en op te maken in PowerPoint‑presentaties met Aspose.Slides voor C++ voor boeiendere dia's."
---
## **Inleiding**

Gegevensetiketten tonen informatie over grafiekreeksen en individuele gegevenspunten, waardoor lezers waarden kunnen identificeren en de grafiek kunnen begrijpen. Dit artikel legt uit hoe je waarden kunt opmaken, percentages kunt weergeven, labeltekst kunt lezen, etiketten buiten de as‑maximum kunt beheren, de afstand tussen categorie‑as‑etiketten kunt aanpassen en taartgrafiek‑etiketten kunt positioneren.

## **Gegevensprecisie instellen in grafiekgegevensetiketten**

Gebruik [set_NumberFormatOfValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_numberformatofvalues/) om reekswerte op te maken. Dit voorbeeld maakt een lijngrafiek met standaardgegevens, toont de gegevenstabel en schakelt waarde‑etiketten in voor de eerste reeks. Het formaat `#,##0.00` toont een duizendtallen‑scheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);
chart->set_HasDataTable(true);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->set_NumberFormatOfValues(u"#,##0.00");
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
```

## **Percentage weergeven als etiketten**

Voor een gestapelde kolomgrafiek bereken je elke waarde als een percentage van het totale van de categorie en wijs je de tekst toe aan het tekstraam dat wordt geretourneerd door [get_TextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertypegrootte van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Portion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <system/convert.h>
#include <vector>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20, 20, 400, 400);

auto categoryTotals = std::vector<double>(chart->get_ChartData()->get_Categories()->get_Count(), 0.0);
for (auto k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
{
    for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
    {
        auto series = chart->get_ChartData()->get_Series()->idx_get(i);
        auto pointValue = Convert::ToDouble(series->get_DataPoint(k)->get_Value()->get_Data());
        categoryTotals[k] += pointValue;
    }
}

for (auto x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(x);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

    for (auto j = 0; j < series->get_DataPoints()->get_Count(); j++)
    {
        auto label = series->get_DataPoint(j)->get_Label();
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        auto pointValue = Convert::ToDouble(series->get_DataPoint(j)->get_Value()->get_Data());
        auto dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        auto portion = MakeObject<Portion>();
        portion->set_Text(String::Format(u"{0:F2} %", dataPointPercent));
        portion->get_PortionFormat()->set_FontHeight(8.0f);

        label->get_TextFrameForOverriding()->set_Text(u"");

        auto paragraph = label->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
        paragraph->get_Portions()->Add(portion);

        label->get_DataLabelFormat()->set_ShowValue(true);
        label->get_DataLabelFormat()->set_ShowSeriesName(false);
        label->get_DataLabelFormat()->set_ShowPercentage(false);
        label->get_DataLabelFormat()->set_ShowLegendKey(false);
        label->get_DataLabelFormat()->set_ShowCategoryName(false);
        label->get_DataLabelFormat()->set_ShowBubbleSize(false);
    }
}

presentation->Save(u"DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
```

## **Percentage‑teken instellen met grafiekgegevensetiketten**

Wanneer waarden als breuken zijn opgeslagen, gebruik je [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) om percentages weer te geven. Geef `false` door aan [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) om het labelformaat onafhankelijk van de broncellen toe te passen. Dit voorbeeld maakt een 100 % gestapelde kolomgrafiek met rode en blauwe reeksen over vier categorieën. Elk paar waarden telt op tot 1. Het labelformaat `0.0%` toont 0,30 als 30,0 %, terwijl de verticale as twee decimalen gebruikt. Beide reeksen gebruiken witte labeltekst van 10 punten.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
for (auto i = 0; i < 4; i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, ObjectExt::Box(String::Format(u"Category {0}", i + 1)));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

String seriesNames[] = { u"Reds", u"Blues" };
Color seriesColors[] = { Color::get_Red(), Color::get_Blue() };
double values[2][4] = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (auto i = 0; i < 2; i++)
{
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, i + 1, ObjectExt::Box(seriesNames[i]));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());
    for (auto j = 0; j < 4; j++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, j + 1, i + 1, ObjectExt::Box(values[i][j]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
    series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColors[i]);

    auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(false);
    labelFormat->set_NumberFormat(u"0.0%");
    labelFormat->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
    labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());
}

presentation->Save(u"SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
```

## **De werkelijke tekst van gegevensetiketten lezen**

Gebruik [GetActualLabelText](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) om de tekst op te halen die wordt gegenereerd door de instellingen van een gegevenslabel. Dit is nuttig bij het extraheren van etiketten voor rapporten, het doorzoeken van presentatie‑inhoud, of het valideren van gegenereerde grafieken. In het voorbeeld hieronder combineert het standaard [data label format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/) elke categorienaam, reeksennaam en waarde. Eén punt formatteert zijn waarde als percentage, en een ander gebruikt aangepaste tekst van [get_TextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/get_textframeforoverriding/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto firstCategoryCell = workbook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Q1"));
chart->get_ChartData()->get_Categories()->Add(firstCategoryCell);
auto secondCategoryCell = workbook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Q2"));
chart->get_ChartData()->get_Categories()->Add(secondCategoryCell);

auto northSeriesCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"North"));
auto north = chart->get_ChartData()->get_Series()->Add(northSeriesCell, chart->get_Type());
auto northFirstValueCell = workbook->GetCell(0, 1, 1, ObjectExt::Box(0.25));
north->get_DataPoints()->AddDataPointForBarSeries(northFirstValueCell);
auto northSecondValueCell = workbook->GetCell(0, 2, 1, ObjectExt::Box(0.75));
north->get_DataPoints()->AddDataPointForBarSeries(northSecondValueCell);

auto southSeriesCell = workbook->GetCell(0, 0, 2, ObjectExt::Box<String>(u"South"));
auto south = chart->get_ChartData()->get_Series()->Add(southSeriesCell, chart->get_Type());
auto southFirstValueCell = workbook->GetCell(0, 1, 2, ObjectExt::Box(0.40));
south->get_DataPoints()->AddDataPointForBarSeries(southFirstValueCell);
auto southSecondValueCell = workbook->GetCell(0, 2, 2, ObjectExt::Box(0.60));
south->get_DataPoints()->AddDataPointForBarSeries(southSecondValueCell);

for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(i);
    auto format = series->get_Labels()->get_DefaultDataLabelFormat();
    format->set_ShowCategoryName(true);
    format->set_ShowSeriesName(true);
    format->set_ShowValue(true);
}

north->get_Label(1)->get_DataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
north->get_Label(1)->get_DataLabelFormat()->set_NumberFormat(u"0%");
south->get_Label(0)->get_TextFrameForOverriding()->set_Text(u"Reviewed");

for (auto i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(i);
    for (auto j = 0; j < series->get_DataPoints()->get_Count(); j++)
    {
        auto point = series->get_DataPoint(j);
        auto label = point->get_Label();
        if (!label->get_IsVisible())
        {
            continue;
        }

        Console::WriteLine(String::Format(u"Value: {0}; label: {1}", point->get_Value()->get_Data(), label->GetActualLabelText()));
    }
}
```

Het getal dat is opgeslagen in een gegevenspunt blijft `0.75`, zelfs wanneer het label `75 %` weergeeft samen met de categorie‑ en reeksennamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [GetActualLabelText](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabel/getactuallabeltext/) retourneert de resulterende label‑string in beide gevallen. Controleer [get_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabel/get_isvisible/) afzonderlijk, zoals hierboven getoond, wanneer je alleen zichtbare etiketten wilt extraheren.

## **Gegevensetiketten beheren buiten de as‑maximum**

Wanneer je een asbereik handmatig beperkt, kunnen sommige gegevenspunten de maximumwaarde overschrijden. Gebruik [set_ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_showdatalabelsovermaximum/) om te bepalen of hun gegevensetiketten worden weergegeven. Deze instelling wijzigt de zichtbaarheid van het label; het verandert niet het asbereik of de onderliggende gegevenswaarden. Het voorbeeld hieronder maakt een 2D gegroepeerde kolomgrafiek met waarden van 60 en 120. Het stelt [set_IsAutomaticMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticmaxvalue/) in op `false` en [set_MaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_maxvalue/) op 100 op de verticale as. De eerste dia staat etiketten toe buiten het maximum; een kopie van die dia schakelt ze uit. Beide dia’s worden opgeslagen in `DataLabelsOverMaximum.pptx`. Schakel waarde‑etiketten in met [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/). De instelling op diagramniveau schakelt de weergave van waarden niet automatisch in en negeert niet de uitgeschakelde weergave van een individueel label. Dit voorbeeld schakelt waarden in voor de volledige reeks en gebruikt [set_Position](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_position/) om etiketten aan het buitenste uiteinde van elke kolom te plaatsen.

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
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

auto firstCategory = workbook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Within range"));
auto secondCategory = workbook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Above maximum"));

chart->get_ChartData()->get_Categories()->Add(firstCategory);
chart->get_ChartData()->get_Categories()->Add(secondCategory);

auto seriesName = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Values"));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());

auto firstValue = workbook->GetCell(0, 1, 1, ObjectExt::Box(60));
auto secondValue = workbook->GetCell(0, 2, 1, ObjectExt::Box(120));

series->get_DataPoints()->AddDataPointForBarSeries(firstValue);
series->get_DataPoints()->AddDataPointForBarSeries(secondValue);

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_Labels()->get_DefaultDataLabelFormat()->set_Position(LegendDataLabelPosition::OutsideEnd);

chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(100);
chart->set_ShowDataLabelsOverMaximum(true);

auto secondSlide = presentation->get_Slides()->AddClone(slide);
auto secondChart = ExplicitCast<IChart>(secondSlide->get_Shape(0));
secondChart->set_ShowDataLabelsOverMaximum(false);

presentation->Save(u"DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
```

De onderstaande afbeeldingen tonen de opgeslagen dia’s zoals gerenderd door Microsoft PowerPoint. Met `true` is het label **120** zichtbaar aan de bovenkant; met `false` is het verborgen. Het label **60** blijft zichtbaar, het as‑maximum blijft **100**, en het tweede gegevenspunt blijft **120** in beide gevallen.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dit voorbeeld gebruikt een 2D kolomgrafiek met een waardenas. Grafieken zonder waardenas, zoals taart‑ en donutgrafieken, hebben geen as‑maximum dat op deze manier kan worden beperkt.
{{% /alert %}}

## **Labelafstand van een as instellen**

Gebruik [set_LabelOffset](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_labeloffset/) om de afstand tussen categorie‑as‑etiketten en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑etiketten. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt categorie‑as‑etiketten in plaats van etiketten die aan individuele gegevenspunten zijn gekoppeld.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset(500);

presentation->Save(u"SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
```

## **Labellocatie aanpassen**

Op een taartgrafiek kun je de posities van gegevensetiketten aanpassen om de spatiëring te verbeteren en ruimte te maken voor leidende lijnen. Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten de sector en gebruikt [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_x/) en [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_y/) om de offsets aan te passen. Deze offsets zijn respectievelijk relatief ten opzichte van de breedte en hoogte van de grafiek.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 200, 200);
auto series = chart->get_ChartData()->get_Series();

auto label = series->idx_get(0)->get_Label(0);
label->get_DataLabelFormat()->set_ShowValue(true);
label->get_DataLabelFormat()->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

![Taartgrafiek met een aangepaste positie van het gegevenslabel](pie-chart-adjusted-label.png)

## **Leidlijnen opmaken**

Wanneer taartgrafiek‑etiketten buiten hun sectoren staan, helpen leidlijnen lezers elke waarde aan de juiste sector te koppelen. Een contrasterende kleur en een iets dikkere lijn maken deze verbindingen makkelijker te volgen, terwijl transparantie en een gestippelde stijl de lijnen visueel onopvallend houden. Gebruik [get_LeaderLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelcollection/get_leaderlinesformat/) om leidlijnen op te maken op het niveau van de gegevenslabel‑collectie van de reeks. De instellingen in `series->get_Labels()->get_LeaderLinesFormat()->get_Line()` zijn van toepassing op de collectie, niet op een individueel label. Dit voorbeeld maakt een taartgrafiek met standaardgegevens, toont waarden buiten de sectoren en schakelt leidlijnen in met [set_ShowLeaderLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showleaderlines/). Het verplaatst twee etiketten verder van hun sectoren met behulp van offsets via [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_x/) en [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_y/), uitgedrukt als breuken van de breedte en hoogte van de grafiek. Er is geen invoerpresentatie vereist. Het opvulformaat dat wordt geretourneerd door [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) wordt gebruikt om een effen blauwe kleur in te stellen met een alfa‑waarde van 191 van 255, wat ongeveer 25 % transparantie geeft. [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) stelt de dikte in op 2 punten, en [set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) maakt de lijn gestippeld.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/LineDashStyle.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 80, 50, 560, 400);
chart->set_HasLegend(false);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
labelFormat->set_ShowValue(true);
labelFormat->set_Position(LegendDataLabelPosition::OutsideEnd);
labelFormat->set_ShowLeaderLines(true);

// Verplaats twee labels verder van hun partjes.
series->get_Label(0)->set_X(0.10f);
series->get_Label(0)->set_Y(-0.05f);
series->get_Label(1)->set_X(-0.10f);
series->get_Label(1)->set_Y(0.05f);

auto line = series->get_Labels()->get_LeaderLinesFormat()->get_Line();
line->get_FillFormat()->set_FillType(FillType::Solid);
line->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(191, 30, 90, 160));
line->set_Width(2);
line->set_DashStyle(LineDashStyle::Dash);

presentation->Save(u"FormattedLeaderLines.pptx", SaveFormat::Pptx);
```

Het inschakelen van leidlijnen garandeert niet dat er voor elk label een lijn verschijnt. De zichtbaarheid hangt af van de plaatsing van het label en het lay‑outgedrag van de grafiek. In dit voorbeeld hebben de twee verplaatste etiketten zichtbare leidlijnen; de etiketten die dicht bij hun sectoren blijven hebben ze niet nodig. De onderstaande afbeelding toont de opgeslagen `FormattedLeaderLines.pptx` zoals gerenderd met Aspose.Slides:

![Taartgrafiek met blauwe, halftransparante gestippelde leidlijnen die twee buitenste etiketten met hun sectoren verbinden](formatted-leader-lines.png)

## **Meerdere rijen gegevensetiketten toevoegen boven een kolomgrafiek**

Dit voorbeeld maakt een kolomgrafiek met twee rijen gegevensetiketten boven het plotgebied. Reeks A toont de zichtbare kolommen, terwijl Reeks B en Reeks C de extra etiketten leveren. Hun kolommen worden verborgen door de opvulling en omtrek te verwijderen. De methode [set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) uitlijnt alle drie de reeksen met dezelfde categoriebenen. De instellingen van [get_PlotArea](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_plotarea/) reserveren ruimte voor de labelrijen. Nadat [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) de standaardposities heeft berekend, behouden [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_x/) en [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilayoutable/set_y/) de horizontale uitlijning en passen verticale offsets toe om de etiketten in twee rijen te rangschikken. De cijfers blijven gegevensetiketten die gekoppeld zijn aan de reeksenwaarden; alleen de rij‑koppen zijn afzonderlijke tekstvormen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/LegendDataLabelPosition.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPlotArea.h>
#include <DOM/Chart/LayoutTargetType.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/ShapeType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
chart->set_HasTitle(false);
chart->set_HasLegend(false);
chart->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

String categories[] = { u"North", u"South", u"East", u"West" };
String seriesNames[] = { u"Series A", u"Series B", u"Series C" };
double seriesValues[3][4] = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (auto categoryIndex = 0; categoryIndex < 4; categoryIndex++)
{
    auto categoryCell = workbook->GetCell(0, categoryIndex + 1, 0, ObjectExt::Box(categories[categoryIndex]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 3; seriesIndex++)
{
    auto seriesCell = workbook->GetCell(0, 0, seriesIndex + 1, ObjectExt::Box(seriesNames[seriesIndex]));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, ChartType::ClusteredColumn);

    for (auto categoryIndex = 0; categoryIndex < 4; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(0, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(seriesValues[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // Verberg de kolommen van B en C, maar behoud hun gegevenslabels.
        series->get_Format()->get_Fill()->set_FillType(FillType::NoFill);
        series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
        auto labelFormat = series->get_Labels()->get_DefaultDataLabelFormat();
        labelFormat->set_ShowValue(true);
        labelFormat->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
        auto labelFill = labelFormat->get_TextFormat()->get_PortionFormat()->get_FillFormat();
        labelFill->set_FillType(FillType::Solid);
        labelFill->get_SolidFillColor()->set_Color(Color::get_Black());
        labelFormat->set_Position(LegendDataLabelPosition::InsideBase);
    }
}

// Lijn alle drie de series uit op dezelfde categoriebenen.
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(100);

// Gebruik minder rasterlijnen voor dit compacte voorbeeld.
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_VerticalAxis()->set_MajorUnit(10);

// Reserveer ruimte boven het plotgebied voor twee rijen gegevenslabels.
chart->get_PlotArea()->set_LayoutTargetType(LayoutTargetType::Inner);
chart->get_PlotArea()->set_X(0.15f);
chart->get_PlotArea()->set_Y(0.32f);
chart->get_PlotArea()->set_Width(0.80f);
chart->get_PlotArea()->set_Height(0.48f);
chart->ValidateChartLayout();

for (auto seriesIndex = 1; seriesIndex < 3; seriesIndex++)
{
    auto series = chart->get_ChartData()->get_Series()->idx_get(seriesIndex);
    auto rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (auto categoryIndex = 0; categoryIndex < 4; categoryIndex++)
    {
        auto dataLabel = series->get_DataPoint(categoryIndex)->get_Label();
        // Bewaar de standaard horizontale positie. Y is een offset ten opzichte van
        // de standaard labelpositie, uitgedrukt als een fractie van de diagramhoogte.
        dataLabel->set_X(0);
        dataLabel->set_Y(rowTop - dataLabel->get_ActualY() / chart->get_Height());
    }

    // Alleen de rijkop is een afzonderlijke tekstvorm.
    auto rowHeading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, chart->get_X(), chart->get_Y() + rowTop * chart->get_Height(), 85, 18);
    rowHeading->get_FillFormat()->set_FillType(FillType::NoFill);
    rowHeading->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    rowHeading->AddTextFrame(seriesNames[seriesIndex]);
    rowHeading->get_TextFrame()->get_TextFrameFormat()->set_MarginTop(0);
    rowHeading->get_TextFrame()->get_TextFrameFormat()->set_MarginBottom(0);
    auto headingFormat = rowHeading->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
    headingFormat->set_FontHeight(12);
    headingFormat->get_FillFormat()->set_FillType(FillType::Solid);
    headingFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
}

presentation->Save(u"multiple-rows-of-labels.pptx", SaveFormat::Pptx);
```

![Kolomgrafiek met twee rijen gegevensetiketten boven het plotgebied](multiple-rows-of-labels.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevensetiketten overlappen in dichte grafieken?**

Combineer automatische labelplaatsing, leidlijnen en een kleinere lettergrootte; verberg indien nodig sommige velden (bijvoorbeeld de categorie) of toon alleen etiketten voor extreme waarden of sleutelpunten.

**Hoe kan ik etiketten uitschakelen alleen voor nul-, negatieve of lege waarden?**

Filter gegevenspunten voordat je etiketten inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl waarborgen bij het exporteren naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en verifieer dat het lettertype beschikbaar is in de renderomgeving om fallback te vermijden.