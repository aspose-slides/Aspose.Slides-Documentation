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
description: "Découvrez comment personnaliser les transitions de diapositives dans Aspose.Slides pour Python via .NET, avec un guide étape par étape pour les présentations PowerPoint et OpenDocument."
---

## **Aperçu**

Aspose.Slides for Python offre un contrôle complet sur les transitions de diapositive, depuis la sélection du type de transition jusqu’à la configuration du timing et des déclencheurs dans le cadre de flux de travail de présentation automatisés. Vous pouvez définir les diapositives pour qu’elles avancent au clic et/ou après un délai spécifié et affiner le comportement visuel avec des effets tels que des coupures depuis le noir ou des entrées directionnelles. La bibliothèque prend également en charge la transition **Morph** introduite dans PowerPoint 2019, incluant des modes qui morphent par objet, mot ou caractère pour créer un mouvement fluide et cohérent entre les diapositives.

## **Ajouter des transitions de diapositive**

Pour faciliter la compréhension, cet exemple montre comment utiliser Aspose.Slides for Python pour gérer des transitions de diapositive simples. Les développeurs peuvent appliquer différents effets de transition aux diapositives et personnaliser leur comportement. Pour créer une transition de diapositive simple, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Appliquez une transition de diapositive en utilisant l’un des effets de l’énumération [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Enregistrez le fichier de présentation modifié.
```py
import aspose.slides as slides

# Instanciez la classe Presentation pour charger un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Appliquez une transition cercle à la diapositive 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Appliquez une transition peigne à la diapositive 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Enregistrez la présentation sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter des transitions de diapositive avancées**

Dans cette section, nous avons appliqué un effet de transition simple à une diapositive. Pour rendre cet effet plus contrôlé et poli, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Appliquez une transition de diapositive en utilisant l’un des effets de l’énumération [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Configurez la transition pour **Advance On Click**, après un intervalle de temps spécifique, ou les deux.
1. Enregistrez le fichier de présentation modifié.

Si **Advance On Click** est activé, la diapositive avance uniquement lorsque l’utilisateur clique. Si la propriété **Advance After Time** est définie, la diapositive avance automatiquement après l’intervalle spécifié.
```py
import aspose.slides as slides

# Instanciez la classe Presentation pour ouvrir un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Appliquez une transition cercle à la diapositive 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Activez l'avance au clic et définissez une avancée automatique de 3 secondes.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Appliquez une transition peigne à la diapositive 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Activez l'avance au clic et définissez une avancée automatique de 5 secondes.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Appliquez une transition zoom à la diapositive 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Activez l'avance au clic et définissez une avancée automatique de 7 secondes.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Enregistrez la présentation sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Transition Morph**

Aspose.Slides for Python prend en charge la [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), qui anime le mouvement fluide d’une diapositive à la suivante. Cette section explique comment utiliser la transition Morph. Pour l’utiliser efficacement, vous avez besoin de deux diapositives partageant au moins un objet commun. L’approche la plus simple consiste à dupliquer une diapositive puis à déplacer l’objet vers une position différente sur la deuxième diapositive.

Le fragment de code suivant montre comment cloner une diapositive contenant du texte et appliquer une transition Morph à la deuxième diapositive.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Clonez la première diapositive pour créer une deuxième diapositive avec les mêmes formes afin d'assurer la continuité du morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Sélectionnez le même rectangle sur la deuxième diapositive et modifiez sa position et sa taille.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Activez la transition Morph sur la deuxième diapositive pour animer les modifications de forme en douceur.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Types de transition Morph**

L’énumération [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) représente les différents types de transitions de diapositive Morph.

Le fragment de code suivant montre comment appliquer une transition Morph à une diapositive et changer le type de morph :
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir les effets de transition**

Aspose.Slides for Python vous permet de définir des effets de transition tels que **From Black**, **From Left**, **From Right**, etc. Pour configurer un effet de transition, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive.
1. Définissez l’effet de transition souhaité.
1. Enregistrez la présentation au format PPTX.

Dans l’exemple ci‑dessous, nous définissons plusieurs effets de transition.
```py
import aspose.slides as slides

# Instanciez la classe Presentation pour ouvrir un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Appliquez une transition Cut et activez From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Enregistrez la présentation sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis‑je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Définissez la **[speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)** de la transition en utilisant le paramètre [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (par ex. : lente/moyenne/rapide).

**Puis‑je attacher un son à une transition et le faire boucler ?**

Oui. Vous pouvez intégrer un son à la transition et contrôler son comportement via des paramètres tels que le mode sonore et la boucle (par ex. : [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), ainsi que des métadonnées comme [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) et [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Quelle est la façon la plus rapide d’appliquer la même transition à toutes les diapositives ?**

Configurez le type de transition souhaité dans les paramètres de transition de chaque diapositive ; les transitions sont stockées par diapositive, ainsi appliquer le même type à toutes les diapositives donne un résultat cohérent.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Inspectez les **[transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/)** de la diapositive et lisez son **[transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/)** ; cette valeur indique exactement quel effet est appliqué.
