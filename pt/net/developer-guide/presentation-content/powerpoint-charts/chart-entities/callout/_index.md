---
title: Gerenciar Chamadas em Gráficos de Apresentação no .NET
linktitle: Chamada
type: docs
url: /pt/net/callout/
keywords:
- chamada de gráfico
- usar chamada
- rótulo de dados
- formato de rótulo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie e estilize chamadas no Aspose.Slides para .NET com exemplos concisos de código C#, compatíveis com PPT e PPTX para automatizar fluxos de trabalho de apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com chamadas para rótulos de dados de gráficos no Aspose.Slides. Ele mostra como usar a propriedade `ShowLabelAsDataCallout` para exibir rótulos como chamadas, como configurar as definições de rótulo relacionadas a chamadas para um gráfico de rosquinha e observa que as chamadas e sua aparência são preservadas quando as apresentações são exportadas para PDF, HTML5, SVG e formatos de imagem raster.

## **Usando chamadas**
A nova propriedade **ShowLabelAsDataCallout** foi adicionada à classe **DataLabelFormat** e à interface **IDataLabelFormat**, que determina se o rótulo de dados de um gráfico especificado será exibido como chamada de dados ou como rótulo de dados. No exemplo abaixo, definimos as chamadas.

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

## **Definir uma chamada para um gráfico de rosquinha**
O Aspose.Slides para .NET oferece suporte para definir a forma de chamada de rótulo de dados de série para um gráfico de rosquinha. A seguir, um exemplo de amostra. 

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

## **Perguntas frequentes**

**As chamadas são preservadas ao converter uma apresentação para PDF, HTML5, SVG ou imagens?**

Sim. As chamadas fazem parte da renderização do gráfico, portanto, ao exportar para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/), [HTML5](/slides/pt/net/export-to-html5/), [SVG](/slides/pt/net/render-a-slide-as-an-svg-image/) ou [imagens raster](/slides/pt/net/convert-powerpoint-to-png/), elas são preservadas juntamente com a formatação do slide.

**Fontes personalizadas funcionam em chamadas e sua aparência pode ser preservada na exportação?**

Sim. O Aspose.Slides oferece suporte à [incorporação de fontes](/slides/pt/net/embedded-font/) na apresentação e controla a incorporação de fontes durante exportações como [PDF](/slides/pt/net/convert-powerpoint-to-pdf/), garantindo que as chamadas mantenham a mesma aparência em diferentes sistemas.