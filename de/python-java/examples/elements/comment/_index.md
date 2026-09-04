---
title: Kommentar
type: docs
weight: 230
url: /de/python-java/examples/elements/comment/
keywords:
- Kommentar
- Moderner Kommentar
- Kommentar hinzufügen
- Kommentar lesen
- Kommentar entfernen
- Auf Kommentar antworten
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie moderne Folienkommentare in Aspose.Slides für Python via Java: Kommentare hinzufügen, lesen, entfernen und auf Kommentare antworten in PowerPoint- und OpenDocument-Präsentationen."
---
Dieser Artikel demonstriert, wie man moderne Kommentare hinzufügt, liest, entfernt und beantwortet, indem **Aspose.Slides for Python via Java** verwendet wird.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jeder Beispiel importiert `asposeslides` bevor die JVM gestartet wird und importiert anschließend die API und die erforderlichen Java-Typen, sobald die JVM läuft. Die Zugriffs- und Entfernungsbeispiele verwenden `modern_comment.pptx`, das im ersten Beispiel erstellt wurde.

## **Modernen Kommentar hinzufügen**

Erstellen Sie einen von einem Benutzer verfassten Kommentar und speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt.geom import Point2D
from java.util import Date

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("User", "U1")
    position = Point2D.Float(100, 100)
    author.getComments().addModernComment("This is a modern comment", slide, None, position, Date())

    presentation.save("modern_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zugriff auf einen modernen Kommentar**

Lesen Sie den ersten modernen Kommentar aus einer vorhandenen Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("modern_comment.pptx")
try:
    if presentation.getCommentAuthors().size() > 0:
        author = presentation.getCommentAuthors().get_Item(0)
        if author.getComments().size() > 0:
            comment = author.getComments().get_Item(0)
            print("Author:", author.getName())
            print("Comment:", comment.getText())
            print("Position:", comment.getPosition())
        else:
            print("The first author has no comments.")
    else:
        print("The presentation has no comment authors.")
finally:
    presentation.dispose()
```

## **Einen modernen Kommentar entfernen**

Entfernen Sie den ersten Kommentar und speichern Sie die aktualisierte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("modern_comment.pptx")
try:
    if presentation.getCommentAuthors().size() > 0:
        author = presentation.getCommentAuthors().get_Item(0)
        if author.getComments().size() > 0:
            comment = author.getComments().get_Item(0)
            comment.remove()
        else:
            print("The first author has no comments.")
    else:
        print("The presentation has no comment authors.")

    presentation.save("modern_comment_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Auf einen modernen Kommentar antworten**

Erstellen Sie einen übergeordneten Kommentar, fügen Sie zwei Antworten hinzu und speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt.geom import Point2D
from java.util import Date

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("User", "U1")
    created_time = Date()

    parent_position = Point2D.Float(100, 100)
    parent_comment = author.getComments().addModernComment("Parent comment", slide, None, parent_position, created_time)

    reply1_position = Point2D.Float(110, 100)
    reply1 = author.getComments().addModernComment("Reply 1", slide, None, reply1_position, created_time)

    reply2_position = Point2D.Float(120, 100)
    reply2 = author.getComments().addModernComment("Reply 2", slide, None, reply2_position, created_time)

    reply1.setParentComment(parent_comment)
    reply2.setParentComment(parent_comment)

    presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```