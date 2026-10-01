---
title: Personnaliser les axes de diagramme dans les présentations en .NET
linktitle: Axe du diagramme
type: docs
url: /fr/net/chart-axis/
keywords:
- axe de diagramme
- axe vertical
- axe horizontal
- personnaliser l'axe
- manipuler l'axe
- gérer l'axe
- propriétés de l'axe
- valeur maximale
- valeur minimale
- ligne d'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides pour .NET afin de personnaliser les axes de diagramme dans les présentations PowerPoint pour les rapports et les visualisations."
---
## **Aperçu**

Cet article explique comment personnaliser les axes de diagramme avec Aspose.Slides pour .NET. Il couvre les valeurs d'axe calculées, l'échange des lignes et colonnes du diagramme, la visibilité des axes, les intervalles des étiquettes de catégorie et des marques de repère, les catégories de dates et leur formatage, la rotation du titre, le positionnement des axes et les unités d'affichage.

## **Obtenir les valeurs maximales sur l'axe vertical des diagrammes**

Créez une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et ajoutez un diagramme en aires avec les données par défaut. Appelez [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) avant de lire les valeurs d'axe calculées afin que la mise en page du diagramme soit à jour.

Lisez [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) et [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) pour les limites de l'axe, et [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) et [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) pour les intervalles des marques. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) et [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) fournissent des échelles d'unités temporelles, pertinentes pour les axes de dates. L'exemple stocke ces valeurs dans des variables locales et enregistre le diagramme.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Échanger les données entre les axes**

Utilisez [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) pour échanger les rôles des séries et des catégories dans les données du diagramme. Chaque catégorie précédente devient une série, et chaque série précédente devient une catégorie. Cela modifie la façon dont les données sont groupées ; cela n'échange pas les axes horizontal et vertical. L'exemple utilise [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) pour lier les données par défaut à `Sheet1!A1:D5`, y compris la ligne d’en-tête et la colonne de catégorie, avant d’échanger les lignes et les colonnes. Il enregistre un diagramme avec quatre séries et trois catégories.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Désactiver l'axe vertical pour les graphiques en lignes**

Définissez [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) sur `false` pour l’axe vertical afin de le masquer. L'exemple crée un graphique en lignes avec les données par défaut et l’enregistre avec l'axe vertical masqué.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Désactiver l'axe horizontal pour les graphiques en lignes**

Définissez [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) sur `false` pour l’axe horizontal afin de le masquer. L'exemple crée un graphique en lignes avec les données par défaut et l’enregistre avec l'axe horizontal masqué.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Modifier un axe de catégorie**

Définissez [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) pour choisir un axe de catégorie de type date ou texte. Cet exemple nécessite `ExistingChart.pptx`, avec un diagramme comme première forme de la première diapositive et des cellules de catégorie contenant des valeurs de dates Excel numériques. Il transforme l'axe horizontal en axe de date. En réglant [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) sur `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) sur `1` et [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) sur « months », les marques majeures sont espacées d’un mois.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **Contrôler les intervalles des étiquettes d'axe de catégorie**

Lorsqu'un diagramme possède de nombreuses catégories, réduisez le nombre d'étiquettes d'axe visibles sans supprimer les catégories ni les points de données. Réglez [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) sur `false`, puis définissez [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) sur l'intervalle de catégorie souhaité. Pour des catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Étiquettes affichées dans l'exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, ... Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, ... Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, ... Catégorie 22 |

Un intervalle de `3` affiche chaque troisième étiquette, laissant deux étiquettes masquées entre les étiquettes affichées. Cela ne supprime pas les colonnes correspondantes. L'espacement automatique choisit un intervalle en fonction de l'espace disponible ; il n'affiche pas nécessairement chaque étiquette.

Les marques de repère disposent de contrôles séparés. Réglez [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) sur `false` et utilisez [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) pour définir leur intervalle. Par exemple, `1` conserve une marque de repère à chaque intervalle de catégorie tandis que les étiquettes n'apparaissent qu'à chaque troisième catégorie. Définissez [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) sur un style visible pour voir le résultat. Réactiver l'une ou l'autre des propriétés d'espacement automatique en les remettant à `true` laisse le diagramme choisir à nouveau cet intervalle.

L'exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement d'étiquettes manuel avec marques de repère indépendantes, et restauration de l'espacement automatique. Les deux copies conservent les données d'origine du diagramme. Aucune présentation d’entrée n'est requise. Le texte des étiquettes horizontales rend la différence de densité facile à percevoir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Diapositive 2: afficher chaque troisième étiquette, mais conserver une marque de repère pour chaque catégorie.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Diapositive 3: laisser le diagramme choisir à nouveau les deux intervalles.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Espacement automatique (diapositive 1) :** Dans ce rendu, chaque deuxième étiquette de catégorie est affichée et se répartit sur deux lignes. Le résultat automatique peut varier selon la taille du diagramme, les polices et le moteur de rendu.

![Espacement automatique des étiquettes de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** Chaque troisième étiquette est affichée sur une ligne, tandis que les marques de repère restent à chaque intervalle de catégorie. Les 24 colonnes, y compris celles sans étiquettes, restent visibles avec les mêmes valeurs. La diapositive 3 restaure l'apparence automatique montrée ci‑dessus.

![Intervalle manuel des étiquettes de catégorie de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir l'axe et l'intervalle corrects**

Utilisez cet intervalle de comptage des catégories pour un axe de catégorie texte, tel que l'axe de catégorie d'un diagramme à colonnes, lignes, aires ou barres. Dans un diagramme à colonnes, il s'agit de l'axe horizontal. Dans un diagramme à barres horizontales, l'axe de catégorie est vertical, donc appliquez ces réglages à [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). L'espacement des marques de repère s'applique également à un axe de séries dans les diagrammes qui en possèdent un.

N'utilisez pas l'espacement des étiquettes de catégorie pour définir l'échelle numérique d'un axe de valeur. Sur un axe de valeur, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) indique une différence de valeurs : par ex., une unité majeure de `10` produit des marques à 0, 10, 20, etc. lorsqu’on part de zéro. Un intervalle d'étiquette de catégorie de `3` compte les positions de catégorie, quelle que soit leur valeur. Les diagrammes à nuage et à bulles utilisent des axes de valeur plutôt qu'un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures basées sur le temps et des échelles comme décrit dans [Modifier un axe de catégorie](#change-a-category-axis).

## **Définir le format de date pour les valeurs d'axe de catégorie**

L'exemple remplace les données de diagramme par défaut par quatre valeurs annuelles. Les dates sont stockées sous forme de nombres de série OLE Automation dans la première feuille de calcul (index `0`). Définissez [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) sur un axe de date, désactivez [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), et attribuez `yyyy` à [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) afin que les étiquettes de catégorie affichent les années sur quatre chiffres indépendamment du format de cellule.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Définir un angle de rotation pour le titre d'un axe de diagramme**

Activez [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) sur l'axe vertical, fournissez le texte du titre, et réglez [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) pour faire pivoter le titre. L'angle est mesuré en degrés ; cet exemple enregistre un diagramme à colonnes avec le titre de l'axe de valeur pivoté de 90 degrés.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Définir la position de l'axe sur un axe de catégorie ou de valeur**

Utilisez [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) pour contrôler si l'axe de valeur coupe l'axe de catégorie entre les catégories ou aux marques de catégorie. Cette propriété s'applique aux axes de catégorie. L'exemple la définit sur `true` pour l'axe de catégorie horizontal d'un diagramme à colonnes et enregistre le résultat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Définir l'unité d'affichage sur un axe de valeur de diagramme**

Définissez [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) pour mettre à l’échelle les étiquettes d’un axe de valeur sans modifier les données sous‑jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) réglé sur `Millions`, une valeur de 60 000 000 s’affiche comme 60. L'exemple crée un diagramme à colonnes et applique l’unité d’affichage « Millions » à son axe vertical.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement des axes) ?**

Utilisez [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) pour choisir le comportement du croisement. Pour spécifier une valeur numérique de croisement, définissez [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Ces réglages vous permettent de déplacer le croisement de l'axe vers une ligne de base adaptée.

**Comment positionner les étiquettes des marques de repère par rapport à l'axe ?**

Définissez [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) à l’aide de [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) : `Low`, `High`, `NextTo` ou `None`. Pour contrôler les marques de repère elles‑mêmes, utilisez [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) ou [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) ; ils sont séparés du positionnement des étiquettes.