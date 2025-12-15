---
title: Exporter les graphiques de présentation sur Android
linktitle: Exporter le graphique
type: docs
weight: 90
url: /fr/androidjava/export-chart/
keywords:
- graphique
- graphique en image
- graphique comme image
- extraire l'image du graphique
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à exporter les graphiques de présentation avec Aspose.Slides pour Android via Java, en prenant en charge les formats PPT et PPTX, et à simplifier la génération de rapports dans tout flux de travail."
---

## **Obtenir une image de graphique**
Aspose.Slides for Android via Java prend en charge l'extraction de l'image d'un graphique spécifique. Voici un exemple.
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

**Puis-je exporter un graphique en tant que vecteur (SVG) plutôt qu'une image raster ?**

Oui. Un graphique est une forme, et son contenu peut être enregistré au format SVG en utilisant la [méthode d'enregistrement shape-to-SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Comment puis‑je définir la taille exacte du graphique exporté en pixels ?**

Utilisez les surcharges de rendu d'image qui vous permettent de spécifier la taille ou l'échelle - la bibliothèque prend en charge le rendu d'objets avec des dimensions ou une échelle données.

**Que faire si les polices des libellés et de la légende sont incorrectes après l'exportation ?**

[Chargez les polices requises](/slides/fr/androidjava/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) afin que le rendu du graphique préserve les métriques et l'apparence du texte.

**L'exportation respecte‑t‑elle le thème, les styles et les effets de PowerPoint ?**

Oui. Le moteur de rendu d'Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), ainsi l'apparence du graphique est préservée.

**Où puis‑je trouver les capacités de rendu/export disponibles au‑delà des images de graphiques ?**

Consultez l'[API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/)/[documentation](/slides/fr/androidjava/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/fr/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/fr/androidjava/convert-powerpoint-to-html/), etc.) et les options de rendu associées.