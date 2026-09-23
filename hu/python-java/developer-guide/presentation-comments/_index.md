---
title: Prezentációs megjegyzések kezelése Pythonban Java-n keresztül
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
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Python via Java segítségével: adjon hozzá, olvassa, szerkessze, válaszoljon, és távolítson el megjegyzéseket PowerPoint prezentációkban gyorsan és egyszerűen."
---
## **Áttekintés**

Ez a cikk leírja, hogyan kezelhetők a prezentációs megjegyzések az Aspose.Slides for Python via Java segítségével. Bemutatja a fő megjegyzéssel kapcsolatos típusokat, valamint azt, hogyan adhatunk megjegyzéseket a diákhoz, érhetjük el a meglévő megjegyzéseket, dolgozhatunk válaszokkal és modern megjegyzésekkel, és hogyan távolíthatjuk el a megjegyzéseket a prezentációból.

A példák a PowerPointban gyakran előforduló felülvizsgálati és együttműködési helyzeteket fedik le, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, válaszos láncok felépítését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések anotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti annak szövegét és a kapcsolódó vitát.

Ahhoz, hogy a megjegyzéseket megjelenítsük vagy elrejtsük a prezentáció megnyitásakor anélkül, hogy magukat a megjegyzéseket módosítanánk, lásd [Megjelenítés vagy elrejtés megjegyzéseket a prezentáció megnyitásakor](/slides/hu/python-java/presentation-view-properties/).

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

A megjegyzésekkel visszajelzést adhat és együttműködhet a kollégákkal a prezentációk felülvizsgálata során.

Az Aspose.Slides for Python via Java a következő API-kat biztosítja a megjegyzésekkel való munkához:

* A [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzés‑szerzőihez.
* A [CommentCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commentcollection/) osztály, amely egy adott szerzőhöz kapcsolódó megjegyzéseket képviseli.
* A [Comment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/) osztály, amely információkat ad egy megjegyzésről, többek között a szerzőről, létrehozási időről, pozícióról és a szövegről.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commentauthor/) osztály, amely információkat ad egy szerzőről, többek között a nevéről, inicialákról és a kapcsolódó megjegyzésekről.

## **Diák megjegyzéseinek hozzáadása**

Az alábbi példa bemutatja, hogyan adhatunk megjegyzéseket egy PowerPoint‑prezentáció diáihoz:

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

## **Diák megjegyzéseinek elérése**

Az alábbi példa bemutatja, hogyan érhetjük el a meglévő megjegyzéseket egy PowerPoint‑prezentációban:

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

## **Megjegyzésekre válaszolás**

A szülő‑megjegyzés az eredeti megjegyzés a válaszhierarchia tetején. A [Comment.getParentComment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/#getParentComment) és a [Comment.setParentComment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/#setParentComment) metódusok lehetővé teszik egy megjegyzés szülőjének lekérését vagy beállítását.

Az alábbi példa bemutatja, hogyan adhatunk válaszokat, és hogyan vizsgálhatjuk meg a keletkezett megjegyzés‑hierarchiát:

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
* Amikor a [Comment.remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/#remove) metódust használjuk egy megjegyzés törlésére, az ahhoz tartozó összes válasz is törlésre kerül.
* Ha a [Comment.setParentComment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/#setParentComment) körkörös hivatkozást hoz létre, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxeditexception/) lesz dobva.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

Modern megjegyzések kapcsolhatók a diához magához, egy adott alakzathoz vagy egy szöveg‑tartományhoz egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/)-ban. A [CommentCollection.addModernComment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/commentcollection/#addModernComment) metódus a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) argumentumot is elfogadja a dia és a megjegyzés‑jelző koordinátái mellett.

Ha a `None` érték kerül átadásra a shape argumentumként, a megjegyzés egy dia‑szintű megjegyzés. Jelzőjét a megadott koordináták határozzák meg, de nem kapcsolódik konkrét alakzathoz, így a [ModernComment.getShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getShape) `None`‑t ad vissza. Ha egy [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) kerül megadásra, a megjegyzés ehhez az alakzathoz lesz rögzítve. A koordináták továbbra is a megjegyzés‑jelző helyét határozzák meg a dián, míg az alakzathoz való kapcsolódás a [ModernComment.getShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getShape)‑on keresztül lekérdezhető.

### **Modern megjegyzés rögzítése egy alakzathoz**

Az alábbi példa létrehoz egy dia‑szintű modern megjegyzést és egy meghatározott [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/)-hez rögzített modern megjegyzést, majd kiolvassa a kapcsolódó alakzatot mindkét megjegyzésből.

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

### **Megjegyzések rögzítése különböző alakzat‑típusokhoz**

Bármely dia‑objektum, amely a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/)-ből származik, használható alakzat‑horgonyként. Gyakori példák a [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/), a [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/), a [GroupShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/groupshape/), a [Connector](https://reference.aspose.com/slides/hu/python-java/aspose.slides/connector/) és a [GraphicalObject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/graphicalobject/) (például diagramok) példányai.

Az alábbi példa több gyakori alakzat‑típust hoz létre, és mindegyikhez modern megjegyzést társít.

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

### **Megjegyzés rögzítése szöveghez és állapotának beállítása**

Egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/)-hez kapcsolódó modern megjegyzés esetén a [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getTextSelectionStart) és a [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#setTextSelectionStart) a shape szövegkeretének kiválasztott szövegének kezdőpozícióját, a [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getTextSelectionLength) és a [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#setTextSelectionLength) pedig a kijelölés hosszát adja meg. Ezek az értékek együtt a megjegyzést egy adott szöveg‑tartományhoz kapcsolják az AutoShape‑ben.

A [ModernComment.getStatus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getStatus) és a [ModernComment.setStatus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#setStatus) metódusok a [ModernCommentStatus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncommentstatus/) konstansok egyik értékét adja vissza:

- [NotDefined](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncommentstatus/#NotDefined) — nincs meghatározott modern‑megjegyzés állapot.
- [Active](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncommentstatus/#Active) — a megjegyzés aktív.
- [Resolved](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncommentstatus/#Resolved) — a megjegyzés megoldott.
- [Closed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncommentstatus/#Closed) — a megjegyzés lezárt.

Az alábbi példa létrehoz egy alakzathoz rögzített modern megjegyzést, szövegkijelöléshez kapcsolja, megoldottnak jelöli, elmenti a prezentációt, majd a fájl újra‑megnyitása után ellenőrzi az értékeket.

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

### **Meglévő modern megjegyzések ellenőrzése**

Egy meglévő prezentáció ellenőrzéséhez ellenőrizze, mely megjegyzések példányai a [ModernComment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/), majd vizsgálja meg a [ModernComment.getShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getShape), a [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getTextSelectionStart), a [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getTextSelectionLength) és a [ModernComment.getStatus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getStatus) értékeket. A `None` alakzat egy dia‑szintű megjegyzést jelez. Egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/)-hez rögzített horgony esetén a szöveg‑kijelölési metódusok az alakzat szövegkeretében lévő tartományt azonosítják.

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

### **Minden megjegyzés és megjegyzés‑szerző eltávolítása**

Az alábbi példa bemutatja, hogyan távolítható el az összes megjegyzés és a megjegyzés‑szerzők a prezentációból:

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

### **Bizonyos megjegyzések eltávolítása**

Az alábbi példa bemutatja, hogyan távolítható el egy adott megjegyzés egy diáról:

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

Igen. A [ModernComment.getStatus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#getStatus) és a [ModernComment.setStatus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncomment/#setStatus) egy [ModernCommentStatus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/moderncommentstatus/) értéket ad vissza, többek között a `Resolved`‑et. Az állapot a prezentációban van tárolva, és a fájl újra‑megnyitása után ismét olvasható.

**Támogatottak-e a szálas beszélgetések (válaszos láncok), és van‑e mélységi korlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/#getParentComment)-re, ezzel lehetővé téve a válaszos láncokat. Az API nem határoz meg konkrét beágyazási mélység‑korlátot.

**Milyen koordináta‑rendszerben van definiálva a megjegyzés‑jelző pozíciója egy dián?**

A jelző pozíciója lebegőpontos koordinátákkal van definiálva a dia koordináta‑rendszerében, lehetővé téve, hogy pontosan a dián helyezze el.