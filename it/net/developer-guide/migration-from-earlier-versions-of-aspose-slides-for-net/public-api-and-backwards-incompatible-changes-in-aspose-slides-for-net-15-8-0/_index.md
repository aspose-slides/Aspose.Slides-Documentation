---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 15.8.0
linktitle: Aspose.Slides per .NET 15.8.0
type: docs
weight: 190
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}}
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via aggiunti o rimossi, nonché le altre modifiche introdotte con l'API di Aspose.Slides per .NET 15.8.0.
{{% /alert %}}
## **Modifiche all'API pubblica**
#### **La proprietà DoughnutHoleSize è stata aggiunta a IChartSeries e ChartSeries**
Specifica la dimensione del foro in un grafico a ciambella.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```