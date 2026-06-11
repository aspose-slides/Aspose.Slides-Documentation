---
title: Dostosowywanie tabel danych wykresów w prezentacjach na Androidzie
linktitle: Tabela danych
type: docs
url: /pl/androidjava/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dostosuj tabele danych wykresów w Javie dla PPT i PPTX za pomocą Aspose.Slides dla Androida, aby zwiększyć wydajność i atrakcyjność prezentacji."
---
## **Overview**

Ten artykuł wyjaśnia, jak pracować z tabelami danych wykresów w Aspose.Slides. Pokazuje, jak wyświetlić tabelę danych dla wykresu i dostosować formatowanie tekstu, ustawiając właściwości czcionki, takie jak pogrubienie i wysokość czcionki. Przykład demonstruje ładowanie prezentacji, dodawanie wykresu, włączenie tabeli danych wykresu, zastosowanie ustawień czcionki oraz zapis zaktualizowanej prezentacji.

## **Set Font Properties for a Chart Data Table**
Aspose.Slides dla Androidu za pośrednictwem Java zapewnia wsparcie dla zmiany koloru kategorii w serii.

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Ustaw tabelę wykresu.
1. Ustaw wysokość czcionki.
1. Zapisz zmodyfikowaną prezentację.

Poniżej podany jest przykładowy kod.

```java
// Tworzenie pustej prezentacji
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

Tak. Tabela danych obsługuje [legend keys](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), i możesz je włączać lub wyłączać.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Tak. Aspose.Slides renderuje wykres jako część slajdu, więc wyeksportowany [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/pl/androidjava/convert-powerpoint-to-html/)/[image](/slides/pl/androidjava/convert-powerpoint-to-png/) zawiera wykres z jego tabelą danych.

**Are data tables supported for charts that come from a template file?**

Tak. Dla każdego wykresu załadowanego z istniejącej prezentacji lub szablonu możesz sprawdzić i zmienić, czy tabela danych [is shown](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chart/#hasDataTable--) używając właściwości wykresu.

**How can I quickly find which charts in a file have the data table enabled?**

Sprawdź właściwość każdego wykresu wskazującą, czy tabela danych [is shown](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chart/#hasDataTable--) i przeiteruj slajdy, aby zidentyfikować wykresy, w których jest włączona.