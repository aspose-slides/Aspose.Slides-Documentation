---
title: Ligne de Tendance
type: docs
url: /fr/androidjava/trend-line/
---

## **Ajouter une Ligne de Tendance**
Aspose.Slides pour Android via Java fournit une API simple pour gérer différentes lignes de tendance de graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que tout type désiré (cet exemple utilise ChartType.ClusteredColumn).
1. Ajout d'une ligne de tendance exponentielle pour la série de graphique 1.
1. Ajout d'une ligne de tendance linéaire pour la série de graphique 1.
1. Ajout d'une ligne de tendance logarithmique pour la série de graphique 2.
1. Ajout d'une ligne de tendance de moyenne mobile pour la série de graphique 2.
1. Ajout d'une ligne de tendance polynomiale pour la série de graphique 3.
1. Ajout d'une ligne de tendance de puissance pour la série de graphique 3.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Création d'un graphique à colonnes groupées
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Ajout d'une ligne de tendance exponentielle pour la série de graphique 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Ajout d'une ligne de tendance linéaire pour la série de graphique 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Ajout d'une ligne de tendance logarithmique pour la série de graphique 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("Nouvelle ligne de tendance logarithmique");
    
    // Ajout d'une ligne de tendance de moyenne mobile pour la série de graphique 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("Nouveau nom de ligne de tendance");
    
    // Ajout d'une ligne de tendance polynomiale pour la série de graphique 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Ajout d'une ligne de tendance de puissance pour la série de graphique 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Sauvegarde de la présentation
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter une Ligne Personnalisée**
Aspose.Slides pour Android via Java fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une simple ligne à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
- Obtenez la référence d'une diapositive en utilisant son index
- Créez un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes
- Ajoutez une forme automatique de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Définissez la couleur des lignes de la forme.
- Écrivez la présentation modifiée sous forme de fichier PPTX

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