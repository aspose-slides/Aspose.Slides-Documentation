---
title: PowerPoint-presentaties naar video converteren met Python
linktitle: PowerPoint naar video
type: docs
weight: 130
url: /nl/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint naar video
- PowerPoint omzetten naar video
- presentatie naar video
- presentatie omzetten naar video
- PPT naar video
- PPT omzetten naar video
- PPTX naar video
- PPTX omzetten naar video
- ODP naar video
- ODP omzetten naar video
- PowerPoint naar MP4
- PowerPoint omzetten naar MP4
- presentatie naar MP4
- presentatie omzetten naar MP4
- PPT naar MP4
- PPT omzetten naar MP4
- PPTX naar MP4
- PPTX omzetten naar MP4
- PowerPoint-video-conversie
- presentatie-video-conversie
- PPT-video-conversie
- PPTX-video-conversie
- ODP-video-conversie
- Python-video-conversie
- PowerPoint
- Python
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties kunt omzetten naar video met Python. Ontdek voorbeeldcode en automatiseringstechnieken om uw workflow te stroomlijnen."
---
## **Introductie**

Door uw PowerPoint‑ of OpenDocument‑presentatie naar video te converteren, krijgt u:

**Verhoogde toegankelijkheid:** Alle apparaten, ongeacht het platform, zijn standaard uitgerust met videospelers, waardoor het voor gebruikers makkelijker is om video's te openen of af te spelen dan traditionele presentatie‑applicaties.

**Groter bereik:** Video’s stellen u in staat een groter publiek te bereiken en informatie op een boeiendere manier te presenteren. Enquêtes en statistieken tonen aan dat mensen liever video‑inhoud bekijken en consumeren dan andere vormen, waardoor uw boodschap meer impact heeft.

{{% alert color="primary" %}} 

Bekijk onze [**PowerPoint naar Video Online Converter**](https://products.aspose.app/slides/nl/video) omdat het een live en effectieve implementatie biedt van het hier beschreven proces.

{{% /alert %}} 

In Aspose.Slides for Python 24.4 hebben we ondersteuning geïmplementeerd voor het converteren van presentaties naar video.

* Gebruik Aspose.Slides for Python om frames uit de presentatieslides te genereren met een opgegeven framerate (FPS).
* Gebruik vervolgens een hulpprogramma van derden, zoals ffmpeg, om deze frames samen te voegen tot een video.

## **Converteer een PowerPoint‑presentatie naar video**

1. Gebruik de pip‑install‑opdracht om Aspose.Slides for Python aan uw project toe te voegen: `pip install aspose-slides==24.4.0`
2. Download ffmpeg van [hier](https://ffmpeg.org/download.html) of installeer het via de pakketbeheerder.
3. Zorg ervoor dat ffmpeg in de `PATH` staat. Zo niet, start ffmpeg met het volledige pad naar het uitvoerbare bestand (bijv. `C:\ffmpeg\ffmpeg.exe` op Windows of `/opt/ffmpeg/ffmpeg` op Linux).
4. Voer de PowerPoint‑naar‑video‑conversiecode uit.

Deze Python‑code toont hoe u een presentatie (met een vorm en twee animatie‑effecten) naar een video converteert:

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

## **Video‑effecten**

Bij het converteren van een PowerPoint‑presentatie naar video met Aspose.Slides for Python kunt u diverse video‑effecten toepassen om de visuele kwaliteit van het resultaat te verbeteren. Deze effecten laten u het uiterlijk van slides in de uiteindelijke video sturen door vloeiende overgangen, animaties en andere visuele elementen toe te voegen. Deze sectie legt de beschikbare video‑effectopties uit en laat zien hoe u ze toepast.

{{% alert color="primary" %}} 

Zie [PowerPoint‑animatie](https://docs.aspose.com/slides/nl/python-net/powerpoint-animation/), [Vormanimatie](https://docs.aspose.com/slides/nl/python-net/shape-animation/), en [Vorm‑effect](https://docs.aspose.com/slides/nl/python-net/shape-effect/).

{{% /alert %}} 

Animaties en overgangen maken diavoorstellingen aantrekkelijker en interessanter — en hetzelfde geldt voor video’s. Laten we een extra slide en overgang toevoegen aan de code voor de vorige presentatie:

```python
import aspose.pydrawing as drawing

# Voeg een glimlachvorm toe en animeer deze.
# ...

# Voeg een nieuwe dia toe en een geanimeerde overgang.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python ondersteunt ook tekstanimaties. In dit voorbeeld animeren we alinea’s op objecten zodat ze één voor één verschijnen, met een vertraging van één seconde tussen elke alinea:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Voeg tekst en animaties toe.
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

    # Converteer frames naar video.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Video‑conversieklassen**

Om PowerPoint‑naar‑video‑taken mogelijk te maken, biedt Aspose.Slides for Python de [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` stelt u in staat de frame‑grootte voor de (later te maken) video en de FPS‑waarde (frames per seconde) via de constructor in te stellen. Als u een presentatie‑instantie doorgeeft, wordt de `Presentation.SlideSize` daarvan gebruikt.

Om alle animaties in een presentatie tegelijk af te laten spelen, gebruikt u de methode `PresentationEnumerableFramesGenerator.enumerate_frames`. Deze methode neemt een collectie slides en geeft opeenvolgend [EnumerableFrameArgs](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/enumerableframeargs/) terug. Gebruik vervolgens `EnumerableFrameArgs.get_frame()` om elk video‑frame te verkrijgen.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

De gegenereerde frames kunnen daarna worden samengevoegd tot een video. Voor meer details, zie de [Converteer PowerPoint naar Video](https://docs.aspose.com/slides/nl/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video) sectie.

## **Ondersteunde animaties en effecten**

Bij het converteren van een PowerPoint‑presentatie naar video met Aspose.Slides for Python is het belangrijk te weten welke animaties en effecten in de uitvoer worden ondersteund. Aspose.Slides ondersteunt een breed scala aan gangbare in‑, uit‑ en nadruk‑effecten zoals vervagen, binnenvliegen, inzoomen en draaien. Sommige geavanceerde of aangepaste animaties worden echter mogelijk niet volledig behouden of kunnen er anders uitzien in de uiteindelijke video. Deze sectie geeft een overzicht van de ondersteunde animaties en effecten.

**Ingang**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Nadruk**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Uitgang**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Bewegingspaden**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Ondersteunde diaovergangseffecten**

Dia‑overgangseffecten spelen een belangrijke rol bij het creëren van vloeiende en visueel aantrekkelijke overgangen tussen slides in een video. Aspose.Slides for Python ondersteunt een verscheidenheid aan veelgebruikte overgangseffecten om de stroom en stijl van uw originele presentatie te behouden. Deze sectie belicht welke overgangseffecten tijdens het conversie‑proces worden ondersteund.

**Subtiel**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Opwindend**:

| Animatietype | Aspose.Slides | PowerPoint |
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

**Dynamische inhoud**:

| Animatietype | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Veelgestelde vragen**

**Is het mogelijk om presentaties die met een wachtwoord beveiligd zijn te converteren?**

Ja, Aspose.Slides for Python maakt het werken met met wachtwoord beveiligde presentaties mogelijk. Bij het verwerken van dergelijke bestanden dient u het juiste wachtwoord op te geven zodat de bibliotheek toegang krijgt tot de inhoud van de presentatie.

**Ondersteunt Aspose.Slides for Python gebruik in cloud‑oplossingen?**

Ja, Aspose.Slides for Python kan worden geïntegreerd in cloud‑applicaties en -services. De bibliotheek is ontworpen om in serveromgevingen te functioneren, met hoge prestaties en schaalbaarheid voor batchverwerking van bestanden.

**Zijn er grootte‑beperkingen voor presentaties tijdens de conversie?**

Aspose.Slides for Python kan presentaties van praktisch elke grootte aan. Bij zeer grote bestanden kan echter extra systeem­resources nodig zijn, en het wordt soms aanbevolen de presentatie te optimaliseren om de prestaties te verbeteren.