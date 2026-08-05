---
title: Dostosuj tabele danych wykresów w prezentacjach przy użyciu C++
linktitle: Tabela danych
type: docs
url: /pl/cpp/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dostosuj tabele danych wykresów w C++ dla PPT i PPTX za pomocą Aspose.Slides, aby zwiększyć wydajność i atrakcyjność prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z tabelami danych wykresów w Aspose.Slides. Pokazuje, jak wyświetlić tabelę danych dla wykresu i dostosować formatowanie tekstu, ustawiając właściwości czcionki, takie jak pogrubiona styl i wysokość czcionki. Przykład demonstruje wczytywanie prezentacji, dodawanie wykresu, włączenie tabeli danych wykresu, zastosowanie ustawień czcionki oraz zapis zaktualizowanej prezentacji.

## **Ustaw właściwości czcionki dla tabeli danych wykresu**
Aspose.Slides dla C++ umożliwia zmianę właściwości czcionki w tabeli danych wykresu.  

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Dodaj wykres na slajdzie.
1. Ustaw tabelę wykresu.
1. Ustaw wysokość czcionki.
1. Zapisz zmodyfikowaną prezentację.

Poniżej podany jest przykładowy kod.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę wyświetlić małe klucze legendy obok wartości w tabeli danych wykresu?**

Tak. Tabela danych obsługuje [klucze legendy](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/datatable/set_showlegendkey/), i można je włączać lub wyłączać.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres jako część slajdu, więc wyeksportowany [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/pl/cpp/convert-powerpoint-to-html/)/[image](/slides/pl/cpp/convert-powerpoint-to-png/) zawiera wykres wraz z jego tabelą danych.

**Czy tabele danych są obsługiwane dla wykresów pochodzących z pliku szablonu?**

Tak. Dla każdego wykresu wczytanego z istniejącej prezentacji lub szablonu można sprawdzić i zmienić, czy tabela danych jest wyświetlana, używając właściwości wykresu [jest wyświetlana](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chart/set_hasdatatable/).

**Jak szybko znaleźć, które wykresy w pliku mają włączoną tabelę danych?**

Sprawdź właściwość każdego wykresu, która wskazuje, czy tabela danych jest wyświetlana [jest wyświetlana](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chart/get_hasdatatable/), i przeiteruj slajdy, aby zidentyfikować wykresy, w których jest włączona.