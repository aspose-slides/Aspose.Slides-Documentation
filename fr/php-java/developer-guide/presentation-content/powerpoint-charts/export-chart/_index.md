---
title: Exporter des graphiques de présentation en PHP
linktitle: Exporter le graphique
type: docs
weight: 90
url: /fr/php-java/export-chart/
keywords:
- graphique
- graphique en image
- graphique comme image
- extraire l'image du graphique
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment exporter les graphiques de présentation avec Aspose.Slides pour PHP via Java, prendre en charge les formats PPT et PPTX, et rationaliser le reporting dans n’importe quel flux de travail."
---

## **Obtenir une image de graphique**
Aspose.Slides for PHP via Java fournit une prise en charge de l’extraction d’une image d’un graphique spécifique. L’exemple suivant est donné.  
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis-je exporter un graphique sous forme de vecteur (SVG) au lieu d’une image raster ?**

Oui. Un graphique est une forme, et son contenu peut être enregistré au format SVG à l’aide de la [méthode d’enregistrement shape-to-SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/).

**Comment définir la taille exacte du graphique exporté en pixels ?**

Utilisez les surcharges de rendu d’image qui permettent de spécifier la taille ou l’échelle — la bibliothèque prend en charge le rendu des objets avec les dimensions ou l’échelle indiquées.

**Que faire si les polices des libellés et de la légende sont incorrectes après l’exportation ?**

[Charger les polices requises](/slides/fr/php-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) afin que le rendu du graphique conserve les métriques et l’apparence du texte.

**L’exportation respecte-t-elle le thème, les styles et les effets de PowerPoint ?**

Oui. Le moteur de rendu d’Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), de sorte que l’apparence du graphique est préservée.

**Où puis‑je trouver les capacités de rendu/export disponibles au‑delà des images de graphiques ?**

Consultez l’[API](https://reference.aspose.com/slides/php-java/aspose.slides/)/[documentation](/slides/fr/php-java/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/php-java/convert-powerpoint-to-xps/), [HTML](/slides/fr/php-java/convert-powerpoint-to-html/), etc.) et les options de rendu associées.