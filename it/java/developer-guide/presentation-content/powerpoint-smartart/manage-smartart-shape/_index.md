---
title: Gestire le grafiche SmartArt nelle presentazioni usando Java
linktitle: Grafica SmartArt
type: docs
weight: 20
url: /it/java/manage-smartart-shape/
keywords:
- oggetto SmartArt
- grafica SmartArt
- stile SmartArt
- colore SmartArt
- creare SmartArt
- aggiungere SmartArt
- modificare SmartArt
- cambiare SmartArt
- accedere a SmartArt
- tipo layout SmartArt
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Automatizza la creazione, modifica e stili di SmartArt in PowerPoint con Java usando Aspose.Slides, con esempi di codice concisi e indicazioni focalizzate sulle prestazioni."
---
## **Panoramica**

Aspose.Slides consente di creare e gestire grafiche SmartArt nelle presentazioni PowerPoint in modo programmatico. Questo articolo spiega come aggiungere una forma SmartArt a una diapositiva, accedere a forme SmartArt esistenti, trovare SmartArt per un tipo di layout specifico e aggiornare il suo aspetto visuale modificando lo stile SmartArt o lo stile colore.

Gli esempi mostrano come lavorare con le forme SmartArt tramite la raccolta forme della diapositiva della presentazione, verificare se una forma è SmartArt e quindi modificare o ispezionare le sue proprietà.

## **Creare una forma SmartArt**
Aspose.Slides for Java ha fornito un'API per creare forme SmartArt. Per creare una forma SmartArt in una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
3. [Aggiungi una forma SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) impostandola tramite [LayoutType](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtLayoutType).
4. Salva la presentazione modificata come file PPTX.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiungi forma SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Salva la presentazione
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: forma SmartArt aggiunta alla diapositiva**|

## **Accedere a una forma SmartArt su una diapositiva**
Il codice seguente verrà utilizzato per accedere alle forme SmartArt aggiunte nella diapositiva della presentazione. Nel codice di esempio percorreremo ogni forma all'interno della diapositiva e verificheremo se è una forma [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt). Se la forma è di tipo SmartArt, la convertirà in un'istanza di [**SmartArt**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt).

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
            // Converti la forma in SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accedere a una forma SmartArt con un tipo di Layout specifico**
Il codice di esempio seguente aiuterà ad accedere alla forma [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt) con un LayoutType specifico. Nota che non è possibile modificare il LayoutType di SmartArt poiché è di sola lettura e viene impostato solo quando la forma [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt) viene aggiunta.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) e carica la presentazione con la forma SmartArt.
2. Ottieni il riferimento della prima diapositiva utilizzando il suo indice.
3. Scorri ogni forma all'interno della prima diapositiva.
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt) e converti la forma selezionata in SmartArt se è SmartArt.
5. Verifica la forma SmartArt con il LayoutType specifico e esegui le operazioni richieste successivamente.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Scorri ogni forma all'interno della prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt)
        {
            // Esegui il cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Verifica il layout di SmartArt
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

## **Modificare lo stile di una forma SmartArt**
In questo esempio, impareremo a cambiare lo stile rapido per qualsiasi forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) e carica la presentazione con la forma SmartArt.
2. Ottieni il riferimento della prima diapositiva utilizzando il suo indice.
3. Scorri ogni forma all'interno della prima diapositiva.
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt) e converti la forma selezionata in SmartArt se è SmartArt.
5. Trova la forma SmartArt con lo Style specifico.
6. Imposta il nuovo Style per la forma SmartArt.
7. Salva la Presentazione.

```java
// Istanzia la classe Presentation
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
            // Esegui il cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verifica lo stile SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Modifica lo stile SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Salva la presentazione
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: forma SmartArt con stile modificato**|

## **Modificare lo stile colore di una forma SmartArt**
In questo esempio, impareremo a cambiare lo stile colore per qualsiasi forma SmartArt. Nel codice di esempio seguente verrà acceduta la forma SmartArt con uno specifico stile colore e verrà modificato il suo stile.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) e carica la presentazione con la forma SmartArt.
2. Ottieni il riferimento della prima diapositiva utilizzando il suo indice.
3. Scorri ogni forma all'interno della prima diapositiva.
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt) e converti la forma selezionata in SmartArt se è SmartArt.
5. Trova la forma SmartArt con lo Stile colore specifico.
6. Imposta il nuovo Stile colore per la forma SmartArt.
7. Salva la Presentazione.

```java
// Istanzia la classe Presentation
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
            // Esegui il cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Verifica il tipo di colore SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Modifica il tipo di colore SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Salva la presentazione
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: forma SmartArt con stile colore modificato**|

## **FAQ**

**Posso animare SmartArt come un singolo oggetto?**

Sì. SmartArt è una forma, quindi puoi applicare [animazioni standard](/slides/it/java/powerpoint-animation/) tramite l'API di animazione (entrata, uscita, enfasi, percorsi di movimento) proprio come per le altre forme.

**Come posso trovare uno SmartArt specifico su una diapositiva se non conosco il suo ID interno?**

Imposta e utilizza il Testo Alternativo (AltText) e cerca la forma per quel valore—questo è un metodo consigliato per individuare la forma target.

**Posso raggruppare SmartArt con altre forme?**

Sì. Puoi raggruppare SmartArt con altre forme (immagini, tabelle, ecc.) e poi [manipolare il gruppo](/slides/it/java/group/).

**Come posso ottenere un'immagine di uno SmartArt specifico (ad esempio per un'anteprima o un report)?**

Esporta una miniatura/immagine della forma; la libreria può [renderizzare forme individuali](/slides/it/java/create-shape-thumbnails/) in file raster (PNG/JPG/TIFF).

**L'aspetto di SmartArt sarà preservato quando si converte l'intera presentazione in PDF?**

Sì. Il motore di rendering punta a un'elevata fedeltà per l'[esportazione PDF](/slides/it/java/convert-powerpoint-to-pdf/), offrendo una gamma di opzioni di qualità e compatibilità.