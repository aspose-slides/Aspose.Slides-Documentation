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
- gleitende Durchschnittstrendlinie
- polynomiale Trendlinie
- Potenz‑Trendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie schnell Trendlinien zu PowerPoint- und OpenDocument-Diagrammen mit Aspose.Slides für Python über .NET hinzu und passen Sie sie an – ein praxisorientierter Leitfaden und Codebeispiele zur Verbesserung der Prognosegenauigkeit und zur Einbindung Ihres Publikums."
---

## **Trendlinie hinzufügen**
Aspose.Slides für Python über .NET bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie den gewünschten Typ auswählen (in diesem Beispiel wird ChartType.CLUSTERED_COLUMN verwendet).
4. Hinzufügen einer exponentiellen Trendlinie für Diagrammreihe 1.
5. Hinzufügen einer linearen Trendlinie für Diagrammreihe 1.
6. Hinzufügen einer logarithmischen Trendlinie für Diagrammreihe 2.
7. Hinzufügen einer gleitenden Mittelwert‑Trendlinie für Diagrammreihe 2.
8. Hinzufügen einer polynomialen Trendlinie für Diagrammreihe 3.
9. Hinzufügen einer Potenz‑Trendlinie für Diagrammreihe 3.
10. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Leere Präsentation erstellen
with slides.Presentation() as pres:

    # Gruppiertes Säulendiagramm erstellen
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Exponentielle Trendlinie für Diagrammreihe 1 hinzufügen
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Lineare Trendlinie für Diagrammreihe 1 hinzufügen
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Logarithmische Trendlinie für Diagrammreihe 2 hinzufügen
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Gleitende Mittelwert‑Trendlinie für Diagrammreihe 2 hinzufügen
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Polynomial‑Trendlinie für Diagrammreihe 3 hinzufügen
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Potenz‑Trendlinie für Diagrammreihe 3 hinzufügen
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Präsentation speichern
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für Python über .NET bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in einem Diagramm. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Presentation‑Klasse
- Holen Sie sich die Referenz einer Folie über deren Index
- Erstellen Sie ein neues Diagramm mit der AddChart‑Methode, die vom Shapes‑Objekt bereitgestellt wird
- Fügen Sie eine AutoShape vom Typ Linie mithilfe der AddAutoShape‑Methode des Shapes‑Objekts hinzu
- Legen Sie die Farbe der Formlinien fest.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei

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


## **FAQ**

**Was bedeuten 'forward' und 'backward' bei einer Trendlinie?**

Sie geben die Längen der Trendlinie an, die vorwärts bzw. rückwärts projiziert werden: Für Streudiagramme (XY) in Achseneinheiten; für Nicht‑Streudiagramme in der Anzahl der Kategorien. Es sind nur nicht‑negative Werte zulässig.

**Bleibt die Trendlinie erhalten, wenn die Präsentation in PDF oder SVG exportiert oder eine Folie als Bild gerendert wird?**

Ja. Aspose.Slides konvertiert Präsentationen in [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/de/python-net/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Teil des Diagramms, bleiben bei diesen Vorgängen erhalten. Eine Methode ist ebenfalls verfügbar, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/python-net/create-shape-thumbnails/).