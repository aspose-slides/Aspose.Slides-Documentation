---
title: Správa komentářů v prezentaci v Javě
linktitle: Komentáře v prezentaci
type: docs
weight: 100
url: /cs/java/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře v prezentaci
- komentáře na snímcích
- přidat komentář
- přístup ke komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Spravujte komentáře v prezentacích pomocí Aspose.Slides pro Java: přidávejte, čtěte, upravujte, odpovídejte na a odstraňujte komentáře v PowerPointových prezentacích rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře v prezentaci pomocí Aspose.Slides pro Java. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revizí a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení textu komentáře a metadat, vytváření řetězců odpovědí a odstraňování vybraných nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako anotace na snímcích. Výběrem komentáře se zobrazí jeho text a související diskuse.

## **Proč přidávat komentáře do prezentací?**

Komentáře můžete použít k poskytnutí zpětné vazby a ke spolupráci s kolegy při revizi prezentací.

Aspose.Slides pro Java poskytuje následující API pro práci s komentáři:

* Třída [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), která umožňuje přístup k autorům komentářů v prezentaci.
* Rozhraní [ICommentCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icommentcollection/), které představuje komentáře přiřazené konkrétnímu autorovi.
* Rozhraní [IComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icomment/), které poskytuje informace o komentáři, včetně autora, času vytvoření, polohy a textu.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/commentauthor/), která poskytuje informace o autorovi, včetně jména, iniciál a přiřazených komentářů.

## **Přidání komentářů do snímků**

Následující příklad ukazuje, jak přidat komentáře do snímků v PowerPointové prezentaci:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    Point2D.Float position = new Point2D.Float(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přístup ke komentářům ve snímcích**

Následující příklad ukazuje, jak přistupovat k existujícím komentářům v PowerPointové prezentaci:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Odpovědi na komentáře**

Rodičovský komentář je původní komentář na vrcholu hierarchie odpovědí. Metody [IComment.getParentComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icomment/#getParentComment--) a [IComment.setParentComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) umožňují získat nebo nastavit rodiče komentáře.

Následující příklad ukazuje, jak přidat odpovědi a prozkoumat vzniklou hierarchii komentářů:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Point2D.Float position = new Point2D.Float(10, 10);
    Date createdTime = new Date();

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Varování" %}}
* Když je použita metoda [IComment.remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icomment/#remove--), jsou smazány i všechny odpovědi na tento komentář.
* Pokud metoda [IComment.setParentComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) vytvoří kruhovou referenci, je vyhozena výjimka [PptxEditException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidání moderních komentářů**

Moderní komentáře mohou být přiřazeny přímo ke snímku, konkrétnímu tvaru nebo textovému rozsahu uvnitř AutoShape. Metoda [ICommentCollection.addModernComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) přijímá argument [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) kromě snímku a souřadnic ukazatele komentáře.

Když je pro argument shape předáno `null`, jde o komentář úrovně snímku. Jeho ukazatel je umístěn podle zadaných souřadnic, ale není spojen s konkrétním tvarem, takže [IModernComment.getShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getShape--) vrací `null`. Když je předán [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), je komentář ukotven k tomuto tvaru. Souřadnice stále určují polohu ukazatele komentáře na snímku, zatímco asociaci s tvarem lze získat přes [IModernComment.getShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getShape--).

### **Ukotvení moderního komentáře k tvaru**

Následující příklad vytvoří jak moderní komentář úrovně snímku, tak moderní komentář ukotvený k určitému AutoShape. Poté načte přiřazený tvar z každého komentáře.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    Point2D.Float slideCommentPosition = new Point2D.Float(20, 20);
    Point2D.Float shapeCommentPosition = new Point2D.Float(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ukotvení komentářů k různým typům tvarů**

Jakýkoli objekt snímku, který implementuje [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), může být použit jako ukotvení tvaru. Běžné příklady zahrnují [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iconnector/) a instance [IGraphicalObject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igraphicalobject/) jako jsou grafy.

Následující příklad vytvoří několik běžných typů tvarů a přiřadí k nim moderní komentář.

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    Point2D.Float autoShapeCommentPosition = new Point2D.Float(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    Point2D.Float pictureCommentPosition = new Point2D.Float(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    Point2D.Float groupCommentPosition = new Point2D.Float(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    Point2D.Float connectorCommentPosition = new Point2D.Float(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    Point2D.Float chartCommentPosition = new Point2D.Float(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ukotvení komentáře k textu a nastavení jeho stavu**

Pro moderní komentář přiřazený k [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) poskytují metody [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) a [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) počáteční pozici vybraného textu v textovém rámci tvaru. Metody [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) a [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) přistupují k délce výběru. Společně tyto hodnoty přiřazují komentář konkrétnímu textovému rozsahu uvnitř AutoShape.

Metody [IModernComment.getStatus](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getStatus--) a [IModernComment.setStatus](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#setStatus-byte-) získávají hodnotu ze seznamu konstant [ModernCommentStatus](https://reference.aspose.com/slides/cs/java/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — není definován žádný konkrétní stav moderního komentáře.
- `Active` — komentář je aktivní.
- `Resolved` — komentář byl vyřešen.
- `Closed` — komentář je uzavřen.

Následující příklad vytvoří moderní komentář ukotvený k tvaru, přiřadí jej k výběru textu, označí jej jako vyřešený, uloží prezentaci a po opětovném otevření souboru ověří hodnoty.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Point2D.Float commentPosition = new Point2D.Float(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Prozkoumání existujících moderních komentářů**

Pro prozkoumání existující prezentace zjistěte, které komentáře implementují [IModernComment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/), pak prohlédněte [IModernComment.getShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) a [IModernComment.getStatus](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getStatus--). `null` tvar naznačuje komentář úrovně snímku. Pro ukotvení k [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) metody výběru textu identifikují přiřazený rozsah v textovém rámci tvaru.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Odstranění komentářů**

### **Odstranění všech komentářů a autorů komentářů**

Následující příklad ukazuje, jak odstranit všechny komentáře a autory komentářů z prezentace:

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Odstranění konkrétních komentářů**

Následující příklad ukazuje, jak odstranit konkrétní komentáře ze snímku:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    Point2D.Float firstCommentPosition = new Point2D.Float(0.2f, 0.2f);
    Point2D.Float secondCommentPosition = new Point2D.Float(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Podporuje Aspose.Slides stav vyřešeného moderního komentáře?**

Ano. Metody [IModernComment.getStatus](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#getStatus--) a [IModernComment.setStatus](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imoderncomment/#setStatus-byte-) přistupují k hodnotě [ModernCommentStatus](https://reference.aspose.com/slides/cs/java/com.aspose.slides/moderncommentstatus/), včetně `Resolved`. Stav je uložen v prezentaci a lze jej znovu přečíst po opětovném otevření souboru.

**Jsou podporovány vlákna diskusí (řetězce odpovědí) a existuje limit zanoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icomment/#getParentComment--), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky zanoření.

**V jakém souřadnicovém systému je určena pozice ukazatele komentáře na snímku?**

Pozice ukazatele je definována pomocí desetinných souřadnic v souřadnicovém systému snímku, což vám umožní jej přesně umístit na snímek.