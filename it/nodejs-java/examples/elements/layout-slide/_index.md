---
title: Diapositiva di layout
type: docs
weight: 20
url: /it/nodejs-java/examples/elements/layout-slide/
keywords:
- esempio di codice
- diapositiva di layout
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Diapositive master di layout in Aspose.Slides per Node.js: scegli, applica e personalizza i layout delle diapositive, i segnaposti e i master con esempi per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con le **Layout Slides** in Aspose.Slides per Node.js tramite Java. Una diapositiva di layout definisce il design e la formattazione ereditati dalle diapositive normali. È possibile aggiungere, accedere, clonare e rimuovere le diapositive di layout, nonché pulire quelle inutilizzate per ridurre la dimensione della presentazione.

## **Aggiungi una diapositiva di layout**

È possibile creare una diapositiva di layout personalizzata per definire una formattazione riutilizzabile.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Crea una diapositiva di layout con un tipo di layout vuoto e un nome personalizzato.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota 1:** Le diapositive di layout fungono da modelli per le singole diapositive. È possibile definire gli elementi comuni una volta e riutilizzarli in molte diapositive.

> 💡 **Nota 2:** Quando aggiungi forme o testo a una diapositiva di layout, tutte le diapositive basate su quel layout mostreranno automaticamente questo contenuto condiviso.  
> Lo screenshot seguente mostra due diapositive, ognuna delle quali eredita una casella di testo dalla stessa diapositiva di layout.

![Diapositive che ereditano contenuto del layout](layout-slide-result.png)

## **Accedi a una diapositiva di layout**

Le diapositive di layout possono essere accessibili tramite indice o per tipo di layout (ad es., `Blank`, `Title`, `SectionHeader`, ecc.).

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Accedi a una diapositiva di layout per indice.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Accedi a una diapositiva di layout per tipo.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi una diapositiva di layout**

È possibile rimuovere una specifica diapositiva di layout se non è più necessaria.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Ottieni una diapositiva di layout per tipo e rimuovila.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi diapositive di layout inutilizzate**

Per ridurre la dimensione della presentazione, è possibile rimuovere le diapositive di layout che non sono utilizzate da alcuna diapositiva normale.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Rimuove automaticamente tutte le diapositive di layout non referenziate da alcuna diapositiva.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Clona una diapositiva di layout**

È possibile duplicare una diapositiva di layout utilizzando il metodo `addClone`.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Ottieni una diapositiva di layout esistente per tipo.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Clona la diapositiva di layout alla fine della collezione di diapositive di layout.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Riepilogo:** Le diapositive di layout sono strumenti potenti per gestire una formattazione coerente tra le diapositive. Aspose.Slides consente il pieno controllo sulla creazione, gestione e ottimizzazione delle diapositive di layout.