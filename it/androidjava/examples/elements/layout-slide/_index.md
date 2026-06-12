---
title: Diapositiva Layout
type: docs
weight: 20
url: /it/androidjava/examples/elements/layout-slide/
keywords:
- esempio di codice
- diapositiva layout
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Diapositive master di layout in Aspose.Slides per Android: scegli, applica e personalizza layout diapositive, segnaposti e master con esempi Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con le **Diapositive Layout** in Aspose.Slides per Android tramite Java. Una diapositiva layout definisce il design e la formattazione ereditati dalle diapositive normali. È possibile aggiungere, accedere, clonare e rimuovere diapositive layout, oltre a pulire quelle inutilizzate per ridurre le dimensioni della presentazione.

## **Aggiungi una diapositiva layout**

È possibile creare una diapositiva layout personalizzata per definire una formattazione riutilizzabile. Ad esempio, si può aggiungere una casella di testo che appare su tutte le diapositive che utilizzano questo layout.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Crea una diapositiva layout con un tipo di layout vuoto e un nome personalizzato.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Aggiungi una casella di testo alla diapositiva layout.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Aggiungi due diapositive utilizzando questo layout; entrambe erediteranno il testo dal layout.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Le diapositive layout fungono da modelli per le singole diapositive. È possibile definire gli elementi comuni una sola volta e riutilizzarli in molte diapositive.
> 
> 💡 **Nota 2:** Quando si aggiungono forme o testo a una diapositiva layout, tutte le diapositive basate su quel layout visualizzeranno automaticamente questo contenuto condiviso.  
> Lo screenshot sottostante mostra due diapositive, ognuna delle quali eredita una casella di testo dalla stessa diapositiva layout.

![Diapositive che ereditano il contenuto del layout](layout-slide-result.png)

## **Accedi a una diapositiva layout**

Le diapositive layout possono essere accessate per indice o per tipo di layout (ad es., `Blank`, `Title`, `SectionHeader`, ecc.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Accedi a una diapositiva layout per indice.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Accedi a una diapositiva layout per tipo.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi una diapositiva layout**

È possibile rimuovere una diapositiva layout specifica se non è più necessaria.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Ottieni una diapositiva layout per tipo e rimuovila.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi le diapositive layout inutilizzate**

Per ridurre le dimensioni della presentazione, si può desiderare rimuovere le diapositive layout che non sono utilizzate da alcuna diapositiva normale.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Rimuove automaticamente tutte le diapositive layout non referenziate da alcuna diapositiva.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Clona una diapositiva layout**

È possibile duplicare una diapositiva layout usando il metodo `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Ottieni una diapositiva layout esistente per tipo.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Clona la diapositiva layout alla fine della collezione di diapositive layout.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Riepilogo:** Le diapositive layout sono strumenti potenti per gestire una formattazione coerente tra le diapositive. Aspose.Slides consente il pieno controllo sulla creazione, gestione e ottimizzazione delle diapositive layout.