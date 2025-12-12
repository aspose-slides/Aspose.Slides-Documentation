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
description: "Découvrez les capacités d'Aspose.Slides pour Android via Java dans la gestion des animations PowerPoint. Cet aperçu général met en avant les fonctionnalités clés."
---

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**Animation PowerPoint** joue un rôle important afin de rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides for Android via Java offre un large éventail d'options pour ajouter des animations à une présentation PowerPoint :

- appliquer différents types d'effets d'animation PowerPoint sur des formes, des graphiques, des tableaux, des objets OLE et d'autres éléments de la présentation.
- utiliser plusieurs effets d'animation PowerPoint sur une forme.
- utiliser la chronologie d'animation pour contrôler les effets d'animation.
- créer des animations personnalisées.

Dans Aspose.Slides for Android via Java, divers effets d'animation peuvent être appliqués aux formes. Comme chaque élément de la diapositive, y compris le texte, les images, les objets OLE, les tableaux, etc., est considéré comme une forme, cela signifie que nous pouvons appliquer un effet d'animation à chaque élément d'une diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets d'animation de base tels que Bounce, PathFootball, l'effet Zoom et des effets d'animation spécifiques comme OLEObjectShow, OLEObjectOpen. Vous pouvez trouver une liste complète des effets d'animation dans l'énumération **EffectType**.

De plus, ces effets d'animation peuvent être utilisés en combinaison avec eux :
- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements en une nouvelle animation personnalisée.

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) est une unité de base de tout effet d'animation PowerPoint. Tous les effets d'animation sont en réalité un ensemble de comportements composés en une seule stratégie. Vous pouvez combiner des comportements dans une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard, cela constituera une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire répéter plusieurs fois.

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) est un point où le comportement doit être appliqué.

## **Chronologie d'animation**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) est une collection d'effets d'animation, appliquée à une forme concrète.

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) est un ensemble de Séquences utilisées dans une diapositive concrète. C'est un moteur d'animation présent depuis PowerPoint 2002. Dans les versions précédentes de PowerPoint, il était difficile d'ajouter des effets d'animation à une présentation, ce qui ne pouvait être réalisé qu'avec différentes solutions de contournement. La chronologie remplace l'ancienne classe AnimationSettings et fournit un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) permet de définir des actions utilisateur (par ex. clic sur un bouton) qui déclencheront le démarrage d'une animation spécifique. Les déclencheurs ont été ajoutés uniquement dans la dernière version de PowerPoint.

## **Animation de forme**
Aspose.Slides permet d'appliquer des animations aux formes, qui peuvent être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="primary" %}} 
En savoir plus [**À propos de l'animation de forme**](/slides/fr/androidjava/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, il est possible d'utiliser l'animation PowerPoint uniquement sur les catégories de graphique ou les séries de graphique. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="primary" %}} 
En savoir plus [**À propos des graphiques animés**](/slides/fr/androidjava/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus du texte animé, il est également possible d'appliquer une animation à un paragraphe.

{{% alert color="primary" %}} 
En savoir plus [**À propos du texte animé**](/slides/fr/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront-elles conservées lors de l'exportation au PDF ?**

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/androidjava/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez vers [HTML5](/slides/fr/androidjava/export-to-html5/), [GIF animé](/slides/fr/androidjava/convert-powerpoint-to-animated-gif/), ou [vidéo](/slides/fr/androidjava/convert-powerpoint-to-video/) à la place.

**Puis-je convertir une présentation animée en vidéo et contrôler le taux d'images et la taille du cadre ?**

Oui. Vous pouvez [rendre la présentation sous forme d'images](/slides/fr/androidjava/convert-powerpoint-to-video/) et les encoder en vidéo (par ex. via ffmpeg), en choisissant les FPS et la résolution. Les animations et les transitions de diapositive sont lues pendant le rendu.

**Les animations resteront-elles intactes lors de l'utilisation d'ODP (et pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/androidjava/open-presentation/) et l'[écriture](/slides/fr/androidjava/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Validez les cas critiques avec des échantillons réels.