---
title: Správa komentářů v prezentaci v .NET
linktitle: Komentáře v prezentaci
type: docs
weight: 100
url: /cs/net/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímku
- přidat komentář
- přístup ke komentáři
- upravit komentář
- odpověď na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Mistrujte komentáře v prezentacích s Aspose.Slides pro .NET: přidávejte, čtěte, upravujte a mažte komentáře v souborech PowerPoint rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentaci v Aspose.Slides. Ukazuje hlavní typy související s komentáři a demonstruje, jak přidávat komentáře k snímkům, přistupovat k existujícím komentářům, pracovat s odpověďmi, používat moderní komentáře a odstraňovat komentáře z prezentace.

Příklady se zaměřují na běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení obsahu a metadat komentářů, vytváření řetězců odpovědí a mazání všech komentářů nebo odstraňování vybraných.

V PowerPointu se komentář zobrazuje jako poznámka nebo anotace na snímku. Po kliknutí na komentář se zobrazí jeho obsah nebo zprávy.

## **Proč přidávat komentáře do prezentací?**

Možná budete chtít používat komentáře k poskytování zpětné vazby nebo komunikaci s kolegy při revizi prezentací.

Aby vám Aspose.Slides pro .NET umožnil používat komentáře v PowerPoint prezentacích, poskytuje
* Třídu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), která obsahuje kolekce autorů (z vlastnosti [CommentAuthorCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icommentauthorcollection/properties/index)). Autoři přidávají komentáře k snímkům. 
* Rozhraní [ICommentCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icommentcollection), které obsahuje kolekci komentářů pro jednotlivé autory. 
* Třídu [IComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment), která obsahuje informace o autorech a jejich komentářích: kdo přidal komentář, kdy byl komentář přidán, pozice komentáře atd. 
* Třídu [CommentAuthor](https://reference.aspose.com/slides/cs/net/aspose.slides/commentauthor), která obsahuje informace o jednotlivých autorech: jméno autora, jeho iniciály, komentáře spojené s jménem autora atd. 

## **Přidání komentářů ke snímkům**
Tento kód v C# ukazuje, jak přidat komentář ke snímku v PowerPoint prezentaci:

```c#
// Vytváří instanci třídy Presentation
using (Presentation presentation = new Presentation())
{
    // Přidá prázdný snímek
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Přidá autora
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Nastavuje pozici pro komentáře
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Přidá komentář ke snímku pro autora na snímku 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Přidá komentář ke snímku pro autora na snímku 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Přistupuje k ISlide 1
    ISlide slide = presentation.Slides[0];

    // Když je jako argument předáno null, jsou na vybraný snímek přineseny komentáře všech autorů
    IComment[] Comments = slide.GetSlideComments(author);

    // Přistupuje k komentáři na indexu 0 pro snímek 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Vybere kolekci komentářů autora na indexu 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Přístup ke komentářům na snímcích**
Tento kód v C# ukazuje, jak získat přístup k existujícímu komentáři na snímku v PowerPoint prezentaci:

```c#
// Vytváří instanci třídy Presentation
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

## **Odpovědi na komentáře**
Nadřazený komentář je nejvyšší nebo původní komentář v hierarchii komentářů nebo odpovědí. Pomocí vlastnosti [ParentComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment/properties/parentcomment) (z rozhraní [IComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment)) můžete nastavit nebo získat nadřazený komentář.

Tento kód v C# ukazuje, jak přidat komentáře a získat odpovědi na ně:

```c#
using (Presentation pres = new Presentation())
{
    // Přidá komentář
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Přidá odpověď na comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Přidá další odpověď na comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Přidá odpověď na existující odpověď
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Zobrazí hierarchii komentářů v konzoli
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

    // Odstraní comment1 a všechny odpovědi na něj
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Pozor" %}} 
* Když je metoda [Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment/methods/remove) (z rozhraní [IComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment)) použita k odstranění komentáře, jsou také smazány odpovědi na tento komentář. 
* Pokud nastavení [ParentComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment/properties/parentcomment) způsobí kruhový odkaz, bude vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxeditexception).
{{% /alert %}}

## **Přidání moderních komentářů**

V roce 2021 Microsoft představil *moderní komentáře* v PowerPointu. Funkce moderních komentářů výrazně zlepšuje spolupráci v PowerPointu. Díky moderním komentářům mohou uživatelé PowerPointu řešit komentáře, přichycovat komentáře k objektům a textům a zapojovat se do interakcí mnohem jednodušeji než dříve. 

V [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/cs/net/aspose-slides-for-net-21-11-release-notes/) jsme implementovali podporu moderních komentářů přidáním třídy [ModernComment](https://reference.aspose.com/slides/cs/net/aspose.slides/moderncomment). Metody [AddModernComment](https://reference.aspose.com/slides/cs/net/aspose.slides/commentcollection/methods/addmoderncomment) a [InsertModernComment](https://reference.aspose.com/slides/cs/net/aspose.slides/commentcollection/methods/insertmoderncomment) byly přidány do třídy [CommentCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/commentcollection). 

Tento kód v C# ukazuje, jak přidat moderní komentář ke snímku v PowerPoint prezentaci: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Odstranění komentářů**

### **Smazat všechny komentáře a autory**

Tento kód v C# ukazuje, jak odstranit všechny komentáře a autory v prezentaci:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Odstraní všechny komentáře z prezentace
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Odstraní všechny autory
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Smazat konkrétní komentáře**

Tento kód v C# ukazuje, jak smazat konkrétní komentáře na snímku:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // přidá komentáře...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // odstraní všechny komentáře, které obsahují text "comment 1"
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

## **Často kladené otázky**

**Podporuje Aspose.Slides stav jako 'vyřešeno' pro moderní komentáře?**

Ano. [Moderní komentáře](https://reference.aspose.com/slides/cs/net/aspose.slides/moderncomment/) poskytují vlastnost [Status](https://reference.aspose.com/slides/cs/net/aspose.slides/moderncomment/status/); můžete číst a nastavit [stav komentáře](https://reference.aspose.com/slides/cs/net/aspose.slides/moderncommentstatus/) (například jej označit jako vyřešený) a tento stav je uložen v souboru a rozpoznán PowerPointem.

**Jsou podporovány vlákna diskusí (řetězce odpovědí) a existuje omezení hloubky?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/net/aspose.slides/comment/parentcomment/), což umožňuje libovolné řetězce odpovědí. API neuvádí konkrétní omezení hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice je uložena jako desetinný bod v souřadnicovém systému snímku. To vám umožní umístit značku komentáře přesně tam, kde ji potřebujete.