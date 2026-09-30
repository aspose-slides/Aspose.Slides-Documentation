---
title: Personalizar leyendas de gráficos en presentaciones usando Java
linktitle: Leyenda del gráfico
type: docs
url: /es/java/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para Java para optimizar presentaciones de PowerPoint con un formato de leyenda a medida."
---
## **Visión general**

Aspose.Slides for Java ofrece opciones para personalizar las leyendas de los gráficos en presentaciones de PowerPoint. Este artículo muestra cómo posicionar y dimensionar una leyenda, establecer el tamaño de fuente para toda la leyenda, dar formato a una entrada de leyenda individual y ocultar o restaurar entradas seleccionadas.

Las preguntas frecuentes (FAQ) describen comportamientos relacionados, como reservar espacio para la leyenda, mostrar etiquetas multilínea y heredar el formato del tema de la presentación.

## **Posicionamiento de la leyenda**

Utilice los métodos [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), y [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) de la leyenda para especificar su posición y tamaño como fracciones de las dimensiones del gráfico.

Este ejemplo crea una presentación y añade un gráfico de columnas agrupadas con datos predeterminados a la primera diapositiva. Dividir los desplazamientos y dimensiones deseados de la leyenda entre el ancho y alto del gráfico los convierte en valores relativos: la leyenda se desplaza 50 puntos desde la esquina superior izquierda del gráfico y tiene un tamaño de 100 por 100 puntos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Expresa la posición y el tamaño de la leyenda en relación con el gráfico.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el tamaño de fuente de una leyenda**

Utilice el método [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) de la leyenda para acceder a su formato de texto y emplee [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) para establecer el tamaño de fuente en puntos.

Este ejemplo crea un gráfico con datos predeterminados y establece el texto de la leyenda a 20 puntos. También desactiva los límites automáticos para el eje vertical y define su rango de -5 a 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer el tamaño de fuente de una entrada de leyenda individual**

Utilice la colección devuelta por el método [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) de la leyenda para acceder al formato de una entrada concreta. Los índices de las entradas empiezan en cero, por lo que el índice `1` corresponde a la segunda entrada.

Este ejemplo crea un gráfico de columnas agrupadas cuyos datos predeterminados incluyen al menos dos series. Da formato a la segunda entrada de la leyenda con texto negrita, cursiva y azul de 20 puntos.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ocultar entradas de leyenda individuales**

Para excluir una serie auxiliar de la leyenda manteniendo sus datos visibles, llame a [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) con `true` mediante [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Esto oculta solo la entrada de leyenda seleccionada; no elimina la serie ni sus puntos de datos. En cambio, llamar a [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) con `false` oculta la leyenda completa.

El ejemplo siguiente crea un gráfico de columnas agrupadas con varias series usando datos predeterminados. Oculta la entrada de leyenda de la segunda serie (índice `1`) y guarda la presentación. Luego restaura la entrada llamando a [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) con `false` y guarda una segunda copia. Las columnas siguen visibles en ambos archivos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Restaurar la misma entrada sin cambiar los datos del gráfico.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparación a continuación muestra el mismo gráfico con todas las entradas visibles y con la segunda entrada oculta. Las columnas de la segunda serie permanecen sin cambios.

![Comparación de un gráfico con todas las entradas de leyenda visibles y con la Serie 2 oculta de la leyenda; todas las columnas permanecen visibles.](hide-legend-entry.png)

En los gráficos de columnas, barras y líneas, las entradas de la leyenda identifican series. En los gráficos de pastel, identifican puntos de datos individuales (rebanadas), por lo que debe usar [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) sobre la rebanada seleccionada. La API documenta este método de punto de datos para los tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` y `BarOfPie`. No asuma que se aplica a los gráficos de anillo, que no están incluidos en esa lista.

## **Preguntas frecuentes**

**¿Puedo hacer que el gráfico reserve espacio para la leyenda en lugar de superponerse a ella?**

Sí. Llame a [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) con `false` para reservar espacio para la leyenda en lugar de permitir que se superponga al área de trazado.

**¿Puedo crear etiquetas de leyenda multilínea?**

Sí. Las etiquetas largas pueden ajustarse cuando el ancho disponible es insuficiente. También puede usar caracteres de salto de línea en los nombres de series para solicitar quiebres de línea.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

Deje sin establecer los colores, rellenos y fuentes de la leyenda para que pueda heredar el formato del tema. Un formato explícito sobrescribe la configuración correspondiente del tema.