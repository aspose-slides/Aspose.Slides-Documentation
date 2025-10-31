---
title: Exporter les graphiques de présentation avec Python
linktitle: Exporter le graphique
type: docs
weight: 90
url: /fr/python-net/export-chart/
keywords:
- graphique
- graphique en image
- graphique comme image
- extraire l'image du graphique
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment exporter les graphiques de présentation avec Aspose.Slides for Python via .NET, en prenant en charge les formats PPT, PPTX et ODP, et simplifiez la génération de rapports dans n'importe quel flux de travail."
---

## **Obtenir l'image du graphique**
Aspose.Slides for Python via .NET offre la prise en charge de l'extraction de l'image d'un graphique spécifique. L'exemple d'échantillon ci‑dessous est fourni.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Puis-je exporter un graphique en tant que vecteur (SVG) au lieu d'une image raster ?**

Oui. Un graphique est une forme, et son contenu peut être enregistré au format SVG en utilisant la [méthode d'enregistrement shape-to-SVG](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/).

**Comment puis‑je définir la taille exacte du graphique exporté en pixels ?**

Utilisez les surcharges de rendu d'image qui permettent de spécifier la taille ou l'échelle — la bibliothèque prend en charge le rendu d'objets avec des dimensions ou une échelle données.

**Que faire si les polices des étiquettes et de la légende apparaissent incorrectes après l'exportation ?**

[Chargez les polices requises](/slides/fr/python-net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) afin que le rendu du graphique préserve les métriques et l'apparence du texte.

**L'exportation respecte‑t‑elle le thème, les styles et les effets de PowerPoint ?**

Oui. Le moteur de rendu d'Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), de sorte que l'apparence du graphique est préservée.

**Où puis‑je trouver les capacités de rendu/export disponibles au‑delà des images de graphiques ?**

Consultez la section d'exportation de l'[API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[documentation](/slides/fr/python-net/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/fr/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/python-net/convert-powerpoint-to-xps/), [HTML](/slides/fr/python-net/convert-powerpoint-to-html/), etc.) et les options de rendu associées.