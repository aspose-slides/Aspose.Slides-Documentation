---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 15.2.0
linktitle: Aspose.Slides för .NET 15.2.0
type: docs
weight: 140
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migration
- gammal kod
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
{{% alert color="primary" %}} 
Denna sida listar alla [added](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) eller [removed](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) klasser, metoder, egenskaper osv., samt andra ändringar som introducerats med Aspose.Slides för .NET 15.2.0 API.
{{% /alert %}} 
## **Ändringar i offentligt API**
#### **AddDataPointForDoughnutSeries-metoder har lagts till**
De två överlagringarna av IChartDataPointCollection.AddDataPointForDoughnutSeries()-metoden har lagts till för att lägga till datapunkter i serier av diagramtypen Doughnut.
#### **Aspose.Slides.SmartArt.SmartArtShape Class har ärvts från Aspose.Slides.GeometryShape Class**
Klassen Aspose.Slides.SmartArt.SmartArtShape har ärvt från klassen Aspose.Slides.GeometryShape. Denna förändring förbättrar Aspose.Slides-objektmodellen och lägger till nya funktioner i SmartArtShape class.
#### **Metoder för att ta bort diagramdatapunkt och diagramkategori efter index har lagts till**
Metoden IChartDataPointCollection.RemoveAt(int index) har lagts till för att ta bort en diagramdatapunkt efter dess index. Metoden IChartCategoryCollection.RemoveAt(int index) har lagts till för att ta bort en diagramkategori efter dess index.
#### **PptXPptY‑värdet har lagts till i Aspose.Slides.Animation.PropertyType‑enumerationen**
PptXPptY‑värdet har lagts till i Aspose.Slides.Animation.PropertyType‑enumerationen i samband med en fix för ett serialiseringsproblem.
#### **System.Drawing.Color GetAutomaticSeriesColor() Method har lagts till i Aspose.Slides.Charts.IChartSeries**
GetAutomaticSeriesColor‑metoden returnerar en automatisk färg för serien baserat på serieindex och diagramstil. Denna färg används som standard om FillType är lika med NotDefined.

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