---
title: Personnaliser les tableaux de données de graphiques dans les présentations en .NET
linktitle: Tableau de données
type: docs
url: /fr/net/chart-data-table/
keywords:
- données de graphique
- tableau de données
- propriétés de police
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Personnalisez les polices, les bordures et les clés de légende du tableau de données d'un graphique dans les présentations PowerPoint à l'aide d'Aspose.Slides pour .NET et C#."
---
## **Vue d'ensemble**

Aspose.Slides for .NET vous permet d'afficher le tableau de données d'un graphique et de personnaliser le formatage du texte, les bordures et les clés de légende. Cet article explique comment activer le tableau, formater son texte, contrôler chaque type de bordure et afficher ou masquer les clés de légende. Les exemples enregistrent les graphiques configurés dans des fichiers PPTX.

## **Définir les propriétés de police**

Pour afficher le tableau de données d'un graphique, définissez [HasDataTable](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chart/hasdatatable/) sur `true`. Utilisez [ChartDataTable](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chart/chartdatatable/) pour accéder au tableau et configurer le formatage du texte.

1. Chargez la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Ajoutez un graphique à colonnes groupées à la première diapositive.
1. Activez le tableau de données du graphique.
1. Activez le texte en gras avec [FontBold](https://reference.aspose.com/slides/fr/net/aspose.slides/baseportionformat/fontbold/) et définissez [FontHeight](https://reference.aspose.com/slides/fr/net/aspose.slides/baseportionformat/fontheight/) à `20` pour un texte de 20 points.
1. Enregistrez la présentation modifiée.

L'exemple suivant nécessite le fichier `test.pptx` dans le répertoire de travail avec au moins une diapositive. Il ajoute un graphique avec des données par défaut à la position (50, 50), avec une largeur de 600 points et une hauteur de 400 points. Le fichier `output.pptx` enregistré contient le graphique avec son tableau de données activé et les paramètres de police spécifiés appliqués.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Personnaliser les bordures du tableau de données**

Activez le tableau avec [IChart.HasDataTable](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/hasdatatable/) et accédez-y via [IChart.ChartDataTable](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/chartdatatable/). Vous pouvez contrôler trois types de bordures de manière indépendante :

- [HasBorderHorizontal](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/idatatable/hasborderhorizontal/) contrôle les bordures horizontales des cellules.
- [HasBorderVertical](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/idatatable/hasbordervertical/) contrôle les bordures verticales des cellules.
- [HasBorderOutline](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/idatatable/hasborderoutline/) contrôle la bordure extérieure du tableau.

Définissez chaque propriété sur `true` pour afficher ses bordures ou sur `false` pour les masquer. L'exemple suivant crée un graphique à colonnes groupées avec des données par défaut, affiche les bordures horizontales et la bordure extérieure, et masque les bordures verticales. Aucun fichier d'entrée n'est requis. La position et la taille du graphique sont spécifiées en points.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

La comparaison ci-dessous utilise les mêmes données de graphique et le même paramètre de clé de légende dans les quatre cas. En partant de toutes les bordures activées, chaque variante suivante désactive une seule propriété de bordure. La variante en bas à gauche correspond aux paramètres de bordure de l'exemple.

![Tableaux de données de graphiques avec toutes les bordures activées, sans bordures horizontales, sans bordures verticales et sans bordure extérieure](data-table-borders.png)

## **Afficher ou masquer les clés de légende**

Les clés de légende sont de petites marques colorées à côté des noms de série dans le tableau de données. Elles aident les lecteurs à associer chaque ligne du tableau à une série du graphique. Définissez [ShowLegendKey](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/idatatable/showlegendkey/) sur `true` pour afficher ces marques ou sur `false` pour les masquer.

La légende séparée du graphique est contrôlée par [IChart.HasLegend](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/haslegend/). Ces paramètres sont indépendants : masquer la légende séparée ne masque pas les clés dans le tableau de données, et masquer les clés du tableau ne masque pas la légende séparée.

L'exemple suivant crée un graphique avec des données par défaut, active son tableau de données et affiche les clés de légende à l'intérieur tout en masquant la légende séparée. Toutes les bordures du tableau sont explicitement activées. Aucun fichier de présentation d'entrée n'est requis. Pour masquer uniquement les clés du tableau, modifiez `dataTable.ShowLegendKey` en `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

La comparaison ci-dessous montre le même tableau avec les clés de légende activées et désactivées. Toutes les bordures restent activées, et la légende séparée du graphique est masquée dans les deux cas.

![Tableaux de données de graphiques avec les clés de légende affichées à gauche et masquées à droite](data-table-legend-keys.png)

## **FAQ**

**Puis-je afficher les clés de légende dans le tableau de données d'un graphique ?**

Oui. Définissez [ShowLegendKey](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/datatable/showlegendkey/) sur `true` pour afficher les clés de légende ou sur `false` pour les masquer.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation vers PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique et son tableau de données affiché comme partie de la diapositive lors de l'exportation vers [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [HTML](/slides/fr/net/convert-powerpoint-to-html/) ou [images](/slides/fr/net/convert-powerpoint-to-png/).

**Puis-je travailler avec les tableaux de données dans des graphiques chargés depuis un modèle ?**

Oui. Pour un graphique chargé depuis une présentation ou un modèle existant, utilisez [HasDataTable](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chart/hasdatatable/) pour vérifier ou modifier si son tableau de données est affiché.

**Comment puis-je trouver les graphiques dont le tableau de données est activé ?**

Parcourez les formes de chaque diapositive, identifiez les graphiques et vérifiez leur propriété [HasDataTable](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chart/hasdatatable/). Une valeur de `true` indique que le tableau de données est activé.