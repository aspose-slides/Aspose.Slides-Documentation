---
title: Dostosuj tabele danych wykresów w prezentacjach przy użyciu Javy
linktitle: Tabela danych
type: docs
url: /pl/java/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dostosuj tabele danych wykresów w Javie dla plików PPT i PPTX przy użyciu Aspose.Slides, aby zwiększyć efektywność i atrakcyjność prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z tabelami danych wykresu w Aspose.Slides. Pokazuje, jak wyświetlić tabelę danych dla wykresu i dostosować formatowanie tekstu, ustawiając właściwości czcionki, takie jak styl pogrubienia i wysokość czcionki. Przykład demonstruje wczytanie prezentacji, dodanie wykresu, włączenie tabeli danych wykresu, zastosowanie ustawień czcionki oraz zapis zaktualizowanej prezentacji.

Zawiera również krótkie odpowiedzi na często zadawane pytania dotyczące wyświetlania kluczy legendy w tabeli danych wykresu, zachowywania tabeli danych podczas eksportu, pracy z wykresami wczytanymi z istniejących prezentacji lub szablonów oraz identyfikacji wykresów, w których tabela danych jest włączona.

## **Ustaw właściwości czcionki dla tabeli danych wykresu**
Aspose.Slides for Java zapewnia wsparcie dla zmiany koloru kategorii w kolorze serii.  

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Ustaw tabelę wykresu.
1. Ustaw wysokość czcionki.
1. Zapisz zmodyfikowaną prezentację.

Poniżej znajduje się przykładowy kod.  

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

**Czy mogę wyświetlać małe klucze legendy obok wartości w tabeli danych wykresu?**

Tak. Tabela danych obsługuje [klucze legendy](https://reference.aspose.com/slides/pl/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), i możesz je włączyć lub wyłączyć.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres jako część slajdu, więc wyeksportowany [PDF](/slides/pl/java/convert-powerpoint-to-pdf/)/[HTML](/slides/pl/java/convert-powerpoint-to-html/)/[image](/slides/pl/java/convert-powerpoint-to-png/) zawiera wykres z jego tabelą danych.

**Czy tabele danych są obsługiwane dla wykresów pochodzących z pliku szablonu?**

Tak. Dla każdego wykresu wczytanego z istniejącej prezentacji lub szablonu możesz sprawdzić i zmienić, czy tabela danych [jest wyświetlana](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/#hasDataTable--) za pomocą właściwości wykresu.

**Jak szybko znaleźć, które wykresy w pliku mają włączoną tabelę danych?**

Sprawdź właściwość każdego wykresu, która wskazuje, czy tabela danych [jest wyświetlana](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/#hasDataTable--), i przeiteruj slajdy, aby zidentyfikować wykresy, w których jest włączona.