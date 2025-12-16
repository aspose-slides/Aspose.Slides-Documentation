---
title: Bubble-Charts in Präsentationen auf Android anpassen
linktitle: Blasendiagramm
type: docs
url: /de/androidjava/bubble-chart/
keywords:
- Blasendiagramm
- Blasengröße
- Größen-Skalierung
- Größen-Darstellung
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen und passen Sie leistungsstarke Blasendiagramme in PowerPoint mit Aspose.Slides für Android über Java an, um Ihre Datenvisualisierung einfach zu verbessern."
---

## **Skalierung der Bubble-Chart-Größe**
Aspose.Slides for Android via Java bietet Unterstützung für die Skalierung der Bubble-Chart-Größe. In Aspose.Slides for Android via Java wurden die Methoden [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--) , [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) und [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) hinzugefügt. Ein Beispiel ist unten angegeben. 
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


## **Daten als Bubble-Chart-Größen darstellen**
Methoden [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) und [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) wurden zu den Schnittstellen [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) sowie zu den zugehörigen Klassen hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Bubble‑Größenwerte im Bubble‑Chart dargestellt werden. Mögliche Werte sind: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) und [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Dementsprechend wurde das Aufzählungselement [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) hinzugefügt, um die möglichen Darstellungsarten für Bubble‑Chart‑Größen zu spezifizieren. Beispielcode ist unten angegeben.
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

**Wird ein „Bubble‑Chart mit 3‑D‑Effekt“ unterstützt und wie unterscheidet es sich von einem normalen?**

Ja. Es gibt einen eigenen Diagrammtyp „Bubble with 3‑D“. Dieser wendet eine 3‑D‑Darstellung auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der Klasse [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) verfügbar.

**Gibt es ein Limit für die Anzahl von Reihen und Punkten in einem Bubble‑Chart?**

Auf API‑Ebene gibt es kein festes Limit; die Grenzen werden durch Leistung und die Ziel‑PowerPoint‑Version bestimmt. Es wird empfohlen, die Punktzahl für Lesbarkeit und Rendering‑Geschwindigkeit überschaubar zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Bubble‑Charts aus (PDF, Bilder)?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendering erfolgt durch die Aspose.Slides‑Engine. Für Raster‑/Vektor‑Formate gelten die üblichen Diagramm‑Rendering‑Regeln (Auflösung, Antialiasing), sodass für den Druck eine ausreichende DPI gewählt werden sollte.