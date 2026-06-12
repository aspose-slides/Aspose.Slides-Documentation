---
title: Transizione diapositiva
type: docs
weight: 110
url: /it/androidjava/examples/elements/slide-transition/
keywords:
- esempio di codice
- transizione diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci le transizioni diapositive in Aspose.Slides per Android: aggiungi, personalizza e sequenzia effetti e durate con esempi Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come applicare effetti di transizione delle diapositive e tempi con **Aspose.Slides for Android via Java**.

## **Aggiungere una transizione alla diapositiva**
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

## **Accedere a una transizione della diapositiva**
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

## **Rimuovere una transizione della diapositiva**
Rimuovi qualsiasi effetto di transizione impostando il tipo su `None`.

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

## **Impostare la durata della transizione**
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