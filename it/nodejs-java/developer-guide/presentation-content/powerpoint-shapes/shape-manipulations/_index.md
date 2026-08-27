---
title: Gestire le forme della presentazione in JavaScript
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
- Modifica ordine forma
- Ottieni ID forma interop
- Testo alternativo della forma
- Punto di regolazione della forma
- Regolazione forma predefinita
- Geometria della forma
- Formati layout della forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- Ribalta forma
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come identificare, regolare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme della presentazione con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Aspose.Slides for Node.js tramite Java rappresenta le forme su una diapositiva come una collezione ordinata [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/). La collezione è sia il luogo in cui si trovano e modificano le forme sia la fonte del loro ordine di sovrapposizione: l’indice `0` è la forma più arretrata, mentre l’ultimo indice è la forma più anteriore.

Questo articolo segue quel modello. Prima spiega come identificare in modo affidabile una forma e modificare i punti di regolazione predefiniti, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali trattano la formattazione a livello di layout, l’esportazione SVG, l’allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, così è possibile utilizzare solo le operazioni di cui il proprio flusso di lavoro ha bisogno.

## **Identifica e trova le forme**

Gli indici della collezione sono comodi durante l’elaborazione di un file noto, ma non sono identificatori stabili. L’aggiunta, la rimozione o il riordino di una forma può modificarne l’indice. Scegli un identificatore in base a come la presentazione è stata creata e mantenuta:

- [Name](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getname/) è utile per modelli controllati dallo sviluppatore ed è facile da ispezionare nel riquadro di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti univoci, quindi stabilisci una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getalternativetext/) è utile quando una descrizione di accessibilità o un tag fornito dall’autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l’accessibilità e non è garantito univoco. Non riutilizzare silenziosamente testo di accessibilità significativo come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) è un identificatore di sola lettura univoco all’interno di una diapositiva e corrisponde all’ID forma usato dall’interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando ti serve un riferimento inequivocabile per la durata di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

Il metodo correlato [getUniqueId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getuniqueid/) restituisce un identificatore con ambito di presentazione, ma quell’identificatore è pensato per componenti aggiuntivi e può essere riassegnato. Non dovrebbe essere trattato come una chiave esterna permanente. Se l’identità a lungo termine è essenziale, conserva la mappatura nei dati dell’applicazione e verifica che la forma prevista esista ancora.

L’esempio seguente cerca per nome con confronto esatto e restituisce l’ID interop a livello di diapositiva. Quando il modello non contiene la forma attesa, il codice segnala quel risultato invece di continuare con l’oggetto errato.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Quando un’operazione è specifica a un tipo di forma, controlla la classe a runtime prima di usare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l’oggetto denominato è un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identifica e modifica le regolazioni predefinite delle forme**

Le forme di geometria predefinita possono esporre punti di regolazione che controllano caratteristiche come la dimensione degli angoli, le proporzioni della freccia o gli angoli dell’arco. Accedili tramite la collezione di sola lettura [GeometryShape.getAdjustments](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/geometryshape/). La collezione stessa è fornita dalla forma, ma ogni [AdjustValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/) contiene un valore modificabile.

Non fare affidamento solo su un indice fisso della collezione. Itera tra le regolazioni e ispeziona il metodo di sola lettura [getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/) il cui valore [ShapeAdjustmentType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapeadjustmenttype/) descrive cosa controlla la regolazione. Il metodo di sola lettura [getName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/getname/) fornisce informazioni di identificazione aggiuntive ed è particolarmente utile quando una preimpostazione contiene più di una regolazione con lo stesso tipo semantico.

Usa il metodo valore che corrisponde al significato della regolazione:

| Tipo di aggiustamento | Scopo | Valore da modificare |
|---|---|---|
| `CornerSize` | Dimensione degli angoli arrotondati | [setRawValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Spessore della coda di una freccia | `setRawValue` |
| `ArrowheadLength` | Lunghezza della punta della freccia | `setRawValue` |
| `ArrowheadWidth` | Larghezza della punta della freccia | `setRawValue` |
| `StartAngle` | Angolo iniziale di una torta o arco | [setAngleValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Angolo finale di una torta o arco | `setAngleValue` |

`getType` e `getName` restituiscono informazioni di sola lettura. `getRawValue` e `setRawValue` lavorano con un intero nelle unità di geometria native della preimpostazione, mentre `getAngleValue` e `setAngleValue` lavorano con un angolo in gradi. Il numero, l’ordine, il significato e l’intervallo valido delle regolazioni dipendono dalla preimpostazione [GeometryShape.getShapeType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/geometryshape/). Un valore valido per una preimpostazione può essere non valido o avere un effetto diverso per un’altra.

Quando `getType` restituisce `ShapeAdjustmentType.Custom`, l’API non riconosce un significato semantico standard. Ispeziona `getName`, il tipo di preimpostazione e il valore esistente, e mantieni la regolazione invariata a meno che non si conosca il significato e l’intervallo attesi. Anche per i tipi riconosciuti, verifica se lo stesso tipo appare più volte prima di selezionare un valore. L’articolo [Connector](/slides/it/nodejs-java/connector/) mostra questa situazione con le regolazioni di piegatura del connettore.

L’esempio completo seguente crea versioni predefinite e modificate di tre forme preimpostate. Itera su ogni regolazione, segnala il suo nome e tipo, modifica i valori relativi alle dimensioni tramite `setRawValue`, le angolazioni tramite `setAngleValue` e salva il risultato. La colonna sinistra mantiene la geometria predefinita; la colonna destra mostra il rettangolo arrotondato, la freccia a quattro punte e la fetta di torta regolati.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Aggiunge le intestazioni per le colonne di forma predefinita e regolata.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Controllare il tipo semantico prima di cambiare un valore rende il codice esplicito riguardo all’intento ed evita di presumere che un indice di collezione specifico abbia lo stesso significato su forme preimpostate diverse.

## **Modifica la collezione di forme**

I metodi di aggiunta, clonazione, rimozione e riordino operano immediatamente sulla collezione. Se un’operazione cambia il numero o l’ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di quell’operazione.

### **Clona una forma**

[addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/addclone/) crea una copia indipendente e la aggiunge alla collezione di destinazione. [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/insertclone/) crea anch’essa una copia ma la posiziona a un indice di z‑order specificato. Le overload che accettano coordinate spostano il clone senza cambiarne le dimensioni; le overload con larghezza e altezza possono ridimensionarlo.

L’esempio crea una diapositiva di destinazione, clona un rettangolo con etichetta in primo piano e inserisce un secondo clone in fondo. Le modifiche a ciascun clone non alterano la forma sorgente.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Clonare copia il contenuto e la formattazione della forma, incluso nome e testo alternativo. Assegna nuovi identificatori logici al clone quando tali valori devono essere univoci. Le risorse usate da forme complesse sono gestite dalla presentazione, ma il clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovi le forme**

[remove](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/remove/) elimina un oggetto forma specifico dalla sua collezione. Quando rimuovi più corrispondenze durante un’iterazione indicizzata, percorri la collezione dal fondo così che ogni indice rimanente rimanga valido.

Questo esempio rimuove ogni forma con un nome designato. Legge la forma all’indice corrente e non presume un tipo di forma specifico.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili di indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che potrebbero fare riferimento all’oggetto rimosso; rimuovere una forma visibile può modificare più del semplice aspetto della diapositiva.

### **Nascondi una forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/sethidden/) su `true` mantiene la forma nella collezione ma ne impedisce la visualizzazione nella presentazione normale. Il suo indice, la formattazione e il contenuto restano disponibili al codice, quindi nascondere è appropriato per elementi opzionali che potrebbero essere ripristinati in seguito.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nascondere non è cancellazione né sicurezza. L’oggetto può ancora essere scoperto e reso nuovamente visibile da un utente o da codice, e rimane parte del file della presentazione.

### **Modifica l'ordine Z**

Le forme sovrapposte sono dipinte secondo l’ordine della collezione. [reorder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/reorder/) sposta una forma esistente a un indice di destinazione senza clonarla. L’indice `0` è il retro, `size() - 1` è il fronte.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il rettangolo è creato per primo e inizialmente si trova dietro l’ellisse. Spostandolo all’indice finale lo porta in primo piano. Finalizza l’ordine Z dopo aver aggiunto o clonato tutte le forme correlate, perché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare la pila prevista.

## **Ispeziona le forme nei layout diapositive**

Le diapositive normali, i layout e i master hanno collezioni di forme separate. Una forma in una collezione di layout non è lo stesso oggetto di una forma posizionata in modo simile su una diapositiva normale. Ispeziona le forme del layout quando devi comprendere o modificare la formattazione fornita da un layout.

L’esempio seguente legge il [FillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getfillformat/) e il [LineFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getlineformat/) di ciascuna forma del layout senza presumere che ogni forma sia una `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Modificare un layout può influire su più diapositive che lo utilizzano. Prima di cambiare una forma di layout, determina se una diapositiva normale eredita l’oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che usa quel layout.

## **Esporta una forma in SVG**

[writeAsSvg](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/) scrive il contenuto renderizzato di una singola forma in uno stream. Il risultato contiene solo la forma, non lo sfondo dell’intera diapositiva né le forme vicine.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Mantieni la presentazione aperta durante il rendering. L’output dipende dalla formattazione della forma e dalle risorse quali font e immagini. Se ti serve l’intera composizione, esporta la diapositiva anziché una singola forma. Il chiamante possiede lo stream e deve chiuderlo.

## **Allinea le forme**

Le overload di [SlideUtil.alignShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/alignshapes/) allineano tutte le forme o gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` su `true` per usare i bordi della diapositiva; impostalo su `false` per allineare le forme selezionate tra loro.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti vengono convertiti nei loro indici correnti subito prima dell’allineamento.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’allineamento modifica le posizioni, non l’ordine Z. L’allineamento relativo normalmente richiede almeno due forme, mentre la distribuzione orizzontale o verticale necessita di un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Ribalta una forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapeframe/) memorizza posizione, dimensione, impostazioni di ribaltamento orizzontale e verticale e rotazione. I valori di `getFlipH` e `getFlipV` usano [NullableBool](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/nullablebool/): `True` abilita il ribaltamento, `False` lo disabilita e `NotDefined` conserva lo stato non specificato/predefinito.

La presentazione di input sottostante contiene una forma non ribaltata.

![The shape before flipping](shape_to_be_flipped.png)

L’esempio mantiene tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Ciò è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/setframe/) sostituisce l’intero frame.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La forma salvata è riflessa orizzontalmente e verticalmente mantenendo posizione, dimensione e rotazione.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di una forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell’utilizzo dell’indice. Preferisci una convenzione validata di `Name` o `AlternativeText` per i modelli creati, oppure `OfficeInteropShapeId` per lavori di interop a livello di diapositiva.

**Nascondere una forma la rimuove dall’ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata è apparsa davanti a un’altra forma?**

`addClone` aggiunge il clone alla fine della collezione, che è il fronte dell’ordine Z. Usa `insertClone` per scegliere l’indice iniziale o `reorder` dopo aver aggiunto tutte le forme.

**Posso usare un indice fisso per identificare una regolazione predefinita di una forma?**

Solo dopo aver convalidato la preimpostazione esatta e la disposizione della collezione. Preferisci iterare su `GeometryShape.getAdjustments` e controllare `AdjustValue.getType`; usa `AdjustValue.getName` come informazione aggiuntiva quando lo stesso tipo semantico appare più di una volta.