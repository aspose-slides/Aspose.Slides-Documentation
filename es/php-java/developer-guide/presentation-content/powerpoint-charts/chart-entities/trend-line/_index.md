---
title: Línea de Tendencia
type: docs
url: /php-java/lnea-de-tendencia/
---

## **Agregar Línea de Tendencia**
Aspose.Slides para PHP a través de Java proporciona una API simple para gestionar diferentes Líneas de Tendencia en gráficos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquier tipo deseado (este ejemplo utiliza ChartType::ClusteredColumn).
1. Agregar línea de tendencia exponencial para la serie de gráficos 1.
1. Agregar línea de tendencia lineal para la serie de gráficos 1.
1. Agregar línea de tendencia logarithmica para la serie de gráficos 2.
1. Agregar línea de tendencia de media móvil para la serie de gráficos 2.
1. Agregar línea de tendencia polinómica para la serie de gráficos 3.
1. Agregar línea de tendencia de potencia para la serie de gráficos 3.
1. Escribir la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico con Líneas de Tendencia.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Crear un gráfico de columnas agrupadas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Agregar línea de tendencia exponencial para la serie de gráficos 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Agregar línea de tendencia lineal para la serie de gráficos 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Agregar línea de tendencia logarítmica para la serie de gráficos 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("Nueva línea de tendencia logarítmica");
    # Agregar línea de tendencia de media móvil para la serie de gráficos 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("Nuevo Nombre de Línea de Tendencia");
    # Agregar línea de tendencia polinómica para la serie de gráficos 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Agregar línea de tendencia de potencia para la serie de gráficos 3
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Guardar presentación
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Agregar Línea Personalizada**
Aspose.Slides para PHP a través de Java proporciona una API simple para agregar líneas personalizadas en un gráfico. Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)
- Obtener la referencia de una diapositiva utilizando su índice
- Crear un nuevo gráfico utilizando el método AddChart expuesto por el objeto Shapes
- Agregar un AutoShape de tipo línea utilizando el método AddAutoShape expuesto por el objeto Shapes
- Establecer el color de las líneas de la forma.
- Escribir la presentación modificada como un archivo PPTX

El siguiente código se utiliza para crear un gráfico con Líneas Personalizadas.

```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```