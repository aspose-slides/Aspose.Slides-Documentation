---
title: Améliorer les présentations PowerPoint avec des animations en Python via Java
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/python-java/powerpoint-animation/
keywords:
- ajouter une animation
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
description: "Explorez les capacités d’Aspose.Slides pour Python via Java dans la gestion des animations PowerPoint. Cette vue d’ensemble générale met en évidence les fonctionnalités clés et offre des conseils pour améliorer vos présentations."
---
## **Introduction**

L'apparence visuelle et le comportement interactif sont pris en compte lors de la création des présentations.

**PowerPoint animation** joue un rôle important pour rendre une présentation attrayante et engageante pour les spectateurs. Aspose.Slides propose un large éventail d'options pour ajouter des animations aux présentations PowerPoint :

- Appliquer différents types d'effets d'animation PowerPoint aux formes, graphiques, tableaux, objets OLE et autres éléments de présentation.
- Utiliser plusieurs effets d'animation PowerPoint sur une même forme.
- Utiliser la chronologie d'animation pour contrôler les effets d'animation.
- Créer des animations personnalisées.

Dans Aspose.Slides, divers effets d'animation peuvent être appliqués aux formes. Puisque chaque élément d’une diapositive, y compris le texte, les images, les objets OLE et les tableaux, est considéré comme une forme, les effets d'animation peuvent être appliqués à n’importe quel élément de la diapositive.

## **Effets d'animation**

Aspose.Slides prend en charge **150+ effets d'animation**, y compris des effets de base tels que Bounce, PathFootball et Zoom, ainsi que des effets spécifiques tels que OLEObjectShow et OLEObjectOpen. Vous pouvez trouver la liste complète dans la classe [EffectType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttype/).

De plus, ces effets d'animation peuvent être utilisés en combinaison avec les comportements suivants :

- [ColorEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/seteffect/)

## **Animation personnalisée**

Pour des exemples complets Python via Java qui créent, inspectent et modifient des comportements et des trajectoires de mouvement éditables, voir [Animation personnalisée](/slides/fr/python-java/custom-animation/).

Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements en une nouvelle animation personnalisée.

[Behavior](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behavior/) est un élément de base d’un effet d’animation PowerPoint. Combinez des comportements pour personnaliser un effet, ou ajoutez un comportement pour étendre un effet prédéfini. La répétition est configurée via les paramètres de timing plutôt que par un comportement de répétition séparé.

[Point](https://reference.aspose.com/slides/fr/python-java/aspose.slides/point/) est un point auquel un comportement doit être appliqué.

## **Chronologie d'animation**
[Sequence](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/) est une collection d’effets d’animation pouvant cibler différentes formes.

[AnimationTimeLine](https://reference.aspose.com/slides/fr/python-java/aspose.slides/animationtimeline/) est un ensemble de séquences utilisé sur une diapositive spécifique. Elle représente le moteur d’animation introduit dans PowerPoint 2002. Dans les versions antérieures de PowerPoint, ajouter des effets d’animation à une présentation était difficile et nécessitait des solutions de contournement. La chronologie offre un modèle d’objet plus clair pour les animations PowerPoint. Une diapositive ne peut contenir qu’une seule chronologie d’animation.

## **Animation interactive**
[EffectTriggerType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttriggertype/) permet de définir des actions utilisateur, telles qu’un clic de bouton, qui déclenchent une animation spécifique.

## **Animation de forme**
Aspose.Slides vous permet d’appliquer une animation aux formes, qui peuvent représenter du texte, des rectangles, des lignes, des cadres, des objets OLE et d’autres éléments.

{{% alert color="info" title="Note" %}}
En savoir plus [À propos de l'animation de forme](/slides/fr/python-java/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, utilisez les mêmes classes que pour les formes. Cependant, il n’est possible d’appliquer l’animation PowerPoint que sur les catégories de graphique ou les séries de graphique. Vous pouvez également appliquer un effet d’animation à un élément de catégorie ou à un élément de série.

{{% alert color="info" title="Note" %}}
En savoir plus [À propos des graphiques animés](/slides/fr/python-java/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus d’animer du texte, vous pouvez appliquer une animation à un paragraphe.

{{% alert color="info" title="Note" %}}
En savoir plus [À propos du texte animé](/slides/fr/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront-elles conservées lors de l'exportation vers PDF ?**

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/python-java/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez vers [HTML5](/slides/fr/python-java/export-to-html5/), [animated GIF](/slides/fr/python-java/convert-powerpoint-to-animated-gif/) ou [video](/slides/fr/python-java/convert-powerpoint-to-video/) à la place.

**Puis-je transformer une présentation animée en vidéo et contrôler le taux d’images et la taille des images ?**

Oui. Vous pouvez [render the presentation as frames](/slides/fr/python-java/convert-powerpoint-to-video/) et les encoder dans une vidéo (par ex. via ffmpeg), en choisissant le FPS et la résolution. Les animations et les transitions de diapositive sont lues pendant le rendu.

**Les animations resteront-elles intactes lors de l’utilisation d’ODP (et pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/python-java/open-presentation/) et l’[écriture](/slides/fr/python-java/save-presentation/), mais cela ne garantit pas la conservation des animations. Les données d’animation personnalisées peuvent être perdues lors de la conversion en ODP. Voir [Animation personnalisée](/slides/fr/python-java/custom-animation/) pour des exemples et des conseils sur la vérification de la compatibilité des formats.