---
title: Améliorer les présentations PowerPoint avec des animations en C++
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/cpp/powerpoint-animation/
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
- C++
- Aspose.Slides
description: "Apprenez comment ajouter et contrôler des effets d'animation avancés dans Aspose.Slides pour C++ afin de créer des présentations PowerPoint et OpenDocument dynamiques."
---
## **Introduction**

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**L’animation PowerPoint** joue un rôle important pour rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides for C++ propose un large éventail d’options pour **ajouter des animations** à une présentation PowerPoint :

- appliquer différents types d’effets d’animation PowerPoint sur les formes, graphiques, tableaux, objets OLE et autres éléments de la présentation.
- utiliser plusieurs effets d’animation PowerPoint sur une même forme.
- utiliser la chronologie d’animation pour contrôler les effets d’animation.
- créer des animations personnalisées.

Dans Aspose.Slides for C++, divers effets d’animation peuvent être appliqués aux formes. Comme chaque élément de la diapositive, y compris le texte, les images, les objets OLE, les tableaux, etc., est considéré comme une forme, cela signifie que nous pouvons appliquer un effet d’animation à chaque élément d’une diapositive.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/fr/cpp/namespace/aspose.slides.animation) **namespace** fournit des classes pour travailler avec les animations PowerPoint.

## **Effets d’animation**
Aspose.Slides prend en charge **plus de 150 effets d’animation**, y compris des effets de base comme Bounce, PathFootball, Zoom et des effets spécifiques tels que OLEObjectShow, OLEObjectOpen. Vous pouvez consulter la liste complète des effets d’animation dans l’énumération [**EffectType**](https://reference.aspose.com/slides/fr/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

De plus, ces effets d’animation peuvent être combinés avec :

- [ColorEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.set_effect)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides.  
Cela peut être réalisé en combinant plusieurs comportements pour former une nouvelle animation personnalisée.

[**Behavior**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.behavior) est l’unité de base de tout effet d’animation PowerPoint. Tous les effets d’animation sont en fait un ensemble de comportements composés en une stratégie. Vous pouvez combiner les comportements en une animation personnalisée **une fois** et la réutiliser dans d’autres présentations. Si vous ajoutez un nouveau comportement à un effet d’animation PowerPoint standard, il s’agit d’une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire se répéter plusieurs fois.

[**Animation Point**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.point) est le point où le comportement doit être appliqué.

## **Chronologie d’animation**
[**Sequence**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.sequence) est une collection d’effets d’animation appliqués à une forme concrète.

[**AnimationTimeLine**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.animation.animation_time_line) est un ensemble de séquences utilisées dans une diapositive donnée. C’est le moteur d’animation introduit depuis PowerPoint 2002. Dans les versions antérieures de PowerPoint, il était difficile d’ajouter des effets d’animation à une présentation, ce qui n’était possible qu’avec des solutions de contournement. La chronologie remplace l’ancienne classe **AnimationSettings** et fournit un modèle d’objet plus clair pour les animations PowerPoint. Une diapositive ne peut contenir **qu’une seule** chronologie d’animation.

## **Animation interactive**
[**EffectTriggerType**](https://reference.aspose.com/slides/fr/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) permet de définir des actions utilisateur (par ex. clic sur un bouton) qui déclencheront le démarrage d’une certaine animation. Les déclencheurs n’ont été ajoutés que dans la version la plus récente de PowerPoint.

## **Animation de forme**
Aspose.Slides permet d’appliquer des animations aux formes, qui peuvent être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="info" %}} 
En savoir plus [**À propos de l'animation de forme**](/slides/fr/cpp/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, il est possible d’appliquer l’animation PowerPoint uniquement aux catégories de graphique ou aux séries de graphique. Vous pouvez également appliquer un effet d’animation à un élément de catégorie ou à un élément de série.

{{% alert color="info" %}} 
En savoir plus [**À propos des graphiques animés**](/slides/fr/cpp/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus du texte animé, il est également possible d’appliquer une animation à un paragraphe.

{{% alert color="info" %}} 
En savoir plus [**À propos du texte animé**](/slides/fr/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### Les animations seront‑elles conservées lors de l’exportation vers PDF ?

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/cpp/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/cpp/export-to-html5/), [GIF animé](/slides/fr/cpp/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/cpp/convert-powerpoint-to-video/).

### Puis‑je transformer une présentation animée en vidéo et contrôler le nombre d’images par seconde ainsi que la taille du cadre ?

Oui. Vous pouvez [rendre la présentation sous forme d’images](/slides/fr/cpp/convert-powerpoint-to-video/) puis les encoder en vidéo (par ex. avec ffmpeg), en choisissant le FPS et la résolution. Les animations et les transitions de diapositive sont reproduites pendant le rendu.

### Les animations resteront‑elles intactes lors de l’utilisation d’ODP (et pas seulement PPTX) ?

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/cpp/open-presentation/) et l’[écriture](/slides/fr/cpp/save-presentation/), mais les différences de format peuvent entraîner des variations d’aspect ou de comportement de certains effets. Vérifiez les cas critiques avec des échantillons réels.