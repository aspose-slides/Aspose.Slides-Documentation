---
title: Crear o actualizar gráficos de presentaciones PowerPoint en PHP
linktitle: Crear o actualizar gráficos
type: docs
weight: 10
url: /es/php-java/create-chart/
keywords:
- añadir gráfico
- crear gráfico
- editar gráfico
- cambiar gráfico
- actualizar gráfico
- gráfico de dispersión
- gráfico circular
- gráfico de líneas
- gráfico de mapa de árbol
- gráfico de cotizaciones
- gráfico de caja y bigotes
- gráfico de embudo
- gráfico radial
- gráfico de histograma
- gráfico de radar
- gráfico multicaategoría
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crear y personalizar gráficos en presentaciones PowerPoint usando Aspose.Slides para PHP a través de Java. Añadir, formatear y editar gráficos con ejemplos de código prácticos."
---
## **Visión general**

Este artículo proporciona una guía completa sobre cómo crear y personalizar gráficos utilizando Aspose.Slides. Aprenderá a añadir programáticamente un gráfico a una diapositiva, a poblarlo con datos y a aplicar diversas opciones de formato para que coincidan con sus requisitos de diseño específicos. A lo largo del artículo, ejemplos de código detallados ilustran cada paso, desde la inicialización de la presentación y del objeto gráfico hasta la configuración de series, ejes y leyendas. Siguiendo esta guía, obtendrá una comprensión sólida de cómo integrar la generación dinámica de gráficos en sus aplicaciones, optimizando el proceso de creación de presentaciones basadas en datos.

## **Crear un gráfico**

Los gráficos ayudan a las personas a visualizar rápidamente los datos y a obtener información que puede no ser evidente a simple vista en una tabla o hoja de cálculo.

**¿Por qué crear gráficos?**

Al usar gráficos, puede:

* agregar, condensar o resumir grandes cantidades de datos en una sola diapositiva de una presentación
* revelar patrones y tendencias en los datos
* deducir la dirección y el impulso de los datos a lo largo del tiempo o con respecto a una unidad de medida específica
* detectar valores atípicos, aberraciones, desviaciones, errores, datos sin sentido, etc.
* comunicar o presentar datos complejos

En PowerPoint, puede crear gráficos mediante la función *Insertar*, que proporciona plantillas para diseñar muchos tipos de gráficos. Con Aspose.Slides, puede crear tanto gráficos habituales (basados en tipos de gráficos populares) como gráficos personalizados.

{{% alert color="info" title="Note" %}}
Para crear gráficos, utilice la clase [ChartType](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/). Los campos de esta clase corresponden a diferentes tipos de gráficos.
{{% /alert %}}

### **Crear gráficos de columnas agrupadas**

Esta sección explica cómo crear gráficos de columnas agrupadas usando Aspose.Slides. Aprenderá a inicializar una presentación, añadir un gráfico y personalizar sus elementos, como el título, los datos, las series, las categorías y el estilo. Siga los pasos a continuación para ver cómo se genera un gráfico de columnas agrupadas estándar:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con algunos datos y especifique el tipo `ChartType::ClusteredColumn` .
4. Añada un título al gráfico.
5. Acceda a la hoja de datos del gráfico.
6. Elimine todas las series y categorías predeterminadas.
7. Añada nuevas series y categorías.
8. Añada nuevos datos al gráfico para las series.
9. Aplique un color de relleno a las series del gráfico.
10. Añada etiquetas a las series del gráfico.
11. Guarde la presentación modificada como archivo PPTX.

Este código C# muestra cómo crear un gráfico de columnas agrupadas:

```php
  # Instancia una clase de presentación que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añade un gráfico con sus datos predeterminados
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Establece el título del gráfico
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Establece que la primera serie muestre los valores
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Establece el índice para la hoja de datos del gráfico
    $defaultWorksheetIndex = 0;
    # Obtiene la hoja de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Elimina las series y categorías generadas por defecto
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Añade nuevas series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Añade nuevas categorías
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Obtiene la primera serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Ahora rellena los datos de la serie
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Establece el color de relleno para la serie
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Obtiene la segunda serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Rellena los datos de la serie
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Establece el color de relleno para la serie
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Crea etiquetas personalizadas para cada categoría de la nueva serie
    # Establece la primera etiqueta para mostrar el nombre de la categoría
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Muestra el valor para la tercera etiqueta
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Guarda la presentación con el gráfico
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos de dispersión**

Los gráficos de dispersión (también conocidos como diagramas de dispersión o gráficos x‑y) se utilizan a menudo para buscar patrones o demostrar correlaciones entre dos variables.

Utilice un gráfico de dispersión cuando:

* disponga de datos numéricos emparejados
* tenga dos variables que se relacionen bien entre sí
* quiera determinar si dos variables están relacionadas
* tenga una variable independiente que posea múltiples valores para una variable dependiente

1. Siga los pasos de [Crear gráficos de columnas agrupadas](#crear-gráficos-de-columnas-agrupadas).
2. En el tercer paso, añada un gráfico con algunos datos y especifique su tipo de gráfico como uno de los siguientes:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Representa un gráfico de dispersión._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representa un gráfico de dispersión conectado por curvas, con marcadores de datos._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Representa un gráfico de dispersión conectado por curvas, sin marcadores de datos._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representa un gráfico de dispersión conectado por líneas rectas, con marcadores de datos._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Representa un gráfico de dispersión conectado por líneas rectas, sin marcadores de datos._

Este código PHP muestra cómo crear un gráfico de dispersión con diferentes marcadores para cada serie:

```php
  # Instancia una clase de presentación que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Crea el gráfico predeterminado
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Obtiene el índice de la hoja de datos del gráfico predeterminada
    $defaultWorksheetIndex = 0;
    # Obtiene la hoja de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Elimina la serie de demostración
    $chart->getChartData()->getSeries()->clear();
    # Añade nuevas series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Obtiene la primera serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Añade un nuevo punto (1:3) a la serie
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Añade un nuevo punto (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Cambia el tipo de serie
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Cambia el marcador de la serie del gráfico
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Obtiene la segunda serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Añade un nuevo punto (5:2) allí
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Añade un nuevo punto (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Añade un nuevo punto (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Añade un nuevo punto (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Cambia el marcador de la serie del gráfico
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos circulares**

Los gráficos circulares son útiles para mostrar la relación parte‑todo en los datos, especialmente cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si sus datos contienen muchas partes o etiquetas, quizás prefiera usar un gráfico de barras.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados y especifique el tipo [ChartType::Pie](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#Pie) .
4. Acceda al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/) .
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Añada nuevos puntos al gráfico y aplique colores personalizados a los sectores del gráfico circular.
9. Defina etiquetas para las series.
10. Active las líneas guía para las etiquetas de las series.
11. Establezca el ángulo de rotación para los sectores del gráfico circular.
12. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un gráfico circular:

```php
  # Instancia una clase de presentación que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $slides = $pres->getSlides()->get_Item(0);
    # Añade un gráfico con datos predeterminados
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Establece el título del gráfico
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Establece que la primera serie muestre los valores
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Establece el índice para la hoja de datos del gráfico
    $defaultWorksheetIndex = 0;
    # Obtiene la hoja de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Elimina las series y categorías generadas por defecto
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Añade nuevas categorías
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Añade nuevas series
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Rellena los datos de la serie
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # No funciona en la nueva versión
    # Añadiendo nuevos puntos y estableciendo el color del sector
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Establece el borde del sector
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Establece el borde del sector
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Establece el borde del sector
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Crea etiquetas personalizadas para cada categoría de la nueva serie
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Muestra líneas guía para el gráfico
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Establece el ángulo de rotación para los sectores del gráfico circular
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Guarda la presentación con un gráfico
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos de líneas**

Los gráficos de líneas (también conocidos como diagramas de líneas) son ideales cuando desea demostrar cambios de valor a lo largo del tiempo. Con un gráfico de líneas, puede comparar una gran cantidad de datos a la vez, seguir cambios y tendencias a lo largo del tiempo, resaltar anomalías en series de datos, y más.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
1. Obtenga una referencia a una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados y especifique el tipo [ChartType::Line](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#Line) .
1. Acceda al libro de datos del gráfico ([ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/)) .
1. Elimine las series y categorías predeterminadas.
1. Añada nuevas series y categorías.
1. Añada nuevos datos al gráfico para las series.
1. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un gráfico de líneas:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Por defecto, los puntos en un gráfico de líneas están unidos por líneas continuas rectas. Si desea que los puntos se unan mediante guiones, puede especificar su tipo de guión preferido de la siguiente manera:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos de mapa de árbol**

Los gráficos de mapa de árbol son útiles para datos de ventas cuando desea mostrar el tamaño relativo de categorías de datos y llamar rápidamente la atención sobre los elementos que son grandes contribuyentes dentro de cada categoría.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados y especifique el tipo [ChartType::Treemap](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#Treemap) .
4. Acceda al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/) .
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un gráfico de mapa de árbol:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # rama 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # rama 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos de cotizaciones**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados y especifique el tipo [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Acceda al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/) .
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Especifique el formato de las líneas alto‑bajo.
9. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un gráfico de cotizaciones:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos de caja y bigotes**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados y especifique el tipo [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Acceda al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/) .
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un gráfico de caja y bigotes:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos de embudo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados y especifique el tipo [ChartType::Funnel](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#Funnel) .
4. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un gráfico de embudo:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos radiales**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados y especifique el tipo [ChartType::Sunburst](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#Sunburst) .
4. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un gráfico radial:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # rama 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # rama 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear histogramas**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados y especifique el tipo [ChartType::Histogram](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#Histogram) .
4. Acceda al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/) .
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un histograma:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **Crear gráficos de radar**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con algunos datos y especifique su tipo de gráfico preferido ([ChartType::Radar](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#Radar) en este caso).
4. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un gráfico de radar:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos multicaategoría**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) .
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados y especifique el tipo [ChartType::ClusteredColumn](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/#ClusteredColumn) .
4. Acceda al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/) .
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo crear un gráfico multicaategoría:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Añadiendo series
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Guardar presentación con gráfico
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos de mapa**

Los gráficos de mapa visualizan datos geográficos y ayudan a comparar valores entre regiones.

Este código PHP muestra cómo crear un gráfico de mapa:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear gráficos combinados**

Un gráfico combinado (o gráfico combo) combina dos o más tipos de gráficos en un solo diagrama. Este gráfico le permite resaltar, comparar o examinar diferencias entre dos o más conjuntos de datos, ayudándole a identificar relaciones entre ellos.

![El gráfico combinado](combination_chart.png)

El siguiente código PHP muestra cómo crear el gráfico combinado mostrado arriba en una presentación de PowerPoint:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Set the chart title.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Set the chart legend.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Delete the default generated series and categories.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Add new categories.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Add the first series.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Set the horizontal axis.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Set the vertical axis.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Set the vertical major gridlines color.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Set the secondary horizontal axis.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Set the secondary vertical axis.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Actualizar gráficos**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) que representa la presentación que contiene el gráfico que desea actualizar.
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Recorra todas las formas para encontrar el gráfico deseado.
4. Acceda a la hoja de datos del gráfico.
5. Modifique las series de datos del gráfico cambiando los valores de las series.
6. Añada una nueva serie y rellene sus datos.
7. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo actualizar un gráfico:

```php
  $pres = new Presentation();
  try {
    # Acceder al primer marcador de diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Obtener el gráfico con datos predeterminados
    $chart = $sld->getShapes()->get_Item(0);
    # Establecer el índice de la hoja de datos del gráfico
    $defaultWorksheetIndex = 0;
    # Obtener la hoja de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Cambiar el nombre de la categoría del gráfico
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Tomar la primera serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Ahora actualizando los datos de la serie
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Modificando el nombre de la serie

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Tomar la segunda serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Ahora actualizando los datos de la serie
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Modificando el nombre de la serie

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Ahora, añadiendo una nueva serie
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Tomar la tercera serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Ahora rellenando los datos de la serie
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Guardar la presentación con el gráfico
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer rango de datos para un gráfico**

Para establecer el rango de datos de un gráfico, haga lo siguiente:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) que representa la presentación que contiene el gráfico.
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Recorra todas las formas para encontrar el gráfico deseado.
4. Acceda a los datos del gráfico y establezca el rango.
5. Guarde la presentación modificada como archivo PPTX.

Este código PHP muestra cómo establecer el rango de datos para un gráfico:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usar marcadores predeterminados en los gráficos**

Cuando usa marcadores predeterminados en los gráficos, cada serie del gráfico recibe automáticamente un símbolo de marcador diferente.

Este código PHP muestra cómo establecer automáticamente un marcador para una serie de gráfico:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # Tomar la segunda serie del gráfico
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Ahora rellenando los datos de la serie
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**¿Qué tipos de gráficos admite Aspose.Slides?**

Aspose.Slides admite una amplia gama de [tipos de gráficos](https://reference.aspose.com/slides/es/php-java/aspose.slides/charttype/), incluidos barras, líneas, circulares, áreas, dispersión, histogramas, radar y muchos más. Esta flexibilidad le permite elegir el tipo de gráfico más adecuado para sus necesidades de visualización de datos.

**¿Cómo añado un nuevo gráfico a una diapositiva?**

Para añadir un gráfico, primero cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) , recupere la diapositiva deseada mediante su índice y luego invoque el método para añadir un gráfico, especificando el tipo de gráfico y los datos iniciales. Este proceso integra el gráfico directamente en su presentación.

**¿Cómo puedo actualizar los datos mostrados en un gráfico?**

Puede actualizar los datos de un gráfico accediendo a su libro de datos ([ChartDataWorkbook](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdataworkbook/)), eliminando cualquier serie y categoría predeterminada y luego añadiendo sus datos personalizados. Esto le permite refrescar el gráfico para reflejar la información más reciente.

**¿Es posible personalizar la apariencia del gráfico?**

Sí, Aspose.Slides ofrece amplias opciones de personalización. Puede modificar colores, fuentes, etiquetas, leyendas y otros [elementos de formato](/slides/es/php-java/chart-entities/) para adaptar la apariencia del gráfico a sus requisitos de diseño específicos.