---
title: Folien zu Präsentationen mit Python hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/python-net/add-slide-to-presentation/
keywords:
- Folie hinzufügen
- Folie erstellen
- leere Folie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie Ihren PowerPoint- und OpenDocument-Präsentationen ganz einfach Folien mit Aspose.Slides für Python via .NET hinzu – nahtloses, effizientes Einfügen von Folien in Sekunden."
---

## **Übersicht**

Bevor Sie Folien zu einer Präsentation hinzufügen, ist es hilfreich zu verstehen, wie PowerPoint sie organisiert. Jede Präsentation enthält eine Masterfolie, optionale Layoutfolien und eine oder mehrere normale Folien. Jede Folie hat eine eindeutige ID, und normale Folien werden nach einem nullbasierten Index sortiert. Dieser Artikel zeigt, wie man Aspose.Slides für Python verwendet, um Folien zu erstellen und geeignete Layouts auszuwählen.

## **Folien zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Anhängen neuer Folien basierend auf vorhandenen Layoutfolien. Das untenstehende Beispiel durchläuft jedes Layout in der Präsentation, fügt eine Folie hinzu, die dieses Layout verwendet, und speichert anschließend die Datei.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Greifen Sie auf die [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) zu.
3. Rufen Sie für jedes Element in `presentation.layout_slides` die Methode `add_empty_slide` auf, um eine Folie anzuhängen, die dieses Layout verwendet.
4. Optional können Sie die neu hinzugefügten Folien ändern.
5. Speichern Sie die Präsentation als PPTX-Datei.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:
    # Greifen Sie auf die Folienkollektion zu.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Fügen Sie eine leere Folie zur Folienkollektion hinzu.
        slides.add_empty_slide(layout_slide)

    # Führen Sie Arbeiten an den neu hinzugefügten Folien durch.

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt FolienSammlungen und die Operationen [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), sodass Sie eine Folie an dem gewünschten Index einfügen können, anstatt nur am Ende.

**Werden die Themen/Stile beim Hinzufügen einer Folie basierend auf einem Layout beibehalten?**

Ja. Ein Layout erbt die Formatierung von seinem Master, und die neue Folie erbt von dem ausgewählten Layout und dem zugehörigen Master.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit dem Index null. Das ist wichtig zu beachten, wenn Einfügeindizes berechnet werden.

**Wie wähle ich das „richtige“ Layout für eine neue Folie, wenn der Master viele Optionen hat?**

Wählen Sie im Allgemeinen das [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), das der benötigten Struktur entspricht ([Titel und Inhalt, Zwei Inhalte usw.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [add it to the master](/slides/de/python-net/slide-layout/) hinzufügen und anschließend verwenden.