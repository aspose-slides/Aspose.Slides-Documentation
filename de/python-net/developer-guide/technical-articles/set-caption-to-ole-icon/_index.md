---
title: Beschriftung für OLE-Symbol festlegen
type: docs
weight: 160
url: /de/python-net/set-caption-to-ole-icon/
---

Eine neue Eigenschaft **SubstitutePictureTitle** wurde zu der **IOleObjectFrame**-Schnittstelle und der **OleObjectFrame**-Klasse hinzugefügt. Sie ermöglicht es, die Beschriftung eines OLE-Symbols abzurufen, festzulegen oder zu ändern. Der folgende Codeausschnitt zeigt ein Beispiel zum Erstellen eines Excel-Objekts und zum Festlegen seiner Beschriftung.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügen Sie ein OLE-Objekt zur Folie hinzu
    with open("oleSourceFile.xlsx", "rb") as ole_stream:
        data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.read(), "xlsx")

    ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

    # Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu
    with slides.Images.from_file("oleIconFile.ico") as image:
        pp_image = presentation.images.add_image(image)

    # Setzen Sie das Bild als Symbol für das OLE-Objekt
    ole_frame.is_object_icon = True
    ole_frame.substitute_picture_format.picture.image = pp_image

    # Setzen Sie eine Beschriftung für das OLE-Symbol
    ole_frame.substitute_picture_title = "Beispielbeschriftung"
```