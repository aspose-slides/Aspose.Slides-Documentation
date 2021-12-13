---
title: Extracting Images from Presentation shapes
type: docs
weight: 90
url: /python-net/extracting-images-from-presentation-shapes/
---

{{% alert color="primary" %}} 

Images are added in slide background and shapes. Sometimes, it is required to extract the images added in the presentation shapes. The images are added in **PPImageCollection** inside Presentation Document Object Model (DOM). This article covers the feature of accessing the images in presentation shape, extracting them from presentation collection and saving them in a file.

{{% /alert %}} 
## **Extracting images from Presentation Shapes**
In Aspose.Slides for Python via .NET, images can be added to slide shape and slide background. The images are added in **PPImageCollection** of the presentation. In this example we will traverse through each shape inside every slide of presentation and see if there is any image added in slide shape. If the image will be found for any shape, we will extract that and will save it in file.The following code snippet will serve the purpose.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

def get_image_format(image_type):
    return {
        "jpeg": draw.imaging.ImageFormat.jpeg,
        "emf": draw.imaging.ImageFormat.emf,
        "bmp": draw.imaging.ImageFormat.bmp,
        "png": draw.imaging.ImageFormat.png,
        "wmf": draw.imaging.ImageFormat.wmf,
        "gif": draw.imaging.ImageFormat.gif,
    }.get(image_type, draw.imaging.ImageFormat.jpeg)

with slides.Presentation("pres.pptx") as pres:
    #Accessing the presentation
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #Accessing the first slide
        image_format = draw.imaging.ImageFormat.jpeg

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Getting the back picture  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Getting the back picture  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #Setting the desired picture format 
            image_type = back_image.content_type.split("/")[1]
            image_format = get_image_format(image_type)

            back_image.system_image.save(
                file_name.format("LayoutSlide_" if is_layout else "", slideIndex, image_type), 
                image_format)

        for i in range(len(slide.shapes)):
            shape = slide.shapes[i]
            shape_image = None

            if type(shape) is slides.AutoShape and shape.fill_format.fill_type == slides.FillType.PICTURE:
                shape_image = shape.fill_format.picture_fill_format.picture.image
            elif type(shape) is slides.PictureFrame:
                shape_image = shape.picture_format.picture.image

            if shape_image is not None:
                image_type = shape_image.content_type.split("/")[1]
                image_format = get_image_format(image_type)

                shape_image.system_image.save(
                                file_name.format("shape_"+str(i)+"_", slideIndex, image_type), 
                                image_format)
```



