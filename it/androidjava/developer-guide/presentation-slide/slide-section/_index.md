---
title: Gestisci le sezioni delle diapositive nelle presentazioni su Android
linktitle: Sezione diapositive
type: docs
weight: 90
url: /it/androidjava/slide-section/
keywords:
- crea sezione
- aggiungi sezione
- modifica sezione
- cambia sezione
- nome sezione
- recupera diapositive sezione
- elabora diapositive sezione
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive con Aspose.Slides per Android tramite Java: crea, rinomina, riordina, recupera ed elabora le diapositive delle sezioni nelle presentazioni PPTX."
---
## **Introduzione**

Le sezioni organizzano le diapositive consecutive in gruppi nominati senza modificare il contenuto delle diapositive. Con Aspose.Slides per Android tramite Java, è possibile creare, riordinare, rinominare, ispezionare e rimuovere le sezioni tramite il metodo [Presentation.getSections](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSections--) .

Le sezioni sono particolarmente utili quando:

- una presentazione di grandi dimensioni deve essere suddivisa in argomenti o capitoli logici;
- diversi gruppi di diapositive sono assegnati a collaboratori differenti;
- le diapositive devono essere elaborate, spostate o unite come gruppi.

Scegli nomi di sezione concisi che descrivano lo scopo delle diapositive raggruppate. Poiché le sezioni fanno parte della struttura della presentazione, utilizza le API delle sezioni per determinare l’appartenenza invece di dedurla dalle posizioni delle diapositive.

## **Crea e gestisci le sezioni**

Usa [ISectionCollection.addSection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) per creare una sezione specificando il suo nome e la diapositiva iniziale. Aspose.Slides determina a quali diapositive appartiene la sezione dalla struttura delle sezioni corrente della presentazione.

La stessa [ISectionCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isectioncollection/) consente anche di:

- spostare una sezione insieme alle sue diapositive usando [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- rimuovere solo la definizione della sezione con [ISectionCollection.removeSection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), mantenendo le sue diapositive;
- rimuovere una sezione e le sue diapositive con [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- aggiungere una sezione vuota alla fine con [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

L’esempio seguente crea due sezioni, sposta una di esse, la rimuove insieme alle sue diapositive e aggiunge una sezione vuota:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Dopo queste operazioni, la presentazione contiene la sezione `Introduction` con le sue diapositive e una sezione vuota `Appendix`. La sezione `Results` e le sue diapositive sono state rimosse.

## **Rinomina le sezioni**

Per rinominare una sezione, chiama il suo metodo [ISection.setName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#setName-java.lang.String-). Le diapositive e la posizione della sezione rimangono invariate.

L’esempio seguente crea una sezione e ne cambia il nome:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Recupera diapositive dalle sezioni**

Il metodo [Presentation.getSections](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSections--) restituisce una [ISectionCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isectioncollection/) su cui è possibile iterare. Per ogni [ISection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/), chiama [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) per ottenere le diapositive che attualmente appartengono ad essa. Il metodo restituisce una [ISectionSlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isectionslidecollection/), che fornisce il conteggio, l’accesso indicizzato e l’iterazione.

L’esempio seguente crea due sezioni popolate e una sezione vuota, quindi stampa per ogni sezione il suo [nome](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getName--), il suo [identificatore](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getSectionId--), la [diapositiva iniziale](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), il conteggio delle diapositive e i numeri delle diapositive. Usa [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) per leggere la prima diapositiva e una dichiarazione `for` migliorata per elaborare ogni diapositiva. Per la sezione vuota, la collezione restituita ha dimensione zero, il metodo non viene chiamato e l’iterazione non esegue operazioni.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

L’appartenenza a una sezione è determinata dalla struttura delle sezioni della presentazione. Non calcolare manualmente l’intervallo di una sezione da [ISection.getStartedFromSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), dagli indici delle diapositive e dalla diapositiva iniziale della sezione successiva.

Le modifiche strutturali possono cambiare sia le diapositive restituite per una sezione sia i loro numeri. Ciò include il riordino delle diapositive, la clonazione di una diapositiva in una sezione, lo spostamento di una sezione con le sue diapositive, la rimozione di diapositive e la rimozione di sezioni. L’esempio successivo chiama [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) dopo ogni tale modifica invece di mantenere ipotesi sui confini precedenti della sezione.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Chiama nuovamente [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) ogni volta che diapositive o sezioni vengono riordinate, clonate, spostate o rimosse. Questo mantiene l’elaborazione successiva allineata con la struttura corrente della presentazione.

Il formato PPT (PowerPoint 97–2003) non conserva i metadati delle sezioni. Usa questo flusso di lavoro con un formato che supporta le sezioni, come PPTX; la conversione in PPT rimuove la struttura delle sezioni necessaria per le iterazioni successive.

## **FAQ**

**Le sezioni vengono preservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile nascondere un'intera sezione?**

No. Una sezione non possiede uno stato di visibilità. Per nascondere il suo contenuto, chiama [ISlide.setHidden](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#setHidden-boolean-) per ogni diapositiva nella sezione.

**Come posso trovare la sezione che contiene una diapositiva?**

Itera sulla collezione restituita da [Presentation.getSections](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSections--), chiama [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) per ogni sezione e confronta le diapositive restituite con la diapositiva di destinazione. Per una sezione non vuota, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) restituisce la sua prima diapositiva; per una sezione vuota, restituisce `null`.