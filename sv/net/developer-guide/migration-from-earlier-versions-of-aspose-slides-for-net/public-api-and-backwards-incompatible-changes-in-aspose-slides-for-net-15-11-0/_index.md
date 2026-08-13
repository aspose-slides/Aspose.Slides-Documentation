---
title: Offentligt API och bakåt inkompatibla förändringar i Aspose.Slides för .NET 15.11.0
linktitle: Aspose.Slides för .NET 15.11.0
type: docs
weight: 210
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- migrering
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
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP‑presentationslösningar."
---
{{% alert color="info" %}} 

Denna sida listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) klasser, metoder, egenskaper osv., samt andra förändringar som införts med Aspose.Slides for .NET 15.11.0 API.

{{% /alert %}} 
## **Offentliga API‑ändringar**

#### **Obsoleta egenskaper i DataLabelCollection‑klassen har tagits bort**
Obsoleta egenskaper i DataLabelCollection‑klassen har tagits bort:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **Den nya egenskapen FirstSlideNumber har lagts till i Presentation‑klassen**
Den nya egenskapen FirstSlideNumber som lagts till i Presentation gör det möjligt att hämta eller ange numret på den första bilden i en presentation.

När ett nytt värde för FirstSlideNumber anges räknas alla bildnummer om.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string path = "sample.pptx";
string newPath = "output.pptx";

using (var pres = new Presentation(path))
{
    int firstSlideNumber = pres.FirstSlideNumber;

    pres.FirstSlideNumber = 10;

    pres.Save(newPath, SaveFormat.Pptx);
}
```