---
title: Gestire le callout nei grafici delle presentazioni in .NET
linktitle: Callout
type: docs
url: /it/net/callout/
keywords:
- callout grafico
- uso di callout
- etichetta dati
- formato etichetta
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea e formatta le callout in Aspose.Slides per .NET con esempi di codice C# concisi, compatibili con PPT e PPTX per automatizzare i flussi di lavoro delle presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le callout per le etichette dei dati dei grafici in Aspose.Slides. Mostra come utilizzare la proprietà `ShowLabelAsDataCallout` per visualizzare le etichette come callout, come configurare le impostazioni delle etichette correlate alle callout per un grafico a ciambella e osserva che le callout e il loro aspetto vengono conservati quando le presentazioni vengono esportate in PDF, HTML5, SVG e formati di immagine raster.

## **Utilizzo delle Callout**
È stata aggiunta una nuova proprietà **ShowLabelAsDataCallout** alla classe **DataLabelFormat** e all'interfaccia **IDataLabelFormat**, che determina se l'etichetta dei dati del grafico specificato verrà visualizzata come callout o come etichetta dei dati. Nell'esempio riportato di seguito, abbiamo impostato le Callout.

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



## **Impostare una Callout per un Grafico a Ciambella**
Aspose.Slides per .NET fornisce il supporto per impostare la forma della callout delle etichette dei dati di una serie per un grafico a ciambella. Di seguito è riportato un esempio.

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

## **FAQ**

**Le callout vengono conservate durante la conversione di una presentazione in PDF, HTML5, SVG o immagini?**

Sì. Le callout fanno parte del rendering del grafico, quindi quando si esporta in [PDF](/slides/it/net/convert-powerpoint-to-pdf/), [HTML5](/slides/it/net/export-to-html5/), [SVG](/slides/it/net/render-a-slide-as-an-svg-image/) o [immagini raster](/slides/it/net/convert-powerpoint-to-png/), vengono conservate insieme alla formattazione della diapositiva.

**I font personalizzati funzionano nelle callout e il loro aspetto può essere conservato durante l'esportazione?**

Sì. Aspose.Slides supporta [l'inserimento di font](/slides/it/net/embedded-font/) nella presentazione e controlla l'incorporamento dei font durante esportazioni come [PDF](/slides/it/net/convert-powerpoint-to-pdf/), garantendo che le callout appaiano identiche su sistemi diversi.