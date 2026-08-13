---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.11.0
linktitle: Aspose.Slides pro .NET 15.11.0
type: docs
weight: 210
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: Prohlédněte si aktualizace veřejného API a zásadní změny v Aspose.Slides pro .NET, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP.
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [added](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) nebo [removed](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 15.11.0 API.

{{% /alert %}} 
## **Změny veřejného API**

#### **Zastaralé vlastnosti ve třídě DataLabelCollection byly odstraněny**
Zastaralé vlastnosti ve třídě DataLabelCollection byly odstraněny:
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

#### **Nová vlastnost FirstSlideNumber byla přidána do třídy Presentation**
Nová vlastnost FirstSlideNumber přidaná do třídy Presentation umožňuje získat nebo nastavit číslo první stránky v prezentaci.

Když je zadána nová hodnota FirstSlideNumber, všechna čísla snímků jsou přepočítána.

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