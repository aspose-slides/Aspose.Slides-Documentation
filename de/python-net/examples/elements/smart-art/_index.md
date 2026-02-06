---
title: SmartArt
type: docs
weight: 140
url: /de/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt hinzufügen
- SmartArt zugreifen
- SmartArt entfernen
- SmartArt-Layout
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und bearbeiten Sie SmartArt in Python mit Aspose.Slides: Knoten hinzufügen, Layouts und Stile ändern, präzise in Formen konvertieren und für PPT, PPTX und ODP exportieren."
---
Zeigt, wie man SmartArt‑Grafiken hinzufügt, darauf zugreift, sie entfernt und Layouts ändert, wobei **Aspose.Slides for Python via .NET** verwendet wird.

## **SmartArt hinzufügen**

Fügen Sie eine SmartArt‑Grafik mithilfe eines der integrierten Layouts ein.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt zugreifen**

Rufen Sie das erste SmartArt‑Objekt auf einer Folie ab.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Zugriff auf die erste SmartArt-Form.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **SmartArt entfernen**

Löschen Sie eine SmartArt‑Form von der Folie.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, die erste Form ist ein SmartArt-Objekt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt‑Layout ändern**

Aktualisieren Sie den Layouttyp einer vorhandenen SmartArt‑Grafik.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, die erste Form ist ein SmartArt-Objekt.
        smart_art = slide.shapes[0]

        # SmartArt-Layout ändern.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```