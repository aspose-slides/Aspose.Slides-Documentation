---
title: Verwalten von Präsentationskommentaren auf Android
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/androidjava/presentation-comments/
keywords:
- kommentar
- moderner kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar lesen
- Kommentar bearbeiten
- Kommentar beantworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: Verwalten Sie Präsentationskommentare mit Aspose.Slides für Android via Java: Kommentare in PowerPoint-Dateien schnell und einfach hinzufügen, lesen, bearbeiten und löschen.
---

In PowerPoint erscheint ein Kommentar als Notiz oder Anmerkung auf einer Folie. Wenn ein Kommentar angeklickt wird, werden dessen Inhalt oder Nachrichten angezeigt. 

### **Warum Kommentare zu Präsentationen hinzufügen?**

Möglicherweise möchten Sie Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen zu kommunizieren, wenn Sie Präsentationen überprüfen.

Um Ihnen die Verwendung von Kommentaren in PowerPoint-Präsentationen zu ermöglichen, bietet Aspose.Slides für Android via Java

* Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse, die die Sammlungen von Autoren enthält (aus der [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection)-Schnittstelle). Die Autoren fügen Folien Kommentare hinzu.
* Die [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection)-Schnittstelle, die die Sammlung von Kommentaren für einzelne Autoren enthält.
* Die [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)-Klasse, die Informationen zu Autoren und deren Kommentaren enthält: wer den Kommentar hinzugefügt hat, wann der Kommentar hinzugefügt wurde, die Position des Kommentars usw.
* Die [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor)-Klasse, die Informationen zu einzelnen Autoren enthält: den Namen des Autors, seine Initialen, mit dem Namen des Autors verbundene Kommentare usw.

## **Einen Folienkommentar hinzufügen**
Dieser Java-Code zeigt, wie Sie einen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen:
```java
// Instanziert die Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Fügt eine leere Folie hinzu
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Fügt einen Autor hinzu
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Setzt die Position für Kommentare
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Fügt einen Folienkommentar für einen Autor auf Folie 1 hinzu
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Fügt einen Folienkommentar für einen Autor auf Folie 2 hinzu
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Greift auf ISlide 1 zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Wenn null als Argument übergeben wird, werden Kommentare aller Autoren zur ausgewählten Folie gebracht
    IComment[] Comments = slide.getSlideComments(author);

    // Greift auf den Kommentar an Index 0 für Folie 1 zu
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Wählt die Kommentar Sammlung des Autors an Index 0 aus
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Auf Folienkommentare zugreifen**
Dieser Java-Code zeigt, wie Sie auf einen vorhandenen Kommentar einer Folie in einer PowerPoint-Präsentation zugreifen:
```java
// Instanziert die Presentation-Klasse
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Antwortkommentare**

Ein Elternkommentar ist der oberste oder ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit den Methoden [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) oder [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (aus der [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)-Schnittstelle) können Sie einen Elternkommentar setzen oder abrufen.

Dieser Java-Code zeigt, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:
```java
Presentation pres = new Presentation();
try {
    // Fügt einen Kommentar hinzu
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Fügt eine Antwort zu Kommentar1 hinzu
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Fügt eine weitere Antwort zu Kommentar1 hinzu
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Fügt eine Antwort zu einer bestehenden Antwort hinzu
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Zeigt die Kommentarhierarchie in der Konsole an
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Entfernt Kommentar1 und alle dazugehörigen Antworten
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="Achtung" %}} 

* Wenn die Methode [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) (aus der [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment)-Schnittstelle) verwendet wird, um einen Kommentar zu löschen, werden auch die Antworten auf den Kommentar gelöscht.
* Führt die Einstellung [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) zu einer zirkulären Referenz, wird [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

## **Einen modernen Kommentar hinzufügen**

Im Jahr 2021 hat Microsoft *moderne Kommentare* in PowerPoint eingeführt. Die Funktion moderner Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint‑Benutzer Kommentare lösen, Kommentare an Objekten und Texten verankern und viel einfacher interagieren als zuvor. 

In [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/) haben wir die Unterstützung für moderne Kommentare implementiert, indem wir die [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment)-Klasse hinzugefügt haben. Die Methoden [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) und [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) wurden zur [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection)-Klasse hinzugefügt.

Dieser Java-Code zeigt, wie Sie einen modernen Kommentar zu einer Folie in einer PowerPoint‑Präsentation hinzufügen: 
```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Einen Kommentar entfernen**

### **Alle Kommentare und Autoren löschen**

Dieser Java-Code zeigt, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Löscht alle Kommentare aus der Präsentation
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Löscht alle Autoren
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **Bestimmte Kommentare löschen**

Dieser Java-Code zeigt, wie Sie bestimmte Kommentare auf einer Folie löschen:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Kommentare hinzufügen...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // Alle Kommentare entfernen, die den Text "comment 1" enthalten
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Unterstützt Aspose.Slides einen Status wie „gelöst“ für moderne Kommentare?**

Ja. [Modern comments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/) stellen eine [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-)‑Methode bereit; Sie können einen [Kommentar‑Zustand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) festlegen (z. B. als gelöst markieren), und dieser Zustand wird in der Datei gespeichert und von PowerPoint erkannt.

**Werden Thread‑Diskussionen (Antwortketten) unterstützt und gibt es ein Verschachtelungs‑Limit?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/comment/#getParentComment--) verweisen, wodurch beliebige Antwortketten ermöglicht werden. Die API gibt keine spezifische Begrenzung der Verschachtelungstiefe vor.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Position wird als Fließkomma‑Punkt im Koordinatensystem der Folie gespeichert. Dadurch können Sie den Kommentar‑Marker genau dort platzieren, wo Sie ihn benötigen.