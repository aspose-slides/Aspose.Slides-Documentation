---
title: "Gestire le caselle di testo nelle presentazioni usando JavaScript"
linktitle: "Gestire la casella di testo"
type: docs
weight: 20
url: /it/nodejs-java/manage-textbox/
keywords:
- casella di testo
- frame di testo
- aggiungere testo
- aggiornare testo
- creare casella di testo
- verificare casella di testo
- aggiungere colonna di testo
- aggiungere collegamento ipertestuale
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides per Node.js semplifica la creazione, modifica e clonazione delle caselle di testo nei file PowerPoint e OpenDocument, migliorando l'automazione delle tue presentazioni."
---
## **Introduzione**

I testi nelle diapositive solitamente si trovano in caselle di testo o forme. Pertanto, per aggiungere un testo a una diapositiva, è necessario aggiungere una casella di testo e poi inserire del testo all'interno della casella. Aspose.Slides for Node.js via Java fornisce la classe [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) che consente di aggiungere una forma contenente del testo.

{{% alert title="Info" color="info" %}}

Aspose.Slides fornisce anche la classe [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape) che consente di aggiungere forme alle diapositive. Tuttavia, non tutte le forme aggiunte tramite la classe `Shape` possono contenere testo. Le forme aggiunte tramite la classe [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) invece possono contenere testo.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Pertanto, quando si lavora con una forma a cui si desidera aggiungere testo, è consigliabile verificare e confermare che sia stata convertita tramite la classe `AutoShape`. Solo in questo modo sarà possibile lavorare con [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrame), che è una proprietà di `AutoShape`. Vedi la sezione [Aggiorna testo](https://docs.aspose.com/slides/it/nodejs-java/manage-textbox/#update-text) di questa pagina.

{{% /alert %}}

## **Crea casella di testo sulla diapositiva**

Per creare una casella di testo su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata. 
3. Aggiungi un oggetto [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) con [ShapeType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) impostato su `Rectangle` in una posizione specificata sulla diapositiva e ottieni il riferimento all'oggetto `AutoShape` appena aggiunto.
4. Aggiungi la proprietà `TextFrame` all'oggetto `AutoShape` che conterrà del testo. Nell'esempio seguente, abbiamo aggiunto questo testo: *Aspose TextBox*
5. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice JavaScript—un'implementazione dei passaggi sopra—mostra come aggiungere testo a una diapositiva:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanzia la Presentazione
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    var sld = pres.getSlides().get_Item(0);
    // Aggiunge un AutoShape con tipo impostato a Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Aggiunge TextFrame al rettangolo
    ashp.addTextFrame(" ");
    // Accede al frame di testo
    var txtFrame = ashp.getTextFrame();
    // Crea l'oggetto Paragraph per il frame di testo
    var para = txtFrame.getParagraphs().get_Item(0);
    // Crea un oggetto Portion per il paragrafo
    var portion = para.getPortions().get_Item(0);
    // Imposta il testo
    portion.setText("Aspose TextBox");
    // Salva la presentazione su disco
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Verifica la forma casella di testo**

Aspose.Slides fornisce il metodo [isTextBox](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/#isTextBox) della classe [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) che consente di esaminare le forme e identificare le caselle di testo.

![Casella di testo e forma](istextbox.png)

Questo codice JavaScript mostra come verificare se una forma è stata creata come casella di testo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Nota che se si aggiunge semplicemente un'autoshape usando il metodo `addAutoShape` della classe [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/), il metodo `isTextBox` dell'autoshape restituirà `false`. Tuttavia, dopo aver aggiunto testo all'autoshape usando il metodo `addTextFrame` o il metodo `setText`, la proprietà `isTextBox` restituisce `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() restituisce false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() restituisce true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() restituisce false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() restituisce true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() restituisce false
shape3.addTextFrame("");
// shape3.isTextBox() restituisce false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() restituisce false
shape4.getTextFrame().setText("");
// shape4.isTextBox() restituisce false
```

## **Trova la forma che possiede un TextFrame**

In codice generico di elaborazione del testo, potresti ricevere un [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) senza sapere già quale oggetto di presentazione lo contiene. Usa il metodo [TextFrame.getParentShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentShape--) per tornare alla [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) proprietaria.

Per un TextFrame che appartiene a una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) o a un'altra forma contenente testo, [TextFrame.getParentShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentShape--) restituisce il proprietario e [TextFrame.getParentCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentCell--) restituisce `null`. Entrambi i metodi forniscono una navigazione di sola lettura, quindi la loro chiamata non modifica la proprietà. Verifica sempre che il valore restituito non sia `null` prima di accedere alla forma.

Per un esempio completo che identifica i proprietari di forma e di cella tabella, incluse le forme associate a nodi SmartArt, vedi [Cerca e sostituisci testo](/slides/it/nodejs-java/search-and-replace-text/).

## **Aggiungi colonna in casella di testo**

Aspose.Slides fornisce i metodi [setColumnCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) e [setColumnSpacing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat) che consentono di aggiungere colonne alle caselle di testo. Puoi specificare il numero di colonne in una casella di testo e impostare la spaziatura, in punti, tra le colonne.

Questo codice JavaScript dimostra l'operazione descritta:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    var slide = pres.getSlides().get_Item(0);
    // Aggiunge un AutoShape con tipo impostato a Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Aggiunge TextFrame al rettangolo
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Ottiene il formato del testo del TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Specifica il numero di colonne nel TextFrame
    format.setColumnCount(3);
    // Specifica la spaziatura tra le colonne
    format.setColumnSpacing(10);
    // Salva la presentazione
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungi colonna in TextFrame**

Aspose.Slides for Node.js via Java fornisce il metodo [setColumnCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat) che consente di aggiungere colonne nei TextFrame. Attraverso questa proprietà, puoi specificare il numero di colonne desiderato in un TextFrame.

Questo codice JavaScript mostra come aggiungere una colonna all'interno di un TextFrame:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // La spaziatura della colonna non è mai stata impostata, quindi viene riportata come NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiorna testo**

Aspose.Slides consente di modificare o aggiornare il testo contenuto in una casella di testo o tutti i testi contenuti in una presentazione. 

Questo codice JavaScript dimostra un'operazione in cui tutti i testi di una presentazione vengono aggiornati o modificati:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Verifica se la forma supporta il frame di testo (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Itera attraverso i paragrafi nel frame di testo
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Itera attraverso ogni porzione nel paragrafo
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Modifica il testo
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Modifica la formattazione
                    }
                }
            }
        }
    }
    // Salva la presentazione modificata
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungi casella di testo con collegamento ipertestuale** 

Puoi inserire un collegamento all'interno di una casella di testo. Quando la casella di testo viene cliccata, gli utenti vengono indirizzati all'apertura del collegamento. 

 Per aggiungere una casella di testo contenente un collegamento, segui questi passaggi:

1. Crea un'istanza della classe `Presentation`. 
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata. 
3. Aggiungi un oggetto `AutoShape` con `ShapeType` impostato su `Rectangle` in una posizione specificata sulla diapositiva e ottieni il riferimento all'oggetto AutoShape appena aggiunto.
4. Aggiungi un `TextFrame` all'oggetto `AutoShape` e imposta il testo della sua prima porzione. Nell'esempio sotto, abbiamo usato questo testo: *Aspose.Slides*
5. Ottieni il `HyperlinkManager` di quella porzione tramite il suo `PortionFormat`.
6. Chiama `setExternalHyperlinkClick` sul `HyperlinkManager` per collegare il collegamento alla porzione.
7. Infine, scrivi il file PPTX tramite l'oggetto `Presentation`. 

Questo codice JavaScript—un'implementazione dei passaggi sopra—mostra come aggiungere una casella di testo con collegamento ipertestuale a una diapositiva:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanzia una classe Presentation che rappresenta un PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    var slide = pres.getSlides().get_Item(0);
    // Aggiunge un oggetto AutoShape con tipo impostato a Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Converte la forma in AutoShape
    var pptxAutoShape = shape;
    // Accede alla proprietà ITextFrame associata all'AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Aggiunge del testo al frame
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Imposta il collegamento ipertestuale per il testo della porzione
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Salva la presentazione PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo quando si lavora con le diapositive master?**

Un [placeholder](/slides/it/nodejs-java/manage-placeholder/) eredita stile/posizione dal [master](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/) e può essere sovrascritto nei [layout](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/), mentre una casella di testo normale è un oggetto indipendente su una specifica diapositiva e non cambia quando si passa a un altro layout.

**Come posso eseguire una sostituzione di testo massiva su tutta la presentazione senza modificare il testo all'interno di grafici, tabelle e SmartArt?**

Limita l'iterazione alle auto‑forme che possiedono TextFrame ed escludi gli oggetti incorporati ([charts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartart/)) attraversando le loro collezioni separatamente o ignorando quei tipi di oggetto.