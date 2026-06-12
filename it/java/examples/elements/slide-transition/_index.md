---
title: Transizione diapositiva
type: docs
weight: 110
url: /it/java/examples/elements/slide-transition/
keywords:
- esempio di codice
- transizione diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci le transizioni delle diapositive in Aspose.Slides per Java: aggiungi, personalizza e sequenzia effetti e durate con esempi Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo mostra come applicare effetti di transizione delle diapositive e i tempi con **Aspose.Slides for Java**.

## **Aggiungi una transizione di diapositiva**

Applica un effetto di transizione dissolvenza alla prima diapositiva.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Applica una transizione di dissolvenza.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a una transizione di diapositiva**

Leggi il tipo di transizione attualmente assegnato a una diapositiva.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Accedi al tipo di transizione.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi una transizione di diapositiva**

Elimina qualsiasi effetto di transizione impostando il tipo su `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Rimuovi la transizione impostando none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Imposta la durata della transizione**

Specifica per quanto tempo la diapositiva viene visualizzata prima di avanzare automaticamente.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // in millisecondi.
    } finally {
        presentation.dispose();
    }
}
```