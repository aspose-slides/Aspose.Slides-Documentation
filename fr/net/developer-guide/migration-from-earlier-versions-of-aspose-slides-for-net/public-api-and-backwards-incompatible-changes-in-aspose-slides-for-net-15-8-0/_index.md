---
title: API Publique et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour .NET 15.8.0
type: docs
weight: 190
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) ou [suppressions](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) de classes, méthodes, propriétés, etc., et d'autres changements introduits avec l'API Aspose.Slides pour .NET 15.8.0.

{{% /alert %}} 
## **Changements de l'API Publique**
#### **La propriété DoughnutHoleSize a été ajoutée à IChartSeries et ChartSeries**
Spécifie la taille du trou dans un graphique en anneau.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```