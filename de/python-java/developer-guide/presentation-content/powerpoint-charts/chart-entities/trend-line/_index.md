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
- Gleitender Durchschnitt Trendlinie
- Polynomiale Trendlinie
- Potenz Trendlinie
- Benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint-Diagrammen schnell hinzu und passen Sie sie mit Aspose.Slides für Python via Java an – ein praktischer Leitfaden, um Ihr Publikum zu begeistern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Trendlinien zu Präsentationsdiagrammen mithilfe von Aspose.Slides hinzufügt. Er zeigt, wie ein Diagramm erstellt, Trendlinien zu Diagrammserien hinzugefügt und mit verschiedenen Trendlinientypen, einschließlich exponentiell, linear, logarithmisch, gleitendem Durchschnitt, polynomial und Potenz, gearbeitet wird.

Er beschreibt außerdem, wie man eine benutzerdefinierte Linie zu einem Diagramm hinzufügt, indem man eine Linienform einfügt, und enthält ein kurzes FAQ zu den Vorwärts‑ und Rückwärtsprojektionen von Trendlinien sowie zur Frage, ob Trendlinien beim Export nach PDF oder SVG und beim Rendern von Diagrammen als Bilder erhalten bleiben.

## **Trendlinie hinzufügen**

Verwenden Sie [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add), um einer Diagrammserie eine Trendlinie hinzuzufügen, und wählen Sie deren Typ mit [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). Das Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten und fügt jeder seiner drei Serien zwei Trendlinien hinzu.

Die exponentielle Trendlinie blendet ihre Gleichung und den Bestimmtheitsmaßwert über [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) und [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue) aus, während die lineare Trendlinie rot ist. Die logarithmische Trendlinie verwendet [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) für ein benutzerdefiniertes Beschriftungsfeld. Der gleitende Durchschnitt nutzt ein [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) von drei Datenpunkten und einen benutzerdefinierten [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName).

Die polynomialen Trendlinie hat eine Ordnung von drei, festgelegt über [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder), und erstreckt sich eine Kategorie vorwärts über [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). Die Potenz‑Trendlinie erstreckt sich eine Kategorie rückwärts über [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trendlinien‑Schnittpunkt festlegen**

Verwenden Sie [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept), um den Y‑Wert einer Trendlinie bei X = 0 zu fixieren. Diese Einstellung wird für lineare, exponentielle und polynomialen Trendlinien unterstützt.

Zum Beispiel kann ein Produktionskostenmodell bei bekannten Fixkosten von 100 beginnen, selbst wenn Messungen bei nicht‑null Produktionsvolumina einen anderen Ausgangswert nahelegen. Für eine lineare Trendlinie zwingt das Fixieren des Schnittpunkts die Gleichung `y = ax + b` zu `b = 100`; die Steigung wird unter dieser Einschränkung an die Daten angepasst. Es wird nicht einfach eine bereits angepasste Linie verschoben. Einstellungen zum Achsenkreuz bestimmen, wo die Diagrammachsen sich treffen, nicht die Koeffizienten der angepassten Trendlinie.

Das folgende Beispiel erstellt ein Streudiagramm (XY) mit Produktionsvolumina von 1 bis 4 und Kosten von 170, 200, 230 und 260. Es speichert das Diagramm mit dem standardmäßigen automatischen Schnittpunkt, setzt den Schnittpunkt auf 100 und speichert anschließend eine zweite PPTX. Die beiden Dateien unterscheiden sich ausschließlich durch die Schnittpunkteinstellung. Die Trendlinie zeigt ihre Gleichung und erstreckt sich zurück zu X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bei automatischer Berechnung ergeben diese Daten `y = 30x + 140`. Das Festlegen des Schnittpunkts auf 100 liefert stattdessen ungefähr `y = 43.33x + 100`: Der berechnete Wert bei null entspricht dem bekannten Basiswert, während die Linie nicht mehr durch jeden Datenpunkt verläuft.

| Automatischer Schnittpunkt | Fester Schnittpunkt von 100 |
| --- | --- |
| ![Lineare Trendlinie mit automatisch berechnetem Schnittpunkt von 140](intercept-automatic.png) | ![Lineare Trendlinie mit festem Schnittpunkt von 100](intercept-fixed.png) |

Beide Bilder verwenden dieselben Daten und Achsenskalierungen. Die Trendlinien werden zurück zu X = 0 verlängert, um ihre Schnittpunkte zu zeigen.

Standardmäßig liefert [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) `NaN`, was einen nicht spezifizierten Schnittpunkt anstelle von Null darstellt. Der Schnittpunkt wird dann automatisch aus den Daten berechnet.

## **Benutzerdefinierte Linie hinzufügen**

Eine benutzerdefinierte Linie ist eine Form, die über das Diagramm gezeichnet wird, anstatt einer Trendlinie, die aus Serien‑Daten berechnet wird. Dieses Beispiel verwendet [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape), um eine horizontale Linie über dem Diagramm auf der Folie zu platzieren. Die Position der Linie wird in Folienkoordinaten (Punkte) angegeben, sodass sie an der linken Diagrammkante beginnt und halbwegs in der Mitte des Diagramms liegt. Ihre Breite entspricht der Diagrammbreite. Die Methode [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) ermöglicht den Zugriff auf die Linienformatierung, um eine einheitliche rote Farbe anzuwenden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Was bedeuten „vorwärts“ und „rückwärts“ bei einer Trendlinie?**

Sie geben die Längen der Trendlinie an, die nach vorne bzw. nach hinten projiziert werden: für Streudiagramme (XY) in Achsen­einheiten; für Nicht‑Streudiagramme in Anzahl der Kategorien. Nur nicht‑negative Werte sind zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie als Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/) oder [SVG](/slides/de/python-java/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Teil des Diagramms, bleiben bei diesen Vorgängen erhalten. Es gibt außerdem eine Methode, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/python-java/create-shape-thumbnails/).