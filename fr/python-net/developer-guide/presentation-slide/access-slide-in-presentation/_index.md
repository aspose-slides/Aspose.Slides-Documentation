---
title: Accéder aux diapositives dans les présentations avec Python
linktitle: Accéder à la diapositive
type: docs
weight: 20
url: /fr/python-net/developer-guide/presentation-slide/access-slide-in-presentation/
keywords:
- accéder à la diapositive
- index de diapositive
- ID de diapositive
- position de diapositive
- changer la position
- propriétés de diapositive
- numéro de diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment accéder et gérer les diapositives dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Augmentez la productivité avec des exemples de code."
---

## **Vue d'ensemble**

Cet article explique comment accéder à des diapositives spécifiques dans une présentation PowerPoint à l'aide d'Aspose.Slides pour Python. Il montre comment ouvrir une présentation, référencer les diapositives par indice ou par identifiant unique, et lire les informations de base nécessaires à la navigation dans le fichier. Avec ces techniques, vous pouvez localiser de manière fiable la diapositive exacte que vous souhaitez inspecter ou traiter.

## **Accéder à une diapositive par indice**

Les diapositives d'une présentation sont indexées par position en commençant à 0. La première diapositive a l'indice 0, la deuxième a l'indice 1, etc.

La classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (qui représente un fichier de présentation) expose les diapositives via une [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) d'objets [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

Le code Python suivant montre comment accéder à une diapositive par son indice :

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide by its index.
    slide = presentation.slides[0]
```

## **Accéder à une diapositive par ID**

Chaque diapositive d'une présentation possède un ID unique qui lui est associé. Vous pouvez utiliser la méthode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) pour cibler cet ID.

Le code Python suivant montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) :

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide ID.
    id = presentation.slides[0].slide_id
    # Access the slide by its ID.
    slide = presentation.get_slide_by_id(id)
```

## **Modifier la position d'une diapositive**

Aspose.Slides vous permet de changer la position d'une diapositive. Par exemple, vous pouvez faire en sorte que la première diapositive devienne la seconde.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive dont vous souhaitez modifier la position par son indice.
3. Définissez une nouvelle position pour la diapositive via la propriété [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
4. Enregistrez la présentation modifiée.

Le code Python suivant déplace la diapositive en position 1 vers la position 2 :

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get the slide whose position will be changed.
    slide = presentation.slides[0]
    # Set the new position for the slide.
    slide.slide_number = 2
    # Save the modified presentation.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

La première diapositive devient la seconde ; la seconde diapositive devient la première. Lorsque vous changez la position d’une diapositive, les autres diapositives sont ajustées automatiquement.

## **Définir le numéro de diapositive**

En utilisant la propriété [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d’une présentation. Cette opération entraîne le recalcul des numéros des autres diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez le numéro de diapositive.
3. Enregistrez la présentation modifiée.

Le code Python suivant montre une opération où le numéro de la première diapositive est fixé à 10 :

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Set the slide number.
    presentation.first_slide_number = 10
    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Si vous préférez ignorer la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer le numéro sur la première) comme suit :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Set the number for the first slide in the presentation.
    presentation.first_slide_number = 0

    # Show slide numbers for all slides.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Hide the slide number on the first slide.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le numéro de diapositive affiché à l'utilisateur correspond‑il à l'indice zéro‑based de la collection ?**

Le numéro affiché sur une diapositive peut commencer à une valeur arbitraire (par ex., 10) et ne doit pas forcément correspondre à l’indice ; la relation est contrôlée par le paramètre [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) de la présentation.

**Les diapositives masquées affectent‑elles l’indexation ?**

Oui. Une diapositive masquée reste dans la collection et est comptée dans l’indexation ; « masquée » fait référence à l’affichage, pas à sa position dans la collection.

**L’indice d’une diapositive change‑t‑il lorsque d’autres diapositives sont ajoutées ou supprimées ?**

Oui. Les indices reflètent toujours l’ordre actuel des diapositives et sont recalculés lors des opérations d’insertion, de suppression et de déplacement.