---
title: Personalizar gráficos de pastel en presentaciones en .NET
linktitle: Gráfico de pastel
type: docs
url: /es/net/pie-chart/
keywords:
- gráfico de pastel
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración de gráfico
- opciones de trazado
- color de segmento
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos de pastel en .NET con Aspose.Slides, exportables a PowerPoint, impulsando su narración de datos en segundos."
---

## **Opciones de segunda trama para gráficos Pie of Pie y Bar of Pie**
Aspose.Slides para .NET ahora admite opciones de segunda trama para gráficos Pie of Pie o Bar of Pie. En este tema, veremos con un ejemplo cómo especificar estas opciones usando Aspose.Slides. Para especificar las propiedades, siga los pasos a continuación:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Agregar un gráfico en la diapositiva.
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


## **Establecer colores automáticos de las porciones del gráfico de pastel**
Aspose.Slides para .NET ofrece una API sencilla para establecer colores automáticos en las porciones de los gráficos de pastel. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase Presentation.
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Establecer el título del gráfico.
1. Configurar la primera serie para Mostrar valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de cálculo de datos del gráfico.
1. Eliminar las series y categorías generadas por defecto.
1. Agregar nuevas categorías.
1. Agregar nuevas series.

Guardar la presentación modificada en un archivo PPTX.
```c#
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

	// Establecer la primera serie para Mostrar valores
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Configurar el índice de la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtener la hoja de cálculo de datos del gráfico
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

	// Poblar los datos de la serie
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) una trama secundaria para gráficos de pastel, incluidas las variantes 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como imagen (por ejemplo, PNG)?**

Sí, puede [exportar el gráfico como una imagen](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (como PNG) sin toda la presentación.