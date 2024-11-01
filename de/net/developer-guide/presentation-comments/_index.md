---
title: Präsentationskommentare
type: docs
weight: 100
url: /de/net/presentation-comments/
keywords: "Kommentare, PowerPoint-Kommentare, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Fügen Sie Kommentare und Antworten in einer PowerPoint-Präsentation in C# oder .NET hinzu"
---

In PowerPoint erscheint ein Kommentar als Notiz oder Anmerkung auf einer Folie. Wenn auf einen Kommentar geklickt wird, werden dessen Inhalte oder Nachrichten angezeigt. 

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie möchten möglicherweise Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen zu kommunizieren, wenn Sie Präsentationen überprüfen.

Um Ihnen die Verwendung von Kommentaren in PowerPoint-Präsentationen zu ermöglichen, bietet Aspose.Slides für .NET

* Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Sammlungen von Autoren (aus der [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index) Eigenschaft) enthält. Die Autoren fügen Folien Kommentare hinzu. 
* Das [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) Interface, das die Sammlung von Kommentaren für einzelne Autoren enthält. 
* Die [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) Klasse, die Informationen zu Autoren und deren Kommentaren enthält: wer den Kommentar hinzugefügt hat, wann der Kommentar hinzugefügt wurde, die Position des Kommentars usw. 
* Die [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) Klasse, die Informationen zu einzelnen Autoren enthält: den Namen des Autors, seine Initialen, Kommentare, die mit dem Namen des Autors verbunden sind, usw. 

## **Kommentare zu Folien hinzufügen**
Dieser C#-Code zeigt Ihnen, wie Sie einen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```c#
// Instanziiert die Präsentation-Klasse
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

    // Fügt Folienkommentar für einen Autor auf Folie 1 hinzu
    author.Comments.AddComment("Hallo Jawad, dies ist ein Folienkommentar", presentation.Slides[0], point, DateTime.Now);

    // Fügt Folienkommentar für einen Autor auf Folie 2 hinzu
    author.Comments.AddComment("Hallo Jawad, dies ist der zweite Folienkommentar", presentation.Slides[1], point, DateTime.Now);

    // Greift auf ISlide 1 zu
    ISlide slide = presentation.Slides[0];

    // Wenn null als Argument übergeben wird, werden die Kommentare aller Autoren auf der ausgewählten Folie angezeigt
    IComment[] Comments = slide.GetSlideComments(author);

    // Greift auf den Kommentar am Index 0 für Folie 1 zu
    String str = Comments[0].Text;

    presentation.Save("Kommentare_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Wählt die Kommentarsammlung des Autors am Index 0 aus
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Zugriff auf Folienkommentare**
Dieser C#-Code zeigt Ihnen, wie Sie auf einen vorhandenen Kommentar auf einer Folie in einer PowerPoint-Präsentation zugreifen:

```c#
// Instanziiert die Präsentation-Klasse
using (Presentation presentation = new Presentation("Kommentare1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " hat Kommentar: " + comment.Text + " von Autor: " + comment.Author.Name + " gepostet um: " + comment.CreatedTime + "\n");
        }
    }
}
```


## **Antworten auf Kommentare**
Ein übergeordneter Kommentar ist der oberste oder ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit der [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) Eigenschaft (aus dem [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) Interface) können Sie einen übergeordneten Kommentar festlegen oder abrufen. 

Dieser C#-Code zeigt Ihnen, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:

```c#
using (Presentation pres = new Presentation())
{
    // Fügt einen Kommentar hinzu
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Autor_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("Kommentar 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Fügt eine Antwort auf Kommentar 1 hinzu
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autor_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("Antwort 1 für Kommentar 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Fügt eine weitere Antwort auf Kommentar 1 hinzu
    IComment reply2 = author2.Comments.AddComment("Antwort 2 für Kommentar 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Fügt eine Antwort auf eine bestehende Antwort hinzu
    IComment subReply = author1.Comments.AddComment("Unterantwort 3 für Antwort 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("Kommentar 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("Kommentar 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("Antwort 4 für Kommentar 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Gibt die Kommentarhierarchie in der Konsole aus
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

    pres.Save("uebergeordneter_kommentar.pptx", SaveFormat.Pptx);

    // Entfernt Kommentar 1 und alle Antworten darauf
    comment1.Remove();

    pres.Save("entfernen_kommentar.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Achtung" %}} 

* Wenn die [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) Methode (aus dem [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) Interface) verwendet wird, um einen Kommentar zu löschen, werden auch die Antworten auf den Kommentar gelöscht. 
* Wenn die [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) Einstellung zu einer zirkulären Referenz führt, wird eine [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) ausgelöst.

{{% /alert %}}

## **Modernen Kommentar hinzufügen**

Im Jahr 2021 führte Microsoft *moderne Kommentare* in PowerPoint ein. Die Funktion moderne Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare haben PowerPoint-Nutzer die Möglichkeit, Kommentare zu lösen, Kommentare an Objekte und Texte zu verknüpfen und viel einfacher zu interagieren als zuvor. 

In [Aspose Slides für .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) implementierten wir die Unterstützung für moderne Kommentare, indem wir die [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment) Klasse hinzufügten. Die [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) und [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) Methoden wurden zur [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection) Klasse hinzugefügt. 

Dieser C#-Code zeigt Ihnen, wie Sie einen modernen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Ein Autor", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("Das ist ein moderner Kommentar", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Kommentar entfernen**

### **Alle Kommentare und Autoren löschen**

Dieser C#-Code zeigt Ihnen, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:

```c#
using (var presentation = new Presentation("beispiel.pptx"))
{
    // Löscht alle Kommentare aus der Präsentation
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Löscht alle Autoren
    presentation.CommentAuthors.Clear();

    presentation.Save("beispiel_out.pptx", SaveFormat.Pptx);
}
```

### **Spezifische Kommentare löschen**

Dieser C#-Code zeigt Ihnen, wie Sie spezifische Kommentare auf einer Folie löschen:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // Kommentare hinzufügen...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Autor", "A");
    author.Comments.AddComment("Kommentar 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("Kommentar 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // Entfernt alle Kommentare, die den Text "Kommentar 1" enthalten
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "Kommentar 1")
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