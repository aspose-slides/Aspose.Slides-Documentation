---
title: Präsentationsnotizen in Python über Java verwalten
linktitle: Präsentationsnotizen
type: docs
weight: 110
url: /de/python-java/presentation-notes/
keywords:
- Notizen
- Notizfolie
- Notizen hinzufügen
- Notizen entfernen
- Notizstil
- Master-Notizen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für Python über Java an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---
## **Übersicht**

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. Dieses Thema führt in diese Funktion ein, einschließlich wie man Notizen entfernt und wie man einen Stil auf Notizfolien in einer Präsentation anwendet. Aspose.Slides ermöglicht es Ihnen, Notizen von beliebigen Folien zu entfernen und das Styling vorhandener Notizen anzuwenden. Entwickler können Notizen auf folgende Weise entfernen:

- Entfernen von Notizen einer bestimmten Folie in einer Präsentation.
- Entfernen von Notizen von allen Folien in einer Präsentation.

## **Notizen von einer Folie entfernen**

Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Erstelle ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("presWithNotes.pptx")
try:
    # Entferne Notizen von der ersten Folie.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Speichere die Präsentation auf der Festplatte.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Notizen aus einer Präsentation entfernen**

Notizen von allen Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Erstelle ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("presWithNotes.pptx")
try:
    # Entferne Notizen von allen Folien.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Speichere die Präsentation auf der Festplatte.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Einen Notizstil hinzufügen**

Die [getNotesStyle](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslide/#getNotesStyle)‑Methode der [MasterNotesSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslide/)‑Klasse bietet Zugriff auf den Stil des Notiztextes. Die Implementierung wird im folgenden Beispiel gezeigt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Erstelle ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Hole den Textstil der Master-Notizfolie.
        notes_style = notes_master.getNotesStyle()

        # Setze Symbol-Aufzählungszeichen für Absätze der ersten Ebene.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welche API-Entität bietet Zugriff auf die Notizen einer bestimmten Folie?**

Notizen werden über den Notizen‑Manager der Folie abgerufen: Die Folie besitzt einen [NotesSlideManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/notesslidemanager/) und eine [getNotesSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/notesslidemanager/#getNotesSlide)‑Methode, die das Notizen‑Objekt zurückgibt oder `None`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek unterstützt ein breites Spektrum von Microsoft PowerPoint‑Formaten (97 und neuer) sowie ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.