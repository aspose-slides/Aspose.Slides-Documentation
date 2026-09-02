---
title: Crea miniature di forme di presentazione in JavaScript
linktitle: Miniature di forme
type: docs
weight: 70
url: /it/nodejs-java/create-shape-thumbnails/
keywords:
- miniatura forma
- immagine forma
- renderizzare forma
- renderizzazione forma
- limiti visivi
- limiti forma
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Genera miniature di forma ad alta qualità dalle diapositive PowerPoint con JavaScript e Aspose.Slides per Node.js – crea ed esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides viene utilizzato per creare file di presentazione in cui ogni pagina è una diapositiva. Queste diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides ti aiuta a generare immagini in miniatura delle forme della diapositiva. Come utilizzare questa funzionalità è descritto in questo articolo.
Questo articolo spiega come generare miniature diapositive in diversi modi:

- Generare una miniatura di una forma all'interno di una diapositiva.
- Generare una miniatura di una forma per una forma della diapositiva con dimensioni definite dall'utente.
- Generare una miniatura di una forma nei limiti dell'aspetto di una forma.

## **Generazione di miniature di forme dalle diapositive**
Per generare una miniatura di una forma da qualsiasi diapositiva utilizzando Aspose.Slides per Node.js tramite Java, esegui i seguenti passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine miniatura della forma](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getImage--) della diapositiva di riferimento con la scala predefinita.
1. Salva l'immagine miniatura nel formato immagine preferito.

```javascript
// Instanzia una classe Presentation che rappresenta il file di presentazione
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a scala completa
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
Per generare la miniatura della forma di una diapositiva utilizzando Aspose.Slides per Node.js tramite Java, esegui i seguenti passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine miniatura della forma](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) della diapositiva di riferimento con dimensioni definite dall'utente.
1. Salva l'immagine miniatura nel formato immagine preferito.

```javascript
// Istanzia una classe Presentation che rappresenta il file di presentazione
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a scala completa
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
Questo metodo di creazione di miniature di forme consente agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura generata è limitata dai limiti della diapositiva. Per generare una miniatura di una forma della diapositiva nei limiti del suo aspetto, esegui i seguenti passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salva l'immagine miniatura nel formato immagine preferito.

```javascript
// Istanzia una classe Presentation che rappresenta il file di presentazione
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a scala completa
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

## **Ottenere i limiti visivi effettivi di una forma**

Le proprietà del frame di un [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/)—i metodi `getX()`, `getY()`, `getWidth()` e `getHeight()`—descrivono il rettangolo memorizzato nel modello della presentazione. Il contenuto effettivamente renderizzato può estendersi oltre quel frame o occupare un rettangolo allineato agli assi diverso. Rotazione, contorni, punte di freccia, layout e overflow del testo, geometria SmartArt generata e altri effetti di rendering possono cambiare l'area occupata.

Usa [Shape.getVisualBounds](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getVisualBounds--) per calcolare quell'area occupata senza creare un'immagine. Il metodo restituisce un oggetto [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) in coordinate della diapositiva. Il rettangolo restituito non è ritagliato alla diapositiva, quindi le sue coordinate possono essere negative quando il contenuto si estende oltre l'origine della diapositiva.

L'esempio seguente ottiene e confronta i limiti del frame e quelli visivi:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Lo stesso rettangolo può essere usato per allineare forme vicine al suo bordo sinistro, destro, superiore o inferiore; per riservare spazio sufficiente in un layout generato; o per rilevare contenuti al di fuori di una regione consentita. I limiti visivi sono particolarmente utili per SmartArt, caselle di testo, frecce, immagini, forme ruotate e forme raggruppate, dove il frame memorizzato potrebbe non rappresentare il risultato renderizzato completo.

Usa [Shape.getVisualBounds](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getVisualBounds--) quando ti servono coordinate per layout o validazione e non hai bisogno di una bitmap. Usa [Shape.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage--) quando devi renderizzare la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona l'immagine dai limiti della forma, includendo le impostazioni del contorno, mentre `ShapeThumbnailBounds.Appearance` la dimensiona dall'aspetto della forma e limita il risultato ai limiti della diapositiva. Al contrario, [Shape.getVisualBounds](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getVisualBounds--) restituisce solo il rettangolo calcolato e non lo ritaglia alla diapositiva.

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance quando si renderizza una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` tiene conto dei [visual effects](/slides/it/nodejs-java/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Viene comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione nella presentazione ma non impedisce la generazione dell'immagine della forma.

**Le forme raggruppate, i grafici, SmartArt e altri oggetti complessi sono supportati?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/) e [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartart/)) può essere salvato come miniatura o come SVG.

**I caratteri installati sul sistema influiscono sulla qualità delle miniature per le forme di testo?**

Sì. È necessario [fornire i caratteri richiesti](/slides/it/nodejs-java/custom-font/) (o [configurare le sostituzioni dei caratteri](/slides/it/nodejs-java/font-substitution/)) per evitare fallback indesiderati e riorganizzazioni del testo.