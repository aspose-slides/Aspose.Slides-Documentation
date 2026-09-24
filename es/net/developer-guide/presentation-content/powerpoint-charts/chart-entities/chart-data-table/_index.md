---
title: Personalizar tablas de datos de gráficos en presentaciones en .NET
linktitle: Tabla de datos
type: docs
url: /es/net/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Personaliza las fuentes, los bordes y las claves de leyenda de la tabla de datos de gráficos en presentaciones de PowerPoint usando Aspose.Slides para .NET y C#."
---
## **Visión general**

Aspose.Slides for .NET le permite mostrar la tabla de datos de un gráfico y personalizar el formato de texto, los bordes y las claves de leyenda. Este artículo explica cómo habilitar la tabla, formatear su texto, controlar cada tipo de borde y mostrar u ocultar las claves de leyenda. Los ejemplos guardan los gráficos configurados en archivos PPTX.

## **Establecer propiedades de fuente**

Para mostrar la tabla de datos de un gráfico, establezca [HasDataTable](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chart/hasdatatable/) en `true`. Use [ChartDataTable](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chart/chartdatatable/) para acceder a la tabla y configurar su formato de texto.

1. Cargue la presentación utilizando la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
1. Añada un gráfico de columnas agrupadas a la primera diapositiva.
1. Habilite la tabla de datos del gráfico.
1. Active el texto en negrita con [FontBold](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/fontbold/) y establezca [FontHeight](https://reference.aspose.com/slides/es/net/aspose.slides/baseportionformat/fontheight/) en `20` para un texto de 20 puntos.
1. Guarde la presentación modificada.

El siguiente ejemplo requiere `test.pptx` en el directorio de trabajo con al menos una diapositiva. Añade un gráfico con datos predeterminados en la posición (50, 50), con un ancho de 600 puntos y una altura de 400 puntos. El `output.pptx` guardado contiene el gráfico con su tabla de datos habilitada y los ajustes de fuente especificados aplicados.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Personalizar bordes de la tabla de datos**

Habilite la tabla con [IChart.HasDataTable](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/hasdatatable/) y acceda a ella a través de [IChart.ChartDataTable](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/chartdatatable/). Puede controlar tres tipos de bordes de forma independiente:

- [HasBorderHorizontal](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatatable/hasborderhorizontal/) controla los bordes horizontales de las celdas.
- [HasBorderVertical](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatatable/hasbordervertical/) controla los bordes verticales de las celdas.
- [HasBorderOutline](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatatable/hasborderoutline/) controla el borde exterior de la tabla.

Establezca cada propiedad en `true` para mostrar sus bordes o en `false` para ocultarlos. El siguiente ejemplo crea un gráfico de columnas agrupadas con datos predeterminados, muestra los bordes horizontales y el borde exterior, y oculta los bordes verticales. No requiere archivo de entrada. La posición y el tamaño del gráfico se especifican en puntos.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

La comparación a continuación utiliza los mismos datos del gráfico y la configuración de claves de leyenda en los cuatro casos. Partiendo de todos los bordes habilitados, cada variante restante desactiva solo una propiedad de borde. La variante inferior izquierda coincide con la configuración de bordes del ejemplo.

![Tablas de datos del gráfico con todos los bordes habilitados, sin bordes horizontales, sin bordes verticales y sin borde exterior](data-table-borders.png)

## **Mostrar u ocultar claves de leyenda**

Las claves de leyenda son pequeños marcadores de color junto a los nombres de las series en la tabla de datos. Ayudan a los lectores a asociar cada fila de la tabla con una serie del gráfico. Establezca [ShowLegendKey](https://reference.aspose.com/slides/es/net/aspose.slides.charts/idatatable/showlegendkey/) en `true` para mostrar estos marcadores o en `false` para ocultarlos.

La leyenda separada del gráfico se controla mediante [IChart.HasLegend](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/haslegend/). Estas configuraciones son independientes: ocultar la leyenda separada no oculta las claves dentro de la tabla de datos, y ocultar las claves de la tabla no oculta la leyenda separada.

El siguiente ejemplo crea un gráfico con datos predeterminados, habilita su tabla de datos y muestra las claves de leyenda dentro de ella mientras oculta la leyenda separada. Todos los bordes de la tabla están explícitamente habilitados. No se requiere una presentación de entrada. Para ocultar solo las claves de la tabla, cambie `dataTable.ShowLegendKey` a `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

La comparación a continuación muestra la misma tabla con las claves de leyenda habilitadas y deshabilitadas. Todos los bordes permanecen habilitados, y la leyenda separada del gráfico está oculta en ambos casos.

![Tablas de datos del gráfico con claves de leyenda mostradas a la izquierda y ocultas a la derecha](data-table-legend-keys.png)

## **FAQ**

**¿Puedo mostrar claves de leyenda en la tabla de datos de un gráfico?**

Sí. Establezca [ShowLegendKey](https://reference.aspose.com/slides/es/net/aspose.slides.charts/datatable/showlegendkey/) en `true` para mostrar las claves de leyenda o en `false` para ocultarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico y su tabla de datos mostrada como parte de la diapositiva al exportar a [PDF](/slides/es/net/convert-powerpoint-to-pdf/), [HTML](/slides/es/net/convert-powerpoint-to-html/), o [imágenes](/slides/es/net/convert-powerpoint-to-png/).

**¿Puedo trabajar con tablas de datos en gráficos cargados desde una plantilla?**

Sí. Para un gráfico cargado desde una presentación o plantilla existente, utilice [HasDataTable](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chart/hasdatatable/) para comprobar o cambiar si su tabla de datos se muestra.

**¿Cómo puedo encontrar gráficos que tengan la tabla de datos habilitada?**

Recorra las formas en cada diapositiva, identifique los gráficos y compruebe su propiedad [HasDataTable](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chart/hasdatatable/). Un valor de `true` indica que la tabla de datos está habilitada.