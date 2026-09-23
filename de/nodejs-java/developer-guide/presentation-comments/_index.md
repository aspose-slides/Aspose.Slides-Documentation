---
title: "Verwalten von Präsentationskommentaren in Node.js"
linktitle: "Präsentationskommentare"
type: docs
weight: 100
url: /de/nodejs-java/presentation-comments/
keywords:
- Kommentar
- Moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar bearbeiten
- Kommentar antworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten von Präsentationskommentaren mit Aspose.Slides für Node.js via Java: Hinzufügen, Lesen, Bearbeiten, Antworten und Entfernen von Kommentaren in PowerPoint-Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationskommentare mit Aspose.Slides für Node.js via Java verwalten. Er stellt die wichtigsten kommentarbezogenen Typen vor und demonstriert, wie Kommentare zu Folien hinzugefügt, vorhandene Kommentare abgerufen, mit Antworten und modernen Kommentaren gearbeitet und Kommentare aus einer Präsentation entfernt werden.

Die Beispiele decken gängige Überprüfungs‑ und Kollaborationsszenarien in PowerPoint ab, z. B. das Zuweisen von Kommentaren zu Autoren, das Lesen von Kommentart ext und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

Um zu verlangen, dass Kommentare beim Öffnen einer Präsentation angezeigt oder ausgeblendet werden, ohne die Kommentare selbst zu ändern, siehe [Kommentare beim Öffnen einer Präsentation ein- oder ausblenden](/slides/de/nodejs-java/presentation-view-properties/).

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen zusammenzuarbeiten, wenn Sie Präsentationen prüfen.

Aspose.Slides für Node.js via Java bietet die folgenden APIs für die Arbeit mit Kommentaren:

* Die [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse, die Zugriff auf die Kommentarautoren der Präsentation bietet.
* Die [CommentCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commentcollection/)‑Klasse, die die Kommentare eines einzelnen Autors darstellt.
* Die [Comment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/)‑Klasse, die Informationen zu einem Kommentar enthält, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commentauthor/)‑Klasse, die Informationen zu einem Autor enthält, einschließlich Name, Initialen und zugehörigen Kommentaren.

## **Folienkommentare hinzufügen**

Das folgende Beispiel zeigt, wie Kommentare zu Folien in einer PowerPoint‑Präsentation hinzugefügt werden:

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

Das folgende Beispiel zeigt, wie vorhandene Kommentare in einer PowerPoint‑Präsentation abgerufen werden:

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

Ein übergeordneter Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antworthierarchie. Die Methoden [Comment.getParentComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/getparentcomment/) und [Comment.setParentComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/setparentcomment/) ermöglichen das Abrufen bzw. Festlegen des übergeordneten Kommentars.

Das folgende Beispiel zeigt, wie Antworten hinzugefügt und die resultierende Kommentarhierarchie untersucht werden:

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
* Wenn die Methode [Comment.remove](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/remove/) verwendet wird, um einen Kommentar zu löschen, werden auch alle Antworten auf diesen Kommentar gelöscht.
* Wenn [Comment.setParentComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/setparentcomment/) eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) zugeordnet werden. Die Methode [CommentCollection.addModernComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) akzeptiert ein [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/)-Argument zusätzlich zu Folie und Koordinaten des Kommentarmarkers.

Wird `null` für das Shape‑Argument übergeben, ist der Kommentar ein Folien‑Kommentar. Sein Marker wird anhand der angegebenen Koordinaten positioniert, ist jedoch keiner bestimmten Form zugeordnet, so dass [ModernComment.getShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getshape/) `null` zurückgibt. Wird ein [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/) übergeben, wird der Kommentar an diese Form verankert. Die Koordinaten bestimmen weiterhin die Position des Kommentarmarkers auf der Folie, während die Formzuordnung über [ModernComment.getShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getshape/) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das folgende Beispiel erstellt sowohl einen Folien‑Kommentar als auch einen modernen Kommentar, der an einer bestimmten [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) verankert ist. Anschließend wird die zugehörige Form jedes Kommentars ausgelesen.

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

Jedes Folienobjekt, das von [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/) abgeleitet ist, kann als Anker verwendet werden. Häufige Beispiele sind [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/connector/) und [GraphicalObject](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/graphicalobject/)-Instanzen wie Diagramme.

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

### **Einen Kommentar an Text verankern und seinen Status festlegen**

Für einen modernen Kommentar, der einer [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) zugeordnet ist, greifen [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) und [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) auf die Startposition des ausgewählten Textes im Textfeld der Form zu. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) und [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) geben die Länge der Auswahl zurück. Zusammen verknüpfen diese Werte den Kommentar mit einem bestimmten Textbereich innerhalb der [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/).

Die Methoden [ModernComment.getStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getstatus/) und [ModernComment.setStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/setstatus/) greifen auf einen Wert der Aufzählung [ModernCommentStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncommentstatus/) zu:

- `NotDefined` — kein spezifischer moderner Kommentarstatus ist definiert.
- `Active` — der Kommentar ist aktiv.
- `Resolved` — der Kommentar wurde gelöst.
- `Closed` — der Kommentar ist geschlossen.

Das folgende Beispiel erstellt einen an einer Form verankerten modernen Kommentar, verknüpft ihn mit einer Textauswahl, markiert ihn als gelöst, speichert die Präsentation und überprüft die Werte nach dem erneuten Öffnen der Datei.

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

### **Vorhandene moderne Kommentare untersuchen**

Um eine vorhandene Präsentation zu untersuchen, prüfen Sie, welche Kommentare [ModernComment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/)-Instanzen sind, und betrachten Sie dann [ModernComment.getShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) sowie [ModernComment.getStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getstatus/). Ein `null`‑Shape weist auf einen Folien‑Kommentar hin. Für einen Anker einer [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) geben die Textauswahl‑Methoden den zugehörigen Bereich im Textfeld der Form an.

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

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/getstatus/) und [ModernComment.setStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncomment/setstatus/) greifen auf einen [ModernCommentStatus](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/moderncommentstatus/)-Wert zu, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach dem erneuten Öffnen der Datei wieder ausgelesen werden.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es ein Begrenzung der Verschachtelungstiefe?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/comment/getparentcomment/) verweisen, wodurch Antwortketten ermöglicht werden. Die API definiert keine spezifische Begrenzung der Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentarmarkers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie sie präzise auf der Folie platzieren können.