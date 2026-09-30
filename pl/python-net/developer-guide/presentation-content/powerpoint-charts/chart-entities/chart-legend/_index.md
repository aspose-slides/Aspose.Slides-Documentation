---
title: Dostosowywanie legend wykresów w prezentacjach przy użyciu Pythona
linktitle: Legenda wykresu
type: docs
url: /pl/python-net/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dostosuj legendy wykresów za pomocą Aspose.Slides for Python via .NET, aby zoptymalizować prezentacje PowerPoint poprzez dopasowane formatowanie legend."
---
## **Przegląd**

Aspose.Slides for Python via .NET oferuje opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić położenie i rozmiar legendy, określić rozmiar czcionki dla całej legendy, sformatować pojedynczy wpis legendy oraz ukryć lub przywrócić wybrane pozycje.

FAQ opisuje powiązane zachowania, w tym rezerwowanie miejsca dla legendy, wyświetlanie etykiet wieloliniowych oraz dziedziczenie formatowania z motywu prezentacji.

## **Pozycjonowanie legendy**

Użyj właściwości legendy [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [szerokość](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), i [wysokość](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/), aby określić jej położenie i rozmiar jako ułamki wymiarów wykresu.

Ten przykład tworzy prezentację i dodaje wykres słupkowy skumulowany z domyślnymi danymi do pierwszego slajdu. Podzielenie żądanych przesunięć i wymiarów legendy przez szerokość i wysokość wykresu konwertuje je na wartości względne: legenda jest przesunięta o 50 punktów od lewego górnego rogu wykresu i ma rozmiar 100 na 100 punktów.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Wyraź pozycję i rozmiar legendy względem wykresu.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawienie rozmiaru czcionki legendy**

Użyj właściwości legendy [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) , aby uzyskać dostęp do formatowania tekstu i ustaw [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) w punktach.

Ten przykład tworzy wykres z domyślnymi danymi i ustawia tekst legendy na 20 punktów. Wyłącza także automatyczne granice dla osi pionowej i ustawia jej zakres od -5 do 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawienie rozmiaru czcionki pojedynczego wpisu legendy**

Użyj kolekcji [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) , aby uzyskać dostęp do formatowania konkretnego wpisu legendy. Indeksy wpisów są zerowe, więc indeks `1` odnosi się do drugiego wpisu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Ukrywanie pojedynczych wpisów legendy**

Aby wykluczyć dodatkową serię z legendy, zachowując jednocześnie widoczność jej danych, ustaw [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) na `True` poprzez [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). To ukrywa tylko wybrany wpis legendy; nie usuwa serii ani jej punktów danych. Natomiast ustawienie [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) na `False` ukrywa całą legendę.

Poniższy przykład tworzy wykres słupkowy skumulowany z wieloma seriami przy użyciu domyślnych danych. Ukrywa wpis legendy drugiej serii (indeks `1`) i zapisuje prezentację. Następnie przywraca ten wpis, ustawiając [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) na `False` i zapisuje drugą kopię. Kolumny pozostają widoczne w obu plikach.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Przywróć ten sam wpis bez zmiany danych wykresu.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Poniższe porównanie pokazuje ten sam wykres ze wszystkimi widocznymi wpisami legendy oraz z ukrytym serią 2 w legendzie; wszystkie kolumny pozostają widoczne.

![Porównanie wykresu ze wszystkimi widocznymi wpisami legendy oraz z ukrytym serią 2 w legendzie; wszystkie kolumny pozostają widoczne.](hide-legend-entry.png)

W wykresach kolumnowych, słupkowych i liniowych wpisy legendy identyfikują serie. W wykresach kołowych identyfikują one pojedyncze punkty danych (segmenty), więc zamiast tego użyj [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) na wybranym segmencie. API dokumentuje tę właściwość punktu danych dla typów wykresów `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` oraz `BAR_OF_PIE`. Nie zakładaj, że ma zastosowanie do wykresów pierścieniowych, które nie są wymienione na tej liście.

## **FAQ**

**Czy mogę sprawić, że wykres przydzieli miejsce dla legendy zamiast nakładać ją?**

Tak. Ustaw [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) na `False`, aby zarezerwować miejsce dla legendy zamiast pozwalać jej nakładać się na obszar wykresu.

**Czy mogę tworzyć wieloliniowe etykiety legendy?**

Tak. Długie etykiety mogą się zawijać, gdy dostępna szerokość jest niewystarczająca. Możesz także używać znaków nowej linii w nazwach serii, aby wymusić podziały linii.

**Jak sprawić, aby legenda korzystała ze schematu kolorów motywu prezentacji?**

Pozostaw kolory, wypełnienia i czcionki legendy nieustawione, aby mogła dziedziczyć formatowanie motywu. Jawne formatowanie zastępuje odpowiadające ustawienia motywu.