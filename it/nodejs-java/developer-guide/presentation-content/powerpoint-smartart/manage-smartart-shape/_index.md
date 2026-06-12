---
title: Gestisci grafiche SmartArt nelle presentazioni usando JavaScript
linktitle: Grafica SmartArt
type: docs
weight: 20
url: /it/nodejs-java/manage-smartart-shape/
keywords:
- Oggetto SmartArt
- Grafica SmartArt
- Stile SmartArt
- Colore SmartArt
- Crea SmartArt
- Aggiungi SmartArt
- Modifica SmartArt
- Cambia SmartArt
- Accedi a SmartArt
- Tipo di layout SmartArt
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizza la creazione, la modifica e lo styling di SmartArt in PowerPoint con JavaScript usando Aspose.Slides, con esempi di codice concisi e consigli orientati alle prestazioni."
---
## **Panoramica**

Aspose.Slides consente di creare e gestire grafici SmartArt nelle presentazioni PowerPoint in modo programmatico. Questo articolo spiega come aggiungere una forma SmartArt a una diapositiva, accedere alle forme SmartArt esistenti, trovare SmartArt per un tipo di layout specifico e aggiornare l'aspetto visivo modificando lo stile SmartArt o lo stile colore.

Gli esempi mostrano come lavorare con le forme SmartArt tramite la collezione di forme della diapositiva della presentazione, verificare se una forma è SmartArt e quindi modificare o ispezionare le sue proprietà.

## **Crea forma SmartArt**
Aspose.Slides per Node.js via Java ha fornito un'API per creare forme SmartArt. Per creare una forma SmartArt in una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
3. [Aggiungi una forma SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) impostando il suo [LayoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtLayoutType).
4. Salva la presentazione modificata come file PPTX.

```javascript
// Instanzia la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiungi forma SmartArt
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Salvataggio della presentazione
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt aggiunta alla diapositiva**|

## **Accedi alla forma SmartArt nella diapositiva**
Il codice seguente verrà utilizzato per accedere alle forme SmartArt aggiunte nella diapositiva della presentazione. Nel codice di esempio attraverseremo ogni forma all'interno della diapositiva e verificheremo se è una forma [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt). Se la forma è di tipo SmartArt, la convertirà al tipo [**SmartArt**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) istanza.

```javascript
// Carica la presentazione desiderata
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Esegui il cast della forma a SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Accedi alla forma SmartArt con un LayoutType particolare**
Il seguente codice di esempio aiuterà ad accedere alla forma [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) con un LayoutType particolare. Si noti che non è possibile modificare il LayoutType dello SmartArt poiché è di sola lettura e viene impostato solo quando la forma [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) viene aggiunta.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) e carica la presentazione con forma SmartArt.
2. Ottieni il riferimento della prima diapositiva utilizzando il suo indice.
3. Attraversa tutte le forme all'interno della prima diapositiva.
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) e, se lo è, effettua il cast della forma selezionata a SmartArt.
5. Verifica la forma SmartArt con il LayoutType specifico ed esegui le operazioni necessarie successivamente.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Esegui il cast della forma a SmartArtEx
            var smart = shape;
            // Verifica il layout di SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifica lo stile della forma SmartArt**
In questo esempio, impareremo a modificare lo stile rapido per qualsiasi forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) e carica la presentazione con forma SmartArt.
2. Ottieni il riferimento della prima diapositiva utilizzando il suo indice.
3. Attraversa tutte le forme all'interno della prima diapositiva.
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) e, se lo è, effettua il cast della forma selezionata a SmartArt.
5. Trova la forma SmartArt con uno stile specifico.
6. Imposta il nuovo stile per la forma SmartArt.
7. Salva la presentazione.

```javascript
// Instanzia la classe Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Ottieni la prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Scorri tutte le forme nella prima diapositiva
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Esegui il cast della forma a SmartArtEx
            var smart = shape;
            // Verifica lo stile di SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Cambia lo stile di SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Salvataggio della presentazione
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt con stile modificato**|

## **Modifica lo stile colore della forma SmartArt**
In questo esempio, impareremo a modificare lo stile colore per qualsiasi forma SmartArt. Nel codice di esempio seguente verrà acceduta la forma SmartArt con uno stile colore specifico e ne verrà modificato lo stile.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) e carica la presentazione con forma SmartArt.
2. Ottieni il riferimento della prima diapositiva utilizzando il suo indice.
3. Attraversa tutte le forme all'interno della prima diapositiva.
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) e, se lo è, effettua il cast della forma selezionata a SmartArt.
5. Trova la forma SmartArt con uno Stile Colore specifico.
6. Imposta il nuovo Stile Colore per la forma SmartArt.
7. Salva la presentazione.

```javascript
// Instanzia la classe Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Ottieni la prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Scorri tutte le forme nella prima diapositiva
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Esegui il cast della forma a SmartArtEx
            var smart = shape;
            // Verifica il tipo di colore di SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Cambia il tipo di colore di SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Salvataggio della presentazione
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt con stile colore modificato**|

## **FAQ**

**Posso animare SmartArt come un unico oggetto?**

Sì. SmartArt è una forma, quindi è possibile applicare le [animazioni standard](/slides/it/nodejs-java/powerpoint-animation/) tramite l'API di animazione (entrata, uscita, enfasi, percorsi di movimento) proprio come per le altre forme.

**Come posso trovare uno SmartArt specifico su una diapositiva se non conosco il suo ID interno?**

Imposta e usa il Testo Alternativo (AltText) e cerca la forma per quel valore — questo è il modo consigliato per individuare la forma target.

**Posso raggruppare SmartArt con altre forme?**

Sì. È possibile raggruppare SmartArt con altre forme (immagini, tabelle, ecc.) e quindi [manipolare il gruppo](/slides/it/nodejs-java/group/).

**Come ottengo un'immagine di uno SmartArt specifico (ad esempio per un'anteprima o un report)?**

Esporta una miniatura/immagine della forma; la libreria può [renderizzare forme individuali](/slides/it/nodejs-java/create-shape-thumbnails/) in file raster (PNG/JPG/TIFF).

**L'aspetto di SmartArt verrà preservato quando si converte l'intera presentazione in PDF?**

Sì. Il motore di rendering punta a un'alta fedeltà per la [esportazione PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), con un'ampia gamma di opzioni di qualità e compatibilità.