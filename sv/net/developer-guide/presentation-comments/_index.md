---
title: Hantera presentationskommentarer i .NET
linktitle: Presentationskommentarer
type: docs
weight: 100
url: /sv/net/presentation-comments/
keywords:
- kommentar
- modern kommentar
- PowerPoint-kommentarer
- presentationskommentarer
- bildkommentarer
- lägga till kommentar
- komma åt kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska presentationskommentarer med Aspose.Slides för .NET: lägg till, läs, redigera och radera kommentarer i PowerPoint-filer snabbt och enkelt."
---
## **Översikt**

Denna artikel förklarar hur man hanterar presentationskommentarer i Aspose.Slides. Den visar de viktigaste kommentarrelaterade typerna och demonstrerar hur man lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar, använder moderna kommentarer och tar bort kommentarer från en presentation.

Exemplen fokuserar på vanliga gransknings- och samarbetsscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentarens innehåll och metadata, bygga svarskedjor och rensa alla kommentarer eller radera valda.

I PowerPoint visas en kommentar som en anteckning eller annotering på en bild. När en kommentar klickas på visas dess innehåll eller meddelanden.

## **Varför lägga till kommentarer i presentationer?**

Du kan vilja använda kommentarer för att ge återkoppling eller kommunicera med dina kollegor när du granskar presentationer.

För att låta dig använda kommentarer i PowerPoint-presentationer tillhandahåller Aspose.Slides för .NET

* Klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) som innehåller samlingarna av författare (från egenskapen [CommentAuthorCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/icommentauthorcollection/properties/index)). Författarna lägger till kommentarer på bilder. 
* Gränssnittet [ICommentCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/icommentcollection) som innehåller samlingen av kommentarer för enskilda författare. 
* Klassen [IComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment) som innehåller information om författare och deras kommentarer: vem som lade till kommentaren, när kommentaren lades till, kommentarens position osv. 
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/net/aspose.slides/commentauthor) som innehåller information om enskilda författare: författarens namn, deras initialer, kommentarer som är kopplade till författarens namn osv. 

## **Lägg till bildkommentarer**
Den här C#-koden visar hur du lägger till en kommentar på en bild i en PowerPoint-presentation:

```c#
 // Instansierar Presentation-klassen
 using (Presentation presentation = new Presentation())
 {
     // Lägger till en tom bild
     presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

     // Lägger till en författare
     ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

     // Anger positionen för kommentarer
     PointF point = new PointF();
     point.X = 0.2f;
     point.Y = 0.2f;

     // Lägger till en bildkommentar för en författare på bild 1
     author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

     // Lägger till en bildkommentar för en författare på bild 2
     author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

     // Kommer åt ISlide 1
     ISlide slide = presentation.Slides[0];

     // När null skickas som argument, hämtas kommentarer från alla författare till den valda bilden
     IComment[] Comments = slide.GetSlideComments(author);

     // Kommer åt kommentaren på index 0 för bild 1
     String str = Comments[0].Text;

     presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

     if (Comments.GetLength(0) > 0)
     {
         // Väljer författarens kommentarsamling på index 0
         ICommentCollection commentCollection = Comments[0].Author.Comments;
         String Comment = commentCollection[0].Text;
     }
 }
```

## **Åtkomst till bildkommentarer**
Den här C#-koden visar hur du får åtkomst till en befintlig kommentar på en bild i en PowerPoint-presentation:

```c#
 // Instansierar Presentation-klassen
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

## **Svar på kommentarer**
En föräldrakommentar är den översta eller ursprungliga kommentaren i en hierarki av kommentarer eller svar. Genom att använda egenskapen [ParentComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment/properties/parentcomment) (från gränssnittet [IComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment)) kan du sätta eller hämta en föräldrakommentar.

Den här C#-koden visar hur du lägger till kommentarer och får svar på dem:

```c#
using (Presentation pres = new Presentation())
{
    // Lägger till en kommentar
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Lägger till ett svar på kommentar1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Lägger till ytterligare ett svar på kommentar1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Lägger till ett svar på befintligt svar
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Visar kommentarshierarkin i konsolen
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

    // Tar bort kommentar1 och alla svar på den
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Uppmärksamhet" %}} 
* När metoden [Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment/methods/remove) (från gränssnittet [IComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment)) används för att ta bort en kommentar, tas även svaren på kommentaren bort. 
* Om inställningen [ParentComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment/properties/parentcomment) resulterar i en cirkulär referens kommer ett [PptxEditException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxeditexception) att kastas.
{{% /alert %}}

## **Lägg till moderna kommentarer**

År 2021 introducerade Microsoft *moderna kommentarer* i PowerPoint. Funktionen för moderna kommentarer förbättrar samarbetet i PowerPoint avsevärt. Med moderna kommentarer kan PowerPoint-användare lösa kommentarer, förankra kommentarer till objekt och texter samt delta i interaktioner mycket enklare än tidigare. 

I [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/sv/net/aspose-slides-for-net-21-11-release-notes/) implementerade vi stöd för moderna kommentarer genom att lägga till klassen [ModernComment](https://reference.aspose.com/slides/sv/net/aspose.slides/moderncomment). Metoderna [AddModernComment](https://reference.aspose.com/slides/sv/net/aspose.slides/commentcollection/methods/addmoderncomment) och [InsertModernComment](https://reference.aspose.com/slides/sv/net/aspose.slides/commentcollection/methods/insertmoderncomment) lades till i klassen [CommentCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/commentcollection). 

Den här C#-koden visar hur du lägger till en modern kommentar på en bild i en PowerPoint-presentation: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Ta bort kommentarer**

### **Ta bort alla kommentarer och författare**
Den här C#-koden visar hur du tar bort alla kommentarer och författare i en presentation:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Tar bort alla kommentarer från presentationen
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Tar bort alla författare
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Ta bort specifika kommentarer**
Den här C#-koden visar hur du tar bort specifika kommentarer på en bild:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // lägg till kommentarer...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // ta bort alla kommentarer som innehåller texten "comment 1"
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

**Stöder Aspose.Slides en status som 'lösta' för moderna kommentarer?**

Ja. [Modern comments](https://reference.aspose.com/slides/sv/net/aspose.slides/moderncomment/) exponerar en [Status](https://reference.aspose.com/slides/sv/net/aspose.slides/moderncomment/status/)‑egenskap; du kan läsa och sätta ett [kommentarstillstånd](https://reference.aspose.com/slides/sv/net/aspose.slides/moderncommentstatus/) (t.ex. markera den som löst), och detta tillstånd sparas i filen och känns igen av PowerPoint.

**Stöds trådade diskussioner (svarskedjor) och finns det någon begränsning för inbäddning?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/net/aspose.slides/comment/parentcomment/), vilket möjliggör godtyckliga svarskedjor. API‑et deklarerar ingen specifik begränsning för nesting‑djupet.

**I vilket koordinatsystem definieras en kommentarmärkas position på en bild?**

Positionen lagras som en flyttalspunkt i bildens koordinatsystem. Detta låter dig placera kommentarmärket exakt där du behöver det.