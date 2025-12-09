---
title: Diagramme en beignet
type: docs
weight: 30
url: /fr/nodejs-java/doughnut-chart/
---

## **Modifier l'écart du centre du diagramme en beignet**
{{% alert color="primary" %}} 

Aspose.Slides pour Node.js via Java prend désormais en charge la spécification de la taille du trou d'un diagramme en beignet. Dans ce sujet, nous verrons avec un exemple comment spécifier la taille du trou d'un diagramme en beignet.

{{% /alert %}} 

Pour spécifier la taille du trou d'un diagramme en beignet, veuillez suivre les étapes ci-dessous :

1. Instancier l'objet Presentation.
1. Ajouter un diagramme en beignet sur la diapositive.
1. Spécifier la taille du trou du diagramme en beignet.
1. Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini la taille du trou du diagramme en beignet.
```javascript
// Créer une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Enregistrer la présentation sur le disque
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je créer un diagramme en beignet à plusieurs niveaux avec plusieurs anneaux ?**

Oui. Ajoutez plusieurs séries à un même diagramme en beignet — chaque série devient un anneau distinct. L'ordre des anneaux est déterminé par l'ordre des séries dans la collection.

**Le diagramme en beignet « explosé » (parts séparées) est-il pris en charge ?**

Oui. Il existe un type de diagramme Exploded Doughnut[chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) et une propriété d'explosion sur les points de données ; vous pouvez séparer les parts individuelles.

**Comment obtenir une image d'un diagramme en beignet (PNG/SVG) pour un rapport ?**

Un diagramme est une forme ; vous pouvez le rendre sous forme d'[raster image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) ou exporter le diagramme en [SVG image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/).