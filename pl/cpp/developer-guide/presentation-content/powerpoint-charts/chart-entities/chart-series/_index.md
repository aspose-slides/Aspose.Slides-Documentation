---
title: Zarządzanie seriami danych wykresu w prezentacjach w C++
linktitle: Serie danych
type: docs
url: /pl/cpp/chart-series/
keywords:
- serie wykresu
- nachodzenie serii
- kolor serii
- kolor kategorii
- nazwa serii
- punkt danych
- przerwa serii
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nachodzeniem, szerokością przerwy i wartościami ujemnymi w prezentacjach przy użyciu C++."
---
## **Przegląd**

Wykres przechowuje dane do rysowania w skoroszycie danych wykresu. [IChartSeries](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [IChartDataPoint](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/) w serii odnosi się do jednej lub wielu komórek skoroszytu. Obiekty [IChartCategory](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartcategory/) dostarczają etykiety lub wartości grupujące współdzielone przez serie. Dlatego nazwa serii, kategorie i wartości punktów są połączone z obiektami [IChartDataCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/), a nie przechowywane wyłącznie jako tekst wyświetlany.

Dla typowego wykresu kategorii domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumn przekazywane do [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) są zerowe. Ten układ jest przydatny, gdy tworzysz wykres z danymi domyślnymi, ale nie zakładaj, że każdy istniejący wykres go używa. Dla wczytanej prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości skoroszytu.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [IChartSeries::get_Format](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/get_format/), dostarczają domyślny wygląd dla wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [IChartDataPoint::get_Format](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/get_format/), zastępują wygląd serii dla jednego punktu.
- Ustawienia grupowe mają zastosowanie do zgodnych serii, które należą do tego samego [IChartSeriesGroup](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseriesgroup/). Uzyskaj dostęp do grupy przez [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/), gdy musisz ustawić opcje takie jak nachodzenie lub szerokość przerwy.

Gdy nie jest ustawione jawne wypełnienie punktu lub serii, styl i motyw wykresu określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![serie-wykresu-powerpoint](chart-series-powerpoint.png)

## **Ustaw nachodzenie serii wykresu**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/get_overlap/) podaje, o ile słupki lub kolumny nachodzą na siebie w wykresie 2D, od ‑100 do 100 procent. Jest to tylko do odczytu projekcja ustawienia w grupie serii nadrzędnej. Wywołaj [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/), aby zaktualizować wszystkie zgodne serie w tej grupie. Ta opcja ma zastosowanie do typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niezwiązane grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia nachodzenie dla grupy zawierającej pierwszą serię:

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

// Nowy wykres zawiera przykładowe serie, kategorie i wartości.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wynik:

![Nachodzenie serii](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Użyj [IChartSeries::get_Format](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/get_format/), aby ustawić domyślne wypełnienie dla całej serii. Jeśli punkt ma już jawne wypełnienie, jego ustawienie [IChartDataPoint::get_Format](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/get_format/) zastępuje wypełnienie serii dla tego punktu.

Poniższy przykład stosuje jednolite niebieskie wypełnienie do pierwszej serii:

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

Wynik:

![Kolor serii](series_color.png)

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zazwyczaj wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla wykresu słupkowego skumulowanego komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Stałe nazwane w poniższym przykładzie wyraźnie określają tę strukturę:

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

Możesz także zaktualizować komórkę już odwoływaną przez [IChartSeries::get_Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/get_name/). To podejście unika zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

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

Wynik:

![Nazwa serii](series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało jawnie określone. Wywołanie tej metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

Poniższy przykład wypisuje automatyczny kolor każdej domyślnej serii:

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

Przykładowe wyjście dla domyślnego stylu wykresu:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Dokładne kolory zależą od stylu i motywu wykresu.

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Dla serii słupkowych, kolumnowych i bąbelkowych [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na jednolite, włącz odwrócenie i przypisz kolor wartości ujemnej przez [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Liczby ujemne pozostają niezmienione w skoroszycie; zmienia się jedynie ich kolor wyświetlania.

Poniższy przykład zastępuje domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 zawiera nazwy kategorii, a kolumna 1 zawiera wartości:

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

Wynik:

![Odwrócony jednolity kolor wypełnienia](inverted_solid_fill_color.png)

Możesz włączyć odwrócenie dla jednego punktu przez [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). W poniższym przykładzie odwrócenie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punktowi przypisano także wartość ujemną, aby efekt był widoczny:

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

## **Wyczyść konkretną wartość punktu danych**

Aby pozostawić jeden punkt pusty bez usuwania pozostałych, ustaw jego komórkę w skoroszycie na `nullptr`. Dla wykresu kolumnowego wartość rysowana jest dostępna przez [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Punkt danych pozostaje w tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

Poniższy przykład usuwa tylko drugi punkt w pierwszej serii:

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

Wykresy rozproszenia używają osobnych komórek X i Y, a wykresy bąbelkowe dodatkowo używają komórki rozmiaru. Czyść tylko komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointcollection/clear/), gdy chcesz zachować pozostałe punkty, ponieważ ta metoda usuwa wszystkie punkty danych z kolekcji.

## **Kontroluj wyświetlanie pustych komórek**

Pusta komórka skoroszytu oznacza brak danych; komórka zawierająca `0` oznacza znaną wartość liczbową. Wywołaj [IChartDataCell::set_Value](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatacell/set_value/) z `nullptr`, aby uczynić komórkę pustą. Liczbowe zero pozostaje zerem niezależnie od ustawienia pustej komórki.

Użyj [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/set_displayblanksas/), aby wybrać, jak wykres wyświetla puste komórki. To ustawienie ma zastosowanie do całego wykresu. Zmienia sposób rysowania pustych wartości, nie wypełniając pustej komórki skoroszytu zerem ani interpolowaną wartością.

Poniższy samodzielny przykład tworzy wykres liniowy z jedną serią, usuwa wartość dla Dnia 3 i zapisuje wykres w każdym trybie. Nie jest wymagany plik wejściowy. [IChartDataWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/) używa arkusza 0, kolumny 0 dla etykiet kategorii i kolumny 1 dla wartości; wiersz 0 przechowuje nazwę serii. Końcowe dane to `10, 20, empty, 30, 40`.

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

// Zostaw Dzień 3 naprawdę pusty, zachowując jego kategorię i punkt danych.
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

Każdy plik wyjściowy przechowuje tryb przydzielony przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, przypisz żądany tryb i zapisz prezentację jednorazowo, zamiast iterować po trybach.

Poniższe porównanie pokazuje te same dane we wszystkich trzech plikach. Dzień 3 jest pusty w skoroszycie we wszystkich przypadkach:

![Wykresy liniowe z identycznymi danymi: Gap przerywa linię w Dniu 3, Zero obniża linię do zera, a Span łączy Dzień 2 z Dniem 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy umożliwia łatwe porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii łączącej brakującą kategorię, więc `Span` nie może wygenerować pokazanego segmentu; brakująca kolumna i kolumna o wysokości zero mogą wyglądać podobnie. Podobnie wykres rozproszenia z samymi znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wynik dla używanego typu.

## **Ustaw szerokość przerwy między seriami**

Szerokość przerwy to odległość między sąsiadującymi skupiskami słupków lub kolumn, wyrażona procentowo względem szerokości słupka lub kolumny. Podobnie jak nachodzenie, należy ona do grupy serii nadrzędnej, a nie do jednej serii. Wywołaj [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) raz dla grupy. Większa wartość tworzy więcej przestrzeni między skupiskami; mniejsza wartość powoduje ich zagęszczenie.

Poniższy przykład zmienia szerokość przerwy i zapisuje tylko ostateczną prezentację:

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

Wynik:

![Szerokość przerwy](gap_width.png)

## **FAQ**

**Jakie typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/) używają danych wykresu, ale ich serie nie mają identycznej struktury wartości ani ustawień. Na przykład wykresy kategorii używają kategorii i wartości, wykresy rozproszenia używają wartości X i Y, a wykresy bąbelkowe dodają rozmiary bąbelkowe. Użyj metody tworzenia punktu danych pasującej do typu serii. Opcje takie jak nachodzenie i szerokość przerwy mają zastosowanie wyłącznie do zgodnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseriesgroup/) zawiera zgodne serie, które współdzielą ustawienia grupowe wykresu. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmienia wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera dane domyślne?**

Tak. Domyślnie [IShapeCollection::AddChart](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addchart/) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno kolekcje serii, jak i kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może także utworzyć wykres bez danych domyślnych.

**W jaki sposób obiekty wykresu są połączone z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [IChartDataWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdataworkbook/). Zmiana odwoływanej komórki aktualizuje odpowiedni element wykresu. Budując własne dane, utrzymuj wiersze kategorii i wiersze wartości serii wyrównane, aby każdy punkt był rysowany pod zamierzoną kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `nullptr`, aby zachować pozycję kategorii punktu jako pustego punktu. Wywołaj [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z danej serii. Jeśli usuwasz także kategorie, zaktualizuj każdą serię, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zerowe lub poprzez połączenie sąsiednich punktów. Wybierz ustawienie pasujące do znaczenia brakujących danych w Twojej prezentacji. Zobacz sekcję [Kontroluj wyświetlanie pustych komórek](#control-the-display-of-empty-cells) po pełny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) i ustaw kolor przez [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Możesz nadpisać zachowanie dla pojedynczego punktu przy pomocy [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Metody te wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie ma pierwszeństwo, gdy zarówno seria, jak i punkt są sformatowane?**

Jawne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają jawnego formatu serii lub, gdy format serii nie jest zdefiniowany, automatycznego stylu i motywu wykresu. Ustawienia grupowe, takie jak nachodzenie i szerokość przerwy, kontrolują układ i nie są nadpisywane przez formatowanie punktowe.

**Czy istnieje limit liczby serii w wykresie?**

Aspose.Slides nie narzuca osobnego, stałego limitu liczby serii. W praktyce ograniczenia wynikają z rozmiaru pliku prezentacji, dostępnej pamięci, czasu renderowania oraz czytelności wykresu.

**Co zmienić, gdy kolumny są ze sobą zbyt blisko lub zbyt daleko?**

Wywołaj [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby rozszerzyć odstęp między grupami, lub zmniejsz ją, aby przybliżyć grupy do siebie.