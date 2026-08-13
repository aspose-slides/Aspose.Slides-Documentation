---
title: Améliorer les présentations PowerPoint avec des animations en Java
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/java/powerpoint-animation/
keywords:
- ajouter animation
- mettre à jour l'animation
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
- Java
- Aspose.Slides
description: "Explorez les capacités d'Aspose.Slides pour Java dans la gestion des animations PowerPoint. Cette vue d'ensemble générale met en lumière les fonctionnalités clés et offre des conseils pour améliorer vos présentations."
---
## **Introduction**

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de la création.

**PowerPoint animation** joue un rôle important pour rendre une présentation attrayante et engageante pour les spectateurs. Aspose.Slides offre un large éventail d'options pour ajouter des animations aux présentations PowerPoint :

- Appliquer différents types d'effets d'animation PowerPoint aux formes, graphiques, tableaux, objets OLE et autres éléments de la présentation.
- Utiliser plusieurs effets d'animation PowerPoint sur une même forme.
- Utiliser la chronologie d'animation pour contrôler les effets d'animation.
- Créer des animations personnalisées.

Dans Aspose.Slides, divers effets d'animation peuvent être appliqués aux formes. Étant donné que chaque élément d'une diapositive, y compris le texte, les images, les objets OLE et les tableaux, est considéré comme une forme, les effets d'animation peuvent être appliqués à tout élément de la diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets d'animation de base tels que Bounce, PathFootball, effet Zoom et des effets d'animation spécifiques comme OLEObjectShow, OLEObjectOpen. Vous pouvez trouver une liste complète des effets d'animation dans l'énumération [**EffectType**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/effecttype/).

De plus, ces effets d'animation peuvent être utilisés en combinaison avec eux :
- [ColorEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SetEffect)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides.
Cela peut être réalisé si vous combinez plusieurs comportements en une nouvelle animation personnalisée.

[**Behavior**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Behavior) est une unité de construction de tout effet d'animation PowerPoint. Tous les effets d'animation sont en fait un ensemble de comportements composés en une stratégie unique. Vous pouvez combiner des comportements en une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard, cela constituera une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire répéter plusieurs fois.

[**Animation Point**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Point) est un point où le comportement doit être appliqué.

## **Chronologie d'animation**
[**Sequence**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Sequence) est une collection d'effets d'animation, appliquée à une forme concrète.

[**Timeline**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/AnimationTimeLine) est un ensemble de Séquences utilisé dans une diapositive concrète. C'est un moteur d'animation présent depuis PowerPoint 2002. Dans les versions précédentes de PowerPoint, il était difficile d'ajouter des effets d'animation à une présentation, ce qui ne pouvait être réalisé qu'avec différentes solutions de contournement. Timeline remplace l'ancienne classe AnimationSettings et fournit un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**
[**Trigger**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/EffectTriggerType) permet de définir des actions utilisateur (par ex. clic sur un bouton), qui déclencheront le démarrage d'une certaine animation. Les déclencheurs n'ont été ajoutés que dans la dernière version de PowerPoint.

## **Animation de forme**
Aspose.Slides permet d'appliquer des animations aux formes, qui peuvent être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="info" %}} 
En savoir plus [**À propos de l'animation de forme**](/slides/fr/java/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, il est possible d'utiliser l'animation PowerPoint uniquement sur les catégories de graphique ou les séries de graphique. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="info" %}} 
En savoir plus [**À propos des graphiques animés**](/slides/fr/java/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus du texte animé, il est également possible d'appliquer une animation à un paragraphe.

{{% alert color="info" %}} 
En savoir plus [**À propos du texte animé**](/slides/fr/java/animated-text/).
{{% /alert %}}

## **FAQ**

### Les animations seront-elles conservées lors de l'exportation en PDF ?

Non. Le PDF est un format statique, donc les animations et les [transition de diapositive](/slides/fr/java/slide-transition/) ne se lisent pas. Si vous avez besoin de mouvement, exportez plutôt en [HTML5](/slides/fr/java/export-to-html5/), [GIF animé](/slides/fr/java/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/java/convert-powerpoint-to-video/).

### Puis-je transformer une présentation animée en vidéo et contrôler le taux de rafraîchissement et la taille du cadre ?

Oui. Vous pouvez [rendre la présentation sous forme de trames](/slides/fr/java/convert-powerpoint-to-video/) et les encoder en vidéo (par ex. via ffmpeg), en choisissant le nombre d'images par seconde et la résolution. Les animations et les transitions de diapositive sont lues pendant le rendu.

### Les animations resteront-elles intactes lors de l'utilisation d'ODP (et pas seulement PPTX) ?

Les formats PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/java/open-presentation/) et l'[écriture](/slides/fr/java/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Vérifiez les cas critiques avec des échantillons réels.