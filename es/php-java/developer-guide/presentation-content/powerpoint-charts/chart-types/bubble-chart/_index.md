---
title: Personalizar gráficos de burbujas en presentaciones usando PHP
linktitle: Gráfico de burbujas
type: docs
url: /es/php-java/bubble-chart/
keywords:
- gráfico de burbujas
- tamaño de burbuja
- escalado de tamaño
- representación de tamaño
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crea y personaliza potentes gráficos de burbujas en PowerPoint con Aspose.Slides para PHP a través de Java para mejorar fácilmente la visualización de tus datos."
---

## **Escalado del tamaño del gráfico de burbujas**
Aspose.Slides for PHP via Java ofrece soporte para el escalado del tamaño del gráfico de burbujas. En Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) y [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) se han añadido métodos. A continuación se muestra un ejemplo.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Representar datos como tamaños de gráfico de burbujas**
Se han añadido los métodos [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) y [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) a las clases [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) y clases relacionadas. **BubbleSizeRepresentation** especifica cómo se representan los valores de tamaño de burbuja en el gráfico de burbujas. Los valores posibles son: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) y [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). En consecuencia, el enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) se ha añadido para especificar las formas posibles de representar datos como tamaños de gráfico de burbujas. A continuación se muestra el código de ejemplo.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Se admite un "gráfico de burbujas con efecto 3D" y en qué se diferencia de uno normal?**

Sí. Existe un tipo de gráfico separado, "Bubble with 3-D". Aplica estilo 3D a las burbujas pero no añade un eje adicional; los datos siguen siendo X-Y-S (tamaño). El tipo está disponible en la clase [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

**¿Existe un límite en el número de series y puntos en un gráfico de burbujas?**

No hay un límite estricto a nivel de API; las limitaciones dependen del rendimiento y de la versión de PowerPoint destino. Se recomienda mantener un número razonable de puntos para una buena legibilidad y velocidad de renderizado.

**¿Cómo afecta la exportación a la apariencia de un gráfico de burbujas (PDF, imágenes)?**

Exportar a los formatos compatibles conserva la apariencia del gráfico; el renderizado lo realiza el motor de Aspose.Slides. Para formatos raster/vector, se aplican las reglas generales de renderizado de gráficos (resolución, antialiasing), por lo que debe elegirse un DPI suficiente para la impresión.