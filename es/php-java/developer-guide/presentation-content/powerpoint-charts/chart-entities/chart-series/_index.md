---
title: Series de Gráficos
type: docs
url: /es/php-java/chart-series/
keywords: "Series de gráficos, color de series, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Series de gráficos en presentaciones de PowerPoint"
---

Una serie es una fila o columna de números trazados en un gráfico.

![series-graficos-powerpoint](chart-series-powerpoint.png)

## **Establecer la Superposición de Series de Gráficos**

Con la propiedad [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap), puedes especificar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series padre: se trata de una proyección de la propiedad del grupo correspondiente. Por lo tanto, esta propiedad es de solo lectura.

Usa la propiedad de lectura/escritura `ParentSeriesGroup.Overlap` para establecer tu valor preferido para `Overlap`.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Agrega un gráfico de columnas agrupadas en una diapositiva.
1. Accede a la primera serie del gráfico.
1. Accede a `ParentSeriesGroup` de la serie del gráfico y establece tu valor de superposición preferido para la serie.
1. Escribe la presentación modificada en un archivo PPTX.

Este código PHP te muestra cómo establecer la superposición para una serie de gráficos:

```php
  $pres = new Presentation();
  try {
    # Agrega un gráfico
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Establece la superposición de la serie
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Escribe el archivo de presentación en el disco
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiar el Color de la Serie**
Aspose.Slides para PHP a través de Java te permite cambiar el color de una serie de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Agrega un gráfico en la diapositiva.
1. Accede a la serie cuyo color deseas cambiar.
1. Establece tu tipo de relleno preferido y color de relleno.
1. Guarda la presentación modificada.

Este código PHP te muestra cómo cambiar el color de una serie:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiar el Color de la Categoría de la Serie**
Aspose.Slides para PHP a través de Java te permite cambiar el color de la categoría de una serie de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Agrega un gráfico en la diapositiva.
1. Accede a la categoría de la serie cuyo color deseas cambiar.
1. Establece tu tipo de relleno preferido y color de relleno.
1. Guarda la presentación modificada.

Este código te muestra cómo cambiar el color de la categoría de una serie:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiar el Nombre de la Serie**

Por defecto, los nombres de la leyenda para un gráfico son los contenidos de las celdas sobre cada columna o fila de datos.

En nuestro ejemplo (imagen de muestra),

* las columnas son *Serie 1, Serie 2,* y *Serie 3*;
* las filas son *Categoría 1, Categoría 2, Categoría 3,* y *Categoría 4.*

Aspose.Slides para PHP a través de Java te permite actualizar o cambiar el nombre de una serie en sus datos de gráfico y leyenda.

Este código PHP te muestra cómo cambiar el nombre de una serie en sus datos de gráfico `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("Nuevo nombre");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este código PHP te muestra cómo cambiar el nombre de una serie en su leyenda a través de `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("Nuevo nombre");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer el Color de Relleno de la Serie de Gráficos**

Aspose.Slides para PHP a través de Java te permite establecer el color de relleno automático para las series de gráficos dentro de un área de trazado de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva por su índice.
1. Agrega un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, usamos `ChartType::ClusteredColumn`).
1. Accede a la serie del gráfico y establece el color de relleno en Automático.
1. Guarda la presentación en un archivo PPTX.

Este código PHP te muestra cómo establecer el color de relleno automático para una serie de gráficos:

```php
  $pres = new Presentation();
  try {
    # Crea un gráfico de columnas agrupadas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Establece el formato de relleno de la serie en automático
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Escribe el archivo de presentación en el disco
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Colores de Relleno Invertidos para Series de Gráficos**
Aspose.Slides te permite establecer el color de relleno invertido para las series de gráficos dentro de un área de trazado de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva por su índice.
1. Agrega un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, usamos `ChartType::ClusteredColumn`).
1. Accede a la serie de gráficos y establece el color de relleno en invertido.
1. Guarda la presentación en un archivo PPTX.

Este código PHP demuestra la operación:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Agrega nuevas series y categorías
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Serie 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Categoría 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Categoría 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Categoría 3"));
    # Toma la primera serie de gráfico y pobla sus datos de serie.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Series para Invertir Cuando el Valor es Negativo**
Aspose.Slides te permite establecer inversiones a través de las propiedades `IChartDataPoint.InvertIfNegative` y `ChartDataPoint.InvertIfNegative`. Cuando una inversión se establece usando las propiedades, el punto de datos invierte sus colores cuando recibe un valor negativo.

Este código PHP demuestra la operación:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Limpiar Datos de Puntos de Datos Específicos**
Aspose.Slides para PHP a través de Java te permite limpiar el dato de `DataPoints` para una serie de gráficos específica de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Obtén la referencia de un gráfico a través de su índice.
4. Itera a través de todos los `DataPoints` de un gráfico y establece `XValue` y `YValue` en null.
5. Limpia todos los `DataPoints` para series de gráficos específicas.
6. Escribe la presentación modificada en un archivo PPTX.

Este código PHP demuestra la operación:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer el Ancho de Espaciado de la Serie**
Aspose.Slides para PHP a través de Java te permite establecer el ancho de espaciado de una serie a través de la propiedad **`GapWidth`** de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accede a la primera diapositiva.
1. Agrega un gráfico con datos predeterminados.
1. Accede a cualquier serie de gráfico.
1. Establece la propiedad `GapWidth`.
1. Escribe la presentación modificada en un archivo PPTX.

Este código te muestra cómo establecer el ancho de espaciado de una serie:

```php
  # Crea una presentación vacía
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Agrega un gráfico con datos predeterminados
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Establece el índice de la hoja de datos del gráfico
    $defaultWorksheetIndex = 0;
    # Obtiene la hoja de trabajo de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Agrega series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Serie 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Serie 2"), $chart->getType());
    # Agrega Categorías
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Categoría 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Categoría 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Categoría 3"));
    # Toma la segunda serie de gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Pobla los datos de la serie
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Establece el valor de GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Guarda la presentación en el disco
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```