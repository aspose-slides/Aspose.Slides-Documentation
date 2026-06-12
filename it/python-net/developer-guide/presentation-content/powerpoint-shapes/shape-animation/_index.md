---
title: Applicare animazioni di forme nelle presentazioni con Python
linktitle: Animazione di forma
type: docs
weight: 60
url: /it/python-net/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungi animazione
- ottieni animazione
- estrai animazione
- aggiungi effetto
- ottieni effetto
- estrai effetto
- suono effetto
- applica animazione
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare e personalizzare le animazioni di forme in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET. Distinguersi!"
---
## **Introduzione**

Le animazioni sono effetti visivi che possono essere applicati a testi, immagini, forme o [grafici](/slides/it/python-net/animated-charts/). Danno vita alle presentazioni o ai loro componenti. 

## **Perché usare le animazioni nelle presentazioni?**

* controllare il flusso di informazioni
* sottolineare i punti importanti
* aumentare l'interesse o la partecipazione del pubblico
* rendere il contenuto più facile da leggere, assimilare o elaborare
* catturare l'attenzione dei lettori o spettatori verso le parti importanti di una presentazione

PowerPoint offre molte opzioni e strumenti per le animazioni e gli effetti di animazione nelle categorie **entrata**, **uscita**, **enfasi** e **percorsi di movimento**. 

## **Animazioni in Aspose.Slides**

* Aspose.Slides fornisce le classi e i tipi necessari per lavorare con le animazioni nel namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/), 
* Aspose.Slides fornisce più di **150 effetti di animazione** nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttype/). Questi effetti sono sostanzialmente gli stessi (o equivalenti) effetti usati in PowerPoint.

## **Applicare l'animazione a TextBox**

Aspose.Slides per Python tramite .NET consente di applicare animazioni al testo in una forma. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla slide tramite il suo indice.
3. Aggiungi un `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/iautoshape/). 
4. Aggiungi testo a `IAutoShape.TextFrame`.
5. Ottieni la sequenza principale di effetti.
6. Aggiungi un effetto di animazione a [IAutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/iautoshape/). 
7. Imposta la proprietà `TextAnimation.BuildType` al valore dell'enumerazione `BuildType`.
8. Scrivi la presentazione su disco come file PPTX.

Questo codice Python mostra come applicare l'effetto `Fade` a AutoShape e impostare l'animazione del testo sul valore *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Istanzia una classe di presentazione che rappresenta un file di presentazione.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Aggiunge una nuova AutoShape con testo
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Ottiene la sequenza principale della slide.
    sequence = sld.timeline.main_sequence

    # Aggiunge l'effetto di animazione Fade alla forma
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Anima il testo della forma per paragrafi di primo livello
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Salva il file PPTX su disco
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Oltre ad applicare animazioni al testo, è possibile applicare animazioni anche a un singolo [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/iparagraph/). Vedi [**Animated Text**](/slides/it/python-net/animated-text/).

{{% /alert %}} 

## **Applicare l'animazione a PictureFrame**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla slide tramite il suo indice.
3. Aggiungi o ottieni un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) sulla slide. 
4. Ottieni la sequenza principale di effetti.
5. Aggiungi un effetto di animazione a [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/).
6. Scrivi la presentazione su disco come file PPTX.

Questo codice Python mostra come applicare l'effetto `Fly` a un picture frame:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Istanzia una classe di presentazione che rappresenta un file di presentazione.
with slides.Presentation() as pres:
    # Carica l'immagine da aggiungere alla raccolta di immagini della presentazione
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Aggiunge un fotogramma immagine alla slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Ottiene la sequenza principale della slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Aggiunge l'effetto di animazione Fly da sinistra al fotogramma immagine
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Salva il file PPTX su disco
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Applicare l'animazione a Shape**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla slide tramite il suo indice.
3. Aggiungi un `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/iautoshape/). 
4. Aggiungi un `Bevel` [IAutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/iautoshape/) (quando questo oggetto viene cliccato, l'animazione viene riprodotta).
5. Crea una sequenza di effetti sulla forma Bevel.
6. Crea un `UserPath` personalizzato.
7. Aggiungi comandi per spostarsi al `UserPath`.
8. Scrivi la presentazione su disco come file PPTX.

Questo codice Python mostra come applicare l'effetto `PathFootball` (path football) a una forma:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanzia una classe Presentation che rappresenta un file PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Crea l'effetto PathFootball per la forma esistente da zero.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Aggiunge l'effetto di animazione PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Crea una sorta di "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Crea una sequenza di effetti per il pulsante.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Crea un percorso utente personalizzato. Il nostro oggetto verrà spostato solo dopo che il pulsante viene cliccato.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Aggiunge comandi per lo spostamento poiché il percorso creato è vuoto.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Scrive il file PPTX su disco
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottenere gli effetti di animazione applicati a Shape**

Gli esempi seguenti mostrano come utilizzare il metodo `get_effects_by_shape` della classe [Sequence](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/sequence/) per ottenere tutti gli effetti di animazione applicati a una forma.

**Esempio 1: Ottenere gli effetti di animazione applicati a una forma su una slide normale**

In precedenza hai imparato come aggiungere effetti di animazione alle forme nelle presentazioni PowerPoint. Il codice di esempio seguente mostra come ottenere gli effetti applicati alla prima forma della prima slide normale nella presentazione `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Ottiene la sequenza principale di animazione della slide.
    sequence = first_slide.timeline.main_sequence

    # Ottiene la prima forma sulla prima slide.
    shape = first_slide.shapes[0]

    # Ottiene gli effetti di animazione applicati alla forma.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Esempio 2: Ottenere tutti gli effetti di animazione, inclusi quelli ereditati dai segnaposti**

Se una forma su una slide normale ha segnaposti che si trovano sulla slide layout e/o master, e sono stati aggiunti effetti di animazione a questi segnaposti, allora tutti gli effetti della forma verranno riprodotti durante la presentazione, inclusi quelli ereditati dai segnaposti.

Supponiamo di avere un file di presentazione PowerPoint `sample.pptx` con una slide contenente solo una forma piè di pagina con il testo "Made with Aspose.Slides" e l'effetto **Random Bars** è applicato alla forma.

![Effetto di animazione della forma nella slide](slide-shape-animation.png)

Supponiamo inoltre che l'effetto **Split** sia applicato al segnaposto piè di pagina nella slide **layout**.

![Effetto di animazione della forma nella slide layout](layout-shape-animation.png)

Infine, l'effetto **Fly In** è applicato al segnaposto piè di pagina nella slide **master**.

![Effetto di animazione della forma nella slide master](master-shape-animation.png)

Il codice di esempio seguente mostra come utilizzare il metodo `get_base_placeholder` della classe [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) per accedere ai segnaposti delle forme e ottenere gli effetti di animazione applicati alla forma piè di pagina, inclusi quelli ereditati dai segnaposti situati sulle slide layout e master.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Ottieni gli effetti di animazione della forma sulla slide normale.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Ottieni gli effetti di animazione del segnaposto sulla slide di layout.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Ottieni gli effetti di animazione del segnaposto sulla slide master.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Modificare le proprietà di temporizzazione dell'effetto di animazione**

Aspose.Slides per Python tramite .NET consente di modificare le proprietà di temporizzazione di un effetto di animazione.

Questo è il pannello di temporizzazione dell'animazione in Microsoft PowerPoint:

![Pannello di temporizzazione dell'animazione](shape-animation.png)

Queste sono le corrispondenze tra la temporizzazione di PowerPoint e le proprietà `Effect.Timing`:

- L'elenco a discesa **Start** della temporizzazione di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerType](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/effecttriggertype/). 
- La **Duration** della temporizzazione di PowerPoint corrisponde alla proprietà `Effect.Timing.Duration`. La durata di un'animazione (in secondi) è il tempo totale necessario perché l'animazione completi un ciclo. 
- Il **Delay** della temporizzazione di PowerPoint corrisponde alla proprietà `Effect.Timing.TriggerDelayTime`. 

Ecco come modificare le proprietà di temporizzazione dell'effetto:

1. [Applica](#apply-animation-to-shape) o ottieni l'effetto di animazione.
2. Imposta nuovi valori per le proprietà `Effect.Timing` necessarie. 
3. Salva il file PPTX modificato.

Questo codice Python dimostra l'operazione:

```python
import aspose.slides as slides

# Istanzia una classe di presentazione che rappresenta un file di presentazione.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Ottiene la sequenza principale della slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Ottiene il primo effetto della sequenza principale.
    effect = sequence[0]

    # Modifica il TriggerType dell'effetto per avviare al clic
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Modifica la Durata dell'effetto
    effect.timing.duration = 3

    # Modifica il TriggerDelayTime dell'effetto
    effect.timing.trigger_delay_time = 0.5

    # Salva il file PPTX su disco
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Suono dell'effetto di animazione**

Aspose.Slides fornisce queste proprietà per consentire di lavorare con i suoni negli effetti di animazione: 

- `sound`
- `stop_previous_sound`

### **Aggiungere suono all'effetto di animazione**

Questo codice Python mostra come aggiungere un suono a un effetto di animazione e fermarlo quando inizia il prossimo effetto:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Aggiunge audio alla raccolta audio della presentazione
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Ottiene la sequenza principale della slide.
    sequence = first_slide.timeline.main_sequence

    # Ottiene il primo effetto della sequenza principale
    first_effect = sequence[0]

    # Verifica l'effetto per "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Aggiunge suono per il primo effetto
        first_effect.sound = effect_sound

    # Ottiene la prima sequenza interattiva della slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Imposta il flag "Stop previous sound" dell'effetto
    interactive_sequence[0].stop_previous_sound = True

    # Scrive il file PPTX su disco
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Estrarre suono dall'effetto di animazione**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento alla slide tramite il suo indice. 
3. Ottieni la sequenza principale di effetti. 
4. Estrai il `sound` incorporato in ciascun effetto di animazione. 

Questo codice Python mostra come estrarre il suono incorporato in un effetto di animazione:

```python
import aspose.slides as slides

# Istanzia una classe di presentazione che rappresenta un file di presentazione.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Ottiene la sequenza principale della slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Estrae il suono dell'effetto in un array di byte
        audio = effect.sound.binary_data
```

## **Dopo l'animazione**

Aspose.Slides per .NET consente di modificare la proprietà After animation di un effetto di animazione.

![Pannello dell'effetto di animazione dopo (After)](shape-after-animation.png)

L'elenco a discesa **After animation** dell'effetto PowerPoint corrisponde a queste proprietà: 

- la proprietà `after_animation_type` che descrive il tipo di After animation :
  * PowerPoint **More Colors** corrisponde al tipo [COLOR](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** corrisponde al tipo [DO_NOT_DIM](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/afteranimationtype/) (tipo di after animation predefinito);
  * PowerPoint **Hide After Animation** corrisponde al tipo [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** corrisponde al tipo [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/afteranimationtype/);
- la proprietà `after_animation_color` che definisce il formato del colore after animation. Questa proprietà funziona in combinazione con il tipo [COLOR](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/afteranimationtype/). Se cambi il tipo con un altro, il colore after animation verrà cancellato.

Questo codice Python mostra come modificare un effetto after animation:

```python
import aspose.slides as slides

# Istanzia una classe di presentazione che rappresenta un file di presentazione
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Ottiene il primo effetto della sequenza principale
    first_effect = first_slide.timeline.main_sequence[0]

    # Imposta il tipo di after animation su Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Imposta il colore di dim dell'after animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Scrive il file PPTX su disco
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animare il testo**

Aspose.Slides fornisce queste proprietà per consentire di lavorare con il blocco *Animate text* di un effetto di animazione:

- `animate_text_type` che descrive il tipo di animazione del testo dell'effetto. Il testo della forma può essere animato:
  - Tutto in una volta ([ALL_AT_ONCE](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/animatetexttype/) tipo)
  - Per parola ([BY_WORD](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/animatetexttype/) tipo)
  - Per lettera ([BY_LETTER](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/animatetexttype/) tipo)
- `delay_between_text_parts` imposta un ritardo tra le parti di testo animate (parole o lettere). Un valore positivo specifica la percentuale della durata dell'effetto. Un valore negativo specifica il ritardo in secondi.

Ecco come è possibile modificare le proprietà Animate text dell'effetto:

1. [Applica](#apply-animation-to-shape) o ottieni l'effetto di animazione.
2. Imposta la proprietà `build_type` al valore [AS_ONE_OBJECT](https://reference.aspose.com/slides/it/python-net/aspose.slides.animation/buildtype/) per disattivare la modalità di animazione *By Paragraphs*.
3. Imposta nuovi valori per le proprietà `animate_text_type` e `delay_between_text_parts`.
4. Salva il file PPTX modificato.

Questo codice Python dimostra l'operazione:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Ottiene il primo effetto della sequenza principale
    first_effect = first_slide.timeline.main_sequence[0]

    # Modifica il tipo di animazione del testo dell'effetto a "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Modifica il tipo di animazione del testo dell'effetto a "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Imposta il ritardo tra le parole al 20% della durata dell'effetto
    first_effect.delay_between_text_parts = 20

    # Scrive il file PPTX su disco
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Come posso assicurarmi che le animazioni siano preservate durante la pubblicazione della presentazione sul web?**

[Export to HTML5](/slides/it/python-net/export-to-html5/) e abilita le [opzioni](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/) responsabili delle animazioni di [shape](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/animate_shapes/) e di [transition](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/html5options/animate_transitions/). L'HTML semplice non riproduce le animazioni delle slide, mentre l'HTML5 lo fa.

**Come influisce la modifica dell'ordine Z (ordine dei livelli) delle forme sull'animazione?**

L'animazione e l'ordine di disegno sono indipendenti: un effetto controlla la temporizzazione e il tipo di apparizione/scomparsa, mentre [z-order](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/z_order_position/) determina cosa copre cosa. Il risultato visibile è definito dalla loro combinazione. (Questo è il comportamento generale di PowerPoint; il modello effetti‑e‑forme di Aspose.Slides segue la stessa logica.)

**Ci sono limitazioni nella conversione delle animazioni in video per alcuni effetti?**

In generale, [le animazioni sono supportate](/slides/it/python-net/convert-powerpoint-to-video/), ma in alcuni casi rari o per effetti specifici potrebbero essere renderizzate diversamente. Si consiglia di testare con gli effetti utilizzati e con la versione della libreria.