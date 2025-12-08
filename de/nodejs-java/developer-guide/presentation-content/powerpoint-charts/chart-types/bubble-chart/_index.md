---
title: Blasendiagramm
type: docs
url: /de/nodejs-java/bubble-chart/
---

## **Skalierung der Bubble‑Diagrammgröße**
Aspose.Slides für Node.js via Java bietet Unterstützung für die Skalierung der Bubble‑Diagrammgröße. In Aspose.Slides für Node.js via Java wurden die Methoden [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--) , [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) und [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) hinzugefügt. Nachstehendes Beispiel wird angegeben. 
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Daten als Bubble‑diagrammgrößen darstellen**
Methoden [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) und [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) wurden zu den Klassen [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries) , [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup) und verwandten Klassen hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Bubble‑Größenwerte im Bubble‑Diagramm dargestellt werden. Mögliche Werte sind: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) und [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Entsprechend wurde das Aufzählungs­element [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType) hinzugefügt, um die möglichen Darstellungsweisen für Daten als Bubble‑Diagrammgrößen zu spezifizieren. Beispielcode wird nachfolgend gezeigt. 
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wird ein "Bubble‑Diagramm mit 3‑D‑Effekt" unterstützt und wie unterscheidet es sich von einem normalen?**

Ja. Es gibt einen separaten Diagrammtyp, "Bubble mit 3‑D". Er wendet 3‑D‑Styling auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der Aufzählung [chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) verfügbar.

**Gibt es eine Begrenzung für die Anzahl der Serien und Punkte in einem Bubble‑Diagramm?**

Auf API‑Ebene gibt es keine feste Begrenzung; die Einschränkungen ergeben sich aus Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Punktzahl für Lesbarkeit und Render‑Geschwindigkeit angemessen zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Bubble‑Diagramms aus (PDF, Bilder)?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendering erfolgt durch die Aspose.Slides‑Engine. Für Raster‑/Vektor‑Formate gelten allgemeine Rendering‑Regeln für Diagrammgrafiken (Auflösung, Anti‑Aliasing), wählen Sie daher eine ausreichende DPI für den Druck.