---
title: Diagramm exportieren
type: docs
weight: 90
url: /de/java/export-chart/
---

## **Diagrammbild erhalten**
Aspose.Slides für Java unterstützt das Extrahieren von Bildern spezifischer Diagramme. Unten ist ein Beispiel angegeben.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```