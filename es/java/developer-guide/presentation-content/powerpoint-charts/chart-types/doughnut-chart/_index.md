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
description: "Descubra cómo crear y personalizar gráficos de dona en Aspose.Slides para Java, compatible con formatos PowerPoint para presentaciones dinámicas."
---
## **Visión general**

Este artículo muestra cómo trabajar con un gráfico de dona en Aspose.Slides añadiendo el gráfico a una diapositiva, estableciendo el tamaño del agujero central y guardando la presentación. Se centra en el método `setDoughnutHoleSize` y demuestra los pasos básicos necesarios para personalizar este tipo de gráfico mediante código.

También incluye una breve sección de preguntas frecuentes que cubre escenarios relacionados con gráficos de dona, como el uso de varias series para crear varios anillos, trabajar con gráficos de dona explotados y exportar un gráfico como imagen raster o SVG.

## **Especificar el espacio central en un gráfico de dona**
{{% alert color="info" %}} 

Ahora Aspose.Slides para Java admite la especificación del tamaño del agujero en un gráfico de dona. En este tema, veremos con un ejemplo cómo especificar el tamaño del agujero en un gráfico de dona.

{{% /alert %}} 

Para especificar el tamaño del agujero en un gráfico de dona, siga los pasos a continuación:

1. Instanciar el objeto [Presentación](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation).
2. Añadir un gráfico de dona a la diapositiva.
3. Especificar el tamaño del agujero en un gráfico de dona.
4. Guardar la presentación en disco.

En el ejemplo siguiente, hemos establecido el tamaño del agujero en un gráfico de dona.

```java
import com.aspose.slides.*;

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

## **Preguntas frecuentes**

### ¿Puedo crear una dona de varios niveles con varios anillos?

Sí. Añada varias series a un único gráfico de dona; cada serie se convierte en un anillo separado. El orden de los anillos se determina por el orden de las series en la colección.

### ¿Se admite una dona "explotada" (rebanadas separadas)?

Sí. Existe un tipo de gráfico de Dona Explosada [tipo de gráfico](https://reference.aspose.com/slides/es/java/com.aspose.slides/charttype/) y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.

### ¿Cómo puedo obtener una imagen de un gráfico de dona (PNG/SVG) para un informe?

Un gráfico es una forma; puede renderizarlo a una [imagen raster](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getImage-int-float-float-) o exportar el gráfico a una [imagen SVG](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).