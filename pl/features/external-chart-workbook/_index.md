---
title: Łącz wykresy z zewnętrznymi skoroszytami
description: Połącz dane wykresu ze zewnętrznym skoroszytem i odśwież je.
type: docs
url: /pl/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Przegląd**

Skieruj wykres do zewnętrznego skoroszytu zamiast trzymać wszystkie jego dane źródłowe w osadzonej w prezentacji. Możesz ustawić ścieżkę do skoroszytu i wybrać, czy aktualizować wykres z tego pliku. Zapisany wykres może również zawierać buforowane dane wyświetlania.

## **Przykład użycia**

Ten przykład w C# wykorzystuje Aspose.Slides for .NET. Utwórz prawidłowy skoroszyt sprzedaży z North = 55 i South = 40 i zapisz go jako sales.xlsx obok wyniku. Zresetuj wartość North wykresu do 20, a następnie połącz wykres ze ścieżką bezwzględną do skoroszytu i odśwież: North ponownie wynosi 55. Jawny zakres obejmuje nagłówek i dwa wiersze danych. Utrzymuj plik sales.xlsx dostępny przy ponownym otwieraniu lub aktualizacji połączonego wykresu; prezentacja nie osadza tego zewnętrznego pliku. Nie jest wymagany plik wejściowy. Zapisuje *external-chart-workbook.pptx* i *external-chart-workbook.png*. Zainstaluj bibliotekę, korzystając z [przewodnik instalacji](/slides/pl/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **FAQ**

### **Czy mogę odczytać wszystkie buforowane wartości, gdy powiązany plik jest brakujący?**

Aspose.Slides for .NET 26.11 może [odczytać przechowywane wartości wykresu bezpośrednio](/slides/pl/net/chart-workbook/#read-cached-chart-values-without-a-workbook) bez otwierania powiązanego skoroszytu. Obejmuje to zwykłe wartości, wartości X/Y, rozmiary bąbelków oraz wartości kategorii, gdy takie bufory istnieją. Zbuforowane dane mogą być nieobecne lub przestarzałe; nie jest to pełny skoroszyt. Odświeżanie ze źródła nadal wymaga dostępnego, obsługiwanego skoroszytu. Dla innych SDK i wersji sprawdź ich odpowiedni przewodnik po wykresach.

### **Co się stanie, jeśli zewnętrzny skoroszyt zostanie przeniesiony?**

Zaktualizuj ścieżkę zewnętrznego skoroszytu wykresu do nowej lokalizacji i udostępnij ten plik wszędzie tam, gdzie przetwarzana jest prezentacja. Nie polegaj na buforowanych danych przy pełnych operacjach dostępu do danych, gdy są one nieobecne.

### **Czy mogę wybrać, czy odświeżać buforowane dane wykresu przy łączeniu?**

Tak. Możesz wybrać, czy aktualizować dane wykresu przy ustawianiu łącza. Odświeżanie wymaga dostępnego, obsługiwanego skoroszytu; pominięcie odświeżania zapisuje łącze bez odczytywania nowych wartości z tego pliku.

## **Poradniki**

- [Zarządzanie skoroszytami wykresów w prezentacjach w .NET](/slides/pl/net/chart-workbook/)

Powiązana funkcja: [Wypełniaj edytowalne wykresy danymi](/slides/pl/features/chart-data-binding/).