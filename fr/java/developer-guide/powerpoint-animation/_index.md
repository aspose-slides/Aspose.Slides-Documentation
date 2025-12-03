---
title: Améliorer les présentations PowerPoint avec des animations en Java
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/java/powerpoint-animation/
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
- Java
- Aspose.Slides
description: "Découvrez les capacités d'Aspose.Slides pour Java dans la gestion des animations PowerPoint. Cet aperçu général met en évidence les fonctionnalités clés et offre des conseils pour enrichir vos présentations."
---

## **Vue d'ensemble**

Comme les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**L'animation PowerPoint** joue un rôle important pour rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides for Java propose un large éventail d'options pour ajouter des animations à une présentation PowerPoint :

- appliquer différents types d'effets d'animation PowerPoint sur les formes, les graphiques, les tableaux, les objets OLE et les autres éléments de la présentation.
- utiliser plusieurs effets d'animation PowerPoint sur une forme.
- utiliser la chronologie d'animation pour contrôler les effets d'animation.
- créer des animations personnalisées.

Dans Aspose.Slides for Java, divers effets d'animation peuvent être appliqués aux formes. Comme chaque élément de la diapositive, y compris le texte, les images, les objets OLE, les tableaux, etc., est considéré comme une forme, cela signifie que nous pouvons appliquer un effet d'animation à chaque élément d'une diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets d'animation de base tels que Bounce, PathFootball, l'effet Zoom et des effets d'animation spécifiques comme OLEObjectShow, OLEObjectOpen. Vous pouvez trouver la liste complète des effets d'animation dans l'énumération [**EffectType**](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype/).

De plus, ces effets d'animation peuvent être utilisés en combinaison avec eux :

- [ColorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/java/com.aspose.slides/SetEffect)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements en une nouvelle animation personnalisée.

[**Behavior**](https://reference.aspose.com/slides/java/com.aspose.slides/Behavior) est une unité de construction de tout effet d'animation PowerPoint. Tous les effets d'animation sont en fait un ensemble de comportements composés en une stratégie unique. Vous pouvez combiner des comportements dans une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard, cela deviendra une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire se répéter plusieurs fois.

[**Animation Point**](https://reference.aspose.com/slides/java/com.aspose.slides/Point) est le point où le comportement doit être appliqué.

## **Chronologie d'animation**
[**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) est une collection d'effets d'animation appliquée à une forme concrète.

[**Timeline**](https://reference.aspose.com/slides/java/com.aspose.slides/AnimationTimeLine) est un ensemble de Séquences utilisé dans une diapositive concrète. C'est un moteur d'animation présent depuis PowerPoint 2002. Dans les versions précédentes de PowerPoint, il était difficile d'ajouter des effets d'animation à une présentation, ce qui ne pouvait être réalisé qu'avec diverses solutions de contournement. La chronologie vient remplacer l'ancienne classe AnimationSettings et offre un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**
[**Trigger**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectTriggerType) permet de définir des actions utilisateur (par exemple un clic de bouton) qui déclencheront le démarrage d'une animation donnée. Les déclencheurs ont été ajoutés uniquement dans la dernière version de PowerPoint.

## **Animation de forme**
Aspose.Slides permet d'appliquer des animations aux formes, qui peuvent être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="primary" %}} 
En savoir plus [**À propos de l'animation de forme**](/slides/fr/java/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, il est possible d'utiliser l'animation PowerPoint uniquement sur les catégories de graphique ou les séries de graphique. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="primary" %}} 
En savoir plus [**À propos des graphiques animés**](/slides/fr/java/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus du texte animé, il est également possible d'appliquer une animation à un paragraphe.

{{% alert color="primary" %}} 
En savoir plus [**À propos du texte animé**](/slides/fr/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront-elles conservées lors de l'exportation en PDF ?**

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/java/slide-transition/) ne se lisent pas. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/java/export-to-html5/), [GIF animé](/slides/fr/java/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/java/convert-powerpoint-to-video/).

**Puis-je transformer une présentation animée en vidéo et contrôler le taux d'images et la taille du cadre ?**

Oui. Vous pouvez [rendre la présentation en images](/slides/fr/java/convert-powerpoint-to-video/) et les encoder en vidéo (par exemple avec ffmpeg), en choisissant le nombre d'images par seconde et la résolution. Les animations et les transitions de diapositive sont jouées lors du rendu.

**Les animations resteront-elles intactes lors de l'utilisation d'ODP (et pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/java/open-presentation/) et l'[écriture](/slides/fr/java/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Vérifiez les cas critiques avec des exemples réels.