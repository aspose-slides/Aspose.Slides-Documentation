---
title: Améliorer les présentations PowerPoint avec des animations en .NET
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/net/powerpoint-animation/
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
- présentation PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Explorez les capacités d'Aspose.Slides pour .NET dans la gestion des animations PowerPoint. Cet aperçu général met en évidence les fonctionnalités clés et offre des idées pour améliorer vos présentations."
---
## **Introduction**

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de la création.

**PowerPoint animation** joue un rôle important pour rendre une présentation attrayante et captivante pour les spectateurs. Aspose.Slides for .NET fournit un large éventail d'options pour ajouter des animations aux présentations PowerPoint :

- Appliquer différents types d'effets d'animation PowerPoint aux formes, graphiques, tableaux, objets OLE et autres éléments de la présentation.
- Utiliser plusieurs effets d'animation PowerPoint sur une même forme.
- Utiliser la chronologie d'animation pour contrôler les effets d'animation.
- Créer des animations personnalisées.

Dans Aspose.Slides for .NET, divers effets d'animation peuvent être appliqués aux formes. Puisque chaque élément d’une diapositive, y compris le texte, les images, les objets OLE et les tableaux, est considéré comme une forme, les effets d'animation peuvent être appliqués à n’importe quel élément de la diapositive.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/) l'espace de noms fournit des classes pour travailler avec les animations PowerPoint.

## **Effets d'animation**

Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets de base tels que Bounce, PathFootball et Zoom, ainsi que des effets spécifiques tels que OLEObjectShow et OLEObjectOpen. Vous pouvez consulter la liste complète des effets d'animation dans l'énumération [EffectType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effecttype).

De plus, ces effets d'animation peuvent être combinés avec les éléments suivants :

- [ColorEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/seteffect)

## **Animation personnalisée**

Pour des exemples C# complets qui créent, inspectent et modifient les comportements et les trajectoires de mouvement éditables, voir [Animation personnalisée](/slides/fr/net/custom-animation/).

Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements pour former une nouvelle animation personnalisée.

[Behavior](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/behavior) est un élément de base d'un effet d'animation PowerPoint. Combinez des comportements pour personnaliser un effet, ou ajoutez un comportement pour étendre un effet prédefini. La répétition est configurée via les paramètres de chronométrage plutôt que par un comportement de répétition séparé.

[Animation Point](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/point) est un point où un comportement doit être appliqué.

## **Chronologie d'animation**

[Sequence](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/sequence) est une collection d'effets d'animation pouvant cibler différentes formes.

[Timeline](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/animationtimeline) est un ensemble de séquences utilisé dans une diapositive spécifique. C'est un moteur d'animation introduit dans PowerPoint 2002. Dans les versions antérieures de PowerPoint, ajouter des effets d'animation aux présentations était difficile et ne pouvait être réalisé qu'avec diverses solutions de contournement. La chronologie remplace l'ancienne classe AnimationSettings et fournit un modèle d'objet plus clair pour les animations PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**

[Trigger](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effecttriggertype) vous permet de définir des actions utilisateur (par ex., un clic de bouton) qui déclencheront une animation spécifique. Les déclencheurs ont été introduits dans la dernière version de PowerPoint.

## **Animation de forme**

Aspose.Slides vous permet d'appliquer des animations aux formes, qui peuvent inclure du texte, des rectangles, des lignes, des cadres, des objets OLE, etc.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos de l'animation de forme**](/slides/fr/net/shape-animation/).
{{% /alert %}}

## **Graphiques animés**

Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, les animations PowerPoint ne peuvent être appliquées qu'aux catégories de graphique ou aux séries de graphique. Vous pouvez également appliquer des effets d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos des graphiques animés**](/slides/fr/net/animated-charts/).
{{% /alert %}}

## **Texte animé**

En plus d'animer du texte, vous pouvez appliquer une animation à un paragraphe.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos du texte animé**](/slides/fr/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/net/slide-transition/) ne se lisent pas. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/net/export-to-html5/), [GIF animé](/slides/fr/net/convert-powerpoint-to-animated-gif/), ou [vidéo](/slides/fr/net/convert-powerpoint-to-video/).

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

Oui. Vous pouvez [rendre la présentation sous forme de trames](/slides/fr/net/convert-powerpoint-to-video/) et les encoder dans une vidéo (par exemple avec ffmpeg), en choisissant le nombre d'images par seconde et la résolution. Les animations et les transitions de diapositive sont lues pendant le rendu.

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/net/open-presentation/) et l'[écriture](/slides/fr/net/save-presentation/), mais cela ne garantit pas la conservation des animations. Les données d'animation personnalisées peuvent être perdues lors de la conversion en ODP. Consultez [Animation personnalisée](/slides/fr/net/custom-animation/) pour un exemple testé et les limitations du format.