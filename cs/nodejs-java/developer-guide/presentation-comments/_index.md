---
title: Správa komentářů prezentací v Node.js
linktitle: Komentáře prezentace
type: docs
weight: 100
url: /cs/nodejs-java/presentation-comments/
keywords:
  - komentář
  - moderní komentář
  - komentáře PowerPoint
  - komentáře prezentace
  - komentáře snímku
  - přidat komentář
  - přístup ke komentáři
  - upravit komentář
  - odpovědět na komentář
  - odstranit komentář
  - smazat komentář
  - PowerPoint
  - prezentace
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Spravujte komentáře prezentací pomocí Aspose.Slides pro Node.js přes Java: přidávejte, čtěte, upravujte, odpovídejte na a odstraňujte komentáře v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře prezentace pomocí Aspose.Slides pro Node.js přes Java. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře recenzí a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení textu a metadat komentářů, vytváření řetězců odpovědí a odstraňování vybraných nebo všech komentářů.

V PowerPointu se komentáře objevují jako anotace na snímcích. Výběrem komentáře se zobrazí jeho text a související diskuse.

## **Proč přidávat komentáře do prezentací?**

Komentáře můžete použít k poskytování zpětné vazby a spolupráci s kolegy při recenzování prezentací.

Aspose.Slides pro Node.js přes Java poskytuje následující API pro práci s komentáři:

* Třída [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) poskytuje přístup k autorům komentářů v prezentaci.
* Třída [CommentCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/commentcollection/) představuje komentáře spojené s jednotlivým autorem.
* Třída [Comment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/comment/) poskytuje informace o komentáři, včetně jeho autora, času vytvoření, pozice a textu.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/commentauthor/) poskytuje informace o autorovi, včetně jeho jména, iniciál a přidružených komentářů.

## **Přidat komentáře ke snímkům**

Následující příklad ukazuje, jak přidat komentáře do snímků v PowerPointové prezentaci:

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

## **Přístup k komentářům na snímcích**

Následující příklad ukazuje, jak přistupovat k existujícím komentářům v PowerPointové prezentaci:

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

## **Odpovědět na komentáře**

Nadřazený komentář je původní komentář na vrcholu hierarchie odpovědí. Metody [Comment.getParentComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/comment/getparentcomment/) a [Comment.setParentComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/comment/setparentcomment/) vám umožňují získat nebo nastavit nadřazený komentář.

Následující příklad ukazuje, jak přidat odpovědi a prozkoumat vzniklou hierarchii komentářů:

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

{{% alert color="warning" title="Upozornění" %}}
* Když je metoda [Comment.remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/comment/remove/) použita ke smazání komentáře, všechny odpovědi na tento komentář jsou také smazány.
* Pokud [Comment.setParentComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/comment/setparentcomment/) vytvoří kruhový odkaz, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidat moderní komentáře**

Moderní komentáře mohou být asociovány přímo se snímkem, s konkrétním tvarem nebo s textovým rozsahem uvnitř [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/). Metoda [CommentCollection.addModernComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) přijímá argument [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) kromě snímku a souřadnic markeru komentáře.

Pokud je jako argument shape předáno `null`, jedná se o komentář na úrovni snímku. Jeho marker je umístěn pomocí dodaných souřadnic, ale není asociován s konkrétním tvarem, takže [ModernComment.getShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/getshape/) vrací `null`. Pokud je předán [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/), je komentář ukotven k tomuto tvaru. Souřadnice stále definují pozici markeru komentáře na snímku, zatímco asociaci s tvarem lze získat přes [ModernComment.getShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Ukotvit moderní komentář k tvaru**

Následující příklad vytvoří jak moderní komentář na úrovni snímku, tak moderní komentář ukotvený ke konkrétnímu [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/). Pak načte přidružený tvar z každého komentáře.

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

### **Ukotvit komentáře k různým typům tvarů**

Jakýkoli objekt snímku odvozený od [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) může být použit jako ukotvení tvaru. Běžné příklady zahrnují [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/connector/), a instance [GraphicalObject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/graphicalobject/) jako jsou grafy.

Následující příklad vytvoří několik běžných typů tvarů a přiřadí k nim moderní komentář.

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

### **Ukotvit komentář k textu a nastavit jeho stav**

Pro moderní komentář spojený s [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) a [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) přistupují k počáteční pozici vybraného textu v textovém rámci tvaru. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) a [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) přistupují k délce výběru. Společně tyto hodnoty spojují komentář s konkrétním textovým rozsahem uvnitř [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/).

Metody [ModernComment.getStatus](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/getstatus/) a [ModernComment.setStatus](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/setstatus/) přistupují k hodnotě z výčtu [ModernCommentStatus](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — není definován konkrétní stav moderního komentáře.
- `Active` — komentář je aktivní.
- `Resolved` — komentář byl vyřešen.
- `Closed` — komentář je uzavřen.

Následující příklad vytvoří moderní komentář ukotvený k tvaru, přiřadí jej k výběru textu, označí jej jako vyřešený, uloží prezentaci a ověří hodnoty po opětovném otevření souboru.

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

### **Prozkoumat existující moderní komentáře**

Aby bylo možné prozkoumat existující prezentaci, zjistěte, které komentáře jsou instance [ModernComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/), pak prozkoumejte [ModernComment.getShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) a [ModernComment.getStatus](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/getstatus/). `null` tvar označuje komentář na úrovni snímku. Pro ukotvení k [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) se metody výběru textu identifikují související rozsah v textovém rámci tvaru.

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

## **Odstranit komentáře**

### **Odstranit všechny komentáře a autory komentářů**

Následující příklad ukazuje, jak odstranit všechny komentáře a autory komentářů z prezentace:

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

### **Odstranit konkrétní komentáře**

Následující příklad ukazuje, jak odstranit konkrétní komentáře ze snímku:

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

## **Často kladené otázky**

**Podporuje Aspose.Slides stav vyřešen pro moderní komentáře?**

Ano. [ModernComment.getStatus](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/getstatus/) a [ModernComment.setStatus](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/setstatus/) přistupují k hodnotě [ModernCommentStatus](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncommentstatus/), včetně `Resolved`. Stav je uložen v prezentaci a může být znovu načten po opětovném otevření souboru.

**Jsou podporovány vláknové diskuse (řetězce odpovědí) a existuje omezení hloubky vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/comment/getparentcomment/), čímž umožňuje řetězce odpovědí. API nedefinuje konkrétní omezení hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice markeru komentáře na snímku?**

Pozice markeru je definována pomocí souřadnic s plovoucí desetinnou čárkou v souřadnicovém systému snímku, což vám umožňuje jej přesně umístit na snímek.