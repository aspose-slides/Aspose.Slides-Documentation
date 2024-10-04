---
title: Leyenda del Gráfico
type: docs
url: /php-java/chart-legend/
---

## **Posicionamiento de la Leyenda**
Para establecer las propiedades de la leyenda. Por favor, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenga la referencia de la diapositiva.
- Agregue un gráfico en la diapositiva.
- Establezca las propiedades de la leyenda.
- Escriba la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos establecido la posición y el tamaño de la leyenda del gráfico.

```php
  # Cree una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtenga la referencia de la diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregue un gráfico de columnas agrupadas en la diapositiva
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Establezca las propiedades de la leyenda
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Escriba la presentación en el disco
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer el Tamaño de Fuente de la Leyenda**
Aspose.Slides para PHP a través de Java permite a los desarrolladores establecer el tamaño de fuente de la leyenda. Por favor, siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Escriba la presentación en el disco.

```php
  # Cree una instancia de la clase Presentation
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

## **Establecer el Tamaño de Fuente de Leyenda Individual**
Aspose.Slides para PHP a través de Java permite a los desarrolladores establecer el tamaño de fuente de entradas de leyenda individuales. Por favor, siga los pasos a continuación:

- Instancie la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Cree el gráfico predeterminado.
- Acceda a la entrada de la leyenda.
- Establezca el tamaño de fuente.
- Establezca el valor mínimo del eje.
- Establezca el valor máximo del eje.
- Escriba la presentación en el disco.

```php
  # Cree una instancia de la clase Presentation
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