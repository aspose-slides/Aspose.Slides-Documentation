---
title: Marcador de Datos del Gráfico
type: docs
url: /php-java/chart-data-marker/
---

## **Configurar Opciones de Marcador del Gráfico**
Los marcadores se pueden establecer en los puntos de datos del gráfico dentro de series particulares. Para configurar las opciones de marcador del gráfico. Por favor, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Tomar la primera serie del gráfico.
- Agregar un nuevo punto de datos.
- Escribir la presentación en el disco.

En el ejemplo dado a continuación, hemos configurado las opciones de marcador del gráfico a nivel de los puntos de datos.

```php
  # Creando presentación vacía
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Creando el gráfico predeterminado
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Obteniendo el índice de la hoja de trabajo de datos del gráfico predeterminado
    $defaultWorksheetIndex = 0;
    # Obteniendo la hoja de trabajo de datos del gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Eliminar serie de demostración
    $chart->getChartData()->getSeries()->clear();
    # Agregar nueva serie
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Serie 1"), $chart->getType());
    # Cargar la imagen 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Cargar la imagen 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Tomar la primera serie del gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Agregar nuevo punto (1:3) allí.
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
    # Cambiando el marcador de la serie del gráfico
    $series->getMarker()->setSize(15);
    # Guardar presentación con gráfico
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```