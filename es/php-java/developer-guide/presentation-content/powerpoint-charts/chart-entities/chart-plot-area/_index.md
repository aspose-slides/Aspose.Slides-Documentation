---
title: Área de Trazado del Gráfico
type: docs
url: /es/php-java/chart-plot-area/
---


## **Obtener Ancho, Alto del Área de Trazado del Gráfico**
Aspose.Slides para PHP a través de Java proporciona una API simple para. 

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Llamar al método [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) antes de obtener los valores reales.
1. Obtener la ubicación X real (izquierda) del elemento gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtener la parte superior real del elemento gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtener el ancho real del elemento gráfico.
1. Obtener la altura real del elemento gráfico.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Modo de Diseño del Área de Trazado del Gráfico**
Aspose.Slides para PHP a través de Java proporciona una API simple para establecer el modo de diseño del área de trazado del gráfico. Se han añadido los métodos [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) y [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) a la clase [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) y a la interfaz [**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea). Si el diseño del área de trazado se define manualmente, esta propiedad especifica si el área de trazado debe ser diseñada por su interior (sin incluir los ejes y las etiquetas de los ejes) o por su exterior (incluyendo los ejes y las etiquetas de los ejes). Hay dos valores posibles que se definen en el enum [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, las marcas de graduación, y las etiquetas de los ejes.

El código de muestra se da a continuación.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```