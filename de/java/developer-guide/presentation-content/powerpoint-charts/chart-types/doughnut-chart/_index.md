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
## **Übersicht**

Dieser Artikel zeigt, wie man mit einem Donut‑Diagramm in Aspose.Slides arbeitet, indem man das Diagramm zu einer Folie hinzufügt, die Größe des mittleren Lochs festlegt und die Präsentation speichert. Er konzentriert sich auf die `setDoughnutHoleSize`‑Methode und demonstriert die grundlegenden Schritte, die erforderlich sind, um diesen Diagrammtyp im Code anzupassen.

Er enthält außerdem ein kurzes FAQ, das verwandte Donut‑Diagramm‑Szenarien abdeckt, z. B. die Verwendung mehrerer Serien zum Erzeugen mehrerer Ringe, das Arbeiten mit explodierten Donut‑Diagrammen und das Exportieren eines Diagramms als Raster‑Bild oder SVG.

## **Zentralen Abstand im Donut‑Diagramm festlegen**
{{% alert color="info" %}} 
Aspose.Slides for Java unterstützt jetzt die Angabe der Größe des Lochs in einem Donut‑Diagramm. In diesem Thema sehen wir anhand eines Beispiels, wie die Größe des Lochs in einem Donut‑Diagramm angegeben wird.
{{% /alert %}} 

Um die Größe des Lochs in einem Donut‑Diagramm anzugeben, führen Sie die folgenden Schritte aus:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation)‑Objekt.
1. Fügen Sie ein Donut‑Diagramm zur Folie hinzu.
1. Geben Sie die Größe des Lochs im Donut‑Diagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Größe des Lochs in einem Donut‑Diagramm festgelegt.

```java
import com.aspose.slides.*;

// Eine Instanz der Presentation-Klasse erstellen
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

### Kann ich ein mehrstufiges Donut‑Diagramm mit mehreren Ringen erstellen?

Ja. Fügen Sie mehrere Serien zu einem einzigen Donut‑Diagramm hinzu – jede Serie wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

### Wird ein „explodiertes“ Donut‑Diagramm (getrennte Segmente) unterstützt?

Ja. Es gibt einen Exploded Donut‑[chart type](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente separat darstellen.

### Wie kann ich ein Bild eines Donut‑Diagramms (PNG/SVG) für einen Bericht erhalten?

Ein Diagramm ist eine Form; Sie können es in ein [raster image](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getImage-int-float-float-) rendern oder das Diagramm in ein [SVG image](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) exportieren.