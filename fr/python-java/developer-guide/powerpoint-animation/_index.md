---
title: Améliorer les présentations PowerPoint avec des animations en Python via Java
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/python-java/powerpoint-animation/
keywords:
- ajouter animation
- mettre à jour l'animation
- modifier l'animation
- supprimer l'animation
- gérer l'animation
- contrôler l'animation
- effet d'animation
- animation PowerPoint
- chronologie d'animation
- animation interactive
- animation personnalisée
- animation de forme
- graphique animé
- texte animé
- forme animée
- objet OLE animé
- image animée
- tableau animé
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez les capacités d'Aspose.Slides pour Python via Java dans la gestion des animations PowerPoint. Cette vue d'ensemble générale met en évidence les fonctionnalités clés et offre des conseils pour améliorer vos présentations."
---
## **Introduction**

Les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de la création.

**Animation PowerPoint** joue un rôle important pour rendre une présentation attrayante et engageante pour les spectateurs. Aspose.Slides propose un large éventail d'options pour ajouter des animations aux présentations PowerPoint :

- Appliquer divers types d'effets d'animation PowerPoint aux formes, graphiques, tableaux, objets OLE et autres éléments de la présentation.
- Utiliser plusieurs effets d'animation PowerPoint sur une même forme.
- Utiliser la chronologie des animations pour contrôler les effets d'animation.
- Créer des animations personnalisées.

Dans Aspose.Slides, divers effets d'animation peuvent être appliqués aux formes. Comme chaque élément d'une diapositive, y compris le texte, les images, les objets OLE et les tableaux, est considéré comme une forme, les effets d'animation peuvent être appliqués à n'importe quel élément de la diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets d'animation de base comme Bounce, PathFootball, l'effet Zoom et des effets d'animation spécifiques tels que OLEObjectShow, OLEObjectOpen. Vous pouvez consulter la liste complète des effets d'animation dans l'énumération [EffectType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttype/).

- [ColorEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/seteffect/)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé si vous combinez plusieurs comportements en une nouvelle animation personnalisée.

[Behavior](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behavior/) est une unité de construction de tout effet d'animation PowerPoint. Tous les effets d'animation sont en réalité un ensemble de comportements composés en une stratégie. Vous pouvez combiner des comportements en une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard, cela deviendra une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire répéter plusieurs fois.

[Point](https://reference.aspose.com/slides/fr/python-java/aspose.slides/point/) est un point où le comportement doit être appliqué.

## **Chronologie d'animation**
[Sequence](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/) est une collection d'effets d'animation, appliquée à une forme concrète.

[AnimationTimeLine](https://reference.aspose.com/slides/fr/python-java/aspose.slides/animationtimeline/) est un ensemble de Sequences utilisées dans une diapositive concrète. C'est un moteur d'animation présent depuis PowerPoint 2002. Dans les versions précédentes de PowerPoint, il était difficile d'ajouter des effets d'animation à la présentation, ce qui ne pouvait être réalisé qu'avec différentes solutions de contournement. La chronologie remplace l'ancienne classe AnimationSettings et fournit un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**
[EffectTriggerType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttriggertype/) permet de définir des actions utilisateur (par ex. clic de bouton) qui déclencheront le démarrage d'une certaine animation. Les déclencheurs n'ont été ajoutés que dans la dernière version de PowerPoint.

## **Animation des formes**
Aspose.Slides permet d'appliquer des animations aux formes, qui peuvent être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="info" title="Note" %}} 
En savoir plus [À propos de l'animation des formes](/slides/fr/python-java/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, il est possible d'utiliser l'animation PowerPoint uniquement sur les catégories de graphique ou les séries de graphique. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="info" title="Note" %}} 
En savoir plus [À propos des graphiques animés](/slides/fr/python-java/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus du texte animé, il est également possible d'appliquer une animation à un paragraphe.

{{% alert color="info" title="Note" %}} 
En savoir plus [À propos du texte animé](/slides/fr/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront-elles conservées lors de l'exportation vers PDF ?**
Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/python-java/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez plutôt en [HTML5](/slides/fr/python-java/export-to-html5/), [GIF animé](/slides/fr/python-java/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/python-java/convert-powerpoint-to-video/).

**Puis-je convertir une présentation animée en vidéo et contrôler le nombre d'images par seconde et la résolution ?**
Oui. Vous pouvez [rendre la présentation sous forme de frames](/slides/fr/python-java/convert-powerpoint-to-video/) et les encoder en vidéo (par ex. via ffmpeg), en choisissant le FPS et la résolution. Les animations et les [transitions de diapositive](/slides/fr/python-java/slide-transition/) sont jouées pendant le rendu.

**Les animations resteront-elles intactes lors de l'utilisation d'ODP (et pas seulement PPTX) ?**
PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/python-java/open-presentation/) et l'[écriture](/slides/fr/python-java/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Validez les cas critiques avec des exemples réels.