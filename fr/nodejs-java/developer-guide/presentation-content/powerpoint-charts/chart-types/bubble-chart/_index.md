---
title: Diagramme à bulles
type: docs
url: /fr/nodejs-java/bubble-chart/
---

## **Échelle de taille du diagramme à bulles**
Aspose.Slides for Node.js via Java offre une prise en charge du redimensionnement des diagrammes à bulles. Dans Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) et [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) les méthodes ont été ajoutées. Un exemple de code ci‑dessous est fourni. 
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Représenter les données comme tailles de diagramme à bulles**
Des méthodes [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) et [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) ont été ajoutées aux classes [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup) et aux classes associées. **BubbleSizeRepresentation** indique comment les valeurs de taille des bulles sont représentées dans le diagramme à bulles. Les valeurs possibles sont : [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) et [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). En conséquence, l’énumération [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType) a été ajoutée pour spécifier les différentes manières de représenter les données comme tailles de diagramme à bulles. Un exemple de code est donné ci‑dessous.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Un « diagramme à bulles avec effet 3‑D » est‑il pris en charge, et en quoi diffère‑t‑il d’un diagramme standard ?**

Oui. Il existe un type de diagramme distinct, « Bubble with 3‑D ». Il applique un style 3‑D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Le type est disponible dans l’énumération du [chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

**Existe‑t‑il une limite au nombre de séries et de points dans un diagramme à bulles ?**

Il n’y a pas de limite stricte au niveau de l’API ; les contraintes sont déterminées par les performances et la version cible de PowerPoint. Il est recommandé de garder le nombre de points raisonnable pour assurer la lisibilité et la rapidité de rendu.

**Comment l’exportation affecte‑t‑elle l’apparence d’un diagramme à bulles (PDF, images) ?**

L’exportation vers les formats pris en charge préserve l’apparence du diagramme ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster ou vectoriel, les règles générales de rendu des graphiques s’appliquent (résolution, anti‑aliasing), il faut donc choisir une résolution DPI suffisante pour l’impression.