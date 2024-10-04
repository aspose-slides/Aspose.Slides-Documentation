---
title: Exportar Gráfico
type: docs
weight: 90
url: /androidjava/export-chart/
---

## **Obtener Imagen del Gráfico**
Aspose.Slides para Android a través de Java proporciona soporte para extraer la imagen de un gráfico específico. A continuación se presenta un ejemplo de muestra.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("imagen.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```