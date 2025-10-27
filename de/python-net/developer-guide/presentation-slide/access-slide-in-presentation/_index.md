---
title: Folien in Präsentationen mit Python zugreifen
linktitle: Folie zugreifen
type: docs
weight: 20
url: /de/python-net/developer-guide/presentation-slide/access-slide-in-presentation/
keywords:
- Folie zugreifen
- Folienindex
- Folien‑ID
- Folienposition
- Position ändern
- Folieneigenschaften
- Foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET zugreifen und verwalten. Steigern Sie die Produktivität mit Codebeispielen."
---

## **Überblick**

Dieser Artikel erklärt, wie Sie mit Aspose.Slides für Python bestimmte Folien in einer PowerPoint‑Präsentation zugreifen können. Er zeigt, wie man eine Präsentation öffnet, Folien über den Index oder die eindeutige ID referenziert und grundlegende Folieninformationen ausliest, die für die Navigation innerhalb der Datei erforderlich sind. Mit diesen Techniken können Sie zuverlässig die genaue Folie finden, die Sie inspizieren oder verarbeiten möchten.

## **Eine Folie nach Index zugreifen**

Folien in einer Präsentation werden nach ihrer Position indexiert, beginnend bei 0. Die erste Folie hat den Index 0, die zweite Folie den Index 1 und so weiter.

Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse (die eine Präsentationsdatei repräsentiert) stellt Folien über eine [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) von [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)-Objekten bereit.

Der folgende Python‑Code zeigt, wie Sie eine Folie über ihren Index zugreifen:

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide by its index.
    slide = presentation.slides[0]
```

## **Eine Folie nach ID zugreifen**

Jede Folie in einer Präsentation besitzt eine eindeutige ID. Sie können die Methode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse) verwenden, um diese ID anzusprechen.

Der folgende Python‑Code zeigt, wie Sie eine gültige Folien‑ID angeben und die Folie über die Methode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) zugreifen:

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide ID.
    id = presentation.slides[0].slide_id
    # Access the slide by its ID.
    slide = presentation.get_slide_by_id(id)
```

## **Die Position einer Folie ändern**

Aspose.Slides ermöglicht es Ihnen, die Position einer Folie zu ändern. Beispielsweise können Sie die erste Folie zur zweiten machen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz zu der Folie, deren Position Sie ändern möchten, über ihren Index.  
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

Die erste Folie wird zur zweiten; die zweite Folie wird zur ersten. Wenn Sie die Position einer Folie ändern, werden die anderen Folien automatisch angepasst.

## **Die Foliennummer festlegen**

Mit der Eigenschaft [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Dieser Vorgang bewirkt, dass die anderen Folienzahlen neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Setzen Sie die Foliennummer.  
3. Speichern Sie die geänderte Präsentation.

Der folgende Python‑Code demonstriert eine Operation, bei der die erste Foliennummer auf 10 gesetzt wird:

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

**Entspricht die vom Benutzer gesehenen Foliennummer dem nullbasierten Index der Sammlung?**

Die auf einer Folie angezeigte Nummer kann mit einem beliebigen Wert beginnen (z. B. 10) und muss nicht dem Index entsprechen; die Beziehung wird durch die Einstellung [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) der Präsentation gesteuert.

**Beeinflussen ausgeblendete Folien die Indizierung?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indizierung gezählt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf die Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfüge‑, Lösch‑ und Verschiebe‑Operationen neu berechnet.