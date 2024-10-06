---
title: Graphique à Bulles
type: docs
url: /net/bubble-chart/
keywords: "Graphique à bulles, taille du graphique, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Taille des graphiques à bulles dans les présentations PowerPoint en C# ou .NET"
---

## **Mise à l'Échelle de la Taille du Graphique à Bulles**
Aspose.Slides pour .NET prend en charge la mise à l'échelle de la taille des graphiques à bulles. Dans Aspose.Slides pour .NET, les propriétés **IChartSeries.BubbleSizeScale** et **IChartSeriesGroup.BubbleSizeScale** ont été ajoutées. Un exemple d'échantillon est donné ci-dessous.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Représenter les Données comme des Tailles de Graphique à Bulles**
La propriété **BubbleSizeRepresentation** a été ajoutée aux interfaces IChartSeries, IChartSeriesGroup et aux classes associées. **BubbleSizeRepresentation** spécifie comment les valeurs de taille des bulles sont représentées dans le graphique à bulles. Les valeurs possibles sont : **BubbleSizeRepresentationType.Area** et **BubbleSizeRepresentationType.Width**. En conséquence, l'énumération **BubbleSizeRepresentationType** a été ajoutée pour spécifier les manières possibles de représenter des données sous forme de tailles de graphiques à bulles. Un code d'exemple est donné ci-dessous.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```