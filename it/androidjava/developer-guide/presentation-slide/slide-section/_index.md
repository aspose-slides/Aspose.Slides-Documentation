---
title: Gestisci le sezioni delle diapositive nelle presentazioni su Android
linktitle: Sezione diapositiva
type: docs
weight: 90
url: /it/androidjava/slide-section/
keywords:
- creare sezione
- aggiungere sezione
- modificare sezione
- cambiare sezione
- nome sezione
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Ottimizza le sezioni delle diapositive in PowerPoint e OpenDocument con Aspose.Slides per Android via Java—dividi, rinomina e riordina per ottimizzare i flussi di lavoro PPTX e ODP."
---
## **Introduzione**

Con Aspose.Slides per Android via Java, è possibile organizzare una presentazione PowerPoint in sezioni. È possibile creare sezioni che contengono diapositive specifiche.

Potresti voler creare sezioni e usarle per organizzare o dividere le diapositive in una presentazione in parti logiche nelle seguenti situazioni:

- Quando si lavora su una presentazione di grandi dimensioni con altre persone o un team—e si deve assegnare determinate diapositive a un collega o a alcuni membri del team. 
- Quando si ha a che fare con una presentazione che contiene molte diapositive—e si fatica a gestire o modificare il suo contenuto tutto in una volta.

Idealmente, dovresti creare una sezione che raggruppa diapositive simili—le diapositive hanno qualcosa in comune o possono esistere in un gruppo basato su una regola—e dare alla sezione un nome che descriva le diapositive al suo interno. 

## **Crea sezioni nelle presentazioni**

Per aggiungere una sezione che conterrà diapositive in una presentazione, Aspose.Slides per Android via Java fornisce il metodo [addSection()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) che consente di specificare il nome della sezione che si intende creare e la diapositiva da cui inizia la sezione.

Questo codice di esempio mostra come creare una sezione in una presentazione in Java:

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

## **Modifica i nomi delle sezioni**

Dopo aver creato una sezione in una presentazione PowerPoint, potresti decidere di cambiarne il nome. 

Questo codice di esempio mostra come modificare il nome di una sezione in una presentazione in Java usando Aspose.Slides:

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

**Le sezioni vengono preservate quando si salva in formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile nascondere un'intera sezione?**

No. È possibile nascondere solo le singole diapositive. Una sezione come entità non ha uno stato "nascosto".

**Posso trovare rapidamente una sezione a partire da una diapositiva e, viceversa, la prima diapositiva di una sezione?**

Sì. Una sezione è definita in modo univoco dalla diapositiva iniziale; data una diapositiva è possibile determinare a quale sezione appartiene, e per una sezione è possibile accedere alla sua prima diapositiva.