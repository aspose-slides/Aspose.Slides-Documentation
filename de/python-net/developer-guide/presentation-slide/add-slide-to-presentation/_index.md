---
title: Folien zu Präsentationen mit Python hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/python-net/add-slide-to-presentation/
keywords:
- add slide
- create slide
- empty slide
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Fügen Sie Ihrer PowerPoint‑ und OpenDocument‑Präsentation mithilfe von Aspose.Slides für Python via .NET ganz einfach Folien hinzu – nahtloses, effizientes Einfügen von Folien in Sekunden."
---

## **Übersicht**

Bevor Sie Folien zu einer Präsentation hinzufügen, ist es hilfreich zu verstehen, wie PowerPoint sie organisiert. Jede Präsentation enthält eine Master‑Folie, optionale Layout‑Folien und eine oder mehrere Normal‑Folien. Jede Folie hat eine eindeutige ID, und Normal‑Folien werden über einen nullbasierten Index sortiert. Dieser Artikel zeigt, wie Sie Aspose.Slides für Python verwenden, um Folien zu erstellen und geeignete Layouts auszuwählen.

## **Folien zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht es Ihnen, neue Folien basierend auf vorhandenen Layout‑Folien anzuhängen. Das nachfolgende Beispiel iteriert über jedes Layout in der Präsentation, fügt eine Folie hinzu, die dieses Layout verwendet, und speichert anschließend die Datei.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
1. Greifen Sie auf die [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) zu.  
1. Rufen Sie für jedes Element in `presentation.layout_slides` `add_empty_slide` auf, um eine Folie hinzuzufügen, die dieses Layout verwendet.  
1. Ändern Sie optional die neu hinzugefügten Folien.  
1. Speichern Sie die Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the slide collection.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Add an empty slide to the slide collection.
        slides.add_empty_slide(layout_slide)

    # Do some work on the newly added slides.

    # Save the presentation to disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen und nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Folien‑Sammlungen und [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/)-Operationen, sodass Sie eine Folie an dem gewünschten Index hinzufügen können, nicht nur am Ende.

**Werden Themen/Styles beibehalten, wenn ich eine Folie basierend auf einem Layout einfüge?**

Ja. Ein Layout übernimmt die Formatierung von seinem Master, und die neue Folie übernimmt die Formatierung des ausgewählten Layouts sowie des zugehörigen Masters.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit Index 0. Das ist wichtig zu berücksichtigen, wenn Einfüge‑Indizes berechnet werden.

**Wie wähle ich das „richtige“ Layout für eine neue Folie aus, wenn der Master viele Optionen hat?**

Wählen Sie im Allgemeinen das [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), das der gewünschten Struktur entspricht ([Titel und Inhalt, Zwei Inhalte usw.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [hinzufügen](/slides/de/python-net/slide-layout/) und anschließend verwenden.