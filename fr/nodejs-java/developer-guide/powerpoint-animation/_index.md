---
title: Améliorer les présentations PowerPoint avec des animations en JavaScript
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/nodejs-java/powerpoint-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Utilisez Aspose.Slides pour Node.js via Java pour gérer les animations PowerPoint. Cet aperçu met en évidence les fonctionnalités clés et offre des conseils pour améliorer vos présentations."
---
## **Introduction**

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**animation PowerPoint** joue un rôle important pour rendre une présentation attrayante et engageante pour les spectateurs. Aspose.Slides for Node.js via Java offre un large éventail d'options pour ajouter des animations aux présentations PowerPoint :

- Appliquer différents types d'effets d'animation PowerPoint aux formes, graphiques, tableaux, objets OLE et autres éléments de la présentation.
- Utiliser plusieurs effets d'animation PowerPoint sur une même forme.
- Utiliser la chronologie d'animation pour contrôler les effets d'animation.
- Créer des animations personnalisées.

Dans Aspose.Slides for Node.js via Java, divers effets d'animation peuvent être appliqués aux formes. Puisque chaque élément d'une diapositive, y compris le texte, les images, les objets OLE et les tableaux, est considéré comme une forme, les effets d'animation peuvent être appliqués à n'importe quel élément de la diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **150+ effets d'animation**, y compris des effets de base tels que Bounce, PathFootball et Zoom, ainsi que des effets spécifiques tels que OLEObjectShow et OLEObjectOpen. Vous pouvez trouver la liste complète dans l'énumération [EffectType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effecttype/).

De plus, ces effets d'animation peuvent être combinés avec les comportements suivants :

- [ColorEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SetEffect)

## **Animation personnalisée**

Pour des exemples JavaScript complets qui créent, inspectent et modifient les comportements ainsi que les trajectoires de mouvement éditables, consultez [Animation personnalisée](/slides/fr/nodejs-java/custom-animation/).

Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides. Cela peut être réalisé en combinant plusieurs comportements pour former une nouvelle animation personnalisée.

[Behavior](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/behavior/) est un élément de construction d'un effet d'animation PowerPoint. Combinez des comportements pour personnaliser un effet, ou ajoutez un comportement pour étendre un effet prédéfini. La répétition est configurée via les paramètres de timing plutôt que par un comportement de répétition distinct.

[Animation Point](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/point/) est le point auquel un comportement doit être appliqué.

## **Chronologie d'animation**
[Sequence](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sequence/) est une collection d'effets d'animation pouvant cibler différentes formes.

[Timeline](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/animationtimeline/) est un ensemble de séquences utilisé dans une diapositive spécifique. C'est le moteur d'animation introduit dans PowerPoint 2002. Dans les versions antérieures de PowerPoint, l'ajout d'effets d'animation aux présentations était difficile et ne pouvait être réalisé qu'avec diverses solutions de contournement. La chronologie offre un modèle d'objet plus clair pour les animations PowerPoint. Une diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**
[Trigger](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/effecttriggertype/) vous permet de définir des actions utilisateur, comme un clic sur un bouton, qui déclenchent une animation particulière.

## **Animation de forme**
Aspose.Slides vous permet d'appliquer des animations aux formes, qui peuvent inclure du texte, des rectangles, des lignes, des cadres, des objets OLE, etc.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos de l'animation de forme**](/slides/fr/nodejs-java/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, les animations PowerPoint ne peuvent être appliquées qu'aux catégories de graphique ou aux séries de graphique. Vous pouvez également appliquer des effets d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos des graphiques animés**](/slides/fr/nodejs-java/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus d'animer le texte, vous pouvez appliquer une animation à un paragraphe.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos du texte animé**](/slides/fr/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront‑t‑elles conservées lors de l'exportation au format PDF ?**

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositives](/slides/fr/nodejs-java/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez vers [HTML5](/slides/fr/nodejs-java/export-to-html5/), [GIF animé](/slides/fr/nodejs-java/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/nodejs-java/convert-powerpoint-to-video/) à la place.

**Puis‑je transformer une présentation animée en vidéo et contrôler le taux d'images et la taille des images ?**

Oui. Vous pouvez [rendre la présentation sous forme de cadres](/slides/fr/nodejs-java/convert-powerpoint-to-video/) et les encoder dans une vidéo (par ex. avec ffmpeg), en choisissant le nombre d'images par seconde et la résolution. Les animations et les transitions de diapositives sont jouées pendant le rendu.

**Les animations resteront‑elles intactes lors du travail avec ODP (pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/nodejs-java/open-presentation/) et l'[écriture](/slides/fr/nodejs-java/save-presentation/), mais cela ne garantit pas la conservation des animations. Les données d'animation personnalisées peuvent être perdues lors de la conversion en ODP. Consultez [Animation personnalisée](/slides/fr/nodejs-java/custom-animation/) pour des exemples et des conseils sur la vérification de la compatibilité des formats.