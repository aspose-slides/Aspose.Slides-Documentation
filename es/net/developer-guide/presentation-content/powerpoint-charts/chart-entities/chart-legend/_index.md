---
title: Personalizar leyendas de gráficos en presentaciones en .NET
linktitle: Leyenda del gráfico
type: docs
url: /es/net/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para .NET para optimizar las presentaciones de PowerPoint con un formato de leyenda a medida."
---
## **Visión general**

Aspose.Slides for .NET ofrece opciones para personalizar las leyendas de los gráficos en presentaciones de PowerPoint. Este artículo muestra cómo posicionar y dimensionar una leyenda, establecer el tamaño de fuente para toda la leyenda, formatear una entrada individual de la leyenda y ocultar o restaurar entradas seleccionadas.

Las preguntas frecuentes cubren comportamientos relacionados, incluyendo reservar espacio para la leyenda, mostrar etiquetas multilínea y heredar el formato del tema de la presentación.

## **Posicionamiento de la leyenda**

Utilice las propiedades [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) y [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) de la leyenda para especificar su posición y tamaño como fracciones de las dimensiones del gráfico.

Este ejemplo crea una presentación y agrega un gráfico de columnas agrupadas con datos predeterminados a la primera diapositiva. Dividir los desplazamientos y dimensiones deseados de la leyenda entre el ancho y alto del gráfico los convierte en valores relativos: la leyenda se desplaza 50 puntos desde la esquina superior izquierda del gráfico y tiene un tamaño de 100 por 100 puntos.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Expresar la posición y el tamaño de la leyenda en relación con el gráfico.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Establecer el tamaño de fuente de una leyenda**

Utilice la [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) de la leyenda para acceder a su formato de texto y establezca [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) en puntos.

Este ejemplo crea un gráfico con datos predeterminados y establece el texto de la leyenda a 20 puntos. También desactiva los límites automáticos para el eje vertical y establece su rango de -5 a 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Establecer el tamaño de fuente de una entrada individual de la leyenda**

Utilice la colección [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) de la leyenda para acceder al formato de una entrada específica. Los índices de las entradas empiezan en cero, por lo que el índice `1` se refiere a la segunda entrada.

Este ejemplo crea un gráfico de columnas agrupadas cuyos datos predeterminados incluyen al menos dos series. Formatea la segunda entrada de la leyenda con texto en negrita, cursiva y de 20 puntos en color azul.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Ocultar entradas individuales de la leyenda**

Para excluir una serie auxiliar de la leyenda mientras se mantiene sus datos visibles, establezca [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) en `true` a través de [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Esto oculta solo la entrada de la leyenda seleccionada; no elimina la serie ni sus puntos de datos. Establecer [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) en `false`, en cambio, oculta toda la leyenda.

El ejemplo siguiente crea un gráfico de columnas agrupadas con varias series usando datos predeterminados. Oculta la entrada de la leyenda de la segunda serie (índice `1`) y guarda la presentación. Luego restaura la entrada estableciendo `Hide` en `false` y guarda una segunda copia. Las columnas permanecen visibles en ambos archivos.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Restaurar la misma entrada sin cambiar los datos del gráfico.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

La comparación a continuación muestra el mismo gráfico con todas las entradas visibles y con la segunda entrada oculta. Las columnas de la segunda serie permanecen sin cambios.

![Comparación de un gráfico con todas las entradas de la leyenda visibles y con la Serie 2 oculta de la leyenda; todas las columnas permanecen visibles.](hide-legend-entry.png)

En los gráficos de columnas, barras y líneas, las entradas de la leyenda identifican series. En los gráficos de sectores, identifican puntos de datos individuales (rebanadas), por lo que debe usar [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) en la rebanada seleccionada. La API documenta esta propiedad del punto de datos para los tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` y `BarOfPie`. No asuma que se aplica a los gráficos de rosquilla, que no están incluidos en esa lista.

## **Preguntas frecuentes**

**¿Puedo hacer que el gráfico reserve espacio para la leyenda en lugar de superponerla?**

Sí. Establezca [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) en `false` para reservar espacio para la leyenda en lugar de permitir que se solape con el área de trazado.

**¿Puedo crear etiquetas de leyenda multilínea?**

Sí. Las etiquetas largas pueden ajustarse cuando el ancho disponible es insuficiente. También puede usar caracteres de salto de línea en los nombres de las series para solicitar rupturas de línea.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

Deje sin establecer los colores, rellenos y fuentes de la leyenda para que pueda heredar el formato del tema. El formato explícito sobrescribe los ajustes correspondientes del tema.