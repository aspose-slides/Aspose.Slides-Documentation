---
title: Annotation
type: docs
url: /fr/net/callout/
keywords: "Annotation de graphique, étiquette de données de graphique, C#, Csharp, Aspose.Slides for .NET"
description: "Annotations de graphiques PowerPoint et étiquettes de données en C# ou .NET"
---

## **Utilisation des callouts**
Une nouvelle propriété **ShowLabelAsDataCallout** a été ajoutée à la classe **DataLabelFormat** et à l'interface **IDataLabelFormat**, qui détermine si l'étiquette de données du graphique spécifié sera affichée comme annotation de données ou comme étiquette de données. Dans l'exemple ci-dessous, nous avons défini les annotations.
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


## **Définir l'annotation pour le graphique en anneau**
Aspose.Slides for .NET offre la prise en charge de la définition de la forme d'annotation d'étiquette de données de série pour un graphique en anneau. Un exemple d'échantillon est présenté ci-dessous.
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

**Les annotations sont‑elles conservées lors de la conversion d’une présentation en PDF, HTML5, SVG ou images ?**

Oui. Les annotations font partie du rendu du graphique, de sorte que lorsque vous exportez vers [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [HTML5](/slides/fr/net/export-to-html5/), [SVG](/slides/fr/net/render-a-slide-as-an-svg-image/) ou [images matricielles](/slides/fr/net/convert-powerpoint-to-png/), elles sont conservées avec le formatage de la diapositive.

**Les polices personnalisées fonctionnent‑elles dans les annotations, et leur apparence peut‑elle être conservée lors de l’exportation ?**

Oui. Aspose.Slides prend en charge [l’intégration de polices](/slides/fr/net/embedded-font/) dans la présentation et contrôle l’intégration des polices lors des exportations telles que [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), garantissant que les annotations conservent le même aspect sur différents systèmes.