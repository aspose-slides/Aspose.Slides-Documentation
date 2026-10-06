---
title: Limitazioni dei Metadati di Output
type: docs
weight: 320
url: /it/java/api-limitations/
keywords:
- limitazioni API
- formato di esportazione
- applicazione
- produttore
- proprietà del documento
- metadati
- generatore
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Aspose.Slides for Java scrive metadati di applicazione, creatore e produttore fissi nei file PPTX, PDF e ODP salvati, indipendentemente dal nome dell'applicazione impostato."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, alcuni metadati tecnici vengono scritti nel file di output. Questo articolo spiega le limitazioni relative ai campi di metadati `Application`, `Creator`, `Producer` e generator nei file PPTX, PDF e ODP.

## **Application e Producer**

Quando crei o esporti presentazioni con Aspose.Slides for Java, alcuni metadati tecnici vengono scritti nel file. Due campi sollevano spesso domande:

**Application** identifica il programma che ha creato o salvato per ultimo una presentazione **PPTX**. In Aspose.Slides for Java, questo valore è fisso e mostra il nome della libreria anziché il nome della tua app, anche se utilizzi [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifica il motore di rendering che ha generato il file finale durante l'esportazione. Nelle esportazioni **PDF**, i metadati utilizzano i campi **Creator** e **Producer**. Con Aspose.Slides for Java, entrambi sono fissi e riflettono la libreria e la sua versione.

**Cosa è limitato**

Non è possibile sovrascrivere questi campi tramite l'API per i formati sopra indicati. Per **PPTX**, la proprietà Application viene scritta come "Aspose.Slides for Java". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for Java" seguito dalla versione della libreria. Per **ODP**, il campo generator viene scritto come "Aspose.Slides for Java" seguito dalla versione della libreria. Questo comportamento è progettato così e si applica indipendentemente da come carichi o salvi il file, e indipendentemente dai valori assegnati usando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Questa restrizione non si applica ai file **PPT**: in un file PPT, il nome dell'applicazione impostato con [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) viene salvato.