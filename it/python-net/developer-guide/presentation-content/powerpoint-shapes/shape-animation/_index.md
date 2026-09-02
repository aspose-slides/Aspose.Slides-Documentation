---
title: "Applicare animazioni di forma nelle presentazioni con Python"
linktitle: "Animazione Forma"
type: docs
weight: 60
url: /it/python-net/shape-animation/
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
- Aspose.Slides
description: "Impara come aggiungere, ispezionare e personalizzare le animazioni di forma, la temporizzazione, i suoni, il comportamento post-animazione e il testo animato con Aspose.Slides per Python via .NET."
---
## **Panoramica**

Aspose.Slides for Python via .NET rappresenta le animazioni delle diapositive come effetti in una timeline della diapositiva. Un effetto ha una forma target, un tipo e sottotipo di animazione, un trigger, impostazioni di temporizzazione e proprietà opzionali come suono o comportamento post‑animazione.

La timeline contiene due tipi di sequenze:

- La **sequenza principale** viene riprodotta mentre la diapositiva avanza.
- Una **sequenza interattiva** inizia quando la sua forma di trigger viene cliccata.

Poiché caselle di testo, immagini, grafici, tabelle e altri oggetti della diapositiva implementano [IShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishape/), si utilizza lo stesso metodo [Sequence.add_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/add_effect/) per la maggior parte del contenuto della diapositiva. Gli effetti disponibili sono elencati nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttype/).

## **Aggiungi animazioni alle forme**

Per aggiungere un'animazione, ottieni la sequenza principale della diapositiva e chiama [Sequence.add_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/add_effect/) con la forma target, il tipo di effetto, il sottotipo e il trigger. Per un effetto che inizia quando un'altra forma viene cliccata, crea una sequenza interattiva il cui trigger è quell'altra forma.

Il seguente esempio crea entrambi i tipi di animazione e salva il risultato in `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

Il trigger controlla quando un effetto inizia:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttriggertype/) attende un clic nella sequenza principale, o un clic sulla forma di trigger in una sequenza interattiva.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttriggertype/) inizia con l'effetto precedente.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttriggertype/) inizia quando l'effetto precedente termina.

Per animare un'immagine, un grafico o un altro tipo di forma, passa quell'oggetto a [Sequence.add_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/add_effect/) invece di `target_shape`. Per opzioni di raggruppamento specifiche per i grafici, vedere [Animated Charts](/slides/it/python-net/animated-charts/).

## **Leggi animazioni delle forme**

Utilizza [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) quando conosci la forma target. Per esaminare ogni effetto, itera attraverso la sequenza principale e tutte le sequenze interattive. L'iterazione evita di presumere che una sequenza contenga un effetto all'indice `0`.

Il seguente esempio crea una forma con effetti nella sequenza principale e interattiva, ottiene gli effetti che hanno come target la forma, e poi itera attraverso tutte le sequenze sulla diapositiva.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Se hai bisogno solo degli effetti per una singola forma, identifica prima la forma per nome, tipo di segnaposto o altra proprietà stabile; quindi chiama [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Non presumere che la forma all'indice `0` sia sempre l'oggetto desiderato.

## **Lavorare con gli effetti dei segnaposti ereditati**

Un segnaposto su una diapositiva normale può ereditare il comportamento di animazione dal corrispondente segnaposto sulla diapositiva layout e sulla diapositiva master. [Shape.get_base_placeholder](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_base_placeholder/) restituisce quel segnaposto genitore, o `None` quando non esiste alcun genitore.

Nella presentazione di esempio seguente, il piè di pagina ha **Random Bars** sulla diapositiva normale, **Split** sulla diapositiva layout, e **Fly In** sulla diapositiva master.

![Animazione dell'effetto piè di pagina sulla diapositiva normale](slide-shape-animation.png)

![Animazione dell'effetto segnaposto piè di pagina sulla diapositiva layout](layout-shape-animation.png)

![Animazione dell'effetto segnaposto piè di pagina sulla diapositiva master](master-shape-animation.png)

Il prossimo esempio costruisce la gerarchia dei segnaposti. Aggiunge effetti a un segnaposto master, a un segnaposto layout e al corrispondente segnaposto su una diapositiva normale. Ogni chiamata a [Shape.get_base_placeholder](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_base_placeholder/) viene verificata prima di utilizzare la forma restituita.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifica la temporizzazione dell'animazione**

La finestra di dialogo **Timing** di PowerPoint corrisponde alle proprietà di [Timing](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/).

![Finestra di dialogo Timing di PowerPoint per un effetto di animazione](shape-animation.png)

- **Start** corrisponde a [Timing.trigger_type](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duration** corrisponde a [Timing.duration](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/duration/), in secondi.
- **Delay** corrisponde a [Timing.trigger_delay_time](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/trigger_delay_time/), in secondi.
- **Repeat** corrisponde a [Timing.repeat_count](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/repeat_until_next_click/), o [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Rewind when done playing** corrisponde a [Timing.rewind](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/rewind/).

Questo esempio indipendente aggiunge un effetto, modifica la sua temporizzazione tramite l'oggetto restituito da [Sequence.add_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/add_effect/), e salva il risultato. Conservare il riferimento all'[Effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effect/) restituito evita un indice di raccolta non necessario.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Usa intenzionalmente un solo modo di ripetizione. Combinare un conteggio di ripetizione con un flag "until" può produrre risultati confusi in diversi visualizzatori. Quando cambi i modi di ripetizione, imposta [Timing.repeat_until_next_click](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/repeat_until_next_click/) e [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) prima di [Timing.repeat_count](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/timing/repeat_count/), perché impostare uno dei due flag cambia anche il modo di ripetizione attivo.

## **Aggiungi ed estrai suoni di animazione**

Un effetto di animazione può fare riferimento a audio incorporato tramite [Effect.sound](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effect/stop_previous_sound/) indica a un effetto di fermare l'audio avviato da un effetto precedente.

### **Aggiungi un suono a un effetto**

Il seguente esempio richiede un file audio locale chiamato `animation-sound.wav`. Crea due effetti, incorpora quel file come suono per il primo effetto e configura il secondo effetto per fermare il suono. Utilizza gli oggetti restituiti da [Sequence.add_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/add_effect/), quindi non è necessario un indice di sequenza.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Estrai suoni incorporati negli effetti**

Il seguente esempio richiede una presentazione locale chiamata `presentation-with-animation-sounds.pptx`. Scansiona sia le sequenze principali che quelle interattive e scrive ogni suono incorporato dell'effetto nella directory `extracted-animation-sounds`. L'estensione è selezionata dal tipo MIME audio esposto da [Audio.content_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Per oggetti audio di grandi dimensioni, usa [Audio.get_stream](https://reference.aspose.com/slides/it/python-net/aspose.slides/audio/get_stream/) e copia lo stream in un file anziché caricare l'intero oggetto in un array di byte.

## **Imposta il comportamento post‑animazione**

L'opzione **After animation** controlla cosa accade a una forma dopo che il suo effetto è terminato.

![Finestra di dialogo PowerPoint Effect Options che mostra le impostazioni After animation](shape-after-animation.png)

L'enumerazione [AfterAnimationType](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/afteranimationtype/) supporta mantenere la forma invariata, cambiare il suo colore, nasconderla dopo l'animazione, o nasconderla al clic successivo. Quando il tipo è [AfterAnimationType.COLOR](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/afteranimationtype/), impostare anche [Effect.after_animation_color](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effect/after_animation_color/).

Questo esempio indipendente crea un effetto, imposta il suo comportamento post‑animazione tramite l'oggetto effetto restituito e salva il risultato.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

Cambiare il tipo da [AfterAnimationType.COLOR](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/afteranimationtype/) cancella l'impostazione del colore post‑animazione.

## **Animare il testo**

L'animazione del testo ha due controlli correlati:

- [TextAnimation.build_type](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/textanimation/build_type/) controlla se i paragrafi appaiono tutti insieme o per livello di paragrafo.
- [Effect.animate_text_type](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effect/animate_text_type/) controlla se il testo appare tutto in una volta, per parola o per lettera. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effect/delay_between_text_parts/) imposta il ritardo tra parole o lettere. Un valore positivo è una percentuale della durata dell'effetto; un valore negativo è un ritardo in secondi.

Il seguente esempio indipendente anima le parole in una casella di testo. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/buildtype/) disabilita la costruzione paragrafo per paragrafo così che l'impostazione per le parole si applichi all'intero riquadro di testo.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Per costruire una casella di testo per paragrafo, imposta [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/buildtype/) (o un altro livello di paragrafo). Per mirare a un singolo paragrafo con il proprio effetto, usa la sovraccarico di [Sequence.add_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/add_effect/) che accetta un [IParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/iparagraph/). Vedi [Animated Text](/slides/it/python-net/animated-text/) per esempi a livello di paragrafo.

## **Note su esportazione e compatibilità**

- Il salvataggio in PPT o PPTX preserva il modello di animazione, ma la riproduzione finale è controllata dal visualizzatore della presentazione.
- PDF e immagini statiche non riproducono animazioni. Usa [HTML5 export](/slides/it/python-net/export-to-html5/), GIF animate o [video conversion](/slides/it/python-net/convert-powerpoint-to-video/) quando l'output deve mostrare movimento.
- Per HTML5, abilita [Html5Options.animate_shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/animate_shapes/) e, se necessario, [Html5Options.animate_transitions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/animate_transitions/).
- Il rendering video supporta molti effetti comuni di ingresso, enfasi, uscita e percorso di movimento, ma non tutti gli effetti PowerPoint sono supportati. Verifica le attuali [supported animations and effects](/slides/it/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) e testa le presentazioni critiche con la versione di Aspose.Slides target.
- Gli effetti personalizzati avanzati e gli effetti importati da altri formati di presentazione possono essere preservati nel file ma renderizzati in modo diverso in PowerPoint, HTML5 o video. Convalida il risultato esportato invece di fare affidamento solo sul nome dell'effetto.

## **FAQ**

**Perché un'animazione appare in PowerPoint ma non in un PDF?**

Il PDF è un formato statico, quindi le animazioni e le transizioni delle diapositive non vengono riprodotte. Esporta in HTML5, GIF animata o video quando il movimento deve essere preservato.

**Perché un effetto viene riprodotto diversamente in un video?**

L'esportazione video rende le animazioni anziché memorizzare il comportamento originale di PowerPoint. Alcuni effetti avanzati non sono supportati o sono approssimati. Consulta la tabella degli effetti supportati e testa la presentazione effettiva prima dell'uso in produzione.

**Spostare una forma in avanti o indietro cambia il suo ordine di animazione?**

No. L'ordine Z della forma controlla la sovrapposizione, mentre l'ordine della sequenza e i trigger controllano la riproduzione dell'animazione. Modifica la timeline se necessiti di un ordine di riproduzione diverso.