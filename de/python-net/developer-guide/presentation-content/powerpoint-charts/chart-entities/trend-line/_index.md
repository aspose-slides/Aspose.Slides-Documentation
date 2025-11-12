---
title: Trendlinien zu Präsentationsdiagrammen in Python hinzufügen
linktitle: Trendlinie
type: docs
url: /de/python-net/trend-line/
keywords:
- Diagramm
- Trendlinie
- Exponentialtrendlinie
- Lineartrendlinie
- LogarithmischeTrendlinie
- GleitenderDurchschnittTrendlinie
- Polynomialtrendlinie
- Potenztrendlinie
- BenutzerdefinierteTrendlinie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie schnell Trendlinien zu PowerPoint- und OpenDocument-Diagrammen mit Aspose.Slides für Python via .NET hinzu und passen Sie sie an – ein praktischer Leitfaden und Codebeispiele zur Verbesserung der Prognosegenauigkeit und zur Einbindung Ihres Publikums."
---

## **Trendlinie hinzufügen**
Aspose.Slides für Python via .NET bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Trendlinien:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (dieses Beispiel verwendet ChartType.CLUSTERED_COLUMN).  
4. Exponentialtrendlinie für Diagrammserie 1 hinzufügen.  
5. Lineartrendlinie für Diagrammserie 1 hinzufügen.  
6. Logarithmische Trendlinie für Diagrammserie 2 hinzufügen.  
7. Gleitende‑Durchschnitt‑Trendlinie für Diagrammserie 2 hinzufügen.  
8. Polynomialtrendlinie für Diagrammserie 3 hinzufügen.  
9. Potenztrendlinie für Diagrammserie 3 hinzufügen.  
10. Speichern Sie die geänderte Präsentation in einer PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Leere Präsentation erstellen
with slides.Presentation() as pres:

    # Gruppiertes Säulendiagramm erstellen
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Exponentialtrendlinie für Diagrammserie 1 hinzufügen
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Lineartrendlinie für Diagrammserie 1 hinzufügen
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Logarithmische Trendlinie für Diagrammserie 2 hinzufügen
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Gleitende‑Durchschnitt‑Trendlinie für Diagrammserie 2 hinzufügen
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Polynomialtrendlinie für Diagrammserie 3 hinzufügen
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Potenztrendlinie für Diagrammserie 3 hinzufügen
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Präsentation speichern
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für Python via .NET bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in einem Diagramm. Gehen Sie folgendermaßen vor, um eine einfache, gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen:

- Instanz der Klasse Presentation erstellen  
- Referenz einer Folie über deren Index abrufen  
- Neues Diagramm mit der AddChart‑Methode des Shapes‑Objekts erstellen  
- AutoShape vom Typ Line mit der AddAutoShape‑Methode des Shapes‑Objekts hinzufügen  
- Farbe der Linien der Form festlegen  
- Geänderte Präsentation als PPTX‑Datei speichern  

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

**Was bedeuten „forward“ und „backward“ für eine Trendlinie?**

Sie geben die Länge der Trendlinie an, die vorwärts bzw. rückwärts projiziert wird: für Streudiagramme (XY) in Achsen­einheiten; für Nicht‑Streudiagramme in Anzahl der Kategorien. Nur nicht‑negative Werte sind zulässig.

**Wird die Trendlinie beim Exportieren der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie als Bild beibehalten?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/de/python-net/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Bestandteil des Diagramms, bleiben dabei erhalten. Es gibt zudem eine Methode zum [Exportieren eines Bildes des Diagramms](/slides/de/python-net/create-shape-thumbnails/).