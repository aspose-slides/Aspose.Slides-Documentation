---
title: Administrar marcadores de datos de gráfico en presentaciones usando PHP
linktitle: Marcador de datos
type: docs
url: /es/php-java/chart-data-marker/
keywords:
- gráfico
- punto de datos
- marcador
- opciones de marcador
- tamaño del marcador
- tipo de relleno
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a personalizar los marcadores de datos del gráfico en Aspose.Slides para PHP, mejorando el impacto de la presentación en formatos PPT y PPTX con ejemplos de código claros."
---

## **Configurar opciones de marcador de gráfico**
Los marcadores se pueden establecer en los puntos de datos del gráfico dentro de series específicas. Para configurar las opciones de marcador del gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Obtener la primera serie del gráfico.
- Agregar un nuevo punto de datos.
- Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos configurado las opciones de marcador del gráfico a nivel de puntos de datos.
```php
  # Creando una presentación vacía
  $pres = new Presentation();
  try {
    # Acceder a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Creando el gráfico predeterminado
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Obtención del índice de hoja de datos del gráfico predeterminado
    $defaultWorksheetIndex = 0;
    # Obtención de la hoja de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Eliminar serie de demostración
    $chart->getChartData()->getSeries()->clear();
    # Añadir nueva serie
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Cargar la imagen 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Cargar la imagen 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Tomar la primera serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Añadir nuevo punto (1:3) allí.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Cambiar el marcador de la serie del gráfico
    $series->getMarker()->setSize(15);
    # Guardar la presentación con el gráfico
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Qué formas de marcador están disponibles de forma predeterminada?**

Están disponibles formas estándar (círculo, cuadrado, diamante, triángulo, etc.); la lista está definida por la clase [MarkerStyleType](https://reference.aspose.com/slides/php-java/aspose.slides/markerstyletype/). Si necesita una forma no estándar, utilice un marcador con un relleno de imagen para emular visuales personalizados.

**¿Se conservan los marcadores al exportar un gráfico a una imagen o SVG?**

Sí. Al renderizar gráficos a [formatos raster](/slides/es/php-java/convert-powerpoint-to-png/) o al guardar [formas como SVG](/slides/es/php-java/render-a-slide-as-an-svg-image/), los marcadores conservan su apariencia y configuración, incluyendo tamaño, relleno y contorno.