---
title: Añadir líneas de tendencia a los gráficos de presentación en PHP
linktitle: Línea de tendencia
type: docs
url: /es/php-java/trend-line/
keywords:
- gráfico
- línea de tendencia
- línea de tendencia exponencial
- línea de tendencia lineal
- línea de tendencia logarítmica
- línea de tendencia de media móvil
- línea de tendencia polinómica
- línea de tendencia de potencia
- línea de tendencia personalizada
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Añade rápidamente y personaliza líneas de tendencia en los gráficos de PowerPoint con Aspose.Slides para PHP via Java: una guía práctica para captar la atención de tu audiencia."
---

## **Agregar una línea de tendencia**
Aspose.Slides for PHP via Java proporciona una API simple para gestionar diferentes líneas de tendencia de gráficos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un gráfico con datos predeterminados y el tipo deseado (este ejemplo utiliza ChartType::ClusteredColumn).
1. Agregar una línea de tendencia exponencial para la serie 1 del gráfico.
1. Agregar una línea de tendencia lineal para la serie 1 del gráfico.
1. Agregar una línea de tendencia logarítmica para la serie 2 del gráfico.
1. Agregar una línea de tendencia de media móvil para la serie 2 del gráfico.
1. Agregar una línea de tendencia polinómica para la serie 3 del gráfico.
1. Agregar una línea de tendencia de potencia para la serie 3 del gráfico.
1. Escriba la presentación modificada en un archivo PPTX.

El siguiente código se usa para crear un gráfico con líneas de tendencia.
```php
  # Crear una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Crear un gráfico de columnas agrupadas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Añadiendo línea de tendencia exponencial para la serie 1 del gráfico
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Añadiendo línea de tendencia lineal para la serie 1 del gráfico
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Añadiendo línea de tendencia logarítmica para la serie 2 del gráfico
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Añadiendo línea de tendencia de media móvil para la serie 2 del gráfico
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Añadiendo línea de tendencia polinómica para la serie 3 del gráfico
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Añadiendo línea de tendencia de potencia para la serie 3 del gráfico
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Guardando la presentación
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Agregar una línea personalizada**
Aspose.Slides for PHP via Java proporciona una API simple para agregar líneas personalizadas en un gráfico. Para agregar una línea simple y sencilla a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)
- Obtenga la referencia de una diapositiva usando su índice
- Cree un nuevo gráfico usando el método AddChart expuesto por el objeto Shapes
- Agregue una AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes
- Establezca el color de las líneas de la forma.
- Escriba la presentación modificada como un archivo PPTX

El siguiente código se usa para crear un gráfico con líneas personalizadas.
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


## **Preguntas frecuentes**

**¿Qué significan 'forward' y 'backward' en una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades de eje; para gráficos que no son de dispersión — en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva a una imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/es/php-java/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del propio gráfico](/slides/es/php-java/create-shape-thumbnails/).