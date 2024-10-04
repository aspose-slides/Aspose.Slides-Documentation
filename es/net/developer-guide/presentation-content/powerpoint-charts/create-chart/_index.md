---
title: Crear o Actualizar Gráficos de Presentaciones de PowerPoint en C# o .NET
linktitle: Crear o Actualizar Gráfico
type: docs
weight: 10
url: /net/create-chart/
keywords: "Crear gráfico, gráfico disperso, gráfico de pastel, gráfico de mapa de árbol, gráfico de acciones, gráfico de caja y bigote, gráfico de histogramas, gráfico de embudo, gráfico de sol, gráfico multicategoría, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Crear gráfico en presentación de PowerPoint en C# o .NET"
---

## **Crear Gráfico**
Los gráficos ayudan a las personas a visualizar datos rápidamente y obtener información, que puede no ser obvia de inmediato en una tabla o hoja de cálculo.

**¿Por qué Crear Gráficos?**

Usando gráficos, puedes

* agregar, condensar o resumir grandes cantidades de datos en una sola diapositiva de una presentación
* exponer patrones y tendencias en los datos
* deducir la dirección y el momento de los datos a lo largo del tiempo o con respecto a una unidad de medida específica
* identificar valores atípicos, aberraciones, desviaciones, errores, datos sin sentido, etc.
* comunicar o presentar datos complejos

En PowerPoint, puedes crear gráficos a través de la función de insertar, que proporciona plantillas utilizadas para diseñar muchos tipos de gráficos. Usando Aspose.Slides, puedes crear gráficos regulares (basados en tipos de gráficos populares) y gráficos personalizados.

{{% alert color="primary" %}}

Para permitirte crear gráficos, Aspose.Slides proporciona la enumeración [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) en el espacio de nombres [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). Los valores de esta enumeración corresponden a diferentes tipos de gráficos.

{{% /alert %}}

### **Creando Gráficos Normales**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con algunos datos y especifica tu tipo de gráfico preferido.
1. Agrega un título para el gráfico.
1. Accede a la hoja de trabajo de datos del gráfico.
1. Limpia todas las series y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega algunos nuevos datos de gráfico para las series del gráfico.
1. Agrega un color de relleno para las series del gráfico.
1. Agrega etiquetas para las series del gráfico.
1. Escribe la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo crear un gráfico normal:

```c#
// Instancia la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();

// Accede a la primera diapositiva
ISlide sld = pres.Slides[0];

// Agrega un gráfico con sus datos predeterminados
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

// Establece el título del gráfico
chart.ChartTitle.AddTextFrameForOverriding("Título de Muestra");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Establece la primera serie para mostrar valores
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// Establece el índice para la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

// Obtiene la hoja de trabajo de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Elimina las series y categorías generadas por defecto
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

// Agrega nuevas series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

// Agrega nuevas categorías
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Categoría 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Categoría 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Categoría 3"));

// Toma la primera serie del gráfico
IChartSeries series = chart.ChartData.Series[0];

// Población de datos de la serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// Establece el color de relleno para la serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Toma la segunda serie del gráfico
series = chart.ChartData.Series[1];

// Población de datos de la serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Establece el color de relleno para la serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

// Establece la primera etiqueta para mostrar el nombre de la categoría
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

// Establece la serie para mostrar el valor para la tercera etiqueta
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

// Guarda el archivo PPTX en disco
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **Creando Gráficos Dispersos**
Los gráficos dispersos (también conocidos como gráficos dispersos o gráficos x-y) se utilizan a menudo para verificar patrones o demostrar correlaciones entre dos variables.

Es posible que desees utilizar un gráfico disperso cuando

* tengas datos numéricos emparejados
* tengas 2 variables que se emparejan bien juntas
* quieras determinar si 2 variables están relacionadas
* tengas una variable independiente que tiene múltiples valores para una variable dependiente

Este código C# te muestra cómo crear un gráfico disperso con una serie diferente de marcadores:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// Crea el gráfico predeterminado
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// Obtiene el índice de la hoja de datos del gráfico predeterminado
int defaultWorksheetIndex = 0;

// Obtiene la hoja de trabajo de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Elimina las series de demostración
chart.ChartData.Series.Clear();

// Agrega nuevas series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Serie 2"), chart.Type);

// Toma la primera serie del gráfico
IChartSeries series = chart.ChartData.Series[0];

// Agrega un nuevo punto (1:3) a la serie
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// Agrega un nuevo punto (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// Cambia el tipo de serie
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// Cambia el marcador de la serie del gráfico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// Toma la segunda serie del gráfico
series = chart.ChartData.Series[1];

// Agrega un nuevo punto (5:2) a la serie del gráfico
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// Agrega un nuevo punto (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// Agrega un nuevo punto (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// Agrega un nuevo punto (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// Cambia el marcador de la serie del gráfico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

// Guarda el archivo PPTX en disco
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **Creando Gráficos de Pastel**

Los gráficos de pastel se utilizan mejor para mostrar la relación parte-todo en los datos, especialmente cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si tus datos contienen muchas partes o etiquetas, es posible que desees considerar el uso de un gráfico de barras en su lugar.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.Pie`).
1. Accede a los datos del gráfico IChartDataWorkbook.
1. Limpia la serie y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series del gráfico.
1. Agrega nuevos puntos para gráficos y añade colores personalizados para los sectores del gráfico de pastel.
1. Establece etiquetas para las series.
1. Establece líneas de líder para las etiquetas de las series.
1. Establece el ángulo de rotación para las diapositivas de gráficos de pastel.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo crear un gráfico de pastel:

```c#
// Instancia una clase Presentation que representa un archivo PPTX
Presentation presentation = new Presentation();

// Accede a la primera diapositiva
ISlide slides = presentation.Slides[0];

// Agrega un gráfico con sus datos predeterminados
IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Establece el Título del gráfico
chart.ChartTitle.AddTextFrameForOverriding("Título de Muestra");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Establece la primera serie para mostrar valores
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// Establece el índice para la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

// Obtiene la hoja de trabajo de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Elimina las series y categorías generadas por defecto
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

// Agrega nuevas categorías
chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "Primer Trimestre"));
chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "Segundo Trimestre"));
chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "Tercer Trimestre"));

// Agrega nuevas series
IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Serie 1"), chart.Type);

// Población de datos de la serie
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// No funciona en la nueva versión
// Agregando nuevos puntos y estableciendo color de sector
// series.IsColorVaried = true;
chart.ChartData.SeriesGroups[0].IsColorVaried = true;

IChartDataPoint point = series.DataPoints[0];
point.Format.Fill.FillType = FillType.Solid;
point.Format.Fill.SolidFillColor.Color = Color.Cyan;
// Establece el borde del Sector
point.Format.Line.FillFormat.FillType = FillType.Solid;
point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
point.Format.Line.Width = 3.0;
point.Format.Line.Style = LineStyle.ThinThick;
point.Format.Line.DashStyle = LineDashStyle.DashDot;

IChartDataPoint point1 = series.DataPoints[1];
point1.Format.Fill.FillType = FillType.Solid;
point1.Format.Fill.SolidFillColor.Color = Color.Brown;

// Establece el borde del Sector
point1.Format.Line.FillFormat.FillType = FillType.Solid;
point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
point1.Format.Line.Width = 3.0;
point1.Format.Line.Style = LineStyle.Single;
point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

IChartDataPoint point2 = series.DataPoints[2];
point2.Format.Fill.FillType = FillType.Solid;
point2.Format.Fill.SolidFillColor.Color = Color.Coral;

// Establece el borde del Sector
point2.Format.Line.FillFormat.FillType = FillType.Solid;
point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
point2.Format.Line.Width = 2.0;
point2.Format.Line.Style = LineStyle.ThinThin;
point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

// Crea etiquetas personalizadas para cada una de las categorías para la nueva serie
IDataLabel lbl1 = series.DataPoints[0].Label;

// lbl.ShowCategoryName = true;
lbl1.DataLabelFormat.ShowValue = true;

IDataLabel lbl2 = series.DataPoints[1].Label;
lbl2.DataLabelFormat.ShowValue = true;
lbl2.DataLabelFormat.ShowLegendKey = true;
lbl2.DataLabelFormat.ShowPercentage = true;

IDataLabel lbl3 = series.DataPoints[2].Label;
lbl3.DataLabelFormat.ShowSeriesName = true;
lbl3.DataLabelFormat.ShowPercentage = true;

// Establece que las series muestren líneas de líder para el gráfico
series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

// Establece el ángulo de rotación para los sectores del gráfico de pastel
chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

// Guarda el archivo PPTX en disco
presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
```

### **Creando Gráficos de Líneas**

Los gráficos de líneas (también conocidos como gráficos de línea) se utilizan mejor en situaciones donde quieres demostrar cambios en el valor a lo largo del tiempo. Usando un gráfico de líneas, puedes comparar muchos datos a la vez, seguir cambios y tendencias a lo largo del tiempo, resaltar anomalías en las series de datos, etc.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.Line`).
1. Accede a los datos del gráfico IChartDataWorkbook.
1. Limpia la serie y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series del gráfico.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo crear un gráfico de líneas:

```c#
using (Presentation pres = new Presentation())
{
    IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);
    
    pres.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Por defecto, los puntos en un gráfico de líneas están conectados por líneas continuas rectas. Si deseas que los puntos sean conectados por guiones en su lugar, puedes especificar tu tipo de guion preferido de esta manera:

```c#
IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);

foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

### **Creando Gráficos de Mapa de Árbol**

Los gráficos de mapa de árbol se utilizan mejor para datos de ventas cuando quieres mostrar el tamaño relativo de las categorías de datos y (al mismo tiempo) atraer rápidamente la atención a elementos que son grandes contribuyentes a cada categoría.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.TreeMap`).
1. Accede a los datos del gráfico IChartDataWorkbook.
1. Limpia la serie y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series del gráfico.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo crear un gráfico de mapa de árbol:

```c#
using (Presentation presentation = new Presentation())
{
	IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	// Rama 1
	IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Hoja1"));
	leaf.GroupingLevels.SetGroupingItem(1, "Tallo1");
	leaf.GroupingLevels.SetGroupingItem(2, "Rama1");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Hoja2"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Hoja3"));
	leaf.GroupingLevels.SetGroupingItem(1, "Tallo2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Hoja4"));


	// Rama 2
	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Hoja5"));
	leaf.GroupingLevels.SetGroupingItem(1, "Tallo3");
	leaf.GroupingLevels.SetGroupingItem(2, "Rama2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Hoja6"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Hoja7"));
	leaf.GroupingLevels.SetGroupingItem(1, "Tallo4");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Hoja8"));

	IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
	series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 5));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 3));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 6));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 3));

	series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

	presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

### **Creando Gráficos de Acciones**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.OpenHighLowClose).
1. Accede a los datos del gráfico IChartDataWorkbook.
1. Limpia la serie y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series del gráfico.
1. Especifica el formato de HiLowLines.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# utilizado para crear un gráfico de acciones:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);
    
	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "A"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "B"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "C"));

	chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "Abrir"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 2, "Alto"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 3, "Bajo"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 4, "Cerrar"), chart.Type);

	IChartSeries series = chart.ChartData.Series[0];

	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 1, 72));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 1, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 1, 38));

	series = chart.ChartData.Series[1];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 2, 172));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 2, 57));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 2, 57));

	series = chart.ChartData.Series[2];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 3, 13));

	series = chart.ChartData.Series[3];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 4, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 4, 38));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 4, 50));

	chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
	chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

	foreach (IChartSeries ser in chart.ChartData.Series)
	{
		ser.Format.Line.FillFormat.FillType = FillType.NoFill;
	}

	pres.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

### **Creando Gráficos de Caja y Bigote**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.BoxAndWhisker).
1. Accede a los datos del gráfico IChartDataWorkbook.
1. Limpia la serie y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series del gráfico.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo crear un gráfico de caja y bigote:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Categoría 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Categoría 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Categoría 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Categoría 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Categoría 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Categoría 1"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

		series.QuartileMethod = QuartileMethodType.Exclusive;
		series.ShowMeanLine = true;
		series.ShowMeanMarkers = true;
		series.ShowInnerPoints = true;
		series.ShowOutlierPoints = true;

		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B1", 15));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B2", 41));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B3", 16));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B4", 10));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B5", 23));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B6", 16));

		pres.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
	}
}
```

### **Creando Gráficos de Embudo**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.Funnel).
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo crear un gráfico de embudo:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Categoría 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Categoría 2"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Categoría 3"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Categoría 4"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Categoría 5"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Categoría 6"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B1", 50));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B2", 100));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B3", 200));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B4", 300));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B5", 400));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B6", 500));

		pres.Save("Funnel.pptx", SaveFormat.Pptx);
	}
}
```

### **Creando Gráficos de Sol**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.Sunburst`).
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo crear un gráfico de sol:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		// Rama 1
		IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Hoja1"));
		leaf.GroupingLevels.SetGroupingItem(1, "Tallo1");
		leaf.GroupingLevels.SetGroupingItem(2, "Rama1");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Hoja2"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Hoja3"));
		leaf.GroupingLevels.SetGroupingItem(1, "Tallo2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Hoja4"));

		// Rama 2
		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Hoja5"));
		leaf.GroupingLevels.SetGroupingItem(1, "Tallo3");
		leaf.GroupingLevels.SetGroupingItem(2, "Rama2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Hoja6"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Hoja7"));
		leaf.GroupingLevels.SetGroupingItem(1, "Tallo4");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Hoja8"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
		series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D1", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D2", 5));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D3", 3));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D4", 6));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D5", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D6", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D7", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D8", 3));

		pres.Save("Sunburst.pptx", SaveFormat.Pptx);
	}
}
```

### **Creando Gráficos de Histogramas**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con algunos datos y especifica tu tipo de gráfico preferido (`ChartType.Histogram` en este caso).
1. Accede a los datos del gráfico `IChartDataWorkbook`.
1. Limpia la serie y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo crear un gráfico de histogramas:

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Histogram, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A1", 15));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A2", -41));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A3", 16));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A4", 10));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A5", -23));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A6", 16));

		chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

		pres.Save("Histogram.pptx", SaveFormat.Pptx);
	}
}
```

### **Creando Gráficos de Radar**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con algunos datos y especifica tu tipo de gráfico preferido (`ChartType.Radar` en este caso).
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo crear un gráfico de radar:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 400, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

### **Creando Gráficos Multicategoría**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.ClusteredColumn).
1. Accede a los datos del gráfico IChartDataWorkbook.
1. Limpia la serie y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series del gráfico.
1. Escribe la presentación modificada en un archivo PPTX.

Este código C# te muestra cómo crear un gráfico multicategoría:

```c#
Presentation pres = new Presentation();
ISlide slide = pres.Slides[0];

IChart ch = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
ch.ChartData.Series.Clear();
ch.ChartData.Categories.Clear();

IChartDataWorkbook fact = ch.ChartData.ChartDataWorkbook;
fact.Clear(0);
int defaultWorksheetIndex = 0;

IChartCategory category = ch.ChartData.Categories.Add(fact.GetCell(0, "c2", "A"));
category.GroupingLevels.SetGroupingItem(1, "Grupo1");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c3", "B"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c4", "C"));
category.GroupingLevels.SetGroupingItem(1, "Grupo2");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c5", "D"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c6", "E"));
category.GroupingLevels.SetGroupingItem(1, "Grupo3");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c7", "F"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c8", "G"));
category.GroupingLevels.SetGroupingItem(1, "Grupo4");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c9", "H"));

// Agrega las Series
IChartSeries series = ch.ChartData.Series.Add(fact.GetCell(0, "D1", "Serie 1"),
    ChartType.ClusteredColumn);

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D2", 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D3", 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D4", 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D5", 40));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D6", 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D7", 60));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D8", 70));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D9", 80));
// Guarda presentación con gráfico
pres.Save("AsposeChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **Creando Gráficos de Mapa**

Un gráfico de mapa es una visualización de un área que contiene datos. Los gráficos de mapa se usan mejor para comparar datos o valores a través de regiones geográficas.

Este código C# te muestra cómo crear un gráfico de mapa:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Map, 50, 50, 500, 400);
    pres.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

### **Creando Gráficos de Combinación**

Un gráfico de combinación (o gráfico combo) es un gráfico que combina dos o más gráficos en un solo gráfico. Tal gráfico te permite resaltar, comparar o revisar diferencias entre dos (o más) conjuntos de datos. De esta manera, ves la relación (si la hay) entre los conjuntos de datos.

![combination-chart-ppt](combination-chart-ppt.png)

Este código C# te muestra cómo crear un gráfico de combinación en PowerPoint:

```c#
private static void CreateComboChart()
{
    using (Presentation pres = new Presentation())
    {
        IChart chart = CreateChart(pres.Slides[0]);
        AddFirstSeriesToChart(chart);
        AddSecondSeriesToChart(chart);
        pres.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChart(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Serie 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Serie 2"), chart.Type);
    
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Categoría 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Categoría 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Categoría 3"));

    IChartSeries series = chart.ChartData.Series[0];

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));
    
    series = chart.ChartData.Series[1];
    
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    return chart;
}

private static void AddFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Serie 3"), ChartType.ScatterWithSmoothLines);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 0, 1, 3),
        workbook.GetCell(worksheetIndex, 0, 2, 5));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 10),
        workbook.GetCell(worksheetIndex, 1, 4, 13));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 3, 20),
        workbook.GetCell(worksheetIndex, 2, 4, 15));

    series.PlotOnSecondAxis = true;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 5, "Serie 4"),
        ChartType.ScatterWithStraightLinesAndMarkers);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 5),
        workbook.GetCell(worksheetIndex, 1, 4, 2));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 5, 10),
        workbook.GetCell(worksheetIndex, 1, 6, 7));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 5, 15),
        workbook.GetCell(worksheetIndex, 2, 6, 12));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 3, 5, 12),
        workbook.GetCell(worksheetIndex, 3, 6, 9));
    
    series.PlotOnSecondAxis = true;
}
```

## **Actualizando Gráficos**

1. Instancia una clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que representa la presentación que contiene el gráfico.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Recorre todas las formas para encontrar el gráfico deseado.
4. Accede a la hoja de datos del gráfico.
5. Modifica los datos de la serie del gráfico cambiando los valores de la serie.
6. Agrega una nueva serie y puebla los datos en ella.
7. Escribe la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo actualizar un gráfico:

```c#
// Instancia una clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation("ExistingChart.pptx");

// Accede a la primera diapositiva
ISlide sld = pres.Slides[0];

// Agrega un gráfico con datos predeterminados
IChart chart = (IChart)sld.Shapes[0];

// Establece el índice para la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

// Obtiene la hoja de trabajo de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Cambia el nombre de la categoría del gráfico
fact.GetCell(defaultWorksheetIndex, 1, 0, "Categoría Modificada 1");
fact.GetCell(defaultWorksheetIndex, 2, 0, "Categoría Modificada 2");

// Toma la primera serie del gráfico
IChartSeries series = chart.ChartData.Series[0];

// Actualiza los datos de la serie
fact.GetCell(defaultWorksheetIndex, 0, 1, "Nuevo_Serie1");// Modificando el nombre de la serie
series.DataPoints[0].Value.Data = 90;
series.DataPoints[1].Value.Data = 123;
series.DataPoints[2].Value.Data = 44;

// Toma la segunda serie del gráfico
series = chart.ChartData.Series[1];

// Ahora actualizando los datos de la serie
fact.GetCell(defaultWorksheetIndex, 0, 2, "Nuevo_Serie2");// Modificando el nombre de la serie
series.DataPoints[0].Value.Data = 23;
series.DataPoints[1].Value.Data = 67;
series.DataPoints[2].Value.Data = 99;

// Ahora, Agregando una nueva serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 3, "Serie 3"), chart.Type);

// Toma la tercera serie del gráfico
series = chart.ChartData.Series[2];

// Ahora pueblando los datos de la serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 3, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 30));

chart.Type = ChartType.ClusteredCylinder;

// Guarda presentación con gráfico
pres.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
```

## **Estableciendo Rango de Datos para Gráficos**

1. Instancia una clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que representa la presentación que contiene el gráfico.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Recorre todas las formas para encontrar el gráfico deseado.
4. Accede a los datos del gráfico y establece el rango.
5. Guarda la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo establecer el rango de datos para un gráfico:

```c#
// Instancia una clase Presentation que representa un archivo PPTX
Presentation presentation = new Presentation("ExistingChart.pptx");

// Accede a la primera diapositiva y agrega un gráfico con datos predeterminados
ISlide slide = presentation.Slides[0];
IChart chart = (IChart)slide.Shapes[0];
chart.ChartData.SetRange("Sheet1!A1:B4");
presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
```

## **Usando Marcadores Predeterminados en Gráficos**
Cuando utilizas un marcador predeterminado en gráficos, cada serie del gráfico obtiene automáticamente diferentes símbolos de marcador predeterminados.

Este código C# te muestra cómo establecer automáticamente un marcador de serie de gráfico:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
    chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Serie 1"), chart.Type);
    IChartSeries series = chart.ChartData.Series[0];

    chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 1, 24));
    chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 1, 23));
    chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 1, -10));
    chart.ChartData.Categories.Add(fact.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 1, null));

    chart.ChartData.Series.Add(fact.GetCell(0, 0, 2, "Serie 2"), chart.Type);
    // Toma la segunda serie del gráfico
    IChartSeries series2 = chart.ChartData.Series[1];

    // Población de datos de la serie
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    pres.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```