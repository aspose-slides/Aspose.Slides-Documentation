---
title: Optimizar cálculos de gráficos para presentaciones en PHP
linktitle: Cálculos de gráficos
type: docs
weight: 50
url: /es/php-java/chart-calculations/
keywords:
- cálculos de gráficos
- elementos del gráfico
- posición del elemento
- posición real
- elemento hijo
- elemento padre
- valores del gráfico
- valor real
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Comprenda los cálculos de gráficos, la actualización de datos y el control de precisión en Aspose.Slides for PHP via Java para PPT y PPTX, con ejemplos de código prácticos."
---

## **Calcular valores reales de los elementos del gráfico**
Aspose.Slides for PHP via Java proporciona una API sencilla para obtener estas propiedades. Los métodos de la clase [Axis](https://reference.aspose.com/slides/php-java/aspose.slides/axis/) proporcionan información sobre la posición real del elemento del eje del gráfico ([getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)). Es necesario llamar previamente al método [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) para rellenar las propiedades con los valores reales.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Calcular la posición real de los elementos padre del gráfico**
Aspose.Slides for PHP via Java proporciona una API sencilla para obtener estas propiedades. Los métodos de la clase `ActualLayout` proporcionan información sobre la posición real del elemento padre del gráfico (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Es necesario llamar previamente al método [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) para rellenar las propiedades con los valores reales.
```php
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


## **Ocultar elementos del gráfico**
Este tema le ayuda a entender cómo ocultar información del gráfico. Utilizando Aspose.Slides for PHP via Java puede ocultar **Título, eje vertical, eje horizontal** y **líneas de cuadrícula** del gráfico. El siguiente ejemplo de código muestra cómo usar estas propiedades.
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Ocultando el título del gráfico
    $chart->setTitle(false);
    # /Ocultando el eje de valores
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Visibilidad del eje de categorías
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Ocultando la leyenda
    $chart->setLegend(false);
    # Ocultando las líneas de cuadrícula principales
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Estableciendo el color de línea de la serie
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Los libros de Excel externos funcionan como fuente de datos y cómo afecta eso a la recalculación?**

Sí. Un gráfico puede hacer referencia a un libro externo: cuando se conecta o actualiza la fuente externa, las fórmulas y valores se toman de ese libro, y el gráfico refleja las actualizaciones durante las operaciones de apertura/edición. La API le permite [especificar la ruta del libro externo](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) y gestionar los datos vinculados.

**¿Puedo calcular y mostrar líneas de tendencia sin implementar la regresión yo mismo?**

Sí. Las [líneas de tendencia](/slides/es/php-java/trend-line/) (lineales, exponenciales y otras) son añadidas y actualizadas por Aspose.Slides; sus parámetros se recalculan automáticamente a partir de los datos de la serie, por lo que no es necesario que implemente sus propios cálculos.

**Si una presentación tiene varios gráficos con enlaces externos, ¿puedo controlar qué libro utiliza cada gráfico para los valores calculados?**

Sí. Cada gráfico puede apuntar a su propio [libro externo](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), o puede crear/reemplazar un libro externo por gráfico de forma independiente de los demás.