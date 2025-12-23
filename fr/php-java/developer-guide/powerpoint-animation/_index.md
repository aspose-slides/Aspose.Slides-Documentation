---
title: Améliorer les présentations PowerPoint avec des animations en PHP
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/php-java/powerpoint-animation/
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
- PHP
- Aspose.Slides
description: "Explorez les capacités d'Aspose.Slides pour PHP via Java dans la gestion des animations PowerPoint. Fonctionnalités clés et informations pour améliorer vos présentations."
---

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**Animation PowerPoint** joue un rôle important afin de rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides for PHP via Java propose une large gamme d'options pour ajouter des animations aux présentations PowerPoint :

- appliquer divers types d'effets d'animation PowerPoint sur des formes, des graphiques, des tableaux, des objets OLE et d'autres éléments de présentation.
- utiliser plusieurs effets d'animation PowerPoint sur une forme.
- utiliser la chronologie d'animation pour contrôler les effets d'animation.
- créer des animations personnalisées.

Dans Aspose.Slides for PHP via Java, divers effets d'animation peuvent être appliqués aux formes. Comme chaque élément de la diapositive, y compris le texte, les images, les objets OLE, les tableaux, etc., est considéré comme une forme, cela signifie que nous pouvons appliquer un effet d'animation à chaque élément d'une diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **150 + effets d'animation**, y compris des effets d'animation de base tels que Bounce, PathFootball, l'effet Zoom et des effets d'animation spécifiques comme OLEObjectShow, OLEObjectOpen. Vous pouvez trouver une liste complète des effets d'animation dans l'énumération [**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

De plus, ces effets d'animation peuvent être combinés avec eux :
- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements pour créer une nouvelle animation personnalisée.

[**Behavior**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior) est une unité de construction de tout effet d'animation PowerPoint. Tous les effets d'animation sont en fait un ensemble de comportements composés en une seule stratégie. Vous pouvez combiner des comportements en une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard, cela constituera une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire répéter plusieurs fois.

[**Animation Point**](https://reference.aspose.com/slides/php-java/aspose.slides/Point) est un point où le comportement doit être appliqué.

## **Chronologie d'animation**
[**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) est une collection d'effets d'animation appliquée à une forme concrète.

[**Timeline**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine) est un ensemble de Séquences utilisé dans une diapositive concrète. C'est un moteur d'animation présent depuis PowerPoint 2002. Dans les versions antérieures de PowerPoint, il était difficile d'ajouter des effets d'animation à une présentation, ce qui ne pouvait être réalisé qu'avec différentes solutions de contournement. La chronologie remplace l'ancienne classe AnimationSettings et fournit un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**
[**Trigger**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType) permet de définir des actions utilisateur (par ex. clic de bouton) qui déclencheront le démarrage d'une animation donnée. Les déclencheurs n'ont été ajoutés que dans la dernière version de PowerPoint.

## **Animation de forme**
Aspose.Slides permet d'appliquer des animations aux formes, qui peuvent être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="primary" %}} 
En savoir plus [**About Shape Animation**](/slides/fr/php-java/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, il est possible d'appliquer l'animation PowerPoint uniquement aux catégories de graphique ou aux séries de graphique. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="primary" %}} 
En savoir plus [**About Animated Charts**](/slides/fr/php-java/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus du texte animé, il est également possible d'appliquer une animation à un paragraphe.

{{% alert color="primary" %}} 
En savoir plus [**About Animated Text**](/slides/fr/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront‑telles conservées lors de l'exportation en PDF ?**

Non. Le PDF est un format statique, donc les animations et les [slide transitions](/slides/fr/php-java/slide-transition/) ne s'exécutent pas. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/php-java/export-to-html5/), [animated GIF](/slides/fr/php-java/convert-powerpoint-to-animated-gif/), ou [video](/slides/fr/php-java/convert-powerpoint-to-video/).

**Puis‑je convertir une présentation animée en vidéo et contrôler le taux d'images et la taille des images ?**

Oui. Vous pouvez [render the presentation as frames](/slides/fr/php-java/convert-powerpoint-to-video/) et les encoder en vidéo (par ex. avec ffmpeg), en choisissant le nombre d'images par seconde et la résolution. Les animations et les transitions de diapositive sont jouées pendant le rendu.

**Les animations resteront‑elles intactes lors de l'utilisation d'ODP (pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [reading](/slides/fr/php-java/open-presentation/) et la [writing](/slides/fr/php-java/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Vérifiez les cas critiques avec des exemples réels.