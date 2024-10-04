---
title: Gráfico de Dona
type: docs
weight: 30
url: /es/php-java/doughnut-chart/
---

## **Cambiar el Espacio Central en el Gráfico de Dona**
{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java ahora admite especificar el tamaño del agujero en un gráfico de dona. En este tema, veremos con un ejemplo cómo especificar el tamaño del agujero en un gráfico de dona.

{{% /alert %}} 

Para especificar el tamaño del agujero en un gráfico de dona, siga los pasos a continuación:

1. Instanciar el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Agregar un gráfico de dona en la diapositiva.
1. Especificar el tamaño del agujero en un gráfico de dona.
1. Guardar la presentación en el disco.

En el ejemplo dado a continuación, hemos establecido el tamaño del agujero en un gráfico de dona.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Guardar la presentación en el disco
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```