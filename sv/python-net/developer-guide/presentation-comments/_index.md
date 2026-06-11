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
- åtkomst kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Behärska presentationskommentarer med Aspose.Slides för Python via .NET: lägg till, läs, redigera och ta bort kommentarer i PowerPoint-filer snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur man hanterar presentationskommentarer i Aspose.Slides. Den visar de viktigaste kommentarrelaterade typerna och demonstrerar hur man lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar, använder moderna kommentarer och tar bort kommentarer från en presentation.

Exemplen fokuserar på vanliga gransknings- och samarbets scenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentarens innehåll och metadata, bygga svarskedjor och rensa alla kommentarer eller ta bort valda.

I PowerPoint visas en kommentar som en notering eller annotation på en bild. När en kommentar klickas på visas dess innehåll eller meddelanden.

## **Varför lägga till kommentarer i presentationer?**

Du kanske vill använda kommentarer för att ge feedback eller kommunicera med dina kollegor när du granskar presentationer.

För att du ska kunna använda kommentarer i PowerPoint-presentationer tillhandahåller Aspose.Slides för Python via .NET

* Klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) som innehåller samlingarna av författare (från egenskapen [CommentAuthorCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/commentauthorcollection/) ). Författarna lägger till kommentarer på bilder. 
* Klassen [CommentCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/commentcollection/) som innehåller samlingen av kommentarer för enskilda författare. 
* Klassen [Comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/) som innehåller information om författare och deras kommentarer: vem som lade till kommentaren, tiden kommentaren lades till, kommentarens position osv. 
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/python-net/aspose.slides/commentauthor/) som innehåller information om enskilda författare: författarens namn, deras initialer, kommentarer kopplade till författarens namn osv. 

## **Lägg till bildkommentar**
Den här Python-koden visar hur du lägger till en kommentar på en bild i en PowerPoint-presentation:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instansierar Presentation‑klassen
with slides.Presentation() as presentation:
    # Lägger till en tom bild
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Lägger till en författare
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Ställer in positionen för kommentarer
    point = draw.PointF(0.2, 0.2)

    # Lägger till bildkommentar för en författare på bild 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Lägger till bildkommentar för en författare på bild 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Åtkomst till ISlide 1
    slide = presentation.slides[0]

    # När null skickas som argument hämtas kommentarer från alla författare till den valda bilden
    comments = slide.get_slide_comments(author)

    # Hämtar kommentaren på index 0 för bild 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Väljer författarens kommentarskollektion på index 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Åtkomst till bildkommentarer**
Den här Python-koden visar hur du får åtkomst till en befintlig kommentar på en bild i en PowerPoint-presentation:

```python
import aspose.slides as slides

# Instansierar Presentation-klassen
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Svara på kommentarer**
En föräldrakommentar är den översta eller ursprungliga kommentaren i en hierarki av kommentarer eller svar. Med egenskapen `parent_comment` (från klassen [Comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/)) kan du ange eller hämta en föräldrakommentar. 

Den här Python-koden visar hur du lägger till kommentarer och får svar på dem:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Lägger till en kommentar
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Lägger till ett svar på comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Lägger till ett annat svar på comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Lägger till ett svar på befintligt svar
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Visar kommentarshierarkin i konsolen
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

    # Tar bort comment1 och alla svar på den
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 

* När metoden `remove` (från klassen [Comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/comment/)) används för att ta bort en kommentar, tas även svaren på kommentaren bort. 
* Om inställningen `parent_comment` resulterar i en cirkulär referens kommer `PptxEditException` att kastas.

{{% /alert %}}

## **Lägg till modern kommentar**

År 2021 introducerade Microsoft *moderna kommentarer* i PowerPoint. Funktionen för moderna kommentarer förbättrar samarbetet i PowerPoint avsevärt. Genom moderna kommentarer kan PowerPoint-användare lösa kommentarer, fästa kommentarer på objekt och texter samt interagera mycket enklare än tidigare. 

Vi har implementerat stöd för moderna kommentarer genom att lägga till klassen [ModernComment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/). Metoderna `add_modern_comment` och `insert_modern_comment` har lagts till i klassen [CommentCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/commentcollection/). 

Den här Python-koden visar hur du lägger till en modern kommentar på en bild i en PowerPoint-presentation:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort kommentar**

### **Ta bort alla kommentarer och författare**

Den här Python-koden visar hur du tar bort alla kommentarer och författare i en presentation:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Tar bort alla kommentarer från presentationen
    for author in presentation.comment_authors:
        author.comments.clear()

    # Tar bort alla författare
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Ta bort specifika kommentarer**

Den här Python-koden visar hur du tar bort specifika kommentarer på en bild:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # lägg till kommentarer...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # ta bort alla kommentarer som innehåller "comment 1" text
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

**Stöder Aspose.Slides en status som 'resolved' för moderna kommentarer?**

Ja. [Modern comments](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/) exponerar en [status](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/status/)‑egenskap; du kan läsa och ange ett [kommentars tillstånd](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncommentstatus/) (till exempel markera det som resolved), och detta tillstånd sparas i filen och känns igen av PowerPoint.

**Stöds trådade diskussioner (svarskedjor) och finns det någon begränsning för inbäddning?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/moderncomment/parent_comment/), vilket möjliggör godtyckliga svarskedjor. API:et specificerar ingen särskild begränsning för inbäddningsdjup.

**I vilket koordinatsystem är en kommentarmärkares position definierad på en bild?**

Positionen lagras som en flyttalspunkt i bildens koordinatsystem. Detta låter dig placera kommentarmärken exakt där du behöver den.