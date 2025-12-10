---
title: Administrar llamadas en gráficos de presentación en .NET
linktitle: Llamada
type: docs
url: /es/net/callout/
keywords:
- llamada de gráfico
- uso de llamada
- etiqueta de datos
- formato de etiqueta
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cree y diseñe llamadas en Aspose.Slides para .NET con ejemplos de código C# concisos, compatibles con PPT y PPTX para automatizar flujos de trabajo de presentaciones."
---

## **Uso de llamadas**
Nueva propiedad **ShowLabelAsDataCallout** se ha añadido a la clase **DataLabelFormat** y a la interfaz **IDataLabelFormat**, lo que determina si la etiqueta de datos del gráfico especificado se mostrará como llamada de datos o como etiqueta de datos. En el ejemplo que se muestra a continuación, hemos configurado las llamadas.
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;
    presentation.Save("DisplayChartLabels_out.pptx", SaveFormat.Pptx);
}
```


## **Establecer una llamada para un gráfico de dona**
Aspose.Slides for .NET brinda soporte para establecer la forma de llamada de etiqueta de datos de la serie en un gráfico de dona. A continuación se muestra un ejemplo.
```c#
Presentation pres = new Presentation("testc.pptx");
ISlide slide = pres.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 10, 10, 500, 500, false);
IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = false;
int seriesIndex = 0;
while (seriesIndex < 15)
{
	IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.Type);
	series.Explosion = 0;
	series.ParentSeriesGroup.DoughnutHoleSize = (byte)20;
	series.ParentSeriesGroup.FirstSliceAngle = 351;
	seriesIndex++;
}
int categoryIndex = 0;
while (categoryIndex < 15)
{
	chart.ChartData.Categories.Add(workBook.GetCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
	int i = 0;
	while (i < chart.ChartData.Series.Count)
	{
		IChartSeries iCS = chart.ChartData.Series[i];
		IChartDataPoint dataPoint = iCS.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(0, categoryIndex + 1, i + 1, 1));
		dataPoint.Format.Fill.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
		dataPoint.Format.Line.Width = 1;
		dataPoint.Format.Line.Style = LineStyle.Single;
		dataPoint.Format.Line.DashStyle = LineDashStyle.Solid;
		if (i == chart.ChartData.Series.Count - 1)
		{
			IDataLabel lbl = dataPoint.Label;
			lbl.TextFormat.TextBlockFormat.AutofitType = TextAutofitType.Shape;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
			lbl.DataLabelFormat.TextFormat.PortionFormat.LatinFont = new FontData("DINPro-Bold");
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontHeight = 12;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.LightGray;
			lbl.DataLabelFormat.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
			lbl.DataLabelFormat.ShowValue = false;
			lbl.DataLabelFormat.ShowCategoryName = true;
			lbl.DataLabelFormat.ShowSeriesName = false;
			//lbl.DataLabelFormat.ShowLabelAsDataCallout = true;
			lbl.DataLabelFormat.ShowLeaderLines = true;
			lbl.DataLabelFormat.ShowLabelAsDataCallout = false;
			chart.ValidateChartLayout();
			lbl.AsILayoutable.X = (float)lbl.AsILayoutable.X + (float)0.5;
			lbl.AsILayoutable.Y = (float)lbl.AsILayoutable.Y + (float)0.5;
		}
		i++;
	}
	categoryIndex++;
}
pres.Save("chart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Se conservan las llamadas al convertir una presentación a PDF, HTML5, SVG o imágenes?**

Sí. Las llamadas forman parte del renderizado del gráfico, por lo que cuando exportas a [PDF](/slides/es/net/convert-powerpoint-to-pdf/), [HTML5](/slides/es/net/export-to-html5/), [SVG](/slides/es/net/render-a-slide-as-an-svg-image/) o [imágenes raster](/slides/es/net/convert-powerpoint-to-png/), se conservan junto con el formato de la diapositiva.

**¿Funcionan las fuentes personalizadas en las llamadas y se puede preservar su apariencia al exportar?**

Sí. Aspose.Slides admite [incrustar fuentes](/slides/es/net/embedded-font/) en la presentación y controla la incrustación de fuentes durante exportaciones como [PDF](/slides/es/net/convert-powerpoint-to-pdf/), garantizando que las llamadas tengan el mismo aspecto en diferentes sistemas.