---
title: Trendlinien zu Präsentationsdiagrammen in Java hinzufügen
linktitle: Trendlinie
type: docs
url: /de/java/trend-line/
keywords:
- Diagramm
- Trendlinie
- Exponentielle Trendlinie
- Lineare Trendlinie
- Logarithmische Trendlinie
- Trendlinie für gleitenden Durchschnitt
- Polynomische Trendlinie
- Potenztrendlinie
- Benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint‑Diagrammen mit Aspose.Slides für Java schnell hinzu und passen Sie sie an – ein praktischer Leitfaden, um Ihr Publikum zu begeistern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Trendlinien zu Präsentationsdiagrammen mit Aspose.Slides hinzufügt. Er zeigt, wie man ein Diagramm erstellt, Trendlinien zu Diagrammserien hinzufügt und mit mehreren Trendlinientypen arbeitet, darunter exponentiell, linear, logarithmisch, gleitender Durchschnitt, polynomial und Potenz.

Er beschreibt außerdem, wie man eine benutzerdefinierte Linie zu einem Diagramm hinzufügt, indem man eine Linienform einfügt, und enthält ein kurzes FAQ zu den Vorwärts‑ und Rückwärts‑Projektionswerten von Trendlinien sowie zur Frage, ob Trendlinien beim Export in PDF oder SVG und beim Rendern von Diagrammen als Bilder erhalten bleiben.

## **Trendlinie hinzufügen**

Verwenden Sie [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-), um eine Trendlinie zu einer Diagrammserie hinzuzufügen, wobei Sie den Typ mit [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/) auswählen. Das Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten und fügt jeder seiner drei Serien zwei Trendlinien hinzu.

Die exponentielle Trendlinie blendet ihre Gleichung und den R‑Quadrat‑Wert über [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) und [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) aus, während die lineare Trendlinie rot ist. Die logarithmische Trendlinie verwendet [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) für ein benutzerdefiniertes Beschriftungsfeld. Der gleitende Durchschnitt verwendet ein [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) von drei Datenpunkten und einen benutzerdefinierten [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

Die polynomische Trendlinie hat ein [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) von drei und erstreckt eine Kategorie nach vorne über [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). Die Potenz‑Trendlinie erstreckt eine Kategorie nach hinten über [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trendlinienabschnitt festlegen**

Verwenden Sie [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-), um den Y‑Wert einer Trendlinie bei X = 0 festzulegen. Diese Einstellung wird für lineare, exponentielle und polynomische Trendlinien unterstützt.

Beispielsweise muss ein Modell für Produktionskosten bei bekannten Fixkosten von 100 beginnen, selbst wenn Messungen bei von Null verschiedenen Produktionsmengen eine andere Basislinie nahelegen. Bei einer linearen Trendlinie bewirkt das Festlegen des Schnittpunkts, dass die Gleichung `y = ax + b` zu `b = 100` wird; die Steigung wird unter dieser Einschränkung an die Daten angepasst. Es wird nicht einfach eine bereits angepasste Linie verschoben. Die Einstellungen für den Achsenkreuzungspunkt bestimmen, wo die Diagrammachsen sich treffen, nicht die Koeffizienten der angepassten Trendlinie.

Das folgende Beispiel erstellt ein Streudiagramm (XY) mit Produktionsmengen von 1 bis 4 und Kosten von 170, 200, 230 und 260. Es speichert das Diagramm mit dem standardmäßigen automatischen Schnittpunkt, setzt den Schnittpunkt auf 100 und speichert eine zweite PPTX. Die beiden Dateien unterscheiden sich nur in der Schnittpunkt‑Einstellung. Die Trendlinie zeigt ihre Gleichung an und erstreckt sich zurück zu X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bei automatischer Berechnung ergeben diese Daten `y = 30x + 140`. Das Festlegen des Schnittpunkts auf 100 erzeugt etwa `y = 43.33x + 100`: Der angepasste Wert bei Null entspricht dem bekannten Basiswert, während die Linie nicht mehr durch jeden Datenpunkt verläuft.

| Automatischer Schnittpunkt | Fester Schnittpunkt von 100 |
| --- | --- |
| ![Lineare Trendlinie mit automatisch berechnetem Schnittpunkt von 140](intercept-automatic.png) | ![Lineare Trendlinie mit festem Schnittpunkt von 100](intercept-fixed.png) |

Beide Bilder verwenden dieselben Daten und Achsenskalierungen. Die Trendlinien werden zurück zu X = 0 erweitert, um ihre Schnittpunkte zu zeigen.

Standardmäßig liefert [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) `Double.NaN`, was einen nicht angegebenen Schnittpunkt statt null darstellt. Der Schnittpunkt wird dann automatisch aus den Daten berechnet.

## **Benutzerdefinierte Linie hinzufügen**

Eine benutzerdefinierte Linie ist eine Form, die über dem Diagramm gezeichnet wird, anstatt einer Trendlinie, die aus den Seriendaten berechnet wird. Dieses Beispiel verwendet [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-), um eine horizontale Linie zur Folie über dem Diagramm hinzuzufügen. Die Position der Linie wird in Folienkoordinaten angegeben, gemessen in Punkten, sodass sie am linken Rand des Diagramms beginnt und halbwegs in der Höhe des Diagramms liegt. Die Breite entspricht der Diagrammbreite. Der [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) gibt der Linie eine durchgezogene rote Farbe.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was bedeuten 'forward' und 'backward' bei einer Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. nach hinten projiziert werden: Für Streudiagramme (XY) – in Achseeinheiten; für Nicht‑Streudiagramme – in Anzahl der Kategorien. Nur nicht negative Werte sind zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie als Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/java/convert-powerpoint-to-pdf/) oder [SVG](/slides/de/java/render-a-slide-as-an-svg-image/) und rendert Diagramme als Bilder; Trendlinien, als Teil des Diagramms, bleiben bei diesen Vorgängen erhalten. Es gibt zudem eine Methode, um ein Bild des Diagramms selbst [ein Bild des Diagramms exportieren](/slides/de/java/create-shape-thumbnails/).