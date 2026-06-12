---
title: Správa komentářů prezentace v Javě
linktitle: Komentáře prezentace
type: docs
weight: 100
url: /cs/java/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPointu
- komentáře prezentace
- komentáře snímku
- přidat komentář
- přístup ke komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Ovládejte komentáře prezentací pomocí Aspose.Slides pro Javu: přidávejte, čtěte, upravujte a mazte komentáře v souborech PowerPoint rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře prezentace v Aspose.Slides. Ukazuje hlavní typy související s komentáři a demonstruje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi, používat moderní komentáře a odstraňovat komentáře z prezentace.

Příklady se soustředí na běžné scénáře recenze a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení obsahu a metadat komentáře, vytváření řetězců odpovědí a čištění všech komentářů nebo mazání vybraných.

V PowerPointu se komentář zobrazuje jako poznámka nebo anotace na snímku. Po kliknutí na komentář se odhalí jeho obsah nebo zprávy.

## **Proč přidávat komentáře do prezentací?**

Můžete chtít používat komentáře k poskytnutí zpětné vazby nebo ke komunikaci s kolegy při revizi prezentací.

Aby bylo možné používat komentáře v prezentacích PowerPoint, Aspose.Slides pro Java poskytuje

* Třídu [Prezentace](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která obsahuje kolekce autorů (z rozhraní [ICommentAuthorCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICommentAuthorCollection)). Autoři přidávají komentáře do snímků. 
* Rozhraní [ICommentCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICommentCollection), které obsahuje kolekci komentářů pro jednotlivé autory. 
* Třídu [IComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IComment), která obsahuje informace o autorech a jejich komentářích: kdo komentář přidal, čas přidání, pozici komentáře atd. 
* Třídu [CommentAuthor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/CommentAuthor), která obsahuje informace o jednotlivých autorech: jméno autora, jeho iniciály, komentáře spojené s jménem autora atd. 

## **Přidání komentářů do snímku**
Tento kód v Javě ukazuje, jak přidat komentář do snímku v prezentaci PowerPoint:

```java
// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Přidá prázdný snímek
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Přidá autora
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Nastaví pozici pro komentáře
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Přidá komentář ke snímku pro autora na snímku 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Přidá komentář ke snímku pro autora na snímku 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Přistupuje k ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Když je jako argument předáno null, jsou na vybraný snímek načteny komentáře od všech autorů
    IComment[] Comments = slide.getSlideComments(author);

    // Přistupuje k komentáři na indexu 0 pro snímek 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Vybere kolekci komentářů autora na indexu 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup ke komentářům ve snímku**
Tento kód v Javě ukazuje, jak získat existující komentář na snímku v prezentaci PowerPoint:

```java
// Vytvoří instanci třídy Presentation
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

## **Odpovědi na komentáře**
Nadřazený komentář je horní nebo původní komentář v hierarchii komentářů nebo odpovědí. Pomocí metod [getParentComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IComment#getParentComment--) nebo [setParentComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (z rozhraní [IComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IComment)) můžete nastavit nebo získat nadřazený komentář. 

Tento kód v Javě ukazuje, jak přidávat komentáře a získávat odpovědi na ně:

```java
Presentation pres = new Presentation();
try {
    // Přidá komentář
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Přidá odpověď na komentář 1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Přidá další odpověď na komentář 1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Přidá odpověď na existující odpověď
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Zobrazí hierarchii komentářů v konzoli
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

    // Odstraní komentář 1 a všechny jeho odpovědi
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Pozor" %}} 

* Když je použita metoda [Remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IComment#remove--) (z rozhraní [IComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IComment)), jsou s komentářem smazány i jeho odpovědi. 
* Pokud nastavení [setParentComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) vytvoří kruhový odkaz, bude vyhozena výjimka [PptxEditException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **Přidání moderních komentářů**

V roce 2021 Microsoft představil *moderní komentáře* v PowerPointu. Funkce moderních komentářů výrazně zlepšuje spolupráci v PowerPointu. Díky moderním komentářům mohou uživatelé PowerPointu řešit komentáře, přichycovat komentáře k objektům a textům a mnohem snadněji komunikovat.

V [Aspose Slides pro Java 21.11](https://docs.aspose.com/slides/cs/java/aspose-slides-for-java-21-11-release-notes/) jsme implementovali podporu moderních komentářů přidáním třídy [ModernComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ModernComment). Metody [addModernComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) a [insertModernComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) byly přidány do třídy [CommentCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/CommentCollection). 

Tento kód v Javě ukazuje, jak přidat moderní komentář do snímku v prezentaci PowerPoint:

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

## **Odstranění komentářů**

### **Smazání všech komentářů a autorů**

Tento kód v Javě ukazuje, jak odstranit všechny komentáře a autory v prezentaci:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Odstraní všechny komentáře z prezentace
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Odstraní všechny autory
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Smazání konkrétních komentářů**

Tento kód v Javě ukazuje, jak smazat konkrétní komentáře na snímku:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    //    přidá komentáře...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    //    odstraní všechny komentáře, které obsahují text "comment 1"
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

## **Často kladené otázky**

**Podporuje Aspose.Slides stav jako „vyřešeno“ u moderních komentářů?**

Ano. [Moderní komentáře](https://reference.aspose.com/slides/cs/java/com.aspose.slides/moderncomment/) poskytují metodu [setStatus](https://reference.aspose.com/slides/cs/java/com.aspose.slides/moderncomment/#setStatus-byte-); můžete nastavit [stav komentáře](https://reference.aspose.com/slides/cs/java/com.aspose.slides/moderncommentstatus/) (například jej označit jako vyřešený) a tento stav je uložen v souboru a rozpoznán PowerPointem.

**Jsou podporovány vlákna diskuzí (řetězce odpovědí) a existuje limit hloubky vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/comment/#getParentComment--), což umožňuje libovolné řetězce odpovědí. API neuvádí konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice je uložena jako desetinný bod v souřadnicovém systému snímku. To vám umožní umístit značku komentáře přesně tam, kde ji potřebujete.