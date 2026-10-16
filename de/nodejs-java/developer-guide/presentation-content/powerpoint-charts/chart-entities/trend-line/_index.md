---
title: Trendlinien zu Präsentationsdiagrammen in JavaScript hinzufügen
linktitle: Trendlinie
type: docs
url: /de/nodejs-java/trend-line/
keywords:
- Diagramm
- Trendlinie
- Exponentielle Trendlinie
- Lineare Trendlinie
- Logarithmische Trendlinie
- Trendlinie für gleitenden Durchschnitt
- Polynomiale Trendlinie
- Potenztrendlinie
- Benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint-Diagrammen schnell hinzu und passen Sie sie mit JavaScript und Aspose.Slides für Node.js über Java an – ein praktischer Leitfaden, um Ihr Publikum zu begeistern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Trendlinien zu Präsentationsdiagrammen mit Aspose.Slides hinzufügt. Er zeigt, wie man ein Diagramm erstellt, Trendlinien zu Diagrammserien hinzufügt und mit verschiedenen Trendlinientypen arbeitet, einschließlich exponentiell, linear, logarithmisch, gleitender Mittelwert, polynomial und Potenz.

Er beschreibt außerdem, wie man eine benutzerdefinierte Linie zu einem Diagramm hinzufügt, indem man eine Linienform einfügt, und enthält ein kurzes FAQ zu Vorwärts‑ und Rückwärtsprojektion von Trendlinien sowie dazu, ob Trendlinien beim Export in PDF oder SVG und beim Rendern von Diagrammen als Bilder erhalten bleiben.

## **Trendlinie hinzufügen**

Verwenden Sie [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add), um einer Diagrammserie eine Trendlinie hinzuzufügen, wobei Sie den Typ mit [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/) auswählen. Das Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten und fügt jeder seiner drei Serien zwei Trendlinien hinzu.

Die exponentielle Trendlinie blendet ihre Gleichung und den R‑Quadrat‑Wert über [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) und [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue) aus, während die lineare Trendlinie rot ist. Die logarithmische Trendlinie verwendet [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) für ein benutzerdefiniertes Beschriftungsfeld. Der gleitende Durchschnitt verwendet ein [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) von drei Datenpunkten und einen benutzerdefinierten [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName).

Die polynomialen Trendlinie hat einen [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) von drei und erstreckt eine Kategorie nach vorne über [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). Die Potenz‑Trendlinie erstreckt eine Kategorie nach hinten über [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trendlinien‑Achsenabschnitt festlegen**

Verwenden Sie [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept), um den Y‑Wert einer Trendlinie bei X = 0 festzulegen. Diese Einstellung wird für lineare, exponentielle und polynomialen Trendlinien unterstützt.

Zum Beispiel muss ein Produktionskostenmodell bei bekannten Fixkosten von 100 beginnen, selbst wenn Messungen bei nicht‑null Produktionsmengen einen anderen Ausgangswert nahelegen. Bei einer linearen Trendlinie erzwingt das Festlegen des Achsenabschnitts, dass die Gleichung `y = ax + b` zu `b = 100` wird; die Steigung wird unter dieser Einschränkung an die Daten angepasst. Es verschiebt nicht einfach eine bereits angepasste Linie. Die Einstellungen für den Achsenkreuzungs­punkt steuern, wo sich die Diagrammachsen treffen, nicht die Koeffizienten der angepassten Trendlinie.

Das folgende Beispiel erstellt ein Streudiagramm (XY) mit Produktionsmengen von 1 bis 4 und Kosten von 170, 200, 230 und 260. Es speichert das Diagramm mit dem standardmäßigen automatischen Achsenabschnitt, setzt den Achsenabschnitt auf 100 und speichert eine zweite PPTX. Die beiden Dateien unterscheiden sich nur in der Achsenabschnitt‑Einstellung. Die Trendlinie zeigt ihre Gleichung an und erstreckt sich zurück zu X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bei automatischer Berechnung ergeben diese Daten `y = 30x + 140`. Das Festlegen des Achsenabschnitts auf 100 ergibt stattdessen ungefähr `y = 43,33x + 100`: Der angepasste Wert bei Null entspricht dem bekannten Ausgangswert, während die Linie nicht mehr durch jeden Datenpunkt verläuft.

| Automatischer Achsenabschnitt | Fixierter Achsenabschnitt von 100 |
| --- | --- |
| ![Lineare Trendlinie mit automatisch berechnetem Achsenabschnitt von 140](intercept-automatic.png) | ![Lineare Trendlinie mit festem Achsenabschnitt von 100](intercept-fixed.png) |

Beide Bilder verwenden die gleichen Daten und Achsenskalen. Die Trendlinien werden zurück zu X = 0 verlängert, um ihre Achsenabschnitte zu zeigen.

Standardmäßig gibt [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) `NaN` zurück, was einen nicht spezifizierten Achsenabschnitt statt Null darstellt. Der Achsenabschnitt wird dann automatisch aus den Daten berechnet.

## **Benutzerdefinierte Linie hinzufügen**

Eine benutzerdefinierte Linie ist eine Form, die über dem Diagramm gezeichnet wird, anstatt eine aus den Seriendaten berechnete Trendlinie zu sein. Dieses Beispiel verwendet [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape), um eine horizontale Linie zur Folie über dem Diagramm hinzuzufügen. Die Position der Linie wird in Folienkoordinaten angegeben, gemessen in Punkten, sodass sie am linken Rand des Diagramms beginnt und halbwegs in der Höhe des Diagramms liegt. Die Breite entspricht der Diagrammbreite. Mit [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) erhält die Linie eine durchgängige rote Farbe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was bedeuten „forward“ und „backward“ bei einer Trendlinie?**

Es handelt sich um die Längen der Trendlinie, die nach vorne bzw. nach hinten projiziert werden: für Streu‑ (XY‑)Diagramme – in Achseneinheiten; für Nicht‑Streu‑Diagramme – in Kategorienzahl. Es sind nur nicht‑negative Werte zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie als Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/) oder [SVG](/slides/de/nodejs-java/render-a-slide-as-an-svg-image/) und rendert Diagramme als Bilder; Trendlinien werden als Teil des Diagramms bei diesen Vorgängen beibehalten. Eine Methode ist zudem verfügbar, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/nodejs-java/create-shape-thumbnails/).