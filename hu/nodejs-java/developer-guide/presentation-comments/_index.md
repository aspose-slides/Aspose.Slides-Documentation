---
title: Prezentációs megjegyzések kezelése Node.js-ben
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
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Node.js via Java segítségével: megjegyzések hozzáadása, olvasása, szerkesztése, válaszolás és eltávolítása PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentáció megjegyzései az Aspose.Slides for Node.js via Java segítségével. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és megmutatja, hogyan lehet megjegyzéseket hozzáadni a diákhoz, meglévő megjegyzéseket elérni, válaszokkal és modern megjegyzésekkel dolgozni, illetve megjegyzéseket eltávolítani egy prezentációból.

A példák a PowerPointban gyakori felülvizsgálati és együttműködési helyzeteket fedik le, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, a válaszkötetek építését, valamint a kijelölt vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti a szövegét és a kapcsolódó beszélgetést.

A megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor: [Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor](/slides/hu/nodejs-java/presentation-view-properties/).

## **Miért érdemes megjegyzéseket hozzáadni a prezentációkhoz?**

A megjegyzéseket felhasználhatja visszajelzés adására és együttműködésre a kollégákkal a prezentációk áttekintése során.

Az Aspose.Slides for Node.js via Java a következő API-kat biztosítja a megjegyzésekkel való munkahoz:

* A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzés szerzőihez.
* A [CommentCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commentcollection/) osztály, amely egy adott szerzőhöz tartozó megjegyzéseket képviseli.
* A [Comment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/) osztály, amely információkat nyújt egy megjegyzésről, beleértve a szerzőt, a létrehozási időt, a pozíciót és a szöveget.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commentauthor/) osztály, amely információkat ad egy szerzőről, beleértve a nevüket, a monogramot és a kapcsolódó megjegyzéseket.

## **Diák megjegyzéseinek hozzáadása**

Az alábbi példa bemutatja, hogyan adhatunk megjegyzéseket a diákhoz egy PowerPoint prezentációban:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diák megjegyzéseinek elérése**

Az alábbi példa bemutatja, hogyan érhetjük el a meglévő megjegyzéseket egy PowerPoint prezentációban:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Megjegyzésekre válasz**

A szülő megjegyzés az eredeti megjegyzés a válaszhierarchia csúcsán. A [Comment.getParentComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/getparentcomment/) és a [Comment.setParentComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/setparentcomment/) metódusok lehetővé teszik a megjegyzés szülőjének lekérését vagy beállítását.

Az alábbi példa bemutatja, hogyan adhatunk válaszokat, és hogyan vizsgálhatjuk meg a keletkezett megjegyzési hierarchiát:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Ha a [Comment.remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/remove/) metódust használják egy megjegyzés törlésére, a megjegyzéshez tartozó összes válasz is törlődik.
* Ha a [Comment.setParentComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/setparentcomment/) körkörös hivatkozást hoz létre, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxeditexception/) kivétel kerül dobásra.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

Modern megjegyzések kapcsolhatók a diádhoz, egy adott alakzathoz vagy egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) szövegtartományához. A [CommentCollection.addModernComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) metódus egy [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) argumentumot is elfogad a dia és a megjegyzés jelző koordinátái mellett.

Ha a `null` értéket adjuk meg a shape argumentumnak, a megjegyzés dia‑szintű megjegyzés lesz. Jelzője a megadott koordináták alapján helyezkedik el, de nincs hozzákapcsolva konkrét alakzathoz, ezért a [ModernComment.getShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getshape/) `null`‑t ad vissza. Ha egy [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) kerül megadásra, a megjegyzés ehhez az alakzathoz lesz rögzítve. A koordináták továbbra is a megjegyzés jelző pozícióját határozzák meg a dián, míg az alakzathoz való kötést a [ModernComment.getShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getshape/) lekérdezésével nyerhetjük ki.

### **Modern megjegyzés rögzítése alakzatra**

Az alábbi példa létrehoz egy dia‑szintű modern megjegyzést és egy adott [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) alakzatra rögzített modern megjegyzést. Ezután mindkét megjegyzéshez tartozó alakzatot kiolvassa.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Megjegyzések rögzítése különböző alakzat típusokra**

Bármely, a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) osztályból származó dia‑objektum használható alakzatra való rögzítéshez. Gyakori példák: [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/) és [GraphicalObject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/graphicalobject/) például diagramok.

Az alábbi példa több gyakori alakzattípust hoz létre, és mindegyikhez modern megjegyzést rendel.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Megjegyzés rögzítése szöveghez és állapotának beállítása**

Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)-hez kapcsolódó modern megjegyzés esetén a [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) és a [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) a szövegkeretben kiválasztott szöveg kezdőpozícióját adja meg. A [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) és a [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) a kijelölés hosszát adja meg. Ezekkel az értékekkel a megjegyzés egy konkrét szövegtartományhoz kapcsolódik az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)-ben.

A [ModernComment.getStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment.setStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/setstatus/) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncommentstatus/) felsorolásból egy értéket adnak vissza:

- `NotDefined` — nincs meghatározott modern megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

Az alábbi példa létrehoz egy alakzatra rögzített modern megjegyzést, szövegválasztáshoz kapcsolja, megoldottként jelöli, elmenti a prezentációt, majd a fájl újbóli megnyitása után ellenőrzi az értékeket.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Meglévő modern megjegyzések vizsgálata**

Egy meglévő prezentáció vizsgálatához ellenőrizze, mely megjegyzések [ModernComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/) példányok, majd tekintse meg a [ModernComment.getShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) és [ModernComment.getStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getstatus/) értékeket. A `null` alakzat dia‑szintű megjegyzést jelez. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) horgonynál a szövegkiválasztási metódusok az alakzat szövegtáblájában lévő tartományt azonosítják.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Megjegyzések eltávolítása**

### **Minden megjegyzés és megjegyzés szerző eltávolítása**

Az alábbi példa bemutatja, hogyan lehet eltávolítani minden megjegyzést és megjegyzés szerzőt egy prezentációból:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Specifikus megjegyzések eltávolítása**

Az alábbi példa bemutatja, hogyan lehet specifikus megjegyzéseket eltávolítani egy diáról:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Támogatja az Aspose.Slides a megoldott állapotot a modern megjegyzésekhez?**

Igen. A [ModernComment.getStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment.setStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/setstatus/) egy [ModernCommentStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncommentstatus/) értéket ad vissza, többek között a `Resolved` állapotot. Az állapot a prezentációban tárolódik, és a fájl újra megnyitása után ismét beolvasható.

**Támogatottak a szálas megbeszélések (válaszkötetek), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [szülő megjegyzésére](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/getparentcomment/), ami lehetővé teszi a válaszköteteket. Az API nem határoz meg konkrét beágyazási mélység‑korlátot.

**Milyen koordináta‑rendszerben van meghatározva a megjegyzés jelző pozíciója a dián?**

A jelző pozíciója lebegőpontos koordinátákkal van definiálva a dia koordináta‑rendszerében, lehetővé téve a pontos elhelyezést a dián.