---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 14.2.0
linktitle: Aspose.Slides per .NET 14.2.0
type: docs
weight: 40
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
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
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
## **API Pubbliche e Modifiche Incompatibili Retroattive**
{{% alert color="primary" %}} 

Abbiamo apportato alcune modifiche all'API di Aspose.Slides per .NET 14.2.0. Alcune proprietà e metodi sono stati rimossi e alcuni sono stati spostati in un altro namespace.

{{% /alert %}} 
### **Metodi Aspose.Slides.IPresentation.Write(…) rimossi**
Questi metodi scrivevano gli oggetti Presentation solo in file con formato PPTX. Nella nuova API, la classe Presentation è destinata a lavorare con tutti i formati. È possibile utilizzare i metodi Presentation.Save(…) per salvare gli oggetti Presentation in tutti i formati supportati.
### **Classi relative agli Stili del Tema spostate nel namespace Aspose.Slides.Theme**
Le seguenti classi sono state spostate dal namespace Aspose.Slides al namespace Aspose.Slides.Theme.

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Modifiche da Aspose.Slides per .NET 8.X.0**
Le funzionalità di Aspose.Slides per .NET 8.4 sono state aggiunte a Aspose.Slides per .NET 14.2.0