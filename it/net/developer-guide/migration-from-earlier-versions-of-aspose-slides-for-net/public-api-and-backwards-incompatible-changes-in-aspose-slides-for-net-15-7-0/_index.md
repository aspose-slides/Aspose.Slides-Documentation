---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 15.7.0
linktitle: Aspose.Slides per .NET 15.7.0
type: docs
weight: 180
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche di rottura in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [added](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) o [removed](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) introdotte con l'API di Aspose.Slides per .NET 15.7.0.
{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **Enum ImagePixelFormat è stato aggiunto**
L'enumeratore Aspose.Slides.Export.ImagePixelFormat è stato aggiunto per specificare il formato dei pixel per le immagini generate.
#### **Metodo IChartDataPoint.GetAutomaticDataPointColor() è stato aggiunto**
Restituisce un colore automatico del punto dati basato sull'indice della serie, sull'indice del punto dati, su ParentSeriesGroup, sulla proprietà IsColorVaried e sullo stile del grafico.
Questo colore è usato per impostazione predefinita se FillType è uguale a NotDefined.
#### **Metodo RenderToGraphics è stato aggiunto a Slide**
Il metodo RenderToGraphics (e le sue overload) è stato aggiunto a Aspose.Slides.Slide per il rendering di una slide su un oggetto Graphics.
#### **Proprietà PixelFormat è stata aggiunta a ITiffOptions e TiffOptions**
La proprietà PixelFormat è stata aggiunta a Aspose.Slides.Export.ITiffOptions e Aspose.Slides.Export.TiffOptions per specificare il formato dei pixel per le immagini TIFF generate.