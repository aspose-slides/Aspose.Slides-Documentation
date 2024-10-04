---
title: Barra de Error
type: docs
url: /es/php-java/error-bar/
---

## **Agregar Barra de Error**
Aspose.Slides para PHP a través de Java proporciona una API simple para gestionar los valores de la barra de error. El código de muestra se aplica al usar un tipo de valor personalizado. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección de [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection):

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Agrega un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie del gráfico y establece el formato X de la barra de error.
1. Accede a la primera serie del gráfico y establece el formato Y de la barra de error.
1. Estableciendo valores y formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Creando un gráfico de burbujas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Agregando barras de error y estableciendo su formato
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
    # Guardando la presentación
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Agregar Valor de Barra de Error Personalizado**
Aspose.Slides para PHP a través de Java proporciona una API simple para gestionar valores personalizados de barra de error. El código de muestra se aplica cuando la propiedad [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) es igual a **Custom**. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección de [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection):

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Agrega un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie del gráfico y establece el formato X de la barra de error.
1. Accede a la primera serie del gráfico y establece el formato Y de la barra de error.
1. Accede a los puntos de datos individuales de la serie del gráfico y establece los valores de la barra de error para el punto de datos de serie individual.
1. Estableciendo valores y formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Creando un gráfico de burbujas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Agregando barras de error personalizadas y estableciendo su formato
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Accediendo a los puntos de datos de la serie del gráfico y estableciendo los valores de las barras de error para
    # el punto individual
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Estableciendo barras de error para los puntos de la serie del gráfico
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Guardando la presentación
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```