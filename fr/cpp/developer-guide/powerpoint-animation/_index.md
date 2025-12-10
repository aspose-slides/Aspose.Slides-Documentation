---
title: "Améliorer les présentations PowerPoint avec des animations en C++"
linktitle: "Animation PowerPoint"
type: docs
weight: 150
url: /fr/cpp/powerpoint-animation/
keywords:
- ajouter animation
- mettre à jour animation
- modifier animation
- supprimer animation
- gérer animation
- contrôler animation
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
description: "Découvrez comment ajouter et contrôler des effets d'animation avancés dans Aspose.Slides pour C++ afin de créer des présentations PowerPoint et OpenDocument dynamiques."
---

Comme les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**PowerPoint animation** joue un rôle important afin de rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides pour C++ offre un large éventail d’options pour ajouter des animations à une présentation PowerPoint :

- appliquer différents types d’effets d’animation PowerPoint sur les formes, graphiques, tableaux, objets OLE et d’autres éléments de la présentation.
- utiliser plusieurs effets d’animation PowerPoint sur une forme.
- utiliser la chronologie d’animation pour contrôler les effets d’animation.
- créer une animation personnalisée.

Dans Aspose.Slides pour C++, divers effets d’animation peuvent être appliqués aux formes. Comme chaque élément de la diapositive, y compris le texte, les images, les objets OLE, les tableaux, etc., est considéré comme une forme, cela signifie que nous pouvons appliquer un effet d’animation à chaque élément d’une diapositive.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** fournit des classes pour travailler avec les animations PowerPoint.

## **Effets d'animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets d'animation de base tels que Bounce, PathFootball, l’effet Zoom et des effets d'animation spécifiques comme OLEObjectShow, OLEObjectOpen. Vous pouvez trouver la liste complète des effets d'animation dans l’énumération [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

De plus, ces effets d'animation peuvent être combinés avec eux :
- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements pour former une nouvelle animation personnalisée.

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) est l’unité de base de tout effet d'animation PowerPoint. Tous les effets d'animation sont en fait un ensemble de comportements composés en une stratégie unique. Vous pouvez combiner des comportements dans une animation personnalisée une fois, puis la réutiliser dans d’autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard, cela constituera une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire se répéter plusieurs fois.

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) est le point où le comportement doit être appliqué.

## **Chronologie d'animation**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) est une collection d'effets d'animation appliqués à une forme concrète.

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) est un ensemble de Séquences utilisé dans une diapositive concrète. C’est un moteur d’animation présent depuis PowerPoint 2002. Dans les versions antérieures de PowerPoint, il était difficile d’ajouter des effets d'animation à une présentation, ce qui ne pouvait être réalisé qu’avec différentes solutions de contournement. La chronologie vient remplacer l’ancienne classe AnimationSettings et fournit un modèle d’objet plus clair pour les animations PowerPoint. Une diapositive ne peut contenir qu’une seule chronologie d'animation.

## **Animation interactive**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) permet de définir des actions utilisateur (par ex. clic de bouton) qui déclencheront le démarrage d’une certaine animation. Les déclencheurs n’ont été ajoutés que dans la dernière version de PowerPoint.

## **Animation de forme**
Aspose.Slides permet d’appliquer des animations aux formes, qui peuvent être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="primary" %}} 
En savoir plus [**À propos de l'animation de forme**](/slides/fr/cpp/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, il est possible d’utiliser l’animation PowerPoint uniquement sur les catégories de graphique ou les séries de graphique. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="primary" %}} 
En savoir plus [**À propos des graphiques animés**](/slides/fr/cpp/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus du texte animé, il est également possible d’appliquer une animation à un paragraphe.

{{% alert color="primary" %}} 
En savoir plus [**À propos du texte animé**](/slides/fr/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront‑elles conservées lors de l’exportation en PDF ?**

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/cpp/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/cpp/export-to-html5/), [GIF animé](/slides/fr/cpp/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/cpp/convert-powerpoint-to-video/).

**Puis‑je transformer une présentation animée en vidéo et contrôler le taux d’images et la taille des images ?**

Oui. Vous pouvez [rendre la présentation sous forme de cadres](/slides/fr/cpp/convert-powerpoint-to-video/) et les encoder en vidéo (par ex. avec ffmpeg), en choisissant le nombre d’images par seconde et la résolution. Les animations et les transitions de diapositive sont jouées pendant le rendu.

**Les animations resteront‑elles intactes lors du travail avec ODP (et pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/cpp/open-presentation/) et l’[écriture](/slides/fr/cpp/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Vérifiez les cas critiques avec des exemples réels.