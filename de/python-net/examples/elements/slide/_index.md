---
title: Folie
type: docs
weight: 10
url: /de/python-net/examples/elements/slide/
keywords:
- Folie
- Folie hinzufügen
- Folie zugreifen
- Folienindex
- Folie duplizieren
- Folien neu anordnen
- Folie entfernen
- Code-Beispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Folien in Python mit Aspose.Slides: erstellen, duplizieren, neu anordnen, ausblenden, Hintergründe und Größe festlegen, Übergänge anwenden und für PowerPoint und OpenDocument exportieren."
---
Dieser Artikel enthält eine Reihe von Beispielen, die zeigen, wie man mit Folien unter **Aspose.Slides for Python via .NET** arbeitet. Sie lernen, wie man Folien mit der Klasse `Presentation` hinzufügt, darauf zugreift, sie dupliziert, neu anordnet und entfernt.

Jedes der nachstehenden Beispiele enthält eine kurze Erklärung gefolgt von einem Python‑Code‑Snippet.

## **Eine Folie hinzufügen**

Um eine neue Folie hinzuzufügen, müssen Sie zunächst ein Layout auswählen. In diesem Beispiel verwenden wir das Layout `Blank` und fügen eine leere Folie zur Präsentation hinzu.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Jede Folie basiert auf einem Layout, das selbst auf einer Master-Folie basiert.
        # Verwenden Sie das Blank-Layout, um eine neue Folie zu erstellen.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Fügen Sie eine neue leere Folie mit dem ausgewählten Layout hinzu.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡**Tipp:** Jedes Folienlayout leitet sich von einer Master‑Folie ab, die das Gesamtdesign und die Platzhalterstruktur definiert. Das untenstehende Bild zeigt, wie Master‑Folien und ihre zugehörigen Layouts in PowerPoint organisiert sind.

![Master and Layout Relationship](master-layout-slide.png)

## **Folien nach Index zugreifen**

Sie können auf Folien über ihren Index zugreifen. Das ist nützlich, um Folien zu durchlaufen oder bestimmte Folien zu ändern.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Zugriff auf eine Folie per Index.
        first_slide = presentation.slides[0]
```

## **Eine Folie duplizieren**

Dieses Beispiel zeigt, wie man eine vorhandene Folie dupliziert. Die duplizierte Folie wird automatisch am Ende der Folien‑Sammlung eingefügt.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Dupliziere die Folie; sie wird am Ende der Präsentation hinzugefügt.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Folien neu anordnen**

Sie können die Reihenfolge der Folien ändern, indem Sie eine Folie an einen neuen Index verschieben. In diesem Fall verschieben wir eine Folie an die erste Position.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Verschiebe die Folie an die erste Position (andere rücken nach unten).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Eine Folie entfernen**

Um eine Folie zu entfernen, referenzieren Sie sie einfach und rufen `remove` auf. Dieses Beispiel entfernt die erste Folie.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Entferne die Folie.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```