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

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese neue Funktion zum Entfernen von Notizen sowie zum Hinzufügen von Notiz‑Stil‑Folien aus einer beliebigen Präsentation vor. Aspose.Slides für Python über .NET bietet die Möglichkeit, Notizen einer beliebigen Folie zu entfernen und Stil zu vorhandenen Notizen hinzuzufügen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen einer bestimmten Folie einer Präsentation entfernen.
- Notizen aller Folien einer Präsentation entfernen.

## **Notizen von Folie entfernen**
Notizen einer bestimmten Folie können, wie im folgenden Beispiel gezeigt, entfernt werden:
```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Entfernen der Notizen der ersten Folie
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # Präsentation auf Festplatte speichern
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Notizen aller Folien entfernen**
Notizen aller Folien einer Präsentation können, wie im folgenden Beispiel gezeigt, entfernt werden:
```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Entfernen der Notizen aller Folien
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # Präsentation auf Festplatte speichern
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **NotesStyle hinzufügen**
Die [notes_style](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/notes_style/)‑Eigenschaft wurde zur [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/)‑Klasse hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im folgenden Beispiel gezeigt.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide-Textstil abrufen
        notesStyle = notesMaster.notes_style

        #Set Symbol-Bullet für die Absätze der ersten Ebene
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX-Datei auf die Festplatte speichern
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Welche API‑Entität bietet Zugriff auf die Notizen einer bestimmten Folie?**

Auf die Notizen wird über den Notiz‑Manager der Folie zugegriffen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) und eine [property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/), die das Notiz‑Objekt zurückgibt, bzw. `None`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek unterstützt ein breites Spektrum an Microsoft‑PowerPoint‑Formaten (97 - neuere) sowie ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte PowerPoint‑Kopie erforderlich ist.