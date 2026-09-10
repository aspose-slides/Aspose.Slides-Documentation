---
title: Dostosowywanie tabel danych wykresów w prezentacjach przy użyciu Pythona
linktitle: Tabela danych
type: docs
url: /pl/python-java/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dostosuj tabele danych wykresów w Pythonie dla plików PPT i PPTX za pomocą Aspose.Slides for Python via Java, aby zwiększyć wydajność i atrakcyjność prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z tabelami danych wykresów w Aspose.Slides. Pokazuje, jak wyświetlić tabelę danych dla wykresu i dostosować formatowanie tekstu, ustawiając właściwości czcionki, takie jak styl pogrubienia i wysokość czcionki. Przykład demonstruje tworzenie prezentacji, dodawanie wykresu, włączenie tabeli danych wykresu, zastosowanie ustawień czcionki oraz zapis zmodyfikowanej prezentacji.

Zawiera także krótkie odpowiedzi na najczęstsze pytania dotyczące wyświetlania kluczy legendy w tabeli danych wykresu, zachowania tabeli danych podczas eksportu, pracy z wykresami załadowanymi z istniejących prezentacji lub szablonów oraz identyfikacji wykresów, w których tabela danych jest włączona.

## **Ustaw właściwości czcionki dla tabeli danych wykresu**

Aspose.Slides for Python via Java pozwala wyświetlić tabelę danych wykresu oraz zmienić właściwości czcionki jego tekstu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Dodaj wykres do slajdu.
1. Pokaż tabelę danych wykresu.
1. Ustaw styl pogrubienia i wysokość czcionki tekstu w tabeli danych.
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład demonstruje te kroki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Utwórz pustą prezentację.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę wyświetlać małe klucze legendy obok wartości w tabeli danych wykresu?**

Tak. Tabela danych obsługuje [klucze legendy](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datatable/#setShowLegendKey) i można je włączać lub wyłączać.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do formatu PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres jako część slajdu, więc wyeksportowany [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/pl/python-java/convert-powerpoint-to-html/)/[image](/slides/pl/python-java/convert-powerpoint-to-png/) zawiera wykres wraz z jego tabelą danych.

**Czy tabele danych są obsługiwane dla wykresów pochodzących z pliku szablonu?**

Tak. Dla każdego wykresu załadowanego z istniejącej prezentacji lub szablonu można sprawdzić i zmienić, czy tabela danych [jest wyświetlana](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#hasDataTable), korzystając z właściwości wykresu.

**Jak szybko znaleźć, które wykresy w pliku mają włączoną tabelę danych?**

Sprawdź właściwość każdego wykresu wskazującą, czy tabela danych [jest wyświetlana](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#hasDataTable), i przeiteruj slajdy, aby zidentyfikować wykresy, w których jest włączona.