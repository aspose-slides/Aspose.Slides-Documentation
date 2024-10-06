---
title: Animation PowerPoint
type: docs
weight: 150
url: /java/powerpoint-animation/
keywords: "animation PowerPoint"
description: "Animation PowerPoint, animation de diapositives PowerPoint avec Aspose.Slides."
---

Puisque les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**L'animation PowerPoint** joue un rôle important pour rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides pour Java offre un large éventail d'options pour ajouter de l'animation à la présentation PowerPoint :

- appliquer divers types d'effets d'animation PowerPoint sur des formes, des graphiques, des tableaux, des objets OLE et d'autres éléments de la présentation.
- utiliser plusieurs effets d'animation PowerPoint sur une forme.
- utiliser une chronologie d'animation pour contrôler les effets d'animation.
- créer une animation personnalisée.

Dans Aspose.Slides pour Java, divers effets d'animation peuvent être appliqués aux formes. Comme chaque élément de la diapositive, y compris le texte, les images, les objets OLE, les tableaux, etc., est considéré comme une forme, cela signifie que nous pouvons appliquer un effet d'animation à chaque élément d'une diapositive.

## **Effets d'Animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets d'animation de base comme Bounce, PathFootball, effet Zoom et des effets d'animation spécifiques comme OLEObjectShow, OLEObjectOpen. Vous pouvez trouver une liste complète des effets d'animation dans l'énumération [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

De plus, ces effets d'animation peuvent être utilisés en combinaison avec les suivants :

- [ColorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/java/com.aspose.slides/SetEffect)

## **Animation Personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. 
Cela peut être réalisé si vous combinez plusieurs comportements ensemble pour en faire une nouvelle animation personnalisée.

[**Behavior**](https://reference.aspose.com/slides/java/com.aspose.slides/Behavior) est une unité de construction de tout effet d'animation PowerPoint. Tous les effets d'animation sont en réalité un ensemble de comportements composés en une seule stratégie. Vous pouvez combiner des comportements en une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement dans un effet d'animation PowerPoint standard, cela deviendra une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire répéter plusieurs fois.

[**Animation Point**](https://reference.aspose.com/slides/java/com.aspose.slides/Point) est un point où le comportement doit être appliqué.

## **Chronologie d'Animation**
[**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) est une collection d'effets d'animation, appliqués sur une forme concrète.

[**Timeline**](https://reference.aspose.com/slides/java/com.aspose.slides/AnimationTimeLine) est un ensemble de séquences utilisées dans une diapositive concrète. C'est un moteur d'animation représenté depuis PowerPoint 2002. Dans les versions précédentes de PowerPoint, il était difficile d'ajouter des effets d'animation à la présentation, ce qui ne pouvait être réalisé qu'avec différents contournements. La chronologie vient remplacer l'ancienne classe AnimationSettings et fournit un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut avoir qu'une seule chronologie d'animation.

## **Animation Interactive**
[**Trigger**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectTriggerType) permet de définir des actions utilisateur (par exemple, clic sur un bouton), qui feront démarrer une certaine animation. Les déclencheurs n'ont été ajoutés que dans la dernière version de PowerPoint.

## **Animation de Forme**
Aspose.Slides permet d'appliquer de l'animation aux formes, qui peuvent être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="primary" %}} 
En savoir plus sur [**Animation de Forme**](/slides/java/shape-animation/).
{{% /alert %}}

## **Graphiques Animés**
Pour créer des graphiques animés, vous devez utiliser toutes les mêmes classes que pour les formes. Cependant, il est possible d'utiliser l'animation PowerPoint uniquement sur les catégories de graphiques ou les séries de graphiques. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="primary" %}} 
En savoir plus sur [**Graphiques Animés**](/slides/java/animated-charts/).
{{% /alert %}}

## **Texte Animé**
En plus du texte animé, il est également possible d'appliquer de l'animation à un paragraphe.

{{% alert color="primary" %}} 
En savoir plus sur [**Texte Animé**](/slides/java/animated-text/).
{{% /alert %}}