---
title: Prezentációs megjegyzések kezelése Pythonon keresztül Java használatával
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/python-java/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentációs megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzés válasza
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Prezentációs megjegyzések kezelése az Aspose.Slides for Python via Java segítségével: megjegyzések hozzáadása, olvasása, szerkesztése, válaszolás és eltávolítása PowerPoint prezentációkban gyorsan és egyszerűen."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentációs megjegyzések az Aspose.Slides for Python via Java segítségével. Bemutatja a fő megjegyzéssel kapcsolatos típusokat, és demonstrálja, hogyan lehet megjegyzéseket hozzáadni a diákhoz, meglévő megjegyzéseket elérni, válaszokkal és modern megjegyzésekkel dolgozni, valamint hogyan lehet megjegyzéseket eltávolítani egy prezentációból.

A példák a PowerPointban gyakran előforduló felülvizsgálati és együttműködési helyzeteket fedik le, például a megjegyzések szerzőkhöz való hozzárendelését, a megjegyzés szövegének és metaadatainak olvasását, a válaszláncok felépítését, valamint a kijelölt vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti annak szövegét és a kapcsolódó vitát.

A megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor anélkül, hogy magukat a megjegyzéseket módosítaná, lásd a [Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor](/slides/hu/python-java/presentation-view-properties/).

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

Megjegyzéseket használhat a visszajelzéshez és a kollégákkal való együttműködéshez a prezentációk áttekintésekor.

Aspose.Slides for Python via Java a következő API-kat biztosítja a megjegyzésekkel való munkához:

* Az [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzés‑szerzőihez.
* Az [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) osztály, amely egy adott szerzőhöz kapcsolódó megjegyzéseket képviseli.
* A [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) osztály, amely információkat ad egy megjegyzésről, beleértve annak szerzőjét, létrehozási idejét, pozícióját és szövegét.
* A [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) osztály, amely információkat ad egy szerzőről, beleértve a nevét, iniciáljait és a kapcsolódó megjegyzéseket.

## **Dia megjegyzések hozzáadása**

Az példa két diát hoz létre, és regisztrál egy megjegyzés‑szerzőt a [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) metódussal. A [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) metódust használja, hogy minden diára egy megjegyzést helyezzen, majd a [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) metódussal lekéri az első dia megjegyzéseit azon szerző számára. A konzol kétszer jeleníti meg az első megjegyzés szövegét, demonstrálva a hozzáférést mind a dián, mind a szerzőn keresztül, és a mentett prezentáció mindkét megjegyzést tartalmazza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))

    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Megjegyzés‑szerző keresése vagy létrehozása**

Amikor egy automatizált felülvizsgálat ismételten ugyanazt a prezentációt dolgozza fel, a [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) által visszaadott gyűjteményben keresni kell, mielőtt szerzőt adna hozzá. A [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) egyezést keres a név és az iniciálék alapján, és egy tömböt ad vissza a megfelelő szerzőkkel, vagy egy üres tömböt, ha nincs egyezés. Ezzel szemben a [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) csak a név alapján keres, az iniciáléktól függetlenül. Egy már meglévő név‑iniciálé párossal történő [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) hívás kivételt dob.

A példa egy legalább egy diát tartalmazó prezentációs fájlt igényel. Két átmenet során újra felhasználja az első egyező szerzőt, vagy csak akkor hoz létre újat, ha az eredmény üres. Ha több egyezés van, az első tömbelemet választja anélkül, hogy más szerzőket összevonna vagy eltávolítana. Ezután a kiválasztott szerzőhöz [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) hívásával megjegyzést ad hozzá, majd menti a prezentációt. A második átmenet megnyitja az első átmenet kimenetét és megismétli a műveletet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

A második átmenet egy újabb megjegyzést ad hozzá anélkül, hogy új szerzőt hozna létre vagy a meglévő megjegyzéseket eltávolítaná. A végleges fájl, `review_pass_2.pptx`, mindkét új megjegyzést tartalmazza az eredeti megjegyzések mellett. Egy szerző újbóli felhasználása nem szűri le a duplikált megjegyzéseket: a többszöri hozzáadás elkerülése érdekében a hozzáadás előtt valósítsa meg a duplikátum‑detektálást.

## **Dia megjegyzések elérése**

A példa meglévő prezentációt nyit meg, és beolvassa a [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) által visszaadott gyűjteményt. Minden szerzőhöz végigiterál a [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) által visszaadott megjegyzéseken, és kiírja a dia számát, a megjegyzés szövegét, a szerző nevét és a létrehozás időpontját. A bemeneti prezentációnak tartalmaznia kell megjegyzéseket a konzolkimenet előállításához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Válasz a megjegyzésekre**

Egy szülő megjegyzés a válaszköz hierarchia tetején lévő eredeti megjegyzés. A [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) és a [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) metódusok lehetővé teszik egy megjegyzés szülőjének lekérését vagy beállítását.

A példa két szerző megjegyzéseit hozza létre, és a [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) segítségével épít fel válaszokat, többek között egy válasz egy másik válaszra. A `None` átadása a [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) metódusnak minden szerző megjegyzéseit lekéri; a konzol minden bejegyzést a válaszhierarchiában elfoglalt mélysége szerint beljebb húz. A példa elmenti a teljes vitát, akkor a [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) metódust meghívja az első gyökérmegjegyzésen, majd egy második prezentációt ment, amelyben ez a megjegyzés és a hozzá tartozó válaszok eltávolításra kerültek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* Amikor a [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) metódusát egy megjegyzés törlésére használják, az az adott megjegyzés összes válasza is törlésre kerül.
* Ha a [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) körkörös hivatkozást hoz létre, egy [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/) kerül dobásra.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

A modern megjegyzések kapcsolódhatnak magához a diához, egy adott alakzathoz vagy egy szövegtartományhoz egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) belsejében. A [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) metódus egy [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) argumentumot is elfogad a dia és a megjegyzés‑marker koordinátái mellett.

Amikor a shape argumentumnak `None` értéket adunk, a megjegyzés dia‑szintű megjegyzés lesz. A markert a megadott koordináták határozzák meg, de nem kapcsolódik egy konkrét alakzathoz, ezért a [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) `None`‑t ad vissza. Ha egy [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) kerül megadásra, a megjegyzés ehhez az alakzathoz lesz rögzítve. A koordináták továbbra is a megjegyzés‑marker pozícióját határozzák meg a dián, míg az alakzatkapcsolat a [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) segítségével kérdezhető le.

### **Modern megjegyzés rögzítése alakzatra**

A példa kétszer hívja a [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) metódust: egyszer `None` shape‑al egy dia‑szintű megjegyzéshez, egyszer pedig egy téglalappal rögzítve. A [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) kiíratása `True`‑t ad a dia‑szintű megjegyzés `None` ellenőrzésére és a `Revenue title` szöveget az rögzített megjegyzésnél. Mindkét megjegyzés mentésre kerül a prezentációval.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Megjegyzések rögzítése különböző alakzattípusokra**

Bármely diaobjektum, amely a [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)‑ból származik, használható alakzatrögzítésként. Gyakori példák a [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), a [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), a [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), a [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) és a [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) példányok, például diagramok.

A példa a [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) segítségével egy megjegyzést kapcsol hozzá öt alakzattípushoz: egy AutoShape‑hez, egy képkockához, egy csoporthoz, egy csatlóshoz és egy diagramhoz. A kép beágyazott képadatot használ, ezért nincs szükség külső képre. Minden megjegyzésnek saját marker‑pozíciója van, és a mentett prezentáció megtartja az öt alakzatkapcsolatot.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")

    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Megjegyzés rögzítése szövegre és állapotának beállítása**

Egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)‑hez kapcsolódó modern megjegyzés esetén a [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) és a [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) a kiválasztott szöveg kezdőpozícióját adja vissza az alakzat szövegdobozában. A [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) és a [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) a kiválasztás hosszát adja vissza. Ezek az értékek együtt a megjegyzést egy adott szövegtartománnyal kapcsolják össze az AutoShape‑ben.

A [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) és a [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) állandóinak egyik értékét adják vissza:

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — nincs meghatározott modern‑megjegyzés állapot.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — a megjegyzés aktív.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — a megjegyzés megoldott.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — a megjegyzés lezárt.

A példa egy modern megjegyzést rögzít a „quarterly revenue” szavakra egy téglalap szövegében. A szövegből számított null‑indexelt kezdőpozíciót átadja a [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) metódusnak, és a [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) segítségével beállítja a kiválasztott karakterek számát. A [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) `Resolved` értékkel való meghívása után menti és újra megnyitja a prezentációt. A négy konzol‑ellenőrzésnek mindegyiknek `True`‑t kell kiírnia, ezzel igazolva, hogy az alakzat‑rögzítés, a szövegtartomány és az állapot megmaradt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Meglévő modern megjegyzések vizsgálata**

A példa egy meglévő, modern megjegyzéseket tartalmazó prezentációt igényel, és kiírja azok szövegét, állapotát és rögzítési részleteit. A vizsgálathoz ellenőrizze, mely megjegyzések példányai a [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), majd vizsgálja a [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), a [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), a [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) és a [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) értékeket. Egy `None` shape egy dia‑szintű megjegyzést jelez. Egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) rögzítésnél a szöveg‑kiválasztási metódusok meghatározzák a kapcsolódó tartományt az alakzat szövegdobozában.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Megjegyzések eltávolítása**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy egy prezentációból eltávolítsa az összes megjegyzést és azok szerzőit, vagy csak a kiválasztott megjegyzéseket törölje, a többit megtartva. Az alábbi példák mindkét megközelítést demonstrálják, és elmentik a frissített prezentációt.

### **Az összes megjegyzés és megjegyzés‑szerző eltávolítása**

A példa egy meglévő prezentációt nyit meg, majd minden szerzőre meghívja a [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) metódust, ezután a [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) metódussal eltávolítja magukat a szerzőket. A mentett prezentáció sem megjegyzést, sem megjegyzés‑szerzőt nem tartalmaz. Használjon egy megjegyzéseket tartalmazó prezentációt a törlés megfigyeléséhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kifejezett megjegyzések eltávolítása**

A példa két megjegyzést hoz létre egy dián, és a [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) segítségével megtalálja a szerzők által írt megjegyzéseket. Azok a megjegyzések, amelyek szövege „comment 1”, a [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove) meghívása előtt kerülnek összegyűjtésre, elkerülve a kollekció módosítását a kiválasztás közben. A mentett prezentáció csak a „comment 2” megjegyzést tartja meg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Támogatja-e az Aspose.Slides a modern megjegyzések megoldott állapotát?**

Igen. A [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) és a [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) egy [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) értéket ad vissza, beleértve a `Resolved` állapotot. Az állapot a prezentációban tárolódik, és a fájl újranyitása után ismét lekérhető.

**Támogatja-e a szálas beszélgetéseket (válaszláncokat), és van-e mélységkorlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment)‑re, lehetővé téve a válaszláncokat. Az API nem határoz meg specifikus mélység‑korlátot.

**Milyen koordináta‑rendszerben van meghatározva a megjegyzés‑marker pozíciója a dián?**

A marker pozíciója lebegőpontos koordinátákkal van megadva a dia koordináta‑rendszerében, ami lehetővé teszi a pontos elhelyezést a dián.