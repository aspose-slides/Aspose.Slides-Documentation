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
- Kommentar abrufen
- Kommentar bearbeiten
- Kommentar beantworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Meistern Sie Präsentationskommentare mit Aspose.Slides für Python via .NET: Kommentare in PowerPoint-Dateien schnell und einfach hinzufügen, lesen, bearbeiten und löschen."
---

In PowerPoint wird ein Kommentar als Notiz oder Anmerkung auf einer Folie angezeigt. Wenn ein Kommentar angeklickt wird, werden dessen Inhalt oder Nachrichten angezeigt. 

## **Warum Kommentare zu Präsentationen hinzufügen?**

Möglicherweise möchten Sie Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen zu kommunizieren, wenn Sie Präsentationen überprüfen.

* Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Sammlungen von Autoren (aus der [CommentAuthorCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/)‑Eigenschaft) enthält. Die Autoren fügen Folien Kommentare hinzu. 
* Das [ICommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icommentcollection/) Interface, das die Sammlung von Kommentaren für einzelne Autoren enthält. 
* Die [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) Klasse, die Informationen über Autoren und deren Kommentare enthält: wer den Kommentar hinzugefügt hat, wann er hinzugefügt wurde, die Position des Kommentars usw. 
* Die [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) Klasse, die Informationen über einzelne Autoren enthält: den Namen des Autors, seine Initialen, mit dem Namen des Autors verbundene Kommentare usw. 

## **Kommentar zur Folie hinzufügen**
Dieser Python‑Code zeigt, wie Sie einem Folie in einer PowerPoint‑Präsentation einen Kommentar hinzufügen:
```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Instanziiert die Presentation-Klasse
with slides.Presentation() as presentation:
    # Fügt eine leere Folie hinzu
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Fügt einen Autor hinzu
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Setzt die Position für Kommentare
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
        # Wählt die Kommentarsammlung des Autors an Index 0 aus
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```


## **Zugriff auf Folienkommentare**
Dieser Python‑Code zeigt, wie Sie auf einen vorhandenen Kommentar einer Folie in einer PowerPoint‑Präsentation zugreifen:
```python
import aspose.slides as slides

# Instanziiert die Presentation-Klasse
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Antworten auf Kommentare**
Ein übergeordneter Kommentar ist der oberste bzw. ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit der `parent_comment`‑Eigenschaft (aus dem [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) Interface) können Sie einen übergeordneten Kommentar festlegen oder abrufen. 

Dieser Python‑Code zeigt, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:
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

    # Fügt eine Antwort auf vorhandene Antwort hinzu
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Zeigt die Kommentarhierarchie in der Konsole an
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

    # Entfernt comment1 und alle dazugehörigen Antworten
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" title="Achtung" %}} 

* Wenn die `Remove`‑Methode (aus dem [IComment](https://reference.aspose.com/slides/python-net/aspose.slides/icomment/) Interface) verwendet wird, um einen Kommentar zu löschen, werden auch die Antworten auf den Kommentar gelöscht. 
* Wenn die Einstellung `parent_comment` zu einer zirkulären Referenz führt, wird `PptxEditException` ausgelöst.

{{% /alert %}}

## **Modernen Kommentar hinzufügen**

Im Jahr 2021 hat Microsoft *moderne Kommentare* in PowerPoint eingeführt. Die Funktion moderne Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint‑Benutzer Kommentare auflösen, Kommentare an Objekten und Texten verankern und viel einfacher interagieren als zuvor. 

Wir haben die Unterstützung für moderne Kommentare implementiert, indem wir die [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) Klasse hinzugefügt haben. Die Methoden `add_modern_comment` und `insert_modern_comment` wurden zur [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) Klasse hinzugefügt. 

Dieser Python‑Code zeigt, wie Sie einem Folie in einer PowerPoint‑Präsentation einen modernen Kommentar hinzufügen:
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

Dieser Python‑Code zeigt, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:
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

Dieser Python‑Code zeigt, wie Sie bestimmte Kommentare auf einer Folie löschen:
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
    
    # Alle Kommentare entfernen, die den Text "comment 1" enthalten
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

**Unterstützt Aspose.Slides einen Status wie „gelöst“ für moderne Kommentare?**

Ja. [Moderne Kommentare](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) stellen eine [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/)‑Eigenschaft bereit; Sie können den [Zustand eines Kommentars](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) auslesen und festlegen (z. B. ihn als gelöst markieren), und dieser Zustand wird in der Datei gespeichert und von PowerPoint erkannt.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es ein Verschachtelungslimit?**

Ja. Jeder Kommentar kann auf seinen [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/parent_comment/) verweisen, wodurch beliebige Antwortketten ermöglicht werden. Die API legt kein spezifisches Verschachtelungstiefe‑Limit fest.

**In welchem Koordinatensystem ist die Position eines Kommentarmarkers auf einer Folie definiert?**

Die Position wird als Gleitkomma‑Punkt im Koordinatensystem der Folie gespeichert. Dadurch können Sie den Kommentarmarker exakt dort platzieren, wo Sie ihn benötigen.