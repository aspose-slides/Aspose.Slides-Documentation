---
title: Správa komentářů prezentace v Node.js
linktitle: Komentáře prezentace
type: docs
weight: 100
url: /cs/nodejs-java/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímků
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
description: "Spravujte komentáře v prezentacích pomocí Aspose.Slides pro Node.js přes Java: přidávejte, čtěte, upravujte, odpovídejte a odstraňujte komentáře v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentacích pomocí Aspose.Slides pro Node.js přes Java. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení textu a metadat komentáře, vytváření řetězců odpovědí a odstraňování vybraných nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako anotace na snímcích. Výběrem komentáře se zobrazí jeho text a související diskuse.

Chcete-li požádat, aby se při otevření prezentace komentáře zobrazily nebo skryly, aniž byste měnili samotné komentáře, viz [Zobrazit nebo skrýt komentáře při otevření prezentace](/slides/cs/nodejs-java/presentation-view-properties/).

## **Proč přidávat komentáře do prezentací?**

Komentáře můžete použít k poskytnutí zpětné vazby a ke spolupráci s kolegy při revizi prezentací.

Aspose.Slides pro Node.js přes Java poskytuje následující rozhraní API pro práci s komentáři:

* Třída [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) poskytuje přístup k autorům komentářů prezentace.
* Třída [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) představuje komentáře spojené s konkrétním autorem.
* Třída [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) poskytuje informace o komentáři, včetně jeho autora, času vytvoření, pozice a textu.
* Třída [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) poskytuje informace o autorovi, včetně jeho jména, iniciál a souvisejících komentářů.

## **Přidání komentářů ke snímkům**

Příklad vytvoří dva snímky a zaregistruje autora komentáře pomocí [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). Použije [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/), aby umístil jeden komentář na každý snímek, poté získá komentáře prvního snímku pro tohoto autora pomocí [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). Konzole zobrazí text prvního komentáře dvakrát, což demonstruje přístup jak přes snímek, tak přes autora, a uložená prezentace obsahuje oba komentáře.

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

## **Najít nebo vytvořit autora komentáře**

Když automatizovaná revize opakovaně zpracovává stejnou prezentaci, vyhledejte v kolekci vrácené metodou [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) před přidáním autora. Metoda [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) porovná jak jméno, tak iniciály a vrátí pole odpovídajících autorů, nebo prázdné pole, pokud žádná shoda neexistuje. Oproti tomu [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) vyhledává pouze podle jména, nezávisle na iniciálách. Volání [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) s jménem a iniciálami, které již v kolekci existují, vyvolá výjimku.

Příklad vyžaduje soubor prezentace s alespoň jedním snímkem. V každém ze dvou průchodů znovu použije prvního odpovídajícího autora, nebo vytvoří nového pouze v případě, že je výsledek prázdný. Pokud existuje více shod, vybere první prvek pole bez sloučení nebo odstranění ostatních autorů. Poté zavolá [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) pro vybraného autora a uloží prezentaci. Druhý průchod otevře výstup z prvního průchodu a operaci zopakuje.

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

Druhý průchod přidá další komentář, aniž by přidal dalšího autora nebo odstraňoval existující komentáře. Konečný soubor `review_pass_2.pptx` obsahuje oba nové komentáře spolu s případnými původními komentáři. Opětovné použití autora neodstraňuje duplicitní komentáře: abyste se vyhnuli opakovanému přidávání stejných komentářů, implementujte samostatnou detekci duplicit před jejich přidáním.

## **Přístup ke komentářům snímků**

Příklad otevře existující prezentaci a načte kolekci vrácenou metodou [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). Pro každého autora prochází kolekci vrácenou metodou [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) a vypisuje číslo snímku, text komentáře, jméno autora a čas vytvoření. Vstupní prezentace musí obsahovat komentáře, aby se vygeneroval výstup do konzole.

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

## **Odpovídání na komentáře**

Rodičovský komentář je původní komentář na vrcholu hierarchie odpovědí. Metody [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) a [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) vám umožňují získat nebo nastavit rodiče komentáře.

Příklad vytvoří komentáře od dvou autorů a použije [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) k vytvoření odpovědí, včetně odpovědi na další odpověď. Předáním `null` do [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) se získají komentáře od všech autorů; konzole odsazuje každou položku podle její hloubky v hierarchii odpovědí. Příklad uloží kompletní diskusi, zavolá [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) na první kořenový komentář a uloží druhou prezentaci, ve které je tento komentář a jeho odpovědi odstraněny.

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
* Pokud je metoda [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) použita k smazání komentáře, všechny odpovědi na tento komentář jsou také smazány.
* Pokud metoda [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) vytvoří kruhovou referenci, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidání moderních komentářů**

Moderní komentáře mohou být přiřazeny přímo ke snímku, ke konkrétnímu tvaru nebo k textovému rozsahu uvnitř AutoShape. Metoda [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) přijímá jako argument [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) kromě parametrů snímku a souřadnic značky komentáře.

Když je pro argument shape předáno `null`, komentář je na úrovni snímku. Jeho značka je umístěna podle zadaných souřadnic, ale není spojena s konkrétním tvarem, takže [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) vrací `null`. Když je poskytnut objekt [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), komentář je ukotven k tomuto tvaru. Souřadnice i nadále určují pozici značky komentáře na snímku, zatímco přiřazení tvaru lze získat pomocí [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Ukotvení moderního komentáře k tvaru**

Příklad volá [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) dvakrát: jednou s tvarem `null` pro komentář na úrovni snímku a podruhé s obdélníkem jako ukotvením. Čtení [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) vypíše `true` pro kontrolu null u komentáře na úrovni snímku a `Revenue title` pro ukotvený komentář. Oba komentáře jsou uloženy spolu s prezentací.

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

### **Ukotvení komentářů k různým typům tvarů**

Jakýkoli objekt snímku odvozený od [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) může být použit jako ukotvení tvaru. Běžné příklady zahrnují [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) a instance [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) jako jsou grafy.

Příklad používá [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) k přiřazení komentáře k pěti typům tvarů: AutoShape, rámečku obrázku, skupině, spojnici a grafu. Obrázek používá vložená data obrázku, takže není potřeba externí obrázek. Každý komentář má vlastní pozici značky a uložená prezentace zachovává všech pět ukotvení tvarů.

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

### **Ukotvení komentáře k textu a nastavení jeho stavu**

Pro moderní komentář přiřazený k [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) metody [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) a [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) získávají počáteční pozici vybraného textu v textovém rámci tvaru. Metody [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) a [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) získávají délku výběru. Společně tyto hodnoty spojují komentář s konkrétním textovým rozsahem uvnitř AutoShape.

Metody [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) a [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) přistupují k hodnotě [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) :

- `NotDefined` — není definován žádný konkrétní stav moderního komentáře.
- `Active` — komentář je aktivní.
- `Resolved` — komentář byl vyřešen.
- `Closed` — komentář je uzavřen.

Příklad ukotví moderní komentář ke slovům „quarterly revenue“ v textu obdélníku. Vypočítá nulový index počátku výběru z textu a předá jej metodě [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) a použije [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) k nastavení počtu vybraných znaků. Po zavolání [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) s hodnotou `Resolved` prezentaci uloží a znovu otevře. Čtyři kontroly v konzoli by měly každá vypsat `true`, což potvrzuje, že ukotvení tvaru, textový rozsah a stav byly zachovány.

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

### **Prozkoumání existujících moderních komentářů**

Příklad vyžaduje existující prezentaci obsahující moderní komentáře a vypisuje jejich text, stav a podrobnosti o ukotvení. Pro jejich prozkoumání zkontrolujte, které komentáře jsou instance [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/), poté prozkoumejte [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) a [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). `null` tvar indikuje komentář na úrovni snímku. Pro ukotvení k [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) metody výběru textu určí související rozsah v textovém rámci tvaru.

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

## **Odstranění komentářů**

Aspose.Slides pro Node.js přes Java vám umožňuje odstranit všechny komentáře a jejich autory z prezentace nebo smazat vybrané komentáře při zachování ostatních. Následující příklady ukazují oba přístupy a ukládají aktualizovanou prezentaci.

### **Odstranění všech komentářů a autorů komentářů**

Příklad otevře existující prezentaci a pro každého autora zavolá [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/), poté zavolá [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) k odstranění samotných autorů. Uložená prezentace neobsahuje ani komentáře, ani autory komentářů. Použijte prezentaci obsahující komentáře, abyste viděli odstranění.

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

### **Odstranění konkrétních komentářů**

Příklad vytvoří dva komentáře na jednom snímku a použije [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) k nalezení komentářů od každého autora. Shromáždí komentáře, jejichž text se rovná „comment 1“, před voláním [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/), čímž se vyhne změnám kolekce během výběru. Uložená prezentace zachová pouze „comment 2“.

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

**Podporuje Aspose.Slides stav „vyřešeno“ pro moderní komentáře?**

Ano. Metody [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) a [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) přistupují k hodnotě [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/), včetně `Resolved`. Stav je uložen v prezentaci a lze jej po opětovném otevření souboru znovu načíst.

**Jsou podporována vlákna diskusí (řetězce odpovědí) a existuje omezení hloubky vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je na snímku definována pozice značky komentáře?**

Pozice značky je definována desetinnými souřadnicemi v souřadnicovém systému snímku, což vám umožňuje ji přesně umístit na snímek.