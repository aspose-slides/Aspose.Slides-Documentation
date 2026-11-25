---
title: Restreindre les modifications de présentation avec des verrous de forme en Python
linktitle: Restreindre les modifications de présentation
type: docs
weight: 70
url: /fr/python-net/applying-protection-to-presentation/
keywords:
- empêcher les modifications
- protéger contre la modification
- verrouiller la forme
- verrouiller la position
- verrouiller la sélection
- verrouiller le redimensionnement
- verrouiller le groupement
- PowerPoint
- PPTX
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment verrouiller et déverrouiller des formes dans les présentations PPTX avec Aspose.Slides for Python via .NET afin de restreindre la sélection, le déplacement, le redimensionnement et le groupement."
---
## **Contexte**

Une utilisation courante d’Aspose.Slides for Python via .NET consiste à créer, mettre à jour et enregistrer des présentations PowerPoint (PPTX) dans le cadre d’un flux de travail automatisé. Lorsque les utilisateurs reçoivent ces présentations, restreindre les modifications des formes peut aider à préserver la mise en page et le contenu prévus.

Cet article explique comment les formes sont organisées sur les diapositives et comment appliquer et supprimer les verrous de forme dans une présentation PPTX. Ces verrous vous permettent de restreindre des opérations de modification spécifiques sur des formes individuelles.

## **Composition d'une diapositive**

Une diapositive de présentation se compose d’éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d’images, des cadres vidéo, des connecteurs et d’autres éléments utilisés pour construire une présentation. Dans Aspose.Slides for Python via .NET, chaque élément d’une diapositive est représenté par un objet qui hérite de la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Différents types de forme exposent différentes options de verrouillage. La classe [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) est la classe de base pour les verrous de forme. Aspose.Slides for Python via .NET fournit les classes de verrouillage suivantes :

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) verrouille les formes automatiques.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) verrouille les formes de connecteur.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) verrouille les objets graphiques.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) verrouille les groupes de formes.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) verrouille les cadres d’images.  

Pour appliquer des verrous à l’ensemble d’une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), parcourez ses diapositives et définissez les verrous appropriés sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les éditeurs de présentation compatibles utilisent les verrous de forme pour restreindre des opérations de modification individuelles. Le chiffrement de fichier et la protection en écriture au niveau du document sont des [paramètres de protection de présentation](/slides/fr/python-net/password-protected-presentation/).

### **Appliquer une protection aux formes PPTX**

Aspose.Slides for Python via .NET fournit la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pour travailler avec les formes sur une diapositive.

L’exemple définit [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) et [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) sur `True` pour les formes automatiques, avec les verrous équivalents pour les groupes de formes, les connecteurs et les cadres d’images. Les connecteurs utilisent [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) pour le déplacement ; les groupes utilisent également [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) pour restreindre le groupement.

L’exemple charge une présentation PPTX existante, examine les formes dans la collection de formes de chaque diapositive et enregistre une copie avec ces restrictions appliquées. Les formes hors des quatre types traités restent inchangées. La boucle ne parcourt pas les formes enfants à l’intérieur d’un groupe.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Supprimer la protection**

Pour supprimer un verrou de forme, définissez sa valeur sur `False`. L’exemple suivant charge une présentation avec des verrous de forme et supprime les restrictions de sélection, de déplacement et de redimensionnement via [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) et [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Il supprime également [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) et enregistre une copie de la présentation. Les autres paramètres de verrouillage restent inchangés.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Conserver le recadrage d'une image**

Placez une photo nommée `photo.jpg` dans le répertoire de travail. L’exemple recadre de 12 % à gauche et de 8 % à droite, puis définit [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) sur le cadre d’image. Ce drapeau restreint tout recadrage ultérieur et préserve le recadrage existant.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` stocke le verrou de recadrage comme `True`. Dans PowerPoint, la commande **Crop** est désactivée lorsque la photo est sélectionnée.

### **Conserver un diagramme groupé**

L’exemple groupe un rectangle et une flèche, puis définit [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) sur le groupe lui‑même pour maintenir les composants du diagramme ensemble. D’autres modifications, comme le déplacement du groupe ou le changement du remplissage d’un composant, restent disponibles.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` stocke le verrou de désagrégation comme `True`. Dans PowerPoint, la commande **Ungroup** est désactivée lorsque le diagramme complet est sélectionné.

### **Rapporter les verrous de forme existants**

Pour examiner un modèle, ouvrez‑le et lisez l’objet de verrouillage de chaque forme. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) est `True` lorsque tous les indicateurs de cet objet sont désactivés et `False` lorsqu’au moins un est activé. Un groupe et ses enfants disposent d’objets de verrouillage séparés, il faut donc inspecter les enfants même si le groupe n’a aucun verrou.

Cet exemple vérifie le déplacement pour les formes automatiques, les cadres d’images et les groupes, le recadrage pour les images et la désagrégation pour les groupes. Il signale les indicateurs qu’il reconnaît et marque les types de forme qu’il n’inspecte pas.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Supposons que la diapositive 1 de `Sample.pptx` contienne un groupe nommé `Layout` avec la désagrégation verrouillée, une image nommée `Photo` à l’intérieur avec le recadrage verrouillé, et un rectangle non verrouillé nommé `Free`. Le rapport ignore `Free` et affiche ces deux lignes :

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Le rapport lit les indicateurs de modification stockés au niveau de la forme sans les modifier ni enregistrer la présentation. La protection en écriture au niveau du document est un paramètre distinct, et l’application de chaque indicateur dépend de l’éditeur.

### **Conclusion**

Aspose.Slides for Python via .NET vous permet de restreindre des opérations de modification spécifiques sur des formes individuelles ou d’appliquer les mêmes restrictions sur l’ensemble des diapositives. Choisissez les verrous pris en charge par chaque type de forme et définissez leurs valeurs sur `False` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Puis‑je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous de forme restreignent des opérations de modification spécifiques, tandis que la [protection par mot de passe](/slides/fr/python-net/password-protected-presentation/) peut restreindre l’ouverture ou la modification de la présentation. Vous pouvez utiliser les deux dans le même fichier.

**Puis‑je restreindre la modification sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez les verrous uniquement aux formes des diapositives sélectionnées. Cela ne modifie pas les paramètres de verrouillage des autres diapositives.

**Comment puis‑je appliquer des verrous aux formes individuelles à l’intérieur d’un groupe ?**

Parcourez la collection de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez l’opération pour les groupes imbriqués, en suivant le parcours de l’exemple de rapport.