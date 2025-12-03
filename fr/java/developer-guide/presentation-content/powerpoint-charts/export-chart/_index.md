---
title: Exporter des graphiques de présentation en Java
linktitle: Exporter le graphique
type: docs
weight: 90
url: /fr/java/export-chart/
keywords:
- graphique
- graphique en image
- graphique comme image
- extraire l'image du graphique
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment exporter des graphiques de présentation avec Aspose.Slides pour Java, en prenant en charge les formats PPT et PPTX, et simplifiez la génération de rapports dans n’importe quel flux de travail."
---

## **Obtenir l'image du graphique**
Aspose.Slides for Java offre la prise en charge de l'extraction d'image d'un graphique spécifique. L'exemple suivant est fourni.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis-je exporter un graphique en vecteur (SVG) au lieu d'une image raster ?**

Oui. Un graphique est une forme, et son contenu peut être enregistré au format SVG à l'aide de la [méthode d'enregistrement shape-to-SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Comment puis-je définir la taille exacte du graphique exporté en pixels ?**

Utilisez les surcharges de rendu d'image qui permettent de spécifier la taille ou l'échelle — la bibliothèque prend en charge le rendu d'objets avec des dimensions/échelles données.

**Que faire si les polices des étiquettes et de la légende apparaissent incorrectes après l'exportation ?**

[Chargez les polices requises](/slides/fr/java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) afin que le rendu du graphique préserve les métriques et l'apparence du texte.

**L'exportation respecte-t-elle le thème, les styles et les effets de PowerPoint ?**

Oui. Le moteur de rendu d'Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), de sorte que l'apparence du graphique est conservée.

**Où puis-je trouver les capacités de rendu/exportation disponibles au‑delà des images de graphiques ?**

Voir l'[API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[documentation](/slides/fr/java/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/java/convert-powerpoint-to-pdf/), [SVG](/slides/fr/java/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/java/convert-powerpoint-to-xps/), [HTML](/slides/fr/java/convert-powerpoint-to-html/), etc.) et les options de rendu associées.