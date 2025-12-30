---
title: Personalizar leyendas de gráficos en presentaciones usando PHP
linktitle: Leyenda de gráfico
type: docs
url: /es/php-java/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para PHP a través de Java para optimizar presentaciones de PowerPoint con un formato de leyenda a medida."
---

## **Posicionamiento de la Leyenda**
Para establecer las propiedades de la leyenda, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenga la referencia de la diapositiva.
- Añada un gráfico a la diapositiva.
- Establezca las propiedades de la leyenda.
- Grabe la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos establecido la posición y el tamaño de la leyenda del gráfico.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la referencia de la diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar un gráfico de columnas agrupadas en la diapositiva
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Establecer propiedades de la leyenda
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Guardar la presentación en disco
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el Tamaño de Fuente de una Leyenda**
Aspose.Slides for PHP a través de Java permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Grabe la presentación en disco.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el Tamaño de Fuente de una Leyenda Individual**
Aspose.Slides for PHP a través de Java permite a los desarrolladores establecer el tamaño de fuente de entradas de leyenda individuales. Siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Acceda a la entrada de la leyenda.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Grabe la presentación en disco.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Puedo activar la leyenda de modo que el gráfico asigne automáticamente espacio para ella en lugar de superponerse?**

Sí. Utilice el modo sin superposición ([setOverlay(false)](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/)); en este caso, el área de trazado se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda en varias líneas?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea obligatorios se admiten mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo puedo hacer que la leyenda siga el esquema de colores del tema de la presentación?**

No establezca colores/rellenos/fuentes explícitos para la leyenda o su texto. Entonces heredarán del tema y se actualizarán correctamente cuando el diseño cambie.