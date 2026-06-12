---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 16.1.0
linktitle: Aspose.Slides per .NET 16.1.0
type: docs
weight: 220
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esamina gli aggiornamenti delle API pubbliche e le modifiche incompatibili in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) o [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/), e le altre modifiche introdotte con l'API Aspose.Slides for .NET 16.1.0.

{{% /alert %}} 
## **Modifiche API Pubbliche**


#### **La proprietà RotationAngle è stata aggiunta alle interfacce IChartTextBlockFormat e ITextFrameFormat**
La proprietà RotationAngle è stata aggiunta alle interfacce Aspose.Slides.Charts.IChartTextBlockFormat e Aspose.Slides.ITextFrameFormat. Specifica la rotazione personalizzata che viene applicata al testo all'interno del riquadro.

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
#### **OdpException spostata da Aspose.Slides.Odp allo spazio dei nomi Aspose.Slides**