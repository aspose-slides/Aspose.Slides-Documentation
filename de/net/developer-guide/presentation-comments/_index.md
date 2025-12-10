---
title: Verwalten von Präsentationskommentaren in .NET
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/net/presentation-comments/
keywords:
- Kommentar
- moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar bearbeiten
- Kommentar beantworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Meistern Sie Präsentationskommentare mit Aspose.Slides für .NET: Kommentare in PowerPoint-Dateien schnell und einfach hinzufügen, lesen, bearbeiten und löschen."
---

In PowerPoint erscheint ein Kommentar als Hinweis oder Anmerkung auf einer Folie. Wenn ein Kommentar angeklickt wird, werden dessen Inhalt oder Nachrichten angezeigt. 

## **Warum Kommentare zu Präsentationen hinzufügen?**

Möglicherweise möchten Sie Kommentare verwenden, um Feedback zu geben oder mit Ihren Kolleg*innen zu kommunizieren, wenn Sie Präsentationen überprüfen.

Um Ihnen die Nutzung von Kommentaren in PowerPoint‑Präsentationen zu ermöglichen, stellt Aspose.Slides für .NET bereit

* Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, die die Sammlungen von Autoren enthält (aus der [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)-Eigenschaft). Die Autoren fügen Folien Kommentare hinzu. 
* Das [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection)-Interface, das die Sammlung von Kommentaren für einzelne Autoren enthält. 
* Das [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)-Klasse, die Informationen zu Autoren und deren Kommentaren enthält: wer den Kommentar hinzugefügt hat, wann der Kommentar hinzugefügt wurde, die Position des Kommentars usw. 
* Die [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor)-Klasse, die Informationen zu einzelnen Autoren enthält: den Namen des Autors, dessen Initialen, dem Autor zugeordnete Kommentare usw. 

## **Folienkommentare hinzufügen**
Der folgende C#‑Code zeigt, wie Sie einer Folie in einer PowerPoint‑Präsentation einen Kommentar hinzufügen:
```c#
// Instanziiert die Presentation-Klasse
using (Presentation presentation = new Presentation())
{
    // Fügt eine leere Folie hinzu
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Fügt einen Autor hinzu
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Setzt die Position für Kommentare
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Fügt einen Folienkommentar für einen Autor auf Folie 1 hinzu
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Fügt einen Folienkommentar für einen Autor auf Folie 2 hinzu
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Greift auf ISlide 1 zu
    ISlide slide = presentation.Slides[0];

    // Wenn null als Argument übergeben wird, werden Kommentare aller Autoren zur ausgewählten Folie gebracht
    IComment[] Comments = slide.GetSlideComments(author);

    // Greift auf den Kommentar am Index 0 für Folie 1 zu
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Wählt die Kommentarsammlung des Autors am Index 0 aus
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```


## **Auf Folienkommentare zugreifen**
Der folgende C#‑Code zeigt, wie Sie auf einen bestehenden Kommentar einer Folie in einer PowerPoint‑Präsentation zugreifen:
```c#
 // Instanziert die Presentation-Klasse
 using (Presentation presentation = new Presentation("Comments1.pptx"))
 {
     foreach (var commentAuthor in presentation.CommentAuthors)
     {
         var author = (CommentAuthor) commentAuthor;
         foreach (var comment1 in author.Comments)
         {
             var comment = (Comment) comment1;
             Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
         }
     }
 }
```


## **Antwortkommentare**
Ein übergeordneter Kommentar ist der oberste bzw. ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit der [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment)-Eigenschaft (aus dem [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)-Interface) können Sie einen übergeordneten Kommentar festlegen oder abrufen. 

Der folgende C#‑Code zeigt, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:
```c#
using (Presentation pres = new Presentation())
{
    // Fügt einen Kommentar hinzu
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Fügt eine Antwort zu comment1 hinzu
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Fügt eine weitere Antwort zu comment1 hinzu
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Fügt eine Antwort auf die bestehende Antwort hinzu
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Gibt die Kommentar-Hierarchie in der Konsole aus
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Entfernt comment1 und alle darauf folgenden Antworten
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="Attention" %}} 

* Wenn die [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove)-Methode (aus dem [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)-Interface) verwendet wird, um einen Kommentar zu löschen, werden auch die Antworten auf den Kommentar gelöscht. 
* Führt die [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment)-Einstellung zu einer zirkulären Referenz, wird eine [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) ausgelöst.

{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Im Jahr 2021 hat Microsoft *moderne Kommentare* in PowerPoint eingeführt. Die Funktion moderne Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Mit modernen Kommentaren können PowerPoint‑Benutzer Kommentare auflösen, Kommentare an Objekten und Texten verankern und viel einfacher interagieren als zuvor. 

In [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) haben wir die Unterstützung für moderne Kommentare implementiert, indem wir die [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment)-Klasse hinzugefügt haben. Die Methoden [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) und [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) wurden zur [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection)-Klasse hinzugefügt. 

Der folgende C#‑Code zeigt, wie Sie einer Folie in einer PowerPoint‑Präsentation einen modernen Kommentar hinzufügen: 
```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Kommentare entfernen**

### **Alle Kommentare und Autoren löschen**

Der folgende C#‑Code zeigt, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:
```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Löscht alle Kommentare aus der Präsentation
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Löscht alle Autoren
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


### **Bestimmte Kommentare löschen**

Der folgende C#‑Code zeigt, wie Sie bestimmte Kommentare auf einer Folie löschen:
```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // Kommentare hinzufügen...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // Entfernt alle Kommentare, die den Text "comment 1" enthalten
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Unterstützt Aspose.Slides einen Status wie „gelöst“ für moderne Kommentare?**

Ja. [Moderne Kommentare](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/) stellen eine [Status](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/status/)-Eigenschaft bereit; Sie können den [Zustand eines Kommentars](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) lesen und festlegen (z. B. ihn als gelöst markieren), und dieser Zustand wird in der Datei gespeichert und von PowerPoint erkannt.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es ein Begrenzungsniveau?**

Ja. Jeder Kommentar kann seinen [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) referenzieren, was beliebige Antwortketten ermöglicht. Die API legt keine spezielle Begrenzung für die Verschachtelungstiefe fest.

**In welchem Koordinatensystem ist die Position eines Kommentar-Markers auf einer Folie definiert?**

Die Position wird als Gleitkomma‑Punkt im Koordinatensystem der Folie gespeichert. Dadurch können Sie den Kommentar‑Marker genau dort platzieren, wo Sie ihn benötigen.