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
description: "Explorez les capacités d'Aspose.Slides pour Python via .NET dans la gestion des animations PowerPoint. Cette vue d'ensemble générale met en évidence les fonctionnalités clés et offre des idées pour améliorer vos présentations."
---
## **Introduction**

Les présentations sont conçues pour transmettre des informations, de sorte que leur apparence visuelle et leur comportement interactif sont des considérations clés lors de la création.

**Animation PowerPoint** joue un rôle important pour rendre une présentation attrayante et captivante pour les spectateurs. Aspose.Slides for Python via .NET fournit un large éventail d'options pour ajouter des animations à une présentation PowerPoint. Vous pouvez :

- Appliquer divers effets d'animation aux formes, graphiques, tableaux, objets OLE et autres éléments.
- Utiliser plusieurs effets d'animation sur une même forme.
- Contrôler les effets via la chronologie d'animation.
- Créer des animations personnalisées.

Dans Aspose.Slides for Python via .NET, les effets d'animation peuvent être appliqués aux formes. Étant donné que chaque élément d'une diapositive—y compris le texte, les images, les objets OLE et les tableaux—est traité comme une forme, vous pouvez appliquer des effets d'animation à n'importe quel élément de la diapositive.

L'espace de noms [aspose.slides.animation](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/) fournit les classes permettant de travailler avec les animations PowerPoint.

## **Installation**

```bash
pip install aspose.slides
```

## **Ajouter un effet d'animation à une forme en Python**

Les effets d'animation résident dans la séquence principale d'une diapositive. Ajoutez une forme, puis appelez `add_effect` sur `slide.timeline.main_sequence`, en passant le type d'effet, son sous-type et le déclencheur qui le lance.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Le fichier enregistré contient un effet sur la première diapositive : le rectangle entre en vol depuis la gauche pendant deux secondes lorsque le présentateur clique. Le rouvrir et lire `slide.timeline.main_sequence` renvoie cet effet, de sorte que l'animation survit au aller‑retour plutôt que de n'exister que dans la mémoire.

## **Effets d'animation**

Aspose.Slides prend en charge **plus de 150 effets d'animation**, y compris des effets de base tels que Bounce, PathFootball et Zoom, ainsi que des effets spécialisés comme OLEObjectShow et OLEObjectOpen. Vous pouvez trouver la liste complète dans l'énumération [EffectType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effecttype/).

De plus, ces effets d'animation peuvent être combinés avec les effets suivants :

- [ColorEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/seteffect/)

## **Animation personnalisée**

Pour des exemples Python complets qui créent, inspectent et modifient les comportements et les chemins de mouvement éditables, consultez [Custom Animation](/slides/fr/python-net/custom-animation/).

Vous pouvez créer vos propres **animations personnalisées** dans Aspose.Slides en combinant plusieurs comportements en un seul effet.

[Behavior](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behavior/) est un élément de base d'un effet d'animation PowerPoint. Combinez des comportements pour personnaliser un effet, ou ajoutez un comportement pour étendre un effet prédéfini. La répétition est configurée via les paramètres de synchronisation plutôt que par un comportement de répétition séparé.

[Animation Point](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/point/) indique le moment ou la position où un comportement est appliqué (une image clé).

## **Chronologie d'animation**

[Sequence](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/) est une collection d'effets d'animation pouvant cibler différentes formes.

[Timeline](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/animationtimeline/) est l'ensemble des séquences utilisées sur une diapositive spécifique. Elle a été introduite dans PowerPoint 2002. Dans les versions antérieures de PowerPoint, l'ajout d'effets d'animation était difficile et nécessitait souvent des solutions de contournement. La chronologie remplace l'ancienne classe `AnimationSettings` et fournit un modèle d'objet plus clair pour l'animation PowerPoint. Chaque diapositive ne peut contenir qu'une seule chronologie d'animation.

## **Animation interactive**

[Trigger](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effecttriggertype/) vous permet de définir des actions utilisateur (par ex., un clic de bouton) qui démarrent une animation spécifique. Les déclencheurs n'ont été ajoutés que dans les dernières versions de PowerPoint.

## **Animation de forme**

Aspose.Slides vous permet d'appliquer des animations aux formes—comme le texte, les rectangles, les lignes, les cadres, les objets OLE, et plus encore.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos de l'animation des formes**](/slides/fr/python-net/shape-animation/).
{{% /alert %}}

## **Graphiques animés**

Pour créer des graphiques animés, utilisez les mêmes classes que pour les formes. Cependant, les animations PowerPoint ne peuvent être appliquées qu'aux catégories de graphiques ou aux séries de graphiques. Vous pouvez également appliquer un effet d'animation à un élément de catégorie individuel ou à un élément de série.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos des graphiques animés**](/slides/fr/python-net/animated-charts/).
{{% /alert %}}

## **Texte animé**

En plus d'animer du texte, vous pouvez appliquer une animation à un paragraphe.

{{% alert color="info" title="Note" %}}
En savoir plus [**À propos du texte animé**](/slides/fr/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

**Les animations seront‑elles conservées lors de l'exportation en PDF ?**

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/python-net/slide-transition/) ne sont pas lues. Si vous avez besoin de mouvement, exportez plutôt vers [HTML5](/slides/fr/python-net/export-to-html5/), [GIF animé](/slides/fr/python-net/convert-powerpoint-to-animated-gif/), ou [vidéo](/slides/fr/python-net/convert-powerpoint-to-video/).

**Puis‑je transformer une présentation animée en vidéo et contrôler le taux d'images et la taille du cadre ?**

Oui. Vous pouvez [rendre la présentation en images](/slides/fr/python-net/convert-powerpoint-to-video/) et les encoder en vidéo (par ex., via ffmpeg), en choisissant le nombre d'images par seconde et la résolution. Les animations et les transitions de diapositive sont jouées lors du rendu.

**Les animations resteront‑elles intactes lors du travail avec ODP (et pas seulement PPTX) ?**

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/python-net/open-presentation/) et l'[écriture](/slides/fr/python-net/save-presentation/), mais cela ne garantit pas la conservation des animations. Les données d'animation personnalisées peuvent être perdues lors de la conversion en ODP. Consultez [Custom Animation](/slides/fr/python-net/custom-animation/) pour des exemples et des conseils sur la vérification de la compatibilité des formats.