---
title: "Node.js-ben a bemutató megjegyzéseinek kezelése"
linktitle: "Bemutató megjegyzések"
type: docs
weight: 100
url: /hu/nodejs-java/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- bemutató megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "A Aspose.Slides for Node.js via Java segítségével bemutató megjegyzések kezelése: megjegyzések hozzáadása, olvasása, szerkesztése, válaszadás és eltávolítása PowerPoint bemutatókban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhető a bemutató megjegyzései az Aspose.Slides for Node.js via Java segítségével. Ismerteti a megjegyzésekkel kapcsolatos fő típusokat, és bemutatja, hogyan adhatunk megjegyzéseket a diákhoz, hogyan érhetjük el a meglévő megjegyzéseket, hogyan dolgozhatunk válaszokkal és modern megjegyzésekkel, illetve hogyan távolíthatjuk el a megjegyzéseket a bemutatóból.

A példák lefedik a PowerPoint tipikus felülvizsgálati és együttműködési forgatókönyveit, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, válaszláncok építését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti a szövegét és a kapcsolódó beszélgetést.

## **Miért adjunk megjegyzéseket a bemutatókhoz?**

A megjegyzéseket felhasználhatja visszajelzés adására és a kollégákkal való együttműködésre a bemutatók áttekintése során.

Az Aspose.Slides for Node.js via Java a következő API-kat biztosítja a megjegyzésekkel való munkához:

* A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a bemutató megjegyzés‑szerzőihez.
* A [CommentCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commentcollection/) osztály, amely egy adott szerzőhöz tartozó megjegyzéseket képviseli.
* A [Comment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/) osztály, amely információkat ad egy megjegyzésről, többek között a szerzőjéről, létrehozási időről, pozícióról és a szövegről.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commentauthor/) osztály, amely információkat ad egy szerzőről, többek között a nevéről, monogramjáról és az ahhoz tartozó megjegyzésekről.

## **Dia‑megjegyzések hozzáadása**

Az alábbi példa bemutatja, hogyan adhatunk megjegyzéseket a diákhoz egy PowerPoint‑bemutatóban:

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

## **Dia‑megjegyzések elérése**

Az alábbi példa bemutatja, hogyan érhetők el a meglévő megjegyzések egy PowerPoint‑bemutatóban:

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

## **Megjegyzésekre válaszolás**

Egy szülő megjegyzés a válasz‑hierarchia tetején lévő eredeti megjegyzés. A [Comment.getParentComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/getparentcomment/) és a [Comment.setParentComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/setparentcomment/) metódusok lehetővé teszik a szülő megjegyzés lekérését vagy beállítását.

Az alábbi példa bemutatja, hogyan adhatunk válaszokat, és hogyan vizsgálhatjuk meg a kapott megjegyzés‑hierarchiát:

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

* Amikor a [Comment.remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/remove/) metódust használják egy megjegyzés törlésére, a megjegyzés minden válasza is törlésre kerül.
* Ha a [Comment.setParentComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/setparentcomment/) körkörös hivatkozást hoz létre, egy [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxeditexception/) kerül dobásra.

{{% /alert %}}

## **Modern megjegyzések hozzáadása**

Modern megjegyzések társíthatók a diára, egy konkrét alakzatra, vagy egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) szövegtartományához. A [CommentCollection.addModernComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) metódus egy [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) argumentumot is elfogad a dián és a megjegyzés‑jelző koordináták mellett.

Ha a shape argumentum `null` értékkel kerül átadásra, a megjegyzés diaszintű megjegyzés lesz. Jelzőjét a megadott koordináták határozzák meg, de nem kapcsolódik egy adott alakzathoz, ezért a [ModernComment.getShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getshape/) `null`‑t ad vissza. Ha egy [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) kerül megadásra, a megjegyzés ahhoz az alakzathoz lesz rögzítve. A koordináták továbbra is a megjegyzés jelzőjének pozícióját határozzák meg a dián, míg az alakzati kapcsolat a [ModernComment.getShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getshape/) segítségével lekérhető.

### **Modern megjegyzés rögzítése egy alakzatra**

Az alábbi példa egy diaszintű modern megjegyzést és egy konkrét [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑re rögzített modern megjegyzést hoz létre, majd kiolvassa mindkét megjegyzéshez kapcsolódó alakzatot.

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

### **Megjegyzések rögzítése különböző alakzat‑típusokra**

Bármely, a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/)‑ből származó diaobjektum használható alakzat‑rögzítési pontként. Gyakori példák a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/), a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/), a [GroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/groupshape/), a [Connector](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/) és a [GraphicalObject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/graphicalobject/) példányok, például diagramok.

Az alábbi példa több gyakori alakzat‑típust hoz létre, és mindegyikhez modern megjegyzést társít.

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

### **Megjegyzés rögzítése szövegre és állapotának beállítása**

Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑hez társított modern megjegyzés esetén a [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) és a [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) a kiválasztott szöveg kezdőpozícióját adja vissza az alakzat szövegtáblájában. A [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) és a [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) a kijelölés hosszát adja vissza. Ezek az értékek együtt az megjegyzést egy konkrét szövegtartományhoz kötik az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑ben.

A [ModernComment.getStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment.setStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/setstatus/) metódusok egy értéket adnak vissza a [ModernCommentStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncommentstatus/) felsorolásból:

- `NotDefined` – nincs definiálva konkrét modern‑megjelzési állapot.
- `Active` – a megjegyzés aktív.
- `Resolved` – a megjegyzés megoldott.
- `Closed` – a megjegyzés lezárt.

Az alábbi példa egy alakzatra rögzített modern megjegyzést hoz létre, szövegjelöléshez társítja, megoldottként jelöli, elmenti a bemutatót, majd a fájl újbóli megnyitása után ellenőrzi az értékeket.

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

Egy meglévő bemutató vizsgálatához ellenőrizze, mely megjegyzések [ModernComment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/) példányok, majd tekintse meg a [ModernComment.getShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getshape/), a [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), a [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) és a [ModernComment.getStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getstatus/) eredményeit. Egy `null` alakzat diaszintű megjegyzést jelent. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) rögzítés esetén a szövegkijelölés‑metódusok az alakzat szövegtáblájában lévő tartományt azonosítják.

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

### **Minden megjegyzés és megjegyzés‑szerző eltávolítása**

Az alábbi példa bemutatja, hogyan lehet eltávolítani az összes megjegyzést és megjegyzés‑szerzőt egy bemutatóból:

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

### **Külön meghatározott megjegyzések eltávolítása**

Az alábbi példa bemutatja, hogyan lehet egy diáról konkrét megjegyzéseket eltávolítani:

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

**Támogatja-e az Aspose.Slides a modern megjegyzések megoldott állapotát?**

Igen. A [ModernComment.getStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment.setStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncomment/setstatus/) egy [ModernCommentStatus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/moderncommentstatus/) értéket ad vissza, beleértve a `Resolved` állapotot. Az állapot a bemutatóban tárolódik, és a fájl újbóli megnyitása után újra kiolvasható.

**Támogatottak-e a szálas beszélgetések (válasz‑láncok), és van‑e beágyazási limit?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/comment/getparentcomment/)-ra, lehetővé téve a válasz‑láncokat. Az API nem definiál konkrét beágyazási mélység‑limitet.

**Milyen koordináta‑rendszerben van definiálva egy megjegyzés‑jelző pozíciója a dián?**

A jelző pozíciója lebegőpontos koordinátákkal van megadva a dia koordináta‑rendszerében, ami lehetővé teszi a pontos elhelyezést a dián.