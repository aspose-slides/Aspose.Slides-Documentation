---
title: Cómo crear gráficos en una presentación
type: docs
weight: 30
url: /net/how-to-create-charts-in-a-presentation/
---

{{% alert color="primary" %}} 

Se ha lanzado una nueva [Aspose.Slides para .NET API](/slides/net/) y ahora este único producto admite la capacidad de generar documentos de PowerPoint desde cero y editar los existentes.

{{% /alert %}} 
## **Soporte para código heredado**
Para usar el código heredado desarrollado con Aspose.Slides para .NET versiones anteriores a 13.x, necesitas hacer algunos cambios menores en tu código y funcionará como antes. Todas las clases que estaban presentes en la antigua Aspose.Slides para .NET bajo los espacios de nombres Aspose.Slide y Aspose.Slides.Pptx ahora se han fusionado en un único espacio de nombres Aspose.Slides. Por favor, echa un vistazo al siguiente fragmento de código simple para crear un gráfico normal desde cero en una presentación utilizando la API heredada de Aspose.Slides y sigue los pasos que describen cómo migrar a la nueva API fusionada.
## **Enfoque heredado de Aspose.Slides para .NET**
```c#
//Instanciar la clase PresentationEx que representa el archivo PPTX
using (PresentationEx pres = new PresentationEx())
{
	//Acceder a la primera diapositiva
	SlideEx sld = pres.Slides[0];

	// Agregar gráfico con datos predeterminados
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//Configurando el título del gráfico
	chart.ChartTitle.Text.Text = "Título de muestra";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//Configurar la primera serie para mostrar valores
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//Configurando el índice de la hoja de datos del gráfico 
	int defaultWorksheetIndex = 0;

	//Obteniendo la hoja de datos del gráfico
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//Eliminar series y categorías generadas por defecto
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//Añadir nuevas series
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

	//Añadir nuevas categorías
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Categoría 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Categoría 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Categoría 3"));

	//Tomar la primera serie del gráfico
	ChartSeriesEx series = chart.ChartData.Series[0];

	//Ahora poblamos los datos de la serie
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//Configurando el color de relleno para la serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//Tomar la segunda serie del gráfico
	series = chart.ChartData.Series[1];

	//Ahora poblamos los datos de la serie
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//Configurando el color de relleno para la serie
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//Crear etiquetas personalizadas para cada una de las categorías para nuevas series

	//la primera etiqueta mostrará el nombre de la categoría
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//Mostrar el nombre de la serie para la segunda etiqueta
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//Mostrar valor para la tercera etiqueta
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//Mostrar valor y texto personalizado
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "Mi texto";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//Guardar la presentación con el gráfico
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **Nuevo enfoque de Aspose.Slides para .NET 13.x**
``` csharp
//Instanciar la clase Presentation que representa el archivo PPTX
Presentation pres = new Presentation();

//Acceder a la primera diapositiva
ISlide sld = pres.Slides[0];

// Agregar gráfico con datos predeterminados
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Configurando el título del gráfico
//chart.ChartTitle.TextFrameForOverriding.Text = "Título de muestra";
chart.ChartTitle.AddTextFrameForOverriding("Título de muestra");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Establecer la primera serie para mostrar valores
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Configurando el índice de la hoja de datos del gráfico
int defaultWorksheetIndex = 0;

//Obteniendo la hoja de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Eliminar series y categorías generadas por defecto
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Añadir nuevas series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.Type);

//Añadir nuevas categorías
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Categoría 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Categoría 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Categoría 3"));

//Tomar la primera serie del gráfico
IChartSeries series = chart.ChartData.Series[0];

//Ahora poblamos los datos de la serie

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Configurando el color de relleno para la serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Tomar la segunda serie del gráfico
series = chart.ChartData.Series[1];

//Ahora poblamos los datos de la serie
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Configurando el color de relleno para la serie
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Crear etiquetas personalizadas para cada una de las categorías para nuevas series

//la primera etiqueta mostrará el nombre de la categoría
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Mostrar valor para la tercera etiqueta
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Guardar presentación con gráfico
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Por favor, echa un vistazo al siguiente fragmento de código simple para crear un gráfico disperso desde cero en una presentación utilizando la API heredada de Aspose.Slides y cómo lograrlo con la nueva API fusionada.

## **Enfoque heredado de Aspose.Slides para .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Creando el gráfico predeterminado
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Obteniendo el índice de la hoja de datos del gráfico predeterminado
    int defaultWorksheetIndex = 0;

    //Accediendo a la hoja de datos del gráfico
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Eliminar series de demostración
    chart.ChartData.Series.Clear();

    //Añadir nuevas series
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Serie 2"), chart.Type);

    //Tomar la primera serie del gráfico
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Añadir nuevo punto (1:3) allí.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Añadir nuevo punto (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Editar el tipo de serie
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Cambiar el marcador de la serie del gráfico
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Tomar la segunda serie del gráfico
    series = chart.ChartData.Series[1];

    //Añadir nuevo punto (5:2) allí.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Añadir nuevo punto (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Añadir nuevo punto (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Añadir nuevo punto (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Cambiar el marcador de la serie del gráfico
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **Nuevo enfoque de Aspose.Slides para .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Creando el gráfico predeterminado
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Obteniendo el índice de la hoja de datos del gráfico predeterminado
int defaultWorksheetIndex = 0;

//Accediendo a la hoja de datos del gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Eliminar series de demostración
chart.ChartData.Series.Clear();

//Añadir nuevas series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Serie 2"), chart.Type);

//Tomar la primera serie del gráfico
IChartSeries series = chart.ChartData.Series[0];

//Añadir nuevo punto (1:3) allí.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Añadir nuevo punto (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Editar el tipo de serie
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Cambiar el marcador de la serie del gráfico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyle.Star;

//Tomar la segunda serie del gráfico
series = chart.ChartData.Series[1];

//Añadir nuevo punto (5:2) allí.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Añadir nuevo punto (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Añadir nuevo punto (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Añadir nuevo punto (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Cambiar el marcador de la serie del gráfico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyle.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```