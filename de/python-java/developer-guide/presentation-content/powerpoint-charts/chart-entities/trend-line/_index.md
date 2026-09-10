---
title: Trendlinien zu Präsentationsdiagrammen in Python hinzufügen
linktitle: Trendlinie
type: docs
url: /de/python-java/trend-line/
keywords:
- Diagramm
- Trendlinie
- Exponentielle Trendlinie
- Lineare Trendlinie
- Logarithmische Trendlinie
- Trendlinie für gleitenden Durchschnitt
- Polynomialtrendlinie
- Potenztrendlinie
- Benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint‑Diagrammen mit Aspose.Slides für Python via Java schnell hinzu und passen Sie sie an – ein praxisorientierter Leitfaden, um Ihr Publikum zu fesseln."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Trendlinien zu Präsentationsdiagrammen mit Aspose.Slides hinzufügt. Er zeigt, wie man ein Diagramm erstellt, Trendlinien zu Diagrammserien hinzufügt und mit verschiedenen Trendlinientypen arbeitet, darunter exponentiell, linear, logarithmisch, gleitender Durchschnitt, polynomial und potenziell.

Er beschreibt außerdem, wie man eine benutzerdefinierte Linie zu einem Diagramm hinzufügt, indem man eine Linienform einfügt, und enthält ein kurzes FAQ zu den Vorwärts‑ und Rückwärts‑Projektionen von Trendlinien und dazu, ob Trendlinien beim Export nach PDF oder SVG sowie beim Rendern von Diagrammen als Bilder erhalten bleiben.

## **Trendlinie hinzufügen**

Aspose.Slides for Python via Java bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Trendlinien:

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. Erhalte eine Referenz auf eine Folie über ihren Index.
1. Füge ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (dieses Beispiel verwendet [ChartType.ClusteredColumn](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Füge eine exponentielle Trendlinie zur Diagrammserie 1 hinzu.
1. Füge eine lineare Trendlinie zur Diagrammserie 1 hinzu.
1. Füge eine logarithmische Trendlinie zur Diagrammserie 2 hinzu.
1. Füge eine Trendlinie für gleitenden Durchschnitt zur Diagrammserie 2 hinzu.
1. Füge eine polynomiale Trendlinie zur Diagrammserie 3 hinzu.
1. Füge eine potenzielle Trendlinie zur Diagrammserie 3 hinzu.
1. Schreibe die geänderte Präsentation in eine PPTX‑Datei.

Der folgende Code erstellt ein Diagramm mit Trendlinien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    # Erstelle ein gruppiertes Säulendiagramm.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Füge eine exponentielle Trendlinie zur Diagrammserie 1 hinzu.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Füge eine lineare Trendlinie zur Diagrammserie 1 hinzu.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Füge eine logarithmische Trendlinie zur Diagrammserie 2 hinzu.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Füge eine Trendlinie für gleitenden Durchschnitt zur Diagrammserie 2 hinzu.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Füge eine polynomialen Trendlinie zur Diagrammserie 3 hinzu.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Füge eine Potenztrendlinie zur Diagrammserie 3 hinzu.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Speichere die Präsentation.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Benutzerdefinierte Linie hinzufügen**

Aspose.Slides for Python via Java bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien zu einem Diagramm. Um eine einfache Linie zu einem Diagramm auf einer ausgewählten Folie hinzuzufügen, befolge diese Schritte:

- Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
- Erhalte eine Referenz auf eine Folie über ihren Index.
- Erstelle ein neues Diagramm mit der [addChart](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addChart)‑Methode der [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/)‑Klasse.
- Füge eine Linienform mit der [addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape)‑Methode und [ShapeType.Line](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#Line) hinzu.
- Setze die Farbe der Linienform.
- Schreibe die geänderte Präsentation in eine PPTX‑Datei.

Der folgende Code erstellt ein Diagramm mit einer benutzerdefinierten Linie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Was bedeuten „forward“ und „backward“ bei einer Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. nach hinten projiziert werden: Für Streudiagramme (XY) werden sie in Achseneinheiten gemessen; für Nicht‑Streudiagramme werden sie in der Anzahl der Kategorien gemessen. Nur nicht‑negative Werte sind zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie zu einem Bild beibehalten?**

Ja. Aspose.Slides konvertiert Präsentationen in [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/de/python-java/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Teil des Diagramms, bleiben bei diesen Vorgängen erhalten. Es gibt zudem eine Methode, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/python-java/create-shape-thumbnails/).