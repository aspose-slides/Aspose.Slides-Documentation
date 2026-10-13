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
- ligne de l'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides pour .NET afin de personnaliser les axes des graphiques dans les présentations PowerPoint destinées aux rapports et aux visualisations."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les axes des graphiques avec Aspose.Slides pour .NET. Il couvre les valeurs d'axe calculées, l'échange des lignes et colonnes du graphique, la visibilité des axes, les intervalles des étiquettes de catégorie et des marques de graduation, les catégories de dates et leur mise en forme, la rotation du titre, le positionnement des axes, les unités d'affichage et le redimensionnement logarithmique.

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**

Créez une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et ajoutez un graphique en aires avec les données par défaut. Appelez [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) avant de lire les valeurs d'axe calculées afin que la disposition du graphique soit à jour.

Lisez [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) et [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) pour les limites de l'axe, ainsi que [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) et [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) pour les intervalles des graduations. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) et [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) fournissent des échelles d'unités de temps, pertinentes pour les axes de dates. L'exemple stocke ces valeurs dans des variables locales et enregistre le graphique.

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

Utilisez [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) pour échanger les rôles des séries et des catégories dans les données du graphique. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie la façon dont les données sont groupées ; cela n'échange pas les axes horizontal et vertical. L'exemple utilise [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) pour lier les données par défaut à `Sheet1!A1:D5`, y compris la ligne d'en-tête et la colonne de catégorie, avant d'échanger les lignes et les colonnes. Il enregistre un graphique avec quatre séries et trois catégories.

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

## **Désactiver l'axe vertical pour les graphiques linéaires**

Définissez [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) sur `false` sur l'axe vertical pour le masquer. L'exemple crée un graphique linéaire avec les données par défaut et l'enregistre avec l'axe vertical masqué.

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

## **Désactiver l'axe horizontal pour les graphiques linéaires**

Définissez [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) sur `false` sur l'axe horizontal pour le masquer. L'exemple crée un graphique linéaire avec les données par défaut et l'enregistre avec l'axe horizontal masqué.

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

Définissez [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) pour choisir un axe de catégorie date ou texte. Cet exemple nécessite `ExistingChart.pptx`, avec un graphique comme première forme de la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il modifie l'axe horizontal en un axe de date. La définition de [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) sur `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) sur `1` et [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) sur months place les graduations majeures à des intervalles d'un mois.

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

## **Contrôler les intervalles des étiquettes de l'axe de catégorie**

Lorsqu'un graphique possède de nombreuses catégories, réduisez le nombre d'étiquettes d'axe visibles sans supprimer les catégories ou les points de données. Définissez [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) sur `false`, puis définissez [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) sur l'intervalle de catégorie souhaité. Pour les catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Étiquettes affichées dans l'exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, ... Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, ... Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, ... Catégorie 22 |

L'intervalle `3` affiche chaque troisième étiquette, laissant deux étiquettes masquées entre les étiquettes affichées. Il ne supprime pas les colonnes correspondantes. L'espacement automatique choisit un intervalle en fonction de l'espace disponible ; il n'affiche pas forcément chaque étiquette.

Les marques de graduation ont des contrôles séparés. Définissez [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) sur `false` et utilisez [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) pour définir leur intervalle. Par exemple, `1` conserve une marque de graduation à chaque intervalle de catégorie tandis que les étiquettes n'apparaissent qu'à chaque troisième catégorie. Définissez [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) sur un style visible pour voir le résultat. Rétablir l'une des propriétés d'espacement automatique à `true` permet au graphique de choisir à nouveau cet intervalle.

L'exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement manuel des étiquettes avec marques de graduation indépendantes, et restauration de l'espacement automatique. Les deux copies conservent les données originales du graphique. aucune présentation d'entrée n'est requise. Le texte des étiquettes horizontales rend la différence de densité facile à voir.

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

// Diapositive 2: afficher chaque troisième étiquette, mais conserver une marque de graduation pour chaque catégorie.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Diapositive 3: laisser le graphique choisir les deux intervalles à nouveau.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Espacement automatique (diapositive 1) :** Dans ce rendu, chaque deuxième étiquette de catégorie est affichée et se répartit sur deux lignes. Le résultat automatique peut varier selon la taille du graphique, les polices et le moteur de rendu.

![Espacement automatique des étiquettes de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** Chaque troisième étiquette est affichée sur une ligne, tandis que les marques de graduation restent à chaque intervalle de catégorie. Les 24 colonnes, y compris celles sans étiquette, restent visibles avec les mêmes valeurs. La diapositive 3 restaure l'apparence automatique présentée ci‑dessus.

![Intervalle manuel des étiquettes de catégorie de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir l'axe et l'intervalle corrects**

Utilisez cet intervalle de comptage de catégorie pour un axe de catégorie texte, tel que l'axe de catégorie d'un graphique en colonnes, lignes, aires ou barres. Dans un graphique en colonnes, il s'agit de l'axe horizontal. Dans un graphique à barres horizontales, l'axe de catégorie est vertical, il faut donc appliquer ces paramètres à [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). L'espacement des marques de graduation s'applique également à un axe de séries dans les graphiques qui en possèdent un.

Ne pas utiliser l'espacement des étiquettes de catégorie pour définir l'échelle numérique d'un axe de valeur. Sur un axe de valeur, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) spécifie une différence de valeurs : par exemple, une unité majeure de `10` produit des graduations à 0, 10, 20, etc. lorsqu'un axe commence à zéro. Un intervalle d'étiquette de catégorie de `3` compte les positions de catégorie, indépendamment de leurs valeurs de données. Les graphiques en nuage de points et en bulles utilisent des axes de valeur plutôt qu'un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures et des échelles basées sur le temps comme décrit dans [Modifier un axe de catégorie](#change-a-category-axis).

## **Définir le format de date pour les valeurs de l'axe de catégorie**

L'exemple remplace les données de graphique par défaut par quatre valeurs annuelles. Les dates sont stockées sous forme de nombres décimaux OLE Automation dans la première feuille de calcul (index `0`). Définissez [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) sur un axe de date, désactivez [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), et attribuez `yyyy` à [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) pour que les étiquettes de catégorie affichent les années à quatre chiffres indépendamment du format de la cellule.

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

Activez [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) sur l'axe vertical, fournissez le texte du titre, et définissez [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) pour faire pivoter le titre. L'angle est mesuré en degrés ; cet exemple enregistre un graphique en colonnes avec le titre de l'axe des valeurs pivoté de 90 degrés.

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

Utilisez [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) pour contrôler si l'axe de valeur traverse l'axe de catégorie entre les catégories ou aux marques de graduation des catégories. Cette propriété s'applique aux axes de catégorie. L'exemple la définit sur `true` sur l'axe de catégorie horizontal d'un graphique en colonnes et enregistre le résultat.

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

Définissez [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) pour mettre à l'échelle les étiquettes d'un axe de valeur sans modifier les données sous-jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) réglé sur `Millions`, une valeur de 60 000 000 s'affiche comme 60. L'exemple crée un graphique en colonnes et applique l'unité d'affichage millions à son axe vertical.

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

Un axe de valeur logarithmique est utile lorsque des valeurs positives couvrent plusieurs ordres de grandeur. Par exemple, un service peut recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent proches les unes des autres près de zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Définissez [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) sur `true` sur l'axe de valeur et utilisez [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) pour choisir la base. Cela modifie la façon dont les valeurs existantes sont affichées ; cela ne change pas les données ni n'ajoute une courbe de tendance logarithmique. Une courbe de tendance représente une relation ajustée aux données et constitue une fonctionnalité distincte.

### **Choisir l'axe de valeur et la base**

Pour un graphique en lignes ou en colonnes, l'axe de valeur est [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Pour un graphique à barres horizontales, il s'agit de [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Les graphiques en nuage de points et en bulles disposent de deux axes de valeur, il faut donc choisir l'axe horizontal pour les valeurs X, l'axe vertical pour les valeurs Y, ou les deux. N'appliquez pas de mise à l'échelle logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les graphiques PPTX, utilisez une base comprise entre `2` et `1000`, inclus ; les bases fractionnaires telles que `2.5` sont également prises en charge. Avec la base `10`, les puissances successives comme 10, 100, 1 000 et 10 000 sont espacées uniformément.

### **Comparer la mise à l'échelle linéaire et logarithmique**

L'exemple autonome suivant crée un graphique linéaire avec les cinq décomptes de requêtes sur la première diapositive, puis duplique cette diapositive et active un axe de valeur logarithmique base 10 sur la seconde. Les deux diapositives conservent les mêmes données.

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

// Conserver la première diapositive linéaire et ne modifier que l'échelle de l'axe des valeurs de la copie.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Échelle linéaire (diapositive 1) :** Des distances verticales égales représentent des différences égales dans les décomptes de requêtes. La plus grande valeur domine le graphique, rendant les valeurs plus petites difficiles à distinguer.

![Graphique linéaire dans PowerPoint montrant cinq décomptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2) :** Des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, de sorte que les points forment une ligne droite ascendante sur l'échelle base 10. Les étiquettes d'axe affichent toujours les décomptes de requêtes originaux.

![Les mêmes cinq décomptes de requêtes dans PowerPoint sur un axe de valeur logarithmique base 10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l'activer. Si les valeurs zéro ou négatives sont pertinentes, conservez une échelle linéaire ou affichez‑les séparément. Si l'exclusion de ces valeurs est appropriée pour l'analyse, expliquez l'omission. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela modifie le sens des données. Toute valeur minimale ou maximale configurée manuellement pour un axe logarithmique doit également être positive.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axes) ?**

Utilisez [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) pour sélectionner le comportement de croisement. Pour spécifier une valeur numérique de croisement, définissez [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Ces paramètres vous permettent de déplacer le croisement des axes vers une ligne de base appropriée.

**Comment positionner les étiquettes de graduation par rapport à l'axe ?**

Définissez [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) en utilisant [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) : `Low`, `High`, `NextTo` ou `None`. Pour contrôler les marques de graduation elles‑mêmes, utilisez [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) ou [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) ; elles sont distinctes du positionnement des étiquettes.