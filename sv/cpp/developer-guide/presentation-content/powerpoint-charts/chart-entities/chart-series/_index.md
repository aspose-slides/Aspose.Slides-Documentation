---
title: Hantera diagramdataserier i presentationer i C++
linktitle: Dataserier
type: docs
url: /sv/cpp/chart-series/
keywords:
- diagramserie
- serieöverlappning
- seriefärg
- kategorifärg
- serienamn
- datapunkt
- seriegap
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboksceller, formatering, överlappning, gapbredd och negativa värden i presentationer med C++."
---
## **Översikt**

Ett diagram lagrar sina plottade data i en diagramdataarbetsbok. En [IChartSeries](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/) representerar ett set av relaterade värden, och varje [IChartDataPoint](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/) i serien refererar till en eller flera celler i arbetsboken. [IChartCategory](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartcategory/)‑objekt tillhandahåller etiketter eller grupperingsvärden som delas av serierna. Serienamnet, kategorierna och punktvärdena är därför kopplade till [IChartDataCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/)‑objekt snarare än att bara lagras som visningstext.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för serienamn, kolumn 0 för kategorinamn och de återstående cellerna för serievärden. Arbetsblads‑, rad‑ och kolumnindex som skickas till [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) är nollbaserade. Denna layout är användbar när du skapar ett diagram med standarddata, men anta inte att varje befintligt diagram använder den. För en inläst presentation, inspektera cellerna som refereras av serierna, kategorierna och datapunkterna innan du ändrar arbetsboksvärden.

Diagraminställningarna har tre olika omfång:

- Inställningar på serie‑nivå, såsom [IChartSeries::get_Format](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/get_format/), anger standardutseendet för alla punkter i en serie.
- Inställningar på datapunkt‑nivå, såsom [IChartDataPoint::get_Format](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/get_format/), åsidosätter serieutseendet för en enskild punkt.
- Gruppinställningar gäller kompatibla serier som tillhör samma [IChartSeriesGroup](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseriesgroup/). Åtkomst till gruppen sker via [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) när du behöver ange alternativ som överlappning eller gapbredd.

När ingen explicit fyllning för punkt eller serie är angiven bestämmer diagramstilen och temat det automatiska utseendet. När både serie‑ och punktformat finns, har punktformatet företräde för den punkten.

![diagram-serie-powerpoint](chart-series-powerpoint.png)

## **Ställ in överlappning för diagramserier**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/get_overlap/) rapporterar hur mycket staplar eller kolumner överlappar i ett 2D‑diagram, från -100 till 100 procent. Det är en skrivskyddad projektion av inställningen på den överordnade seriesgruppen. Anropa [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) för att uppdatera varje kompatibel serie i den gruppen. Detta alternativ gäller diagramtyper som visar grupperade staplar eller kolumner; det påverkar inte orelaterade seriesgrupper i ett kombinationsdiagram.

Följande exempel ställer in överlappning för gruppen som innehåller den första serien:

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

// Det nya diagrammet innehåller exempelserier, kategorier och värden.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Serie‑överlappning](series_overlap.png)

## **Ändra färg för serie‑fyllning**

Använd [IChartSeries::get_Format](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/get_format/) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning åsidosätter dess [IChartDataPoint::get_Format](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/get_format/) inställning seriefyllningen för den punkten.

Följande exempel tillämpar en solid blå fyllning på den första serien:

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

Resultatet:

![Serie‑färgen](series_color.png)

## **Ändra serienamnet**

Ett serienamn lagras i diagramdataarbetsboken och visas normalt i förklaringen. I standardarbetsboken som skapas för ett grupperat kolumndiagram är cell B1 på rad 0, kolumn 1 och innehåller namnet på den första serien. De namngivna konstanterna i följande exempel gör den strukturen tydlig:

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

Du kan också uppdatera cellen som redan refereras av [IChartSeries::get_Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/get_name/). Detta tillvägagångssätt undviker att anta en särskild rad och kolumn i ett befintligt diagram:

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

Resultatet:

![Serie‑namn](series_name.png)

## **Hämta automatisk färg för serie‑fyllning**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) returnerar färgen som beräknas utifrån serieindexet och diagramstilen. Detta är färgen som används när seriefyllningen inte har definierats explicit. Anropet läser den beräknade färgen; det tilldelar ingen ny fyllning.

Följande exempel skriver ut den automatiska färgen för varje standardserie:

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

Exempelutdata för standarddiagramstilen:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exakta färgerna beror på diagramstilen och temat.

## **Ställ in inverterad fyllningsfärg för en diagramserie**

För stapel‑, kolumn‑ och bubbeldiagram kan [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) visa negativa värden med en annan fyllning. Ställ in den vanliga seriefyllningen till solid, aktivera inversion och tilldela färgen för negativa värden via [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Negativa tal förblir oförändrade i arbetsboken; bara deras visningsfärg ändras.

Följande exempel ersätter standarddiagramdata med en serie. Arbetsbladsrad 0 innehåller serienamnet, kolumn 0 innehåller kategorinamnen och kolumn 1 innehåller värdena:

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

Resultatet:

![Inverterad solid fyllningsfärg](inverted_solid_fill_color.png)

Du kan aktivera inversion för en punkt via [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). I följande exempel är inversion inaktiverad för serien och endast aktiverad för den valda punkten. Punkten får dessutom ett negativt värde så att effekten blir synlig:

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

## **Rensa ett specifikt datapunktvärde**

För att göra en punkt tom utan att ta bort de andra punkterna, sätt dess underliggande arbetsbokscell till `nullptr`. För ett kolumndiagram är det plottade värdet tillgängligt via [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Datapunkten behåller samma kategori‑position, men diagrammet behandlar dess värde som tomt enligt diagrammets inställningar för tomma värden.

Följande exempel rensar endast den andra punkten i den första serien:

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

Spridningsdiagram använder separata X‑ och Y‑celler, och bubbeldiagram använder också en storlekscell. Rensa endast den cell som representerar det värde du avser att ta bort. Anropa inte [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) när du vill behålla de andra punkterna, eftersom den metoden tar bort varje datapunkt i samlingen.

## **Styr visning av tomma celler**

En tom arbetsbokscell representerar saknade data; en cell som innehåller `0` representerar ett känt numeriskt värde. Anropa [IChartDataCell::set_Value](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/set_value/) med `nullptr` för att göra en cell tom. Ett numeriskt nollvärde förblir noll oavsett inställning för tomma celler.

Använd [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/set_displayblanksas/) för att välja hur diagrammet visar tomma celler. Denna inställning gäller för hela diagrammet. Den ändrar hur tomma värden plottas utan att fylla den tomma arbetsbokscellen med noll eller ett interpolerat värde.

Följande fristående exempel skapar ett linjediagram med en serie, rensar värdet för Dag 3 och sparar samma diagram med varje läge. Ingen indatafil krävs. [IChartDataWorkbook](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/) använder arbetsblad 0, kolumn 0 för kategorietiketter och kolumn 1 för värden; rad 0 innehåller serienamnet. Den slutliga datan är `10, 20, empty, 30, 40`.

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

Varje utdatafil sparar läget som tilldelats innan sparning: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` och `empty_cells_Span.pptx`. För att spara endast en version, tilldela önskat läge och spara presentationen en gång istället för att iterera över lägena.

Jämförelsen nedan visar samma data i alla tre filerna. Dag 3 är tom i arbetsboken i varje fall:

![Linjediagram med identiska data: Gap bryter linjen vid Dag 3, Zero sänker linjen till noll, och Span kopplar Dag 2 till Dag 4.](display_blanks_as.png)

Den synliga effekten beror på diagramtypen. Ett linjediagram gör alla tre lägen enkla att jämföra. Stapel‑ och kolumndiagram har ingen linje att koppla över en saknad kategori, så `Span` kan inte skapa den anslutande sektionen som visas ovan; en saknad kolumn och en noll‑höjd kolumn kan också se lika ut. På samma sätt har ett spridningsdiagram med endast markörer ingen anslutningslinje. Förvänta dig inte tre distinkta resultat för varje diagramtyp; kontrollera utdata för den typ du använder.

## **Ställ in serienas gapbredd**

Gapbredd är avståndet mellan intilliggande stapel‑ eller kolumnkluster, uttryckt som procent av stapel‑ eller kolumnbredden. På samma sätt som överlappning tillhör den den överordnade seriesgruppen snarare än en enskild serie. Anropa [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) en gång för gruppen. Ett större värde skapar mer utrymme mellan klustren; ett mindre värde gör dem tätare.

Följande exempel ändrar gapbredden och sparar endast den slutliga presentationen:

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

Resultatet:

![Gapbredd](gap_width.png)

## **FAQ**

**Vilka diagramtyper stöder dataserier?**

Alla diagramtyper som representeras av uppräkningen [ChartType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/charttype/) använder diagramdata, men deras serier har inte alla samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram använder X‑ och Y‑värden, och bubbeldiagram lägger till bubbelförråd. Använd den datapunkt‑skapar‑metod som matchar serietypen. Alternativ som överlappning och gapbredd gäller endast kompatibla stapel‑ eller kolumngrupper.

**Vad är en diagramseriegroupe?**

En [IChartSeriesGroup](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseriesgroup/) innehåller kompatibla serier som delar grupp‑nivå plotinställningar. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen som nås via en serie förändrar inte nödvändigtvis alla serier i diagrammet.

**Innehåller ett nyskapat diagram standarddata?**

Ja. Som standard skapar [IShapeCollection::AddChart](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addchart/) exempelserier, kategorier och värden. Du kan redigera dessa celler eller rensa både serie‑ och kategorisamlingarna innan du lägger till ett helt anpassat dataset. En overload kan också skapa ett diagram utan standarddata.

**Hur är diagramobjekt kopplade till arbetsboksceller?**

Serienamn, kategorietiketter och datapunktvärden refererar till celler i en [IChartDataWorkbook](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/). Att ändra en refererad cell uppdaterar motsvarande diagramdel. När du bygger anpassade data, håll kategorirader och serie‑värderader i synk så att varje punkt plottas under avsedd kategori.

**Hur rensar jag en punkt utan att rensa hela serien?**

Sätt den relevanta värdecellen till `nullptr` för att behålla punktens kategori‑position som en tom punkt. Anropa [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) endast när du avser att ta bort alla punkter från den serien. Om du även tar bort kategorier, uppdatera varje serie så att deras värden förblir i linje med kategorisamlingen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtyp och [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Stödda diagram kan visa tomrum som gap, som nollvärden eller genom att ansluta grannpunkter. Välj den inställning som motsvarar betydelsen av saknade data i din presentation. Se avsnittet [Styr visning av tomma celler](#control-the-display-of-empty-cells) för ett komplett exempel och visuell jämförelse.

**Hur formateras negativa värden?**

För stödda stapel‑, kolumn‑ och bubbeldiagram, anropa [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) och ange färgen via [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Du kan åsidosätta beteendet för en enskild punkt med [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Dessa metoder påverkar formatering, inte de lagrade numeriska värdena.

**Vilken formatering vinner när både en serie och en punkt är formaterade?**

Explicit datapunkt‑formatering har företräde för den punkten. Andra punkter fortsätter att använda den explicita serieformatet eller, när serieformatet inte är definierat, den automatiska diagramstilen och temat. Gruppinställningar såsom överlappning och gapbredd styr layout och är inte format‑överskrivningar på punkt‑nivå.

**Finns det en gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides pålägger ingen separat fast gräns för antalet serier. I praktiken bestäms en rimlig gräns av presentationsfilens begränsningar, tillgängligt minne, renderingtid och diagrammets läsbarhet.

**Vad bör jag justera när kolumnerna är för nära varandra eller för långt isär?**

Anropa [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) på den aktuella överordnade seriesgruppen. Öka värdet för att bredda avståndet mellan klustren, eller minska det för att föra klustren närmare varandra.