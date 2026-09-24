---
title: Dostosuj tabele danych wykresów w prezentacjach w .NET
linktitle: Tabela danych
type: docs
url: /pl/net/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dostosuj czcionki, obramowania i klucze legendy w tabelach danych wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET i C#."
---
## **Przegląd**

Aspose.Slides for .NET umożliwia wyświetlanie tabeli danych wykresu oraz dostosowywanie formatowania tekstu, obramowań i kluczy legendy. Ten artykuł wyjaśnia, jak włączyć tabelę, sformatować jej tekst, kontrolować każdy typ obramowania oraz pokazać lub ukryć klucze legendy. Przykłady zapisują skonfigurowane wykresy w plikach PPTX.

## **Ustaw właściwości czcionki**

Aby wyświetlić tabelę danych wykresu, ustaw [HasDataTable](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/hasdatatable/) na `true`. Użyj [ChartDataTable](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/chartdatatable/), aby uzyskać dostęp do tabeli i skonfigurować formatowanie tekstu.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Dodaj skumulowany wykres kolumnowy do pierwszego slajdu.
1. Włącz tabelę danych wykresu.
1. Włącz pogrubiony tekst za pomocą [FontBold](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/fontbold/) i ustaw [FontHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/fontheight/) na `20`, aby uzyskać czcionkę 20 punktów.
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład wymaga pliku `test.pptx` w katalogu roboczym z co najmniej jednym slajdem. Dodaje wykres z domyślnymi danymi w pozycji (50, 50), o szerokości 600 punktów i wysokości 400 punktów. Zapisany plik `output.pptx` zawiera wykres z włączoną tabelą danych oraz zastosowanymi ustawieniami czcionki.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Dostosuj obramowania tabeli danych**

Włącz tabelę za pomocą [IChart.HasDataTable](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/hasdatatable/) i uzyskaj do niej dostęp przez [IChart.ChartDataTable](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/chartdatatable/). Możesz niezależnie sterować trzema typami obramowań:

- [HasBorderHorizontal](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatatable/hasborderhorizontal/) kontroluje poziome obramowania komórek.
- [HasBorderVertical](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatatable/hasbordervertical/) kontroluje pionowe obramowania komórek.
- [HasBorderOutline](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatatable/hasborderoutline/) kontroluje zewnętrzne obramowanie tabeli.

Ustaw każdą właściwość na `true`, aby wyświetlić obramowanie, lub na `false`, aby je ukryć. Poniższy przykład tworzy skumulowany wykres kolumnowy z domyślnymi danymi, wyświetla poziome obramowania i obramowanie zewnętrzne, a ukrywa pionowe obramowania. Nie wymaga pliku wejściowego. Pozycja i rozmiar wykresu są podane w punktach.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Poniższe porównanie używa tych samych danych wykresu i ustawień klucza legendy we wszystkich czterech przypadkach. Zaczynając od włączonych wszystkich obramowań, każda kolejna wariacja wyłącza jedną właściwość obramowania. Wariant w lewym dolnym rogu odpowiada ustawieniom obramowań z przykładu.

![Wykresy z tabelą danych ze wszystkimi obramowaniami włączonymi, bez poziomych obramowań, bez pionowych obramowań i bez obramowania zewnętrznego](data-table-borders.png)

## **Pokaż lub ukryj klucze legendy**

Klucze legendy to małe kolorowe znaczniki obok nazw serii w tabeli danych. Pomagają czytelnikom dopasować każdy wiersz tabeli do serii wykresu. Ustaw [ShowLegendKey](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/idatatable/showlegendkey/) na `true`, aby pokazać te znaczniki, lub na `false`, aby je ukryć.

Oddzielna legenda wykresu jest kontrolowana przez [IChart.HasLegend](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/haslegend/). Ustawienia te są niezależne: ukrycie oddzielnej legendy nie ukrywa kluczy wewnątrz tabeli danych, a ukrycie kluczy w tabeli nie ukrywa oddzielnej legendy.

Poniższy przykład tworzy wykres z domyślnymi danymi, włącza jego tabelę danych i pokazuje klucze legendy w niej, jednocześnie ukrywając oddzielną legendę. Wszystkie obramowania tabeli są jawnie włączone. Nie jest wymagana żadna prezentacja wejściowa. Aby ukryć tylko klucze tabeli, zmień `dataTable.ShowLegendKey` na `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Poniższe porównanie pokazuje tę samą tabelę z włączonymi i wyłączonymi kluczami legendy. Wszystkie obramowania pozostają włączone, a oddzielna legenda wykresu jest ukryta w obu przypadkach.

![Wykresy z tabelą danych z kluczami legendy pokazanymi po lewej i ukrytymi po prawej](data-table-legend-keys.png)

## **FAQ**

**Czy mogę wyświetlać klucze legendy w tabeli danych wykresu?**

Tak. Ustaw [ShowLegendKey](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/datatable/showlegendkey/) na `true`, aby wyświetlić klucze legendy, lub na `false`, aby je ukryć.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres i wyświetlaną tabelę danych jako część slajdu przy eksportowaniu do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), [HTML](/slides/pl/net/convert-powerpoint-to-html/) lub [obrazów](/slides/pl/net/convert-powerpoint-to-png/).

**Czy mogę pracować z tabelami danych w wykresach wczytanych z szablonu?**

Tak. Dla wykresu wczytanego z istniejącej prezentacji lub szablonu użyj [HasDataTable](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/hasdatatable/), aby sprawdzić lub zmienić, czy jego tabela danych jest wyświetlana.

**Jak mogę znaleźć wykresy, które mają włączoną tabelę danych?**

Iteruj kształty na każdym slajdzie, zidentyfikuj wykresy i sprawdź ich właściwość [HasDataTable](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/hasdatatable/). Wartość `true` wskazuje, że tabela danych jest włączona.