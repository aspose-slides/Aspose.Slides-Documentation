---
title: Präsentationsnotizen
type: docs
weight: 110
url: /de/python-net/presentation-notes/
keywords: "Notizen, PowerPoint-Notizen, Notizen hinzufügen, Notizen entfernen, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Notizen in PowerPoint-Präsentationen in Python hinzufügen und entfernen"
---



Aspose.Slides unterstützt das Entfernen von Notizenfolien aus einer Präsentation. In diesem Thema werden wir diese neue Funktion zum Entfernen von Notizen sowie das Hinzufügen von Notizenstilfolien aus jeder Präsentation vorstellen. Aspose.Slides für Python über .NET bietet die Funktion, Notizen von jeder Folie zu entfernen sowie Stil zu bestehenden Notizen hinzuzufügen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen einer bestimmten Folie einer Präsentation entfernen.
- Notizen aller Folien einer Präsentation entfernen.
## **Notizen von einer Folie entfernen**
Notizen einer bestimmten Folie können wie im folgenden Beispiel gezeigt entfernt werden:

```py
import aspose.slides as slides

# Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Entfernen der Notizen der ersten Folie
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # Präsentation auf der Festplatte speichern
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Notizen von allen Folien entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel gezeigt entfernt werden:

```py
import aspose.slides as slides

# Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Entfernen der Notizen aller Folien
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # Präsentation auf der Festplatte speichern
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Notizenstil hinzufügen**
Die Notizenstil-Eigenschaft wurde zur [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) Schnittstelle und zur [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) Klasse hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztexts an. Die Implementierung wird im folgenden Beispiel demonstriert.

```py
import aspose.slides as slides

# Instanziieren Sie die Präsentationsklasse, die die Präsentationsdatei darstellt
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Holen Sie den Textstil der MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Setzen Sie das Symbol für die Aufzählungszeichen für die ersten Absatzebenen
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # Speichern Sie die PPTX-Datei auf der Festplatte
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```