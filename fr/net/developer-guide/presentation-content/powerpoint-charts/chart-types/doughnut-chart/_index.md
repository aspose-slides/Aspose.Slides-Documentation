---
title: Graphique en anneau
type: docs
weight: 30
url: /fr/net/doughnut-chart/
keywords: "Graphique en anneau, écart central, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Spécifier l'écart central dans un graphique en anneau dans une présentation PowerPoint en C# ou .NET"
---

## **Spécifier l'écart central dans un graphique en anneau**
Pour spécifier la taille du trou dans un graphique en anneau, suivez les étapes ci-dessous :

- Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Ajoutez un graphique en anneau sur la diapositive.
- Spécifiez la taille du trou dans un graphique en anneau.
- Enregistrez la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini la taille du trou dans un graphique en anneau.
```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Enregistrer la présentation sur le disque
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Puis‑je créer un graphique en anneau à plusieurs niveaux avec plusieurs anneaux ?**

Oui. Ajoutez plusieurs séries à un même graphique en anneau — chaque série devient un anneau distinct. L'ordre des anneaux est déterminé par l'ordre des séries dans la collection.

**Le graphique en anneau « explosé » (parts séparées) est‑il pris en charge ?**

Oui. Il existe un type de graphique [Exploded Doughnut](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) et une propriété d'explosion sur les points de données ; vous pouvez séparer les parts individuellement.

**Comment obtenir une image d'un graphique en anneau (PNG/SVG) pour un rapport ?**

Un graphique est une forme ; vous pouvez le rendre sous forme d'[image raster](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ou exporter le graphique vers une [image SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).