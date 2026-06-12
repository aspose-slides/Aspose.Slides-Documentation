---
title: Gestisci tag e dati personalizzati nelle presentazioni con PHP
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/php-java/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- etichetta
- dati personalizzati
- aggiungere tag
- coppie di valori
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come aggiungere, leggere, aggiornare e rimuovere tag e dati personalizzati in Aspose.Slides per PHP via Java, con esempi per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. Descrive brevemente come i dati sono memorizzati nei file PPTX, osserva che i dati specifici della presentazione possono esistere come tag e parti XML personalizzate, e definisce i tag come coppie di stringhe chiave‑valore.

Mostra inoltre come leggere i valori dei tag e come aggiungere tag a una presentazione, a una singola diapositiva o a una forma. Inoltre, l'articolo copre le operazioni comuni di gestione dei tag, come cancellare tutti i tag, rimuovere un tag per nome e recuperare l'elenco dei nomi dei tag.

## **Archiviazione dei dati nei file di presentazione**

I file PPTX—elementi con estensione .pptx—sono memorizzati nel formato PresentationML, che fa parte della specifica Office Open XML. Il formato Office Open XML definisce la struttura dei dati contenuti nelle presentazioni. 

Con una *diapositiva* che è uno degli elementi nelle presentazioni, una *parte della diapositiva* contiene il contenuto di una singola diapositiva. Una parte della diapositiva può avere relazioni esplicite con molte parti—come i Tag definiti dall'utente—definite da ISO/IEC 29500. 

I dati personalizzati (specifici di una presentazione) o dell'utente possono esistere come tag ([TagCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/)) e CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 

I tag sono essenzialmente valori a coppia chiave‑stringa. 

{{% /alert %}} 

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde ai metodi [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getKeywords) e [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#setKeywords). Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per PHP via Java per [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente è composto da due elementi: 

- il nome di una proprietà personalizzata - `MyTag` 
- il valore della proprietà personalizzata - `My Tag Value`

Se è necessario classificare alcune presentazioni in base a una regola o proprietà specifica, è possibile beneficiare dell'aggiunta di tag a tali presentazioni. Ad esempio, se si vuole raggruppare tutte le presentazioni dei paesi del Nord America, è possibile creare un tag Nord America e assegnare i paesi rilevanti (Stati Uniti, Messico e Canada) come valori. 

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) usando Aspose.Slides per PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

I tag possono anche essere impostati per [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

O per qualsiasi [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) individuale:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Limitazioni**

I tag aggiunti tramite la raccolta di tag dei dati personalizzati usando `getCustomData()->getTags()` vengono memorizzati solo nel file PowerPoint. Non vengono **trasferiti** alla struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF con tag.

**Soluzione alternativa**: È possibile memorizzare un identificatore personalizzato nel **Alt Text** dell'oggetto (ad es., `$shape->setAlternativeText("MyId")`). Dopo l'esportazione in PDF, il Alt Text potrebbe apparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un'unica operazione?**

Sì. La [tag collection](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/) supporta un'operazione [clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/clear/) che elimina tutte le coppie chiave‑valore in una volta.

**Come posso eliminare un singolo tag per nome senza iterare sull'intera collezione?**

Utilizzare l'operazione [remove(name)](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/remove/) sulla [tag collection](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/) per eliminare il tag per chiave.

**Come posso recuperare l'elenco completo dei nomi dei tag per analisi o filtraggio?**

Utilizzare [getNamesOfTags](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/getnamesoftags/) sulla [tag collection](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/); restituisce un array di tutti i nomi dei tag.