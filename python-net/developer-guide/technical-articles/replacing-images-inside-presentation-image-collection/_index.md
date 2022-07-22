---
title: Replacing Images inside Presentation Image Collection
type: docs
weight: 110
url: /python-net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for Python via .NET makes it possible to replace the images added in slide shapes. This article explains how to replace the image added in presentation image collection using different approaches.

{{% /alert %}} 
## **Replacing Image inside Presentation Image Collection**
Aspose.Slides for Python via .NET provides a simple API methods for replacing the images inside presentation image collection. Please follow the steps below:

1. Load the presentation file with image inside it using [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Load an image from file in byte array.
1. Replace the target image with new image in byte array
1. In second approach load the image in Image object and replace the target image with loaded image.
1. In third approach replace the image with already added image in presentation image collection.
1. Write the modified presentation as a PPTX file.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

#Instantiate the presentation
with slides.Presentation("pres.pptx") as presentation:

    #the first way
    data = read_all_bytes("image_0.jpeg")
    oldImage = presentation.images[0]
    oldImage.replace_image(data)

    #the second way
    newImage = draw.Image.from_file("image_1.jpeg")
    oldImage = presentation.images[1]
    oldImage.replace_image(newImage)

    #the third way
    oldImage = presentation.images[2]
    oldImage.replace_image(presentation.images[3])

    #Save the presentation
    presentation.save("replace_image-out.pptx", slides.export.SaveFormat.PPTX)
```

