---
title: OleObject
type: docs
weight: 210
url: /de/python-net/examples/elements/ole-object/
keywords:
- OLE-Objekt
- OLE-Objekt hinzufügen
- Zugriff auf OLE-Objekt
- OLE-Objekt entfernen
- OLE-Objekt aktualisieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Arbeiten Sie mit OLE-Objekten in Python unter Verwendung von Aspose.Slides: Einbetten oder Aktualisieren von Dateien, Festlegen von Symbolen oder Links, Extrahieren von Inhalten, Steuern des Verhaltens für PPT, PPTX und ODP."
---
Zeigt, wie man eine Datei als OLE-Objekt einbettet und deren Daten mit **Aspose.Slides for Python via .NET** aktualisiert.

## **Ein OLE-Objekt hinzufügen**

Betten Sie eine PDF-Datei in die Präsentation ein.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # PDF-Daten zum Einbetten laden.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Ein OLE-Objekt-Rahmen zur Folie hinzufügen.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf ein OLE-Objekt**

Rufen Sie den ersten OLE-Objektrahmen auf einer Folie ab.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Den ersten OLE-Objektrahmen auf der Folie erhalten.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Ein OLE-Objekt entfernen**

Löschen Sie ein eingebettetes OLE-Objekt von der Folie.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Vorausgesetzt, dass das erste Shape ein OleObjectFrame-Objekt ist.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE-Objektdaten aktualisieren**

Ersetzen Sie die in einem bestehenden OLE-Objekt eingebetteten Daten.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Vorausgesetzt, dass das erste Shape ein OleObjectFrame-Objekt ist.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Aktualisiere das OLE-Objekt mit den neuen eingebetteten Daten.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```