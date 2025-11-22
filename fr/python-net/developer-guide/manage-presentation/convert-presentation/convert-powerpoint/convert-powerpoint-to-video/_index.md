---
title: Convertir des présentations PowerPoint en vidéo avec Python
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
- conversion de PowerPoint en vidéo
- conversion de présentation en vidéo
- conversion de PPT en vidéo
- conversion de PPTX en vidéo
- conversion de ODP en vidéo
- conversion vidéo Python
- PowerPoint
- Python
- Aspose.Slides
description: "Apprenez à convertir des présentations PowerPoint et OpenDocument en vidéo avec Python. Découvrez des exemples de code et des techniques d'automatisation pour optimiser votre flux de travail."
---

## **Vue d'ensemble**

En convertissant votre présentation PowerPoint ou OpenDocument en vidéo, vous obtenez :

**Accessibilité accrue :** Tous les appareils, quelle que soit la plateforme, sont équipés de lecteurs vidéo par défaut, ce qui facilite l'ouverture ou la lecture des vidéos pour les utilisateurs par rapport aux applications de présentation traditionnelles.

**Portée plus large :** Les vidéos vous permettent d'atteindre un public plus vaste et de présenter les informations dans un format plus attrayant. Les enquêtes et les statistiques indiquent que les gens préfèrent regarder et consommer du contenu vidéo plutôt que d'autres formes, rendant votre message plus percutant.

{{% alert color="primary" %}} 

Découvrez notre [**Convertisseur en ligne PowerPoint en Vidéo**](https://products.aspose.app/slides/video) car il offre une implémentation en direct et efficace du processus décrit ici.

{{% /alert %}} 

Dans [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), nous avons implémenté la prise en charge de la conversion des présentations en vidéo.

* Utilisez Aspose.Slides for Python pour générer des images à partir des diapositives de la présentation à une fréquence d'images spécifiée (FPS).
* Ensuite, utilisez un utilitaire tiers comme ffmpeg pour compiler ces images en une vidéo.

## **Convertir une présentation PowerPoint en vidéo**

1. Utilisez la commande pip install pour ajouter Aspose.Slides for Python à votre projet : `pip install aspose-slides==24.4.0`
2. Téléchargez ffmpeg depuis [ici](https://ffmpeg.org/download.html) ou installez-le via le gestionnaire de paquets.
3. Assurez‑vous que ffmpeg se trouve dans le `PATH`. Sinon, lancez ffmpeg en utilisant le chemin complet vers le binaire (par ex., `C:\ffmpeg\ffmpeg.exe` sous Windows ou `/opt/ffmpeg/ffmpeg` sous Linux).
4. Exécutez le code de conversion PowerPoint‑vers‑vidéo.

Ce code Python montre comment convertir une présentation (contendant une forme et deux effets d'animation) en vidéo :
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

Voir [Animation PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Animation de forme](https://docs.aspose.com/slides/python-net/shape-animation/), et [Effet de forme](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus attrayants et intéressants — et il en est de même pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :
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


Aspose.Slides for Python prend également en charge les animations de texte. Dans cet exemple, nous animons les paragraphes sur les objets afin qu’ils apparaissent les uns après les autres, avec un délai d’une seconde entre eux :
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

Pour permettre les tâches de conversion PowerPoint en vidéo, Aspose.Slides for Python fournit le [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/).

`PresentationEnumerableAnimationsGenerator` vous permet de définir la taille des images pour la vidéo (qui sera créée ultérieurement) et la valeur FPS (images par seconde) via son constructeur. Si vous transmettez une instance d’une présentation, son `Presentation.SlideSize` sera utilisé.

Pour faire jouer toutes les animations d’une présentation en même temps, utilisez la méthode `PresentationEnumerableAnimationsGenerator.enumerate_frames`. Cette méthode prend une collection de diapositives et renvoie séquentiellement des [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). Ensuite, utilisez `EnumerableFrameArgs.get_frame()` pour obtenir chaque image vidéo.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


Les images générées peuvent ensuite être compilées en une vidéo. Pour plus de détails, consultez la section [Convert PowerPoint to Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et effets pris en charge**

Lors de la conversion d’une présentation PowerPoint en vidéo avec Aspose.Slides for Python, il est important de comprendre quelles animations et quels effets sont pris en charge dans le résultat. Aspose.Slides prend en charge un large éventail d’effets d’entrée, de sortie et d’emphase courants tels que fondu, vol entrant, zoom et rotation. Cependant, certaines animations avancées ou personnalisées peuvent ne pas être entièrement conservées ou apparaître différemment dans la vidéo finale. Cette section décrit les animations et effets pris en charge.

**Entrée** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Mise en évidence** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Sortie** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Chemins de mouvement** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Effets de transition de diapositive pris en charge**

Les effets de transition de diapositive jouent un rôle important pour créer des changements fluides et visuellement attrayants entre les diapositives dans une vidéo. Aspose.Slides for Python prend en charge une variété d’effets de transition couramment utilisés afin de préserver le flux et le style de votre présentation d’origine. Cette section met en évidence les effets de transition pris en charge pendant le processus de conversion.

**Subtil** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Excitant** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Contenu dynamique** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Est‑il possible de convertir des présentations protégées par mot de passe ?**

Oui, Aspose.Slides for Python permet de travailler avec des présentations protégées par mot de passe. Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

**Aspose.Slides for Python prend‑il en charge une utilisation dans des solutions cloud ?**

Oui, Aspose.Slides for Python peut être intégré dans des applications et services cloud. La bibliothèque est conçue pour fonctionner en environnements serveur, assurant haute performance et évolutivité pour le traitement par lots de fichiers.

**Existe‑t‑il des limitations de taille pour les présentations lors de la conversion ?**

Aspose.Slides for Python peut gérer des présentations de taille pratiquement illimitée. Cependant, pour des fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires, et il est parfois recommandé d’optimiser la présentation afin d’améliorer les performances.