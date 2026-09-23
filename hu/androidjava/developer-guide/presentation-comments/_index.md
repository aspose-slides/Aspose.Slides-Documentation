---
title: Androidon történő prezentációs megjegyzések kezelése
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/androidjava/presentation-comments/
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
- Android
- Java
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Android via Java segítségével: gyorsan és egyszerűen adjon hozzá, olvasson, szerkesszen, válaszoljon, és távolítson el megjegyzéseket PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentációs megjegyzések az Aspose.Slides for Android via Java segítségével. Bevezeti a fő megjegyzéssel kapcsolatos típusokat, és bemutatja, hogyan adhat megjegyzéseket a diákhoz, hogyan érheti el a már létező megjegyzéseket, hogyan dolgozhat válaszokkal és modern megjegyzésekkel, valamint hogyan távolíthatja el a megjegyzéseket egy prezentációból.

A példák lefedik a PowerPoint gyakori felülvizsgálati és együttműködési forgatókönyveit, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, válaszláncok építését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti annak szövegét és a kapcsolódó beszélgetést.

A megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor a megjegyzések maguk módosítása nélkül kéréshez, lásd [Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor](/slides/hu/androidjava/presentation-view-properties/).

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

A megjegyzéseket felhasználhatja visszajelzés adására és a kollégákkal való együttműködésre a prezentációk felülvizsgálata során.

Az Aspose.Slides for Android via Java a következő API-kat biztosítja a megjegyzésekkel való munkához:

* A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzés szerzőihez.
* Az [ICommentCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icommentcollection/) interfész, amely egy adott szerzőhöz kapcsolódó megjegyzéseket képviseli.
* Az [IComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icomment/) interfész, amely információkat ad egy megjegyzésről, beleértve a szerzőt, létrehozás időpontját, pozícióját és szövegét.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/commentauthor/) osztály, amely információkat ad egy szerzőről, beleértve a nevét, monogramját és a hozzá tartozó megjegyzéseket.

## **Diamegjegyzések hozzáadása**

Az alábbi példa megmutatja, hogyan adhat megjegyzéseket diákhoz egy PowerPoint‑prezentációban:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    PointF position = new PointF(0.2f, 0.2f);
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

## **Diamegjegyzések elérése**

Az alábbi példa megmutatja, hogyan érheti el a már létező megjegyzéseket egy PowerPoint‑prezentációban:

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

## **Megjegyzések megválaszolása**

A szülőmegjegyzés az eredeti megjegyzés a válasz‑hierarchia csúcsán. Az [IComment.getParentComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icomment/#getParentComment--) és az [IComment.setParentComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) metódusok lehetővé teszik egy megjegyzés szülőjének lekérdezését vagy beállítását.

Az alábbi példa megmutatja, hogyan adhat válaszokat, és hogyan vizsgálhatja meg a létrejött megjegyzés‑hierarchiát:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    PointF position = new PointF(10, 10);
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
* Amikor az [IComment.remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icomment/#remove--) metódust használja egy megjegyzés törlésére, a megjegyzésre adott összes válasz is törlődik.
* Ha az [IComment.setParentComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) körkörös hivatkozást hoz létre, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pptxeditexception/) kerül kivételként dobásra.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

A modern megjegyzések a diára, egy adott alakzatra vagy egy AutoShape‑on belüli szövegtartományra vonatkozhatnak. Az [ICommentCollection.addModernComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) metódus egy [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) argumentumot is elfogad a dia és a megjegyzés‑marker koordinátái mellett.

Ha a shape argumentumként `null` kerül átadásra, a megjegyzés diaszintű megjegyzés lesz. Markerét a megadott koordináták alapján helyezi el, de nem kapcsolódik egy konkrét alakzathoz, így az [IModernComment.getShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getShape--) `null`‑t ad vissza. Ha egy [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) van megadva, a megjegyzés arra az alakzatra van rögzítve. A koordináták továbbra is meghatározzák a megjegyzés‑marker pozícióját a dián, míg az alakzati kapcsolatot a [IModernComment.getShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getShape--) hívással lehet lekérdezni.

### **Modern megjegyzés rögzítése alakzatra**

Az alábbi példa létrehoz egy diaszintű modern megjegyzést és egy specifikus AutoShape‑ra rögzített modern megjegyzést is. Ezután minden megjegyzéshez kiolvassa a hozzá tartozó alakzatot.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    PointF slideCommentPosition = new PointF(20, 20);
    PointF shapeCommentPosition = new PointF(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Megjegyzések rögzítése különböző alakzattípusokhoz**

Bármely diaobjektum, amely implementálja az [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) interfészt, használható alakzatrögzítőként. Gyakori példák: [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iconnector/) és a diagramokhoz hasonló [IGraphicalObject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igraphicalobject/) példányok.

Az alábbi példa több gyakori alakzattípust hoz létre, és mindegyikhez modern megjegyzést rendel.

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
import android.graphics.PointF;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    PointF autoShapeCommentPosition = new PointF(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    PointF pictureCommentPosition = new PointF(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    PointF groupCommentPosition = new PointF(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    PointF connectorCommentPosition = new PointF(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    PointF chartCommentPosition = new PointF(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Megjegyzés rögzítése szöveghez és állapotának beállítása**

Egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/)-hez kapcsolódó modern megjegyzésnél az [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) és az [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) a kiválasztott szöveg kezdőpozícióját adja meg az alakzat szövegkeretében. Az [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) és az [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) a kijelölés hosszát adja vissza. Ezek együtt a megjegyzést az AutoShape‑on belüli konkrét szövegtartományhoz kötik.

Az [IModernComment.getStatus](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getStatus--) és az [IModernComment.setStatus](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/moderncommentstatus/) konstansok egyikének értékét adják vissza:

- `NotDefined` — nincs meghatározott modern‑megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

Az alábbi példa alakzatra rögzített modern megjegyzést hoz létre, szövegjelenítést ad hozzá, megoldottnak jelöli, elmenti a prezentációt, majd a fájl újbóli megnyitása után ellenőrzi az értékeket.

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
import android.graphics.PointF;
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
    PointF commentPosition = new PointF(60, 60);
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

### **Meglévő modern megjegyzések vizsgálata**

Egy meglévő prezentáció vizsgálatához először ellenőrizze, mely megjegyzések implementálják az [IModernComment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/) interfészt, majd tekintse meg az [IModernComment.getShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getShape--), az [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), az [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) és az [IModernComment.getStatus](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getStatus--) metódusokat. A `null` alakzat diaszintű megjegyzést jelent. Egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) rögzítő esetén a szöveg‑kijelölési metódusok az alakzat szövegkeretében található tartományra mutatnak.

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

## **Megjegyzések eltávolítása**

### **Minden megjegyzés és megjegyzés‑szerző eltávolítása**

Az alábbi példa megmutatja, hogyan távolíthatja el az összes megjegyzést és megjegyzés‑szerzőt egy prezentációból:

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

### **Specifikus megjegyzések eltávolítása**

Az alábbi példa megmutatja, hogyan távolíthatja el a konkrét megjegyzéseket egy diáról:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    PointF firstCommentPosition = new PointF(0.2f, 0.2f);
    PointF secondCommentPosition = new PointF(0.3f, 0.2f);
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

**Támogatja az Aspose.Slides a modern megjegyzések megoldott állapotát?**

Igen. Az [IModernComment.getStatus](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#getStatus--) és az [IModernComment.setStatus](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) a [ModernCommentStatus](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/moderncommentstatus/) értékét adja vissza, beleértve a `Resolved` állapotot. Az állapot a prezentációban tárolódik, és a fájl újbóli megnyitása után ismét leolvasható.

**Támogatottak a szálas beszélgetések (válaszláncok), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a saját [szülő megjegyzésére](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icomment/#getParentComment--), így válaszláncok hozhatók létre. Az API nem határoz meg konkrét beágyazási mélységi korlátot.

**Milyen koordináta‑rendszerben van meghatározva a megjegyzés‑marker pozíciója a dián?**

A marker pozíciója lebegőpontos koordinátákkal van meghatározva a dia koordináta‑rendszerében, lehetővé téve a pontos elhelyezést a dián.