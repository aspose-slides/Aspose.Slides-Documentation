---
title: Exporter le graphique
type: docs
weight: 90
url: /fr/nodejs-java/export-chart/
---

## **Obtenir l'image du graphique**
Aspose.Slides for Node.js via Java fournit une prise en charge de l'extraction de l'image d'un graphique spécifique. L'exemple suivant est fourni. 
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je exporter un graphique au format vectoriel (SVG) plutôt qu'une image raster ?**

Oui. Un graphique est une forme, et son contenu peut être enregistré au format SVG en utilisant la [méthode d'enregistrement shape-to-SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/).

**Comment puis-je définir la taille exacte du graphique exporté en pixels ?**

Utilisez les surcharges de rendu d'image qui permettent de spécifier la taille ou l'échelle — la bibliothèque prend en charge le rendu d'objets avec des dimensions/échelles données.

**Que dois-je faire si les polices des étiquettes et de la légende sont incorrectes après l'exportation ?**

[Chargez les polices requises](/slides/fr/nodejs-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) afin que le rendu du graphique préserve les métriques et l'apparence du texte.

**L'exportation respecte-t-elle le thème, les styles et les effets de PowerPoint ?**

Oui. Le moteur de rendu d'Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), de sorte que l'apparence du graphique est préservée.

**Où puis-je trouver les capacités de rendu/export disponibles au‑delà des images de graphiques ?**

Consultez l'[API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/)/[documentation](/slides/fr/nodejs-java/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/), etc.) et les options de rendu associées.