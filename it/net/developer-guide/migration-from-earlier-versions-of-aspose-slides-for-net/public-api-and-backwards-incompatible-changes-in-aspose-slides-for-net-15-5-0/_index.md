---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 15.5.0
linktitle: Aspose.Slides per .NET 15.5.0
type: docs
weight: 160
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche che introducono rotture in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}}

Questa pagina elenca tutti gli [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) o [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) classi, metodi, proprietà e così via, e le altre modifiche introdotte con l'API di Aspose.Slides per .NET 15.5.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **Classe CommonSlideViewProperties e Interfaccia ICommonSlideViewProperties sono state aggiunte**
La classe Aspose.Slides.CommonSlideViewProperties e l'interfaccia Aspose.Slides.ICommonSlideViewProperties rappresentano le proprietà comuni della vista diapositiva (attualmente le opzioni di scala della vista).
#### **Proprietà IAxis.LabelOffset è stata aggiunta**
La proprietà IAxis.LabelOffset specifica la distanza delle etichette dall'asse. Si applica all'asse di categoria o di data.
#### **Proprietà IChartTextBlockFormat.AutofitType è stata aggiunta**
La modifica di questa proprietà può influire solo su queste parti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2013; in PowerPoint 2007 non ha alcun effetto durante il rendering).
#### **Proprietà IChartTextBlockFormat.WrapText è stata aggiunta**
La modifica di questa proprietà può influire solo su queste parti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2007/2013).
#### **Proprietà Margin sono state aggiunte a IChartTextBlockFormat**
La modifica di queste proprietà può influire solo su queste parti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2013; in PowerPoint 2007 non ha alcun effetto durante il rendering).
#### **Proprietà ViewProperties.NotesViewProperties è stata aggiunta**
È stata aggiunta la proprietà Aspose.Slides.ViewProperties.NotesViewProperties. Specifica le proprietà comuni della vista associate alla modalità visualizzazione note.
#### **Proprietà ViewProperties.SlideViewProperties è stata aggiunta**
È stata aggiunta la proprietà Aspose.Slides.ViewProperties.SlideViewProperties. Specifica le proprietà comuni della vista associate alla modalità visualizzazione diapositiva.