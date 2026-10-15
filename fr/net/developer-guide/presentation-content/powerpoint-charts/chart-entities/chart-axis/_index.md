---
title: Personnaliser les axes des graphiques dans les présentations en .NET
linktitle: Axe du graphique
type: docs
url: /fr/net/chart-axis/
keywords:
- axe du graphique
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
description: "Découvrez comment utiliser Aspose.Slides pour .NET afin de personnaliser les axes des graphiques dans les présentations PowerPoint pour les rapports et les visualisations."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les axes de graphique avec Aspose.Slides pour .NET. Il couvre les valeurs d'axe calculées, l'échange des lignes et colonnes du graphique, la visibilité des axes, les intervalles des libellés de catégorie et des marques de graduation, les catégories de dates et leur formatage, la rotation du titre, le positionnement des axes, les unités d'affichage et la mise à l'échelle logarithmique.

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**

Créez une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et ajoutez un graphique en aires avec les données par défaut. Appelez [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) avant de lire les valeurs d'axe calculées afin que la disposition du graphique soit à jour.

Lisez [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) et [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) pour les limites de l'axe, et [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) et [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) pour les intervalles des graduations. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) et [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) fournissent des échelles d'unité de temps, pertinentes pour les axes de dates. L'exemple stocke ces valeurs dans des variables locales et enregistre le graphique.

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

Utilisez [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) pour échanger les rôles des séries et des catégories dans les données du graphique. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie la façon dont les données sont groupées ; cela n'échange pas les axes horizontal et vertical. L'exemple utilise [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) pour lier les données par défaut à `Sheet1!A1:D5`, en incluant la ligne d'en-tête et la colonne de catégorie, avant d'échanger les lignes et les colonnes. Il enregistre un graphique avec quatre séries et trois catégories.

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

## **Inverser l'ordre de tracé d'un axe**

Utilisez [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) pour inverser un axe de catégorie ou de valeur. Par exemple, un graphique à barres horizontales peut afficher les étapes du projet de haut en bas dans le même ordre que la feuille de calcul : Planning, Development, Testing. Inverser un axe change la direction du tracé ; cela ne trie pas et ne réarrange pas les données du classeur. En comparaison, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) échange les rôles des séries et des catégories.

L'exemple suivant crée un graphique à barres horizontales avec trois étapes et une série. Il enregistre une présentation avec trois diapositives : ordre normal, catégories inversées et valeurs inversées. Chaque copie utilise le même jeu de données, et un seul axe est inversé dans chaque copie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Diapositive 2: afficher la première catégorie en haut.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Conserver l'axe de valeur horizontal en bas.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Diapositive 3: inverser uniquement l'échelle numérique horizontale.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Inverser un axe peut également déplacer l'axe perpendiculaire du côté opposé du tracé. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) contrôle où l'autre axe croise l'axe configuré. Dans la diapositive 2, le définir sur `Maximum` sur l'axe de catégorie inversé maintient l'axe de valeur horizontal en bas. Pour un point de croisement spécifique, utilisez [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Vérifiez les paramètres de croisement lors du changement de direction, surtout si le graphique possède déjà un point de croisement personnalisé. Réglez `IsPlotOrderReversed` sur `false` pour restaurer la direction de tracé normale ; les paramètres de croisement sont distincts.

| Ordre normal (diapositive 1) | Catégories inversées (diapositive 2) | Valeurs inversées (diapositive 3) |
| --- | --- | --- |
| ![Graphique à barres horizontales avec ordre normal des axes de catégorie et de valeur](axis-order-normal.png) | ![Graphique à barres horizontales avec les catégories affichées de haut en bas](axis-order-categories-reversed.png) | ![Graphique à barres horizontales avec un axe de valeur inversé et zéro à droite](axis-order-values-reversed.png) |
| Les catégories s'étendent du bas vers le haut ; les valeurs augmentent de gauche à droite. | Planning, Development et Testing s'étendent de haut en bas. Les valeurs et l'ordre des lignes du classeur restent inchangés. | Les catégories conservent leur ordre normal ; les valeurs augmentent de droite à gauche. L'axe de catégorie croise à zéro à droite. |

## **Désactiver l'axe vertical pour les graphiques en courbes**

Définissez [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) sur `false` sur l'axe vertical pour le masquer. L'exemple crée un graphique en courbes avec les données par défaut et l'enregistre avec l'axe vertical masqué.

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

## **Désactiver l'axe horizontal pour les graphiques en courbes**

Définissez [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) sur `false` sur l'axe horizontal pour le masquer. L'exemple crée un graphique en courbes avec les données par défaut et l'enregistre avec l'axe horizontal masqué.

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

Définissez [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) pour choisir un axe de catégorie de type date ou texte. Cet exemple nécessite `ExistingChart.pptx`, avec un graphique comme première forme de la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il change l'axe horizontal en axe de date. Définir [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) sur `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) sur `1` et [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) sur mois place les graduations majeures à intervalles d'un mois.

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

## **Contrôler les intervalles des libellés d'axe de catégorie**

Lorsqu'un graphique possède de nombreuses catégories, réduisez le nombre de libellés d'axe visibles sans supprimer les catégories ni les points de données. Définissez [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) sur `false`, puis définissez [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) sur l'intervalle de catégorie souhaité. Pour les catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Libellés affichés dans l'exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, ... Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, ... Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, ... Catégorie 22 |

Un intervalle de `3` affiche chaque troisième libellé, laissant deux libellés masqués entre les libellés affichés. Il ne supprime pas les colonnes correspondantes. L'espacement automatique choisit un intervalle en fonction de l'espace disponible ; il n'affiche pas nécessairement chaque libellé.

Les marques de graduation ont des contrôles séparés. Définissez [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) sur `false` et utilisez [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) pour définir leur intervalle. Par exemple, `1` maintient une marque de graduation à chaque intervalle de catégorie tandis que les libellés n'apparaissent qu'à chaque troisième catégorie. Définissez [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) sur un style visible pour voir le résultat. Rétablir l'une ou l'autre propriété d'espacement automatique à `true` permet au graphique de choisir à nouveau cet intervalle.

L'exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement manuel des libellés avec marques de graduation indépendantes, et restauration de l'espacement automatique. Les deux copies conservent les données originales du graphique. Aucun diaporama d'entrée n'est requis. Le texte horizontal des libellés rend la différence de densité facile à percevoir.

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

// Diapositive 2 : afficher chaque troisième libellé, mais conserver une marque de graduation pour chaque catégorie.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Diapositive 3 : laisser le graphique choisir à nouveau les deux intervalles.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Espacement automatique (diapositive 1) :** Dans ce rendu, chaque deuxième libellé de catégorie est affiché et se replie sur deux lignes. Le résultat automatique peut varier selon la taille du graphique, les polices et le moteur de rendu.

![Espacement automatique des libellés de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** Chaque troisième libellé est affiché sur une ligne, tandis que les marques de graduation restent à chaque intervalle de catégorie. Les 24 colonnes, y compris celles sans libellés, restent visibles avec les mêmes valeurs. La diapositive 3 restaure l'apparence automatique montrée ci‑dessus.

![Intervalle manuel des libellés de catégorie de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir l'axe et l'intervalle corrects**

Utilisez cet intervalle de comptage de catégories pour un axe de catégorie texte, comme l'axe de catégorie d'un graphique à colonnes, en courbes, en aires ou à barres. Dans un graphique à colonnes, il s'agit de l'axe horizontal. Dans un graphique à barres horizontales, l'axe de catégorie est vertical, donc appliquez ces paramètres à [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). L'espacement des marques de graduation s'applique également à un axe de séries dans les graphiques qui en possèdent un.

N'utilisez pas l'espacement des libellés de catégorie pour définir l'échelle numérique d'un axe de valeur. Sur un axe de valeur, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) spécifie une différence entre les valeurs : par exemple, une unité majeure de `10` génère des graduations à 0, 10, 20, etc. lorsqu'un axe commence à zéro. Un intervalle de libellés de catégorie de `3` compte les positions de catégorie, indépendamment de leurs valeurs de données. Les graphiques en nuage de points et à bulles utilisent des axes de valeur plutôt qu'un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures et des échelles basées sur le temps comme décrit dans [Change a Category Axis](#change-a-category-axis).

## **Définir le format de date pour les valeurs d'axe de catégorie**

L'exemple remplace les données de graphique par défaut par quatre valeurs annuelles. Les dates sont stockées comme numéros de série OLE Automation dans la première feuille de calcul (index `0`). Définissez [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) sur un axe de date, désactivez [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), et assignez `yyyy` à [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) afin que les libellés de catégorie affichent des années à quatre chiffres indépendamment du format de la cellule.

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

## **Définir un angle de rotation pour le titre d'un axe de graphique**

Activez [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) sur l'axe vertical, fournissez le texte du titre et définissez [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) pour faire pivoter le titre. L'angle est mesuré en degrés ; cet exemple enregistre un graphique à colonnes avec le titre de l'axe de valeur pivoté à 90 degrés.

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

Utilisez [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) pour contrôler si l'axe de valeur croise l'axe de catégorie entre les catégories ou aux marques de graduation de catégorie. Cette propriété s'applique aux axes de catégorie. L'exemple le définit sur `true` sur l'axe de catégorie horizontal d'un graphique à colonnes et enregistre le résultat.

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

## **Définir l'unité d'affichage sur un axe de valeur de graphique**

Définissez [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) pour mettre à l'échelle les libellés d'un axe de valeur sans modifier les données sous-jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) défini sur `Millions`, une valeur de 60 000 000 s'affiche comme 60. L'exemple crée un graphique à colonnes et applique l'unité d'affichage en millions à son axe vertical.

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

## **Configurer un axe de valeur logarithmique**

Un axe de valeur logarithmique est utile lorsque les valeurs positives s'étendent sur plusieurs ordres de grandeur. Par exemple, un service peut recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent très proches du zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Définissez [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) sur `true` sur l'axe de valeur et utilisez [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) pour choisir la base. Cela modifie l'affichage des valeurs existantes ; cela ne change pas les données ni n'ajoute une ligne de tendance logarithmique. Une ligne de tendance représente une relation ajustée aux données et constitue une fonctionnalité distincte.

### **Choisir l'axe de valeur et la base**

Pour un graphique en courbes ou à colonnes, l'axe de valeur est [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Pour un graphique à barres horizontales, il s'agit de [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Les graphiques en nuage de points et à bulles possèdent deux axes de valeur, donc choisissez l'axe horizontal pour les valeurs X, l'axe vertical pour les valeurs Y, ou les deux. N'appliquez pas la mise à l'échelle logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les graphiques PPTX, utilisez une base comprise entre `2` et `1000`, inclusive ; les bases fractionnaires comme `2.5` sont également prises en charge. Avec la base `10`, les puissances successives telles que 10, 100, 1 000 et 10 000 sont également espacées.

### **Comparer la mise à l'échelle linéaire et logarithmique**

L'exemple autonome suivant crée un graphique en courbes avec les cinq décomptes de requêtes sur la première diapositive, puis clone cette diapositive et active un axe de valeur logarithmique base‑10 sur la seconde. Les deux diapositives conservent les mêmes données.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Conserver la première diapositive en linéaire et modifier uniquement l'échelle de l'axe des valeurs de la copie.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Échelle linéaire (diapositive 1) :** Des distances verticales égales représentent des différences égales dans les décomptes de requêtes. La valeur la plus grande domine le graphique, rendant les petites valeurs difficiles à distinguer.

![Graphique en courbes dans PowerPoint montrant cinq décomptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2) :** Des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, ainsi les points forment une ligne droite ascendante sur l'échelle base‑10. Les libellés d'axe affichent toujours les décomptes de requêtes originaux.

![Les mêmes cinq décomptes de requêtes dans PowerPoint sur un axe de valeur logarithmique base‑10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l'activer. Si les valeurs zéro ou négatives sont significatives, conservez une échelle linéaire ou affichez‑les séparément. Si l'exclusion de ces valeurs est appropriée pour l'analyse, expliquez l'omission. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela change la signification des données. Tout minimum ou maximum configuré manuellement pour un axe logarithmique doit également être positif.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axe) ?**  
Utilisez [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) pour sélectionner le comportement de croisement. Pour spécifier une valeur de croisement numérique, définissez [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Ces paramètres vous permettent de déplacer le croisement des axes vers une ligne de base appropriée.

**Comment positionner les libellés de graduation par rapport à l'axe ?**  
Définissez [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) en utilisant [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Pour contrôler les marques de graduation elles‑mêmes, utilisez [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) ou [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); elles sont distinctes du positionnement des libellés.