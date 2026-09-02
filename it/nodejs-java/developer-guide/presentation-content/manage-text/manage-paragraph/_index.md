---
title: Gestire i paragrafi di testo PowerPoint in JavaScript
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
- gestire elenco puntato
- rientro del paragrafo
- rientro sospeso
- punto elenco del paragrafo
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
description: "Scopri come creare e formattare paragrafi, porzioni, punti elenco, elenchi numerati, rientri, contenuti HTML e immagini dei paragrafi con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Aspose.Slides per Node.js tramite Java rappresenta il testo come una gerarchia di TextFrame, Paragraph e Portion:

* [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua collezione di paragrafi.
* [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) rappresenta un paragrafo in un TextFrame e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) rappresenta una sequenza di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con diversi caratteri, colori, dimensioni e altra formattazione utilizzando più porzioni.

## **Creare e Formattare i Paragrafi**

### **Creare Paragrafi con Più Porzioni**

I passaggi seguenti creano un TextFrame con tre paragrafi, ognuno contenente tre porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi un [AutoShape] rettangolare alla diapositiva.
4. Accedi al [TextFrame] della forma.
5. Usa il paragrafo predefinito e aggiungi altri due oggetti [Paragraph] al TextFrame.
6. Aggiungi sufficienti oggetti [Portion] affinché ogni paragrafo contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Imposta il testo di ogni porzione.
8. Applica la formattazione a livello di carattere tramite [Portion.getPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/getportionformat/).
9. Salva la presentazione modificata.

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

Le sezioni puntate e numerate facilitano la lettura di elementi correlati. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [BulletFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/).

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi un [AutoShape] alla diapositiva selezionata.
4. Accedi al [TextFrame] della forma.
5. Rimuovi il paragrafo predefinito dal TextFrame.
6. Crea un [Paragraph] per un bullet a simbolo.
7. Imposta [BulletFormat.setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/settype/) su [BulletType.Symbol](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bullettype/) e specifica il carattere del bullet.
8. Imposta il testo del paragrafo, l'indentazione, il colore del bullet e l'altezza del bullet.
9. Aggiungi il paragrafo al TextFrame.
10. Crea un secondo paragrafo e imposta [BulletFormat.setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/settype/) su [BulletType.Numbered](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bullettype/).
11. Configura lo stile del bullet numerato e aggiungi il paragrafo al TextFrame.
12. Salva la presentazione.

Questo esempio JavaScript crea un bullet a simbolo e un bullet numerato:

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

### **Usare i Bullet con Immagine**

I bullet con immagine ti consentono di usare un'immagine personalizzata al posto di un simbolo o di un numero.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla diapositiva pertinente tramite il suo indice.
3. Aggiungi un [AutoShape] e accedi al suo [TextFrame].
4. Rimuovi il paragrafo predefinito dal TextFrame.
5. Carica l'immagine del bullet e aggiungila alla collezione di immagini della presentazione come [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/).
6. Crea un [Paragraph] e imposta il suo testo.
7. Imposta [BulletFormat.setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/settype/) su [BulletType.Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bullettype/).
8. Assegna l'immagine tramite [BulletFormat.getPicture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/getpicture/) e imposta l'altezza del bullet.
9. Aggiungi il paragrafo al TextFrame.
10. Salva la presentazione modificata.

Questo esempio JavaScript crea un bullet con immagine:

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

### **Creare un Elenco Multilivello**

Imposta [ParagraphFormat.setDepth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setdepth/) per posizionare i paragrafi a diversi livelli di un elenco. Il livello superiore ha una profondità di `0`.

1. Crea un [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi un [AutoShape] e cancella il paragrafo predefinito dal suo TextFrame.
3. Crea quattro paragrafi e configura i loro simboli di bullet.
4. Imposta i loro valori [ParagraphFormat.setDepth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setdepth/) a `0`, `1`, `2` e `3`.
5. Aggiungi i paragrafi al TextFrame e salva la presentazione.

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

### **Iniziare gli Elementi Numerati dell'Elenco con Valori Personalizzati**

Usa [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Crea un [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e aggiungi un [AutoShape] a una diapositiva.
2. Cancella il paragrafo predefinito dal TextFrame della forma.
3. Crea tre paragrafi numerati.
4. Imposta [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) a `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungi i paragrafi al TextFrame e salva la presentazione.

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

## **Controllare il Layout dei Paragrafi e le Proprietà di Fine**

### **Impostare un Rientro della Prima Linea**

Utilizza [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per controllare il rientro della prima linea di un paragrafo. Questo metodo sposta solo la prima linea rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima linea a destra, mentre le linee rimanenti rimangono allineate al corpo del paragrafo.

Usa [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) quando è necessario spostare l'intero paragrafo. Usa [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) quando devi spostare solo la prima linea.

L'esempio seguente crea diversi paragrafi e applica valori diversi di [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per dimostrare come il rientro della prima linea influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi un [AutoShape] rettangolare alla diapositiva.
4. Accedi al [TextFrame] della forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per ciascuno.
6. Aggiungi i paragrafi al TextFrame.
7. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro del paragrafo:

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

![Il rientro della prima linea dei paragrafi](first_line_indent.png)

### **Impostare un Rientro Sospeso**

Un rientro sospeso è un layout di paragrafo in cui la prima linea inizia a sinistra delle linee successive. In Aspose.Slides, crei questo effetto con [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/). Passa un valore negativo per spostare la prima linea a sinistra rispetto al corpo del paragrafo.

Nella pratica, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) definisce la posizione sinistra del corpo del paragrafo, e [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) definisce la posizione della prima linea rispetto a quel margine. Per creare un rientro sospeso, passa un valore positivo a `setMarginLeft` e un valore negativo a `setIndent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le linee a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima linea.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi un [AutoShape] rettangolare alla diapositiva.
4. Accedi al [TextFrame] della forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e passa un valore positivo a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) per ciascun paragrafo.
6. Passa un valore negativo a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per creare l'effetto del rientro sospeso.
7. Aggiungi i paragrafi al TextFrame.
8. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro sospeso per un paragrafo:

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

![Il rientro sospeso dei paragrafi](hanging_indent.png)

### **Impostare le Proprietà di Fine del Paragrafo**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) controlla la formattazione del segno di fine del paragrafo. L'esempio seguente assegna una dimensione del carattere e un font latino al segno di fine del secondo paragrafo:

1. Crea o carica una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi un [AutoShape] e cancella il suo paragrafo predefinito.
3. Crea due paragrafi e aggiungi porzioni di testo a ciascuno.
4. Crea un [PortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Imposta [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) e [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Assegna la formattazione con [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) e salva la presentazione.

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

## **Importare ed Esportare il Contenuto dei Paragrafi**

### **Importare Testo HTML nei Paragrafi**

Usa [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) per convertire il markup HTML in paragrafi e porzioni in un TextFrame.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi a una diapositiva e aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).
3. Accedi al [TextFrame] della forma e cancella il suo paragrafo predefinito.
4. Definisci o leggi la stringa HTML di origine.
5. Passa la stringa HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Salva la presentazione modificata.

Questo esempio JavaScript importa HTML in un TextFrame:

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

Usa [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) per esportare un intervallo selezionato di paragrafi come HTML.

1. Crea o carica un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla diapositiva e trova il [AutoShape] che contiene il testo.
3. Accedi al [TextFrame] della forma.
4. Chiama [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) con l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivi la stringa HTML restituita su un file.

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

[Paragraph.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getImage) renderizza direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/). Salva il risultato su un file con [IImage.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/#save). Non è necessario renderizzare la forma contenitrice o ritagliare manualmente un bitmap.

[Paragraph.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getImage) può restituire `null` se il paragrafo non è trovato nella sua collezione genitore, non ha limiti di rendering validi o non può essere renderizzato. Controlla il risultato prima di salvarlo e rilascia l'immagine restituita dopo l'uso.

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

#### **Renderizzare un Paragrafo in una Cella di Tabella con Scala**

Usa la sovraccarica di [Paragraph.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getImage) che accetta i parametri `scaleX` e `scaleY` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, renderizza il paragrafo nella sua prima cella a due volte la larghezza e l'altezza predefinite, e salva il risultato come immagine PNG.

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

Un fattore di scala di `1` mantiene quell'asse alle dimensioni pixel predefinite. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per lo zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e le dimensioni del file. Fattori inferiori a `1` producono immagini più piccole con meno dettaglio. Usa fattori uguali per preservare le proporzioni del paragrafo; fattori diversi per gli assi orizzontale e verticale allungano l'output indipendentemente.

Renderizzare un'intera forma con [Shape.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage) rimane utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine solo del paragrafo, usa [Paragraph.getImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Posso disabilitare completamente a capo automatico all'interno di un TextFrame?**

Sì. Imposta [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/setwraptext/) per disabilitare l'andare a capo in modo che le linee non si interruttano ai bordi del TextFrame.

**Come posso ottenere i limiti esatti sulla diapositiva di un paragrafo specifico?**

Usa [Paragraph.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/getrect/) per recuperare il rettangolo di delimitazione del paragrafo. [Portion.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#getRect) fornisce i limiti di una singola porzione.

**Dove viene controllato l'allineamento del paragrafo (sinistra, destra, al centro o giustificato)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setalignment/) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per parte di un paragrafo?**

Sì. Imposta [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) per le singole porzioni, così un paragrafo può contenere testo in più lingue.