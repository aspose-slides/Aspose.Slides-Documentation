---
title: Trendlinie
type: docs
url: /de/python-net/trend-line/
keywords: "Trendlinie, benutzerdefinierte Linie PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Fügen Sie Trendlinien und benutzerdefinierte Linien zu PowerPoint-Präsentationen in Python hinzu"
---

## **Trendlinie hinzufügen**
Aspose.Slides für Python über .NET bietet eine einfache API zur Verwaltung verschiedener Diagramm-Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit einem beliebigen gewünschten Typ hinzu (dieses Beispiel verwendet ChartType.CLUSTERED_COLUMN).
1. Hinzufügen der exponentiellen Trendlinie für Diagrammreihe 1.
1. Hinzufügen der linearen Trendlinie für Diagrammreihe 1.
1. Hinzufügen der logarithmischen Trendlinie für Diagrammreihe 2.
1. Hinzufügen der gleitenden Durchschnittstrendlinie für Diagrammreihe 2.
1. Hinzufügen der polynomialen Trendlinie für Diagrammreihe 3.
1. Hinzufügen der Potenztrendlinie für Diagrammreihe 3.
1. Speichern der modifizierten Präsentation in einer PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Erstellen einer leeren Präsentation
with slides.Presentation() as pres:

    # Erstellen eines gruppierten Säulendiagramms
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Hinzufügen der exponentiellen Trendlinie für Diagrammreihe 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Hinzufügen der linearen Trendlinie für Diagrammreihe 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Hinzufügen der logarithmischen Trendlinie für Diagrammreihe 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("Neue log-Trendlinie")

    # Hinzufügen der gleitenden Durchschnittstrendlinie für Diagrammreihe 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "Neuer Trendlinienname"

    # Hinzufügen der polynomialen Trendlinie für Diagrammreihe 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Hinzufügen der Potenztrendlinie für Diagrammreihe 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Speichern der Präsentation
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für Python über .NET bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in ein Diagramm. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden
- Erstellen Sie ein neues Diagramm mit der Methode AddChart, die vom Shapes-Objekt bereitgestellt wird
- Fügen Sie eine AutoShape vom Typ Linie mit der Methode AddAutoShape hinzu, die vom Shapes-Objekt bereitgestellt wird
- Setzen Sie die Farbe der Linien des Shapes.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.

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