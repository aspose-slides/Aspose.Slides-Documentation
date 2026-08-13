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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}}
Questa pagina elenca tutte le classi, i metodi, le proprietà [aggiunto](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) o [rimosso](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) e così via, e le altre modifiche introdotte con l'API di Aspose.Slides per .NET 16.1.0.
{{% /alert %}}
## **Modifiche all'API pubblica**

#### **Proprietà RotationAngle è stata aggiunta alle interfacce IChartTextBlockFormat e ITextFrameFormat**
La proprietà RotationAngle è stata aggiunta alle interfacce Aspose.Slides.Charts.IChartTextBlockFormat e Aspose.Slides.ITextFrameFormat.
Specifica la rotazione personalizzata applicata al testo all'interno del riquadro delimitante.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


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
#### **OdpException spostata dal namespace Aspose.Slides.Odp a quello Aspose.Slides**