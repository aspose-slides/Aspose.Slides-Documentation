---
title: Python bemutató megjegyzések kezelése
linktitle: Bemutató megjegyzések
type: docs
weight: 100
url: /hu/python-net/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- bemutató megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Kezelje a bemutató megjegyzéseket az Aspose.Slides for Python via .NET segítségével: adjon hozzá, olvassa, szerkessze, válaszoljon, és távolítsa el a megjegyzéseket a PowerPoint bemutatókban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a bemutató megjegyzései az Aspose.Slides for Python via .NET segítségével. Bemutatja a fő megjegyzéssel kapcsolatos típusokat, és megmutatja, hogyan adhatók megjegyzések a diákhoz, hogyan érhetők el a meglévő megjegyzések, hogyan dolgozhatunk válaszokkal és modern megjegyzésekkel, valamint hogyan távolíthatók el a megjegyzések a bemutatóból.

A példák a PowerPoint gyakori felülvizsgálati és együttműködési forgatókönyveit fedik le, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, válaszláncok felépítését, valamint a kijelölt vagy összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti a szövegét és a kapcsolódó megbeszélést.

Annak kéréséhez, hogy a megjegyzések megjelenjenek vagy el legyenek rejtve a bemutató megnyitásakor anélkül, hogy magukat a megjegyzéseket módosítanánk, lásd a [Megjegyzések megjelenítése vagy elrejtése bemutató megnyitásakor](/slides/hu/python-net/presentation-view-properties/).

## **Miért adjunk megjegyzéseket a bemutatókhoz?**

A megjegyzések segítségével visszajelzést adhat és együttműködhet a kollégákkal a bemutatók felülvizsgálata során.

Az Aspose.Slides for Python via .NET a következő API‑kat biztosítja a megjegyzésekkel való munkához:

* A [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztály, amely hozzáférést biztosít a bemutató megjegyzés‑szerzőihez.
* A [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) osztály, amely egy adott szerzőhöz kapcsolódó megjegyzéseket képviseli.
* A [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) osztály, amely információkat nyújt egy megjegyzésről, beleértve a szerzőt, a létrehozás időpontját, a pozíciót és a szöveget.
* A [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) osztály, amely információkat nyújt egy szerzőről, beleértve a nevét, a kezdőbetűit és a kapcsolódó megjegyzéseket.

## **Diák megjegyzéseinek hozzáadása**

A példa két diát hoz létre, és egy megjegyzés‑szerzőt regisztrál a [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) segítségével. Az [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) használatával egy megjegyzést helyez el minden dián, majd a [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) segítségével lekéri az első dia megjegyzéseit az adott szerzőhez. A konzol kétszer jeleníti meg az első megjegyzés szövegét, bemutatva a hozzáférést mind a diáról, mind a szerzőről, és a mentett bemutató mindkét megjegyzést tartalmazza.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
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

## **Megjegyzés‑szerző keresése vagy létrehozása**

Amikor egy automatizált felülvizsgálat többször is feldolgozza ugyanazt a bemutatót, a [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) gyűjteményt keresni kell egy szerző hozzáadása előtt. A [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) a név és a kezdőbetűk egyaránt egyezik, és egy tömböt ad vissza a megfelelő szerzőkkel, vagy egy üres tömböt, ha nincs egyezés. Ezzel szemben a [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) csak név alapján keres, a kezdőbetűktől függetlenül. Egy már meglévő név‑ és kezdőbetűpárral való [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) hívás kivételt dob.

A példa legalább egy diát tartalmazó bemutatófájlt igényel. Két átfutás során újra felhasználja az első egyező szerzőt, vagy csak akkor hoz létre újat, ha az eredmény üres. Több egyezés esetén az első tömb‑elemet választja anélkül, hogy egyesítené vagy eltávolítaná a többi szerzőt. Ezután a [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) hívással a kiválasztott szerzőhöz hozzáad egy megjegyzést, és elmenti a bemutatót. A második átfutás megnyitja az első átfutás kimenetét és megismétli a műveletet.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

A második átfutás egy újabb megjegyzést ad hozzá anélkül, hogy új szerzőt hozna létre vagy a meglévő megjegyzéseket eltávolítaná. A végső fájl, `review_pass_2.pptx`, mindkét új megjegyzést tartalmazza az eredeti megjegyzésekkel együtt. Egy szerző újbóli felhasználása nem szűri ki a duplikált megjegyzéseket: a többszöri hozzáadás elkerüléséhez külön duplikátum‑detektálást kell megvalósítani a hozzáadás előtt.

## **Megjegyzés‑szerzők elérése**

A példa meglévő bemutatót nyit meg, és beolvassa a [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) gyűjteményt. Minden szerzőhez végigiterál a [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) listáján, és kiírja a dia számát, a megjegyzés szövegét, a szerző nevét és a létrehozás időpontját. A bemeneti bemutatónak tartalmaznia kell megjegyzéseket ahhoz, hogy a konzol kimenete megjelenjen.

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

## **Válasz a megjegyzésekre**

Egy szülő‑megjegyzés a válasz‑hierarchia tetején lévő eredeti megjegyzés. A [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) osztály [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) tulajdonsága lehetővé teszi a szülő megjegyzés lekérését vagy beállítását.

A példa két szerző megjegyzéseit hozza létre, és a [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) segítségével felépíti a válaszokat, beleértve egy válasz egy másik válaszra is. A `None` érték átadása a [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) metódusnak az összes szerző megjegyzéseit adja vissza; a konzol minden bejegyzést a válasz‑hierarchiában elfoglalt mélysége szerint behúz. A példa elmenti a teljes megbeszélést, a [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) metódust hívja az első gyökér‑megjegyzésen, és egy második bemutatót ment, amelyben az a megjegyzés és válaszai eltávolításra kerültek.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Amikor a [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) metódust a [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) osztályban használják megjegyzés törlésére, a megjegyzés összes válasza is törlődik.
* Ha a [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) tulajdonság körkörös hivatkozást hoz létre, egy [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) kerül dobásra.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

A modern megjegyzések kapcsolódhatnak a diához magához, egy adott alakzathoz vagy egy AutoShape szöveg‑tartományához. A [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) metódus a [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) argumentumot is elfogadja a dia és a megjegyzés‑jelölő koordinátái mellett.

Ha a shape argumentum értéke `None`, a megjegyzés diálszintű megjegyzés. A jelölő a megadott koordinátákkal kerül elhelyezésre, de nem kapcsolódik egy konkrét alakzathoz, ezért a [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) `None`‑t ad vissza. Ha egy [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) van megadva, a megjegyzés ahhoz az alakzathoz van rögzítve. A koordináták továbbra is a megjegyzés‑jelölő pozícióját határozzák a dián, míg az alakzathoz való kapcsolódás a [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) segítségével kérdezhető le.

### **Modern megjegyzés rögzítése alakzathoz**

A példa kétszer hívja meg a [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) metódust: egyszer `None` shape‑szel egy diálszintű megjegyzéshez, egyszer pedig egy téglalappal az anchor‑ként. A [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) kiolvasása `True`‑t ad a diálszintű megjegyzés null ellenőrzésére és a `Revenue title`‑t az anchor‑olt megjegyzésre. Mindkét megjegyzés elmentésre kerül a bemutatóval.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Megjegyzések rögzítése különböző alakzattípusokhoz**

Bármely [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) osztályból származó diaobjektum használható alakzat‑ankernak. Gyakori példák a [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), a [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), a [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) és a [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) példányok, például diagramok.

A példa a [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) metódust használja, hogy megjegyzést kapcsoljon öt alakzattípushoz: egy AutoShape‑hez, egy képkerethez, egy csoporthoz, egy connector‑hoz és egy diagramhoz. A kép beágyazott képadatot használ, ezért nincs szükség külső képre. Minden megjegyzésnek saját jelölőpozíciója van, és a mentett bemutató megőrzi az öt alakzat‑kapcsolatot.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Megjegyzés rögzítése szöveghez és állapotának beállítása**

Egy modern megjegyzéshez, amely egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-hez kapcsolódik, a [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) a kijelölt szöveg kezdőpozícióját adja meg az alakzat szövegkeretében, míg a [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) a kijelölés hosszát határozza meg. Ezek a tulajdonságok együtt a megjegyzést egy meghatározott szövegtartományhoz kötik az AutoShape‑ben.

A [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) tulajdonság olvasható vagy frissíthető a [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) felsorolás egyik értékével:

- `NOT_DEFINED` — nincs meghatározott modern‑megjegyzés állapot.
- `ACTIVE` — a megjegyzés aktív.
- `RESOLVED` — a megjegyzés megoldott.
- `CLOSED` — a megjegyzés lezárt.

A példa egy modern megjegyzést rögzít a „quarterly revenue” szavakhoz egy téglalap szövegében. A null‑alapú [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) a szövegből kerül kiszámításra, a [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) pedig a kijelölt karakterek számára állítódik. A [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) `RESOLVED`‑re állítása után a bemutató mentésre és újra megnyitásra kerül. A négy konzol‑ellenőrzés mindegyike `True`‑t kell, hogy kiírjon, ezzel megerősítve, hogy az alakzat‑anchor, a szöveg‑tartomány és az állapot megmaradt.

```python
from datetime import datetime

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
    comment_position = slides.PointF(60, 60)
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

### **Létező modern megjegyzések ellenőrzése**

A példa egy meglévő bemutatót igényel, amely modern megjegyzéseket tartalmaz, és kiírja azok szövegét, állapotát és anchor részleteit. A vizsgálathoz ellenőrizze, hogy a megjegyzések példányai [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/)-ek‑e, majd vizsgálja meg a [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), a [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), a [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) és a [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) értékeket. A `None` shape egy diálszintű megjegyzést jelez. Egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) anchor esetén a szöveg‑kijelölési tulajdonságok az alakzat szövegkeretében lévő tartományt azonosítják.

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

## **Megjegyzések eltávolítása**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy az összes megjegyzést és szerzőjüket eltávolítsa egy bemutatóból, vagy csak a kiválasztott megjegyzéseket törölje, a többit megtartva. Az alábbi példák mindkét megközelítést bemutatják, és mentik a frissített bemutatót.

### **Minden megjegyzés és megjegyzés‑szerző eltávolítása**

A példa egy meglévő bemutatót nyit meg, és minden szerzőnél meghívja a [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) metódust, majd a [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) hívással eltávolítja magukat a szerzőket. A mentett bemutató sem megjegyzéseket, sem megjegyzés‑szerzőket nem tartalmaz. A eltávolítás megfigyeléséhez használjon olyan bemutatót, amely tartalmaz megjegyzéseket.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Specifikus megjegyzések eltávolítása**

A példa két megjegyzést hoz létre egy dián, és a [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) segítségével megtalálja minden szerző megjegyzéseit. Azokat a megjegyzéseket gyűjti, amelyek szövege „comment 1”, mielőtt meghívná a [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/) metódust, így elkerülve a gyűjtemény módosítását a kiválasztás során. A mentett bemutató csak a „comment 2” megjegyzést tartja meg.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
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

**Támogatja-e az Aspose.Slides a modern megjegyzések megoldott állapotát?**

Igen. A [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) olvasható és beállítható egy [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) értékkel, beleértve a `RESOLVED`‑t. Az állapot a bemutatóban tárolódik, és újra kiolvasható a fájl újra megnyitása után.

**Támogatottak-e a szálas megbeszélések (válasz‑láncok), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/)‑re, így lehetővé téve a válasz‑láncokat. Az API nem definiál konkrét beágyazási mélység‑korlátot.

**Milyen koordináta‑rendszerben van definiálva egy megjegyzés‑jelölő pozíciója a dián?**

A jelölő pozíciója lebegőpontos koordinátákkal van megadva a dia koordináta‑rendszerében, lehetővé téve a pontos elhelyezést a dián.