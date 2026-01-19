---
title: Convertir les présentations PowerPoint en vidéo avec Python
linktitle: PowerPoint en vidéo
type: docs
weight: 130
url: /fr/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint en vidéo
- convertir PowerPoint en vidéo
- présentation en vidéo
- convertir présentation en vidéo
- PPT en vidéo
- convertir PPT en vidéo
- PPTX en vidéo
- convertir PPTX en vidéo
- ODP en vidéo
- convertir ODP en vidéo
- PowerPoint en MP4
- convertir PowerPoint en MP4
- présentation en MP4
- convertir présentation en MP4
- PPT en MP4
- convertir PPT en MP4
- PPTX en MP4
- convertir PPTX en MP4
- conversion PowerPoint en vidéo
- conversion présentation en vidéo
- conversion PPT en vidéo
- conversion PPTX en vidéo
- conversion ODP en vidéo
- conversion vidéo Python
- PowerPoint
- Python
- Aspose.Slides
description: "Apprenez comment convertir les présentations PowerPoint et OpenDocument en vidéo avec Python. Découvrez des exemples de code et des techniques d'automatisation pour rationaliser votre flux de travail."
---

## **Vue d'ensemble**

En convertissant votre présentation PowerPoint ou OpenDocument en vidéo, vous obtenez :

**Accessibilité accrue :** Tous les appareils, quel que soit le système, sont équipés de lecteurs vidéo par défaut, ce qui facilite l’ouverture ou la lecture des vidéos par rapport aux applications de présentation traditionnelles.

**Portée plus large :** Les vidéos vous permettent d’atteindre un public plus vaste et de présenter l’information sous un format plus engageant. Les enquêtes et les statistiques montrent que les gens préfèrent regarder et consommer du contenu vidéo plutôt que d’autres formes, rendant votre message plus percutant.

{{% alert color="primary" %}} 

Découvrez notre [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/video) qui propose une implémentation en direct et efficace du processus décrit ici.

{{% /alert %}} 

Dans [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), nous avons ajouté la prise en charge de la conversion des présentations en vidéo.

* Utilisez Aspose.Slides for Python pour générer des images à partir des diapositives à une fréquence d’images spécifiée (FPS).
* Puis, utilisez un utilitaire tiers comme ffmpeg pour assembler ces images en une vidéo.

## **Convertir une présentation PowerPoint en vidéo**

1. Utilisez la commande pip install pour ajouter Aspose.Slides for Python à votre projet : `pip install aspose-slides==24.4.0`
2. Téléchargez ffmpeg depuis [ici](https://ffmpeg.org/download.html) ou installez‑le via le gestionnaire de paquets.
3. Assurez‑vous que ffmpeg se trouve dans le `PATH`. Sinon, lancez ffmpeg en indiquant le chemin complet du binaire (par exemple, `C:\ffmpeg\ffmpeg.exe` sous Windows ou `/opt/ffmpeg/ffmpeg` sous Linux).
4. Exécutez le code de conversion PowerPoint‑vers‑vidéo.

Ce code Python montre comment convertir une présentation (contennant une forme et deux effets d’animation) en vidéo :
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```


## **Effets vidéo**

Lors de la conversion d’une présentation PowerPoint en vidéo avec Aspose.Slides for Python, vous pouvez appliquer divers effets vidéo pour améliorer la qualité visuelle du résultat. Ces effets vous permettent de contrôler l’apparence des diapositives dans la vidéo finale en ajoutant des transitions fluides, des animations et d’autres éléments visuels. Cette section explique les options d’effets vidéo disponibles et montre comment les appliquer.

{{% alert color="primary" %}} 

Voir [PowerPoint Animation](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/python-net/shape-animation/), et [Shape Effect](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus attrayants et intéressants — et il en va de même pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :
```python
import aspose.pydrawing as drawing

# Ajouter une forme souriante et l'animer.
# ...

# Ajouter une nouvelle diapositive et une transition animée.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides for Python prend également en charge les animations de texte. Dans cet exemple, nous animons les paragraphes sur les objets afin qu’ils apparaissent les uns après les autres, avec un délai d’une seconde entre chaque :
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter du texte et des animations.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Convertir les images en vidéo.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```


## **Classes de conversion vidéo**

Pour activer les tâches de conversion PowerPoint‑vers‑vidéo, Aspose.Slides for Python fournit le [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` vous permet de définir la taille d’image pour la vidéo (qui sera créée ultérieurement) et la valeur FPS (images par seconde) via son constructeur. Si vous transmettez une instance d’une présentation, son `Presentation.SlideSize` sera utilisé.

Pour faire lire toutes les animations d’une présentation en même temps, utilisez la méthode `PresentationEnumerableFramesGenerator.enumerate_frames`. Cette méthode prend une collection de diapositives et renvoie séquentiellement des [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). Puis, utilisez `EnumerableFrameArgs.get_frame()` pour obtenir chaque image vidéo.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


Les images générées peuvent ensuite être assemblées en une vidéo. Pour plus de détails, consultez la section [Convert PowerPoint to Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et effets pris en charge**

Lors de la conversion d’une présentation PowerPoint en vidéo avec Aspose.Slides for Python, il est important de connaître les animations et effets supportés dans le résultat. Aspose.Slides prend en charge un large éventail d’effets d’entrée, de sortie et de mise en évidence courants tels que le fondu, le déplacement, le zoom et la rotation. Cependant, certaines animations avancées ou personnalisées peuvent ne pas être entièrement conservées ou apparaître différemment dans la vidéo finale. Cette section décrit les animations et effets pris en charge.

**Entrée**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fade** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Fly In** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Float In** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Split** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Wipe** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shape** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Wheel** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Random Bars** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Grow & Turn** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Swivel** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Bounce** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Mise en évidence**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Color Pulse** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Teeter** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Spin** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Grow/Shrink** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Desaturate** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Darken** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Lighten** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Transparency** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Object Color** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Complementary Color** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Line Color** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fill Color** | ![non pris en charge](x.png) | ![pris en charge](v.png) |

**Sortie**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fade** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Fly Out** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Float Out** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Split** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Wipe** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shape** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Random Bars** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shrink & Turn** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Swivel** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Bounce** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Chemins de mouvement**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Arcs** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Turns** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shapes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Loops** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Custom Path** | ![pris en charge](v.png) | ![pris en charge](v.png) |

## **Effets de transition de diapositive pris en charge**

Les effets de transition de diapositive jouent un rôle important pour créer des changements fluides et visuellement attrayants entre les diapositives d’une vidéo. Aspose.Slides for Python prend en charge une variété d’effets de transition couramment utilisés afin de préserver le flux et le style de votre présentation originale. Cette section met en avant les transitions supportées lors du processus de conversion.

**Subtil**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fade** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Push** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Pull** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Wipe** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Split** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Reveal** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Random Bars** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shape** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Uncover** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Cover** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Flash** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Strips** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Excitant**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Drape** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Curtains** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Wind** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Prestige** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fracture** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Crush** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Peel Off** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Page Curl** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Airplane** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Origami** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Dissolve** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Checkerboard** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Blinds** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Clock** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Ripple** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Honeycomb** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Glitter** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Vortex** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Shred** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Switch** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Flip** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Gallery** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Cube** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Doors** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Box** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Comb** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Random** | ![non pris en charge](x.png) | ![pris en charge](v.png) |

**Contenu dynamique**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Ferris Wheel** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Conveyor** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Rotate** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Orbit** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fly Through** | ![pris en charge](v.png) | ![pris en charge](v.png) |

## **FAQ**

**Est‑il possible de convertir des présentations protégées par mot de passe ?**

Oui, Aspose.Slides for Python permet de travailler avec des présentations protégées. Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

**Aspose.Slides for Python prend‑il en charge une utilisation dans des solutions cloud ?**

Oui, Aspose.Slides for Python peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, garantissant haute performance et évolutivité pour le traitement par lots de fichiers.

**Existe‑t‑il des limites de taille pour les présentations lors de la conversion ?**

Aspose.Slides for Python peut gérer des présentations de taille pratiquement illimitée. Cependant, pour des fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires, et il est parfois recommandé d’optimiser la présentation afin d’améliorer les performances.