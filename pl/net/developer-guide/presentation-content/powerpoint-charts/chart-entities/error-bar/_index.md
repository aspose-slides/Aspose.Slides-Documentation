---
title: Dostosowywanie pasków błędów w wykresach prezentacji w .NET
linktitle: Pasek błędu
type: docs
url: /pl/net/error-bar/
keywords:
- pasek błędu
- wartość niestandardowa
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak dodawać i dostosowywać paski błędów w wykresach przy użyciu Aspose.Slides dla .NET — optymalizuj wizualizacje danych w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z paskami błędów w wykresach prezentacji przy użyciu Aspose.Slides. Pokazuje, jak dodać paski błędów do serii wykresu, skonfigurować ustawienia pasków błędów X i Y oraz zastosować różne typy wartości, takie jak stałe, procentowe i niestandardowe.

Prezentuje także, jak przypisać niestandardowe wartości pasków błędów do pojedynczych punktów danych w serii, korzystając z odpowiedniej kolekcji punktów danych. Dodatkowo artykuł zawiera krótkie notatki na temat zachowania pasków błędów podczas eksportu, ich kompatybilności ze znacznikami i etykietami danych oraz gdzie znaleźć powiązane klasy i wyliczenia w referencji API.

## **Dodaj paski błędów**
Aspose.Slides for .NET udostępnia prosty interfejs API do zarządzania wartościami pasków błędów. Przykładowy kod ma zastosowanie przy użyciu typu wartości niestandardowej. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** określonego punktu danych w kolekcji **DataPoints** serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów Y.
1. Ustaw wartości i format pasków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```c#
// Tworzenie pustej prezentacji
using (Presentation presentation = new Presentation())
{
    // Tworzenie wykresu bąbelkowego
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Dodawanie pasków błędów i ustawianie ich formatu
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Zapisywanie prezentacji
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```



## **Dodaj niestandardowe wartości pasków błędów**
Aspose.Slides for .NET udostępnia prosty interfejs API do zarządzania niestandardowymi wartościami pasków błędów. Przykładowy kod ma zastosowanie, gdy właściwość **IErrorBarsFormat.ValueType** jest równa **Custom**. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** określonego punktu danych w kolekcji **DataPoints** serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów Y.
1. Uzyskaj dostęp do pojedynczych punktów danych serii wykresu i ustaw wartości pasków błędów dla poszczególnych punktów.
1. Ustaw wartości i format pasków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```c#
// Tworzenie pustej prezentacji
using (Presentation presentation = new Presentation())
{
    // Tworzenie wykresu bąbelkowego
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Dodawanie niestandardowych pasków błędów i ustawianie ich formatu
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Dostęp do punktu danych serii wykresu i ustawianie wartości pasków błędów dla pojedynczego punktu
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Ustawianie pasków błędów dla punktów serii wykresu
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Zapisywanie prezentacji
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Co się dzieje z paskami błędów podczas eksportu prezentacji do PDF lub obrazów?**

Są renderowane jako część wykresu i zachowywane podczas konwersji wraz z resztą formatowania wykresu, zakładając kompatybilną wersję lub renderer.

**Czy paski błędów można łączyć ze znacznikami i etykietami danych?**

Tak. Paski błędów są oddzielnym elementem i są kompatybilne ze znacznikami i etykietami danych; jeśli elementy nakładają się na siebie, może być konieczne dostosowanie formatowania.

**Gdzie mogę znaleźć listę właściwości i wyliczeń do pracy z paskami błędów w API?**

W dokumentacji API: klasa [ErrorBarsFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/errorbarsformat/) oraz powiązane wyliczenia [ErrorBarType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/errorbartype/) i [ErrorBarValueType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/errorbarvaluetype/).