---
title: Personnaliser les graphiques 3D dans les présentations avec Java
linktitle: Graphique 3D
type: docs
url: /fr/java/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques 3D dans Aspose.Slides for Java, avec prise en charge des fichiers PPT et PPTX—boostez vos présentations dès aujourd'hui."
---

## **Définir les propriétés RotationX, RotationY et DepthPercents d'un graphique 3D**
Aspose.Slides for Java propose une API simple pour définir ces propriétés. Cet article vous aidera à définir différentes propriétés telles que **Rotation X,Y, DepthPercents** etc. Le code d'exemple montre comment appliquer les propriétés susmentionnées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Définissez les propriétés Rotation3D.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```java
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter un graphique avec des données par défaut
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Définir l'index de la feuille de données du graphique
    int defaultWorksheetIndex = 0;
    
    // Obtention de la feuille de données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Ajouter des séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Ajouter des catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Définir les propriétés Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Prendre la deuxième série du graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Maintenant remplissage des données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Définir la valeur OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Enregistrer la présentation sur le disque
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via la classe [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image matricielle d'un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique vers une image via l'[API de graphique](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) ou [rendre toute la diapositive](/slides/fr/java/convert-powerpoint-to-png/) aux formats PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu pixel‑parfait ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de gros graphiques 3D ?**

Les performances dépendent du volume des données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque possible, et rendez la sortie à une taille appropriée (résolution et dimensions) correspondant à l’affichage cible ou aux exigences d’impression.