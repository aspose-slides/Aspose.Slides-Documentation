---
title: Crea Miniature di Forme di Presentazione in Java
linktitle: Miniature Forma
type: docs
weight: 70
url: /it/java/create-shape-thumbnails/
keywords:
- miniatura forma
- immagine forma
- renderizzare forma
- rendering forma
- confini visivi
- confini forma
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Genera miniature di forma ad alta qualità dalle diapositive PowerPoint con Aspose.Slides per Java – crea ed esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides per Java può essere usato per creare file di presentazione in cui ogni pagina corrisponde a una diapositiva. Le diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, a volte gli sviluppatori hanno bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides per Java li aiuta a generare immagini miniature delle forme della diapositiva.

Questo articolo spiega come generare miniature di diapositive in diversi modi:

- Generare una miniatura di una forma all'interno di una diapositiva.
- Generare una miniatura di una forma per una forma della diapositiva con dimensioni definite dall'utente.
- Generare una miniatura di una forma nei confini dell'aspetto di una forma.

## **Genera una Miniatura di Forma da una Diapositiva**
Per generare una miniatura di una forma da qualsiasi diapositiva usando Aspose.Slides per Java, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine miniatura della forma](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getImage--) della diapositiva di riferimento a scala predefinita.
1. Salva l'immagine miniatura nel formato immagine preferito.

Questo esempio di codice mostra come generare una miniatura di una forma da una diapositiva:

```java
// Istanzia una classe Presentation che rappresenta il file di presentazione
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a scala completa
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

## **Genera una Miniatura con Fattore di Scalatura Definito dall'Utente**
Per generare la miniatura della forma di una diapositiva usando Aspose.Slides per Java, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine miniatura della forma](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getImage-int-float-float-) della diapositiva di riferimento con dimensioni definite dall'utente.
1. Salva l'immagine miniatura nel formato immagine preferito.

Questo esempio di codice mostra come generare una miniatura di una forma basata su un fattore di scalatura definito:

```java
// Instanzia una classe Presentation che rappresenta il file di presentazione
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a scala completa
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

## **Crea una Miniatura di Forma Basata sui Confini dell'Aspetto**
Questo metodo di creazione di miniature di forme consente agli sviluppatori di generare una miniatura nei confini dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura generata della forma è limitata dai confini della diapositiva. Per generare una miniatura di una forma della diapositiva nei confini del suo aspetto, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con i confini della forma come aspetto.
1. Salva l'immagine miniatura nel formato immagine preferito.

Questo esempio di codice si basa sui passaggi precedenti:

```java
// Istanzia una classe Presentation che rappresenta il file di presentazione
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Crea un'immagine a scala completa
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

## **Ottieni i Reali Confini Visivi di una Forma**

Le proprietà del frame di [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/)—i suoi metodi `getX()`, `getY()`, `getWidth()` e `getHeight()`—descrivono il rettangolo memorizzato nel modello della presentazione. Il contenuto effettivamente renderizzato può estendersi oltre quel frame o occupare un rettangolo allineato agli assi diverso. Rotazione, contorni, punte delle frecce, layout del testo e overflow, geometria SmartArt generata e altri effetti di rendering possono tutti modificare l'area occupata.

Utilizza [Shape.getVisualBounds](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getVisualBounds--) per calcolare quell'area occupata senza creare un'immagine. Il metodo restituisce un [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) nelle coordinate della diapositiva. Il rettangolo restituito non è ritagliato alla diapositiva, quindi le sue coordinate possono essere negative quando il contenuto si estende oltre l'origine della diapositiva.

[Shape.getVisualBounds](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getVisualBounds--) attualmente non è dichiarato dall'interfaccia [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/). Pertanto, conserva la forma ottenuta dalla raccolta di forme della diapositiva come valore di interfaccia e castala solo quando chiami il metodo.

Il seguente esempio recupera e confronta i confini del frame e i confini visivi:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Lo stesso [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) può essere usato per allineare le forme vicine al suo bordo sinistro, destro, superiore o inferiore; riservare spazio sufficiente in un layout generato; o rilevare contenuti al di fuori di una regione consentita. I confini visivi sono particolarmente utili per SmartArt, caselle di testo, frecce, immagini, forme ruotate e gruppi di forme, dove il frame memorizzato potrebbe non rappresentare il risultato renderizzato completo.

Utilizza [Shape.getVisualBounds](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getVisualBounds--) quando ti servono le coordinate per layout o convalida e non hai bisogno di una bitmap. Usa [IShape.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getImage--) quando devi renderizzare la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona l'immagine dai confini della forma, includendo le impostazioni del contorno, mentre `ShapeThumbnailBounds.Appearance` la dimensiona dall'aspetto della forma e limita il risultato ai confini della diapositiva. Al contrario, [Shape.getVisualBounds](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getVisualBounds--) restituisce solo il rettangolo calcolato e non lo ritaglia alla diapositiva.

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/java/com.aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i confini Shape e Appearance quando si rende una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` tiene conto dei [effetti visivi](/slides/it/java/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Viene comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Sono supportati gruppi di forme, grafici, SmartArt e altri oggetti complessi?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/) e [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/smartart/)) può essere salvato come miniatura o come SVG.

**I font installati nel sistema influenzano la qualità delle miniature per le forme di testo?**

Sì. Dovresti [fornire i font richiesti](/slides/it/java/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/java/font-substitution/)) per evitare fallback indesiderati e ricomposizione del testo.