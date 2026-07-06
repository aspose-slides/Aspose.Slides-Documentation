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
- échelle relative
- effet d'image
- ratio d'aspect
- transparence d'image
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Simplifiez votre flux de travail et améliorez la conception des diapositives."
---
## **Introduction**

Les cadres d’image dans Aspose.Slides for Python vous permettent de placer et de gérer des images raster et vectorielles en tant que formes natives de diapositive. Vous pouvez insérer des images à partir de fichiers ou de flux, les positionner et les redimensionner avec des coordonnées précises, appliquer une rotation, définir la transparence et contrôler l’ordre Z avec les autres formes. L’API prend également en charge le recadrage, le maintien du rapport d’aspect, la définition de bordures et d’effets, ainsi que le remplacement de l’image sous‑jacent sans reconstruire la disposition. Parce que les cadres d’image se comportent comme des formes ordinaires, vous pouvez ajouter des animations, des hyperliens et du texte alternatif, ce qui facilite la création de présentations visuellement riches et accessibles.

## **Create Picture Frames**

Cette section montre comment insérer une image dans une diapositive en créant un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) avec Aspose.Slides for Python. Vous apprendrez comment charger l’image, la placer précisément sur la diapositive et contrôler sa taille et son formatage.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Récupérez une diapositive par son indice.
3. Créez un [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) en ajoutant l’image à la [ImageCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/) de la présentation. Cette image sera utilisée pour remplir la forme.
4. Précisez la largeur et la hauteur du cadre.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) de cette taille à l’aide de la méthode [add_picture_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Enregistrez la présentation au format PPTX.

Le code Python suivant montre comment créer un cadre d’image :

```py
import aspose.slides as slides

# Instancier la classe Presentation pour représenter un fichier PPTX.
with slides.Presentation() as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter l'image à la présentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Ajouter un cadre d'image dimensionné à l'image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Enregistrer la présentation au format PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}

Les cadres d’image vous permettent de créer rapidement des diapositives à partir d’images. En combinant les cadres d’image avec les options d’enregistrement d’Aspose.Slides, vous pouvez contrôler les opérations d’E/S pour convertir les images d’un format à un autre. Vous voudrez peut‑être consulter ces pages : convertir [image en JPG](https://products.aspose.com/slides/fr/python-net/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/fr/python-net/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/fr/python-net/conversion/jpg-to-png/); convertir [PNG en JPG](https://products.aspose.com/slides/fr/python-net/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/fr/python-net/conversion/png-to-svg/); convertir [SVG en PNG](https://products.aspose.com/slides/fr/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Create Picture Frames with Relative Scale**

Cette section montre comment placer une image à une taille fixe, puis appliquer un redimensionnement basé sur un pourcentage séparément à sa largeur et à sa hauteur. Comme les pourcentages peuvent différer, le rapport d’aspect peut changer. Le redimensionnement est effectué relativement aux dimensions d’origine de l’image.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Récupérez une diapositive par son indice.
3. Créez un [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) en ajoutant l’image à la [ImageCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/) de la présentation.
4. Ajoutez un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) à la diapositive.
5. Définissez la largeur et la hauteur relatives du cadre d’image.
6. Enregistrez la présentation au format PPTX.

Le code Python suivant montre comment créer un cadre d’image avec un redimensionnement relatif :

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

        # Définir la largeur et la hauteur d'échelle relative.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Enregistrer la présentation.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Extract Raster Images from Picture Frames**

Vous pouvez extraire des images raster à partir d’objets [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) et les enregistrer au format PNG, JPG et autres. L’exemple de code ci‑dessous montre comment extraire une image du document « sample.pptx » et l’enregistrer au format PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Extract SVG Images from Picture Frames**

Lorsqu’une présentation contient des graphiques SVG placés à l’intérieur de formes [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/), Aspose.Slides for Python via .NET vous permet de récupérer les images vectorielles originales avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/), vérifier si le [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) sous‑jacent contient du contenu SVG, puis enregistrer cette image sur disque ou dans un flux au format SVG natif.

Le code suivant montre comment extraire une image SVG d’un cadre d’image :

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

## **Get Image Transparency**

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
Tous les effets appliqués aux images sont disponibles dans [aspose.slides.effects](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Get Brightness and Contrast of an Image**

Aspose.Slides vous permet de récupérer les effets de luminosité et de contraste appliqués à une image. La classe [Luminance](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/luminance/) représente cet effet de transformation d’image.

Ce code Python montre comment obtenir les paramètres de luminosité et de contraste d’un cadre d’image :

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Picture Frame Formatting**

Aspose.Slides propose de nombreuses options de formatage que vous pouvez appliquer à un cadre d’image. Avec ces options, vous pouvez ajuster un cadre d’image pour répondre à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Récupérez une diapositive par son indice.
3. Créez un [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) en ajoutant l’image à la [ImageCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/) de la présentation. Cette image sera utilisée pour remplir la forme.
4. Précisez la largeur et la hauteur du cadre.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) de cette taille à l’aide de la méthode [add_picture_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_picture_frame/) de la diapositive.
6. Définissez la couleur de ligne du cadre d’image.
7. Définissez la largeur de ligne du cadre d’image.
8. Faites pivoter le cadre d’image en fournissant une valeur positive (dans le sens des aiguilles d’une montre) ou négative (dans le sens inverse).
9. Enregistrez la présentation modifiée au format PPTX.

Le code Python suivant montre le processus de formatage d’un cadre d’image :

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

        # Ajouter un cadre d'image dimensionné à l'image.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Appliquer le formatage au cadre d'image.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Enregistrer la présentation au format PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

Aspose a développé un outil gratuit [Collage Maker](https://products.aspose.app/slides/fr/collage). Si vous devez [fusionner des JPG/JPEG](https://products.aspose.app/slides/fr/collage/jpg) ou PNG, ou [créer des grilles de photos](https://products.aspose.app/slides/fr/collage/photo-grid), vous pouvez utiliser ce service.

{{% /alert %}}

## **Add Images as Links**

Pour garder la taille des fichiers de présentation petite, vous pouvez ajouter des images ou des vidéos via des liens au lieu d’incorporer les fichiers directement dans les présentations. Le code Python suivant montre comment insérer une image et une vidéo dans un espace réservé :

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

## **Crop Images**

Dans cette section, vous apprendrez à recadrer la zone visible d’une image à l’intérieur d’un cadre d’image sans modifier le fichier source. Vous apprendrez également la méthode de base pour appliquer des marges de recadrage afin de créer une composition nette et ciblée directement sur la diapositive.

Le code Python suivant montre comment recadrer une image sur une diapositive :

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

## **Delete Cropped Areas of Images**

Si vous souhaitez supprimer les zones recadrées d’une image dans un cadre, utilisez la méthode [delete_picture_cropped_areas](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Cette méthode renvoie l’image recadrée, ou l’image originale si aucun recadrage n’est nécessaire.

Le code Python suivant montre l’opération :

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

La méthode [delete_picture_cropped_areas](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) ajoute l’image recadrée à la collection d’images de la présentation. Si l’image n’est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) traité, cela peut réduire la taille de la présentation ; sinon, le nombre d’images dans la présentation résultante peut augmenter.

Lors du recadrage, cette méthode convertit les métafichiers WMF/EMF en image PNG raster.

{{% /alert %}}

## **Compress Images**

Vous pouvez compresser une image dans une présentation à l’aide de la méthode [PictureFillFormat.compress_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/compress_image/).
Cette méthode compresse une image en réduisant sa taille en fonction de la taille de la forme et de la résolution spécifiée, avec la possibilité de supprimer les zones recadrées.

Elle ajuste la taille et la résolution de l’image de façon similaire à la fonctionnalité PowerPoint **Picture Format → Compress Pictures → Resolution**.

Les exemples Python suivants montrent comment compresser une image dans une présentation en spécifiant une résolution cible et, éventuellement, en supprimant les zones recadrées :

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Compresser l'image avec une résolution cible de 150 DPI (résolution Web) et supprimer les zones recadrées.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Vérifier le résultat de la compression.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Ou en utilisant directement une valeur DPI personnalisée :

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Compresser l'image à 150 DPI (résolution web), en supprimant les zones recadrées.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

La méthode convertit l’image à une résolution inférieure en fonction de la taille de la forme et du DPI fourni. Les régions recadrées peuvent également être supprimées pour optimiser la taille du fichier.
Si l’image est un métafi­chier (WMF/EMF) ou un SVG, la compression ne sera pas appliquée. De plus, la qualité JPEG est conservée ou légèrement réduite selon la résolution, de la même façon que PowerPoint gère les JPEG haute résolution.

{{% /alert %}}

## **Lock the Aspect Ratio**

Si vous voulez qu’une forme contenant une image conserve son rapport d’aspect après avoir modifié les dimensions de l’image, définissez la propriété [aspect_ratio_locked](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) sur `True`.

Le code Python suivant montre comment verrouiller le rapport d’aspect d’une forme :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Verrouiller le ratio d'aspect lors du redimensionnement.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Ce paramètre *Lock Aspect Ratio* ne préserve que le rapport d’aspect de la forme, pas celui de l’image qu’elle contient.

{{% /alert %}}

## **Use Stretch Offset Properties**

En utilisant les propriétés `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` et `stretch_offset_bottom` de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/), vous pouvez définir un rectangle de remplissage.

Lorsque l’étirement est spécifié pour une image, le rectangle source est mis à l’échelle pour s’ajuster au rectangle de remplissage. Chaque bord du rectangle de remplissage est défini par un offset en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait, tandis qu’un pourcentage négatif indique un dépassement.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par son indice.
3. Ajoutez une forme rectangulaire [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/).
4. Définissez le type de remplissage de la forme.
5. Définissez le mode de remplissage image de la forme.
6. Chargez une image.
7. Assignez l’image comme remplissage de la forme.
8. Spécifiez les offsets d’image par rapport aux bords correspondants de la boîte englobante de la forme.
9. Enregistrez la présentation au format PPTX.

Le code Python suivant montre comment utiliser les propriétés Stretch Offset :

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

    # Définir le mode de remplissage d’image de la forme.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Charger l'image et l'ajouter à la présentation.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assigner l'image pour remplir la forme.
    shape.fill_format.picture_fill_format.picture.image = image

    # Spécifier les décalages d'image par rapport aux bords correspondants de la boîte englobante de la forme.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

Aspose fournit des convertisseurs gratuits — [JPEG to PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt) — qui vous permettent de créer rapidement des présentations à partir d’images.

{{% /alert %}}

## **FAQ**

**Comment puis‑je connaître les formats d’image pris en charge pour PictureFrame ?**

Aspose.Slides prend en charge les images raster (PNG, JPEG, BMP, GIF, etc.) ainsi que les images vectorielles (par exemple, SVG) via l’objet image assigné à un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/). La liste des formats pris en charge se recoupe généralement avec les capacités du moteur de conversion de diapositives et d’images.

**Quel impact l’ajout de dizaines d’images volumineuses aura‑t‑il sur la taille et les performances du PPTX ?**

L’incorporation d’images volumineuses augmente la taille du fichier et la consommation de mémoire ; le lien d’images permet de garder la taille de la présentation réduite mais nécessite que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d’ajouter des images par lien afin de réduire la taille du fichier.

**Comment puis‑je verrouiller un objet image pour éviter tout déplacement/redimensionnement accidentel ?**

Utilisez les [shape locks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/picture_frame_lock/) pour un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est décrit pour les formes dans un [article sur la protection](/slides/fr/python-net/applying-protection-to-presentation/) séparé et est supporté pour divers types de formes, y compris les [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/).

**La fidélité du vecteur SVG est‑elle conservée lors de l’exportation d’une présentation vers PDF/images ?**

Aspose.Slides permet d’extraire un SVG d’un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) en tant que vecteur original. Lors de l’[exportation vers PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/) ou vers des [formats raster](/slides/fr/python-net/convert-powerpoint-to-png/), le résultat peut être rasterisé en fonction des paramètres d’exportation ; le fait que le SVG original soit stocké comme vecteur est confirmé par le comportement d’extraction.