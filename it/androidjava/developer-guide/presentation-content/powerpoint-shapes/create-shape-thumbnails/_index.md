---
title: Crea Thumbnail di Forme di Presentazione su Android
linktitle: Thumbnail di forme
type: docs
weight: 70
url: /it/androidjava/create-shape-thumbnails/
keywords:
- thumbnail di forma
- immagine della forma
- renderizzare forma
- renderizzazione della forma
- limiti visivi
- limiti della forma
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Genera thumbnail di forma di alta qualità dalle diapositive PowerPoint con Aspose.Slides per Android via Java – crea ed esporta facilmente thumbnail di presentazioni."
---
## **Introduzione**

Aspose.Slides for Android via Java può essere usato per creare file di presentazione in cui ogni pagina corrisponde a una diapositiva. Le diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, gli sviluppatori a volte hanno bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In questi casi, Aspose.Slides for Android via Java li aiuta a generare immagini thumbnail delle forme delle diapositive.

In questo argomento, mostreremo come generare thumbnail delle diapositive in diverse situazioni:

- Generazione di una thumbnail di una forma all’interno di una diapositiva.
- Generazione di una thumbnail di una forma per una forma di diapositiva con dimensioni definite dall’utente.
- Generazione di una thumbnail di una forma nei limiti dell’aspetto della forma.

## **Genera una Thumbnail di una Forma da una Diapositiva**
Per generare una thumbnail di una forma da qualsiasi diapositiva usando Aspose.Slides for Android via Java, esegui quanto segue:

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l’immagine thumbnail della forma](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#getImage--) della diapositiva di riferimento con scala predefinita.
1. Salva l’immagine thumbnail nel formato immagine preferito.

Questo codice di esempio mostra come generare una thumbnail di una forma da una diapositiva:

```java
// Istanza di una classe Presentation che rappresenta il file di presentazione
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a scala piena
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Salva l'immagine su disco in formato PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Genera una Thumbnail con Fattore di Scala Definito dall’Utente**
Per generare la thumbnail della forma di una diapositiva usando Aspose.Slides for Android via Java, esegui quanto segue:

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l’immagine thumbnail della forma](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) della diapositiva di riferimento con dimensioni definite dall’utente.
1. Salva l’immagine thumbnail nel formato immagine preferito.

Questo codice di esempio mostra come generare una thumbnail di una forma basata su un fattore di scala definito:

```java
// Istanza di una classe Presentation che rappresenta il file di presentazione
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a scala piena
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Salva l'immagine su disco in formato PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crea una Thumbnail di Aspetto della Forma Basata sui Limiti**
Questo metodo di creazione delle thumbnail delle forme consente agli sviluppatori di generare una thumbnail nei limiti dell’aspetto della forma. Tiene conto di tutti gli effetti della forma. La thumbnail della forma generata è limitata dai limiti della diapositiva. Per generare una thumbnail di una forma di diapositiva nei limiti del suo aspetto, esegui quanto segue:

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l’immagine thumbnail della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salva l’immagine thumbnail nel formato immagine preferito.

Questo codice di esempio è basato sui passaggi sopra:

```java
// Istanza di una classe Presentation che rappresenta il file di presentazione
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a scala piena
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Salva l'immagine su disco in formato PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ottieni i Limiti Visivi Reali di una Forma**

Le proprietà del frame di [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/)—i metodi `getX()`, `getY()`, `getWidth()` e `getHeight()`—descrivono il rettangolo memorizzato nel modello di presentazione. Il contenuto effettivamente renderizzato può estendersi oltre quel frame o occupare un rettangolo allineato agli assi diverso. Rotazione, contorni, punte di freccia, layout e overflow del testo, geometria SmartArt generata e altri effetti di rendering possono tutti modificare l’area occupata.

Usa [Shape.getVisualBounds](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getVisualBounds--) per calcolare quell’area occupata senza creare un’immagine. Il metodo restituisce un [RectF](https://developer.android.com/reference/android/graphics/RectF) in coordinate della diapositiva. Il rettangolo restituito non è ritagliato alla diapositiva, quindi le sue coordinate possono essere negative quando il contenuto supera l’origine della diapositiva.

[Shape.getVisualBounds](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getVisualBounds--) non è attualmente dichiarato dall’interfaccia [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/). Pertanto, conserva la forma ottenuta dalla collezione di forme della diapositiva come valore di interfaccia e castala solo quando chiami il metodo.

L’esempio seguente ottiene e confronta i limiti del frame e i limiti visivi:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Lo stesso [RectF](https://developer.android.com/reference/android/graphics/RectF) può essere usato per allineare forme vicine al suo bordo sinistro, destro, superiore o inferiore; per riservare spazio sufficiente in un layout generato; o per rilevare contenuti fuori da una regione consentita. I limiti visivi sono particolarmente utili per SmartArt, caselle di testo, frecce, immagini, forme ruotate e forme raggruppate, dove il frame memorizzato potrebbe non rappresentare il risultato renderizzato completo.

Usa [Shape.getVisualBounds](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getVisualBounds--) quando ti servono coordinate per il layout o la validazione e non hai bisogno di una bitmap. Usa [IShape.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getImage--) quando devi renderizzare la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona l’immagine dai limiti della forma, includendo le impostazioni del contorno, mentre `ShapeThumbnailBounds.Appearance` la dimensiona dall’aspetto della forma e limita il risultato ai limiti della diapositiva. Al contrario, [Shape.getVisualBounds](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getVisualBounds--) restituisce solo il rettangolo calcolato e non lo ritaglia alla diapositiva.

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance quando si rende una thumbnail?**

`Shape` utilizza la geometria della forma; `Appearance` prende in considerazione gli [effetti visivi](/slides/it/androidjava/shape-effect/) (ombreggiature, bagliori, ecc.).

** Cosa succede se una forma è contrassegnata come nascosta? Verrà comunque renderizzata come thumbnail?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell’immagine della forma.

**Sono supportate le forme raggruppate, i grafici, SmartArt e altri oggetti complessi?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chart/) e [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/smartart/)) può essere salvato come thumbnail o come SVG.

**I font installati sul sistema influenzano la qualità delle thumbnail per le forme di testo?**

Sì. Dovresti [fornire i font richiesti](/slides/it/androidjava/custom-font/) (o [configurare le sostituzioni di font](/slides/it/androidjava/font-substitution/)) per evitare fallback indesiderati e riorganizzazioni del testo.