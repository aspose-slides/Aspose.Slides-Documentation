---
title: Graphique 3D
type: docs
url: /fr/nodejs-java/3d-chart/
---

## **Définir les propriétés RotationX, RotationY et DepthPercents d'un graphique 3D**

Aspose.Slides for Node.js via Java fournit une API simple pour définir ces propriétés. Cet article vous aidera à définir différentes propriétés comme **Rotation X,Y, DepthPercents** etc. Le code d'exemple applique la configuration des propriétés mentionnées ci‑above.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec les données par défaut.
1. Définissez les propriétés Rotation3D.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter un graphique avec les données par défaut
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Définir l'index de la feuille de données du graphique
    var defaultWorksheetIndex = 0;
    // Obtenir la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Ajouter des séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Ajouter des catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Définir les propriétés Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Prendre la deuxième série du graphique
    var series = chart.getChartData().getSeries().get_Item(1);
    // Maintenant remplissage des données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Définir la valeur Overlap
    series.getParentSeriesGroup().setOverlap(100);
    // Enregistrer la présentation sur le disque
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques en colonnes, y compris Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via l’énumération [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) dans la référence API de la version installée.

**Puis-je obtenir une image raster d'un graphique 3D pour un rapport ou le Web ?**

Oui. Vous pouvez exporter un graphique vers une image via l’[API du graphique](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) ou [rendre toute la diapositive](/slides/fr/nodejs-java/convert-powerpoint-to-png/) dans des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu pixel‑perfect ou souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages Web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque cela est possible, et rendez la sortie à une résolution et des dimensions appropriées pour correspondre aux besoins d’affichage ou d’impression ciblés.