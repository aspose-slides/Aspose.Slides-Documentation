---
title: Transition de Diapositive
type: docs
weight: 80
url: /cpp/slide-transition/
keywords: "transition de diapositive PowerPoint, transition morph"
description: "Transition de diapositive PowerPoint, transition morph PowerPoint avec Aspose.Slides."
---

## **Ajouter une Transition de Diapositive**
Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides pour C++ pour gérer des transitions de diapositive simples. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositive sur les diapositives, mais aussi personnaliser le comportement de ces effets de transition. Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Appliquez un Type de Transition de Diapositive sur la diapositive à partir d'un des effets de transition proposés par Aspose.Slides pour C++ via l'énumération TransitionType.
1. Écrivez le fichier de présentation modifié.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Ajouter une Transition de Diapositive Avancée**
Dans la section ci-dessus, nous avons simplement appliqué un effet de transition simple sur la diapositive. Maintenant, pour améliorer et contrôler cet effet de transition simple, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Appliquez un Type de Transition de Diapositive sur la diapositive à partir d'un des effets de transition proposés par Aspose.Slides pour C++.
1. Vous pouvez également définir la transition pour Avancer au Clic, après une période de temps spécifique ou les deux.
1. Si la transition de diapositive est activée pour Avancer au Clic, la transition ne progressera que lorsqu'une personne cliquera avec la souris. De plus, si la propriété Avancer Après Le Temps est définie, la transition avancera automatiquement après que le temps d'avance spécifié aura été écoulé.
1. Écrivez la présentation modifiée en tant que fichier de présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Transition Morph**
Aspose.Slides pour C++ prend désormais en charge la Transition Morph. Elle représente la nouvelle transition morph introduite dans PowerPoint 2019. La transition Morph vous permet d'animer un mouvement fluide d'une diapositive à l'autre. Cet article décrit le concept et comment utiliser la transition Morph. Pour utiliser efficacement la transition Morph, vous devrez avoir deux diapositives avec au moins un objet en commun. La manière la plus simple est de dupliquer la diapositive, puis de déplacer l'objet sur la seconde diapositive à un autre endroit.

Le code ci-dessous vous montre comment ajouter un clone de la diapositive avec du texte à la présentation et définir une transition de type morph pour la seconde diapositive.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Type de Transition Morph**
Une nouvelle énumération Aspose.Slides.SlideShow.TransitionMorphType a été ajoutée. Elle représente différents types de transition de diapositive Morph.

L'énumération TransitionMorphType a trois membres :

- ParObjet : La transition morph sera effectuée en considérant les formes comme des objets indivisibles.
- ParMot : La transition morph sera effectuée en transférant le texte par mots lorsque cela est possible.
- ParCaractère : La transition morph sera effectuée en transférant le texte par caractères lorsque cela est possible.

Le code ci-dessous vous montre comment définir une transition morph pour la diapositive et changer le type morph :

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Définir les Effets de Transition**
Aspose.Slides pour C++ prend en charge la définition des effets de transition tels que, de noir, de gauche, de droite, etc. Pour définir l'Effet de Transition, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe Presentation.
- Obtenez la référence de la diapositive.
- Définir l'effet de transition.
- Écrivez la présentation en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons défini les effets de transition.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}