---
title: Ajouter des lignes de tendance aux graphiques de présentation sur Android
linktitle: Ligne de tendance
type: docs
url: /fr/androidjava/trend-line/
keywords:
- graphique
- ligne de tendance
- ligne de tendance exponentielle
- ligne de tendance linéaire
- ligne de tendance logarithmique
- ligne de tendance moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance de puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Ajoutez et personnalisez rapidement les lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour Android via Java — un guide pratique pour captiver votre audience."
---

## **Ajouter une ligne de tendance**
Aspose.Slides for Android via Java fournit une API simple pour gérer différentes lignes de tendance des graphiques:

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise ChartType.ClusteredColumn).
1. Ajout d'une ligne de tendance exponentielle pour la série 1 du graphique.
1. Ajout d'une ligne de tendance linéaire pour la série 1 du graphique.
1. Ajout d'une ligne de tendance logarithmique pour la série 2 du graphique.
1. Ajout d'une ligne de tendance moyenne mobile pour la série 2 du graphique.
1. Ajout d'une ligne de tendance polynomiale pour la série 3 du graphique.
1. Ajout d'une ligne de tendance de puissance pour la série 3 du graphique.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.
```java
// Créez une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Création d'un graphique à colonnes groupées
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Ajout d'une ligne de tendance exponentielle pour la série 1 du graphique
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Ajout d'une ligne de tendance linéaire pour la série 1 du graphique
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Ajout d'une ligne de tendance logarithmique pour la série 2 du graphique
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Ajout d'une ligne de tendance moyenne mobile pour la série 2 du graphique
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Ajout d'une ligne de tendance polynomiale pour la série 3 du graphique
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Ajout d'une ligne de tendance de puissance pour la série 3 du graphique
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Enregistrement de la présentation
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajouter une ligne personnalisée**
Aspose.Slides for Android via Java fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous:

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
- Obtenez la référence d'une diapositive en utilisant son Index
- Créez un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes
- Ajoutez une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Définissez la Color des lignes de la forme.
- Enregistrez la présentation modifiée en tant que fichier PPTX

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

Ce sont les longueurs de la ligne de tendance projetées en avant/en arrière : pour les graphiques de dispersion (XY) — en unités d’axe ; pour les graphiques non dispersés — en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera-t-elle conservée lors de l’exportation de la présentation au format PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/fr/androidjava/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées lors de ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/androidjava/create-shape-thumbnails/) lui‑même.