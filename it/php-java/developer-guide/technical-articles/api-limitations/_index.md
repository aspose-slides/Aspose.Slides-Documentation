---
title: Limitazioni API
type: docs
weight: 320
url: /it/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Scopri i limiti di Aspose.Slides per PHP: le esportazioni impostano metadati fissi Application/Producer in PPT, PPTX, ODP e PDF—aiutandoti a pianificare le integrazioni senza sorprese."
---
## **Panoramica**

Quando le presentazioni vengono create o esportate con Aspose.Slides, alcuni metadati tecnici vengono scritti nel file di output. Questo articolo spiega le limitazioni relative ai campi di metadati `Application`, `Creator` e `Producer` nei file PPTX e PDF.

## **Application e Producer**

Quando crei o esporti presentazioni con Aspose.Slides for PHP via Java, alcuni metadati tecnici vengono scritti nel file. Due campi suscitano spesso domande:

**Application** identifica il programma che ha creato o salvato per ultimo una presentazione **PPTX**. In Aspose.Slides for PHP via Java, questo valore è fisso e mostra il fornitore della libreria anziché il nome della tua applicazione, anche se usi [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifica il motore di rendering che ha generato il file finale durante l'esportazione. Nelle esportazioni **PDF**, i metadati utilizzano i campi **Creator** e **Producer**. Con Aspose.Slides for PHP via Java, entrambi sono fissi e riflettono la libreria e la sua versione.

**Cosa è limitato**

Non puoi sovrascrivere questi campi tramite l'API per i formati sopra citati. Per **PPTX**, la proprietà Application viene scritta come "Aspose.Slides for PHP via Java". Per **PDF**, le proprietà Creator e Producer vengono scritte come "Aspose.Slides for PHP via Java x.x.x." Questo comportamento è progettato così e si applica indipendentemente da come carichi o salvi il file, e indipendentemente dai valori assegnati usando [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/setnameofapplication/).