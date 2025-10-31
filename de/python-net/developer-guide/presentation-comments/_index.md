---
title: Verwalten von Präsentationskommentaren in Python
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/python-net/presentation-comments/
keywords:
- Kommentar
- moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar zugreifen
- Kommentar bearbeiten
- Kommentar antworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Meistern Sie Präsentationskommentare mit Aspose.Slides für Python via .NET: Kommentare in PowerPoint-Dateien schnell und einfach hinzufügen, lesen, bearbeiten und löschen."
---

In PowerPoint erscheint ein Kommentar als Hinweis oder Anmerkung auf einer Folie. Wird ein Kommentar angeklickt, werden dessen Inhalt bzw. Nachrichten angezeigt.

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie möchten Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen bei der Durchsicht von Präsentationen zu kommunizieren.

Um Ihnen die Nutzung von Kommentaren in PowerPoint‑Präsentationen zu ermöglichen, bietet Aspose.Slides für Python via .NET:

* Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse, die die Sammlungen von Autoren enthält (aus der [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)-Eigenschaft). Die Autoren fügen Kommentare zu Folien hinzu.  
* Die [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/)-Schnittstelle, die die Sammlung von Kommentaren für einzelne Autoren enthält.  
* Die [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)-Klasse, die Informationen zu Autoren und ihren Kommentaren enthält: wer den Kommentar hinzugefügt hat, wann er hinzugefügt wurde, die Position des Kommentars usw.  
* Die [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/)-Klasse, die Informationen zu einzelnen Autoren enthält: Name des Autors, dessen Initialen, mit dem Autor verknüpfte Kommentare usw.  

## **Folienkommentar hinzufügen**
Dieses Python‑Beispiel zeigt, wie man einen Kommentar zu einer Folie in einer PowerPoint‑Präsentation hinzufügt:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instanziiert die Presentation‑Klasse
with slides.Presentation() as presentation:
    # Fügt eine leere Folie hinzu
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Fügt einen Autor hinzu
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Legt die Position für Kommentare fest
    point = draw.PointF(0.2, 0.2)

    # Fügt einen Folienkommentar für einen Autor auf Folie 1 hinzu
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Fügt einen Folienkommentar für einen Autor auf Folie 2 hinzu
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Zugriff auf ISlide 1
    slide = presentation.slides[0]

    # Wenn null als Argument übergeben wird, werden Kommentare aller Autoren zur ausgewählten Folie gebracht
    comments = slide.get_slide_comments(author)

    # Greift auf den Kommentar an Index 0 für Folie 1 zu
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Wählt die Kommentar‑Sammlung des Autors am Index 0 aus
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **Folienkommentare zugreifen**
Dieses Python‑Beispiel zeigt, wie man einen bestehenden Kommentar auf einer Folie in einer PowerPoint‑Präsentation abruft:

```python
import aspose.slides as slides

# Instanziiert die Presentation‑Klasse
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **Kommentare beantworten**
Ein übergeordneter Kommentar ist der oberste bzw. ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit der `parent_comment`‑Eigenschaft (aus der [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)-Schnittstelle) können Sie einen übergeordneten Kommentar setzen oder abrufen.

Dieses Python‑Beispiel zeigt, wie man Kommentare hinzufügt und Antworten darauf erhält:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Fügt einen Kommentar hinzu
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Fügt eine Antwort zu comment1 hinzu
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Fügt eine weitere Antwort zu comment1 hinzu
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Fügt eine Antwort auf eine vorhandene Antwort hinzu
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Gibt die Kommentar‑Hierarchie auf der Konsole aus
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

    # Entfernt comment1 und alle darauf antwortenden Kommentare
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 

* Wenn die `Remove`‑Methode (aus der [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/)-Schnittstelle) verwendet wird, um einen Kommentar zu löschen, werden auch die Antworten auf den Kommentar gelöscht.  
* Wenn die Einstellung `parent_comment` zu einer zirkulären Referenz führt, wird eine `PptxEditException` ausgelöst. 

{{% /alert %}}

## **Modernen Kommentar hinzufügen**

Im Jahr 2021 hat Microsoft *moderne Kommentare* in PowerPoint eingeführt. Die Funktion moderner Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint‑Benutzer Kommentare auflösen, Kommentare an Objekte und Texte verankern und viel einfacher interagieren als zuvor.  

Wir haben die Unterstützung für moderne Kommentare implementiert, indem wir die [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/)-Klasse hinzugefügt haben. Die Methoden `add_modern_comment` und `insert_modern_comment` wurden der [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/)-Klasse hinzugefügt.  

Dieses Python‑Beispiel zeigt, wie man einen modernen Kommentar zu einer Folie in einer PowerPoint‑Präsentation hinzufügt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Kommentar entfernen**

### **Alle Kommentare und Autoren löschen**

Dieses Python‑Beispiel zeigt, wie man alle Kommentare und Autoren in einer Präsentation entfernt:

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

Dieses Python‑Beispiel zeigt, wie man gezielte Kommentare auf einer Folie löscht:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # Kommentare hinzufügen...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # Entfernt alle Kommentare, die den Text "comment 1" enthalten
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

**Unterstützt Aspose.Slides einen Status wie 'gelöst' für moderne Kommentare?**

Ja. [Moderne Kommentare](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) stellen eine [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/)-Eigenschaft bereit; Sie können den [Zustand eines Kommentars](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) lesen und setzen (z. B. ihn als gelöst markieren). Dieser Zustand wird in der Datei gespeichert und von PowerPoint erkannt.

**Werden Threaded Discussions (Antwortketten) unterstützt, und gibt es ein Verschachtelungslimit?**

Ja. Jeder Kommentar kann sein [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/)-Element referenzieren, wodurch beliebige Antwortketten möglich sind. Die API definiert kein spezifisches Verschachtelungstiefe‑Limit.

**In welchem Koordinatensystem ist die Position eines Kommentarmarkers auf einer Folie definiert?**

Die Position wird als Gleitkommapunkt im Koordinatensystem der Folie gespeichert. Damit können Sie den Kommentarmarker genau dort platzieren, wo Sie ihn benötigen.