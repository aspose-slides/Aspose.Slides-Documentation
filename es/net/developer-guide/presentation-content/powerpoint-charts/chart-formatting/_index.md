---
title: Formatear gráficos de presentación en .NET
linktitle: Formato de gráficos
type: docs
weight: 60
url: /es/net/chart-formatting/
keywords:
- formatear gráfico
- formateo de gráfico
- entidad de gráfico
- propiedades del gráfico
- configuración del gráfico
- opciones del gráfico
- propiedades de fuente
- borde redondeado
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda el formateo de gráficos en Aspose.Slides para .NET y mejore su presentación de PowerPoint con ejes personalizados, fuentes, formatos numéricos y bordes redondeados de los gráficos."
---
## **Visión general**

Este artículo explica cómo formatear gráficos en presentaciones de PowerPoint usando Aspose.Slides. Muestra cómo personalizar elementos clave del gráfico, como ejes, líneas de cuadrícula, títulos, leyendas, el área de trazado y los rellenos de paredes, para mejorar la apariencia y la legibilidad de los datos del gráfico.

También demuestra cómo establecer propiedades de fuente para el texto del gráfico, aplicar formatos numéricos predefinidos a los datos del gráfico y habilitar esquinas redondeadas para el área del gráfico. En conjunto, estos ejemplos muestran cómo controlar tanto el estilo visual como la presentación de datos de los gráficos en una presentación.

## **Formatear entidades del gráfico**

Utilice [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) para formatear los títulos del gráfico, los ejes, las líneas de cuadrícula, las leyendas y el área de trazado. Este ejemplo crea un gráfico de líneas con marcadores y datos predeterminados, y luego aplica estilos de texto y línea separados a sus ejes de valores y de categorías. Los tamaños de fuente y los grosores de línea se especifican en puntos; las etiquetas de categoría se rotan 45 grados.

El eje de valores utiliza [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) de forma independiente de las celdas de origen. Su escala va de -2 a 15, con intervalos principales de 2 y intervalos menores de 0.5. El ejemplo también combina el formato de porcentaje con [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) configurado en miles, por lo que debe adaptar estos ajustes al significado y la magnitud de sus datos. La leyenda permanece fuera del área de trazado porque [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) está desactivado. Los rellenos de la pared trasera y del suelo se configuran mediante [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) y [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), pero estas superficies solo son visibles en gráficos 3D.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Establecer propiedades de fuente para un gráfico**

Establezca el tamaño de fuente predeterminado para el texto del gráfico mediante [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). El ejemplo crea un gráfico de columnas agrupadas con una fuente de 20 puntos y habilita las etiquetas de valor para la primera serie mediante [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Los elementos de texto con sus propias configuraciones de fuente explícitas pueden sobrescribir el valor predeterminado del gráfico.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Establecer el formato numérico**

Utilice [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) para aplicar un formato numérico incorporado a las celdas del libro de trabajo del gráfico. Este ejemplo crea un gráfico de columnas agrupadas con datos predeterminados respaldados por celdas y aplica el índice de formato 10 (`0.00%`) a cada celda de valor de la serie. Esto cambia la forma en que los valores se muestran en el libro de trabajo sin modificar los números subyacentes; por ejemplo, 0.25 se muestra como 25.00 %. Los formatos de eje y de etiquetas de datos pueden configurarse por separado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

La tabla siguiente enumera los índices de formatos numéricos incorporados con formatos representativos de Excel para la configuración regional Inglés (Estados Unidos). Las cadenas de formato exactas y su visualización pueden variar según la aplicación y la configuración regional, particularmente para moneda y fechas. Algunos formatos de Excel también difieren de los valores predeterminados en la norma OOXML, como se describe en [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Índice | Formato |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Establecer bordes redondeados del área del gráfico**

Active [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) para redondear las esquinas del área del gráfico. El ejemplo crea un gráfico de columnas agrupadas y utiliza [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) para dar a su contorno un color gris sólido y un estilo de línea única antes de guardar la presentación.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Editar anotaciones de gráficos existentes**

Un gráfico puede contener formas personalizadas, como una anotación de texto que explique el estado de un informe. Acceda a estas formas a través de [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), también listadas bajo [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) en la referencia de la API de Chart. Su colección [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) contiene las formas pertenecientes al gráfico.

Un cuadro de texto ordinario colocado sobre un gráfico pertenece a la diapositiva, incluso si parece parte del gráfico. Recorrer [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) encuentra el gráfico y las formas normales de la diapositiva, pero no enumera las formas individuales dentro del gráfico. Los títulos del gráfico y las etiquetas de datos son elementos de gráfico separados, no anotaciones personalizadas en esta colección.

Descargue [chart-annotations.pptx](chart-annotations.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene un gráfico con una anotación desagruparada que dice "Preliminary results", una línea perteneciente al gráfico y un cuadro de texto normal de la diapositiva que dice "Slide overlay". El ejemplo encuentra el primer gráfico en esa diapositiva y cambia la anotación a "Final results" cuando el informe está listo para publicarse. Verifica si la colección está vacía y solo edita un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) con un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) no nulo y el texto esperado.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

La línea y el cuadro de texto de la diapositiva permanecen sin cambios. Las imágenes siguientes muestran la entrada y el resultado guardado y vuelto a abrir:

| Antes de editar | Después de editar |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
El ejemplo inspecciona solo las formas de nivel superior pertenecientes al gráfico. Si una anotación está dentro de un [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), inspeccione también la colección [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) de ese grupo. Repita esto recursivamente para los grupos anidados, aplicando las mismas comprobaciones de texto a sus formas hijas. Un grupo en sí mismo es un contenedor; no lo trate como un cuadro de texto.
{{% /alert %}}

## **FAQ**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el borde opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo gestionar las etiquetas de datos cuando se superponen?**

Reduzca el tamaño de la fuente, desactive componentes de etiqueta no esenciales (por ejemplo, categorías), ajuste la posición de la etiqueta, muestre etiquetas solo para los puntos seleccionados si es necesario, o cambie el formato a "valor + leyenda".

**¿Puedo aplicar rellenos de degradado o patrón a las series?**

Sí. Las series admiten rellenos sólidos, degradados y de patrón. En la práctica, use degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.