---
title: Použití animací tvarů v prezentacích s Pythonem
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/python-net/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat animace tvarů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím .NET. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](/slides/cs/python-net/animated-charts/). Dodávají život prezentacím nebo jejich částem. 

## **Proč používat animace v prezentacích?**

Použitím animací můžete 

* řídit tok informací
* zdůraznit důležité body
* zvýšit zájem nebo zapojení publika
* usnadnit čtení, vstřebání nebo zpracování obsahu
* upoutat pozornost čtenářů nebo diváků na důležité části v prezentaci

PowerPoint nabízí mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **odchod**, **zdůraznění** a **cesty pohybu**. 

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy, které potřebujete pro práci s animacemi v rámci jmenného prostoru [Aspose.Slides.Animation](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/),
* Aspose.Slides poskytuje více než **150 animačních efektů** v rámci výčtu [EffectType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effecttype/). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) jako efekty používané v PowerPointu.

## **Použití animace na TextBox**

Aspose.Slides pro Python prostřednictvím .NET vám umožňuje aplikovat animaci na text ve tvaru. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iautoshape/). 
4. Přidejte text do `IAutoShape.TextFrame`.
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt k [IAutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iautoshape/). 
7. Nastavte vlastnost `TextAnimation.BuildType` na hodnotu z výčtu `BuildType`.
8. Uložte prezentaci na disk jako soubor PPTX.

Tento Python kód vám ukazuje, jak aplikovat efekt `Fade` na AutoShape a nastavit animaci textu na hodnotu *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Přidá nový AutoShape s textem
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Získá hlavní sekvenci snímku.
    sequence = sld.timeline.main_sequence

    # Přidá efekt rozplynutí (Fade) k tvaru
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animuje text tvaru po odstavcích prvního úrovně
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Uloží soubor PPTX na disk
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Kromě aplikace animací na text můžete také použít animace na jediný [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iparagraph/). Viz [**Animated Text**](/slides/cs/python-net/animated-text/).

{{% /alert %}} 

## **Použití animace na PictureFrame**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) na snímku. 
4. Získejte hlavní sekvenci efektů.
5. Přidejte animační efekt k [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/).
6. Uložte prezentaci na disk jako soubor PPTX.

Tento Python kód vám ukazuje, jak aplikovat efekt `Fly` na rámeček obrázku:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
with slides.Presentation() as pres:
    # Načte obrázek, který bude přidán do kolekce obrázků prezentace
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Přidá rámeček obrázku na snímek
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Získá hlavní sekvenci snímku.
    sequence = pres.slides[0].timeline.main_sequence

    # Přidá efekt animace Let zleva k rámečku obrázku
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Uloží soubor PPTX na disk
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Použití animace na tvar**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iautoshape/). 
4. Přidejte `Bevel` [IAutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iautoshape/) (když je tento objekt kliknut, animace se spustí).
5. Vytvořte sekvenci efektů na tvaru bevel.
6. Vytvořte vlastní `UserPath`.
7. Přidejte příkazy pro přesun na `UserPath`.
8. Uložte prezentaci na disk jako soubor PPTX.

Tento Python kód vám ukazuje, jak aplikovat efekt `PathFootball` (cesta football) na tvar:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvoří instanci třídy Presentation, která představuje soubor PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Vytvoří efekt PathFootball pro existující tvar od nuly.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Přidá animační efekt PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Vytvoří nějaký typ „tlačítka“.
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Vytvoří sekvenci efektů pro tlačítko.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Vytvoří vlastní uživatelskou cestu. Náš objekt bude přesunut až po kliknutí na tlačítko.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Přidá příkazy pro pohyb, protože vytvořená cesta je prázdná.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Zapíše soubor PPTX na disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Získání animačních efektů aplikovaných na tvar**

Následující příklady ukazují, jak použít metodu `get_effects_by_shape` ze třídy [Sequence](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/) k získání všech animačních efektů aplikovaných na tvar.

**Příklad 1: Získání animačních efektů aplikovaných na tvar na normálním snímku**

Dříve jste se naučili, jak přidávat animační efekty do tvarů v PowerPoint prezentacích. Následující ukázkový kód ukazuje, jak získat efekty aplikované na první tvar na prvním normálním snímku v prezentaci `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Získá hlavní sekvenci animací snímku.
    sequence = first_slide.timeline.main_sequence

    # Získá první tvar na prvním snímku.
    shape = first_slide.shapes[0]

    # Získá animační efekty aplikované na tvar.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Příklad 2: Získání všech animačních efektů, včetně těch zděděných z placeholderů**

Pokud má tvar na normálním snímku placeholdery, které jsou na rozvržení snímku a/nebo hlavním snímku, a k těmto placeholderům byly přidány animační efekty, pak budou během prezentace přehrány všechny efekty tvaru, včetně těch zděděných z placeholderů.

Předpokládejme, že máme soubor PowerPoint prezentace `sample.pptx` s jedním snímkem obsahujícím pouze tvar zápatí s textem „Made with Aspose.Slides“ a na tvar byl aplikován efekt **Random Bars**.

![Efekt animace tvaru snímku](slide-shape-animation.png)

Předpokládejme také, že na placeholder zápatí na **layout** snímku je aplikován efekt **Split**.

![Efekt animace tvaru rozvržení](layout-shape-animation.png)

A nakonec je na placeholder zápatí na **master** snímku aplikován efekt **Fly In**.

![Efekt animace tvaru hlavního snímku](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `get_base_placeholder` ze [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) třídy k přístupu k placeholderům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch zděděných z placeholderů umístěných na rozvržení a hlavním snímku.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Získá animační efekty tvaru na normálním snímku.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Získá animační efekty placeholderu na snímku rozvržení.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Získá animační efekty placeholderu na hlavním snímku.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

**Výstup:**
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Změna časových vlastností animačního efektu**

Aspose.Slides pro Python prostřednictvím .NET vám umožňuje změnit časové vlastnosti animačního efektu.

Toto je panel časování animace v Microsoft PowerPoint:

![example1_image](shape-animation.png)

Tyto jsou odpovídající vztahy mezi PowerPoint Timing a `Effect.Timing` vlastnostmi:

- Rozbalovací seznam **Start** v PowerPoint Timing odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effecttriggertype/). 
- **Duration** v PowerPoint Timing odpovídá vlastnosti `Effect.Timing.Duration`. Délka animace (v sekundách) je celkový čas, který trvá, než animace dokončí jeden cyklus. 
- **Delay** v PowerPoint Timing odpovídá vlastnosti `Effect.Timing.TriggerDelayTime`. 

Takto změníte vlastnosti časování efektu:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte nové hodnoty pro vlastnosti `Effect.Timing`, které potřebujete. 
3. Uložte upravený soubor PPTX.

```python
import aspose.slides as slides

# Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Získá hlavní sekvenci snímku.
    sequence = pres.slides[0].timeline.main_sequence

    # Získá první efekt hlavní sekvence.
    effect = sequence[0]

    # Změní TriggerType efektu na spuštění po kliknutí
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Změní Duration efektu
    effect.timing.duration = 3

    # Změní TriggerDelayTime efektu
    effect.timing.trigger_delay_time = 0.5

    # Uloží soubor PPTX na disk
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Zvuk animačního efektu**

Aspose.Slides poskytuje následující vlastnosti, které vám umožňují pracovat se zvuky v animačních efektech: 

- `sound`
- `stop_previous_sound`

### **Přidání zvuku animačního efektu**

Tento Python kód vám ukazuje, jak přidat zvuk animačního efektu a zastavit jej, když začne další efekt:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Přidá zvuk do audio kolekce prezentace
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Získá hlavní sekvenci snímku.
    sequence = first_slide.timeline.main_sequence

    # Získá první efekt hlavní sekvence
    first_effect = sequence[0]

    # Zkontroluje, zda efekt nemá zvuk ("No Sound")
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Přidá zvuk k prvnímu efektu
        first_effect.sound = effect_sound

    # Získá první interaktivní sekvenci snímku.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Nastaví příznak „Stop previous sound“ pro efekt
    interactive_sequence[0].stop_previous_sound = True

    # Zapíše soubor PPTX na disk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Extrahování zvuku animačního efektu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Získejte hlavní sekvenci efektů. 
4. Extrahujte `sound` vložený do každého animačního efektu. 

Tento Python kód vám ukazuje, jak extrahovat zvuk vložený do animačního efektu:

```python
import aspose.slides as slides

# Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Získá hlavní sekvenci snímku.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extrahuje zvuk efektu do pole bajtů
        audio = effect.sound.binary_data
```

## **Po animaci**

Aspose.Slides pro .NET vám umožňuje změnit vlastnost After animation animačního efektu.

Toto je panel animačního efektu a rozšířené menu v Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Rozbalovací seznam PowerPoint Effect **After animation** odpovídá těmto vlastnostem: 

- Vlastnost `after_animation_type`, která popisuje typ After animation:
  * **More Colors** v PowerPoint odpovídá typu [COLOR](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/afteranimationtype/);
  * **Don't Dim** v PowerPoint odpovídá typu [DO_NOT_DIM](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/afteranimationtype/) (výchozí typ po animaci);
  * **Hide After Animation** v PowerPoint odpovídá typu [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/afteranimationtype/);
  * **Hide on Next Mouse Click** v PowerPoint odpovídá typu [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/afteranimationtype/);
- Vlastnost `after_animation_color`, která definuje formát barvy po animaci. Tato vlastnost funguje ve spojení s typem [COLOR](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/afteranimationtype/). Pokud typ změníte na jiný, barva po animaci bude vymazána.

Tento Python kód vám ukazuje, jak změnit efekt po animaci:

```python
import aspose.slides as slides

# Vytvoří instanci třídy prezentace, která představuje soubor prezentace
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Získá první efekt hlavní sekvence
    first_effect = first_slide.timeline.main_sequence[0]

    # Změní typ po animaci na Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Nastaví barvu po animaci
    first_effect.after_animation_color.color = Color.alice_blue

    # Zapíše soubor PPTX na disk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animovat text**

Aspose.Slides poskytuje následující vlastnosti, které vám umožňují pracovat s blokem *Animate text* animačního efektu:

- `animate_text_type`, která popisuje typ animace textu efektu. Text ve tvaru může být animován:
  * Vše najednou ([ALL_AT_ONCE](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/animatetexttype/) typ)
  * Po slovech ([BY_WORD](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/animatetexttype/) typ)
  * Po jednotlivých písmencích ([BY_LETTER](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/animatetexttype/) typ)
- `delay_between_text_parts` nastavuje prodlevu mezi animovanými částmi textu (slovy nebo písmeny). Kladná hodnota určuje procento trvání efektu. Záporná hodnota určuje prodlevu v sekundách.

Takto můžete změnit vlastnosti Effect Animate text:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte vlastnost `build_type` na hodnotu [AS_ONE_OBJECT](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/buildtype/), abyste vypnuli režim animace *By Paragraphs*.
3. Nastavte nové hodnoty pro vlastnosti `animate_text_type` a `delay_between_text_parts`.
4. Uložte upravený soubor PPTX.

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Získá první efekt hlavní sekvence
    first_effect = first_slide.timeline.main_sequence[0]

    # Změní typ textové animace efektu na "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Změní typ animace textu efektu na "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Nastaví prodlevu mezi slovy na 20% trvání efektu
    first_effect.delay_between_text_parts = 20

    # Zapíše soubor PPTX na disk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **Často kladené otázky**

**Jak mohu zajistit, že animace budou zachovány při publikování prezentace na web?**

[Export to HTML5](/slides/cs/python-net/export-to-html5/) a povolte [options](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/) zodpovědné za animace [shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/animate_shapes/) a [transition](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/html5options/animate_transitions/). Čisté HTML nepřehrává animace snímků, zatímco HTML5 ano.

**Jak ovlivní změna z‑orderu (pořadí vrstev) tvarů animaci?**

Animace a pořadí kreslení jsou nezávislé: efekt řídí časování a typ zobrazování/skrývání, zatímco [z-order](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/z_order_position/) určuje, co co překrývá. Viditelný výsledek je definován jejich kombinací. (Jedná se o obecné chování PowerPointu; model effect‑and‑shapes v Aspose.Slides následuje stejnou logiku.)

**Existují omezení při konverzi animací do videa pro určité efekty?**

Obecně jsou [animace podporovány](/slides/cs/python-net/convert-powerpoint-to-video/), ale v rarých případech nebo u specifických efektů může dojít k odlišnému vykreslení. Doporučuje se testovat s efekty, které používáte, a s verzí knihovny.