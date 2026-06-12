---
title: Gestire le forme delle presentazioni in JavaScript
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/nodejs-java/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma nella diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Cambia ordine della forma
- Ottieni ID forma Interop
- Testo alternativo della forma
- Formati di layout della forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Impara a creare, modificare e ottimizzare le forme usando JavaScript e Aspose.Slides per Node.js via Java e a fornire presentazioni PowerPoint ad alte prestazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme nelle presentazioni utilizzando Aspose.Slides. Mostra come trovare una forma in una diapositiva, clonarla, rimuoverla, nasconderla, cambiarne l'ordine, ottenere il suo ID forma Interop e impostare il testo alternativo per l'identificazione e ulteriori elaborazioni.

Copre inoltre come accedere ai formati di layout per le forme, rendere una forma come SVG, allineare le forme su una diapositiva e utilizzare le proprietà di flip per la riflessione orizzontale e verticale. Inoltre, l'articolo include una breve FAQ su combinazione di forme, ordine di sovrapposizione e blocco delle forme.

## **Trova Forma nella Diapositiva**
Questo argomento descriverà una tecnica semplice per facilitare gli sviluppatori nel trovare una forma specifica in una diapositiva senza usare il suo Id interno. È importante sapere che i file PowerPoint Presentation non hanno alcun modo per identificare le forme in una diapositiva se non tramite un Id interno univoco. Risulta difficile per gli sviluppatori trovare una forma usando il suo Id interno univoco. Tutte le forme aggiunte alle diapositive hanno un certo Alt Text. Suggeriamo agli sviluppatori di utilizzare il testo alternativo per trovare una forma specifica. È possibile utilizzare MS PowerPoint per definire il testo alternativo per gli oggetti che si prevede di modificare in futuro.

Dopo aver impostato il testo alternativo di qualsiasi forma desiderata, è possibile aprire la presentazione con Aspose.Slides per Node.js via Java e iterare su tutte le forme aggiunte a una diapositiva. Durante ogni iterazione, è possibile controllare il testo alternativo della forma e la forma con il testo alternativo corrispondente sarà quella richiesta. Per dimostrare meglio questa tecnica, abbiamo creato un metodo, [findShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) che esegue il trucco per trovare una forma specifica in una diapositiva e restituisce semplicemente quella forma.

```javascript
// Istanziare una classe Presentation che rappresenta il file di presentazione
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Testo alternativo della forma da trovare
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Clona Forma**
Per clonare una forma in una diapositiva usando Aspose.Slides per Node.js via Java:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Accedi alla raccolta di forme della diapositiva sorgente.
1. Aggiungi una nuova diapositiva alla presentazione.
1. Clona le forme dalla raccolta di forme della diapositiva sorgente alla nuova diapositiva.
1. Salva la presentazione modificata come file PPTX.

L'esempio seguente aggiunge una forma di gruppo a una diapositiva.

```javascript
// Istanziare la classe Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Scrivere il file PPTX su disco
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rimuovi Forma**
Aspose.Slides per Node.js via Java consente agli sviluppatori di rimuovere qualsiasi forma. Per rimuovere la forma da una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Trova la forma con un determinato AlternativeText.
1. Rimuovi la forma.
1. Salva il file su disco.

```javascript
// Crea l'oggetto Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi una forma autogenerata di tipo rettangolo
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Salva la presentazione su disco
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nascondi Forma**
Aspose.Slides per Node.js via Java consente agli sviluppatori di nascondere qualsiasi forma. Per nascondere la forma da una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Trova la forma con un determinato AlternativeText.
1. Nascondi la forma.
1. Salva il file su disco.

```javascript
// Istanziare la classe Presentation che rappresenta il PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi autoshape di tipo rettangolo
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Salva la presentazione su disco
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifica Ordine delle Forme**
Aspose.Slides per Node.js via Java consente agli sviluppatori di riordinare le forme. Riordinare le forme specifica quale forma è in primo piano o quale è sullo sfondo. Per riordinare le forme in una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi una forma.
1. Aggiungi del testo nel riquadro di testo della forma.
1. Aggiungi un'altra forma con le stesse coordinate.
1. Riordina le forme.
1. Salva il file su disco.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ottieni ID Forma Interop**
Aspose.Slides per Node.js via Java consente agli sviluppatori di ottenere un identificatore univoco della forma nell'ambito della diapositiva, a differenza del metodo [getUniqueId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getUniqueId--) che restituisce un identificatore univoco nell'ambito della presentazione. Il metodo [getOfficeInteropShapeId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) è stato aggiunto alla classe [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape) e alla classe [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape). Il valore restituito dal metodo [getOfficeInteropShapeId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) corrisponde al valore dell'Id dell'oggetto Microsoft.Office.Interop.PowerPoint.Shape. Di seguito è riportato un esempio di codice.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Ottenere l'identificatore univoco della forma nell'ambito della diapositiva
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta Testo Alternativo per la Forma**
Aspose.Slides per Node.js via Java consente agli sviluppatori di impostare l'AlternateText di qualsiasi forma.
Le forme in una presentazione possono essere distinte tramite il metodo [AlternativeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) o [Shape Name](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#setName-java.lang.String-).
I metodi [setAlternativeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) e [getAlternativeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getAlternativeText--) possono essere letti o impostati utilizzando Aspose.Slides così come Microsoft PowerPoint.
Usando questo metodo, è possibile etichettare una forma e svolgere diverse operazioni come rimuovere una forma, nascondere una forma o riordinare le forme in una diapositiva.
Per impostare l'AlternateText di una forma, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi qualsiasi forma alla diapositiva.
1. Esegui alcune operazioni con la forma appena aggiunta.
1. Scorri le forme per trovare una forma.
1. Imposta l'AlternativeText.
1. Salva il file su disco.

```javascript
// Istanziare la classe Presentation che rappresenta il PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi autoshape di tipo rettangolo
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Salva la presentazione su disco
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Accedi ai Formati di Layout per la Forma**
Aspose.Slides per Node.js via Java fornisce un'API semplice per accedere ai formati di layout per una forma. Questo articolo dimostra come è possibile accedere ai formati di layout.

Di seguito è riportato un esempio di codice.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rendi Forma come SVG**
Ora Aspose.Slides per Node.js via Java supporta la resa di una forma come SVG. Il metodo [writeAsSvg](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (e le sue sovraccariche) è stato aggiunto alla classe [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape). Questo metodo permette di salvare il contenuto della forma come file SVG. Lo snippet di codice qui sotto mostra come esportare la forma di una diapositiva in un file SVG.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Allineamento delle Forme**
Aspose.Slides consente di allineare le forme sia rispetto ai margini della diapositiva sia rispetto l'una all'altra. A tal fine, è stato aggiunto il metodo sovraccaricato [SlidesUtil.alignShape()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-). L'enumerazione [ShapesAlignmentType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapesAlignmentType) definisce le possibili opzioni di allineamento.

**Example 1**

Il codice sorgente qui sotto allinea le forme con indici 1,2 e 4 lungo il bordo superiore della diapositiva.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Example 2**

L'esempio qui sotto mostra come allineare l'intera raccolta di forme rispetto alla forma più bassa nella raccolta.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Proprietà di Flip**

In Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapeframe/) offre controllo sul ribaltamento orizzontale e verticale delle forme tramite le proprietà `flipH` e `flipV`. Entrambe le proprietà sono di tipo `byte`, consentendo valori `1` per indicare un ribaltamento, `0` per nessun ribaltamento o `-1` per utilizzare il comportamento predefinito. Questi valori sono accessibili dal [Frame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getFrame) di una forma.

Per modificare le impostazioni di flip, viene costruita una nuova istanza di [ShapeFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapeframe/) con la posizione e le dimensioni attuali della forma, i valori desiderati per `flipH` e `flipV` e l'angolo di rotazione. Assegnando questa istanza al [Frame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getFrame) della forma e salvando la presentazione, si applicano le trasformazioni di mirror e vengono incorporate nel file di output.

Supponiamo di avere un file sample.pptx in cui la prima diapositiva contiene una singola forma con impostazioni di flip predefinite, come mostrato di seguito.

![La forma da ribaltare](shape_to_be_flipped.png)

Il seguente esempio di codice recupera le proprietà di flip attuali della forma e le ribalta sia orizzontalmente sia verticalmente.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Recupera la proprietà di ribaltamento orizzontale della forma.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Recupera la proprietà di ribaltamento verticale della forma.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Ribaltamento orizzontale.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Ribaltamento verticale.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La forma ribaltata](flipped_shape.png)

## **FAQ**

**Posso combinare forme (unione/intersezione/sottrazione) in una diapositiva come in un editor desktop?**

Non esiste un'API di operazioni booleane incorporata. È possibile approssimarla costruendo manualmente il contorno desiderato, ad esempio calcolando la geometria risultante (tramite [GeometryPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/geometrypath/)) e creando una nuova forma con quel contorno, eventualmente rimuovendo le originali.

**Come posso controllare l'ordine di sovrapposizione (z-order) affinché una forma rimanga sempre in "primo piano"?**

Modifica l'ordine di inserimento/spostamento nella collezione di [shapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getShapes) della diapositiva. Per risultati prevedibili, finalizza lo z-order dopo tutte le altre modifiche alla diapositiva.

**Posso "bloccare" una forma per impedire agli utenti di modificarla in PowerPoint?**

Sì. Imposta i flag di protezione a livello di forma (ad esempio blocco selezione, movimento, ridimensionamento, modifica del testo). Se necessario, applica restrizioni analoghe al master o al layout. Nota che si tratta di protezione a livello UI, non di una funzionalità di sicurezza; per una protezione più forte, combina con restrizioni a livello di file come [raccomandazioni di sola lettura o password](/slides/it/nodejs-java/password-protected-presentation/).