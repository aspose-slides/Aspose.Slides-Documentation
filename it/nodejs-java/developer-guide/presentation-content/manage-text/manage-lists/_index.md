---
title: Gestisci elenchi puntati e numerati nelle presentazioni usando JavaScript
linktitle: Gestisci gli elenchi
type: docs
weight: 60
url: /it/nodejs-java/manage-lists/
keywords:
- pallino
- elenco puntato
- elenco numerato
- pallino simbolo
- pallino immagine
- pallino personalizzato
- elenco multilivello
- crea pallino
- aggiungi pallino
- aggiungi elenco
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, con immagine, multilivello e numerati in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Aspose.Slides per Node.js tramite Java ti consente di creare e formattare elenchi puntati e numerati in presentazioni PowerPoint e OpenDocument. Un elemento dell'elenco è un paragrafo le cui impostazioni del pallino sono controllate tramite il formato del paragrafo.

Usa la classe [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) per accedere alle impostazioni dell'elenco a livello di paragrafo. Il punto di ingresso principale è `Paragraph.getParagraphFormat().getBullet()`, che restituisce un oggetto [BulletFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/). Con questo oggetto è possibile impostare il tipo di pallino, il simbolo, l'immagine, il colore, la dimensione, lo stile di numerazione e il numero iniziale.

Questo articolo mostra come:

- creare un elenco puntato con un simbolo personalizzato
- creare un pallino immagine
- creare un elenco a più livelli impostando la profondità del paragrafo
- creare un elenco numerato
- ispezionare e modificare la formattazione dell'elenco in una presentazione esistente

## **Creare un Elenco Puntato**

Per creare un elenco puntato, aggiungi oggetti [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) a un [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) e imposta `BulletFormat.setType` su [BulletType.Symbol](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bullettype/). Puoi quindi impostare `BulletFormat.setChar`, `BulletFormat.getColor` e `BulletFormat.setHeight` per controllare l'aspetto del pallino.

Il seguente codice JavaScript dimostra come creare un elenco puntato in una diapositiva:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![I simboli dei pallini](symbol_bullets.png)

## **Creare un Elenco Numerato**

Usa gli elenchi numerati quando l'ordine degli elementi è importante. Imposta `BulletFormat.setType` su [BulletType.Numbered](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bullettype/). Puoi anche scegliere un formato di numerazione con `BulletFormat.setNumberedBulletStyle` o impostare `BulletFormat.setNumberedBulletStartWith` quando l'elenco deve iniziare da un valore diverso da 1.

Il seguente codice JavaScript mostra come creare un elenco numerato in una diapositiva:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![I pallini numerati](numbered_bullets.png)

## **Creare un Pallino Immagine**

Aspose.Slides consente di sostituire un simbolo di pallino standard con un'immagine. I pallini immagine funzionano al meglio con immagini semplici che rimangono leggibili a dimensioni ridotte, come icone o piccoli file PNG trasparenti.

{{% alert color="primary" %}}
Idealmente, se prevedi di sostituire il simbolo di pallino standard con un'immagine, è meglio scegliere una grafica semplice con sfondo trasparente. Tali immagini funzionano bene come simboli di pallino personalizzati.

Tieni presente che l'immagine verrà scalata a una dimensione molto piccola. Per questo motivo, consigliamo vivamente di selezionare un'immagine che rimanga chiara ed efficace visivamente quando viene usata come pallino in un elenco.
{{% /alert %}}

Per creare un pallino immagine, aggiungi un'immagine a [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) con `Presentation.getImages().addImage` e assegna l'oggetto [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) restituito a `BulletFormat.getPicture().setImage`. Imposta `BulletFormat.setType` su [BulletType.Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bullettype/) prima di assegnare l'immagine.

Supponiamo di avere un file "image.png":

![Un'immagine per i pallini](picture_for_bullets.png)

Il seguente codice JavaScript mostra come creare pallini immagine in una diapositiva:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Il risultato:

![I pallini immagine](picture_bullets.png)

## **Creare un Elenco Multilivello**

Usa `ParagraphFormat.setDepth` per posizionare gli elementi dell'elenco a livelli diversi. Il livello 0 è quello superiore, il livello 1 è nidificato sotto di esso, e così via.

Il seguente codice JavaScript mostra come creare un elenco puntato multilivello:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'elenco multilivello](multilevel_list.png)

## **Modificare un Elenco Esistente**

Per modificare la formattazione di un elenco in una presentazione esistente, accedi al paragrafo di destinazione e aggiorna le sue impostazioni `ParagraphFormat.getBullet`. Le stesse proprietà usate per creare gli elenchi possono essere utilizzate per ispezionare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

Il seguente codice JavaScript modifica il primo paragrafo in un frame di testo per utilizzare uno stile di elenco numerato:

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**È possibile esportare elenchi puntati e numerati in PDF o immagini?**

Sì. Aspose.Slides conserva la formattazione degli elenchi quando il formato di destinazione supporta il layout del testo e le funzionalità dei pallini corrispondenti.

**Posso modificare gli elenchi in presentazioni esistenti?**

Sì. Carica la presentazione, accedi al paragrafo di destinazione, ispeziona o aggiorna le sue impostazioni `ParagraphFormat.getBullet` e salva la presentazione.

**Gli elenchi possono contenere testo non latino?**

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, quindi è possibile creare elenchi in presentazioni multilingue. Assicurati che i font usati nella presentazione supportino i caratteri di cui hai bisogno.