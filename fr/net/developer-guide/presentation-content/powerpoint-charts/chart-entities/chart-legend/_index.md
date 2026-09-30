---
title: Personnaliser les légendes de graphiques dans les présentations en .NET
linktitle: Légende du graphique
type: docs
url: /fr/net/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides pour .NET afin d’optimiser les présentations PowerPoint grâce à un formatage de légende adapté."
---
## **Vue d'ensemble**

Aspose.Slides pour .NET offre des options permettant de personnaliser les légendes des graphiques dans les présentations PowerPoint. Cet article montre comment positionner et dimensionner une légende, définir la taille de police pour l’ensemble de la légende, formater une entrée de légende individuelle et masquer ou restaurer des entrées sélectionnées.

La FAQ couvre les comportements associés, notamment la réservation d’espace pour la légende, l’affichage d’étiquettes multilignes et l’héritage du formatage du thème de la présentation.

## **Positionnement de la légende**

Utilisez les propriétés [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) et [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) de la légende pour spécifier sa position et sa taille en fractions des dimensions du graphique.

Cet exemple crée une présentation et ajoute un graphique à colonnes groupées avec des données par défaut à la première diapositive. Diviser les décalages et dimensions souhaités de la légende par la largeur et la hauteur du graphique les convertit en valeurs relatives : la légende est décalée de 50 points depuis le coin supérieur gauche du graphique et dimensionnée à 100 × 100 points.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Exprimez la position et la taille de la légende par rapport au graphique.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Définir la taille de police d’une légende**

Utilisez la propriété [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) de la légende pour accéder à son formatage de texte et définissez [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) en points.

Cet exemple crée un graphique avec des données par défaut et définit le texte de la légende à 20 points. Il désactive également les limites automatiques pour l’axe vertical et fixe sa plage de -5 à 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Définir la taille de police d’une entrée de légende individuelle**

Utilisez la collection [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) de la légende pour accéder au formatage d’une entrée spécifique. Les indices des entrées sont basés sur zéro, ainsi l’indice `1` correspond à la deuxième entrée.

Cet exemple crée un graphique à colonnes groupées dont les données par défaut comprennent au moins deux séries. Il formate la deuxième entrée de légende avec du texte gras, italique et bleu de 20 points.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Masquer les entrées de légende individuelles**

Pour exclure une série auxiliaire de la légende tout en conservant ses données visibles, définissez [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) sur `true` via [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Cela masque uniquement l’entrée de légende sélectionnée ; cela ne supprime pas la série ni ses points de données. En revanche, définir [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) sur `false` masque la légende entière.

L’exemple ci‑dessous crée un graphique à colonnes groupées avec plusieurs séries utilisant des données par défaut. Il masque l’entrée de légende de la deuxième série (indice `1`) et enregistre la présentation. Il restaure ensuite l’entrée en définissant `Hide` sur `false` et enregistre une seconde copie. Les colonnes restent visibles dans les deux fichiers.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Restaurer la même entrée sans changer les données du graphique.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

La comparaison ci‑dessous montre le même graphique avec toutes les entrées visibles et avec la deuxième entrée masquée. Les colonnes de la deuxième série restent inchangées.

![Comparaison d’un graphique avec toutes les entrées de légende visibles et avec la Série 2 masquée de la légende ; toutes les colonnes restent visibles.](hide-legend-entry.png)

Dans les graphiques en colonnes, en barres et en lignes, les entrées de légende identifient les séries. Pour les graphiques circulaires, elles identifient les points de données individuels (tranches), utilisez donc [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) sur la tranche sélectionnée. L’API documente cette propriété de point de données pour les types de graphiques `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` et `BarOfPie`. Ne supposez pas qu’elle s’applique aux graphiques en anneau, qui ne figurent pas dans cette liste.

## **FAQ**

**Puis‑je faire en sorte que le graphique réserve de l’espace pour la légende au lieu de la superposer ?**

Oui. Réglez [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) sur `false` pour réserver de l’espace à la légende au lieu de la laisser se superposer à la zone du tracé.

**Puis‑je créer des étiquettes de légende multilignes ?**

Oui. Les longues étiquettes peuvent se renvoyer à la ligne lorsque la largeur disponible est insuffisante. Vous pouvez également insérer des caractères de saut de ligne dans les noms de séries pour forcer des retours à la ligne.

**Comment faire en sorte que la légende suive le jeu de couleurs du thème de la présentation ?**

Laissez les couleurs, remplissages et polices de la légende non définis afin qu’elle hérite du formatage du thème. Un formatage explicite remplace les paramètres correspondants du thème.