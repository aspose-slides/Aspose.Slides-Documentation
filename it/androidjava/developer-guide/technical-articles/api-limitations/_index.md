---
title: Limitazioni API
type: docs
weight: 320
url: /it/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "Conosci i limiti di Aspose.Slides per Android: le esportazioni impostano metadati Application/Producer fissi in PPT, PPTX, ODP e PDF—aiutandoti a pianificare le integrazioni senza sorprese."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, alcuni metadati tecnici vengono scritti nel file di output. Questo articolo spiega le limitazioni relative ai campi di metadati `Application`, `Creator` e `Producer` nei file PPTX e PDF.

## **Applicazione e Produttore**

Quando si creano o esportano presentazioni con Aspose.Slides for Android tramite Java, alcuni metadati tecnici vengono scritti nel file. Due campi sollevano spesso domande:

**Application** identifica il programma che ha creato o salvato per ultima una presentazione **PPTX**. In Aspose.Slides for Android tramite Java, questo valore è fisso e mostra il fornitore della libreria anziché il nome della tua app, anche se utilizzi [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifica il motore di rendering che ha generato il file finale durante l'esportazione. Nelle esportazioni **PDF**, i metadati utilizzano i campi **Creator** e **Producer**. Con Aspose.Slides for Android tramite Java, entrambi sono fissi e riflettono la libreria e la sua versione.

## **Cosa è limitato**

Non è possibile sovrascrivere questi campi tramite l'API per i formati sopra elencati. Per **PPTX**, la proprietà Application viene scritta come "Aspose.Slides for Android via Java". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for Android via Java x.x.x." Questo comportamento è intenzionale e si applica indipendentemente da come si carica o salva il file, e indipendentemente dai valori assegnati utilizzando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).