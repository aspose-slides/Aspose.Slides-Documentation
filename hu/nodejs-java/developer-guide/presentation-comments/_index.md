---
title: Prezentációs megjegyzések kezelése JavaScriptben
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/nodejs-java/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentációs megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzés válasza
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Node.js segítségével: gyorsan és egyszerűen adjon hozzá, olvasson, szerkesszen és töröljön megjegyzéseket PowerPoint fájlokban JavaScript használatával."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentáció megjegyzései az Aspose.Slides‑ben. Ismerteti a megjegyzésekkel kapcsolatos fő típusokat, és demonstrálja, hogyan lehet megjegyzéseket hozzáadni a diákhoz, meglévő megjegyzéseket elérni, válaszokkal dolgozni, modern megjegyzéseket használni, valamint megjegyzéseket eltávolítani egy prezentációból.

Az példák a PowerPointban gyakori felülvizsgálati és együttműködési forgatókönyvekre fókuszálnak, például a megjegyzések szerzőkhöz rendeltére, a megjegyzés tartalmának és metaadatainak olvasására, válaszláncok építésére, valamint az összes megjegyzés törlésére vagy a kiválasztottak eltávolítására.

A PowerPointban egy megjegyzés jegyzet vagy annotáció formájában jelenik meg egy dián. Ha egy megjegyzésre kattintanak, a tartalma vagy üzenetei megjelennek.

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

A megjegyzéseket felhasználhatja visszajelzés nyújtására vagy kollégáival való kommunikációra a prezentációk felülvizsgálata során.

Az Aspose.Slides for Node.js via Java lehetővé teszi a megjegyzések használatát PowerPoint‑prezentációkban, a következőkkel:

* A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztály, amely tartalmazza a szerzők gyűjteményét (a [CommentAuthorCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CommentAuthorCollection) osztályból). A szerzők megjegyzéseket adnak hozzá a diákhoz.
* A [CommentCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CommentCollection) osztály, amely egyes szerzőkhöz tartozó megjegyzések gyűjteményét tartalmazza.
* A [Comment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Comment) osztály, amely információkat tartalmaz a szerzőkről és a megjegyzéseikről: ki adta a megjegyzést, mikor adták hozzá, a megjegyzés pozíciója stb.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CommentAuthor) osztály, amely egyes szerzőkről tartalmaz információkat: a szerző neve, monogramja, a szerző nevéhez kapcsolódó megjegyzések stb.

## **Dia megjegyzés hozzáadása**
Ez a JavaScript kód megmutatja, hogyan adhat megjegyzést egy diához egy PowerPoint‑prezentációban:

```javascript
// Példányosítja a Presentation osztályt
var pres = new aspose.slides.Presentation();
try {
    // Üres diát ad hozzá
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Szerzőt ad hozzá
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Beállítja a megjegyzések pozícióját
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Megjegyzést ad egy szerzőnek az 1. dián
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Megjegyzést ad egy szerzőnek a 2. dián
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Eléri az ISlide 1-et
    var slide = pres.getSlides().get_Item(0);
    // Ha null értéket adunk át argumentumként, akkor az összes szerző megjegyzései megjelennek a kiválasztott dián
    var Comments = slide.getSlideComments(author);
    // Eléri az 1. dián a 0. indexű megjegyzést
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Kiválasztja a szerző 0. indexű megjegyzéseinek gyűjteményét
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dia megjegyzések elérése**
Ez a JavaScript kód megmutatja, hogyan érhető el egy meglévő megjegyzés egy dián egy PowerPoint‑prezentációban:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Megjegyzések válaszai**
A szülőmegjegyzés a hierarchia csúcsán vagy eredeti megjegyzése. A [getParentComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Comment#getParentComment--) vagy a [setParentComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) módszerek (a [Comment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Comment) osztályból) segítségével beállíthat vagy lekérhet egy szülőmegjegyzést.

Ez a JavaScript kód megmutatja, hogyan adhat megjegyzéseket, és hogyan kaphat válaszokat rájuk:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Megjegyzést ad hozzá
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Megjegyzés1-hez válasz hozzáadása
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Megjegyzés1-hez egy másik válasz hozzáadása
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Válasz hozzáadása egy meglévő válaszhoz
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Megjeleníti a megjegyzések hierarchiáját a konzolon
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Eltávolítja a megjegyzés1-et és az összes hozzá tartozó választ
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 

* Amikor a [Remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Comment#remove--) metódust (a [Comment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Comment) osztályból) használják egy megjegyzés törlésére, a megjegyzésre válaszok is törlődnek.
* Ha a [setParentComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) beállítása körkörös hivatkozást eredményez, [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PptxEditException) kivétel keletkezik.

{{% /alert %}}

## **Modern megjegyzés hozzáadása**

2021-ben a Microsoft bevezette a *modern megjegyzéseket* a PowerPointban. A modern megjegyzések jelentősen javítják az együttműködést a PowerPointban. A modern megjegyzésekkel a felhasználók megoldhatják a megjegyzéseket, rögzíthetik azokat objektumokhoz és szövegekhez, és sokkal egyszerűbben léphetnek interakcióba, mint korábban.

Az Aspose.Slides a [ModernComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ModernComment) osztállyal támogatja a modern megjegyzéseket. A [addModernComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) és az [insertModernComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) módszerek a [CommentCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CommentCollection) osztályhoz lettek hozzáadva.

Ez a JavaScript kód megmutatja, hogyan adhat modern megjegyzést egy diához egy PowerPoint‑prezentációban:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Megjegyzés eltávolítása**

### **Az összes megjegyzés és szerző törlése**

Ez a JavaScript kód megmutatja, hogyan távolíthatja el az összes megjegyzést és szerzőt egy prezentációból:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Törli a prezentáció összes megjegyzését
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Törli az összes szerzőt
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Kifejezett megjegyzések törlése**

Ez a JavaScript kód megmutatja, hogyan törölhet konkrét megjegyzéseket egy dián:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // megjegyzések hozzáadása...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // eltávolítja az összes "comment 1" szöveget tartalmazó megjegyzést
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **GYIK**

**Támogatja-e az Aspose.Slides a modern megjegyzések „megoldott” állapotát?**

Igen. A [Modern comments](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/) rendelkezik egy [getStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getstatus/) és egy [setStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/setStatus/) metódussal; olvashat és beállíthat egy [comment’s state](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncommentstatus/)‑et (például megjelölheti megoldottként), és ez az állapot a fájlban tárolódik, valamint a PowerPoint felismeri.

**Támogatottak-e a szálas megbeszélések (válaszláncok), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/getparentcomment/)‑re, lehetővé téve tetszőleges mélységű válaszláncokat. Az API nem határoz meg konkrét beágyazási mélységkorlátot.

**Milyen koordináta-rendszerben van meghatározva egy megjegyzésjelző pozíciója a dián?**

A pozíció lebegőpontos pontként van tárolva a dia koordináta‑rendszerében, ami lehetővé teszi, hogy a megjegyzésjelzőt pontosan oda helyezze, ahová szüksége van.