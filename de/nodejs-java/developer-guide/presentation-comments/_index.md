---
title: Präsentationskommentare
type: docs
weight: 100
url: /de/nodejs-java/presentation-comments/
keywords: "Kommentare, PowerPoint-Kommentare, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "Kommentare und Antworten in PowerPoint-Präsentation in JavaScript hinzufügen"
---

In PowerPoint erscheint ein Kommentar als Notiz oder Anmerkung auf einer Folie. Wenn ein Kommentar angeklickt wird, werden dessen Inhalt oder Nachrichten angezeigt. 

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen beim Überprüfen von Präsentationen zu kommunizieren.

Um Ihnen die Verwendung von Kommentaren in PowerPoint‑Präsentationen zu ermöglichen, bietet Aspose.Slides for Node.js via Java

* Die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Klasse, die die Sammlungen von Autoren (aus der [CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection)-Klasse) enthält. Die Autoren fügen Folien Kommentare hinzu.
* Die [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection)-Klasse, die die Sammlung von Kommentaren für einzelne Autoren enthält.
* Die [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)-Klasse, die Informationen zu Autoren und deren Kommentaren enthält: wer den Kommentar hinzugefügt hat, wann der Kommentar hinzugefügt wurde, die Position des Kommentars usw.
* Die [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor)-Klasse, die Informationen zu einzelnen Autoren enthält: Name des Autors, seine Initialen, dem Autor zugeordnete Kommentare usw.

## **Folienkommentar hinzufügen**
Dieses JavaScript‑Beispiel zeigt, wie Sie einer Folie in einer PowerPoint‑Präsentation einen Kommentar hinzufügen:
```javascript
// Instanziiert die Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Fügt eine leere Folie hinzu
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Fügt einen Autor hinzu
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Setzt die Position für Kommentare
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Fügt einen Folienkommentar für einen Autor auf Folie 1 hinzu
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Fügt einen Folienkommentar für einen Autor auf Folie 2 hinzu
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Greift auf ISlide 1 zu
    var slide = pres.getSlides().get_Item(0);
    // Wenn null als Argument übergeben wird, werden Kommentare aller Autoren zur ausgewählten Folie gebracht
    var Comments = slide.getSlideComments(author);
    // Greift auf den Kommentar an Index 0 für Folie 1 zu
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Wählt die Kommentarensammlung des Autors an Index 0 aus
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Folienkommentare abrufen**
Dieses JavaScript‑Beispiel zeigt, wie Sie auf einen vorhandenen Kommentar einer Folie in einer PowerPoint‑Präsentation zugreifen:
```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Kommentarantworten**
Ein übergeordneter Kommentar ist der oberste bzw. ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit den Methoden [getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) bzw. [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (aus der [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)-Klasse) können Sie einen übergeordneten Kommentar setzen oder abrufen.

Dieses JavaScript‑Beispiel zeigt, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Fügt einen Kommentar hinzu
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Fügt eine Antwort zu Kommentar 1 hinzu
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Fügt eine weitere Antwort zu Kommentar 1 hinzu
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Fügt eine Antwort zu einer bestehenden Antwort hinzu
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Zeigt die Kommentarhierarchie in der Konsole an
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Entfernt Kommentar 1 und alle dazugehörigen Antworten
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" title="Attention" %}} 

* Wenn die [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--)‑Methode (aus der [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)-Klasse) zum Löschen eines Kommentars verwendet wird, werden auch die Antworten auf diesen Kommentar gelöscht.
* Führt das Setzen von [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) zu einer zirkulären Referenz, wird eine [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

## **Modernen Kommentar hinzufügen**

Im Jahr 2021 führte Microsoft *moderne Kommentare* in PowerPoint ein. Die Funktion moderner Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint‑Benutzer Kommentare auflösen, Kommentare an Objekten und Texten verankern und viel einfacher interagieren als zuvor. 

In [Aspose.Slides for Node.js via Java 21.11](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-11-release-notes/) haben wir die Unterstützung für moderne Kommentare implementiert, indem wir die [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment)-Klasse hinzugefügt haben. Die Methoden [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) und [insertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) wurden zur [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection)-Klasse hinzugefügt.

Dieses JavaScript‑Beispiel zeigt, wie Sie einer Folie in einer PowerPoint‑Präsentation einen modernen Kommentar hinzufügen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Kommentar entfernen**

### **Alle Kommentare und Autoren löschen**

Dieses JavaScript‑Beispiel zeigt, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Löscht alle Kommentare aus der Präsentation
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Löscht alle Autoren
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **Spezifische Kommentare löschen**

Dieses JavaScript‑Beispiel zeigt, wie Sie bestimmte Kommentare auf einer Folie löschen:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Kommentare hinzufügen...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // Entfernt alle Kommentare, die den Text "comment 1" enthalten
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Unterstützt Aspose.Slides einen Status wie "gelöst" für moderne Kommentare?**

Ja. [Modern comments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) bieten die Methoden [getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) und [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setStatus/); Sie können den [Zustand eines Kommentars](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) lesen und setzen (z. B. ihn als gelöst markieren). Dieser Zustand wird in der Datei gespeichert und von PowerPoint erkannt.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es ein Nesting‑Limit?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) verweisen, wodurch beliebig tiefe Antwortketten ermöglicht werden. Die API definiert kein konkretes Verschachtelungstiefe‑Limit.

**In welchem Koordinatensystem ist die Position eines Kommentarmarkers auf einer Folie definiert?**

Die Position wird als Gleitkommapunkt im Koordinatensystem der Folie gespeichert. Dadurch können Sie den Kommentarmarker exakt dort platzieren, wo Sie ihn benötigen.