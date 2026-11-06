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
- Kommentarantwort
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für Node.js via Java: Kommentare in PowerPoint-Präsentationen hinzufügen, lesen, bearbeiten, darauf antworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationskommentare mit Aspose.Slides für Node.js via Java verwaltet. Er führt die wichtigsten kommentarbezogenen Typen ein und zeigt, wie man Kommentare zu Folien hinzufügt, vorhandene Kommentare abruft, mit Antworten und modernen Kommentaren arbeitet und Kommentare aus einer Präsentation entfernt.

Die Beispiele decken gängige Prüfungs- und Zusammenarbeitsszenarien in PowerPoint ab, wie das Zuweisen von Kommentaren zu Autoren, das Lesen von Kommentartexten und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint werden Kommentare als Anmerkungen auf Folien angezeigt. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

Um zu verlangen, dass Kommentare beim Öffnen einer Präsentation angezeigt oder ausgeblendet werden, ohne die Kommentare selbst zu ändern, siehe [Kommentare beim Öffnen einer Präsentation anzeigen oder ausblenden](/slides/de/nodejs-java/presentation-view-properties/).

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen bei der Durchsicht von Präsentationen zusammenzuarbeiten.

Aspose.Slides für Node.js via Java bietet die folgenden APIs zur Arbeit mit Kommentaren:

* Die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse, die Zugriff auf die Kommentarautoren der Präsentation bietet.
* Die [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) Klasse, die die mit einem einzelnen Autor verbundenen Kommentare darstellt.
* Die [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) Klasse, die Informationen über einen Kommentar bereitstellt, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) Klasse, die Informationen über einen Autor bereitstellt, einschließlich Name, Initialen und zugehöriger Kommentare.

## **Folienkommentare hinzufügen**

Das Beispiel erstellt zwei Folien und registriert einen Kommentarautor mit [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). Es verwendet [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/), um auf jeder Folie einen Kommentar zu platzieren, und ruft dann die Kommentare der ersten Folie für diesen Autor mit [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) ab. Die Konsole gibt den Text des ersten Kommentars zweimal aus, was den Zugriff sowohl über die Folie als auch über den Autor demonstriert, und die gespeicherte Präsentation enthält beide Kommentare.

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Einen Kommentarautor finden oder erstellen**

Wenn eine automatisierte Überprüfung dieselbe Präsentation wiederholt verarbeitet, durchsuchen Sie die Sammlung, die von [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) zurückgegeben wird, bevor Sie einen Autor hinzufügen. [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) stimmt sowohl Name als auch Initialen überein und gibt ein Array von passenden Autoren zurück, oder ein leeres Array, wenn keine Übereinstimmungen existieren. Im Gegensatz dazu sucht [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) nur nach dem Namen, unabhängig von den Initialen. Das Aufrufen von [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) mit einem Namen und Initialen, die bereits in der Sammlung vorhanden sind, löst eine Ausnahme aus.

Das Beispiel erfordert eine Präsentationsdatei mit mindestens einer Folie. Bei jedem der beiden Durchläufe verwendet es den zuerst passenden Autor erneut oder erstellt einen neuen, nur wenn das Ergebnis leer ist. Gibt es mehrere Übereinstimmungen, wird das erste Array‑Element ausgewählt, ohne die anderen Autoren zu zusammenzuführen oder zu entfernen. Anschließend wird [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) für den ausgewählten Autor aufgerufen und die Präsentation gespeichert. Der zweite Durchlauf öffnet die Ausgabe des ersten Durchlaufs und wiederholt den Vorgang.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

Der zweite Durchlauf fügt einen weiteren Kommentar hinzu, ohne einen zusätzlichen Autor zu erstellen oder vorhandene Kommentare zu entfernen. Die endgültige Datei, `review_pass_2.pptx`, enthält beide neuen Kommentare zusammen mit allen ursprünglichen Kommentaren. Das Wiederverwenden eines Autors dedupliziert Kommentare nicht: Um zu vermeiden, dass derselbe Kommentar mehrfach hinzugefügt wird, sollte vor dem Hinzufügen eine separate Duplikaterkennung implementiert werden.

## **Folienkommentare abrufen**

Das Beispiel öffnet eine vorhandene Präsentation und liest die von [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) zurückgegebene Sammlung. Für jeden Autor iteriert es durch die von [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) zurückgegebene Sammlung und gibt Foliennummer, Kommentartext, Autorname und Erstellungszeit aus. Die Eingabedatei muss Kommentare enthalten, damit Konsolenausgaben erzeugt werden.

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

Ein übergeordneter Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antworthierarchie. Die Methoden [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) und [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) ermöglichen das Abrufen bzw. Festlegen des übergeordneten Kommentars.

Das Beispiel erstellt Kommentare von zwei Autoren und verwendet [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/), um Antworten zu erstellen, einschließlich einer Antwort auf eine andere Antwort. Das Übergeben von `null` an [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) ruft Kommentare aller Autoren ab; die Konsole rückt jeden Eintrag entsprechend seiner Tiefe in der Antworthierarchie ein. Das Beispiel speichert die gesamte Diskussion, ruft [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) für den ersten Stammkommentar auf und speichert eine zweite Präsentation, in der dieser Kommentar und seine Antworten entfernt wurden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Wenn die Methode [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) verwendet wird, um einen Kommentar zu löschen, werden alle Antworten auf diesen Kommentar ebenfalls gelöscht.
* Wenn [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können mit der Folie selbst, mit einer bestimmten Form oder mit einem Textbereich innerhalb einer AutoShape verknüpft werden. Die Methode [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) akzeptiert zusätzlich zu Folie und Kommentar-Markierungskoordinaten ein [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑Argument.

Wird für das Shape‑Argument `null` übergeben, ist der Kommentar ein Folien‑Kommentar. Sein Markierer wird durch die angegebenen Koordinaten positioniert, ist jedoch nicht einer bestimmten Form zugeordnet, sodass [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) `null` zurückliefert. Wird ein [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) angegeben, wird der Kommentar an dieser Form verankert. Die Koordinaten definieren weiterhin die Position des Kommentar‑Markierers auf der Folie, während die Formzuordnung über [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das Beispiel ruft [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) zweimal auf: einmal mit einer `null`‑Form für einen Folien‑Kommentar und einmal mit einem Rechteck als Anker. Das Lesen von [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) gibt `true` für den Null‑Check des Folien‑Kommentars und `Revenue title` für den verankerten Kommentar aus. Beide Kommentare werden zusammen mit der Präsentation gespeichert.

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

Jedes Folienobjekt, das von [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) abgeleitet ist, kann als Form‑Anker verwendet werden. Häufige Beispiele sind [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) und [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/)-Instanzen wie Diagramme.

Das Beispiel verwendet [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/), um einen Kommentar mit jedem der fünf Formtypen zu verknüpfen: einer AutoShape, einem PictureFrame, einer Gruppe, einem Connector und einem Diagramm. Das Bild verwendet eingebettete Bilddaten, sodass kein externes Bild erforderlich ist. Jeder Kommentar hat seine eigene Markierungsposition, und die gespeicherte Präsentation behält alle fünf Formzuordnungen bei.

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

Für einen modernen Kommentar, der mit einer [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) verknüpft ist, greifen [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) und [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) auf die Startposition des ausgewählten Textes im Textfeld der Form zu. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) und [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) geben die Länge der Auswahl zurück. Zusammen verknüpfen diese Werte den Kommentar mit einem bestimmten Textbereich innerhalb der AutoShape.

Die Methoden [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) und [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) greifen auf einen Wert aus der [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/)‑Aufzählung zu:
- `NotDefined` — kein spezifischer Modern‑Comment‑Status ist definiert.
- `Active` — der Kommentar ist aktiv.
- `Resolved` — der Kommentar wurde gelöst.
- `Closed` — der Kommentar ist geschlossen.

Das Beispiel verankert einen modernen Kommentar an den Worten „quarterly revenue“ im Text eines Rechtecks. Es berechnet den nullbasierten Auswahlstart aus dem Text und übergibt ihn an [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) und verwendet [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/), um die Anzahl der ausgewählten Zeichen festzulegen. Nach dem Aufrufen von [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) mit `Resolved` wird die Präsentation gespeichert und erneut geöffnet. Die vier Konsolenprüfungen sollten jeweils `true` ausgeben, was bestätigt, dass der Form‑Anker, der Textbereich und der Status erhalten wurden.

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

### **Vorhandene moderne Kommentare prüfen**

Das Beispiel erfordert eine vorhandene Präsentation, die moderne Kommentare enthält, und gibt deren Text, Status und Ankerdetails aus. Um sie zu prüfen, bestimmen Sie, welche Kommentare Instanzen von [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) sind, und untersuchen dann [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) und [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). Eine `null`‑Form weist auf einen Folien‑Kommentar hin. Für einen [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)‑Anker identifizieren die Textauswahl‑Methoden den zugehörigen Bereich im Textfeld der Form.

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

Aspose.Slides für Node.js via Java ermöglicht das Entfernen aller Kommentare und ihrer Autoren aus einer Präsentation oder das Löschen ausgewählter Kommentare bei Beibehaltung der übrigen. Die folgenden Beispiele demonstrieren beide Ansätze und speichern die aktualisierte Präsentation.

### **Alle Kommentare und Kommentarautoren entfernen**

Das Beispiel öffnet eine vorhandene Präsentation und ruft für jeden Autor [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) auf, anschließend wird [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) aufgerufen, um die Autoren selbst zu entfernen. Die gespeicherte Präsentation enthält weder Kommentare noch Kommentarautoren. Verwenden Sie eine Präsentation mit Kommentaren, um die Entfernung zu beobachten.

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

Das Beispiel erstellt zwei Kommentare auf einer Folie und verwendet [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/), um Kommentare jedes Autors zu finden. Es sammelt Kommentare, deren Text gleich „comment 1“ ist, bevor [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/) aufgerufen wird, um Änderungen an der Sammlung während der Auswahl zu vermeiden. Die gespeicherte Präsentation enthält nur „comment 2“.

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

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) und [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) greifen auf einen [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/)‑Wert zu, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach dem erneuten Öffnen der Datei wieder ausgelesen werden.

**Werden Thread‑Diskussionen (Antwortketten) unterstützt und gibt es ein Begrenzungsniveau?**

Ja. Jeder Kommentar kann auf seinen [übergeordneter Kommentar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) verweisen, wodurch Antwortketten ermöglicht werden. Die API definiert kein spezifisches Begrenzungsniveau für die Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie ihn präzise auf der Folie platzieren können.