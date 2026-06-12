---
title: Převod prezentací PowerPoint na video v Pythonu
linktitle: PowerPoint na video
type: docs
weight: 130
url: /cs/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint na video
- převést PowerPoint na video
- prezentace na video
- převést prezentaci na video
- PPT na video
- převést PPT na video
- PPTX na video
- převést PPTX na video
- ODP na video
- převést ODP na video
- PowerPoint na MP4
- převést PowerPoint na MP4
- prezentace na MP4
- převést prezentaci na MP4
- PPT na MP4
- převést PPT na MP4
- PPTX na MP4
- převést PPTX na MP4
- Převod PowerPoint na video
- Převod prezentace na video
- Převod PPT na video
- Převod PPTX na video
- Převod ODP na video
- Převod videa v Pythonu
- PowerPoint
- Python
- Aspose.Slides
description: "Zjistěte, jak pomocí Pythonu převést prezentace PowerPoint a OpenDocument na video. Objevte ukázkový kód a automatizační techniky, které zjednoduší váš pracovní tok."
---
## **Úvod**

**Zvýšená přístupnost:** Všechny zařízení, bez ohledu na platformu, mají ve výchozím nastavení video přehrávač, což usnadňuje uživatelům otevírání nebo přehrávání videí ve srovnání s tradičními prezentačními aplikacemi.

**Širší dosah:** Videa vám umožní oslovit širší publikum a představit informace poutavějším formátem. Průzkumy a statistiky ukazují, že lidé dávají přednost sledování a konzumaci video obsahu před jinými formami, což činí vaši zprávu účinnější.

{{% alert color="primary" %}} 
Vyzkoušejte náš [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/cs/video), protože nabízí živou a efektivní implementaci procesu popsaného zde.
{{% /alert %}} 

V [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/cs/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) jsme implementovali podporu převodu prezentací do videa.

* Použijte Aspose.Slides for Python k vytvoření snímků z prezentace se zadanou snímkovací frekvencí (FPS).
* Poté použijte nástroj třetí strany, například ffmpeg, k sestavení těchto snímků do videa.

## **Převést prezentaci PowerPoint na video**

1. Použijte příkaz pip install k přidání Aspose.Slides for Python do svého projektu: `pip install aspose-slides==24.4.0`
2. Stáhněte ffmpeg z [zde](https://ffmpeg.org/download.html) nebo jej nainstalujte pomocí správce balíčků.
3. Ujistěte se, že ffmpeg je v proměnné `PATH`. Jinak spusťte ffmpeg s úplnou cestou k binárnímu souboru (např. `C:\ffmpeg\ffmpeg.exe` na Windows nebo `/opt/ffmpeg/ffmpeg` na Linuxu).
4. Spusťte kód pro převod PowerPointu na video.

Tento Python kód ukazuje, jak převést prezentaci (obsahující tvar a dva animační efekty) na video:

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

## **Video efekty**

Při konverzi prezentace PowerPoint na video pomocí Aspose.Slides for Python můžete aplikovat různé video efekty, které zlepší vizuální kvalitu výstupu. Tyto efekty umožňují kontrolovat vzhled snímků ve finálním videu přidáním plynulých přechodů, animací a dalších vizuálních prvků. Tato sekce vysvětluje dostupné možnosti video efektů a ukazuje, jak je použít.

{{% alert color="primary" %}} 
Podívejte se na [PowerPoint Animation](https://docs.aspose.com/slides/cs/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cs/python-net/shape-animation/), a [Shape Effect](https://docs.aspose.com/slides/cs/python-net/shape-effect/).
{{% /alert %}} 

Animace a přechody dělají prezentace poutavější a zajímavější — a totéž platí pro videa. Přidejme další snímek a přechod do kódu předchozí prezentace:

```python
import aspose.pydrawing as drawing

# Přidejte tvar s úsměvem a animujte jej.
# ...

# Přidejte nový snímek a animovaný přechod.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python také podporuje animace textu. V tomto příkladu animujeme odstavce na objektech tak, aby se objevovaly jeden po druhém s jednosekundovým zpožděním mezi nimi:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte text a animace.
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

    # Převést snímky na video.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Třídy pro konverzi videa**

Aby bylo možné provádět úlohy převodu PowerPointu na video, Aspose.Slides for Python poskytuje [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` umožňuje nastavit velikost snímku pro video (které bude vytvořeno později) a hodnotu FPS (snímků za sekundu) prostřednictvím svého konstruktoru. Pokud předáte instanci prezentace, bude použita její `Presentation.SlideSize`.

Aby se všechny animace v prezentaci přehrály najednou, použijte metodu `PresentationEnumerableFramesGenerator.enumerate_frames`. Tato metoda přijímá kolekci snímků a postupně vrací [EnumerableFrameArgs](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/enumerableframeargs/). Poté použijte `EnumerableFrameArgs.get_frame()` k získání každého video snímku.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Poté lze vygenerované snímky sestavit do videa. Další podrobnosti naleznete v sekci [Convert PowerPoint to Video](https://docs.aspose.com/slides/cs/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Podporované animace a efekty**

Při konverzi prezentace PowerPoint na video pomocí Aspose.Slides for Python je důležité pochopit, které animace a efekty jsou ve výstupu podporovány. Aspose.Slides podporuje širokou škálu běžných vstupních, výstupních a zvýrazňovacích efektů, jako je ztlumení, let, přiblížení a otáčení. Některé pokročilé nebo vlastní animace však nemusí být plně zachovány nebo se mohou ve finálním videu objevit odlišně. Tato sekce uvádí podporované animace a efekty.

**Vstup**

| Typ animace | Aspose.Slides | PowerPoint |
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

**Zvýraznění**

| Typ animace | Aspose.Slides | PowerPoint |
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

**Odchod**

| Typ animace | Aspose.Slides | PowerPoint |
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

**Cesty pohybu**

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Podporované efekty přechodu snímků**

Efekty přechodu snímků hrají důležitou roli při vytváření plynulých a vizuálně atraktivních změn mezi snímky ve videu. Aspose.Slides for Python podporuje různé běžně používané efekty přechodu, aby pomohl zachovat tok a styl vaší původní prezentace. Tato sekce zdůrazňuje, které efekty přechodu jsou při konverzi podporovány.

**Jemné**

| Typ animace | Aspose.Slides | PowerPoint |
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

**Vzrušující**

| Typ animace | Aspose.Slides | PowerPoint |
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

**Dynamický obsah**

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Často kladené otázky**

**Je možné převést prezentace chráněné heslem?**

Ano, Aspose.Slides for Python umožňuje pracovat s prezentacemi chráněnými heslem. Při zpracování takových souborů musíte zadat správné heslo, aby knihovna mohla získat přístup k obsahu prezentace.

**Podporuje Aspose.Slides for Python použití v cloudových řešeních?**

Ano, Aspose.Slides for Python lze integrovat do cloudových aplikací a služeb. Knihovna je navržena pro provoz na serverových prostředích a zajišťuje vysoký výkon a škálovatelnost pro dávkové zpracování souborů.

**Existují nějaká omezení velikosti prezentací během konverze?**

Aspose.Slides for Python dokáže zpracovat prezentace téměř jakékoli velikosti. Při práci s velmi velkými soubory však může být potřeba více systémových prostředků a někdy se doporučuje prezentaci optimalizovat pro zlepšení výkonu.