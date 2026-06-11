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
description: "Dostosuj tabele danych wykresów w .NET dla plików PPT i PPTX za pomocą Aspose.Slides, aby zwiększyć wydajność i atrakcyjność prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z tabelami danych wykresu w Aspose.Slides. Pokazuje, jak wyświetlić tabelę danych dla wykresu i dostosować formatowanie tekstu, ustawiając właściwości czcionki, takie jak styl pogrubienia i wysokość czcionki. Przykład demonstruje ładowanie prezentacji, dodawanie wykresu, włączanie tabeli danych wykresu, zastosowanie ustawień czcionki oraz zapis zaktualizowanej prezentacji.

Zawiera również krótkie odpowiedzi na najczęstsze pytania dotyczące wyświetlania kluczy legendy w tabeli danych wykresu, zachowywania tabeli danych podczas eksportu, pracy z wykresami ładowanymi z istniejących prezentacji lub szablonów oraz identyfikacji wykresów, w których tabela danych jest włączona.

## **Ustaw właściwości czcionki dla tabeli danych wykresu**

Aspose.Slides dla .NET zapewnia obsługę zmiany koloru kategorii w kolorze serii.

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Dodaj wykres na slajdzie.
3. Ustaw tabelę wykresu.
4. Ustaw wysokość czcionki.
5. Zapisz zmodyfikowaną prezentację.

Poniżej podano przykład.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę wyświetlać małe klucze legendy obok wartości w tabeli danych wykresu?**

Tak. Tabela danych obsługuje [klucze legendy](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/datatable/showlegendkey/), i możesz je włączać lub wyłączać.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres jako część slajdu, więc wyeksportowane [PDF](/slides/pl/net/convert-powerpoint-to-pdf/)/[HTML](/slides/pl/net/convert-powerpoint-to-html/)/[obraz](/slides/pl/net/convert-powerpoint-to-png/) zawiera wykres wraz z jego tabelą danych.

**Czy tabele danych są obsługiwane dla wykresów pochodzących z pliku szablonu?**

Tak. Dla każdego wykresu załadowanego z istniejącej prezentacji lub szablonu możesz sprawdzić i zmienić, czy tabela danych [jest wyświetlana](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/hasdatatable/) za pomocą właściwości wykresu.

**Jak szybko znaleźć, które wykresy w pliku mają włączoną tabelę danych?**

Sprawdź właściwość każdego wykresu wskazującą, czy tabela danych [jest wyświetlana](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/hasdatatable/), i przeiteruj slajdy, aby zidentyfikować wykresy, w których jest włączona.