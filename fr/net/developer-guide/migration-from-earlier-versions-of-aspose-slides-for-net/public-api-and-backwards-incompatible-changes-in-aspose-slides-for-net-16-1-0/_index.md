---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides pour .NET 16.1.0
linktitle: Aspose.Slides pour .NET 16.1.0
type: docs
weight: 220
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
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
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés et ainsi de suite [ajoutés](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) ou [supprimés](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/), ainsi que les autres modifications introduites avec l’API Aspose.Slides for .NET 16.1.0.

{{% /alert %}} 
## **Modifications de l'API publique**


#### **La propriété RotationAngle a été ajoutée aux interfaces IChartTextBlockFormat et ITextFrameFormat**
La propriété RotationAngle a été ajoutée aux interfaces Aspose.Slides.Charts.IChartTextBlockFormat et Aspose.Slides.ITextFrameFormat.
Elle spécifie la rotation personnalisée appliquée au texte à l'intérieur de la boîte englobante.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException déplacé du namespace Aspose.Slides.Odp vers le namespace Aspose.Slides**