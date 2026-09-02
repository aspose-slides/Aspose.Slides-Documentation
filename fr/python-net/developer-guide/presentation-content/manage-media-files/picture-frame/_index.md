---
title: "Gérer les cadres d’image dans les présentations avec Python"
linktitle: "Cadre d’image"
type: docs
weight: 10
url: /fr/python-net/picture-frame/
keywords:
- "cadre d'image"
- "ajouter cadre d'image"
- "créer cadre d'image"
- "image intégrée"
- "image liée"
- "extraire image"
- "image raster"
- "image SVG"
- "recadrer image"
- "supprimer zones recadrées"
- "compresser image"
- StretchOffset
- "formatage du cadre d'image"
- "échelle relative"
- "effet d'image"
- "ratio d'aspect"
- PowerPoint
- OpenDocument
- "présentation"
- Python
- Aspose.Slides
description: "Créer, formater, lier, recadrer, extraire et compresser des cadres d’image dans les présentations avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Un cadre d’image est une forme de diapositive qui affiche une image. Dans Aspose.Slides, la ressource image et la forme qui l’affiche sont des objets séparés : une [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) possède des ressources d’image intégrées via sa [ImageCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/), tandis qu’un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) contrôle la position, la taille, le format de ligne, la rotation, le recadrage, les effets d’image et d’autres paramètres au niveau du cadre.

Cette séparation est utile lorsque la même image est affichée plusieurs fois. Ajoutez l’image à la présentation une fois, conservez le [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) retourné, et utilisez cette ressource d’image lors de la création de cadres d’image.

Les cadres d’image peuvent contenir des images raster telles que PNG ou JPEG ainsi que des images vectorielles SVG. Ils peuvent également référencer des images liées au lieu de stocker les octets de l’image dans la présentation. Ce choix influence la portabilité, la taille du fichier, l’extraction et le comportement d’exportation, il est donc utile de décider comment l’image doit être stockée avant d’appliquer le formatage ou l’optimisation.

## **Ajouter et formater une image intégrée**

Pour une image intégrée, ajoutez les données de l’image à la présentation et créez un cadre d’image avec [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_picture_frame/). L’image devient partie du package de la présentation, de sorte que la présentation reste autonome lorsqu’elle est déplacée vers un autre ordinateur.

L’exemple suivant ajoute une image JPEG, crée un cadre aux dimensions natives de l’image et applique un format de ligne ainsi qu’une rotation :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Le cadre d’image contrôle la géométrie affichée ; changer la taille du cadre ne modifie pas les dimensions en pixels d’origine stockées dans la ressource d’image intégrée. Cette distinction devient importante lors du recadrage ou de la compression d’une image ultérieurement.

## **Utiliser l’échelle relative**

[PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) expose [relative_scale_width](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/relative_scale_width/) et [relative_scale_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/relative_scale_height/) pour le cadre. Une valeur de `1.0` correspond à 100 % de la taille originale de l’image. L’échelle relative est utile lorsqu’un workflow doit préserver un rapport avec la taille de l’image source au lieu de calculer manuellement les dimensions finales.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

L’échelle relative modifie les paramètres d’échelle du cadre ; elle ne rééchantillonne ni ne compresse pas l’image intégrée.

## **Images intégrées et liées**

Une image intégrée stocke les données de l’image à l’intérieur de la présentation et constitue donc le choix le plus sûr pour la portabilité et un rendu prévisible. Une image liée stocke un emplacement externe via le chemin de lien [Picture](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picture/) au lieu d’intégrer les données de l’image de la même façon.

Les images liées peuvent réduire la quantité de données d’image stockées dans le PPTX, mais elles introduisent une dépendance externe. Le fichier lié doit rester accessible à l’application qui ouvre ou rend la présentation. Si le chemin change, que le fichier est déplacé ou que la ressource devient indisponible, l’image liée peut ne pas s’afficher comme prévu. Pour les présentations qui doivent être envoyées par e‑mail, archivées ou rendues dans des environnements isolés, les images intégrées sont généralement plus fiables.

### **Ajouter une image liée**

L’exemple suivant crée un cadre d’image et le pointe vers un fichier image local. Il ne traite que le lien d’image ; le lien vidéo est un workflow média séparé et n’est pas mélangé à cet exemple.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Utilisez les liens lorsque la gestion de fichiers externes est intentionnelle. Ne les utilisez pas simplement comme un remplacement de la compression : un petit PPTX avec des dépendances d’image cassées est généralement moins utile qu’une présentation plus grande et autonome.

## **Extraire des images des cadres d’image**

Avant d’extraire une image d’une présentation existante, vérifiez qu’une forme est réellement un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) et qu’elle contient une image intégrée. Les cadres d’image liés peuvent ne pas contenir les octets d’image qui peuvent être extraits de la même manière.

### **Extraire une image raster**

L’API d’image moderne utilise [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/) directement. L’exemple suivant trouve la première image raster intégrée sur une diapositive et l’enregistre au format PNG :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

L’enregistrement via [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/) convertit l’image extraite au format de sortie demandé. Si vous avez besoin des octets encodés stockés dans la présentation plutôt qu’un fichier raster converti, utilisez la propriété [PPImage.binary_data](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/binary_data/) à la place.

### **Extraire une image SVG**

Pour une image SVG, le [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) expose un objet [SvgImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/svgimage/). Cela vous permet de récupérer les données SVG directement au lieu de rasteriser d’abord l’image.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Conserver le contenu SVG en tant que SVG préserve la source vectorielle à l’intérieur de la présentation. Les exportations raster telles que PNG ou JPEG rendent nécessairement ce contenu vectoriel en pixels. L’exportation de diapositives en PDF ou SVG est également une opération de rendu, de sorte que les graphiques exportés ne doivent pas être considérés comme une copie octet à octet de l’original SVG intégré ; utilisez le [SvgImage.svg_data](https://reference.aspose.com/slides/fr/python-net/aspose.slides/svgimage/svg_data/) intégré lorsque la ressource vectorielle d’origine est requise.

## **Recadrer une image**

Le recadrage modifie la partie de l’image visible à l’intérieur du cadre. Les valeurs de recadrage sur [PictureFillFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/) sont des pourcentages des dimensions de l’image source. Le recadrage ne supprime pas initialement les pixels masqués de l’image intégrée ; il ne change que la région visible.

L’exemple suivant trouve un cadre d’image de façon sécurisée et applique des valeurs de recadrage :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Comme les données d’image masquées sont toujours présentes, le recadrage peut être modifié ultérieurement sans perdre les pixels d’origine. Si la taille du fichier est plus importante que la réversibilité, les zones recadrées peuvent être supprimées physiquement comme décrit dans la section suivante.

## **Supprimer les données d’image recadrées**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) supprime les données d’image situées en dehors du rectangle de recadrage actuel et renvoie la ressource d’image résultante. Cela peut réduire la taille du fichier, mais il s’agit d’une optimisation destructive : après l’enregistrement de la présentation, les pixels supprimés ne sont plus disponibles pour une opération de décadrage ultérieure.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

La méthode peut ajouter une nouvelle ressource d’image à la présentation. Si l’image d’origine est également utilisée par d’autres cadres d’image, ces cadres ont toujours besoin de leur ressource existante, de sorte que la suppression des zones recadrées ne diminue pas nécessairement le nombre total d’images. Le recadrage de contenu WMF ou EMF avec cette méthode rasterise le résultat recadré en PNG.

## **Compresser les images raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/compress_image/) réduit la résolution d’une image raster par rapport à la taille à laquelle l’image est affichée. Elle peut également supprimer les zones recadrées dans la même opération. La méthode renvoie `True` lorsque l’image a été redimensionnée ou recadrée et `False` lorsqu’aucun changement n’était nécessaire.

Utilisez une valeur prédéfinie de [PicturesCompression](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/picturescompression/) lorsqu’une résolution cible standard suffit :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Une valeur DPI positive personnalisée peut être passée à la place d’une valeur d’énumération lorsqu’une cible spécifique est requise.

La compression est destinée aux images raster. Le contenu SVG et les métafichiers ne sont pas réduits par ce workflow de compression raster. Rappelez‑vous également que la résolution inférieure et les zones recadrées supprimées ne peuvent pas être récupérées à partir de la présentation optimisée. Choisissez une résolution cible basée sur la plus grande taille à laquelle l’image sera réellement visualisée ou exportée plutôt que d’appliquer le DPI le plus bas de façon globale.

## **Gérer les effets de transformation d’image**

Pour un workflow complet couvrant la luminosité, le contraste, les transformations de couleurs, le flou, les effets alpha, les chaînes ordonnées, l’inspection, la suppression et la vérification en aller‑retour, voyez [Image Transform Effects](/slides/fr/python-net/image-transform-effects/).

## **Verrouiller la géométrie du cadre d’image**

Les paramètres du [PictureFrameLock](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframelock/) contrôlent quelles opérations d’édition sont désactivées pour un cadre d’image. Par exemple, la propriété [aspect_ratio_locked](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) conserve les proportions de la forme lors du redimensionnement.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Le verrou s’applique à la forme du cadre d’image. Il ne force pas l’image source à être rééchantillonnée ou modifiée de façon permanente pour correspondre au même ratio d’aspect.

## **Ajuster les valeurs StretchOffset**

Lorsque le mode de remplissage d’image est « stretch », les valeurs stretch‑offset sur [PictureFillFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/) définissent le rectangle de remplissage relatif à la boîte englobante du cadre d’image. Des pourcentages positifs créent un retrait depuis un bord, tandis que des pourcentages négatifs créent un débordement.

C’est différent du recadrage. Les valeurs de recadrage sélectionnent la partie de l’image source visible ; les offsets d’étirement modifient le rectangle dans lequel le remplissage d’image visible est étiré.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Utilisez les offsets d’étirement pour le placement du remplissage. Utilisez les propriétés de recadrage lorsque le but est de masquer les bords de l’image source.

## **Stockage, taille du fichier et considérations d’exportation**

Les principaux compromis sont plus faciles à gérer lorsque le stockage des images et le formatage des cadres d’image sont traités séparément :

- **Images intégrées** rendent la présentation autonome et sont les plus fiables pour le partage et le rendu côté serveur, mais les grandes images raster augmentent la taille du PPTX et la consommation mémoire.
- **Images liées** permettent de garder le package plus petit, mais la présentation dépend de la disponibilité continue des fichiers externes aux chemins ou emplacements stockés.
- **Recadrage** est initialement non destructif. Les pixels masqués restent intégrés jusqu’à ce que les zones recadrées soient explicitement supprimées ou retirées lors de la compression.
- **Compression** peut réduire significativement la taille du fichier pour les images raster surdimensionnées, mais elle sacrifie la résolution source. Elle doit être appliquée après que la taille finale sur la diapositive soit connue.
- **Images SVG** doivent rester au format SVG lorsque la préservation vectorielle est importante. Extrayez le SVG intégré directement lorsque la ressource vectorielle elle‑même est nécessaire. Les exportations de diapositives raster convertissent toujours la diapositive rendue en pixels.
- **Images répétées** doivent réutiliser une ressource [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) existante lorsque cela est possible au lieu de charger à nouveau le même fichier dans le workflow de la présentation.

Pour les présentations volumineuses, l’optimisation des images est généralement plus efficace lorsqu’elle est réalisée de façon sélective : conservez les logos et diagrammes en contenu vectoriel, compressez les photographies en fonction de leur taille d’affichage réelle, supprimez les pixels recadrés uniquement lorsque l’édition ultérieure n’est pas requise, et évitez les liens externes sauf si la gestion des dépendances fait partie du design de déploiement.

## **FAQ**

**Quelle est la différence entre un cadre d’image et une ressource d’image ?**

Un [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) représente une ressource d’image associée à la présentation. Un [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) est une forme sur une diapositive qui affiche une image et stocke la géométrie et le formatage au niveau du cadre tels que la taille, la rotation, les valeurs de recadrage, les effets et les verrous.

**Dois‑je intégrer ou lier les images ?**

Intégrez les images lorsque la présentation doit être portable, archivée ou rendue sans accès à des ressources externes. Liez les images uniquement lorsque le fait de garder les fichiers image hors du PPTX est intentionnel et que les emplacements externes peuvent être maintenus de façon fiable.

**Le recadrage réduit‑il la taille du fichier PPTX ?**

Pas en soi. Les réglages de recadrage standard masquent des parties de l’image source mais conservent les pixels sous‑jacents. Utilisez [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) ou la compression d’image avec suppression des zones recadrées lorsque ces pixels peuvent être éliminés définitivement.

**Puis‑je restaurer la qualité de l’image après compression ?**

Non. La compression peut réduire la résolution raster stockée, et la suppression des zones recadrées élimine les données d’image. Conservez l’image source originale à l’extérieur de la présentation si un futur éditing haute résolution est susceptible d’être requis.

**Comment gérer les images SVG ?**

Conservez le contenu SVG en SVG lorsque la fidélité vectorielle compte. Le [SvgImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/svgimage/) intégré peut être extrait directement. Rendre une diapositive dans un format raster tel que PNG ou JPEG rasterise le SVG dans le cadre de l’image de la diapositive.

**Comment éviter les casts incorrects lors de la lecture de diapositives existantes ?**

Vérifiez le type de forme avant d’utiliser les membres spécifiques aux cadres d’image. Utiliser `isinstance(shape, slides.PictureFrame)` évite les casts invalides et permet au code de gérer les diapositives qui ne contiennent pas de cadres d’image.