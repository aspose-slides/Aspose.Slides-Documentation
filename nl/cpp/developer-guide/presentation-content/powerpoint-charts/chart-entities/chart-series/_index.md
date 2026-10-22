---
title: Beheer grafiekdataseries in presentaties in C++
linktitle: Dataseries
type: docs
url: /nl/cpp/chart-series/
keywords:
- grafiekseries
- serie-overlap
- seriekleur
- categoriakleur
- serienaam
- datapunt
- seriegat
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u grafiekseries, datapunten, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties kunt beheren met C++."
---
## **Overzicht**

Een grafiek kan zijn weergegeven waarden opslaan in werkboekcellen of rechtstreeks als numerieke letterlijke waarden. Een [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/) vertegenwoordigt één set verwante waarden, en elk [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/) vertegenwoordigt een punt in die serie. [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/)‑objecten leveren de labels of groepeerwaarden die door de series worden gedeeld. In grafieken die met standaardgegevens worden aangemaakt, gebruiken seriesnamen, categorieën en puntwaarden [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/)‑objecten uit het grafiekwerkboek.

Voor een typische categoriegrafiek gebruikt het standaardwerkboek rij 0 voor seriesnamen, kolom 0 voor categorienamen en de overige cellen voor serieswaarden. Werkblad‑, rij‑ en kolom‑indexen die worden doorgegeven aan [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) zijn nul‑gebaseerd. Deze indeling is nuttig wanneer u een grafiek met standaardgegevens aanmaakt, maar ga er niet vanuit dat elke bestaande grafiek deze indeling hanteert. Voor een geladen presentatie moet u de cellen inspecteren die door de series, categorieën en datapoints worden gerefereerd voordat u werkboekwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende scopes:

- Instellingen op serieniveau, zoals [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/), bepalen de standaarduiterlijk voor alle punten in één serie.
- Instellingen per datapunt, zoals [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/), overschrijven de serie‑uiterlijk voor één punt.
- Groepsinstellingen gelden voor compatibele series die tot dezelfde [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) behoren. Benader de groep via [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) wanneer u opties wilt instellen zoals overlap of gatbreedte.

Wanneer er geen expliciete punt‑ of serie‑vulling is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Serieswaarden instellen met numerieke letterlijke waarden**

Gebruik numerieke letterlijke waarden wanneer serieswaarden afkomstig zijn van toepassingsdata of berekeningen en geen cel‑referenties naar een werkblad nodig hebben. Roep [set_DataSourceTypeForValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforvalues/) aan met [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) voordat u de waarde die door elk punt wordt geretourneerd via [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_value/) toewijst via [set_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/set_asliteraldouble/).

De collectiesetting bepaalt het brontype van alle puntwaarden in die serie. Elke punt‑[IBaseChartValue::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ibasechartvalue/get_datasourcetype/) rapporteert het geselecteerde type; wijzig het via de collectiesetting. Met `Worksheet` gebruikt u [get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/isinglecellchartvalue/get_ascell/) om de gerefereerde cel te benaderen. Met `DoubleLiterals` gebruikt u [get_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/get_asliteraldouble/) of `set_AsLiteralDouble` om het getal direct te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomgrafiek met standaard series en categorieën en kent berekende waarden van 10, 20, enz. toe aan de bestaande punten van de eerste serie. Het slaat de presentatie op, opent deze opnieuw en drukt de opgeslagen waarden af.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

series->get_DataPoints()->set_DataSourceTypeForValues(DataSourceType::DoubleLiterals);
for (auto i = 0; i < series->get_DataPoints()->get_Count(); i++)
{
    series->get_DataPoints()->idx_get(i)->get_Value()->set_AsLiteralDouble((i + 1) * 10);
}

presentation->Save(u"numeric_literals.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"numeric_literals.pptx");
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedChart = ExplicitCast<IChart>(reopenedSlide->get_Shape(0));
auto reopenedSeries = reopenedChart->get_ChartData()->get_Series()->idx_get(0);
for (auto i = 0; i < reopenedSeries->get_DataPoints()->get_Count(); i++)
{
    auto point = reopenedSeries->get_DataPoints()->idx_get(i);
    Console::WriteLine(point->get_Value()->get_AsLiteralDouble());
}
reopenedPresentation->Dispose();
```

Het punt‑waarde‑brontype staat los van [IChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_datasourcetype/), dat de interne of externe werkboekconfiguratie van de grafiek identificeert. Het gebruik van numerieke letterlijke waarden verwijdert op zichzelf niet het ingebedde werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, serienamen en de overige series. Zie [Chart Workbook](/slides/nl/cpp/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en bubbelgrafieken roept u [set_DataSourceTypeForXValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforxvalues/) en [set_DataSourceTypeForYValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforyvalues/) aan om de bronnen voor [get_XValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_xvalue/) en [get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) te kiezen. Bubbelgrafieken gebruiken ook [set_DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforbubblesizes/) voor [get_BubbleSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_bubblesize/). Stel elke toepasselijke bron in op `DoubleLiterals` voordat u getallen toekent via de `set_AsLiteralDouble`‑methode van die waarde.

## **Overlap van grafiekseries instellen**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende seriegroep. Roep [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) aan om elke compatibele serie in die groep bij te werken. Deze optie geldt voor grafiektype­n die gegroepeerde balken of kolommen weergeven; hij beïnvloedt geen niet‑gerelateerde seriegroepen in een combinatiegrafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste serie bevat:

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

// De nieuwe grafiek bevat voorbeeldseries, categorieën en waarden.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![The series overlap](series_overlap.png)

## **Kleur van de serie‑vulling wijzigen**

Gebruik [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) om de standaardvulling voor een hele serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft zijn [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) instelling de serie‑vulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste serie:

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

![The color of the series](series_color.png)

## **Naam van de serie wijzigen**

Een serienaam wordt opgeslagen in het grafiekwerkboek en wordt normaal gesproken in de legenda weergegeven. In het standaardwerkboek dat voor een gegroepeerde kolomgrafiek wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt gerefereerd door [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/). Deze aanpak vermijdt aannames over een specifieke rij en kolom in een bestaande grafiek:

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

![The series name](series_name.png)

### **Een serie maken met een naam uit meerdere cellen**

Een samengestelde serienaam is handig wanneer een productnaam en een verslagperiode in afzonderlijke werkboekcellen staan. U kunt bijvoorbeeld `Product A` in B1 en `2026` in C1 combineren tot één serienaam, terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/) om het naam‑bereik op te halen en geef die collectie door aan [IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één serie en twee datapoints. Cellen B1:C1 leveren alleen de serienaam; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCellCollection.h>
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

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 620.0f, 180.0f);
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
chart->set_HasLegend(true);

auto workbook = chartData->get_ChartDataWorkbook();
workbook->Clear(0);

// Deze twee cellen leveren de seriesnaam.
auto productName = ObjectExt::Box<String>(u"Product A");
auto reportingPeriod = ObjectExt::Box<String>(u"2026");
workbook->GetCell(0, 0, 1, productName);
workbook->GetCell(0, 0, 2, reportingPeriod);
auto nameCells = workbook->GetCellCollection(u"Sheet1!$B$1:$C$1", false);
auto series = chartData->get_Series()->Add(nameCells, ChartType::ClusteredColumn);

// Aparte cellen leveren de categorieën en numerieke datapunten.
auto northLabel = ObjectExt::Box<String>(u"North");
auto southLabel = ObjectExt::Box<String>(u"South");
auto northCategory = workbook->GetCell(0, 1, 0, northLabel);
auto southCategory = workbook->GetCell(0, 2, 0, southLabel);
chartData->get_Categories()->Add(northCategory);
chartData->get_Categories()->Add(southCategory);
auto northAmount = ObjectExt::Box<int>(120);
auto southAmount = ObjectExt::Box<int>(150);
auto northValue = workbook->GetCell(0, 1, 1, northAmount);
auto southValue = workbook->GetCell(0, 2, 1, southAmount);
series->get_DataPoints()->AddDataPointForBarSeries(northValue);
series->get_DataPoints()->AddDataPointForBarSeries(southValue);

presentation->Save(u"composite_series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De resulterende serienaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één item voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Automatische serie‑vulkleur ophalen**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) geeft de kleur terug die wordt berekend op basis van de serie‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de serie‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur van elke standaardsere uit:

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

Voorbeeldoutput voor de standaardgrafiekstijl:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Omgekeerde vullingskleur voor een grafiekserie instellen**

Voor balk‑, kolom‑ en bubbelseries kan [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) negatieve waarden met een andere vulling weergeven. Stel de gewone serie‑vulling in op effen, schakel inversie in en wijs de negatieve‑waardekleur toe via [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekdata door één serie. Werkblad‑rij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt tevens een negatieve waarde zodat het effect zichtbaar is:

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

## **Specifieke datapuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `nullptr`. Voor een kolomgrafiek is de weergegeven waarde beschikbaar via [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Het datapunt blijft op dezelfde categorielocatie, maar de grafiek behandelt de waarde als leeg volgens de leeg‑waarde‑instellingen van de grafiek.

Het volgende voorbeeld wist alleen het tweede punt van de eerste serie:

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

Spreidingsgrafieken gebruiken aparte X‑ en Y‑cellen, en bubbelgrafieken gebruiken bovendien een groottecel. Wis alleen de cel die de waarde representeert die u wilt verwijderen. Roep [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert alle datapoints uit de collectie.

## **Weergave van lege cellen regelen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Om data uit verborgen rijen en kolommen van een werkblad wel of niet op te nemen, zie [Include Data from Hidden Rows and Columns](/slides/nl/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel staat voor missende data; een cel met `0` staat voor een bekende numerieke waarde. Roep [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/) aan met `nullptr` om een cel leeg te maken. Een numeriek nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Hij bepaalt hoe leegtes worden uitgezet, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelf‑containende voorbeeld maakt een lijngrafiek met één serie, wist de waarde voor Dag 3 en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand vereist. De [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke data zijn `10, 20, empty, 30, 40`.

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

// Laat dag 3 echt leeg, terwijl de categorie en het datapunt behouden blijven.
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

Elke uitvoer‑file slaat de vóór het opslaan toegekende modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat u de presentatie één keer op in plaats van over alle modi te itereren.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om over een ontbrekende categorie heen te verbinden, dus `Span` kan het getoonde verbindingssegment niet creëren; een ontbrekende kolom en een kolom met nul‑hoogte kunnen er ook op elkaar lijken. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk grafiektype; controleer de output voor het type dat u gebruikt.

## **Gatbreedte van de serie instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort dit tot de bovenliggende seriegroep en niet tot één serie. Roep [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) één keer aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

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

![The gap width](gap_width.png)

## **FAQ**

**Welke grafiektype­n ondersteunen dataseries?**

Alle grafiektype­n die door de [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑enumeratie worden vertegenwoordigd, gebruiken grafiekdata, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriegrafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de datapunt‑creatiemethode die past bij het serietype. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiek‑seriegroep?**

Een [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, zodat het wijzigen van de groep die via één serie wordt benaderd, niet per se elke serie in de grafiek verandert.

**Bevat een nieuw aangemaakte grafiek standaarddata?**

Ja. Standaard maakt [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) voorbeeld‑series, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de series‑ als categorie‑collecties wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaarddata maken.

**Hoe zijn grafiekobjecten gekoppeld aan werkboekcellen?**

Serienamen, categorielabels en datapuntwaarden refereren cellen in een [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer u aangepaste data samenstelt, houdt u de rijen met categorieën en de rijen met series‑waarden op één lijn zodat elk punt onder de juiste categorie wordt uitgezet.

**Hoe wis ik één punt in plaats van de volledige serie?**

Stel de relevante waardecel in op `nullptr` om de positie van het punt in de categorie te behouden als een leeg punt. Roep [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) alleen aan wanneer u alle punten uit die serie wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden uitgelijnd blijven met de categoricollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en van [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Ondersteunde grafieken kunnen leegtes weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van missende data in uw presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelseries roept u [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) aan en stelt u de kleur in via [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). U kunt het gedrag voor een individueel punt overschrijven met [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet gedefinieerd is, de automatische grafiekstijl en het thema. Groepsinstellingen zoals overlap en gatbreedte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overriding.

**Is er een limiet aan het aantal series dat een grafiek kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal series. In de praktijk bepalen bestandsbeperkingen, beschikbare geheugen, render‑tijd en leesbaarheid van de grafiek een praktisch maximum.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) aan op de juiste bovenliggende seriegroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag de waarde om de clusters dichter bij elkaar te brengen.