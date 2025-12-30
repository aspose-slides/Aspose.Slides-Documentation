---
title: Personalizar gráficos de rosquilla en presentaciones usando PHP
linktitle: Gráfico de rosquilla
type: docs
weight: 30
url: /es/php-java/doughnut-chart/
keywords:
- gráfico de rosquilla
- hueco central
- tamaño del hueco
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Descubra cómo crear y personalizar gráficos de rosquilla en Aspose.Slides para PHP a través de Java, compatible con formatos de PowerPoint para presentaciones dinámicas."
---

## **Especificar el hueco central en un gráfico de rosquilla**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java ahora admite especificar el tamaño del hueco en un gráfico de rosquilla. En este tema, veremos con un ejemplo cómo especificar el tamaño del hueco en un gráfico de rosquilla.

{{% /alert %}} 

Para especificar el tamaño del hueco en un gráfico de rosquilla, siga los pasos a continuación:

1. Instanciar el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Añadir un gráfico de rosquilla en la diapositiva.
1. Especificar el tamaño del hueco en un gráfico de rosquilla.
1. Escribir la presentación en disco.

En el ejemplo que se muestra a continuación, hemos establecido el tamaño del hueco en un gráfico de rosquilla.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Guardar la presentación en disco
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo crear una rosquilla multinivel con varios anillos?**

Sí. Añada varias series a un único gráfico de rosquilla—cada serie se convierte en un anillo separado. El orden de los anillos está determinado por el orden de las series en la colección.

**¿Se admite una rosquilla "explosada" (rebanadas separadas)?**

Sí. Existe un Exploded Doughnut [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) y una propiedad de explosión en los puntos de datos; puedes separar rebanadas individuales.

**¿Cómo puedo obtener una imagen de un gráfico de rosquilla (PNG/SVG) para un informe?**

Un gráfico es una forma; puedes renderizarlo a una [raster image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) o exportar el gráfico a una [SVG image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg).