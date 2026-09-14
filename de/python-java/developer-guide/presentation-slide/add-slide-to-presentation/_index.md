---
title: Folien zu Präsentationen in Python hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/python-java/add-slide-to-presentation/
keywords:
- Folie hinzufügen
- Folie erstellen
- Leere Folie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie ganz einfach Folien zu Ihren PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java hinzu – nahtloses, effizientes Einfügen von Folien in Sekunden."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, Folien programmatisch zu PowerPoint‑Präsentationen hinzuzufügen. Eine Präsentation enthält Master‑/Layout‑Folien und normale Folien, und normale Folien werden über einen nullbasierten Index angeordnet. Jede Folie hat eine eindeutige ID, und Präsentationsdateien ohne Folien werden nicht unterstützt.

Dieser Artikel erklärt, wie ein [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekt erstellt, seine Folien‑Collection abgerufen, eine leere Folie hinzugefügt, mit der neu hinzugefügten Folie gearbeitet und die aktualisierte Präsentation gespeichert wird. Außerdem werden verwandte Punkte behandelt, wie das Einfügen von Folien an einer bestimmten Position, die Verwendung von Layouts und das Verständnis der leeren Folie, die in einer neu erstellten Präsentation vorkommt.

## **Eine Folie zu einer Präsentation hinzufügen**

Bevor wir besprechen, wie Folien zu Präsentationsdateien hinzugefügt werden, werfen wir einen Blick auf einige Fakten zu Folien. Jede PowerPoint‑Präsentationsdatei enthält **Master‑/Layout‑**Folien und **normale** Folien. Eine Präsentationsdatei enthält mindestens eine Folie. Präsentationsdateien ohne Folien werden von Aspose.Slides for Python via Java nicht unterstützt. Jede Folie hat eine eindeutige ID, und alle normalen Folien sind in einer Reihenfolge angeordnet, die durch einen nullbasierten Index festgelegt wird.

Aspose.Slides for Python via Java ermöglicht Entwicklern, leere Folien zu ihren Präsentationen hinzuzufügen. So fügen Sie einer Präsentation eine leere Folie hinzu:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.  
- Holen Sie sich über die Methode [getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlides) des [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekts eine Referenz auf das [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/)‑Objekt.  
- Fügen Sie der Folien‑Collection der Präsentation am Ende eine leere Folie hinzu, indem Sie die Methode [addEmptySlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addEmptySlide) des [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/)‑Objekts aufrufen.  
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.  
- Schreiben Sie schließlich die Präsentationsdatei mit dem [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei repräsentiert.
presentation = Presentation()
try:
    # Holen Sie die Folien-Collection.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Fügen Sie der Folien-Collection eine leere Folie hinzu.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Arbeiten Sie mit der neu hinzugefügten Folie.

    # Speichern Sie die PPTX-Datei auf der Festplatte.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Folien‑Collections und die Operationen [insert](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertClone), sodass Sie eine Folie am gewünschten Index und nicht ausschließlich am Ende hinzufügen können.

**Werden Theme/Styles beibehalten, wenn ich eine Folie basierend auf einem Layout hinzufüge?**

Ja. Ein Layout übernimmt die Formatierung von seinem Master, und die neue Folie erbt vom gewählten Layout sowie dem zugehörigen Master.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit dem Index null. Das ist bei der Berechnung von Einfüge‑Indizes zu beachten.

**Wie wähle ich das „richtige“ Layout für eine neue Folie, wenn der Master viele Optionen bietet?**

Im Allgemeinen wählen Sie das [LayoutSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/), das der gewünschten Struktur entspricht ([Titel und Inhalt, Zwei Inhalte usw.](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidelayouttype/)). Sollte ein solches Layout fehlen, können Sie es dem Master [add it to the master](/slides/de/python-java/slide-layout/) hinzufügen und dann verwenden.