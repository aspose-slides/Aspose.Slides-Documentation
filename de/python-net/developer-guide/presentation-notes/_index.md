---
title: Verwalten von Präsentationsnotizen in Python
linktitle: Präsentationsnotizen
type: docs
weight: 110
url: /de/python-net/presentation-notes/
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
  - Aspose.Slides
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für Python über .NET an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---
## **Übersicht**

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese Funktion vor, einschließlich wie Notizen entfernt und wie ein Stil auf Notizfolien in einer Präsentation angewendet wird. Aspose.Slides ermöglicht das Entfernen von Notizen von jeder Folie und das Anwenden von Formatierungen auf vorhandene Notizen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen von einer bestimmten Folie in einer Präsentation entfernen.
- Notizen von allen Folien in einer Präsentation entfernen.

Um die Abmessungen der Notizseite zu lesen oder zu ändern, die Orientierung zu wechseln und das Exportverhalten zu prüfen, siehe [Notes Page Size](/slides/de/python-net/notes-size/).

## **Notizen von einer Folie entfernen**
Notizen von einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

```py
import aspose.slides as slides

# Instanziieren eines Presentation-Objekts, das eine Präsentationsdatei darstellt
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Entfernen der Notizen der ersten Folie
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # Präsentation auf Festplatte speichern
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Notizen von allen Folien entfernen**
Notizen von allen Folien in einer Präsentation können wie im folgenden Beispiel entfernt werden:

```py
import aspose.slides as slides

# Instanziieren eines Presentation-Objekts, das eine Präsentationsdatei darstellt
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Entfernen der Notizen aller Folien
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # Präsentation auf Festplatte speichern
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Einen Notizstil anwenden**
Die Eigenschaft [notes_style](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslide/notes_style/) wurde zur Klasse [MasterNotesSlide](https://reference.aspose.com/slides/de/python-net/aspose.slides/masternotesslide/) hinzugefügt. Diese Eigenschaft gibt den Stil des Notiztextes an. Die Implementierung wird im folgenden Beispiel gezeigt.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, die die Präsentationsdatei darstellt
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide-Textstil abrufen
        notesStyle = notesMaster.notes_style

        #Set Symbol-Aufzählungszeichen für die Absätze der ersten Ebene
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX-Datei auf der Festplatte speichern
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Welche API‑Entität bietet Zugriff auf die Notizen einer bestimmten Folie?**

Notizen werden über den Notiz‑Manager der Folie abgerufen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/notesslidemanager/) und eine [property](https://reference.aspose.com/slides/de/python-net/aspose.slides/notesslidemanager/notes_slide/), die das Notiz­objekt zurückgibt, oder `None`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek richtet sich an ein breites Spektrum von Microsoft PowerPoint‑Formaten (97–neuere) und ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte PowerPoint‑Kopie erforderlich ist.