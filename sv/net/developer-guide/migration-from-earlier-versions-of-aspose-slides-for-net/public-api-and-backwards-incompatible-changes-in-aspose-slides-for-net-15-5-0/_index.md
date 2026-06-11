---
title: Offentligt API och bakåtinkompatibla ändringar i Aspose.Slides för .NET 15.5.0
linktitle: Aspose.Slides för .NET 15.5.0
type: docs
weight: 160
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
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
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint-PPT, PPTX- och ODP-presentationslösningar."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) klasser, metoder, egenskaper osv., samt andra förändringar som införts med Aspose.Slides för .NET 15.5.0 API.

{{% /alert %}} 
## **Ändringar i offentligt API**
#### **Klassen CommonSlideViewProperties och gränssnittet ICommonSlideViewProperties har lagts till**
Klassen Aspose.Slides.CommonSlideViewProperties och gränssnittet Aspose.Slides.ICommonSlideViewProperties representerar gemensamma bildvisningsinställningar (för närvarande alternativ för visningsskala).
#### **IAxis.LabelOffset‑egenskap har lagts till**
IAxis.LabelOffset‑egenskapen anger avståndet för etiketter från axeln. Tillämplig på kategori- eller datumaxel.
#### **IChartTextBlockFormat.AutofitType‑egenskap har lagts till**
Att ändra denna egenskap kan ha en viss inverkan endast på dessa diagramdelar: DataLabel och DataLabelFormat (fullt stöd i PowerPoint 2013; i PowerPoint 2007 har det ingen effekt på rendering).
#### **IChartTextBlockFormat.WrapText‑egenskap har lagts till**
Att ändra denna egenskap kan ha en viss inverkan endast på dessa diagramdelar: DataLabel och DataLabelFormat (fullt stöd i PowerPoint 2007/2013).
#### **Marginegenskaper har lagts till i IChartTextBlockFormat**
Att ändra dessa egenskaper kan ha en viss inverkan endast på dessa diagramdelar: DataLabel och DataLabelFormat (fullt stöd i PowerPoint 2013; i PowerPoint 2007 har det ingen effekt på rendering).
#### **ViewProperties.NotesViewProperties‑egenskap har lagts till**
Aspose.Slides.ViewProperties.NotesViewProperties‑egenskapen har lagts till. Den anger gemensamma visningsinställningar som är kopplade till anteckningsvyläget.
#### **ViewProperties.SlideViewProperties‑egenskap har lagts till**
Aspose.Slides.ViewProperties.SlideViewProperties‑egenskapen har lagts till. Den anger gemensamma visningsinställningar som är kopplade till bildvyläget.