---
title: Améliorer les présentations PowerPoint avec des animations en C#
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
- C#
- Csharp
- Aspose.Slides for .NET
description: "Explorez les capacités d'Aspose.Slides pour .NET à gérer les animations PowerPoint. Cet aperçu général met en avant les fonctionnalités clés et offre des conseils pour améliorer vos présentations."
---

## **Vue d'ensemble**

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de la création.

**PowerPoint animation** joue un rôle important pour rendre une présentation attrayante et engageante pour les spectateurs. Aspose.Slides for .NET offre un large éventail d'options pour ajouter des animations aux présentations PowerPoint :

- Appliquer différents types d'effets d'animation PowerPoint aux formes, graphiques, tableaux, objets OLE et autres éléments de la présentation.  
- Utiliser plusieurs effets d'animation PowerPoint sur une même forme.  
- Utiliser la chronologie d'animation pour contrôler les effets d'animation.  
- Créer des animations personnalisées.

Dans Aspose.Slides for .NET, divers effets d'animation peuvent être appliqués aux formes. Comme chaque élément d'une diapositive, y compris le texte, les images, les objets OLE et les tableaux, est considéré comme une forme, les effets d'animation peuvent être appliqués à n'importe quel élément de la diapositive.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) espace de noms fournit des classes pour travailler avec les animations PowerPoint.

## **Effets d'animation**

Aspose.Slides supporte **plus de 150 effets d'animation**, incluant des effets de base comme Bounce, PathFootball et Zoom, ainsi que des effets spécifiques comme OLEObjectShow et OLEObjectOpen. Vous pouvez trouver la liste complète des effets d'animation dans l'énumération [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype).

De plus, ces effets d'animation peuvent être combinés avec les éléments suivants :

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **Animation personnalisée**

Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements en une nouvelle animation personnalisée.

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) est le bloc de construction de tout effet d'animation PowerPoint. Tous les effets d'animation sont essentiellement un ensemble de comportements composés en une stratégie unique. Vous pouvez combiner des comportements en une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard, cela deviendra une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire se répéter plusieurs fois.

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) est le point auquel un comportement doit être appliqué.

## **Chronologie d'animation**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) est une collection d'effets d'animation appliqués à une forme spécifique.

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) est un ensemble de séquences utilisé sur une diapositive spécifique. C’est un moteur d’animation introduit dans PowerPoint 2002. Dans les versions antérieures de PowerPoint, l’ajout d’effets d’animation aux présentations était difficile et ne pouvait être réalisé qu’avec diverses solutions de contournement. La chronologie remplace l’ancienne classe AnimationSettings et offre un modèle d’objet plus clair pour les animations PowerPoint. Une diapositive ne peut contenir qu’une seule chronologie d’animation.

## **Animation interactive**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) vous permet de définir des actions utilisateur (par ex., un clic de bouton) qui déclencheront une animation spécifique. Les déclencheurs ont été introduits dans la dernière version de PowerPoint.

## **Animation des formes**

Aspose.Slides vous permet d’appliquer des animations aux formes, qui peuvent inclure du texte, des rectangles, des lignes, des cadres, des objets OLE, etc.

{{% alert color="primary" %}} 
En savoir plus [**À propos de l'animation des formes**](/slides/fr/net/shape-animation/).
{{% /alert %}}

## **Graphiques animés**

Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, les animations PowerPoint ne peuvent être appliquées qu'aux catégories de graphique ou aux séries de graphique. Vous pouvez également appliquer des effets d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="primary" %}} 
En savoir plus [**À propos des graphiques animés**](/slides/fr/net/animated-charts/).
{{% /alert %}}

## **Texte animé**

En plus du texte animé, il est également possible d’appliquer une animation à un paragraphe.

{{% alert color="primary" %}} 
En savoir plus [**À propos du texte animé**](/slides/fr/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront‑elles conservées lors de l'exportation en PDF ?**

Non. Le PDF est un format statique, donc les animations et les [transition de diapositive](/slides/fr/net/slide-transition/) ne s'exécutent pas. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/net/export-to-html5/), [GIF animé](/slides/fr/net/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/net/convert-powerpoint-to-video/).

**Puis‑je transformer une présentation animée en vidéo et contrôler le nombre d'images par seconde ainsi que la taille du cadre ?**

Oui. Vous pouvez [rendu de la présentation sous forme de cadres](/slides/fr/net/convert-powerpoint-to-video/) et les encoder dans une vidéo (par ex., via ffmpeg), en choisissant le FPS et la résolution. Les animations et les transitions de diapositive sont exécutées pendant le rendu.

**Les animations resteront‑elles intactes lors de la manipulation d'ODP (et pas seulement de PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/net/open-presentation/) et l’[écriture](/slides/fr/net/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Validez les cas critiques avec des échantillons réels.