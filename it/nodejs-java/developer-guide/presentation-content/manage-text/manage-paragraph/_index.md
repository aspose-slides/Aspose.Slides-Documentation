---
title: Gestire i paragrafi di testo di PowerPoint in JavaScript
linktitle: Gestire Paragrafo
type: docs
weight: 40
url: /it/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- aggiungere testo
- aggiungere paragrafo
- gestire testo
- gestire paragrafo
- gestire punto elenco
- rientro paragrafo
- rientro sospensione
- punto elenco paragrafo
- elenco numerato
- elenco puntato
- proprietà del paragrafo
- importare HTML
- testo in HTML
- paragrafo in HTML
- paragrafo in immagine
- testo in immagine
- esportare paragrafo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuto HTML e immagini dei paragrafi con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Aspose.Slides for Node.js via Java rappresenta il testo come una gerarchia di frame di testo, paragrafi e porzioni:

* [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua raccolta di paragrafi.
* [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) rappresenta un paragrafo in un frame di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) rappresenta un run di testo all'interno di un paragrafo. Ogni porzione può avere la propria formattazione di testo e di carattere.

Un paragrafo può quindi contenere testo con caratteri, colori, dimensioni e altre formattazioni diverse usando più porzioni.

## **Creare e Formattare i Paragrafi**

### **Creare Paragrafi con Più Porzioni**

I passaggi seguenti creano un frame di testo con tre paragrafi, ciascuno contenente tre porzioni:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedere alla diapositiva pertinente tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) della forma.
5. Utilizzare il paragrafo predefinito e aggiungere altri due oggetti [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) al frame di testo.
6. Aggiungere un numero sufficiente di oggetti [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) affinché ogni paragrafo contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Impostare il testo di ciascuna porzione.
8. Applicare la formattazione a livello di carattere tramite [Portion.getPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/getportionformat/).
9. Salvare la presentazione modificata.

Questo esempio JavaScript implementa i passaggi:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Creare Elenchi Puntati e Numerati**

### **Creare un Elenco Puntato o Numerato**

I punti elenco e la numerazione rendono più facili da scansionare gli elementi correlati. In Aspose.Slides le impostazioni dell'elenco sono definite tramite [BulletFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/).

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedere alla diapositiva pertinente tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva selezionata.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) della forma.
5. Rimuovere il paragrafo predefinito dal frame di testo.
6. Creare un [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) per un punto elenco a simbolo.
7. Impostare [BulletFormat.setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/settype/) su [BulletType.Symbol](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bullettype/) e specificare il carattere del punto elenco.
8. Impostare il testo del paragrafo, l'indentazione, il colore e l'altezza del punto elenco.
9. Aggiungere il paragrafo al frame di testo.
10. Creare un secondo paragrafo e impostare [BulletFormat.setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/settype/) su [BulletType.Numbered](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bullettype/).
11. Configurare lo stile del punto elenco numerato e aggiungere il paragrafo al frame di testo.
12. Salvare la presentazione.

Questo esempio JavaScript crea un punto elenco a simbolo e un punto elenco numerato:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Utilizzare Punti Elenco con Immagine**

I punti elenco con immagine consentono di usare un'immagine personalizzata al posto di un simbolo o di un numero.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedere alla diapositiva pertinente tramite il suo indice.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) e accedere al suo [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/).
4. Rimuovere il paragrafo predefinito dal frame di testo.
5. Caricare l'immagine del punto elenco e aggiungerla alla raccolta di immagini della presentazione come [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/).
6. Creare un [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) e impostarne il testo.
7. Impostare [BulletFormat.setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/settype/) su [BulletType.Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bullettype/).
8. Assegnare l'immagine tramite [BulletFormat.getPicture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/getpicture/) e impostare l'altezza del punto elenco.
9. Aggiungere il paragrafo al frame di testo.
10. Salvare la presentazione modificata.

Questo esempio JavaScript crea un punto elenco con immagine:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Creare un Elenco a Più Livelli**

Impostare [ParagraphFormat.setDepth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setdepth/) per collocare i paragrafi a diversi livelli di un elenco. Il livello superiore ha una profondità di `0`.

1. Creare una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e accedere a una diapositiva.
2. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) e cancellare il paragrafo predefinito dal suo frame di testo.
3. Creare quattro paragrafi e configurare i loro simboli di punto elenco.
4. Impostare i valori di [ParagraphFormat.setDepth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setdepth/) su `0`, `1`, `2` e `3`.
5. Aggiungere i paragrafi al frame di testo e salvare la presentazione.

Questo esempio JavaScript crea un elenco puntato a quattro livelli:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Iniziare gli Elementi Numerati con Valori Personalizzati**

Usare [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Creare una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) a una diapositiva.
2. Cancellare il paragrafo predefinito dal frame di testo della forma.
3. Creare tre paragrafi numerati.
4. Impostare [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) su `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungere i paragrafi al frame di testo e salvare la presentazione.

Questo esempio JavaScript assegna un numero di partenza personalizzato a ciascun paragrafo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controllare il Layout del Paragrafo e le Proprietà di Fine**

### **Impostare un Rientro della Prima Riga**

Usare [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per controllare il rientro della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga verso destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usare [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) quando è necessario spostare l'intero paragrafo. Usare [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica vari valori di [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per dimostrare come il rientro della prima riga influisce sul layout del paragrafo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) della forma e rimuovere il paragrafo predefinito.
5. Creare diversi paragrafi e impostare valori diversi di [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per ciascuno.
6. Aggiungere i paragrafi al frame di testo.
7. Salvare la presentazione modificata.

Questo codice mostra come impostare un rientro di paragrafo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il rientro della prima riga dei paragrafi](first_line_indent.png)

### **Impostare un Rientro a Sospensione**

Un rientro a sospensione è un layout di paragrafo in cui la prima riga inizia a sinistra delle linee rimanenti. In Aspose.Slides si crea questo effetto con [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/). Passare un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) definisce la posizione sinistra del corpo del paragrafo, e [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro a sospensione, passare un valore positivo a `setMarginLeft` e un valore negativo a `setIndent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Accedere al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) della forma e rimuovere il paragrafo predefinito.
5. Creare paragrafi e passare un valore positivo a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) per ciascun paragrafo.
6. Passare un valore negativo a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per creare l'effetto di rientro a sospensione.
7. Aggiungere i paragrafi al frame di testo.
8. Salvare la presentazione modificata.

Questo codice mostra come impostare un rientro a sospensione per un paragrafo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il rientro a sospensione dei paragrafi](hanging_indent.png)

### **Impostare le Proprietà di Fine del Paragrafo**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) controlla la formattazione del segno di fine paragrafo. L'esempio seguente assegna una dimensione del carattere e un carattere latino al segno di fine del secondo paragrafo:

1. Creare o caricare una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e accedere a una diapositiva.
2. Aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) e cancellare il suo paragrafo predefinito.
3. Creare due paragrafi e aggiungere porzioni di testo a ciascuno.
4. Creare un [PortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Impostare [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) e [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Assegnare il formato con [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) e salvare la presentazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Conteggiare le Linee Renderizzate**

Usare [Paragraph.getLinesCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getLinesCount) per contare le linee occupate da un paragrafo dopo il layout del testo, inclusi gli avvolgimenti automatici. Questo è utile quando si verifica la lunghezza del testo e il layout in modelli di presentazione.

Un paragrafo è un elemento in [TextFrame.getParagraphs](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParagraphs) e può occupare diverse linee renderizzate. Un'interruzione di riga esplicita all'interno di un paragrafo forza una nuova linea senza creare un altro paragrafo. L'avvolgimento automatico crea linee in base alla larghezza disponibile senza inserire interruzioni di riga esplicite nel testo. Pertanto, conteggiare i paragrafi o i caratteri di interruzione di riga non fornisce il conteggio delle linee renderizzate.

L'esempio seguente crea una forma di testo, conta le sue linee, restringe la forma e quindi sostituisce il testo con una stringa più corta. L'avvolgimento è abilitato e l'adattamento automatico è disabilitato in modo che la larghezza della forma controlli l'avvolgimento senza ridurre automaticamente il testo o ridimensionare la forma. Le dimensioni della forma sono in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle linee nell'intero frame di testo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle linee, mentre sostituire il testo con la stringa breve lo riduce. I conteggi esatti possono variare in base alla disponibilità e sostituzione dei caratteri, alla dimensione del carattere, ai margini, all'indentazione, all'avvolgimento e alle impostazioni di adattamento automatico. Utilizzare i caratteri e le impostazioni di layout previste per l'ambiente di destinazione quando si verifica un modello.

Il conteggio delle linee da solo non determina se il testo supera i confini del contenitore. Anche l'altezza disponibile, le altezze delle linee, la spaziatura dei paragrafi e delle linee e il comportamento di adattamento automatico sono importanti; anche una singola linea può superare la larghezza disponibile quando l'avvolgimento è disabilitato.

## **Importare ed Esportare il Contenuto dei Paragrafi**

### **Importare Testo HTML nei Paragrafi**

Usare [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) per convertire il markup HTML in paragrafi e porzioni in un frame di testo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedere a una diapositiva e aggiungere una [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).
3. Accedere al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) della forma e cancellare il paragrafo predefinito.
4. Definire o leggere la stringa HTML di origine.
5. Passare la stringa HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Salvare la presentazione modificata.

Questo esempio JavaScript importa HTML in un frame di testo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Esportare il Testo del Paragrafo in HTML**

Usare [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) per esportare un intervallo selezionato di paragrafi come HTML.

1. Creare o caricare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedere alla diapositiva e trovare la [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) che contiene il testo.
3. Accedere al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) della forma.
4. Chiamare [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) con l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivere la stringa HTML restituita in un file.

Questo esempio JavaScript autonomo crea una forma di testo ed esporta tutti i suoi paragrafi:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Renderizzare un Paragrafo come Immagine**

[Paragraph.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getImage) renderizza un singolo paragrafo direttamente e restituisce un [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/). Salva il risultato in un file con [IImage.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/#save). Non è necessario renderizzare la forma contenente o ritagliare manualmente un bitmap.

[Paragraph.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getImage) può restituire `null` se il paragrafo non viene trovato nella sua collezione padre, non ha limiti di rendering validi o non può essere renderizzato. Verifica il risultato prima di salvarlo e rilascia l'immagine restituita dopo l'uso.

#### **Renderizzare un Paragrafo alla Scala Predefinita**

La casella di testo seguente contiene tre paragrafi:

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

L'esempio seguente renderizza il secondo paragrafo in una forma di testo normale alla scala predefinita e salva l'immagine restituita in formato PNG. Il blocco `finally` garantisce che l'immagine venga rilasciata correttamente.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'immagine del paragrafo](paragraph_to_image_output.png)

#### **Renderizzare un Paragrafo in una Cella di Tabella con Scaling**

Usare la sovraccarico di [Paragraph.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getImage) che accetta i parametri `scaleX` e `scaleY` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, renderizza il paragrafo nella sua prima cella a due volte la larghezza e l'altezza predefinite, e salva il risultato come immagine PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Un fattore di scala di `1` mantiene quell'asse alle dimensioni predefinite in pixel. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi in genere producono testi più nitidi per lo zoom o l'output ad alta risoluzione, ma aumentano anche l'uso di memoria e la dimensione del file. Fattori inferiori a `1` producono immagini più piccole con meno dettagli. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi allungano l'output in modo indipendente.

Renderizzare un'intera forma con [Shape.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage) resta utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine contenente solo il paragrafo, usa [Paragraph.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Posso disabilitare completamente l'avvolgimento delle righe all'interno di un frame di testo?**

Sì. Imposta [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/setwraptext/) per disabilitare l'avvolgimento in modo che le righe non si interrompano ai bordi del frame di testo.

**Come posso ottenere i limiti esatti del paragrafo specifico sulla diapositiva?**

Usa [Paragraph.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/getrect/) per recuperare il rettangolo di delimitazione del paragrafo. [Portion.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#getRect) fornisce i limiti di una singola porzione.

**Dove viene controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setalignment/) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di revisione per una parte di un paragrafo?**

Sì. Imposta [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) per le singole porzioni, così un paragrafo può contenere testo in più lingue.