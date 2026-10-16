---
title: Trendlinien zu Präsentationsdiagrammen in Python hinzufügen
linktitle: Trendlinie
type: docs
url: /de/python-net/trend-line/
keywords:
- Diagramm
- Trendlinie
- exponentielle Trendlinie
- lineare Trendlinie
- logarithmische Trendlinie
- Trendlinie für gleitenden Mittelwert
- polynomiale Trendlinie
- Potenz-Trendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint-Diagrammen schnell hinzu und passen Sie sie mit Aspose.Slides für Python über .NET an – ein praktischer Leitfaden, um Ihr Publikum zu begeistern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Trendlinien zu Präsentationsdiagrammen mithilfe von Aspose.Slides hinzufügt. Er zeigt, wie man ein Diagramm erstellt, Trendlinien zu Diagrammserien hinzufügt und mit verschiedenen Trendlinientypen arbeitet, einschließlich exponentiell, linear, logarithmisch, gleitendem Mittelwert, polynomial und Potenz.

Er beschreibt außerdem, wie man eine benutzerdefinierte Linie zu einem Diagramm hinzufügt, indem man eine Linienform einfügt, und enthält ein kurzes FAQ zu den Vorwärts‑ und Rückwärts‑Projektionwerten von Trendlinien sowie dazu, ob Trendlinien beim Exportieren in PDF oder SVG und beim Rendern von Diagrammen als Bilder erhalten bleiben.

## **Trendlinie hinzufügen**

Verwenden Sie [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/), um einer Diagrammserie eine Trendlinie hinzuzufügen, wobei Sie den Typ mit [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/) auswählen. Das Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten und fügt jeder der drei Serien zwei Trendlinien hinzu.

Die exponentielle Trendlinie blendet ihre Gleichung und den R‑Quadrat‑Wert über [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) bzw. [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/) aus, während die lineare Trendlinie rot ist. Die logarithmische Trendlinie verwendet [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) für ein benutzerdefiniertes Etikett. Der gleitende Mittelwert verwendet ein [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) von drei Datenpunkten und einen benutzerdefinierten [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/).

Die polynomiale Trendlinie hat einen [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) von drei und erstreckt eine Kategorie vorwärts über [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). Die Potenz‑Trendlinie erstreckt eine Kategorie rückwärts über [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

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

## **Trendlinienabschnitt festlegen**

Verwenden Sie [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/), um den Y‑Wert einer Trendlinie bei X = 0 festzulegen. Diese Einstellung wird für lineare, exponentielle und polynomiale Trendlinien unterstützt.

Zum Beispiel muss ein Produktionskostemodell bei bekannten Fixkosten von 100 beginnen, selbst wenn Messungen bei nicht‑null Produktionsmengen eine andere Basislinie nahelegen. Für eine lineare Trendlinie zwingt das Festlegen des Schnittpunkts die Gleichung `y = ax + b` zu `b = 100`; die Steigung wird unter dieser Bedingung an die Daten angepasst. Es verschiebt nicht einfach eine bereits angepasste Linie. Die Achsenkreuzungseinstellungen bestimmen, wo die Diagrammachsen sich treffen, nicht die Koeffizienten der angepassten Trendlinie.

Das folgende Beispiel erstellt ein Streudiagramm (XY) mit Produktionsvolumina von 1 bis 4 und Kosten von 170, 200, 230 und 260. Es speichert das Diagramm mit dem standardmäßigen automatischen Achsenabschnitt, setzt den Achsenabschnitt auf 100 und speichert eine zweite PPTX. Die beiden Dateien unterscheiden sich nur durch die Achsenabschnitt‑Einstellung. Die Trendlinie zeigt ihre Gleichung an und erstreckt sich zurück zu X = 0.

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

Bei automatischer Berechnung ergeben diese Daten `y = 30x + 140`. Das Festlegen des Achsenabschnitts auf 100 ergibt stattdessen ungefähr `y = 43.33x + 100`: Der angepasste Wert bei Null entspricht der bekannten Basislinie, während die Linie nicht mehr durch jeden Datenpunkt verläuft.

| Automatischer Achsenabschnitt | Fester Achsenabschnitt von 100 |
| --- | --- |
| ![Lineare Trendlinie mit automatisch berechnetem Achsenabschnitt von 140](intercept-automatic.png) | ![Lineare Trendlinie mit festem Achsenabschnitt von 100](intercept-fixed.png) |

Beide Bilder verwenden dieselben Daten und Achsenskalierungen. Die Trendlinien werden zurück zu X = 0 verlängert, um ihre Achsenabschnitte zu zeigen.

Standardmäßig enthält die Eigenschaft `float("nan")`, was einen nicht angegebenen Achsenabschnitt und nicht Null darstellt. Der Achsenabschnitt wird dann automatisch aus den Daten berechnet.

## **Benutzerdefinierte Linie hinzufügen**

Eine benutzerdefinierte Linie ist eine Form, die über dem Diagramm gezeichnet wird, anstatt einer aus den Seriendaten berechneten Trendlinie. Dieses Beispiel verwendet [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/), um dem Folieninhalt über dem Diagramm eine horizontale Linie hinzuzufügen. Die Position der Linie wird in Folienkoordinaten angegeben, gemessen in Punkten, sodass sie am linken Rand des Diagramms beginnt und halbwegs in der Höhe des Diagramms liegt. Ihre Breite entspricht der Diagrammbreite. Der [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) verleiht der Linie eine durchgängige rote Farbe.

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

**Was bedeuten 'forward' und 'backward' für eine Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. hinten projiziert werden: für Streudiagramme (XY) — in Achseneinheiten; für Nicht‑Streudiagramme — in Anzahl der Kategorien. Nur nicht‑negative Werte sind erlaubt.

**Wird die Trendlinie beim Exportieren der Präsentation nach PDF oder SVG oder beim Rendern einer Folie zu einem Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/) oder [SVG](/slides/de/python-net/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Teil des Diagramms, bleiben bei diesen Vorgängen erhalten. Es steht außerdem eine Methode zum [Export eines Bildes des Diagramms](/slides/de/python-net/create-shape-thumbnails/) selbst zur Verfügung.