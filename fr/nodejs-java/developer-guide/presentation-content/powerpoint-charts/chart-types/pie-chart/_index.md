---
title: Personnaliser les graphiques circulaires dans les présentations avec JavaScript
linktitle: Graphique circulaire
type: docs
url: /fr/nodejs-java/pie-chart/
keywords:
- graphique circulaire
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur des parts
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer et personnaliser des graphiques circulaires en JavaScript avec Aspose.Slides pour Node.js via Java. Configurer les tracés secondaires, afficher les étiquettes de données et appliquer des couleurs automatiques aux parts dans PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec des graphiques circulaires dans Aspose.Slides. Il montre comment configurer les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie, et comment activer la coloration automatique des parts pour un graphique circulaire standard.

Les exemples se concentrent sur les tâches de personnalisation de graphiques telles que l’ajout d’un graphique à une diapositive, le réglage des séries et des paramètres d’étiquette, le remplacement des données de graphique par défaut par des catégories et des valeurs personnalisées, et l’enregistrement de la présentation mise à jour.

## **Options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie**

Aspose.Slides for Node.js via Java prend en charge les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie. Ces options contrôlent la taille du tracé secondaire et la manière dont les points de données sont répartis entre les deux tracés.

L'exemple suivant crée un graphique Pie of Pie dans une nouvelle présentation et affiche les valeurs des points de données en tant qu’étiquettes. La méthode [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) définit la taille du tracé secondaire à 149% du tracé principal. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) sélectionne une répartition basée sur le pourcentage, et [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) définit le seuil à 53%.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Afficher les valeurs et configurer le tracé secondaire.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sélectionner les catégories pour le tracé secondaire**

Utilisez le fractionnement personnalisé lorsque vous souhaitez regrouper des catégories spécifiques dans le tracé secondaire, quelle que soit leur valeur en pourcentage. Par exemple, un rapport de ventes peut afficher Online et Events ensemble afin que les lecteurs puissent comparer ces deux canaux, même s’ils représentent 35% et 10% des ventes totales.

Appelez [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) avec [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) et sélectionnez les points via [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). La méthode [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) de la collection accepte un indice basé sur zéro dans la série ; utilisez [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) pour ajouter un objet de point de données. Dans cet exemple, l’indice 1 sélectionne Online, et le point à l’indice 3 sélectionne Events. Partners est également ajouté temporairement, puis exclu à l’aide de [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Remplacer les données par défaut par les ventes par canal.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Sélectionner Online par son indice zéro et Events par son objet de point de données.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Exclure Partners de la sélection sans supprimer ses données sources.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) et Events (10) apparaissent comme des parts séparées dans le tracé secondaire. Dans le tracé principal, ils sont représentés par une part combinée d’une valeur de 45, aux côtés de Retail (40) et Partners (15). La suppression de Partners de la sélection personnalisée le maintient dans le tracé principal ; cela ne supprime pas la catégorie ni sa valeur des données sources du graphique.

L'image suivante montre la présentation enregistrée dans PowerPoint :

![Graphique Pie of Pie avec Online et Events dans le tracé secondaire et leur valeur combinée de 45 dans le tracé principal](pie_of_pie_custom.png)

## **Définir les couleurs automatiques des parts du graphique circulaire**

Aspose.Slides for Node.js via Java peut attribuer automatiquement des couleurs différentes aux parts d’un graphique circulaire. L'exemple suivant crée un graphique circulaire avec un titre centré et remplace les données par défaut par trois catégories trimestrielles et leurs valeurs. La méthode [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) affiche les valeurs 20, 50 et 30 en tant qu’étiquettes, tandis que [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) active une couleur distincte pour chaque part.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Ajouter un titre de graphique centré.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Remplacer les données par défaut en utilisant la première feuille de calcul.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Afficher les valeurs et attribuer des couleurs différentes aux parts.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Les variantes Pie of Pie et Bar of Pie sont‑elles prises en charge ?**

Oui, la bibliothèque [supports](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types Pie of Pie et Bar of Pie.

**Puis‑je exporter uniquement le graphique sous forme d’image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même sous forme d’image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (comme PNG) sans exporter l’ensemble de la présentation.