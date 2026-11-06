---
title: Beheer presentatiecommentaren in Python
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/python-net/presentation-comments/
keywords:
- commentaar
- modern commentaar
- PowerPoint-commentaren
- presentatiecommentaren
- dia commentaren
- commentaar toevoegen
- commentaar benaderen
- commentaar bewerken
- commentaar beantwoorden
- commentaar verwijderen
- commentaar wissen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatiecommentaren met Aspose.Slides for Python via .NET: toevoegen, lezen, bewerken, beantwoorden en verwijderen van commentaren in PowerPoint‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatiecommentaren kunt beheren met Aspose.Slides for Python via .NET. Het introduceert de belangrijkste typen die gerelateerd zijn aan commentaren en demonstreert hoe u commentaren aan dia's kunt toevoegen, bestaande commentaren kunt benaderen, kunt werken met antwoorden en moderne commentaren, en commentaren uit een presentatie kunt verwijderen.

De voorbeelden behandelen veelvoorkomende beoordelings‑ en samenwerkingsscenario's in PowerPoint, zoals commentaren toewijzen aan auteurs, commentaartekst en metagegevens lezen, antwoordketens opbouwen, en geselecteerde commentaren of alle commentaren verwijderen.

In PowerPoint verschijnen commentaren als annotaties op dia's. Het selecteren van een commentaar toont de tekst en de bijbehorende discussie.

Om aan te geven dat commentaren moeten worden getoond of verborgen bij het openen van een presentatie zonder de commentaren zelf te wijzigen, zie [Toon of verberg commentaren bij het openen van een presentatie](/slides/nl/python-net/presentation-view-properties/).

## **Waarom commentaren toevoegen aan presentaties?**

U kunt commentaren gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides for Python via .NET biedt de volgende API's voor het werken met commentaren:

* De [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse, die toegang biedt tot de commentaarauteurs van de presentatie.
* De [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) klasse, die de commentaren vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) klasse, die informatie over een commentaar biedt, inclusief auteur, aanmaaktijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) klasse, die informatie over een auteur biedt, inclusief naam, initialen en gekoppelde commentaren.

## **Dia‑commentaren toevoegen**

Het voorbeeld maakt twee dia's aan en registreert een commentaarauteur met [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Het gebruikt [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) om één commentaar op elke dia te plaatsen, haalt vervolgens de commentaren van de eerste dia op voor die auteur met [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). De console toont de tekst van het eerste commentaar twee keer, waarmee toegang via zowel de dia als de auteur wordt aangetoond, en de opgeslagen presentatie bevat beide commentaren.

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

## **Zoek of maak een commentaarauteur**

Wanneer een geautomatiseerde beoordeling dezelfde presentatie herhaaldelijk verwerkt, doorzoek dan eerst de [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) collectie voordat u een auteur toevoegt. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) vergelijkt zowel de naam als de initialen en retourneert een array met overeenkomende auteurs, of een lege array als er geen overeenkomsten zijn. Daarentegen zoekt [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) uitsluitend op naam, ongeacht initialen. Het aanroepen van [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) met een naam en initialen die al in de collectie bestaan, veroorzaakt een exceptie.

Het voorbeeld vereist een presentatieweerder met ten minste één dia. Bij elke van de twee doorlopen wordt de eerst gevonden auteur opnieuw gebruikt, of wordt er een nieuwe aangemaakt wanneer het resultaat leeg is. Als er meerdere overeenkomsten zijn, wordt het eerste array‑element geselecteerd zonder de andere auteurs te combineren of te verwijderen. Vervolgens wordt [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) aangeroepen voor de geselecteerde auteur en wordt de presentatie opgeslagen. De tweede doorloop opent de uitvoer van de eerste doorloop en herhaalt de operatie.

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

De tweede doorloop voegt een extra commentaar toe zonder een extra auteur toe te voegen of bestaande commentaren te verwijderen. Het uiteindelijke bestand, `review_pass_2.pptx`, bevat beide nieuwe commentaren naast eventuele oorspronkelijke commentaren. Het opnieuw gebruiken van een auteur dedupliceert commentaren niet: om te voorkomen dat hetzelfde commentaar meerdere keren wordt toegevoegd, implementeer aparte detectie voor duplicaten vóór het toevoegen.

## **Toegang tot dia‑commentaren**

Het voorbeeld opent een bestaande presentatie en leest de [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) collectie. Voor elke auteur wordt door [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) geïtereerd en worden het dia‑nummer, de commentaartekst, de naam van de auteur en de aanmaaktijd afgedrukt. De invoerpresentatie moet commentaren bevatten om console‑output te genereren.

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

## **Antwoorden op commentaren**

Een hoofcommentaar is het oorspronkelijke commentaar bovenaan een antwoordhiërarchie. De [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) eigenschap van de [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) klasse stelt u in staat de ouder van een commentaar op te halen of in te stellen.

Het voorbeeld maakt commentaren van twee auteurs en gebruikt [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) om antwoorden te bouwen, inclusief een antwoord op een ander antwoord. Het doorgeven van `None` aan [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) haalt commentaren op van alle auteurs; de console inspringt elk item volgens de diepte in de antwoordhiërarchie. Het voorbeeld slaat de volledige discussie op, roept [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) aan op het eerste root‑commentaar, en slaat een tweede presentatie op waarin dat commentaar en de bijbehorende antwoorden zijn verwijderd.

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
* Wanneer de [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) methode van de [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) klasse wordt gebruikt om een commentaar te verwijderen, worden ook alle antwoorden op dat commentaar verwijderd.
* Als de [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) eigenschap een cirkelreferentie creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne commentaren toevoegen**

Moderne commentaren kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstruimte binnen een AutoShape. De [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) methode accepteert een [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) argument naast de dia‑ en commentaarmarker‑coördinaten.

Wanneer `None` wordt doorgegeven voor het shape‑argument, is het commentaar een commentaar op dia‑niveau. De marker wordt gepositioneerd met de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) `None` retourneert. Wanneer een [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) wordt opgegeven, wordt het commentaar aan die vorm verankerd. De coördinaten bepalen nog steeds de positie van de commentaarmarker op de dia, terwijl de vormkoppeling kan worden opgehaald via [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Een modern commentaar aan een vorm verankeren**

Het voorbeeld roept [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) twee keer aan: éénmaal met een `None` shape voor een commentaar op dia‑niveau en éénmaal met een rechthoek als anker. Het lezen van [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) drukt `True` af voor de null‑check van het dia‑niveau commentaar en `Revenue title` voor het verankerde commentaar. Beide commentaren worden met de presentatie opgeslagen.

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

### **Commentaren verankeren aan verschillende vormtypen**

Elk dia‑object afgeleid van [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) kan worden gebruikt als anker. Veelvoorkomende voorbeelden zijn [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) en [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) instanties zoals grafieken.

Het voorbeeld gebruikt [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) om een commentaar te koppelen aan elk van vijf vormtypen: een AutoShape, een afbeeldingsframe, een groep, een connector en een grafiek. De afbeelding maakt gebruik van ingesloten afbeeldingsgegevens, zodat er geen externe afbeelding nodig is. Elk commentaar heeft zijn eigen markerpositie, en de opgeslagen presentatie behoudt alle vijf vormkoppelingen.

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

### **Een commentaar aan tekst verankeren en de status instellen**

Voor een modern commentaar gekoppeld aan een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) specificeert [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) de startpositie van de geselecteerde tekst in het tekstvak van de vorm, terwijl [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) de lengte van de selectie aangeeft. Samen koppelen deze eigenschappen het commentaar aan een specifieke tekstruimte binnen de AutoShape.

De [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) eigenschap kan worden gelezen of bijgewerkt met een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) enumeratie:

- `NOT_DEFINED` — er is geen specifieke status voor een modern commentaar gedefinieerd.
- `ACTIVE` — het commentaar is actief.
- `RESOLVED` — het commentaar is opgelost.
- `CLOSED` — het commentaar is gesloten.

Het voorbeeld verankert een modern commentaar aan de woorden “quarterly revenue” in de tekst van een rechthoek. Het berekent de nulgebaseerde [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) vanuit de tekst en stelt [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) in op het aantal geselecteerde tekens. Na het instellen van [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) op `RESOLVED`, wordt de presentatie opgeslagen en opnieuw geopend. De vier console‑controles moeten elk `True` afdrukken, waarmee wordt bevestigd dat de vorm‑verankering, tekstruimte en status behouden zijn gebleven.

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

### **Bestaande moderne commentaren inspecteren**

Het voorbeeld vereist een bestaande presentatie die moderne commentaren bevat en drukt hun tekst, status en ankerdetails af. Om dit te inspecteren, controleert u welke commentaren instanties zijn van [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), bekijkt vervolgens [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) en [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). Een `None` shape duidt op een commentaar op dia‑niveau. Voor een [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) anker identificeren de tekst‑selectie‑eigenschappen het bijbehorende bereik in het tekstvak van de vorm.

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

## **Commentaren verwijderen**

Aspose.Slides for Python via .NET laat u alle commentaren en hun auteurs uit een presentatie verwijderen of geselecteerde commentaren verwijderen terwijl de rest behouden blijft. De volgende voorbeelden demonstreren beide benaderingen en slaan de bijgewerkte presentatie op.

### **Alle commentaren en commentaarauteurs verwijderen**

Het voorbeeld opent een bestaande presentatie en roept [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) aan voor elke auteur, daarna wordt [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) aangeroepen om de auteurs zelf te verwijderen. De opgeslagen presentatie bevat geen commentaren of commentaarauteurs. Gebruik een presentatie met commentaren om de verwijdering te observeren.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Specifieke commentaren verwijderen**

Het voorbeeld maakt twee commentaren op één dia en gebruikt [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) om commentaren per auteur te vinden. Het verzamelt commentaren waarvan de tekst gelijk is aan “comment 1” voordat [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/) wordt aangeroepen, zodat de collectie niet wordt gewijzigd tijdens de selectie. De opgeslagen presentatie bevat alleen “comment 2”.

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

**Ondersteunt Aspose.Slides een opgeloste status voor moderne commentaren?**

Ja. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) kan worden gelezen en ingesteld met een [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) waarde, inclusief `RESOLVED`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand is heropend.

**Worden draden voor discussies (antwoordketens) ondersteund, en is er een limiet op het nestingniveau?**

Ja. Elk commentaar kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van de nesting.

**In welk coördinatensysteem wordt de positie van een commentaarmarker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevende‑komma coördinaten in het dia‑coördinatensysteem, waardoor u de marker nauwkeurig op de dia kunt plaatsen.