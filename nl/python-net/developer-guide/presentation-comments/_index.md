---
title: Beheer presentatie‑opmerkingen in Python
linktitle: Presentatie‑opmerkingen
type: docs
weight: 100
url: /nl/python-net/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint‑opmerkingen
- presentatie‑opmerkingen
- dia‑opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking verwijderen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatie‑opmerkingen met Aspose.Slides for Python via .NET: voeg toe, lees, bewerk, beantwoord en verwijder opmerkingen in PowerPoint‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑opmerkingen kunt beheren met Aspose.Slides voor Python via .NET. Het introduceert de belangrijkste opmerkinggerelateerde types en demonstreert hoe u opmerkingen aan dia's kunt toevoegen, bestaande opmerkingen kunt benaderen, met antwoorden en moderne opmerkingen kunt werken, en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden behandelen veelvoorkomende beoordelings‑ en samenwerkingsscenario's in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van opmerkingstekst en metadata, het opbouwen van antwoordketens, en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia's. Het selecteren van een opmerking toont de tekst en de bijbehorende discussie.

## **Waarom opmerkingen toevoegen aan presentaties?**

U kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides voor Python via .NET biedt de volgende API's voor het werken met opmerkingen:

* De [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse, die toegang biedt tot de commentauteurs van de presentatie.
* De [CommentCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/commentcollection/) klasse, die de opmerkingen vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [Comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/) klasse, die informatie over een opmerking levert, inclusief auteur, aanmaakdatum, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/commentauthor/) klasse, die informatie over een auteur biedt, inclusief naam, initialen en bijbehorende opmerkingen.

## **Opmerkingen aan dia's toevoegen**

Het volgende voorbeeld toont hoe u opmerkingen aan dia's kunt toevoegen in een PowerPoint‑presentatie:

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

## **Opmerkingen van dia's benaderen**

Het volgende voorbeeld toont hoe u bestaande opmerkingen in een PowerPoint‑presentatie kunt benaderen:

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

## **Antwoorden op opmerkingen**

Een hoofdopmerking is de oorspronkelijke opmerking bovenaan een antwoordhiërarchie. De [parent_comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/parent_comment/) eigenschap van de [Comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/) klasse stelt u in staat de ouder van een opmerking op te vragen of in te stellen.

Het volgende voorbeeld toont hoe u antwoorden kunt toevoegen en de resulterende opmerkinghiërarchie kunt inspecteren:

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
* Wanneer de [remove](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/remove/) methode van de [Comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/) klasse wordt gebruikt om een opmerking te verwijderen, worden ook alle antwoorden op die opmerking verwijderd.
* Als de [parent_comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/parent_comment/) eigenschap een cirkelvormige referentie creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/commentcollection/add_modern_comment/) methode accepteert een [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) argument naast de dia- en opmerking‑marker‑coördinaten.

Wanneer `None` wordt doorgegeven voor het shape‑argument, is de opmerking een dia‑niveau opmerking. De marker wordt gepositioneerd met de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [ModernComment.shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/shape/) `None` retourneert. Wanneer er een [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) wordt opgegeven, wordt de opmerking aan die vorm verankerd. De coördinaten blijven de positie van de opmerkingmarker op de dia bepalen, terwijl de vormkoppeling kan worden opgehaald via [ModernComment.shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/shape/).

### **Een moderne opmerking aan een vorm verankeren**

Het volgende voorbeeld maakt zowel een moderne opmerking op dia‑niveau als een moderne opmerking verankerd aan een specifieke AutoShape. Het leest vervolgens de gekoppelde vorm uit elke opmerking.

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

### **Opmerkingen aan verschillende vormtypen verankeren**

Elk dia‑object afgeleid van [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) kan worden gebruikt als vormanker. Veelvoorkomende voorbeelden zijn [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nl/python-net/aspose.slides/connector/) en [GraphicalObject](https://reference.aspose.com/slides/nl/python-net/aspose.slides/graphicalobject/) instanties, zoals diagrammen.

Het volgende voorbeeld maakt verschillende veelvoorkomende vormtypen aan en koppelt een moderne opmerking aan elk van hen.

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

### **Een opmerking aan tekst verankeren en de status instellen**

Voor een moderne opmerking gekoppeld aan een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) geeft [ModernComment.text_selection_start](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/text_selection_start/) de startpositie van de geselecteerde tekst in het tekstframe van de vorm aan, terwijl [ModernComment.text_selection_length](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/text_selection_length/) de lengte van de selectie aangeeft. Samen koppelen deze eigenschappen de opmerking aan een specifieke tekstreeks binnen de AutoShape.

De [ModernComment.status](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/status/) eigenschap kan worden gelezen of bijgewerkt met een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncommentstatus/) enumeratie:

- `NOT_DEFINED` — geen specifieke moderne‑opmerkingstatus is gedefinieerd.
- `ACTIVE` — de opmerking is actief.
- `RESOLVED` — de opmerking is opgelost.
- `CLOSED` — de opmerking is gesloten.

Het volgende voorbeeld maakt een vormverankerde moderne opmerking, koppelt deze aan een tekstreeks, markeert deze als opgelost, slaat de presentatie op en verifieert de waarden na het opnieuw openen van het bestand.

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

### **Bestaande moderne opmerkingen inspecteren**

Om een bestaande presentatie te inspecteren, controleer welke opmerkingen van het type [ModernComment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/) zijn, en bekijk vervolgens [ModernComment.shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/text_selection_length/) en [ModernComment.status](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/status/). Een `None` vorm geeft een opmerking op dia‑niveau aan. Voor een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) anker identificeren de tekst‑selectie‑eigenschappen het gekoppelde bereik in het tekstframe van de vorm.

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

## **Opmerkingen verwijderen**

### **Alle opmerkingen en opmerkingauteurs verwijderen**

Het volgende voorbeeld toont hoe u alle opmerkingen en opmerkingauteurs uit een presentatie kunt verwijderen:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Specifieke opmerkingen verwijderen**

Het volgende voorbeeld toont hoe u specifieke opmerkingen van een dia kunt verwijderen:

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

**Ondersteunt Aspose.Slides een opgeloste status voor moderne opmerkingen?**

Ja. [ModernComment.status](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/status/) kan gelezen en ingesteld worden met een [ModernCommentStatus](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncommentstatus/) waarde, inclusief `RESOLVED`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand opnieuw is geopend.

**Worden thread‑discussies (antwoordketens) ondersteund, en is er een limiet op het niveau van geneste reacties?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/parent_comment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van nesting.

**In welk coördinatensysteem wordt de positie van een opmerkingmarker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevend‑kommagetallen in het dia‑coördinatensysteem, waardoor u de marker nauwkeurig op de dia kunt plaatsen.