---
title: Accéder aux diapositives dans les présentations avec Python
linktitle: Accéder à la diapositive
type: docs
weight: 20
url: /fr/python-net/access-slide-in-presentation/
keywords:
- accès diapositive
- index diapositive
- id diapositive
- position diapositive
- modifier position
- propriétés diapositive
- numéro diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment accéder aux diapositives et les gérer dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Augmentez votre productivité grâce à des exemples de code."
---

## **Aperçu**

Cet article explique comment accéder à des diapositives spécifiques dans une présentation PowerPoint à l'aide d'Aspose.Slides pour Python. Il montre comment ouvrir une présentation, référencer les diapositives par index ou par identifiant unique, et lire les informations de base sur la diapositive nécessaires à la navigation dans le fichier. Avec ces techniques, vous pouvez localiser de manière fiable la diapositive exacte que vous souhaitez inspecter ou traiter.

## **Accéder à une diapositive par index**

Les diapositives d'une présentation sont indexées par position à partir de 0. La première diapositive a l'index 0, la deuxième a l'index 1, etc.

La classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (qui représente un fichier de présentation) expose les diapositives via une [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) d'objets [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

Le code Python suivant montre comment accéder à une diapositive par son index :

```python
import aspose.slides as slides

# Créez une Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Obtenez une diapositive par son index.
    slide = presentation.slides[0]
```

## **Accéder à une diapositive par ID**

Chaque diapositive d'une présentation possède un identifiant unique associé. Vous pouvez utiliser la méthode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ) pour cibler cet ID.

Le code Python suivant montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) :

```python
import aspose.slides as slides

# Créez une Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Obtenez un ID de diapositive.
    id = presentation.slides[0].slide_id
    # Accédez à la diapositive par son ID.
    slide = presentation.get_slide_by_id(id)
```

## **Modifier la position d'une diapositive**

Les Aspose.Slides vous permettent de modifier la position d'une diapositive. Par exemple, vous pouvez faire en sorte que la première diapositive devienne la deuxième.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive dont vous souhaitez changer la position par son index.
1. Définissez une nouvelle position pour la diapositive via la propriété [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
1. Enregistrez la présentation modifiée.

Le code Python suivant déplace la diapositive en position 1 vers la position 2 :

```python
import aspose.slides as slides

# Instanciez un objet Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Obtenez la diapositive dont la position sera modifiée.
    slide = presentation.slides[0]
    # Définissez la nouvelle position pour la diapositive.
    slide.slide_number = 2
    # Enregistrez la présentation modifiée.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

La première diapositive devient la deuxième ; la deuxième diapositive devient la première. Lorsque vous modifiez la position d'une diapositive, les autres diapositives sont ajustées automatiquement.

## **Définir le numéro de diapositive**

En utilisant la propriété [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ), vous pouvez spécifier un nouveau numéro pour la première diapositive d'une présentation. Cette opération entraîne le recalcul des autres numéros de diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Définissez le numéro de diapositive.
1. Enregistrez la présentation modifiée.

Le code Python suivant montre une opération où le numéro de la première diapositive est fixé à 10 :

```python
import aspose.slides as slides

# Instanciez un objet Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Définissez le numéro de diapositive.
    presentation.first_slide_number = 10
    # Enregistrez la présentation modifiée.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Si vous préférez sauter la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer le numéro sur la première) comme suit :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Définissez le numéro pour la première diapositive de la présentation.
    presentation.first_slide_number = 0

    # Affichez les numéros de diapositives pour toutes les diapositives.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Masquez le numéro de diapositive sur la première diapositive.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Enregistrez la présentation modifiée.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le numéro de diapositive vu par l'utilisateur correspond-il à l'indice zéro de la collection ?**

Le numéro affiché sur une diapositive peut commencer à une valeur arbitraire (par ex., 10) et ne doit pas nécessairement correspondre à l'indice ; la relation est contrôlée par le paramètre [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) de la présentation.

**Les diapositives masquées affectent-elles l'indexation ?**

Oui. Une diapositive masquée reste dans la collection et est comptée dans l'indexation ; « masqué » fait référence à l'affichage, pas à sa position dans la collection.

**L'indice d'une diapositive change-t-il lorsqu'on ajoute ou supprime d'autres diapositives ?**

Oui. Les indices reflètent toujours l'ordre actuel des diapositives et sont recalculés lors des opérations d'insertion, de suppression et de déplacement.