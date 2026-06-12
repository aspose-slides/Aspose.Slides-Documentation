---
title: Limitazioni API
type: docs
weight: 320
url: /it/java/api-limitations/
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
- Java
- Aspose.Slides
description: "Scopri i limiti di Aspose.Slides per Java: le esportazioni impostano metadati Application/Producer fissi in PPT, PPTX, ODP e PDF, aiutandoti a pianificare le integrazioni senza sorprese."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, vengono scritti determinati metadati tecnici nel file di output. Questo articolo spiega le limitazioni relative ai campi di metadati `Application`, `Creator` e `Producer` nei file PPTX e PDF.

## **Application e Producer**

Quando crei o esporti presentazioni con Aspose.Slides for Java, alcuni metadati tecnici vengono scritti nel file. Due campi suscitano spesso domande:

**Application** identifica il programma che ha creato o salvato per ultimo una presentazione **PPTX**. In Aspose.Slides for Java, questo valore è fisso e mostra il fornitore della libreria anziché il nome della tua app, anche se utilizzi [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifica il motore di rendering che ha generato il file finale durante l'esportazione. Nelle esportazioni **PDF**, i metadati usano i campi **Creator** e **Producer**. Con Aspose.Slides for Java, entrambi sono fissi e riflettono la libreria e la sua versione.

**Cosa è limitato**

Non è possibile sovrascrivere questi campi tramite l'API per i formati sopra indicati. Per **PPTX**, la proprietà Application viene escrita come "Aspose.Slides for Java". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for Java x.x.x." Questo comportamento è deliberato e si applica indipendentemente da come carichi o salvi il file, e indipendentemente dai valori assegnati usando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).