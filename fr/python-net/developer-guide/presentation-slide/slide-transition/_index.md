---
title: Gérer les transitions de diapositives dans les présentations avec Python
linktitle: Transition de diapositive
type: docs
weight: 90
url: /fr/python-net/slide-transition/
keywords:
- transition de diapositive
- ajouter une transition de diapositive
- appliquer une transition de diapositive
- transition de diapositive avancée
- transition morph
- type de transition
- effet de transition
- Python
- Aspose.Slides
description: "Découvrez comment personnaliser les transitions de diapositives dans Aspose.Slides for Python via .NET, avec un guide étape par étape pour les présentations PowerPoint et OpenDocument."
---

## **Vue d'ensemble**

Aspose.Slides for Python offre un contrôle complet des transitions de diapositives, du choix du type de transition à la configuration du minutage et des déclencheurs dans le cadre de flux de travail de présentations automatisées. Vous pouvez définir les diapositives pour avancer au clic et/ou après un délai spécifié et affiner le comportement visuel avec des effets tels que les coupures depuis le noir ou les entrées directionnelles. La bibliothèque prend également en charge la transition Morph introduite dans PowerPoint 2019, incluant des modes qui morphent par objet, mot ou caractère afin de créer un mouvement fluide et cohérent entre les diapositives.

## **Ajouter des transitions de diapositives**

Pour faciliter la compréhension, cet exemple montre comment utiliser Aspose.Slides for Python pour gérer des transitions de diapositives simples. Les développeurs peuvent appliquer différents effets de transition de diapositive aux diapositives et personnaliser leur comportement. Pour créer une transition de diapositive simple, suivez les étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Appliquez une transition de diapositive en utilisant l’un des effets de l’énumération [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Enregistrez le fichier de présentation modifié.

```py
import aspose.slides as slides

# Instantiate the Presentation class to load a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Apply a circle transition to slide 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Apply a comb transition to slide 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des transitions de diapositives avancées**

Dans cette section, nous avons appliqué un effet de transition simple à une diapositive. Pour rendre cet effet plus contrôlé et poli, suivez les étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Appliquez une transition de diapositive en utilisant l’un des effets de l’énumération [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Configurez la transition pour avancer au clic, après un délai spécifique, ou les deux.
1. Enregistrez le fichier de présentation modifié.

Si **Advance On Click** est activé, la diapositive avance uniquement lorsque l’utilisateur clique. Si la propriété **Advance After Time** est définie, la diapositive avance automatiquement après l’intervalle spécifié.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Apply a circle transition to slide 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Enable advance on click and set a 3-second auto-advance.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Apply a comb transition to slide 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Enable advance on click and set a 5-second auto-advance.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Apply a zoom transition to slide 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Enable advance on click and set a 7-second auto-advance.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Transition Morph**

Aspose.Slides for Python prend en charge la [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), qui anime le déplacement fluide d’une diapositive à la suivante. Cette section explique comment utiliser la transition Morph. Pour l’utiliser efficacement, vous avez besoin de deux diapositives partageant au moins un objet commun. L’approche la plus simple consiste à dupliquer une diapositive puis à déplacer l’objet vers une position différente sur la deuxième diapositive.

Le fragment de code suivant montre comment cloner une diapositive contenant du texte et appliquer une transition Morph à la deuxième diapositive.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Clone the first slide to create a second slide with the same shapes for Morph continuity.
    slide1 = presentation.slides.add_clone(slide0)

    # Select the same rectangle on the second slide and change its position and size.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Enable the Morph transition on the second slide to animate the shape changes smoothly.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Types de transition Morph**

L’énumération [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) représente les différents types de transitions Morph de diapositive.

Le fragment de code suivant montre comment appliquer une transition Morph à une diapositive et modifier le type de morph :

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir les effets de transition**

Aspose.Slides for Python vous permet de définir des effets de transition tels que **From Black**, **From Left**, **From Right**, etc. Pour configurer un effet de transition, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive.
1. Définissez l’effet de transition souhaité.
1. Enregistrez la présentation au format PPTX.

Dans l’exemple ci‑dessous, nous définissons plusieurs effets de transition.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Apply a Cut transition and enable From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis-je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Définissez la [vitesse](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) de la transition à l’aide du paramètre [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (par ex., lent/moyen/rapide).

**Puis-je ajouter un son à une transition et le faire boucler ?**

Oui. Vous pouvez incorporer un son pour la transition et contrôler son comportement via des paramètres tels que le mode son et la boucle (par ex., [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), ainsi que des métadonnées comme [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) et [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Quelle est la façon la plus rapide d’appliquer la même transition à chaque diapositive ?**

Configurez le type de transition souhaité dans les paramètres de transition de chaque diapositive ; les transitions étant stockées par diapositive, appliquer le même type à toutes les diapositives donne un résultat cohérent.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Inspectez les [paramètres de transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) de la diapositive et lisez son [type de transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ; cette valeur indique exactement quel effet est appliqué.