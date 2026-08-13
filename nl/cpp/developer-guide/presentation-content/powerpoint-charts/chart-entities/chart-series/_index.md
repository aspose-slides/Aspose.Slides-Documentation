---
title: Beheer diagramreeksen in presentaties in C++
linktitle: Gegevensreeksen
type: docs
url: /nl/cpp/chart-series/
keywords:
- diagramreeks
- reeks overlap
- reekskleur
- categoriakleur
- reeksnaam
- datapunt
- reeksafstand
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunten, werkboekcellen, opmaak, overlap, tussenruimte en negatieve waarden in presentaties kunt beheren met C++."
---
## **Overzicht**

Een diagram slaat zijn uitgeplotte gegevens op in een diagramdataboek. Een [IChartSeries](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/) in de reeks verwijst naar één of meer cellen in het werkboek. [IChartCategory](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartcategory/) objecten leveren de labels of groepeerwaarden die door de reeksen worden gedeeld. De naam van de reeks, categorieën en puntwaarden zijn daarom verbonden met [IChartDataCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/) objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typisch categorie‑diagram gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de overige cellen voor reekswaarden. Werkblad‑, rij‑ en kolomindexen die worden doorgegeven aan [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram deze indeling gebruikt. Voor een geladen presentatie inspecteert u de cellen waarnaar de reeksen, categorieën en datapunten verwijzen voordat u werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende reikwijdtes:

- Instellingen op reeksniveau, zoals [IChartSeries::get_Format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_format/), bepalen het standaard uiterlijk voor alle punten in één reeks.
- Instellingen per datapunt, zoals [IChartDataPoint::get_Format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_format/), overschrijven het uiterlijk van de reeks voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die behoren tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseriesgroup/). Gebruik de groep via [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) wanneer u opties wilt instellen zoals overlap of tussenruimte.

Wanneer geen expliciete punt‑ of reeksvulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als puntopmaak aanwezig zijn, heeft de puntopmaak voorrang voor dat punt.

![diagram-reeks-powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlap van de diagramreeks**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_overlap/) geeft weer hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Roep [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) aan om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor diagramtypen die gegroepeerde balken of kolommen weergeven; hij heeft geen invloed op niet‑gerelateerde reeksgroepen in een combinatiediagram.

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

// Het nieuwe diagram bevat voorbeeldreeksen, categorieën en waarden.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![De reeks-overlap](series_overlap.png)

## **Verander de vulkleur van de reeks**

Gebruik [IChartSeries::get_Format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_format/) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [IChartDataPoint::get_Format](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_format/) instelling de reeksvulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste reeks:

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

![De kleur van de reeks](series_color.png)

## **Wijzig de naam van de reeks**

Een reeksnaam wordt opgeslagen in het diagramdataboek en normaal weergegeven in de legende. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerd kolomdiagram bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt verwezen door [IChartSeries::get_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_name/). Deze aanpak voorkomt dat u een specifieke rij en kolom in een bestaand diagram aanneemt:

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

![De naam van de reeks](series_name.png)

## **Haal de automatische vulkleur van de reeks op**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) retourneert de kleur die wordt berekend op basis van de reeks‑index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur af van elke standaardreeks:

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

Voorbeelduitvoer voor de standaarddiagramstijl:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Stel omgekeerde vulkleur in voor een diagramreeks**

Voor balk‑, kolom‑ en bubbelreeksen kan [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) negatieve waarden met een andere vulling weergeven. Stel de reguliere reeksvulling in op effen, schakel inversie in, en wijs de negatieve‑waardekleur toe via [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard diagramgegevens door één reeks. Werkbladrij 0 bevat de naam van de reeks, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![De omgekeerde effen vulkleur](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Wis een specifieke datapuntwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `nullptr`. Voor een kolomdiagram is de uitgeplotte waarde beschikbaar via [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Het datapunt blijft op dezelfde categoriepositie staan, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Spreidingsdiagrammen gebruiken afzonderlijke X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken bovendien een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Stel de tussenruimte van de reeks in**

Tussenruimte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende reeksgroep in plaats van tot één reeks. Roep [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) één keer voor de groep aan. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de tussenruimte en slaat alleen de uiteindelijke presentatie op:

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

![De tussenruimte](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen gegevensreeksen?**

Alle diagramtypen die worden weergegeven door de [ChartType]‑enumeratie gebruiken diagramgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de datapunt‑creatiemethode die overeenkomt met het type reeks. Opties zoals overlap en tussenruimte zijn alleen van toepassing op compatibele balk‑ of kolomgroepen.

**Wat is een diagramreeks‑groep?**

Een [IChartSeriesGroup] bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet noodzakelijk elke reeks in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard creëert [IShapeCollection::AddChart] voorbeeldreeksen, categorieën en waarden. U kunt die cellen bewerken of zowel de reeksen‑ als categorieverzamelingen wissen voordat u een volledig aangepast gegevensset toevoegt. Een overload kan ook een diagram maken zonder standaardgegevens.

**Hoe zijn diagramobjecten verbonden met werkboekcellen?**

Reeksnamen, categorielabels en datapuntwaarden refereren naar cellen in een [IChartDataWorkbook]. Het wijzigen van een verwezen cel werkt het overeenkomstige diagramonderdeel bij. Wanneer u aangepaste gegevens bouwt, houdt categorie‑rijen en reeks‑waarde‑rijen op één lijn zodat elk punt onder de beoogde categorie wordt uitgezet.

**Hoe kan ik één punt wissen in plaats van de hele reeks?**

Stel de betreffende waardecel in op `nullptr` om de categoriepositie van het punt te behouden als een leeg punt. Roep [IChartDataPointCollection::Clear] alleen aan wanneer u alle punten van die reeks wilt verwijderen. Als u ook categorieën verwijdert, werkt u elke reeks bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en [IChart::get_DisplayBlanksAs]. Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende gegevens in uw presentatie.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roep [IChartSeries::set_InvertIfNegative] aan en stel de kleur in via [IChartSeries::get_InvertedSolidFillColor]. U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint::set_InvertIfNegative]. Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeksopmaak gebruiken of, wanneer de reeksopmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlap en tussenruimte bepalen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan hoeveel reeksen een diagram kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal reeksen. In de praktijk bepalen bestandslimieten, beschikbaar geheugen, render‑tijd en de leesbaarheid van het diagram een bruikbare grens.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup::set_GapWidth] aan op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.