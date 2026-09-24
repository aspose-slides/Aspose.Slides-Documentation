---
title: Dostosuj tabele danych wykresów w prezentacjach w Pythonie
linktitle: Tabela danych
type: docs
url: /pl/python-net/chart-data-table/
keywords:
- dane wykresu
- tabela danych
- właściwości czcionki
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dostosuj czcionki, obramowania i klucze legendy tabeli danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Przegląd**

Aspose.Slides for Python via .NET umożliwia wyświetlanie tabeli danych wykresu oraz dostosowywanie formatowania tekstu, obramowań i kluczy legendy. W tym artykule wyjaśniono, jak włączyć tabelę, sformatować jej tekst, kontrolować każdy rodzaj obramowania oraz pokazać lub ukryć klucze legendy. Przykłady zapisują skonfigurowane wykresy w plikach PPTX.

## **Ustaw właściwości czcionki**

Aby wyświetlić tabelę danych wykresu, ustaw [has_data_table](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/has_data_table/) na `True`. Użyj [chart_data_table](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/chart_data_table/), aby uzyskać dostęp do tabeli i skonfigurować formatowanie tekstu.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Dodaj wykres kolumnowy skumulowany do pierwszego slajdu.
1. Włącz tabelę danych wykresu.
1. Włącz pogrubiony tekst za pomocą [font_bold](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/font_bold/) i ustaw [font_height](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/font_height/) na `20`, aby uzyskać tekst o rozmiarze 20 punktów.
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład wymaga pliku `test.pptx` w bieżącym katalogu, zawierającego przynajmniej jeden slajd. Dodaje wykres z domyślnymi danymi w pozycji (50, 50), o szerokości 600 punktów i wysokości 400 punktów. Zapisany plik `output.pptx` zawiera wykres z włączoną tabelą danych oraz zastosowanymi określonymi ustawieniami czcionki.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostosuj obramowania tabeli danych**

Włącz tabelę przy użyciu [Chart.has_data_table](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/has_data_table/) i uzyskaj do niej dostęp przez [Chart.chart_data_table](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/chart_data_table/). Możesz niezależnie kontrolować trzy rodzaje obramowań:

- [has_border_horizontal](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datatable/has_border_horizontal/) kontroluje poziome obramowania komórek.
- [has_border_vertical](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datatable/has_border_vertical/) kontroluje pionowe obramowania komórek.
- [has_border_outline](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datatable/has_border_outline/) kontroluje zewnętrzne obramowanie tabeli.

Ustaw każdą właściwość na `True`, aby wyświetlić jej obramowanie, lub na `False`, aby je ukryć. Poniższy przykład tworzy wykres kolumnowy skumulowany z domyślnymi danymi, wyświetla poziome obramowania oraz obramowanie zewnętrzne, a ukrywa pionowe obramowania. Nie wymaga pliku wejściowego. Pozycja i rozmiar wykresu są określone w punktach.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Poniższe porównanie używa tych samych danych wykresu i ustawienia klucza legendy we wszystkich czterech przypadkach. Zaczynając od włączonych wszystkich obramowań, każda kolejna wariacja wyłącza tylko jedną właściwość obramowania. Wariant w lewym dolnym rogu odpowiada ustawieniom obramowań w przykładzie.

![Tabele danych wykresu z włączonymi wszystkimi obramowaniami, bez poziomych obramowań, bez pionowych obramowań i bez obramowania zewnętrznego](data-table-borders.png)

## **Pokaż lub ukryj klucze legendy**

Klucze legendy to małe, kolorowe znaczniki obok nazw serii w tabeli danych. Pomagają czytelnikom dopasować każdy wiersz tabeli do serii wykresu. Ustaw [show_legend_key](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datatable/show_legend_key/) na `True`, aby wyświetlić te znaczniki, lub na `False`, aby je ukryć.

Oddzielna legenda wykresu jest kontrolowana przez [Chart.has_legend](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/has_legend/). Te ustawienia są niezależne: ukrycie oddzielnej legendy nie ukrywa kluczy w tabeli danych, a ukrycie kluczy tabeli nie ukrywa oddzielnej legendy.

Poniższy przykład tworzy wykres z domyślnymi danymi, włącza jego tabelę danych i wyświetla klucze legendy wewnątrz niej, ukrywając jednocześnie oddzielną legendę. Wszystkie obramowania tabeli są wyraźnie włączone. Nie wymaga pliku prezentacji wejściowej. Aby ukryć tylko klucze tabeli, zmień `data_table.show_legend_key` na `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Poniższe porównanie pokazuje tę samą tabelę z włączonymi i wyłączonymi kluczami legendy. Wszystkie obramowania pozostają włączone, a oddzielna legenda wykresu jest ukryta w obu przypadkach.

![Tabele danych wykresu z kluczami legendy pokazanymi po lewej i ukrytymi po prawej](data-table-legend-keys.png)

## **FAQ**

**Czy mogę wyświetlić klucze legendy w tabeli danych wykresu?**

Tak. Ustaw [show_legend_key](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/datatable/show_legend_key/) na `True`, aby wyświetlić klucze legendy, lub na `False`, aby je ukryć.

**Czy tabela danych zostanie zachowana przy eksportowaniu prezentacji do PDF, HTML lub obrazów?**

Tak. Aspose.Slides renderuje wykres i wyświetlaną tabelę danych jako część slajdu przy eksporcie do [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/pl/python-net/convert-powerpoint-to-html/), lub [images](/slides/pl/python-net/convert-powerpoint-to-png/).

**Czy mogę pracować z tabelami danych w wykresach załadowanych z szablonu?**

Tak. Dla wykresu załadowanego z istniejącej prezentacji lub szablonu, użyj [has_data_table](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/has_data_table/), aby sprawdzić lub zmienić, czy jego tabela danych jest wyświetlana.

**Jak mogę znaleźć wykresy z włączoną tabelą danych?**

Iteruj po kształtach na każdym slajdzie, zidentyfikuj wykresy i sprawdź ich właściwość [has_data_table](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/has_data_table/). Wartość `True` oznacza, że tabela danych jest włączona.