---
title: Ajouter des cadres d'image aux présentations avec Python
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/python-net/picture-frame/
keywords:
- cadre d'image
- ajouter cadre d'image
- créer cadre d'image
- ajouter image
- créer image
- extraire image
- image raster
- image vectorielle
- recadrer image
- zone recadrée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- mise à l'échelle relative
- effet d'image
- rapport d'aspect
- transparence d'image
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Rationalisez votre flux de travail et améliorez la conception des diapositives."
---

## **Vue d’ensemble**

Les cadres d'image dans Aspose.Slides pour Python vous permettent de placer et de gérer des images raster et vectorielles comme des formes natives de diapositive. Vous pouvez insérer des images depuis des fichiers ou des flux, les positionner et les redimensionner avec des coordonnées précises, appliquer une rotation, définir la transparence et contrôler l'ordre Z avec d'autres formes. L'API prend également en charge le recadrage, le maintien des rapports d'aspect, la définition de bordures et d'effets, ainsi que le remplacement de l'image sous-jacente sans reconstruire la mise en page. Comme les cadres d'image se comportent comme des formes classiques, vous pouvez ajouter des animations, des hyperliens et du texte alternatif, ce qui simplifie la création de présentations visuellement riches et accessibles.

## **Créer des cadres d'image**

Cette section montre comment insérer une image dans une diapositive en créant un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) avec Aspose.Slides pour Python. Vous apprendrez à charger l'image, la placer précisément sur la diapositive et contrôler sa taille et sa mise en forme.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Récupérez une diapositive par son indice.
3. Créez un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) en ajoutant l'image à la [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) de la présentation. Cette image sera utilisée pour remplir la forme.
4. Précisez la largeur et la hauteur du cadre.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) de cette taille à l’aide de la méthode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Enregistrez la présentation au format PPTX.

Le code Python suivant montre comment créer un cadre d'image :

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Save the presentation as PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

Les cadres d'image vous permettent de créer rapidement des diapositives à partir d'images. En combinant les cadres d'image avec les options d’enregistrement d’Aspose.Slides, vous pouvez contrôler les opérations d’E/S pour convertir les images d’un format à un autre. Vous pourriez être intéressé par ces pages : convertir [image en JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/) ; convertir [PNG en JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/) ; convertir [SVG en PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Créer des cadres d'image avec mise à l’échelle relative**

Cette section montre comment placer une image à une taille fixe, puis appliquer une mise à l’échelle en pourcentage indépendamment à sa largeur et à sa hauteur. Comme les pourcentages peuvent différer, le rapport d’aspect peut changer. La mise à l’échelle se fait par rapport aux dimensions d’origine de l’image.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Récupérez une diapositive par son indice.
3. Créez un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) en ajoutant l'image à la [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) de la présentation.
4. Ajoutez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) à la diapositive.
5. Définissez la largeur et la hauteur relatives du cadre d'image.
6. Enregistrez la présentation au format PPTX.

Le code Python suivant montre comment créer un cadre d'image avec mise à l’échelle relative :

```py
import aspose.slides as slides

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame to the slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Set the relative scale width and height.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Save the presentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraire des images raster à partir de cadres d'image**

Vous pouvez extraire des images raster depuis des objets [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) et les enregistrer au format PNG, JPG, etc. L’exemple ci‑dessous montre comment extraire une image du document « sample.pptx » et l’enregistrer au format PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Extraire des images SVG à partir de cadres d'image**

Lorsqu’une présentation contient des graphiques SVG insérés dans des formes [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), Aspose.Slides pour Python via .NET vous permet de récupérer les images vectorielles d’origine avec une fidélité totale. En parcourant la collection de formes d’une diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), vérifier si l’objet [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) sous‑jacent contient du SVG, puis enregistrer cette image sur disque ou dans un flux au format SVG natif.

Le code suivant montre comment extraire une image SVG d’un cadre d’image :

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

## **Obtenir la transparence d’une image**

Aspose.Slides vous permet de récupérer l’effet de transparence appliqué à une image. Ce code Python montre l’opération :

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
Tous les effets appliqués aux images sont disponibles dans [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Mise en forme du cadre d'image**

Aspose.Slides offre de nombreuses options de mise en forme que vous pouvez appliquer à un cadre d'image. Avec ces options, vous pouvez ajuster un cadre d'image afin de répondre à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Récupérez une diapositive par son indice.
3. Créez un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) en ajoutant l'image à la [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) de la présentation. Cette image sera utilisée pour remplir la forme.
4. Précisez la largeur et la hauteur du cadre.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) de cette taille à l’aide de la méthode [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) de la diapositive.
6. Définissez la couleur de bordure du cadre d'image.
7. Définissez la largeur du bord du cadre d'image.
8. Faites pivoter le cadre d'image en fournissant une valeur positive (sens horaire) ou négative (sens antihoraire).
9. Enregistrez la présentation modifiée au format PPTX.

Le code Python suivant illustre le processus de mise en forme :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to represent a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Add a picture frame sized to the image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Apply formatting to the picture frame.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Save the presentation as PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Astuce" color="primary" %}}

Aspose a créé un **Collage Maker** gratuit (https://products.aspose.app/slides/collage). Si vous devez [fusionner des JPG/JPEG](https://products.aspose.app/slides/collage/jpg) ou des PNG, ou [créer des grilles de photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service.

{{% /alert %}}

## **Ajouter des images sous forme de liens**

Pour garder les fichiers de présentation légers, vous pouvez ajouter des images ou des vidéos via des liens plutôt que d’incorporer les fichiers directement dans la présentation. Le code Python suivant montre comment insérer une image et une vidéo dans un espace réservé :

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

## **Recadrer des images**

Dans cette section, vous apprendrez à recadrer la zone visible d’une image à l’intérieur d’un cadre d’image sans modifier le fichier source. Vous découvrirez également la méthode de base pour appliquer des marges de recadrage afin de créer une composition nette et ciblée directement sur la diapositive.

Le code Python suivant montre comment recadrer une image sur une diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add the image to the presentation's image collection.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Add a picture frame to the slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Crop the image (percentage values).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Save the result.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer les zones recadrées des images**

Si vous souhaitez supprimer les zones recadrées d’une image dans un cadre, utilisez la méthode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Cette méthode renvoie l’image recadrée, ou l’image originale si aucun recadrage n’est nécessaire.

Le code Python suivant montre l’opération :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get the PictureFrame from the first slide.
    picture_frame = slides.shape[0]

    # Get the PictureFrame from the first slide.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Save the result.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

La méthode [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) ajoute l’image recadrée à la collection d’images de la présentation. Si l’image n’est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) traité, cela peut réduire la taille de la présentation ; sinon, le nombre d’images dans la présentation résultante peut augmenter.

Lors du recadrage, cette méthode convertit les métafichiers WMF/EMF en une image PNG raster.

{{% /alert %}}

## **Verrouiller le rapport d’aspect**

Si vous voulez qu’une forme contenant une image conserve son rapport d’aspect après modification des dimensions de l’image, définissez la propriété [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) sur `True`.

Le code Python suivant montre comment verrouiller le rapport d’aspect d’une forme :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Lock the aspect ratio when resizing.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Ce paramètre *Verrouiller le rapport d’aspect* ne préserve que le rapport d’aspect de la forme, pas celui de l’image qu’elle contient.

{{% /alert %}}

## **Utiliser les propriétés d’offset d’étirement**

En utilisant les propriétés `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` et `stretch_offset_bottom` de la classe [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/), vous pouvez définir un rectangle de remplissage.

Lorsque l’étirement est spécifié pour une image, le rectangle source est mis à l’échelle pour s’ajuster au rectangle de remplissage. Chaque bord du rectangle de remplissage est défini par un pourcentage d’offset par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait, un pourcentage négatif indique un débordement.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par son indice.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) rectangulaire.
4. Définissez le type de remplissage de la forme.
5. Définissez le mode de remplissage d’image de la forme.
6. Chargez une image.
7. Assignez l’image pour remplir la forme.
8. Précisez les offsets d’image par rapport aux bords correspondants de la boîte englobante de la forme.
9. Enregistrez la présentation au format PPTX.

Le code Python suivant montre comment utiliser les propriétés d’offset d’étirement :

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a rectangle AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Set the shape's fill type.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Set the shape's picture fill mode.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image and add it to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assign the image to fill the shape.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specify image offsets from the corresponding edges of the shape's bounding box.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Save the PPTX file to disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Astuce" color="primary" %}}

Aspose propose des convertisseurs gratuits — [JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — qui vous permettent de créer rapidement des présentations à partir d’images.

{{% /alert %}}

## **FAQ**

**Comment savoir quels formats d’image sont pris en charge par PictureFrame ?**

Aspose.Slides prend en charge les images raster (PNG, JPEG, BMP, GIF, etc.) et les images vectorielles (par exemple SVG) via l’objet image assigné à un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). La liste des formats supportés chevauche généralement les capacités du moteur de conversion de diapositives et d’images.

**Quel impact l’ajout de dizaines d’images volumineuses aura-t-il sur la taille et les performances du PPTX ?**

Intégrer des images de grande taille augmente la taille du fichier et la consommation mémoire ; créer des liens vers les images réduit la taille de la présentation mais nécessite que les fichiers externes restent accessibles. Aspose.Slides permet d’ajouter des images par lien afin de diminuer la taille du fichier.

**Comment verrouiller un objet image contre tout déplacement/redimensionnement accidentel ?**

Utilisez les [verrouillages de forme](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) pour un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est décrit dans un article séparé sur la [protection des présentations](/slides/fr/python-net/applying-protection-to-presentation/) et est pris en charge pour divers types de formes, y compris les [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**La fidélité vectorielle du SVG est‑elle préservée lors de l’exportation d’une présentation vers PDF ou images ?**

Aspose.Slides permet d’extraire un SVG d’un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) en tant que vecteur d’origine. Lors de l’[exportation vers PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/) ou les [formats raster](/slides/fr/python-net/convert-powerpoint-to-png/), le résultat peut être rasterisé selon les paramètres d’exportation ; le fait que le SVG d’origine soit stocké comme vecteur est confirmé par le comportement d’extraction.