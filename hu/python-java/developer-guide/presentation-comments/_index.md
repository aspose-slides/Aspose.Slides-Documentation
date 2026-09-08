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
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for Python via Java segítségével: gyorsan és egyszerűen adjon hozzá, olvassa, szerkessze, válaszoljon, és távolítsa el a megjegyzéseket a PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a bemutató megjegyzései az Aspose.Slides for Python via Java segítségével. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és megmutatja, hogyan adhatunk megjegyzéseket a diákhoz, hogyan érhetjük el a meglévő megjegyzéseket, hogyan dolgozhatunk a válaszokkal és a modern megjegyzésekkel, valamint hogyan távolíthatjuk el a megjegyzéseket egy bemutatóból.

Az példák a PowerPointban gyakran előforduló felülvizsgálati és együttműködési forgatókönyveket fedik le, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, a válaszláncok felépítését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti a szövegét és a kapcsolódó vitát.

## **Miért adjunk megjegyzéseket a bemutatókhoz?**

A megjegyzésekkel visszajelzést adhat és együttműködhet a kollégákkal a bemutatók felülvizsgálata során.

Az Aspose.Slides for Python via Java a következő API-kat kínálja a megjegyzésekkel való munkához:
* A [Presentation] osztály, amely hozzáférést biztosít a bemutató megjegyzés-szerzőihez.
* A [CommentCollection] osztály, amely egy adott szerzőhöz tartozó megjegyzéseket képviseli.
* A [Comment] osztály, amely információkat nyújt egy megjegyzésről, beleértve a szerzőjét, létrehozási időt, pozíciót és szöveget.
* A [CommentAuthor] osztály, amely információkat ad egy szerzőről, beleértve a nevét, monogramját és a kapcsolódó megjegyzéseket.

## **Dia megjegyzések hozzáadása**

A következő példa bemutatja, hogyan adhatunk megjegyzéseket a diákhoz egy PowerPoint bemutatóban:

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

## **Dia megjegyzések elérése**

A következő példa megmutatja, hogyan érhetők el a meglévő megjegyzések egy PowerPoint bemutatóban:

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

A szülő megjegyzés a válaszhierarchia tetején lévő eredeti megjegyzés. A [Comment.getParentComment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/#getParentComment) és a [Comment.setParentComment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/#setParentComment) metódusok lehetővé teszik, hogy lekérdezzük vagy beállítsuk egy megjegyzés szülőjét.

A következő példa bemutatja, hogyan adhatunk válaszokat és vizsgálhatjuk meg a keletkezett megjegyzés hierarchiát:

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

{{% alert color="warning" title="Figyelmeztetés" %}}
* Ha a [Comment.remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/#remove) metódust használják egy megjegyzés törlésére, akkor az összes válasz is törlődik.
* Ha a [Comment.setParentComment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/comment/#setParentComment) körkörös hivatkozást hoz létre, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxeditexception/) kivétel kerül dobásra.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

A modern megjegyzések társíthatók a diára, egy adott alakzatra vagy egy szövegtartományra egy [AutoShape]-en belül. A [CommentCollection.addModernComment] metódus egy [Shape] argumentumot is elfogad a dia és a megjegyzés-jelző koordináták mellett.

Ha a shape argumentumnak `None` értéket adunk át, akkor a megjegyzés dia-szintű megjegyzés lesz. Jelzője a megadott koordinátákkal helyezkedik el, de nem kapcsolódik egy adott alakzathoz, ezért a [ModernComment.getShape] `None`-t ad vissza. Ha egy [Shape] kerül megadásra, a megjegyzés az adott alakzathoz lesz rögzítve. A koordináták továbbra is a megjegyzés-jelző pozícióját határozzák meg a dián, míg az alakzat-határozás a [ModernComment.getShape] metódussal lekérdezhető.

### **Modern megjegyzés rögzítése egy alakzathoz**

A következő példa létrehoz egy dia-szintű modern megjegyzést és egy adott [AutoShape]-hez rögzített modern megjegyzést. Ezután minden megjegyzésből kiolvassa a kapcsolódó alakzatot.

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

### **Megjegyzések rögzítése különböző alakzat típusokhoz**

Bármely diaobjektum, amely a [Shape]-ből származik, használható alakzat rögzítőként. Gyakori példák a [AutoShape], a [PictureFrame], a [GroupShape], a [Connector] és a [GraphicalObject] példányok, például diagramok.

A következő példa több gyakori alakzat típust hoz létre, és mindegyikhez modern megjegyzést társít.

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

Egy [AutoShape]-hez társított modern megjegyzés esetén a [ModernComment.getTextSelectionStart] és a [ModernComment.setTextSelectionStart] a kiválasztott szöveg kezdőpozícióját adja vissza az alakzat szövegkeretében. A [ModernComment.getTextSelectionLength] és a [ModernComment.setTextSelectionLength] a kiválasztás hosszát adja meg. Ezek együtt egy adott szövegtartományhoz kötik a megjegyzést az AutoShape-en belül.

A [ModernComment.getStatus] és a [ModernComment.setStatus] metódusok a [ModernCommentStatus] konstansok egyik értékét adják vissza:
- [NotDefined] — nincs meghatározott modern megjegyzés állapot.
- [Active] — a megjegyzés aktív.
- [Resolved] — a megjegyzés megoldott.
- [Closed] — a megjegyzés lezárt.

A következő példa létrehoz egy alakzathoz rögzített modern megjegyzést, szövegválasztáshoz társítja, megoldottként jelöli, elmenti a bemutatót, és a fájl újranyitása után ellenőrzi az értékeket.

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

Egy meglévő bemutató ellenőrzéséhez ellenőrizze, mely megjegyzések [ModernComment] példányok, majd vizsgálja meg a [ModernComment.getShape], [ModernComment.getTextSelectionStart], [ModernComment.getTextSelectionLength] és [ModernComment.getStatus] metódusokat. A `None` alakzat egy dia-szintű megjegyzést jelez. Egy [AutoShape] rögzítő esetén a szövegkijelölési metódusok a hozzá tartozó tartományt az alakzat szövegkeretében azonosítják.

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

### **Minden megjegyzés és megjegyzés-szerző eltávolítása**

A következő példa bemutatja, hogyan távolíthatók el az összes megjegyzés és megjegyzés-szerző egy bemutatóból:

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

### **Kijelölt megjegyzések eltávolítása**

A következő példa megmutatja, hogyan távolíthatók el egy diáról a konkrét megjegyzések:

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

**Támogatja-e az Aspose.Slides a megoldott állapotot a modern megjegyzéseknél?**

Igen. A [ModernComment.getStatus] és a [ModernComment.setStatus] a [ModernCommentStatus] egy értékét adja vissza, beleértve a `Resolved` állapotot is. Az állapot a bemutatóban tárolódik, és a fájl újranyitása után újból leolvasható.

**Támogatottak-e a szálas viták (válaszláncok), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a szülő megjegyzésre, lehetővé téve a válaszláncokat. Az API nem határoz meg konkrét beágyazási mélységkorlátot.

**Milyen koordinátrendszerben van meghatározva a megjegyzés-jelző pozíciója egy dián?**

A jelző pozíciója lebegőpontos koordinátákkal van meghatározva a dia koordinátrendszerében, ami lehetővé teszi a pontos elhelyezést a dián.