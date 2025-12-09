---
title: Ajouter des cadres d'image aux présentations avec Python
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/python-net/picture-frame/
keywords:
- cadre d'image
- ajouter un cadre d'image
- créer un cadre d'image
- ajouter une image
- créer une image
- extraire une image
- image raster
- image vectorielle
- recadrer une image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- mise à l'échelle relative
- effet d'image
- rapport d'aspect
- transparence de l'image
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Simplifiez votre flux de travail et améliorez la conception des diapositives."
---

## **Vue d'ensemble**

Les cadres d’image dans Aspose.Slides pour Python vous permettent de placer et de gérer des images raster et vectorielles comme des formes natives de diapositives. Vous pouvez insérer des images à partir de fichiers ou de flux, les positionner et les redimensionner avec des coordonnées précises, appliquer une rotation, définir la transparence et contrôler l’ordre Z aux côtés d’autres formes. L’API prend également en charge le recadrage, le maintien des rapports d’aspect, la définition des bordures et des effets, ainsi que le remplacement de l’image sous‑jacent sans reconstruire la mise en page. Comme les cadres d’image se comportent comme des formes ordinaires, vous pouvez ajouter des animations, des hyperliens et du texte alternatif, ce qui simplifie la création de présentations visuellement riches et accessibles.

## **Créer des cadres d’image**

Cette section montre comment insérer une image dans une diapositive en créant un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) avec Aspose.Slides pour Python. Vous apprendrez à charger l’image, la placer précisément sur la diapositive et à contrôler sa taille et son formatage.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une diapositive par son indice.
3. Créez un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) en ajoutant l’image à la [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) de la présentation. Cette image sera utilisée pour remplir la forme.
4. Spécifiez la largeur et la hauteur du cadre.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) de cette taille en utilisant la méthode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Enregistrez la présentation au format PPTX.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour représenter un fichier PPTX.
with slides.Presentation() as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter l'image à la présentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Ajouter un cadre d'image aux dimensions de l'image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Enregistrer la présentation au format PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="warning" %}}
Les cadres d’image vous permettent de créer rapidement des diapositives de présentation à partir d’images. Lorsque vous combinez les cadres d’image avec les options d’enregistrement d’Aspose.Slides, vous pouvez contrôler les opérations d’E/S pour convertir les images d’un format à un autre. Vous pourriez consulter ces pages : convertir [image en JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); convertir [PNG en JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); convertir [SVG en PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Créer des cadres d’image avec mise à l’échelle relative**

Cette section montre comment placer une image à une taille fixe, puis appliquer un redimensionnement basé sur des pourcentages de manière indépendante sur sa largeur et sa hauteur. Comme les pourcentages peuvent différer, le rapport d’aspect peut changer. Le redimensionnement est effectué par rapport aux dimensions originales de l’image.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une diapositive par son indice.
3. Créez un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) en ajoutant l’image à la [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/).
4. Ajoutez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) à la diapositive.
5. Définissez la largeur et la hauteur relatives du cadre d’image.
6. Enregistrez la présentation au format PPTX.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour représenter un fichier PPTX.
with slides.Presentation() as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter l'image à la collection d'images de la présentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Ajouter un cadre d'image à la diapositive.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Définir la largeur et la hauteur de l'échelle relative.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Enregistrer la présentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```


## **Extraire les images raster des cadres d’image**

Vous pouvez extraire des images raster des objets [PictureFrame] et les enregistrer au format PNG, JPG et autres. L’exemple de code ci‑dessous montre comment extraire une image du document "sample.pptx" et l’enregistrer au format PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```


## **Extraire les images SVG des cadres d’image**

Lorsque une présentation contient des graphiques SVG placés à l’intérieur de formes [PictureFrame], Aspose.Slides pour Python via .NET vous permet de récupérer les images vectorielles originales avec pleine fidélité. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame], vérifier si le [PPImage] sous‑jacent contient du contenu SVG, puis enregistrer cette image sur le disque ou dans un flux au format SVG natif.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```


## **Obtenir la transparence de l’image**

Aspose.Slides vous permet de récupérer l’effet de transparence appliqué à une image. Ce code Python montre l’opération :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```


{{% alert color="primary" %}}
Tous les effets appliqués aux images se trouvent dans [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Mise en forme du cadre d’image**

Aspose.Slides propose de nombreuses options de mise en forme que vous pouvez appliquer à un cadre d’image. Avec ces options, vous pouvez ajuster un cadre d’image pour répondre à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une diapositive par son indice.
3. Créez un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) en ajoutant l’image à la [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) de la présentation. Cette image sera utilisée pour remplir la forme.
4. Spécifiez la largeur et la hauteur du cadre.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) de cette taille en utilisant la méthode [add_picture_frame] de la diapositive.
6. Définissez la couleur du trait du cadre d’image.
7. Définissez la largeur du trait du cadre d’image.
8. Faites pivoter le cadre d’image en fournissant une valeur positive (dans le sens des aiguilles d’une montre) ou négative (dans le sens inverse).
9. Enregistrez la présentation modifiée au format PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation pour représenter un fichier PPTX.
with slides.Presentation() as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter l'image à la collection d'images de la présentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Ajouter un cadre d'image aux dimensions de l'image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Appliquer la mise en forme au cadre d'image.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Enregistrer la présentation au format PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Tip" color="primary" %}}
Aspose a développé un [Collage Maker](https://products.aspose.app/slides/collage) gratuit. Si vous devez [fusionner des JPG/JPEG](https://products.aspose.app/slides/collage/jpg) ou des images PNG, ou [créer des grilles de photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service.
{{% /alert %}}

## **Ajouter des images comme liens**

Pour garder les fichiers de présentation petits, vous pouvez ajouter des images ou des vidéos via des liens au lieu d’incorporer les fichiers directement dans les présentations. Le code Python suivant montre comment insérer une image et une vidéo dans un espace réservé :

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Recadrer les images**

Dans cette section, vous apprendrez comment recadrer la zone visible d’une image à l’intérieur d’un cadre d’image sans modifier le fichier source. Vous apprendrez également la méthode de base pour appliquer des marges de recadrage afin de créer une composition nette et ciblée directement sur la diapositive.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter l'image à la collection d'images de la présentation.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Ajouter un cadre d'image à la diapositive.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Recadrer l'image (valeurs en pourcentage).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Enregistrer le résultat.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer les zones recadrées des images**

Si vous souhaitez supprimer les zones recadrées d’une image dans un cadre, utilisez la méthode [delete_picture_cropped_areas]. Cette méthode renvoie l’image recadrée, ou l’image originale si aucun recadrage n’est nécessaire.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Obtenir le PictureFrame de la première diapositive.
    picture_frame = slides.shape[0]

    # Obtenir le PictureFrame de la première diapositive.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Enregistrer le résultat.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}
La méthode [delete_picture_cropped_areas] ajoute l’image recadrée à la collection d’images de la présentation. Si l’image n’est utilisée que dans le [PictureFrame] traité, cela peut réduire la taille de la présentation ; sinon, le nombre d’images dans la présentation résultante peut augmenter.

Lors du recadrage, cette méthode convertit les métas fichiers WMF/EMF en image PNG raster.
{{% /alert %}}

## **Verrouiller le rapport d’aspect**

Si vous souhaitez qu’une forme contenant une image conserve son rapport d’aspect après avoir modifié les dimensions de l’image, définissez la propriété [aspect_ratio_locked] sur `True`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Verrouiller le rapport d'aspect lors du redimensionnement.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}
Ce paramètre *Verrouiller le rapport d’aspect* ne préserve que le rapport d’aspect de la forme, pas celui de l’image qu’elle contient.
{{% /alert %}}

## **Utiliser les propriétés de décalage d’étirement**

En utilisant les propriétés `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` et `stretch_offset_bottom` de la classe [PictureFillFormat], vous pouvez définir un rectangle de remplissage.

Lorsque l’étirement est spécifié pour une image, le rectangle source est mis à l’échelle pour remplir le rectangle de remplissage. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait, tandis qu’un pourcentage négatif indique une extension.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par son indice.
3. Ajoutez une [AutoShape] rectangulaire.
4. Définissez le type de remplissage de la forme.
5. Définissez le mode de remplissage d’image de la forme.
6. Chargez une image.
7. Attribuez l’image pour remplir la forme.
8. Spécifiez les décalages de l’image par rapport aux bords correspondants de la boîte englobante de la forme.
9. Enregistrez la présentation au format PPTX.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation() as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une AutoShape rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Définir le type de remplissage de la forme.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Définir le mode de remplissage de l'image de la forme.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Charger l'image et l'ajouter à la présentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assigner l'image pour remplir la forme.
    shape.fill_format.picture_fill_format.picture.image = image

    # Spécifier les décalages de l'image par rapport aux bords correspondants de la boîte englobante de la forme.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert  title="Tip" color="primary" %}}
Aspose propose des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui vous permettent de créer rapidement des présentations à partir d’images.
{{% /alert %}}

## **FAQ**

**Comment puis‑je savoir quels formats d’image sont pris en charge pour PictureFrame ?**

Aspose.Slides prend en charge les images raster (PNG, JPEG, BMP, GIF, etc.) et les images vectorielles (par exemple, SVG) via l’objet image attribué à un [PictureFrame]. La liste des formats pris en charge chevauche généralement les capacités du moteur de présentation et de conversion d’images.

**Comment l’ajout de dizaines d’images volumineuses affecte‑t‑il la taille et les performances du PPTX ?**

L’incorporation d’images volumineuses augmente la taille du fichier et l’utilisation de la mémoire ; le lien vers des images permet de réduire la taille de la présentation mais nécessite que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d’ajouter des images par lien pour réduire la taille du fichier.

**Comment puis‑je verrouiller un objet image contre un déplacement/redimensionnement accidentel ?**

Utilisez les [shape locks] pour un [PictureFrame] (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est décrit pour les formes dans un [article de protection](/slides/fr/python-net/applying-protection-to-presentation/) séparé et est pris en charge pour divers types de formes, y compris [PictureFrame].

**La fidélité du vecteur SVG est‑elle préservée lors de l’exportation d’une présentation vers PDF/images ?**

Aspose.Slides permet d’extraire un SVG d’un [PictureFrame] en tant que vecteur original. Lors de l’[exportation vers PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/) ou vers des [formats raster](/slides/fr/python-net/convert-powerpoint-to-png/), le résultat peut être rasterisé selon les paramètres d’exportation ; le fait que le SVG original soit stocké en tant que vecteur est confirmé par le comportement d’extraction.