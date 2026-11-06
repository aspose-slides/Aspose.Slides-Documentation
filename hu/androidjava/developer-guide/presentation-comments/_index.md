---
title: Prezentációs megjegyzések kezelése Androidon
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
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Android via Java segítségével: gyorsan és egyszerűen adjon hozzá, olvasson, szerkesszen, válaszoljon, és távolítson el megjegyzéseket a PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a bemutató megjegyzések az Aspose.Slides for Android via Java segítségével. Bemutatja a fő megjegyzésekkel kapcsolatos típusokat, és demonstrálja, hogyan adhatunk megjegyzéseket a diákhoz, hogyan érhetjük el a meglévő megjegyzéseket, hogyan dolgozhatunk válaszokkal és modern megjegyzésekkel, illetve hogyan távolíthatjuk el a megjegyzéseket egy bemutatóból.

A példák a PowerPoint gyakori felülvizsgálati és együttműködési forgatókönyveit fedik le, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, a válaszkötegek felépítését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti annak szövegét és a kapcsolódó megbeszélést.

Ha szeretné beállítani, hogy a megjegyzések megjelenjenek vagy rejtve legyenek egy bemutató megnyitásakor a megjegyzések módosítása nélkül, tekintse meg a [Show or Hide Comments When Opening a Presentation](/slides/hu/androidjava/presentation-view-properties/).

## **Miért adjunk megjegyzéseket a bemutatókhoz?**

Megjegyzésekkel visszajelzést adhat és együttműködhet kollégáival a bemutatók felülvizsgálata során.

Az Aspose.Slides for Android via Java a következő API-kat biztosítja a megjegyzésekkel való munkához:

* A [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztály, amely hozzáférést biztosít a bemutató megjegyzés szerzőihez.
* A [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/) interface, amely egy adott szerzőhöz társított megjegyzéseket reprezentál.
* A [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/) interface, amely információkat nyújt egy megjegyzésről, beleértve annak szerzőjét, létrehozási időpontját, pozícióját és szövegét.
* A [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/) osztály, amely információkat nyújt egy szerzőről, beleértve a nevét, monogramját és a kapcsolódó megjegyzéseket.

## **Dia Megjegyzések Hozzáadása**

A példa két diát hoz létre, és regisztrál egy megjegyzés szerzőt a [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) segítségével. A [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) használatával egy megjegyzést helyez el minden dián, majd a [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) hívással lekéri az első dia megjegyzéseit az adott szerzőhöz. A konzol kétszer jeleníti meg az első megjegyzés szövegét, demonstrálva a hozzáférést mind a dián, mind a szerzőn keresztül, és a mentett bemutató mindkét megjegyzést tartalmazza.

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

        String commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Megjegyzés Szerző Keresése vagy Létrehozása**

Amikor egy automatizált felülvizsgálat ugyanazt a bemutatót többször dolgozza fel, a [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) által visszaadott gyűjteményt kell keresni egy szerző hozzáadása előtt. A [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) mind a nevet, mind a monogramot egyezteti, és a megfelelő szerzőket tartalmazó tömböt ad vissza, vagy egy üres tömböt, ha nincs egyezés. Ezzel szemben a [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) csak a nevet vizsgálja, a monogramtól függetlenül. A [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) hívása egy már meglévő név‑ és monogramkészlettel kivételt dob.

A példa egy legalább egy diás bemutató fájlt igényel. Két átfutás során újra használja az első egyező szerzőt, vagy csak akkor hoz létre újat, ha a találat üres. Ha több egyezés van, a tömb első elemét választja anélkül, hogy egyesítené vagy eltávolítaná a többi szerzőt. Ezután a kiválasztott szerzőhöz a [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) hívást végzi, és menti a bemutatót. A második átfutás megnyitja az első átfutás kimenetét és ismétli a műveletet.

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
PointF position = new PointF(20, 20);

for (int pass = 1; pass <= 2; pass++) {
    Presentation presentation = new Presentation(inputFile);
    try {
        ICommentAuthor[] matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        ICommentAuthor author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, new Date());

        String outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

A második átfutás egy újabb megjegyzést ad hozzá anélkül, hogy új szerzőt hozna létre vagy a meglévő megjegyzéseket eltávolítaná. A végső fájl, `review_pass_2.pptx`, mindkét új megjegyzést tartalmazza az eredeti megjegyzésekkel együtt. Egy szerző újrahasználása nem deduplikálja a megjegyzéseket: a többszöri ugyanazon megjegyzés hozzáadásának elkerüléséhez valósítsa meg a duplikátum‑detektálást a hozzáadás előtt.

## **Dia Megjegyzések Elérése**

A példa egy meglévő bemutatót nyit meg, és a [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) által visszaadott gyűjteményt olvassa. Minden szerző esetén végigiterál a [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) által visszaadott gyűjteményen, és kiírja a dia számát, a megjegyzés szövegét, a szerző nevét és a létrehozás időpontját. A bemeneti bemutatónak megjegyzéseket kell tartalmaznia ahhoz, hogy a konzol kimenetet előállítsa.

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

## **Megjegyzések Válaszolása**

Egy szülő megjegyzés a válaszhierarchia tetején található eredeti megjegyzés. Az [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) és az [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) metódusok lehetővé teszik egy megjegyzés szülőjének lekérdezését vagy beállítását.

A példa két szerzőtől hoz létre megjegyzéseket, és a [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) segítségével felépíti a válaszokat, beleértve egy válasz egy másik válaszra való hivatkozását is. A [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) `null` argumentummal történő meghívása az összes szerző megjegyzéseit adja vissza; a konzol minden bejegyzést a válaszhierarchia mélységének megfelelően igazít. A példa elmenti a teljes megbeszélést, az első gyökér megjegyzésen meghívja a [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) metódust, majd egy második bemutatót ment, amelyben az a megjegyzés és annak válaszai eltávolításra kerültek.

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

    ICommentAuthor originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    IComment secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    IComment subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    IComment separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    IComment separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Amikor az [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) metódust használják egy megjegyzés törlésére, az összes hozzá tartozó válasz is törlődik.
* Ha az [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) körkörös hivatkozást hoz létre, egy [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/) kerül dobásra.
{{% /alert %}}

## **Modern Megjegyzések Hozzáadása**

A modern megjegyzések kapcsolhatók a diához, egy adott alakzathoz vagy egy AutoShape szövegtartományához. Az [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) metódus egy [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) argumentumot is elfogad a dia és a megjegyzés‑marker koordinátái mellett.

Ha a shape argumentum `null`, a megjegyzés dia‑szintű. A marker a megadott koordinátákkal kerül pozícionálásra, de nem kapcsolódik konkrét alakzathoz, ezért az [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) `null`‑t ad vissza. Ha egy [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) van megadva, a megjegyzés ehhez az alakzathoz lesz rögzítve. A koordináták továbbra is a megjegyzés marker pozícióját határozzák a dián, míg az alakzat‑kapcsolat a [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) segítségével kérdezhető le.

### **Modern Megjegyzés Horgonyzása Alakzathoz**

A példa kétszer hívja az [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) metódust: egyszer `null` shape‑szel dia‑szintű megjegyzéshez, egyszer pedig egy téglalappal horgonyként. A [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) kiírása `true`‑t ad a dia‑szintű megjegyzés null‑ellenőrzésére, és `Revenue title`‑t az horgonyzott megjegyzésre. Mindkét megjegyzés a prezentációval mentésre kerül.

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

### **Megjegyzések Horgonyzása Különböző Alakzat Típusokhoz**

Bármely diaobjektum, amely megvalósítja az [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interfészt, használható alakzat‑horgonyként. Gyakori példák a [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), a [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), az [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), az [IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/) és az [IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/) példányok, például diagramok.

A példa az [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) használatával egy megjegyzést kapcsol minden öt alakzat típushoz: egy AutoShape-hez, egy képkerethez, egy csoporthoz, egy csatlakozóhoz és egy diagramhoz. A kép beágyazott képadatot használ, így külső kép nem szükséges. Minden megjegyzésnek saját marker‑pozíciója van, és a mentett bemutató megőrzi mind az öt alakzatkapcsolatot.

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
import android.util.Base64;
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
    byte[] imageData = Base64.decode(imageBase64, Base64.DEFAULT);
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

### **Megjegyzés Horgonyzása Szöveghez és Állapotának Beállítása**

Egy modern megjegyzés, amely egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)-hez van kapcsolva, a [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) és a [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) metódusokkal éri el a kiválasztott szöveg kezdőpozícióját az alakzat szövegdobozában. A [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) és a [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) a kijelölés hosszát adja meg. Ezek együtt a megjegyzést egy adott szövegtartományhoz kötik az AutoShape‑en belül.

Az [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) és az [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) konstansok közül egy értéket adnak vissza:

- `NotDefined` — nincs definiálva konkrét modern‑megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

A példa egy modern megjegyzést rögzít a "quarterly revenue" szavakra egy téglalap szövegében. Kiszámítja a null‑alapú kezdőpozíciót a szövegből, és átadja a [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) metódusnak, majd a [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) segítségével beállítja a kiválasztott karakterek számát. A [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) `Resolved` értékre állítása után menti és újra megnyitja a bemutatót. A négy konzol‑ellenőrzés mindegyike `true`‑t kell, hogy kiírjon, megerősítve, hogy az alakzat‑horgony, a szöveg‑tartomány és az állapot megmaradt.

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

### **Meglévő Modern Megjegyzések Ellenőrzése**

A példa egy már létező, modern megjegyzéseket tartalmazó bemutatót igényel, és kiírja azok szövegét, állapotát és horgony részleteit. Az ellenőrzéshez először meg kell határozni, mely megjegyzések implementálják az [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/) interfészt, majd megvizsgálni az [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) és [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) metódusokat. Egy `null` shape egy dia‑szintű megjegyzést jelez. Egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) horgony esetén a szöveg‑kijelölés‑metódusok az alakzat szövegdobozában lévő tartományt határozzák meg.

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

## **Megjegyzések Törlése**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy egy bemutatóból minden megjegyzést és szerzőjüket eltávolítsa, vagy csak a kiválasztott megjegyzéseket törölje a többi megőrzése mellett. Az alábbi példák mindkét megközelítést szemléltetik, és elmentik a módosított bemutatót.

### **Minden Megjegyzés és Megjegyzés Szerző Törlése**

A példa egy meglévő bemutatót nyit meg, és minden szerző esetén meghívja az [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--) metódust, majd az [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) segítségével eltávolítja magukat a szerzőket is. A mentett bemutató sem megjegyzéseket, sem megjegyzés‑szerzőket nem tartalmaz. Használjon egy megjegyzéseket tartalmazó bemutatót a törlés megfigyeléséhez.

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

### **Kifejezetten Kiválasztott Megjegyzések Törlése**

A példa két megjegyzést hoz létre egy dián, és a [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) segítségével megtalálja a megjegyzéseket minden szerzőnél. Azok a megjegyzések, amelyek szövege „comment 1”, gyűjtődik, mielőtt meghívná az [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-) metódust, elkerülve a gyűjtemény módosítását a kiválasztás közben. A mentett bemutató csak a „comment 2” megjegyzést tartalmazza.

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

**Támogatja-e az Aspose.Slides a modern megjegyzések megoldott állapotát?**

Igen. Az [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) és az [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) egy [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) értéket ad vissza, többek között a `Resolved`-t. Az állapot a bemutatóban tárolódik, és a fájl újranyitása után újra olvasható.

**Támogatottak-e a szálas megbeszélések (válaszkötegek), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--)‑re, így lehetővé téve a válaszkötegeket. Az API nem határoz meg konkrét beágyazási mélység‑korlátot.

**Milyen koordináta‑rendszerben van definiálva egy megjegyzés marker pozíciója a dián?**

A marker pozíciója lebegőpontos koordinátákkal van definiálva a dia koordináta‑rendszerében, lehetővé téve a pontos elhelyezést a dián.