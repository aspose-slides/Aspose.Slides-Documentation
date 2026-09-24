---
title: Personnaliser les tableaux de données des graphiques dans les présentations à l'aide de JavaScript
linktitle: Tableau de données
type: docs
url: /fr/nodejs-java/chart-data-table/
keywords:
- données du graphique
- tableau de données
- propriétés de police
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Personnalisez les polices, les bordures et les clés de légende du tableau de données d'un graphique dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via Java vous permet d'afficher le tableau de données d'un graphique et de personnaliser le formatage du texte, les bordures et les clés de légende. Cet article explique comment activer le tableau, formater son texte, contrôler chaque type de bordure et afficher ou masquer les clés de légende. Les exemples enregistrent les graphiques configurés dans des fichiers PPTX.

## **Définir les propriétés de police**

Pour afficher le tableau de données d'un graphique, transmettez `true` à [setDataTable](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/setdatatable/). Utilisez [getChartDataTable](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/getchartdatatable/) pour accéder au tableau et configurer son formatage de texte.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Ajoutez un graphique à colonnes groupées à la première diapositive.
1. Activez le tableau de données du graphique.
1. Activez le texte en gras avec [setFontBold](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setfontbold) et transmettez `20` à [setFontHeight](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setfontheight) pour un texte de 20 points.
1. Enregistrez la présentation modifiée.

L'exemple suivant nécessite `input.pptx` dans le répertoire de travail avec au moins une diapositive. Il ajoute un graphique avec des données par défaut à la position (50, 50), avec une largeur de 600 points et une hauteur de 400 points. Le `output.pptx` enregistré contient le graphique avec son tableau de données activé et les paramètres de police spécifiés appliqués.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Personnaliser les bordures du tableau de données**

Activez le tableau avec [Chart.setDataTable](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/setdatatable/) et accédez‑y via [Chart.getChartDataTable](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/getchartdatatable/). Vous pouvez contrôler trois types de bordures de façon indépendante :

- [setBorderHorizontal](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datatable/setborderhorizontal/) contrôle les bordures horizontales des cellules.
- [setBorderVertical](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datatable/setbordervertical/) contrôle les bordures verticales des cellules.
- [setBorderOutline](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datatable/setborderoutline/) contrôle la bordure extérieure du tableau.

Transmettez `true` à chaque méthode pour afficher ses bordures ou `false` pour les masquer. L'exemple suivant crée un graphique à colonnes groupées avec des données par défaut, affiche les bordures horizontales et la bordure extérieure, et masque les bordures verticales. Aucun fichier d'entrée n'est requis. La position et la taille du graphique sont spécifiées en points.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparaison ci‑dessous utilise les mêmes données de graphique et le même paramètre de clé de légende dans les quatre cas. En partant de toutes les bordures activées, chaque variante restante désactive uniquement un paramètre de bordure. La variante en bas à gauche correspond aux paramètres de bordure de l'exemple.

![Tableaux de données de graphique avec toutes les bordures activées, aucune bordure horizontale, aucune bordure verticale et aucune bordure extérieure](data-table-borders.png)

## **Afficher ou masquer les clés de légende**

Les clés de légende sont de petites marques colorées à côté des noms de séries dans le tableau de données. Elles aident les lecteurs à associer chaque ligne du tableau à une série du graphique. Transmettez `true` à [setShowLegendKey](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datatable/setshowlegendkey/) pour afficher ces marqueurs ou `false` pour les masquer.

La légende séparée du graphique est contrôlée par [Chart.setLegend](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/setlegend/). Ces paramètres sont indépendants : masquer la légende séparée ne masque pas les clés à l'intérieur du tableau de données, et masquer les clés du tableau ne masque pas la légende séparée.

L'exemple suivant crée un graphique avec des données par défaut, active son tableau de données et affiche les clés de légende à l'intérieur tout en masquant la légende séparée. Toutes les bordures du tableau sont explicitement activées. Aucune présentation d'entrée n'est requise. Pour masquer uniquement les clés du tableau, transmettez `false` à [setShowLegendKey](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La comparaison ci‑dessous montre le même tableau avec les clés de légende activées et désactivées. Toutes les bordures restent activées, et la légende séparée du graphique est masquée dans les deux cas.

![Tableaux de données de graphique avec les clés de légende affichées à gauche et masquées à droite](data-table-legend-keys.png)

## **FAQ**

**Puis-je afficher les clés de légende dans le tableau de données d'un graphique ?**

Oui. Transmettez `true` à [setShowLegendKey](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datatable/setshowlegendkey/) pour afficher les clés de légende ou `false` pour les masquer.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation en PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique et son tableau de données affiché comme partie de la diapositive lors de l'exportation vers [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/) ou [images](/slides/fr/nodejs-java/convert-powerpoint-to-png/).

**Puis-je travailler avec les tableaux de données dans les graphiques chargés à partir d'un modèle ?**

Oui. Pour un graphique chargé depuis une présentation existante ou un modèle, utilisez [hasDataTable](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/hasdatatable/) et [setDataTable](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/setdatatable/) pour vérifier ou modifier l'affichage de son tableau de données.

**Comment puis‑je trouver les graphiques dont le tableau de données est activé ?**

Parcourez les formes de chaque diapositive, identifiez les graphiques et appelez leur méthode [hasDataTable](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/hasdatatable/). Une valeur `true` indique que le tableau de données est activé.