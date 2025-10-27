---
title: Ajouter des diapositives aux présentations avec Python
linktitle: Ajouter une diapositive
type: docs
weight: 10
url: /fr/python-net/add-slide-to-presentation/
keywords:
- ajouter une diapositive
- créer une diapositive
- diapositive vide
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez facilement des diapositives à vos présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET — insertion de diapositives fluide et efficace en quelques secondes."
---

## **Vue d'ensemble**

Avant d'ajouter des diapositives à une présentation, il est utile de comprendre comment PowerPoint les organise. Chaque présentation contient une diapositive maître, des diapositives de disposition facultatives et une ou plusieurs diapositives normales. Chaque diapositive possède un ID unique, et les diapositives normales sont ordonnées selon un indice commençant à zéro. Cet article montre comment utiliser Aspose.Slides pour Python afin de créer des diapositives et de choisir les dispositions appropriées.

## **Ajouter des diapositives aux présentations**

Aspose.Slides vous permet d'ajouter de nouvelles diapositives en vous basant sur des diapositives de disposition existantes. L'exemple ci‑dessous parcourt chaque disposition de la présentation, ajoute une diapositive qui utilise cette disposition, puis enregistre le fichier.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accéder à la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
3. Pour chaque élément de `presentation.layout_slides`, appeler `add_empty_slide` pour ajouter une diapositive qui utilise cette disposition.
4. Facultativement, modifier les diapositives nouvellement ajoutées.
5. Enregistrer la présentation au format PPTX.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the slide collection.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Add an empty slide to the slide collection.
        slides.add_empty_slide(layout_slide)

    # Do some work on the newly added slides.

    # Save the presentation to disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis-je insérer une nouvelle diapositive à une position spécifique, et pas seulement à la fin ?**

Oui. La bibliothèque prend en charge les collections de diapositives ainsi que les opérations [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), vous permettant d'ajouter une diapositive à l'indice requis plutôt qu'uniquement à la fin.

**Les thèmes/styles sont-ils conservés lors de l'ajout d'une diapositive basée sur une disposition ?**

Oui. Une disposition hérite du formatage de son maître, et la nouvelle diapositive hérite de la disposition sélectionnée et de son maître associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d'ajouter des diapositives ?**

Une présentation nouvellement créée contient déjà une diapositive vierge avec l'indice zéro. Cela est important à prendre en compte lors du calcul des indices d'insertion.

**Comment choisir la disposition « correcte » pour une nouvelle diapositive si le maître propose de nombreuses options ?**

En général, choisissez le [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) qui correspond à la structure requise ([Titre et contenu, Deux contenus, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Si une telle disposition est absente, vous pouvez la [ajouter au maître](/slides/fr/python-net/slide-layout/) puis l'utiliser.