---
title: Animation PowerPoint
type: docs
weight: 150
url: /python-net/powerpoint-animation/
keywords: "Animation, effets d'animation, animation PowerPoint, chronologie d'animation, animation interactive, animation de forme, graphique animé, texte animé, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Animation et effets de présentation PowerPoint en Python"
---

Puisque les présentations sont conçues pour présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**L'animation PowerPoint** joue un rôle important pour rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides pour Python via .NET offre une large gamme d'options pour ajouter de l'animation à une présentation PowerPoint :

- appliquer divers types d'effets d'animation PowerPoint sur des formes, graphiques, tableaux, objets OLE et autres éléments de présentation.
- utiliser plusieurs effets d'animation PowerPoint sur une forme.
- utiliser une chronologie d'animation pour contrôler les effets d'animation.
- créer une animation personnalisée.

Dans Aspose.Slides pour Python via .NET, divers effets d'animation peuvent être appliqués sur les formes. Comme chaque élément sur la diapositive, y compris le texte, les images, l'objet OLE, le tableau, etc., est considéré comme une forme, cela signifie que nous pouvons appliquer un effet d'animation sur chaque élément d'une diapositive.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) **espace de noms** fournit des classes pour travailler avec les animations PowerPoint.
## **Effets d'Animation**
Aspose.Slides prend en charge **150+ effets d'animation**, y compris des effets d'animation de base comme Bounce, PathFootball, effet Zoom et des effets d'animation spécifiques comme OLEObjectShow, OLEObjectOpen. Vous pouvez trouver une liste complète des effets d'animation dans l’[**énumération EffectType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/).

De plus, ces effets d'animation peuvent être utilisés en combinaison avec ceux-ci :

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)
## **Animation Personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. 
Cela peut être réalisé si vous combinez plusieurs comportements ensemble dans une nouvelle animation personnalisée.

[**Comportement**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) est une unité de base de tout effet d'animation PowerPoint. Tous les effets d'animation sont en fait un ensemble de comportements composés en une seule stratégie. Vous pouvez combiner des comportements en une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard - ce sera une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour qu'elle se répète plusieurs fois.

[**Point d'Animation**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) est un point où le comportement doit être appliqué.
## **Chronologie d'Animation**
[**Séquence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) est une collection d'effets d'animation appliqués sur une forme concrète.

[**Chronologie**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) est un ensemble de séquences utilisé dans une diapositive concrète. C'est un moteur d'animation représenté depuis PowerPoint 2002. Dans les versions PowerPoint précédentes, il était difficile d'ajouter des effets d'animation à la présentation, ce qui ne pouvait être réalisé qu'avec différents contournements. La chronologie vient remplacer l'ancienne classe AnimationSettings et fournir un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut avoir qu'une seule chronologie d'animation.
## **Animation Interactive**
[**Déclencheur**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) permet de définir des actions utilisateur (par exemple, clic sur un bouton), qui déclencheront le début d'une certaine animation. Les déclencheurs ont été ajoutés uniquement dans la dernière version de PowerPoint.
## **Animation de Forme**
Aspose.Slides permet d'appliquer de l'animation aux formes, qui peuvent en fait être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="primary" %}} 
En savoir plus sur [**L'Animation de Forme**](/slides/python-net/shape-animation/).
{{% /alert %}}

## **Graphiques Animés**
Pour créer des graphiques animés, vous devez utiliser toutes les mêmes classes que pour les formes. Cependant, il est possible d'utiliser l'animation PowerPoint uniquement sur les catégories de graphiques ou les séries de graphiques. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="primary" %}} 
En savoir plus sur [**Les Graphiques Animés**](/slides/python-net/animated-charts/).
{{% /alert %}}

## **Texte Animé**
En plus du texte animé, il est également possible d'appliquer de l'animation à un paragraphe.

{{% alert color="primary" %}} 
En savoir plus sur [**Le Texte Animé**](/slides/python-net/animated-text/).
{{% /alert %}}