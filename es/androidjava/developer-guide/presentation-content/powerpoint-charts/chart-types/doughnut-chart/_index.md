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

## **Especificar el espacio central en un gráfico de rosquilla**
{{% alert color="primary" %}} 
Aspose.Slides para Android mediante Java ahora admite especificar el tamaño del agujero en un gráfico de rosquilla. En este tema, veremos con un ejemplo cómo especificar el tamaño del agujero en un gráfico de rosquilla.
{{% /alert %}} 
Para especificar el tamaño del agujero en un gráfico de rosquilla, siga los pasos a continuación:
1. Instanciar el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Añadir un gráfico de rosquilla en la diapositiva.
1. Especificar el tamaño del agujero en el gráfico de rosquilla.
1. Guardar la presentación en disco.
En el ejemplo que se muestra a continuación, hemos establecido el tamaño del agujero en un gráfico de rosquilla.
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
**¿Puedo crear una rosquilla de varios niveles con varios anillos?**
Sí. Añada varias series a un único gráfico de rosquilla; cada serie se convierte en un anillo separado. El orden de los anillos se determina por el orden de las series en la colección.
**¿Se admite una rosquilla "explotada" (rebanadas separadas)?**
Sí. Existe un tipo de gráfico de rosquilla Explotada [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.
**¿Cómo puedo obtener una imagen de un gráfico de rosquilla (PNG/SVG) para un informe?**
Un gráfico es una forma; puede renderizarlo a una [raster image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) o exportar el gráfico a una [SVG image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).