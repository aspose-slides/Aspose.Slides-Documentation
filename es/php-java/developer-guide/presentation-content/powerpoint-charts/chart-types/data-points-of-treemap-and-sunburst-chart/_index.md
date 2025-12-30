---
title: Personalizar puntos de datos en gráficos Treemap y Sunburst usando PHP
linktitle: Puntos de datos en gráficos Treemap y Sunburst
type: docs
url: /es/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- punto de datos
- color de etiqueta
- color de rama
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo gestionar los puntos de datos en gráficos treemap y sunburst con Aspose.Slides para PHP a través de Java, compatible con los formatos de PowerPoint."
---

Entre los demás tipos de gráficos de PowerPoint, existen dos tipos "jerárquicos": el gráfico **Treemap** y el gráfico **Sunburst** (también conocido como Gráfico Sunburst, Diagrama Sunburst, Gráfico radial, Gráfico radial o Gráfico de pastel multilevel). Estos gráficos muestran datos jerárquicos organizados como un árbol, desde las hojas hasta la parte superior de la rama. Las hojas se definen por los puntos de datos de la serie, y cada nivel de agrupación anidado posterior se define por la categoría correspondiente. Aspose.Slides for PHP a través de Java permite dar formato a los puntos de datos del gráfico Sunburst y Treemap.

A continuación se muestra un gráfico Sunburst, donde los datos en la columna Series1 definen los nodos hoja, mientras que las demás columnas definen los puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Empecemos añadiendo un nuevo gráfico Sunburst a la presentación:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="Ver también" %}} 
- [**Creando gráfico Sunburst**](/slides/es/php-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Si es necesario dar formato a los puntos de datos del gráfico, debemos usar lo siguiente:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager), [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) clases y el método [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPoint#getDataPointLevels--) proporcionan acceso para dar formato a los puntos de datos de los gráficos Treemap y Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager) se utiliza para acceder a categorías de varios niveles; representa el contenedor de objetos [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) . Básicamente es un contenedor para [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartCategoryLevelsManager) con propiedades añadidas específicas para los puntos de datos. La clase [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) tiene dos métodos: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getFormat--) y [**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getLabel--) que proporcionan acceso a la configuración correspondiente.

## **Mostrar el valor de un punto de datos**
Mostrar el valor del punto de datos "Leaf 4":
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Establecer etiqueta y color del punto de datos**
Establecer la etiqueta de datos de "Branch 1" para que muestre el nombre de la serie ("Series1") en lugar del nombre de la categoría. Luego establecer el color del texto a amarillo:
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Establecer color de rama del punto de datos**
Cambiar el color de la rama "Steam 4":
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Preguntas frecuentes**

**¿Puedo cambiar el orden (clasificación) de los segmentos en Sunburst/Treemap?**

No. PowerPoint ordena los segmentos automáticamente (normalmente por valores descendentes, en sentido horario). Aspose.Slides refleja este comportamiento: no puedes cambiar el orden directamente; lo consigues preprocesando los datos.

**¿Cómo afecta el tema de la presentación a los colores de los segmentos y etiquetas?**

Los colores del gráfico heredan el [theme/palette](/slides/es/php-java/presentation-theme/) de la presentación a menos que establezcas explícitamente rellenos/fuentes. Para obtener resultados consistentes, fija rellenos sólidos y el formato de texto en los niveles necesarios.

**¿Se conservarán los colores de rama personalizados y la configuración de etiquetas al exportar a PDF/PNG?**

Sí. Al exportar la presentación, la configuración del gráfico (rellenos, etiquetas) se conserva en los formatos de salida porque Aspose.Slides renderiza aplicando el formato del gráfico.

**¿Puedo calcular las coordenadas reales de una etiqueta/elemento para colocar una superposición personalizada sobre el gráfico?**

Sí. Después de que se valida la disposición del gráfico, están disponibles los valores reales de *x* e *y* para los elementos (por ejemplo, una [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/)), lo que ayuda a posicionar con precisión las superposiciones.