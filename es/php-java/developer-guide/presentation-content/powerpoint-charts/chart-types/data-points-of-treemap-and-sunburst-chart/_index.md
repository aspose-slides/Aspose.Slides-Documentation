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
description: "Aprenda a gestionar los puntos de datos en gráficos treemap y sunburst con Aspose.Slides para PHP a través de Java, compatible con los formatos de PowerPoint."
---

Entre los demás tipos de gráficos de PowerPoint, existen dos tipos «jerárquicos»: el gráfico **Treemap** y el gráfico **Sunburst** (también conocido como Gráfico Sunburst, Diagrama Sunburst, Gráfico radial, Gráfico circular radial o Gráfico de pastel multinivel). Estos gráficos muestran datos jerárquicos organizados como un árbol, desde las hojas hasta la rama superior. Las hojas se definen mediante los puntos de datos de la serie, y cada nivel de agrupación anidado posterior se define por la categoría correspondiente. Aspose.Slides for PHP via Java permite dar formato a los puntos de datos del gráfico Sunburst y del Treemap .

Este es un gráfico Sunburst, donde los datos de la columna Series1 definen los nodos hoja, mientras que el resto de columnas definen los puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Comencemos añadiendo un nuevo gráfico Sunburst a la presentación:
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
- [**Crear o actualizar gráficos de presentaciones PowerPoint en PHP**](/slides/es/php-java/create-chart/)
{{% /alert %}}

Si es necesario dar formato a los puntos de datos del gráfico, debemos utilizar lo siguiente:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) classes 
and [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) method 
provide access to format data points of Treemap and Sunburst charts. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevelsmanager/)
is used for accessing multi-level categories - it represents the container of 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) objects.
Basically it is a wrapper for 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/) with
the properties added specific for data points. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) class has
two methods: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/#getFormat) and 
[**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/#getLabel) which
provide access to corresponding settings.

## **Mostrar el valor de un punto de datos**
Mostrar el valor del punto de datos "Leaf 4":
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Establecer una etiqueta y color de un punto de datos**
Establezca la etiqueta del punto de datos "Branch 1" para que muestre el nombre de la serie ("Series1") en lugar del nombre de la categoría. A continuación, establezca el color del texto a amarillo:
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Establecer el color de una rama de punto de datos**
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

No. PowerPoint ordena los segmentos de forma automática (normalmente por valores descendentes, en sentido horario). Aspose.Slides refleja este comportamiento: no se puede cambiar el orden directamente; se logra preprocesando los datos.

**¿Cómo afecta el tema de la presentación a los colores de los segmentos y las etiquetas?**

Los colores del gráfico heredan el [tema/paleta](/slides/es/php-java/presentation-theme/) de la presentación, a menos que se establezcan explícitamente rellenos/fuentes. Para obtener resultados consistentes, bloquee los rellenos sólidos y el formato de texto en los niveles requeridos.

**¿La exportación a PDF/PNG preservará los colores de rama personalizados y la configuración de etiquetas?**

Sí. Al exportar la presentación, la configuración del gráfico (rellenos, etiquetas) se conserva en los formatos de salida porque Aspose.Slides renderiza con el formato del gráfico aplicado.

**¿Puedo calcular las coordenadas reales de una etiqueta/elemento para colocar una superposición personalizada sobre el gráfico?**

Sí. Después de validar el diseño del gráfico, están disponibles los valores reales de *x* y *y* para los elementos (por ejemplo, una [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/)), lo que ayuda a posicionar con precisión las superposiciones.