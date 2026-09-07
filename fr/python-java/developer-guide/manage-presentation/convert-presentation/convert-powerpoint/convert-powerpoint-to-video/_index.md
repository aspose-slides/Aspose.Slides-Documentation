---
title: Convertir des présentations PowerPoint en vidéo avec Python
linktitle: PowerPoint en vidéo
type: docs
weight: 130
url: /fr/python-java/convert-powerpoint-to-video/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir PPT
- convertir PPTX
- PowerPoint en vidéo
- présentation en vidéo
- PPT en vidéo
- PPTX en vidéo
- PowerPoint en MP4
- présentation en MP4
- PPT en MP4
- PPTX en MP4
- enregistrer PPT en MP4
- enregistrer PPTX en MP4
- exporter PPT en MP4
- exporter PPTX en MP4
- conversion vidéo
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint en vidéo MP4 avec Python via Java. Générer des images avec Aspose.Slides et les encoder avec FFmpeg, y compris les animations et les transitions."
---
## **Vue d'ensemble**

Convertir une présentation PowerPoint ou OpenDocument en vidéo permet aux spectateurs de regarder son contenu dans un lecteur vidéo sans ouvrir d'application de présentation. Aspose.Slides for Python via Java rend les animations et les transitions de la présentation sous forme d'images. Un encodeur séparé, tel que FFmpeg, combine ces images en un fichier vidéo.

{{% alert color="info" title="Remarque" %}}
Essayez le convertisseur en ligne [PowerPoint vers Vidéo](https://products.aspose.app/slides/fr/video) pour voir la conversion de présentation en vidéo en action.
{{% /alert %}}

## **Convertir PowerPoint en Vidéo**

La conversion comporte deux étapes : générer des images PNG à une fréquence d'images choisie, puis encoder la séquence d'images en MP4. Utilisez la même fréquence d'images dans les deux étapes pour préserver le timing des animations.

Avant d'exécuter l'exemple :

1. Installez [Aspose.Slides for Python via Java](/slides/fr/python-java/installation/).
2. Téléchargez [FFmpeg](https://ffmpeg.org/download.html) et rendez son exécutable disponible dans `PATH`. L'exemple utilise une version avec l'encodeur `libx264`.
3. Exécutez le code Python suivant dans un répertoire accessible en écriture.

L'exemple crée une forme souriante avec des animations d'entrée et de sortie, rend les images à 30 FPS et appelle FFmpeg pour créer `output.mp4`. Un nouveau répertoire d'images empêche les images des exécutions précédentes d'être incluses dans la vidéo.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Pour convertir un fichier existant, initialisez [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) avec son chemin et omettez les instructions de création de forme et d'animation.

La commande FFmpeg lit une [séquence d'images](https://ffmpeg.org/ffmpeg-formats.html#image2) numérotée, ajuste les dimensions impaires à des valeurs paires, puis écrit une vidéo H.264 avec le format pixel `yuv420p`. L'option `-n` empêche d'écraser un fichier de sortie existant. Les fichiers PNG générés restent dans le répertoire d'images ; supprimez‑les lorsqu'ils ne sont plus nécessaires.

{{% alert color="info" title="Remarque" %}}
Cet exemple n'encode que les images. Il n'ajoute pas de narration ni d'audio intégré de la présentation à la vidéo de sortie.
{{% /alert %}}

## **Effets vidéo**

Les animations contrôlent la façon dont les objets de la diapositive apparaissent, se déplacent ou disparaissent. Les transitions contrôlent le changement entre les diapositives. Ajoutez ces effets avant de générer les images vidéo.

Voir [Animation PowerPoint](/slides/fr/python-java/powerpoint-animation/), [Animation de Forme](/slides/fr/python-java/shape-animation/), [Effets de Forme](/slides/fr/python-java/shape-effect/), et [Transitions de Diapositive](/slides/fr/python-java/slide-transition/).

### **Ajouter une Transition de Diapositive**

L'exemple autonome suivant crée une présentation avec deux diapositives. La deuxième diapositive a un arrière‑plan magenta et une transition de type push. Enregistrez la présentation, puis utilisez‑la comme entrée de l'exemple de génération d'images ci‑dessus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Animer les Paragraphes**

Le texte peut apparaître paragraphe par paragraphe. Cet exemple crée trois paragraphes avec des effets d'entrée en fondu séquentiels, chacun retardé d'une seconde après l'effet précédent. Utilisez le fichier `paragraphs.pptx` enregistré comme entrée de l'exemple de conversion vidéo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Classes de Conversion Vidéo**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationanimationsgenerator/) génère des événements d'animation pour les diapositives. Le construire à partir d'une présentation utilise la taille des diapositives de la présentation pour les images. Utilisez [setDefaultDelay](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) pour configurer le délai par défaut en millisecondes.

[PresentationPlayer](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationplayer/) prélève les animations générées à la fréquence d'images fournie à son constructeur. Enregistrez un rappel Python via JPype avec [setFrameTick](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationplayer/#setFrameTick), puis appelez [run](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationanimationsgenerator/#run) pour générer les images. Le premier exemple utilise son propre compteur zéro‑basé afin que les noms de fichiers correspondent à la séquence d'entrée de FFmpeg.

Pour les états d'animation individuels, enregistrez un rappel avec [setNewAnimation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). Le rappel reçoit un lecteur d'animation qui peut être positionné à un moment sélectionné. L'exemple suivant enregistre les premières et dernières images de chaque animation générée avec des noms de fichiers uniques :

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Animations et Effets Pris en Charge**

Les tableaux suivants résument la prise en charge du rendu décrite dans l'article de conversion Java. Prévisualisez les images générées lorsqu'une présentation utilise des effets non pris en charge.

**Entrée**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly In** | Yes | Yes |
| **Float In** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Wheel** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Grow & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Accentuation**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | No | Yes |
| **Color Pulse** | No | Yes |
| **Teeter** | Yes | Yes |
| **Spin** | Yes | Yes |
| **Grow/Shrink** | No | Yes |
| **Desaturate** | No | Yes |
| **Darken** | No | Yes |
| **Lighten** | No | Yes |
| **Transparency** | No | Yes |
| **Object Color** | No | Yes |
| **Complementary Color** | No | Yes |
| **Line Color** | No | Yes |
| **Fill Color** | No | Yes |

**Sortie**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly Out** | Yes | Yes |
| **Float Out** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Shrink & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Chemins de Mouvement**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **FAQ**

**Aspose.Slides crée‑t‑il directement un fichier MP4 ?**

Non. Aspose.Slides génère les images de la présentation. Utilisez un encodeur vidéo tel que FFmpeg pour les combiner en un fichier MP4.

**Pourquoi la vidéo se lit‑elle plus vite ou plus lentement que prévu ?**

Utilisez le même nombre d'images par seconde pour la génération des images et le taux d'images d'entrée de l'encodeur. Un décalage modifie la durée de lecture de la séquence d'images.

**Puis‑je convertir une présentation protégée par mot de passe ?**

Oui. Fournissez le mot de passe correct lors du [chargement de la présentation protégée](/slides/fr/python-java/password-protected-presentation/), puis générez les images à partir du contenu chargé.

**Ce flux de travail préserve‑t‑il l'audio de la présentation ?**

Les exemples exportent des images, donc la vidéo résultante est muette. Pour inclure l'audio, fournissez une piste audio séparément lors de l'encodage vidéo.

**Comment réduire l'utilisation temporaire du disque ?**

Utilisez une taille d'image plus petite ou un FPS inférieur, et supprimez les fichiers PNG temporaires après un encodage réussi. Vérifiez la qualité de la vidéo résultante lors de la réduction de l'un ou l'autre paramètre.