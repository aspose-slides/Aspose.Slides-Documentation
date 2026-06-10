---
title: Prezentáció megjegyzések kezelése Java-ban
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/java/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentációs megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Kezeld a prezentációs megjegyzéseket az Aspose.Slides for Java-val: hozzáadj, olvass, szerkessz és törölj megjegyzéseket PowerPoint fájlokban gyorsan és egyszerűen."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a megjegyzések egy prezentációban az Aspose.Slides használatával. Megmutatja a fő megjegyzésekkel kapcsolatos típusokat, és demonstrálja, hogyan adhatunk megjegyzéseket a diákhoz, hogyan érhetjük el a meglévő megjegyzéseket, hogyan dolgozhatunk válaszokkal, hogyan használhatunk modern megjegyzéseket, illetve hogyan távolíthatunk el megjegyzéseket egy prezentációból.

A példák a gyakori felülvizsgálati és együttműködési forgatókönyvekre összpontosítanak a PowerPointban, mint például a megjegyzések szerzőkhöz rendelése, a megjegyzés tartalmának és metaadatainak olvasása, válaszláncok építése, valamint az összes megjegyzés törlése vagy a kiválasztottak eltávolítása.

A PowerPointban a megjegyzés jegyzet vagy annotáció formájában jelenik meg egy dián. Amikor egy megjegyzésre kattintanak, annak tartalma vagy üzenetei megjelennek.

## **Miért adunk megjegyzéseket a prezentációkhoz?**

Lehet, hogy a megjegyzéseket szeretnéd használni visszajelzés nyújtására vagy a kollégáiddal való kommunikációra a prezentációk felülvizsgálata során.

Annak érdekében, hogy a PowerPoint prezentációkban megjegyzéseket használhass, az Aspose.Slides for Java a következőket biztosítja

* A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztály, amely a szerzők gyűjteményét (az [ICommentAuthorCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICommentAuthorCollection) interfészből) tartalmazza. A szerzők megjegyzéseket adnak a diákhoz. 
* Az  [ICommentCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICommentCollection) interfész, amely az egyes szerzők megjegyzéseinek gyűjteményét tartalmazza. 
* A  [IComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IComment) osztály, amely a szerzőkről és a megjegyzéseikről tartalmaz információkat: ki adta a megjegyzést, mikor került hozzáadásra, a megjegyzés pozíciója stb. 
* A [CommentAuthor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/CommentAuthor) osztály, amely egyes szerzőkről tartalmaz információkat: a szerző neve, monogramja, a szerző nevéhez kapcsolódó megjegyzések stb. 

## **Dia megjegyzések hozzáadása**
Ez a Java kód bemutatja, hogyan adhatunk megjegyzést egy diahoz egy PowerPoint prezentációban:

```java
// Példányosítja a Presentation osztályt
Presentation pres = new Presentation();
try {
    // Hozzáad egy üres diát
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Hozzáad egy szerzőt
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Beállítja a megjegyzések pozícióját
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Megjegyzést ad a szerzőnek az 1. dián
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Megjegyzést ad a szerzőnek a 2. dián
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Eléri az ISlide 1-et
    ISlide slide = pres.getSlides().get_Item(0);

    // Ha null értéket adunk át argumentumként, akkor az összes szerző megjegyzései megjelennek a kiválasztott dián
    IComment[] Comments = slide.getSlideComments(author);

    // Eléri a 0. indexű megjegyzést az 1. dián
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Kiválasztja a szerző 0. indexű megjegyzésgyűjteményét
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dia megjegyzések elérése**
Ez a Java kód bemutatja, hogyan érhetjük el egy meglévő megjegyzést egy dián egy PowerPoint prezentációban:

```java
// Példányosítja a Presentation osztályt
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

## **Megjegyzések válasza**
A szülő megjegyzés a hierarchia legfelső vagy eredeti megjegyzése a megjegyzések vagy válaszok között. A [getParentComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IComment#getParentComment--) vagy a [setParentComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) metódusok (az [IComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IComment) interfészből) használatával beállíthat vagy lekérdezhet egy szülő megjegyzést.

Ez a Java kód bemutatja, hogyan adhatunk megjegyzéseket és hogyan kaphatunk válaszokat rájuk:

```java
Presentation pres = new Presentation();
try {
    // Megjegyzést ad hozzá
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Válasz hozzáadása a comment1-hez
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Egy másik választ ad hozzá a comment1-hez
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Válasz hozzáadása egy meglévő válaszhoz
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Megjeleníti a megjegyzések hierarchiáját a konzolon
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

    // Eltávolítja a comment1-et és az összes rá válaszolt megjegyzést
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 

* Amikor a [Remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IComment#remove--) metódust (az [IComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IComment) interfészből) használják egy megjegyzés törlésére, a megjegyzésre adott válaszok is törlődnek. 
* Ha a [setParentComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) beállítás körkörös hivatkozást eredményez, [PptxEditException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PptxEditException) lesz dobva.

{{% /alert %}}

## **Modern megjegyzések hozzáadása**

2021-ben a Microsoft bevezetett *modern megjegyzéseket* a PowerPointban. A modern megjegyzések funkció jelentősen javítja az együttműködést a PowerPointban. A modern megjegyzéseken keresztül a PowerPoint felhasználók könnyebben oldhatnak fel megjegyzéseket, rögzíthetik azokat objektumokhoz és szövegekhez, és sokkal egyszerűbben léphetnek interakcióba.

A [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/hu/java/aspose-slides-for-java-21-11-release-notes/) kiadásban a modern megjegyzések támogatását valósítottuk meg a [ModernComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ModernComment) osztály hozzáadásával. A [addModernComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) és a [insertModernComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) metódusok a [CommentCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/CommentCollection) osztályhoz lettek hozzáadva. 

Ez a Java kód bemutatja, hogyan adhatunk modern megjegyzést egy diához egy PowerPoint prezentációban: 

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

## **Megjegyzések eltávolítása**

### **Minden megjegyzés és szerző törlése**

Ez a Java kód bemutatja, hogyan távolíthatók el egy prezentációban az összes megjegyzés és szerző:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Törli a prezentáció összes megjegyzését
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Törli az összes szerzőt
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Specifikus megjegyzések törlése**

Ez a Java kód bemutatja, hogyan törölhetők specifikus megjegyzések egy dián:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // megjegyzések hozzáadása...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // eltávolítja az összes megjegyzést, amely a "comment 1" szöveget tartalmazza
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

## **GYIK**

**Támogatja-e az Aspose.Slides a 'megoldva' állapotot a modern megjegyzéseknél?**

Igen. A [Modern comments](https://reference.aspose.com/slides/hu/java/com.aspose.slides/moderncomment/) egy [setStatus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/moderncomment/#setStatus-byte-) metódust biztosít; ezzel beállítható egy [megjegyzés állapota](https://reference.aspose.com/slides/hu/java/com.aspose.slides/moderncommentstatus/) (például megjelölhető megoldottként), és ez az állapot elmentésre kerül a fájlba, valamint a PowerPoint felismeri.

**Támogatottak-e a szálas viták (válaszláncok), és van-e mélységkorlát?**

Igen. Minden megjegyzés hivatkozhat a saját [parent comment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/comment/#getParentComment--) (szülő megjegyzésére), lehetővé téve tetszőleges válaszláncok létrehozását. Az API nem határoz meg konkrét mélységkorlátot.

**Milyen koordináta-rendszerben van meghatározva egy megjegyzés jelzőjének pozíciója a dián?**

A pozíció lebegőpontos pontként van tárolva a dia koordináta-rendszerében. Ez lehetővé teszi, hogy a megjegyzés jelzőjét pontosan oda helyezd, ahol szükséges.