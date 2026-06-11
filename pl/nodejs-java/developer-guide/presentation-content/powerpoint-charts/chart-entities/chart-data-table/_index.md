---
title: Dostosuj tabele danych wykresów w prezentacjach przy użyciu JavaScript
linktitle: Tabela danych
type: docs
url: /pl/nodejs-java/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dostosuj tabele danych wykresów w JavaScript dla plików PPT i PPTX przy użyciu Aspose.Slides dla Node.js via Java, aby zwiększyć wydajność i atrakcyjność prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z tabelami danych wykresów w Aspose.Slides. Pokazuje, jak wyświetlić tabelę danych wykresu i dostosować formatowanie tekstu, ustawiając właściwości czcionki, takie jak pogrubienie i wysokość czcionki. Przykład demonstruje wczytywanie prezentacji, dodawanie wykresu, włączanie tabeli danych wykresu, stosowanie ustawień czcionki oraz zapisywanie zaktualizowanej prezentacji.

Zawiera również krótkie odpowiedzi na często zadawane pytania dotyczące wyświetlania kluczy legendy w tabeli danych wykresu, zachowywania tabeli danych podczas eksportu, pracy z wykresami wczytanymi z istniejących prezentacji lub szablonów oraz identyfikowania wykresów, w których tabela danych jest włączona.

## **Ustawienia właściwości czcionki dla tabeli danych wykresu**

Aspose.Slides dla Node.js via Java zapewnia wsparcie dla zmiany koloru kategorii w serii kolorów.

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Ustaw tabelę wykresu.
1. Ustaw wysokość czcionki.
1. Zapisz zmodyfikowaną prezentację.

Poniżej podano przykładowy kod.

```javascript
// Tworzenie pustej prezentacji
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę wyświetlać małe klucze legendy obok wartości w tabeli danych wykresu?**

Tak. Tabela danych obsługuje [legend keys](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/datatable/setshowlegendkey/), i możesz je włączać lub wyłączać.

**Czy tabela danych zostanie zachowana podczas eksportu prezentacji do formatu PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres jako część slajdu, więc wyeksportowany [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/pl/nodejs-java/convert-powerpoint-to-png/) zawiera wykres wraz z jego tabelą danych.

**Czy tabele danych są obsługiwane dla wykresów pochodzących z pliku szablonu?**

Tak. Dla każdego wykresu wczytanego z istniejącej prezentacji lub szablonu możesz sprawdzić i zmienić, czy tabela danych [jest wyświetlana](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/hasdatatable/) za pomocą właściwości wykresu.

**Jak szybko znaleźć, które wykresy w pliku mają włączoną tabelę danych?**

Sprawdź właściwość każdego wykresu wskazującą, czy tabela danych [jest wyświetlana](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/hasdatatable/) i przeiteruj slajdy, aby zidentyfikować wykresy, w których jest włączona.