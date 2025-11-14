---
title: Extraire des images à partir de formes de présentation en Python
linktitle: Image d’une forme
type: docs
weight: 90
url: /fr/python-net/extracting-images-from-presentation-shapes/
keywords:
- extraire image
- récupérer image
- arrière‑plan de diapositive
- arrière‑plan de forme
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Extrayez des images à partir de formes dans des présentations PowerPoint et OpenDocument avec Aspose.Slides for Python via .NET — une solution rapide et adaptée au code."
---

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et sont également fréquemment utilisées comme arrière-plans de diapositives. Les objets image sont ajoutés via [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), qui est une collection d'objets [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/). 

Cet article explique comment vous pouvez extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d'une présentation, vous devez d'abord localiser l'image en parcourant chaque diapositive, puis en parcourant chaque forme. Une fois l'image trouvée ou identifiée, vous pouvez l'extraire et la sauvegarder sous un nouveau fichier. XXX 

```py
import aspose.slides as slides

def get_image_format(image_type):
    return {
        "jpeg": slides.ImageFormat.JPEG,
        "emf": slides.ImageFormat.EMF,
        "bmp": slides.ImageFormat.BMP,
        "png": slides.ImageFormat.PNG,
        "wmf": slides.ImageFormat.WMF,
        "gif": slides.ImageFormat.GIF,
    }.get(image_type, slides.ImageFormat.JPEG)

with slides.Presentation("pres.pptx") as pres:
    #Accéder à la présentation
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #Accéder à la première diapositive
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Obtenir l'image de fond  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Obtenir l'image de fond  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #Définir le format d'image souhaité 
            image_type = back_image.content_type.split("/")[1]
            image_format = get_image_format(image_type)

            back_image.image.save(
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

                shape_image.image.save(
                                file_name.format("shape_"+str(i)+"_", slideIndex, image_type), 
                                image_format)
```