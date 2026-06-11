---
title: Optymalizuj obliczenia wykresów w prezentacjach w Pythonie
linktitle: Obliczenia wykresów
type: docs
weight: 50
url: /pl/python-net/chart-calculations/
keywords:
- obliczenia wykresów
- elementy wykresu
- pozycja elementu
- rzeczywista pozycja
- element podrzędny
- element nadrzędny
- wartości wykresu
- rzeczywista wartość
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zrozum obliczenia wykresów, aktualizacje danych i kontrolę precyzji w Aspose.Slides for Python via .NET dla PPT, PPTX i ODP, wraz z praktycznymi przykładami kodu."
---
## **Przegląd**

Aspose.Slides udostępnia interfejsy API do pracy z obliczeniami wykresów i danymi układu w prezentacjach. Ten artykuł pokazuje, jak pobrać rzeczywiste wartości elementów wykresu, w tym rzeczywistą pozycję i rozmiar elementów implementujących `ActualLayout` oraz rzeczywiste wartości osi wykresu. Wyjaśnia również, że te wartości są uzupełniane po weryfikacji układu wykresu.

Ponadto artykuł demonstruje, jak uzyskać rzeczywistą pozycję nadrzędnych elementów wykresu oraz jak ukryć komponenty wykresu, takie jak tytuł, osie, legenda i linie siatki. Razem te przykłady pomagają sprawdzić informacje o układzie wykresu i sterować widocznością elementów wykresu w prezentacjach PowerPoint programowo.

## **Oblicz rzeczywiste wartości elementów wykresu**
Aspose.Slides for Python via .NET udostępnia prosty interfejs API do uzyskiwania tych właściwości. Pomoże to w obliczaniu rzeczywistych wartości elementów wykresu. Rzeczywiste wartości obejmują pozycję elementów dziedziczących klasę [IActualLayout](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/iactuallayout/) (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) oraz rzeczywiste wartości osi (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **Oblicz rzeczywistą pozycję nadrzędnych elementów wykresu**
Aspose.Slides for Python via .NET udostępnia prosty interfejs API do uzyskiwania tych właściwości. Właściwości IActualLayout dostarczają informacji o rzeczywistej pozycji nadrzędnego elementu wykresu. Należy wcześniej wywołać metodę IChart.ValidateChartLayout(), aby wypełnić właściwości rzeczywistymi wartościami.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **Ukryj informacje z wykresu**
Ten temat pomaga zrozumieć, jak ukrywać informacje w wykresie. Korzystając z Aspose.Slides for Python via .NET możesz ukryć **Tytuł, Oś pionową, Oś poziomą** oraz **Linie siatki** w wykresie. Poniższy przykład kodu pokazuje, jak używać tych właściwości.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Ukrywanie tytułu wykresu
    chart.has_title = False

    # Ukrywanie osi wartości
    chart.axes.vertical_axis.is_visible = False

    # Widoczność osi kategorii
    chart.axes.horizontal_axis.is_visible = False

    # Ukrywanie legendy
    chart.has_legend = False

    # Ukrywanie głównych linii siatki
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Ustawianie koloru linii serii
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy zewnętrzne skoroszyty Excel działają jako źródło danych i jak to wpływa na przeliczanie?**

Tak. Wykres może odwoływać się do zewnętrznego skoroszytu: gdy połączysz się lub odświeżysz zewnętrzne źródło, formuły i wartości są pobierane z tego skoroszytu, a wykres odzwierciedla aktualizacje podczas operacji otwierania/edycji. API pozwala [określić ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) i zarządzać powiązanymi danymi.

**Czy mogę obliczyć i wyświetlić linie trendu bez samodzielnego implementowania regresji?**

Tak. [Linie trendu](/slides/pl/python-net/trend-line/) (liniowe, wykładnicze i inne) są dodawane i aktualizowane przez Aspose.Slides; ich parametry są automatycznie przeliczane na podstawie danych serii, więc nie musisz implementować własnych obliczeń.

**Jeśli prezentacja zawiera wiele wykresów z linkami zewnętrznymi, czy mogę kontrolować, który skoroszyt używa każdy wykres do obliczonych wartości?**

Tak. Każdy wykres może wskazywać własny [zewnętrzny skoroszyt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chartdata/set_external_workbook/), lub możesz tworzyć/zastępować zewnętrzny skoroszyt dla każdego wykresu niezależnie od pozostałych.