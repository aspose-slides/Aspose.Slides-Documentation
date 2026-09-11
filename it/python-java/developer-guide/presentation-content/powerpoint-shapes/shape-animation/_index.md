---
title: Applica animazioni di forma nelle presentazioni usando Python via Java
linktitle: Animazione di forma
type: docs
weight: 60
url: /it/python-java/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungere animazione
- ottenere animazione
- estrarre animazione
- aggiungere effetto
- ottenere effetto
- estrarre effetto
- suono effetto
- applicare animazione
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come aggiungere, ispezionare e personalizzare le animazioni di forme, la temporizzazione, i suoni, il comportamento post-animazione e il testo animato con Aspose.Slides per Python via Java."
---
## **Panoramica**

Aspose.Slides per Python via Java rappresenta le animazioni delle diapositive come effetti in una timeline della diapositiva. Un effetto ha una forma di destinazione, un tipo e sottotipo di animazione, un trigger, impostazioni di temporizzazione e proprietà opzionali come suono o comportamento post‑animazione.

La timeline contiene due tipi di sequenze:

- La **sequenza principale** viene riprodotta man mano che la diapositiva avanza.
- Una **sequenza interattiva** inizia quando la sua forma trigger viene cliccata.

Poiché caselle di testo, immagini, grafici, tabelle e altri oggetti della diapositiva derivano da [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/), si utilizza lo stesso metodo [Sequence.addEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#addEffect) per la maggior parte del contenuto della diapositiva. Gli effetti disponibili sono elencati nella classe [EffectType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttype/).

## **Aggiungere animazioni a forme**

Per aggiungere un'animazione, ottieni la sequenza principale della diapositiva e chiama [Sequence.addEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#addEffect) con la forma di destinazione, il tipo di effetto, il sottotipo e il trigger. Per un effetto che inizia quando un'altra forma viene cliccata, crea una sequenza interattiva il cui trigger è quell'altra forma.

L'esempio seguente crea entrambi i tipi di animazione e salva il risultato in `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il trigger controlla quando un effetto inizia:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttriggertype/#OnClick) attende un clic nella sequenza principale, o un clic sulla forma trigger in una sequenza interattiva.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttriggertype/#WithPrevious) inizia con l'effetto precedente.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/it/python-java/aspose.slides/effecttriggertype/#AfterPrevious) inizia quando l'effetto precedente termina.

Per animare un'immagine, un grafico o un altro tipo di forma, passa quell'oggetto a [Sequence.addEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#addEffect) invece di `target_shape`. Per le opzioni di raggruppamento specifiche dei grafici, vedi [Animated Charts](/slides/it/python-java/animated-charts/).

## **Leggere le animazioni di forma**

Usa [Sequence.getEffectsByShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#getEffectsByShape) quando conosci la forma di destinazione. Per ispezionare ogni effetto, enumera la sequenza principale e ogni sequenza interattiva. L'enumerazione evita di presumere che una sequenza contenga un effetto all'indice `0`.

L'esempio seguente crea una forma con effetti nella sequenza principale e in quella interattiva, ottiene gli effetti che hanno come target la forma, e poi enumera ogni sequenza sulla diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Se hai bisogno solo degli effetti per una forma, identifica prima la forma per nome, tipo di segnaposto o un'altra proprietà stabile; poi chiama [Sequence.getEffectsByShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#getEffectsByShape). Non presumere che [ShapeCollection.get_Item](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#get_Item) all'indice `0` sia sempre l'oggetto desiderato.

## **Lavorare con gli effetti dei segnaposto ereditati**

Un segnaposto su una diapositiva normale può ereditare il comportamento di animazione dal corrispondente segnaposto sulla diapositiva layout e sul master. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getBasePlaceholder) restituisce quel segnaposto genitore, o `None` quando non esiste un genitore.

Nella presentazione d'esempio seguente, il piè di pagina ha **Random Bars** sulla diapositiva normale, **Split** sulla diapositiva layout e **Fly In** sulla diapositiva master.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

L'esempio successivo utilizza una gerarchia di segnaposto da una nuova presentazione. Aggiunge effetti a un segnaposto master, a un segnaposto layout e al corrispondente segnaposto su una diapositiva normale. Ogni chiamata a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getBasePlaceholder) viene verificata prima di utilizzare la forma restituita.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modificare la temporizzazione dell'animazione**

La finestra di dialogo **Timing** di PowerPoint corrisponde alle proprietà di [Timing](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** corrisponde a [Timing.getTriggerType](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** corrisponde a [Timing.getDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getDuration), in secondi.
- **Delay** corrisponde a [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getTriggerDelayTime), in secondi.
- **Repeat** corrisponde a [Timing.getRepeatCount](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getRepeatUntilNextClick) o [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** corrisponde a [Timing.getRewind](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#getRewind).

Questo esempio indipendente aggiunge un effetto, ne modifica la temporizzazione tramite l'oggetto restituito da [Sequence.addEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#addEffect), e salva il risultato. Mantenere il riferimento all'[Effect](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/) restituito evita un indice di raccolta non necessario.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Usa un unico modo di ripetizione intenzionalmente. Combinare un conteggio di ripetizioni con un flag "until" può produrre risultati confusi in diversi visualizzatori. Quando si cambiano le modalità di ripetizione, imposta [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#setRepeatUntilNextClick) e [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) prima di [Timing.setRepeatCount](https://reference.aspose.com/slides/it/python-java/aspose.slides/timing/#setRepeatCount), perché impostare uno dei due flag cambia anche la modalità di ripetizione attiva.

## **Aggiungere ed estrarre suoni di animazione**

Un effetto di animazione può fare riferimento a audio incorporato tramite [Effect.getSound](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#setStopPreviousSound) indica a un effetto di fermare l'audio avviato da un effetto precedente.

### **Aggiungere un suono a un effetto**

L'esempio seguente richiede un file audio locale chiamato `animation-sound.wav`. Crea due effetti, incorpora quel file come suono per il primo effetto, e configura il secondo effetto per fermare il suono. Usa gli oggetti restituiti da [Sequence.addEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#addEffect), quindi non è necessario l'indice della sequenza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Estrarre i suoni di effetto incorporati**

L'esempio seguente richiede una presentazione locale chiamata `presentation-with-animation-sounds.pptx`. Scansiona sia le sequenze principali che quelle interattive e scrive ogni suono di effetto incorporato nella cartella `extracted-animation-sounds`. L'estensione è selezionata dal tipo MIME audio esposto da [Audio.getContentType](https://reference.aspose.com/slides/it/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

Per oggetti audio di grandi dimensioni, usa [Audio.getStream](https://reference.aspose.com/slides/it/python-java/aspose.slides/audio/#getStream) e copia lo stream su un file invece di caricare l'intero oggetto in un array di byte.

## **Impostare il comportamento post‑animazione**

L'opzione **After animation** controlla cosa succede a una forma dopo che il suo effetto termina.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

La classe [AfterAnimationType](https://reference.aspose.com/slides/it/python-java/aspose.slides/afteranimationtype/) supporta lasciare la forma invariata, cambiarne il colore, nasconderla dopo l'animazione, o nasconderla al prossimo clic. Quando il tipo è [AfterAnimationType.Color](https://reference.aspose.com/slides/it/python-java/aspose.slides/afteranimationtype/#Color), imposta anche [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#getAfterAnimationColor).

Questo esempio indipendente crea un effetto, imposta il suo comportamento post‑animazione tramite l'oggetto effetto restituito, e salva il risultato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cambiare il tipo da [AfterAnimationType.Color](https://reference.aspose.com/slides/it/python-java/aspose.slides/afteranimationtype/#Color) cancella l'impostazione del colore post‑animazione.

## **Animare il testo**

L'animazione del testo ha due controlli correlati:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textanimation/#getBuildType) controlla se i paragrafi appaiono tutti insieme o a livello di paragrafo.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#getAnimateTextType) controlla se il testo appare tutto in una volta, parola per parola o lettera per lettera. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/effect/#getDelayBetweenTextParts) imposta il ritardo tra parole o lettere. Un valore positivo è una percentuale della durata dell'effetto; un valore negativo è un ritardo in secondi.

L'esempio indipendente seguente anima le parole in una casella di testo. [BuildType.AsOneObject](https://reference.aspose.com/slides/it/python-java/aspose.slides/buildtype/#AsOneObject) disabilita la costruzione paragrafo per paragrafo in modo che l'impostazione per parola si applichi all'intero riquadro di testo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per costruire una casella di testo per paragrafo, imposta [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/it/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (o un altro livello di paragrafo). Per targettare un singolo paragrafo con il proprio effetto, usa la sovraccarico di [Sequence.addEffect](https://reference.aspose.com/slides/it/python-java/aspose.slides/sequence/#addEffect) che accetta un [Paragraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/). Vedi [Animated Text](/slides/it/python-java/animated-text/) per esempi a livello di paragrafo.

## **Esportazione e note di compatibilità**

- Salvare in PPT o PPTX conserva il modello di animazione, ma la riproduzione finale è controllata dal visualizzatore della presentazione.
- PDF e immagini statiche non riproducono animazioni. Usa [HTML5 export](/slides/it/python-java/export-to-html5/), GIF animato o [video conversion](/slides/it/python-java/convert-powerpoint-to-video/) quando l'output deve mostrare movimento.
- Per HTML5, abilita [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/#setAnimateShapes) e, se necessario, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Il rendering video supporta molti effetti di ingresso, enfasi, uscita e percorsi di movimento comuni, ma non tutti gli effetti di PowerPoint sono supportati. Controlla le [supported animations and effects](/slides/it/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) attuali e testa le presentazioni critiche con la versione di Aspose.Slides in uso.
- Effetti personalizzati avanzati e effetti importati da altri formati di presentazione possono essere conservati nel file ma renderizzati diversamente in PowerPoint, HTML5 o video. Convalida il risultato esportato invece di fare affidamento solo sul nome dell'effetto.

## **FAQ**

**Perché un'animazione appare in PowerPoint ma non in un PDF?**

Il PDF è un formato statico, quindi le animazioni e le transizioni delle diapositive non vengono riprodotte. Esporta in HTML5, GIF animato o video quando è necessario preservare il movimento.

**Perché un effetto viene riprodotto diversamente in un video?**

L'esportazione video rende le animazioni anziché memorizzare il comportamento originale di PowerPoint. Alcuni effetti avanzati non sono supportati o vengono approssimati. Consulta la tabella degli effetti supportati e testa la presentazione reale prima dell'uso in produzione.

**Spostare una forma avanti o indietro cambia l'ordine della sua animazione?**

No. L'ordine Z della forma controlla la sovrapposizione, mentre l'ordine della sequenza e i trigger controllano la riproduzione dell'animazione. Modifica la timeline se hai bisogno di un ordine di riproduzione diverso.