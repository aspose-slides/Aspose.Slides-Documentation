---
title: Inchiostro
type: docs
weight: 180
url: /it/nodejs-java/examples/elements/ink/
keywords:
- esempio di codice
- inchiostro
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Lavora con l'Inchiostro in Aspose.Slides per Node.js: disegna, importa e modifica i tratti, regola colore e larghezza e esporta in PPT, PPTX e ODP con esempi."
---
Questo articolo fornisce esempi di accesso a forme di inchiostro esistenti e rimozione utilizzando **Aspose.Slides for Node.js via Java**.

> ❗ **Nota:** Le forme di inchiostro rappresentano l'input dell'utente da dispositivi specializzati. Aspose.Slides non può creare nuovi tratti di inchiostro programmaticamente, ma è possibile leggere e modificare l'inchiostro esistente.

## **Accesso all'inchiostro**

Recupera la prima forma di inchiostro su una diapositiva.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi l'inchiostro**

Elimina una forma di inchiostro dalla diapositiva.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponendo che la forma di inchiostro sia la prima forma sulla diapositiva.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```