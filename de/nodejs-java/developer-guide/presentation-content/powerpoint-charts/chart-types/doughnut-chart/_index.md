---
title: Donut-Diagramm
type: docs
weight: 30
url: /de/nodejs-java/doughnut-chart/
---

## **Mittlere Lücke im Donut-Diagramm ändern**
{{% alert color="primary" %}} 

Aspose.Slides für Node.js über Java unterstützt jetzt die Angabe der Lochgröße in einem Donut-Diagramm. In diesem Thema zeigen wir anhand eines Beispiels, wie die Lochgröße in einem Donut-Diagramm angegeben wird.

{{% /alert %}} 

Um die Größe des Lochs in einem Donut-Diagramm anzugeben, folgen Sie bitte den untenstehenden Schritten:

1. Instanziieren Sie das Objekt [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Fügen Sie der Folie ein Donut-Diagramm hinzu.
1. Geben Sie die Größe des Lochs im Donut-Diagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir die Größe des Lochs in einem Donut-Diagramm festgelegt.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Speichere die Präsentation auf die Festplatte
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich ein mehrstufiges Donut-Diagramm mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donut-Diagramm mehrere Serien hinzu – jede Serie wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

**Wird ein „explodiertes“ Donut‑Diagramm (getrennte Segmente) unterstützt?**

Ja. Es gibt den Diagrammtyp Exploded Doughnut [chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) und eine Explosions‑Eigenschaft an Datenpunkten; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donut‑Diagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es in ein [Rasterbild](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) rendern oder das Diagramm in ein [SVG‑Bild](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) exportieren.