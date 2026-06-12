---
title: Ottieni i limiti dei paragrafi dalle presentazioni in JavaScript
linktitle: Paragrafo
type: docs
weight: 60
url: /it/nodejs-java/paragraph/
keywords:
- limiti del paragrafo
- limiti della porzione di testo
- coordinate del paragrafo
- coordinate della porzione
- dimensione del paragrafo
- dimensione della porzione di testo
- frame di testo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come recuperare i limiti dei paragrafi e delle porzioni di testo in JavaScript con Aspose.Slides per Node.js per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, la dimensione e le coordinate di paragrafi e porzioni di testo in Aspose.Slides. Mostra come recuperare il rettangolo di un paragrafo in un `TextFrame` usando `getRect()`, come ottenere le coordinate di paragrafi e porzioni all'interno di un frame di testo di una cella di tabella, e evidenzia dettagli importanti come le unità di misura, l'effetto del word wrapping sui limiti, la conversione in pixel e i valori di formattazione del paragrafo efficace.

## **Ottenere le coordinate di Paragrafo e Porzione in TextFrame**
Utilizzando Aspose.Slides for Node.js via Java, gli sviluppatori possono ora ottenere le coordinate rettangolari per il Paragraph all'interno della collezione di paragrafi di TextFrame. Consente anche di ottenere [le coordinate della porzione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Portion#getCoordinates--) nella collezione di porzioni di un paragrafo. In questo argomento, dimostreremo con l'aiuto di un esempio come ottenere le coordinate rettangolari per il paragrafo insieme alla posizione della porzione all'interno dello stesso.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **Ottenere le coordinate rettangolari del paragrafo**
Utilizzando il metodo [**getRect()**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Paragraph#getRect--) gli sviluppatori possono ottenere il rettangolo dei limiti del paragrafo.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ottenere la dimensione di paragrafo e porzione all'interno del frame di testo di una cella di tabella**

Per ottenere la dimensione e le coordinate della [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Portion) o del [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Paragraph) in un frame di testo di una cella di tabella, è possibile utilizzare i metodi [Portion.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Portion#getRect--) e [Paragraph.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Paragraph#getRect--).

Questo codice di esempio dimostra l'operazione descritta:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**In quali unità vengono restituiti i coordinate di un paragrafo e delle porzioni di testo?**

In punti, dove 1 pollice = 72 punti. Questo vale per tutte le coordinate e dimensioni nella diapositiva.

**L'incorniciatura del testo (word wrapping) influisce sui limiti di un paragrafo?**

Sì. Se il [wrapping](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/setwraptext/) è abilitato nel [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/), il testo viene interrotto per adattarsi alla larghezza dell'area, modificando i limiti effettivi del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile a pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando: pixel = punti × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering/esportazione.

**Come ottenere i parametri di formattazione del paragrafo "efficaci", tenendo conto dell'ereditarietà di stile?**

Utilizza la [effective paragraph formatting data structure](/slides/it/nodejs-java/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziatura, incorniciatura, RTL e altro.