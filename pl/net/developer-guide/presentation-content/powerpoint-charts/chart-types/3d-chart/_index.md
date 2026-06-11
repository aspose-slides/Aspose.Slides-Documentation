---
title: Dostosowywanie wykresów 3D w prezentacjach w .NET
linktitle: Wykres 3D
type: docs
url: /pl/net/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy 3D w Aspose.Slides dla .NET, z obsługą plików PPT i PPTX — zwiększ jakość swoich prezentacji już dziś."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować wykres 3D w Aspose.Slides, konfigurując ustawienia `Rotation3D`, takie jak `RotationX`, `RotationY`, `DepthPercents` i `RightAngleAxes`. Przejmuje proces tworzenia prezentacji, dodawania wykresu 3D z domyślnymi danymi, zastosowania wymaganych ustawień widoku 3D oraz zapisania zmodyfikowanej prezentacji jako plik PPTX.

## **Ustaw właściwości RotationX, RotationY i DepthPercents wykresu 3D**
Aspose.Slides for .NET udostępnia prosty interfejs API do ustawiania tych właściwości. Poniższy artykuł pomoże Ci ustawić różne właściwości, takie jak rotacja X, Y, **DepthPercents** itp. Przykładowy kod zastosowuje ustawienie wymienionych właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Ustaw właściwości Rotation3D.
5. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```c#
// Utwórz instancję klasy Presentation
Presentation presentation = new Presentation();
           
// Uzyskaj dostęp do pierwszego slajdu
ISlide slide = presentation.Slides[0];

// Dodaj wykres z domyślnymi danymi
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Ustawianie indeksu arkusza danych wykresu
int defaultWorksheetIndex = 0;

// Pobieranie arkusza danych wykresu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Dodaj serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Dodaj kategorie
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Ustaw właściwości Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Pobierz drugą serię wykresu
IChartSeries series = chart.ChartData.Series[1];

// Teraz wypełniamy dane serii
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Ustaw wartość OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Zapisz prezentację na dysk
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje 3D warianty wykresów słupkowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100% Stacked Column 3D, wraz z powiązanymi typami 3D udostępnionymi przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/charttype/) w dokumentacji API zainstalowanej wersji.

**Czy mogę uzyskać rastrowy obraz wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres jako obraz za pomocą [chart API](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage/) lub [renderować cały slajd](/slides/pl/net/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebujesz podglądu w pełni odwzorowanego pikselowo lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez wymogu użycia PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od wielkości danych i złożoności wizualnej. Aby uzyskać optymalne wyniki, utrzymuj efekty 3D na minimalnym poziomie, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do wyjścia o odpowiednich rozmiarach (rozdzielczość i wymiary), dopasowanych do docelowego wyświetlacza lub potrzeb druku.