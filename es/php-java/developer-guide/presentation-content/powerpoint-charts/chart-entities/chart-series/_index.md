---
title: Gestionar series de datos de gráficos en presentaciones usando PHP
linktitle: Series de datos
type: docs
url: /es/php-java/chart-series/
keywords:
- serie de gráfico
- superposición de series
- color de series
- color de categoría
- nombre de serie
- punto de datos
- espacio entre series
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a gestionar series de datos de gráficos en PHP para PowerPoint (PPT/PPTX) con ejemplos de código prácticos y buenas prácticas para mejorar sus presentaciones de datos."
---

Una serie es una fila o columna de números representados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer la superposición de series del gráfico**

Con la propiedad [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) puedes especificar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series padre: es una proyección de la propiedad correspondiente del grupo. Por lo tanto, esta propiedad es de solo lectura. 

Usa la propiedad de lectura/escritura `ParentSeriesGroup.Overlap` para establecer el valor que prefieras para `Overlap`. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Añade un gráfico de columnas agrupadas en una diapositiva.
1. Accede a la primera serie del gráfico.
1. Accede al `ParentSeriesGroup` de la serie del gráfico y establece el valor de superposición que prefieras para la serie. 
1. Guarda la presentación modificada en un archivo PPTX.

Este código PHP muestra cómo establecer la superposición para una serie de un gráfico:
```php
  $pres = new Presentation();
  try {
    # Añade el gráfico
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Establece la superposición de series
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Escribe el archivo de presentación en disco
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Cambiar el color de la serie**

Aspose.Slides for PHP via Java permite cambiar el color de una serie de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Añade un gráfico en la diapositiva.
1. Accede a la serie cuyo color deseas cambiar. 
1. Establece el tipo de relleno y el color de relleno que prefieras.
1. Guarda la presentación modificada.

Este código PHP muestra cómo cambiar el color de una serie:
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


## **Cambiar el color de la categoría de la serie**

Aspose.Slides for PHP via Java permite cambiar el color de la categoría de una serie de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Añade un gráfico en la diapositiva.
1. Accede a la categoría de la serie cuyo color deseas cambiar.
1. Establece el tipo de relleno y el color de relleno que prefieras.
1. Guarda la presentación modificada.

Este código muestra cómo cambiar el color de la categoría de una serie:
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


## **Cambiar el nombre de la serie** 

Por defecto, los nombres de la leyenda de un gráfico son el contenido de las celdas situadas encima de cada columna o fila de datos. 

En nuestro ejemplo (imagen de muestra),

* las columnas son *Series 1, Series 2,* y *Series 3*;
* las filas son *Category 1, Category 2, Category 3,* y *Category 4.* 

Aspose.Slides for PHP via Java permite actualizar o cambiar el nombre de una serie en los datos del gráfico y en la leyenda.

Este código PHP muestra cómo cambiar el nombre de una serie en los datos del gráfico `ChartDataWorkbook`:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Este código PHP muestra cómo cambiar el nombre de una serie en su leyenda a través de `Series`:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el color de relleno de la serie del gráfico**

Aspose.Slides for PHP via Java permite establecer el color de relleno automático para las series de un gráfico dentro del área de trazado de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva mediante su índice.
1. Añade un gráfico con datos predeterminados según el tipo que prefieras (en el ejemplo siguiente, utilizamos `ChartType::ClusteredColumn`).
1. Accede a la serie del gráfico y establece el color de relleno a Automatic.
1. Guarda la presentación en un archivo PPTX.

Este código PHP muestra cómo establecer el color de relleno automático para una serie de un gráfico:
```php
  $pres = new Presentation();
  try {
    # Crea un gráfico de columnas agrupadas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Establece el formato de relleno de la serie a automático
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Escribe el archivo de presentación en disco
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el color de relleno invertido para una serie de gráfico**
Aspose.Slides permite establecer el color de relleno invertido para las series de un gráfico dentro del área de trazado de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva mediante su índice.
1. Añade un gráfico con datos predeterminados según el tipo que prefieras (en el ejemplo siguiente, utilizamos `ChartType::ClusteredColumn`).
1. Accede a la serie del gráfico y establece el color de relleno a invert.
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
    # Añade nuevas series y categorías
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Obtiene la primera serie del gráfico y rellena sus datos de serie.
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


## **Configurar una serie para invertir cuando el valor es negativo**
Aspose.Slides permite establecer la inversión mediante las propiedades `IChartDataPoint.InvertIfNegative` y `ChartDataPoint.InvertIfNegative`. Cuando se establece una inversión mediante estas propiedades, el punto de datos invierte sus colores al recibir un valor negativo. 

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


## **Borrar datos de puntos específicos**
Aspose.Slides for PHP via Java permite borrar los datos de `DataPoints` para una serie de gráfico específica de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva mediante su índice.
3. Obtén la referencia de un gráfico mediante su índice.
4. Recorre todos los `DataPoints` del gráfico y establece `XValue` y `YValue` a null.
5. Borra todos los `DataPoints` de la serie de gráfico específica.
6. Guarda la presentación modificada en un archivo PPTX.

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


## **Establecer el ancho del intervalo de la serie**
Aspose.Slides for PHP via Java permite establecer el ancho del intervalo de una serie mediante la propiedad **`GapWidth`** de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accede a la primera diapositiva.
1. Añade un gráfico con datos predeterminados.
1. Accede a cualquier serie del gráfico.
1. Establece la propiedad `GapWidth`.
1. Guarda la presentación modificada en un archivo PPTX.

Este código muestra cómo establecer el ancho del intervalo de una serie:
```php
  # Crea una presentación vacía
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Añade un gráfico con datos predeterminados
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Establece el índice de la hoja de datos del gráfico
    $defaultWorksheetIndex = 0;
    # Obtiene la hoja de cálculo de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Añade series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Añade categorías
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Obtiene la segunda serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Rellena los datos de la serie
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Establece el valor de GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Guarda la presentación en disco
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Existe un límite en la cantidad de series que puede contener un único gráfico?**

Aspose.Slides no impone un límite fijo al número de series que añadas. El techo práctico está determinado por la legibilidad del gráfico y por la memoria disponible para tu aplicación.

**¿Qué ocurre si las columnas dentro de un grupo están demasiado juntas o demasiado separadas?**

Ajusta la configuración `GapWidth` para esa serie (o su grupo de series padre). Incrementar el valor amplía el espacio entre columnas, mientras que disminuirlo las acerca más.