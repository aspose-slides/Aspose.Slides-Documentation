---
title: OleObject
type: docs
weight: 210
url: /python-net/examples/elements/ole-object/
keywords:
- OLE object
- add OLE object
- access OLE object
- remove OLE object
- update OLE object
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Work with OLE objects in Python using Aspose.Slides: insert or update embedded files, set icons or links, extract content, control behavior for PPT, PPTX and ODP."
---

Demonstrates embedding a file as an OLE object and updating its data using **Aspose.Slides for Python via .NET**.

## **Add an OLE Object**

Embed a PDF file into the presentation.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Load PDF data to embed.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Add an OLE object frame to the slide.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Access an OLE Object**

Retrieve the first OLE object frame on a slide.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Get the first OLE object frame on the slide.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Remove an OLE Object**

Delete an embedded OLE object from the slide.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is an OleObjectFrame object.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Update OLE Object Data**

Replace the data embedded in an existing OLE object.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is an OleObjectFrame object.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Update the OLE object with the new embedded data.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```
