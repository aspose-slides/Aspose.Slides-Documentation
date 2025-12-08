---
title: Formes de présentation groupées avec Python
linktitle: Groupe de formes
type: docs
weight: 40
url: /fr/python-net/group/
keywords:
- forme de groupe
- groupe de formes
- ajouter groupe
- texte alternatif
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à regrouper et dégrouper des formes dans PowerPoint et les présentations OpenDocument à l'aide d'Aspose.Slides pour Python—guide rapide, étape par étape, avec du code gratuit."
---

## **Vue d'ensemble**

Le regroupement de formes vous permet de traiter plusieurs objets de dessin comme une seule unité, afin de pouvoir les déplacer, redimensionner, mettre en forme et les transformer ensemble. Avec Aspose.Slides pour Python, vous pouvez créer un [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), ajouter et organiser des formes enfants à l'intérieur, et enregistrer le résultat au format PPTX. Cet article montre comment ajouter une forme groupée sur une diapositive et comment accéder aux métadonnées d'accessibilité telles que le texte alternatif (Alt Text) des formes à l'intérieur du groupe, permettant une structure plus propre et des présentations plus riches et plus faciles à maintenir.

## **Ajouter des formes groupées**

Aspose.Slides prend en charge la manipulation des formes groupées sur une diapositive. Cette fonctionnalité vous permet de créer des présentations plus riches en traitant plusieurs formes comme un seul objet. Vous pouvez ajouter de nouvelles formes groupées, accéder aux existantes, les remplir de formes enfants, et lire ou modifier n'importe laquelle de leurs propriétés. Pour ajouter une forme groupée à une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par son indice.
3. Ajoutez un [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) à la diapositive.
4. Ajoutez des formes à la nouvelle forme groupée.
5. Enregistrez la présentation modifiée au format PPTX.

L’exemple ci‑dessous montre comment ajouter une forme groupée à une diapositive.
```py
import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation() as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme groupée à la diapositive.
    group_shape = slide.shapes.add_group_shape()

    # Ajouter des formes à l'intérieur de la forme groupée.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **Accéder à la propriété Alt Text**

Cette section explique comment lire le texte Alt (Alt Text) des formes contenues dans une forme groupée sur une diapositive à l’aide d’Aspose.Slides. Pour accéder au texte Alt des formes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour représenter un fichier PPTX.
2. Obtenez une référence à la diapositive par son indice.
3. Accédez à la collection de formes de la diapositive.
4. Accédez au [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. Lisez la propriété Alt Text.

L’exemple ci‑dessous récupère le texte Alt des formes contenues dans des formes groupées.
```py
import aspose.slides as slides

# Instancier la classe Presentation pour ouvrir le fichier PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Accéder à la forme groupée.
            for child_shape in shape.shapes:
                # Accéder à la propriété Alt Text.
                print(child_shape.alternative_text)
```


## **FAQ**

**Le regroupement imbriqué (un groupe à l’intérieur d’un autre groupe) est‑il pris en charge ?**

Oui. Le [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) possède une propriété [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/), qui indique directement la prise en charge de la hiérarchie (un groupe peut être enfant d’un autre groupe).

**Comment contrôler l’ordre Z du groupe par rapport aux autres objets sur la diapositive ?**

Utilisez la propriété [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) du [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) pour inspecter ou modifier sa position dans la pile d’affichage.

**Puis‑je empêcher le déplacement/l’édition/le dégroupage ?**

Oui. La section de verrouillage du groupe est exposée via [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/), ce qui vous permet de restreindre les opérations sur l’objet.