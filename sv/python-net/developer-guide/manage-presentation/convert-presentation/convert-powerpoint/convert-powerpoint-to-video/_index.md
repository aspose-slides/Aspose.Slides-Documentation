---
title: Konvertera PowerPoint-presentationer till video i Python
linktitle: PowerPoint till video
type: docs
weight: 130
url: /sv/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint till video
- konvertera PowerPoint till video
- presentation till video
- konvertera presentation till video
- PPT till video
- konvertera PPT till video
- PPTX till video
- konvertera PPTX till video
- ODP till video
- konvertera ODP till video
- PowerPoint till MP4
- konvertera PowerPoint till MP4
- presentation till MP4
- konvertera presentation till MP4
- PPT till MP4
- konvertera PPT till MP4
- PPTX till MP4
- konvertera PPTX till MP4
- PowerPoint till videokonvertering
- presentation till videokonvertering
- PPT till videokonvertering
- PPTX till videokonvertering
- ODP till videokonvertering
- Python videokonvertering
- PowerPoint
- Python
- Aspose.Slides
description: "Lär dig hur du konverterar PowerPoint- och OpenDocument-presentationer till video med Python. Upptäck exempel på kod och automatiseringstekniker för att effektivisera ditt arbetsflöde."
---
## **Introduktion**

Genom att konvertera din PowerPoint- eller OpenDocument-presentation till video får du:

**Ökad tillgänglighet:** Alla enheter, oavsett plattform, har som standard videospelare, vilket gör det enklare för användare att öppna eller spela upp videor jämfört med traditionella presentationsprogram.

**Bredare räckvidd:** Videor gör det möjligt att nå en större publik och presentera information i ett mer engagerande format. Undersökningar och statistik visar att människor föredrar att titta på och konsumera videoinnehåll framför andra former, vilket gör ditt budskap mer kraftfullt.

{{% alert color="primary" %}} 

Kolla in vår [**PowerPoint till Video Online‑konverterare**](https://products.aspose.app/slides/sv/video) eftersom den erbjuder en levande och effektiv implementering av processen som beskrivs här.

{{% /alert %}} 

I [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/sv/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) implementerade vi stöd för att konvertera presentationer till video.

* Använd Aspose.Slides for Python för att generera bildrutor från presentationsbilderna med en specificerad bildfrekvens (FPS).
* Använd sedan ett tredjepartsverktyg som ffmpeg för att sammanställa dessa bildrutor till en video.

## **Konvertera en PowerPoint-presentation till video**

1. Använd pip‑install‑kommandot för att lägga till Aspose.Slides for Python i ditt projekt: `pip install aspose-slides==24.4.0`
2. Hämta ffmpeg från [här](https://ffmpeg.org/download.html) eller installera det via pakethanteraren.
3. Se till att ffmpeg finns i `PATH`. Annars starta ffmpeg med den fullständiga sökvägen till den körbara filen (t.ex. `C:\ffmpeg\ffmpeg.exe` på Windows eller `/opt/ffmpeg/ffmpeg` på Linux).
4. Kör koden för PowerPoint‑till‑video‑konvertering.

Denna Python‑kod visar hur man konverterar en presentation (som innehåller en form och två animeringseffekter) till en video:

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

## **Videoeffekter**

När du konverterar en PowerPoint-presentation till video med Aspose.Slides for Python kan du applicera olika videoeffekter för att förbättra den visuella kvaliteten på resultatet. Dessa effekter låter dig styra hur bilderna ser ut i den färdiga videon genom att lägga till mjuka övergångar, animationer och andra visuella element. Denna avsnitt förklarar de tillgängliga videoeffektalternativen och visar hur man använder dem.

{{% alert color="primary" %}} 

Se [PowerPoint‑animation](https://docs.aspose.com/slides/sv/python-net/powerpoint-animation/), [Form‑animation](https://docs.aspose.com/slides/sv/python-net/shape-animation/), och [Form‑effekt](https://docs.aspose.com/slides/sv/python-net/shape-effect/).

{{% /alert %}} 

Animationer och övergångar gör bildspel mer engagerande och intressanta — och de gör samma sak för videor. Låt oss lägga till en ytterligare bild och en övergång i koden för den föregående presentationen:

```python
import aspose.pydrawing as drawing

# Lägg till en leendeform och animera den.
# ...

# Lägg till en ny bild och en animerad övergång.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python stödjer också textanimationer. I detta exempel animerar vi stycken på objekt så att de visas ett efter ett, med en sekunds fördröjning mellan dem:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till text och animationer.
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

    # Konvertera bildrutor till video.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Klasser för videokonvertering**

För att möjliggöra PowerPoint‑till‑video‑konverteringsuppgifter tillhandahåller Aspose.Slides for Python [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` låter dig ange bildstorleken för videon (som kommer att skapas senare) och FPS‑värdet (bilder per sekund) via dess konstruktor. Om du anger en instans av en presentation kommer dess `Presentation.SlideSize` att användas.

För att låta alla animationer i en presentation spelas upp samtidigt, använd metoden `PresentationEnumerableFramesGenerator.enumerate_frames`. Denna metod tar en samling bilder och returnerar sekventiellt [EnumerableFrameArgs](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/enumerableframeargs/). Använd sedan `EnumerableFrameArgs.get_frame()` för att hämta varje videobildruta.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Därefter kan de genererade bildrutorna sammanställas till en video. För mer information, se avsnittet [Konvertera PowerPoint till video](https://docs.aspose.com/slides/sv/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Stödda animationer och effekter**

När du konverterar en PowerPoint-presentation till video med Aspose.Slides for Python är det viktigt att förstå vilka animationer och effekter som stöds i resultatet. Aspose.Slides stödjer ett brett spektrum av vanliga inträdes-, utgångs‑ och betoningseffekter såsom toning, inflygning, zoom och rotation. Vissa avancerade eller anpassade animationer kan dock inte bevaras helt eller kan visas annorlunda i den färdiga videon. Detta avsnitt beskriver de stödda animationerna och effekterna.

**Inträde**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Betoning**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Utgång**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Rörelsebanor**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Stödda bildövergångseffekter**

Bildövergångseffekter spelar en viktig roll för att skapa smidiga och visuellt tilltalande övergångar mellan bilder i en video. Aspose.Slides for Python stödjer en mängd vanliga övergångseffekter för att bevara flödet och stilen i din ursprungliga presentation. Detta avsnitt lyfter fram vilka övergångseffekter som stöds under konverteringsprocessen.

**Subtila**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Spännande**:

| Animationstyp | Aspose.Slides | PowerPoint |
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

**Dynamiskt innehåll**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Vanliga frågor**

**Är det möjligt att konvertera presentationer som är lösenordsskyddade?**

Ja, Aspose.Slides for Python tillåter arbete med lösenordsskyddade presentationer. Vid bearbetning av sådana filer måste du ange rätt lösenord så att biblioteket kan komma åt presentationens innehåll.

**Stöder Aspose.Slides for Python användning i molnlösningar?**

Ja, Aspose.Slides for Python kan integreras i molnapplikationer och -tjänster. Biblioteket är designat för att fungera i servermiljöer och säkerställer hög prestanda och skalbarhet för batchbearbetning av filer.

**Finns det några storleksbegränsningar för presentationer vid konvertering?**

Aspose.Slides for Python kan hantera presentationer av i princip vilken storlek som helst. Vid arbete med mycket stora filer kan dock ytterligare systemresurser behövas, och det kan ibland rekommenderas att optimera presentationen för att förbättra prestandan.