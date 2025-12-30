---
title: Personalizar gráficos 3D en presentaciones usando PHP
linktitle: Gráfico 3D
type: docs
url: /es/php-java/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos 3-D en Aspose.Slides for PHP vía Java, con soporte para archivos PPT y PPTX — mejore sus presentaciones hoy."
---

## **Establecer las propiedades RotationX, RotationY y DepthPercents de un gráfico 3D**
Aspose.Slides for PHP vía Java ofrece una API sencilla para establecer estas propiedades. El siguiente artículo le ayudará a establecer distintas propiedades como **X,Y Rotation, DepthPercents**, etc. El código de ejemplo muestra cómo aplicar la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Establecer las propiedades Rotation3D.
1. Guardar la presentación modificada en un archivo PPTX.
```php
  $pres = new Presentation();
  try {
    # Acceder a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir gráfico con datos predeterminados
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Establecer el índice de la hoja de datos del gráfico
    $defaultWorksheetIndex = 0;
    # Obtener la hoja de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Añadir series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Añadir categorías
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Establecer propiedades Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Obtener la segunda serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Ahora rellenando datos de la serie
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Establecer valor OverLap
    $series->getParentSeriesGroup()->setOverlap(100);
    # Guardar la presentación en disco
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Qué tipos de gráficos admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de los gráficos de columnas, incluyendo Column 3D, Clustered Column 3D, Stacked Column 3D y 100% Stacked Column 3D, junto con los tipos 3D relacionados expuestos a través de la clase [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) en la referencia de la API de la versión que tiene instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen mediante la [chart API](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage), o [renderizar toda la diapositiva](/slides/es/php-java/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto resulta útil cuando necesita una vista previa píxel a píxel perfecta o quiere incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué rendimiento tiene la creación y renderizado de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a una salida de tamaño adecuado (resolución y dimensiones) para que coincida con la pantalla o las necesidades de impresión del destino.