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
description: "Esamina gli aggiornamenti delle API pubbliche e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}}

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) o [rimosse](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) e le altre modifiche introdotte con l'API Aspose.Slides per .NET 15.7.0.

{{% /alert %}}
## **Modifiche API Pubbliche**
#### **Enum ImagePixelFormat è stato aggiunto**
L'enumerazione Aspose.Slides.Export.ImagePixelFormat è stata aggiunta per specificare il formato pixel delle immagini generate.
#### **Metodo IChartDataPoint.GetAutomaticDataPointColor() è stato aggiunto**
Restituisce un colore automatico del punto dati basato su indice della serie, indice del punto dati, ParentSeriesGroup, proprietà IsColorVaried e stile del grafico.
Questo colore è usato per impostazione predefinita se FillType è uguale a NotDefined.
#### **Metodo RenderToGraphics è stato aggiunto a Slide**
Il metodo RenderToGraphics (e le sue overload) è stato aggiunto a Aspose.Slides.Slide per renderizzare una diapositiva in un oggetto Graphics.
#### **Proprietà PixelFormat è stata aggiunta a ITiffOptions e TiffOptions**
La proprietà PixelFormat è stata aggiunta a Aspose.Slides.Export.ITiffOptions e Aspose.Slides.Export.TiffOptions per specificare il formato pixel delle immagini TIFF generate.