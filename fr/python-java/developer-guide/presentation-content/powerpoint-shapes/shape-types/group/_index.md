---
title: Formes de présentation groupées en Python via Java
linktitle: Groupe de formes
type: docs
weight: 40
url: /fr/python-java/group/
keywords:
- forme groupée
- groupe de formes
- ajouter un groupe
- texte alternatif
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à grouper et dégrouper des formes dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Python via Java — guide étape par étape avec du code Python gratuit."
---
## **Aperçu**

Cet article explique comment travailler avec les formes groupées dans Aspose.Slides. Il montre comment ajouter une forme groupée à une diapositive, placer des formes à l'intérieur et enregistrer la présentation mise à jour. Il montre également comment accéder aux formes stockées dans un groupe et lire leur texte alternatif à l'aide de [getAlternativeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getAlternativeText). De plus, l'article couvre brièvement les fonctionnalités liées aux formes groupées, telles que les groupes imbriqués, l'ordre Z et les options de verrouillage.

## **Ajouter une forme groupée**

Aspose.Slides prend en charge le travail avec les formes groupées sur les diapositives. Cette fonctionnalité aide les développeurs à créer des présentations plus riches. Aspose.Slides for Python via Java prend en charge l'ajout et l'accès aux formes groupées. Vous pouvez remplir une forme groupée avec des formes ou accéder à ses propriétés. Pour ajouter une forme groupée à une diapositive avec Aspose.Slides for Python via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez une forme groupée à la diapositive.
1. Ajoutez des formes à la forme groupée.
1. Enregistrez la présentation modifiée au format PPTX.

L'exemple ci-dessous ajoute une forme groupée à une diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Instancier la classe Presentation.
presentation = Presentation()
try:
    # Obtenir la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Accéder à la collection de formes de la diapositive.
    slide_shapes = slide.getShapes()

    # Ajouter une forme groupée à la diapositive.
    group_shape = slide_shapes.addGroupShape()

    # Ajouter des formes à l'intérieur de la forme groupée.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Définir le cadre de la forme groupée.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accéder au texte alternatif**

Cette section montre comment accéder au texte alternatif des formes à l'intérieur d'un groupe sur une diapositive. Pour accéder à ce texte avec Aspose.Slides for Python via Java :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui représente un fichier PPTX.
1. Obtenez une référence à une diapositive par son indice.
1. Accédez à la collection de formes de la diapositive.
1. Accédez à la forme groupée.
1. Lisez le texte alternatif de ses formes à l'aide de [getAlternativeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getAlternativeText).

L'exemple ci-dessous accède au texte alternatif des formes à l'intérieur d'un groupe :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Instancier la classe Presentation qui représente le fichier PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Obtenir la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Accéder à une forme dans la collection de formes de la diapositive.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Accéder aux formes à l'intérieur du groupe.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Lire le texte alternatif.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Le regroupement imbriqué (un groupe à l'intérieur d'un groupe) est‑il pris en charge ?**

Oui. [GroupShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/groupshape/) possède une méthode [getParentGroup](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getParentGroup), qui indique la prise en charge de la hiérarchie : un groupe peut être enfant d'un autre groupe.

**Comment contrôler l'ordre Z du groupe par rapport aux autres objets de la diapositive ?**

Utilisez la méthode [getZOrderPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getZOrderPosition) de l'objet [GroupShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/groupshape/) pour inspecter sa position dans la pile d'affichage.

**Puis‑je empêcher le déplacement, la modification ou le dégroupage ?**

Oui. Les verrous du groupe sont exposés via [getGroupShapeLock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/groupshape/#getGroupShapeLock), ce qui vous permet de restreindre les opérations sur l'objet.