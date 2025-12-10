---
title: Exporter les graphiques de présentation en .NET
linktitle: Exporter le graphique
type: docs
weight: 90
url: /fr/net/export-chart/
keywords:
- graphique
- graphique vers image
- graphique comme image
- extraire l'image du graphique
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à exporter les graphiques de présentation avec Aspose.Slides pour .NET, prenant en charge les formats PPT et PPTX, et à rationaliser les rapports dans n'importe quel flux de travail."
---

## **Obtenir une image de graphique**
Aspose.Slides for .NET offre la prise en charge de l'extraction d'image d'un graphique spécifique. L'exemple suivant est fourni.
```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```


## **FAQ**

**Puis-je exporter un graphique sous forme de vecteur (SVG) plutôt que comme image raster ?**

Oui. Un graphique est une forme, et son contenu peut être enregistré au format SVG à l'aide de la [méthode d'enregistrement shape-to-SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).

**Comment puis-je définir la taille exacte du graphique exporté en pixels ?**

Utilisez les surcharges de rendu d'image qui permettent de spécifier la taille ou l'échelle — la bibliothèque prend en charge le rendu d'objets avec les dimensions ou l'échelle souhaitées.

**Que dois-je faire si les polices dans les libellés et la légende apparaissent incorrectes après l'exportation ?**

[Chargez les polices requises](/slides/fr/net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) afin que le rendu du graphique préserve les métriques et l'apparence du texte.

**L'exportation respecte-t-elle le thème PowerPoint, les styles et les effets ?**

Oui. Le renduur d'Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), de sorte que l'apparence du graphique est préservée.

**Où puis-je trouver les capacités de rendu/export disponibles au-delà des images de graphiques ?**

Consultez la section exportation de l'[API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[documentation](/slides/fr/net/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [SVG](/slides/fr/net/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/net/convert-powerpoint-to-xps/), [HTML](/slides/fr/net/convert-powerpoint-to-html/), etc.) et les options de rendu associées.