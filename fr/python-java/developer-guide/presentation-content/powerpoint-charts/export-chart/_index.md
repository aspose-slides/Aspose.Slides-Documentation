---
title: Exporter les graphiques de présentation en Python via Java
linktitle: Exporter le graphique
type: docs
weight: 90
url: /fr/python-java/export-chart/
keywords:
- graphique
- graphique vers image
- graphique comme image
- extraire l'image du graphique
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à exporter des graphiques de présentation avec Aspose.Slides for Python via Java, prenant en charge les formats PPT et PPTX, et simplifiez la génération de rapports dans n'importe quel flux de travail."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'exporter un graphique d'une présentation sous forme d'image. Cet article montre comment obtenir une image d'un graphique et l'enregistrer, ce qui est utile lorsque vous devez réutiliser les visuels du graphique en dehors d'une présentation PowerPoint.

En plus du flux de travail d'exportation d'image de base, l'article répond également aux questions courantes liées à l'exportation, notamment la sauvegarde du contenu du graphique au format SVG, le contrôle de la taille de sortie via les options de rendu, le chargement des polices pour préserver l'apparence des étiquettes et de la légende, ainsi que la conservation du formatage original de la présentation tel que les thèmes, les styles, les remplissages et les effets lors du rendu.

## **Obtenir une image de graphique**
Aspose.Slides for Python via Java prend en charge l'extraction d'une image d'un graphique spécifique. L'exemple suivant montre comment procéder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je exporter un graphique sous forme vectorielle (SVG) plutôt qu'une image raster ?**

Oui. Un graphique est une forme, et son contenu peut être enregistré au format SVG en utilisant la [méthode d'enregistrement shape-to-SVG](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Comment puis-je définir la taille exacte du graphique exporté en pixels ?**

Utilisez les surcharges de rendu d'image qui vous permettent de spécifier la taille ou l'échelle — la bibliothèque prend en charge le rendu d'objets avec des dimensions/échelles données.

**Que faire si les polices des étiquettes et de la légende apparaissent incorrectes après l'exportation ?**

[Chargez les polices requises](/slides/fr/python-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/) afin que le rendu du graphique préserve les métriques et l'apparence du texte.

**L'exportation respecte-t-elle le thème, les styles et les effets de PowerPoint ?**

Oui. Le moteur de rendu d'Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), de sorte que l'apparence du graphique est préservée.

**Où puis-je trouver les fonctionnalités de rendu/export disponibles au‑delà des images de graphiques ?**

Consultez l'[API](https://reference.aspose.com/slides/fr/python-java/aspose.slides/)/[documentation](/slides/fr/python-java/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/fr/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/python-java/convert-powerpoint-to-xps/), [HTML](/slides/fr/python-java/convert-powerpoint-to-html/), etc.) ainsi que les options de rendu associées.