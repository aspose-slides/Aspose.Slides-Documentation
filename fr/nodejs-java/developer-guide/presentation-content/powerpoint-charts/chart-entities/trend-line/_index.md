---
title: Ligne de tendance
type: docs
url: /fr/nodejs-java/trend-line/
---

## **Ajouter une ligne de tendance**

Aspose.Slides for Node.js via Java fournit une API simple pour gérer différentes lignes de tendance de graphiques :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive à son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise ChartType.ClusteredColumn).
4. Ajout d’une ligne de tendance exponentielle pour la série 1 du graphique.
5. Ajout d’une ligne de tendance linéaire pour la série 1 du graphique.
6. Ajout d’une ligne de tendance logarithmique pour la série 2 du graphique.
7. Ajout d’une ligne de tendance moyenne mobile pour la série 2 du graphique.
8. Ajout d’une ligne de tendance polynomiale pour la série 3 du graphique.
9. Ajout d’une ligne de tendance puissance pour la série 3 du graphique.
10. Enregistrez la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.
```javascript
// Créez une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Création d'un graphique à colonnes groupées
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Ajout d'une ligne de tendance exponentielle pour la série 1 du graphique
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Ajout d'une ligne de tendance linéaire pour la série 1 du graphique
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Ajout d'une ligne de tendance logarithmique pour la série 2 du graphique
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Ajout d'une ligne de tendance moyenne mobile pour la série 2 du graphique
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Ajout d'une ligne de tendance polynomiale pour la série 3 du graphique
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Ajout d'une ligne de tendance puissance pour la série 3 du graphique
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Enregistrement de la présentation
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajouter une ligne personnalisée**

Aspose.Slides for Node.js via Java fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)
- Obtenez la référence d’une diapositive en utilisant son index
- Créez un nouveau graphique en utilisant la méthode AddChart exposée par l’objet Shapes
- Ajoutez une AutoShape de type Line en utilisant la méthode AddAutoShape exposée par l’objet Shapes
- Définissez la couleur des lignes de la forme.
- Enregistrez la présentation modifiée dans un fichier PPTX

Le code suivant est utilisé pour créer un graphique avec des lignes personnalisées.
```javascript
// Créez une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Que signifient « forward » et « backward » pour une ligne de tendance ?**

Il s’agit des longueurs de la ligne de tendance projetées en avant/arrière : pour les graphiques de dispersion (XY) — en unités d’axe ; pour les graphiques non‑dispersion — en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera‑t‑elle conservée lors de l’exportation de la présentation en PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées pendant ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/nodejs-java/create-shape-thumbnails/) lui‑même.