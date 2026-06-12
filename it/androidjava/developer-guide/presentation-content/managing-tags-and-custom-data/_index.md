---
title: Gestire tag e dati personalizzati nelle presentazioni su Android
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/androidjava/managing-tags-and-custom-data
keywords:
- proprietà del documento
- tag
- dati personalizzati
- aggiungere tag
- coppie di valori
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Aggiungi, leggi, aggiorna e rimuovi tag e dati personalizzati in Aspose.Slides per Android, con esempi Java per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce tag e dati personalizzati nelle presentazioni PowerPoint. Descrive brevemente come i dati sono memorizzati nei file PPTX, osserva che dati specifici della presentazione possono esistere come tag e parti XML personalizzate, e definisce i tag come coppie di stringa chiave‑valore.

Mostra inoltre come leggere i valori dei tag e come aggiungere tag a una presentazione, a una singola diapositiva o a una forma. Inoltre, l’articolo copre operazioni comuni di gestione dei tag come cancellare tutti i tag, rimuovere un tag per nome e recuperare l’elenco dei nomi dei tag.

## **Archiviazione dei dati nei file di presentazione**

I file PPTX—elementi con estensione .pptx—sono memorizzati nel formato PresentationML, parte della specifica Office Open XML. Il formato Office Open XML definisce la struttura dei dati contenuti nelle presentazioni.

Con una *diapositiva* che è uno degli elementi di una presentazione, una *parte diapositiva* contiene il contenuto di una singola diapositiva. Una parte diapositiva può avere relazioni esplicite con molte altre parti—come i Tag definiti dall’utente—definite da ISO/IEC 29500.

I dati personalizzati (specifici di una presentazione) o dell'utente possono esistere come tag ([ITagCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITagCollection)) e CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

I tag sono essenzialmente coppie chiave‑valore stringa. 

{{% /alert %}} 

## **Recuperare i valori dei tag**

In Slides, un tag corrisponde ai metodi [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) e [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per Android via Java per [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag è tipicamente composto da due elementi:

- il nome di una proprietà personalizzata - `MyTag`
- il valore della proprietà personalizzata - `My Tag Value`

Se è necessario classificare alcune presentazioni in base a una regola o proprietà specifica, è possibile beneficiare dell’aggiunta di tag a tali presentazioni. Ad esempio, se si vuole raggruppare tutte le presentazioni dei paesi del Nord America, si può creare un tag “North American” e assegnare i paesi pertinenti (gli Stati Uniti, il Messico e il Canada) come valori.

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) usando Aspose.Slides per Android via Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

I tag possono anche essere impostati per [Slide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Oppure per qualsiasi singola [Shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Limitazioni**

I tag aggiunti tramite la collezione di tag dei dati personalizzati usando `getCustomData().getTags()` vengono memorizzati solo all’interno del file PowerPoint. **Non** vengono trasferiti nella struttura dei tag PDF quando la presentazione è esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF taggato.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Testo alternativo** dell'oggetto (ad esempio, `shape.setAlternativeText("MyId")`). Dopo l’esportazione in PDF, il Testo alternativo può comparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un’unica operazione?**

Sì. La [tag collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/) supporta l’operazione [clear](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/#clear--) che elimina tutte le coppie chiave‑valore in una volta.

**Come elimino un singolo tag per nome senza iterare sull’intera collezione?**

Utilizzare l’operazione [remove(name)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) sulla [tag collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/) per cancellare il tag tramite la sua chiave.

**Come posso recuperare l’elenco completo dei nomi dei tag per analisi o filtraggio?**

Usare [getNamesOfTags](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) sulla [tag collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/); restituisce un array con tutti i nomi dei tag.