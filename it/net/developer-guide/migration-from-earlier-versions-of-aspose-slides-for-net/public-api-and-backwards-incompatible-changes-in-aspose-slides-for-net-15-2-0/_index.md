---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 15.2.0
linktitle: Aspose.Slides per .NET 15.2.0
type: docs
weight: 140
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
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
description: "Revisiona gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}}

Questa pagina elenca tutte le classi, i metodi, le proprietà [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) o [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/), e così via, nonché le altre modifiche introdotte con l'API di Aspose.Slides per .NET 15.2.0.

{{% /alert %}}
## **Modifiche all'API pubblica**
#### **Metodi AddDataPointForDoughnutSeries aggiunti**
Sono state aggiunte le due overload del metodo IChartDataPointCollection.AddDataPointForDoughnutSeries() per aggiungere punti dati nelle serie del tipo di grafico Doughnut.
#### **La classe Aspose.Slides.SmartArt.SmartArtShape è stata ereditata dalla classe Aspose.Slides.GeometryShape**
La classe Aspose.Slides.SmartArt.SmartArtShape è stata ereditata dalla classe Aspose.Slides.GeometryShape. Questa modifica migliora il modello oggetti di Aspose.Slides e aggiunge nuove funzionalità alla classe SmartArtShape.
#### **Metodi per rimuovere il punto dati del grafico e la categoria del grafico per indice aggiunti**
Il metodo IChartDataPointCollection.RemoveAt(int index) è stato aggiunto per rimuovere il punto dati del grafico in base al suo indice.
Il metodo IChartCategoryCollection.RemoveAt(int index) è stato aggiunto per rimuovere la categoria del grafico in base al suo indice.
#### **Il valore PptXPptY è stato aggiunto all'enumerazione Aspose.Slides.Animation.PropertyType**
Il valore PptXPptY è stato aggiunto all'enumerazione Aspose.Slides.Animation.PropertyType nell'ambito della correzione di un problema di serializzazione.
#### **Il metodo System.Drawing.Color GetAutomaticSeriesColor() è stato aggiunto a Aspose.Slides.Charts.IChartSeries**
Il metodo GetAutomaticSeriesColor restituisce un colore automatico della serie basato sull'indice della serie e sullo stile del grafico. Questo colore è utilizzato per impostazione predefinita se FillType è uguale a NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```