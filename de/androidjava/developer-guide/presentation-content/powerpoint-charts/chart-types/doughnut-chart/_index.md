---
title: Donutdiagramme in Präsentationen auf Android anpassen
linktitle: Donutdiagramm
type: docs
weight: 30
url: /de/androidjava/doughnut-chart/
keywords:
- Donutdiagramm
- Mittellücke
- Lochgröße
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Donutdiagramme in Aspose.Slides für Android via Java erstellen und anpassen und PowerPoint‑Formate für dynamische Präsentationen unterstützen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man mit einem Donutdiagramm in Aspose.Slides arbeitet, indem man das Diagramm zu einer Folie hinzufügt, die Größe des Mittellochs festlegt und die Präsentation speichert. Er konzentriert sich auf die `setDoughnutHoleSize`-Methode und demonstriert die grundlegenden Schritte, die erforderlich sind, um diesen Diagrammtyp im Code anzupassen.

Er enthält außerdem ein kurzes FAQ, das verwandte Szenarien von Donutdiagrammen abdeckt, wie das Verwenden mehrerer Serien zum Erstellen mehrerer Ringe, die Arbeit mit explodierten Donutdiagrammen und das Exportieren eines Diagramms als Rasterbild oder SVG.

## **Mittellücke in einem Donutdiagramm angeben**
{{% alert color="info" %}} 

Aspose.Slides für Android via Java unterstützt jetzt die Angabe der Lochgröße in einem Donutdiagramm. In diesem Thema zeigen wir anhand eines Beispiels, wie die Lochgröße in einem Donutdiagramm angegeben wird.

{{% /alert %}} 

Um die Größe des Lochs in einem Donutdiagramm anzugeben, folgen Sie bitte den untenstehenden Schritten:

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation)-Objekt.
1. Fügen Sie ein Donutdiagramm zur Folie hinzu.
1. Geben Sie die Größe des Lochs in einem Donutdiagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Größe des Lochs in einem Donutdiagramm festgelegt.

```java
import com.aspose.slides.*;

// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Speichere die Präsentation auf der Festplatte
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Kann ich ein mehrstufiges Donutdiagramm mit mehreren Ringen erstellen?

Ja. Fügen Sie einer einzelnen Donutdiagramm mehrere Serien hinzu – jede Serie wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

### Wird ein „explodiertes“ Donutdiagramm (getrennte Segmente) unterstützt?

Ja. Es gibt einen Exploded Doughnut [chart type](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/charttype/)-Diagrammtyp und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

### Wie kann ich ein Bild eines Donutdiagramms (PNG/SVG) für einen Bericht erhalten?

Ein Diagramm ist eine Form; Sie können es in ein [raster image](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) rendern oder das Diagramm in ein [SVG image](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) exportieren.