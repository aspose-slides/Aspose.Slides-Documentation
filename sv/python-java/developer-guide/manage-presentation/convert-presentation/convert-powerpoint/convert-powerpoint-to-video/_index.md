---
title: "Konvertera PowerPoint-presentationer till video i Python"
linktitle: "PowerPoint till video"
type: docs
weight: 130
url: /sv/python-java/convert-powerpoint-to-video/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera PPT
- konvertera PPTX
- PowerPoint till video
- presentation till video
- PPT till video
- PPTX till video
- PowerPoint till MP4
- presentation till MP4
- PPT till MP4
- PPTX till MP4
- spara PPT som MP4
- spara PPTX som MP4
- exportera PPT till MP4
- exportera PPTX till MP4
- videokonvertering
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till MP4-video i Python via Java. Generera ramar med Aspose.Slides och koda dem med FFmpeg, inklusive animationer och övergångar."
---
## **Översikt**

Att konvertera en PowerPoint‑ eller OpenDocument‑presentation till video låter visare titta på innehållet i en videospelare utan att öppna ett presentationsprogram. Aspose.Slides för Python via Java renderar presentationsanimationer och övergångar till bildrutor. En separat kodare, till exempel FFmpeg, kombinerar dessa rutor till en videofil.

{{% alert color="info" title="Obs" %}}
Prova den online [PowerPoint till Video‑omvandlaren](https://products.aspose.app/slides/sv/video) för att se presentation‑till‑video‑konvertering i praktiken.
{{% /alert %}}

## **Konvertera PowerPoint till video**

Konverteringen har två steg: generera PNG‑rutor med en vald bildfrekvens och sedan koda bildsekvensen som MP4. Använd samma bildfrekvens i båda stegen för att bevara animationstiden.

Innan du kör exemplet:

1. Installera [Aspose.Slides för Python via Java](/slides/sv/python-java/installation/).
2. Hämta [FFmpeg](https://ffmpeg.org/download.html) och gör dess körbara fil tillgänglig på `PATH`. Exemplet använder en build med `libx264`‑kodaren.
3. Kör följande Python‑kod i en skrivbar katalog.

Exemplet skapar en leende form med ingångs‑ och utgångsanimationer, renderar rutor med 30 FPS och anropar FFmpeg för att skapa `output.mp4`. En ny ramkatalog förhindrar att rutor från tidigare körningar inkluderas i videon.

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

För att konvertera en befintlig fil, initiera [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) med dess sökväg och utelämna skapandet av form‑ och animationssatser.

FFmpeg‑kommandot läser en numrerad [bildsekvens](https://ffmpeg.org/ffmpeg-formats.html#image2), fyller ut ojämna dimensioner till jämna värden och skriver H.264‑video med pixelformatet `yuv420p`. Alternativet `-n` förhindrar överskrivning av en befintlig utskriftsfil. Genererade PNG‑filer kvarstår i ramkatalogen; ta bort dem när de inte längre behövs.

{{% alert color="info" title="Obs" %}}
Detta exempel kodar endast bildrutor. Det lägger inte till berättarröst eller inbäddat presentationsljud i den resulterande videon.
{{% /alert %}}

## **Videoeffekter**

Animationer styr hur bildobjekt visas, rör sig eller försvinner. Övergångar styr förändringen mellan bilder. Lägg till dessa effekter innan du genererar videoramar.

Se [PowerPoint‑animation](/slides/sv/python-java/powerpoint-animation/), [Form‑animation](/slides/sv/python-java/shape-animation/), [Form‑effekter](/slides/sv/python-java/shape-effect/) och [Bild‑övergångar](/slides/sv/python-java/slide-transition/).

### **Lägg till en bildövergång**

Följande fristående exempel skapar en presentation med två bilder. Den andra bilden har en magentafarvet bakgrund och en push‑övergång. Spara presentationen och använd den sedan som indata till exempel‑ramgenereringen ovan.

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

### **Animera stycken**

Text kan visas stycke för stycke. Detta exempel skapar tre stycken med sekventiella fade‑ingångseffekter, var och en fördröjd med en sekund efter föregående effekt. Använd den sparade filen `paragraphs.pptx` som indata till videokonverterings‑exemplet.

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

## **Klasser för videokonvertering**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationanimationsgenerator/) genererar animationsevenemang för bilderna. Att konstruera den från en presentation använder presentationens bildstorlek för ramarna. Använd [setDefaultDelay](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) för att konfigurera standardfördröjning i millisekunder.

[PresentationPlayer](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationplayer/) samplar de genererade animationerna med bildfrekvensen som anges i dess konstruktor. Registrera ett Python‑återanrop via JPype med [setFrameTick](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationplayer/#setFrameTick) och anropa sedan [run](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationanimationsgenerator/#run) för att generera ramarna. Det första exemplet använder sin egen nollbaserade räknare så att filnamnen matchar FFmpegs indatasekvens.

För enskilda animationsstatusar, registrera ett återanrop med [setNewAnimation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). Återanropet får en animationsspelare som kan positioneras vid en vald tidpunkt. Följande exempel sparar den första och sista ramen för varje genererad animation med unika filnamn:

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

## **Stödda animationer och effekter**

Följande tabeller sammanfattar renderingsstödet som beskrivs i Java‑konverterings‑artikeln. Förhandsgranska de genererade ramarna när en presentation använder effekter som inte stöds.

**Ingång**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | Nej | Ja |
| **Fade** | Ja | Ja |
| **Fly In** | Ja | Ja |
| **Float In** | Ja | Ja |
| **Split** | Ja | Ja |
| **Wipe** | Ja | Ja |
| **Shape** | Ja | Ja |
| **Wheel** | Ja | Ja |
| **Random Bars** | Ja | Ja |
| **Grow & Turn** | Nej | Ja |
| **Zoom** | Ja | Ja |
| **Swivel** | Ja | Ja |
| **Bounce** | Ja | Ja |

**Betoning**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | Nej | Ja |
| **Color Pulse** | Nej | Ja |
| **Teeter** | Ja | Ja |
| **Spin** | Ja | Ja |
| **Grow/Shrink** | Nej | Ja |
| **Desaturate** | Nej | Ja |
| **Darken** | Nej | Ja |
| **Lighten** | Nej | Ja |
| **Transparency** | Nej | Ja |
| **Object Color** | Nej | Ja |
| **Complementary Color** | Nej | Ja |
| **Line Color** | Nej | Ja |
| **Fill Color** | Nej | Ja |

**Utgång**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | Nej | Ja |
| **Fade** | Ja | Ja |
| **Fly Out** | Ja | Ja |
| **Float Out** | Ja | Ja |
| **Split** | Ja | Ja |
| **Wipe** | Ja | Ja |
| **Shape** | Ja | Ja |
| **Random Bars** | Ja | Ja |
| **Shrink & Turn** | Nej | Ja |
| **Zoom** | Ja | Ja |
| **Swivel** | Ja | Ja |
| **Bounce** | Ja | Ja |

**Rörelsespår**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Ja | Ja |
| **Arcs** | Ja | Ja |
| **Turns** | Ja | Ja |
| **Shapes** | Ja | Ja |
| **Loops** | Ja | Ja |
| **Custom Path** | Ja | Ja |

## **FAQ**

**Skapar Aspose.Slides en MP4‑fil direkt?**

Nej. Aspose.Slides genererar presentationsrutor. Använd en video‑kodare som FFmpeg för att kombinera dem till en MP4‑fil.

**Varför spelas videon snabbare eller långsammare än förväntat?**

Använd samma FPS för ramgenerering och kodarens indata‑bildfrekvens. En avvikelse ändrar uppspelningslängden för bildsekvensen.

**Kan jag konvertera en lösenordsskyddad presentation?**

Ja. Ange rätt lösenord när du [läser in den skyddade presentationen](/slides/sv/python-java/password-protected-presentation/), och generera sedan ramar från det inlästa innehållet.

**Bevarar detta arbetsflöde presentations‑ljud?**

Exemplen exporterar bildrutor, så den resulterande videon är tyst. För att inkludera ljud, tillhandahåll ett ljudspår separat under videokodning.

**Hur kan jag minska temporärt diskutrymme?**

Använd en mindre ramstorlek eller en lägre FPS och ta bort temporära PNG‑filer efter lyckad kodning. Kontrollera den resulterande videokvaliteten när du minskar någon av inställningarna.