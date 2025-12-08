---
title: "Calculs de graphiques"
type: docs
weight: 50
url: /fr/net/chart-calculations/
keywords: "Calculs de graphiques, éléments de graphique, position d'élément, valeurs de graphique C#, Csharp, Aspose.Slides for .NET"
description: "Calculs et valeurs de graphiques PowerPoint en C# ou .NET"
---

## **Calculer les valeurs réelles des éléments du graphique**
Aspose.Slides for .NET fournit une API simple permettant d'obtenir ces propriétés. Cela vous aidera à calculer les valeurs réelles des éléments du graphique. Les valeurs réelles comprennent la position des éléments qui implémentent l'interface IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) ainsi que les valeurs réelles des axes (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Enregistrement de la présentation
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```




## **Calculer la position réelle des éléments parent du graphique**
Aspose.Slides for .NET fournit une API simple permettant d'obtenir ces propriétés. Les propriétés de IActualLayout fournissent des informations sur la position réelle de l'élément parent du graphique. Il est nécessaire d'appeler la méthode IChart.ValidateChartLayout() au préalable pour remplir les propriétés avec les valeurs réelles.
```c#
// Création d'une présentation vide
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```




## **Masquer des informations du graphique**
Ce sujet vous aide à comprendre comment masquer des informations du graphique. Avec Aspose.Slides for .NET, vous pouvez masquer le **Titre, l'Axe vertical, l'Axe horizontal** et les **Lignes de grille** du graphique. L'exemple de code ci‑dessous montre comment utiliser ces propriétés.
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Masquer le titre du graphique
    chart.HasTitle = false;

    ///Masquer l'axe des valeurs
    chart.Axes.VerticalAxis.IsVisible = false;

    //Visibilité de l'axe des catégories
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Masquer la légende
    chart.HasLegend = false;

    //Masquer les lignes de grille majeures
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Définir la couleur de la ligne de la série
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Les classeurs Excel externes peuvent-ils être utilisés comme source de données, et comment cela affecte‑t‑il le recalcul ?**

Oui. Un graphique peut référencer un classeur externe : lorsque vous connectez ou actualisez la source externe, les formules et les valeurs sont prises à partir de ce classeur, et le graphique reflète les mises à jour pendant les opérations d'ouverture/édition. L'API vous permet de [spécifier le classeur externe](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) chemin et de gérer les données liées.

**Puis‑je calculer et afficher des lignes de tendance sans implémenter moi‑même la régression ?**

Oui. Les [lignes de tendance](/slides/fr/net/trend-line/) (linéaires, exponentielles et autres) sont ajoutées et mises à jour par Aspose.Slides ; leurs paramètres sont recalculés automatiquement à partir des données de la série, vous n'avez donc pas besoin d'implémenter vos propres calculs.

**Si une présentation comporte plusieurs graphiques avec des liens externes, puis‑je contrôler quel classeur chaque graphique utilise pour les valeurs calculées ?**

Oui. Chaque graphique peut pointer vers son propre [classeur externe](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/), ou vous pouvez créer/remplacer un classeur externe par graphique indépendamment des autres.