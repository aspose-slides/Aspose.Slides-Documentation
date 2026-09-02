---
title: Präsentationskommentare in Node.js verwalten
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/nodejs-java/presentation-comments/
keywords:
- Kommentar
- moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar bearbeiten
- Antwort auf Kommentar
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für Node.js via Java: Kommentare in PowerPoint‑Präsentationen hinzufügen, lesen, bearbeiten, darauf antworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationskommentare mit Aspose.Slides für Node.js via Java verwaltet. Er stellt die wichtigsten kommentarbezogenen Typen vor und zeigt, wie man Kommentare zu Folien hinzufügt, vorhandene Kommentare abruft, mit Antworten und modernen Kommentaren arbeitet und Kommentare aus einer Präsentation entfernt.

Die Beispiele decken typische Überprüfungs‑ und Zusammenarbeitsszenarien in PowerPoint ab, wie das Zuordnen von Kommentaren zu Autoren, das Auslesen von Kommentartext und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen bei der Durchsicht von Präsentationen zusammenzuarbeiten.

Aspose.Slides für Node.js via Java stellt die folgenden APIs für die Arbeit mit Kommentaren bereit:

* Die [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse, die Zugriff auf die Kommentarautoren der Präsentation bietet.
* Die [CommentCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commentcollection/)‑Klasse, die die Kommentare eines einzelnen Autors repräsentiert.
* Die [Comment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/)‑Klasse, die Informationen zu einem Kommentar bereitstellt, einschließlich Autor, Erstellzeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commentauthor/)‑Klasse, die Informationen zu einem Autor liefert, einschließlich Name, Initialen und zugehörigen Kommentaren.

## **Folienkommentare hinzufügen**

Das folgende Beispiel zeigt, wie man Kommentare zu Folien in einer PowerPoint‑Präsentation hinzufügt:

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

## **Folienkommentare abrufen**

Das folgende Beispiel zeigt, wie man vorhandene Kommentare in einer PowerPoint‑Präsentation abruft:

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

## **Auf Kommentare antworten**

Ein Eltern‑Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antwort‑Hierarchie. Die [Comment.getParentComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/getparentcomment/)‑ und [Comment.setParentComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/setparentcomment/)‑Methoden ermöglichen das Abrufen bzw. Festlegen des Eltern‑Kommentars.

Das folgende Beispiel zeigt, wie man Antworten hinzufügt und die resultierende Kommentar‑Hierarchie inspiziert:

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
* Wird die [Comment.remove](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/remove/)‑Methode verwendet, um einen Kommentar zu löschen, werden auch alle Antworten auf diesen Kommentar gelöscht.
* Wenn [Comment.setParentComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/setparentcomment/) eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) zugeordnet werden. Die [CommentCollection.addModernComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commentcollection/addmoderncomment/)‑Methode akzeptiert ein [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/)‑Argument zusätzlich zu den Folien‑ und Kommentar‑Marker‑Koordinaten.

Wird `null` für das Shape‑Argument übergeben, ist der Kommentar ein Folien‑Kommentar. Sein Marker wird durch die angegebenen Koordinaten positioniert, ist jedoch keiner konkreten Form zugeordnet, sodass [ModernComment.getShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getshape/) `null` zurückgibt. Wird ein [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/) übergeben, wird der Kommentar an diese Form angeheftet. Die Koordinaten definieren weiterhin die Position des Kommentar‑Markers auf der Folie, während die Formzuordnung über [ModernComment.getShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getshape/) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das folgende Beispiel erstellt sowohl einen Folien‑Kommentar als auch einen modernen Kommentar, der an einer bestimmten [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) verankert ist. Anschließend wird die zugehörige Form aus jedem Kommentar ausgelesen.

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

### **Kommentare an verschiedenen Formtypen verankern**

Jedes Folienobjekt, das von [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/) abgeleitet ist, kann als Form‑Anker verwendet werden. Häufige Beispiele sind [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/connector/) und [GraphicalObject](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/graphicalobject/)-Instanzen wie Diagramme.

Das folgende Beispiel erstellt mehrere gängige Formtypen und ordnet jedem einen modernen Kommentar zu.

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

### **Einen Kommentar an Text verankern und den Status setzen**

Für einen modernen Kommentar, der einer [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) zugeordnet ist, greifen [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) und [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) auf die Startposition des ausgewählten Textes im Textfeld der Form zu. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) und [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) geben die Länge der Auswahl zurück. Zusammen verknüpfen diese Werte den Kommentar mit einem bestimmten Textbereich innerhalb der [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/).

Die Methoden [ModernComment.getStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getstatus/) und [ModernComment.setStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/setstatus/) greifen auf einen Wert aus der Aufzählung [ModernCommentStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncommentstatus/) zu:

- `NotDefined` — kein spezifischer moderner Kommentarstatus ist definiert.
- `Active` — der Kommentar ist aktiv.
- `Resolved` — der Kommentar wurde gelöst.
- `Closed` — der Kommentar ist geschlossen.

Das folgende Beispiel erstellt einen an einer Form verankerten modernen Kommentar, ordnet ihn einer Textauswahl zu, markiert ihn als gelöst, speichert die Präsentation und prüft die Werte nach erneutem Öffnen der Datei.

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

### **Vorhandene moderne Kommentare inspizieren**

Um eine vorhandene Präsentation zu untersuchen, prüfen Sie, welche Kommentare [ModernComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/)‑Instanzen sind, und betrachten Sie dann [ModernComment.getShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) sowie [ModernComment.getStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getstatus/). Ein `null`‑Shape weist auf einen Folien‑Kommentar hin. Für einen [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/)‑Anker identifizieren die Textauswahl‑Methoden den zugehörigen Bereich im Textfeld der Form.

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

## **Kommentare entfernen**

### **Alle Kommentare und Kommentarautoren entfernen**

Das folgende Beispiel zeigt, wie alle Kommentare und Kommentarautoren aus einer Präsentation entfernt werden:

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

### **Bestimmte Kommentare entfernen**

Das folgende Beispiel zeigt, wie bestimmte Kommentare von einer Folie entfernt werden:

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

**Unterstützt Aspose.Slides einen gelösten Status für moderne Kommentare?**

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getstatus/) und [ModernComment.setStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/setstatus/) greifen auf einen Wert der [ModernCommentStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncommentstatus/)-Aufzählung zu, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach erneutem Öffnen der Datei wieder ausgelesen werden.

**Werden Thread‑Diskussionen (Antwortketten) unterstützt und gibt es ein Verschachtelungs‑Limit?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/getparentcomment/) verweisen, wodurch Antwortketten ermöglicht werden. Die API definiert kein spezifisches Verschachtelungstiefen‑Limit.

**In welchem Koordinatensystem ist die Position des Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass sie präzise auf der Folie platziert werden kann.