---
title: Zugriff auf Folien in Präsentationen mit Python
linktitle: Folie aufrufen
type: docs
weight: 20
url: /de/python-net/access-slide-in-presentation/
keywords:
- auf folien zugreifen
- folienindex
- folien-ID
- folienposition
- position ändern
- folieneigenschaften
- foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides for Python via .NET aufrufen und verwalten. Steigern Sie Ihre Produktivität mit Codebeispielen."
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: über den Index und über die ID.

## **Zugriff auf Folie über Index**

Alle Folien in einer Präsentation sind numerisch basierend auf der Folienposition angeordnet, beginnend mit 0. Die erste Folie ist über den Index 0 zugänglich; die zweite Folie wird über den Index 1 erreicht; usw.

Die Klasse Presentation, die eine Präsentationsdatei repräsentiert, stellt alle Folien als eine [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Sammlung (Sammlung von [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Objekten) zur Verfügung. Dieser Python-Code zeigt, wie man über den Index auf eine Folie zugreift:

```python
import aspose.slides as slides

# Erstellt ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Erhält einen Verweis auf die Folie über ihren Index
    slide = presentation.slides[0]
```

## **Zugriff auf Folie über ID**

Jede Folie in einer Präsentation hat eine eindeutige ID, die mit ihr verbunden ist. Sie können die Methode `get_slide_by_id(id)` verwenden (bereitgestellt durch die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse), um diese ID gezielt anzusprechen. Dieser Python-Code zeigt, wie man eine gültige Folien-ID angibt und über die Methode `get_slide_by_id(id)` auf diese Folie zugreift:

```python
import aspose.slides as slides

# Erstellt ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Erhält eine Folien-ID
    id = presentation.slides[0].slide_id
    # Greift auf die Folie über ihre ID zu
    slide = presentation.get_slide_by_id(id)
```

## **Folie Position ändern**

Aspose.Slides ermöglicht Ihnen, die Position einer Folie zu ändern. Zum Beispiel können Sie angeben, dass die erste Folie zur zweiten Folie werden soll.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich den Verweis auf die Folie (deren Position Sie ändern möchten) über ihren Index.
3. Legen Sie eine neue Position für die Folie über die Eigenschaft `slide_number` fest.
4. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code demonstriert eine Operation, bei der die Folie in Position 1 nach Position 2 verschoben wird:

```python
import aspose.slides as slides

# Erstellt ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "ChangePosition.pptx") as pres:
    # Erhält die Folie, deren Position geändert wird
    sld = pres.slides[0]
    # Setzt die neue Position für die Folie
    sld.slide_number = 2
    # Speichert die modifizierte Präsentation
    pres.save("Aspose_out.pptx", slides.export.SaveFormat.PPTX)
```

Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Wenn Sie die Position einer Folie ändern, werden andere Folien automatisch angepasst.

## **Folie Nummer festlegen**

Durch die Verwendung der Eigenschaft `first_slide_number` (bereitgestellt durch die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse) können Sie eine neue Nummer für die erste Folie in einer Präsentation festlegen. Diese Operation führt dazu, dass die anderen Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Foliennummer.
3. Legen Sie die Foliennummer fest.
4. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code demonstriert eine Operation, bei der die erste Foliennummer auf 10 gesetzt wird:

```python
import aspose.slides as slides

# Erstellt ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Erhält die Foliennummer
    firstSlideNumber = presentation.first_slide_number
    # Setzt die Foliennummer
    presentation.first_slide_number = 10
    # Speichert die modifizierte Präsentation
    presentation.save("Set_Slide_Number_out.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummerierung für die erste Folie ausblenden) auf folgende Weise:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Legt die Nummer für die erste Präsentationsfolie fest
    presentation.first_slide_number = 0

    # Zeigt die Foliennummern für alle Folien an
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Blendet die Foliennummer für die erste Folie aus
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Speichert die modifizierte Präsentation
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```