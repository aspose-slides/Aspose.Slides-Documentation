---
title: "Prezentációs megjegyzések kezelése Java-ban"
linktitle: "Prezentációs megjegyzések"
type: docs
weight: 100
url: /hu/java/presentation-comments/
keywords:
- "megjegyzés"
- "modern megjegyzés"
- "PowerPoint megjegyzések"
- "prezentációs megjegyzések"
- "dia megjegyzések"
- "megjegyzés hozzáadása"
- "megjegyzés elérése"
- "megjegyzés szerkesztése"
- "megjegyzésre válasz"
- "megjegyzés eltávolítása"
- "megjegyzés törlése"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Java segítségével: gyorsan és egyszerűen adjon hozzá, olvasson, szerkesszen, válaszoljon, és távolítson el megjegyzéseket a PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentáció megjegyzései az Aspose.Slides for Java használatával. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és demonstrálja, hogyan lehet megjegyzéseket hozzáadni a diákhoz, meglévő megjegyzéseket elérni, válaszokkal és modern megjegyzésekkel dolgozni, valamint megjegyzéseket eltávolítani egy prezentációból.

A példák lefedik a PowerPointban előforduló gyakori felülvizsgálati és együttműködési helyzeteket, például a megjegyzések szerzőkhöz való hozzárendelését, a megjegyzés szövegének és metaadatainak olvasását, válaszképek építését, valamint kiválasztott vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti a szövegét és a kapcsolódó beszélgetést.

## **Miért Adjunk Megjegyzéseket a Prezentációkhoz?**

A megjegyzéseket visszajelzés nyújtására és a kollégákkal való együttműködésre használhatja a prezentációk felülvizsgálata során.

Az Aspose.Slides for Java a következő API-kat biztosítja a megjegyzésekkel való munkához:
* A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzés szerzőihez.
* Az [ICommentCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icommentcollection/) interfész, amely egy adott szerzőhöz tartozó megjegyzéseket képviseli.
* Az [IComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icomment/) interfész, amely információt nyújt egy megjegyzésről, beleértve a szerzőjét, létrehozási időt, pozíciót és szöveget.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/commentauthor/) osztály, amely információt ad egy szerzőről, beleértve a nevét, monogramját és a kapcsolódó megjegyzéseket.

## **Dia Megjegyzések Hozzáadása**

Az alábbi példa bemutatja, hogyan adhat megjegyzéseket a diákhoz egy PowerPoint prezentációban:

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

## **Dia Megjegyzések Elérése**

Az alábbi példa bemutatja, hogyan érheti el a meglévő megjegyzéseket egy PowerPoint prezentációban:

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

## **Válasz a Megjegyzésekre**

A szülő megjegyzés az eredeti megjegyzés a válaszhierarchia tetején. Az [IComment.getParentComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icomment/#getParentComment--) és az [IComment.setParentComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) metódusok lehetővé teszik a megjegyzés szülőjének lekérését vagy beállítását.

Az alábbi példa bemutatja, hogyan adhat hozzá válaszokat, és hogyan vizsgálhatja meg a resulting megjegyzés hierarchiát:

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

{{% alert color="warning" title="Warning" %}}
* Amikor az [IComment.remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icomment/#remove--) metódust használják egy megjegyzés törlésére, a megjegyzéshez tartozó összes válasz is törlődik.
* Ha az [IComment.setParentComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) körkörös hivatkozást hoz létre, egy [PptxEditException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pptxeditexception/) lesz dobva.
{{% /alert %}}

## **Modern Megjegyzések Hozzáadása**

A modern megjegyzések a diával, egy konkrét alakzattal vagy egy AutoShape belüli szövegtartománnyal társíthatók. Az [ICommentCollection.addModernComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) metódus egy [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) argumentumot is elfogad a dia és a megjegyzésjelző koordinátákon kívül.

Ha a shape argumentumnak `null` értéket adunk, a megjegyzés diaszintű megjegyzés lesz. Jelzője a megadott koordináták alapján helyezkedik el, de nem kapcsolódik konkrét alakzathoz, így az [IModernComment.getShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getShape--) `null`-t ad vissza. Ha egy [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) kerül megadásra, a megjegyzés erre az alakzatra lesz rögzítve. A koordináták továbbra is a megjegyzésjelző helyét határozzák meg a dián, míg az alakzatkapcsolat a [IModernComment.getShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getShape--) segítségével kérhető le.

### **Modern Megjegyzés Rögzítése egy Alakzatra**

Az alábbi példa létrehoz egy diaszintű modern megjegyzést és egy konkrét AutoShape-hez rögzített modern megjegyzést is. Ezután minden megjegyzéshez kiolvassa a kapcsolódó alakzatot.

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

### **Megjegyzések Rögzítése Különböző Alakzattípusokhoz**

Bármely diakép, amely megvalósítja az [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfészt, használható alakzatankerületi horgonyként. Gyakori példák a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iconnector/) és a diagramokhoz hasonló [IGraphicalObject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igraphicalobject/) példányok.

Az alábbi példa létrehoz több gyakori alakzattípust, és mindegyikhez modern megjegyzést rendel.

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

### **Megjegyzés Rögzítése Szöveghez és Állapotának Beállítása**

Egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/)‑hez társított modern megjegyzés esetén az [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) és az [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int--) a szövegkeretben a kiválasztott szöveg kezdőpozícióját adják. Az [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) és az [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int--) a kiválasztás hosszát adják meg. Ezek együtt a megjegyzést egy adott szövegtartománnyal kötik az AutoShape‑ben.

Az [IModernComment.getStatus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getStatus--) és az [IModernComment.setStatus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#setStatus-byte--) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/moderncommentstatus/) konstansok egyik értékét adják vissza:
- `NotDefined` — nincs meghatározott modern megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

Az alábbi példa létrehoz egy alakzatra rögzített modern megjegyzést, szövegkiválasztáshoz társítja, megoldottként jelöli, elmenti a prezentációt, és a fájl újranyitása után ellenőrzi az értékeket.

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

### **Létező Modern Megjegyzések Ellenőrzése**

Egy meglévő prezentáció ellenőrzéséhez vizsgálja meg, mely megjegyzések valósítják meg az [IModernComment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/) interfészt, majd tekintse meg az [IModernComment.getShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) és [IModernComment.getStatus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getStatus--) értékeket. A `null` alakzat diaszintű megjegyzést jelez. Egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) horgony esetén a szövegkiválasztási metódusok a alakzat szövegtömbjében a kapcsolódó tartományt azonosítják.

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

## **Megjegyzések Eltávolítása**

### **Minden Megjegyzés és Megjegyzés Szerző Eltávolítása**

Az alábbi példa bemutatja, hogyan távolíthatók el egy prezentációból az összes megjegyzés és megjegyzés szerző:

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

### **Különálló Megjegyzések Eltávolítása**

Az alábbi példa bemutatja, hogyan távolíthatók el konkrét megjegyzések egy diáról:

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

## **GYIK**

**Támogatja-e az Aspose.Slides a megoldott állapotot a modern megjegyzéseknél?**

Igen. Az [IModernComment.getStatus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#getStatus--) és az [IModernComment.setStatus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imoderncomment/#setStatus-byte--) a [ModernCommentStatus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/moderncommentstatus/) értékét adja vissza, beleértve a `Resolved` értéket. Az állapot a prezentációban tárolódik, és a fájl újranyitása után újra leolvasható.

**Támogatottak-e a szálas megbeszélések (válaszképek), és van-e mélységi korlát?**

Igen. Minden megjegyzés hivatkozhat a saját [szülő megjegyzésére](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icomment/#getParentComment--), lehetővé téve a válaszképeket. Az API nem definiál konkrét beágyazási mélységkorlátot.

**Milyen koordináta‑rendszerben van meghatározva egy megjegyzésjelző pozíciója a dián?**

A jelző pozíciója lebegőpontos koordinátákkal van meghatározva a dia koordináta‑rendszerében, ami lehetővé teszi a pontos elhelyezést a dián.