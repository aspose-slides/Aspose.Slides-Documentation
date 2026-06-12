---
title: Sezione
type: docs
weight: 90
url: /it/nodejs-java/examples/elements/section/
keywords:
- esempio di codice
- sezione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive in Aspose.Slides per Node.js via Java: crea, rinomina, riordina e raggruppa le diapositive con esempi JavaScript per PPT, PPTX e ODP."
---
Esempi per gestire le sezioni di una presentazione — aggiungere, accedere, rimuovere e rinominarle programmaticamente usando **Aspose.Slides for Node.js via Java**.

## **Aggiungi una sezione**

Crea una sezione che inizia su una diapositiva specifica.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Specifica la diapositiva che segna l'inizio della sezione.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a una sezione**

Leggi le informazioni della sezione da una presentazione.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accedi a una sezione tramite indice.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi una sezione**

Elimina una sezione aggiunta in precedenza.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Rimuovi la prima sezione.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Rinomina una sezione**

Modifica il nome di una sezione esistente.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```