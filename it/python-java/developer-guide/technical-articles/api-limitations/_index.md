---
title: Limitazioni API
type: docs
weight: 320
url: /it/python-java/api-limitations/
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
- Java
- Aspose.Slides
description: "Scopri le limitazioni di Aspose.Slides per Python via Java: metadati Application, Creator e Producer fissi nei file PPTX e PDF."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, vengono scritti alcuni metadati tecnici nel file di output. Questo articolo spiega le limitazioni relative ai campi di metadati `Application`, `Creator` e `Producer` nei file PPTX e PDF.

## **Applicazione e Produttore**

Quando crei o esporti presentazioni con Aspose.Slides for Python via Java, alcuni metadati tecnici vengono scritti nel file. Due campi sollevano spesso domande:

**Application** identifica il programma che ha creato o salvato per ultimo una presentazione **PPTX**. In Aspose.Slides for Python via Java, questo valore è fisso e mostra il fornitore della libreria piuttosto che il nome della tua app, anche se usi [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** identifica il motore di rendering che ha generato il file finale durante l'esportazione. Nelle esportazioni **PDF**, i metadati utilizzano i campi **Creator** e **Producer**. Con Aspose.Slides for Python via Java, entrambi sono fissi e riflettono la libreria e la sua versione.

**Cosa è limitato**

Non è possibile sovrascrivere questi campi tramite l'API per i formati sopra indicati. Per **PPTX**, la proprietà Application viene scritta come "Aspose.Slides for Java". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for Java x.x.x." Questo comportamento è previsto e si applica indipendentemente da come carichi o salvi il file, e indipendentemente dai valori assegnati usando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **FAQ**

**Posso sostituire il valore Application in un file PPTX con il nome della mia app?**

No. Il valore è fisso, anche se usi [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Posso sovrascrivere i campi Creator e Producer nelle esportazioni PDF?**

No. Entrambi i campi sono fissi e riflettono la libreria e la sua versione, indipendentemente da come carichi o salvi la presentazione.