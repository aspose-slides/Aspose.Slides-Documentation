---
title: Personalizar gráficos de dona en presentaciones usando Java
linktitle: Gráfico de dona
type: docs
weight: 30
url: /es/java/doughnut-chart/
keywords:
- gráfico de dona
- espacio central
- tamaño del agujero
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Descubra cómo crear y personalizar gráficos de dona en Aspose.Slides for Java, compatible con formatos de PowerPoint para presentaciones dinámicas."
---

## **Cambiar el espacio central en un gráfico de dona**
{{% alert color="primary" %}} 

Aspose.Slides for Java ahora admite especificar el tamaño del agujero en un gráfico de dona. En este tema, veremos con un ejemplo cómo especificar el tamaño del agujero en un gráfico de dona.

{{% /alert %}} 

Para especificar el tamaño del agujero en un gráfico de dona, siga los pasos a continuación:

1. Instanciar el objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Agregar un gráfico de dona en la diapositiva.
1. Especificar el tamaño del agujero en un gráfico de dona.
1. Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos establecido el tamaño del agujero en un gráfico de dona.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Guardar la presentación en disco
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Puedo crear una dona multinivel con varios anillos?**

Sí. Añada varias series a un único gráfico de dona; cada serie se convierte en un anillo separado. El orden de los anillos se determina por el orden de las series en la colección.

**¿Se admite una dona "explosiva" (porciones separadas)?**

Sí. Existe un tipo de gráfico [Exploded Doughnut](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) y una propiedad de explosión en los puntos de datos; puede separar porciones individuales.

**¿Cómo puedo obtener una imagen de un gráfico de dona (PNG/SVG) para un informe?**

Un gráfico es una forma; puede renderizarlo a una [raster image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) o exportar el gráfico a una [SVG image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).