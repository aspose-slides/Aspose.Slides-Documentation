---
title: Exporter un Graphique
type: docs
weight: 90
url: /net/export-chart/
keywords:
- graphique
- image de graphique
- extraire l'image de graphique
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Obtenez des images de graphiques à partir de présentations PowerPoint en C# ou .NET"
---

## **Obtenir l'Image d'un Graphique**
Aspose.Slides pour .NET fournit un support pour extraire l'image d'un graphique spécifique. Un exemple de code est donné ci-dessous.

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