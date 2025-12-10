---
title: Personalizar gráficos circulares en presentaciones en .NET
linktitle: Gráfico circular
type: docs
url: /es/net/pie-chart/
keywords:
- gráfico circular
- administrar gráfico
- personalizar gráfico
- opciones del gráfico
- configuraciones del gráfico
- opciones de trazado
- color de segmento
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos circulares en .NET con Aspose.Slides, exportables a PowerPoint, impulsando su narración de datos en segundos."
---

## **Opciones de segundo trazado para gráficos Pie of Pie y Bar of Pie**
Aspose.Slides for .NET ahora admite las opciones de segundo trazado para los gráficos Pie of Pie o Bar of Pie. En este tema, veremos con un ejemplo cómo especificar estas opciones usando Aspose.Slides. Para especificar las propiedades, siga los pasos a continuación:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Agregar un gráfico en la diapositiva.
1. Especificar las opciones de segundo trazado del gráfico.
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


## **Establecer colores automáticos de las porciones del gráfico circular**
Aspose.Slides for .NET proporciona una API simple para establecer colores automáticos en los gráficos circulares. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase Presentation.
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Establecer el título del gráfico.
1. Configurar la primera serie para Mostrar valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de datos del gráfico.
1. Eliminar las series y categorías generadas por defecto.
1. Agregar nuevas categorías.
1. Agregar nuevas series.

Guardar la presentación modificada en un archivo PPTX.
```c#
// Instanciar la clase Presentation que representa un archivo PPTX
using (Presentation presentation = new Presentation())
{
	// Instanciar la clase Presentation que representa un archivo PPTX
	Presentation presentation = new Presentation();

	// Acceder a la primera diapositiva
	ISlide slides = presentation.Slides[0];

	// Agregar gráfico con datos predeterminados
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Establecer el título del gráfico
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Establecer la primera serie para Mostrar valores
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Establecer el índice de la hoja de datos del gráfico
	int defaultWorksheetIndex = 0;

	// Obtener la hoja de datos del gráfico
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Eliminar series y categorías generadas por defecto
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Agregar nuevas categorías
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Agregar nuevas series
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Ahora poblando datos de la serie
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) un trazado secundario para los gráficos de sectores, incluidos los tipos 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como imagen](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (por ejemplo PNG) sin toda la presentación.