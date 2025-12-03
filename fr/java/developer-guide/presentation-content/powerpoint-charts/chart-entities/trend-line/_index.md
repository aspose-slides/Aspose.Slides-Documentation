---
title: Ajouter des lignes de tendance aux graphiques de présentation en Java
linktitle: Ligne de tendance
type: docs
url: /fr/java/trend-line/
keywords:
- graphique
- ligne de tendance
- ligne de tendance exponentielle
- ligne de tendance linéaire
- ligne de tendance logarithmique
- ligne de tendance moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Ajoutez rapidement et personnalisez les lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour Java — un guide pratique pour captiver votre audience."
---

## **Ajouter une ligne de tendance**
Aspose.Slides for Java fournit une API simple pour gérer différentes lignes de tendance de graphiques :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenir la référence d'une diapositive par son index.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise ChartType.ClusteredColumn).
1. Ajouter une ligne de tendance exponentielle pour la série 1 du graphique.
1. Ajouter une ligne de tendance linéaire pour la série 1 du graphique.
1. Ajouter une ligne de tendance logarithmique pour la série 2 du graphique.
1. Ajouter une ligne de tendance moyenne mobile pour la série 2 du graphique.
1. Ajouter une ligne de tendance polynomiale pour la série 3 du graphique.
1. Ajouter une ligne de tendance puissance pour la série 3 du graphique.
1. Enregistrer la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Créer un graphique en colonnes groupées
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Ajouter une ligne de tendance exponentielle pour la série 1 du graphique
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Ajouter une ligne de tendance linéaire pour la série 1 du graphique
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Ajouter une ligne de tendance logarithmique pour la série 2 du graphique
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Ajouter une ligne de tendance moyenne mobile pour la série 2 du graphique
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Ajouter une ligne de tendance polynomiale pour la série 3 du graphique
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Ajouter une ligne de tendance puissance pour la série 3 du graphique
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Enregistrer la présentation
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajouter une ligne personnalisée**
Aspose.Slides for Java fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
- Obtenir la référence d'une diapositive en utilisant son Index
- Créer un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes
- Ajouter une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Définir la couleur des lignes de la forme.
- Enregistrer la présentation modifiée au format PPTX

Le code suivant est utilisé pour créer un graphique avec des lignes personnalisées.
```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Que signifient « forward » et « backward » pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées vers l'avant/arrière : pour les graphiques de dispersion (XY) — en unités d'axe ; pour les graphiques qui ne sont pas de dispersion — en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera-t-elle conservée lors de l'exportation de la présentation en PDF ou SVG, ou lors du rendu d'une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/java/convert-powerpoint-to-pdf/)/[SVG](/slides/fr/java/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées lors de ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/java/create-shape-thumbnails/) lui‑même.