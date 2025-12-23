---
title: Personalizar ejes de gráficos en presentaciones usando PHP
linktitle: Eje de gráfico
type: docs
url: /es/php-java/chart-axis/
keywords:
- eje de gráfico
- eje vertical
- eje horizontal
- personalizar eje
- manipular eje
- gestionar eje
- propiedades del eje
- valor máximo
- valor mínimo
- línea del eje
- formato de fecha
- título del eje
- posición del eje
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Descubra cómo usar Aspose.Slides for PHP via Java para personalizar los ejes de los gráficos en presentaciones de PowerPoint para informes y visualizaciones."
---

## **Obtener los valores máximos en el eje vertical de los gráficos**
Aspose.Slides for PHP via Java permite obtener los valores mínimo y máximo en un eje vertical. Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Agregue un gráfico con datos predeterminados.
1. Obtenga el valor máximo real en el eje.
1. Obtenga el valor mínimo real en el eje.
1. Obtenga la unidad mayor real del eje.
1. Obtenga la unidad menor real del eje.
1. Obtenga la escala de unidad mayor real del eje.
1. Obtenga la escala de unidad menor real del eje.

Este código de ejemplo—una implementación de los pasos anteriores—le muestra cómo obtener los valores requeridos:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Guarda la presentación
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Intercambiar los datos entre ejes**
Aspose.Slides permite intercambiar rápidamente los datos entre ejes: los datos representados en el eje vertical (eje y) pasan al eje horizontal (eje x) y viceversa.

Este código PHP le muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Cambia filas y columnas
    $chart->getChartData()->switchRowColumn();
    # Guarda la presentación
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Desactivar el eje vertical en gráficos de líneas**
Este código PHP muestra cómo ocultar el eje vertical en un gráfico de líneas:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Desactivar el eje horizontal en gráficos de líneas**
Este código muestra cómo ocultar el eje horizontal en un gráfico de líneas:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Cambiar el eje de categorías**
Usando la propiedad **CategoryAxisType**, puede especificar su tipo de eje de categorías preferido (**date** o **text**). Este código demuestra la operación:
```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Establecer el formato de fecha para los valores del eje de categorías**
Aspose.Slides for PHP via Java permite establecer el formato de fecha para un valor del eje de categorías. La operación se demuestra en este código PHP:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Establecer el ángulo de rotación para el título de un eje de gráfico**
Aspose.Slides for PHP via Java permite establecer el ángulo de rotación para el título de un eje de gráfico. Este código PHP demuestra la operación:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer la posición del eje en un eje de categoría o de valor**
Aspose.Slides for PHP via Java permite establecer la posición del eje en un eje de categoría o de valor. Este código PHP muestra cómo realizar la tarea:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Habilitar la etiqueta de unidad de visualización en el eje de valores del gráfico**
Aspose.Slides for PHP via Java permite configurar un gráfico para que muestre una etiqueta de unidad en su eje de valores. Este código PHP demuestra la operación:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Los ejes proporcionan una [configuración de cruce](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/): puede elegir cruzar en cero, en la categoría/valor máximo, o en un valor numérico específico. Esto es útil para desplazar el eje X hacia arriba o hacia abajo o para resaltar una línea base.

**¿Cómo puedo posicionar las etiquetas de marcas de graduación respecto al eje (junto, afuera, dentro)?**

Establezca la [posición de la etiqueta](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) en "cross", "outside" o "inside". Esto afecta la legibilidad y ayuda a conservar espacio, especialmente en gráficos pequeños.