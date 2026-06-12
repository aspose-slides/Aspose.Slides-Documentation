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
description: "Beheers presentatie‑opmerkingen met Aspose.Slides for Python via .NET: voeg opmerkingen toe, lees, bewerk en verwijder ze snel en eenvoudig in PowerPoint‑bestanden."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑opmerkingen beheert in Aspose.Slides. Het toont de belangrijkste typen die met opmerkingen te maken hebben en demonstreert hoe u opmerkingen aan dia’s kunt toevoegen, bestaande opmerkingen kunt benaderen, met antwoorden kunt werken, moderne opmerkingen kunt gebruiken en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden richten zich op veelvoorkomende beoordelings‑ en samenwerkingsscenario’s in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de inhoud en metadata van opmerkingen, het opbouwen van antwoordketens, en het wissen van alle opmerkingen of het verwijderen van geselecteerde opmerkingen.

In PowerPoint wordt een opmerking weergegeven als een aantekening of annotatie op een dia. Wanneer op een opmerking wordt geklikt, wordt de inhoud of de berichten ervan weergegeven.

## **Waarom opmerkingen aan presentaties toevoegen?**

U wilt wellicht opmerkingen gebruiken om feedback te geven of met uw collega’s te communiceren bij het beoordelen van presentaties.

Om u toe te staan opmerkingen te gebruiken in PowerPoint‑presentaties, biedt Aspose.Slides for Python via .NET

* De [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse, die de collecties van auteurs bevat (via de [CommentAuthorCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/commentauthorcollection/)‑eigenschap). De auteurs voegen opmerkingen toe aan dia’s.  
* De [CommentCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/commentcollection/)‑klasse, die de verzameling van opmerkingen voor individuele auteurs bevat.  
* De [Comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/)‑klasse, die informatie over auteurs en hun opmerkingen bevat: wie de opmerking heeft toegevoegd, het tijdstip van toevoeging, de positie van de opmerking, enzovoort.  
* De [CommentAuthor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/commentauthor/)‑klasse, die informatie over individuele auteurs bevat: de naam van de auteur, zijn initialen, opmerkingen die aan de naam van de auteur zijn gekoppeld, enzovoort.

## **Opmerking aan dia toevoegen**
Deze Python‑code laat zien hoe u een opmerking aan een dia in een PowerPoint‑presentatie toevoegt:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instantieert de Presentation‑klasse
with slides.Presentation() as presentation:
    # Voegt een lege dia toe
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Voegt een auteur toe
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Stelt de positie voor opmerkingen in
    point = draw.PointF(0.2, 0.2)

    # Voegt een diaopmerking toe voor een auteur op dia 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Voegt een diaopmerking toe voor een auteur op dia 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Benadert ISlide 1
    slide = presentation.slides[0]

    # Wanneer null als argument wordt doorgegeven, worden opmerkingen van alle auteurs naar de geselecteerde dia gehaald
    comments = slide.get_slide_comments(author)

    # Benadert de opmerking op index 0 voor dia 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Selecteert de opmerkingenverzameling van de auteur op index 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **Opmerkingen van dia benaderen**
Deze Python‑code laat zien hoe u een bestaande opmerking op een dia in een PowerPoint‑presentatie benadert:

```python
import aspose.slides as slides

# Instantieert de Presentation‑klasse
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **Opmerkingen beantwoorden**
Een bovenliggende opmerking is de eerste of originele opmerking in een hiërarchie van opmerkingen of antwoorden. Met de `parent_comment`‑eigenschap (van de [Comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/)‑klasse) kunt u een bovenliggende opmerking instellen of ophalen.

Deze Python‑code laat zien hoe u opmerkingen toevoegt en antwoorden erop krijgt:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Voegt een opmerking toe
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Voegt een antwoord toe aan comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Voegt een extra antwoord toe aan comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Voegt een antwoord toe aan een bestaand antwoord
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Toont de hiërarchie van opmerkingen op de console
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # Verwijdert comment1 en alle antwoorden erop
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Aandacht" %}} 
* Wanneer de `remove`‑methode (van de [Comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/comment/)‑klasse) wordt gebruikt om een opmerking te verwijderen, worden ook de antwoorden op die opmerking verwijderd.  
* Als de instelling `parent_comment` leidt tot een circulaire verwijzing, wordt er een `PptxEditException` gegooid.  
{{% /alert %}}

## **Moderne opmerking toevoegen**

In 2021 heeft Microsoft *moderne opmerkingen* geïntroduceerd in PowerPoint. De functie moderne opmerkingen verbetert de samenwerking in PowerPoint aanzienlijk. Via moderne opmerkingen kunnen PowerPoint‑gebruikers opmerkingen oplossen, opmerkingen verankeren aan objecten en teksten, en veel gemakkelijker interacties aangaan dan voorheen.

We hebben ondersteuning voor moderne opmerkingen geïmplementeerd door de [ModernComment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/)‑klasse toe te voegen. De methoden `add_modern_comment` en `insert_modern_comment` zijn toegevoegd aan de [CommentCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/commentcollection/)‑klasse.

Deze Python‑code laat zien hoe u een moderne opmerking aan een dia in een PowerPoint‑presentatie toevoegt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Opmerking verwijderen**

### **Alle opmerkingen en auteurs verwijderen**

Deze Python‑code laat zien hoe u alle opmerkingen en auteurs in een presentatie verwijdert:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Verwijdert alle opmerkingen uit de presentatie
    for author in presentation.comment_authors:
        author.comments.clear()

    # Verwijdert alle auteurs
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Specifieke opmerkingen verwijderen**

Deze Python‑code laat zien hoe u specifieke opmerkingen op een dia verwijdert:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # voeg opmerkingen toe...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # verwijder alle opmerkingen die de tekst "comment 1" bevatten
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Ondersteunt Aspose.Slides een status zoals ‘opgelost’ voor moderne opmerkingen?**

Ja. [Modern comments](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/) bieden een [status](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/status/)-eigenschap; u kunt de [status van een opmerking](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncommentstatus/) lezen en instellen (bijvoorbeeld markeren als opgelost), en deze status wordt opgeslagen in het bestand en herkend door PowerPoint.

**Worden geneste discussies (antwoordketens) ondersteund, en is er een limiet op de nesting?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nl/python-net/aspose.slides/moderncomment/parent_comment/), waardoor willekeurige antwoordketens mogelijk zijn. De API specificeert geen specifieke diepte‑limiet.

**In welk coördinatensysteem wordt de positie van een opmerkingsteken op een dia gedefinieerd?**

De positie wordt opgeslagen als een zwevend‑kommagetal in het coördinatensysteem van de dia. Hierdoor kunt u het opmerkingsteken precies plaatsen waar u het nodig heeft.