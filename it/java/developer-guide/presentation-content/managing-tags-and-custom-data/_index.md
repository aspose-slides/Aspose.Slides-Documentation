---
title: Gestire tag e dati personalizzati nelle presentazioni usando Java
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/java/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- tag
- dati personalizzati
- aggiungere tag
- valori coppia
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come aggiungere, leggere, aggiornare e rimuovere tag e dati personalizzati in Aspose.Slides per Java, con esempi per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. Descrive brevemente come i dati sono memorizzati nei file PPTX, osserva che i dati specifici della presentazione possono esistere come tag e parti XML personalizzate, e descrive i tag come coppie chiave-valore di stringhe.

Mostra inoltre come leggere i valori dei tag e come aggiungere tag a una presentazione, a una singola diapositiva o a una forma. Inoltre, l’articolo copre operazioni comuni di gestione dei tag come cancellare tutti i tag, rimuovere un tag per nome e recuperare l’elenco dei nomi dei tag.

## **Memorizzazione dei dati nei file di presentazione**

I file PPTX—elementi con estensione .pptx—sono memorizzati nel formato PresentationML, che fa parte della specifica Office Open XML. Il formato Office Open XML definisce la struttura dei dati contenuti nelle presentazioni.

Con una *diapositiva* che è uno degli elementi delle presentazioni, una *parte diapositiva* contiene il contenuto di una singola diapositiva. Una parte diapositiva può avere relazioni esplicite con molte parti—come i Tag definiti dall’utente—definite da ISO/IEC 29500.

I dati personalizzati (specifici di una presentazione) o dell’utente possono esistere come tag ([ITagCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITagCollection)) e CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

I tag sono essenzialmente valori di coppie chiave-stringa. 

{{% /alert %}} 

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde ai metodi [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IDocumentProperties#getKeywords--) e [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/it/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per Java per [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente è composto da due elementi:

- il nome di una proprietà personalizzata - `MyTag`
- il valore della proprietà personalizzata - `My Tag Value`

Se è necessario classificare alcune presentazioni in base a una regola o proprietà specifica, è possibile trarre vantaggio dall’aggiungere tag a quelle presentazioni. Ad esempio, se si vuole raggruppare tutte le presentazioni dei paesi del Nord America, si può creare un tag “North American” e assegnare i paesi pertinenti (Stati Uniti, Messico e Canada) come valori.

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) utilizzando Aspose.Slides per Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

I tag possono anche essere impostati per una [Slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Oppure per qualsiasi [Shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAutoShape) individuale:

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

I tag aggiunti tramite la raccolta di tag dei dati personalizzati usando `getCustomData().getTags()` sono memorizzati solo nel file PowerPoint. Non sono **trasferiti** alla struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF taggato.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Testo alternativo** dell'oggetto (ad esempio, `shape.setAlternativeText("MyId")`). Dopo l’esportazione in PDF, il Testo alternativo può apparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un’unica operazione?**

Sì. La [tag collection](https://reference.aspose.com/slides/it/java/com.aspose.slides/tagcollection/) supporta l’operazione [clear](https://reference.aspose.com/slides/it/java/com.aspose.slides/tagcollection/#clear--) che elimina tutte le coppie chiave-valore in una volta.

**Come posso eliminare un singolo tag per nome senza iterare sull’intera raccolta?**

Utilizzare l’operazione [Remove(name)](https://reference.aspose.com/slides/it/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) sulla [tag collection](https://reference.aspose.com/slides/it/java/com.aspose.slides/tagcollection/) per eliminare il tag tramite la sua chiave.

**Come posso recuperare l’elenco completo dei nomi dei tag per analisi o filtraggio?**

Utilizzare [getNamesOfTags](https://reference.aspose.com/slides/it/java/com.aspose.slides/tagcollection/#getNamesOfTags--) sulla [tag collection](https://reference.aspose.com/slides/it/java/com.aspose.slides/tagcollection/); restituisce un array di tutti i nomi dei tag.