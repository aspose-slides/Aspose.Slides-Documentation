---
title: Exporter un graphique
type: docs
weight: 90
url: /java/export-chart/
---

## **Obtenir l'image du graphique**
Aspose.Slides pour Java fournit un support pour extraire l'image d'un graphique spécifique. Un exemple de code est donné ci-dessous.

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