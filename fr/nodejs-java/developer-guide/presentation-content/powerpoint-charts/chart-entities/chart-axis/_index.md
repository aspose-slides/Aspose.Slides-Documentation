---
title: Personnaliser les axes des graphiques dans les présentations avec JavaScript
linktitle: Axe du graphique
type: docs
url: /fr/nodejs-java/chart-axis/
keywords:
- axe de graphique
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
description: "Découvrez comment utiliser JavaScript avec Aspose.Slides pour Node.js via Java afin de personnaliser les axes des graphiques dans les présentations PowerPoint pour les rapports et les visualisations."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les axes de diagrammes avec Aspose.Slides for Node.js via Java. Il couvre les valeurs d'axe calculées, l'échange des lignes et colonnes du diagramme, la visibilité des axes, les intervalles des étiquettes de catégorie et des marques de graduation, les catégories de dates et leur formatage, la rotation du titre, le positionnement des axes, les unités d'affichage et la mise à l'échelle logarithmique.

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**

Créez une [Présentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et ajoutez un diagramme de zone avec des données par défaut. Appelez [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) avant de lire les valeurs d'axe calculées afin que la disposition du diagramme soit à jour.

Lisez [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) et [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) pour les limites de l'axe, et [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) et [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) pour les intervalles des marques. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) et [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) fournissent des échelles d'unités de temps, pertinentes pour les axes de dates. L'exemple stocke ces valeurs dans des variables locales et enregistre le diagramme.

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

Utilisez [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) pour échanger les rôles des séries et des catégories dans les données du diagramme. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie la façon dont les données sont groupées ; cela n'échange pas les axes horizontal et vertical. L'exemple utilise [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) pour lier les données par défaut à `Sheet1!A1:D5`, y compris la ligne d'en-tête et la colonne de catégorie, avant d'échanger les lignes et colonnes. Il enregistre un diagramme avec quatre séries et trois catégories.

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

## **Inverser l'ordre de tracé d'un axe**

Utilisez [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) pour inverser un axe de catégorie ou de valeur. Par exemple, un diagramme à barres horizontal peut afficher les étapes d'un projet de haut en bas dans le même ordre que la feuille de calcul : Planification, Développement, Test. Inverser un axe modifie la direction du traçage ; cela ne trie pas et ne réarrange pas les données du classeur. En comparaison, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) échange les rôles des séries et des catégories.

L'exemple suivant crée un diagramme à barres horizontal avec trois étapes et une série. Il enregistre une présentation avec trois diapositives : ordre normal, catégories inversées et valeurs inversées. Chaque copie utilise le même jeu de données, et un seul axe est inversé dans chaque copie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Diapositive 2 : afficher la première catégorie en haut.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Conserver l'axe de valeur horizontal en bas.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Diapositive 3 : inverser uniquement l'échelle numérique horizontale.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Inverser un axe peut également déplacer l'axe perpendiculaire du côté opposé du tracé. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) contrôle où l'autre axe croise l'axe configuré. Dans la diapositive 2, l'appeler avec `aspose.slides.CrossesType.Maximum` sur l'axe de catégorie inversé maintient l'axe de valeur horizontal en bas. Pour un point de croisement spécifique, utilisez [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Vérifiez les paramètres de croisement lors du changement de direction, surtout si le diagramme possède déjà un point de croisement personnalisé. Appelez `setPlotOrderReversed` avec `false` pour restaurer la direction de tracé normale ; les paramètres de croisement sont indépendants.

| Ordre normal (diapositive 1) | Catégories inversées (diapositive 2) | Valeurs inversées (diapositive 3) |
| --- | --- | --- |
| ![Diagramme à barres horizontal avec ordre normal des axes de catégorie et de valeur](axis-order-normal.png) | ![Diagramme à barres horizontal avec catégories affichées de haut en bas](axis-order-categories-reversed.png) | ![Diagramme à barres horizontal avec un axe de valeur inversé et zéro à droite](axis-order-values-reversed.png) |
| Les catégories vont du bas vers le haut ; les valeurs augmentent de gauche à droite. | Planification, Développement et Test vont de haut en bas. Les valeurs et l'ordre des lignes du classeur restent inchangés. | Les catégories conservent leur ordre normal ; les valeurs augmentent de droite à gauche. L'axe de catégorie croise à zéro à droite. |

## **Désactiver l'axe vertical pour les graphiques en lignes**

Appelez [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) avec `false` sur l'axe vertical pour le masquer. L'exemple crée un graphique en lignes avec des données par défaut et l'enregistre avec l'axe vertical masqué.

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

## **Désactiver l'axe horizontal pour les graphiques en lignes**

Appelez [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) avec `false` sur l'axe horizontal pour le masquer. L'exemple crée un graphique en lignes avec des données par défaut et l'enregistre avec l' axe horizontal masqué.

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

## **Afficher ou masquer les lignes de grille du diagramme**

Appelez [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) et [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) pour vérifier quelles lignes de grille un axe affiche. Pour afficher les lignes de grille mineures, utilisez [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) et définissez le remplissage de la ligne sur une couleur solide et visible. Pour les masquer, définissez le remplissage sur [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/). Utilisez [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) pour modifier le remplissage des lignes de grille majeures de la même manière. Modifier le remplissage préserve la visibilité de l'axe et les marques de graduation.

L'axe vertical de ce diagramme à colonnes groupées affiche initialement uniquement les lignes de grille majeures. L'exemple affiche les lignes de grille mineures en orange foncé, puis les masque à nouveau avant d'enregistrer la présentation. Il imprime la visibilité des lignes de grille à chaque étape.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Lignes de grille mineures affichées | Lignes de grille mineures masquées |
| --- | --- |
| ![Lignes de grille mineures orange entre les lignes de grille majeures sur l'axe vertical](minor-gridlines-enabled.png) | ![Même diagramme à colonnes avec seules les lignes de grille majeures visibles](minor-gridlines-hidden.png) |

## **Modifier un axe de catégorie**

Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) pour choisir un axe de catégorie de type date ou texte. Cet exemple nécessite `ExistingChart.pptx`, avec un diagramme comme première forme de la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il transforme l'axe horizontal en axe de date. En appelant [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) avec `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) avec `1`, et [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) avec `TimeUnitType.Months`, les marques majeures sont placées à intervalles d'un mois.

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

### **Déterminer le type d'axe de catégorie à partir des données**

Appelez [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) après avoir rempli les catégories, puis lisez [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) pour inspecter la sélection. Ceci est utile lorsque le même diagramme reçoit soit des étiquettes texte, soit des valeurs de date numériques. La méthode détermine le type au moment de l'appel ; elle n'active pas un mode persistant qui réévalue les changements de données ultérieurs. Appelez-la de nouveau après avoir remplacé les catégories.

L'exemple suivant crée un diagramme avec des catégories texte et affiche `true` lorsque le type sélectionné est `CategoryAxisType.Text`. Il remplace ensuite les valeurs des cellules de catégorie par des dates et rappelle la méthode, affichant `true` lorsque le type sélectionné est `CategoryAxisType.Date`. Les dates sont stockées en tant que valeurs numériques OLE Automation, calculées pour ces dates comme le nombre de jours depuis le 30 décembre 1899, plutôt que sous forme de chaînes de caractères. Le calcul JavaScript utilise des horodatages UTC et divise la différence par 86 400 000 millisecondes par jour ; les indices de mois sont à base zéro. Utilisez `java.newDouble` pour transmettre chaque valeur de date à Java sous forme de double. [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) contrôle la façon dont ces valeurs sont affichées ; il ne convertit pas le texte en dates numériques. Pour plus d'informations sur les cellules de catégorie, voir [Chart Workbook](/slides/fr/nodejs-java/chart-workbook/).

Utilisez la détermination automatique lorsque l'entrée est connue pour contenir des catégories texte ou des dates numériques, comme dans cet exemple. Pour des étiquettes numériques ordinaires, des catégories mixtes ou des données vides, appelez explicitement [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) pour correspondre à la signification prévue. Des valeurs numériques seules ne prouvent pas que les catégories représentent des dates.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // true

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler les intervalles des étiquettes d'axe de catégorie**

Lorsque un diagramme possède de nombreuses catégories, réduisez le nombre d'étiquettes d'axe visibles sans supprimer les catégories ou les points de données. Appelez [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) avec `false`, puis transmettez l'intervalle de catégorie souhaité à [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Pour des catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Étiquettes affichées dans l'exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, ... Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, ... Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, ... Catégorie 22 |

Un intervalle de `3` affiche chaque troisième étiquette, laissant deux étiquettes cachées entre les étiquettes affichées. Il ne supprime pas les colonnes correspondantes. L'espacement automatique choisit un intervalle en fonction de l'espace disponible ; il n'affiche pas nécessairement toutes les étiquettes.

Les marques de graduation ont des contrôles séparés. Appelez [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) avec `false` et utilisez [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) pour définir leur intervalle. Par exemple, `1` conserve une marque de graduation à chaque intervalle de catégorie tandis que les étiquettes n'apparaissent qu'à chaque troisième catégorie. Utilisez [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) avec un style visible pour voir le résultat. Appeler l'un ou l'autre des configureurs d'espacement automatique avec `true` permet de nouveau au diagramme de choisir cet intervalle.

L'exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement manuel des étiquettes avec marques de graduation indépendantes, et rétablissement de l'espacement automatique. Les deux copies conservent les données originales du diagramme. Aucune présentation d'entrée n'est requise. Le texte d'étiquette horizontal rend la différence de densité facile à percevoir.

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

    // Diapositive 2 : afficher chaque troisième étiquette, mais conserver une marque de graduation pour chaque catégorie.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Diapositive 3 : laisser le diagramme choisir à nouveau les deux intervalles.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Espacement automatique (diapositive 1) :** Dans ce rendu, chaque deuxième étiquette de catégorie est affichée et passe sur deux lignes. Le résultat automatique peut varier selon la taille du diagramme, les polices et le moteur de rendu.

![Espacement automatique des étiquettes de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** Chaque troisième étiquette est affichée sur une ligne, tandis que les marques de graduation restent à chaque intervalle de catégorie. Toutes les 24 colonnes, y compris celles sans étiquette, restent visibles avec les mêmes valeurs. La diapositive 3 rétablit l'apparence automatique montrée ci‑dessus.

![Intervalle manuel des étiquettes de catégorie de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir l'axe et l'intervalle corrects**

Utilisez cet intervalle de compte de catégories pour un axe de catégorie texte, comme l'axe de catégorie d'un diagramme à colonnes, lignes, zones ou barres. Dans un diagramme à colonnes, il s'agit de l'axe horizontal. Dans un diagramme à barres horizontal, l'axe de catégorie est vertical, donc appliquez ces paramètres à l'axe retourné par [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). L'espacement des marques de graduation s'applique également à un axe de séries dans les diagrammes qui en possèdent un.

N'utilisez pas l'espacement des étiquettes de catégorie pour définir l'échelle numérique d'un axe de valeur. Sur un axe de valeur, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) spécifie une différence de valeurs : par exemple, une unité majeure de `10` produit des marques à 0, 10, 20, etc. lorsqu'un axe commence à zéro. Un intervalle d'étiquette de catégorie de `3` compte les positions de catégorie, indépendamment de leurs valeurs de données. Les diagrammes en nuage de points et à bulles utilisent des axes de valeur plutôt qu'un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures et des échelles basées sur le temps comme décrit dans [Change a Category Axis](#change-a-category-axis).

## **Définir le format de date pour les valeurs de l'axe de catégorie**

L'exemple remplace les données de diagramme par défaut par quatre valeurs annuelles. Les dates sont stockées sous forme de numéros de série OLE Automation dans la première feuille de calcul (index `0`), calculées comme le nombre de jours écoulés depuis le 30 décembre 1899 pour ces dates. Le calcul JavaScript utilise des horodatages UTC et divise la différence par 86 400 000 millisecondes par jour. Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) avec `CategoryAxisType.Date`, appelez [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) avec `false`, et passez `yyyy` à [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) afin que les étiquettes de catégorie affichent les années à quatre chiffres indépendamment du format de la cellule.

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

## **Définir un angle de rotation pour le titre d'un axe de diagramme**

Appelez [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) avec `true` sur l'axe vertical, fournissez le texte du titre, et utilisez [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) pour faire pivoter le titre. L'angle est mesuré en degrés ; cet exemple enregistre un diagramme à colonnes avec le titre de l'axe de valeur pivoté de 90 degrés.

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

Utilisez [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) pour contrôler si l'axe de valeur traverse l'axe de catégorie entre les catégories ou aux marques de catégorie. Ce paramètre s'applique aux axes de catégorie. L'exemple le définit à `true` sur l'axe de catégorie horizontal d'un diagramme à colonnes et enregistre le résultat.

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

## **Définir l'unité d'affichage sur un axe de valeur de diagramme**

Utilisez [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) pour mettre à l'échelle les étiquettes d'un axe de valeur sans modifier les données sous-jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) défini sur `Millions`, une valeur de 60 000 000 est affichée comme 60. L'exemple crée un diagramme à colonnes et applique l'unité d'affichage millions à son axe vertical.

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

Un axe de valeur logarithmique est utile lorsque les valeurs positives couvrent plusieurs ordres de grandeur. Par exemple, un service peut recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent rapprochées près de zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Appelez [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) avec `true` sur l'axe de valeur et utilisez [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) pour choisir la base. Cela modifie la façon dont les valeurs existantes sont affichées ; cela ne change pas les données ni n'ajoute une ligne de tendance logarithmique. Une ligne de tendance représente une relation ajustée dans les données et constitue une fonctionnalité distincte.

### **Choisir l'axe de valeur et la base**

Pour un diagramme en lignes ou à colonnes, l'axe de valeur est retourné par [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Pour un diagramme à barres horizontal, il est retourné par [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Les diagrammes en nuage de points et à bulles ont deux axes de valeur, choisissez donc l'axe horizontal pour les valeurs X, l'axe vertical pour les valeurs Y, ou les deux. N'appliquez pas de mise à l'échelle logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les diagrammes PPTX, utilisez une base comprise entre `2` et `1000`, inclusivement ; les bases fractionnaires comme `2,5` sont également prises en charge. Avec la base `10`, les puissances successives telles que 10, 100, 1 000 et 10 000 sont espacées de manière égale.

### **Comparer les échelles linéaire et logarithmique**

L'exemple autonome suivant crée un diagramme en lignes avec les cinq comptes de requêtes sur la première diapositive, puis clone cette diapositive et active un axe de valeur logarithmique en base 10 sur la seconde. Les deux diapositives conservent les mêmes données.

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

    // Conserver la première diapositive linéaire et ne modifier que l'échelle de l'axe de valeur de la copie.
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

**Échelle linéaire (diapositive 1) :** Des distances verticales égales représentent des différences égales dans les comptes de requêtes. La plus grande valeur domine le diagramme, rendant les petites valeurs difficiles à distinguer.

![Diagramme en lignes dans PowerPoint montrant cinq comptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2) :** Des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, ainsi les points forment une ligne droite ascendante sur l'échelle en base 10. Les étiquettes d'axe affichent toujours les comptes de requêtes originaux.

![Les mêmes cinq comptes de requêtes dans PowerPoint sur un axe de valeur logarithmique en base 10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l'activer. Si les valeurs zéro ou négatives ont un sens, conservez une échelle linéaire ou affichez‑les séparément. Si l'exclusion de ces valeurs est appropriée pour l'analyse, expliquez l'omission. Ne les remplacez pas silencieusement par de petites valeurs positives, car cela change la signification des données. Tout minimum ou maximum configuré manuellement pour un axe logarithmique doit également être positif.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axe) ?**

Utilisez [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) pour choisir le comportement de croisement. Pour spécifier une valeur de croisement numérique, utilisez [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Ces réglages vous permettent de déplacer le point de croisement de l'axe vers une ligne de base appropriée.

**Comment positionner les étiquettes de graduation par rapport à l'axe ?**

Appelez [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) en utilisant [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Pour contrôler les marques de graduation elles‑mêmes, utilisez [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) ou [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); elles sont séparées du positionnement des étiquettes.