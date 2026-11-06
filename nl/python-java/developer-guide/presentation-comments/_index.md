---
title: Beheer presentatiecommentaren in Python via Java
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/python-java/presentation-comments/
keywords:
- commentaar
- modern commentaar
- PowerPoint-commentaren
- presentatiecommentaren
- dia-commentaren
- commentaar toevoegen
- commentaar benaderen
- commentaar bewerken
- antwoord op commentaar
- commentaar verwijderen
- commentaar wissen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer presentatiecommentaren met Aspose.Slides voor Python via Java: voeg toe, lees, bewerk, beantwoord en verwijder commentaren in PowerPoint-presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑commentaren kunt beheren met Aspose.Slides voor Python via Java. Het introduceert de belangrijkste commentaar‑gerelateerde typen en laat zien hoe u commentaren aan dia's kunt toevoegen, bestaande commentaren kunt benaderen, met antwoorden en moderne commentaren kunt werken, en commentaren uit een presentatie kunt verwijderen.

De voorbeelden behandelen veelvoorkomende beoordelings‑ en samenwerkingsscenario’s in PowerPoint, zoals het toewijzen van commentaren aan auteurs, het lezen van commentaartekst en metadata, het opbouwen van antwoordketens, en het verwijderen van geselecteerde commentaren of alle commentaren.

In PowerPoint verschijnen commentaren als annotaties op dia's. Het selecteren van een commentaar toont de tekst en de bijbehorende discussie.

Om aan te geven dat commentaren getoond of verborgen moeten worden wanneer een presentatie wordt geopend zonder de commentaren zelf te wijzigen, zie [Commentaar weergeven of verbergen bij het openen van een presentatie](/slides/nl/python-java/presentation-view-properties/).

## **Waarom commentaar toevoegen aan presentaties?**

U kunt commentaren gebruiken om feedback te geven en samen te werken met collega’s bij het beoordelen van presentaties.

Aspose.Slides voor Python via Java biedt de volgende API’s voor het werken met commentaren:

* De [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse, die toegang biedt tot de commentaarauteurs van de presentatie.
* De [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/)‑klasse, die de commentaren vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/)‑klasse, die informatie over een commentaar levert, inclusief auteur, aanmaaktijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/)‑klasse, die informatie over een auteur levert, waaronder naam, initialen en gekoppelde commentaren.

## **Dia‑commentaren toevoegen**

Het voorbeeld maakt twee dia’s aan en registreert een commentaarauteur met [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor). Het gebruikt [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) om één commentaar op elke dia te plaatsen, en haalt vervolgens de commentaren van de eerste dia op voor die auteur met [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments). De console toont de tekst van het eerste commentaar twee keer, wat de toegang via zowel de dia als de auteur demonstreert, en de opgeslagen presentatie bevat beide commentaren.

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

## **Zoek of maak een commentaarauteur**

Wanneer een geautomatiseerde beoordeling dezelfde presentatie herhaaldelijk verwerkt, doorzoekt u de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) voordat u een auteur toevoegt. [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) vergelijkt zowel de naam als de initialen en retourneert een array met overeenkomende auteurs, of een lege array als er geen overeenkomsten zijn. In tegenstelling hiermee zoekt [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) alleen op naam, ongeacht de initialen. Een aanroep van [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) met een naam en initialen die al in de collectie aanwezig zijn, veroorzaakt een uitzondering.

Het voorbeeld vereist een presentatiebestand met minstens één dia. Tijdens elk van twee doorlopen wordt de eerste overeenkomende auteur hergebruikt, of wordt er één aangemaakt alleen wanneer het resultaat leeg is. Als er meerdere overeenkomsten zijn, wordt het eerste array‑element geselecteerd zonder de andere auteurs te combineren of te verwijderen. Vervolgens wordt [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) aangeroepen voor de geselecteerde auteur en wordt de presentatie opgeslagen. De tweede doorloop opent de uitvoer van de eerste doorloop en herhaalt de bewerking.

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

De tweede doorloop voegt een extra commentaar toe zonder een extra auteur toe te voegen of bestaande commentaren te verwijderen. Het uiteindelijke bestand, `review_pass_2.pptx`, bevat beide nieuwe commentaren naast eventuele originele commentaren. Het hergebruiken van een auteur leidt niet tot deduplicatie van commentaren: om te voorkomen dat hetzelfde commentaar herhaaldelijk wordt toegevoegd, dient u vooraf een aparte duplicaatdetectie te implementeren.

## **Dia‑commentaren benaderen**

Het voorbeeld opent een bestaande presentatie en leest de collectie die wordt geretourneerd door [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Voor elke auteur itereert het door de collectie die wordt geretourneerd door [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) en print het dia‑nummer, de commentaartekst, de naam van de auteur en de aanmaaktijd. De invoerpresentatie moet commentaren bevatten om console‑output te produceren.

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

## **Antwoorden op commentaren**

Een bovenliggend commentaar is het originele commentaar bovenaan een antwoordhiërarchie. De methoden [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) en [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) stellen u in staat respectievelijk het bovenliggende commentaar op te halen of in te stellen.

Het voorbeeld maakt commentaren van twee auteurs aan en gebruikt [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) om antwoorden op te bouwen, inclusief een antwoord op een ander antwoord. Het doorgeven van `None` aan [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) haalt commentaren van alle auteurs op; de console maakt voor elk item een inspringing volgens de diepte in de antwoordhiërarchie. Het voorbeeld slaat de volledige discussie op, roept [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) aan op het eerste wortelcommentaar, en slaat een tweede presentatie op waarin dat commentaar en de bijbehorende antwoorden zijn verwijderd.

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
* Wanneer de [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove)‑methode wordt gebruikt om een commentaar te verwijderen, worden alle antwoorden op dat commentaar ook verwijderd.
* Als [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) een circulaire verwijzing creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne commentaren toevoegen**

Moderne commentaren kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstrange binnen een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). De methode [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) accepteert een [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)‑argument naast de dia‑ en commentaar‑markercoördinaten.

Wanneer `None` wordt doorgegeven voor het vorm‑argument, betreft het commentaar een dia‑niveau commentaar. De marker wordt gepositioneerd op basis van de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) `None` retourneert. Wanneer een [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) wordt opgegeven, wordt het commentaar aan die vorm verankerd. De coördinaten bepalen nog steeds de positie van de commentaar‑marker op de dia, terwijl de vormkoppeling kan worden opgevraagd via [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape).

### **Een modern commentaar aan een vorm verankeren**

Het voorbeeld roept [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) twee keer aan: één keer met een `None` vorm voor een dia‑niveau commentaar en één keer met een rechthoek als anker. Het lezen van [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) print `True` voor de `None`‑controle van het dia‑niveau commentaar en `Revenue title` voor het verankerde commentaar. Beide commentaren worden met de presentatie opgeslagen.

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

### **Commentaren aan verschillende vormtypen verankeren**

Elk dia‑object dat afstamt van [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) kan worden gebruikt als anker. Veelvoorkomende voorbeelden zijn [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) en [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/)‑instanties zoals grafieken.

Het voorbeeld gebruikt [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) om een commentaar te koppelen aan elk van vijf vormtypen: een AutoShape, een picture frame, een groep, een connector en een grafiek. De afbeelding maakt gebruik van ingebedde beeldgegevens, dus er is geen externe afbeelding vereist. Elk commentaar heeft een eigen marker‑positie, en de opgeslagen presentatie behoudt alle vijf vormkoppelingen.

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

### **Een commentaar aan tekst verankeren en de status instellen**

Voor een modern commentaar gekoppeld aan een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), geven [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) en [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) de beginnende positie van de geselecteerde tekst in het tekstframe van de vorm. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) en [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) geven de lengte van de selectie. Samen koppelen deze waarden het commentaar aan een specifieke tekstrange binnen de AutoShape.

De methoden [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) en [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) benaderen een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/)‑constanten:

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — er is geen specifieke modern‑commentaarstatus gedefinieerd.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — het commentaar is actief.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — het commentaar is opgelost.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — het commentaar is gesloten.

Het voorbeeld verankert een modern commentaar aan de woorden “quarterly revenue” in de tekst van een rechthoek. Het berekent de nul‑gebaseerde startpositie van de selectie uit de tekst en geeft die door aan [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) en gebruikt [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) om het aantal geselecteerde tekens in te stellen. Na het aanroepen van [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) met `Resolved` slaat het op en opent de presentatie opnieuw. De vier console‑controles moeten elk `True` afdrukken, wat bevestigt dat de vormverankering, tekstrange en status behouden zijn gebleven.

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

### **Bestaande moderne commentaren inspecteren**

Het voorbeeld vereist een bestaande presentatie met moderne commentaren en drukt hun tekst, status en ankerdetails af. Om dit te inspecteren, controleert u welke commentaren instanties zijn van [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), vervolgens bekijkt u [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) en [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus). Een `None` vorm duidt op een commentaar op dia‑niveau. Voor een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) anker identificeren de tekst‑selectiemethoden het bijbehorende bereik in het tekstframe van de vorm.

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

## **Commentaren verwijderen**

Aspose.Slides voor Python via Java stelt u in staat alle commentaren en hun auteurs uit een presentatie te verwijderen of geselecteerde commentaren te verwijderen terwijl de rest behouden blijft. De volgende voorbeelden demonstreren beide benaderingen en slaan de bijgewerkte presentatie op.

### **Alle commentaren en commentaarauteurs verwijderen**

Het voorbeeld opent een bestaande presentatie en roept [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) aan voor elke auteur, waarna [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) wordt aangeroepen om de auteurs zelf te verwijderen. De opgeslagen presentatie bevat geen commentaren en geen commentaarauteurs. Gebruik een presentatie met commentaren om de verwijdering te observeren.

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

### **Specifieke commentaren verwijderen**

Het voorbeeld maakt twee commentaren op één dia en gebruikt [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) om commentaren per auteur te vinden. Het verzamelt commentaren waarvan de tekst gelijk is aan “comment 1” voordat [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove) wordt aangeroepen, om wijzigingen in de collectie tijdens de selectie te vermijden. De opgeslagen presentatie bevat alleen “comment 2”.

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

**Ondersteunt Aspose.Slides een status ‘opgelost’ voor moderne commentaren?**

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) en [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) benaderen een [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/)‑waarde, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand opnieuw is geopend.

**Worden discussies (antwoordketens) ondersteund en is er een maximale nestingsdiepte?**

Ja. Elk commentaar kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van het nestelen.

**In welk coördinatensysteem wordt de positie van een commentaar‑marker op een dia gedefinieerd?**

De marker‑positie wordt gedefinieerd door zwevende‑komma‑coördinaten in het dia‑coördinatensysteem, zodat u het nauwkeurig op de dia kunt plaatsen.