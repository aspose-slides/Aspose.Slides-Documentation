---
title: API Public et Changements Incompatibles en Arrière dans Aspose.Slides pour .NET 16.1.0
type: docs
weight: 220
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajouts](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) ou [suppressions](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) de classes, méthodes, propriétés, etc., et d'autres changements introduits avec l'API Aspose.Slides pour .NET 16.1.0.

{{% /alert %}} 
## **Changements de l'API Public**


#### **La propriété RotationAngle a été ajoutée aux interfaces IChartTextBlockFormat et ITextFrameFormat**
La propriété RotationAngle a été ajoutée aux interfaces Aspose.Slides.Charts.IChartTextBlockFormat et Aspose.Slides.ITextFrameFormat.
Elle spécifie la rotation personnalisée appliquée au texte à l'intérieur de la zone de délimitation.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Titre personnalisé").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException déplacé du namespace Aspose.Slides.Odp au namespace Aspose.Slides**