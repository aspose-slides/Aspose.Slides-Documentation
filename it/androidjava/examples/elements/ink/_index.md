---
title: Inchiostro
type: docs
weight: 180
url: /it/androidjava/examples/elements/ink/
keywords:
- esempio di codice
- inchiostro
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Lavora con l'Inchiostro in Aspose.Slides per Android: disegna, importa e modifica le pennellate, regola colore e spessore ed esporta in PPT, PPTX e ODP usando esempi Java."
---
Questo articolo fornisce esempi di accesso a forme di inchiostro esistenti e rimozione delle stesse utilizzando **Aspose.Slides for Android via Java**.

> ❗ **Nota:** Le forme di inchiostro rappresentano l'input dell'utente da dispositivi specializzati. Aspose.Slides non può creare nuove pennellate di inchiostro programmaticamente, ma è possibile leggere e modificare gli inchiostri esistenti.

## **Accesso all'inchiostro**

Leggi i tag dalla prima forma di inchiostro in una diapositiva.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // Usa tagName secondo necessità.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi l'inchiostro**

Elimina una forma di inchiostro dalla diapositiva se ne esiste una.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```