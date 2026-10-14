---
title: Personnaliser les graphiques circulaires dans les présentations en .NET
linktitle: Graphique circulaire
type: docs
url: /fr/net/pie-chart/
keywords:
- graphique circulaire
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur des tranches
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser des graphiques circulaires en .NET avec Aspose.Slides. Configurer les tracés secondaires, afficher les étiquettes de données et appliquer des couleurs automatiques aux tranches dans PowerPoint."
---
## **Aperçu**

Cet article explique comment travailler avec les graphiques circulaires dans Aspose.Slides. Il montre comment configurer les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie, et comment activer la coloration automatique des tranches pour un graphique circulaire standard.

Les exemples se concentrent sur les tâches de personnalisation des graphiques telles que l’ajout d’un graphique à une diapositive, le réglage des séries et des paramètres d’étiquettes, le remplacement des données de graphique par défaut par des catégories et des valeurs personnalisées, et l’enregistrement de la présentation mise à jour.

## **Options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie**

Aspose.Slides for .NET prend en charge les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie. Ces options contrôlent la taille du tracé secondaire et la façon dont les points de données sont répartis entre les deux tracés.

L’exemple suivant crée un graphique Pie of Pie dans une nouvelle présentation et affiche les valeurs des points de données comme étiquettes. La propriété [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) définit la taille du tracé secondaire à 149 % du tracé principal. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) sélectionne le fractionnement basé sur le pourcentage, et [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) fixe le seuil à 53 %.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Afficher les valeurs et configurer le tracé secondaire.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Sélectionner les catégories pour le tracé secondaire**

Utilisez le fractionnement personnalisé lorsque vous souhaitez regrouper des catégories spécifiques dans le tracé secondaire, quelle que soit leur valeur en pourcentage. Par exemple, un rapport de ventes pourrait afficher Online et Events ensemble afin que les lecteurs puissent comparer ces deux canaux, même s’ils représentent 35 % et 10 % des ventes totales.

Définissez [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) sur [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) et sélectionnez les points via [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). La méthode [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) de la collection accepte soit un indice zéro‑based dans la série, soit un objet point de données. Dans cet exemple, l’indice 1 sélectionne Online, et le point à l’indice 3 sélectionne Events. Partners est également ajouté temporairement, puis exclu à l’aide de [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Remplacer les données par défaut par les ventes par canal.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Sélectionner Online par son indice zéro et Events par son objet de point de données.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Exclure Partners de la sélection sans supprimer ses données source.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) et Events (10) apparaissent comme des tranches séparées dans le tracé secondaire. Dans le tracé principal, ils sont représentés par une tranche combinée d’une valeur de 45, aux côtés de Retail (40) et Partners (15). Supprimer Partners de la sélection personnalisée le maintient dans le tracé principal ; cela ne supprime pas la catégorie ni sa valeur des données source du graphique.

L’image suivante montre la présentation enregistrée dans PowerPoint :

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Définir les couleurs automatiques des tranches du graphique circulaire**

Aspose.Slides for .NET peut attribuer automatiquement des couleurs différentes aux tranches d’un graphique circulaire. L’exemple suivant crée un graphique circulaire avec un titre centré et remplace les données par défaut par trois catégories trimestrielles et leurs valeurs. La propriété [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) affiche les valeurs 20, 50 et 30 comme étiquettes, tandis que [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) active une couleur distincte pour chaque tranche.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Ajouter un titre de graphique centré.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Remplacer les données par défaut en utilisant la première feuille de calcul.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Afficher les valeurs et attribuer des couleurs différentes aux tranches.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Les variantes Pie of Pie et Bar of Pie sont‑elles prises en charge ?**

Oui, la bibliothèque [supports](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types Pie of Pie et Bar of Pie.

**Puis‑je exporter uniquement le graphique sous forme d’image (par exemple PNG) ?**

Oui, vous pouvez [export the chart itself as an image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (tel que PNG) sans exporter l’ensemble de la présentation.