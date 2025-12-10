---
title: Personnaliser les graphiques en anneau dans les présentations en C++
linktitle: Graphique en anneau
type: docs
weight: 30
url: /fr/cpp/doughnut-chart/
keywords:
- graphique en anneau
- écart central
- taille du trou
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des graphiques en anneau avec Aspose.Slides pour C++, prenant en charge les formats PowerPoint pour des présentations dynamiques."
---

## **Spécifier l'écart central dans un graphique en anneau**
Pour spécifier la taille du trou dans un graphique en anneau, suivez les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Ajouter un graphique en anneau sur la diapositive.
- Spécifier la taille du trou dans le graphique en anneau.
- Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini la taille du trou dans le graphique en anneau.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Puis-je créer un anneau à plusieurs niveaux avec plusieurs cercles ?**

Oui. Ajoutez plusieurs séries à un même graphique en anneau — chaque série devient un cercle distinct. L'ordre des cercles est déterminé par l'ordre des séries dans la collection.

**Un anneau « explosé » (parts séparées) est‑il pris en charge ?**

Oui. Il existe un type de graphique Exploded Doughnut[chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) et une propriété d'explosion sur les points de données ; vous pouvez séparer les parts individuelles.

**Comment obtenir une image d'un graphique en anneau (PNG/SVG) pour un rapport ?**

Un graphique est une forme ; vous pouvez le rendre sous forme d'[image raster](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) ou exporter le graphique vers une [image SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/).