---
title: Exporter les graphiques de présentation en C++
linktitle: Exporter le graphique
type: docs
weight: 90
url: /fr/cpp/export-chart/
keywords:
- graphique
- graphique en image
- graphique comme image
- extraire l'image du graphique
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez comment exporter les graphiques de présentation avec Aspose.Slides pour C++, en prenant en charge les formats PPT et PPTX, et rationalisez le reporting dans n’importe quel flux de travail."
---
## **Vue d’ensemble**

Aspose.Slides vous permet d’exporter un graphique d’une présentation sous forme d’image. Cet article montre comment obtenir une image d’un graphique et l’enregistrer, ce qui est utile lorsque vous devez réutiliser les visuels du graphique en dehors d’une présentation PowerPoint.

## **Obtenir une image de graphique**
Aspose.Slides pour C++ offre une prise en charge de l’extraction d’image d’un graphique spécifique. Un exemple d’échantillon est fourni ci-dessous.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Puis‑je exporter un graphique sous forme de vecteur (SVG) au lieu d’une image raster ?**

Oui. Un graphique est une forme, et son contenu peut être enregistré en SVG en utilisant la [méthode d’enregistrement shape-to-SVG saving method](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/writeassvg/).

**Comment puis‑je définir la taille exacte du graphique exporté en pixels ?**

Utilisez les surcharges de rendu d’image qui vous permettent de spécifier la taille ou l’échelle — la bibliothèque prend en charge le rendu d’objets avec des dimensions/échelle données.

**Que faire si les polices des libellés et de la légende apparaissent incorrectes après l’exportation ?**

[Chargez les polices requises](/slides/fr/cpp/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsloader/) afin que le rendu du graphique conserve les métriques et l’apparence du texte.

**L’exportation respecte‑t‑elle le thème, les styles et les effets de PowerPoint ?**

Oui. Le moteur de rendu d’Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), de sorte que l’apparence du graphique est préservée.

**Où puis‑je trouver les capacités de rendu/export disponibles au‑delà des images de graphique ?**

Consultez la section exportation de l’[API](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/)/[documentation](/slides/fr/cpp/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/cpp/convert-powerpoint-to-xps/), [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), etc.) et les options de rendu associées.