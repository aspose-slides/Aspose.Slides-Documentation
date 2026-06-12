---
title: Diapositiva
type: docs
weight: 10
url: /it/androidjava/examples/elements/slide/
keywords:
- esempio di codice
- diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci le diapositive in Aspose.Slides per Android: crea, clona, riordina, ridimensiona, imposta gli sfondi e applica le transizioni con Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo fornisce una serie di esempi che mostrano come lavorare con le diapositive usando **Aspose.Slides for Android via Java**. Imparerai come aggiungere, accedere, clonare, riordinare e rimuovere diapositive usando la classe `Presentation`.

Ogni esempio di seguito include una breve spiegazione seguita da uno snippet di codice in Java.

## **Aggiungi una diapositiva**

Per aggiungere una nuova diapositiva, devi prima selezionare un layout. In questo esempio, usiamo il layout `Blank` e aggiungiamo una diapositiva vuota alla presentazione.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota:** Ogni layout di diapositiva deriva da una diapositiva master, che definisce il design complessivo e la struttura dei segnaposto. L'immagine seguente illustra come le diapositive master e i loro layout associati sono organizzati in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Accedi alle diapositive per indice**

Puoi accedere alle diapositive usando il loro indice, oppure trovare l'indice di una diapositiva basandoti su un riferimento. Questo è utile per iterare o modificare diapositive specifiche.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Aggiungi un'altra diapositiva vuota.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Accedi alle diapositive per indice.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Ottieni l'indice della diapositiva da un riferimento, poi accedila per indice.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Clona una diapositiva**

Questo esempio dimostra come clonare una diapositiva esistente. La diapositiva clonata viene aggiunta automaticamente alla fine della raccolta di diapositive.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Riordina le diapositive**

Puoi cambiare l'ordine delle diapositive spostandone una in un nuovo indice. In questo caso, spostiamo una diapositiva clonata nella prima posizione.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi una diapositiva**

Per rimuovere una diapositiva, basta fare riferimento ad essa e chiamare `remove`. Questo esempio aggiunge una seconda diapositiva e poi rimuove l'originale, lasciando solo quella nuova.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```