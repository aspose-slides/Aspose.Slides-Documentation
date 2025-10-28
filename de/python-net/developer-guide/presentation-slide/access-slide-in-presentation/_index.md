---
title: Zugriff auf Folien in Präsentationen mit Python
linktitle: Folie öffnen
type: docs
weight: 20
url: /de/python-net/access-slide-in-presentation/
keywords:
- Folie öffnen
- Folienindex
- Folien-ID
- Folienposition
- Position ändern
- Folieneigenschaften
- Foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python über .NET Folien in PowerPoint‑ und OpenDocument‑Präsentationen öffnen und verwalten. Steigern Sie die Produktivität mit Code‑Beispielen."
---

## **Übersicht**

Dieser Artikel erklärt, wie Sie mit Aspose.Slides für Python auf bestimmte Folien in einer PowerPoint‑Präsentation zugreifen. Er zeigt, wie Sie eine Präsentation öffnen, Folien über den Index oder die eindeutige ID referenzieren und grundlegende Folieninformationen auslesen, die für die Navigation innerhalb der Datei erforderlich sind. Mit diesen Techniken können Sie zuverlässig die genaue Folie finden, die Sie inspizieren oder verarbeiten möchten.

## **Zugriff auf eine Folie über den Index**

Folien in einer Präsentation werden nach ihrer Position indiziert, beginnend bei 0. Die erste Folie hat den Index 0, die zweite Folie den Index 1 usw.

Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse (die eine Präsentationsdatei darstellt) stellt Folien über eine [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) von [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)‑Objekten bereit.

Der folgende Python‑Code zeigt, wie Sie über den Index auf eine Folie zugreifen:

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide by its index.
    slide = presentation.slides[0]
```

## **Zugriff auf eine Folie über die ID**

Jede Folie in einer Präsentation besitzt eine eindeutige ID. Sie können die Methode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse) verwenden, um diese ID anzusprechen.

Der folgende Python‑Code zeigt, wie Sie eine gültige Folien‑ID ermitteln und über die Methode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) darauf zugreifen:

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide ID.
    id = presentation.slides[0].slide_id
    # Access the slide by its ID.
    slide = presentation.get_slide_by_id(id)
```

## **Ändern der Position einer Folie**

Aspose.Slides ermöglicht das Ändern der Position einer Folie. Beispielsweise können Sie die erste Folie zur zweiten machen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie, deren Position Sie ändern möchten, über deren Index.  
3. Setzen Sie über die Eigenschaft [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) eine neue Position für die Folie.  
4. Speichern Sie die geänderte Präsentation.

Der folgende Python‑Code verschiebt die Folie an Position 1 zu Position 2:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get the slide whose position will be changed.
    slide = presentation.slides[0]
    # Set the new position for the slide.
    slide.slide_number = 2
    # Save the modified presentation.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Die erste Folie wird zur zweiten; die zweite Folie wird zur ersten. Beim Ändern der Folienposition werden andere Folien automatisch angepasst.

## **Festlegen der Foliennummer**

Mittels der Eigenschaft [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Dieser Vorgang führt zu einer Neuberechnung aller anderen Foliennummern.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Setzen Sie die Foliennummer.  
3. Speichern Sie die geänderte Präsentation.

Der folgende Python‑Code demonstriert, wie die erste Foliennummer auf 10 gesetzt wird:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Set the slide number.
    presentation.first_slide_number = 10
    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummer auf der ersten Folie ausblenden) wie folgt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Set the number for the first slide in the presentation.
    presentation.first_slide_number = 0

    # Show slide numbers for all slides.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Hide the slide number on the first slide.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Entspricht die von einem Benutzer gesehenen Foliennummer dem nullbasierten Index der Sammlung?**

Die auf einer Folie angezeigte Nummer kann einen beliebigen Wert (z. B. 10) haben und muss nicht mit dem Index übereinstimmen; die Beziehung wird durch die Einstellung *first slide number* der Präsentation gesteuert.

**Beeinflussen ausgeblendete Folien die Indizierung?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indizierung gezählt; *ausgeblendet* bezieht sich nur auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden nach Einfügen, Löschen und Verschieben neu berechnet.