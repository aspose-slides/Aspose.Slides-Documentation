---
title: Gérer les cadres image dans les présentations avec Python
linktitle: Cadre image
type: docs
weight: 10
url: /fr/python-java/picture-frame/
keywords:
- cadre image
- ajouter un cadre image
- créer un cadre image
- image intégrée
- image liée
- extraire l'image
- image matricielle
- image SVG
- recadrer l'image
- supprimer les zones recadrées
- compresser l'image
- StretchOffset
- formatage du cadre image
- échelle relative
- effet d'image
- rapport d'aspect
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer, formater, lier, recadrer, extraire et compresser des cadres image dans les présentations avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Un cadre image est une forme de diapositive qui affiche une image. Dans Aspose.Slides, la ressource image et la forme qui l'affiche sont des objets distincts : une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) possède des ressources d'images intégrées via sa [ImageCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/), tandis qu'un [PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) contrôle la position, la taille, le format de ligne, la rotation, le recadrage, les effets d'image et d'autres paramètres au niveau du cadre.

Cette séparation est utile lorsque la même image est affichée plusieurs fois. Ajoutez l'image à la présentation une fois, conservez le [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) retourné, et utilisez cette ressource d'image lors de la création de cadres image.

Les cadres image peuvent contenir des images matricielles telles que PNG ou JPEG ainsi que des images vectorielles SVG. Ils peuvent également faire référence à des images liées au lieu de stocker les octets de l'image dans la présentation. Le choix influence la portabilité, la taille du fichier, l'extraction et le comportement d'exportation, il est donc utile de décider comment l'image doit être stockée avant d'appliquer le formatage ou l'optimisation.

## **Ajouter et formater une image intégrée**

Pour une image intégrée, ajoutez les données de l'image à la présentation et créez un cadre image avec [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addPictureFrame). L'image devient alors partie du package de la présentation, de sorte que la présentation reste autonome lorsqu'elle est déplacée sur un autre ordinateur.

L'exemple suivant ajoute une image JPEG, crée un cadre aux dimensions natives de l'image et applique un format de ligne ainsi qu'une rotation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le cadre image contrôle la géométrie affichée ; modifier la taille du cadre ne change pas les dimensions en pixels d'origine stockées dans la ressource d'image intégrée. Cette distinction devient importante lors d'un recadrage ou d'une compression de l'image ultérieurement.

## **Utiliser l'échelle relative**

[PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) expose le redimensionnement relatif en largeur et en hauteur du cadre via [setRelativeScaleWidth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) et [setRelativeScaleHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Une valeur de `1.0` correspond à 100 % de la taille d'origine de l'image. L'échelle relative est utile lorsqu'un flux de travail doit préserver une relation avec la taille source de l'image plutôt que de calculer manuellement les dimensions finales.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'échelle relative modifie les paramètres de redimensionnement du cadre ; elle ne rééchantillonne pas et ne compresse pas l'image intégrée.

## **Images intégrées et liées**

Une image intégrée stocke les données de l'image à l'intérieur de la présentation et constitue donc le choix le plus sûr pour la portabilité et un rendu prévisible. Une image liée stocke un emplacement externe via la méthode [Picture.setLinkPathLong](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/#setLinkPathLong) au lieu d'intégrer les données de l'image de la même manière.

Les images liées peuvent réduire la quantité de données d'image stockées dans le PPTX, mais elles introduisent une dépendance externe. Le fichier lié doit rester accessible à l'application qui ouvre ou rend la présentation. Si le chemin change, le fichier est déplacé ou la ressource devient indisponible, l'image liée peut ne pas s'afficher comme prévu. Pour les présentations qui doivent être envoyées par courriel, archivées ou rendues dans des environnements isolés, les images intégrées sont généralement plus fiables.

### **Ajouter une image liée**

L'exemple suivant crée un cadre image et le pointe vers un fichier image local. Il ne traite que la liaison d'image ; la liaison de vidéo constitue un flux multimédia distinct et n'est pas mélangée à cet exemple.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Utilisez les liens lorsque la gestion de fichiers externes est intentionnelle. Ne les utilisez pas simplement comme un substitut à la compression : un petit PPTX avec des dépendances d'image cassées est généralement moins utile qu'une présentation plus grande et autonome.

## **Extraire des images des cadres image**

Avant d'extraire une image d'une présentation existante, vérifiez qu'une forme est réellement un [PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) et qu'elle contient une image intégrée. Les cadres image liés peuvent ne pas contenir les octets d'image pouvant être extraits de la même façon.

### **Extraire une image matricielle**

L'API d'image moderne travaille directement avec les images matricielles et ne nécessite pas l'ancien wrapper Java d'image. L'exemple suivant trouve la première image matricielle intégrée d'une diapositive et l'enregistre au format PNG :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Enregistrer l'image matricielle convertit l'image extraite vers le format de sortie demandé. Si vous avez besoin des octets encodés stockés dans la présentation plutôt qu'un fichier matriciel converti, utilisez les données binaires de la ressource image.

### **Extraire une image SVG**

Pour une image SVG, le [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) expose un objet [SvgImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/). Cela vous permet de récupérer directement les données SVG au lieu de rasteriser d'abord l'image.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Conserver le contenu SVG en tant que SVG préserve la source vectorielle à l'intérieur de la présentation. Les exports matriciels tels que PNG ou JPEG rendent nécessairement ce contenu vectoriel en pixels. L'export de diapositive au format PDF ou SVG est également une opération de rendu, ainsi les graphiques exportés ne doivent pas être traités comme une copie octet à octet de l'SVG intégré ; utilisez les données [SvgImage.getSvgData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/#getSvgData) lorsqu'il faut la ressource vectorielle originale.

## **Recadrer une image**

Le recadrage modifie la partie de l'image visible à l'intérieur du cadre. Les valeurs de recadrage sur [PictureFillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/) sont exprimées en pourcentage des dimensions de l'image source. Le recadrage ne supprime pas initialement les pixels masqués de l'image intégrée ; il ne fait que changer la région visible.

L'exemple suivant trouve un cadre image en toute sécurité et applique des valeurs de recadrage :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Comme les données d'image cachées sont toujours présentes, le recadrage peut être modifié ultérieurement sans perdre les pixels d'origine. Si la taille du fichier est plus importante que la réversibilité, les zones recadrées peuvent être supprimées physiquement comme décrit dans la section suivante.

## **Supprimer les données d'image recadrées**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) supprime les données d'image situées en dehors du rectangle de recadrage actuel et renvoie la ressource image résultante. Cela peut réduire la taille du fichier, mais il s'agit d'une optimisation destructive : après la sauvegarde de la présentation, les pixels supprimés ne sont plus disponibles pour une opération de décadrage ultérieure.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La méthode peut ajouter une nouvelle ressource image à la présentation. Si l'image originale est également utilisée par d'autres cadres image, ces cadres conservent toujours leur ressource existante, de sorte que la suppression des zones recadrées ne réduit pas nécessairement le nombre total d'images. Recadrer du contenu WMF ou EMF avec cette méthode rasterise le résultat recadré en PNG.

## **Compresser les images matricielles**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#compressImage) réduit la résolution d'une image matricielle par rapport à la taille à laquelle l'image est affichée. Elle peut également supprimer les zones recadrées dans la même opération. La méthode renvoie `True` lorsque l'image a été redimensionnée ou recadrée et `False` lorsqu'aucun changement n'était nécessaire.

Utilisez une valeur prédéfinie de [PicturesCompression](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturescompression/) lorsqu'une résolution cible standard suffit :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Une valeur DPI positive personnalisée peut être passée à la place d'une valeur prédéfinie lorsqu'une cible spécifique est requise.

La compression est destinée aux images matricielles. Le contenu SVG et les métas fichiers ne sont pas réduits par ce flux de compression matricielle. Rappelez-vous également que la résolution inférieure et les zones recadrées supprimées ne peuvent pas être récupérées à partir de la présentation optimisée. Choisissez une résolution cible en fonction de la plus grande taille à laquelle l'image sera réellement vue ou exportée, plutôt que d'appliquer le DPI le plus bas globalement.

## **Gérer les effets de transformation d'image**

Pour un flux complet couvrant la luminosité, le contraste, les transformations de couleur, le flou, les effets alpha, les chaînes ordonnées, l'inspection, la suppression et la vérification en aller-retour, voir [Image Transform Effects](/slides/fr/python-java/image-transform-effects/).

## **Verrouiller la géométrie du cadre image**

Les paramètres du [PictureFrameLock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframelock/) contrôlent quelles opérations d'édition sont désactivées pour un cadre image. Par exemple, [setAspectRatioLocked](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) préserve les proportions de la forme lors du redimensionnement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le verrou s'applique à la forme du cadre image. Il ne force pas l'image source à être rééchantillonnée ou modifiée de façon permanente pour correspondre au même ratio d'aspect.

## **Ajuster les valeurs StretchOffset**

Lorsque le mode de remplissage d'image est étiré, les valeurs stretch‑offset sur [PictureFillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/) définissent le rectangle de remplissage relatif à la boîte englobante du cadre image. Des pourcentages positifs créent un retrait depuis un bord, tandis que des pourcentages négatifs créent un débordement.

Ceci diffère du recadrage. Les valeurs de recadrage sélectionnent quelle partie de l'image source est visible ; les offsets d'étirement modifient le rectangle dans lequel le remplissage d'image visible est étiré.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Utilisez les offsets d'étirement pour le placement du remplissage. Utilisez les propriétés de recadrage lorsque le but est de masquer les bords de l'image source.

## **Stockage, taille du fichier et considérations d'exportation**

Les principaux compromis sont plus faciles à gérer lorsque le stockage d'images et le formatage du cadre image sont traités séparément :

- **Images intégrées** rendent la présentation autonome et sont les plus fiables pour le partage et le rendu côté serveur, mais les grandes images matricielles augmentent la taille du PPTX et la consommation mémoire.
- **Images liées** peuvent garder le package plus petit, mais la présentation dépend de la disponibilité continue des fichiers externes aux chemins ou emplacements stockés.
- **Recadrage** est initialement non destructif. Les pixels masqués restent intégrés jusqu'à ce que les zones recadrées soient explicitement supprimées ou retirées lors de la compression.
- **Compression** peut réduire considérablement la taille du fichier pour les images matricielles surdimensionnées, mais elle sacrifie la résolution source. Elle doit être appliquée après que la taille finale sur la diapositive soit connue.
- **Images SVG** doivent rester au format SVG lorsque la préservation vectorielle est importante. Extrayez le SVG intégré directement lorsque vous avez besoin de la ressource vectorielle elle‑même. Les exports de diapositive en raster convertissent toujours la diapositive rendue en pixels.
- **Images répétées** doivent réutiliser une ressource [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) existante dès que possible au lieu de charger à nouveau le même fichier dans le flux de travail de la présentation.

Pour les présentations volumineuses, l'optimisation des images est généralement la plus efficace lorsqu'elle est effectuée sélectivement : conservez les logos et diagrammes en tant que contenu vectoriel, compressez les photographies selon leur taille d'affichage réelle, supprimez les pixels recadrés uniquement lorsque l'édition ultérieure n'est pas requise, et évitez les liens externes sauf si la gestion des dépendances fait partie de la conception du déploiement.

## **FAQ**

**Quelle est la différence entre un cadre image et une ressource d'image ?**

Un [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) représente une ressource d'image associée à la présentation. Un [PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) est une forme sur une diapositive qui affiche une image et stocke la géométrie et le formatage au niveau du cadre tels que la taille, la rotation, les valeurs de recadrage, les effets et les verrous.

**Dois‑je intégrer ou lier les images ?**

Intégrez les images lorsque la présentation doit être portable, archivée ou rendue sans accès aux ressources externes. Liez les images uniquement lorsque le maintien des fichiers image hors du PPTX est intentionnel et que les emplacements externes peuvent être maintenus de façon fiable.

**Le recadrage réduit‑il la taille du fichier PPTX ?**

Pas en soi. Les paramètres de recadrage normal masquent des parties de l'image source mais conservent les pixels sous‑jacents. Utilisez [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ou la compression d'image avec suppression des zones recadrées lorsque ces pixels peuvent être éliminés définitivement.

**Puis‑je restaurer la qualité de l'image après compression ?**

Non. La compression peut réduire la résolution raster stockée, et la suppression des zones recadrées élimine les données d'image. Conservez l'image source originale en dehors de la présentation si un futur montage haute résolution peut être nécessaire.

**Comment gérer les images SVG ?**

Conservez le contenu SVG en tant que SVG lorsque la fidélité vectorielle compte. Le [SvgImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgimage/) intégré peut être extrait directement. Rendre une diapositive en format raster tel que PNG ou JPEG rasterise le SVG comme partie de l'image de la diapositive.

**Comment éviter les castings dangereux lors de la lecture des diapositives existantes ?**

Vérifiez le type de forme avant d'utiliser des membres spécifiques au cadre image. Un test `isinstance` contre [PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) évite les castings invalides et permet au code de gérer les diapositives qui ne contiennent pas de cadres image.