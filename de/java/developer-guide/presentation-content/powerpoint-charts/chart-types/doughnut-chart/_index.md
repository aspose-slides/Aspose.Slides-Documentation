---
title: Donut-Diagramm
type: docs
weight: 30
url: /de/java/doughnut-chart/
---

## **Ändern des Zentrumslochs im Donut-Diagramm**
{{% alert color="primary" %}} 

Aspose.Slides für Java unterstützt nun die Angabe der Größe des Lochs in einem Donut-Diagramm. In diesem Thema werden wir anhand eines Beispiels sehen, wie man die Größe des Lochs in einem Donut-Diagramm angibt.

{{% /alert %}} 

Um die Größe des Lochs in einem Donut-Diagramm anzugeben, befolgen Sie bitte die folgenden Schritte:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Objekt.
1. Fügen Sie ein Donut-Diagramm auf der Folie hinzu.
1. Geben Sie die Größe des Lochs in einem Donut-Diagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im unten stehenden Beispiel haben wir die Größe des Lochs in einem Donut-Diagramm festgelegt.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Schreiben Sie die Präsentation auf die Festplatte
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```