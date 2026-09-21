---
title: Verwalten von Präsentationsnotizen in Python über Java
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

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. Dieses Thema stellt diese Funktion vor, einschließlich wie Notizen entfernt und wie ein Stil auf Notizfolien in einer Präsentation angewendet wird. Aspose.Slides ermöglicht das Entfernen von Notizen von jeder Folie und das Anwenden von Formatierungen auf vorhandene Notizen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen einer bestimmten Folie in einer Präsentation entfernen.
- Notizen aus allen Folien einer Präsentation entfernen.

Um die Seitenabmessungen von Notizen zu lesen oder zu ändern, die Orientierung umzuschalten und das Exportverhalten zu prüfen, siehe [Notes Page Size](/slides/de/python-java/notes-size/).

## **Notizen von einer Folie entfernen**

Notizen von einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("presWithNotes.pptx")
try:
    # Entfernen Sie Notizen von der ersten Folie.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Notizen aus einer Präsentation entfernen**

Notizen aus allen Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("presWithNotes.pptx")
try:
    # Entfernen Sie Notizen von allen Folien.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Notizstil hinzufügen**

Die [getNotesStyle](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslide/#getNotesStyle)-Methode der [MasterNotesSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslide/)-Klasse bietet Zugriff auf den Stil des Notiztextes. Die Implementierung wird im nachstehenden Beispiel demonstriert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Holen Sie den Textstil der Master-Notizfolie.
        notes_style = notes_master.getNotesStyle()

        # Setzen Sie Symbolaufzählungszeichen für Absätze der ersten Ebene.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welches API-Entität bietet Zugriff auf die Notizen einer bestimmten Folie?**

Notizen werden über den Notizen‑Manager der Folie abgerufen: Die Folie besitzt einen [NotesSlideManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/notesslidemanager/) und eine [getNotesSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/notesslidemanager/#getNotesSlide)-Methode, die das Notizobjekt zurückgibt, oder `None`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek richtet sich an ein breites Spektrum von Microsoft PowerPoint‑Formaten (97 und neuer) sowie ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Version von PowerPoint erforderlich ist.