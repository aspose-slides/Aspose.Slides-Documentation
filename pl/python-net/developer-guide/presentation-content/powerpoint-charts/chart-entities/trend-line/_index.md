---
title: Dodaj linie trendu do wykresów w prezentacji w Pythonie
linktitle: Linia trendu
type: docs
url: /pl/python-net/trend-line/
keywords:
- wykres
- linia trendu
- linia trendu wykładniczego
- linia trendu liniowego
- linia trendu logarytmicznego
- linia trendu średniej kroczącej
- linia trendu wielomianowego
- linia trendu potęgowego
- własna linia trendu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides dla Pythona via .NET — praktyczny przewodnik, który zaangażuje Twoją publiczność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z różnymi typami linii trendu, w tym wykładniczym, liniowym, logarytmicznym, średnią kroczącą, wielomianowym i potęgowym.

Opisuje również, jak dodać własną linię do wykresu, wstawiając kształt linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu „forward” i „backward” oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazy.

## **Dodawanie linii trendu**

Użyj [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) do dodania linii trendu do serii wykresu, wybierając jej typ za pomocą [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). Przykład tworzy wykres kolumnowy grupowany z danymi domyślnymi i dodaje po dwie linie trendu do każdej z trzech serii.

Linia trendu wykładniczego ukrywa swoje równanie i wartość R‑kwadrat za pomocą [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) oraz [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), podczas gdy linia trendu liniowego jest czerwona. Linia trendu logarytmicznego używa [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) do utworzenia własnej etykiety. Średnia krocząca korzysta z [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) wynoszącego trzy punkty danych oraz własnego [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/).

Linia trendu wielomianowego ma [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) równy trzy i rozciąga się o jedną kategorię do przodu dzięki [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). Linia trendu potęgowego rozciąga się o jedną kategorię wstecz dzięki [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie przecięcia linii trendu**

Użyj [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) aby ustalić wartość Y linii trendu przy X = 0. Ustawienie to jest obsługiwane dla linii trendu liniowych, wykładniczych i wielomianowych.

Na przykład model kosztów produkcji może wymagać rozpoczęcia od znanych stałych kosztów w wysokości 100, nawet jeśli pomiary przy niezerowych wolumenach produkcji sugerują inną podstawę. Dla linii trendu liniowego, ustalenie przecięcia ogranicza równanie `y = ax + b` do `b = 100`; nachylenie jest dopasowywane do danych przy tym ograniczeniu. Nie przesuwa to po prostu już dopasowanej linii. Ustawienia przecięcia osi kontrolują, gdzie osie wykresu się spotykają, a nie współczynniki dopasowanej linii trendu.

Poniższy przykład tworzy wykres punktowy (XY) z wolumenami produkcji od 1 do 4 i kosztami 170, 200, 230 oraz 260. Zapisuje wykres z domyślnym automatycznym przecięciem, ustawia przecięcie na 100 i zapisuje drugi plik PPTX. Dwa pliki różnią się jedynie ustawieniem przecięcia. Linia trendu wyświetla swoje równanie i rozciąga się do X = 0.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

Przy automatycznym obliczeniu te dane dają `y = 30x + 140`. Ustawienie przecięcia na 100 zamiast tego daje przybliżenie `y = 43.33x + 100`: dopasowana wartość przy zerze odpowiada znanej podstawie, a linia nie przechodzi już przez każdy punkt danych.

| Automatyczne przecięcie | Stałe przecięcie 100 |
| --- | --- |
| ![Linia trendu liniowego z automatycznie obliczonym przecięciem 140](intercept-automatic.png) | ![Linia trendu liniowego ze stałym przecięciem 100](intercept-fixed.png) |

Oba obrazy używają tych samych danych i skal osi. Linie trendu są rozciągnięte do X = 0, aby pokazać ich przecięcia.

Domyślnie właściwość zawiera `float("nan")`, co oznacza nieokreślone przecięcie, a nie zero. Przecięcie jest wtedy obliczane automatycznie na podstawie danych.

## **Dodawanie własnej linii**

Własna linia to kształt narysowany nad wykresem, a nie linia trendu obliczona na podstawie danych serii. Ten przykład używa [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) do dodania poziomej linii do slajdu nad wykresem. Pozycja linii jest określona w współrzędnych slajdu, mierzonych w punktach, więc zaczyna się od lewego brzegu wykresu i znajduje się w połowie wysokości wykresu. Jej szerokość odpowiada szerokości wykresu. [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) nadaje linii jednolity czerwony kolor.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Co oznaczają wartości „forward” i „backward” dla linii trendu?**

Są to długości linii trendu projekowane do przodu/tłu: dla wykresów punktowych (XY) – w jednostkach osi; dla wykresów innych niż punktowe – w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana przy eksporcie prezentacji do PDF lub SVG, lub przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/) lub [SVG](/slides/pl/python-net/render-a-slide-as-an-svg-image/) oraz renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest także metoda do [export an image of the chart](/slides/pl/python-net/create-shape-thumbnails/) samego wykresu.