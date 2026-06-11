---
title: Dodaj linie trendu do wykresów w prezentacji w Pythonie
linktitle: Linia trendu
type: docs
url: /pl/python-net/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- własna linia trendu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Szybko dodawaj i dostosowuj linie trendu w wykresach PowerPoint i OpenDocument za pomocą Aspose.Slides for Python via .NET — praktyczny przewodnik i przykłady kodu, które pomagają zwiększyć dokładność prognozowania i przyciągnąć uwagę odbiorców."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z kilkoma typami linii trendu, w tym wykładniczymi, liniowymi, logarytmicznymi, średnią kroczącą, wielomianowymi i potęgowymi.

Opisuje również, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu do przodu i do tyłu oraz tego, czy linie trendu są zachowywane podczas eksportu do formatu PDF lub SVG oraz przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**
Aspose.Slides for Python via .NET udostępnia prosty interfejs API do zarządzania różnymi liniami trendu wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z domyślnymi danymi oraz wybranym typem (w tym przykładzie użyto ChartType.CLUSTERED_COLUMN).
4. Dodawanie wykładniczej linii trendu dla serii wykresu 1.
5. Dodawanie liniowej linii trendu dla serii wykresu 1.
6. Dodawanie logarytmicznej linii trendu dla serii wykresu 2.
7. Dodawanie linii trendu średniej kroczącej dla serii wykresu 2.
8. Dodawanie wielomianowej linii trendu dla serii wykresu 3.
9. Dodawanie potęgowej linii trendu dla serii wykresu 3.
10. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Poniższy kod służy do stworzenia wykresu z liniami trendu.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Tworzenie pustej prezentacji
with slides.Presentation() as pres:

    # Tworzenie grupowanego wykresu kolumnowego
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Dodawanie wykładniczej linii trendu dla serii wykresu 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Dodawanie liniowej linii trendu dla serii wykresu 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Dodawanie logarytmicznej linii trendu dla serii wykresu 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Dodawanie linii trendu średniej kroczącej dla serii wykresu 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Dodawanie wielomianowej linii trendu dla serii wykresu 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Dodawanie potęgowej linii trendu dla serii wykresu 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Zapisywanie prezentacji
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj własną linię**
Aspose.Slides for Python via .NET udostępnia prosty interfejs API do dodawania własnych linii w wykresie. Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy Presentation
- Uzyskaj odwołanie do slajdu, używając jego indeksu
- Utwórz nowy wykres przy użyciu metody AddChart udostępnionej przez obiekt Shapes
- Dodaj AutoShape typu Linia, używając metody AddAutoShape udostępnionej przez obiekt Shapes
- Ustaw kolor linii kształtu.
- Zapisz zmodyfikowaną prezentację jako plik PPTX

Poniższy kod służy do stworzenia wykresu z własnymi liniami.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Co oznaczają terminy 'forward' i 'backward' w odniesieniu do linii trendu?**

Są to długości linii trendu projekowane do przodu lub do tyłu: dla wykresów punktowych (XY) — w jednostkach osi; dla wykresów niepunktowych — w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana podczas eksportu prezentacji do formatu PDF lub SVG, lub przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje na [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/pl/python-net/render-a-slide-as-an-svg-image/) i renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest również metoda umożliwiająca [eksport obrazu wykresu](/slides/pl/python-net/create-shape-thumbnails/).