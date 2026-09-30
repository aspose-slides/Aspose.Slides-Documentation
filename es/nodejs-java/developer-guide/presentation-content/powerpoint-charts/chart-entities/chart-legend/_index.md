---
title: Personalizar leyendas de gráficos en presentaciones usando JavaScript
linktitle: Leyenda del gráfico
type: docs
url: /es/nodejs-java/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para Node.js a través de Java para optimizar las presentaciones de PowerPoint con un formato de leyenda a medida."
---
## **Visión general**

Aspose.Slides for Node.js via Java ofrece opciones para personalizar las leyendas de los gráficos en presentaciones de PowerPoint. Este artículo muestra cómo posicionar y dimensionar una leyenda, establecer el tamaño de fuente para toda la leyenda, formatear una entrada individual de la leyenda y ocultar o restaurar entradas seleccionadas.

Las preguntas frecuentes cubren comportamientos relacionados, incluyendo reservar espacio para la leyenda, mostrar etiquetas de varias líneas y heredar el formato del tema de la presentación.

## **Posicionamiento de la leyenda**

Utilice los métodos [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) y [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) de la leyenda para especificar su posición y tamaño como fracciones de las dimensiones del gráfico.

Este ejemplo crea una presentación y añade un gráfico de columnas agrupadas con datos predeterminados a la primera diapositiva. Dividir los desplazamientos y dimensiones deseados de la leyenda entre el ancho y alto del gráfico los convierte en valores relativos: la leyenda se desplaza 50 puntos desde la esquina superior izquierda del gráfico y su tamaño es de 100 por 100 puntos.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Expresar la posición y el tamaño de la leyenda en relación con el gráfico.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el tamaño de fuente de una leyenda**

Utilice [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) de la leyenda para acceder a su formato de texto y [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) para establecer el tamaño de fuente en puntos.

Este ejemplo crea un gráfico con datos predeterminados y establece el texto de la leyenda a 20 puntos. También desactiva los límites automáticos del eje vertical y define su rango de -5 a 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el tamaño de fuente de una entrada individual de la leyenda**

Utilice la colección devuelta por el método [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) de la leyenda para acceder al formato de una entrada específica. Los índices de las entradas comienzan en cero, por lo que el índice `1` se refiere a la segunda entrada.

Este ejemplo crea un gráfico de columnas agrupadas cuyo conjunto de datos predeterminado incluye al menos dos series. Formatea la segunda entrada de la leyenda con negrita, cursiva y texto azul de 20 puntos.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ocultar entradas individuales de la leyenda**

Para excluir una serie auxiliar de la leyenda manteniendo sus datos visibles, llame a [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) con `true` a través de [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Esto oculta solo la entrada de la leyenda seleccionada; no elimina la serie ni sus puntos de datos. Llamar a [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) con `false`, en cambio, oculta la leyenda completa.

El ejemplo a continuación crea un gráfico de columnas agrupadas con varias series utilizando datos predeterminados. Oculta la entrada de la leyenda de la segunda serie (índice `1`) y guarda la presentación. Luego restaura la entrada llamando a [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) con `false` y guarda una segunda copia. Las columnas permanecen visibles en ambos archivos.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Restaurar la misma entrada sin cambiar los datos del gráfico.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparación a continuación muestra el mismo gráfico con todas las entradas visibles y con la segunda entrada oculta. Las columnas de la segunda serie permanecen sin cambios.

![Comparación de un gráfico con todas las entradas de la leyenda visibles y con la Serie 2 oculta en la leyenda; todas las columnas permanecen visibles.](hide-legend-entry.png)

En los gráficos de columnas, barras y líneas, las entradas de la leyenda identifican series. En los gráficos de pastel, identifican puntos de datos individuales (rebanadas), por lo que debe usar [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) en la rebanada seleccionada. La documentación de la API expone este método de punto de datos para los tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` y `BarOfPie`. No asuma que se aplica a los gráficos de rosquilla, que no están incluidos en esa lista.

## **Preguntas frecuentes**

**¿Puedo hacer que el gráfico reserve espacio para la leyenda en lugar de superponerla?**

Sí. Llame a [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) con `false` para reservar espacio para la leyenda en lugar de permitir que se superponga al área del gráfico.

**¿Puedo crear etiquetas de leyenda de varias líneas?**

Sí. Las etiquetas largas pueden ajustarse cuando el ancho disponible es insuficiente. También puede usar caracteres de nueva línea en los nombres de las series para solicitar saltos de línea.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

Deje sin definir los colores, rellenos y fuentes de la leyenda para que pueda heredar el formato del tema. El formato explícito anula la configuración correspondiente del tema.