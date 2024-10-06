---
title: Appel
type: docs
url: /net/callout/
keywords: "Appel de graphique, étiquette de données de graphique, C#, Csharp, Aspose.Slides pour .NET"
description: "Appels de graphique PowerPoint et étiquettes de données en C# ou .NET"
---

## **Utilisation des Appels**
Une nouvelle propriété **ShowLabelAsDataCallout** a été ajoutée à la classe **DataLabelFormat** et à l'interface **IDataLabelFormat**, qui détermine si l'étiquette de données spécifiée du graphique sera affichée comme un appel de données ou comme une étiquette de données. Dans l'exemple ci-dessous, nous avons défini les Appels.

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



## **Définir un Appel pour un Graphique Anneau**
Aspose.Slides pour .NET fournit un support pour définir la forme de l'étiquette de données de la série pour un graphique en anneau. Un exemple d'échantillon est donné ci-dessous.

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
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, seriesIndex + 1, "SÉRIE " + seriesIndex), chart.Type);
    series.Explosion = 0;
    series.ParentSeriesGroup.DoughnutHoleSize = (byte)20;
    series.ParentSeriesGroup.FirstSliceAngle = 351;
    seriesIndex++;
}
int categoryIndex = 0;
while (categoryIndex < 15)
{
    chart.ChartData.Categories.Add(workBook.GetCell(0, categoryIndex + 1, 0, "CATÉGORIE " + categoryIndex));
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