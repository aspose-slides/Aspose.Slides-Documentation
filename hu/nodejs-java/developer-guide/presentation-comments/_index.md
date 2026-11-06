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
- megjegyzés megválaszolása
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Node.js via Java segítségével: megjegyzések hozzáadása, olvasása, szerkesztése, megválaszolása és eltávolítása PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a bemutatók megjegyzései az Aspose.Slides for Node.js via Java segítségével. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és demonstrálja, hogyan adhatunk megjegyzéseket a diákhoz, érhetjük el a meglévő megjegyzéseket, dolgozhatunk válaszokkal és modern megjegyzésekkel, valamint hogyan távolíthatók el a megjegyzések egy prezentációból.

A példák lefedik a PowerPointban gyakran előforduló felülvizsgálati és együttműködési forgatókönyveket, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, a válaszkötetek felépítését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti a szövegét és a kapcsolódó vitát.

To request that comments be shown or hidden when a presentation opens without changing the comments themselves, see [Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor](/slides/hu/nodejs-java/presentation-view-properties/).

## **Miért érdemes megjegyzéseket hozzáadni a prezentációkhoz?**

Az megjegyzésekkel visszajelzést adhat és együttműködhet kollégákkal a prezentációk felülvizsgálata során.

Az Aspose.Slides for Node.js via Java a következő API-kat biztosítja a megjegyzésekkel való munkához:
* A [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzés-szerzőihez.
* A [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) osztály, amely egy adott szerzőhöz kapcsolódó megjegyzéseket képviseli.
* A [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) osztály, amely információkat nyújt egy megjegyzésről, beleértve a szerzőjét, létrehozási idejét, pozícióját és szövegét.
* A [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) osztály, amely információkat nyújt egy szerzőről, beleértve a nevét, kezdőbetűit és a kapcsolódó megjegyzéseket.

## **Dia megjegyzések hozzáadása**

A példa két diát hoz létre, és regisztrál egy megjegyzés-szerzőt a [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) metódussal. Az [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) metódust használja, hogy minden diára egy megjegyzést helyezzen, majd a [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) metódussal lekéri az első dia megjegyzéseit az adott szerzőnek. A konzol kétszer jeleníti meg az első megjegyzés szövegét, demonstrálva a hozzáférést a dia és a szerző útján, és a mentett prezentáció mindkét megjegyzést tartalmazza.

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Megjegyzés-szerző megtalálása vagy létrehozása**

Ha egy automatizált felülvizsgálat ismételten feldolgozza ugyanazt a prezentációt, akkor az [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) által visszaadott gyűjteményben keressen, mielőtt szerzőt adna hozzá. A [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) a nevet és a kezdőbetűket egyaránt egyezteti, és a megfelelő szerzőket tartalmazó tömböt ad vissza, vagy egy üres tömböt, ha nincs egyezés. Ezzel szemben a [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) csak a név alapján keres, a kezdőbetűket figyelmen kívül hagyva. Az [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) metódus hívása olyan névvel és kezdőbetűkkel, amelyek már jelen vannak a gyűjteményben, kivételt dob.

A példához egy olyan prezentációfájl szükséges, amely legalább egy diát tartalmaz. Két átfutás során újra felhasználja az első megtalált szerzőt, vagy csak akkor hoz létre újat, ha az eredmény üres. Ha több egyezés van, a tömb első elemét választja ki, anélkül, hogy összevonná vagy eltávolítaná a többi szerzőt. Ezután a kiválasztott szerzőhöz meghívja az [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) metódust, és menti a prezentációt. A második átfutás megnyitja az első átfutás kimenetét, és megismétli a műveletet.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

A második átfutás egy újabb megjegyzést ad hozzá, anélkül, hogy új szerzőt hozna létre vagy eltávolítaná a meglévő megjegyzéseket. A végső fájl, `review_pass_2.pptx`, mindkét új megjegyzést tartalmazza az eredeti megjegyzésekkel együtt. Egy szerző újbóli felhasználása nem vezet megjegyzések deduplikálásához: a többszöri hozzáadás elkerülése érdekében a hozzáadás előtt külön duplikátum-keresést kell bevezetni.

## **Dia megjegyzések elérése**

A példa megnyit egy meglévő prezentációt, és beolvassa a [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) által visszaadott gyűjteményt. Minden szerzőnél végigiterál a [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) által visszaadott gyűjteményen, és kiírja a dia számát, a megjegyzés szövegét, a szerző nevét és a létrehozási időt. A bemeneti prezentációnak megjegyzéseket kell tartalmaznia, hogy a konzol kimenete megjelenjen.

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

## **Válaszok a megjegyzésekhez**

Az anyavégjegyzés a válaszhierarchia tetején lévő eredeti megjegyzés. A [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) és a [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) metódusok lehetővé teszik egy megjegyzés szülőjének lekérését vagy beállítását.

A példa két szerző megjegyzéseit hozza létre, és a [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) metódust használja a válaszok építéséhez, beleértve egy válasz másik válaszra. A `null` átadása a [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) metódusnak az összes szerző megjegyzéseit lekéri; a konzol minden bejegyzést a válaszhierarchiában betöltött mélységnek megfelelően behúz. A példa menti a teljes vitát, meghívja a [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) metódust az első gyökérmegjegyzésen, és egy második prezentációt ment, ahol az a megjegyzés és válaszai eltávolításra kerültek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Ha a [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) metódust használják egy megjegyzés törlésére, a megjegyzéshez tartozó összes válasz is törlésre kerül.
* Ha a [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) körkörös hivatkozást hoz létre, egy [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/) kivétel keletkezik.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

A modern megjegyzések a diával, egy adott alakzattal vagy egy AutoShape belüli szövegtartománnyal társíthatók. A [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) metódus egy [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) argumentumot is elfogad a dia és a megjegyzés-jelző koordináták mellett.

Ha a shape argumentumhoz `null` értéket adunk, a megjegyzés diaszintű megjegyzés lesz. A jelző a megadott koordinátákkal kerül elhelyezésre, de nincs konkrét alakzathoz társítva, ezért a [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) `null`-t ad vissza. Ha egy [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) van megadva, a megjegyzés arra az alakzatra lesz rögzítve. A koordináták továbbra is a megjegyzés-jelző pozícióját határozzák meg a dián, míg az alakzati kapcsolat a [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) metódussal kérdezhető le.

### **Modern megjegyzés rögzítése egy alakzatra**

A példa kétszer hívja a [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) metódust: egyszer egy `null` alakzattal diaszintű megjegyzéshez, és egyszer egy téglalappal, mint rögzítési pont. A [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) kiolvasása `true`-t írás ki a diaszintű megjegyzés null ellenőrzésére, és a `Revenue title`-t a rögzített megjegyzéshez. Mindkét megjegyzés a prezentációval együtt mentésre kerül.

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

### **Megjegyzések rögzítése különböző alakzat típusokhoz**

Bármely, a [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) osztályból származó diaobjektum használható alakzatrögzítésként. Gyakori példák a [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), a [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), a [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), a [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) és a [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) példányokra, például diagramokra.

A példa a [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) metódust használja, hogy egy megjegyzést társítson öt különböző alakzattípushoz: egy AutoShape-hoz, egy képkockához, egy csoporthoz, egy csatlóshoz és egy diagramhoz. A kép beágyazott képadatot használ, így nincs szükség külső képre. Minden megjegyzésnek saját jelzőpozíciója van, és a mentett prezentáció megtartja az öt alakzati kapcsolatot.

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

Egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) számára társított modern megjegyzésnél a [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) és a [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) a szövegrész kezdeti pozíciójához fér hozzá az alakzat szövegdobozában. A [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) és a [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) a kiválasztás hosszát adja. Együtt ezek az értékek a megjegyzést egy konkrét szövegtartományhoz kapcsolják az AutoShape-on belül.

A [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) értékéhez férnek hozzá:

- `NotDefined` — nincs meghatározott modern megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

A példa egy modern megjegyzést rögzít a "quarterly revenue" szavakhoz egy téglalap szövegében. Számítja a nullától induló kiválasztás kezdetét a szövegből, és átadja a [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) metódusnak, majd a [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) segítségével beállítja a kiválasztott karakterek számát. A [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) `Resolved` értékkel való hívása után menti és újra megnyitja a prezentációt. A négy konzol-ellenőrzésnek mind `true`-t kell kiírnia, megerősítve, hogy az alakzati rögzítés, a szövegtartomány és az állapot megmaradt.

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

### **Meglévő modern megjegyzések ellenőrzése**

A példa egy modern megjegyzéseket tartalmazó meglévő prezentációt igényel, és kiírja azok szövegét, állapotát és rögzítési részleteit. Az ellenőrzéshez nézze meg, mely megjegyzések példányai a [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) osztálynak, majd vizsgálja meg a [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), a [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), a [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) és a [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) metódusokat. A `null` alakzat egy diaszintű megjegyzést jelöl. Egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) rögzítése esetén a szövegkiválasztási metódusok meghatározzák a kapcsolódó tartományt az alakzat szövegdobozában.

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

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy egy prezentációból eltávolítsa az összes megjegyzést és azok szerzőit, vagy csak a kiválasztott megjegyzéseket törölje, miközben a többit megtartja. A következő példák mindkét megközelítést bemutatják, és elmentik a frissített prezentációt.

### **Minden megjegyzés és a megjegyzés-szerzők eltávolítása**

A példa megnyit egy meglévő prezentációt, és minden szerzőnél meghívja a [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) metódust, majd a [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) metódussal eltávolítja magukat a szerzőket. A mentett prezentáció sem megjegyzéseket, sem megjegyzés-szerzőket nem tartalmaz. Egy megjegyzéseket tartalmazó prezentációval figyelheti meg az eltávolítást.

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

A példa egy dián két megjegyzést hoz létre, és a [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) metódust használja a szerzők szerint történő megjegyzések keresésére. Összegyűjti azokat a megjegyzéseket, amelyek szövege "comment 1", mielőtt meghívná a [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/) metódust, elkerülve a gyűjtemény módosítását a kiválasztás közben. A mentett prezentáció csak a "comment 2"-t tartja meg.

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

**Támogatja az Aspose.Slides a megoldott állapotot a modern megjegyzéseknél?**

Igen. A [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) és a [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) a [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) értékéhez fér hozzá, beleértve a `Resolved`-et is. Az állapot a prezentációban tárolódik, és a fájl újranyitása után újból lekérhető.

**Támogatottak a szálas viták (válaszkötetek), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [szülő megjegyzés](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) elemre, lehetővé téve a válaszköteteket. Az API nem definiál konkrét beágyazási mélységkorlátot.

**Milyen koordináta-rendszerben van definiálva egy megjegyzés-jelző pozíciója a dián?**

A jelző pozíciója lebegőpontos koordinátákkal van definiálva a dia koordináta-rendszerében, lehetővé téve a pontos elhelyezést a dián.