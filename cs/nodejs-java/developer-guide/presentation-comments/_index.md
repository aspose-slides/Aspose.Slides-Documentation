---
title: Správa komentářů v prezentaci v JavaScriptu
linktitle: Komentáře prezentace
type: docs
weight: 100
url: /cs/nodejs-java/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPointu
- komentáře prezentace
- komentáře snímku
- přidat komentář
- přístup k komentáři
- upravit komentář
- odpověď na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Mistrovsky spravujte komentáře k prezentacím s Aspose.Slides pro Node.js: přidávejte, čtěte, upravujte a mažte komentáře v souborech PowerPoint pomocí JavaScriptu rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentacích v Aspose.Slides. Ukazuje hlavní typy související s komentáři a demonstruje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi, používat moderní komentáře a odstraňovat komentáře z prezentace.

Příklady se zaměřují na běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení obsahu a metadat komentářů, vytváření řetězců odpovědí a vymazání všech komentářů nebo smazání vybraných.

V PowerPointu se komentář zobrazuje jako poznámka nebo anotace na snímku. Po kliknutí na komentář se zobrazí jeho obsah nebo zprávy.

## **Proč přidávat komentáře do prezentací?**

Možná budete chtít použít komentáře k poskytnutí zpětné vazby nebo komunikaci s kolegy při revizi prezentací.

Aby vám umožnily používat komentáře v PowerPoint prezentacích, Aspose.Slides pro Node.js přes Java poskytuje
* Třída [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahuje kolekce autorů (z třídy [CommentAuthorCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/CommentAuthorCollection) ). Autoři přidávají komentáře do snímků.
* Třída [CommentCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/CommentCollection) obsahuje kolekci komentářů pro jednotlivé autory.
* Třída [Comment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Comment) obsahuje informace o autorech a jejich komentářích: kdo komentář přidal, čas přidání komentáře, pozice komentáře atd.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/CommentAuthor) obsahuje informace o jednotlivých autorech: jméno autora, jeho iniciály, komentáře spojené s jménem autora atd.

## **Přidat komentář ke snímku**
Tento JavaScriptový kód vám ukazuje, jak přidat komentář do snímku v PowerPoint prezentaci:

```javascript
// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Přidá prázdný snímek
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Přidá autora
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Nastaví pozici pro komentáře
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Přidá komentář ke snímku od autora na snímku 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Přidá komentář ke snímku od autora na snímku 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Přistupuje k ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Když je jako argument předáno null, jsou k vybranému snímku přineseny komentáře od všech autorů
    var Comments = slide.getSlideComments(author);
    // Přistupuje k komentáři na indexu 0 pro snímek 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Vybere kolekci komentářů autora na indexu 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přístup ke komentářům snímku**
Tento JavaScriptový kód vám ukazuje, jak přistupovat k existujícímu komentáři na snímku v PowerPoint prezentaci:

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

## **Odpovědi na komentáře**
Rodičovský komentář je nejvyšší nebo původní komentář v hierarchii komentářů či odpovědí. Pomocí metod [getParentComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Comment#getParentComment--) nebo [setParentComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (třídy [Comment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Comment)) můžete nastavit nebo získat rodičovský komentář.

Tento JavaScriptový kód vám ukazuje, jak přidávat komentáře a získávat odpovědi na ně:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá komentář
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Přidá odpověď na comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Přidá další odpověď na comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Přidá odpověď na existující odpověď
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Zobrazí hierarchii komentářů v konzoli
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
    // Odstraní comment1 a všechny odpovědi na něj
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 
* Když je metoda [Remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Comment#remove--) (třídy [Comment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Comment)) použita k smazání komentáře, jsou také smazány odpovědi na tento komentář.
* Pokud nastavení [setParentComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) vede k cyklickému odkazu, bude vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Přidat moderní komentář**

V roce 2021 společnost Microsoft představila *moderní komentáře* v PowerPointu. Funkce moderních komentářů výrazně zlepšuje spolupráci v PowerPointu. Prostřednictvím moderních komentářů mohou uživatelé PowerPointu řešit komentáře, připojovat komentáře k objektům a textům a mnohem snadněji se zapojit do interakcí než dříve. 

Aspose.Slides podporuje moderní komentáře pomocí třídy [ModernComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ModernComment). Metody [addModernComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) a [insertModernComment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) byly přidány do třídy [CommentCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/CommentCollection).

Tento JavaScriptový kód vám ukazuje, jak přidat moderní komentář do snímku v PowerPoint prezentaci:

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

## **Odstranit komentář**

### **Smazat všechny komentáře a autory**
Tento JavaScriptový kód vám ukazuje, jak odstranit všechny komentáře a autory v prezentaci:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Smaže všechny komentáře z prezentace
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Smaže všechny autory
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Smazat konkrétní komentáře**
Tento JavaScriptový kód vám ukazuje, jak smazat konkrétní komentáře na snímku:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // přidá komentáře...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // odstraní všechny komentáře, které obsahují text "comment 1"
    
    
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

## **Často kladené otázky**

**Podporuje Aspose.Slides stav jako „vyřešeno“ pro moderní komentáře?**

Ano. [Moderní komentáře](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/) poskytují metody [getStatus](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/getstatus/) a [setStatus](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncomment/setStatus/); můžete číst a nastavit [stav komentáře](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/moderncommentstatus/) (například jej označit jako vyřešený) a tento stav je uložen v souboru a rozpoznán PowerPointem.

**Jsou podporovány vlákna diskuzí (řetězce odpovědí) a existuje limit hloubky?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/comment/getparentcomment/), což umožňuje libovolné řetězce odpovědí. API neuvádí konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice je uložena jako desetinný bod v souřadnicovém systému snímku. To vám umožní umístit značku komentáře přesně tam, kde ji potřebujete.