---
title: Formatear gráficos de presentaciones en .NET
linktitle: Formato de gráficos
type: docs
weight: 60
url: /es/net/chart-formatting/
keywords:
- formatear gráfico
- formato de gráfico
- entidad del gráfico
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
description: "Aprenda el formato de gráficos en Aspose.Slides para .NET y mejore su presentación de PowerPoint con ejes personalizados, fuentes, formatos numéricos y bordes de gráfico redondeados."
---
## **Visión general**

Este artículo explica cómo formatear gráficos en presentaciones de PowerPoint utilizando Aspose.Slides. Muestra cómo personalizar los elementos clave del gráfico, como ejes, líneas de cuadrícula, títulos, leyendas, el área de trazado y los rellenos de paredes, para mejorar la apariencia y la legibilidad de los datos del gráfico.

También demuestra cómo establecer propiedades de fuente para el texto del gráfico, aplicar formatos numéricos predefinidos a los datos del gráfico y habilitar esquinas redondeadas para el área del gráfico. En conjunto, estos ejemplos muestran cómo controlar tanto el estilo visual como la presentación de los datos de los gráficos en una presentación.

Para rellenos y contornos separados en intervalos alcistas y bajistas, consulte el [ejemplo de gráfico bursátil](/slides/es/net/create-chart/#create-stock-charts).

## **Formato de entidades del gráfico**

Utilice [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) para formatear los títulos de los gráficos, los ejes, las líneas de cuadrícula, las leyendas y el área de trazado. Este ejemplo crea un gráfico de líneas con marcadores y datos predeterminados, y luego aplica estilos de texto y de línea diferentes a sus ejes de valores y de categorías. Los tamaños de fuente y los grosores de línea se especifican en puntos; las etiquetas de categoría se rotan 45 grados.

El eje de valores utiliza [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) de forma independiente de las celdas de origen. Su escala va de -2 a 15, con intervalos mayores de 2 y menores de 0,5. El ejemplo también combina el formato de porcentaje con [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) establecido en miles, por lo que debe adaptar estos ajustes al significado y magnitud de sus datos. La leyenda permanece fuera del área de trazado porque [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) está desactivado. Los rellenos de la pared trasera y del suelo se configuran mediante [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) y [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), pero estas superficies solo son visibles en gráficos 3D.

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

Establezca el tamaño de fuente predeterminado para el texto del gráfico mediante [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). El ejemplo crea un gráfico de columnas agrupadas con una fuente de 20 puntos y habilita las etiquetas de valor para la primera serie a través de [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Los elementos de texto con sus propias configuraciones de fuente explícitas pueden sobrescribir el valor predeterminado del gráfico.

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

## **Reutilizar el formato del marco de texto para la leyenda del gráfico**

Para que una leyenda coincida con el encabezado de una diapositiva, establezca la fuente en el [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) del primer párrafo. Llame a [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) en el [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) de la leyenda. Este lee la configuración del marco de texto, el formato del primer párrafo y las propiedades de fuente predeterminadas de ese párrafo. El formato aplicado directamente a porciones individuales o a párrafos posteriores permanece local al origen.

El ejemplo utiliza un encabezado en Calibri negrita de 26 puntos en color azul marino como plantilla. Después de dar estilo a la leyenda, emplea [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) para aplicar el mismo formato a una leyenda separada.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

En la presentación guardada, la leyenda y la descripción coinciden con el encabezado en tamaño, grosor y color. La leyenda sigue mostrando los nombres de las series, y la descripción conserva su propio texto. Si una porción de la descripción ya tiene un tamaño de fuente explícito, ese tamaño prevalece sobre el predeterminado del párrafo copiado.

| Antes de copiar | Después de copiar |
| --- | --- |
| ![Gráfico de ventas trimestrales con etiquetas de leyenda negras normales y una descripción negra](legend-formatting-before.png) | ![El mismo gráfico con etiquetas de leyenda más grandes, en negrita y azul marino, y una descripción coincidente](legend-formatting.png) |

## **Establecer el formato numérico**

Utilice [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) para aplicar un formato numérico predefinido a las celdas del libro de trabajo del gráfico. Este ejemplo crea un gráfico de columnas agrupadas con datos predeterminados respaldados por celdas y aplica el índice de formato 10 (`0.00%`) a cada celda de valor de la serie. Esto modifica la forma en que los valores se muestran en el libro sin cambiar los números subyacentes; por ejemplo, 0.25 se muestra como 25.00 %. Los formatos de los ejes y de las etiquetas de datos pueden configurarse por separado.

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
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0,00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

La tabla siguiente enumera los índices de formatos numéricos predefinidos con formatos de Excel representativos para la configuración regional en inglés (Estados Unidos). Las cadenas de formato exactas y su visualización pueden variar según la aplicación y la configuración regional, especialmente para monedas y fechas. Algunos formatos de Excel también difieren de los valores predeterminados del estándar OOXML, como se describe en [Notas de implementación de formato numérico de Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

Habilite [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) para redondear las esquinas del área del gráfico. El ejemplo crea un gráfico de columnas agrupadas y utiliza [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) para dar a su contorno un color gris sólido y un estilo de línea simple antes de guardar la presentación.

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

Un gráfico puede contener formas personalizadas, como una anotación de texto que explique el estado de un informe. Acceda a estas formas mediante [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), también enumeradas bajo [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) en la referencia de la API de gráficos. Su colección [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) contiene las formas propias del gráfico.

Un cuadro de texto ordinario colocado sobre un gráfico pertenece a la diapositiva, aunque parezca parte del gráfico. Recorrer [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) encuentra el gráfico y las formas ordinarias de la diapositiva, pero no enumera las formas individuales dentro del gráfico. Los títulos de los gráficos y las etiquetas de datos son elementos de gráfico separados, no anotaciones personalizadas en esta colección.

Descargue [chart-annotations.pptx](chart-annotations.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene un gráfico con una anotación no agrupada que dice "Preliminary results", una línea propia del gráfico y un cuadro de texto ordinario de la diapositiva que dice "Slide overlay". El ejemplo encuentra el primer gráfico en esa diapositiva y cambia la anotación a "Final results" cuando el informe está listo para publicarse. Verifica que la colección no esté vacía y solo edita un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) con un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) no nulo y el texto esperado.

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

La línea y el cuadro de texto de la diapositiva permanecen sin cambios. Las siguientes imágenes muestran la entrada y el resultado guardado y reabierto:

| Antes de editar | Después de editar |
| --- | --- |
| ![Anotación del gráfico que dice Resultados preliminares](chart-annotations-before.png) | ![Anotación del gráfico que dice Resultados finales](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
El ejemplo inspecciona solo las formas propias del gráfico a nivel superior. Si una anotación está dentro de un [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), inspeccione también la colección [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) de ese grupo. Repita esto recursivamente para grupos anidados, aplicando las mismas comprobaciones de texto a sus formas hijas. Un grupo en sí es un contenedor; no lo trate como un cuadro de texto.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el contorno opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo gestionar las etiquetas de datos cuando se solapan?**

Reduzca el tamaño de la fuente, desactive los componentes de etiqueta no esenciales (por ejemplo, categorías), ajuste la posición de la etiqueta, muestre etiquetas solo para los puntos seleccionados si es necesario, o cambie el formato a "valor + leyenda".

**¿Puedo aplicar rellenos de degradado o patrón a las series?**

Sí. Las series admiten rellenos sólidos, degradados y de patrón. En la práctica, utilice degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.