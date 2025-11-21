---
title: Formato de gráficos
type: docs
weight: 60
url: /es/net/chart-formatting/
keywords: "Entidades de gráfico, propiedades de gráfico, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Formatear entidades de gráfico en presentaciones de PowerPoint en C# o .NET"
---

## **Formatear Entidades del Gráfico**
Aspose.Slides for .NET permite a los desarrolladores agregar gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo formatear diferentes entidades de gráfico, incluidas el eje de categoría y el eje de valores.

Aspose.Slides for .NET proporciona una API sencilla para administrar distintas entidades de gráfico y formatearlas con valores personalizados:

1. Crear una instancia de la clase **Presentation**.
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (en este ejemplo usaremos ChartType.LineWithMarkers).
1. Acceder al Eje de Valores del gráfico y establecer las siguientes propiedades:
   1. Configurar **Line format** para las líneas de cuadrícula mayores del Eje de Valores
   1. Configurar **Line format** para las líneas de cuadrícula menores del Eje de Valores
   1. Configurar **Number Format** para el Eje de Valores
   1. Configurar **Min, Max, Major and Minor units** para el Eje de Valores
   1. Configurar **Text Properties** para los datos del Eje de Valores
   1. Configurar **Title** para el Eje de Valores
   1. Configurar **Line Format** para el Eje de Valores
1. Acceder al Eje de Categoría del gráfico y establecer las siguientes propiedades:
   1. Configurar **Line format** para las líneas de cuadrícula mayores del Eje de Categoría
   1. Configurar **Line format** para las líneas de cuadrícula menores del Eje de Categoría
   1. Configurar **Text Properties** para los datos del Eje de Categoría
   1. Configurar **Title** para el Eje de Categoría
   1. Configurar **Label Positioning** para el Eje de Categoría
   1. Configurar **Rotation Angle** para las etiquetas del Eje de Categoría
1. Acceder a la Leyenda del gráfico y establecer las **Text Properties** correspondientes.
1. Mostrar las Leyendas del gráfico sin que se superpongan al gráfico.
1. Acceder al **Secondary Value Axis** del gráfico y establecer las siguientes propiedades:
   1. Habilitar el **Secondary Value Axis**
   1. Configurar **Line Format** para el Secondary Value Axis
   1. Configurar **Number Format** para el Secondary Value Axis
   1. Configurar **Min, Max, Major and Minor units** para el Secondary Value Axis
1. Ahora trazar la primera serie del gráfico en el Secondary Value Axis.
1. Establecer el color de relleno de la pared posterior del gráfico.
1. Establecer el color de relleno del área de trazado del gráfico.
1. Guardar la presentación modificada en un archivo PPTX.
```c#
// Instanciando la presentación// Instanciando la presentación
Presentation pres = new Presentation();

// Accediendo a la primera diapositiva
ISlide slide = pres.Slides[0];

// Añadiendo el gráfico de ejemplo
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Configurando el título del gráfico
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Configurando el formato de líneas de cuadrícula principales para el eje de valores
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Configurando el formato de líneas de cuadrícula menores para el eje de valores
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Configurando el formato numérico del eje de valores
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Configurando los valores máximo y mínimo del gráfico
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Configurando las propiedades de texto del eje de valores
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Configurando el título del eje de valores
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Configurando el formato de línea del eje de valores : Ahora obsoleto
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Configurando el formato de líneas de cuadrícula principales para el eje de categorías
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Configurando el formato de líneas de cuadrícula menores para el eje de categorías
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Configurando las propiedades de texto del eje de categorías
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Configurando el título del eje de categorías
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Configurando la posición de la etiqueta del eje de categorías
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Configurando el ángulo de rotación de la etiqueta del eje de categorías
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Configurando las propiedades de texto de la leyenda
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Mostrar la leyenda del gráfico sin superponerse al gráfico
chart.Legend.Overlay = true;
            
// Trazando la primera serie en el eje de valores secundario
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Configurando el color de la pared trasera del gráfico
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Configurando el color del área de trazado
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Guardar la presentación
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```




## **Establecer Propiedades de Fuente para el Gráfico**
Aspose.Slides for .NET admite la configuración de propiedades relacionadas con la fuente del gráfico. Siga los pasos a continuación para establecer las propiedades de fuente para el gráfico.

- Instanciar el objeto de la clase Presentation.
- Añadir un gráfico a la diapositiva.
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





## **Establecer Formato de Números**
Aspose.Slides for .NET ofrece una API sencilla para gestionar el formato de datos del gráfico:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Añadir un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo usa **ChartType.ClusteredColumn**).
1. Establecer el formato numérico predefinido a partir de los valores predefinidos posibles.
1. Recorrer cada celda de datos del gráfico en cada serie y establecer el formato numérico de los datos del gráfico.
1. Guardar la presentación.
1. Establecer un formato numérico personalizado.
1. Recorrer cada celda de datos del gráfico en cada serie y establecer un formato numérico diferente para los datos del gráfico.
1. Guardar la presentación.
```c#
// Instanciar la presentación// Instanciar la presentación
Presentation pres = new Presentation();

// Acceder a la primera diapositiva de la presentación
ISlide slide = pres.Slides[0];

// Añadiendo un gráfico de columnas agrupadas por defecto
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accediendo a la colección de series del gráfico
IChartSeriesCollection series = chart.ChartData.Series;

// Configurando el formato numérico predefinido
// Recorrer cada serie del gráfico
foreach (ChartSeries ser in series)
{
    // Recorrer cada celda de datos en la serie
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Configurando el formato numérico
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Guardando la presentación
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Los posibles valores de formato numérico predefinidos, junto con su índice predefinido y que pueden usarse, se presentan a continuación:

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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Establecer Bordes Redondeados en el Área del Gráfico**
Aspose.Slides for .NET permite configurar el área del gráfico. Las propiedades **IChart.HasRoundedCorners** y **Chart.HasRoundedCorners** se han añadido en Aspose.Slides.

1. Instanciar el objeto de la clase `Presentation`.
1. Añadir un gráfico a la diapositiva.
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

**¿Puedo aplicar rellenos semitransparentes a columnas/áreas manteniendo el borde opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo manejar las etiquetas de datos cuando se superponen?**

Reducir el tamaño de la fuente, desactivar componentes de etiqueta no esenciales (por ejemplo, categorías), ajustar el desplazamiento/posición de la etiqueta, mostrar etiquetas solo para los puntos seleccionados si es necesario, o cambiar el formato a “valor + leyenda”.

**¿Puedo aplicar rellenos de degradado o patrón a las series?**

Sí. Normalmente están disponibles tanto los rellenos sólidos como los degradados/patrón. En la práctica, use degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.