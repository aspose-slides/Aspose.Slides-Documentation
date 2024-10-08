---
title: Graphique en Anneau
type: docs
weight: 30
url: /fr/net/doughnut-chart/
keywords: "Graphique en anneau, trou central, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Spécifiez le trou central dans un graphique en anneau dans une présentation PowerPoint en C# ou .NET"
---

## **Spécifiez le Trou Central dans un Graphique en Anneau**
Afin de spécifier la taille du trou dans un graphique en anneau. Veuillez suivre les étapes ci-dessous :

- Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Ajoutez un graphique en anneau sur la diapositive.
- Spécifiez la taille du trou dans un graphique en anneau.
- Écrivez la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini la taille du trou dans un graphique en anneau.

```c#
// Créez une instance de la classe Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Écrivez la présentation sur le disque
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```