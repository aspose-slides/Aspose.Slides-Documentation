---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides pour .NET 15.8.0
linktitle: Aspose.Slides pour .NET 15.8.0
type: docs
weight: 190
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/), ainsi que d’autres changements introduits avec l'API Aspose.Slides for .NET 15.8.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **La propriété DoughnutHoleSize a été ajoutée à IChartSeries et ChartSeries**
Spécifie la taille du trou dans un diagramme en anneau.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```