---
title: Gestire le forme della presentazione in JavaScript
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/nodejs-java/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma sulla diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Cambia ordine forma
- Ottieni ID forma interop
- Testo alternativo della forma
- Formati layout della forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- Ribalta forma
- PowerPoint
- Presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come identificare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme della presentazione con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Aspose.Slides for Node.js via Java rappresenta le forme su una diapositiva come una [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/) ordinata. La collezione è sia il luogo dove si trovano e modificano le forme sia la fonte del loro ordine di sovrapposizione: l'indice `0` è la forma più arretrata, mentre l'ultimo indice è la forma più avanzata.

Questo articolo segue quel modello. Prima spiega come identificare in modo affidabile una forma, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali coprono la formattazione a livello di layout, l'esportazione SVG, l'allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, così è possibile utilizzare solo le operazioni richieste dal proprio flusso di lavoro.

## **Identificare e trovare le forme**

Gli indici della collezione sono comodi durante l'elaborazione di un file noto, ma non sono identificatori stabili. L'aggiunta, la rimozione o il riordino di una forma può cambiarne l'indice. Scegliere un identificatore in base a come la presentazione è creata e mantenuta:

- [Name](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getname/) è utile per modelli controllati dallo sviluppatore ed è facile da ispezionare nel riquadro di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti univoci, quindi stabilire una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getalternativetext/) è utile quando una descrizione di accessibilità o un tag fornito dall'autore identifica già la forma. È visibile agli utenti, può essere tradotto o riscritto per l'accessibilità e non è garantito univoco. Non riutilizzare silenziosamente testo di accessibilità significativo come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) è un identificatore di sola lettura che è unico all'interno di una diapositiva e corrisponde all'ID della forma usato dall'interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando hai bisogno di un riferimento inequivocabile durante la vita di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

Il metodo correlato [getUniqueId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getuniqueid/) restituisce un identificatore con ambito di presentazione, ma tale identificatore è destinato a componenti aggiuntivi e può essere riassegnato. Non deve essere trattato come una chiave esterna permanente. Se è essenziale un'identità a lungo termine, conserva la mappatura nei dati dell'applicazione e verifica che la forma prevista esista ancora.

L'esempio seguente ricerca per nome con confronto esatto e riporta l'ID interop a livello di diapositiva. Quando il modello non contiene la forma prevista, il codice riporta quel risultato invece di continuare con l'oggetto errato.

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

Quando un'operazione è specifica per un tipo di forma, controlla la classe a runtime prima di utilizzare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l'oggetto nominato è un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).

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

## **Modificare la collezione di forme**

I metodi add, clone, remove e reorder operano sulla collezione immediatamente. Se un'operazione cambia il numero o l'ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di quell'operazione.

### **Clonare una forma**

[addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/addclone/) crea una copia indipendente e la aggiunge alla collezione di destinazione. [insertClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/insertclone/) crea anch'essa una copia ma la posiziona a un indice di ordine Z specificato. Le overload che accettano coordinate spostano la copia senza cambiarne le dimensioni; le overload con larghezza e altezza possono ridimensionarla anche.

L'esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone sul retro. Le modifiche a ciascun clone non modificano la forma di origine.

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

Il cloning copia il contenuto e la formattazione della forma, compresi nome e testo alternativo. Assegna nuovi identificatori logici al clone quando quei valori devono essere unici. Le risorse usate dalle forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere forme**

[remove](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/remove/) elimina un oggetto forma specifico dalla sua collezione. Quando si rimuovono più corrispondenze durante un'iterazione indicizzata, attraversa la collezione dalla fine così che ogni indice rimanente rimanga valido.

Questo esempio rimuove ogni forma con un nome designato. Legge la forma all'indice corrente e non presume un tipo di forma specifico.

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

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto agli indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che possono fare riferimento all'oggetto rimosso; rimuovere una forma visibile può modificare più dell'aspetto della diapositiva.

### **Nascondere una forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/sethidden/) su `true` mantiene la forma nella collezione ma ne impedisce la comparsa nella presentazione normale. Il suo indice, la formattazione e il contenuto rimangono disponibili per il codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

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

Nascondere non è cancellazione né sicurezza. L'oggetto può ancora essere scoperto e resa visibile da un utente o dal codice, e rimane parte del file di presentazione.

### **Modificare l'ordine Z**

Le forme sovrapposte vengono dipinte nell'ordine della collezione. [reorder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/reorder/) sposta una forma esistente a un indice di destinazione senza clonarla. L'indice `0` è il retro; `size() - 1` è il fronte.

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

Il rettangolo è creato per primo e inizialmente si trova dietro l'ellisse. Spostandolo all'indice finale lo porta in primo piano. Finalizza l'ordine Z dopo aver aggiunto o clonato tutte le forme correlate, perché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare lo stack previsto.

## **Ispezionare le forme nelle diapositive layout**

Le diapositive normali, le diapositive layout e le diapositive master hanno collezioni di forme separate. Una forma nella collezione di layout non è lo stesso oggetto di una forma posizionata in modo simile su una diapositiva normale. Ispeziona le forme di layout quando devi comprendere o modificare la formattazione fornita da un layout.

L'esempio seguente legge il [FillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getfillformat/) e il [LineFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getlineformat/) di ciascuna forma di layout senza presumere che ogni forma sia un `AutoShape`.

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

Modificare un layout può influire su più diapositive che lo usano. Prima di cambiare una forma di layout, determina se una diapositiva normale eredita l'oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che utilizza quel layout.

## **Esportare una forma in SVG**

[writeAsSvg](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/) scrive il contenuto renderizzato di una forma in uno stream. Il risultato contiene la forma, non lo sfondo dell'intera diapositiva o le forme vicine.

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

Mantieni la presentazione aperta durante il rendering. L'output dipende dalla formattazione della forma e dalle risorse come font e immagini. Se ti serve l'intera composizione, esporta la diapositiva anziché la singola forma. Chi chiama è responsabile dello stream e deve chiuderlo.

## **Allineare le forme**

Le overload di [SlideUtil.alignShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/alignshapes/) allineano tutte le forme o gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` su `true` per usare i bordi della diapositiva; impostalo su `false` per allineare le forme selezionate l'una rispetto all'altra.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti sono convertiti nei loro indici correnti immediatamente prima dell'allineamento.

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

L'allineamento cambia le posizioni, non l'ordine Z. L'allineamento relativo normalmente richiede almeno due forme, mentre la distribuzione orizzontale o verticale necessita di un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Ribaltare una forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapeframe/) memorizza posizione, dimensione, impostazioni di ribaltamento orizzontale e verticale e rotazione. I suoi valori `getFlipH` e `getFlipV` usano [NullableBool](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/nullablebool/): `True` abilita il ribaltamento, `False` lo disabilita e `NotDefined` preserva lo stato non specificato/predefinito.

La presentazione di input sotto contiene una forma non ribaltata.

![La forma prima del ribaltamento](shape_to_be_flipped.png)

L'esempio preserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Ciò è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/setframe/) sostituisce l'intero frame.

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

La forma salvata è ribaltata orizzontalmente e verticalmente mantenendo la posizione, la dimensione e la rotazione.

![La forma dopo il ribaltamento](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di una forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell'uso dell'indice. Preferisci una convenzione con `Name` o `AlternativeText` validata per modelli creati, o `OfficeInteropShapeId` per lavoro interop a livello di diapositiva.

**Nascondere una forma la rimuove dall'ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata è apparsa davanti a un'altra forma?**

`addClone` aggiunge il clone alla fine della collezione, che è il fronte dell'ordine Z. Usa `insertClone` per scegliere l'indice iniziale o `reorder` dopo che tutte le forme sono state aggiunte.