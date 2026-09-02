---
title: Améliorer les présentations PowerPoint avec des animations en Python
linktitle: Animation PowerPoint
type: docs
weight: 150
url: /fr/python-net/powerpoint-animation/
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
- Python
- Aspose.Slides
description: "Explorez les capacités d'Aspose.Slides pour Python via .NET dans la gestion des animations PowerPoint. Cette vue d'ensemble générale met en évidence les fonctionnalités clés et offre des conseils pour améliorer vos présentations."
---
## **Introduction**

Les présentations sont conçues pour transmettre des informations, ainsi leur apparence visuelle et leur comportement interactif sont des considérations clés lors de la création.

**PowerPoint animation** joue un rôle important pour rendre une présentation attrayante et captivante pour les spectateurs. Aspose.Slides for Python via .NET offre un large éventail d’options pour ajouter de l’animation à une présentation PowerPoint. Vous pouvez :

- Appliquer divers effets d’animation aux formes, graphiques, tableaux, objets OLE et autres éléments.
- Utiliser plusieurs effets d’animation sur une même forme.
- Contrôler les effets via la chronologie d’animation.
- Créer des animations personnalisées.

Dans Aspose.Slides for Python via .NET, les effets d’animation peuvent être appliqués aux formes. Parce que chaque élément d’une diapositive — texte, images, objets OLE et tableaux — est traité comme une forme, vous pouvez appliquer des effets d’animation à tout élément de la diapositive.

Le [aspose.slides.animation](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/) namespace fournit les classes pour travailler avec les animations PowerPoint.

## **Installation**

```bash
pip install aspose.slides
```

## **Add an Animation Effect to a Shape in Python**

Les effets d’animation résident dans la séquence principale d’une diapositive. Ajoutez une forme, puis appelez `add_effect` sur
`slide.timeline.main_sequence`, en transmettant le type d’effet, son sous‑type et le déclencheur qui le lance.

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

Le fichier enregistré contient un effet sur la première diapositive : le rectangle entre en vol depuis la gauche pendant deux
secondes lorsque le présentateur clique. En rouvrant le fichier et en lisant `slide.timeline.main_sequence`, cet
effet est renvoyé, de sorte que l’animation survit au round‑trip au lieu de n’exister que en mémoire.

## **Animation Effects**

Aspose.Slides prend en charge **plus de 150 effets d’animation**, y compris des effets de base tels que Bounce, PathFootball et Zoom, ainsi que des effets spécialisés comme OLEObjectShow et OLEObjectOpen. Vous pouvez consulter la liste complète dans l’énumération [EffectType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effecttype/).

De plus, ces effets d’animation peuvent être combinés avec les effets suivants :

- [ColorEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/seteffect/)

## **Custom Animation**

Vous pouvez créer vos propres **animations personnalisées** dans Aspose.Slides en combinant plusieurs comportements en un seul effet.

[Behavior](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/behavior/) est le bloc de construction de base de tout effet d’animation PowerPoint. Chaque effet d’animation est essentiellement un ensemble de comportements organisés en une stratégie ou une chronologie. Vous pouvez assembler des comportements en une animation personnalisée une fois et la réutiliser dans d’autres présentations. Si vous ajoutez un nouveau comportement à un effet d’animation PowerPoint standard, cela devient une animation personnalisée — par exemple, ajouter un comportement de répétition pour que l’animation se joue plusieurs fois.

[Animation Point](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/point/) indique le moment ou la position où un comportement est appliqué (une image clé).

## **Animation Time Line**

[Sequence](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/sequence/) est une collection d’effets d’animation appliqués à une forme spécifique.

[Timeline](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/animationtimeline/) est l’ensemble de séquences utilisé sur une diapositive donnée. Il a été introduit dans PowerPoint 2002. Dans les versions antérieures de PowerPoint, l’ajout d’effets d’animation était difficile et nécessitait souvent des solutions de contournement. Timeline remplace l’ancienne classe `AnimationSettings` et fournit un modèle d’objet plus clair pour les animations PowerPoint. Chaque diapositive ne peut contenir qu’une seule chronologie d’animation.

## **Interactive Animation**

[Trigger](https://reference.aspose.com/slides/fr/python-net/aspose.slides.animation/effecttriggertype/) vous permet de définir des actions utilisateur (par ex., un clic de bouton) qui démarrent une animation spécifique. Les déclencheurs n’ont été ajoutés que dans les versions les plus récentes de PowerPoint.

## **Shape Animation**

Aspose.Slides vous permet d’appliquer des animations aux formes — texte, rectangles, lignes, cadres, objets OLE, etc.

{{% alert color="primary" %}}
En savoir plus [**À propos de l'animation de forme**](/slides/fr/python-net/shape-animation/).
{{% /alert %}}

## **Animated Charts**

Pour créer des graphiques animés, utilisez les mêmes classes que pour les formes. Cependant, les animations PowerPoint ne peuvent être appliquées qu’aux catégories de graphique ou aux séries de graphique. Vous pouvez également appliquer un effet d’animation à un élément de catégorie individuel ou à un élément de série.

{{% alert color="primary" %}}
En savoir plus [**À propos des graphiques animés**](/slides/fr/python-net/animated-charts/).
{{% /alert %}}

## **Animated text**

En plus d’animer le texte, vous pouvez appliquer une animation à un paragraphe.

{{% alert color="primary" %}}
En savoir plus [**À propos du texte animé**](/slides/fr/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

### Les animations seront‑elles conservées lors de l’exportation vers PDF ?

Non. Le PDF est un format statique, donc les animations et les [transitions de diapositive](/slides/fr/python-net/slide-transition/) ne se jouent pas. Si vous avez besoin de mouvement, exportez vers [HTML5](/slides/fr/python-net/export-to-html5/), [GIF animé](/slides/fr/python-net/convert-powerpoint-to-animated-gif/) ou [vidéo](/slides/fr/python-net/convert-powerpoint-to-video/) à la place.

### Puis‑je transformer une présentation animée en vidéo et contrôler le taux d’images et la taille du cadre ?

Oui. Vous pouvez [rendre la présentation sous forme de cadres](/slides/fr/python-net/convert-powerpoint-to-video/) et les encoder en vidéo (par ex., via ffmpeg), en choisissant le FPS et la résolution. Les animations et les transitions de diapositive sont jouées pendant le rendu.

### Les animations resteront‑elles intactes lors de la manipulation d’ODP (et pas seulement PPTX) ?

PPT, PPTX et ODP sont pris en charge pour la [lecture](/slides/fr/python-net/open-presentation/) et l’[écriture](/slides/fr/python-net/save-presentation/), mais les différences de format signifient que certains effets peuvent apparaître ou se comporter légèrement différemment. Validez les cas critiques avec des échantillons réels.