---
title: Accéder aux diapositives dans les présentations avec Python
linktitle: Accéder à la diapositive
type: docs
weight: 20
url: /fr/python-net/access-slide-in-presentation/
keywords:
- accéder à la diapositive
- index de diapositive
- ID de diapositive
- position de la diapositive
- changer la position
- propriétés de la diapositive
- numéro de diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à accéder et à gérer les diapositives dans les présentations PowerPoint et OpenDocument avec Aspose.Slides for Python via .NET. Améliorez votre productivité grâce à des exemples de code."
---

Aspose.Slides vous permet d'accéder aux diapositives de deux manières : par index et par ID.

## **Accéder à une Diapositive par Index**

Toutes les diapositives d'une présentation sont disposées numériquement en fonction de la position de la diapositive, en commençant à partir de 0. La première diapositive est accessible par l'index 0 ; la deuxième diapositive est accessible par l'index 1 ; etc.

La classe Presentation, qui représente un fichier de présentation, expose toutes les diapositives en tant que collection [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) (collection d'objets [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)). Ce code Python vous montre comment accéder à une diapositive via son index :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Obtient la référence d'une diapositive par son index
    slide = presentation.slides[0]
```

## **Accéder à une Diapositive par ID**

Chaque diapositive d'une présentation a un ID unique qui lui est associé. Vous pouvez utiliser la méthode `get_slide_by_id(id)` (exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) pour cibler cet ID. Ce code Python vous montre comment fournir un ID de diapositive valide et accéder à cette diapositive via la méthode `get_slide_by_id(id)` :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Obtient un ID de diapositive
    id = presentation.slides[0].slide_id
    # Accède à la diapositive via son ID
    slide = presentation.get_slide_by_id(id)
```

## **Changer la Position de la Diapositive**

Aspose.Slides vous permet de changer la position d'une diapositive. Par exemple, vous pouvez spécifier que la première diapositive doit devenir la deuxième diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive (dont vous souhaitez changer la position) par son index.
1. Définissez une nouvelle position pour la diapositive via la propriété `slide_number`.
1. Enregistrez la présentation modifiée.

Ce code Python illustre une opération où la diapositive en position 1 est déplacée à la position 2 :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "ChangePosition.pptx") as pres:
    # Obtient la diapositive dont la position sera changée
    sld = pres.slides[0]
    # Définit la nouvelle position pour la diapositive
    sld.slide_number = 2
    # Enregistre la présentation modifiée
    pres.save("Aspose_out.pptx", slides.export.SaveFormat.PPTX)
```

La première diapositive est devenue la deuxième ; la deuxième diapositive est devenue la première. Lorsque vous changez la position d'une diapositive, les autres diapositives s'ajustent automatiquement.


## **Définir le Numéro de la Diapositive**

En utilisant la propriété `first_slide_number` (exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)), vous pouvez spécifier un nouveau numéro pour la première diapositive d'une présentation. Cette opération entraîne le recalcul des numéros des autres diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez le numéro de la diapositive.
1. Définissez le numéro de la diapositive.
1. Enregistrez la présentation modifiée.

Ce code Python illustre une opération où le numéro de la première diapositive est défini sur 10 :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Obtient le numéro de la diapositive
    firstSlideNumber = presentation.first_slide_number
    # Définit le numéro de la diapositive
    presentation.first_slide_number = 10
    # Enregistre la présentation modifiée
    presentation.save("Set_Slide_Number_out.pptx", slides.export.SaveFormat.PPTX)
```

Si vous préférez passer la première diapositive, vous pouvez commencer la numérotation à partir de la deuxième diapositive (et masquer la numérotation pour la première diapositive) de cette manière :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Définit le numéro pour la première diapositive de la présentation
    presentation.first_slide_number = 0

    # Affiche les numéros de diapositives pour toutes les diapositives
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Masque le numéro de la diapositive pour la première diapositive
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Enregistre la présentation modifiée
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```