---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 15.7.0
linktitle: Aspose.Slides för .NET 15.7.0
type: docs
weight: 180
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
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
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP-presentationer."
---
{{% alert color="primary" %}}

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) klasser, metoder, egenskaper med mera, samt andra förändringar som introducerats med Aspose.Slides för .NET 15.7.0 API.

{{% /alert %}}
## **Ändringar i offentligt API**
#### **Enum ImagePixelFormat har lagts till**
Enum Aspose.Slides.Export.ImagePixelFormat har lagts till för att specificera pixelformat för de genererade bilderna.
#### **Metoden IChartDataPoint.GetAutomaticDataPointColor() har lagts till**
Returnerar en automatisk färg för datapunkten baserat på seriens index, datapunktens index, ParentSeriesGroup, IsColorVaried‑egenskapen och diagramstilen.
Denna färg används som standard om FillType är NotDefined.
#### **Metoden RenderToGraphics har lagts till i Slide**
Metoden RenderToGraphics (och dess överlagringar) har lagts till i Aspose.Slides.Slide för att rendera en slide till ett Graphics‑objekt.
#### **Egenskapen PixelFormat har lagts till i ITiffOptions och TiffOptions**
Egenskapen PixelFormat har lagts till i Aspose.Slides.Export.ITiffOptions och Aspose.Slides.Export.TiffOptions för att specificera pixelformat för de genererade TIFF‑bilderna.