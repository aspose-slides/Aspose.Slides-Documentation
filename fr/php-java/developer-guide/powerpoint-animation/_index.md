---
title: Animation PowerPoint
type: docs
weight: 150
url: /php-java/powerpoint-animation/
keywords: "animation PowerPoint"
description: "Animation PowerPoint, animation de diapositives PowerPoint avec Aspose.Slides."
---

Puisque les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**L'animation PowerPoint** joue un rôle important pour rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides pour PHP via Java offre un large éventail d'options pour ajouter une animation à la présentation PowerPoint :

- appliquer divers types d'effets d'animation PowerPoint sur des formes, des graphiques, des tableaux, des objets OLE et d'autres éléments de la présentation.
- utiliser plusieurs effets d'animation PowerPoint sur une forme.
- utiliser une chronologie d'animation pour contrôler les effets d'animation.
- créer une animation personnalisée.

Dans Aspose.Slides pour PHP via Java, divers effets d'animation peuvent être appliqués aux formes. Comme chaque élément de la diapositive, y compris le texte, les images, les objets OLE, les tableaux, etc., est considéré comme une forme, cela signifie que nous pouvons appliquer un effet d'animation sur chaque élément d'une diapositive.


## **Effets d'Animation**
Aspose.Slides prend en charge **150+ effets d'animation**, y compris des effets d'animation de base tels que Bounce, PathFootball, effet Zoom et des effets d'animation spécifiques tels que OLEObjectShow, OLEObjectOpen. Vous pouvez trouver une liste complète des effets d'animation dans l'énumération [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

De plus, ces effets d'animation peuvent être utilisés en combinaison avec les suivants :

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **Animation Personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. 
Cela peut être réalisé si vous combinez plusieurs comportements ensemble dans une nouvelle animation personnalisée.

[**Comportement**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) est une unité de base de tout effet d'animation PowerPoint. Tous les effets d'animation sont en fait un ensemble de comportements composés en une seule stratégie. Vous pouvez combiner des comportements dans une animation personnalisée une fois et les réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard - cela sera une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire répéter plusieurs fois.

[**Point d'Animation**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) est un point où le comportement doit être appliqué.

## **Chronologie d'Animation**
[**Séquence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) est une collection d'effets d'animation, appliqués sur une forme concrète.

[**Chronologie**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) est un ensemble de Séquences utilisé dans une diapositive concrète. C'est un moteur d'animation représenté depuis PowerPoint 2002. Dans les versions précédentes de PowerPoint, il était difficile d'ajouter des effets d'animation à une présentation, ce qui ne pouvait se faire que par différents contournements. La chronologie remplace l'ancienne classe AnimationSettings et fournit un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive peut avoir seulement une chronologie d'animation.

## **Animation Interactive**
[**Déclencheur**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) permet de définir des actions utilisateur (par exemple, clic sur un bouton), qui déclencheront le démarrage d'une certaine animation. Les déclencheurs n'ont été ajoutés que dans la dernière version de PowerPoint.

## **Animation de Forme**
Aspose.Slides permet d'appliquer une animation aux formes, qui peuvent en fait être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="primary" %}} 
Lire plus [**À propos de l'Animation de Forme**](/slides/php-java/shape-animation/).
{{% /alert %}}

## **Graphiques Animés**
Pour créer des graphiques animés, vous devez utiliser toutes les mêmes classes que pour les formes. Cependant, il est possible d'utiliser une animation PowerPoint uniquement sur des catégories de graphiques ou des séries de graphiques. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou un élément de série.

{{% alert color="primary" %}} 
Lire plus [**À propos des Graphiques Animés**](/slides/php-java/animated-charts/).
{{% /alert %}}

## **Texte Animé**
En plus du texte animé, il est également possible d'appliquer une animation à un paragraphe.

{{% alert color="primary" %}} 
Lire plus [**À propos du Texte Animé**](/slides/php-java/animated-text/).
{{% /alert %}}