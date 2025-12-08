---
title: Gráfico de pastel
type: docs
url: /es/net/pie-chart/
keywords: "Gráfico de pastel, opciones de trazado, colores de porciones, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Opciones de trazado y colores de porciones del gráfico de pastel en una presentación de PowerPoint en C# o .NET"
---

## **Opciones de segunda trama para gráficos Pie of Pie y Bar of Pie**
Aspose.Slides for .NET ahora admite opciones de segunda trama para los gráficos Pie of Pie o Bar of Pie. En este tema, veremos con un ejemplo cómo especificar estas opciones usando Aspose.Slides. Para especificar las propiedades, siga los pasos a continuación:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Añadir un gráfico a la diapositiva.
1. Especificar las opciones de segunda trama del gráfico.
1. Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos configurado diferentes propiedades del gráfico Pie of Pie.
```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

// Añadir gráfico en la diapositiva
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Establecer diferentes propiedades
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Guardar la presentación en disco
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```





## **Establecer colores automáticos de las secciones del gráfico circular**
Aspose.Slides for .NET proporciona una API simple para establecer colores automáticos de las secciones del gráfico circular. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase Presentation.
2. Acceder a la primera diapositiva.
3. Añadir un gráfico con datos predeterminados.
4. Establecer el título del gráfico.
5. Configurar la primera serie para mostrar valores.
6. Establecer el índice de la hoja de datos del gráfico.
7. Obtener la hoja de trabajo de datos del gráfico.
8. Eliminar las series y categorías generadas por defecto.
9. Añadir nuevas categorías.
10. Añadir una nueva serie.

Guardar la presentación modificada en un archivo PPTX.
```c#
 // Instanciar la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
	// Instanciar la clase Presentation que representa un archivo PPTX
	Presentation presentation = new Presentation();

	// Acceder a la primera diapositiva
	ISlide slides = presentation.Slides[0];

	// Añadir gráfico con datos predeterminados
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Configurar el título del gráfico
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Establecer la primera serie para mostrar valores
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Configurar el índice de la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtener la hoja de trabajo de datos del gráfico
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Eliminar series y categorías generadas por defecto
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Añadir nuevas categorías
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Añadir nueva serie
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Ahora poblando los datos de la serie
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) una trama secundaria para los gráficos circulares, incluidas los tipos 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (por ejemplo PNG) sin necesidad de toda la presentación.