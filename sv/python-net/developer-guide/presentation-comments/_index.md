---
title: Hantera presentationskommentarer i Python
linktitle: Presentationskommentarer
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

Denna artikel förklarar hur man hanterar presentationskommentarer med Aspose.Slides för Python via .NET. Den introducerar de viktigaste kommentarrelaterade typerna och demonstrerar hur man lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings- och samarbetsscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentartext och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som anteckningar på bilder. När du markerar en kommentar visas dess text och relaterade diskussion.

För att begära att kommentarer visas eller döljes när en presentation öppnas utan att ändra kommentarerna själva, se [Visa eller dölj kommentarer när en presentation öppnas](/slides/sv/python-net/presentation-view-properties/).

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge återkoppling och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för Python via .NET tillhandahåller följande API:er för att arbeta med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) som ger åtkomst till presentationens kommentarförfattare.
* Klassen [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) som representerar kommentarerna som är kopplade till en enskild författare.
* Klassen [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) som tillhandahåller information om en kommentar, inklusive dess författare, skapelsedatum, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) som ger information om en författare, inklusive deras namn, initialer och associerade kommentarer.

## **Lägg till bildkommentarer**

Exemplet skapar två bilder och registrerar en kommentarförfattare med [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Det använder [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) för att placera en kommentar på varje bild, och hämtar sedan den första bildens kommentarer för den författaren med [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). Konsolen visar den första kommentarens text två gånger, vilket demonstrerar åtkomst via både bilden och författaren, och den sparade presentationen innehåller båda kommentarerna.

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

## **Hitta eller skapa en kommentarförfattare**

När en automatiserad granskning bearbetar samma presentation upprepade gånger, sök i dess [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/)‑samling innan du lägger till en författare. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) matchar både namn och initialer och returnerar en array med matchande författare, eller en tom array om inga matchningar finns. I kontrast söker [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) endast på namn, oavsett initialer. Att anropa [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) med ett namn och initialer som redan finns i samlingen kastar ett undantag.

Exemplet kräver en presentationsfil med minst en bild. Vid varje av två genomgångar återanvänder det den första matchande författaren, eller skapar en endast när resultatet är tomt. Om det finns flera matchningar väljer det det första arrayelementet utan att slå ihop eller ta bort de andra författarna. Det anropar sedan [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) för den valda författaren och sparar presentationen. Den andra genomgången öppnar utdata från den första genomgången och upprepar operationen.

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

Den andra genomgången lägger till en ny kommentar utan att lägga till en ny författare eller ta bort befintliga kommentarer. Den slutgiltiga filen, `review_pass_2.pptx`, innehåller båda nya kommentarerna tillsammans med eventuella ursprungliga kommentarer. Återanvändning av en författare deduplicerar inte kommentarer: för att undvika att upprepade gånger lägga till samma kommentar, implementera separat duplikatdetektering innan du lägger till den.

## **Få åtkomst till bildkommentarer**

Exemplet öppnar en befintlig presentation och läser dess [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/)‑samling. För varje författare itererar det genom [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) och skriver ut bildnumret, kommentartexten, författarens namn och skapningstid. Inmatningspresentationen måste innehålla kommentarer för att producera konsolutdata.

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

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Egenskapen [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) i klassen [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) låter dig hämta eller sätta föräldern till en kommentar.

Exemplet skapar kommentarer från två författare och använder [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) för att bygga svar, inklusive ett svar på ett annat svar. Att skicka `None` till [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) hämtar kommentarer från alla författare; konsolen indenterar varje post enligt dess djup i svarshierarkin. Exemplet sparar den kompletta diskussionen, anropar [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) på den första huvudkommentaren, och sparar en andra presentation där den kommentaren och dess svar har tagits bort.

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
* När [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/)‑metoden i [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/)‑klassen används för att radera en kommentar, tas alla svar på den kommentaren också bort.
* Om [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/)‑egenskapen skapar en cirkulär referens kastas ett [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan associeras med själva bilden, med en specifik shape eller med ett texträckvidd inuti en AutoShape. Metoden [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) accepterar ett [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑argument utöver bild‑ och kommentar‑markörkoordinaterna.

När `None` skickas för shape‑argumentet är kommentaren en bildnivåkommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte kopplad till någon specifik shape, så [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) returnerar `None`. När en [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) tillhandahålls är kommentaren förankrad till den shape. Koordinaterna definierar fortfarande positionen för kommentar­markören på bilden, medan shape‑associationen kan hämtas via [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) .

### **Förankra en modern kommentar till en shape**

Exemplet anropar [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) två gånger: en gång med en `None`‑shape för en bildnivåkommentar och en gång med en rektangel som förankring. Att läsa [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) skriver ut `True` för bildnivåkommentarens null‑kontroll och `Revenue title` för den förankrade kommentaren. Båda kommentarerna sparas tillsammans med presentationen.

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

### **Förankra kommentarer till olika shape-typer**

Alla bildobjekt som är härledda från [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) kan användas som en shape‑förankring. Vanliga exempel inkluderar [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) och [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/)‑instanser såsom diagram.

Exemplet använder [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) för att associera en kommentar med var och en av fem shape‑typer: en AutoShape, en picture frame, en grupp, en connector och ett diagram. Bilden använder inbäddad bilddata, så ingen extern bild krävs. Varje kommentar har sin egen markörposition, och den sparade presentationen behåller alla fem shape‑associationer.

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

### **Förankra en kommentar till text och ange dess status**

För en modern kommentar som är associerad med en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) specificerar [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) startpositionen för den markerade texten i shape:ens textruta, medan [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) anger längden på markeringen. Tillsammans associerar dessa egenskaper kommentaren med ett specifikt texträckvidd inuti AutoShape.

[ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) kan läsas eller sättas med ett [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/)‑värde, inklusive `RESOLVED`. Statusen lagras i presentationen och kan läsas igen efter att filen har öppnats på nytt.

- `NOT_DEFINED` — ingen specifik modern‑kommentarstatus är definierad.
- `ACTIVE` — kommentaren är aktiv.
- `RESOLVED` — kommentaren har lösts.
- `CLOSED` — kommentaren är stängd.

Exemplet förankrar en modern kommentar till orden "quarterly revenue" i en rektangels text. Det beräknar den nollbaserade [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) från texten och sätter [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) till antalet valda tecken. Efter att ha satt [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) till `RESOLVED` sparas och öppnas presentationen igen. De fyra konsollkontrollerna bör vardera skriva ut `True`, vilket bekräftar att shape‑förankringen, texträckvidden och statusen bevarades.

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

### **Inspektera befintliga moderna kommentarer**

Exemplet kräver en befintlig presentation som innehåller moderna kommentarer och skriver ut deras text, status och förankringsdetaljer. För att inspektera den, kontrollera vilka kommentarer som är instanser av [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), sedan granska [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) och [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). En `None`‑shape indikerar en bildnivåkommentar. För en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑förankring identifierar texträckviddsegenskaperna det associerade intervallet i shape:ens textruta.

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

Aspose.Slides för Python via .NET låter dig ta bort alla kommentarer och deras författare från en presentation eller radera utvalda kommentarer samtidigt som resten behålls. Följande exempel demonstrerar båda tillvägagångssätten och sparar den uppdaterade presentationen.

### **Ta bort alla kommentarer och kommentarförfattare**

Exemplet öppnar en befintlig presentation och anropar [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) för varje författare, och anropar sedan [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) för att ta bort själva författarna. Den sparade presentationen innehåller varken kommentarer eller kommentarförfattare. Använd en presentation som innehåller kommentarer för att observera borttagningen.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Ta bort specifika kommentarer**

Exemplet skapar två kommentarer på en bild och använder [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) för att hitta kommentarer per författare. Det samlar kommentarer vars text är lika med "comment 1" innan [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/) anropas, för att undvika förändringar i samlingen under urvalet. Den sparade presentationen behåller endast "comment 2".

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

## **FAQ**

**Stöder Aspose.Slides en löst status för moderna kommentarer?**

Ja. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) kan läsas och sättas med ett [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/)‑värde, inklusive `RESOLVED`. Statusen lagras i presentationen och kan läsas igen efter att filen har öppnats på nytt.

**Stöds trådade diskussioner (svarskedjor) och finns det någon begränsning för nästning?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), vilket möjliggör svarskedjor. API:et definierar ingen specifik begränsning för nästningsdjup.

**I vilket koordinatsystem definieras en kommentarmarkers position på en bild?**

Markeringspositionen definieras av flyttal‑koordinater i bildens koordinatsystem, vilket gör att du kan placera den exakt på bilden.