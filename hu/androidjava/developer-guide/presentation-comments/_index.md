---
title: Prezentációs megjegyzések kezelése Androidon
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/androidjava/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentációs megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- válasz megjegyzés
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Android via Java segítségével: gyorsan és egyszerűen adjon hozzá, olvasson, szerkesszen és töröljön megjegyzéseket PowerPoint fájlokban."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan kezelhetők a megjegyzések egy prezentációban az Aspose.Slides segítségével. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és demonstrálja, hogyan adhatunk megjegyzéseket diákhoz, hogyan érhetjük el a meglévő megjegyzéseket, hogyan dolgozhatunk válaszokkal, hogyan használhatók a modern megjegyzések, valamint hogyan távolíthatók el a megjegyzések a prezentációból.

A példák a PowerPoint gyakori felülvizsgálati és együttműködési forgatókönyveire összpontosítanak, például a megjegyzések szerzőkhöz rendelésére, a megjegyzés tartalmának és metaadatainak olvasására, a válaszkötegek felépítésére, valamint az összes megjegyzés törlésére vagy kiválasztottak eltávolítására.

PowerPointban egy megjegyzés megjelenik jegyzetként vagy annotációként egy dián. Ha egy megjegyzésre kattintanak, a tartalma vagy üzenetei megjelennek.

### **Miért érdemes megjegyzéseket hozzáadni a prezentációkhoz?**

Szeretné használni a megjegyzéseket visszajelzés adására vagy kollégáival való kommunikációra a prezentációk felülvizsgálata során.

Az Aspose.Slides for Android via Java lehetővé teszi a megjegyzések használatát PowerPoint‑prezentációkban a következőkkel:

* A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály, amely a szerzők (az [ICommentAuthorCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICommentAuthorCollection) interfész) gyűjteményét tartalmazza. A szerzők megjegyzéseket adnak a diákhoz.
* Az [ICommentCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICommentCollection) interfész, amely egyes szerzők megjegyzéseinek gyűjteményét tartalmazza.
* Az [IComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IComment) osztály, amely a szerzőkre és azok megjegyzéseire vonatkozó információkat tartalmazza: ki adta a megjegyzést, mikor adták hozzá, a megjegyzés pozíciója stb.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/CommentAuthor) osztály, amely egyes szerzőkről tartalmaz információkat: a szerző neve, monogramja, a szerző nevéhez kapcsolódó megjegyzések stb.

## **Megjegyzés hozzáadása egy diához**
Ez a Java‑kód megmutatja, hogyan adhat megjegyzést egy diához egy PowerPoint‑prezentációban:

```java
// Létrehozza a Presentation osztályt
Presentation pres = new Presentation();
try {
    // Üres diát ad hozzá
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Szerzőt ad hozzá
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Beállítja a megjegyzések pozícióját
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Dia megjegyzést ad hozzá egy szerzőnek az 1. dián
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Dia megjegyzést ad hozzá egy szerzőnek a 2. dián
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Az 1. ISlide-hoz fér hozzá
    ISlide slide = pres.getSlides().get_Item(0);

    // Ha null értéket adunk át argumentumként, az összes szerző megjegyzései a kiválasztott diára kerülnek
    IComment[] Comments = slide.getSlideComments(author);

    // Az 0. indexű megjegyzés elérése az 1. dián
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Kiválasztja a szerző megjegyzésgyűjteményét a 0. indexnél
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Diák megjegyzéseinek elérése**
Ez a Java‑kód megmutatja, hogyan érhet el egy meglévő megjegyzést egy dián egy PowerPoint‑prezentációban:

```java
// Létrehozza a Presentation osztályt
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

## **Megjegyzések válaszolása**
Egy szülőmegjegyzés a hierarchia csúcsa vagy eredeti megjegyzése. A [getParentComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IComment#getParentComment--) vagy a [setParentComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) metódusokkal (az [IComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IComment) interfészből) beállíthat vagy lekérhet egy szülőmegjegyzést.

Ez a Java‑kód megmutatja, hogyan adhat megjegyzéseket, és hogyan kaphat válaszokat hozzájuk:

```java
Presentation pres = new Presentation();
try {
    // Megjegyzést ad hozzá
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Válaszként a comment1-hez ad hozzá
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // A comment1-hez egy másik válaszként ad hozzá
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Hozzáad egy válaszkommentet egy meglévő válaszhoz
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Kiírja a megjegyzések hierarchiáját a konzolra
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

    // Eltávolítja a comment1-et és az összes hozzá tartozó választ
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 

* Ha a [Remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IComment#remove--) metódust (az [IComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IComment) interfészből) használják egy megjegyzés törlésére, a megjegyzéshez tartozó válaszok is törlődnek.
* Ha a [setParentComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) beállítása körkörös hivatkozást eredményez, a [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PptxEditException) kerül dobásra.

{{% /alert %}}

## **Modern megjegyzés hozzáadása**

2021‑ben a Microsoft megjelentette a *modern megjegyzéseket* a PowerPointban. A modern megjegyzések funkciója jelentősen javítja az együttműködést a PowerPointban. A modern megjegyzésekkel a PowerPoint‑felhasználók könnyebben tudnak megjegyzéseket megoldani, megjegyzéseket objektumokhoz és szövegekhez rögzíteni, valamint sokkal egyszerűbben léphetnek interakcióba.

Az Aspose.Slides támogatja a modern megjegyzéseket a [ModernComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ModernComment) osztállyal. Az [addModernComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) és az [insertModernComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) metódusok a [CommentCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/CommentCollection) osztályhoz lettek hozzáadva.

Ez a Java‑kód megmutatja, hogyan adhat modern megjegyzést egy diához egy PowerPoint‑prezentációban:

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

## **Megjegyzés eltávolítása**

### **Az összes megjegyzés és szerző törlése**

Ez a Java‑kód megmutatja, hogyan távolíthatja el az összes megjegyzést és szerzőt egy prezentációból:

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

### **Konkrét megjegyzések törlése**

Ez a Java‑kód megmutatja, hogyan törölhet konkrét megjegyzéseket egy dián:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // megjegyzéseket ad hozzá...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // eltávolítja az összes olyan megjegyzést, amely a "comment 1" szöveget tartalmazza
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

**Támogatja-e az Aspose.Slides a „megoldott” állapotot a modern megjegyzéseknél?**

Igen. A [Modern comments](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/moderncomment/) egy [setStatus](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-) metódust biztosít; beállíthat egy [comment’s state](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/moderncommentstatus/) (például megjelölheti megoldottként), és ez az állapot a fájlban tárolódik, valamint a PowerPoint felismeri.

**Támogatottak-e a szálas megbeszélések (válaszkötetek), és van‑e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/comment/#getParentComment--)‑re, lehetővé téve tetszőleges hosszú válaszköteteket. Az API nem tartalmaz konkrét beágyazási mélység‑korlátot.

**Milyen koordináta‑rendszerben van meghatározva egy megjegyzésjelző pozíciója a dián?**

A pozíció lebegőpontos pontként van tárolva a dia koordináta‑rendszerében. Ez lehetővé teszi, hogy a megjegyzésjelzőt pontosan oda helyezze, ahová szüksége van.