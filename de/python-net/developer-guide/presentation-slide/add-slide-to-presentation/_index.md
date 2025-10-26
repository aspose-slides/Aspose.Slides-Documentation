---
title: Folien zu Präsentationen mit Python hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/python-net/developer-guide/presentation-slide/add-slide-to-presentation/
keywords:
- Folien hinzufügen
- Folien erstellen
- Leere Folie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie Ihrer PowerPoint- und OpenDocument-Präsentation ganz einfach Folien mit Aspose.Slides für Python via .NET hinzu – nahtloses, effizientes Einfügen von Folien in Sekundenschnelle."
---

## **Übersicht**

Bevor Sie Folien zu einer Präsentation hinzufügen, ist es hilfreich zu verstehen, wie PowerPoint sie organisiert. Jede Präsentation enthält eine Master‑Folie, optionale Layout‑Folien und eine oder mehrere normale Folien. Jede Folie hat eine eindeutige ID, und normale Folien werden über einen nullbasierten Index sortiert. Dieser Artikel zeigt, wie Sie Aspose.Slides für Python verwenden, um Folien zu erstellen und geeignete Layouts auszuwählen.

## **Folien zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Anhängen neuer Folien basierend auf vorhandenen Layout‑Folien. Das nachstehende Beispiel iteriert über jedes Layout in der Präsentation, fügt eine Folie hinzu, die dieses Layout verwendet, und speichert anschließend die Datei.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Greifen Sie auf die [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) zu.  
3. Für jedes Element in `presentation.layout_slides` rufen Sie `add_empty_slide` auf, um eine Folie hinzuzufügen, die dieses Layout verwendet.  
4. Optional können Sie die neu hinzugefügten Folien bearbeiten.  
5. Speichern Sie die Präsentation als PPTX‑Datei.

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

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Folien‑Sammlungen und [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/)-Operationen, sodass Sie eine Folie an einem gewünschten Index hinzufügen können, nicht nur am Ende.

**Werden Theme/Stile beibehalten, wenn ich eine Folie basierend auf einem Layout hinzufüge?**

Ja. Ein Layout erbt die Formatierung von seinem Master, und die neue Folie erbt vom ausgewählten Layout und dem zugehörigen Master.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit Index 0. Das ist bei der Berechnung von Einfüge‑Indizes zu berücksichtigen.

**Wie wähle ich das „richtige“ Layout für eine neue Folie, wenn das Master‑Layout viele Optionen hat?**

Wählen Sie in der Regel das [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), das der gewünschten Struktur entspricht ([Titel und Inhalt, Zwei Inhalte usw.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [/slides/python-net/slide-layout/](https://reference.aspose.com/slides/python-net/slide-layout/) hinzufügen und dann verwenden.