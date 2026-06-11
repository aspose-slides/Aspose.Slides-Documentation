---
title: Zarządzanie seriami danych wykresu w prezentacjach w .NET
linktitle: Serie danych
type: docs
url: /pl/net/chart-series/
keywords:
- serie wykresu
- nakładanie serii
- kolor serii
- kolor kategorii
- nazwa serii
- punkt danych
- odstęp serii
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresów w C# dla PowerPoint (PPT/PPTX) przy użyciu praktycznych przykładów kodu i najlepszych praktyk, aby wzmocnić prezentacje danych."
---
## **Omówienie**

Ten artykuł opisuje rolę [ChartSeries](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartseries/) w Aspose.Slides for .NET, koncentrując się na tym, jak dane są strukturyzowane i wizualizowane w prezentacjach. Obiekty te zapewniają podstawowe elementy definiujące poszczególne zestawy punktów danych, kategorie i parametry wyglądu wykresu. Pracując z [ChartSeries](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartseries/), programiści mogą płynnie integrować źródła danych i zachować pełną kontrolę nad tym, jak informacje są wyświetlane, co prowadzi do dynamicznych, opartych na danych prezentacji jasno przekazujących wnioski i analizy.

Seria to wiersz lub kolumna liczb wykreślona na wykresie.

![seria-wykresu-powerpoint](chart-series-powerpoint.png)

## **Ustaw nakładanie serii wykresu**

Właściwość [IChartSeriesOverlap](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichartseries/properties/overlap) kontroluje, jak słupki i kolumny zachodzą na siebie w wykresie 2D, określając zakres od -100 do 100. Ponieważ właściwość ta jest powiązana z grupą serii, a nie z pojedynczą serią wykresu, jest ona tylko do odczytu na poziomie serii. Aby skonfigurować wartości nakładania, użyj właściwości odczytu/zapisu `ParentSeriesGroup.Overlap`, która stosuje określone nakładanie do wszystkich serii w tej grupie.

Poniżej znajduje się przykład w C#, który demonstruje, jak utworzyć prezentację, dodać wykres kolumn grupowany, uzyskać dostęp do pierwszej serii wykresu, skonfigurować ustawienie nakładania, a następnie zapisać wynik jako plik PPTX:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj wykres kolumnowy grupowany z domyślnymi danymi.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Ustaw nakładanie serii.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Zapisz plik prezentacji na dysku.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Nakładanie serii](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Aspose.Slides umożliwia łatwe dostosowanie kolorów wypełnienia serii wykresu, pozwalając podkreślić konkretne punkty danych i tworzyć wizualnie atrakcyjne wykresy. Jest to realizowane za pomocą obiektu [IFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/iformat/), który obsługuje różne typy wypełnień, konfiguracje kolorów i inne zaawansowane opcje stylizacji. Po dodaniu wykresu do slajdu i uzyskaniu dostępu do żądanej serii, wystarczy pobrać serię i zastosować odpowiedni kolor wypełnienia. Oprócz jednolitych wypełnień możesz również wykorzystać wypełnienia gradientowe lub wzorcowe, aby zwiększyć elastyczność projektu. Po ustawieniu kolorów zgodnie z wymaganiami, zapisz prezentację, aby sfinalizować zaktualizowany wygląd.

Poniższy przykład w C# pokazuje, jak zmienić kolor pierwszej serii:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj wykres kolumnowy grupowany z domyślnymi danymi.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Ustaw kolor pierwszej serii.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Zapisz plik prezentacji na dysku.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Kolor serii](series_color.png)

## **Zmień nazwę serii**

Aspose.Slides oferuje prosty sposób modyfikacji nazw serii wykresu, ułatwiając etykietowanie danych w sposób jasny i znaczący. Uzyskując dostęp do odpowiedniej komórki arkusza w danych wykresu, programiści mogą dostosować sposób prezentacji danych. Modyfikacja ta jest szczególnie przydatna, gdy nazwy serii wymagają aktualizacji lub wyjaśnienia w kontekście danych. Po zmianie nazwy serii prezentację można zapisać, aby utrwalić zmiany.

Poniżej znajduje się fragment kodu w C#, demonstrujący ten proces w praktyce.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj wykres kolumnowy grupowany z domyślnymi danymi.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Ustaw nazwę pierwszej serii.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Zapisz plik prezentacji na dysku.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Poniższy kod w C# pokazuje alternatywny sposób zmiany nazwy serii:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj wykres kolumnowy grupowany z domyślnymi danymi.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Ustaw nazwę pierwszej serii.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Zapisz plik prezentacji na dysku.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Nazwa serii](series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

Aspose.Slides for .NET umożliwia pobranie automatycznego koloru wypełnienia dla serii wykresu w obszarze wykresu. Po utworzeniu instancji klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), możesz uzyskać odniesienie do żądanego slajdu według indeksu, a następnie dodać wykres przy użyciu wybranego typu (takiego jak `ChartType.ClusteredColumn`). Dostając się do serii w wykresie, możesz odczytać automatyczny kolor wypełnienia.

Poniższy kod w C# szczegółowo demonstruje ten proces.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj wykres kolumnowy grupowany z domyślnymi danymi.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Pobierz kolor wypełnienia serii.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Wyjście:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Gdy Twoja seria danych zawiera zarówno wartości dodatnie, jak i ujemne, jednolite kolorowanie każdej kolumny lub słupka może utrudniać odczyt wykresu. Aspose.Slides for .NET pozwala przypisać odwrócony kolor wypełnienia — osobne wypełnienie stosowane automatycznie do punktów danych poniżej zera — dzięki czemu wartości ujemne wyróżniają się od razu. W tej sekcji dowiesz się, jak włączyć tę opcję, wybrać odpowiedni kolor i zapisać zaktualizowaną prezentację.

Poniższy przykład kodu demonstruje to działanie:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Dodaj nowe kategorie.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Dodaj nową serię.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Wypełnij dane serii.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Ustaw ustawienia koloru dla serii.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Odwrócony jednolity kolor wypełnienia](inverted_solid_fill_color.png)

Możesz odwrócić kolor wypełnienia dla pojedynczego punktu danych, a nie całej serii. Wystarczy uzyskać dostęp do żądanego `IChartDataPoint` i ustawić jego właściwość `InvertIfNegative` na true.

Poniższy przykład kodu pokazuje, jak to zrobić:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Odwróć kolor, jeśli punkt danych o indeksie 2 jest ujemny.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Wyczyść wartości konkretnych punktów danych**

Czasami wykres zawiera wartości testowe, odchylenia lub przestarzałe wpisy, które trzeba usunąć bez przebudowy całej serii. Aspose.Slides for .NET umożliwia wybranie dowolnego punktu danych według indeksu, wyczyszczenie jego zawartości i natychmiastowe odświeżenie wykresu, dzięki czemu pozostałe punkty przesuwają się, a osie skalują automatycznie.

Poniższy przykład kodu demonstruje tę operację:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Ustaw szerokość przerwy serii**

Szerokość przerwy kontroluje ilość pustej przestrzeni między sąsiadującymi kolumnami lub słupkami — większe przerwy podkreślają poszczególne kategorie, a węższe tworzą bardziej zwartą, skondensowaną wizualizację. Dzięki Aspose.Slides for .NET możesz precyzyjnie dostroić ten parametr dla całej serii, uzyskując dokładnie taki balans wizualny, jakiego wymaga Twoja prezentacja, bez zmiany danych źródłowych.

Poniższy przykład kodu pokazuje, jak ustawić szerokość przerwy dla serii:

```cs
ushort gapWidth = 30;

// Utwórz pustą prezentację.
using (Presentation presentation = new Presentation())
{
    // Uzyskaj dostęp do pierwszego slajdu.
    ISlide slide = presentation.Slides[0];

    // Dodaj wykres z domyślnymi danymi.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Zapisz prezentację na dysku.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Ustaw wartość GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Zapisz prezentację na dysku.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Szerokość przerwy](gap_width.png)

## **FAQ**

**Czy istnieje limit liczby serii, które może zawierać pojedynczy wykres?**

Aspose.Slides nie nakłada stałego limitu na liczbę serii, które można dodać. Praktyczny limit wyznaczany jest przez czytelność wykresu oraz dostępną pamięć aplikacji.

**Co zrobić, gdy kolumny w grupie są zbyt blisko siebie lub zbyt od siebie oddalone?**

Dostosuj ustawienie `GapWidth` dla tej serii (lub jej grupy nadrzędnej). Zwiększenie wartości poszerza odstęp między kolumnami, a zmniejszenie przybliża je do siebie.