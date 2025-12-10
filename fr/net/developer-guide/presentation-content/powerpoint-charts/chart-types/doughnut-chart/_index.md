---
title: Personnaliser les graphiques en anneau dans les présentations en .NET
linktitle: Graphique en anneau
type: docs
weight: 30
url: /fr/net/doughnut-chart/
keywords:
- graphique en anneau
- écart central
- taille du trou
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des graphiques en anneau dans Aspose.Slides pour .NET, en prenant en charge les formats PowerPoint pour des présentations dynamiques."
---

## **Spécifier l'écart central dans un graphique en anneau**
Afin de spécifier la taille du trou dans un graphique en anneau. Veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Ajouter un graphique en anneau à la diapositive.
- Spécifier la taille du trou dans le graphique en anneau.
- Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini la taille du trou dans le graphique en anneau.
```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Enregistrer la présentation sur le disque
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Puis-je créer un anneau à plusieurs niveaux avec plusieurs cercles ?**

Oui. Ajoutez plusieurs séries à un même graphique en anneau — chaque série devient un anneau distinct. L'ordre des anneaux est déterminé par l'ordre des séries dans la collection.

**Un anneau « explosé » (parts séparées) est‑il pris en charge ?**

Oui. Il existe un type de graphique Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) et une propriété d'explosion sur les points de données ; vous pouvez séparer les parts individuelles.

**Comment obtenir une image d'un graphique en anneau (PNG/SVG) pour un rapport ?**

Un graphique est une forme ; vous pouvez le rendre sous forme d'[raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ou exporter le graphique sous forme d'[SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).