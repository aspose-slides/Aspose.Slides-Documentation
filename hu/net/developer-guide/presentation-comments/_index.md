---
title: Prezentációs megjegyzések kezelése .NET-ben
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/net/presentation-comments/
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
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for .NET segítségével: adjon, olvasson, szerkesszen és töröljön megjegyzéseket PowerPoint fájlokban gyorsan és egyszerűen."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan kezelhetők a prezentációs megjegyzések az Aspose.Slides-ban. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és demonstrálja, hogyan adhatók megjegyzések a diákhoz, hogyan érhetők el a meglévő megjegyzések, hogyan dolgozhatunk a válaszokkal, hogyan használhatók a modern megjegyzések, és hogyan távolíthatók el a megjegyzések egy prezentációból.

A példák a PowerPoint gyakori felülvizsgálati és együttműködési forgatókönyveire összpontosítanak, például a megjegyzések szerzőkhöz rendelésére, a megjegyzés tartalmának és metaadatainak olvasására, válaszláncok építésére, valamint az összes megjegyzés törlésére vagy a kiválasztottak eltávolítására.

PowerPointban a megjegyzés jegyzet vagy annotáció formájában jelenik meg a dián. Ha egy megjegyzésre kattintunk, annak tartalma vagy üzenetei megjelennek.

## **Miért érdemes megjegyzéseket hozzáadni a prezentációkhoz?**

Megjegyzéseket használhat visszajelzés nyújtására vagy a kollégákkal való kommunikációra a prezentációk felülvizsgálata során.

Ahhoz, hogy a PowerPoint prezentációkban megjegyzéseket használhasson, az Aspose.Slides for .NET a következőket biztosítja:

* A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály, amely a szerzők gyűjteményét tartalmazza (a [CommentAuthorCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icommentauthorcollection/properties/index) tulajdonságból). A szerzők megjegyzéseket adnak a diákhoz. 
* A  [ICommentCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icommentcollection) interfész, amely az egyes szerzők megjegyzéseinek gyűjteményét tartalmazza. 
* A  [IComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment) osztály, amely a szerzőkről és megjegyzéseikről tartalmaz információkat: ki adta a megjegyzést, mikor lett hozzáadva, a megjegyzés pozíciója stb. 
* A [CommentAuthor](https://reference.aspose.com/slides/hu/net/aspose.slides/commentauthor) osztály, amely az egyes szerzőkről tartalmaz információkat: a szerző neve, kezdőbetűi, a szerző nevéhez kapcsolódó megjegyzések stb. 

## **Diák megjegyzések hozzáadása**
Ez a C# kód megmutatja, hogyan adhat megjegyzést egy diához egy PowerPoint prezentációban:

```c#
// Létrehozza a Presentation osztályt
using (Presentation presentation = new Presentation())
{
    // Üres diát ad hozzá
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Szerzőt ad hozzá
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Beállítja a megjegyzések pozícióját
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Megjegyzést ad egy szerzőnek az 1. dián
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Megjegyzést ad egy szerzőnek a 2. dián
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Eléri az ISlide 1-et
    ISlide slide = presentation.Slides[0];

    // Ha null értéket adunk át argumentumként, az összes szerző megjegyzései megjelennek a kiválasztott dián
    IComment[] Comments = slide.GetSlideComments(author);

    // Eléri az 1. dián lévő 0. indexű megjegyzést
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Kiválasztja a szerző 0. indexű megjegyzésgyűjteményét
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Diák megjegyzések elérése**
Ez a C# kód megmutatja, hogyan érhet el egy meglévő megjegyzést egy dián egy PowerPoint prezentációban:

```c#
// Létrehozza a Presentation osztályt
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

## **Megjegyzések válaszolása**
A szülő megjegyzés a hierarchia legfelső vagy eredeti megjegyzése a megjegyzések vagy válaszok sorozatában. A [ParentComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment/properties/parentcomment) tulajdonság (az [IComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment) interfészből) használatával beállíthat vagy lekérdezhet egy szülő megjegyzést.

Ez a C# kód megmutatja, hogyan adhat megjegyzéseket és hogyan kaphat válaszokat rájuk:

```c#
using (Presentation pres = new Presentation())
{
    // Megjegyzést ad hozzá
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Válasz hozzáadása a comment1-hez
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Másik válasz hozzáadása a comment1-hez
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Válasz hozzáadása a meglévő válaszhoz
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Kiírja a megjegyzések hierarchiáját a konzolra
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

    // Eltávolítja a comment1-et és az összes rá válaszoltatot
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Figyelem" %}} 

* Ha a [Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment/methods/remove) metódust (az [IComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment) interfészből) egy megjegyzés törlésére használják, akkor a megjegyzésre adott válaszok is törlésre kerülnek. 
* Ha a [ParentComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment/properties/parentcomment) beállítás körkörös hivatkozást eredményez, akkor [PptxEditException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxeditexception) kivétel dobódik.

{{% /alert %}}

## **Modern megjegyzések hozzáadása**

2021-ben a Microsoft bevezette a *modern megjegyzéseket* a PowerPointban. A modern megjegyzések funkció jelentősen javítja az együttműködést a PowerPointban. A modern megjegyzésekkel a PowerPoint felhasználók könnyebben oldhatják fel a megjegyzéseket, rögzíthetik azokat objektumokhoz és szövegekhez, és sokkal egyszerűbben léphetnek interakcióba.

Az [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/hu/net/aspose-slides-for-net-21-11-release-notes/) kiadásban támogattuk a modern megjegyzéseket a [ModernComment](https://reference.aspose.com/slides/hu/net/aspose.slides/moderncomment) osztály hozzáadásával. A [AddModernComment](https://reference.aspose.com/slides/hu/net/aspose.slides/commentcollection/methods/addmoderncomment) és a [InsertModernComment](https://reference.aspose.com/slides/hu/net/aspose.slides/commentcollection/methods/insertmoderncomment) metódusok a [CommentCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/commentcollection) osztályhoz lettek hozzáadva. 

Ez a C# kód megmutatja, hogyan adhat modern megjegyzést egy diához egy PowerPoint prezentációban: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Megjegyzések eltávolítása**

### **Minden megjegyzés és szerző törlése**

Ez a C# kód megmutatja, hogyan távolíthatók el egy prezentációban az összes megjegyzés és szerző:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Törli a prezentáció összes megjegyzését
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Törli az összes szerzőt
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Kijelölt megjegyzések törlése**

Ez a C# kód megmutatja, hogyan törölhetők egy dián a konkrét megjegyzések:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // megjegyzéseket adjon...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // eltávolítja az összes megjegyzést, amely a "comment 1" szöveget tartalmazza
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

## **GYIK**

**Támogatja az Aspose.Slides a 'megoldva' állapotot a modern megjegyzéseknél?**

Igen. A [Modern comments](https://reference.aspose.com/slides/hu/net/aspose.slides/moderncomment/) rendelkezik egy [Status](https://reference.aspose.com/slides/hu/net/aspose.slides/moderncomment/status/) tulajdonsággal; a [megjegyzés állapotát](https://reference.aspose.com/slides/hu/net/aspose.slides/moderncommentstatus/) (például megoldottként jelölve) beolvashatja és beállíthatja, és ez az állapot a fájlban tárolódik, valamint a PowerPoint is felismeri.

**Támogatottak-e a szálas megbeszélések (válaszláncok), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/hu/net/aspose.slides/comment/parentcomment/) elemre, ezáltal tetszőleges válaszláncok hozhatók létre. Az API nem határoz meg konkrét beágyazási mélységkorlátot.

**Milyen koordináta-rendszerben van meghatározva egy megjegyzésjelző pozíciója a dián?**

A pozíció a dia koordináta-rendszerében lebegőpontos pontként van tárolva. Ez lehetővé teszi, hogy a megjegyzésjelzőt pontosan arra a helyre helyezze, ahol szüksége van rá.