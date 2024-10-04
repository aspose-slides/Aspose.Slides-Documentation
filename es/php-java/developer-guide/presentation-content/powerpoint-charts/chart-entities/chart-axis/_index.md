---
title: Eje de Gráfico
type: docs
url: /php-java/chart-axis/
keywords: "Eje de Gráfico de PowerPoint, Gráficos de Presentación, Java, Manipular Eje de Gráfico, Datos de gráfico"
description: "Cómo editar el eje de gráfico de PowerPoint"
---


## **Obteniendo los Valores Máximos en el Eje Vertical de los Gráficos**
Aspose.Slides para PHP a través de Java te permite obtener los valores mínimos y máximos en un eje vertical. Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accede a la primera diapositiva.
1. Añade un gráfico con datos por defecto.
1. Obtén el valor máximo actual en el eje.
1. Obtén el valor mínimo actual en el eje.
1. Obtén la unidad mayor actual del eje.
1. Obtén la unidad menor actual del eje.
1. Obtén la escala de unidad mayor actual del eje.
1. Obtén la escala de unidad menor actual del eje.

Este código de muestra—una implementación de los pasos anteriores—te muestra cómo obtener los valores requeridos:

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

## **Intercambiando los Datos entre Ejes**
Aspose.Slides te permite intercambiar rápidamente los datos entre ejes—los datos representados en el eje vertical (eje y) se mueven al eje horizontal (eje x) y viceversa.

Este código PHP te muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Intercambia filas y columnas
    $chart->getChartData()->switchRowColumn();
    # Guarda la presentación
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Deshabilitando el Eje Vertical para Gráficos de Líneas**

Este código PHP te muestra cómo ocultar el eje vertical para un gráfico de líneas:

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

## **Deshabilitando el Eje Horizontal para Gráficos de Líneas**

Este código te muestra cómo ocultar el eje horizontal para un gráfico de líneas:

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

## **Cambiando el Eje de Categoría**

Usando la propiedad **CategoryAxisType**, puedes especificar tu tipo de eje de categoría preferido (**fecha** o **texto**). Este código demuestra la operación:

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

## **Estableciendo el Formato de Fecha para el Valor del Eje de Categoría**
Aspose.Slides para PHP a través de Java te permite establecer el formato de fecha para un valor del eje de categoría. La operación se demuestra en este código PHP:

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

## **Estableciendo el Ángulo de Rotación para el Título del Eje del Gráfico**
Aspose.Slides para PHP a través de Java te permite establecer el ángulo de rotación para el título de un eje de gráfico. Este código PHP demuestra la operación:

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

## **Estableciendo la Posición del Eje en un Eje de Categoría o de Valor**
Aspose.Slides para PHP a través de Java te permite establecer la posición del eje en un eje de categoría o de valor. Este código PHP muestra cómo realizar la tarea:

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

## **Habilitando la Etiqueta de Unidad de Visualización en el Eje de Valor del Gráfico**
Aspose.Slides para PHP a través de Java te permite configurar un gráfico para mostrar una etiqueta de unidad en su eje de valor de gráfico. Este código PHP demuestra la operación:

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