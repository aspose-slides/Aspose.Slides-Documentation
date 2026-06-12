---
title: Gestire le caselle di testo nelle presentazioni usando JavaScript
linktitle: Gestire casella di testo
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

I testi sulle diapositive si trovano tipicamente in caselle di testo o forme. Pertanto, per aggiungere del testo a una diapositiva, è necessario inserire una casella di testo e poi inserire del testo all’interno della casella. Aspose.Slides per Node.js via Java fornisce la classe [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) che consente di aggiungere una forma contenente del testo.

{{% alert title="Info" color="info" %}}
Aspose.Slides fornisce anche la classe [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape) che permette di aggiungere forme alle diapositive. Tuttavia, non tutte le forme aggiunte tramite la classe `Shape` possono contenere testo. Le forme aggiunte tramite la classe [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) possono invece contenere testo.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Pertanto, quando si lavora con una forma a cui si desidera aggiungere testo, è opportuno verificare e confermare che sia stata creata tramite la classe `AutoShape`. Solo allora sarà possibile lavorare con [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrame), che è una proprietà di `AutoShape`. Vedere la sezione [Update Text](https://docs.aspose.com/slides/it/nodejs-java/manage-textbox/#update-text) in questa pagina.
{{% /alert %}}

## **Crea casella di testo su diapositiva**

Per creare una casella di testo su una diapositiva, segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).  
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata.  
3. Aggiungi un oggetto [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) con `ShapeType` impostato su `Rectangle` nella posizione desiderata sulla diapositiva e ottieni il riferimento all’oggetto `AutoShape` appena aggiunto.  
4. Aggiungi una proprietà `TextFrame` all’oggetto `AutoShape` che conterrà il testo. Nell’esempio seguente, abbiamo aggiunto questo testo: *Aspose TextBox*  
5. Infine, scrivi il file PPTX attraverso l’oggetto `Presentation`.  

Il seguente codice JavaScript—un’implementazione dei passaggi sopra—mostra come aggiungere testo a una diapositiva:

```javascript
// Istanzia la presentazione
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    var sld = pres.getSlides().get_Item(0);
    // Aggiunge un AutoShape con il tipo impostato a Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Aggiunge TextFrame al Rectangle
    ashp.addTextFrame(" ");
    // Accede al TextFrame
    var txtFrame = ashp.getTextFrame();
    // Crea l'oggetto Paragraph per il TextFrame
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

## **Verifica forma casella di testo**

Aspose.Slides fornisce il metodo [isTextBox](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/#isTextBox) della classe [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) che consente di esaminare le forme e identificare le caselle di testo.

![Text box and shape](istextbox.png)

Questo codice JavaScript mostra come verificare se una forma è stata creata come casella di testo:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Nota che se aggiungi semplicemente un’autoshape usando il metodo `addAutoShape` della classe [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/), il metodo `isTextBox` dell’autoshape restituirà `false`. Tuttavia, dopo aver aggiunto testo all’autoshape mediante il metodo `addTextFrame` o il metodo `setText`, la proprietà `isTextBox` restituisce `true`.

```javascript
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

## **Aggiungi colonna nella casella di testo**

Aspose.Slides fornisce i metodi [setColumnCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) e [setColumnSpacing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat). Questi consentono di aggiungere colonne alle caselle di testo. Puoi specificare il numero di colonne nella casella di testo e impostare la distanza in punti tra le colonne.

Il seguente codice JavaScript dimostra l’operazione descritta:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    var slide = pres.getSlides().get_Item(0);
    // Aggiunge un AutoShape con tipo impostato a Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Aggiunge TextFrame al Rectangle
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

## **Aggiungi colonna nel Text Frame**

Aspose.Slides for Node.js via Java fornisce il metodo [setColumnCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) della classe [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/TextFrameFormat) che permette di aggiungere colonne nei frame di testo. Attraverso questa proprietà, è possibile specificare il numero di colonne desiderato in un Text Frame.

Questo codice JavaScript mostra come aggiungere una colonna all’interno di un Text Frame:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

Il seguente codice JavaScript dimostra un’operazione in cui tutti i testi di una presentazione vengono aggiornati o modificati:

```javascript
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

È possibile inserire un collegamento all’interno di una casella di testo. Quando la casella di testo viene cliccata, gli utenti vengono indirizzati al collegamento.

Per aggiungere una casella di testo contenente un collegamento, segui questi passaggi:

1. Crea un’istanza della classe `Presentation`.  
2. Ottieni un riferimento alla prima diapositiva nella presentazione appena creata.  
3. Aggiungi un oggetto `AutoShape` con `ShapeType` impostato su `Rectangle` nella posizione desiderata sulla diapositiva e ottieni il riferimento all’oggetto AutoShape appena aggiunto.  
4. Aggiungi un `TextFrame` all’oggetto `AutoShape` che contiene *Aspose TextBox* come testo predefinito.  
5. Istanzia la classe `HyperlinkManager`.  
6. Assegna l’oggetto `HyperlinkManager` alla proprietà [HyperlinkClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) associata alla porzione desiderata del `TextFrame`.  
7. Infine, scrivi il file PPTX attraverso l’oggetto `Presentation`.  

Questo codice JavaScript—un’implementazione dei passaggi sopra—mostra come aggiungere una casella di testo con collegamento ipertestuale a una diapositiva:

```javascript
// Istanzia una classe Presentation che rappresenta un PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva nella presentazione
    var slide = pres.getSlides().get_Item(0);
    // Aggiunge un oggetto AutoShape con tipo impostato a Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Effettua il cast della forma a AutoShape
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

Un [placeholder](/slides/it/nodejs-java/manage-placeholder/) eredita stile/posizione dal [master](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/) e può essere sovrascritto nei [layout](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/), mentre una normale casella di testo è un oggetto indipendente su una diapositiva specifica e non cambia quando si cambiano i layout.

**Come posso eseguire una sostituzione di testo in blocco su tutta la presentazione senza modificare il testo all’interno di grafici, tabelle e SmartArt?**

Limita l’iterazione alle auto‑shape che contengono TextFrames ed escludi gli oggetti incorporati ([chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/), [table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartart/)) attraversando le loro collezioni separatamente o saltando quei tipi di oggetto.