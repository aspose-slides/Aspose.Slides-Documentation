---
title: Gestire le sezioni delle diapositive nelle presentazioni con Java
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
- recuperare diapositive della sezione
- processare diapositive della sezione
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive con Aspose.Slides per Java: crea, rinomina, riordina, recupera e processa le diapositive delle sezioni nelle presentazioni PPTX."
---
## **Introduzione**

Le sezioni organizzano diapositive consecutive in gruppi denominati senza modificare il contenuto delle diapositive. Con Aspose.Slides per Java, è possibile creare, riordinare, rinominare, ispezionare e rimuovere le sezioni tramite il metodo [Presentation.getSections](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSections--).

Le sezioni sono particolarmente utili quando:
- una presentazione di grandi dimensioni deve essere suddivisa in argomenti o capitoli logici;
- diversi gruppi di diapositive sono assegnati a diversi collaboratori;
- le diapositive devono essere elaborate, spostate o unite come gruppi.

Scegliete nomi di sezione concisi che descrivano lo scopo delle diapositive raggruppate. Poiché le sezioni fanno parte della struttura della presentazione, utilizzate le API delle sezioni per determinare l'appartenenza anziché dedurla dalle posizioni delle diapositive.

## **Creare e gestire le sezioni**

Utilizzate [ISectionCollection.addSection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) per creare una sezione specificando il suo nome e la diapositiva iniziale. Aspose.Slides determina quali diapositive appartengono alla sezione dalla struttura delle sezioni corrente della presentazione.

La stessa [ISectionCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isectioncollection/) consente inoltre di:
- spostare una sezione insieme alle sue diapositive utilizzando [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- rimuovere solo la definizione della sezione con [ISectionCollection.removeSection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), mantenendo le sue diapositive;
- rimuovere una sezione e le sue diapositive con [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- aggiungere una sezione vuota alla fine con [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Il seguente esempio crea due sezioni, ne sposta una, la rimuove insieme alle sue diapositive e aggiunge una sezione vuota:

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

## **Rinominare le sezioni**

Per rinominare una sezione, chiamate il suo metodo [ISection.setName](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#setName-java.lang.String-). Le diapositive della sezione e la loro posizione rimangono inalterate.

Il seguente esempio crea una sezione e ne cambia il nome:

```java
import com.aspose.slides.ISection;
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

## **Recuperare le diapositive dalle sezioni**

Il metodo [Presentation.getSections](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSections--) restituisce un [ISectionCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isectioncollection/) che potete iterare. Per ogni [ISection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/), chiamate [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getSlidesListOfSection--) per ottenere le diapositive che attualmente gli appartengono. Il metodo restituisce un [ISectionSlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isectionslidecollection/), che fornisce un conteggio, accesso indicizzato e iterazione.

Il seguente esempio crea due sezioni popolate e una sezione vuota, quindi stampa per ogni sezione il [nome](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getName--) , l'[identificatore](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getSectionId--) , la [diapositiva iniziale](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getStartedFromSlide--) , il conteggio delle diapositive e i numeri delle diapositive. Utilizza [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/it/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) per leggere la prima diapositiva e un'istruzione `for` migliorata per elaborare ogni diapositiva. Per la sezione vuota, la collezione restituita ha dimensione zero, il metodo non viene chiamato e l'iterazione non esegue alcuna operazione.

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

L'appartenenza a una sezione è determinata dalla struttura delle sezioni della presentazione. Non calcolare manualmente l'intervallo di una sezione a partire da [ISection.getStartedFromSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getStartedFromSlide--), gli indici delle diapositive e la diapositiva iniziale della sezione successiva.

Le modifiche strutturali possono cambiare sia le diapositive restituite per una sezione sia i loro numeri. Ciò include il riordino delle diapositive, la clonazione di una diapositiva in una sezione, lo spostamento di una sezione insieme alle sue diapositive, la rimozione di diapositive e la rimozione di sezioni. Il prossimo esempio chiama [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getSlidesListOfSection--) dopo ogni tale cambiamento invece di mantenere ipotesi sui precedenti confini della sezione.

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

Chiamate nuovamente [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getSlidesListOfSection--) ogni volta che le diapositive o le sezioni sono riordinate, clonate, spostate o rimosse. Questo mantiene l'elaborazione successiva allineata con la struttura corrente della presentazione.

Il formato PPT (PowerPoint 97–2003) non preserva i metadati delle sezioni. Utilizzate questo flusso di lavoro con un formato che supporta le sezioni, come PPTX; la conversione in PPT rimuove la struttura delle sezioni necessaria per l'iterazione successiva.

## **Domande frequenti**

**Le sezioni vengono preservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**Un'intera sezione può essere "nascosta"?**

No. Una sezione non ha uno stato di visibilità. Per nascondere il suo contenuto, chiamate [ISlide.setHidden](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#setHidden-boolean-) per ogni diapositiva nella sezione.

**Come posso trovare la sezione che contiene una diapositiva?**

Iterate sulla collezione restituita da [Presentation.getSections](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSections--), chiamate [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getSlidesListOfSection--) per ogni sezione e confrontate le diapositive restituite con la diapositiva di destinazione. Per una sezione non vuota, [ISection.getStartedFromSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/isection/#getStartedFromSlide--) restituisce la sua prima diapositiva; per una sezione vuota, restituisce `null`.