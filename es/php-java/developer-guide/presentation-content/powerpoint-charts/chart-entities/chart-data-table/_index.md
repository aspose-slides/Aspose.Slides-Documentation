---
title: Personalizar tablas de datos de gráficos en presentaciones usando PHP
linktitle: Tabla de datos
type: docs
url: /es/php-java/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Personaliza tablas de datos de gráficos para PPT y PPTX con Aspose.Slides para PHP via Java para aumentar la eficiencia y el atractivo en las presentaciones."
---

## **Establecer propiedades de fuente para una tabla de datos de gráfico**
Aspose.Slides for PHP via Java proporciona soporte para cambiar el color de las categorías en una serie. 

1. Instanciar el objeto de clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Añadir un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

 Ejemplo de muestra a continuación. 
```php
  # Creando una presentación vacía
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


## **FAQ**

**¿Puedo mostrar pequeñas claves de leyenda junto a los valores en la tabla de datos del gráfico?**

Sí. La tabla de datos admite [claves de leyenda](https://reference.aspose.com/slides/php-java/aspose.slides/datatable/setshowlegendkey/), y puedes activarlas o desactivarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides representa el gráfico como parte de la diapositiva, por lo que el [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/es/php-java/convert-powerpoint-to-html/)/[image](/slides/es/php-java/convert-powerpoint-to-png/) exportado incluye el gráfico con su tabla de datos.

**¿Se admiten tablas de datos para gráficos que provienen de un archivo de plantilla?**

Sí. Para cualquier gráfico cargado desde una presentación o plantilla existente, puedes comprobar y cambiar si una tabla de datos [se muestra](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/) usando las propiedades del gráfico.

**¿Cómo puedo encontrar rápidamente qué gráficos en un archivo tienen la tabla de datos activada?**

Inspecciona la propiedad de cada gráfico que indica si la tabla de datos [se muestra](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/) y recorre las diapositivas para identificar los gráficos donde está habilitada.