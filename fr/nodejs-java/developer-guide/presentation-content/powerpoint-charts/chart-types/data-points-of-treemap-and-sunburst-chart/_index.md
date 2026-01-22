---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst à l'aide de JavaScript
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graphique treemap
- graphique sunburst
- point de données
- couleur de l'etiquette
- couleur de branche
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à gérer les points de données dans les graphiques treemap et sunburst avec JavaScript et Aspose.Slides pour Node.js via Java, compatible avec les formats PowerPoint."
---

Parmi les autres types de graphiques PowerPoint, il existe deux types « hiérarchiques » — **Treemap** et **Sunburst** (également appelés graphique Sunburst, diagramme Sunburst, graphique radial, graphique radial ou diagramme circulaire à plusieurs niveaux). Ces graphiques affichent des données hiérarchiques organisées en arbre — des feuilles jusqu’au sommet de la branche. Les feuilles sont définies par les points de données de la série, et chaque niveau de regroupement imbriqué suivant est défini par la catégorie correspondante. Aspose.Slides for Node.js via Java permet de formater les points de données des graphiques Sunburst et Treemap en JavaScript.

Voici un graphique Sunburst, où les données de la colonne Series1 définissent les nœuds feuilles, tandis que les autres colonnes définissent les points de données hiérarchiques :
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Commençons par ajouter un nouveau graphique Sunburst à la présentation :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Voir aussi" %}} 
- [**Créer ou mettre à jour des graphiques de présentation PowerPoint en JavaScript**](/slides/fr/nodejs-java/create-chart/)
{{% /alert %}}

Si vous devez formater les points de données du graphique, vous devez utiliser les éléments suivants :
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) classes 
et [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) méthode 
provident un accès au formatage des points de données des graphiques Treemap et Sunburst. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
est utilisé pour accéder aux catégories à plusieurs niveaux — il représente le conteneur des objets 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel).
En gros, c’est un wrapper pour 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) avec les propriétés ajoutées spécifiques aux points de données. 
La classe [**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) possède
deux méthodes : [**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) et 
[**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) qui
fournissent un accès aux paramètres correspondants.

## **Afficher la valeur du point de données**
Afficher la valeur du point de données "Leaf 4" :
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Définir l'étiquette et la couleur du point de données**
Définir l'étiquette de données "Branch 1" pour afficher le nom de la série ("Series1") au lieu du nom de catégorie. Ensuite, définir la couleur du texte en jaune :
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Définir la couleur de branche du point de données**
Modifier la couleur de la branche "Steam 4" :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Puis-je modifier l'ordre (tri) des segments dans Sunburst/Treemap ?**

Non. PowerPoint trie les segments automatiquement (généralement par valeurs décroissantes, dans le sens des aiguilles d’une montre). Aspose.Slides reproduit ce comportement : vous ne pouvez pas modifier l’ordre directement ; vous devez le faire en prétraitant les données.

**Comment le thème de la présentation affecte-t-il les couleurs des segments et des étiquettes ?**

Les couleurs du graphique héritent du [thème/palette](/slides/fr/nodejs-java/presentation-theme/) de la présentation, à moins que vous ne définissiez explicitement les remplissages/les polices. Pour des résultats cohérents, verrouillez les remplissages unis et le formatage du texte aux niveaux requis.

**L’exportation vers PDF/PNG conservera-t-elle les couleurs de branche personnalisées et les paramètres des étiquettes ?**

Oui. Lors de l’exportation de la présentation, les paramètres du graphique (remplissages, étiquettes) sont conservés dans les formats de sortie car Aspose.Slides rend le graphique avec le formatage appliqué.

**Puis-je calculer les coordonnées réelles d’une étiquette/élément pour placer une superposition personnalisée sur le graphique ?**

Oui. Après la validation de la mise en page du graphique, les valeurs X réel et Y réel sont disponibles pour les éléments (par exemple, un [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/)), ce qui facilite le positionnement précis des superpositions.