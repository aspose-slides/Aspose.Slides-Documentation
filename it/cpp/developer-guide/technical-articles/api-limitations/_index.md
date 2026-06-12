---
title: Limitazioni API
type: docs
weight: 320
url: /it/cpp/api-limitations/
keywords:
- Limitazioni API
- formato di esportazione
- applicazione
- produttore
- proprietà del documento
- metadati
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Conosci i limiti di Aspose.Slides for C++: le esportazioni impostano metadati fissi Application/Producer in PPT, PPTX, ODP e PDF, aiutandoti a pianificare le integrazioni senza sorprese."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, alcuni metadati tecnici vengono scritti nel file di output. Questo articolo spiega le limitazioni relative ai campi metadati `Application`, `Creator` e `Producer` nei file PPTX e PDF.

## **Applicazione e Producer**

Quando crei o esporti presentazioni con Aspose.Slides for C++, alcuni metadati tecnici vengono scritti nel file. Due campi sollevano spesso domande:

**Application** identifica il programma che ha creato o salvato per ultimo una presentazione **PPTX**. In Aspose.Slides for C++, questo valore è fisso e mostra il fornitore della libreria anziché il nome della tua applicazione, anche se utilizzi [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/it/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** identifica il motore di rendering che ha generato il file finale durante l'esportazione. Nelle esportazioni **PDF**, i metadati utilizzano i campi **Creator** e **Producer**. Con Aspose.Slides for C++, entrambi sono fissi e riflettono la libreria e la sua versione.

**Cosa è limitato**

Non è possibile sovrascrivere questi campi tramite l'API per i formati sopra citati. Per **PPTX**, la proprietà Application viene scritta come "Aspose.Slides for C++". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for C++ x.x.x". Questo comportamento è progettato così e si applica indipendentemente dal modo in cui carichi o salvi il file, e indipendentemente dai valori assegnati utilizzando [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/it/cpp/aspose.slides/documentproperties/set_nameofapplication/).