---
title: Gestire le caselle di testo nelle presentazioni usando JavaScript
linktitle: Gestire la casella di testo
type: docs
weight: 20
url: /it/nodejs-java/manage-textbox/
keywords:
- casella di testo
- riquadro di testo
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
description: "Crea, identifica, formatta e aggiorna le caselle di testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Node.js via Java."
---
## **Introduzione**

In Aspose.Slides for Node.js via Java, il testo delle diapositive è memorizzato nei riquadri di testo che appartengono alle forme. La classe [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) rappresenta la forma più comune contenente testo ed espone il suo testo tramite il metodo [AutoShape.getTextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Ogni forma automatica deriva da [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/), ma non tutte le forme sono forme automatiche o supportano un riquadro di testo. Quando si elabora una presentazione esistente, verificare che una forma sia un'istanza di [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) prima di accedere al suo testo.

{{% /alert %}}

## **Creare una casella di testo su una diapositiva**

Per creare una casella di testo, aggiungere una forma automatica a una diapositiva, aggiungere testo al suo riquadro di testo e salvare la presentazione. L'esempio seguente crea una casella di testo rettangolare:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le coordinate e le dimensioni passate a [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addAutoShape) sono misurate in punti. [AutoShape.addTextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/#addTextFrame) inizializza il riquadro di testo con il testo fornito.

## **Verificare la presenza di una forma casella di testo**

Utilizzare il metodo [AutoShape.isTextBox](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/#isTextBox) per determinare se una forma automatica è trattata come una casella di testo. Questo è utile quando una presentazione contiene sia forme automatiche con testo sia forme puramente grafiche.

![Una casella di testo e una forma](istextbox.png)

L'esempio seguente esamina ogni forma automatica in una presentazione:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Una forma automatica appena aggiunta non è considerata una casella di testo finché non contiene testo non vuoto. È possibile fornire quel testo tramite [AutoShape.addTextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/#addTextFrame) o [TextFrame.setText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#setText). Aggiungere o assegnare una stringa vuota fa sì che [AutoShape.isTextBox](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/#isTextBox) restituisca `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Le prime due chiamate stampano `true`; le ultime due stampano `false`.

## **Trovare la forma che possiede un riquadro di testo**

Il codice generico di elaborazione del testo può ricevere un [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) senza conoscere quale oggetto della presentazione lo contiene. Utilizzare il metodo di sola lettura [TextFrame.getParentShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentShape) per tornare alla sua forma proprietaria [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/).

Per un riquadro di testo posseduto da una forma automatica o da un'altra forma con testo, [TextFrame.getParentShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentShape) restituisce il proprietario e [TextFrame.getParentCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentCell) restituisce `null`. Controllare il valore restituito prima di accedervi. Per identificare sia i proprietari di forma sia quelli di cella di tabella, comprese le forme associate a nodi SmartArt, vedere [Cerca e sostituisci testo](/slides/it/nodejs-java/search-and-replace-text/).

## **Aggiungere colonne a una casella di testo**

Il metodo [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setColumnCount) divide il riquadro di testo in colonne, mentre [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) imposta lo spazio tra le colonne in punti. Entrambe le impostazioni appartengono a [TextFrameFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/) e possono essere modificate tramite il riquadro di testo di una casella di testo esistente. Il testo si ridistribuisce tra le colonne all'interno della stessa forma; non continua in un'altra forma.

L'esempio seguente crea una casella di testo a tre colonne con 10 punti tra le colonne, salva la presentazione e legge le impostazioni memorizzate dal file di output:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Estrarre il testo dalle singole colonne**

Utilizzare [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#splitTextByColumns) per recuperare il testo assegnato a ciascuna colonna visiva in un riquadro di testo esistente. Il metodo restituisce una stringa per ogni colonna, nell'ordine di lettura basato sulle colonne. Un riquadro di testo a singola colonna produce un array con un elemento, e una colonna vuota è rappresentata da una stringa vuota. Le stringhe contengono solo testo semplice; la formattazione a livello di porzione non è conservata.

Ciò è utile quando è necessario:

- Estrarre il testo preservando l'ordine di lettura basato sulle colonne.
- Indicizzare o confrontare il contenuto di diapositive a più colonne.
- Esportare ogni colonna in un file separato, campo di database o altra destinazione.
- Esaminare come il testo viene ridistribuito dopo aver modificato il conteggio delle colonne con [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setColumnCount), la spaziatura con [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), il carattere o le dimensioni del riquadro di testo.

Il metodo segnala il testo distribuito all'interno del corrente [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/); non fluisce automaticamente il testo tra forme o caselle di testo separate. La distribuzione delle colonne può dipendere dai caratteri disponibili e da altre impostazioni di layout del testo, quindi assicurarsi che i caratteri richiesti siano disponibili quando è importante ottenere risultati coerenti.

L'esempio seguente carica una presentazione, trova la prima forma automatica a più colonne con un riquadro di testo, legge il conteggio di colonne configurato e scrive il testo di ogni colonna in un file separato. Le forme che non forniscono un riquadro di testo vengono ignorate.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Aggiornare il testo**

Per aggiornare il testo in tutta la presentazione, iterare diapositive e forme, selezionare le forme automatiche e quindi modificare le loro porzioni di testo. Lavorare a livello di porzione consente di modificare sia il testo sia la formattazione dei caratteri.

L'esempio seguente sostituisce ogni occorrenza di `years` con `months` nel testo delle forme automatiche e rende ogni porzione interessata in grassetto:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questo percorso aggiorna il testo solo nelle forme automatiche. Il testo memorizzato in tabelle, grafici, SmartArt o forme raggruppate richiede l'iterazione delle collezioni di quegli oggetti.

## **Aggiungere una casella di testo con un collegamento ipertestuale**

È possibile assegnare un collegamento ipertestuale a una specifica porzione di testo, in modo che solo quel testo agisca da link cliccabile. Utilizzare [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) per associare la porzione a un URL esterno.

L'esempio seguente crea del testo collegato e lo salva in una presentazione:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo su una diapositiva master o layout?**

Un [placeholder](/slides/it/nodejs-java/manage-placeholder/) può ereditare la sua posizione e formattazione da una [master slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/) o da una [layout slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/). Una normale casella di testo è una forma indipendente sulla diapositiva in cui è stata creata e non acquisisce il comportamento di segnaposto quando il layout cambia.

**Come posso sostituire il testo senza modificare quello all'interno di grafici, tabelle o SmartArt?**

Limitare l'iterazione alle forme che sono istanze di [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/), come mostrato nell'esempio Aggiorna testo. Grafici, tabelle e SmartArt memorizzano il testo nei propri modelli di oggetto, quindi non vengono modificati da quel ciclo.