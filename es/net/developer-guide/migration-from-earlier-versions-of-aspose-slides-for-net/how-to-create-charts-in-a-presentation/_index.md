---
title: Cómo crear gráficos en presentaciones en .NET
linktitle: Crear gráfico
type: docs
weight: 30
url: /es/net/how-to-create-charts-in-a-presentation/
keywords:
- migración
- crear gráfico
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprende cómo crear gráficos en presentaciones PowerPoint PPT, PPTX y ODP en .NET con Aspose.Slides usando tanto las API de gráficos heredadas como las modernas."
---

{{% alert color="primary" %}} 

Una nueva [Aspose.Slides for .NET API](/slides/es/net/) ha sido lanzada y ahora este producto único soporta la capacidad de generar documentos PowerPoint desde cero y editar los existentes.

{{% /alert %}} 
## **Compatibilidad con código heredado**
Para utilizar el código heredado desarrollado con versiones de Aspose.Slides para .NET anteriores a la 13.x, necesita realizar algunos cambios menores en su código y éste funcionará como antes. Todas las clases que estaban presentes en el antiguo Aspose.Slides para .NET bajo los espacios de nombres Aspose.Slide y Aspose.Slides.Pptx ahora están fusionadas en un único espacio de nombres Aspose.Slides. Por favor, examine el siguiente fragmento de código simple para crear un gráfico normal desde cero en una presentación usando la API heredada de Aspose.Slides y siga los pasos que describen cómo migrar a la nueva API fusionada.
## **Enfoque heredado de Aspose.Slides para .NET**
```c#
//Instanciar la clase PresentationEx que representa un archivo PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Acceder a la primera diapositiva
	SlideEx sld = pres.Slides[0];

	//Agregar gráfico con datos predeterminados
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Establecer el título del gráfico
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Configurar la primera serie para mostrar valores
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Establecer el índice de la hoja de datos del gráfico 
	int defaultWorksheetIndex = 0;

	//Obtener la hoja de datos del gráfico
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Eliminar series y categorías generadas por defecto
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Agregar nuevas series
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//Agregar nuevas categorías
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//Obtener la primera serie del gráfico
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Ahora poblando los datos de la serie
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Establecer el color de relleno para la serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Obtener la segunda serie del gráfico
	series = chart.ChartData.Series[1];

	//Ahora poblando los datos de la serie
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Establecer el color de relleno para la serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Crear etiquetas personalizadas para cada una de las categorías de la nueva serie

	//La primera etiqueta mostrará el nombre de la categoría
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Mostrar el nombre de la serie para la segunda etiqueta
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Mostrar el valor para la tercera etiqueta
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Mostrar el valor y texto personalizado
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Guardar la presentación con el gráfico
	pres.Write(@"D:\AsposeChart.pptx");
}
```




## **Enfoque de Aspose.Slides para .NET 13.x**
``` csharp
//Instanciar la clase Presentation que representa un archivo PPTX//Instanciar la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation();

//Acceder a la primera diapositiva
ISlide sld = pres.Slides[0];

// Agregar gráfico con datos predeterminados
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Establecer el título del gráfico
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Establecer la primera serie para mostrar valores
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Establecer el índice de la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

//Obtener la hoja de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Eliminar series y categorías generadas por defecto
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Agregar nuevas series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Agregar nuevas categorías
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Obtener la primera serie del gráfico
IChartSeries series = chart.ChartData.Series[0];

//Ahora poblando los datos de la serie

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Establecer el color de relleno para la serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Obtener la segunda serie del gráfico
series = chart.ChartData.Series[1];

//Ahora poblando los datos de la serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Establecer el color de relleno para la serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Crear etiquetas personalizadas para cada una de las categorías de la nueva serie

//La primera etiqueta mostrará el nombre de la categoría
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Mostrar el valor para la tercera etiqueta
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Guardar la presentación con el gráfico
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


Por favor, examine el siguiente fragmento de código simple para crear un gráfico de dispersión desde cero en una presentación usando la API heredada de Aspose.Slides y cómo lograrlo con la nueva API fusionada.

## **Enfoque heredado de Aspose.Slides para .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Crear el gráfico predeterminado
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Obteniendo el índice de la hoja de datos del gráfico predeterminada
    int defaultWorksheetIndex = 0;

    //Accediendo a la hoja de datos del gráfico
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Eliminar series de demostración
    chart.ChartData.Series.Clear();

    //Agregar nuevas series
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Obtener la primera serie del gráfico
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Agregar nuevo punto (1:3) allí.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Agregar nuevo punto (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Editar el tipo de serie
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Cambiar el marcador de la serie del gráfico
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Obtener la segunda serie del gráfico
    series = chart.ChartData.Series[1];

    //Agregar nuevo punto (5:2) allí.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Agregar nuevo punto (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Agregar nuevo punto (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Agregar nuevo punto (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Cambiar el marcador de la serie del gráfico
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```



## **Enfoque de Aspose.Slides para .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Crear el gráfico predeterminado
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Obtener el índice de la hoja de datos del gráfico predeterminada
int defaultWorksheetIndex = 0;

//Accediendo a la hoja de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Eliminar series de demostración
chart.ChartData.Series.Clear();

//Agregar nuevas series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Obtener la primera serie del gráfico
IChartSeries series = chart.ChartData.Series[0];

//Agregar nuevo punto (1:3) allí.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Agregar nuevo punto (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Editar el tipo de serie
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Cambiar el marcador de la serie del gráfico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Obtener la segunda serie del gráfico
series = chart.ChartData.Series[1];

//Agregar nuevo punto (5:2) allí.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Agregar nuevo punto (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Agregar nuevo punto (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Agregar nuevo punto (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Cambiar el marcador de la serie del gráfico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
