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
- verrouiller le regroupement
- PowerPoint
- PPTX
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment verrouiller et déverrouiller des formes dans les présentations PPTX avec Aspose.Slides for Python via .NET afin de restreindre la sélection, le déplacement, le redimensionnement et le regroupement."
---
## **Contexte**

Une utilisation courante d'Aspose.Slides for Python via .NET consiste à créer, mettre à jour et enregistrer des présentations PowerPoint (PPTX) dans le cadre d'un flux de travail automatisé. Lorsque les utilisateurs reçoivent ces présentations, restreindre les modifications des formes peut aider à préserver la mise en page et le contenu prévus.

Cet article explique comment les formes sont organisées sur les diapositives et comment appliquer et supprimer les verrous de forme dans une présentation PPTX. Ces verrous vous permettent de restreindre des opérations de modification spécifiques sur des formes individuelles.

## **Composition d'une diapositive**

Une diapositive de présentation est composée de composants tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d’image, des cadres vidéo, des connecteurs et d’autres éléments utilisés pour créer une présentation. Dans Aspose.Slides for Python via .NET, chaque élément d’une diapositive est représenté par un objet qui hérite de la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Différents types de formes offrent différentes options de verrouillage. La classe [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) est la classe de base pour les verrous de forme. Aspose.Slides for Python via .NET fournit les classes de verrouillage suivantes :

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) verrouille les formes automatiques.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) verrouille les formes connecteur.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) verrouille les objets graphiques.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) verrouille les formes groupées.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) verrouille les cadres d’image.  

Pour appliquer des verrous à l’ensemble d’une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), parcourez ses diapositives et définissez les verrous appropriés sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les verrous de forme restreignent des opérations telles que la sélection, le déplacement et le redimensionnement des formes. Ils ne rendent pas l’ensemble de la présentation non modifiable.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for Python via .NET fournit la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pour travailler avec les formes sur une diapositive.

L’exemple définit [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) et [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) à `True` pour les formes automatiques, avec des verrous équivalents pour les formes groupées, les connecteurs et les cadres d’image. Les connecteurs utilisent [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) pour le déplacement ; les groupes utilisent également [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) pour restreindre le regroupement.

L’exemple charge une présentation PPTX existante, vérifie les formes dans la collection de formes de chaque diapositive et enregistre une copie avec ces restrictions appliquées. Les formes qui ne font pas partie des quatre types traités restent inchangées. La boucle ne parcourt pas les formes enfants à l’intérieur d’un groupe.

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

### **Conclusion**

Aspose.Slides for Python via .NET vous permet de restreindre des opérations de modification spécifiques sur des formes individuelles ou d’appliquer les mêmes restrictions sur l’ensemble des diapositives. Choisissez les verrous pris en charge par chaque type de forme, et définissez leurs valeurs sur `False` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Puis-je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous de forme restreignent des opérations de modification spécifiques, tandis que la [protection par mot de passe](/slides/fr/python-net/password-protected-presentation/) peut restreindre l’ouverture ou la modification de la présentation. Vous pouvez utiliser les deux dans le même fichier.

**Puis-je restreindre la modification sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez les verrous uniquement aux formes des diapositives sélectionnées. Cela ne modifie pas les paramètres de verrouillage des autres diapositives.

**Comment puis‑je appliquer des verrous à des formes individuelles à l’intérieur d’un groupe ?**

Parcourez la collection [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez l’opération pour tous les groupes imbriqués. Les exemples ci‑dessus traitent uniquement la collection de formes de la diapositive, ils ne définissent donc pas de verrous sur les membres individuels d’un groupe.