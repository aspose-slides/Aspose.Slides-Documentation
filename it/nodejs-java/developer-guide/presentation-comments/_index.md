---
title: Gestire i commenti della presentazione in Node.js
linktitle: Commenti della presentazione
type: docs
weight: 100
url: /it/nodejs-java/presentation-comments/
keywords:
- commento
- commento moderno
- commenti PowerPoint
- commenti della presentazione
- commenti della diapositiva
- aggiungi commento
- accedi al commento
- modifica commento
- rispondi al commento
- rimuovi commento
- elimina commento
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i commenti della presentazione con Aspose.Slides per Node.js tramite Java: aggiungi, leggi, modifica, rispondi e rimuovi i commenti nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti di presentazione con Aspose.Slides per Node.js tramite Java. Introduce i principali tipi correlati ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con le risposte e i commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi coprono scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il testo e i metadati del commento, creare catene di risposte e rimuovere commenti selezionati o tutti i commenti.

In PowerPoint, i commenti compaiono come annotazioni sulle diapositive. Selezionare un commento visualizza il suo testo e la discussione correlata.

## **Perché aggiungere commenti alle presentazioni?**

Puoi usare i commenti per fornire feedback e collaborare con i colleghi durante la revisione delle presentazioni.

Aspose.Slides per Node.js tramite Java offre le seguenti API per lavorare con i commenti:

* La classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) che fornisce l'accesso agli autori dei commenti della presentazione.
* La classe [CommentCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/commentcollection/) che rappresenta i commenti associati a un singolo autore.
* La classe [Comment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/comment/) che fornisce informazioni su un commento, inclusi autore, data di creazione, posizione e testo.
* La classe [CommentAuthor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/commentauthor/) che fornisce informazioni su un autore, inclusi nome, iniziali e commenti associati.

## **Aggiungere commenti alle diapositive**

L'esempio seguente mostra come aggiungere commenti alle diapositive in una presentazione PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accedere ai commenti delle diapositive**

L'esempio seguente mostra come accedere ai commenti esistenti in una presentazione PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Rispondere ai commenti**

Un commento principale è il commento originale in cima a una gerarchia di risposte. I metodi [Comment.getParentComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/comment/getparentcomment/) e [Comment.setParentComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/comment/setparentcomment/) consentono di ottenere o impostare il commento genitore.

L'esempio seguente mostra come aggiungere risposte e ispezionare la gerarchia di commenti risultante:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}

* Quando si utilizza il metodo [Comment.remove](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/comment/remove/) per eliminare un commento, vengono eliminati anche tutte le risposte a quel commento.
* Se [Comment.setParentComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/comment/setparentcomment/) crea un riferimento circolare, viene generata una [PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxeditexception/).

{{% /alert %}}

## **Aggiungere commenti moderni**

I commenti moderni possono essere associati alla diapositiva stessa, a una forma specifica o a un intervallo di testo all'interno di un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/). Il metodo [CommentCollection.addModernComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) accetta un argomento [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) oltre alla diapositiva e alle coordinate del marcatore del commento.

Quando si passa `null` per l'argomento shape, il commento è un commento a livello di diapositiva. Il suo marcatore è posizionato dalle coordinate fornite, ma non è associato a una forma specifica, quindi [ModernComment.getShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/getshape/) restituisce `null`. Quando viene fornita una [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/), il commento è ancorato a quella forma. Le coordinate continuano a definire la posizione del marcatore del commento sulla diapositiva, mentre l'associazione alla forma può essere recuperata tramite [ModernComment.getShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Ancorare un commento moderno a una forma**

L'esempio seguente crea sia un commento moderno a livello di diapositiva sia un commento moderno ancorato a un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/). Successivamente legge la forma associata a ciascun commento.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancorare commenti a diversi tipi di forma**

Qualsiasi oggetto diapositiva derivato da [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) può essere usato come ancoraggio. Esempi comuni includono [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/connector/) e istanze di [GraphicalObject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/graphicalobject/) come i grafici.

L'esempio seguente crea diversi tipi di forma comuni e associa a ciascuno un commento moderno.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ancorare un commento a un testo e impostarne lo stato**

Per un commento moderno associato a un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/), i metodi [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) e [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) consentono di accedere alla posizione iniziale del testo selezionato nel riquadro di testo della forma. I metodi [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) e [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) accedono alla lunghezza della selezione. Insieme, questi valori associano il commento a uno specifico intervallo di testo all'interno dell'[AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).

I metodi [ModernComment.getStatus](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/getstatus/) e [ModernComment.setStatus](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/setstatus/) accedono a un valore dell'enumerazione [ModernCommentStatus](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — nessuno stato specifico del commento moderno è definito.
- `Active` — il commento è attivo.
- `Resolved` — il commento è stato risolto.
- `Closed` — il commento è chiuso.

L'esempio seguente crea un commento moderno ancorato a una forma, lo associa a una selezione di testo, lo segna come risolto, salva la presentazione e verifica i valori dopo aver riaperto il file.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Ispezionare i commenti moderni esistenti**

Per ispezionare una presentazione esistente, verifica quali commenti sono istanze di [ModernComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/), quindi esamina [ModernComment.getShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) e [ModernComment.getStatus](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/getstatus/). Una forma `null` indica un commento a livello di diapositiva. Per un ancoraggio a [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/), i metodi di selezione del testo identificano l'intervallo associato nel riquadro di testo della forma.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Rimuovere i commenti**

### **Rimuovere tutti i commenti e gli autori dei commenti**

L'esempio seguente mostra come rimuovere tutti i commenti e gli autori dei commenti da una presentazione:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Rimuovere commenti specifici**

L'esempio seguente mostra come rimuovere commenti specifici da una diapositiva:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides supporta uno stato risolto per i commenti moderni?**

Sì. I metodi [ModernComment.getStatus](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/getstatus/) e [ModernComment.setStatus](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/setstatus/) accedono a un valore di [ModernCommentStatus](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncommentstatus/), incluso `Resolved`. Lo stato è memorizzato nella presentazione e può essere letto nuovamente dopo la riapertura del file.

**Le discussioni sequenziali (catene di risposte) sono supportate e c'è un limite di annidamento?**

Sì. Ogni commento può fare riferimento al suo [parent comment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/comment/getparentcomment/), consentendo catene di risposte. L'API non definisce un limite specifico di profondità di annidamento.

**In quale sistema di coordinate è definita la posizione del marcatore di un commento su una diapositiva?**

La posizione del marcatore è definita da coordinate a virgola mobile nel sistema di coordinate della diapositiva, consentendo di posizionarlo con precisione sulla diapositiva.