---
title: Formes de groupe dans les présentations avec Python
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
description: "Apprenez à grouper et dégrouper des formes dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Python — guide rapide, étape par étape, avec du code gratuit."
---

## **Aperçu**

Le regroupement de formes vous permet de traiter plusieurs objets graphiques comme une seule unité afin de les déplacer, redimensionner, formater et transformer ensemble. Avec Aspose.Slides pour Python, vous pouvez créer une [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), ajouter et organiser des formes enfants à l’intérieur, et enregistrer le résultat au format PPTX. Cet article montre comment ajouter une forme de groupe sur une diapositive et comment accéder aux métadonnées d’accessibilité telles que le texte alternatif des formes du groupe, permettant une structure plus claire et des présentations plus riches et plus faciles à entretenir.

## **Ajouter des formes de groupe**

Aspose.Slides prend en charge le travail avec des formes de groupe sur une diapositive. Cette fonctionnalité vous permet de créer des présentations plus riches en traitant plusieurs formes comme un seul objet. Vous pouvez ajouter de nouvelles formes de groupe, accéder à celles existantes, les remplir de formes enfants, et lire ou modifier n’importe laquelle de leurs propriétés. Pour ajouter une forme de groupe à une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par son indice.
3. Ajoutez une [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) à la diapositive.
4. Ajoutez des formes à la nouvelle forme de groupe.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L’exemple ci‑dessous montre comment ajouter une forme de groupe à une diapositive.

```py
import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation() as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme de groupe à la diapositive.
    group_shape = slide.shapes.add_group_shape()

    # Ajouter des formes à l'intérieur de la forme de groupe.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Écrire le fichier PPTX sur le disque.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à la propriété Texte alternatif**

Cette section explique comment lire le texte alternatif des formes contenues dans une forme de groupe sur une diapositive à l’aide d’Aspose.Slides. Pour accéder au texte alternatif des formes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour représenter un fichier PPTX.
2. Obtenez une référence à la diapositive par son indice.
3. Accédez à la collection de formes de la diapositive.
4. Accédez à la [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/).
5. Lisez la propriété Texte alternatif.

L’exemple ci‑dessous récupère le texte alternatif des formes contenues dans les formes de groupe.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour ouvrir le fichier PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Accéder à la forme de groupe.
            for child_shape in shape.shapes:
                # Accéder à la propriété Texte alternatif.
                print(child_shape.alternative_text)
```

## **FAQ**

**Le regroupement imbriqué (un groupe à l'intérieur d'un groupe) est‑il pris en charge ?**

Oui. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) possède une propriété [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/), qui indique directement la prise en charge de la hiérarchie (un groupe peut être enfant d'un autre groupe).

**Comment contrôler l’ordre Z du groupe par rapport aux autres objets de la diapositive ?**

Utilisez la propriété [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) du [GroupShape] pour inspecter ou modifier sa position dans la pile d'affichage.

**Puis‑je empêcher le déplacement/l'édition/le dégrouper ?**

Oui. La section de verrouillage du groupe est exposée via [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/), qui vous permet de restreindre les opérations sur l'objet.