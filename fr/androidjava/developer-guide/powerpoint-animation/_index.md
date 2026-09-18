---
title: Améliorer les présentations PowerPoint avec des animations sur Android
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/androidjava/powerpoint-animation/
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
- Android
- Java
- Aspose.Slides
description: "Explorez les capacités d'Aspose.Slides pour Android via Java dans la gestion des animations PowerPoint. Cette vue d'ensemble générale met en avant les fonctionnalités clés."
---
## **Introduction**

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de la création.

**PowerPoint animation** joue un rôle important pour rendre une présentation attrayante et captivante pour les spectateurs. Aspose.Slides propose de nombreuses options pour ajouter des animations aux présentations PowerPoint :

- Appliquer divers types d'effets d'animation PowerPoint aux formes, graphiques, tableaux, objets OLE et autres éléments de présentation.
- Utiliser plusieurs effets d'animation PowerPoint sur une même forme.
- Utiliser la chronologie d'animation pour contrôler les effets d'animation.
- Créer des animations personnalisées.

Dans Aspose.Slides, divers effets d'animation peuvent être appliqués aux formes. Étant donné que chaque élément d'une diapositive, y compris le texte, les images, les objets OLE et les tableaux, est considéré comme une forme, les effets d'animation peuvent être appliqués à n'importe quel élément de la diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets de base tels que Bounce, PathFootball et Zoom, ainsi que des effets spécifiques tels que OLEObjectShow et OLEObjectOpen. Vous pouvez trouver la liste complète dans la classe [EffectType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/effecttype/).

De plus, ces effets d'animation peuvent être combinés avec les comportements suivants :

- [ColorEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SetEffect)

## **Animation personnalisée**
Pour des exemples Java complets qui créent, inspectent et modifient des comportements et des trajectoires de mouvement modifiables, consultez [Animation personnalisée](/slides/fr/java/custom-animation/).

Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements dans une nouvelle animation personnalisée.

[Behavior](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/behavior/) est un élément de base d'un effet d'animation PowerPoint. Combinez des comportements pour personnaliser un effet, ou ajoutez un comportement pour étendre un effet prédéfini. La répétition est configurée via les paramètres de chronométrage plutôt qu'avec un comportement de répétition distinct.

[Animation Point](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/point/) est un point où un comportement doit être appliqué.

## **Chronologie d'animation**
[Sequence](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sequence/) est une collection d'effets d'animation pouvant cibler différentes formes.

[Timeline](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/animationtimeline/) est un ensemble de séquences utilisées dans une diapositive spécifique. C'est un moteur d'animation introduit dans PowerPoint 2002. Dans les versions antérieures de PowerPoint, ajouter des effets d'animation aux présentations était difficile et ne pouvait être réalisé qu'avec diverses solutions de contournement. La chronologie offre un modèle d'objet plus clair pour les animations PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**
[Trigger](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/effecttriggertype/) vous permet de définir des actions utilisateur, telles qu'un clic sur un bouton, qui déclenchent une animation particulière.

## **Animation de forme**
Aspose.Slides vous permet d'appliquer des animations aux formes, qui peuvent inclure du texte, des rectangles, des lignes, des cadres, des objets OLE, et plus encore.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos de l'animation de forme**](/slides/fr/androidjava/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, les animations PowerPoint ne peuvent être appliquées qu'aux catégories de graphique ou aux séries de graphique. Vous pouvez également appliquer des effets d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos des graphiques animés**](/slides/fr/androidjava/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus d'animer du texte, vous pouvez appliquer une animation à un paragraphe.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos du texte animé**](/slides/fr/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront-elles conservées lors de l'exportation au format PDF ?**

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/androidjava/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/androidjava/export-to-html5/), [GIF animé](/slides/fr/androidjava/convert-powerpoint-to-animated-gif/), ou [vidéo](/slides/fr/androidjava/convert-powerpoint-to-video/).

**Puis-je transformer une présentation animée en vidéo et contrôler le nombre d'images par seconde et la taille du cadre ?**

Oui. Vous pouvez [rendre la présentation en images](/slides/fr/androidjava/convert-powerpoint-to-video/) et les encoder en vidéo (par exemple via ffmpeg), en choisissant le nombre d'images par seconde (FPS) et la résolution. Les animations et les transitions de diapositive sont jouées pendant le rendu.

**Les animations resteront-elles intactes lors de l'utilisation d'ODP (et pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/androidjava/open-presentation/) et l'[écriture](/slides/fr/androidjava/save-presentation/), mais cela ne garantit pas la préservation des animations. Les données d'animation personnalisées peuvent être perdues lors de la conversion en ODP. Consultez [Animation personnalisée pour Java](/slides/fr/java/custom-animation/) pour des exemples et des conseils sur la vérification de la compatibilité des formats.