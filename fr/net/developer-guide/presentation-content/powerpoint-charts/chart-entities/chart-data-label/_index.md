---
title: Gérer les étiquettes de données de graphique dans les présentations .NET
linktitle: Étiquette de données
type: docs
url: /fr/net/chart-data-label/
keywords:
- graphique
- étiquette de données
- précision des données
- pourcentage
- distance d'étiquette
- emplacement de l'étiquette
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à ajouter et formater les étiquettes de données de graphique dans les présentations PowerPoint à l’aide d’Aspose.Slides pour .NET afin de créer des diapositives plus attrayantes."
---
## **Introduction**

Les étiquettes de données affichent des informations sur les séries de graphique et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des étiquettes, contrôler les étiquettes au‑delà du maximum de l’axe, ajuster l’espacement des étiquettes de l’axe des catégories et positionner les étiquettes d’un diagramme circulaire.

## **Définir la précision des données dans les étiquettes de graphique**

Utilisez [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) pour formater les valeurs des séries. Cet exemple crée un graphique en courbes avec des données par défaut, affiche son tableau de données et active les étiquettes de valeur pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous‑jacentes.

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

Pour formater les cellules numériques du classeur intégré à un graphique, consultez [Set Custom Number Formats for Workbook Cells](/slides/fr/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). Cet exemple montre également les étiquettes de valeur suivant les formats de leurs cellules sources tout en conservant les valeurs numériques stockées.

## **Afficher le pourcentage comme étiquettes**

Pour un graphique à colonnes empilées, calculez chaque valeur comme un pourcentage du total de sa catégorie et attribuez le texte à [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Cet exemple utilise les données de graphique par défaut et affiche les pourcentages avec deux décimales dans une police de 8 points. Les catégories dont le total est nul sont ignorées pour éviter une division par zéro. Recalculez le texte d’étiquette personnalisé si les données du graphique changent.

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

## **Définir le signe pourcentage avec les étiquettes de graphique**

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) pour afficher les pourcentages. Définissez [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) sur `false` pour appliquer le format de l’étiquette indépendamment des cellules sources.

Cet exemple crée un graphique à colonnes empilées à 100 % avec des séries rouge et bleue sur quatre catégories. Chaque paire de valeurs totalise 1. Le format d’étiquette `0.0%` affiche 0,30 comme 30,0 %, tandis que l’axe vertical utilise deux décimales. Les deux séries utilisent un texte d’étiquette blanc de 10 points.

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

Utilisez [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) pour récupérer le texte généré par les paramètres d’une étiquette de données. Ceci est utile lors de l’extraction d’étiquettes pour des rapports, la recherche de contenu dans une présentation ou la validation de graphiques générés. Dans l’exemple ci‑dessous, le format d’étiquette de données par défaut [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) combine le nom de chaque catégorie, le nom de la série et la valeur. Un point formate sa valeur comme un pourcentage, et un autre utilise un texte personnalisé provenant de [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

Le nombre stocké dans un point de données reste `0.75`, même si son étiquette affiche `75 %` avec les noms de catégorie et de série. Le texte personnalisé remplace le texte d’étiquette généré. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) renvoie la chaîne d’étiquette résultante dans les deux cas. Vérifiez [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) séparément, comme illustré ci‑dessus, lorsque vous ne souhaitez extraire que les étiquettes visibles.

## **Contrôler les étiquettes de données au‑delà du maximum de l’axe**

Lorsque vous limitez manuellement une plage d’axe, certains points de données peuvent dépasser son maximum. Utilisez [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) pour contrôler si leurs étiquettes de données sont affichées. Ce paramètre modifie la visibilité des étiquettes ; il ne modifie pas la plage de l’axe ni les valeurs sous‑jacentes.

L’exemple ci‑dessous crée un graphique à colonnes groupées 2D avec des valeurs de 60 et 120. Il définit [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) sur `false` et [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) sur 100 pour l’axe vertical. La première diapositive autorise les étiquettes au‑delà du maximum ; une copie de cette diapositive les désactive. Les deux diapositives sont enregistrées dans `DataLabelsOverMaximum.pptx`.

Activez les étiquettes de valeur avec [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Le paramètre au niveau du graphique n’active pas l’affichage des valeurs par lui‑même et ne remplace pas la désactivation de l’affichage de la valeur d’une étiquette individuelle. Cet exemple active les valeurs pour l’ensemble de la série et utilise [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) pour placer les étiquettes à l’extrémité extérieure de chaque colonne.

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

Les images suivantes montrent les diapositives enregistrées rendues par Microsoft PowerPoint. Avec `true`, l’étiquette **120** est visible à la limite supérieure ; avec `false`, elle est masquée. L’étiquette **60** reste visible, le maximum de l’axe reste à **100**, et le deuxième point de données reste **120** dans les deux cas.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![Graphique PowerPoint affichant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-true.png) | ![Graphique PowerPoint masquant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Type de graphique" %}}
Cet exemple utilise un graphique à colonnes 2D avec un axe de valeur. Les graphiques sans axe de valeur, comme les graphiques circulaires et en anneau, n’ont pas de maximum d’axe à limiter de cette manière.
{{% /alert %}}

## **Définir la distance de l’étiquette par rapport à un axe**

Utilisez [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) pour contrôler la distance entre les étiquettes de l’axe des catégories et l’axe. La valeur est un pourcentage de la taille maximale de la police des étiquettes d’axe. Cet exemple crée un graphique à colonnes groupées et définit le décalage des étiquettes de l’axe horizontal à 500. Ce paramètre affecte les étiquettes de l’axe des catégories plutôt que les étiquettes attachées aux points de données individuels.

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

## **Ajuster l’emplacement des étiquettes**

Sur un graphique circulaire, ajustez les positions des étiquettes de données pour améliorer l’espacement et laisser de la place aux lignes de repère.

Cet exemple affiche la valeur du premier point de données, place son étiquette à l’extérieur de la tranche et ajuste ses décalages [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) et [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Ces décalages sont relatifs à la largeur et à la hauteur du graphique, respectivement.

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

![Diagramme circulaire avec une position d’étiquette de données ajustée](pie-chart-adjusted-label.png)

## **Formater les lignes de repère**

Lorsque les étiquettes d’un graphique circulaire se trouvent à l’extérieur de leurs tranches, les lignes de repère aident les lecteurs à associer chaque valeur à la tranche correspondante. Une couleur contrastée et une ligne légèrement plus épaisse peuvent rendre ces connexions plus faciles à suivre, tandis que la transparence et un style pointillé maintiennent les lignes discrètes visuellement.

Utilisez [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) pour formater les lignes de repère au niveau de la collection d’étiquettes de données de la série. Les paramètres de `series.Labels.LeaderLinesFormat.Line` s’appliquent à la collection, plutôt qu’à une étiquette individuelle.

Cet exemple crée un graphique circulaire avec des données par défaut, affiche les valeurs à l’extérieur des tranches et active [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Il éloigne deux étiquettes de leurs tranches en utilisant les décalages [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) et [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/), exprimés en fractions de la largeur et de la hauteur du graphique. aucune présentation d’entrée n’est requise.

Le [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) de la ligne définit une couleur bleue unie avec une valeur alpha de 191 sur 255, offrant environ 25 % de transparence. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) définit l’épaisseur à 2 points, et [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) rend la ligne pointillée.

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

L’activation des lignes de repère ne garantit pas l’apparition d’une ligne pour chaque étiquette. La visibilité dépend du placement des étiquettes et du comportement de mise en page du graphique. Dans cet exemple, les deux étiquettes déplacées ont des lignes de repère visibles ; les étiquettes qui restent près de leurs tranches n’en ont pas besoin.

L’image suivante montre le fichier `FormattedLeaderLines.pptx` enregistré, rendu avec Aspose.Slides :

![Diagramme circulaire avec des lignes de repère bleues, semitransparentes et pointillées reliant deux étiquettes extérieures à leurs tranches](formatted-leader-lines.png)

## **Ajouter plusieurs lignes d’étiquettes de données au‑dessus d’un graphique à colonnes**

Cet exemple crée un graphique à colonnes avec deux lignes d’étiquettes de données au‑dessus de la zone de tracé. La série A affiche les colonnes visibles, tandis que les séries B et C fournissent les étiquettes supplémentaires. Leurs colonnes sont masquées en supprimant le remplissage et le contour. La propriété [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) aligne les trois séries sur les mêmes centres de catégorie.

Les paramètres du [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) réservent de l’espace pour les lignes d’étiquettes. Après que [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) calcule les positions par défaut, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) et [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) conservent l’alignement horizontal et appliquent des décalages verticaux pour disposer les étiquettes en deux rangées. Les nombres restent des étiquettes de données liées aux valeurs des séries ; seules les en‑têtes de rangée sont des formes de texte séparées.

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
        // Masquer les colonnes de B et C, tout en conservant leurs étiquettes de données.
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

// Réserver de l’espace au‑dessus du tracé pour deux rangées d’étiquettes de données.
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
        // Conserver la position horizontale par défaut. Y est un décalage depuis
        // la position d’étiquette par défaut, exprimé comme une fraction de la hauteur du graphique.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Seul l’en‑tête de ligne est une forme de texte distincte.
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

![Graphique à colonnes avec deux rangées d’étiquettes de données au‑dessus de la zone de tracé](multiple-rows-of-labels.png)

## **FAQ**

**Comment éviter que les étiquettes de données se chevauchent sur des graphiques denses ?**  
Combinez le positionnement automatique des étiquettes, les lignes de repère et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les valeurs extrêmes ou les points clés.

**Comment désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**  
Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style d’étiquette cohérent lors de l’exportation en PDF/images ?**  
Définissez explicitement la famille et la taille de police et vérifiez que la police est disponible dans l’environnement de rendu pour éviter le recours à une police de substitution.