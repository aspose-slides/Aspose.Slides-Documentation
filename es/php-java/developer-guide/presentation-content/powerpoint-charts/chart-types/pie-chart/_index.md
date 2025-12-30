---
title: Personalizar gráficos circulares en presentaciones usando PHP
linktitle: Gráfico circular
type: docs
url: /es/php-java/pie-chart/
keywords:
- gráfico circular
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración de gráfico
- opciones de trazado
- color de porción
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprende a crear y personalizar gráficos circulares con Aspose.Slides para PHP via Java, exportables a PowerPoint, mejorando la narración de tus datos en segundos."
---

## **Opciones de segunda trama para gráficos Pie of Pie y Bar of Pie**
Aspose.Slides for PHP via Java ahora admite opciones de segunda trama para los gráficos Pie of Pie o Bar of Pie. En este tema, le mostraremos cómo especificar esas opciones usando Aspose.Slides. Para especificar las propiedades, haga lo siguiente:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Añadir un gráfico en la diapositiva.
1. Especificar las opciones de segunda trama del gráfico.
1. Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos establecido diferentes propiedades del gráfico Pie of Pie.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Añadir un gráfico en la diapositiva
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Establecer diferentes propiedades
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Guardar la presentación en disco
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer colores automáticos de las porciones del gráfico circular**
Aspose.Slides for PHP via Java proporciona una API sencilla para establecer colores automáticos de las porciones del gráfico circular. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Añadir un gráfico con datos predeterminados.
1. Establecer el título del gráfico.
1. Configurar la primera serie para Mostrar valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de datos del gráfico.
1. Eliminar las series y categorías generadas por defecto.
1. Añadir nuevas categorías.
1. Añadir una nueva serie.

Guardar la presentación modificada en un archivo PPTX.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Añadir un gráfico con datos predeterminados
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Establecer el título del gráfico
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Configurar la primera serie para mostrar valores
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Establecer el índice de la hoja de datos del gráfico
    $defaultWorksheetIndex = 0;
    # Obtener la hoja de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Eliminar series y categorías generadas por defecto
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Añadir nuevas categorías
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Añadir nueva serie
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Ahora rellenando los datos de la serie
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) una trama secundaria para los gráficos circulares, incluidas los tipos 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar sólo el gráfico como imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como imagen](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (por ejemplo, PNG) sin toda la presentación.