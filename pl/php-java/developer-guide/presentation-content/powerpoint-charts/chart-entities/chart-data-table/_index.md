---
title: Dostosuj tabele danych wykresu w prezentacjach przy użyciu PHP
linktitle: Tabela danych
type: docs
url: /pl/php-java/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dostosuj tabele danych wykresu dla formatów PPT i PPTX za pomocą Aspose.Slides dla PHP via Java, aby zwiększyć wydajność i atrakcyjność prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z tabelami danych wykresu w Aspose.Slides. Pokazuje, jak wyświetlić tabelę danych dla wykresu i dostosować formatowanie tekstu, ustawiając właściwości czcionki, takie jak styl pogrubienia i wysokość czcionki. Przykład demonstruje ładowanie prezentacji, dodawanie wykresu, włączanie tabeli danych wykresu, zastosowanie ustawień czcionki oraz zapisanie zaktualizowanej prezentacji.

Zawiera również krótkie odpowiedzi na często zadawane pytania dotyczące wyświetlania kluczy legendy w tabeli danych wykresu, zachowywania tabeli danych podczas eksportu, pracy z wykresami wczytanymi z istniejących prezentacji lub szablonów oraz identyfikowania wykresów, w których tabela danych jest włączona.

## **Ustawienie właściwości czcionki dla tabeli danych wykresu**
Aspose.Slides for PHP via Java zapewnia wsparcie dla zmiany koloru kategorii w kolorze serii.  

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Ustaw tabelę wykresu.
1. Ustaw wysokość czcionki.
1. Zapisz zmodyfikowaną prezentację.

Poniżej podano przykładowy kod.  

```php
  # Tworzenie pustej prezentacji
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę wyświetlać małe klucze legendy obok wartości w tabeli danych wykresu?**

Tak. Tabela danych obsługuje [legend keys](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datatable/setshowlegendkey/), a ich wyświetlanie można włączyć lub wyłączyć.

**Czy tabela danych zostanie zachowana podczas eksportu prezentacji do formatu PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres jako część slajdu, więc wyeksportowane [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/pl/php-java/convert-powerpoint-to-html/)/[image](/slides/pl/php-java/convert-powerpoint-to-png/) zawiera wykres wraz z jego tabelą danych.

**Czy tabele danych są obsługiwane dla wykresów pochodzących z pliku szablonu?**

Tak. Dla każdego wykresu wczytanego z istniejącej prezentacji lub szablonu można sprawdzić i zmienić, czy tabela danych jest [wyświetlana](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/hasdatatable/) za pomocą właściwości wykresu.

**Jak szybko znaleźć, które wykresy w pliku mają włączoną tabelę danych?**

Sprawdź właściwość każdego wykresu, która wskazuje, czy tabela danych jest [wyświetlana](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/hasdatatable/), i przeiteruj slajdy, aby zidentyfikować wykresy, w których jest włączona.