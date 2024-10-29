---
title: Gráfico de Dona
type: docs
weight: 30
url: /es/java/doughnut-chart/
---

## **Cambiar el Tamaño del Hueco en el Gráfico de Dona**
{{% alert color="primary" %}} 

Aspose.Slides para Java ahora admite especificar el tamaño del agujero en un gráfico de dona. En este tema, veremos con un ejemplo cómo especificar el tamaño del agujero en un gráfico de dona.

{{% /alert %}} 

Para especificar el tamaño del agujero en un gráfico de dona, siga los pasos a continuación:

1. Instanciar el objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Agregar un gráfico de dona en la diapositiva.
1. Especificar el tamaño del agujero en un gráfico de dona.
1. Escribir la presentación en el disco.

En el ejemplo dado a continuación, hemos establecido el tamaño del agujero en un gráfico de dona.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Escribir la presentación en el disco
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```