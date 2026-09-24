---
title: Dostosuj tabele danych wykresów w prezentacjach przy użyciu Pythona
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
description: "Dostosuj czcionki, obramowania i klucze legendy w tabelach danych wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Aspose.Slides dla Pythona poprzez Java umożliwia wyświetlanie tabeli danych wykresu oraz dostosowywanie formatowania tekstu, obramowań i kluczy legendy. Ten artykuł wyjaśnia, jak włączyć tabelę, sformatować jej tekst, kontrolować każdy rodzaj obramowania oraz pokazywać lub ukrywać klucze legendy. Przykłady zapisują skonfigurowane wykresy w plikach PPTX.

## **Ustaw właściwości czcionki**

Aby wyświetlić tabelę danych wykresu, przekaż `True` do [setDataTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setDataTable). Użyj [getChartDataTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#getChartDataTable), aby uzyskać dostęp do tabeli i skonfigurować formatowanie tekstu.

1. Wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Dodaj wykres kolumnowy grupowany do pierwszego slajdu.
1. Włącz tabelę danych wykresu.
1. Włącz pogrubiony tekst za pomocą [setFontBold](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setFontBold) i przekaż `20` do [setFontHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setFontHeight), aby uzyskać tekst o rozmiarze 20 punktów.
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład wymaga pliku `test.pptx` w katalogu roboczym, zawierającego co najmniej jeden slajd. Dodaje wykres z domyślnymi danymi w pozycji (50, 50), o szerokości 600 punktów i wysokości 400 punktów. Zapisany plik `output.pptx` zawiera wykres z włączoną tabelą danych oraz zastosowanymi określonymi ustawieniami czcionki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostosowanie obramowań tabeli danych**

Włącz tabelę za pomocą [Chart.setDataTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setDataTable) i uzyskaj do niej dostęp poprzez [Chart.getChartDataTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#getChartDataTable). Możesz niezależnie sterować trzema typami obramowań:

- [setBorderHorizontal](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datatable/#setBorderHorizontal) kontroluje poziome obramowania komórek.
- [setBorderVertical](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datatable/#setBorderVertical) kontroluje pionowe obramowania komórek.
- [setBorderOutline](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datatable/#setBorderOutline) kontroluje zewnętrzne obramowanie tabeli.

Przekaż `True` do każdej metody, aby wyświetlić jej obramowanie, lub `False`, aby je ukryć. Poniższy przykład tworzy wykres kolumnowy grupowany z domyślnymi danymi, wyświetla poziome obramowania i zewnętrzne obramowanie oraz ukrywa pionowe obramowania. Nie wymaga pliku wejściowego. Pozycja i rozmiar wykresu są podane w punktach.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poniższe porównanie używa tych samych danych wykresu i ustawienia klucza legendy we wszystkich czterech przypadkach. Zaczynając od włączonych wszystkich obramowań, każdy kolejny wariant wyłącza tylko jedno ustawienie obramowania. Wariant w lewym dolnym rogu odpowiada ustawieniom obramowania w przykładzie.

![Tabele danych wykresu ze wszystkimi włączonymi obramowaniami, bez poziomych obramowań, bez pionowych obramowań i bez obramowania zewnętrznego](data-table-borders.png)

## **Pokaż lub ukryj klucze legendy**

Klucze legendy to małe, kolorowe znaczniki obok nazw serii w tabeli danych. Pomagają czytelnikom dopasować każdy wiersz tabeli do serii wykresu. Przekaż `True` do [setShowLegendKey](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datatable/#setShowLegendKey), aby wyświetlić te znaczniki, lub `False`, aby je ukryć.

Oddzielna legenda wykresu jest kontrolowana przez [Chart.setLegend](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setLegend). Te ustawienia są niezależne: ukrycie oddzielnej legendy nie ukrywa kluczy wewnątrz tabeli danych, a ukrycie kluczy w tabeli nie ukrywa oddzielnej legendy.

Poniższy przykład tworzy wykres z domyślnymi danymi, włącza jego tabelę danych oraz wyświetla klucze legendy w niej, jednocześnie ukrywając oddzielną legendę. Wszystkie obramowania tabeli są wyraźnie włączone. Nie wymaga prezentacji wejściowej. Aby ukryć tylko klucze w tabeli, przekaż `False` do [setShowLegendKey](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poniższe porównanie pokazuje tę samą tabelę z włączonymi i wyłączonymi kluczami legendy. Wszystkie obramowania pozostają włączone, a oddzielna legenda wykresu jest ukryta w obu przypadkach.

![Tabele danych wykresu z kluczami legendy pokazanymi po lewej i ukrytymi po prawej](data-table-legend-keys.png)

## **FAQ**

**Czy mogę wyświetlić klucze legendy w tabeli danych wykresu?**

Tak. Przekaż `True` do [setShowLegendKey](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datatable/#setShowLegendKey), aby wyświetlić klucze legendy, lub `False`, aby je ukryć.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres i wyświetlaną tabelę danych jako część slajdu podczas eksportu do [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/pl/python-java/convert-powerpoint-to-html/), lub [images](/slides/pl/python-java/convert-powerpoint-to-png/).

**Czy mogę pracować z tabelami danych w wykresach ładowanych z szablonu?**

Tak. Dla wykresu wczytanego z istniejącej prezentacji lub szablonu, użyj [hasDataTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#hasDataTable) oraz [setDataTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setDataTable), aby sprawdzić lub zmienić, czy jego tabela danych jest wyświetlana.

**Jak mogę znaleźć wykresy, które mają włączoną tabelę danych?**

Iteruj po kształtach na każdym slajdzie, zidentyfikuj wykresy i wywołaj ich metodę [hasDataTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#hasDataTable). Wartość `True` wskazuje, że tabela danych jest włączona.