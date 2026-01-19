---
title: Formato de gráficos de presentación en .NET
linktitle: Formato de gráficos
type: docs
weight: 60
url: /es/net/chart-formatting/
keywords:
- formatear gráfico
- formato de gráfico
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
description: "Aprenda a formatear gráficos en Aspose.Slides para .NET y mejore su presentación de PowerPoint con un estilo profesional y atractivo."
---

## **Entidades de formato de gráfico**
Aspose.Slides for .NET permite a los desarrolladores añadir gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo dar formato a diferentes entidades de gráficos, incluidas las categorías y los ejes de valores.

Aspose.Slides for .NET proporciona una API simple para gestionar diferentes entidades de gráficos y darles formato mediante valores personalizados:

1. Cree una instancia de la clase **Presentation**.
1. Obtenga una referencia a la diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados del tipo que desee (en este ejemplo utilizaremos ChartType.LineWithMarkers).
1. Acceda al eje de valores del gráfico y establezca las siguientes propiedades:
   1. Establecer **Line format** para las líneas de cuadrícula mayor del eje de valores.
   1. Establecer **Line format** para las líneas de cuadrícula menor del eje de valores.
   1. Establecer **Number Format** para el eje de valores.
   1. Establecer **Min, Max, Major and Minor units** para el eje de valores.
   1. Establecer **Text Properties** para los datos del eje de valores.
   1. Establecer **Title** para el eje de valores.
   1. Establecer **Line Format** para el eje de valores.
1. Acceda al eje de categorías del gráfico y establezca las siguientes propiedades:
   1. Establecer **Line format** para las líneas de cuadrícula mayor del eje de categorías.
   1. Establecer **Line format** para las líneas de cuadrícula menor del eje de categorías.
   1. Establecer **Text Properties** para los datos del eje de categorías.
   1. Establecer **Title** para el eje de categorías.
   1. Establecer **Label Positioning** para el eje de categorías.
   1. Establecer **Rotation Angle** para las etiquetas del eje de categorías.
1. Acceda a la leyenda del gráfico y establezca las **Text Properties** para ella.
1. Configure la visualización de las leyendas del gráfico sin que se superpongan al gráfico.
1. Acceda al **Secondary Value Axis** del gráfico y establezca las siguientes propiedades:
   1. Habilite el **Value Axis** secundario.
   1. Establecer **Line Format** para el eje de valores secundario.
   1. Establecer **Number Format** para el eje de valores secundario.
   1. Establecer **Min, Max, Major and Minor units** para el eje de valores secundario.
1. Ahora represente la primera serie del gráfico en el eje de valores secundario.
1. Establezca el color de relleno del fondo del gráfico.
1. Establezca el color de relleno del área de trazado del gráfico.
1. Guarde la presentación modificada en un archivo PPTX.
```c#
// Instanciando la presentación// Instanciando la presentación
Presentation pres = new Presentation();

// Accessing the first slide
// Accediendo a la primera diapositiva
ISlide slide = pres.Slides[0];

// Adding the sample chart
// Añadiendo el gráfico de ejemplo
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
// Estableciendo el título del gráfico
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
// Estableciendo el formato de líneas de cuadrícula mayores del eje de valores
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
// Estableciendo el formato de líneas de cuadrícula menores del eje de valores
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
// Estableciendo el formato numérico del eje de valores
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
// Estableciendo los valores máximo y mínimo del gráfico
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
// Estableciendo las propiedades de texto del eje de valores
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
// Estableciendo el título del eje de valores
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Value Axis line format : Now Obselete
// Estableciendo el formato de línea del eje de valores: ahora obsoleto
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
// Estableciendo el formato de líneas de cuadrícula mayores del eje de categoría
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
// Estableciendo el formato de líneas de cuadrícula menores del eje de categoría
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
// Estableciendo las propiedades de texto del eje de categoría
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
// Estableciendo el título de la categoría
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
// Estableciendo la posición de la etiqueta del eje de categoría
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
// Estableciendo el ángulo de rotación de la etiqueta del eje de categoría
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
// Estableciendo las propiedades de texto de la leyenda
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart
// Establecer mostrar leyendas del gráfico sin superponer el gráfico

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// Dibujando la primera serie en el eje de valores secundario
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
// Estableciendo el color de la pared trasera del gráfico
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
// Estableciendo el color del área de trazado
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
// Guardar la presentación
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **Establecer propiedades de fuente para un gráfico**
Aspose.Slides for .NET ofrece soporte para establecer las propiedades relacionadas con la fuente del gráfico. Siga los pasos a continuación para establecer las propiedades de fuente del gráfico.

- Instanciar un objeto de la clase Presentation.
- Añadir un gráfico en la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

A continuación se muestra un ejemplo de muestra.
```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **Establecer el formato numérico**
Aspose.Slides for .NET proporciona una API simple para gestionar el formato de datos del gráfico:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga una referencia a la diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados del tipo que desee (este ejemplo utiliza **ChartType.ClusteredColumn**).
1. Establezca el formato numérico predefinido a partir de los valores predefinidos posibles.
1. Recorra la celda de datos del gráfico en cada serie y establezca el formato numérico de los datos del gráfico.
1. Guarde la presentación.
1. Establezca el formato numérico personalizado.
1. Recorra la celda de datos del gráfico dentro de cada serie y establezca un formato numérico de datos diferente.
1. Guarde la presentación.
```c#
// Instanciar la presentación// Instanciar la presentación
Presentation pres = new Presentation();

// Acceder a la primera diapositiva de la presentación
ISlide slide = pres.Slides[0];

// Añadiendo un gráfico de columnas agrupadas por defecto
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accediendo a la colección de series del gráfico
IChartSeriesCollection series = chart.ChartData.Series;

// Estableciendo el formato numérico predefinido
// Recorrer cada serie del gráfico
foreach (ChartSeries ser in series)
{
    // Recorrer cada celda de datos en la serie
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Estableciendo el formato numérico
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Guardando la presentación
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Los valores de formato numérico predefinidos posibles, junto con su índice predefinido y que pueden usarse, se presentan a continuación:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Establecer bordes redondeados del área del gráfico**
Aspose.Slides for .NET ofrece soporte para establecer el área del gráfico. Se han añadido las propiedades **IChart.HasRoundedCorners** y **Chart.HasRoundedCorners** en Aspose.Slides.

1. Instanciar un objeto de la clase `Presentation`.
1. Añadir un gráfico en la diapositiva.
1. Establecer el tipo de relleno y el color de relleno del gráfico.
1. Establecer la propiedad de esquina redondeada en True.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo de muestra.
```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el contorno opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo gestionar las etiquetas de datos cuando se solapan?**

Reduzca el tamaño de la fuente, desactive componentes de etiqueta no esenciales (por ejemplo, categorías), ajuste la posición/desplazamiento de la etiqueta, muestre etiquetas solo para los puntos seleccionados si es necesario, o cambie el formato a "valor + leyenda".

**¿Puedo aplicar rellenos de degradado o patrón a las series?**

Sí. Normalmente están disponibles tanto rellenos sólidos como de degradado/patrón. En la práctica, utilice los degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.