---
title: Series de Gráficos
type: docs
url: /net/chart-series/
keywords: "Series de gráficos, color de series, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Series de gráficos en presentaciones de PowerPoint en C# o .NET"
---

Una serie es una fila o columna de números representados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer Superposición de Series de Gráficos**

Con la propiedad [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap), puedes especificar cuánto deben superponerse las barras y columnas en un gráfico 2D (rango: -100 a 100). Esta propiedad se aplica a todas las series del grupo de series principal: esta es una proyección de la propiedad de grupo correspondiente. Por lo tanto, esta propiedad es de solo lectura.

Utiliza la propiedad de lectura/escritura `ParentSeriesGroup.Overlap` para establecer tu valor preferido para `Overlap`.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Añade un gráfico de columnas agrupadas en una diapositiva.
1. Accede a la primera serie del gráfico.
1. Accede al `ParentSeriesGroup` de la serie del gráfico y establece tu valor preferido de superposición para la serie.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo establecer la superposición para una serie de gráficos:

```c#
using (Presentation presentation = new Presentation())
{
    // Añade un gráfico
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.ChartData.Series;
    if (series[0].Overlap == 0)
    {
        // Establece la superposición de la serie
        series[0].ParentSeriesGroup.Overlap = -30;
    }

    // Escribe el archivo de presentación en disco
    presentation.Save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
}
```

## **Cambiar Color de la Serie**
Aspose.Slides para .NET te permite cambiar el color de una serie de esta manera:

1. Crea una instancia de la clase `Presentation`.
1. Añade un gráfico en la diapositiva.
1. Accede a la serie cuyo color deseas cambiar.
1. Establece tu tipo de relleno y color de relleno preferidos.
1. Guarda la presentación modificada.

Este código C# te muestra cómo cambiar el color de una serie:

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[1];
	
	point.Explosion = 30;
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Cambiar Color de la Categoría de la Serie**
Aspose.Slides para .NET te permite cambiar el color de la categoría de una serie de esta manera:

1. Crea una instancia de la clase `Presentation`.
1. Añade un gráfico en la diapositiva.
1. Accede a la categoría de la serie cuyo color deseas cambiar.
1. Establece tu tipo de relleno y color de relleno preferidos.
1. Guarda la presentación modificada.

Este código en C# te muestra cómo cambiar el color de la categoría de una serie:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];
	
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Cambiar Nombre de la Serie**

Por defecto, los nombres de la leyenda para un gráfico son los contenidos de las celdas sobre cada columna o fila de datos.

En nuestro ejemplo (imagen de muestra),

* las columnas son *Serie 1, Serie 2,* y *Serie 3*;
* las filas son *Categoría 1, Categoría 2, Categoría 3,* y *Categoría 4*.

Aspose.Slides para .NET te permite actualizar o cambiar el nombre de una serie en sus datos del gráfico y leyenda.

Este código C# te muestra cómo cambiar el nombre de una serie en los datos de su gráfico `ChartDataWorkbook`:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = "Nuevo nombre";
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

Este código C# te muestra cómo cambiar el nombre de una serie en su leyenda a través de `Series`:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.ChartData.Series[0];
    
    IStringChartValue name = series.Name;
    name.AsCells[0].Value = "Nuevo nombre";   
}
```

## **Establecer Color de Relleno de la Serie de Gráficos**

Aspose.Slides para .NET te permite establecer el color de relleno automático para las series de gráficos dentro de un área de trazado de esta manera:

1. Crea una instancia de la clase `Presentation`.
1. Obtén la referencia de una diapositiva por su índice.
1. Añade un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, utilizamos `ChartType.ClusteredColumn`).
1. Accede a la serie del gráfico y establece el color de relleno a Automático.
1. Guarda la presentación en un archivo PPTX.

Este código C# te muestra cómo establecer el color de relleno automático para una serie de gráficos:

```c#
using (Presentation presentation = new Presentation())
{
    // Crea un gráfico de columnas agrupadas
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Establece el formato de relleno de la serie a automático
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series[i].GetAutomaticSeriesColor();
    }

    // Escribe el archivo de presentación en disco
    presentation.Save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Establecer Colores de Relleno Invertidos de la Serie de Gráficos**
Aspose.Slides te permite establecer el color de relleno invertido para las series de gráficos dentro de un área de trazado de esta manera:

1. Crea una instancia de la clase `Presentation`.
1. Obtén la referencia de una diapositiva por su índice.
1. Añade un gráfico con datos predeterminados basado en tu tipo preferido (en el ejemplo a continuación, utilizamos `ChartType.ClusteredColumn`).
1. Accede a la serie del gráfico y establece el color de relleno a invertir.
1. Guarda la presentación en un archivo PPTX.

Este código C# demuestra la operación:

```c#
Color inverColor = Color.Red;
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Añade nuevas series y categorías
    chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Serie 1"), chart.Type);
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Categoría 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Categoría 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Categoría 3"));

    // Toma la primera serie del gráfico y llena su datos de serie.
    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;
    pres.Save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);               
}
```

## **Establecer Inversiones de la Serie Cuando el Valor es Negativo**
Aspose.Slides te permite establecer inversiones a través de las propiedades `IChartDataPoint.InvertIfNegative` y `ChartDataPoint.InvertIfNegative`. Cuando se establece una inversión utilizando las propiedades, el punto de datos invierte sus colores cuando recibe un valor negativo.

Este código C# demuestra la operación:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
	IChartSeriesCollection series = chart.ChartData.Series;
	chart.ChartData.Series.Clear();

	series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -2));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

	series[0].InvertIfNegative = false;

	series[0].DataPoints[2].InvertIfNegative = true;

	pres.Save("out.pptx", SaveFormat.Pptx);
}
```

## **Limpiar Datos de Puntos de Datos Específicos**
Aspose.Slides para .NET te permite limpiar los datos de `DataPoints` para una serie de gráficos específica de esta manera:

1. Crea una instancia de la clase `Presentation`.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Obtén la referencia de un gráfico a través de su índice.
4. Itera a través de todos los `DataPoints` del gráfico y establece `XValue` y `YValue` a nulo.
5. Limpia todos los `DataPoints` para la serie de gráficos específica.
6. Escribe la presentación modificada en un archivo PPTX.

Este código C# demuestra la operación:

```c#
using (Presentation pres = new Presentation("TestChart.pptx"))
{
	ISlide sl = pres.Slides[0];

	IChart chart = (IChart)sl.Shapes[0];

	foreach (IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
	{
		dataPoint.XValue.AsCell.Value = null;
		dataPoint.YValue.AsCell.Value = null;
	}

	chart.ChartData.Series[0].DataPoints.Clear();

	pres.Save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
}
```

## **Establecer Ancho de Espaciado de la Serie**
Aspose.Slides para .NET te permite establecer el Ancho de Espaciado de una serie a través de la propiedad **`GapWidth`** de la siguiente manera:

1. Crea una instancia de la clase `Presentation`.
2. Accede a la primera diapositiva.
3. Añade un gráfico con datos predeterminados.
4. Accede a cualquier serie de gráficos.
5. Establece la propiedad `GapWidth`.
6. Escribe la presentación modificada en un archivo PPTX.

Este código en C# te muestra cómo establecer el Ancho de Espaciado de una serie:

```c#
// Crea una presentación vacía 
Presentation presentation = new Presentation();

// Accede a la primera diapositiva de la presentación
ISlide slide = presentation.Slides[0];

// Añade un gráfico con datos predeterminados
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 0, 0, 500, 500);

// Establece el índice de la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

// Obtiene la hoja de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Añade series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

// Añade Categorías
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Categoría 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Categoría 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Categoría 3"));

// Toma la segunda serie del gráfico
IChartSeries series = chart.ChartData.Series[1];

// Llena los datos de la serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Establece el valor de GapWidth
series.ParentSeriesGroup.GapWidth = 50;

// Guarda la presentación en disco
presentation.Save("GapWidth_out.pptx", SaveFormat.Pptx);
```