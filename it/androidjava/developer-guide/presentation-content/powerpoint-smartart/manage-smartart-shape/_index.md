---
title: Gestire grafiche SmartArt nelle presentazioni su Android
linktitle: Grafiche SmartArt
type: docs
weight: 20
url: /it/androidjava/manage-smartart-shape/
keywords:
- oggetto SmartArt
- grafica SmartArt
- stile SmartArt
- colore SmartArt
- creare SmartArt
- aggiungere SmartArt
- modificare SmartArt
- cambiare SmartArt
- accedere SmartArt
- tipo layout SmartArt
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Automatizza la creazione, modifica e stilizzazione di SmartArt in PowerPoint usando Aspose.Slides per Android, con esempi di codice Java concisi e indicazioni orientate alle prestazioni."
---
## **Panoramica**

Aspose.Slides consente di creare e gestire grafici SmartArt nelle presentazioni PowerPoint in modo programmatico. Questo articolo spiega come aggiungere una forma SmartArt a una diapositiva, accedere alle forme SmartArt esistenti, trovare SmartArt in base a un tipo di layout specifico e aggiornare il suo aspetto visivo modificando lo stile SmartArt o lo stile colore.

Gli esempi mostrano come lavorare con le forme SmartArt attraverso la collezione di forme della diapositiva, verificare se una forma è SmartArt e quindi modificarne o ispezionarne le proprietà.

## **Crea una forma SmartArt**
Aspose.Slides for Android via Java fornisce un'API per creare forme SmartArt. Per creare una forma SmartArt in una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. [Aggiungi una forma SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) impostando il suo [LayoutType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType).
4. Salva la presentazione modificata come file PPTX.

```java
// Istanziare la classe Presentation
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiungi forma Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Salvataggio della presentazione
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt aggiunta alla diapositiva**|

## **Accedi a una forma SmartArt su una diapositiva**
Il codice seguente verrà utilizzato per accedere alle forme SmartArt aggiunte nella diapositiva della presentazione. Nel codice di esempio attraverseremo ogni forma all'interno della diapositiva e verificheremo se è una forma [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt). Se la forma è di tipo SmartArt, la casteremo a un'istanza di [**SmartArt**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt).

```java
// Carica la presentazione desiderata
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Scorri ogni forma all'interno della prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accedi a una forma SmartArt con un Layout Type particolare**
Il codice di esempio seguente aiuta ad accedere alla forma [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt) con un LayoutType specifico. Tieni presente che non puoi modificare il LayoutType di SmartArt poiché è di sola lettura e viene impostato solo quando la forma [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt) viene aggiunta.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) e carica la presentazione con la forma SmartArt.
2. Ottieni il riferimento della prima diapositiva usando il suo indice.
3. Scorri ogni forma all'interno della prima diapositiva.
4. Verifica se la forma è di tipo [SmartArt] e, se lo è, effettua il cast al tipo SmartArt.
5. Verifica la forma SmartArt con il LayoutType specifico ed esegui le operazioni necessarie successivamente.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Scorri ogni forma all'interno della prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Controllo del layout SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifica lo stile di una forma SmartArt**
In questo esempio, impareremo a cambiare lo stile rapido per qualsiasi forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) e carica la presentazione con la forma SmartArt.
2. Ottieni il riferimento della prima diapositiva usando il suo indice.
3. Scorri ogni forma all'interno della prima diapositiva.
4. Verifica se la forma è di tipo [SmartArt] e, se lo è, effettua il cast al tipo SmartArt.
5. Trova la forma SmartArt con lo stile specifico.
6. Imposta il nuovo stile per la forma SmartArt.
7. Salva la presentazione.

```java
// Istanziare la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Ottieni la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Scorri ogni forma all'interno della prima diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verifica dello stile SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Modifica dello stile SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Salvataggio della presentazione
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt con stile modificato**|

## **Modifica lo stile colore di una forma SmartArt**
In questo esempio, impareremo a cambiare lo stile colore per qualsiasi forma SmartArt. Nel codice di esempio successivo verrà accessa la forma SmartArt con uno stile colore particolare e il suo stile verrà modificato.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) e carica la presentazione con la forma SmartArt.
2. Ottieni il riferimento della prima diapositiva usando il suo indice.
3. Scorri ogni forma all'interno della prima diapositiva.
4. Verifica se la forma è di tipo [SmartArt] e, se lo è, effettua il cast al tipo SmartArt.
5. Trova la forma SmartArt con lo stile colore specifico.
6. Imposta il nuovo stile colore per la forma SmartArt.
7. Salva la presentazione.

```java
// Istanziare la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Ottieni la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Scorri ogni forma all'interno della prima diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verifica del tipo di colore SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Modifica del tipo di colore SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Salvataggio della presentazione
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt con stile colore modificato**|

## **FAQ**

**Posso animare SmartArt come un singolo oggetto?**

Sì. SmartArt è una forma, quindi puoi applicare le [animazioni standard](/slides/it/androidjava/powerpoint-animation/) tramite l'API delle animazioni (entrata, uscita, enfasi, percorsi di movimento) proprio come per le altre forme.

**Come posso trovare uno SmartArt specifico su una diapositiva se non conosco il suo ID interno?**

Imposta e utilizza il Testo alternativo (AltText) e cerca la forma con quel valore — questo è un metodo consigliato per individuare la forma target.

**Posso raggruppare SmartArt con altre forme?**

Sì. Puoi raggruppare SmartArt con altre forme (immagini, tabelle, ecc.) e quindi [manipolare il gruppo](/slides/it/androidjava/group/).

**Come ottengo un'immagine di uno SmartArt specifico (ad es., per un'anteprima o un rapporto)?**

Esporta una miniatura/immagine della forma; la libreria può [renderizzare forme individuali](/slides/it/androidjava/create-shape-thumbnails/) in file raster (PNG/JPG/TIFF).

**L'aspetto di SmartArt sarà preservato durante la conversione dell'intera presentazione in PDF?**

Sì. Il motore di rendering punta a un'alta fedeltà per la [esportazione PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), con una gamma di opzioni di qualità e compatibilità.