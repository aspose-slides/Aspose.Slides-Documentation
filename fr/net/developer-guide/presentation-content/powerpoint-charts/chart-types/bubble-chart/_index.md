---
title: Graphique à bulles
type: docs
url: /fr/net/bubble-chart/
keywords: "Graphique à bulles, taille du graphique, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Taille du graphique à bulles dans les présentations PowerPoint en C# ou .NET"
---

## **Mise à l'échelle de la taille des graphiques à bulles**
Aspose.Slides for .NET prend en charge la mise à l'échelle de la taille des graphiques à bulles. Dans Aspose.Slides for .NET, les propriétés **IChartSeries.BubbleSizeScale** et **IChartSeriesGroup.BubbleSizeScale** ont été ajoutées. L'exemple suivant est présenté.  
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```





## **Représenter les données en tant que tailles de graphiques à bulles**
La propriété **BubbleSizeRepresentation** a été ajoutée aux interfaces IChartSeries, IChartSeriesGroup et aux classes associées. **BubbleSizeRepresentation** spécifie comment les valeurs de taille des bulles sont représentées dans le graphique à bulles. Les valeurs possibles sont : **BubbleSizeRepresentationType.Area** et **BubbleSizeRepresentationType.Width**. En conséquence, l’énumération **BubbleSizeRepresentationType** a été ajoutée pour spécifier les manières possibles de représenter les données en tailles de graphiques à bulles. Le code d'exemple est donné ci-dessous.  
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Un « graphique à bulles avec effet 3 D » est‑il pris en charge, et en quoi diffère‑t‑il d’un graphique standard ?**

Oui. Il existe un type de graphique distinct, « Bubble with 3‑D ». Il applique un style 3‑D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Le type est disponible dans l’énumération [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

**Existe‑t‑il une limite au nombre de séries et de points dans un graphique à bulles ?**

Il n’y a pas de limite stricte au niveau de l’API ; les contraintes sont déterminées par les performances et la version cible de PowerPoint. Il est recommandé de garder le nombre de points raisonnable pour la lisibilité et la vitesse de rendu.

**Comment l’exportation affectera‑t‑elle l’apparence d’un graphique à bulles (PDF, images) ?**

L’exportation vers les formats pris en charge préserve l’apparence du graphique ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster/vectoriels, les règles générales de rendu des graphiques s’appliquent (résolution, anti‑aliasing), il faut donc choisir un DPI suffisant pour l’impression.