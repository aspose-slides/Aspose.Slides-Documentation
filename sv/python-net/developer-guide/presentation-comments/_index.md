---
title: "Hantera presentationskommentarer i Python"
linktitle: "Presentationskommentarer"
type: docs
weight: 100
url: /sv/python-net/presentation-comments/
keywords:
- kommentar
- modern kommentar
- PowerPoint-kommentarer
- presentationskommentarer
- bildkommentarer
- lägg till kommentar
- åtkomst till kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera presentationskommentarer med Aspose.Slides för Python via .NET: lägg till, läs, redigera, svara på och ta bort kommentarer i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar presentationskommentarer med Aspose.Slides för Python via .NET. Den introducerar de viktigaste kommentarrelaterade typerna och demonstrerar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings- och samarbetsscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentartext och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som annotationer på bilder. När du markerar en kommentar visas dess text och relaterade diskussion.

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge återkoppling och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för Python via .NET tillhandahåller följande API:er för att arbeta med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) som ger åtkomst till presentationens kommentarförfattare.
* Klassen [CommentCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/commentcollection/) som representerar kommentarer som är knutna till en enskild författare.
* Klassen [Comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/) som tillhandahåller information om en kommentar, inklusive dess författare, skapandetid, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/python-net/aspose.slides/commentauthor/) som ger information om en författare, inklusive namn, initialer och associerade kommentarer.

## **Lägg till bildkommentarer**

Följande exempel visar hur du lägger till kommentarer på bilder i en PowerPoint-presentation:

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

## **Åtkomst till bildkommentarer**

Följande exempel visar hur du får åtkomst till befintliga kommentarer i en PowerPoint-presentation:

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

## **Svara på kommentarer**

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Egenskapen [parent_comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/parent_comment/) i klassen [Comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/) låter dig hämta eller ange föräldern till en kommentar.

Följande exempel visar hur du lägger till svar och granskar den resulterande kommentarshierarkin:

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

{{% alert color="warning" title="Varning" %}}

* När [remove](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/remove/)‑metoden i klassen [Comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/) används för att ta bort en kommentar, tas alla svar till den kommentaren också bort.
* Om egenskapen [parent_comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/parent_comment/) skapar en cirkulär referens kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pptxeditexception/).

{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan associeras med själva bilden, med en specifik form eller med ett textintervall i en AutoShape. Metoden [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/commentcollection/add_modern_comment/) accepterar ett [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/)‑argument utöver bild- och kommentarmarkörkoordinaterna.

När `None` skickas för shape‑argumentet är kommentaren en bildnivåkommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte knuten till någon specifik form, så [ModernComment.shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/shape/) returnerar `None`. När en [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) tillhandahålls, förankras kommentaren till den formen. Koordinaterna definierar fortfarande positionen för kommentarmarkören på bilden, medan form‑associationen kan hämtas via [ModernComment.shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/shape/).

### **Förankra en modern kommentar till en form**

Följande exempel skapar både en modern kommentar på bildnivå och en modern kommentar förankrad till en specifik AutoShape. Det läser sedan den associerade formen från varje kommentar.

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

### **Förankra kommentarer till olika formtyper**

Alla bildobjekt som är avledda från [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) kan användas som en formankare. Vanliga exempel inkluderar [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/sv/python-net/aspose.slides/connector/) och [GraphicalObject](https://reference.aspose.com/slides/sv/python-net/aspose.slides/graphicalobject/)-instanser såsom diagram.

Följande exempel skapar flera vanliga formtyper och associerar en modern kommentar med var och en.

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

### **Förankra en kommentar till text och ange dess status**

För en modern kommentar som är knuten till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) specificerar [ModernComment.text_selection_start](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/text_selection_start/) startpositionen för den markerade texten i formens textruta, medan [ModernComment.text_selection_length](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/text_selection_length/) specificerar längden på markeringen. Tillsammans associerar dessa egenskaper kommentaren med ett specifikt textintervall i AutoShape.

Egenskapet [ModernComment.status](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/status/) kan läsas eller uppdateras med ett värde från uppräkningen [ModernCommentStatus](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — ingen specifik modern kommentarstatus är definierad.
- `ACTIVE` — kommentaren är aktiv.
- `RESOLVED` — kommentaren har lösts.
- `CLOSED` — kommentaren är stängd.

Följande exempel skapar en formförankrad modern kommentar, associerar den med en textmarkering, markerar den som löst, sparar presentationen och verifierar värdena efter att filen har öppnats igen.

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

### **Inspektera befintliga moderna kommentarer**

För att inspektera en befintlig presentation, kontrollera vilka kommentarer som är [ModernComment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/)‑instanser, och granska sedan [ModernComment.shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/text_selection_length/) samt [ModernComment.status](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/status/). En `None`‑form indikerar en kommentar på bildnivå. För en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/)‑ankare identifierar textmarkeringsegenskaperna det associerade intervallet i formens textruta.

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

## **Ta bort kommentarer**

### **Ta bort alla kommentarer och kommentarförfattare**

Följande exempel visar hur du tar bort alla kommentarer och kommentarförfattare från en presentation:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Ta bort specifika kommentarer**

Följande exempel visar hur du tar bort specifika kommentarer från en bild:

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

## **FAQ**

**Stöder Aspose.Slides ett löst status för moderna kommentarer?**

Ja. [ModernComment.status](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/status/) kan läsas och sättas med ett [ModernCommentStatus](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncommentstatus/)‑värde, inklusive `RESOLVED`. Statusen sparas i presentationen och kan läsas igen efter att filen har öppnats.

**Stöds trådade diskussioner (svarskedjor) och finns det någon begränsning för nästning?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/parent_comment/), vilket möjliggör svarskedjor. API:et definierar ingen specifik begränsning för nästningsdjup.

**I vilket koordinatsystem definieras en kommentarmarkörs position på en bild?**

Markörens position definieras av flyttalskoordinater i bildens koordinatsystem, vilket gör att du kan placera den exakt på bilden.