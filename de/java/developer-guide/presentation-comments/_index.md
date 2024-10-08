---
title: Präsentationskommentare
type: docs
weight: 100
url: /de/java/presentation-comments/
keywords: "Kommentare, PowerPoint-Kommentare, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Kommentare und Antworten in der PowerPoint-Präsentation in Java hinzufügen"
---

In PowerPoint erscheint ein Kommentar als Notiz oder Anmerkung auf einer Folie. Wenn ein Kommentar angeklickt wird, werden dessen Inhalte oder Nachrichten angezeigt. 

### **Warum Kommentare zu Präsentationen hinzufügen?**

Sie möchten möglicherweise Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen zu kommunizieren, wenn Sie Präsentationen überprüfen.

Um Ihnen die Verwendung von Kommentaren in PowerPoint-Präsentationen zu ermöglichen, bietet Aspose.Slides für Java

* Die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, die die Sammlungen von Autoren (aus der [ICommentAuthorCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentAuthorCollection) Schnittstelle) enthält. Die Autoren fügen Folien Kommentare hinzu. 
* Die [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentCollection) Schnittstelle, die die Sammlung von Kommentaren für einzelne Autoren enthält. 
* Die [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) Klasse, die Informationen zu Autoren und ihren Kommentaren enthält: wer den Kommentar hinzugefügt hat, wann der Kommentar hinzugefügt wurde, die Position des Kommentars usw. 
* Die [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/CommentAuthor) Klasse, die Informationen zu einzelnen Autoren enthält: den Namen des Autors, seine Initialen, Kommentare, die mit dem Namen des Autors verbunden sind usw. 

## **Kommentarfeld hinzufügen**
Dieser Java-Code zeigt Ihnen, wie Sie einen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

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
    author.getComments().addComment("Hallo Jawad, das ist ein Folienkommentar", pres.getSlides().get_Item(0), point, new Date());

    // Fügt einen Folienkommentar für einen Autor auf Folie 2 hinzu
    author.getComments().addComment("Hallo Jawad, das ist der zweite Folienkommentar", pres.getSlides().get_Item(1), point, new Date());

    // Greift auf ISlide 1 zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Wenn null als Argument übergeben wird, werden Kommentare von allen Autoren zur ausgewählten Folie gebracht
    IComment[] Comments = slide.getSlideComments(author);

    // Greift auf den Kommentar an Index 0 für Folie 1 zu
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Wählt die Kommentarensammlung des Autors am Index 0 aus
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Folie Kommentare zugreifen**
Dieser Java-Code zeigt Ihnen, wie Sie auf einen vorhandenen Kommentar auf einer Folie in einer PowerPoint-Präsentation zugreifen:

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
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " hat Kommentar: " + comment.getText() +
                    " mit Autor: " + comment.getAuthor().getName() + " gepostet zur Zeit :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Kommentare Antworten**
Ein Elternkommentar ist der oberste oder ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit den [getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#getParentComment--) oder [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) Methoden (aus der [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) Schnittstelle) können Sie einen Elternkommentar festlegen oder abrufen. 

Dieser Java-Code zeigt Ihnen, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:

```java
Presentation pres = new Presentation();
try {
    // Fügt einen Kommentar hinzu
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("Kommentar 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Fügt eine Antwort zu Kommentar 1 hinzu
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("Antwort 1 für Kommentar 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Fügt eine weitere Antwort zu Kommentar 1 hinzu
    IComment reply2 = author2.getComments().addComment("Antwort 2 für Kommentar 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Fügt eine Antwort zu einer vorhandenen Antwort hinzu
    IComment subReply = author1.getComments().addComment("Unterantwort 3 für Antwort 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("Kommentar 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("Kommentar 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("Antwort 4 für Kommentar 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Gibt die Kommentarhierarchie in der Konsole aus
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

    // Entfernt Kommentar 1 und alle Antworten darauf
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Achtung" %}} 

* Wenn die [Remove](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#remove--) Methode (aus der [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment) Schnittstelle) verwendet wird, um einen Kommentar zu löschen, werden die Antworten auf den Kommentar ebenfalls gelöscht. 
* Wenn die [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) Einstellung einen zirkulären Verweis ergibt, wird eine [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

## **Modernen Kommentar hinzufügen**

Im Jahr 2021 führte Microsoft *moderne Kommentare* in PowerPoint ein. Die modernen Kommentar-Funktionen verbessern die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint-Nutzer Kommentare klären, Kommentare an Objekten und Texten verankern und einfacher mit anderen interagieren. 

In [Aspose Slides für Java 21.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-11-release-notes/) haben wir die Unterstützung für moderne Kommentare implementiert, indem wir die [ModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/ModernComment) Klasse hinzugefügt haben. Die [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) und [insertModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) Methoden wurden zur [CommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection) Klasse hinzugefügt. 

Dieser Java-Code zeigt Ihnen, wie Sie einen modernen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Ein Autor", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("Dies ist ein moderner Kommentar", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kommentar entfernen**

### **Alle Kommentare und Autoren löschen**

Dieser Java-Code zeigt Ihnen, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:

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

Dieser Java-Code zeigt Ihnen, wie Sie bestimmte Kommentare auf einer Folie löschen:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Kommentare hinzufügen...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Autor", "A");
    author.getComments().addComment("Kommentar 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("Kommentar 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // Entfernt alle Kommentare, die den Text "Kommentar 1" enthalten
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("Kommentar 1"))
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