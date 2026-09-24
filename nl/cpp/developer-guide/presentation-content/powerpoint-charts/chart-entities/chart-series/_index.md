---
title: Beheer grafiekgegevensreeksen in presentaties in C++
linktitle: Gegevensreeksen
type: docs
url: /nl/cpp/chart-series/
keywords:
- grafiekreeks
- reeks overlap
- reeks kleur
- categorie kleur
- reeksnaam
- datapunt
- reeks gat
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunt, werkbladcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties met C++ kunt beheren."
---
## **Overzicht**

Een grafiek slaat de weergegeven gegevens op in een grafiek‑gegevens‑werkmap. Een [IChartSeries](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/) in de reeks verwijst naar één of meer werkbladcellen. [IChartCategory](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartcategory/)‑objecten leveren de labels of groeperingswaarden die door de reeksen worden gedeeld. De naam van de reeks, de categorieën en puntwaarden zijn daarom gekoppeld aan [IChartDataCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typische categorie‑grafiek gebruikt de standaardwerkmap rij 0 voor reeksnamen, kolom 0 voor categorienamen en de resterende cellen voor reekswaarden. Werkblad‑, rij‑ en kolomindexen die worden doorgegeven aan [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) zijn nul‑gebaseerd. Deze indeling is handig wanneer je een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek deze indeling gebruikt. Voor een geladen presentatie inspecteer je de cellen waarnaar de reeksen, categorieën en datapunten verwijzen voordat je werkmapwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [IChartSeries::get_Format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_format/), bepalen de standaarduiterlijk voor alle punten in één reeks.
- Instellingen op datapuntniveau, zoals [IChartDataPoint::get_Format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_format/), overschrijven het reeksen‑uiterlijk voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseriesgroup/) behoren. Toegang tot de groep krijg je via [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) wanneer je opties zoals overlap of gatbreedte moet instellen.

Wanneer er geen expliciete punt‑ of reeks‑vulling is ingesteld, bepalen het grafiek‑style en –thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑formattering aanwezig zijn, heeft de punt‑formattering voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Overlap van de grafiekreeks instellen**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_overlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Roep [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) aan om de overlap van elke compatibele reeks in die groep bij te werken. Deze optie geldt voor grafiektype­n die gegroepeerde balken of kolommen weergeven; hij heeft geen effect op niet‑gerelateerde reeksgroepen in een combinatie‑grafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// De nieuwe grafiek bevat voorbeeldreeksen, categorieën en waarden.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De reeks overlap](series_overlap.png)

## **De vulkleur van de reeks wijzigen**

Gebruik [IChartSeries::get_Format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_format/) om de standaardvulling voor een hele reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint::get_Format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_format/)‑instelling de reeksvulling voor dat punt.

Het volgende voorbeeld past een egale blauwe vulling toe op de eerste reeks:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De kleur van de reeks](series_color.png)

## **De naam van de reeks wijzigen**

Een reeksnamen wordt opgeslagen in de grafiek‑gegevens‑werkmap en wordt normaal weergegeven in de legenda. In de standaardwerkmap die voor een gegroepeerde kolomgrafiek wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Je kunt ook de cel bijwerken die al wordt verwezen door [IChartSeries::get_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_name/). Deze aanpak voorkomt dat je een specifieke rij en kolom in een bestaande grafiek moet aannemen:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De reeksnaam](series_name.png)

## **De automatische vulkleur van de reeks ophalen**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) geeft de kleur terug die wordt berekend op basis van de reeks‑index en het grafiek‑style. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij kent geen nieuwe vulling toe.

Het volgende voorbeeld schrijft de automatische kleur van elke standaardreeks uit:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

Voorbeeldoutput voor het standaardgrafiek‑style:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren hangen af van het grafiek‑style en -thema.

## **Omgekeerde vulkleur voor een grafiekreeks instellen**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) negatieve waarden weergeven met een andere vulling. Stel de reguliere reeksvulling in op egaal, schakel inversie in, en ken de negatieve‑waarde‑kleur toe via [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in de werkmap; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één reeks. Werkblad‑rij 0 bevat de reeksnamen, kolom 0 de categorienamen en kolom 1 de waarden:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De omgekeerde egale vulkleur](inverted_solid_fill_color.png)

Je kunt inversie voor één punt inschakelen via [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde zodat het effect zichtbaar is:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Een specifieke datapuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkmapcel in op `nullptr`. Voor een kolomgrafiek is de geplotte waarde beschikbaar via [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Het datapunt blijft op dezelfde categorische positie, maar de grafiek behandelt de waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

Het volgende voorbeeld wist alleen het tweede punt in de eerste reeks:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Spreidingsgrafieken gebruiken aparte X‑ en Y‑cellen, en bubbelgrafieken gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) niet aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Weergave van lege cellen regelen**

Een lege werkmapcel staat voor ontbrekende gegevens; een cel die `0` bevat staat voor een bekende numerieke waarde. Roep [IChartDataCell::set_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_value/) aan met `nullptr` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/set_displayblanksas/) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Hij bepaalt hoe lege waarden worden geplot, zonder de lege werkmapcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelf‑containende voorbeeld maakt een lijngrafiek met één reeks, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand nodig. De [IChartDataWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reeksnamen. De uiteindelijke data is `10, 20, empty, 30, 40`.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

Elk uitvoerbestand slaat de modus op die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs je de gewenste modus toe en sla je de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in de werkmap in elk geval leeg:

![Lijngrafieken met identieke data: Gap verbreekt de lijn op Dag 3, Zero laat de lijn naar nul dalen, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om te verbinden over een ontbrekende categorie, dus `Span` kan het verbindingssegment niet produceren dat hierboven wordt getoond; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook gelijk uitzien. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk grafiektype; controleer de output voor het type dat je gebruikt.

## **De gatbreedte van de reeks instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende reeksgroep en niet tot één enkele reeks. Roep [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) eenmalig aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter bij elkaar.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de uiteindelijke presentatie op:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De gatbreedte](gap_width.png)

## **FAQ**

**Welke grafiektypën ondersteunen reeksen?**

Alle grafiektypën die door de [ChartType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/)‑enumeratie worden vertegenwoordigd gebruiken grafiekgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑grafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de methode voor datapuntcreatie die overeenkomt met het type reeks. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatie‑grafiek kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet per se elke reeks in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [IShapeCollection::AddChart](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addchart/) voorbeeldreeksen, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de reeks‑ als de categorieverzamelingen wissen voordat je een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaardgegevens maken.

**Hoe zijn grafiekobjecten gekoppeld aan werkbladcellen?**

Reeksnamen, categorielabels en datapuntwaarden verwijzen naar cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/). Het wijzigen van een verwezen cel werkt het overeenkomstige grafiekelement bij. Wanneer je aangepaste data bouwt, houd je categorie‑rijen en reeks‑waarde‑rijen op één lijn zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de betreffende waarde‑cel in op `nullptr` om de positie van het punt als een leeg punt te behouden. Roep [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) alleen aan wanneer je alle punten uit die reeks wilt verwijderen. Als je ook categorieën verwijdert, werk je elke reeks bij zodat hun waarden nog steeds uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en van [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Ondersteunde grafieken kunnen lege waarden weergeven als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in je presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en een visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roep je [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) aan en stel je de kleur in via [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Je kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Deze methoden beïnvloeden alleen de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische grafiek‑style en -thema. Groepsinstellingen zoals overlap en gatbreedte regelen de lay‑out en zijn geen opmaak‑overschrijvingen op puntniveau.

**Is er een limiet aan het aantal reeksen dat een grafiek kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal reeksen. In de praktijk bepalen de beperkingen van het presentatie‑bestand, beschikbaar geheugen, rendertijd en de leesbaarheid van de grafiek een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) aan op de betreffende bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.