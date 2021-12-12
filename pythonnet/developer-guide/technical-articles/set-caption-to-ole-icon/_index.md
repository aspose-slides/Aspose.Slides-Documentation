---
title: Set Caption to OLE Icon
type: docs
weight: 160
url: /pythonnet/set-caption-to-ole-icon/
---

A new property **SubstitutePictureTitle** has been added to **IOleObjectFrame** interface and **OleObjectFrame** class. It allows to get, set or change the caption of an OLE icon. The code snippet below shows a sample of creating Excel object and setting its caption.

```py
import aspose.pydrawing as draw
import aspose.slides as slides


def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

with slides.Presentation() as pres:
    slide = pres.slides[0]

    # Add Ole objects
    allbytes = read_all_bytes("oleSourceFile.bin")
    dataInfo = slides.dom.ole.OleEmbeddedDataInfo(allbytes, "xls")
    
    oof = slide.shapes.add_ole_object_frame(20, 20, 50, 50, dataInfo)
    oof.is_object_icon = True

    # Add image object
    imgBuf = read_all_bytes("oleIconFile.ico")
    with open("oleIconFile.ico", "rb") as stream:
        image = pres.images.add_image(slides.Bitmap(stream))
        oof.substitute_pictureFormat.picture.image = image

    # Set caption to OLE icon
    oof.substitute_picture_title = "Caption example"
```


