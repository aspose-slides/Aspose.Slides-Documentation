---
title: Benutzerdefinierte Bubble-Diagramme in Präsentationen mit Java
linktitle: Bubble-Diagramm
type: docs
url: /de/java/bubble-chart/
keywords:
- Bubble-Diagramm
- Bubble-Größe
- Größenskalierung
- Größenrepräsentation
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen und Anpassen leistungsstarker Bubble-Diagramme in PowerPoint mit Aspose.Slides für Java, um Ihre Datenvisualisierung mühelos zu verbessern."
---

## **Skalierung der Bubble‑Diagrammgröße**
Aspose.Slides for Java bietet Unterstützung für die Skalierung von Bubble‑Diagrammgrößen. In Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--) , [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) und [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) Methoden wurden hinzugefügt. Nachfolgend ein Beispiel.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Daten als Bubble‑Diagrammgrößen darstellen**
Methoden [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) und [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) wurden zu den Schnittstellen [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries) und [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup) sowie zu zugehörigen Klassen hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Bubble‑Größenwerte im Bubble‑Diagramm dargestellt werden. Mögliche Werte sind: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Area) und [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Entsprechend wurde das [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType) Enum hinzugefügt, um die möglichen Darstellungsweisen von Daten als Bubble‑Diagrammgrößen zu spezifizieren. Beispielcode ist unten angegeben.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wird ein „Bubble‑Diagramm mit 3‑D‑Effekt“ unterstützt und wie unterscheidet es sich von einem normalen Diagramm?**

Ja. Es gibt einen eigenen Diagrammtyp „Bubble mit 3‑D“. Er wendet 3‑D‑Styling auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der Klasse [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) verfügbar.

**Gibt es eine Begrenzung für die Anzahl von Serien und Punkten in einem Bubble‑Diagramm?**

Auf API‑Ebene gibt es kein festes Limit; die Beschränkungen ergeben sich aus der Performance und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Punktezahl für Lesbarkeit und Rendering‑Geschwindigkeit angemessen zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Bubble‑Diagramms (PDF, Bilder) aus?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendering wird von der Aspose.Slides‑Engine durchgeführt. Für Raster‑/Vektor‑Formate gelten die allgemeinen Rendering‑Regeln für Diagramme (Auflösung, Antialiasing), daher sollte für den Druck eine ausreichend hohe DPI gewählt werden.