---
title: Trendlinie
type: docs
url: /java/trend-line/
---

## **Trendlinie hinzufügen**
Aspose.Slides für Java bietet eine einfache API zur Verwaltung von verschiedenen Diagramm-Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie eine Referenz zu einem Slide anhand seines Index.
1. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (in diesem Beispiel wird ChartType.ClusteredColumn verwendet).
1. Hinzufügen einer exponentiellen Trendlinie für Diagrammreihe 1.
1. Hinzufügen einer linearen Trendlinie für Diagrammreihe 1.
1. Hinzufügen einer logarithmischen Trendlinie für Diagrammreihe 2.
1. Hinzufügen einer gleitenden Durchschnittstrendlinie für Diagrammreihe 2.
1. Hinzufügen einer polynomialen Trendlinie für Diagrammreihe 3.
1. Hinzufügen einer Potenz-Trendlinie für Diagrammreihe 3.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Erstellen eines gruppierten Säulendiagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Hinzufügen einer exponentiellen Trendlinie für Diagrammreihe 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Hinzufügen einer linearen Trendlinie für Diagrammreihe 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Hinzufügen einer logarithmischen Trendlinie für Diagrammreihe 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("Neue log-Trendlinie");
    
    // Hinzufügen einer gleitenden Durchschnittstrendlinie für Diagrammreihe 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("Neue Trendlinienbezeichnung");
    
    // Hinzufügen einer polynomialen Trendlinie für Diagrammreihe 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Hinzufügen einer Potenz-Trendlinie für Diagrammreihe 3
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
Aspose.Slides für Java bietet eine einfache API, um benutzerdefinierte Linien in einem Diagramm hinzuzufügen. Um eine einfache Linie zu einem ausgewählten Slide der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse
- Erhalten Sie die Referenz eines Slides, indem Sie seinen Index verwenden
- Erstellen Sie ein neues Diagramm mit der AddChart-Methode des Shapes-Objekts
- Fügen Sie eine AutoShape vom Typ Linie mit der AddAutoShape-Methode des Shapes-Objekts hinzu
- Setzen Sie die Farbe der Linien des Shapes.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
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