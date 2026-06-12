---
title: Gestire i tag e i dati personalizzati nelle presentazioni usando JavaScript
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/nodejs-java/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- tag
- dati personalizzati
- aggiungere tag
- coppie di valori
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come aggiungere, leggere, aggiornare e rimuovere tag e dati personalizzati in Aspose.Slides per Node.js, con esempi per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. Descrive brevemente come i dati vengono memorizzati nei file PPTX, osserva che i dati specifici di una presentazione possono esistere come tag e parti XML personalizzate, e descrive i tag come coppie chiave‑valore di stringhe.

Mostra inoltre come leggere i valori dei tag e come aggiungere tag a una presentazione, a una singola diapositiva o a una forma. Inoltre, l'articolo copre le operazioni comuni di gestione dei tag, come cancellare tutti i tag, rimuovere un tag per nome e recuperare l'elenco dei nomi dei tag.

## **Memorizzazione dei dati nei file di presentazione**

I file PPTX—elementi con estensione .pptx—sono memorizzati nel formato PresentationML, che fa parte della specifica Office Open XML. Il formato Office Open XML definisce la struttura dei dati contenuti nelle presentazioni. 

Con una *diapositiva* che è uno degli elementi delle presentazioni, una *parte della diapositiva* contiene il contenuto di una singola diapositiva. Una parte della diapositiva può avere relazioni esplicite con molte parti—come i Tag definiti dall'utente—definite da ISO/IEC 29500. 

I dati personalizzati (specifici di una presentazione) o dell'utente possono esistere come tag ([TagCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TagCollection)) e CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
I tag sono essenzialmente valori di coppie chiave‑stringa. 
{{% /alert %}} 

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde ai metodi [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) e [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) . Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per Node.js via Java per [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente è composto da due elementi:

- il nome di una proprietà personalizzata - `MyTag` 
- il valore della proprietà personalizzata - `My Tag Value`

Se è necessario classificare alcune presentazioni in base a una regola o proprietà specifica, è possibile trarre vantaggio dall'aggiungere tag a tali presentazioni. Ad esempio, se si vuole raggruppare tutte le presentazioni dei paesi del Nord America, è possibile creare un tag North American e assegnare i relativi paesi (USA, Messico e Canada) come valori. 

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) utilizzando Aspose.Slides per Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

I tag possono anche essere impostati per [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Oppure per qualsiasi [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Limitazioni**

I tag aggiunti tramite la collezione di tag dei dati personalizzati usando `getCustomData().getTags()` vengono memorizzati solo all'interno del file PowerPoint. **Non** vengono trasferiti nella struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF con i tag.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Alt Text** dell'oggetto (ad esempio, `shape.setAlternativeText("MyId")`). Dopo l'esportazione in PDF, l'Alt Text potrebbe apparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un'unica operazione?**

Sì. La [tag collection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/) supporta l'operazione [clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/clear/) che elimina tutte le coppie chiave‑valore in un'unica volta.

**Come posso eliminare un singolo tag per nome senza iterare sull'intera collezione?**

Utilizzare l'operazione [remove(name)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/remove/) su [TagCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/) per eliminare il tag per la sua chiave.

**Come posso recuperare l'elenco completo dei nomi dei tag per analisi o filtraggio?**

Utilizzare [getNamesOfTags](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) sulla [tag collection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/); restituisce un array con tutti i nomi dei tag.