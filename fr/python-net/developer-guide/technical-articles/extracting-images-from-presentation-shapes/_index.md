---
title: Extraire des images des formes de présentation en Python
linktitle: Image depuis une forme
type: docs
weight: 90
url: /fr/python-net/extracting-images-from-presentation-shapes/
keywords:
- extraire image
- récupérer image
- arrière-plan de diapositive
- arrière-plan de forme
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET — solution rapide et conviviale."
---

## **Extraire des images des formes**

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et sont également fréquemment utilisées comme arrière-plans de diapositives. Les objets image sont ajoutés via [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), qui est une collection d’objets [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/). 

Cet article explique comment extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d’une présentation, vous devez d’abord localiser l’image en parcourant chaque diapositive, puis chaque forme. Une fois l’image trouvée ou identifiée, vous pouvez l’extraire et l’enregistrer en tant que nouveau fichier. XXX 

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
    #Accessing the presentation
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #Accessing the first slide
        image_format = slides.ImageFormat.JPEG

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

## **FAQ**

**Puis-je extraire l’image originale sans aucun recadrage, effet ou transformation de forme ?**

Oui. Lorsque vous accédez à l’image d’une forme, vous obtenez l’objet image provenant de la [collection d'images](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) de la présentation, c’est‑à‑dire les pixels d’origine sans recadrage ni effets de style. Le flux de travail parcourt la collection d’images de la présentation et les objets [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), qui stockent les données brutes.

**Existe‑t‑il un risque de dupliquer des fichiers identiques lors de l’enregistrement de nombreuses images en même temps ?**

Oui, si vous enregistrez tout sans discernement. La [collection d'images](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) d’une présentation peut contenir des données binaires identiques référencées par différentes formes ou différentes diapositives. Pour éviter les doublons, comparez les hachages, les tailles ou le contenu des données extraites avant d’écrire.

**Comment déterminer quelles formes sont liées à une image spécifique de la collection de la présentation ?**

Aspose.Slides ne conserve pas de liens inversés des [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) vers les formes. Créez un mappage manuellement pendant le parcours : chaque fois que vous trouvez une référence à un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), enregistrez quelles formes l’utilisent.

**Puis‑je extraire les images intégrées dans des objets OLE, comme des documents joints ?**

Pas directement, car un objet OLE est un conteneur. Vous devez d’abord extraire le package OLE lui‑même, puis analyser son contenu à l’aide d’outils séparés. Les formes d’image de présentation fonctionnent via [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) ; OLE est un type d’objet différent.