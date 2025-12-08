---
title: Ajouter des diapositives aux présentations avec Python
linktitle: Ajouter une diapositive
type: docs
weight: 10
url: /fr/python-net/add-slide-to-presentation/
keywords:
- ajouter une diapositive
- créer une diapositive
- diapositive vierge
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez facilement des diapositives à vos présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET—une insertion de diapositives transparente et efficace en quelques secondes."
---

## **Vue d'ensemble**

Avant d'ajouter des diapositives à une présentation, il est utile de comprendre comment PowerPoint les organise. Chaque présentation contient une diapositive maître, des diapositives de disposition facultatives et une ou plusieurs diapositives normales. Chaque diapositive possède un ID unique, et les diapositives normales sont ordonnées par un indice zéro. Cet article montre comment utiliser Aspose.Slides pour Python afin de créer des diapositives et de choisir les dispositions appropriées.

## **Ajouter des diapositives aux présentations**

Aspose.Slides vous permet d'ajouter de nouvelles diapositives en fonction de diapositives de disposition existantes. L'exemple ci‑dessous parcourt chaque disposition dans la présentation, ajoute une diapositive qui utilise cette disposition, puis enregistre le fichier.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
1. Pour chaque élément de `presentation.layout_slides`, appelez `add_empty_slide` pour ajouter une diapositive qui utilise cette disposition.
1. Modifiez éventuellement les diapositives ajoutées.
1. Enregistrez la présentation au format PPTX.
```py
import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation() as presentation:
    # Accéder à la collection de diapositives.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Ajouter une diapositive vide à la collection de diapositives.
        slides.add_empty_slide(layout_slide)

    # Effectuer des opérations sur les diapositives nouvellement ajoutées.

    # Enregistrer la présentation sur le disque.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis-je insérer une nouvelle diapositive à une position spécifique, pas seulement à la fin ?**

Oui. La bibliothèque prend en charge les collections de diapositives ainsi que les opérations [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) de sorte que vous pouvez ajouter une diapositive à l’indice requis plutôt qu’à la fin uniquement.

**Les thèmes/styles sont-ils conservés lors de l’ajout d’une diapositive basée sur une disposition ?**

Oui. Une disposition hérite du formatage de son maître, et la nouvelle diapositive hérite de la disposition sélectionnée ainsi que de son maître associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d’ajouter des diapositives ?**

Une présentation nouvellement créée contient déjà une diapositive vierge avec l’indice zéro. Il est important de le prendre en compte lors du calcul des indices d’insertion.

**Comment choisir la disposition « appropriée » pour une nouvelle diapositive si le maître propose de nombreuses options ?**

En général, choisissez le [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) qui correspond à la structure requise ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Si une telle disposition est absente, vous pouvez la [l’ajouter au maître](/slides/fr/python-net/slide-layout/) et l’utiliser ensuite.