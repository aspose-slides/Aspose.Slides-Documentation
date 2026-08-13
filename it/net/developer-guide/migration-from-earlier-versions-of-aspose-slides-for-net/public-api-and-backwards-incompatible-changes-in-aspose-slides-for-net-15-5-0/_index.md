---
title: Modifiche all'API pubblica e incompatibili retroattive in Aspose.Slides per .NET 15.5.0
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) o [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/), e le altre modifiche introdotte con l'API di Aspose.Slides per .NET 15.5.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **Classe CommonSlideViewProperties e interfaccia ICommonSlideViewProperties sono state aggiunte**
La classe Aspose.Slides.CommonSlideViewProperties e l'interfaccia Aspose.Slides.ICommonSlideViewProperties rappresentano le proprietà comuni di visualizzazione delle diapositive (attualmente le opzioni di scala della visualizzazione).
#### **Proprietà IAxis.LabelOffset è stata aggiunta**
La proprietà IAxis.LabelOffset specifica la distanza delle etichette dall'asse. Si applica all'asse di categoria o di data.
#### **Proprietà IChartTextBlockFormat.AutofitType aggiunta**
La modifica di questa proprietà può produrre un certo effetto solo per queste parti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2013; in PowerPoint 2007 non ha effetto durante il rendering).
#### **Proprietà IChartTextBlockFormat.WrapText aggiunta**
La modifica di questa proprietà può produrre un certo effetto solo per queste parti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2007/2013).
#### **Proprietà Margin aggiunte a IChartTextBlockFormat**
La modifica di queste proprietà può produrre un certo effetto solo per queste parti del grafico: DataLabel e DataLabelFormat (supporto completo in PowerPoint 2013; in PowerPoint 2007 non ha effetto durante il rendering).
#### **Proprietà ViewProperties.NotesViewProperties aggiunta**
È stata aggiunta la proprietà Aspose.Slides.ViewProperties.NotesViewProperties. Specifica le proprietà di visualizzazione comuni associate alla modalità di visualizzazione delle note.
#### **Proprietà ViewProperties.SlideViewProperties aggiunta**
È stata aggiunta la proprietà Aspose.Slides.ViewProperties.SlideViewProperties. Specifica le proprietà di visualizzazione comuni associate alla modalità di visualizzazione della diapositiva.