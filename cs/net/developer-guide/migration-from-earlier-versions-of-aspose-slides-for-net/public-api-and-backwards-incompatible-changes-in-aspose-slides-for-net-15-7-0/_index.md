---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.7.0
linktitle: Aspose.Slides pro .NET 15.7.0
type: docs
weight: 180
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a zásadní změny v Aspose.Slides pro .NET, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka vypisuje všechny [přidáno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) nebo [odebráno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 15.7.0.

{{% /alert %}} 
## **Veřejné změny API**
#### **Enum ImagePixelFormat byl přidán**
Enum Aspose.Slides.Export.ImagePixelFormat byl přidán pro určení formátu pixelů pro generované obrázky.
#### **Metoda IChartDataPoint.GetAutomaticDataPointColor() byla přidána**
Vrací automatickou barvu datového bodu na základě indexu řady, indexu datového bodu, ParentSeriesGroup, vlastnosti IsColorVaried a stylu grafu.
Tato barva je použita ve výchozím nastavení, pokud FillType je rovno NotDefined.
#### **Metoda RenderToGraphics byla přidána do Slide**
Metoda RenderToGraphics (a její přetížení) byla přidána do Aspose.Slides.Slide pro vykreslení snímku do objektu Graphics.
#### **Vlastnost PixelFormat byla přidána do ITiffOptions a TiffOptions**
Vlastnost PixelFormat byla přidána do Aspose.Slides.Export.ITiffOptions a Aspose.Slides.Export.TiffOptions pro určení formátu pixelů pro generované TIFF obrázky.