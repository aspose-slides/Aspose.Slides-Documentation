---
title: Formato de Gráficos
type: docs
weight: 60
url: /net/chart-formatting/
keywords: "Entidades de gráficos, propiedades de gráficos, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Formatear entidades de gráficos en presentaciones de PowerPoint en C# o .NET"
---

## **Formatear Entidades de Gráfico**
Aspose.Slides para .NET permite a los desarrolladores añadir gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo formatear diferentes entidades de gráficos, incluyendo el eje de categoría y el eje de valores.

Aspose.Slides para .NET proporciona una API simple para gestionar diferentes entidades de gráficos y formatearlas utilizando valores personalizados:

1. Crear una instancia de la clase **Presentation**.
1. Obtener la referencia de una diapositiva por su índice.
1. Añadir un gráfico con datos predeterminados junto con cualquier tipo deseado (en este ejemplo, usaremos ChartType.LineWithMarkers).
1. Acceder al Eje de Valores del gráfico y establecer las siguientes propiedades:
   1. Establecer el **Formato de Línea** para las líneas de cuadrícula mayores del Eje de Valores
   1. Establecer el **Formato de Línea** para las líneas de cuadrícula menores del Eje de Valores
   1. Establecer el **Formato de Número** para el Eje de Valores
   1. Establecer **Unidades Mínimas, Máximas, Mayores y Menores** para el Eje de Valores
   1. Establecer **Propiedades de Texto** para los datos del Eje de Valores
   1. Establecer **Título** para el Eje de Valores
   1. Establecer **Formato de Línea** para el Eje de Valores
1. Acceder al Eje de Categoría del gráfico y establecer las siguientes propiedades:
   1. Establecer el **Formato de Línea** para las líneas de cuadrícula mayores del Eje de Categoría
   1. Establecer el **Formato de Línea** para las líneas de cuadrícula menores del Eje de Categoría
   1. Establecer **Propiedades de Texto** para los datos del Eje de Categoría
   1. Establecer **Título** para el Eje de Categoría
   1. Establecer **Posicionamiento de Etiquetas** para el Eje de Categoría
   1. Establecer **Ángulo de Rotación** para las etiquetas del Eje de Categoría
1. Acceder a la Leyenda del gráfico y establecer las **Propiedades de Texto** para ellas
1. Establecer la muestra de leyendas de gráficos sin superponer el gráfico
1. Acceder al **Eje de Valores Secundarios** del gráfico y establecer las siguientes propiedades:
   1. Habilitar el **Eje de Valores Secundarios**
   1. Establecer **Formato de Línea** para el Eje de Valores Secundarios
   1. Establecer **Formato de Número** para el Eje de Valores Secundarios
   1. Establecer **Unidades Mínimas, Máximas, Mayores y Menores** para el Eje de Valores Secundarios
1. Ahora trazar la primera serie de gráficos en el Eje de Valores Secundarios
1. Establecer el color de relleno de la pared trasera del gráfico
1. Establecer el color de relleno del área de trazado del gráfico
1. Escribir la presentación modificada en un archivo PPTX

```c#
// Instanciando la presentación
Presentation pres = new Presentation();

// Accediendo a la primera diapositiva
ISlide slide = pres.Slides[0];

// Añadiendo el gráfico de muestra
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Estableciendo el Título del Gráfico
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Gráfico de Muestra";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Estableciendo el formato de las líneas de cuadrícula mayores para el eje de valores
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Estableciendo el formato de las líneas de cuadrícula menores para el eje de valores
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Estableciendo el formato de número del eje de valores
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Estableciendo los valores máximos y mínimos del gráfico
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Estableciendo las Propiedades de Texto para el Eje de Valores
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; 
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Estableciendo el título del eje de valores
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Eje Primario";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Estableciendo el formato de línea del eje de valores : Ahora obsoleto
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Estableciendo el formato de las líneas de cuadrícula mayores para el eje de categoría
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Estableciendo el formato de las líneas de cuadrícula menores para el eje de categoría
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Estableciendo las Propiedades de Texto para el Eje de Categoría
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; 
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Estableciendo el Título de la Categoría
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Categoría de Muestra";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Estableciendo la posición de las etiquetas del eje de categoría
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Estableciendo el ángulo de rotación de las etiquetas del eje de categoría
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Estableciendo las Propiedades de Texto para las Leyendas
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; 
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Establecer la muestra de leyendas de gráficos sin superponer el gráfico
chart.Legend.Overlay = true;
            
// Trazando la primera serie en el eje de valores secundarios
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Estableciendo el color de la pared trasera del gráfico
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Estableciendo el color del área de trazado
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Guardar Presentación
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **Establecer Propiedades de Fuente para el Gráfico**
Aspose.Slides para .NET proporciona soporte para establecer las propiedades relacionadas con la fuente para el gráfico. Por favor, siga los pasos a continuación para establecer las propiedades de la fuente para el gráfico.

- Instanciar el objeto de la clase Presentation.
- Agregar el gráfico en la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

A continuación se da un ejemplo de muestra.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **Establecer el Formato de Números**
Aspose.Slides para .NET proporciona una API simple para gestionar el formato de datos del gráfico:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Añadir un gráfico con datos predeterminados junto con cualquier tipo deseado (este ejemplo utiliza **ChartType.ClusteredColumn**).
1. Establecer el formato de número preestablecido de los posibles valores preestablecidos.
1. Recorrer la celda de datos del gráfico en cada serie de gráficos y establecer el formato de número de datos del gráfico.
1. Guardar la presentación.
1. Establecer el formato de número personalizado.
1. Recorrer la celda de datos del gráfico dentro de cada serie de gráficos y establecer un formato de número de gráfico diferente.
1. Guardar la presentación.

```c#
// Instanciando la presentación
Presentation pres = new Presentation();

// Accediendo a la primera diapositiva de la presentación
ISlide slide = pres.Slides[0];

// Añadiendo un gráfico de columnas agrupadas por defecto
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accediendo a la colección de series del gráfico
IChartSeriesCollection series = chart.ChartData.Series;

// Estableciendo el formato de número preestablecido
// Recorrer cada serie de gráficos
foreach (ChartSeries ser in series)
{
    // Recorrer cada celda de datos en la serie
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Estableciendo el formato de número
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Guardando la presentación
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Los posibles valores de formato de número preestablecidos junto con su índice preestablecido que se pueden usar se proporcionan a continuación:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rojo$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rojo$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/aa|
|**15**|d-mmm-aa|
|**16**|d-mmm|
|**17**|mmm-aa|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/aa h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Rojo-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rojo-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Establecer Bordes Redondeados en el Área del Gráfico**
Aspose.Slides para .NET proporciona soporte para establecer el área del gráfico. Las propiedades **IChart.HasRoundedCorners** y **Chart.HasRoundedCorners** han sido añadidas en Aspose.Slides.

1. Instanciar el objeto de clase `Presentation`.
1. Agregar el gráfico en la diapositiva.
1. Establecer el tipo de relleno y el color de relleno del gráfico
1. Establecer la propiedad de esquina redondeada en verdadero.
1. Guardar la presentación modificada.

A continuación se da un ejemplo de muestra.

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