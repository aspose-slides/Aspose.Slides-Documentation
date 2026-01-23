---
title: Personalizar barras de error en gráficos de presentaciones usando PHP
linktitle: Barra de error
type: docs
url: /es/php-java/error-bar/
keywords:
- barra de error
- valor personalizado
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a añadir y personalizar barras de error en los gráficos con Aspose.Slides for PHP via Java — optimice la visualización de datos en presentaciones de PowerPoint."
---

## **Agregar barras de error**
Aspose.Slides for PHP via Java proporciona una API simple para administrar los valores de las barras de error. El código de ejemplo se aplica cuando se utiliza un tipo de valor personalizado. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección de [**puntos de datos**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/) de la serie:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Agregar un gráfico de burbujas en la diapositiva deseada.
1. Acceder a la primera serie del gráfico y establecer el formato X de la barra de error.
1. Acceder a la primera serie del gráfico y establecer el formato Y de la barra de error.
1. Establecer los valores y el formato de las barras.
1. Escribir la presentación modificada en un archivo PPTX.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Crear un gráfico de burbujas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Añadir barras de error y establecer su formato
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Guardar la presentación
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Agregar valores personalizados de barras de error**
Aspose.Slides for PHP via Java proporciona una API simple para gestionar valores personalizados de barras de error. El código de ejemplo se aplica cuando el método [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/#getValueType) devuelve **Custom**. Para especificar un valor, use la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección de [**puntos de datos**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/) de la serie:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Agregar un gráfico de burbujas en la diapositiva deseada.
1. Acceder a la primera serie del gráfico y establecer el formato X de la barra de error.
1. Acceder a la primera serie del gráfico y establecer el formato Y de la barra de error.
1. Acceder a los puntos de datos individuales de la serie del gráfico y establecer los valores de la barra de error para cada punto de datos de la serie.
1. Establecer los valores y el formato de las barras.
1. Escribir la presentación modificada en un archivo PPTX.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Crear un gráfico de burbujas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Añadir barras de error personalizadas y establecer su formato
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Acceder al punto de datos de la serie del gráfico y establecer los valores de las barras de error para
    # punto individual
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Establecer las barras de error para los puntos de la serie del gráfico
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Guardar la presentación
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Qué ocurre con las barras de error al exportar una presentación a PDF o imágenes?**

Se renderizan como parte del gráfico y se conservan durante la conversión junto con el resto del formato del gráfico, siempre que se utilice una versión o motor compatible.

**¿Se pueden combinar las barras de error con marcadores y etiquetas de datos?**

Sí. Las barras de error son un elemento independiente y son compatibles con los marcadores y las etiquetas de datos; si los elementos se superponen, es posible que sea necesario ajustar el formato.

**¿Dónde puedo encontrar la lista de propiedades y clases para trabajar con barras de error en la API?**

En la referencia de la API: la clase [ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) y las clases relacionadas [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) y [ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/).