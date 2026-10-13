---
title: Personnaliser les axes de graphiques dans les présentations à l'aide de JavaScript
linktitle: Axe du graphique
type: docs
url: /fr/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez comment utiliser JavaScript avec Aspose.Slides pour Node.js via Java afin de personnaliser les axes de graphiques dans les présentations PowerPoint pour les rapports et les visualisations."
---
## **Aperçu**

Cet article explique comment personnaliser les axes des graphiques avec Aspose.Slides pour Node.js via Java. Il couvre les valeurs d'axe calculées, l'échange des lignes et colonnes du graphique, la visibilité des axes, les intervalles des libellés de catégorie et des marques de graduation, les catégories de date et leur formatage, la rotation du titre, le positionnement des axes, les unités d'affichage et le redimensionnement logarithmique.

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**

Créez une [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et ajoutez un graphique en aires avec des données par défaut. Appelez [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) avant de lire les valeurs d'axe calculées afin que la disposition du graphique soit à jour.

Lisez [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) et [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) pour les limites de l'axe, et [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) et [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) pour les intervalles des graduations. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) et [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) fournissent des échelles d'unités de temps, pertinentes pour les axes de date. L'exemple stocke ces valeurs dans des variables locales et enregistre le graphique.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Échanger les données entre les axes**

Utilisez [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) pour échanger les rôles des séries et des catégories dans les données du graphique. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie la façon dont les données sont groupées ; cela n'échange pas les axes horizontal et vertical. L'exemple utilise [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) pour lier les données par défaut à `Sheet1!A1:D5`, y compris la ligne d’en-tête et la colonne de catégorie, avant d’échanger les lignes et colonnes. Il enregistre un graphique avec quatre séries et trois catégories.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Désactiver l'axe vertical pour les graphiques en courbes**

Appelez [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) avec `false` sur l'axe vertical pour le masquer. L'exemple crée un graphique en courbes avec des données par défaut et l’enregistre avec l'axe vertical masqué.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Désactiver l'axe horizontal pour les graphiques en courbes**

Appelez [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) avec `false` sur l'axe horizontal pour le masquer. L'exemple crée un graphique en courbes avec des données par défaut et l’enregistre avec l'axe horizontal masqué.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifier un axe de catégorie**

Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) pour choisir un axe de catégorie de type date ou texte. Cet exemple nécessite `ExistingChart.pptx`, avec un graphique comme première forme de la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il convertit l'axe horizontal en axe de date. En appelant [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) avec `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) avec `1` et [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) avec `TimeUnitType.Months`, les graduations majeures sont placées à des intervalles d'un mois.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler les intervalles des libellés de l'axe de catégorie**

Lorsque un graphique possède de nombreuses catégories, réduisez le nombre de libellés d'axe visibles sans supprimer de catégories ou de points de données. Appelez [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) avec `false`, puis transmettez l'intervalle de catégorie souhaité à [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Pour les catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Libellés affichés dans l'exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, ... Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, ... Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, ... Catégorie 22 |

Un intervalle de `3` affiche chaque troisième libellé, laissant deux libellés masqués entre les libellés affichés. Cela ne supprime pas les colonnes correspondantes. Le espacement automatique choisit un intervalle en fonction de l'espace disponible ; il n'affiche pas forcément chaque libellé.

Les marques de graduation ont des contrôles séparés. Appelez [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) avec `false` et utilisez [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) pour définir leur intervalle. Par exemple, `1` conserve une marque à chaque intervalle de catégorie tandis que les libellés n'apparaissent que toutes les trois catégories. Utilisez [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) avec un style visible pour voir le résultat. Repasser le réglage d'espacement automatique à `true` permet au graphique de choisir de nouveau cet intervalle.

L'exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement manuel des libellés avec marques de graduation indépendantes, et restauration de l'espacement automatique. Les deux copies conservent les données d'origine du graphique. Aucune présentation d'entrée n'est requise. Le texte des libellés horizontaux rend la différence de densité facile à voir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Diapositive 2 : afficher chaque troisième libellé, mais garder une marque de graduation pour chaque catégorie.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Diapositive 3 : laisser le graphique choisir à nouveau les deux intervalles.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Espacement automatique (diapositive 1) :** Dans ce rendu, chaque deuxième libellé de catégorie est affiché et se répartit sur deux lignes. Le résultat automatique peut varier selon la taille du graphique, les polices et le moteur de rendu.

![Espacement automatique des libellés de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** Chaque troisième libellé est affiché sur une ligne, tandis que les marques de graduation restent à chaque intervalle de catégorie. Toutes les 24 colonnes, y compris celles sans libellé, restent visibles avec les mêmes valeurs. La diapositive 3 restaure l'apparence automatique présentée ci‑dessus.

![Intervalle manuel du libellé de catégorie de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir l'axe et l'intervalle corrects**

Utilisez cet intervalle de comptage des catégories pour un axe de catégorie texte, tel que l'axe de catégorie d'un graphique à colonnes, en courbes, en aires ou à barres. Dans un graphique à colonnes, c'est l'axe horizontal. Dans un graphique à barres horizontal, l'axe de catégorie est vertical, donc appliquez ces paramètres à l'axe retourné par [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). L'espacement des marques de graduation s'applique également à un axe de série dans les graphiques qui en possèdent un.

N'utilisez pas l'espacement des libellés de catégorie pour définir l'échelle numérique d'un axe de valeur. Sur un axe de valeur, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) spécifie une différence de valeurs : par exemple, une unité majeure de `10` produit des graduations à 0, 10, 20, etc. lorsqu'il commence à zéro. Un intervalle de libellé de catégorie de `3` compte les positions de catégorie, indépendamment de leurs valeurs. Les graphiques en nuage de points et à bulles utilisent des axes de valeur plutôt qu'un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures et des échelles basées sur le temps comme décrit dans [Modifier un axe de catégorie](#change-a-category-axis).

## **Définir le format de date pour les valeurs de l'axe de catégorie**

L'exemple remplace les données de graphique par défaut par quatre valeurs annuelles. Les dates sont stockées comme nombres de série OLE Automation dans la première feuille de calcul (indice `0`), calculées comme le nombre de jours depuis le 30 décembre 1899 pour ces dates. Le calcul JavaScript utilise les horodatages UTC et divise la différence par 86 400 000 millisecondes par jour. Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) avec `CategoryAxisType.Date`, appelez [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) avec `false`, et transmettez `yyyy` à [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) pour que les libellés de catégorie affichent les années sur quatre chiffres indépendamment du format de cellule.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir un angle de rotation pour le titre d'un axe de graphique**

Appelez [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) avec `true` sur l'axe vertical, fournissez le texte du titre, et utilisez [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) pour le faire pivoter. L'angle est mesuré en degrés ; cet exemple enregistre un graphique à colonnes avec le titre de l'axe de valeur tourné de 90 degrés.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la position de l'axe sur un axe de catégorie ou de valeur**

Utilisez [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) pour contrôler si l'axe de valeur croise l'axe de catégorie entre les catégories ou aux marques de catégorie. Ce réglage s'applique aux axes de catégorie. L'exemple le définit sur `true` pour l'axe de catégorie horizontal d'un graphique à colonnes et enregistre le résultat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l'unité d'affichage sur un axe de valeur du graphique**

Utilisez [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) pour mettre à l'échelle les libellés d'un axe de valeur sans modifier les données sous‑jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) réglé sur `Millions`, une valeur de 60 000 000 s'affiche sous la forme 60. L'exemple crée un graphique à colonnes et applique l'unité d'affichage « Millions » à son axe vertical.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Configurer un axe de valeur logarithmique**

Un axe de valeur logarithmique est utile lorsque des valeurs positives s'étendent sur plusieurs ordres de grandeur. Par exemple, un service pourrait recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes au cours de cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent très proches du zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Appelez [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) avec `true` sur l'axe de valeur et utilisez [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) pour choisir la base. Cela modifie la façon dont les valeurs existantes sont affichées ; cela ne change pas les données ni n'ajoute de ligne de tendance logarithmique. Une ligne de tendance représente une relation ajustée aux données et constitue une fonctionnalité distincte.

### **Choisir l'axe de valeur et la base**

Pour un graphique en courbes ou à colonnes, l'axe de valeur est retourné par [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Pour un graphique à barres horizontal, il est retourné par [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Les graphiques en nuage de points et à bulles ont deux axes de valeur, choisissez donc l'axe horizontal pour les valeurs X, l'axe vertical pour les valeurs Y, ou les deux. N’appliquez pas le redimensionnement logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les graphiques PPTX, utilisez une base comprise entre `2` et `1000` inclusivement ; les bases fractionnaires comme `2.5` sont également prises en charge. Avec la base `10`, les puissances successives telles que 10, 100, 1 000 et 10 000 sont espacées de façon égale.

### **Comparer le redimensionnement linéaire et logarithmique**

L'exemple autonome suivant crée un graphique en courbes avec les cinq comptages de requêtes sur la première diapositive, puis duplique cette diapositive et active un axe de valeur logarithmique base‑10 sur la seconde. Les deux diapositives conservent les mêmes données.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Conserver la première diapositive en linéaire et ne modifier que l'échelle de l'axe de valeur de la copie.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Échelle linéaire (diapositive 1) :** Des distances verticales égales représentent des différences égales dans les comptages de requêtes. La valeur la plus grande domine le graphique, rendant les petites valeurs difficiles à distinguer.

![Graphique en courbes PowerPoint montrant cinq décomptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2) :** Des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, de sorte que les points forment une ligne droite ascendante sur l’échelle base‑10. Les libellés d'axe affichent toujours les comptages de requêtes d'origine.

![Les mêmes cinq décomptes de requêtes dans PowerPoint sur un axe de valeur logarithmique base‑10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l’activer. Si les valeurs zéro ou négatives sont significatives, conservez une échelle linéaire ou affichez‑les séparément. Si les exclure est approprié pour l’analyse, expliquez cette omission. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela changerait le sens des données. Tout minimum ou maximum configuré manuellement pour un axe logarithmique doit également être positif.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axes) ?**

Utilisez [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) pour choisir le comportement de croisement. Pour spécifier une valeur de croisement numérique, utilisez [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Ces paramètres vous permettent de déplacer le croisement des axes vers une ligne de base appropriée.

**Comment positionner les libellés des graduations par rapport à l'axe ?**

Appelez [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) en utilisant [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Pour contrôler les marques de graduation elles‑mêmes, utilisez [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) ou [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); ceux‑ci sont distincts du positionnement des libellés.