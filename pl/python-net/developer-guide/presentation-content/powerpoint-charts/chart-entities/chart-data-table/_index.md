---
title: Dostosuj tabele danych wykresów w Pythonie
linktitle: Tabela danych
type: docs
url: /pl/python-net/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dostosuj tabele danych wykresów w Pythonie dla formatów PPT, PPTX i ODP przy użyciu Aspose.Slides, aby zwiększyć wydajność i atrakcyjność prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z tabelami danych wykresów w Aspose.Slides. Pokazuje, jak wyświetlić tabelę danych dla wykresu i dostosować formatowanie tekstu, ustawiając właściwości czcionki, takie jak pogrubienie i wysokość czcionki. Przykład demonstruje ładowanie prezentacji, dodawanie wykresu, włączanie tabeli danych wykresu, zastosowanie ustawień czcionki i zapisywanie zaktualizowanej prezentacji.

Zawiera także krótkie odpowiedzi na typowe pytania dotyczące wyświetlania kluczy legendy w tabeli danych wykresu, zachowywania tabeli danych podczas eksportu, pracy z wykresami załadowanymi z istniejących prezentacji lub szablonów oraz identyfikowania wykresów, w których tabela danych jest włączona.

## **Ustaw właściwości czcionki dla tabeli danych wykresu**
Aspose.Slides for Python via .NET zapewnia obsługę zmiany koloru kategorii w kolorze serii. 

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Dodaj wykres na slajdzie.
1. ustaw tabelę wykresu.
1. Ustaw wysokość czcionki.
1. Zapisz zmodyfikowaną prezentację.

Poniżej podany jest przykładowy kod. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę wyświetlać małe klucze legendy obok wartości w tabeli danych wykresu?**

Tak. Tabela danych obsługuje [klucze legendy](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datatable/show_legend_key/), i możesz je włączać lub wyłączać.

**Czy tabela danych zostanie zachowana podczas eksportu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres jako część slajdu, więc wyeksportowany [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/)[HTML](/slides/pl/python-net/convert-powerpoint-to-html/)[image](/slides/pl/python-net/convert-powerpoint-to-png/) zawiera wykres wraz z jego tabelą danych.

**Czy tabele danych są obsługiwane dla wykresów pochodzących z pliku szablonu?**

Tak. Dla każdego wykresu załadowanego z istniejącej prezentacji lub szablonu możesz sprawdzić i zmienić, czy tabela danych [is shown](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/has_data_table/) przy użyciu właściwości wykresu.

**Jak szybko znaleźć, które wykresy w pliku mają włączoną tabelę danych?**

Sprawdź właściwość każdego wykresu wskazującą, czy tabela danych [is shown](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/has_data_table/) i przeiteruj slajdy, aby zidentyfikować wykresy, w których jest włączona.