---
title: Améliorer les présentations PowerPoint avec des animations en Python via Java
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/python-java/powerpoint-animation/
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
- Python
- Java
- Aspose.Slides
description: "Découvrez les capacités d'Aspose.Slides pour Python via Java en gestion des animations PowerPoint. Cette vue d'ensemble générale met en avant les principales fonctionnalités et offre des conseils pour améliorer vos présentations."
---
## **Introduction**

L'apparence visuelle et le comportement interactif sont tous deux pris en compte lors de la création des présentations.

**PowerPoint animation** joue un rôle important pour rendre une présentation attrayante et captivante pour les spectateurs. Aspose.Slides offre un large éventail d'options pour ajouter des animations aux présentations PowerPoint :
- Appliquer différents types d'effets d'animation PowerPoint aux formes, graphiques, tableaux, objets OLE et autres éléments de la présentation.
- Utiliser plusieurs effets d'animation PowerPoint sur une même forme.
- Utiliser la chronologie d'animation pour contrôler les effets d'animation.
- Créer des animations personnalisées.

Dans Aspose.Slides, divers effets d'animation peuvent être appliqués aux formes. Puisque chaque élément d'une diapositive, y compris le texte, les images, les objets OLE et les tableaux, est considéré comme une forme, les effets d'animation peuvent être appliqués à n'importe quel élément de la diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets d'animation de base tels que Bounce, PathFootball et Zoom, ainsi que des effets spécialisés tels que OLEObjectShow et OLEObjectOpen. Vous pouvez consulter la liste complète des effets d'animation dans l'énumération [EffectType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttype/).

De plus, les effets d'animation suivants peuvent être utilisés en combinaison avec ceux listés ci‑dessus :
- [ColorEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/seteffect/)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides.
Vous pouvez le faire en combinant plusieurs comportements en une nouvelle animation personnalisée.

[Behavior](https://reference.aspose.com/slides/fr/python-java/aspose.slides/behavior/) est un élément de base de tout effet d'animation PowerPoint. Chaque effet d'animation se compose d'un ensemble de comportements combinés en une seule stratégie. Vous pouvez combiner des comportements dans une animation personnalisée une fois et la réutiliser dans d'autres présentations. Ajouter un nouveau comportement à un effet d'animation PowerPoint standard crée une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition pour que l'animation se répète plusieurs fois.

[Point](https://reference.aspose.com/slides/fr/python-java/aspose.slides/point/) est un point auquel un comportement doit être appliqué.

## **Chronologie d'animation**
[Sequence](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/) est une collection d'effets d'animation appliqués à une forme spécifique.

[AnimationTimeLine](https://reference.aspose.com/slides/fr/python-java/aspose.slides/animationtimeline/) est un ensemble de séquences utilisé sur une diapositive spécifique. Il représente le moteur d'animation introduit dans PowerPoint 2002. Dans les versions antérieures de PowerPoint, l'ajout d'effets d'animation à une présentation était difficile et nécessitait des solutions de contournement. La chronologie remplace l'ancienne classe AnimationSettings et fournit un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**
[EffectTriggerType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effecttriggertype/) vous permet de définir des actions utilisateur (par exemple, un clic de bouton) qui déclenchent une animation spécifique. Les déclencheurs n'ont été ajoutés que dans la dernière version de PowerPoint.

## **Animation de forme**
Aspose.Slides vous permet d'appliquer des animations aux formes, qui peuvent représenter du texte, des rectangles, des lignes, des cadres, des objets OLE et d'autres éléments.

{{% alert color="info" title="Note" %}}
En savoir plus [À propos de l'animation de forme](/slides/fr/python-java/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, utilisez les mêmes classes que pour les formes. Cependant, il est possible d'utiliser l'animation PowerPoint uniquement sur les catégories de graphiques ou les séries de graphiques. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="info" title="Note" %}}
En savoir plus [À propos des graphiques animés](/slides/fr/python-java/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus d'animer du texte, vous pouvez appliquer une animation à un paragraphe.

{{% alert color="info" title="Note" %}}
En savoir plus [À propos du texte animé](/slides/fr/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront‑elles conservées lors de l'exportation en PDF ?**

Non. Le PDF est un format statique, donc les animations et les [transition de diapositives](/slides/fr/python-java/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/python-java/export-to-html5/), [GIF animé](/slides/fr/python-java/convert-powerpoint-to-animated-gif/), ou [vidéo](/slides/fr/python-java/convert-powerpoint-to-video/).

**Puis‑je transformer une présentation animée en vidéo et contrôler le taux d'images et la taille du cadre ?**

Oui. Vous pouvez [rendre la présentation en images](/slides/fr/python-java/convert-powerpoint-to-video/) et les encoder en vidéo (par ex. via ffmpeg), en choisissant les FPS et la résolution. Les animations et les transitions de diapositives sont lues pendant le rendu.

**Les animations resteront‑elles intactes lors de l’utilisation d'ODP (et pas uniquement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/python-java/open-presentation/) et l'[écriture](/slides/fr/python-java/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Validez les cas critiques avec des exemples réels.