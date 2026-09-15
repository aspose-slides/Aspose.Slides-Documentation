---
title: Empêcher les modifications de présentation avec des verrous de forme
linktitle: Empêcher les modifications de présentation
type: docs
weight: 60
url: /fr/python-java/applying-protection-to-presentation/
keywords:
- empêcher les modifications
- protéger contre la modification
- verrouiller la forme
- verrouiller la position
- verrouiller la sélection
- verrouiller la taille
- verrouiller le regroupement
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Python via Java verrouille ou déverrouille les formes dans les fichiers PPT, PPTX et ODP, sécurisant les présentations tout en permettant des modifications contrôlées et une livraison plus rapide."
---
## **Contexte**

Une utilisation courante d'Aspose.Slides consiste à créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint (PPTX) dans le cadre d'un flux de travail automatisé. Les utilisateurs d'applications qui utilisent Aspose.Slides de cette manière ont accès aux présentations générées, il est donc fréquent de s'inquiéter de les protéger contre la modification. Il est important que les présentations générées automatiquement conservent leur mise en forme et leur contenu d'origine.

Cet article explique comment les présentations et les diapositives sont structurées et comment Aspose.Slides for Python via Java peut appliquer une protection à une présentation puis la supprimer. Il offre aux développeurs un moyen de contrôler l'utilisation des présentations générées par leurs applications.

## **Composition d’une diapositive**

Une diapositive de présentation est composée d'éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et d'autres éléments utilisés pour créer une présentation. Dans Aspose.Slides for Python via Java, chaque élément d'une diapositive est représenté par un objet qui hérite de la classe [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/).

La structure du PPTX est complexe, ainsi, contrairement au PPT où un verrou générique peut être utilisé pour tous les types de formes, différents types de formes nécessitent différents verrous. La classe [BaseShapeLock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseshapelock/) est la classe de verrouillage générique pour le PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides for Python via Java pour le PPTX :
- [AutoShapeLock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshapelock/) verrouille les formes automatiques.  
- [ConnectorLock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connectorlock/) verrouille les formes de connecteur.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/graphicalobjectlock/) verrouille les objets graphiques.  
- [GroupShapeLock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/groupshapelock/) verrouille les formes groupées.  
- [PictureFrameLock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframelock/) verrouille les cadres d'image.  

Toute action effectuée sur tous les objets forme dans un objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) est appliquée à l'ensemble de la présentation.

## **Appliquer et supprimer la protection**

Appliquer une protection garantit qu'une présentation ne peut pas être modifiée. C'est une technique utile pour protéger le contenu de la présentation.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for Python via Java fournit la classe [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) pour travailler avec les formes d'une diapositive.

Comme mentionné précédemment, chaque classe de forme possède une classe de verrouillage de forme associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (par un clic de souris ou d'autres méthodes de sélection) et qu'elles ne peuvent pas être déplacées ou redimensionnées.

L'exemple de code suivant applique la protection à tous les types de formes d'une présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instancier la classe Presentation qui représente un fichier PPTX.
presentation = Presentation("Sample.pptx")
try:
    # Parcourir toutes les diapositives de la présentation.
    for slide in presentation.getSlides():
        # Parcourir toutes les formes de la diapositive.
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

    # Enregistrer le fichier de présentation.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Supprimer la protection**

Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur `False`. L'exemple de code suivant montre comment déverrouiller les formes dans une présentation verrouillée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instancier la classe Presentation qui représente un fichier PPTX.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Parcourir toutes les diapositives de la présentation.
    for slide in presentation.getSlides():
        # Parcourir toutes les formes de la diapositive.
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

    # Enregistrer le fichier de présentation.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Conclusion**

Aspose.Slides propose plusieurs options pour protéger les formes d'une présentation. Vous pouvez verrouiller une forme individuelle ou parcourir toutes les formes d'une présentation et les verrouiller chacune afin de sécuriser efficacement le fichier complet. Vous pouvez supprimer la protection en définissant la valeur du verrou sur `False`.

## **FAQ**

**Puis-je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous limitent l'édition des objets à l'intérieur du fichier, tandis que la [protection par mot de passe](/slides/fr/python-java/password-protected-presentation/) contrôle l'accès à l'ouverture et/ou à l'enregistrement des modifications. Ces mécanismes se complètent et fonctionnent ensemble.

**Puis-je restreindre la modification sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez des verrous aux formes des diapositives sélectionnées ; les diapositives restantes resteront modifiables.

**Les verrous de forme s'appliquent-ils aux objets groupés et aux connecteurs ?**

Oui. Des types de verrous dédiés sont pris en charge pour les groupes, les connecteurs, les objets graphiques et les autres types de formes.