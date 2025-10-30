---
title: Folien zu Präsentationen mit Python hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/python-net/add-slide-to-presentation/
keywords:
- Folie hinzufügen
- Folie erstellen
- Leere Folie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie ganz einfach Folien zu Ihren PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET hinzu – nahtloses, effizientes Einfügen von Folien in Sekunden."
---

## **Übersicht**

Bevor Sie Folien zu einer Präsentation hinzufügen, ist es hilfreich zu verstehen, wie PowerPoint sie organisiert. Jede Präsentation enthält eine Masterfolie, optionale Layoutfolien und eine oder mehrere normale Folien. Jede Folie hat eine eindeutige ID, und normale Folien sind nach einem nullbasierten Index geordnet. Dieser Artikel zeigt, wie Sie Aspose.Slides für Python verwenden, um Folien zu erstellen und geeignete Layouts auszuwählen.

## **Folien zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Anhängen neuer Folien basierend auf vorhandenen Layoutfolien. Das nachstehende Beispiel iteriert über jedes Layout in der Präsentation, fügt eine Folie hinzu, die dieses Layout verwendet, und speichert anschließend die Datei.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) zu.
3. Für jedes Element in `presentation.layout_slides` rufen Sie `add_empty_slide` auf, um eine Folie hinzuzufügen, die dieses Layout verwendet.
4. Optional können die neu hinzugefügten Folien geändert werden.
5. Speichern Sie die Präsentation als PPTX-Datei.

```py
import aspose.slides as slides

# Instanziiere die Presentation-Klasse.
with slides.Presentation() as presentation:
    # Greife auf die Folienkollektion zu.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Füge eine leere Folie zur Folienkollektion hinzu.
        slides.add_empty_slide(layout_slide)

    # Führe einige Arbeiten an den neu hinzugefügten Folien aus.

    # Speichere die Präsentation auf dem Datenträger.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Folienkollektionen und [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) Operationen, sodass Sie eine Folie an dem gewünschten Index hinzufügen können, anstatt nur am Ende.

**Werden die Themen/Formatierungen beim Hinzufügen einer Folie basierend auf einem Layout beibehalten?**

Ja. Ein Layout erbt die Formatierung von seinem Master, und die neue Folie erbt vom ausgewählten Layout und dessen zugehörigem Master.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit Index null. Dies ist bei der Berechnung von Einfügeindizes zu beachten.

**Wie wähle ich das „richtige“ Layout für eine neue Folie, wenn der Master viele Optionen hat?**

Wählen Sie im Allgemeinen die [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), die der erforderlichen Struktur entspricht ([Titel und Inhalt, Zwei Inhalte usw.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [zum Master hinzufügen](/slides/de/python-net/slide-layout/) und dann verwenden.