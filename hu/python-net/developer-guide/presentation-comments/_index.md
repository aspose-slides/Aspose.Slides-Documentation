---
title: Prezentációs megjegyzések kezelése Pythonban
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/python-net/presentation-comments/
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
- Aspose.Slides
description: "Az Aspose.Slides for Python via .NET segítségével kezelheti a prezentációs megjegyzéseket: hozzáadhat, olvashat, szerkeszthet, válaszolhat és eltávolíthat megjegyzéseket PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a prezentációs megjegyzések az Aspose.Slides for Python via .NET segítségével. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és azt, hogyan adhat megjegyzéseket a diákhoz, érheti el a meglévő megjegyzéseket, dolgozhat válaszokkal és modern megjegyzésekkel, valamint hogyan távolíthatja el a megjegyzéseket a prezentációból.

A példák lefedik a PowerPoint gyakori felülvizsgálati és együttműködési szituációit, például a megjegyzések szerzőkhöz rendelését, a megjegyzésszöveg és metaadatok olvasását, a válaszkövetések építését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti a szövegét és a kapcsolódó vitát.

A megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor, anélkül, hogy a megjegyzéseket módosítaná, lásd [A megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor](/slides/hu/python-net/presentation-view-properties/).

## **Miért érdemes megjegyzéseket hozzáadni a prezentációkhoz?**

A megjegyzéseket felhasználhatja visszajelzés adására és a kollégákkal való együttműködésre a prezentációk felülvizsgálata során.

Aspose.Slides for Python via .NET a következő API-kat biztosítja a megjegyzésekkel való munkához:

* A [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a prezentáció megjegyzésíróihoz.
* A [CommentCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/commentcollection/) osztály, amely egy adott szerzőhöz kapcsolódó megjegyzéseket képviseli.
* A [Comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/) osztály, amely információkat biztosít egy megjegyzésről, beleértve a szerzőjét, létrehozási időt, pozíciót és szöveget.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/python-net/aspose.slides/commentauthor/) osztály, amely információkat nyújt egy szerzőről, beleértve a nevét, monogramját és a kapcsolódó megjegyzéseket.

## **Dia Megjegyzések Hozzáadása**

Az alábbi példa bemutatja, hogyan adhatók megjegyzések a diákhoz egy PowerPoint prezentációban:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia Megjegyzések Elérése**

Az alábbi példa bemutatja, hogyan érhetők el a meglévő megjegyzések egy PowerPoint prezentációban:

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Válasz a Megjegyzésekre**

A szülőmegjegyzés a válaszak hierarchiájának tetején levő eredeti megjegyzés. A [Comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/) osztály [parent_comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/parent_comment/) tulajdonsága lehetővé teszi a megjegyzés szülőjének lekérdezését vagy beállítását.

Az alábbi példa bemutatja, hogyan adhatók hozzá válaszok és hogyan vizsgálható meg a keletkezett megjegyzéshierarchia:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Amikor a [Comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/) osztály [remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/remove/) metódusa egy megjegyzés törlésére használatos, akkor a megjegyzés összes válasza is törlődik.
* Ha a [parent_comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/parent_comment/) tulajdonság körkörös hivatkozást hoz létre, akkor egy [PptxEditException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxeditexception/) kivétel kerül dobásra.
{{% /alert %}}

## **Modern Megjegyzések Hozzáadása**

A modern megjegyzések a diával, egy konkrét alakzattal vagy egy AutoShape-on belüli szövegtartománnyal társíthatók. A [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/commentcollection/add_modern_comment/) metódus egy [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) argumentumot is elfogad a dia- és megjegyzésjelző koordinátákon felül.

Ha a shape argumentumnak `None` értéket adunk, a megjegyzés dia-szintű megjegyzés lesz. Jelzője a megadott koordinátákkal helyezkedik el, de nem kapcsolódik egy meghatározott alakzathoz, ezért a [ModernComment.shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/shape/) `None` értéket ad vissza. Ha egy [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) kerül megadásra, a megjegyzés az adott alakzathoz van rögzítve. A koordináták továbbra is a megjegyzésjelző pozícióját határozzák meg a dian, míg az alakzattal való kapcsolat a [ModernComment.shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/shape/) segítségével kérhető le.

### **Modern Megjegyzés Rögzítése Alakzathoz**

Az alábbi példa létrehoz egy dia-szintű modern megjegyzést és egy konkrét AutoShape-hoz rögzített modern megjegyzést. Ezután minden megjegyzéshez kiolvassa a kapcsolódó alakzatot.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Megjegyzések Rögzítése Különböző Alakzat Típusokhoz**

Bármely diaobjektum, amely a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályból származik, használható alakzatrögzítőként. Gyakori példák a [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/), a [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/), a [GroupShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/), a [Connector](https://reference.aspose.com/slides/hu/python-net/aspose.slides/connector/) valamint a diagramokhoz hasonló [GraphicalObject](https://reference.aspose.com/slides/hu/python-net/aspose.slides/graphicalobject/) példányok.

Az alábbi példa több gyakori alakzatot hoz létre, és minden egyeshez modern megjegyzést társít.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Megjegyzés Rögzítése Szöveghez és Állapotának Beállítása**

Egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/)‑hoz kapcsolódó modern megjegyzés esetén a [ModernComment.text_selection_start](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/text_selection_start/) a kijelölt szöveg kezdőpozícióját adja meg az alakzat szövegdobozában, míg a [ModernComment.text_selection_length](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/text_selection_length/) a kijelölés hosszát határozza meg. Együtt ezek a tulajdonságok egy adott szövegtartományhoz kötik a megjegyzést az AutoShape‑on belül.

A [ModernComment.status](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/status/) tulajdonság olvasható vagy módosítható a [ModernCommentStatus](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncommentstatus/) felsorolás egy értékével:

- `NOT_DEFINED` — nincs definiált modern‑megjegyzés állapot.
- `ACTIVE` — a megjegyzés aktív.
- `RESOLVED` — a megjegyzés megoldódott.
- `CLOSED` — a megjegyzés lezárt.

Az alábbi példa létrehoz egy alakzatra rögzített modern megjegyzést, szövegválasztáshoz társítja, megoldottként jelöli, elmenti a prezentációt, és újra megnyitás után ellenőrzi az értékeket.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Létező Modern Megjegyzések Vizsgálata**

Egy létező prezentáció vizsgálatához ellenőrizze, mely megjegyzések [ModernComment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/) példányok, majd vizsgálja meg a [ModernComment.shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/shape/), a [ModernComment.text_selection_start](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/text_selection_start/), a [ModernComment.text_selection_length](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/text_selection_length/), és a [ModernComment.status](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/status/) tulajdonságokat. A `None` alakzat dia-szintű megjegyzést jelöl. Egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) rögzítő esetén a szövegkijelölés tulajdonságai az alakzat szövegdobozában lévő kapcsolódó tartományt azonosítják.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Megjegyzések Eltávolítása**

### **Minden Megjegyzés és Megjegyzésíró Eltávolítása**

Az alábbi példa bemutatja, hogyan távolíthatók el a prezentációból az összes megjegyzés és megjegyzésíró:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Adott Megjegyzések Eltávolítása**

Az alábbi példa bemutatja, hogyan távolíthatók el adott megjegyzések egy diáról:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Támogatja az Aspose.Slides a modern megjegyzések megoldott állapotát?**

Igen. A [ModernComment.status](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncomment/status/) olvasható és beállítható a [ModernCommentStatus](https://reference.aspose.com/slides/hu/python-net/aspose.slides/moderncommentstatus/) értékével, beleértve a `RESOLVED` állapotot is. Az állapot a prezentációban tárolódik, és a fájl újra megnyitása után ismét olvasható.

**Támogatottak a szálas megbeszélések (válaszkövetések), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/comment/parent_comment/), lehetővé téve a válaszkövetéseket. Az API nem határoz meg konkrét beágyazási mélységkorlátot.

**Milyen koordinátrendszerben van meghatározva egy megjegyzésjelző pozíciója a dián?**

A jelző pozíciója a dia koordinátrendszerében lebegőpontos koordinátákkal van meghatározva, ami lehetővé teszi a pontos elhelyezést a dián.