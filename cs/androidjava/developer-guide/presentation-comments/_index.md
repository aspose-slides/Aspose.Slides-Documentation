---
title: Správa komentářů v prezentaci na Androidu
linktitle: Komentáře k prezentaci
type: docs
weight: 100
url: /cs/androidjava/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímku
- přidat komentář
- přístup k komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Mistrujte komentáře v prezentacích s Aspose.Slides pro Android prostřednictvím Javy: přidávejte, čtěte, upravujte a mažte komentáře v souborech PowerPoint rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentacích v Aspose.Slides. Ukazuje hlavní typy související s komentáři a demonstruje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi, používat moderní komentáře a odstraňovat komentáře z prezentace.

Příklady se zaměřují na běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení obsahu a metadat komentářů, vytváření řetězců odpovědí a vymazání všech komentářů nebo odstranění vybraných.

V PowerPointu se komentář zobrazuje jako poznámka nebo anotace na snímku. Po kliknutí na komentář se odhalí jeho obsah nebo zprávy.

### **Proč přidávat komentáře do prezentací?**

Možná budete chtít používat komentáře k poskytování zpětné vazby nebo komunikaci s kolegy při revizi prezentací.

Aby vám bylo umožněno používat komentáře v PowerPoint prezentacích, poskytuje Aspose.Slides for Android via Java
* Třída [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) která obsahuje kolekce autorů (z rozhraní [ICommentAuthorCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICommentAuthorCollection)). Autoři přidávají komentáře do snímků.
* Rozhraní [ICommentCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICommentCollection) které obsahuje sbírku komentářů pro jednotlivé autory.
* Třída [IComment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IComment) která obsahuje informace o autorech a jejich komentářích: kdo komentář přidal, čas přidání komentáře, pozice komentáře atd.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/CommentAuthor) která obsahuje informace o jednotlivých autorech: jméno autora, jeho iniciály, komentáře spojené s jménem autora atd.

## **Přidat komentář ke snímku**
Tento Java kód ukazuje, jak přidat komentář do snímku v PowerPoint prezentaci:

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

    // Přistupuje ke komentáři s indexem 0 pro snímek 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Vybere kolekci komentářů autora s indexem 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup ke komentářům na snímku**
Tento Java kód ukazuje, jak získat přístup k existujícímu komentáři na snímku v PowerPoint prezentaci:

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
Nadřazený komentář je horní nebo původní komentář v hierarchii komentářů nebo odpovědí. Pomocí metod [getParentComment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IComment#getParentComment--) nebo [setParentComment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (z rozhraní [IComment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IComment)) můžete nastavit nebo získat nadřazený komentář.

Tento Java kód ukazuje, jak přidat komentáře a získat k nim odpovědi:

```java
Presentation pres = new Presentation();
try {
    // Přidá komentář
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Přidá odpověď na comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Přidá další odpověď na comment1
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

    // Odstraní comment1 a všechny jeho odpovědi
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Upozornění" %}} 
* Když je metoda [Remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IComment#remove--) (z rozhraní [IComment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IComment)) použita k odstranění komentáře, odpovědi na komentář jsou také smazány.
* Pokud nastavení [setParentComment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) vede k cyklickému odkazu, bude vyhozena výjimka [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **Přidat moderní komentář**

V roce 2021 Microsoft představil *moderní komentáře* v PowerPointu. Funkce moderních komentářů výrazně zlepšuje spolupráci v PowerPointu. Pomocí moderních komentářů mohou uživatelé PowerPointu řešit komentáře, připínat komentáře k objektům a textům a mnohem snadněji komunikovat. 

Aspose.Slides podporuje moderní komentáře pomocí třídy [ModernComment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ModernComment). Metody [addModernComment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) a [insertModernComment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) byly přidány do třídy [CommentCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/CommentCollection).

Tento Java kód ukazuje, jak přidat moderní komentář do snímku v PowerPoint prezentaci: 

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

## **Odstranit komentář**

### **Odstranit všechny komentáře a autory**

Tento Java kód ukazuje, jak odstranit všechny komentáře a autory v prezentaci:

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

### **Odstranit konkrétní komentáře**

Tento Java kód ukazuje, jak odstranit konkrétní komentáře na snímku:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // přidá komentáře...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // odstraní všechny komentáře, které obsahují text "comment 1"
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

**Podporuje Aspose.Slides stav jako „vyřešeno“ pro moderní komentáře?**

Ano. [Moderní komentáře](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/moderncomment/) umožňují metodu [setStatus](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-); můžete nastavit [stav komentáře](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/moderncommentstatus/) (například jej označit jako vyřešený) a tento stav je uložen v souboru a rozpoznán PowerPointem.

**Jsou podporovány vlákna diskuzí (řetězce odpovědí) a existuje limit hloubky?**

Ano. Každý komentář může odkazovat na svůj [nadřazený komentář](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/comment/#getParentComment--), což umožňuje libovolné řetězce odpovědí. API neuvádí konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice je uložena jako bod s plovoucí desetinnou čárkou v souřadnicovém systému snímku. To vám umožňuje umístit značku komentáře přesně na požadované místo.