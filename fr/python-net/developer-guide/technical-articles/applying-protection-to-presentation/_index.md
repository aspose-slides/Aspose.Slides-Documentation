---
title: Empêcher les modifications de la présentation avec les verrous de forme en Python
linktitle: Empêcher les modifications de la présentation
type: docs
weight: 70
url: /fr/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour Python via .NET verrouille ou déverrouille les formes dans les fichiers PPT, PPTX et ODP, sécurisant les présentations tout en permettant des modifications contrôlées et une livraison plus rapide."
---

## **Contexte**

Une utilisation courante d’Aspose.Slides consiste à créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint (PPTX) dans le cadre d’un flux de travail automatisé. Les utilisateurs d’applications qui emploient Aspose.Slides de cette façon ont accès aux présentations générées, il est donc fréquent de vouloir les protéger contre toute modification. Il est important que les présentations générées automatiquement conservent leur mise en forme et leur contenu d’origine.

Cet article explique comment les présentations et les diapositives sont structurées et comment Aspose.Slides pour Python peut appliquer une protection à une présentation et la retirer ultérieurement. Il fournit aux développeurs un moyen de contrôler l’utilisation des présentations générées par leurs applications.

## **Composition d’une diapositive**

Une diapositive de présentation est composée d’éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d’image, des cadres vidéo, des connecteurs et d’autres éléments utilisés pour construire une présentation. Dans Aspose.Slides pour Python, chaque élément d’une diapositive est représenté par un objet qui hérite de la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

La structure du PPTX est complexe, de sorte qu’à la différence du PPT, où un verrou générique peut être utilisé pour tous les types de formes, différents types de formes nécessitent des verrous différents. La classe [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) est la classe de verrouillage générique pour le PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides pour Python pour le PPTX :

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) verrouille les formes automatiques.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) verrouille les formes connecteurs.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) verrouille les objets graphiques.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) verrouille les formes groupées.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) verrouille les cadres d’image.  

Toute action effectuée sur tous les objets forme dans un objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) est appliquée à l’ensemble de la présentation.

## **Appliquer et supprimer la protection**

Appliquer une protection garantit qu’une présentation ne peut pas être modifiée. C’est une technique utile pour protéger le contenu de la présentation.

### **Appliquer une protection aux formes PPTX**

Aspose.Slides pour Python fournit la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pour travailler avec les formes d’une diapositive.

Comme indiqué précédemment, chaque classe de forme possède une classe de verrouillage de forme associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (par clics de souris ou autres méthodes de sélection) et qu’elles ne peuvent pas être déplacées ou redimensionnées.

L’exemple de code qui suit applique une protection à tous les types de formes d’une présentation.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # Parcourir toutes les diapositives de la présentation.
    for slide in presentation.slides:
        # Parcourir toutes les formes de la diapositive.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Enregistrer le fichier de présentation.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Supprimer la protection**

Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur `False`. L’exemple de code suivant montre comment déverrouiller les formes dans une présentation verrouillée.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Parcourir toutes les diapositives de la présentation.
    for slide in presentation.slides:
        # Parcourir toutes les formes de la diapositive.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Enregistrer le fichier de présentation.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Conclusion**

Aspose.Slides propose plusieurs options pour protéger les formes d’une présentation. Vous pouvez verrouiller une forme individuelle ou parcourir toutes les formes d’une présentation et verrouiller chacune d’elles afin de sécuriser efficacement l’ensemble du fichier. Vous pouvez supprimer la protection en définissant la valeur du verrou sur `False`.

## **FAQ**

**Puis-je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous limitent la modification des objets à l’intérieur du fichier, tandis que la [protection par mot de passe](/slides/fr/python-net/password-protected-presentation/) contrôle l’accès à l’ouverture et/ou à l’enregistrement des modifications. Ces mécanismes se complètent et fonctionnent ensemble.

**Puis-je restreindre la modification de diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez des verrous aux formes des diapositives sélectionnées ; les diapositives restantes resteront modifiables.

**Les verrous de forme s’appliquent‑ils aux objets groupés et aux connecteurs ?**

Oui. Des types de verrous dédiés sont pris en charge pour les groupes, les connecteurs, les objets graphiques et les autres catégories de formes.