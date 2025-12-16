---
title: Trendlinien zu Präsentationsdiagrammen auf Android hinzufügen
linktitle: Trendlinie
type: docs
url: /de/androidjava/trend-line/
keywords:
- Diagramm
- Trendlinie
- Exponentialtrendlinie
- Lineare Trendlinie
- Logarithmische Trendlinie
- Trendlinie des gleitenden Durchschnitts
- Polynomialtrendlinie
- Potenztrendlinie
- Benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Fügen Sie schnell Trendlinien in PowerPoint-Diagrammen mit Aspose.Slides für Android via Java hinzu und passen Sie sie an – ein praxisnaher Leitfaden, um Ihr Publikum zu begeistern."
---

## **Trendlinie hinzufügen**
Aspose.Slides für Android via Java bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Trendlinien:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Rufen Sie die Referenz einer Folie über ihren Index ab.
1. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (in diesem Beispiel wird ChartType.ClusteredColumn verwendet).
1. Hinzufügen einer exponentiellen Trendlinie für Diagrammreihe 1.
1. Hinzufügen einer linearen Trendlinie für Diagrammreihe 1.
1. Hinzufügen einer logarithmischen Trendlinie für Diagrammreihe 2.
1. Hinzufügen einer gleitenden Mittelwert‑Trendlinie für Diagrammreihe 2.
1. Hinzufügen einer polynomialen Trendlinie für Diagrammreihe 3.
1. Hinzufügen einer Potenz‑Trendlinie für Diagrammreihe 3.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.
```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Erstelle ein gruppiertes Säulendiagramm
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Füge eine exponentielle Trendlinie für Diagrammreihe 1 hinzu
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Füge eine lineare Trendlinie für Diagrammreihe 1 hinzu
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Füge eine logarithmische Trendlinie für Diagrammreihe 2 hinzu
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Füge eine Trendlinie für gleitenden Mittelwert für Diagrammreihe 2 hinzu
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Füge eine polynomiale Trendlinie für Diagrammreihe 3 hinzu
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Füge eine Potenz-Trendlinie für Diagrammreihe 3 hinzu
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Speichere die Präsentation
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für Android via Java bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in ein Diagramm. Um eine einfache, gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die nachstehenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Rufen Sie die Referenz einer Folie mittels ihres Index ab.
- Erstellen Sie ein neues Diagramm mit der Methode AddChart, die vom Shapes‑Objekt bereitgestellt wird.
- Fügen Sie eine AutoShape vom Typ Linie mit der Methode AddAutoShape hinzu, die vom Shapes‑Objekt bereitgestellt wird.
- Setzen Sie die Farbe der Formlinien.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.
```java
// Erstelle eine Instanz der Presentation-Klasse
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

**Was bedeuten „forward“ und „backward“ bei einer Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. hinten projiziert werden: Bei Streudiagrammen (XY) in Achseneinheiten; bei Nicht‑Streudiagrammen in der Anzahl der Kategorien. Es sind nur nicht negative Werte zulässig.

**Wird die Trendlinie bei der Exportierung der Präsentation in PDF oder SVG bzw. beim Rendern einer Folie als Bild beibehalten?**

Ja. Aspose.Slides konvertiert Präsentationen in [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/de/androidjava/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien werden dabei als Teil des Diagramms erhalten. Außerdem steht eine Methode zum [Exportieren eines Bildes des Diagramms](/slides/de/androidjava/create-shape-thumbnails/) bereit.