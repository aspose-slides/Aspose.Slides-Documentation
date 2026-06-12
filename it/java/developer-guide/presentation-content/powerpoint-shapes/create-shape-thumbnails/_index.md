---
title: Crea miniature di forme di presentazione in Java
linktitle: Miniature di forma
type: docs
weight: 70
url: /it/java/create-shape-thumbnails/
keywords:
- miniatura di forma
- immagine di forma
- renderizzare forma
- rendering di forma
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Genera miniature di forma di alta qualità dalle diapositive PowerPoint con Aspose.Slides per Java - crea e esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides for Java può essere utilizzato per creare file di presentazione in cui ogni pagina corrisponde a una diapositiva. Le diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, gli sviluppatori a volte hanno bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides for Java li aiuta a generare immagini miniatura delle forme della diapositiva.

Questo articolo spiega come generare miniature di diapositive in diversi modi:

- Generare una miniatura di forma all'interno di una diapositiva.
- Generare una miniatura di forma per una forma di diapositiva con dimensioni definite dall'utente.
- Generare una miniatura di forma nei limiti dell'aspetto di una forma.

## **Genera una miniatura di forma da una diapositiva**
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine miniatura della forma](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#getImage--) della diapositiva di riferimento a scala predefinita.
1. Salva l'immagine miniatura nel formato immagine preferito.

```java
// Istanzia una classe Presentation che rappresenta il file di presentazione
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

## **Genera una miniatura con fattore di scala definito dall'utente**
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. [Ottieni l'immagine miniatura della forma](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#getImage-int-float-float-) della diapositiva di riferimento con dimensioni definite dall'utente.
1. Salva l'immagine miniatura nel formato immagine preferito.

```java
// Istanzia una classe Presentation che rappresenta il file di presentazione
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

## **Crea una miniatura basata sui limiti dell'aspetto della forma**
Questo metodo di creazione di miniature di forme consente agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura della forma generata è limitata dai limiti della diapositiva. Per generare una miniatura di una forma di diapositiva nei limiti del suo aspetto, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine miniatura della forma della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salva l'immagine miniatura nel formato immagine preferito.

```java
// Istanzia una classe Presentation che rappresenta il file di presentazione
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

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/java/com.aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance quando si rende una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` considera [effetti visivi](/slides/it/java/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Verrà comunque resa come miniatura?**

Una forma nascosta rimane parte del modello e può essere resa; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Le forme di gruppo, i grafici, SmartArt e altri oggetti complessi sono supportati?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/), e [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/smartart/)) può essere salvato come miniatura o come SVG.

**I font installati a livello di sistema influenzano la qualità delle miniature per le forme di testo?**

Sì. È necessario [fornire i font richiesti](/slides/it/java/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/java/font-substitution/)) per evitare fallback indesiderati e rielaborazioni del testo.