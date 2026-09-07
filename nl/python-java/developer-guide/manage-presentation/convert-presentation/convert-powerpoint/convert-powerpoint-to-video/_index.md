---
title: PowerPoint-presentaties naar video converteren in Python
linktitle: PowerPoint naar video
type: docs
weight: 130
url: /nl/python-java/convert-powerpoint-to-video/
keywords:
- PowerPoint converteren
- presentatie converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar video
- presentatie naar video
- PPT naar video
- PPTX naar video
- PowerPoint naar MP4
- presentatie naar MP4
- PPT naar MP4
- PPTX naar MP4
- PPT opslaan als MP4
- PPTX opslaan als MP4
- PPT exporteren naar MP4
- PPTX exporteren naar MP4
- video-conversie
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "PowerPoint-presentaties converteren naar MP4-video in Python via Java. Frames genereren met Aspose.Slides en deze coderen met FFmpeg, inclusief animaties en overgangen."
---
## **Overzicht**

Een PowerPoint‑ of OpenDocument‑presentatie naar video omzetten, maakt het mogelijk om de inhoud te bekijken in een videospeler zonder een presentatietoepassing te openen. Aspose.Slides for Python via Java renderen animaties en overgangen van de presentatie naar afbeeldingsframes. Een aparte encoder, zoals FFmpeg, combineert die frames tot een videobestand.

{{% alert color="info" title="Opmerking" %}}
Probeer de online [PowerPoint naar Video‑converter](https://products.aspose.app/slides/nl/video) om de conversie van presentatie naar video in actie te zien.
{{% /alert %}}

## **PowerPoint naar Video omzetten**

De conversie bestaat uit twee fasen: PNG‑frames genereren met een gekozen framesnelheid, daarna de afbeeldingsreeks coderen als MP4. Gebruik dezelfde framesnelheid in beide fasen om de animatietiming te behouden.

Voor je het voorbeeld uitvoert:

1. Installeer [Aspose.Slides for Python via Java](/slides/nl/python-java/installation/).
2. Download [FFmpeg](https://ffmpeg.org/download.html) en zorg dat het uitvoerbare bestand beschikbaar is via `PATH`. Het voorbeeld gebruikt een build met de `libx264`‑encoder.
3. Voer de volgende Python‑code uit in een map waarin je kunt schrijven.

Het voorbeeld maakt een lachende vorm met in‑ en uit‑animaties, rendert frames met 30 FPS en roept FFmpeg aan om `output.mp4` te maken. Een nieuwe frame‑map voorkomt dat frames van eerdere runs in de video worden opgenomen.

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

Om een bestaand bestand te converteren, initialiseer je [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) met het pad en laat je de statements voor het maken van vormen en animaties weg.

De FFmpeg‑opdracht leest een genummerde [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2), brengt oneven afmetingen naar even waarden en schrijft een H.264‑video met het pixel‑formaat `yuv420p`. De optie `-n` voorkomt overschrijven van een bestaand uitvoerbestand. De gegenereerde PNG‑bestanden blijven in de frame‑map; verwijder ze zodra ze niet meer nodig zijn.

{{% alert color="info" title="Opmerking" %}}
Dit voorbeeld codeert alleen beeldframes. Het voegt geen voice‑over of ingebouwde presentatiesound toe aan de uitvoervideo.
{{% /alert %}}

## **Video‑effecten**

Animaties bepalen hoe objecten op een dia verschijnen, bewegen of verdwijnen. Overgangen bepalen de verandering tussen dia's. Voeg deze effecten toe vóór het genereren van videoframes.

Zie [PowerPoint‑animatie](/slides/nl/python-java/powerpoint-animation/), [Vorm‑animatie](/slides/nl/python-java/shape-animation/), [Vorm‑effecten](/slides/nl/python-java/shape-effect/) en [Dia‑overgangen](/slides/nl/python-java/slide-transition/).

### **Een dia‑overgang toevoegen**

Het volgende zelfstandige voorbeeld maakt een presentatie met twee dia's. De tweede dia heeft een magenta‑achtergrond en een push‑overgang. Sla de presentatie op en gebruik die vervolgens als invoer voor het frame‑generatie‑voorbeeld hierboven.

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

### **Paragraph‑animaties**

Tekst kan alinea voor alinea verschijnen. Dit voorbeeld maakt drie alinea's met opeenvolgende fade‑in‑effecten, elk een seconde vertraagd ten opzichte van het vorige effect. Gebruik het opgeslagen bestand `paragraphs.pptx` als invoer voor het video‑conversie‑voorbeeld.

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

## **Video‑conversie‑klassen**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationanimationsgenerator/) genereert animatie‑events voor de dia's. Wanneer je het constructie‑object maakt vanuit een presentatie, wordt de dia‑grootte van de presentatie gebruikt voor de frames. Gebruik [setDefaultDelay](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) om de standaardvertraging in milliseconden in te stellen.

[PresentationPlayer](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationplayer/) neemt monsters van de gegenereerde animaties op de framesnelheid die aan de constructor wordt doorgegeven. Registreer een Python‑callback via JPype met [setFrameTick](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationplayer/#setFrameTick) en roep vervolgens [run](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationanimationsgenerator/#run) aan om de frames te genereren. Het eerste voorbeeld gebruikt een eigen nul‑gebaseerde teller zodat de bestandsnamen overeenkomen met de invoersequentie van FFmpeg.

Voor individuele animatiestatussen registreer je een callback met [setNewAnimation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). De callback ontvangt een animatie‑speler die op een geselecteerde tijd kan worden gepositioneerd. Het volgende voorbeeld slaat het eerste en laatste frame van elke gegenereerde animatie op met unieke bestandsnamen:

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

## **Ondersteunde animaties en effecten**

De volgende tabellen geven een overzicht van de renderondersteuning zoals beschreven in het Java‑conversie‑artikel. Bekijk de gegenereerde frames wanneer een presentatie effecten bevat die niet worden ondersteund.

**Ingang**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Nadruk**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Uitgang**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Bewegingspaden**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **FAQ**

**Maakt Aspose.Slides direct een MP4‑bestand?**

Nee. Aspose.Slides genereert presentatief rames. Gebruik een video‑encoder zoals FFmpeg om ze te combineren tot een MP4‑bestand.

**Waarom wordt de video sneller of langzamer afgespeeld dan verwacht?**

Gebruik dezelfde FPS voor het genereren van frames en voor de invoer‑frame‑rate van de encoder. Een verschil verandert de afspeelduur van de afbeeldingsreeks.

**Kan ik een met wachtwoord beveiligde presentatie converteren?**

Ja. Geef het juiste wachtwoord op bij het [laden van de beveiligde presentatie](/slides/nl/python-java/password-protected-presentation/), en genereer vervolgens frames vanuit de geladen inhoud.

**Behoudt deze workflow de audiotrack van de presentatie?**

De voorbeelden exporteren alleen beeldframes, waardoor de resulterende video stil is. Om audio toe te voegen, moet je een audiotrack apart bij het video‑encoderen invoegen.

**Hoe kan ik tijdelijk schijfgebruik verminderen?**

Gebruik een kleinere frame‑grootte of een lagere FPS, en verwijder de tijdelijke PNG‑bestanden na een geslaagde codering. Controleer de videokwaliteit wanneer je één van beide instellingen verlaagt.