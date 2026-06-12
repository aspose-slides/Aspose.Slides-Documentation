---
title: Inchiostro
type: docs
weight: 180
url: /it/java/examples/elements/ink/
keywords:
  - esempio di codice
  - inchiostro
  - PowerPoint
  - OpenDocument
  - presentazione
  - Java
  - Aspose.Slides
description: "Lavorare con l'Inchiostro in Aspose.Slides per Java: disegnare, importare e modificare i tratti, regolare colore e larghezza, ed esportare in PPT, PPTX e ODP usando esempi Java."
---
Questo articolo fornisce esempi di accesso a forme di inchiostro esistenti e della loro rimozione usando **Aspose.Slides for Java**.

> ❗ **Nota:** Le forme di inchiostro rappresentano input dell'utente da dispositivi specializzati. Aspose.Slides non può creare nuovi tratti di inchiostro programmaticamente, ma è possibile leggere e modificare l'inchiostro esistente.

## **Accedi all'Inchiostro**

Leggi i tag dalla prima forma di inchiostro su una diapositiva.

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

## **Rimuovi Inchiostro**

Elimina una forma di inchiostro dalla diapositiva se esiste.

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