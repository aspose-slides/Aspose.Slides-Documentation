---
title: Gérer les étiquettes de données de graphique dans les présentations en .NET
linktitle: Étiquette de données
type: docs
url: /fr/net/chart-data-label/
keywords:
- graphique
- étiquette de données
- précision des données
- pourcentage
- distance de l'étiquette
- position de l'étiquette
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à ajouter et à formater les étiquettes de données de graphique dans les présentations PowerPoint en utilisant Aspose.Slides pour .NET afin de créer des diapositives plus attrayantes."
---
## **Introduction**

Les étiquettes de données affichent des informations sur les séries de graphiques et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des étiquettes, contrôler les étiquettes au‑delà du maximum de l'axe, ajuster l'espacement des étiquettes de l'axe des catégories et positionner les étiquettes d'un graphique circulaire.

## **Compter les étiquettes de données visibles**

Utilisez [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) pour vérifier combien d'étiquettes de données sont activées pour l'affichage avant de publier une présentation. Contrairement à [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/), qui renvoie le nombre total d'étiquettes dans la collection, il prend en compte les paramètres par défaut de la série et les réglages individuels des étiquettes.

Cet exemple crée un graphique à colonnes avec une série et trois points de données. Il accède à la collection [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/) de la série et affiche le nombre visible à mesure que les paramètres changent : **0, 3, 2, 3**. Le nombre total reste **3**.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesCell = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

for (int i = 0; i < 3; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var labels = series.Labels;
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // Total: 3; visible: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Visible: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Visible: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // Visible: 3
```

Le [DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) de la série fournit les paramètres par défaut. Activer [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) y affiche les valeurs pour les trois étiquettes. Le définir sur `false` via le [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) d'une étiquette remplace ce paramètre pour l'étiquette sélectionnée. Activer [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) fait en sorte que cette étiquette soit de nouveau comptée comme visible, même si sa valeur reste masquée.

Le nombre visible reflète les paramètres de visibilité. Il ne mesure pas si les étiquettes se chevauchent, sont découpées ou sont lisibles dans le rendu du graphique.

## **Définir la précision des valeurs dans les étiquettes de graphique**

Utilisez [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) pour formater les valeurs de la série. Cet exemple crée un graphique en courbes avec des données par défaut, affiche son tableau de données et active les étiquettes de valeur pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous‑jacentes.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

Pour formater les cellules numériques du classeur intégré du graphique, voir [Set Custom Number Formats for Workbook Cells](/slides/fr/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). Cet exemple montre également les étiquettes de valeur suivant les formats de leurs cellules source tout en conservant les valeurs numériques stockées.

## **Afficher le pourcentage comme étiquettes**

Pour un graphique à colonnes empilées, calculez chaque valeur en pourcentage du total de sa catégorie et attribuez le texte à [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Cet exemple utilise les données par défaut du graphique et affiche les pourcentages avec deux décimales dans une police de 8 points. Les catégories dont le total est zéro sont ignorées afin d'éviter une division par zéro. Recalculez le texte personnalisé de l'étiquette si les données du graphique changent.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Ajouter le signe pourcentage avec les étiquettes de graphique**

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) pour afficher des pourcentages. Définissez [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) sur `false` afin d'appliquer le format de l'étiquette indépendamment des cellules source.

Cet exemple crée un graphique à colonnes empilées à 100 % avec des séries rouge et bleue sur quatre catégories. Chaque paire de valeurs totalise 1. Le format d'étiquette `0.0%` affiche 0,30 comme 30,0 %, tandis que l'axe vertical utilise deux décimales. Les deux séries utilisent un texte d'étiquette blanc de 10 points.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Lire le texte réel des étiquettes de données**

Utilisez [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) pour récupérer le texte généré par les paramètres d'une étiquette de données. Ceci est utile lors de l'extraction d'étiquettes pour les rapports, la recherche de contenu dans une présentation ou la validation de graphiques générés. Dans l'exemple ci‑contre, le [format d'étiquette de données](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) par défaut combine le nom de chaque catégorie, le nom de la série et la valeur. Un point formate sa valeur en pourcentage, et un autre utilise un texte personnalisé provenant de [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

Le nombre stocké dans un point de données reste `0.75`, même si son étiquette affiche `75 %` avec les noms de catégorie et de série. Le texte personnalisé remplace le texte d'étiquette généré. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) renvoie la chaîne d'étiquette résultante dans les deux cas. Vérifiez [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) séparément, comme indiqué ci‑dessus, lorsque vous ne souhaitez extraire que les étiquettes visibles.

## **Contrôler les étiquettes de données au‑delà du maximum de l'axe**

Lorsque vous limitez manuellement la plage d'un axe, certains points de données peuvent dépasser son maximum. Utilisez [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) pour contrôler si leurs étiquettes de données sont affichées. Ce paramètre modifie la visibilité des étiquettes ; il ne modifie pas la plage de l'axe ni les valeurs sous‑jacentes.

L'exemple ci‑dessous crée un graphique à colonnes groupées 2D avec des valeurs de 60 et 120. Il définit [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) sur `false` et [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) à 100 sur l'axe vertical. La première diapositive autorise les étiquettes au‑delà du maximum ; une copie de cette diapositive les désactive. Les deux diapositives sont enregistrées dans `DataLabelsOverMaximum.pptx`.

Activez les étiquettes de valeur avec [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Le paramètre au niveau du graphique n'active pas l'affichage des valeurs par lui‑même et ne remplace pas le désactivation de l'affichage des valeurs d'une étiquette individuelle. Cet exemple active les valeurs pour toute la série et utilise [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) pour placer les étiquettes à l'extrémité extérieure de chaque colonne.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

Les images suivantes montrent les diapositives enregistrées rendues par Microsoft PowerPoint. Avec `true`, l'étiquette **120** est visible à la limite supérieure ; avec `false`, elle est masquée. L'étiquette **60** reste visible, le maximum de l'axe reste à **100**, et le deuxième point de données reste **120** dans les deux cas.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![Graphique PowerPoint affichant l'étiquette de valeur 120 avec un maximum d'axe de 100](data-labels-over-maximum-true.png) | ![Graphique PowerPoint masquant l'étiquette de valeur 120 avec un maximum d'axe de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

Cet exemple utilise un graphique à colonnes 2D avec un axe des valeurs. Les graphiques sans axe des valeurs, tels que les graphiques circulaires et les graphiques en anneau, n'ont pas de maximum d'axe à limiter de cette manière.

{{% /alert %}}

## **Définir la distance de l'étiquette par rapport à un axe**

Utilisez [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) pour contrôler la distance entre les étiquettes de l'axe des catégories et l'axe. La valeur est un pourcentage de la taille maximale de police des étiquettes d'axe. Cet exemple crée un graphique à colonnes groupées et définit le décalage des étiquettes de l'axe horizontal à 500. Ce paramètre affecte les étiquettes de l'axe des catégories plutôt que les étiquettes attachées aux points de données individuels.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Ajuster l'emplacement des étiquettes**

Sur un graphique circulaire, ajustez les positions des étiquettes de données pour améliorer l'espacement et laisser de la place aux traits de repère.

Cet exemple affiche la valeur du premier point de données, place son étiquette à l'extérieur de la tranche et ajuste ses décalages [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) et [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Ces décalages sont relatifs à la largeur et à la hauteur du graphique, respectivement.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Graphique circulaire avec une position d'étiquette de données ajustée](pie-chart-adjusted-label.png)

## **Formater les traits de repère**

Lorsque les étiquettes d'un graphique circulaire se trouvent à l'extérieur de leurs tranches, les traits de repère aident les lecteurs à associer chaque valeur à la tranche correcte. Une couleur contrastée et un trait légèrement plus épais peuvent rendre ces connexions plus faciles à suivre, tandis que la transparence et le style pointillé maintiennent les traits visuellement discrets.

Utilisez [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) pour formater les traits de repère au niveau de la collection d'étiquettes de données de la série. Les paramètres dans `series.Labels.LeaderLinesFormat.Line` s'appliquent à la collection, et non à une étiquette individuelle.

Cet exemple crée un graphique circulaire avec des données par défaut, affiche les valeurs à l'extérieur des tranches et active [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Il déplace deux étiquettes plus loin de leurs tranches en utilisant les décalages [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) et [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/), exprimés comme fractions de la largeur et de la hauteur du graphique. Aucune présentation d'entrée n’est requise.

Le [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) de la ligne définit une couleur bleue solide avec une valeur alpha de 191 sur 255, offrant environ 25 % de transparence. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) définit l'épaisseur à 2 points, et [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) rend la ligne pointillée.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// Déplacer deux étiquettes plus loin de leurs tranches.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

Activer les traits de repère ne garantit pas qu’un trait apparaisse pour chaque étiquette. La visibilité dépend du placement des étiquettes et du comportement de mise en page du graphique. Dans cet exemple, les deux étiquettes déplacées ont des traits de repère visibles ; les étiquettes restées proches de leurs tranches n’en ont pas besoin.

L'image suivante montre le fichier `FormattedLeaderLines.pptx` enregistré rendu avec Aspose.Slides :

![Graphique circulaire avec des traits de repère bleus, semi‑transparents et pointillés reliant deux étiquettes extérieures à leurs tranches](formatted-leader-lines.png)

## **Ajouter plusieurs lignes d'étiquettes de données au-dessus d'un graphique à colonnes**

Cet exemple crée un graphique à colonnes avec deux lignes d'étiquettes de données au-dessus de la zone de tracé. La Série A affiche les colonnes visibles, tandis que les Séries B et C fournissent les étiquettes supplémentaires. Leurs colonnes sont masquées en supprimant le remplissage et le contour. La propriété [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) aligne les trois séries sur les mêmes centres de catégorie.

Les paramètres du [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) réservent de l’espace pour les lignes d’étiquettes. Après que [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) calcule les positions par défaut, les décalages [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) et [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) conservent l’alignement horizontal et appliquent des déplacements verticaux pour disposer les étiquettes en deux rangées. Les nombres restent des étiquettes de données liées aux valeurs de la série ; seules les en‑têtes de rangées sont des formes de texte distinctes.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // Masquer les colonnes de B et C, mais garder leurs étiquettes de données.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Aligner les trois séries sur les mêmes centres de catégorie.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Utiliser moins de lignes de grille pour cet exemple compact.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Réserver de l'espace au-dessus du tracé pour deux rangées d'étiquettes de données.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // Conserver la position horizontale par défaut. Y est un décalage à partir de
        // la position d'étiquette par défaut, exprimé en fraction de la hauteur du graphique.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Seul l'en-tête de rangée est une forme de texte distincte.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![Graphique à colonnes avec deux rangées d'étiquettes de données au-dessus de la zone de tracé](multiple-rows-of-labels.png)

## **Modifier les formes des étiquettes de données**

Aspose.Slides for .NET 26.11 ajoute [IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) pour une étiquette et [IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) pour toutes les étiquettes actuelles d’une série. Ces options changent la forme de l’étiquette, pas le marqueur de point. Pour le réglage d’appel séparé, voir [Data Label Callouts](/slides/fr/net/callout/).

L’affectation de la collection met à jour les étiquettes existantes, il faut donc appliquer les remplacements individuels **après** le paramétrage de la collection. Cet exemple complet nécessite [Aspose.Slides for .NET](/slides/fr/net/installation/) 26.11 ou ultérieur. Il crée des étiquettes de valeur visibles, sélectionne des ellipses pour la première série puis rend sa première étiquette rectangulaire.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var labels = chart.ChartData.Series[0].Labels;
labels.DefaultDataLabelFormat.ShowValue = true;
labels.DefaultLabelShapeType = ShapeType.Ellipse;
labels[0].LabelShapeType = ShapeType.Rectangle;

foreach (var label in labels)
{
    var format = label.DataLabelFormat.Format;
    format.Fill.FillType = FillType.Solid;
    format.Fill.SolidFillColor.Color = Color.LightYellow;
    format.Line.FillFormat.FillType = FillType.Solid;
    format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
}

presentation.Save("label-shapes.pptx", SaveFormat.Pptx);

// Réinitialiser les choix de forme explicites sur toutes les étiquettes actuelles.
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

Attribuer à nouveau la forme de la collection remplace également les choix de forme individuels précédents. [NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) efface la sélection de forme explicite ; cela ne masque pas les étiquettes ni ne supprime leurs autres mises en forme. Définissez les formes souhaitées après avoir rempli la série plutôt que de supposer que les points ajoutés plus tard héritent d’une attribution antérieure. Rectangle et Ellipse sont utilisés ici ; inspectez le résultat rendu lors du choix d’autres types de forme.

## **FAQ**

**How can I prevent data labels from overlapping on dense charts?**

Combine automatic label placement, leader lines, and reduced font size; if necessary, hide some fields (for example, the category) or show labels only for extreme values or key points.

**How can I disable labels only for zero, negative, or empty values?**

Filter data points before enabling labels and turn off display for values of 0, negative values, or missing values according to a defined rule.

**How can I ensure a consistent label style when exporting to PDF/images?**

Explicitly set the font family and size and verify that the font is available in the rendering environment to avoid fallback.