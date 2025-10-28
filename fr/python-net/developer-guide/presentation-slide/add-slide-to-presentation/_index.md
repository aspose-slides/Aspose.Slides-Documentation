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
description: "Ajoutez facilement des diapositives à vos présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET—insertion de diapositives rapide et efficace en quelques secondes."
---

## **Vue d'ensemble**

Avant d'ajouter des diapositives à une présentation, il est utile de comprendre comment PowerPoint les organise. Chaque présentation contient une diapositive maîtresse, des diapositives de mise en page optionnelles et une ou plusieurs diapositives normales. Chaque diapositive possède un identifiant unique, et les diapositives normales sont ordonnées selon un indice démarrant à zéro. Cet article montre comment utiliser Aspose.Slides pour Python afin de créer des diapositives et de choisir les mises en page appropriées.

## **Ajouter des diapositives aux présentations**

Aspose.Slides vous permet d'ajouter de nouvelles diapositives en vous basant sur des diapositives de mise en page existantes. L'exemple ci‑dessous parcourt chaque mise en page de la présentation, ajoute une diapositive qui utilise cette mise en page, puis enregistre le fichier.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
3. Pour chaque élément de `presentation.layout_slides`, appelez `add_empty_slide` pour ajouter une diapositive qui utilise cette mise en page.
4. Modifiez éventuellement les diapositives nouvellement ajoutées.
5. Enregistrez la présentation au format PPTX.

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

Oui. La bibliothèque prend en charge les collections de diapositives ainsi que les opérations [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), vous permettant d'ajouter une diapositive à l'index requis plutôt qu'à la fin uniquement.

**Les thèmes/styles sont-ils conservés lors de l'ajout d'une diapositive basée sur une mise en page ?**

Oui. Une mise en page hérite du formatage de son maître, et la nouvelle diapositive hérite de la mise en page sélectionnée et de son maître associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d'ajouter des diapositives ?**

Une présentation nouvellement créée contient déjà une diapositive blanche avec l'indice zéro. Cela est important à prendre en compte lors du calcul des indices d'insertion.

**Comment choisir la mise en page « adéquate » pour une nouvelle diapositive si le maître propose de nombreuses options ?**

En général, choisissez la [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) qui correspond à la structure requise ([Titre et contenu, Deux contenus, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Si une telle mise en page est absente, vous pouvez la [add it to the master](/slides/fr/python-net/slide-layout/) puis l’utiliser.