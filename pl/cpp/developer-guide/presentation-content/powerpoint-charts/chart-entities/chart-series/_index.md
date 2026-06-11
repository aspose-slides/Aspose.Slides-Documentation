---
title: Zarządzanie seriami danych wykresu w prezentacjach przy użyciu C++
linktitle: Serie danych
type: docs
url: /pl/cpp/chart-series/
keywords:
- serie wykresu
- nakładanie serii
- kolor serii
- kolor kategorii
- nazwa serii
- punkt danych
- przerwa serii
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu w C++ dla PowerPoint (PPT/PPTX) przy użyciu praktycznych przykładów kodu i najlepszych praktyk, aby ulepszyć swoje prezentacje danych."
---
## **Przegląd**

Ten artykuł opisuje rolę [ChartSeries](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartseries/) w Aspose.Slides, skupiając się na tym, jak dane są strukturalizowane i wizualizowane w prezentacjach. Obiekty te zapewniają elementy bazowe definiujące indywidualne zestawy punktów danych, kategorie i parametry wyglądu wykresu. Pracując z [ChartSeries](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartseries/), programiści mogą płynnie integrować źródła danych i zachować pełną kontrolę nad sposobem wyświetlania informacji, co skutkuje dynamicznymi, opartymi na danych prezentacjami jasno przekazującymi wnioski i analizy.

Seria to wiersz lub kolumna liczb wykreślona na wykresie.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii danych**

Za pomocą metody [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) możesz określić, jak bardzo słupki i kolumny mają się nakładać na wykresie 2D (zakres: -100 do 100). Właściwość ta ma zastosowanie do wszystkich serii w grupie serii nadrzędnej: jest to projekcja odpowiedniej właściwości grupy.

Użyj metody `get_ParentSeriesGroup()::set_Overlap()`, aby ustawić preferowaną wartość dla `Overlap`. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Dodaj skontenrowany wykres kolumnowy na slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu.
1. Uzyskaj dostęp do `ParentSeriesGroup` serii wykresu i ustaw preferowaną wartość nakładania dla serii.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten kod C++ pokazuje, jak ustawić nakładanie dla serii wykresu:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Ustawia nakładanie serii
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Writes the presentation file to disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Zmień kolor serii danych**

Aspose.Slides dla C++ umożliwia zmianę koloru serii w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Dodaj wykres na slajdzie.
1. Uzyskaj dostęp do serii, której kolor chcesz zmienić.
1. Ustaw preferowany typ wypełnienia i kolor wypełnienia.
1. Zapisz zmodyfikowaną prezentację.

Ten kod C++ pokazuje, jak zmienić kolor serii:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Zmień kolor kategorii serii danych**

Aspose.Slides dla C++ umożliwia zmianę koloru kategorii serii w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Dodaj wykres na slajdzie.
1. Uzyskaj dostęp do kategorii serii, której kolor chcesz zmienić.
1. Ustaw preferowany typ wypełnienia i kolor wypełnienia.
1. Zapisz zmodyfikowaną prezentację.

Ten kod w C++ pokazuje, jak zmienić kolor kategorii serii:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Zmień nazwę serii danych** 

Domyślnie, nazwy w legendzie wykresu pochodzą z zawartości komórek nad każdą kolumną lub wierszem danych. 

W naszym przykładzie (obrazek przykładowy),

* kolumny to *Series 1, Series 2,* i *Series 3*;
* wiersze to *Category 1, Category 2, Category 3,* i *Category 4.* 

Aspose.Slides dla C++ umożliwia aktualizację lub zmianę nazwy serii w danych wykresu i legendzie. 

Ten kod C++ pokazuje, jak zmienić nazwę serii w danych wykresu `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Ten kod C++ pokazuje, jak zmienić nazwę serii w legendzie poprzez`Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Ustaw kolor wypełnienia serii danych**

Aspose.Slides dla C++ umożliwia ustawienie automatycznego koloru wypełnienia serii wykresu w obszarze wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj wykres z danymi domyślnymi oparty na wybranym typie (w poniższym przykładzie użyliśmy `ChartType::ClusteredColumn`).
1. Uzyskaj dostęp do serii wykresu i ustaw kolor wypełnienia na Automatic.
1. Zapisz prezentację do pliku PPTX.

Ten kod C++ pokazuje, jak ustawić automatyczny kolor wypełnienia dla serii wykresu:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Tworzy wykres kolumnowy skontenrowany
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Ustawia format wypełnienia serii na automatyczny
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Zapisuje plik prezentacji na dysk
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Ustaw odwrócone kolory wypełnienia serii danych**

Aspose.Slides umożliwia ustawienie odwróconego koloru wypełnienia serii wykresu w obszarze wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj wykres z danymi domyślnymi oparty na wybranym typie (w poniższym przykładzie użyliśmy `ChartType::ClusteredColumn`).
1. Uzyskaj dostęp do serii wykresu i ustaw kolor wypełnienia na invert.
1. Zapisz prezentację do pliku PPTX.

Ten kod C++ demonstruje działanie:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Dodaje nowe serie i kategorie
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Pobiera pierwszą serię wykresu i wypełnia jej dane.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Aspose.Slides umożliwia ustawienie odwrócenia za pomocą metod`IChartDataPoint::set_InvertIfNegative()` oraz `ChartDataPoint.set_InvertIfNegative()`. Gdy odwrócenie jest ustawione przy użyciu tych metod, punkt danych odwraca swoje kolory przy uzyskaniu wartości ujemnej. 

Ten kod C++ demonstruje działanie:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Wyczyść określone wartości punktów danych**

Aspose.Slides dla C++ umożliwia wyczyszczenie danych `DataPoints` dla określonej serii wykresu w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Uzyskaj odniesienie do slajdu przez jego indeks.
3. Uzyskaj odniesienie do wykresu przez jego indeks.
4. Iteruj przez wszystkie `DataPoints` wykresu i ustaw `XValue` oraz `YValue` na null.
5. Wyczyść wszystkie `DataPoints` dla określonej serii wykresu.
6. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten kod C++ demonstruje działanie:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Ustaw szerokość przerwy serii danych**

Aspose.Slides dla C++ umożliwia ustawienie szerokości przerwy serii za pomocą metody **`set_GapWidth()`** w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z danymi domyślnymi.
1. Uzyskaj dostęp do dowolnej serii wykresu.
1. Ustaw właściwość `GapWidth`.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten kod w C++ pokazuje, jak ustawić szerokość przerwy serii:

```cpp
// Tworzy pustą prezentację 
auto presentation = System::MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu prezentacji
auto slide = presentation->get_Slides()->idx_get(0);

// Dodaje wykres z domyślnymi danymi
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Ustawia indeks arkusza danych wykresu
int32_t worksheetIndex = 0;

// Pobiera arkusz danych wykresu
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Dodaje serie
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Dodaje kategorie
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Pobiera drugą serię wykresu
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Wypełnia dane serii
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Ustawia wartość GapWidth
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Zapisuje prezentację na dysku
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Is there a limit to how many series a single chart can contain?**

Aspose.Slides nie nakłada stałego limitu na liczbę serii, które możesz dodać. Praktyczny limit określony jest przez czytelność wykresu oraz dostępność pamięci w twojej aplikacji.

**What if the columns within a cluster are too close together or too far apart?**

Dostosuj ustawienie szerokości przerwy dla tej serii (lub jej grupy serii nadrzędnej). Zwiększenie wartości poszerza odstęp między kolumnami, a zmniejszenie go zbliża kolumny do siebie.