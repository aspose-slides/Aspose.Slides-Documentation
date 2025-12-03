---
title: Anpassen von Donut-Diagrammen in Präsentationen mit Java
linktitle: Donut-Diagramm
type: docs
weight: 30
url: /de/java/doughnut-chart/
keywords:
- Donut-Diagramm
- zentraler Abstand
- Lochgröße
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Donut-Diagramme in Aspose.Slides für Java erstellen und anpassen, wobei PowerPoint-Formate für dynamische Präsentationen unterstützt werden."
---

## **Zentralen Abstand im Donut-Diagramm ändern**
{{% alert color="primary" %}} 

Aspose.Slides für Java unterstützt jetzt die Angabe der Lochgröße in einem Donut-Diagramm. In diesem Thema zeigen wir anhand eines Beispiels, wie die Lochgröße in einem Donut-Diagramm festgelegt wird.

{{% /alert %}} 

Um die Lochgröße in einem Donut-Diagramm festzulegen, führen Sie die folgenden Schritte aus:

1. Instanziieren Sie das Objekt [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Fügen Sie der Folie ein Donut-Diagramm hinzu.
1. Geben Sie die Größe des Lochs in einem Donut-Diagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Größe des Lochs in einem Donut-Diagramm festgelegt.
```java
// Instanz der Klasse Presentation erstellen
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Präsentation auf die Festplatte schreiben
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich ein mehrstufiges Donut-Diagramm mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donut-Diagramm mehrere Serien hinzu – jede Serie wird zu einem eigenen Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

**Wird ein „explodiertes“ Donut-Diagramm (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Diagrammtyp Exploded Doughnut [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donut-Diagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es in ein [Raster‑Bild](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) rendern oder das Diagramm in ein [SVG‑Bild](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) exportieren.