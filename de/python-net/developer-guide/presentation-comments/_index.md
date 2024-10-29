---
title: Präsentationskommentare
type: docs
weight: 100
url: /de/python-net/presentation-comments/
keywords: "Kommentare, PowerPoint-Kommentare, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Kommentare und Antworten in einer PowerPoint-Präsentation in Python hinzufügen"
---

In PowerPoint erscheint ein Kommentar als Notiz oder Anmerkung auf einer Folie. Wenn ein Kommentar angeklickt wird, werden seine Inhalte oder Nachrichten angezeigt.

### **Warum Kommentare zu Präsentationen hinzufügen?**

Sie möchten möglicherweise Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen zu kommunizieren, wenn Sie Präsentationen überprüfen.

Um Ihnen die Verwendung von Kommentaren in PowerPoint-Präsentationen zu ermöglichen, bietet Aspose.Slides für Python über .NET

* Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Sammlungen von Autoren (aus der [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/) Eigenschaft) enthält. Die Autoren fügen Folien Kommentare hinzu.
* Die [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) Schnittstelle, die die Sammlung von Kommentaren für einzelne Autoren enthält.
* Die [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) Klasse, die Informationen über Autoren und ihre Kommentare enthält: wer den Kommentar hinzugefügt hat, die Zeit, zu der der Kommentar hinzugefügt wurde, die Position des Kommentars usw.
* Die [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) Klasse, die Informationen über einzelne Autoren enthält: den Namen des Autors, seine Initialen, Kommentare, die mit dem Namen des Autors verbunden sind, usw.

## **Kommentar zur Folie hinzufügen**
Dieser Python-Code zeigt Ihnen, wie Sie einen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instanziiert die Presentation-Klasse
with slides.Presentation() as presentation:
    # Fügt eine leere Folie hinzu
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Fügt einen Autoren hinzu
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Setzt die Position für Kommentare
    point = draw.PointF(0.2, 0.2)

    # Fügt einen Folienkommentar für einen Autor auf Folie 1 hinzu
    author.comments.add_comment("Hallo Jawad, dies ist ein Folienkommentar", presentation.slides[0], point, datetime.date.today())

    # Fügt einen Folienkommentar für einen Autor auf Folie 2 hinzu
    author.comments.add_comment("Hallo Jawad, dies ist der zweite Folienkommentar", presentation.slides[1], point, datetime.date.today())

    # Zugriff auf ISlide 1
    slide = presentation.slides[0]

    # Wenn null als Argument übergeben wird, werden die Kommentare aller Autoren auf der ausgewählten Folie angezeigt
    comments = slide.get_slide_comments(author)

    # Greift auf den Kommentar an Index 0 für Folie 1 zu
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Wählt die Kommentarsammlung des Autors am Index 0 aus
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **Zugriff auf Folienkommentare**
Dieser Python-Code zeigt Ihnen, wie Sie auf einen vorhandenen Kommentar auf einer Folie in einer PowerPoint-Präsentation zugreifen:

```python
import aspose.slides as slides

# Instanziiert die Presentation-Klasse
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " hat Kommentar: " + comment.text + 
            " von Autor: " + comment.author.name + 
            " gepostet um: " + str(comment.created_time) + "\n")
```

## **Kommentare beantworten**
Ein übergeordneter Kommentar ist der oberste oder ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit der `parent_comment` Eigenschaft (aus der [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) Schnittstelle) können Sie einen übergeordneten Kommentar festlegen oder abrufen.

Dieser Python-Code zeigt Ihnen, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Fügt einen Kommentar hinzu
    author1 = pres.comment_authors.add_author("Autor_1", "A.A.")
    comment1 = author1.comments.add_comment("Kommentar 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Fügt eine Antwort zu Kommentar 1 hinzu
    author2 = pres.comment_authors.add_author("Autor_2", "B.B.")
    reply1 = author2.comments.add_comment("Antwort 1 für Kommentar 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Fügt eine weitere Antwort zu Kommentar 1 hinzu
    reply2 = author2.comments.add_comment("Antwort 2 für Kommentar 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Fügt eine Antwort auf eine vorhandene Antwort hinzu
    subReply = author1.comments.add_comment("Unterantwort 3 für Antwort 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("Kommentar 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("Kommentar 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("Antwort 4 für Kommentar 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Gibt die Kommentarhierarchie in der Konsole aus
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

    # Entfernt Kommentar 1 und alle Antworten darauf
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Achtung" %}} 

* Wenn die `Remove` Methode (aus der [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) Schnittstelle) verwendet wird, um einen Kommentar zu löschen, werden auch die Antworten auf den Kommentar gelöscht. 
* Wenn die `parent_comment` Einstellung zu einer zirkulären Referenz führt, wird eine `PptxEditException` ausgelöst.

{{% /alert %}}

## **Modernen Kommentar hinzufügen**

Im Jahr 2021 führte Microsoft *moderne Kommentare* in PowerPoint ein. Die moderne Kommentarfunktion verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint-Nutzer Kommentare lösen, Kommentare an Objekte und Texte anheften und viel einfacher interagieren als zuvor.

Wir implementierten die Unterstützung für moderne Kommentare, indem wir die [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) Klasse hinzufügten. Die Methoden `add_modern_comment` und `insert_modern_comment` wurden zur [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) Klasse hinzugefügt.

Dieser Python-Code zeigt Ihnen, wie Sie einen modernen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Einige Autoren", "SA")
    modernComment = newAuthor.comments.add_modern_comment("Dies ist ein moderner Kommentar", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Kommentar entfernen**

### **Alle Kommentare und Autoren löschen**

Dieser Python-Code zeigt Ihnen, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Löscht alle Kommentare aus der Präsentation
    for author in presentation.comment_authors:
        author.comments.clear()

    # Löscht alle Autoren
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Bestimmte Kommentare löschen**

Dieser Python-Code zeigt Ihnen, wie Sie bestimmte Kommentare auf einer Folie löschen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # Kommentare hinzufügen...
    author = presentation.comment_authors.add_author("Autor", "A")
    author.comments.add_comment("Kommentar 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("Kommentar 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # Entfernt alle Kommentare, die den Text "Kommentar 1" enthalten
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "Kommentar 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```