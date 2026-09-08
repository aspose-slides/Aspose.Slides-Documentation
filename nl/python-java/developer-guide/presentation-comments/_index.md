---
title: Beheer presentatieopmerkingen in Python via Java
linktitle: Presentatieopmerkingen
type: docs
weight: 100
url: /nl/python-java/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint-opmerkingen
- presentatieopmerkingen
- dia-opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking wissen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer presentatieopmerkingen met Aspose.Slides for Python via Java: voeg toe, lees, bewerk, beantwoord en verwijder opmerkingen in PowerPoint-presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieopmerkingen kunt beheren met Aspose.Slides for Python via Java. Het introduceert de belangrijkste types met betrekking tot opmerkingen en toont hoe u opmerkingen aan dia's kunt toevoegen, bestaande opmerkingen kunt benaderen, kunt werken met antwoorden en moderne opmerkingen, en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden behandelen veelvoorkomende beoordelings- en samenwerkingsscenario's in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de tekst en metadata van een opmerking, het opbouwen van antwoordketens en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia's. Het selecteren van een opmerking toont de tekst en de bijbehorende discussie.

## **Waarom opmerkingen toevoegen aan presentaties?**

U kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides for Python via Java biedt de volgende API's voor werken met opmerkingen:

* De klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) die toegang biedt tot de commentaurauteurs van de presentatie.
* De klasse [CommentCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commentcollection/) die de opmerkingen vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De klasse [Comment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/comment/) die informatie over een opmerking geeft, inclusief de auteur, aanmaakdatum, positie en tekst.
* De klasse [CommentAuthor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commentauthor/) die informatie over een auteur geeft, inclusief naam, initiaal(en) en gekoppelde opmerkingen.

## **Dia-opmerkingen toevoegen**

Het volgende voorbeeld toont hoe u opmerkingen aan dia's kunt toevoegen in een PowerPoint‑presentatie:

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

## **Dia-opmerkingen benaderen**

Het volgende voorbeeld toont hoe u bestaande opmerkingen in een PowerPoint‑presentatie kunt benaderen:

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

## **Antwoorden op opmerkingen**

Een hoofdopmerking is de oorspronkelijke opmerking bovenaan een antwoordhiërarchie. De methoden [Comment.getParentComment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/comment/#getParentComment) en [Comment.setParentComment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/comment/#setParentComment) stellen u in staat om de ouder van een opmerking op te halen of in te stellen.

Het volgende voorbeeld toont hoe u antwoorden kunt toevoegen en de resulterende opmerkinghiërarchie kunt inspecteren:

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

{{% alert color="warning" title="Waarschuwing" %}}
* Wanneer de methode [Comment.remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/comment/#remove) wordt gebruikt om een opmerking te verwijderen, worden ook alle antwoorden op die opmerking verwijderd.
* Als [Comment.setParentComment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/comment/#setParentComment) een circulaire verwijzing creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreek binnen een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/). De methode [CommentCollection.addModernComment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commentcollection/#addModernComment) accepteert een [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/)‑argument naast de dia‑ en opmerking‑markercoördinaten.

Wanneer `None` wordt doorgegeven voor het shape‑argument, is de opmerking een dia‑niveau opmerking. De marker wordt gepositioneerd volgens de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [ModernComment.getShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getShape) `None` retourneert. Wanneer een [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/) wordt meegegeven, wordt de opmerking verankerd aan die vorm. De coördinaten bepalen nog steeds de positie van de opmerkingmarker op de dia, terwijl de vormassociatie kan worden opgehaald via [ModernComment.getShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getShape).

### **Een moderne opmerking verankeren aan een vorm**

Het volgende voorbeeld maakt zowel een moderne opmerking op dia‑niveau als een moderne opmerking die verankerd is aan een specifieke [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/). Vervolgens leest het de gekoppelde vorm uit elke opmerking.

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

### **Opmerkingen verankeren aan verschillende vormtypen**

Elk dia‑object dat van [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/) erven kan worden gebruikt als een vormankerpunt. Veelvoorkomende voorbeelden zijn [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connector/) en [GraphicalObject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/graphicalobject/)&nbsp;‑ instellingen zoals grafieken.

Het volgende voorbeeld maakt verschillende veelvoorkomende vormtypen aan en koppelt een moderne opmerking aan elk van hen.

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

### **Een opmerking verankeren aan tekst en de status instellen**

Voor een moderne opmerking die is gekoppeld aan een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/), geven [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getTextSelectionStart) en [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#setTextSelectionStart) de startpositie van de geselecteerde tekst in het tekstkader van de vorm terug. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getTextSelectionLength) en [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#setTextSelectionLength) geven de lengte van de selectie terug. Samen koppelen deze waarden de opmerking aan een specifieke tekstreek binnen de AutoShape.

De methoden [ModernComment.getStatus](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getStatus) en [ModernComment.setStatus](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#setStatus) geven een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncommentstatus/)‑constanten terug:
- [NotDefined](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncommentstatus/#NotDefined) — er is geen specifieke moderne‑opmerkingstatus gedefinieerd.
- [Active](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncommentstatus/#Active) — de opmerking is actief.
- [Resolved](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncommentstatus/#Resolved) — de opmerking is afgehandeld.
- [Closed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncommentstatus/#Closed) — de opmerking is gesloten.

Het volgende voorbeeld maakt een moderne opmerking verankerd aan een vorm, koppelt deze aan een tekstreek, markeert de opmerking als afgehandeld, slaat de presentatie op en verifieert de waarden na het opnieuw openen van het bestand.

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

### **Bestaande moderne opmerkingen inspecteren**

Om een bestaande presentatie te inspecteren, controleer welke opmerkingen instanties van [ModernComment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/) zijn, en kijk vervolgens naar [ModernComment.getShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getTextSelectionLength) en [ModernComment.getStatus](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getStatus). Een `None`‑vorm duidt op een opmerking op dia‑niveau. Voor een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/)‑ankerpunt identificeren de tekstreek‑methoden het bijbehorende bereik in het tekstkader van de vorm.

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

## **Opmerkingen verwijderen**

### **Alle opmerkingen en opmerkingauteurs verwijderen**

Het volgende voorbeeld toont hoe u alle opmerkingen en opmerkingauteurs uit een presentatie kunt verwijderen:

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

### **Specifieke opmerkingen verwijderen**

Het volgende voorbeeld toont hoe u specifieke opmerkingen van een dia kunt verwijderen:

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

**Ondersteunt Aspose.Slides een afgehandelde status voor moderne opmerkingen?**

Ja. [ModernComment.getStatus](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#getStatus) en [ModernComment.setStatus](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncomment/#setStatus) geven een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/nl/python-java/aspose.slides/moderncommentstatus/) terug, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand is heropend.

**Worden thread‑discussies (antwoordketens) ondersteund, en is er een limiet op nesting?**

Ja. Elke opmerking kan naar zijn [parent comment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/comment/#getParentComment) verwijzen, waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van genesting.

**In welk coördinatensysteem is de positie van een opmerkingmarker gedefinieerd op een dia?**

De positie van de marker wordt gedefinieerd door zwevende‑punt coördinaten in het dia‑coördinatensysteem, waardoor u de marker nauwkeurig op de dia kunt plaatsen.