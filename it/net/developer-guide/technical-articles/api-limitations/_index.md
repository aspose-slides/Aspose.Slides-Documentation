---
title: Limitazioni dei metadati di output
type: docs
weight: 320
url: /it/net/api-limitations/
keywords:
- Limitazioni API
- formato di esportazione
- applicazione
- produttore
- proprietà del documento
- metadati
- generatore
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides per .NET scrive metadati fissi di applicazione, creatore e produttore nei file PPTX, PDF e ODP salvati, indipendentemente dal nome dell'applicazione impostato."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, alcuni metadati tecnici vengono scritti nel file di destinazione. Questo articolo spiega le limitazioni relative ai campi di metadati `Application`, `Creator`, `Producer` e generator nei file PPTX, PDF e ODP.

## **Applicazione e Produttore**

Quando crei o esporti presentazioni con Aspose.Slides per .NET, alcuni metadati tecnici vengono scritti nel file. Due campi sollevano spesso domande:

**Application** identifica il programma che ha creato o salvato per ultimo una presentazione **PPTX**. In Aspose.Slides per .NET, questo valore è fisso e mostra il nome della libreria invece del nome della tua app, anche se imposti [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifica il motore di rendering che ha generato il file finale durante l'esportazione. Nelle esportazioni **PDF**, i metadati usano i campi **Creator** e **Producer**. Con Aspose.Slides per .NET, entrambi sono fissi e riflettono la libreria e la sua versione.

**Cosa è limitato**

Non è possibile sovrascrivere questi campi tramite l'API per i formati sopraindicati. Per **PPTX**, la proprietà Application viene scritta come "Aspose.Slides for .NET". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for .NET" seguite dalla versione della libreria. Per **ODP**, il campo generator viene scritto come "Aspose.Slides for .NET" seguita dalla versione della libreria. Questo comportamento è progettato così e si applica indipendentemente da come carichi o salvi il file, e indipendentemente dai valori assegnati a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

Questa restrizione non si applica ai file **PPT**: in un file PPT, il nome dell'applicazione impostato in [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) viene salvato.