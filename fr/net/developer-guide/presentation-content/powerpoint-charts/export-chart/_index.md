---
title: Exporter des graphiques de présentation dans .NET
linktitle: Exporter le graphique
type: docs
weight: 90
url: /fr/net/export-chart/
keywords:
- graphique
- graphique en image
- graphique comme image
- extraire l'image du graphique
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à exporter les graphiques de présentations avec Aspose.Slides pour .NET, prise en charge des formats PPT et PPTX, et simplifiez la génération de rapports dans n'importe quel flux de travail."
---

## **Obtenir l'image du graphique**
Aspose.Slides for .NET offre la prise en charge de l'extraction d'une image d'un graphique spécifique. L'exemple suivant est fourni.
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

**Puis-je exporter un graphique en tant que vecteur (SVG) au lieu d'une image raster ?**  
Oui. Un graphique est une forme, et son contenu peut être enregistré au format SVG en utilisant la [méthode d'enregistrement shape-to-SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).

**Comment puis‑je définir la taille exacte du graphique exporté en pixels ?**  
Utilisez les surcharges de rendu d'image qui permettent de spécifier la taille ou l'échelle — la bibliothèque prend en charge le rendu d'objets avec des dimensions ou une échelle données.

**Que faire si les polices des étiquettes et de la légende apparaissent incorrectes après l'exportation ?**  
[Chargez les polices requises](/slides/fr/net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) afin que le rendu du graphique préserve les métriques et l'apparence du texte.

**L'exportation respecte‑t‑elle le thème, les styles et les effets de PowerPoint ?**  
Oui. Le rendu d’Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), de sorte que l'apparence du graphique est conservée.

**Où puis‑je trouver les capacités de rendu/export disponibles au‑delà des images de graphiques ?**  
Consultez la section export de l'[API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[documentation](/slides/fr/net/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [SVG](/slides/fr/net/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/net/convert-powerpoint-to-xps/), [HTML](/slides/fr/net/convert-powerpoint-to-html/), etc.) et les options de rendu associées.