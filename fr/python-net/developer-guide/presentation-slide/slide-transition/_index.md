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
- transition Morphose
- type de transition
- effet de transition
- Python
- Aspose.Slides
description: "Découvrez comment personnaliser les transitions de diapositives dans Aspose.Slides for Python via .NET, avec des instructions étape par étape pour les présentations PowerPoint et OpenDocument."
---

## **Ajouter une Transition de Diapo**
Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides pour Python via .NET pour gérer des transitions de diapositive simples. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositive sur les diapositives, mais aussi personnaliser le comportement de ces effets de transition. Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) classe.
1. Appliquez un Type de Transition de Diapo sur la diapositive à partir de l'un des effets de transition offerts par Aspose.Slides pour Python via .NET à travers l'énumération TransitionType.
1. Écrivez le fichier de présentation modifié.

```py
import aspose.slides as slides

# Instancier la classe Presentation pour charger le fichier de présentation source
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Appliquer une transition de type cercle sur la diapositive 1
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Appliquer une transition de type peigne sur la diapositive 2
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Écrire la présentation sur le disque
    presentation.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter une Transition de Diapo Avancée**
Dans la section ci-dessus, nous avons simplement appliqué un effet de transition simple sur la diapositive. Maintenant, pour améliorer et contrôler cet effet de transition simple, veuillez suivre les étapes ci-dessous :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) classe.
1. Appliquez un Type de Transition de Diapo sur la diapositive à partir de l'un des effets de transition offerts par Aspose.Slides pour Python via .NET.
1. Vous pouvez également définir la transition pour Avancer Au Clic, après une période de temps spécifique ou les deux.
1. Si la transition de diapositive est activée pour Avancer Au Clic, la transition n'avancera que lorsqu'une personne cliquera avec la souris. De plus, si la propriété Avancer Après Temps est définie, la transition avancera automatiquement après que le temps d'avance spécifié aura été écoulé.
1. Écrivez la présentation modifiée en tant que fichier de présentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation
with slides.Presentation(path + "BetterSlideTransitions.pptx") as pres:
    # Appliquer une transition de type cercle sur la diapositive 1
    pres.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE


    # Définir le temps de transition de 3 secondes
    pres.slides[0].slide_show_transition.advance_on_click = True
    pres.slides[0].slide_show_transition.advance_after_time = 3000

    # Appliquer une transition de type peigne sur la diapositive 2
    pres.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB


    # Définir le temps de transition de 5 secondes
    pres.slides[1].slide_show_transition.advance_on_click = True
    pres.slides[1].slide_show_transition.advance_after_time = 5000

    # Appliquer une transition de type zoom sur la diapositive 3
    pres.slides[2].slide_show_transition.type = slides.slideshow.TransitionType.ZOOM


    # Définir le temps de transition de 7 secondes
    pres.slides[2].slide_show_transition.advance_on_click = True
    pres.slides[2].slide_show_transition.advance_after_time = 7000

    # Écrire la présentation sur le disque
    pres.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Transition Morph**
Aspose.Slides pour Python via .NET prend désormais en charge la [Transition Morph](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/). Elle représente une nouvelle transition morph introduite dans PowerPoint 2019. La transition Morph vous permet d'animer un mouvement fluide d'une diapositive à l'autre. Cet article décrit le concept et comment utiliser la transition Morph. Pour utiliser la transition Morph efficacement, vous devrez disposer de deux diapositives avec au moins un objet en commun. Le moyen le plus simple est de dupliquer la diapositive, puis de déplacer l'objet sur la deuxième diapositive à un endroit différent.

Le code suivant vous montre comment ajouter un clone de la diapositive avec du texte à la présentation et définir une transition de [type morph](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/) pour la deuxième diapositive.



```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoshape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    autoshape.text_frame.text = "Transition Morph dans les Présentations PowerPoint"

    presentation.slides.add_clone(presentation.slides[0])

    presentation.slides[1].shapes[0].x += 100
    presentation.slides[1].shapes[0].y += 50
    presentation.slides[1].shapes[0].width -= 200
    presentation.slides[1].shapes[0].height -= 10

    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Types de Transition Morph**
Une nouvelle énumération [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) a été ajoutée. Elle représente différents types de transition morph.

L'énumération TransitionMorphType a trois membres :

- ByObject : La transition morph sera effectuée en considérant les formes comme des objets indivisibles.
- ByWord : La transition morph sera effectuée en transférant le texte par mots lorsque cela est possible.
- ByChar : La transition morph sera effectuée en transférant le texte par caractères lorsque cela est possible.

Le code suivant vous montre comment définir la transition morph pour une diapositive et changer le type morph :

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    presentation.slides[0].slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```



## **Définir les Effets de Transition**
Aspose.Slides pour Python via .NET prend en charge la définition des effets de transition tels que, de noir, de gauche, de droite, etc. Afin de définir l'Effet de Transition. Veuillez suivre les étapes ci-dessous :

- Créez une instance de [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)classe.
- Obtenez la référence de la diapositive.
- Définir l'effet de transition.
- Écrire la présentation en tant que fichier [PPTX ](https://docs.fileformat.com/presentation/pptx/).

Dans l'exemple ci-dessous, nous avons défini les effets de transition.

```py
import aspose.slides as slides

# Créer une instance de la classe Presentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:

    # Définir l'effet
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CUT
    presentation.slides[0].slide_show_transition.value.from_black = True

    # Écrire la présentation sur le disque
    presentation.save("SetTransitionEffects_out.pptx", slides.export.SaveFormat.PPTX)
```