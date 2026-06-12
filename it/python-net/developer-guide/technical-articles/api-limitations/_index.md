---
title: Limiti API
type: docs
weight: 210
url: /it/python-net/api-limitations/
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
- Python
- Aspose.Slides
description: "Scopri i limiti di Aspose.Slides per Python: le esportazioni impostano metadati Application/Producer fissi in PPT, PPTX, ODP e PDF, aiutandoti a pianificare le integrazioni senza sorprese."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, vengono scritti nel file di output alcuni metadati tecnici. Questo articolo spiega le limitazioni relative ai campi di metadati `Application`, `Creator` e `Producer` nei file PPTX e PDF.

## **Application e Producer**

Quando crei o esporti presentazioni con Aspose.Slides for Python via .NET, alcuni metadati tecnici vengono scritti nel file. Due campi sollevano spesso domande:

**Application** identifica il programma che ha creato o salvato per ultimo una presentazione **PPTX**. In Aspose.Slides for Python via .NET, questo valore è fisso e mostra il fornitore della libreria anziché il nome della tua applicazione, anche se imposti [DocumentProperties.name_of_application](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** identifica il motore di rendering che ha generato il file finale durante l'esportazione. Nelle esportazioni **PDF**, i metadati utilizzano i campi **Creator** e **Producer**. Con Aspose.Slides for Python via .NET, entrambi sono fissati e riflettono la libreria e la sua versione.

**Cosa è limitato**

Non è possibile sovrascrivere questi campi tramite l'API per i formati sopra indicati. Per **PPTX**, la proprietà Application viene scritta come "Aspose.Slides for Python via .NET". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for Python via .NET x.x.x". Questo comportamento è previsto dalla progettazione e si applica indipendentemente da come carichi o salvi il file, e indipendentemente dai valori assegnati a [DocumentProperties.name_of_application](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/name_of_application/).