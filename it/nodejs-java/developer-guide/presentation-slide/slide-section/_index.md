---
title: Gestire le sezioni delle diapositive nelle presentazioni usando JavaScript
linktitle: Sezione diapositiva
type: docs
weight: 90
url: /it/nodejs-java/slide-section/
keywords:
- creare sezione
- aggiungere sezione
- modificare sezione
- cambiare sezione
- nome della sezione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Ottimizza le sezioni delle diapositive in PowerPoint e OpenDocument con Aspose.Slides per Node.js — dividi, rinomina e riordina per ottimizzare i flussi di lavoro PPTX e ODP."
---
## **Introduzione**

Con Aspose.Slides per Node.js tramite Java, è possibile organizzare una presentazione PowerPoint in sezioni. È possibile creare sezioni che contengono diapositive specifiche.

Potresti voler creare sezioni e usarle per organizzare o dividere le diapositive di una presentazione in parti logiche in queste situazioni:

- Quando lavori su una presentazione di grandi dimensioni con altre persone o un team e devi assegnare determinate diapositive a un collega o a membri del team. 
- Quando gestisci una presentazione che contiene molte diapositive e fatichi a gestire o modificare il suo contenuto tutto in una volta.

Idealmente, dovresti creare una sezione che raggruppi diapositive simili—le diapositive hanno qualcosa in comune o possono esistere in un gruppo basato su una regola—e assegnare alla sezione un nome che descriva le diapositive al suo interno. 

## **Creazione di sezioni nelle presentazioni**

Per aggiungere una sezione che conterrà diapositive in una presentazione, Aspose.Slides per Node.js tramite Java fornisce il metodo [addSection()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) che consente di specificare il nome della sezione da creare e la diapositiva da cui la sezione inizia.

Questo esempio di codice mostra come creare una sezione in una presentazione in JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 terminerà a newSlide2 e dopo di esso inizierà section2
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifica dei nomi delle sezioni**

Dopo aver creato una sezione in una presentazione PowerPoint, potresti decidere di cambiarne il nome. 

Questo esempio di codice mostra come modificare il nome di una sezione in una presentazione in JavaScript utilizzando Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Le sezioni sono conservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**Un'intera sezione può essere “nascosta”?**

No. Solo le singole diapositive possono essere nascoste. Una sezione come entità non ha uno stato “nascosto”.

**Posso trovare rapidamente una sezione a partire da una diapositiva e, viceversa, la prima diapositiva di una sezione?**

Sì. Una sezione è definita univocamente dalla sua diapositiva iniziale; data una diapositiva è possibile determinare a quale sezione appartiene, e per una sezione è possibile accedere alla sua prima diapositiva.