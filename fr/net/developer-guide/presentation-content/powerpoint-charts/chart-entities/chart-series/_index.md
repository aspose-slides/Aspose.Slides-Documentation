---
title: Gérer les séries de données de diagramme dans les présentations en .NET
linktitle: Séries de données
type: docs
url: /fr/net/chart-series/
keywords:
- séries de diagramme
- chevauchement de série
- couleur de série
- couleur de catégorie
- nom de série
- point de données
- écart de série
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à gérer les séries de diagramme, les points de données, les cellules du classeur, le formatage, le chevauchement, la largeur d’écart et les valeurs négatives dans les présentations avec C#."
---
## **Vue d’ensemble**

Un diagramme stocke ses données tracées dans un classeur de données de diagramme. Un [IChartSeries](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/) représente un ensemble de valeurs liées, et chaque [IChartDataPoint](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapoint/) de la série fait référence à une ou plusieurs cellules du classeur. Les objets [IChartCategory](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartcategory/) fournissent les libellés ou les valeurs de regroupement partagés par les séries. Le nom de la série, les catégories et les valeurs des points sont donc connectés aux objets [IChartDataCell](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/) plutôt que stockés uniquement comme texte d’affichage.

Pour un diagramme de catégorie typique, le classeur par défaut utilise la ligne 0 pour les noms des séries, la colonne 0 pour les noms des catégories, et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/getcell/) sont basés sur zéro. Cette disposition est utile lorsque vous créez un diagramme avec des données par défaut, mais ne supposez pas que chaque diagramme existant l’utilise. Pour une présentation chargée, inspectez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du diagramme ont trois portées différentes :

- Les paramètres au niveau de la série, tels que [IChartSeries.Format](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/format/), fournissent l’apparence par défaut pour tous les points d’une série.
- Les paramètres de point de données, tels que [IChartDataPoint.Format](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapoint/format/), remplacent l’apparence de la série pour un point.
- Les paramètres de groupe s’appliquent aux séries compatibles qui appartiennent au même [IChartSeriesGroup](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseriesgroup/). Accédez au groupe via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/parentseriesgroup/) lorsque vous devez définir des options telles que le chevauchement ou la largeur d’écart.

Lorsqu’aucun remplissage explicite de point ou de série n’est défini, le style et le thème du diagramme déterminent l’apparence automatique. Lorsque les formats de série et de point sont tous deux présents, le format du point prime pour ce point.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries de diagramme**

[IChartSeries.Overlap](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/overlap/) indique le degré de chevauchement des barres ou des colonnes dans un diagramme 2D, de –100 à 100 pour cent. C’est une projection en lecture seule du paramètre du groupe de séries parent. Définissez [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseriesgroup/overlap/) pour mettre à jour chaque série compatible de ce groupe. Cette option s’applique aux types de diagrammes affichant des barres ou colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un diagramme combiné.

L’exemple suivant définit le chevauchement pour le groupe qui contient la première série :

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Le nouveau diagramme contient des séries, des catégories et des valeurs d'exemple.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Résultat :

![Le chevauchement des séries](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [IChartSeries.Format](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/format/) pour définir le remplissage par défaut d’une série entière. Si un point possède déjà un remplissage explicite, son paramètre [IChartDataPoint.Format](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapoint/format/) remplace le remplissage de la série pour ce point.

L’exemple suivant applique un remplissage bleu uni à la première série :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Résultat :

![La couleur de la série](series_color.png)

## **Modifier le nom de la série**

Le nom d’une série est stocké dans le classeur de données du diagramme et est normalement affiché dans la légende. Dans le classeur par défaut créé pour un diagramme à colonnes groupées, la cellule B1 se trouve à la ligne 0, colonne 1 et contient le nom de la première série. Les constantes nommées de l’exemple suivant rendent cette structure explicite :

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Vous pouvez également mettre à jour la cellule déjà référencée par [IChartSeries.Name](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/name/). Cette approche évite de supposer une ligne ou une colonne particulière dans un diagramme existant :

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Résultat :

![Le nom de la série](series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) renvoie la couleur calculée à partir de l’index de la série et du style du diagramme. C’est la couleur utilisée lorsque le remplissage de la série n’a pas été explicitement défini. L’appel de la méthode lit la couleur calculée ; il n’attribue pas un nouveau remplissage.

L’exemple suivant affiche la couleur automatique de chaque série par défaut :

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Exemple de sortie pour le style de diagramme par défaut :

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Les couleurs exactes dépendent du style et du thème du diagramme.

## **Définir la couleur de remplissage inversée pour une série de diagramme**

Pour les séries de barres, de colonnes et de bulles, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/invertifnegative/) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage régulier de la série sur plein, activez l’inversion et attribuez la couleur de la valeur négative via [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Les nombres négatifs restent inchangés dans le classeur ; seule leur couleur d’affichage change.

L’exemple suivant remplace les données de diagramme par défaut par une série. La ligne 0 de la feuille contient le nom de la série, la colonne 0 les noms des catégories et la colonne 1 les valeurs :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Résultat :

![La couleur de remplissage plein inversée](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un point via [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l’effet soit visible :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Effacer la valeur d’un point de données spécifique**

Pour rendre un point vide sans supprimer les autres points, définissez la cellule du classeur sous‑jacent sur `null`. Pour un diagramme à colonnes, la valeur tracée est accessible via [IChartDataPoint.YValue](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapoint/yvalue/). Le point de données reste à la même position de catégorie, mais le diagramme traite sa valeur comme vide selon les paramètres de valeurs vides du diagramme.

L’exemple suivant efface uniquement le deuxième point de la première série :

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Les diagrammes en nuage utilisent des cellules X et Y séparées, et les diagrammes à bulles utilisent également une cellule de taille. Effacez uniquement la cellule qui représente la valeur que vous souhaitez supprimer. N’appeler pas [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapointcollection/clear/) lorsque vous voulez conserver les autres points, car cette méthode supprime chaque point de données de la collection.

## **Définir la largeur d’écart des séries**

La largeur d’écart est l’espace entre les groupes de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, elle appartient au groupe de séries parent plutôt qu’à une série unique. Définissez [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) une fois pour le groupe. Une valeur plus grande crée plus d’espace entre les groupes ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur d’écart et enregistre uniquement la présentation finale :

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Résultat :

![La largeur d’écart](gap_width.png)

## **FAQ**

**Quels types de diagramme prennent en charge les séries de données ?**

Tous les types de diagrammes représentés par l’énumération [ChartType](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/charttype/) utilisent des données de diagramme, mais leurs séries n’ont pas toutes la même structure de valeurs ou les mêmes paramètres. Par exemple, les diagrammes de catégorie utilisent des catégories et des valeurs, les diagrammes en nuage utilisent des valeurs X et Y, et les diagrammes à bulles ajoutent des tailles de bulles. Utilisez la méthode de création de point de données correspondant au type de série. Des options telles que le chevauchement et la largeur d’écart s’appliquent uniquement aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de diagramme ?**

Un [IChartSeriesGroup](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseriesgroup/) contient des séries compatibles qui partagent des paramètres de tracé au niveau du groupe. Un diagramme combiné peut contenir plusieurs groupes, de sorte que la modification du groupe atteint via une série ne modifie pas forcément toutes les séries du diagramme.

**Un diagramme nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [IShapeCollection.AddChart](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addchart/) crée des séries, des catégories et des valeurs d’exemple. Vous pouvez modifier ces cellules ou vider les collections de séries et de catégories avant d’ajouter un jeu de données entièrement personnalisé. Une surcharge peut également créer un diagramme sans données par défaut.

**Comment les objets de diagramme sont‑ils reliés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données font référence à des cellules d’un [IChartDataWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/). Modifier une cellule référencée met à jour l’élément de diagramme correspondant. Lorsque vous construisez des données personnalisées, maintenez les lignes de catégories et les lignes de valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point au lieu de toute la série ?**

Définissez la cellule de valeur concernée sur `null` pour conserver la position de catégorie du point en tant que point vide. N’utilisez [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapointcollection/clear/) que lorsque vous avez l’intention de supprimer tous les points de cette série. Si vous supprimez également les catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de diagramme et de [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/displayblanksas/). Les diagrammes pris en charge peuvent afficher les blancs comme des espaces, comme des valeurs zéro ou en reliant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries de barres, de colonnes et de bulles prises en charge, activez [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/invertifnegative/) et définissez [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Vous pouvez remplacer le comportement pour un point individuel avec [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Ces propriétés affectent le formatage, pas les valeurs numériques stockées.

**Quel format l’emporte lorsque la série et le point sont tous deux formatés ?**

Le formatage explicite du point de données prime pour ce point. Les autres points continuent d’utiliser le format de série explicite ou, lorsque le format de série n’est pas défini, le style et le thème automatiques du diagramme. Les propriétés de groupe telles que le chevauchement et la largeur d’écart contrôlent la mise en page et ne constituent pas des remplacements de formatage au niveau du point.

**Y a‑t‑il une limite au nombre de séries qu’un diagramme peut contenir ?**

Aspose.Slides n’impose pas de limite fixe distincte du nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du diagramme déterminent une limite utile.

**Que faut‑il modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Définissez [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les groupes, ou diminuez‑la pour rapprocher les groupes.