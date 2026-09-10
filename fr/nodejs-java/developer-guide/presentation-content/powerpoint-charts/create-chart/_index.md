---
title: Créer ou mettre à jour des graphiques de présentation PowerPoint en JavaScript
linktitle: Créer ou mettre à jour des graphiques
type: docs
weight: 10
url: /fr/nodejs-java/create-chart/
keywords:
- ajouter un graphique
- créer un graphique
- modifier un graphique
- changer un graphique
- mettre à jour un graphique
- graphique en nuage de points
- graphique circulaire
- graphique en lignes
- graphique en carte d'arbre
- graphique boursier
- graphique à boîtes et moustaches
- graphique en entonnoir
- graphique en rayonnement
- graphique d'histogramme
- graphique radar
- graphique multicatégorie
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer et personnaliser des graphiques dans les présentations PowerPoint avec Aspose.Slides pour Node.js. Ajouter, mettre en forme et modifier des graphiques avec des exemples de code pratiques en JavaScript."
---
## **Vue d'ensemble**

Cet article fournit un guide complet sur la création et la personnalisation de graphiques avec Aspose.Slides. Vous apprendrez comment ajouter programmatique un graphique à une diapositive, le remplir avec des données et appliquer diverses options de mise en forme pour répondre à vos exigences de conception spécifiques. Tout au long de l'article, des exemples de code détaillés illustrent chaque étape, depuis l'initialisation de la présentation et de l'objet graphique jusqu'à la configuration des séries, des axes et des légendes. En suivant ce guide, vous acquerrez une solide compréhension de l'intégration de la génération dynamique de graphiques dans vos applications, simplifiant le processus de création de présentations basées sur les données.

## **Créer un graphique**

Les graphiques aident les personnes à visualiser rapidement des données et à obtenir des informations qui ne sont pas immédiatement évidentes à partir d'un tableau ou d'une feuille de calcul.

**Pourquoi créer des graphiques ?**

En utilisant des graphiques, vous pouvez :

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d’une présentation
* mettre en évidence des modèles et des tendances dans les données
* déduire la direction et l’élan des données dans le temps ou par rapport à une unité de mesure spécifique
* repérer des valeurs aberrantes, des anomalies, des écarts, des erreurs, des données incohérentes, etc.
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques via la fonction *Insérer*, qui propose des modèles pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer à la fois des graphiques standards (basés sur des types de graphiques populaires) et des graphiques personnalisés.

{{% alert color="info" title="Note" %}}
Pour créer des graphiques, utilisez la classe [ChartType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/). Les champs de cette classe correspondent aux différents types de graphiques.
{{% /alert %}}

### **Créer des graphiques à colonnes groupées**

Cette section explique comment créer des graphiques à colonnes groupées avec Aspose.Slides. Vous apprendrez à initialiser une présentation, ajouter un graphique et personnaliser ses éléments tels que le titre, les données, les séries, les catégories et le style. Suivez les étapes ci‑dessous pour voir comment un graphique à colonnes groupées standard est généré :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec quelques données et spécifiez le type `ChartType.ClusteredColumn` .
4. Ajoutez un titre au graphique.
5. Accédez à la feuille de données du graphique.
6. Supprimez toutes les séries et catégories par défaut.
7. Ajoutez de nouvelles séries et catégories.
8. Ajoutez de nouvelles données de graphique pour les séries du graphique.
9. Appliquez une couleur de remplissage aux séries du graphique.
10. Ajoutez des libellés aux séries du graphique.
11. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique à colonnes groupées :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancie une classe de présentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajoute un graphique avec ses données par défaut
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Définit le titre du graphique
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // Configure la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Définit l'index pour la feuille de données du graphique
    var defaultWorksheetIndex = 0;
    // Obtient la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Ajoute de nouvelles séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Ajoute de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Récupère la première série du graphique
    var series = chart.getChartData().getSeries().get_Item(0);
    // Remplit maintenant les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Récupère la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1);
    // Remplit les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Crée des étiquettes personnalisées pour chaque catégorie de la nouvelle série
    // Définit la première étiquette pour afficher le nom de la catégorie
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Affiche la valeur pour la troisième étiquette
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Enregistre la présentation avec le graphique
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques en nuage de points**

Les graphiques en nuage de points (également appelés diagrammes de dispersion ou graphiques x‑y) sont souvent utilisés pour vérifier des modèles ou démontrer des corrélations entre deux variables.

Utilisez un graphique en nuage de points lorsque :

* vous avez des données numériques appariées
* vous avez deux variables qui se combinent bien
* vous voulez déterminer si deux variables sont liées
* vous avez une variable indépendante qui possède plusieurs valeurs pour une variable dépendante

1. Suivez les étapes de [Créer des graphiques à colonnes groupées](#créer-des-graphiques-à-colonnes-groupées).
2. Pour la troisième étape, ajoutez un graphique avec quelques données et spécifiez votre type de graphique parmi les suivants :
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Représente un graphique en nuage de points._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Représente un graphique en nuage de points relié par des courbes, avec des marqueurs de données._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Représente un graphique en nuage de points relié par des courbes, sans marqueurs de données._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Représente un graphique en nuage de points relié par des lignes droites, avec des marqueurs de données._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Représente un graphique en nuage de points relié par des lignes droites, sans marqueurs de données._

Ce code JavaScript montre comment créer un graphique en nuage de points avec des marqueurs différents pour chaque série :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancie une classe de présentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Crée le graphique par défaut
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Obtient l'index de la feuille de données du graphique par défaut
    var defaultWorksheetIndex = 0;
    // Obtient la feuille de données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Supprime les séries de démonstration
    chart.getChartData().getSeries().clear();
    // Ajoute de nouvelles séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Récupère la première série du graphique
    var series = chart.getChartData().getSeries().get_Item(0);
    // Ajoute un nouveau point (1:3) à la série
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Ajoute un nouveau point (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Modifie le type de la série
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Modifie le marqueur de la série du graphique
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Récupère la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1);
    // Ajoute un nouveau point (5:2) ici
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Ajoute un nouveau point (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Ajoute un nouveau point (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Ajoute un nouveau point (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Modifie le marqueur de la série du graphique
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques circulaires**

Les graphiques circulaires sont les mieux adaptés pour montrer la relation partie‑à‑tout dans les données, en particulier lorsque les données contiennent des libellés catégoriels avec des valeurs numériques. Cependant, si vos données contiennent de nombreuses parties ou libellés, vous pouvez envisager d’utiliser un graphique à barres à la place.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Pie](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#Pie) .
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Ajoutez de nouveaux points au graphique et appliquez des couleurs personnalisées aux secteurs du graphique circulaire.
9. Définissez les libellés pour les séries.
10. Activez les lignes de rappel pour les libellés des séries.
11. Définissez l’angle de rotation des secteurs du graphique circulaire.
12. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique circulaire :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancie une classe de présentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var slides = pres.getSlides().get_Item(0);
    // Ajoute un graphique avec des données par défaut
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Définit le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Configure la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Définit l'index de la feuille de données du graphique
    var defaultWorksheetIndex = 0;
    // Obtient la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Ajoute de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Ajoute de nouvelles séries
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Remplit les données de la série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Ne fonctionne pas dans la nouvelle version
    // Ajout de nouveaux points et définition de la couleur des secteurs
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Définit la bordure du secteur
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Définit la bordure du secteur
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Définit la bordure du secteur
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // Crée des étiquettes personnalisées pour chaque catégorie de la nouvelle série
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Affiche les lignes de repère pour le graphique
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Définit l'angle de rotation des secteurs du graphique circulaire
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Enregistre la présentation avec un graphique
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques en lignes**

Les graphiques en lignes (également appelés graphiques linéaires) sont les mieux adaptés aux situations où vous souhaitez montrer des variations de valeur au fil du temps. Avec un graphique en lignes, vous pouvez comparer un grand nombre de données simultanément, suivre les changements et les tendances dans le temps, mettre en évidence des anomalies dans les séries de données, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Line](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#Line) .
4. Accédez au classeur de données du graphique ([ChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/)) .
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique en lignes :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Par défaut, les points d’un graphique en lignes sont reliés par des lignes droites continues. Si vous souhaitez que les points soient reliés par des tirets, vous pouvez spécifier le type de tiret souhaité comme suit :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques en carte d'arbre**

Les graphiques en carte d'arbre sont les mieux adaptés aux données de ventes lorsque vous voulez montrer la taille relative des catégories de données et attirer rapidement l’attention sur les éléments qui contribuent le plus au sein de chaque catégorie.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Treemap](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#Treemap) .
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique en carte d'arbre :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // branche 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // branche 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques boursiers**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Spécifiez le format des lignes haut‑bas.
9. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique boursier :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques à boîtes et moustaches**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique à boîtes et moustaches :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques en entonnoir**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Funnel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#Funnel) .
4. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique en entonnoir :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques en rayonnement**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Sunburst](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#Sunburst) .
4. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique en rayonnement :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // branche 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // branche 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques d’histogramme**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Histogram](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#Histogram) .
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique d’histogramme :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Créer des graphiques radar**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec quelques données et spécifiez votre type de graphique préféré ([ChartType.Radar](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#Radar) dans ce cas).
4. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique radar :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques multi‑catégories**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.ClusteredColumn](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/#ClusteredColumn) .
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment créer un graphique multi‑catégorie :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Ajout de séries
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Enregistrer la présentation avec le graphique
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques de carte**

Les graphiques de carte visualisent des données géographiques et aident à comparer les valeurs selon les régions.

Ce code JavaScript montre comment créer un graphique de carte :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Créer des graphiques combinés**

Un graphique combiné (ou graphique combo) combine deux types de graphiques ou plus dans un seul graphique. Ce type de graphique vous permet de mettre en évidence, comparer ou examiner les différences entre deux ensembles de données ou plus, facilitant ainsi l’identification des relations entre eux.

![Le graphique combiné](combination_chart.png)

Le code JavaScript suivant montre comment créer le graphique combiné illustré ci‑dessus dans une présentation PowerPoint :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Définir le titre du graphique.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Définir la légende du graphique.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Supprimer les séries et catégories générées par défaut.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Ajouter de nouvelles catégories.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Ajouter la première série.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Définir l'axe horizontal.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Définir l'axe vertical.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Définir la couleur des lignes de grille principales verticales.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Définir l'axe horizontal secondaire.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Définir l'axe vertical secondaire.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Mettre à jour les graphiques**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) qui représente la présentation contenant le graphique à mettre à jour.
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez à la feuille de données du graphique.
5. Modifiez les séries de données du graphique en changeant les valeurs des séries.
6. Ajoutez une nouvelle série et remplissez‑la de données.
7. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment mettre à jour un graphique :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Accéder à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Obtenir le graphique avec les données par défaut
    var chart = sld.getShapes().get_Item(0);
    // Définir l'index de la feuille de données du graphique
    var defaultWorksheetIndex = 0;
    // Obtenir la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Modifier le nom de la catégorie du graphique
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Prendre la première série du graphique
    var series = chart.getChartData().getSeries().get_Item(0);
    // Mettre à jour les données de la série
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Modifier le nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Prendre la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1);
    // Mettre à jour les données de la série
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Modifier le nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Maintenant, ajouter une nouvelle série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Prendre la troisième série du graphique
    series = chart.getChartData().getSeries().get_Item(2);
    // Remplir les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Enregistrer la présentation avec le graphique
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Définir la plage de données d’un graphique**

Pour définir la plage de données d’un graphique, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) qui représente la présentation contenant le graphique.
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez aux données du graphique et définissez la plage.
5. Enregistrez la présentation modifiée au format PPTX.

Ce code JavaScript montre comment définir la plage de données d’un graphique :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Utiliser des marqueurs par défaut dans les graphiques**

Lorsque vous utilisez des marqueurs par défaut dans les graphiques, chaque série de graphique reçoit automatiquement un symbole de marqueur différent.

Ce code JavaScript montre comment définir automatiquement un marqueur de série de graphique :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Prendre la deuxième série du graphique
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Maintenant, remplissage des données de la série
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quels types de graphiques sont pris en charge par Aspose.Slides ?**

Aspose.Slides prend en charge un large éventail de [types de graphiques](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/charttype/), y compris les graphiques à barres, en lignes, circulaires, en aires, en nuage de points, histogrammes, radar, et bien d’autres. Cette flexibilité vous permet de choisir le type de graphique le plus adapté à vos besoins de visualisation des données.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, créez d’abord une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) , récupérez la diapositive souhaitée à l’aide de son indice, puis appelez la méthode d’ajout de graphique en spécifiant le type de graphique et les données initiales. Ce processus intègre le graphique directement dans votre présentation.

**Comment mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d’un graphique en accédant à son classeur de données ([ChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/)), en supprimant les séries et catégories par défaut, puis en ajoutant vos propres données personnalisées. Cela vous permet de rafraîchir le graphique de manière programmatique pour refléter les dernières données.

**Est‑il possible de personnaliser l’apparence du graphique ?**

Oui, Aspose.Slides offre de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les libellés, les légendes et d’autres [éléments de mise en forme](/slides/fr/nodejs-java/chart-entities/) afin d’adapter l’apparence du graphique à vos exigences de conception spécifiques.