---
title: Doughnut-Diagramme in Präsentationen mit Java anpassen
linktitle: Doughnut-Diagramm
type: docs
weight: 30
url: /de/java/doughnut-chart/
keywords:
- Doughnut-Diagramm
- Zentraler Abstand
- Lochgröße
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Doughnut-Diagramme in Aspose.Slides für Java erstellen und anpassen können, wobei PowerPoint-Formate für dynamische Präsentationen unterstützt werden."
---

## **Zentralen Abstand im Donutdiagramm angeben**
{{% alert color="primary" %}} 

Aspose.Slides for Java unterstützt jetzt die Angabe der Lochgröße in einem Donutdiagramm. In diesem Thema sehen wir anhand eines Beispiels, wie die Lochgröße in einem Donutdiagramm angegeben wird.

{{% /alert %}} 

Um die Lochgröße in einem Donutdiagramm anzugeben, führen Sie die folgenden Schritte aus:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)-Objekt.
1. Fügen Sie dem Folie ein Donutdiagramm hinzu.
1. Geben Sie die Größe des Lochs im Donutdiagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Größe des Lochs im Donutdiagramm festgelegt.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Präsentation auf Festplatte schreiben
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich einen mehrstufigen Donut mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donutdiagramm mehrere Serien hinzu – jede Serie wird zu einem eigenen Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

**Wird ein „explodierter“ Donut (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Exploded Doughnut [Diagrammtyp](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donutdiagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es in ein [Rasterbild](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) rendern oder das Diagramm in ein [SVG‑Bild](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) exportieren.