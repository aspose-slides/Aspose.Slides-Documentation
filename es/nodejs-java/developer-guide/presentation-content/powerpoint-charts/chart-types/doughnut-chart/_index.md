---
title: Gráfico de dona
type: docs
weight: 30
url: /es/nodejs-java/doughnut-chart/
---

## **Cambiar el espacio central en el gráfico de dona**
{{% alert color="primary" %}} 

Aspose.Slides para Node.js mediante Java ahora admite especificar el tamaño del agujero en un gráfico de dona. En este tema, veremos con un ejemplo cómo especificar el tamaño del agujero en un gráfico de dona.

{{% /alert %}} 

Para especificar el tamaño del agujero en un gráfico de dona, siga los pasos a continuación:

1. Instanciar el objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Agregar un gráfico de dona en la diapositiva.
1. Especificar el tamaño del agujero en el gráfico de dona.
1. Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos establecido el tamaño del agujero en un gráfico de dona.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Guardar la presentación en disco
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Puedo crear una dona multinivel con varios anillos?**

Sí. Agregue varias series a un solo gráfico de dona; cada serie se convierte en un anillo separado. El orden de los anillos se determina por el orden de las series en la colección.

**¿Se admite una dona "explodida" (rebanadas separadas)?**

Sí. Existe un tipo de gráfico de Dona Explosiva [chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.

**¿Cómo puedo obtener una imagen de un gráfico de dona (PNG/SVG) para un informe?**

Un gráfico es una forma; puede renderizarlo a una [raster image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) o exportar el gráfico a una [SVG image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/).