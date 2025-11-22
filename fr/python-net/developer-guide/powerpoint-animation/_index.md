---
title: Améliorer les présentations PowerPoint avec des animations en Python
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/python-net/powerpoint-animation/
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
- présentation PowerPoint
- Python
- Aspose.Slides
description: "Explorez les capacités d'Aspose.Slides pour Python via .NET dans la gestion des animations PowerPoint. Cette vue d'ensemble générale met en évidence les fonctionnalités clés et offre des conseils pour améliorer vos présentations."
---

## **Vue d'ensemble**

Les présentations sont conçues pour transmettre des informations, c’est pourquoi leur apparence visuelle et leur comportement interactif sont des considérations essentielles lors de la création.

**L’animation PowerPoint** joue un rôle important pour rendre une présentation attrayante et engageante pour les spectateurs. Aspose.Slides for Python via .NET offre un large éventail d’options pour ajouter des animations à une présentation PowerPoint. Vous pouvez :

- Appliquer différents effets d’animation aux formes, graphiques, tableaux, objets OLE et autres éléments.  
- Utiliser plusieurs effets d’animation sur une même forme.  
- Contrôler les effets via la chronologie d’animation.  
- Créer des animations personnalisées.

Dans Aspose.Slides for Python via .NET, les effets d’animation peuvent être appliqués aux formes. Comme chaque élément d’une diapositive – texte, images, objets OLE et tableaux – est traité comme une forme, vous pouvez appliquer des effets d’animation à n’importe quel élément de la diapositive.

L’espace de noms [aspose.slides.animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) fournit les classes permettant de travailler avec les animations PowerPoint.

## **Effets d’animation**

Aspose.Slides prend en charge **plus de 150 effets d’animation**, y compris des effets de base tels que Bounce, PathFootball et Zoom, ainsi que des effets spécialisés comme OLEObjectShow et OLEObjectOpen. Vous trouvez la liste complète dans l’énumération [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/).

De plus, ces effets d’animation peuvent être combinés avec les effets suivants :

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)  
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)  
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)  
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)  
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)  
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)  
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)  
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)

## **Animation personnalisée**

Vous pouvez créer vos propres **animations personnalisées** dans Aspose.Slides en combinant plusieurs comportements en un seul effet.

[Behavior](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) est le bloc de construction de base de tout effet d’animation PowerPoint. Chaque effet d’animation est essentiellement un ensemble de comportements disposés dans une stratégie ou une chronologie. Vous pouvez assembler les comportements en une animation personnalisée une fois, puis la réutiliser dans d’autres présentations. Si vous ajoutez un nouveau comportement à un effet d’animation PowerPoint standard, il devient une animation personnalisée — par exemple, ajouter un comportement de répétition pour que l’animation se joue plusieurs fois.

[Animation Point](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) marque le moment ou la position où un comportement est appliqué (une image clé).

## **Chronologie d’animation**

[Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) est une collection d’effets d’animation appliqués à une forme spécifique.

[Timeline](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) est l’ensemble de séquences utilisé sur une diapositive donnée. Elle a été introduite dans PowerPoint 2002. Dans les versions antérieures, ajouter des effets d’animation était difficile et nécessitait souvent des contournements. La chronologie remplace l’ancienne classe `AnimationSettings` et fournit un modèle d’objet plus clair pour les animations PowerPoint. Chaque diapositive ne peut contenir qu’une seule chronologie d’animation.

## **Animation interactive**

[Trigger](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) vous permet de définir des actions utilisateur (par ex., un clic sur un bouton) qui déclenchent une animation précise. Les déclencheurs n’ont été ajoutés que dans les versions les plus récentes de PowerPoint.

## **Animation de forme**

Aspose.Slides vous permet d’appliquer des animations aux formes — texte, rectangles, lignes, cadres, objets OLE, etc.

{{% alert color="primary" %}}
Lisez plus [**À propos de l’animation de forme**](/slides/fr/python-net/shape-animation/).
{{% /alert %}}

## **Graphiques animés**

Pour créer des graphiques animés, utilisez les mêmes classes que pour les formes. Cependant, les animations PowerPoint ne peuvent être appliquées qu’aux catégories ou aux séries d’un graphique. Vous pouvez également appliquer un effet d’animation à un élément de catégorie individuel ou à un élément de série.

{{% alert color="primary" %}}
Lisez plus [**À propos des graphiques animés**](/slides/fr/python-net/animated-charts/).
{{% /alert %}}

## **Texte animé**

En plus d’animer du texte, vous pouvez appliquer une animation à un paragraphe.

{{% alert color="primary" %}}
Lisez plus [**À propos du texte animé**](/slides/fr/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront‑elles conservées lors de l’exportation en PDF ?**

Non. Le PDF est un format statique, les animations et les [transitions de diapositive](/slides/fr/python-net/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez vers [HTML5](/slides/fr/python-net/export-to-html5/), [GIF animé](/slides/fr/python-net/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/python-net/convert-powerpoint-to-video/) à la place.

**Puis‑je transformer une présentation animée en vidéo et contrôler le nombre d’images par seconde ainsi que la taille du cadre ?**

Oui. Vous pouvez [rendre la présentation sous forme de cadres](/slides/fr/python-net/convert-powerpoint-to-video/) et les encoder en vidéo (par ex., avec ffmpeg), en choisissant le FPS et la résolution. Les animations et les transitions de diapositive sont lues pendant le rendu.

**Les animations resteront‑elles intactes lors du travail avec ODP (et pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/python-net/open-presentation/) et l’[écriture](/slides/fr/python-net/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Validez les cas critiques avec des échantillons réels.