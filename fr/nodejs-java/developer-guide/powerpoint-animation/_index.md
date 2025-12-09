---
title: Animation PowerPoint
type: docs
weight: 150
url: /fr/nodejs-java/powerpoint-animation/
keywords: "Animation PowerPoint"
description: "Animation PowerPoint, animation des diapositives PowerPoint avec Aspose.Slides."
---

Étant donné que les présentations sont destinées à présenter quelque chose, leur apparence visuelle et leur comportement interactif sont toujours pris en compte lors de leur création.

**PowerPoint animation** joue un rôle important afin de rendre la présentation attrayante et captivante pour les spectateurs. Aspose.Slides for Node.js via Java propose un large éventail d'options pour ajouter des animations à une présentation PowerPoint :

- appliquer différents types d'effets d'animation PowerPoint sur les formes, les graphiques, les tableaux, les objets OLE et d'autres éléments de la présentation.
- utiliser plusieurs effets d'animation PowerPoint sur une forme.
- utiliser la chronologie d'animation pour contrôler les effets d'animation.
- créer une animation personnalisée.

Dans Aspose.Slides for Node.js via Java, divers effets d'animation peuvent être appliqués aux formes. Chaque élément de la diapositive, y compris le texte, les images, les objets OLE, les tableaux, etc., étant considéré comme une forme, cela signifie que nous pouvons appliquer un effet d'animation à chaque élément d'une diapositive.

## **Effets d'animation**
Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris les effets d'animation de base comme Bounce, PathFootball, l'effet Zoom et des effets d'animation spécifiques tels que OLEObjectShow, OLEObjectOpen. Vous pouvez consulter la liste complète des effets d'animation dans l'énumération [**EffectType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype/).

De plus, ces effets d'animation peuvent être utilisés en combinaison avec eux :
- [ColorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SetEffect)

## **Animation personnalisée**
Il est possible de créer vos propres **animations personnalisées** dans Aspose.Slides.  
Cela peut être réalisé en combinant plusieurs comportements en une nouvelle animation personnalisée.

[**Behavior**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Behavior) est une unité de base de tout effet d'animation PowerPoint. Tous les effets d'animation sont en réalité un ensemble de comportements composés en une stratégie unique. Vous pouvez combiner des comportements dans une animation personnalisée une fois et la réutiliser dans d'autres présentations. Si vous ajoutez un nouveau comportement à un effet d'animation PowerPoint standard, cela deviendra une autre animation personnalisée. Par exemple, vous pouvez ajouter un comportement de répétition à une animation pour la faire répéter plusieurs fois.

[**Animation Point**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Point) est un point où le comportement doit être appliqué.

## **Chronologie d'animation**
[**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) est une collection d'effets d'animation, appliquée à une forme spécifique.

[**Timeline**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AnimationTimeLine) est un ensemble de Séquences utilisé dans une diapositive concrète. C'est un moteur d'animation présent depuis PowerPoint 2002. Dans les versions antérieures de PowerPoint, il était difficile d'ajouter des effets d'animation à une présentation, ce qui ne pouvait être réalisé qu'avec différents contournements. La timeline remplace l'ancienne classe AnimationSettings et fournit un modèle d'objet plus clair pour l'animation PowerPoint. Une diapositive ne peut contenir qu'une seule timeline d'animation.

## **Animation interactive**
[**Trigger**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectTriggerType) permet de définir des actions utilisateur (par exemple, un clic de bouton), qui déclencheront le démarrage d’une certaine animation. Les déclencheurs n'ont été ajoutés que dans la dernière version de PowerPoint.

## **Animation des formes**
Aspose.Slides permet d'appliquer des animations aux formes, qui peuvent être du texte, un rectangle, une ligne, un cadre, un objet OLE, etc.

{{% alert color="primary" %}} 
En savoir plus [**About Shape Animation**](/slides/fr/nodejs-java/shape-animation/).
{{% /alert %}}

## **Graphiques animés**
Pour créer des graphiques animés, vous devez utiliser les mêmes classes que pour les formes. Cependant, il est possible d'utiliser l'animation PowerPoint uniquement sur les catégories de graphiques ou les séries de graphiques. Vous pouvez également appliquer un effet d'animation à un élément de catégorie ou à un élément de série.

{{% alert color="primary" %}} 
En savoir plus [**About Animated Charts**](/slides/fr/nodejs-java/animated-charts/).
{{% /alert %}}

## **Texte animé**
En plus du texte animé, il est également possible d'appliquer une animation à un paragraphe.

{{% alert color="primary" %}} 
En savoir plus [**About Animated Text**](/slides/fr/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront-elles conservées lors de l'exportation en PDF ?**  
Non. Le PDF est un format statique, donc les animations et les [transitions de diapositives](/slides/fr/nodejs-java/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/nodejs-java/export-to-html5/), [GIF animé](/slides/fr/nodejs-java/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/nodejs-java/convert-powerpoint-to-video/).

**Puis-je transformer une présentation animée en vidéo et contrôler la fréquence d'images ainsi que la taille du cadre ?**  
Oui. Vous pouvez [rendre la présentation sous forme de cadres](/slides/fr/nodejs-java/convert-powerpoint-to-video/) et les encoder dans une vidéo (par exemple via ffmpeg), en choisissant le nombre d'images par seconde et la résolution. Les animations et les transitions de diapositives sont lues pendant le rendu.

**Les animations resteront-elles intactes lors de l'utilisation d'ODP (et pas seulement de PPTX) ?**  
PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/nodejs-java/open-presentation/) et l'[écriture](/slides/fr/nodejs-java/save-presentation/), mais les différences de format peuvent entraîner des effets légèrement différents en apparence ou en comportement. Validez les cas critiques avec des exemples réels.