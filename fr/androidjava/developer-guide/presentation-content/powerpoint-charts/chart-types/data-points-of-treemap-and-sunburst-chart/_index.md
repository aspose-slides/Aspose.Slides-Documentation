---
title: Points de données du graphique Treemap et Sunburst
type: docs
url: /androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Graphique Sunburst dans Aspose.Slides pour Android via Java"
description: "Graphique Sunburst, Diagramme Sunburst, Chart Sunburst, Graphique Radial, Graphique Radial ou Graphique en Secteurs Multi-niveaux avec Aspose.Slides pour Android via Java."
---

Parmi les autres types de graphiques PowerPoint, il existe deux types « hiérarchiques » - **Treemap** et **Sunburst** (également connu sous le nom de Graphique Sunburst, Diagramme Sunburst, Graphique Radial, Graphique Radial ou Graphique en Secteurs Multi-niveaux). Ces graphiques affichent des données hiérarchiques organisées sous forme d'arbre - des feuilles vers le haut de la branche. Les feuilles sont définies par les points de données de la série, et chaque niveau de regroupement imbriqué défini par la catégorie correspondante. Aspose.Slides pour Android via Java permet de formater les points de données du graphique Sunburst et du Treemap en Java.

Voici un graphique Sunburst, où les données dans la colonne Series1 définissent les nœuds feuilles, tandis que les autres colonnes définissent les points de données hiérarchiques :

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Commençons par ajouter un nouveau graphique Sunburst à la présentation :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Voir aussi" %}} 
- [**Créer un graphique Sunburst**](/slides/androidjava/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


S'il est nécessaire de formater les points de données du graphique, nous devrions utiliser ce qui suit :

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) classes 
et [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) méthode 
fournissent un accès pour formater les points de données des graphiques Treemap et Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
est utilisé pour accéder aux catégories multi-niveaux - il représente le conteneur des objets 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel).
C'est essentiellement un wrapper pour 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartCategoryLevelsManager) avec
les propriétés ajoutées spécifiques aux points de données. 
La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel) a
deux méthodes : [**getFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) et 
[**getDataLabel**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) qui
fournissent un accès aux paramètres correspondants.
## **Afficher la valeur du point de données**
Afficher la valeur du point de données "Leaf 4" :

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Définir l'étiquette et la couleur du point de données**
Définir l'étiquette de données "Branch 1" pour afficher le nom de la série ("Series1") au lieu du nom de la catégorie. Ensuite, définir la couleur du texte en jaune :

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Définir la couleur de la branche du point de données**
Changer la couleur de la branche "Steam 4" :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)