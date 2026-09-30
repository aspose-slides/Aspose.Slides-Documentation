---
title: Personalizar leyendas de gráficos en presentaciones usando PHP
linktitle: Leyenda del gráfico
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
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para PHP vía Java para optimizar presentaciones de PowerPoint con un formato de leyenda a medida."
---
## **Visión general**

Aspose.Slides for PHP via Java ofrece opciones para personalizar las leyendas de los gráficos en presentaciones de PowerPoint. Este artículo muestra cómo posicionar y dimensionar una leyenda, establecer el tamaño de fuente para toda la leyenda, formatear una entrada de leyenda individual y ocultar o restaurar entradas seleccionadas.

Las Preguntas frecuentes cubren comportamientos relacionados, incluyendo reservar espacio para la leyenda, mostrar etiquetas multilínea y heredar el formato del tema de la presentación.

## **Posicionamiento de la leyenda**

Utilice los métodos [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/) y [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) de la leyenda para especificar su posición y tamaño como fracciones de las dimensiones del gráfico.

Este ejemplo crea una presentación y añade un gráfico de columnas agrupadas con datos predeterminados a la primera diapositiva. Dividir los desplazamientos y dimensiones deseados de la leyenda por el ancho y alto del gráfico los convierte en valores relativos: la leyenda se desplaza 50 puntos desde la esquina superior izquierda del gráfico y su tamaño es de 100 × 100 puntos. El ejemplo usa java_values para convertir las dimensiones del gráfico devueltas por PHP/Java Bridge a números PHP antes de la división.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Expresar la posición y el tamaño de la leyenda respecto al gráfico.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer el tamaño de fuente de una leyenda**

Utilice el método [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) de la leyenda para acceder a su formato de texto y use [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) para establecer el tamaño de fuente en puntos.

Este ejemplo crea un gráfico con datos predeterminados y establece el texto de la leyenda a 20 puntos. También deshabilita los límites automáticos para el eje vertical y fija su rango de -5 a 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer el tamaño de fuente de una entrada de leyenda individual**

Utilice la colección devuelta por el método [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) de la leyenda para acceder al formato de una entrada específica. Los índices de las entradas comienzan en cero, por lo que el índice `1` se refiere a la segunda entrada.

Este ejemplo crea un gráfico de columnas agrupadas cuyo conjunto de datos predeterminado incluye al menos dos series. Da formato a la segunda entrada de la leyenda con texto azul, en negrita, cursiva y de 20 puntos.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ocultar entradas de leyenda individuales**

Para excluir una serie auxiliar de la leyenda manteniendo sus datos visibles, llame a [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) con `true` a través de [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Esto oculta solo la entrada de leyenda seleccionada; no elimina la serie ni sus puntos de datos. Llamar a [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) con `false`, por el contrario, oculta la leyenda completa.

El ejemplo a continuación crea un gráfico de columnas agrupadas con varias series usando datos predeterminados. Oculta la entrada de leyenda de la segunda serie (índice `1`) y guarda la presentación. Luego restaura la entrada llamando a [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) con `false` y guarda una segunda copia. Las columnas siguen siendo visibles en ambos archivos.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Restaurar la misma entrada sin cambiar los datos del gráfico.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La comparación a continuación muestra el mismo gráfico con todas las entradas visibles y con la segunda entrada oculta. Las columnas de la segunda serie permanecen sin cambios.

![Comparación de un gráfico con todas las entradas de leyenda visibles y con la Serie 2 oculta de la leyenda; todas las columnas permanecen visibles.](hide-legend-entry.png)

En gráficos de columnas, barras y líneas, las entradas de la leyenda identifican series. En los gráficos circulares, identifican puntos de datos individuales (porciones), por lo que debe usar [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) en la porción seleccionada. La API documenta este método de punto de datos para los tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` y `BarOfPie`. No asuma que se aplica a los gráficos de anillo, que no están incluidos en esa lista.

## **Preguntas frecuentes**

**¿Puedo hacer que el gráfico reserve espacio para la leyenda en lugar de superponerse?**

Sí. Llame a [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) con `false` para reservar espacio para la leyenda en lugar de permitir que se superponga al área del gráfico.

**¿Puedo crear etiquetas de leyenda multilínea?**

Sí. Las etiquetas largas pueden ajustarse cuando el ancho disponible es insuficiente. También puede usar caracteres de salto de línea en los nombres de las series para solicitar rupturas de línea.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

Deje sin establecer los colores, rellenos y fuentes de la leyenda para que pueda heredar el formato del tema. El formato explícito sobrescribe la configuración correspondiente del tema.