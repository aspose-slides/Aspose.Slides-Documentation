---
title: Převod prezentací PowerPoint na video v Pythonu
linktitle: PowerPoint na video
type: docs
weight: 130
url: /cs/python-java/convert-powerpoint-to-video/
keywords:
- převést PowerPoint
- převést prezentaci
- převést PPT
- převést PPTX
- PowerPoint na video
- prezentace na video
- PPT na video
- PPTX na video
- PowerPoint na MP4
- prezentace na MP4
- PPT na MP4
- PPTX na MP4
- uložit PPT jako MP4
- uložit PPTX jako MP4
- exportovat PPT do MP4
- exportovat PPTX do MP4
- převod videa
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "Převést prezentace PowerPoint na MP4 video v Pythonu pomocí Javy. Generujte snímky pomocí Aspose.Slides a zakódujte je pomocí FFmpeg, včetně animací a přechodů."
---
## **Přehled**

Převod prezentace PowerPoint nebo OpenDocument na video umožňuje divákům sledovat její obsah ve video přehrávači bez nutnosti otevírat aplikaci pro prezentace. Aspose.Slides for Python via Java převádí animace a přechody prezentace na snímky obrázků. Samostatný enkodér, například FFmpeg, spojí tyto snímky do video souboru.

{{% alert color="info" title="Poznámka" %}}
Vyzkoušejte online [PowerPoint na Video převodník](https://products.aspose.app/slides/cs/video) a podívejte se na převod prezentace na video v akci.
{{% /alert %}}

## **Převod PowerPointu na video**

Převod probíhá ve dvou fázích: vytvoří se PNG snímky při zvolené snímkové rychlosti a poté se sekvence obrázků zakóduje do MP4. Použijte stejnou snímkovou rychlost v obou fázích, aby se zachoval čas animací.

Před spuštěním příkladu:

1. Nainstalujte [Aspose.Slides for Python via Java](/slides/cs/python-java/installation/).
2. Stáhněte [FFmpeg](https://ffmpeg.org/download.html) a zajistěte, aby byl spustitelný soubor dostupný v `PATH`. Příklad používá sestavení s enkodérem `libx264`.
3. Spusťte následující Python kód v zapisovatelném adresáři.

Příklad vytvoří usmívající se tvar s animačními efekty vstupu a výstupu, vykreslí snímky při 30 FPS a zavolá FFmpeg k vytvoření souboru `output.mp4`. Čerstvý adresář se snímky zabraňuje zahrnutí snímků z předchozích běhů do videa.

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

Pro převod existujícího souboru inicializujte [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) s jeho cestou a vynechte příkazy pro vytvoření tvaru a animace.

Příkaz FFmpeg čte očíslovanou [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2), doplní liché rozměry na sudé hodnoty a zapíše video H.264 s formátem pixelů `yuv420p`. Přepínač `-n` zabraňuje přepsání existujícího výstupního souboru. Vygenerované PNG soubory zůstávají v adresáři se snímky; odstraňte je, když již nejsou potřeba.

{{% alert color="info" title="Poznámka" %}}
Tento příklad kódu kóduje pouze obrázkové snímky. Nepřidává komentář ani vložený zvuk prezentace do výstupního videa.
{{% /alert %}}

## **Video efekty**

Animace určují, jak se objekty na snímku objevují, pohybují nebo mizí. Přechody řídí změnu mezi snímky. Přidejte tyto efekty před generováním video snímků.

Viz [PowerPoint Animation](/slides/cs/python-java/powerpoint-animation/), [Shape Animation](/slides/cs/python-java/shape-animation/), [Shape Effects](/slides/cs/python-java/shape-effect/) a [Slide Transitions](/slides/cs/python-java/slide-transition/).

### **Přidání přechodu mezi snímky**

Následující samostatný příklad vytvoří prezentaci se dvěma snímky. Druhý snímek má fialové pozadí a přechod „push“. Uložte prezentaci a použijte ji jako vstup do výše uvedeného příkladu pro generování snímků.

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

### **Animace odstavců**

Text může být zobrazován odstavec po odstavci. Tento příklad vytvoří tři odstavce se sekvenčními efekty postupného objevení, každý zpožděný o jednu sekundu po předchozím efektu. Použijte uložený soubor `paragraphs.pptx` jako vstup do příkladu pro převod videa.

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

## **Třídy pro převod videa**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationanimationsgenerator/) generuje animační události pro snímky. Při vytvoření z prezentace používá velikost snímku prezentace pro snímky. Použijte [setDefaultDelay](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) k nastavení výchozího zpoždění v milisekundách.

[PresentationPlayer](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationplayer/) vzorkuje vygenerované animace při snímkové rychlosti zadané v konstruktoru. Zaregistrujte Python callback pomocí JPype pomocí [setFrameTick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationplayer/#setFrameTick) a poté zavolejte [run](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationanimationsgenerator/#run) k vygenerování snímků. První příklad používá vlastní čítač od nuly, aby názvy souborů odpovídaly vstupní sekvenci FFmpeg.

Pro jednotlivé stavy animace zaregistrujte callback pomocí [setNewAnimation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). Callback obdrží animační přehrávač, který lze umístit na vybraný okamžik. Následující příklad ukládá první a poslední snímek každé vygenerované animace s jedinečnými názvy souborů:

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

## **Podporované animace a efekty**

Následující tabulky shrnují podporu vykreslování popsanou v článku o převodu v Javě. Náhled vygenerovaných snímků, pokud prezentace používá efekty, které nejsou podporovány.

**Vstup**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Zdůraznění**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Výstup**:

| Typ animace | Aspose.Slides | PowerPoint |
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

**Cesty pohybu**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **Často kladené otázky**

**Vytváří Aspose.Slides přímo soubor MP4?**

Ne. Aspose.Slides generuje snímky prezentace. Použijte video enkodér, například FFmpeg, k jejich sloučení do souboru MP4.

**Proč se video přehrává rychleji nebo pomaleji, než jsem očekával?**

Použijte stejný FPS pro generování snímků i pro vstupní snímkovou rychlost enkodéru. Nesoulad mění dobu přehrávání sekvence obrázků.

**Mohu převést prezentaci chráněnou heslem?**

Ano. Při [načítání chráněné prezentace](/slides/cs/python-java/password-protected-presentation/) zadejte správné heslo a následně generujte snímky z načteného obsahu.

**Zachovává tento postup zvuk prezentace?**

Příklady exportují pouze obrázkové snímky, takže výsledné video je tiché. Pro zahrnutí zvuku přidejte zvukovou stopu samostatně během enkódování videa.

**Jak mohu snížit dočasné využití disku?**

Použijte menší rozměry snímků nebo nižší FPS a po úspěšném zakódování odstraňte dočasné PNG soubory. Zkontrolujte kvalitu výsledného videa při snižování kterékoliv z těchto hodnot.