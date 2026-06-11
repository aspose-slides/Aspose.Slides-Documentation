---
title: Hantera presentationskommentarer i Java
linktitle: Presentationskommentarer
type: docs
weight: 100
url: /sv/java/presentation-comments/
keywords:
- kommentar
- modern kommentar
- PowerPoint-kommentarer
- presentationskommentarer
- bildkommentarer
- lägga till kommentar
- åtkomst till kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Mästra presentationskommentarer med Aspose.Slides för Java: lägg till, läs, redigera och radera kommentarer i PowerPoint-filer snabbt och enkelt."
---
## **Översikt**

Denna artikel förklarar hur du hanterar presentationskommentarer i Aspose.Slides. Den visar de viktigaste typ‑relaterade kommentarerna och demonstrerar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar, använder moderna kommentarer och tar bort kommentarer från en presentation.

Exemplen fokuserar på vanliga gransknings‑ och samarbetsscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentarers innehåll och metadata, bygga svarskedjor samt rensa alla kommentarer eller ta bort utvalda.

I PowerPoint visas en kommentar som en anteckning eller markering på en bild. När en kommentar klickas visas dess innehåll eller meddelanden.

## **Varför lägga till kommentarer i presentationer?**

Du kanske vill använda kommentarer för att ge återkoppling eller kommunicera med dina kollegor när du granskar presentationer.

För att du ska kunna använda kommentarer i PowerPoint‑presentationer tillhandahåller Aspose.Slides for Java

* [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑klassen, som innehåller samlingarna av författare (från [ICommentAuthorCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ICommentAuthorCollection)‑gränssnittet). Författarna lägger till kommentarer på bilder.  
* [ICommentCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ICommentCollection)‑gränssnittet, som innehåller samlingen av kommentarer för enskilda författare.  
* [IComment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IComment)‑klassen, som innehåller information om författare och deras kommentarer: vem som lade till kommentaren, tidpunkten då kommentaren lades till, kommentarmärkets position osv.  
* [CommentAuthor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/CommentAuthor)‑klassen, som innehåller information om enskilda författare: författarens namn, initialer, kommentarer som är kopplade till författarens namn osv.  

## **Lägg till bildkommentarer**
Denna Java‑kod visar hur du lägger till en kommentar på en bild i en PowerPoint‑presentation:

```java
// Instansierar Presentation‑klassen
Presentation pres = new Presentation();
try {
    // Lägger till en tom bild
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Lägger till en författare
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Anger positionen för kommentarer
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Lägger till bildkommentar för en författare på bild 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Lägger till bildkommentar för en författare på bild 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Kommer åt ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // När null skickas som argument hämtas kommentarer från alla författare till den valda bilden
    IComment[] Comments = slide.getSlideComments(author);

    // Kommer åt kommentaren på index 0 för bild 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Väljer författarens kommentarsamling på index 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kom åt bildkommentarer**
Denna Java‑kod visar hur du får åtkomst till en befintlig kommentar på en bild i en PowerPoint‑presentation:

```java
// Instansierar Presentation-klassen
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

## **Svara på kommentarer**
En föräldrakommentar är den översta eller den ursprungliga kommentaren i en hierarki av kommentarer eller svar. Med metoderna [getParentComment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IComment#getParentComment--) eller [setParentComment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (från [IComment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IComment)-gränssnittet) kan du hämta eller ange en föräldrakommentar.

Denna Java‑kod visar hur du lägger till kommentarer och får svar på dem:

```java
Presentation pres = new Presentation();
try {
    // Lägger till en kommentar
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Lägger till ett svar på kommentar1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Lägger till ett annat svar på kommentar1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Lägger till ett svar på ett befintligt svar
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Visar kommentarshierarkin i konsolen
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

    // Tar bort kommentar1 och alla svar på den
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* När [Remove](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IComment#remove--)‑metoden (från [IComment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IComment)-gränssnittet) används för att ta bort en kommentar, tas även svaren på kommentaren bort.  
* Om inställningen [setParentComment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) resulterar i en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/PptxEditException).  
{{% /alert %}}

## **Lägg till moderna kommentarer**

År 2021 introducerade Microsoft *moderna kommentarer* i PowerPoint. Funktionen för moderna kommentarer förbättrar samarbetet i PowerPoint avsevärt. Genom moderna kommentarer kan PowerPoint‑användare lösa kommentarer, förankra kommentarer till objekt och texter samt interagera mycket enklare än tidigare.

I [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/sv/java/aspose-slides-for-java-21-11-release-notes/) implementerade vi stöd för moderna kommentarer genom att lägga till [ModernComment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ModernComment)-klassen. Metoderna [addModernComment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) och [insertModernComment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) lades till i [CommentCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/CommentCollection)-klassen.

Denna Java‑kod visar hur du lägger till en modern kommentar på en bild i en PowerPoint‑presentation:

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

## **Ta bort kommentarer**

### **Ta bort alla kommentarer och författare**

Denna Java‑kod visar hur du tar bort alla kommentarer och författare i en presentation:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Tar bort alla kommentarer från presentationen
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Tar bort alla författare
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Ta bort specifika kommentarer**

Denna Java‑kod visar hur du tar bort specifika kommentarer på en bild:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // lägger till kommentarer...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // tar bort alla kommentarer som innehåller texten "comment 1"
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

**Stöder Aspose.Slides ett statusvärde som “lösta” för moderna kommentarer?**

Ja. [Modern comments](https://reference.aspose.com/slides/sv/java/com.aspose.slides/moderncomment/) exponerar en [setStatus](https://reference.aspose.com/slides/sv/java/com.aspose.slides/moderncomment/#setStatus-byte-)‑metod; du kan ange en [kommentarstatus](https://reference.aspose.com/slides/sv/java/com.aspose.slides/moderncommentstatus/) (t.ex. markera den som löst), och detta tillstånd sparas i filen och känns igen av PowerPoint.

**Stöds trådade diskussioner (svarskedjor), och finns det någon begränsning för djupet?**

Ja. Varje kommentar kan referera sin [parent comment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/comment/#getParentComment--), vilket möjliggör godtyckliga svarskedjor. API‑et anger ingen specifik begränsning för nästlingsdjupet.

**I vilket koordinatsystem definieras en kommentarmärkas position på en bild?**

Positionen lagras som ett flyttalspunkt i bildens koordinatsystem. Detta gör att du kan placera kommentarmärket exakt där du behöver det.