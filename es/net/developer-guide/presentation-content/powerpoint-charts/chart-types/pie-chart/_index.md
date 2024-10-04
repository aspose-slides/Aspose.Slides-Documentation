---
title: Gráfico de Pastel
type: docs
url: /net/pie-chart/
keywords: "Gráfico de pastel, opciones de gráfico, colores de rebanadas, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Opciones de gráfico de pastel y colores de rebanadas en presentación de PowerPoint en C# o .NET"
---

## **Segundas Opciones de Gráfico para Gráfico de Pastel de Pastel y Gráfico de Pastel de Barra**
Aspose.Slides for .NET ahora admite segundas opciones de gráfico para gráfico de pastel de pastel o gráfico de pastel de barra. En este tema, veremos con un ejemplo cómo especificar estas opciones usando Aspose.Slides. Para especificar las propiedades, siga los pasos a continuación:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Agregar gráfico en la diapositiva.
1. Especificar las segundas opciones del gráfico.
1. Escribir la presentación en disco.

En el ejemplo dado a continuación, hemos configurado diferentes propiedades del gráfico de pastel de pastel.

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Agregar gráfico en la diapositiva
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Configurar diferentes propiedades
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Escribir la presentación en disco
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **Establecer Colores de Rebanadas Automáticos para el Gráfico de Pastel**
Aspose.Slides for .NET proporciona una API simple para establecer colores de rebanadas automáticos para gráficos de pastel. El código de muestra aplica la configuración de las propiedades mencionadas anteriormente.

1. Crear una instancia de la clase Presentation.
1. Acceder a la primera diapositiva.
1. Agregar gráfico con datos predeterminados.
1. Establecer el Título del gráfico.
1. Establecer la primera serie para Mostrar Valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de datos del gráfico.
1. Eliminar series y categorías generadas por defecto.
1. Agregar nuevas categorías.
1. Agregar nuevas series.

Escribir la presentación modificada en un archivo PPTX.

```c#
// Instanciar la clase Presentation que representa el archivo PPTX
using (Presentation presentation = new Presentation())
{
	// Instanciar la clase Presentation que representa el archivo PPTX
	Presentation presentation = new Presentation();

	// Acceder a la primera diapositiva
	ISlide slides = presentation.Slides[0];

	// Agregar gráfico con datos predeterminados
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Establecer el Título del gráfico
	chart.ChartTitle.AddTextFrameForOverriding("Título de Ejemplo");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Establecer la primera serie para Mostrar Valores
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Establecer el índice de la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtener la hoja de datos del gráfico
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Eliminar series y categorías generadas por defecto
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Agregar nuevas categorías
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "Primer Trimestre"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "Segundo Trimestre"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "Tercer Trimestre"));

	// Agregar nuevas series
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Serie 1"), chart.Type);

	// Ahora rellenar los datos de la serie
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```