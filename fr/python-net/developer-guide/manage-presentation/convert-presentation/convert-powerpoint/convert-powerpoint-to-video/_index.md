---
title: Convertir PowerPoint en Vidéo
type: docs
weight: 130
url: /python-net/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Présentation, Vidéo, MP4, PPT en vidéo, PPT en MP4, Python, Aspose.Slides"
description: "Convertir PowerPoint en Vidéo en Python"
---

En convertissant votre présentation PowerPoint en vidéo, vous obtenez

* **Augmentation de l'accessibilité :** Tous les appareils (quel que soit le système) sont équipés par défaut de lecteurs vidéo par rapport aux applications d'ouverture de présentations, de sorte que les utilisateurs trouvent plus facile d'ouvrir ou de lire des vidéos.
* **Plus de portée :** Grâce aux vidéos, vous pouvez atteindre un large public et les cibler avec des informations qui pourraient autrement sembler ennuyeuses dans une présentation. La plupart des enquêtes et statistiques suggèrent que les gens regardent et consomment des vidéos plus que d'autres formes de contenu, et qu'ils préfèrent généralement ce type de contenu.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter notre [**Convertisseur en ligne PowerPoint en Vidéo**](https://products.aspose.app/slides/conversion/ppt-to-word) car c'est une mise en œuvre en direct et efficace du processus décrit ici.

{{% /alert %}} 

## **Conversion PowerPoint en Vidéo dans Aspose.Slides**

Dans [Aspose.Slides 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), nous avons implémenté le support de la conversion de présentation en vidéo.

* Utilisez Aspose.Slides pour générer un ensemble d'images (à partir des diapositives de la présentation) qui correspondent à un certain FPS (images par seconde)
* Utilisez un utilitaire tiers comme ffmpeg pour créer une vidéo basée sur les images.

### **Convertir PowerPoint en Vidéo**

1. Utilisez la commande pip install pour ajouter Aspose.Slides à votre projet :
   * exécutez `pip install Aspose.Slides==24.4.0`
2. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html) ou installez via un gestionnaire de paquets.
3. Assurez-vous que ffmpeg est dans le `PATH`, sinon lancez ffmpeg en utilisant le chemin complet vers le binaire (par exemple `C:\ffmpeg\ffmpeg.exe` sur Windows ou `/opt/ffmpeg/ffmpeg` sur Linux)
4. Exécutez le code de conversion PowerPoint en vidéo.

Ce code Python vous montre comment convertir une présentation (contenant une figure et deux effets d'animation) en vidéo :

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    smile = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)
    effect_in = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.TOP_LEFT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_out = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM_RIGHT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "smile.webm"]
    subprocess.call(cmd_line)
```

## **Effets Vidéo**

Vous pouvez appliquer des animations aux objets sur les diapositives et utiliser des transitions entre les diapositives.

{{% alert color="primary" %}} 

Vous voudrez peut-être voir ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Animation de Forme](https://docs.aspose.com/slides/python-net/shape-animation/), et [Effet de Forme](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus engageants et intéressants — et elles font la même chose pour les vidéos. Ajoutons une autre diapositive et une transition au code pour la présentation précédente :

```python
import aspose.pydrawing as drawing
# Ajoute une forme smiley et l'anime
# ...
# Ajoute une nouvelle diapositive et une transition animée

new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides prend également en charge l'animation pour les textes. Donc, nous animons des paragraphes sur des objets, qui apparaîtront un après l'autre (avec un délai fixé à une seconde) :

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    # Ajoute des textes et des animations
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose Slides pour .NET"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("convertir la présentation PowerPoint avec texte en vidéo"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraphe par paragraphe"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = presentation.slides[0].timeline.main_sequence.add_effect(para1, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = presentation.slides[0].timeline.main_sequence.add_effect(para2, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Convertit les images en vidéo
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Classes de Conversion Vidéo**

Pour vous permettre d'effectuer des tâches de conversion PowerPoint en vidéo, Aspose.Slides fournit le [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/).

PresentationEnumerableAnimationsGenerator vous permet de définir la taille de l'image pour la vidéo (qui sera créée ultérieurement) et la valeur FPS (images par seconde) via son constructeur. Si vous passez une instance de la présentation, `Presentation.SlideSize` sera utilisée.

Pour faire jouer toutes les animations dans une présentation en même temps, utilisez la méthode PresentationEnumerableAnimationsGenerator.enumerate_frames. Cette méthode prend une collection de diapositives et permet d'obtenir séquentiellement [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). Ensuite, EnumerableFrameArgs.get_frame() vous permet d'obtenir la trame vidéo :

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Ensuite, les images générées peuvent être compilées pour produire une vidéo. Voir la section [Convertir PowerPoint en Vidéo](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et Effets Supportés**

**Entrée**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparaître** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fondu** | ![supporté](v.png) | ![supporté](v.png) |
| **Entrée en Vol** | ![supporté](v.png) | ![supporté](v.png) |
| **Flottement** | ![supporté](v.png) | ![supporté](v.png) |
| **Rupture** | ![supporté](v.png) | ![supporté](v.png) |
| **Essuyer** | ![supporté](v.png) | ![supporté](v.png) |
| **Forme** | ![supporté](v.png) | ![supporté](v.png) |
| **Roue** | ![supporté](v.png) | ![supporté](v.png) |
| **Barres Aléatoires** | ![supporté](v.png) | ![supporté](v.png) |
| **Grandir & Tourner** | ![non supporté](x.png) | ![supporté](v.png) |
| **Zoom** | ![supporté](v.png) | ![supporté](v.png) |
| **Rotation** | ![supporté](v.png) | ![supporté](v.png) |
| **Sauter** | ![supporté](v.png) | ![supporté](v.png) |


**Accentuation**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![non supporté](x.png) | ![supporté](v.png) |
| **Pulse de Couleur** | ![non supporté](x.png) | ![supporté](v.png) |
| **Bascule** | ![supporté](v.png) | ![supporté](v.png) |
| **Tourner** | ![supporté](v.png) | ![supporté](v.png) |
| **Grandir/Réduire** | ![non supporté](x.png) | ![supporté](v.png) |
| **Désaturer** | ![non supporté](x.png) | ![supporté](v.png) |
| **Assombrir** | ![non supporté](x.png) | ![supporté](v.png) |
| **Éclaircir** | ![non supporté](x.png) | ![supporté](v.png) |
| **Transparence** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur de l'Objet** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur Complémentaire** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur de Ligne** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur de Remplissage** | ![non supporté](x.png) | ![supporté](v.png) |

**Sortie**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disparaître** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fondu** | ![supporté](v.png) | ![supporté](v.png) |
| **Sortie en Vol** | ![supporté](v.png) | ![supporté](v.png) |
| **Flottement** | ![supporté](v.png) | ![supporté](v.png) |
| **Rupture** | ![supporté](v.png) | ![supporté](v.png) |
| **Essuyer** | ![supporté](v.png) | ![supporté](v.png) |
| **Forme** | ![supporté](v.png) | ![supporté](v.png) |
| **Barres Aléatoires** | ![supporté](v.png) | ![supporté](v.png) |
| **Réduire & Tourner** | ![non supporté](x.png) | ![supporté](v.png) |
| **Zoom** | ![supporté](v.png) | ![supporté](v.png) |
| **Rotation** | ![supporté](v.png) | ![supporté](v.png) |
| **Sauter** | ![supporté](v.png) | ![supporté](v.png) |

**Trajectoires de Mouvement :**

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lignes** | ![supporté](v.png) | ![supporté](v.png) |
| **Arcs** | ![supporté](v.png) | ![supporté](v.png) |
| **Tournants** | ![supporté](v.png) | ![supporté](v.png) |
| **Formes** | ![supporté](v.png) | ![supporté](v.png) |
| **Boucles** | ![supporté](v.png) | ![supporté](v.png) |
| **Chemin Personnalisé** | ![supporté](v.png) | ![supporté](v.png) |

## **Effets de Transition de Diapo Supportés**

**Subtils**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morphose** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fondu** | ![supporté](v.png) | ![supporté](v.png) |
| **Pousser** | ![supporté](v.png) | ![supporté](v.png) |
| **Tirer** | ![supporté](v.png) | ![supporté](v.png) |
| **Essuyer** | ![supporté](v.png) | ![supporté](v.png) |
| **Rupture** | ![supporté](v.png) | ![supporté](v.png) |
| **Révéler** | ![non supporté](x.png) | ![supporté](v.png) |
| **Barres Aléatoires** | ![supporté](v.png) | ![supporté](v.png) |
| **Forme** | ![non supporté](x.png) | ![supporté](v.png) |
| **Découvrir** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couverture** | ![supporté](v.png) | ![supporté](v.png) |
| **Clignoter** | ![supporté](v.png) | ![supporté](v.png) |
| **Bandes** | ![supporté](v.png) | ![supporté](v.png) |

**Excitants**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Tomber** | ![non supporté](x.png) | ![supporté](v.png) |
| **Draper** | ![non supporté](x.png) | ![supporté](v.png) |
| **Rideaux** | ![non supporté](x.png) | ![supporté](v.png) |
| **Vent** | ![non supporté](x.png) | ![supporté](v.png) |
| **Prestige** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fracture** | ![non supporté](x.png) | ![supporté](v.png) |
| **Écraser** | ![non supporté](x.png) | ![supporté](v.png) |
| **Peel Off** | ![non supporté](x.png) | ![supporté](v.png) |
| **Page Curl** | ![non supporté](x.png) | ![supporté](v.png) |
| **Avion** | ![non supporté](x.png) | ![supporté](v.png) |
| **Origami** | ![non supporté](x.png) | ![supporté](v.png) |
| **Dissoudre** | ![supporté](v.png) | ![supporté](v.png) |
| **Damier** | ![non supporté](x.png) | ![supporté](v.png) |
| **Stores** | ![non supporté](x.png) | ![supporté](v.png) |
| **Horloge** | ![supporté](v.png) | ![supporté](v.png) |
| **Ondulation** | ![non supporté](x.png) | ![supporté](v.png) |
| **Miel** | ![non supporté](x.png) | ![supporté](v.png) |
| **Paillettes** | ![non supporté](x.png) | ![supporté](v.png) |
| **Vortex** | ![non supporté](x.png) | ![supporté](v.png) |
| **Découper** | ![non supporté](x.png) | ![supporté](v.png) |
| **Changer** | ![non supporté](x.png) | ![supporté](v.png) |
| **Retourner** | ![non supporté](x.png) | ![supporté](v.png) |
| **Galerie** | ![non supporté](x.png) | ![supporté](v.png) |
| **Cube** | ![non supporté](x.png) | ![supporté](v.png) |
| **Portes** | ![non supporté](x.png) | ![supporté](v.png) |
| **Boîte** | ![non supporté](x.png) | ![supporté](v.png) |
| **Peigne** | ![non supporté](x.png) | ![supporté](v.png) |
| **Zoom** | ![supporté](v.png) | ![supporté](v.png) |
| **Aléatoire** | ![non supporté](x.png) | ![supporté](v.png) |

**Contenu Dynamique**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Panoramique** | ![non supporté](x.png) | ![supporté](v.png) |
| **Grande Roue** | ![supporté](v.png) | ![supporté](v.png) |
| **Convoyeur** | ![non supporté](x.png) | ![supporté](v.png) |
| **Rotation** | ![non supporté](x.png) | ![supporté](v.png) |
| **Orbiter** | ![non supporté](x.png) | ![supporté](v.png) |
| **Voler à Travers** | ![supporté](v.png) | ![supporté](v.png) |