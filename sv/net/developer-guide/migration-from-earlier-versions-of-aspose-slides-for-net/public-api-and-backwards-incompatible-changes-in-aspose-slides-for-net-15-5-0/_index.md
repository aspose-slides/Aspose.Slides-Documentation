---
title: Offentlig API och bakåt inkompatibla förändringar i Aspose.Slides för .NET 15.5.0
linktitle: Aspose.Slides för .NET 15.5.0
type: docs
weight: 160
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- migrering
- äldre kod
- modern kod
- äldre tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) klasser, metoder, egenskaper osv., samt andra ändringar som införts med Aspose.Slides för .NET 15.5.0 API.

{{% /alert %}} 
## **Offentliga API-ändringar**
#### **Klassen CommonSlideViewProperties och gränssnittet ICommonSlideViewProperties har lagts till**
Klassen Aspose.Slides.CommonSlideViewProperties och gränssnittet Aspose.Slides.ICommonSlideViewProperties representerar gemensamma bildvisningsegenskaper (för närvarande alternativ för visningsskala).
#### **Egenskapen IAxis.LabelOffset har lagts till**
Egenskapen IAxis.LabelOffset specificerar avståndet för etiketter från axeln. Tillämplig på kategori- eller datumaxel.
#### **Egenskapen IChartTextBlockFormat.AutofitType har lagts till**
Ändring av denna egenskap kan ha viss påverkan endast för dessa diagramdelar: DataLabel och DataLabelFormat (fullt stöd i PowerPoint 2013; i PowerPoint 2007 har den ingen effekt på rendering).
#### **Egenskapen IChartTextBlockFormat.WrapText har lagts till**
Ändring av denna egenskap kan ha viss påverkan endast för dessa diagramdelar: DataLabel och DataLabelFormat (fullt stöd i PowerPoint 2007/2013).
#### **Marginegenskaper har lagts till IChartTextBlockFormat**
Ändring av dessa egenskaper kan ha viss påverkan endast för dessa diagramdelar: DataLabel och DataLabelFormat (fullt stöd i PowerPoint 2013; i PowerPoint 2007 har den ingen effekt på rendering).
#### **Egenskapen ViewProperties.NotesViewProperties har lagts till**
Egenskapen Aspose.Slides.ViewProperties.NotesViewProperties har lagts till. Den specificerar gemensamma visningsinställningar för noteringsvyläge.
#### **Egenskapen ViewProperties.SlideViewProperties har lagts till**
Egenskapen Aspose.Slides.ViewProperties.SlideViewProperties har lagts till. Den specificerar gemensamma visningsinställningar för bildvyläge.