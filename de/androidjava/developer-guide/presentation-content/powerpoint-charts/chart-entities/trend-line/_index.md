---
title: Trendlinie
type: docs
url: /de/androidjava/trend-line/
---

## **Trendlinie hinzufügen**
Aspose.Slides für Android über Java bietet eine einfache API zur Verwaltung verschiedener Diagramm-Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie eine Referenz auf die Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie eines gewünschten Typs hinzu (dieses Beispiel verwendet ChartType.ClusteredColumn).
1. Hinzufügen einer exponentiellen Trendlinie für das Diagramm-Datenserie 1.
1. Hinzufügen einer linearen Trendlinie für das Diagramm-Datenserie 1.
1. Hinzufügen einer logarithmischen Trendlinie für das Diagramm-Datenserie 2.
1. Hinzufügen einer gleitenden Durchschnittstrendlinie für das Diagramm-Datenserie 2.
1. Hinzufügen einer polynomialen Trendlinie für das Diagramm-Datenserie 3.
1. Hinzufügen einer Potenztrendlinie für das Diagramm-Datenserie 3.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Erstellen eines gruppierten Säulendiagramms
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Hinzufügen einer exponentiellen Trendlinie für das Diagramm-Datenserie 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Hinzufügen einer linearen Trendlinie für das Diagramm-Datenserie 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Hinzufügen einer logarithmischen Trendlinie für das Diagramm-Datenserie 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("Neue logarithmische Trendlinie");
    
    // Hinzufügen einer gleitenden Durchschnittstrendlinie für das Diagramm-Datenserie 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("Neuer Trendlinienname");
    
    // Hinzufügen einer polynomialen Trendlinie für das Diagramm-Datenserie 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Hinzufügen einer Potenztrendlinie für das Diagramm-Datenserie 3
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
Aspose.Slides für Android über Java bietet eine einfache API, um benutzerdefinierte Linien in ein Diagramm einzufügen. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse
- Erhalten Sie die Referenz auf eine Folie, indem Sie ihren Index verwenden
- Erstellen Sie ein neues Diagramm mit der AddChart-Methode, die vom Shapes-Objekt bereitgestellt wird
- Fügen Sie eine AutoShape vom Typ Linie mit der AddAutoShape-Methode hinzu, die vom Shapes-Objekt bereitgestellt wird
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