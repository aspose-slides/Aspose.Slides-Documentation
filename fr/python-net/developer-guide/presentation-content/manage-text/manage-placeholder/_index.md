---
title: Gérer les espaces réservés dans les présentations avec Python
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/python-net/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- texte d'invite
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérez facilement les espaces réservés dans Aspose.Slides for Python via .NET : remplacez le texte, personnalisez les invites et définissez la transparence des images dans PowerPoint et OpenDocument."
---

## **Vue d'ensemble**

Les espaces réservés définissent des zones réservées sur les maîtres, les mises en page et les diapositives—telles que le titre, le corps, l'image, le graphique, la date/heure, le numéro de diapositive et le pied de page—qui contrôlent où le contenu va et comment il hérite du formatage. Avec Aspose.Slides for Python, vous pouvez découvrir les espaces réservés sur une diapositive, sa mise en page ou le maître en vérifiant que `shape.placeholder` n’est pas `None`, inspecter le `placeholder.type`, puis lire ou modifier le contenu et le formatage associés. L’API vous permet d’ajouter de nouveaux espaces réservés à un maître ou à une mise en page afin qu’ils se propagent aux diapositives descendantes, de repositionner et redimensionner ceux existants, de convertir un espace réservé en forme normale lorsque vous avez besoin d’un contrôle total, ou de le supprimer pour simplifier un design. Les exemples ci‑dessous montrent comment énumérer les espaces réservés, mettre à jour le texte et le style, et garder les mises en page cohérentes en appliquant les modifications au niveau approprié.

## **Modifier le texte dans les espaces réservés**

Avec Aspose.Slides for Python, vous pouvez trouver et modifier les espaces réservés sur les diapositives d’une présentation. Aspose.Slides vous permet de modifier le texte d’un espace réservé.

**Prérequis :** Vous avez besoin d’une présentation contenant un espace réservé. Vous pouvez créer une telle présentation avec Microsoft PowerPoint.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans un espace réservé :

1. Instanciez la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et passez la présentation en argument.
1. Obtenez une référence à la diapositive par son indice.
1. Parcourez les formes pour trouver l’espace réservé.
1. Modifiez le texte à l’aide du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) associé à l’[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Enregistrez la présentation modifiée.

Ce code Python montre comment changer le texte dans un espace réservé :
```python
import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Parcourir les formes pour trouver les espaces réservés.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Modifier le texte de chaque espace réservé.
            shape.text_frame.text = "This is Placeholder"

    # Enregistrer la présentation sur le disque.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le texte d’invite pour un espace réservé**

Les mises en page standard et pré‑construites incluent du texte d’invite tel que **Cliquez pour ajouter un titre** ou **Cliquez pour ajouter un sous‑titre**. Avec Aspose.Slides, vous pouvez remplacer ces invites par votre propre texte dans les mises en page d’espace réservé.

L’exemple Python suivant montre comment définir le texte d’invite pour un espace réservé :
```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Parcourir les formes pour trouver les espaces réservés.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la transparence d’une image dans un espace réservé**

Aspose.Slides vous permet de régler la transparence d’une image de fond dans un espace réservé texte. En ajustant la transparence de l’image dans ce cadre, vous pouvez faire ressortir soit le texte, soit l’image, selon leurs couleurs.

L’exemple Python suivant montre comment définir la transparence d’une image de fond à l’intérieur d’une forme :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```


## **FAQ**

**Qu’est‑ce qu’un espace réservé de base, et en quoi diffère‑t‑il d’une forme locale sur une diapositive ?**

Un espace réservé de base est la forme originale sur une mise en page ou un maître dont hérite la forme de la diapositive — le type, la position et une partie du formatage proviennent de celle‑ci. Une forme locale est indépendante ; s’il n’y a pas d’espace réservé de base, l’héritage ne s’applique pas.

**Comment mettre à jour tous les titres ou légendes d’une présentation sans parcourir chaque diapositive ?**

Modifiez l’espace réservé correspondant sur la mise en page ou le maître. Les diapositives basées sur ces mises en page/ce maître hériteront automatiquement de la modification.

**Comment contrôler les espaces réservés d’en‑tête/pied de page standards — date & heure, numéro de diapositive et texte du pied de page ?**

Utilisez les gestionnaires HeaderFooter au niveau approprié (diapositives normales, mises en page, maître, notes/feuilles de distribution) pour activer ou désactiver ces espaces réservés et définir leur contenu.