---
title: Fügen Sie eine Folie zur Präsentation hinzu
type: docs
weight: 10
url: /de/python-net/add-slide-to-presentation/
keywords: "Folie zur Präsentation hinzufügen, Python, Aspose.Slides"
description: "Folie zur Präsentation in Python hinzufügen"
---

## **Fügen Sie eine Folie zur Präsentation hinzu**
Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten über die Folien besprechen. Jede PowerPoint-Präsentationsdatei enthält Master-/Layoutfolie und andere normale Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für Python über .NET nicht unterstützt werden. Jede Folie hat eine eindeutige ID und alle normalen Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index festgelegt ist. Aspose.Slides für Python über .NET ermöglicht Entwicklern das Hinzufügen von leeren Folien zu ihrer Präsentation. Um eine leere Folie in die Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Klasse, indem Sie eine Referenz auf die Slides (Sammlung von Inhalt-Folienobjekten) Eigenschaft verwenden, die vom Präsentationsobjekt bereitgestellt wird.
- Fügen Sie eine leere Folie am Ende der Sammlung der Inhaltsfolien hinzu, indem Sie die AddEmptySlide-Methoden aufrufen, die vom ISlideCollection-Objekt bereitgestellt werden.
- Machen Sie einige Arbeiten mit der neu hinzugefügten leeren Folie.
- Speichern Sie schließlich die Präsentationsdatei mit dem [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Objekt.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt
with slides.Presentation() as pres:
    # Instanziieren Sie die SlideCollection-Klasse
    slds = pres.slides

    for i in range(len(pres.layout_slides)):
        # Fügen Sie eine leere Folie zur Folienkollektion hinzu
        slds.add_empty_slide(pres.layout_slides[i])
        
    # Machen Sie einige Arbeiten an der neu hinzugefügten Folie

    # Speichern Sie die PPTX-Datei auf der Festplatte
    pres.save("EmptySlide.pptx", slides.export.SaveFormat.PPTX)
```