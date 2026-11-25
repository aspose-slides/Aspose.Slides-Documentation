---
title: Restreindre les modifications de présentation avec les verrous de forme en Python
linktitle: Restreindre les modifications de présentation
type: docs
weight: 60
url: /fr/python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Apprenez comment verrouiller et déverrouiller les formes dans les présentations PPTX avec Aspose.Slides for Python via Java afin de restreindre la sélection, le déplacement, le redimensionnement et le groupement."
---
## **Contexte**

Une utilisation courante d'Aspose.Slides for Python via Java consiste à créer, mettre à jour et enregistrer des présentations PowerPoint (PPTX) dans le cadre d'un flux de travail automatisé. Lorsque les utilisateurs reçoivent ces présentations, restreindre les modifications des formes peut aider à préserver la mise en page et le contenu prévus.

Cet article explique comment les formes sont organisées sur les diapositives et comment appliquer et supprimer les verrous de forme dans une présentation PPTX. Ces verrous vous permettent de restreindre des opérations d'édition spécifiques sur des formes individuelles.

## **Composition d'une diapositive**

Une diapositive de présentation est composée d'éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et d'autres éléments utilisés pour créer une présentation. In Aspose.Slides for Python via Java, chaque élément d'une diapositive est représenté par un objet qui hérite de la classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

Différents types de forme exposent différentes options de verrouillage. La classe [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) est la classe de base pour les verrous de forme. Aspose.Slides for Python via Java fournit les classes de verrouillage suivantes :

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) verrouille les formes automatiques.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) verrouille les formes de connecteur.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) verrouille les objets graphiques.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) verrouille les formes groupées.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) verrouille les cadres d'image.  

Pour appliquer des verrous sur toute une [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), parcourez ses diapositives et définissez les verrous appropriés sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les éditeurs de présentation compatibles utilisent les verrous de forme pour restreindre les opérations d'édition individuelles. Le chiffrement de fichier et la protection en écriture au niveau du document sont des [paramètres de protection de la présentation](/slides/fr/python-java/password-protected-presentation/) distincts.

### **Appliquer une protection aux formes PPTX**

Aspose.Slides for Python via Java fournit la classe [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) pour travailler avec les formes sur une diapositive.

Exemple : l'exemple appelle [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) et [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) avec `True` pour les formes automatiques, avec des verrous équivalents pour les formes groupées, les connecteurs et les cadres d'image. Les connecteurs utilisent [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) pour le déplacement ; les groupes utilisent également [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) pour restreindre le groupement.

L'exemple charge une présentation PPTX existante, examine les formes de la collection de formes de chaque diapositive, et enregistre une copie avec ces restrictions appliquées. Les formes en dehors des quatre types gérés restent inchangées. La boucle ne parcourt pas les formes enfants à l'intérieur d'un groupe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Supprimer la protection**

Pour supprimer un verrou de forme, définissez sa valeur sur `False`. L'exemple suivant charge une présentation avec des verrous de forme et supprime les restrictions de sélection, de déplacement et de redimensionnement via [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), et [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Il supprime également la restriction de groupement en passant `False` à [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), puis enregistre une copie de la présentation. Les autres paramètres de verrouillage restent inchangés.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Conserver le recadrage d'une image**

Placez une photo nommée `photo.jpg` dans le répertoire de travail. L'exemple recadre de 12 % à gauche et de 8 % à droite, puis appelle [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) avec `True` pour conserver le recadrage.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dans `PictureLocked.pptx`, PowerPoint désactive la commande **Crop** lorsque vous sélectionnez la photo.

### **Garder un diagramme groupé**

L'exemple regroupe un rectangle et une flèche, puis appelle [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) avec `True` pour garder les deux formes ensemble. Vous pouvez toujours déplacer le groupe ou modifier le remplissage d'un composant.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dans `DiagramLocked.pptx`, PowerPoint désactive la commande **Ungroup** lorsque vous sélectionnez l'ensemble du diagramme.

### **Rapporter les verrous de forme existants**

Pour examiner un modèle, ouvrez‑le et lisez l'objet de verrouillage pour chaque forme. La méthode [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) renvoie `True` lorsque tous les indicateurs de cet objet sont désactivés et `False` lorsqu'au moins un est activé. Un groupe et ses enfants possèdent des objets de verrouillage séparés, il faut donc inspecter les enfants même si le groupe n'a aucun verrou.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Cet exemple vérifie le déplacement des formes automatiques, des cadres d'image et des groupes. Il vérifie également le recadrage des images et le déclassement pour les groupes. Le rapport énumère les indicateurs activés qu'il reconnaît et marque les types de forme qu'il n'inspecte pas.

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Supposons que la diapositive 1 de `Sample.pptx` contienne un groupe nommé `Layout` avec le dégroupage verrouillé, une image nommée `Photo` à l'intérieur avec le recadrage verrouillé, et un rectangle déverrouillé nommé `Free`. Le rapport ignore `Free` et affiche ces deux lignes :

Le rapport lit les indicateurs d'édition au niveau de la forme sans les modifier ni enregistrer la présentation. La protection en écriture au niveau du document est un paramètre distinct, et l'application de chaque indicateur dépend de l'éditeur.

## **Conclusion**

Aspose.Slides for Python via Java vous permet de restreindre des opérations d'édition spécifiques sur des formes individuelles ou d'appliquer les mêmes restrictions sur plusieurs diapositives. Choisissez les verrous pris en charge par chaque type de forme, et définissez leurs valeurs sur `False` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Puis-je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous de forme restreignent des opérations d'édition spécifiques, tandis que la [protection par mot de passe](/slides/fr/python-java/password-protected-presentation/) peut limiter l'ouverture ou la modification de la présentation. Vous pouvez utiliser les deux dans le même fichier.

**Puis-je restreindre l'édition sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez les verrous uniquement aux formes des diapositives sélectionnées. Cela ne modifie pas les paramètres de verrouillage des autres diapositives.

**Comment puis‑je appliquer des verrous aux formes individuelles à l'intérieur d'un groupe ?**

Parcourez la collection renvoyée par la méthode [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez cela pour tous les groupes imbriqués, en suivant le parcours de l'exemple de rapport.