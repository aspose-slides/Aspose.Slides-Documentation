---
title: Offentligt API och bakåtinkompatibla ändringar i Aspose.Slides för .NET 15.2.0
linktitle: Aspose.Slides för .NET 15.2.0
type: docs
weight: 140
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migrering
- äldre kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) klasser, metoder, egenskaper med mera, samt andra förändringar som införts med Aspose.Slides för .NET 15.2.0 API.

{{% /alert %}} 
## **Offentliga API-ändringar**
#### **AddDataPointForDoughnutSeries-metoder har lagts till**
De två överlagringarna av metoden IChartDataPointCollection.AddDataPointForDoughnutSeries() har lagts till för att lägga till datapunkter i serier av diagramtypen Doughnut.
#### **Klassen Aspose.Slides.SmartArt.SmartArtShape har ärvt från klassen Aspose.Slides.GeometryShape**
Klassen Aspose.Slides.SmartArt.SmartArtShape har ärvt från klassen Aspose.Slides.GeometryShape. Denna förändring förbättrar Aspose.Slides‑objektmodellen och lägger till nya funktioner i SmartArtShape‑klassen.
#### **Metoder för att ta bort diagram‑datapunkt och diagram‑kategori efter index har lagts till**
Metoden IChartDataPointCollection.RemoveAt(int index) har lagts till för att ta bort en diagram‑datapunkt efter dess index.
Metoden IChartCategoryCollection.RemoveAt(int index) har lagts till för att ta bort en diagram‑kategori efter dess index.
#### **Värdet PptXPptY har lagts till i uppräkningen Aspose.Slides.Animation.PropertyType**
Värdet PptXPptY har lagts till i uppräkningen Aspose.Slides.Animation.PropertyType som en del av en korrigering av ett serialiseringsproblem.
#### **Metoden System.Drawing.Color GetAutomaticSeriesColor() har lagts till i Aspose.Slides.Charts.IChartSeries**
Metoden GetAutomaticSeriesColor returnerar en automatisk färg för en serie baserat på serie‑index och diagramstil. Denna färg används som standard om FillType är lika med NotDefined.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

```