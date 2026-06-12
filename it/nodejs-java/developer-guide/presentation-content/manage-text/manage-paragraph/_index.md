---
title: Gestire i paragrafi di testo PowerPoint in JavaScript
linktitle: Gestisci Paragrafo
type: docs
weight: 40
url: /it/nodejs-java/manage-paragraph/
keywords:
- aggiungere testo
- aggiungere paragrafo
- gestire testo
- gestire paragrafo
- gestire elenco puntato
- indentazione del paragrafo
- indentazione sospesa
- elenco puntato del paragrafo
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
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Domina la formattazione dei paragrafi con Aspose.Slides per Node.js tramite Java - ottimizza allineamento, spaziatura e stile nelle presentazioni PPT, PPTX e ODP in JavaScript."
---
## **Introduzione**

Aspose.Slides fornisce tutte le classi necessarie per lavorare con i testi, i paragrafi e le porzioni di PowerPoint in Java.

* Aspose.Slides fornisce la classe [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) per consentire di aggiungere oggetti che rappresentano un paragrafo. Un oggetto `TextFame` può contenere uno o più paragrafi (ogni paragrafo è creato tramite un ritorno a capo).
* Aspose.Slides fornisce la classe [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) per consentire di aggiungere oggetti che rappresentano porzioni. Un oggetto `Paragraph` può contenere una o più porzioni (collezione di oggetti porzione di testo).
* Aspose.Slides fornisce la classe [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) per consentire di aggiungere oggetti che rappresentano testi e le loro proprietà di formattazione.

Un oggetto `Paragraph` è in grado di gestire testi con diverse proprietà di formattazione tramite i relativi oggetti `Portion`.

## **Aggiungere più paragrafi contenenti più porzioni**

Questi passaggi mostrano come aggiungere un frame di testo contenente 3 paragrafi e ciascun paragrafo contenente 3 porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una forma rettangolare [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
4. Ottieni l'ITextFrame associato al [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).
5. Crea due oggetti [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) e aggiungili alla collezione `IParagraphs` del [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/).
6. Crea tre oggetti [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) per ogni nuovo `Paragraph` (due oggetti Portion per il Paragraph predefinito) e aggiungi ogni oggetto `Portion` alla collezione IPortion di ciascun `Paragraph`.
7. Imposta del testo per ogni porzione.
8. Applica le caratteristiche di formattazione desiderate a ogni porzione utilizzando le proprietà di formattazione esposte dall'oggetto `Portion`.
9. Salva la presentazione modificata.

```javascript
// Istanziare una classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accesso alla prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiungere un AutoShape di tipo Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Accedere al TextFrame dell'AutoShape
    var tf = ashp.getTextFrame();
    // Creare Paragraphs e Portions con formati di testo diversi
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Scrivere il PPTX su disco
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestire i punti elenco dei paragrafi**

Le elenchi puntati ti aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I paragrafi puntati sono sempre più facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva selezionata.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo utilizzando la classe [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/).
7. Imposta il `Type` del bullet per il paragrafo su `Symbol` e definisci il carattere del bullet.
8. Imposta il `Text` del paragrafo.
9. Imposta l'`Indent` del paragrafo per il bullet.
10. Imposta un colore per il bullet.
11. Imposta un'altezza per il bullet.
12. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
13. Aggiungi il secondo paragrafo e ripeti il processo descritto nei passaggi da 7 a 13.
14. Salva la presentazione.

```javascript
// Istanzia una classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiunge e accede all'AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al TextFrame dell'AutoShape
    var txtFrm = aShp.getTextFrame();
    // Rimuove il paragrafo predefinito
    txtFrm.getParagraphs().removeAt(0);
    // Crea un paragrafo
    var para = new aspose.slides.Paragraph();
    // Imposta lo stile del bullet del paragrafo e il simbolo
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Imposta il testo del paragrafo
    para.setText("Welcome to Aspose.Slides");
    // Imposta l'indentazione del bullet
    para.getParagraphFormat().setIndent(25);
    // Imposta il colore del bullet
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// imposta IsBulletHardColor su true per utilizzare un colore bullet personalizzato
    // Imposta l'altezza del bullet
    para.getParagraphFormat().getBullet().setHeight(100);
    // Aggiunge il paragrafo al TextFrame
    txtFrm.getParagraphs().add(para);
    // Crea il secondo paragrafo
    var para2 = new aspose.slides.Paragraph();
    // Imposta il tipo e lo stile del bullet del paragrafo
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Aggiunge il testo al paragrafo
    para2.setText("This is numbered bullet");
    // Imposta l'indentazione del bullet
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// imposta IsBulletHardColor su true per utilizzare un colore bullet personalizzato
    // Imposta l'altezza del bullet
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Aggiunge il paragrafo al TextFrame
    txtFrm.getParagraphs().add(para2);
    // Salva la presentazione modificata
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestire i bullet con immagine**

Le elenchi puntati ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I paragrafi con immagine sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo utilizzando la classe [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/).
7. Carica l'immagine in [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/).
8. Imposta il tipo di bullet a [Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) e imposta l'immagine.
9. Imposta il `Text` del Paragraph.
10. Imposta l'`Indent` del Paragraph per il bullet.
11. Imposta un colore per il bullet.
12. Imposta un'altezza per il bullet.
13. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
14. Aggiungi il secondo paragrafo e ripeti il processo basato sui passaggi precedenti.
15. Salva la presentazione modificata.

```javascript
// Instanzia una classe Presentation che rappresenta un file PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var slide = presentation.getSlides().get_Item(0);
    // Instanzia l'immagine per i bullet
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Aggiunge e accede all'AutoShape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al TextFrame dell'AutoShape
    var textFrame = autoShape.getTextFrame();
    // Rimuove il paragrafo predefinito
    textFrame.getParagraphs().removeAt(0);
    // Crea un nuovo paragrafo
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Imposta lo stile del bullet del paragrafo e l'immagine
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Imposta l'altezza del bullet
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Aggiunge il paragrafo al TextFrame
    textFrame.getParagraphs().add(paragraph);
    // Scrive la presentazione come file PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Scrive la presentazione come file PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Gestire i bullet a più livelli**

Le elenchi puntati ti aiutano a organizzare e presentare le informazioni rapidamente ed efficientemente. I bullet a più livelli sono facili da leggere e comprendere.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) nella nuova diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) e imposta la profondità a 0.
7. Crea la seconda istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 1.
8. Crea la terza istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 2.
9. Crea la quarta istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 3.
10. Aggiungi i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
11. Salva la presentazione modificata.

```javascript
// Istanzia una classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiunge e accede all'AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al TextFrame dell'AutoShape creata
    var text = aShp.addTextFrame("");
    // Cancella il paragrafo predefinito
    text.getParagraphs().clear();
    // Aggiunge il primo paragrafo
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Imposta il livello del bullet
    para1.getParagraphFormat().setDepth(0);
    // Aggiunge il secondo paragrafo
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Imposta il livello del bullet
    para2.getParagraphFormat().setDepth(1);
    // Aggiunge il terzo paragrafo
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Imposta il livello del bullet
    para3.getParagraphFormat().setDepth(2);
    // Aggiunge il quarto paragrafo
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Imposta il livello del bullet
    para4.getParagraphFormat().setDepth(3);
    // Aggiunge i paragrafi alla collezione
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Scrive la presentazione come file PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestire il paragrafo con elenco numerato personalizzato**

La classe [BulletFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/) fornisce la proprietà [NumberedBulletStartWith](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) e altre che consentono di gestire i paragrafi con numerazione o formattazione personalizzata.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla diapositiva che contiene il paragrafo.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) dell'autoshape.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/) e imposta [NumberedBulletStartWith](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) a 2.
7. Crea la seconda istanza di paragrafo tramite la classe `Paragraph` e imposta `NumberedBulletStartWith` a 3.
8. Crea la terza istanza di paragrafo tramite la classe `Paragraph` e imposta `NumberedBulletStartWith` a 7.
9. Aggiungi i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
10. Salva la presentazione modificata.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accede al TextFrame dell'AutoShape creata
    var textFrame = shape.getTextFrame();
    // Rimuove il paragrafo predefinito esistente
    textFrame.getParagraphs().removeAt(0);
    // Prima lista
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Impostare l'indentazione della prima riga per un paragrafo**

Utilizza il metodo [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per controllare l'indentazione della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga a destra, mentre le righe successive rimangono allineate al corpo del paragrafo.

Usa [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) quando è necessario spostare l'intero paragrafo. Usa [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori di indentazione differenti per dimostrare come l'indentazione della prima riga influisca sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi un [AutoShape] rettangolare alla diapositiva.
4. Aggiungi un [TextFrame] vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [Indent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per ciascuno.
6. Aggiungi i paragrafi al frame di testo.
7. Salva la presentazione modificata.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![L'indentazione della prima riga dei paragrafi](first_line_indent.png)

## **Impostare l'indentazione sospesa per un paragrafo**

Un'indentazione sospesa è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe rimanenti. In Aspose.Slides, crei questo effetto con il metodo [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/). Imposta l'indentazione a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) definisce la posizione sinistra del corpo del paragrafo, e [ParagraphFormat.setIndent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un'indentazione sospesa, imposta un valore positivo di `MarginLeft` e un valore negativo di `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossari e altri paragrafi in cui le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla diapositiva target.
3. Aggiungi un [AutoShape] rettangolare alla diapositiva.
4. Aggiungi un [TextFrame] vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e imposta un valore positivo di [MarginLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) per ciascun paragrafo.
6. Imposta un valore negativo di [Indent](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setindent/) per creare l'effetto di indentazione sospesa.
7. Aggiungi i paragrafi al frame di testo.
8. Salva la presentazione modificata.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![L'indentazione sospesa dei paragrafi](hanging_indent.png)

## **Gestire le proprietà di esecuzione finale del paragrafo**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Ottieni il riferimento della diapositiva contenente il paragrafo tramite la sua posizione.
3. Aggiungi un [AutoShape] rettangolare alla diapositiva.
4. Aggiungi un [TextFrame] con due paragrafi al rettangolo.
5. Imposta `FontHeight` e il tipo di Font per i paragrafi.
6. Imposta le proprietà End per i paragrafi.
7. Scrivi la presentazione modificata come file PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Importare testo HTML nei paragrafi**

Aspose.Slides fornisce un supporto avanzato per l'importazione di testo HTML nei paragrafi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) alla diapositiva.
4. Aggiungi e accedi al [TextFrame] dell'`AutoShape`.
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Leggi il file HTML sorgente in un TextReader.
7. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/).
8. Aggiungi il contenuto del file HTML letto dal TextReader al [ParagraphCollection] del TextFrame.
9. Salva la presentazione modificata.

```javascript
// Crea un'istanza di presentazione vuota
var pres = new aspose.slides.Presentation();
try {
    // Accede alla diapositiva predefinita iniziale della presentazione
    var slide = pres.getSlides().get_Item(0);
    // Aggiunge l'AutoShape per contenere il contenuto HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Aggiunge il TextFrame alla forma
    ashape.addTextFrame("");
    // Cancella tutti i paragrafi nel TextFrame aggiunto
    ashape.getTextFrame().getParagraphs().clear();
    // Carica il file HTML usando lo StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Aggiunge il testo dallo StreamReader HTML nel TextFrame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Salva la presentazione
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Esportare il testo dei paragrafi in HTML**

Aspose.Slides fornisce un supporto avanzato per esportare i testi (contenuti nei paragrafi) in HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e carica la presentazione desiderata.
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Accedi alla forma contenente il testo che sarà esportato in HTML.
4. Accedi al [TextFrame] della forma.
5. Crea un'istanza di `StreamWriter` e aggiungi il nuovo file HTML.
6. Fornisci un indice di partenza a StreamWriter ed esporta i paragrafi desiderati.

```javascript
// Carica il file di presentazione
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Accede alla prima diapositiva predefinita della presentazione
    var slide = pres.getSlides().get_Item(0);
    // Indice desiderato
    var index = 0;
    // Accede alla forma aggiunta
    var ashape = slide.getShapes().get_Item(index);
    // Crea il file HTML di output
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Estrae il primo paragrafo come HTML
    // Scrive i dati dei paragrafi in HTML fornendo l'indice di partenza del paragrafo e il numero totale di paragrafi da copiare
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Salvare un paragrafo come immagine**

In questa sezione, esploreremo due esempi che dimostrano come salvare un paragrafo di testo, rappresentato dalla classe [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/), come immagine. Entrambi gli esempi includono l'ottenimento dell'immagine di una forma contenente il paragrafo tramite i metodi `getImage` della classe [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/), il calcolo dei limiti del paragrafo all'interno della forma e l'esportazione come immagine bitmap. Questi approcci consentono di estrarre parti specifiche del testo da presentazioni PowerPoint e salvarle come immagini separate, utile in vari scenari.

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, dove la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

**Esempio 1**

In questo esempio, otteniamo il secondo paragrafo come immagine. Per farlo, estraiamo l'immagine della forma dalla prima diapositiva della presentazione e quindi calcoliamo i limiti del secondo paragrafo nel frame di testo della forma. Il paragrafo viene quindi ridisegnato su una nuova immagine bitmap, salvata in formato PNG. Questo metodo è particolarmente utile quando è necessario salvare un paragrafo specifico come immagine separata mantenendo dimensioni e formattazione esatte del testo.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salva la forma in memoria come bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Crea un bitmap della forma dalla memoria.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Calcola i confini del secondo paragrafo.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Ritaglia il bitmap della forma per ottenere solo il bitmap del paragrafo.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

![L'immagine del paragrafo](paragraph_to_image_output.png)

**Esempio 2**

In questo esempio, estendiamo l'approccio precedente aggiungendo fattori di scala all'immagine del paragrafo. La forma viene estratta dalla presentazione e salvata come immagine con un fattore di scala di `2`. Ciò consente un'output a risoluzione più alta quando si esporta il paragrafo. I limiti del paragrafo vengono poi calcolati tenendo conto della scala. La scalatura può essere particolarmente utile quando è necessaria un'immagine più dettagliata, ad esempio per l'uso in materiali stampati di alta qualità.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Salva la forma in memoria come bitmap con ridimensionamento.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Crea un bitmap della forma dalla memoria.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Calcola i confini del secondo paragrafo.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Calcola le coordinate e le dimensioni per l'immagine di output (dimensione minima - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Ritaglia il bitmap della forma per ottenere solo il bitmap del paragrafo.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Domande frequenti**

**Posso disabilitare completamente l'andatura del testo all'interno di un TextFrame?**

Sì. Usa l'impostazione di avvolgimento del TextFrame ([setWrapText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/setwraptext/)) per disattivare l'avvolgimento in modo che le linee non si interrompano ai bordi del frame.

**Come posso ottenere le coordinate esatte sullo slide di un paragrafo specifico?**

Puoi recuperare il rettangolo di delimitazione del paragrafo (e anche di una singola porzione) per conoscere la sua posizione e dimensione precise sulla diapositiva.

**Dove è controllato l'allineamento del paragrafo (sinistra/destra/centrato/giustificato)?**

[setAlignment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/setalignment/) è un metodo di impostazione a livello di paragrafo in [ParagraphFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/); si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare una lingua di correzione ortografica solo per una parte di un paragrafo (ad esempio, una parola)?**

Sì. La lingua è impostata a livello di porzione ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), quindi più lingue possono coesistere all'interno di un unico paragrafo.