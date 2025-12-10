---
title: Exporter les graphiques de présentation en С++
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
- С++
- Aspose.Slides
description: "Apprenez à exporter les graphiques de présentation avec Aspose.Slides pour С++, prise en charge des formats PPT et PPTX, et simplifiez la génération de rapports dans n'importe quel flux de travail."
---

## **Obtenir une image de graphique**
Aspose.Slides for C++ offre la prise en charge de l'extraction d'image d'un graphique spécifique. L'exemple ci-dessous est fourni.
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

**Puis-je exporter un graphique au format vectoriel (SVG) plutôt qu'en image raster ?**

Oui. Un graphique est une forme, et son contenu peut être enregistré au format SVG à l'aide de la [méthode d'enregistrement shape-to-SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/).

**Comment puis-je définir la taille exacte du graphique exporté en pixels ?**

Utilisez les surcharges de rendu d'image qui permettent de spécifier la taille ou l'échelle — la bibliothèque prend en charge le rendu d'objets avec des dimensions ou une échelle données.

**Que faire si les polices dans les libellés et la légende apparaissent incorrectes après l'exportation ?**

[Chargez les polices requises](/slides/fr/cpp/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) afin que le rendu du graphique préserve les métriques et l'apparence du texte.

**L'exportation respecte-t-elle le thème, les styles et les effets PowerPoint ?**

Oui. Le moteur de rendu d’Aspose.Slides suit le formatage de la présentation (thèmes, styles, remplissages, effets), de sorte que l'apparence du graphique est conservée.

**Où puis-je trouver les capacités de rendu/export disponibles au‑delà des images de graphiques ?**

Consultez la section export de l'[API](https://reference.aspose.com/slides/cpp/aspose.slides.export/)/[documentation](/slides/fr/cpp/convert-powerpoint/) pour les cibles de sortie ([PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/fr/cpp/convert-powerpoint-to-xps/), [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), etc.) ainsi que les options de rendu associées.