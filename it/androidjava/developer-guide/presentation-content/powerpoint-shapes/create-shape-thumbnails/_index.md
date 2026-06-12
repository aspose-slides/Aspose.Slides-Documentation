---
title: Crea Miniature delle Forme di Presentazione su Android
linktitle: Miniature di Forma
type: docs
weight: 70
url: /it/androidjava/create-shape-thumbnails/
keywords:
- miniatura della forma
- immagine della forma
- renderizzare forma
- rendering della forma
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Genera miniature di forma ad alta qualità dalle diapositive PowerPoint con Aspose.Slides per Android via Java – crea ed esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides for Android via Java può essere utilizzato per creare file di presentazione in cui ogni pagina corrisponde a una diapositiva. Le diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, a volte gli sviluppatori hanno bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides for Android via Java li aiuta a generare immagini in miniatura delle forme della diapositiva.

In questo argomento, mostreremo come generare miniature di diapositive in diverse situazioni:

- Generare una miniatura di una forma all'interno di una diapositiva.
- Generare una miniatura di una forma per una forma della diapositiva con dimensioni definite dall'utente.
- Generare una miniatura di una forma nei limiti dell'aspetto di una forma.

## **Genera una miniatura di una forma da una diapositiva**
Per generare una miniatura di una forma da qualsiasi diapositiva usando Aspose.Slides for Android via Java, esegui quanto segue:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'[immagine della miniatura della forma](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#getImage--) della diapositiva di riferimento alla scala predefinita.
1. Salva l'immagine miniatura nel formato immagine preferito.

Questo codice di esempio mostra come generare una miniatura di una forma da una diapositiva:

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
Per generare la miniatura della forma di una diapositiva usando Aspose.Slides for Android via Java, esegui quanto segue:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'[immagine della miniatura della forma](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) della diapositiva di riferimento con dimensioni definite dall'utente.
1. Salva l'immagine miniatura nel formato immagine preferito.

Questo codice di esempio mostra come generare una miniatura della forma basata su un fattore di scala definito:

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


## **Crea una miniatura dell'aspetto della forma basata sui limiti**
Questo metodo di creazione di miniature delle forme consente agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura della forma generata è limitata dai confini della diapositiva. Per generare una miniatura di una forma della diapositiva nei limiti del suo aspetto, esegui quanto segue:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salva l'immagine miniatura nel formato immagine preferito.

Questo codice di esempio si basa sui passaggi sopra:

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

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance quando si rende una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` prende in considerazione [effetti visivi](/slides/it/androidjava/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Verrà comunque resa come miniatura?**

Una forma nascosta rimane parte del modello e può essere resa; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Le forme di gruppo, i grafici, SmartArt e altri oggetti complessi sono supportati?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chart/) e [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/smartart/)) può essere salvato come miniatura o come SVG.

**Le font installate di sistema influiscono sulla qualità delle miniature per le forme di testo?**

Sì. È consigliabile [fornire i font necessari](/slides/it/androidjava/custom-font/) (o [configurare le sostituzioni dei font](/slides/it/androidjava/font-substitution/)) per evitare fallback indesiderati e ricomposizione del testo.