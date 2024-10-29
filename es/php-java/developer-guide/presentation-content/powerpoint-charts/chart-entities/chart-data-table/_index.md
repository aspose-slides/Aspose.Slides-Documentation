---
title: Tabla de Datos del Gráfico
type: docs
url: /es/php-java/chart-data-table/
---

## **Establecer Propiedades de Fuente para la Tabla de Datos del Gráfico**
Aspose.Slides para PHP a través de Java proporciona soporte para cambiar el color de las categorías en un color de serie.

1. Crear un objeto de clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Agregar un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer altura de fuente.
1. Guardar la presentación modificada.

 A continuación se presenta un ejemplo de muestra.

```php
  # Creando presentación vacía
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```