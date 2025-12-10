---
title: Gérer les annotations dans les graphiques de présentation en .NET
linktitle: Annotation
type: docs
url: /fr/net/callout/
keywords:
- annotation de graphique
- utiliser annotation
- étiquette de données
- format d'étiquette
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créez et stylisez les annotations dans Aspose.Slides pour .NET avec des exemples de code C# concis, compatibles avec PPT et PPTX pour automatiser les flux de travail de présentation."
---

## **Utilisation des annotations**
Une nouvelle propriété **ShowLabelAsDataCallout** a été ajoutée à la classe **DataLabelFormat** et à l'interface **IDataLabelFormat**, qui détermine si l'étiquette de données du graphique spécifié sera affichée sous forme d'annotation de données ou d'étiquette de données. Dans l'exemple ci-dessous, nous avons configuré les annotations.
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


## **Définir une annotation pour un graphique en anneau**
Aspose.Slides for .NET fournit la prise en charge de la définition de la forme d'annotation d'étiquette de données de série pour un graphique en anneau. L'exemple d'echantillon ci-dessous est fourni.
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

**Les annotations sont-elles conservees lors de la conversion d’une presentation en PDF, HTML5, SVG ou images?**
Oui. Les annotations font partie du rendu du graphique, ainsi lorsque vous exportez vers [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [HTML5](/slides/fr/net/export-to-html5/), [SVG](/slides/fr/net/render-a-slide-as-an-svg-image/), ou [images matricielles](/slides/fr/net/convert-powerpoint-to-png/), elles sont conservees avec le formatage de la diapositive.

**Les polices personnalisees fonctionnent-elles dans les annotations, et leur apparence peut-elle etre conservee a l’exportation?**
Oui. Aspose.Slides prend en charge [l’integration de polices](/slides/fr/net/embedded-font/) dans la presentation et controle l’integration des polices lors des exportations telles que [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), garantissant que les annotations conservent le meme aspect sur differents systemes.