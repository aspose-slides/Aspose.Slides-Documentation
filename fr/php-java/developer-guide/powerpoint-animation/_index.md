---
title: Améliorer les présentations PowerPoint avec des animations en PHP
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/php-java/powerpoint-animation/
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
- PHP
- Aspose.Slides
description: "Explorez les capacités d'Aspose.Slides pour PHP via Java dans la gestion des animations PowerPoint. Fonctionnalités clés et informations pour améliorer vos présentations."
---
## **Introduction**

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de la création.

**PowerPoint animation** joue un rôle important pour rendre une présentation attrayante et captivante pour les spectateurs. Aspose.Slides for PHP via Java offre un large éventail d'options pour ajouter des animations aux présentations PowerPoint :

- Appliquer différents types d'effets d'animation PowerPoint aux formes, graphiques, tableaux, objets OLE et autres éléments de présentation.
- Utiliser plusieurs effets d'animation PowerPoint sur une même forme.
- Utiliser la chronologie d'animation pour contrôler les effets d'animation.
- Créer des animations personnalisées.

Dans Aspose.Slides for PHP via Java, divers effets d'animation peuvent être appliqués aux formes. Étant donné que chaque élément d'une diapositive, y compris le texte, les images, les objets OLE et les tableaux, est considéré comme une forme, les effets d'animation peuvent être appliqués à n'importe quel élément de la diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets de base tels que Bounce, PathFootball et Zoom, ainsi que des effets spécifiques tels que OLEObjectShow et OLEObjectOpen. Vous pouvez trouver la liste complète dans la classe [EffectType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effecttype/).

De plus, ces effets d'animation peuvent être combinés avec les comportements suivants :

- [ColorEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SetEffect)

## **Animation personnalisée**

Pour des exemples PHP complets qui créent, inspectent et modifient les comportements et les trajectoires de déplacement modifiables, voir [Animation personnalisée](/slides/fr/php-java/custom-animation/).

Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements en une nouvelle animation personnalisée.

[Behavior](https://reference.aspose.com/slides/fr/php-java/aspose.slides/behavior/) est un élément de base d'un effet d'animation PowerPoint. Combinez des comportements pour personnaliser un effet, ou ajoutez un comportement pour étendre un effet prédéfini. La répétition est configurée via les paramètres de timing plutôt qu'avec un comportement de répétition séparé.

[Animation Point](https://reference.aspose.com/slides/fr/php-java/aspose.slides/point/) est un point auquel un comportement doit être appliqué.

## **Chronologie d'animation**
[Sequence](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sequence/) est une collection d'effets d'animation qui peuvent cibler différentes formes.

[Timeline](https://reference.aspose.com/slides/fr/php-java/aspose.slides/animationtimeline/) est un ensemble de séquences utilisé dans une diapositive spécifique. C'est un moteur d'animation introduit dans PowerPoint 2002. Dans les versions antérieures de PowerPoint, l'ajout d'effets d'animation aux présentations était difficile et ne pouvait être réalisé qu'avec diverses solutions de contournement. La chronologie fournit un modèle d'objet plus clair pour les animations PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**
[Trigger](https://reference.aspose.com/slides/fr/php-java/aspose.slides/effecttriggertype/) vous permet de définir des actions utilisateur, telles qu'un clic sur un bouton, qui déclenchent une animation particulière.

## **Animation de forme**
Aspose.Slides vous permet d'appliquer des animations aux formes, qui peuvent inclure du texte, des rectangles, des lignes, des cadres, des objets OLE, etc.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos de l'animation de forme**](/slides/fr/php-java/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, les animations PowerPoint ne peuvent être appliquées qu'aux catégories de graphique ou aux séries de graphique. Vous pouvez également appliquer des effets d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos des graphiques animés**](/slides/fr/php-java/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus d'animer du texte, vous pouvez appliquer une animation à un paragraphe.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos du texte animé**](/slides/fr/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront-elles conservées lors de l'exportation en PDF ?**

Non. Le PDF est un format statique, donc les animations et les [slide transitions](/slides/fr/php-java/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/php-java/export-to-html5/), [animated GIF](/slides/fr/php-java/convert-powerpoint-to-animated-gif/) ou [video](/slides/fr/php-java/convert-powerpoint-to-video/).

**Puis-je transformer une présentation animée en vidéo et contrôler le nombre d'images par seconde ainsi que la résolution ?**

Oui. Vous pouvez [render the presentation as frames](/slides/fr/php-java/convert-powerpoint-to-video/) et les encoder dans une vidéo (par exemple avec ffmpeg), en choisissant le FPS et la résolution. Les animations et les transitions de diapositives sont lues pendant le rendu.

**Les animations resteront-elles intactes lors de la manipulation d'ODP (et pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/php-java/open-presentation/) et l'[écriture](/slides/fr/php-java/save-presentation/), mais cela ne garantit pas la préservation des animations. Les données d'animation personnalisée peuvent être perdues lors de la conversion vers ODP. Voir [Animation personnalisée](/slides/fr/php-java/custom-animation/) pour des exemples et des conseils sur la vérification de la compatibilité des formats.