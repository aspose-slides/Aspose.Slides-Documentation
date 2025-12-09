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
- Polynomialtrendlinie
- Potenztrendlinie
- Benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint-Diagrammen mit Aspose.Slides für Java schnell hinzu und passen Sie sie an – ein praxisorientierter Leitfaden, um Ihr Publikum zu fesseln."
---

## **Trendlinie hinzufügen**
Aspose.Slides for Java provides a simple API for managing different chart Trend Lines:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Diagrammtyp hinzu (in diesem Beispiel wird ChartType.ClusteredColumn verwendet).
4. Exponentialtrendlinie für Diagrammserie 1 hinzufügen.
5. Lineare Trendlinie für Diagrammserie 1 hinzufügen.
6. Logarithmische Trendlinie für Diagrammserie 2 hinzufügen.
7. Trendlinie für gleitenden Durchschnitt für Diagrammserie 2 hinzufügen.
8. Polynomialtrendlinie für Diagrammserie 3 hinzufügen.
9. Potenztrendlinie für Diagrammserie 3 hinzufügen.
10. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

The following code is used to create a chart with Trend Lines.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Erstellen eines gruppierten Säulendiagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Hinzufügen einer exponentiellen Trendlinie für Diagrammserie 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Hinzufügen einer linearen Trendlinie für Diagrammserie 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Hinzufügen einer logarithmischen Trendlinie für Diagrammserie 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Hinzufügen einer gleitenden Mittelwert-Trendlinie für Diagrammserie 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Hinzufügen einer polynomialen Trendlinie für Diagrammserie 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Hinzufügen einer Potenz-Trendlinie für Diagrammserie 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Präsentation speichern
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides for Java provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden
- Erstellen Sie ein neues Diagramm mit der AddChart‑Methode, die vom Shapes‑Objekt bereitgestellt wird
- Fügen Sie eine AutoShape vom Typ Linie mithilfe der AddAutoShape‑Methode des Shapes‑Objekts hinzu
- Setzen Sie die Farbe der Formlinien
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei

The following code is used to create a chart with Custom Lines.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Was bedeuten 'forward' und 'backward' für eine Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. hinten projiziert werden: für Streudiagramme (XY) — in Achsen‑Einheiten; für Nicht‑Streudiagramme — in Anzahl der Kategorien. Nur nichtnegative Werte sind zulässig.

**Bleibt die Trendlinie erhalten, wenn die Präsentation nach PDF oder SVG exportiert oder eine Folie als Bild gerendert wird?**

Ja. Aspose.Slides konvertiert Präsentationen in [PDF](/slides/de/java/convert-powerpoint-to-pdf/)/[SVG](/slides/de/java/render-a-slide-as-an-svg-image/) und rendert Diagramme als Bilder; Trendlinien bleiben dabei als Teil des Diagramms erhalten. Es gibt zudem eine Methode, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/java/create-shape-thumbnails/).