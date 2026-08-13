---
title: Personalizar gráficos de rosquilla en presentaciones en Android
linktitle: Gráfico de rosquilla
type: docs
weight: 30
url: /es/androidjava/doughnut-chart/
keywords:
- gráfico de rosquilla
- espacio central
- tamaño del agujero
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Descubra cómo crear y personalizar gráficos de rosquilla en Aspose.Slides para Android mediante Java, compatible con los formatos de PowerPoint para presentaciones dinámicas."
---
## **Visión general**

Este artículo muestra cómo trabajar con un gráfico de rosquilla en Aspose.Slides añadiendo el gráfico a una diapositiva, estableciendo el tamaño del agujero central y guardando la presentación. Se centra en el método `setDoughnutHoleSize` y demuestra los pasos básicos necesarios para personalizar este tipo de gráfico mediante código.

También incluye una breve sección de preguntas frecuentes que cubre escenarios relacionados con gráficos de rosquilla, como usar varias series para crear varios anillos, trabajar con gráficos de rosquilla explotados y exportar un gráfico como imagen rasterizada o SVG.

## **Especificar el espacio central en un gráfico de rosquilla**
{{% alert color="info" %}} 

Aspose.Slides para Android a través de Java ahora admite especificar el tamaño del agujero en un gráfico de rosquilla. En este tema, veremos con un ejemplo cómo especificar el tamaño del agujero en un gráfico de rosquilla.

{{% /alert %}} 

Para especificar el tamaño del agujero en un gráfico de rosquilla, siga los pasos a continuación:

1. Instanciar el objeto [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).
1. Agregar un gráfico de rosquilla a la diapositiva.
1. Especificar el tamaño del agujero en un gráfico de rosquilla.
1. Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos establecido el tamaño del agujero en un gráfico de rosquilla.

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

### ¿Puedo crear una rosquilla multinivel con varios anillos?

Sí. Añada varias series a un único gráfico de rosquilla; cada serie se convierte en un anillo independiente. El orden de los anillos se determina por el orden de las series en la colección.

### ¿Se admite una rosquilla "explotada" (rebanadas separadas)?

Sí. Existe un [tipo de gráfico](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/charttype/) de rosquilla explotada y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.

### ¿Cómo puedo obtener una imagen de un gráfico de rosquilla (PNG/SVG) para un informe?

Un gráfico es una forma; puede renderizarlo a una [imagen rasterizada](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) o exportar el gráfico a una [imagen SVG](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).