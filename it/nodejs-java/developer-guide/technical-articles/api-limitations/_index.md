---
title: Limitazioni API
type: docs
weight: 320
url: /it/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri i limiti di Aspose.Slides for Node.js: le esportazioni impostano metadati fissi Application/Producer in PPT, PPTX, ODP e PDF—aiutandoti a pianificare le integrazioni senza sorprese."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, alcuni metadati tecnici vengono scritti nel file di output. Questo articolo spiega le limitazioni relative ai campi di metadati `Application`, `Creator` e `Producer` nei file PPTX e PDF.

## **Application e Producer**

Quando crei o esporti presentazioni con Aspose.Slides for Node.js via Java, alcuni metadati tecnici vengono scritti nel file. Due campi sollevano spesso domande:

**Application** identifica il programma che ha creato o salvato per ultima una presentazione **PPTX**. In Aspose.Slides for Node.js via Java, questo valore è fisso e mostra il fornitore della libreria invece del nome della tua applicazione, anche se utilizzi [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifica il motore di rendering che ha generato il file finale durante l'esportazione. Nelle esportazioni **PDF**, i metadati usano i campi **Creator** e **Producer**. Con Aspose.Slides for Node.js via Java, entrambi sono fissi e riflettono la libreria e la sua versione.

**Cosa è limitato**

Non è possibile sovrascrivere questi campi tramite l'API per i formati sopra indicati. Per **PPTX**, la proprietà Application viene scritta come "Aspose.Slides for Node.js via Java". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for Node.js via Java x.x.x." Questo comportamento è previsto per design e si applica indipendentemente da come carichi o salvi il file, e indipendentemente dai valori assegnati usando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).