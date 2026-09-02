---
title: Gestisci le sezioni delle diapositive nelle presentazioni con JavaScript
linktitle: Sezione diapositiva
type: docs
weight: 90
url: /it/nodejs-java/slide-section/
keywords:
- crea sezione
- aggiungi sezione
- modifica sezione
- cambia sezione
- nome sezione
- recupera diapositive della sezione
- elabora diapositive della sezione
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive con Aspose.Slides per Node.js tramite Java: crea, rinomina, riordina, recupera ed elabora le diapositive delle sezioni in presentazioni PPTX."
---
## **Introduzione**

Le sezioni organizzano diapositive consecutive in gruppi denominati senza modificare il contenuto della diapositiva. Con Aspose.Slides per Node.js tramite Java, è possibile creare, riordinare, rinominare, ispezionare e rimuovere le sezioni tramite il metodo [Presentation.getSections](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSections).

Le sezioni sono particolarmente utili quando:

- una presentazione di grandi dimensioni deve essere suddivisa in argomenti o capitoli logici;
- diversi gruppi di diapositive sono assegnati a collaboratori diversi;
- le diapositive devono essere elaborate, spostate o unite come gruppi.

Scegli nomi di sezione concisi che descrivano lo scopo delle diapositive raggruppate. Poiché le sezioni fanno parte della struttura della presentazione, utilizza le API delle sezioni per determinare l'appartenenza invece di derivarla dalle posizioni delle diapositive.

## **Crea e gestisci le sezioni**

Usa [SectionCollection.addSection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectioncollection/#addSection) per creare una sezione specificando il suo nome e la diapositiva iniziale. Aspose.Slides determina quali diapositive appartengono alla sezione dalla struttura delle sezioni corrente della presentazione.

La stessa [SectionCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectioncollection/) ti consente anche di:

- spostare una sezione insieme alle sue diapositive utilizzando [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- rimuovere solo la definizione della sezione con [SectionCollection.removeSection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectioncollection/#removeSection), mantenendo le sue diapositive;
- rimuovere una sezione e le sue diapositive con [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- aggiungere una sezione vuota alla fine con [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Il seguente esempio crea due sezioni, sposta una di esse, la rimuove insieme alle sue diapositive e aggiunge una sezione vuota:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Dopo queste operazioni, la presentazione contiene la sezione `Introduction` con le sue diapositive e una sezione vuota `Appendix`. La sezione `Results` e le sue diapositive sono state rimosse.

## **Rinomina le sezioni**

Per rinominare una sezione, chiama il suo metodo [Section.setName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#setName). Le diapositive e la posizione della sezione rimangono invariate.

Il seguente esempio crea una sezione e ne modifica il nome:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Recupera le diapositive dalle sezioni**

Il metodo [Presentation.getSections](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSections) restituisce una [SectionCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectioncollection/) che è possibile accedere per indice. Per ogni [Section](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/), chiama [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getSlidesListOfSection) per ottenere le diapositive che attualmente le appartengono. Il metodo restituisce una [SectionSlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectionslidecollection/), che fornisce un conteggio e accesso indicizzato.

Il seguente esempio crea due sezioni popolate e una sezione vuota, quindi stampa per ogni sezione il suo [name](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getStartedFromSlide), il conteggio delle diapositive e i numeri delle diapositive. Usa [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) per leggere sia la prima diapositiva sia ogni diapositiva nella collezione. Per la sezione vuota, la collezione restituita ha dimensione zero, l'accesso indicizzato è saltato e il ciclo non esegue operazioni.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

L'appartenenza alle sezioni è determinata dalla struttura delle sezioni della presentazione. Non calcolare manualmente l'intervallo di una sezione da [Section.getStartedFromSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getStartedFromSlide), dagli indici delle diapositive e dalla diapositiva iniziale della sezione successiva.

Le modifiche strutturali possono cambiare sia le diapositive restituite per una sezione sia i loro numeri. Questo include il riordino delle diapositive, la clonazione di una diapositiva in una sezione, lo spostamento di una sezione con le sue diapositive, la rimozione di diapositive e la rimozione di sezioni. Il prossimo esempio chiama [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getSlidesListOfSection) dopo ogni cambiamento invece di mantenere ipotesi sui precedenti limiti della sezione.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Chiama nuovamente [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getSlidesListOfSection) ogni volta che diapositive o sezioni vengono riordinate, clonate, spostate o rimosse. Questo mantiene l'elaborazione successiva allineata con la struttura attuale della presentazione.

Il formato PPT (PowerPoint 97–2003) non conserva i metadati delle sezioni. Usa questo flusso di lavoro con un formato che supporta le sezioni, come PPTX; la conversione in PPT rimuove la struttura delle sezioni necessaria per iterazioni successive.

## **FAQ**

**Le sezioni vengono preservate quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile nascondere un'intera sezione?**

No. Una sezione non ha uno stato di visibilità. Per nascondere il suo contenuto, chiama [Slide.setHidden](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#setHidden) per ogni diapositiva nella sezione.

**Come posso trovare la sezione che contiene una diapositiva?**

Accedi a ogni sezione nella collezione restituita da [Presentation.getSections](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSections), chiama [Section.getSlidesListOfSection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getSlidesListOfSection) per ciascuna sezione e confronta le diapositive restituite con la diapositiva target. Per una sezione non vuota, [Section.getStartedFromSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/section/#getStartedFromSlide) restituisce la sua prima diapositiva; per una sezione vuota, restituisce `null`.