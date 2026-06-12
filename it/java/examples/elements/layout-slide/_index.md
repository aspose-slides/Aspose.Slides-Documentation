---
title: "Slide di layout"
type: docs
weight: 20
url: /it/java/examples/elements/layout-slide/
keywords:
- "esempio di codice"
- "slide di layout"
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci le slide di layout master in Aspose.Slides per Java: scegli, applica e personalizza i layout delle slide, i segnaposto e i master con esempi Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con **Layout Slides** in Aspose.Slides per Java. Un layout slide definisce il design e la formattazione ereditati dalle diapositive normali. È possibile aggiungere, accedere, clonare e rimuovere layout slides, così come pulire quelli inutilizzati per ridurre la dimensione della presentazione.

## **Aggiungere una Layout Slide**

È possibile creare una layout slide personalizzata per definire una formattazione riutilizzabile. Ad esempio, si può aggiungere una casella di testo che appare su tutte le diapositive che utilizzano questo layout.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Crea una slide di layout con un tipo di layout vuoto e un nome personalizzato.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Aggiungi una casella di testo alla slide di layout.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Aggiungi due slide usando questo layout; entrambe erediteranno il testo dal layout.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Le layout slides fungono da modelli per le singole diapositive. È possibile definire gli elementi comuni una sola volta e riutilizzarli in molte diapositive.

> 💡 **Nota 2:** Quando si aggiungono forme o testo a una layout slide, tutte le diapositive basate su quel layout visualizzeranno automaticamente questo contenuto condiviso.  
> Lo screenshot qui sotto mostra due diapositive, ciascuna che eredita una casella di testo dallo stesso layout slide.

![Diapositive che ereditano contenuto del layout](layout-slide-result.png)

## **Accedere a una Layout Slide**

Le layout slides possono essere accedute per indice o per tipo di layout (ad es., `Blank`, `Title`, `SectionHeader`, ecc.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Accedi a una slide di layout per indice.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Accedi a una slide di layout per tipo.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere una Layout Slide**

È possibile rimuovere una specifica layout slide se non è più necessaria.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Ottieni una slide di layout per tipo e rimuovila.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere le Layout Slides Inutilizzate**

Per ridurre la dimensione della presentazione, è consigliabile rimuovere le layout slides che non sono utilizzate da alcuna diapositiva normale.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Rimuove automaticamente tutte le slide di layout non referenziate da nessuna slide.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Clonare una Layout Slide**

È possibile duplicare una layout slide usando il metodo `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Ottieni una slide di layout esistente per tipo.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Clona la slide di layout alla fine della collezione di slide di layout.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Riepilogo:** Le layout slides sono strumenti potenti per gestire una formattazione coerente tra le diapositive. Aspose.Slides consente il pieno controllo su creazione, gestione e ottimizzazione delle layout slides.