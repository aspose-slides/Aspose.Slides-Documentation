---
title: Ajouter des cadres photo aux présentations avec Python
linktitle: Cadre Photo
type: docs
weight: 10
url: /fr/python-net/picture-frame/
keywords:
- cadre photo
- ajouter un cadre photo
- créer un cadre photo
- ajouter une image
- créer une image
- extraire une image
- image raster
- image vectorielle
- recadrer une image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre photo
- propriétés du cadre photo
- échelle relative
- effet d'image
- rapport d'aspect
- transparence de l'image
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajouter des cadres photo aux présentations PowerPoint et OpenDocument avec Aspose.Slides for Python via .NET. Rationalisez votre flux de travail et améliorez la conception des diapositives."
---

Un cadre photo est une forme qui contient une image—c'est comme une image dans un cadre.

Vous pouvez ajouter une image à une diapositive via un cadre photo. De cette manière, vous pouvez formater l'image en formatant le cadre photo.

{{% alert  title="Astuce" color="primary" %}}

Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent aux gens de créer rapidement des présentations à partir d'images. 

{{% /alert %}}

## **Créer un Cadre Photo**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive par son index.
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) associée à l'objet de présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) basé sur la largeur et la hauteur de l'image via la méthode `AddPictureFrame` exposée par l'objet de forme associé à la diapositive référencée.
6. Ajoutez un cadre photo (contenant l'image) à la diapositive.
7. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Python vous montre comment créer un cadre photo :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciation de la classe Presentation qui représente un fichier PPTX
with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    # Instanciation de la classe ImageEx
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)

        # Ajoute un cadre avec la hauteur et la largeur équivalentes de l'image
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, image.width, image.height, image)

        # Applique quelques mises en forme à PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

        # Écrit le fichier PPTX sur le disque
        pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

Les cadres photo vous permettent de créer rapidement des diapositives de présentation basées sur des images. Lorsque vous combinez le cadre photo avec les options d'enregistrement d'Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir des images d'un format à un autre. Vous voudrez peut-être consulter ces pages : convertir [image en JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Créer un Cadre Photo avec Échelle Relative**

En modifiant l'échelle relative d'une image, vous pouvez créer un cadre photo plus complexe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez une image à la collection d'images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) associée à l'objet de présentation qui sera utilisé pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre photo.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Python vous montre comment créer un cadre photo avec une échelle relative :

```py
import aspose.slides as slides

# Instanciation de la classe Presentation qui représente un fichier PPTX
with slides.Presentation() as presentation:
    # Charge l'image qui sera ajoutée à la collection d'images de la présentation
    with open("img.jpeg", "rb") as in_file:
        image = presentation.images.add_image(in_file)

        # Ajoute un cadre photo à la diapositive
        pf = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Définit la hauteur et la largeur d'échelle relative
        pf.relative_scale_height = 0.8
        pf.relative_scale_width = 1.35

        # Enregistre la présentation
        presentation.save("Adding Picture Frame with Relative Scale_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraire une Image d'un Cadre Photo**

Vous pouvez extraire des images d'objets [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) et les enregistrer en PNG, JPG et autres formats. L'exemple de code ci-dessous démontre comment extraire une image du document "sample.pptx" et l'enregistrer au format PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Obtenir la Transparence de l'Image**

Aspose.Slides vous permet d'obtenir la transparence d'une image. Ce code Python démontre l'opération :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    pictureFrame = presentation.slides[0].shapes[0]
    imageTransform = pictureFrame.picture_format.picture.image_transform
    for effect in imageTransform:
        if type(effect) is slides.AlphaModulateFixed:
            transparencyValue = 100 - effect.amount
            print("Transparence de l'image : " + str(transparencyValue))
```

## **Mise en Forme du Cadre Photo**

Aspose.Slides propose de nombreuses options de mise en forme qui peuvent être appliquées à un cadre photo. En utilisant ces options, vous pouvez modifier un cadre photo pour qu'il corresponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) class.
2. Obtenez une référence à une diapositive par son index.
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) associée à l'objet de présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l'image via la méthode [AddPictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) exposée par l'objet [IShapes](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection) associé à la diapositive référencée.
6. Ajoutez le cadre photo (contenu l'image) à la diapositive.
7. Définissez la couleur de ligne du cadre photo.
8. Définissez la largeur de ligne du cadre photo.
9. Faites tourner le cadre photo en lui donnant une valeur positive ou négative.
   * Une valeur positive fait tourner l'image dans le sens des aiguilles d'une montre.
   * Une valeur négative fait tourner l'image dans le sens inverse des aiguilles d'une montre.
10. Ajoutez le cadre photo (contenant l'image) à la diapositive.
11. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Python démontre le processus de mise en forme du cadre photo :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciation de la classe Presentation qui représente un fichier PPTX
with slides.Presentation() as pres:
    # Obtient la première diapositive
    sld = pres.slides[0]

    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

         # Ajoute un cadre photo avec la hauteur et la largeur équivalentes de l'image
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, imgx.width, imgx.height, imgx)

        # Applique quelques mises en forme à PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

    # Écrit le fichier PPTX sur le disque
    pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Astuce" color="primary" %}}

Aspose a récemment développé un [créateur de collages gratuit](https://products.aspose.app/slides/collage). Si vous devez un jour [fusionner des images JPG/JPEG](https://products.aspose.app/slides/collage/jpg) ou PNG, [créer des grilles à partir de photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service. 

{{% /alert %}}

## **Ajouter une Image en Tant que Lien**

Pour éviter des tailles de présentation importantes, vous pouvez ajouter des images (ou des vidéos) via des liens au lieu d'incorporer directement les fichiers dans les présentations. Ce code Python vous montre comment ajouter une image et une vidéo dans un espace réservé :

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapesToRemove = []

    for autoShape in presentation.slides[0].shapes:
        if autoShape.placeholder is None:
            continue
        
        if autoShape.placeholder.type == slides.PlaceholderType.PICTURE:
            pictureFrame = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE,
                    autoShape.x, autoShape.y, autoShape.width, autoShape.height, None)

            pictureFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapesToRemove.append(autoShape)

        elif autoShape.placeholder.type == slides.PlaceholderType.MEDIA:
            videoFrame = presentation.slides[0].shapes.add_video_frame(
                autoShape.X, autoShape.Y, autoShape.width, autoShape.height, "")

            videoFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            videoFrame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapesToRemove.append(autoShape)
        
    

    for shape in shapesToRemove:
        presentation.slides[0].shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Rogner une Image**

Ce code Python vous montre comment rogner une image existante sur une diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Crée un nouvel objet image
    newImage = presentation.images.add_image(slides.Images.from_file(imagePath))

    # Ajoute un PictureFrame à une Diapositive
    picFrame = presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 100, 100, 420, 250, newImage)

    # Rogne l'image (valeurs en pourcentage)
    picFrame.picture_format.crop_left = 23.6
    picFrame.picture_format.crop_right = 21.5
    picFrame.picture_format.crop_top = 3
    picFrame.picture_format.crop_bottom = 31

    # Enregistre le résultat
    presentation.save(outPptxFile, slides.export.SaveFormat.PPTX)

```

## **Supprimer les Zones Rognées de l'Image**

Si vous souhaitez supprimer les zones rognées d'une image contenue dans un cadre, vous pouvez utiliser la méthode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/). Cette méthode retourne l'image rognée ou l'image d'origine si le rognage n'est pas nécessaire.

Ce code Python démontre l'opération :

```python
import aspose.slides as slides

with slides.Presentation(path + "PictureFrameCrop.pptx") as pres:
    slide = pres.slides[0]

    # Obtient le PictureFrame de la première diapositive
    picture_frame = slides.shape[0]

    # Supprime les zones rognées de l'image du PictureFrame et retourne l'image rognée
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Enregistre le résultat
    pres.save(path + "PictureFrameDeleteCroppedAreas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

La méthode delete_picture_cropped_areas ajoute l'image rognée à la collection d'images de la présentation. Si l'image est uniquement utilisée dans le [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d'images dans la présentation résultante augmentera.

Cette méthode convertit les mét fichiers WMF/EMF en image PNG raster lors de l'opération de rognage. 

{{% /alert %}}

## **Verrouiller le Rapport d'Aspect**

Si vous souhaitez qu'une forme contenant une image conserve son rapport d'aspect même après que vous ayez modifié les dimensions de l'image, vous pouvez utiliser la propriété *aspect_ratio_locked* pour définir le paramètre *Lock Aspect Ratio*.

Ce code Python vous montre comment verrouiller le rapport d'aspect d'une forme :

```python
from aspose.slides import SlideLayoutType, Presentation, ShapeType
from aspose.pydrawing import Image

with Presentation("pres.pptx") as pres:
    layout = pres.layout_slides.get_by_type(SlideLayoutType.CUSTOM)
    emptySlide = pres.slides.add_empty_slide(layout)
    image = Image.from_file("image.png")
    presImage = pres.images.add_image(image)

    pictureFrame = emptySlide.shapes.add_picture_frame(ShapeType.RECTANGLE, 50, 150, presImage.width, presImage.height, presImage)

    # Définit que la forme doit conserver le rapport d'aspect lors du redimensionnement
    pictureFrame.picture_frame_lock.aspect_ratio_locked = True
```

{{% alert title="NOTE" color="warning" %}}

Ce paramètre *Lock Aspect Ratio* préserve uniquement le rapport d'aspect de la forme et non de l'image qu'elle contient.

{{% /alert %}}

## **Utiliser la Propriété StretchOff**

En utilisant les propriétés `StretchOffsetLeft`, `StretchOffsetTop`, `StretchOffsetRight` et `StretchOffsetBottom` de l'interface [IPictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/), vous pouvez spécifier un rectangle de remplissage.

Lorsque l'étirement est spécifié pour une image, un rectangle source est mis à l'échelle pour s'adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un pourcentage d'écart par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif spécifie un retrait tandis qu'un pourcentage négatif spécifie un dépassement.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) class.
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez une `AutoShape` rectangle.
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage de l'image de la forme.
7. Ajoutez une image définie pour remplir la forme.
8. Spécifiez les décalages d'image par rapport au bord correspondant de la boîte englobante de la forme.
9. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Python démontre un processus dans lequel une propriété StretchOff est utilisée :

```py
import aspose.slides as slides

# Instanciation de la classe Presentation qui représente un fichier PPTX
with slides.Presentation() as pres:

    # Obtient la première diapositive
    slide = pres.slides[0]

    # Instanciation de la classe ImageEx
    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # Ajoute un cadre photo avec la hauteur et la largeur équivalentes de l'image
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

        # Définit le type de remplissage de la forme
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # Définit le mode de remplissage de l'image de la forme
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # Définit l'image pour remplir la forme
        shape.fill_format.picture_fill_format.picture.image = imgx

        # Spécifie les décalages d'image par rapport au bord correspondant de la boîte englobante de la forme
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10
    
    # Écrit le fichier PPTX sur le disque
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", slides.export.SaveFormat.PPTX)
```