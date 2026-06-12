---
title: Gestire le sezioni delle diapositive nelle presentazioni usando Java
linktitle: Sezione diapositiva
type: docs
weight: 90
url: /it/java/slide-section/
keywords:
- creare sezione
- aggiungere sezione
- modificare sezione
- cambiare sezione
- nome sezione
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Ottimizza le sezioni delle diapositive in PowerPoint e OpenDocument con Aspose.Slides per Java — dividi, rinomina e riordina per ottimizzare i flussi di lavoro PPTX e ODP."
---
## **Introduzione**

Con Aspose.Slides per Java, è possibile organizzare una presentazione PowerPoint in sezioni. È possibile creare sezioni che contengono diapositive specifiche. 

Potresti voler creare sezioni e usarle per organizzare o suddividere le diapositive in una presentazione in parti logiche in queste situazioni:

- Quando lavori su una presentazione di grandi dimensioni con altre persone o un team—e devi assegnare determinate diapositive a un collega o a alcuni membri del team. 
- Quando ti trovi di fronte a una presentazione che contiene molte diapositive—e fai fatica a gestire o modificare il suo contenuto tutto in una volta.

Idealmente, dovresti creare una sezione che racchiuda diapositive simili—le diapositive hanno qualcosa in comune o possono esistere in un gruppo basato su una regola—e dare alla sezione un nome che descriva le diapositive al suo interno. 

## **Creare sezioni nelle presentazioni**

Per aggiungere una sezione che conterrà le diapositive in una presentazione, Aspose.Slides per Java fornisce il metodo [addSection()](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) che consente di specificare il nome della sezione che si intende creare e la diapositiva da cui la sezione inizia. 

Questo esempio di codice mostra come creare una sezione in una presentazione in Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 terminerà a newSlide2 e dopo di essa section2 inizierà   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificare i nomi delle sezioni**

Dopo aver creato una sezione in una presentazione PowerPoint, potresti decidere di cambiarne il nome. 

Questo esempio di codice mostra come cambiare il nome di una sezione in una presentazione in Java usando Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Le sezioni vengono conservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile "nascondere" un'intera sezione?**

No. È possibile nascondere solo le diapositive singole. Una sezione come entità non ha uno stato di "nascosto".

**Posso trovare rapidamente una sezione a partire da una diapositiva e, viceversa, la prima diapositiva di una sezione?**

Sì. Una sezione è definita in modo univoco dalla sua diapositiva iniziale; data una diapositiva è possibile determinare a quale sezione appartiene e per una sezione è possibile accedere alla sua prima diapositiva.