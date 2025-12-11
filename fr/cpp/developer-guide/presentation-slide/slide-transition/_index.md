---
title: Gérer les transitions de diapositives dans les présentations avec C++
linktitle: Transition de diapositive
type: docs
weight: 80
url: /fr/cpp/slide-transition/
keywords:
- transition de diapositive
- ajouter transition de diapositive
- appliquer transition de diapositive
- transition de diapositive avancée
- transition morph
- type de transition
- effet de transition
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment personnaliser les transitions de diapositives dans Aspose.Slides pour C++, avec un guide pas à pas pour les présentations PowerPoint et OpenDocument."
---

## **Ajouter une transition de diapositive**
Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides for C++ pour gérer des transitions de diapositive simples. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositive aux diapositives, mais aussi personnaliser le comportement de ces effets de transition. Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Appliquer un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides for C++ via l'énumération TransitionType.
1. Enregistrer le fichier de présentation modifié.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Ajouter une transition de diapositive avancée**
Dans la section précédente, nous n'avons appliqué qu'un effet de transition simple sur la diapositive. Maintenant, pour rendre cet effet de transition simple encore meilleur et plus contrôlé, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Appliquer un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition proposés par Aspose.Slides for C++.
1. Vous pouvez également définir la transition pour qu'elle avance au clic, après une période de temps spécifique ou les deux.
1. Si la transition de diapositive est configurée pour avancer au clic, la transition ne progressera que lorsqu'un utilisateur cliquera avec la souris. De plus, si la propriété Advance After Time est définie, la transition avancera automatiquement après le délai spécifié.
1. Enregistrer la présentation modifiée sous forme de fichier de présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Transition Morph**
Aspose.Slides for C++ prend désormais en charge la transition Morph. Elle représente la nouvelle transition morph introduite dans PowerPoint 2019. La transition Morph vous permet d’animer un déplacement fluide d’une diapositive à l’autre. Cet article décrit le concept et la façon d’utiliser la transition Morph. Pour utiliser efficacement la transition Morph, vous devez disposer de deux diapositives partageant au moins un objet commun. La façon la plus simple consiste à dupliquer la diapositive, puis à déplacer l’objet sur la deuxième diapositive vers un autre emplacement.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Types de transition Morph**
Une nouvelle énumération Aspose.Slides.SlideShow.TransitionMorphType a été ajoutée. Elle représente différents types de transition de diapositive Morph.

L’énumération TransitionMorphType possède trois membres :

- ByObject : La transition Morph sera effectuée en considérant les formes comme des objets indivisibles.
- ByWord : La transition Morph sera effectuée en transférant le texte par mots lorsque cela est possible.
- ByChar : La transition Morph sera effectuée en transférant le texte par caractères lorsque cela est possible.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Définir les effets de transition**
Aspose.Slides for C++ prend en charge la définition des effets de transition tels que « depuis le noir », « depuis la gauche », « depuis la droite », etc. Pour définir l’effet de transition, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe Presentation.
- Obtenir une référence à la diapositive.
- Définir l’effet de transition.
- Enregistrer la présentation sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons défini les effets de transition.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Puis-je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Définissez la [vitesse](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) de la transition à l’aide du paramètre [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) (par exemple, lente/moyenne/rapide).

**Puis-je ajouter un audio à une transition et le faire boucler ?**

Oui. Vous pouvez intégrer un son à la transition et contrôler son comportement via des paramètres tels que le mode sonore et la lecture en boucle (par exemple, [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), ainsi que des métadonnées comme [set_SoundIsBuiltIn](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) et [set_SoundName](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Quelle est la façon la plus rapide d’appliquer la même transition à chaque diapositive ?**

Configurez le type de transition souhaité dans les paramètres de transition de chaque diapositive ; les transitions sont stockées par diapositive, donc appliquer le même type à toutes les diapositives donne un résultat cohérent.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**

Inspectez les [paramètres de transition](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_slideshowtransition/) de la diapositive et lisez son [type de transition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/get_type/) ; cette valeur indique exactement quel effet est appliqué.