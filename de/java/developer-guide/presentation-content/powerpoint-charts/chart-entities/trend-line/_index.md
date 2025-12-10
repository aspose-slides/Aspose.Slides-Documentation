---
title: Trendlinien zu Präsentationsdiagrammen in Java hinzufügen
linktitle: Trendlinie
type: docs
url: /de/java/trend-line/
keywords:
- Diagramm
- Trendlinie
- exponentielle Trendlinie
- lineare Trendlinie
- logarithmische Trendlinie
- gleitender Durchschnitt Trendlinie
- polynomiale Trendlinie
- Potenz‑Trendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Trendlinien schnell zu PowerPoint‑Diagrammen mit Aspose.Slides für Java hinzufügen und anpassen — ein praxisnaher Leitfaden, um Ihr Publikum zu begeistern."
---

## **Trendlinie hinzufügen**
Aspose.Slides for Java bietet eine einfache API zum Verwalten verschiedener Diagramm‑Trendlinien:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (dieses Beispiel verwendet ChartType.ClusteredColumn).
4. Exponential‑Trendlinie für Diagrammreihe 1 hinzufügen.
5. Lineare Trendlinie für Diagrammreihe 1 hinzufügen.
6. Logarithmische Trendlinie für Diagrammreihe 2 hinzufügen.
7. Gleitende‑Durchschnitt‑Trendlinie für Diagrammreihe 2 hinzufügen.
8. Polynomiale Trendlinie für Diagrammreihe 3 hinzufügen.
9. Potenz‑Trendlinie für Diagrammreihe 3 hinzufügen.
10. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Erstellen eines gruppierten Säulendiagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Exponentielle Trendlinie für Diagrammreihe 1 hinzufügen
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Lineare Trendlinie für Diagrammreihe 1 hinzufügen
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Logarithmische Trendlinie für Diagrammreihe 2 hinzufügen
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Gleitende Durchschnitt Trendlinie für Diagrammreihe 2 hinzufügen
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Polynomial‑Trendlinie für Diagrammreihe 3 hinzufügen
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Potenz‑Trendlinie für Diagrammreihe 3 hinzufügen
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
Aspose.Slides for Java bietet eine einfache API, um benutzerdefinierte Linien in einem Diagramm hinzuzufügen. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie über ihren Index.
- Erstellen Sie ein neues Diagramm mit der Methode AddChart, die vom Shapes‑Objekt bereitgestellt wird.
- Fügen Sie mit der Methode AddAutoShape, die vom Shapes‑Objekt bereitgestellt wird, ein AutoShape vom Typ Linie hinzu.
- Setzen Sie die Farbe der Formlinien.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.
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

**Was bedeuten 'forward' und 'backward' bei einer Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. zurück projiziert werden: Für Scatter‑(XY‑)Diagramme in Achseneinheiten; für Nicht‑Scatter‑Diagramme in Kategorienanzahl. Es sind nur nicht‑negative Werte zulässig.

**Wird die Trendlinie beim Exportieren der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie als Bild beibehalten?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/java/convert-powerpoint-to-pdf/)/[SVG](/slides/de/java/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien, als Teil des Diagramms, bleiben bei diesen Vorgängen erhalten. Zudem ist eine Methode verfügbar, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/java/create-shape-thumbnails/).