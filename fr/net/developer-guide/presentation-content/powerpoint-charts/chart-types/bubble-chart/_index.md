---
title: Personnaliser les graphiques à bulles dans les présentations en .NET
linktitle: Graphique à bulles
type: docs
url: /fr/net/bubble-chart/
keywords:
- graphique à bulles
- taille de bulle
- mise à l'échelle de taille
- représentation de taille
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créez et personnalisez des graphiques à bulles puissants dans PowerPoint avec Aspose.Slides pour .NET afin d'améliorer facilement votre visualisation de données."
---

## **Mise à l'échelle de la taille du graphique à bulles**
Aspose.Slides pour .NET prend en charge la mise à l'échelle de la taille des graphiques à bulles. Dans Aspose.Slides pour .NET les propriétés **IChartSeries.BubbleSizeScale** et **IChartSeriesGroup.BubbleSizeScale** ont été ajoutées. L'exemple de code ci‑dessous est fourni.
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Représenter les données comme tailles de graphiques à bulles**
La propriété **BubbleSizeRepresentation** a été ajoutée aux interfaces IChartSeries, IChartSeriesGroup et aux classes associées. **BubbleSizeRepresentation** indique comment les valeurs de taille des bulles sont représentées dans le graphique à bulles. Les valeurs possibles sont : **BubbleSizeRepresentationType.Area** et **BubbleSizeRepresentationType.Width**. En conséquence, l'énumération **BubbleSizeRepresentationType** a été ajoutée pour spécifier les différentes manières de représenter les données comme tailles de graphiques à bulles. Le code d'exemple est donné ci‑dessous.
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Un "graphique à bulles avec effet 3-D" est‑il pris en charge, et comment diffère‑t‑il d’un graphique standard ?**

Oui. Il existe un type de graphique distinct, « Bubble with 3-D ». Il applique un style 3-D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Le type est disponible dans l’énumération [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

**Existe‑t‑il une limite du nombre de séries et de points dans un graphique à bulles ?**

Il n’y a pas de limite stricte au niveau de l’API ; les contraintes sont déterminées par les performances et la version cible de PowerPoint. Il est recommandé de garder le nombre de points raisonnable pour assurer la lisibilité et la vitesse de rendu.

**Comment l’exportation affecte‑t‑elle l’apparence d’un graphique à bulles (PDF, images) ?**

L’exportation vers les formats pris en charge conserve l’apparence du graphique ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster ou vectoriels, les règles générales de rendu graphique des graphiques s’appliquent (résolution, anti‑aliasing), il faut donc choisir un DPI suffisant pour l’impression.