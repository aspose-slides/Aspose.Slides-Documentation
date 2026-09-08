---
title: Hantera presentationskommentarer i Python via Java
linktitle: Presentationskommentarer
type: docs
weight: 100
url: /sv/python-java/presentation-comments/
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
- Java
- Aspose.Slides
description: "Hantera presentationskommentarer med Aspose.Slides för Python via Java: lägg till, läs, redigera, svara på och ta bort kommentarer i PowerPoint-presentationer snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar presentationskommentarer med Aspose.Slides för Python via Java. Den introducerar de viktigaste typerna relaterade till kommentarer och visar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings- och samarbetsscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentarsinnehåll och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som anteckningar på bilder. När du markerar en kommentar visas dess text och relaterade diskussion.

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge återkoppling och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för Python via Java tillhandahåller följande API:er för att arbeta med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som ger åtkomst till presentationens kommentarförfattare.
* Klassen [CommentCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/commentcollection/) som representerar kommentarer som är kopplade till en enskild författare.
* Klassen [Comment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/comment/) som tillhandahåller information om en kommentar, inklusive dess författare, skapningstid, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/commentauthor/) som ger information om en författare, inklusive namn, initialer och associerade kommentarer.

## **Lägg till bildkommentarer**

Följande exempel visar hur du lägger till kommentarer på bilder i en PowerPoint-presentation:

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

## **Hämta bildkommentarer**

Följande exempel visar hur du får åtkomst till befintliga kommentarer i en PowerPoint-presentation:

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

## **Svara på kommentarer**

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Metoderna [Comment.getParentComment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/comment/#getParentComment) och [Comment.setParentComment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/comment/#setParentComment) låter dig hämta eller ange föräldern för en kommentar.

Följande exempel visar hur du lägger till svar och inspekterar den resulterande kommentarshierarkin:

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
* När metoden [Comment.remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/comment/#remove) används för att ta bort en kommentar, tas också alla svar på den kommentaren bort.
* Om [Comment.setParentComment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/comment/#setParentComment) skapar en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan kopplas till själva bilden, till en specifik form eller till ett textintervall i en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/). Metoden [CommentCollection.addModernComment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/commentcollection/#addModernComment) accepterar ett [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/)‑argument utöver bild‑ och kommentarmarkörkoordinaterna.

När `None` skickas för shape‑argumentet är kommentaren en bildnivåkommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte kopplad till någon särskild form, så [ModernComment.getShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getShape) returnerar `None`. När en [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/) anges, förankras kommentaren i den formen. Koordinaterna definierar fortfarande positionen för kommentarmarkören på bilden, medan formkopplingen kan hämtas via [ModernComment.getShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getShape).

### **Förankra en modern kommentar till en form**

Följande exempel skapar både en bildnivå modern kommentar och en modern kommentar förankrad till en specifik [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/). Det läser sedan den associerade formen från varje kommentar.

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

### **Förankra kommentarer till olika formtyper**

Alla bildobjekt som ärver från [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/) kan användas som formankare. Vanliga exempel inkluderar [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connector/) och [GraphicalObject](https://reference.aspose.com/slides/sv/python-java/aspose.slides/graphicalobject/)-instanser såsom diagram.

Följande exempel skapar flera vanliga formtyper och kopplar en modern kommentar till var och en.

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

### **Förankra en kommentar till text och ange dess status**

För en modern kommentar kopplad till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/), ger [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getTextSelectionStart) och [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#setTextSelectionStart) åtkomst till startpositionen för den markerade texten i formens textruta. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getTextSelectionLength) och [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#setTextSelectionLength) ger åtkomst till längden på markeringen. Tillsammans binder dessa värden kommentaren till ett specifikt textintervall i AutoShape.

[ModernComment.getStatus](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getStatus) och [ModernComment.setStatus](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#setStatus) metoderna hämtar ett värde från [ModernCommentStatus](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncommentstatus/)‑konstanterna:

- [NotDefined](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncommentstatus/#NotDefined) — ingen specifik modern‑kommentarstatus är definierad.
- [Active](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncommentstatus/#Active) — kommentaren är aktiv.
- [Resolved](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncommentstatus/#Resolved) — kommentaren har lösts.
- [Closed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncommentstatus/#Closed) — kommentaren är stängd.

Följande exempel skapar en formförankrad modern kommentar, kopplar den till en textmarkering, markerar den som löst, sparar presentationen och verifierar värdena efter att filen har öppnats igen.

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

### **Inspektera befintliga moderna kommentarer**

För att inspektera en befintlig presentation, kontrollera vilka kommentarer som är instanser av [ModernComment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/), och undersök sedan [ModernComment.getShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getTextSelectionLength) och [ModernComment.getStatus](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getStatus). En `None`‑form indikerar en bildnivåkommentar. För ett [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/)‑ankare identifierar textmarkeringsmetoderna det associerade intervallet i formens textruta.

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

## **Ta bort kommentarer**

### **Ta bort alla kommentarer och kommentarförfattare**

Följande exempel visar hur du tar bort alla kommentarer och kommentarförfattare från en presentation:

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

### **Ta bort specifika kommentarer**

Följande exempel visar hur du tar bort specifika kommentarer från en bild:

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

## **FAQ**

**Stöder Aspose.Slides en löst status för moderna kommentarer?**

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#getStatus) och [ModernComment.setStatus](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncomment/#setStatus) hämtar ett [ModernCommentStatus](https://reference.aspose.com/slides/sv/python-java/aspose.slides/moderncommentstatus/)‑värde, inklusive `Resolved`. Statusen lagras i presentationen och kan läsas igen när filen öppnas på nytt.

**Stöds trådade diskussioner (svarskedjor) och finns det en gräns för nästlingsnivå?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/comment/#getParentComment), vilket möjliggör svarskedjor. API‑et definierar ingen specifik gräns för nästlingsdjup.

**I vilket koordinatsystem är en kommentarmärkas position definierad på en bild?**

Markörens position definieras av flyttal‑koordinater i bildens koordinatsystem, vilket gör att du kan placera den exakt på bilden.