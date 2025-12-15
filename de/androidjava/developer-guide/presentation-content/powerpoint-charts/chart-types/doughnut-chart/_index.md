---
title: Anpassen von Donutdiagrammen in Präsentationen auf Android
linktitle: Donutdiagramm
type: docs
weight: 30
url: /de/androidjava/doughnut-chart/
keywords:
- Donutdiagramm
- Mittelspalt
- Lochgröße
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Donutdiagramme in Aspose.Slides für Android über Java erstellen und anpassen können, wobei PowerPoint-Formate für dynamische Präsentationen unterstützt werden."
---

## **Geben Sie die Lücke in der Mitte eines Donutdiagramms an**
{{% alert color="primary" %}} 

Aspose.Slides für Android über Java unterstützt jetzt die Angabe der Lochgröße in einem Donutdiagramm. In diesem Thema sehen wir anhand eines Beispiels, wie die Lochgröße in einem Donutdiagramm angegeben wird.

{{% /alert %}} 

Um die Größe des Lochs in einem Donutdiagramm anzugeben, folgen Sie bitte den untenstehenden Schritten:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)-Objekt.
1. Fügen Sie der Folie ein Donutdiagramm hinzu.
1. Geben Sie die Größe des Lochs in einem Donutdiagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im untenstehenden Beispiel haben wir die Größe des Lochs in einem Donutdiagramm festgelegt.
```java
// Erstellen Sie eine Instanz der Presentation-Klasse
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

**Kann ich einen mehrstufigen Donut mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donutdiagramm mehrere Serien hinzu – jede Serie wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

**Wird ein "explodierter" Donut (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Exploded Doughnut [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) und eine Explosions-Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donutdiagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es in ein [raster image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) rendern oder das Diagramm in ein [SVG image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) exportieren.