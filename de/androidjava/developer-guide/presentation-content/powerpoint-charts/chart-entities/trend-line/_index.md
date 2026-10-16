---
title: Trendlinien zu Präsentationsdiagrammen unter Android hinzufügen
linktitle: Trendlinie
type: docs
url: /de/androidjava/trend-line/
keywords:
- Diagramm
- Trendlinie
- exponentielle Trendlinie
- lineare Trendlinie
- logarithmische Trendlinie
- gleitender Mittelwert Trendlinie
- polynomiale Trendlinie
- Potenz‑Trendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Fügen Sie schnell Trendlinien in PowerPoint‑Diagrammen mit Aspose.Slides für Android via Java hinzu und passen Sie sie an – ein praxisorientierter Leitfaden, um Ihr Publikum zu begeistern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Trendlinien zu Präsentations‑Diagrammen mit Aspose.Slides hinzufügt. Er zeigt, wie man ein Diagramm erstellt, Trendlinien zu Diagramm‑Serien hinzufügt und mit verschiedenen Trendlinientypen arbeitet, darunter exponentiell, linear, logarithmisch, gleitender Mittelwert, polynomial und potenz.  

Er beschreibt zudem, wie man eine benutzerdefinierte Linie zu einem Diagramm hinzufügt, indem man eine Linienform einfügt, und enthält ein kurzes FAQ zu den Vorwärts‑ und Rückwärts‑Projektionswerten von Trendlinien sowie dazu, ob Trendlinien beim Export in PDF oder SVG und beim Rendern von Diagrammen als Bilder erhalten bleiben.

## **Trendlinie hinzufügen**

Verwenden Sie [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) um einer Diagrammserie eine Trendlinie hinzuzufügen, wobei Sie den Typ mit [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/) auswählen. Das Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten und fügt jeder seiner drei Serien zwei Trendlinien hinzu.

Die exponentielle Trendlinie verbirgt ihre Gleichung und den R‑Quadrat‑Wert über [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) und [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), während die lineare Trendlinie rot ist. Die logarithmische Trendlinie verwendet [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) für ein benutzerdefiniertes Label. Der gleitende Mittelwert verwendet ein [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) von drei Datenpunkten und einen benutzerdefinierten [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

Die polynomialen Trendlinie hat ein [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) von drei und erstreckt eine Kategorie nach vorne über [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-). Die Potenz‑Trendlinie erstreckt eine Kategorie nach hinten über [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Trendlinien‑Achsenabschnitt festlegen**

Verwenden Sie [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-), um den Y‑Wert einer Trendlinie bei X = 0 festzulegen. Diese Einstellung wird für lineare, exponentielle und polynomialen Trendlinien unterstützt.

Zum Beispiel kann ein Produktionskostenmodell bei bekannten Fixkosten von 100 beginnen, auch wenn Messungen bei nicht‑null Produktionsvolumina einen anderen Ausgangspunkt nahelegen. Für eine lineare Trendlinie fixiert das Festlegen des Achsenabschnitts die Gleichung `y = ax + b` zu `b = 100`; die Steigung wird unter dieser Einschränkung an die Daten angepasst. Es verschiebt nicht einfach eine bereits angepasste Linie. Achsen‑Kreuzungseinstellungen steuern, wo die Diagrammachsen sich treffen, nicht die Koeffizienten der angepassten Trendlinie.

Das folgende Beispiel erstellt ein Streudiagramm (XY) mit Produktionsvolumina von 1 bis 4 und Kosten von 170, 200, 230 und 260. Es speichert das Diagramm mit dem standardmäßigen automatischen Achsenabschnitt, setzt den Achsenabschnitt auf 100 und speichert ein zweites PPTX. Die beiden Dateien unterscheiden sich nur im Achsenabschnitt. Die Trendlinie zeigt ihre Gleichung und erstreckt sich zurück zu X = 0.

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

Bei automatischer Berechnung ergeben diese Daten `y = 30x + 140`. Das Setzen des Achsenabschnitts auf 100 erzeugt stattdessen etwa `y = 43.33x + 100`: Der angepasste Wert bei Null entspricht dem bekannten Ausgangswert, während die Linie nicht mehr durch jeden Datenpunkt verläuft.

| Automatischer Achsenabschnitt | Fester Achsenabschnitt von 100 |
| --- | --- |
| ![Lineare Trendlinie mit automatisch berechnetem Achsenabschnitt von 140](intercept-automatic.png) | ![Lineare Trendlinie mit festem Achsenabschnitt von 100](intercept-fixed.png) |

Beide Bilder verwenden dieselben Daten und Achsenskalierungen. Die Trendlinien werden zurück zu X = 0 verlängert, um ihre Achsenabschnitte zu zeigen.

Standardmäßig gibt [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) `Double.NaN` zurück, was einen nicht spezifizierten Achsenabschnitt und nicht Null darstellt. Der Achsenabschnitt wird dann automatisch aus den Daten berechnet.

## **Benutzerdefinierte Linie hinzufügen**

Eine benutzerdefinierte Linie ist eine Form, die über das Diagramm gezeichnet wird, anstatt einer Trendlinie, die aus Seriendaten berechnet wird. Dieses Beispiel verwendet [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-), um eine horizontale Linie zur Folie über dem Diagramm hinzuzufügen. Die Position der Linie wird in Folienkoordinaten angegeben, gemessen in Punkten, sodass sie am linken Rand des Diagramms beginnt und halbweg nach unten im Diagramm liegt. Ihre Breite entspricht der Diagrammbreite. Der [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) gibt der Linie eine durchgezogene rote Farbe.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

**Was bedeuten 'forward' und 'backward' für eine Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. nach hinten projiziert werden: für Streudiagramme (XY) – in Achseneinheiten; für Nicht‑Streudiagramme – in Anzahl der Kategorien. Es sind nur nicht‑negative Werte zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie als Bild beibehalten?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/) oder [SVG](/slides/de/androidjava/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Teil des Diagramms, bleiben während dieser Vorgänge erhalten. Es steht zudem eine Methode zur Verfügung, um ein [Bild des Diagramms](/slides/de/androidjava/create-shape-thumbnails/) selbst zu exportieren.