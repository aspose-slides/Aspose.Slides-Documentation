---
title: Limitazioni API
type: docs
weight: 320
url: /it/net/api-limitations/
keywords:
- limitazioni API
- formato di esportazione
- applicazione
- produttore
- proprietà del documento
- metadati
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri i limiti di Aspose.Slides per .NET: le esportazioni impostano metadati Application/Producer fissi in PPT, PPTX, ODP e PDF, aiutandoti a pianificare le integrazioni senza sorprese."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, alcuni metadati tecnici vengono scritti nel file di output. Questo articolo spiega le limitazioni relative ai campi di metadati `Application`, `Creator` e `Producer` nei file PPTX e PDF.

## **Applicazione e Produttore**

Quando crei o esporti presentazioni con Aspose.Slides per .NET, alcuni metadati tecnici vengono scritti nel file. Due campi suscitano spesso domande:

**Application** identifica il programma che ha creato o salvato per l’ultima volta una presentazione **PPTX**. In Aspose.Slides per .NET, questo valore è fisso e mostra il fornitore della libreria piuttosto che il nome della tua app, anche se imposti [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/it/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifica il motore di rendering che ha generato il file finale durante l’esportazione. nelle esportazioni **PDF**, i metadati utilizzano i campi **Creator** e **Producer**. Con Aspose.Slides per .NET, entrambi sono fissi e riflettono la libreria e la sua versione.

**Cosa è limitato**

Non è possibile sovrascrivere questi campi tramite l’API per i formati sopra indicati. Per **PPTX**, la proprietà Application viene scritta come "Aspose.Slides for .NET". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for .NET x.x.x". Questo comportamento è voluto e si applica indipendentemente da come carichi o salvi il file, e indipendentemente dai valori assegnati a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/it/net/aspose.slides/documentproperties/nameofapplication/).