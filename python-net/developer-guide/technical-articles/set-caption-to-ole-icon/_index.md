---
title: Set Caption to OLE Icon
type: docs
weight: 160
url: /python-net/set-caption-to-ole-icon/
---

A new property **SubstitutePictureTitle** has been added to **IOleObjectFrame** interface and **OleObjectFrame** class. It allows to get, set or change the caption of an OLE icon. The code snippet below shows a sample of creating Excel object and setting its caption.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an OLE object to the slide
    with open("oleSourceFile.xlsx", "rb") as ole_stream:
        data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.read(), "xlsx")

    ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

    # Add an image to the presentation's image collection
    with slides.Images.from_file("oleIconFile.ico") as image:
        pp_image = presentation.images.add_image(image)

    # Set the image as an icon for the OLE object
    ole_frame.is_object_icon = True
    ole_frame.substitute_picture_format.picture.image = pp_image

    # Set a caption to the OLE icon
    ole_frame.substitute_picture_title = "Caption example"
```
