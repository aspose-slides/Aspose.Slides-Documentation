---
title: Animation PowerPoint
type: docs
weight: 150
url: /fr/cpp/powerpoint-animation/
keywords: "animation PowerPoint"
description: "Animation PowerPoint, animation de diapositives PowerPoint avec Aspose.Slides."
---

Puisque les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**L'animation PowerPoint** joue un rôle important pour rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides pour C++ offre un large éventail d'options pour ajouter de l'animation à la présentation PowerPoint :

- appliquer différents types d'effets d'animation PowerPoint sur des formes, graphiques, tableaux, objets OLE et autres éléments de présentation.
- utiliser plusieurs effets d'animation PowerPoint sur une forme.
- utiliser la chronologie d'animation pour contrôler les effets d'animation.
- créer une animation personnalisée.

Dans Aspose.Slides pour C++, divers effets d'animation peuvent être appliqués sur les formes. Comme chaque élément de la diapositive, y compris le texte, les images, les objets OLE, les tableaux, etc., est considéré comme une forme, cela signifie que nous pouvons appliquer un effet d'animation sur chaque élément d'une diapositive.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** fournit des classes pour travailler avec les animations PowerPoint.
## **Effets d'animation**
Aspose.Slides prend en charge **150+ effets d'animation**, y compris des effets d'animation de base comme Bounce, PathFootball, Zoom effect et des effets d'animation spécifiques comme OLEObjectShow, OLEObjectOpen. Vous pouvez trouver une liste complète des effets d'animation dans l'**énumération EffectType**.

De plus, ces effets d'animation peuvent être utilisés en combinaison avec eux :

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. 
Cela peut être réalisé si vous combinez plusieurs comportements ensemble en une nouvelle animation personnalisée.

[**Comportement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) est une unité de construction de tout effet d'animation PowerPoint. Tous les effets d'animation sont en fait un ensemble de comportements composés en une stratégie. Vous pouvez combiner des comportements en une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard, ce sera une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour qu'elle se répète plusieurs fois.

[**Point d'animation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) est un point où le comportement doit être appliqué.

## **Chronologie d'animation**
[**Séquence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) est une collection d'effets d'animation, appliqués à une forme concrète.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) est un ensemble de séquences utilisées dans une diapositive concrète. C'est un moteur d'animation représenté depuis PowerPoint 2002. Dans les versions PowerPoint précédentes, il était difficile d'ajouter des effets d'animation à la présentation, ce qui ne pouvait être réalisé qu'avec différentes solutions de contournement. La chronologie vient remplacer l'ancienne classe AnimationSettings et fournir un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut avoir qu'une seule chronologie d'animation.
## **Animation interactive**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) permet de définir des actions utilisateur (par exemple, un clic de bouton), qui déclencheront le démarrage d'une certaine animation. Les déclencheurs ont été ajoutés uniquement dans la dernière version de PowerPoint.

## **Animation de formes**
Aspose.Slides permet d'appliquer de l'animation aux formes, qui peuvent être en fait du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="primary" %}} 
Lire la suite [**À propos de l'animation des formes**](/slides/fr/cpp/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser toutes les mêmes classes que pour les formes. Cependant, il est possible d'utiliser l'animation PowerPoint uniquement sur des catégories de graphiques ou des séries de graphiques. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou un élément de série.

{{% alert color="primary" %}} 
Lire la suite [**À propos des graphiques animés**](/slides/fr/cpp/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus du texte animé, il est également possible d'appliquer de l'animation à un paragraphe.

{{% alert color="primary" %}} 
Lire la suite [**À propos du texte animé**](/slides/fr/cpp/animated-text/).
{{% /alert %}}