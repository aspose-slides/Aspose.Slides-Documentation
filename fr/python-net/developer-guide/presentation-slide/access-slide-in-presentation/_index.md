---
title: Accéder aux diapositives dans les présentations avec Python
linktitle: Accéder à la diapositive
type: docs
weight: 20
url: /fr/python-net/access-slide-in-presentation/
keywords:
- accéder à la diapositive
- indice de diapositive
- id de diapositive
- position de diapositive
- modifier la position
- propriétés de diapositive
- numéro de diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à accéder et à gérer les diapositives dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Augmentez votre productivité grâce à des exemples de code."
---

## **Aperçu**

Cet article explique comment accéder à des diapositives spécifiques dans une présentation PowerPoint à l’aide d’Aspose.Slides pour Python. Il montre comment ouvrir une présentation, référencer les diapositives par indice ou par ID unique, et lire les informations de base nécessaires à la navigation dans le fichier. Avec ces techniques, vous pouvez localiser de façon fiable la diapositive exacte que vous souhaitez examiner ou traiter.

## **Accéder à une diapositive par indice**

Les diapositives d’une présentation sont indexées par position en commençant à 0. La première diapositive a l’indice 0, la deuxième a l’indice 1, etc.

La classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (qui représente un fichier de présentation) expose les diapositives via une [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) d’objets [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

Le code Python suivant montre comment accéder à une diapositive par son indice :

```python
import aspose.slides as slides

# Crée une Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Obtient une diapositive par son indice.
    slide = presentation.slides[0]
```

## **Accéder à une diapositive par ID**

Chaque diapositive d’une présentation possède un ID unique qui lui est associé. Vous pouvez utiliser la méthode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) pour cibler cet ID.

Le code Python suivant montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) :

```python
import aspose.slides as slides

# Crée une Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Obtient l'ID d'une diapositive.
    id = presentation.slides[0].slide_id
    # Accède à la diapositive par son ID.
    slide = presentation.get_slide_by_id(id)
```

## **Modifier la position d’une diapositive**

Aspose.Slides vous permet de modifier la position d’une diapositive. Par exemple, vous pouvez faire en sorte que la première diapositive devienne la deuxième.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive dont vous souhaitez changer la position par son indice.
1. Définissez une nouvelle position pour la diapositive via la propriété [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
1. Enregistrez la présentation modifiée.

Le code Python suivant déplace la diapositive en position 1 vers la position 2 :

```python
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Obtenir la diapositive dont la position sera modifiée.
    slide = presentation.slides[0]
    # Définir la nouvelle position pour la diapositive.
    slide.slide_number = 2
    # Enregistrer la présentation modifiée.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

La première diapositive devient la deuxième ; la deuxième devient la première. Lorsque vous modifiez la position d’une diapositive, les autres diapositives sont ajustées automatiquement.

## **Définir le numéro de la diapositive**

En utilisant la propriété [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d’une présentation. Cette opération entraîne le recalcul des autres numéros de diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Définissez le numéro de la diapositive.
1. Enregistrez la présentation modifiée.

Le code Python suivant montre une opération où le numéro de la première diapositive est fixé à 10 :

```python
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Définir le numéro de la diapositive.
    presentation.first_slide_number = 10
    # Enregistrer la présentation modifiée.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Si vous préférez ignorer la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième (et masquer le numéro sur la première) comme suit :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Définir le numéro pour la première diapositive de la présentation.
    presentation.first_slide_number = 0

    # Afficher les numéros de diapositives pour toutes les diapositives.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Masquer le numéro de diapositive sur la première diapositive.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Enregistrer la présentation modifiée.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le numéro de diapositive vu par l’utilisateur correspond‑il à l’indice basé sur zéro de la collection ?**

Le numéro affiché sur une diapositive peut commencer à une valeur arbitraire (par ex., 10) et n’a pas besoin de correspondre à l’indice ; la relation est contrôlée par le paramètre [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) de la présentation.

**Les diapositives masquées affectent‑elles l’indexation ?**

Oui. Une diapositive masquée reste dans la collection et est comptée dans l’indexation ; « masquée » fait référence à l’affichage, pas à sa position dans la collection.

**L’indice d’une diapositive change‑t‑il lorsque d’autres diapositives sont ajoutées ou supprimées ?**

Oui. Les indices reflètent toujours l’ordre actuel des diapositives et sont recalculés lors des opérations d’insertion, de suppression et de déplacement.