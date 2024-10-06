---
title: Ligne de Tendance
type: docs
url: /java/trend-line/
---

## **Ajouter une Ligne de Tendance**
Aspose.Slides pour Java fournit une API simple pour gérer différentes lignes de tendance de graphiques :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenir la référence d'une diapositive par son index.
1. Ajouter un graphique avec des données par défaut ainsi que le type désiré (cet exemple utilise ChartType.ClusteredColumn).
1. Ajouter une ligne de tendance exponentielle pour la série de graphique 1.
1. Ajouter une ligne de tendance linéaire pour la série de graphique 1.
1. Ajouter une ligne de tendance logarithmique pour la série de graphique 2.
1. Ajouter une ligne de tendance de moyenne mobile pour la série de graphique 2.
1. Ajouter une ligne de tendance polynomiale pour la série de graphique 3.
1. Ajouter une ligne de tendance de puissance pour la série de graphique 3.
1. Écrire la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.

```java
// Créer une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Création d'un graphique en colonnes groupées
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Ajouter une ligne de tendance exponentielle pour la série de graphique 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Ajouter une ligne de tendance linéaire pour la série de graphique 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Ajouter une ligne de tendance logarithmique pour la série de graphique 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("Nouvelle ligne de tendance logarithmique");
    
    // Ajouter une ligne de tendance de moyenne mobile pour la série de graphique 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("Nom de Nouvelle Tendance");
    
    // Ajouter une ligne de tendance polynomiale pour la série de graphique 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Ajouter une ligne de tendance de puissance pour la série de graphique 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Sauvegarder la présentation
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter une Ligne Personnalisée**
Aspose.Slides pour Java fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
- Obtenir la référence d'une diapositive en utilisant son index
- Créer un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes
- Ajouter une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Définir la couleur des lignes de la forme.
- Écrire la présentation modifiée en tant que fichier PPTX

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