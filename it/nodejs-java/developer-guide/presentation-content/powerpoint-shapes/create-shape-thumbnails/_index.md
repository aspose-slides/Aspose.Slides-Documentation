---
title: Crea miniature delle forme di presentazione in JavaScript
linktitle: Miniature delle forme
type: docs
weight: 70
url: /it/nodejs-java/create-shape-thumbnails/
keywords:
- miniatura della forma
- immagine della forma
- render della forma
- rendering della forma
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Genera miniature di forme ad alta qualità dalle diapositive PowerPoint con JavaScript e Aspose.Slides per Node.js – crea ed esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides viene utilizzato per creare file di presentazione in cui ogni pagina è una diapositiva. Queste diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Ma a volte gli sviluppatori potrebbero aver bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides ti aiuta a generare immagini in miniatura delle forme della diapositiva. Come utilizzare questa funzionalità è descritto in questo articolo.  
Questo articolo spiega come generare miniature delle diapositive in modi diversi:

- Generare una miniatura di una forma all'interno di una diapositiva.  
- Generare una miniatura di una forma di diapositiva con dimensioni definite dall'utente.  
- Generare una miniatura di una forma nei limiti dell'aspetto della forma.

## **Generazione di miniature di forme dalle diapositive**
Per generare una miniatura di una forma da qualsiasi diapositiva usando Aspose.Slides per Node.js tramite Java, esegui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine in miniatura della forma](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getImage--) della diapositiva di riferimento alla scala predefinita.
1. Salva l'immagine in miniatura nel formato immagine preferito.

Questo esempio di codice mostra come generare una miniatura di una forma da una diapositiva:

```javascript
// Istanzia una classe Presentation che rappresenta il file di presentazione
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a piena scala
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Salva l'immagine su disco in formato PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generazione di miniature di forme con fattore di scala definito dall'utente**
Per generare la miniatura della forma di una diapositiva usando Aspose.Slides per Node.js tramite Java, esegui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine in miniatura della forma](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) della diapositiva di riferimento con dimensioni definite dall'utente.
1. Salva l'immagine in miniatura nel formato immagine preferito.

Questo esempio di codice mostra come generare una miniatura di una forma basata su un fattore di scala definito:

```javascript
// Istanzia una classe Presentation che rappresenta il file di presentazione
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a piena scala
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Salva l'immagine su disco in formato PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generazione di miniatura di forma nei limiti**
Questo metodo di creazione di miniature di forme consente agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura generata è limitata dai bordi della diapositiva. Per generare una miniatura di una forma di diapositiva nei limiti del suo aspetto, esegui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine in miniatura della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salva l'immagine in miniatura nel formato immagine preferito.

Questo esempio di codice è basato sui passaggi sopra:

```javascript
// Istanzia una classe Presentation che rappresenta il file di presentazione
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a piena scala
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Salva l'immagine su disco in formato PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance durante il rendering di una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` tiene conto degli [effetti visivi](/slides/it/nodejs-java/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Verrà comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Sono supportate forme di gruppo, grafici, SmartArt e altri oggetti complessi?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/), e [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartart/)) può essere salvato come miniatura o come SVG.

**Le font installate di sistema influiscono sulla qualità delle miniature per le forme di testo?**

Sì. Dovresti [fornire i font richiesti](/slides/it/nodejs-java/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/nodejs-java/font-substitution/)) per evitare fallback indesiderati e riformattazione del testo.