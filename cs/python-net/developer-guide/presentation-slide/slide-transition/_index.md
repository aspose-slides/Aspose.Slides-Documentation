---
title: Správa přechodů snímků v prezentacích pomocí Pythonu
linktitle: Přechod snímku
type: docs
weight: 90
url: /cs/python-net/slide-transition/
keywords:
- přechod snímku
- přidání přechodu snímku
- použití přechodu snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Aplikujte přechody snímků, nakonfigurujte automatické posunování snímků a přizpůsobte Morph a jiné efekty přechodů pomocí Aspose.Slides pro Python prostřednictvím .NET."
---
## **Přehled**

Přechody snímků určují, jak se snímky zobrazují během prezentace. S Aspose.Slides pro Python pomocí .NET můžete pro každý snímek zvolit efekt přechodu, nakonfigurovat postupování kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v Pythonu k aplikaci přechodů, nastavení přesných délek trvání přechodu, správě načasování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Pro aplikaci přechodu načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a přistupte k vlastnosti snímku [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Nastavte její [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) na hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) a poté uložte prezentaci.

Následující příklad použije přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Kolečkový přechod**

Vlastnost [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) třídy [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) určuje počet radiálních sektorů, které odhalují cílový snímek. Nastavte [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) přechodu snímku na WHEEL z výčtu [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) před přístupem k [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) jako [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Tento příklad vytvoří dva identické páry snímků: černý snímek následovaný snímkem se zlatým obdélníkem. Cílové snímky používají počty paprsků 1 a 8, stejnou [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) a explicitní [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 8 000 milisekund, aby byl rozdíl snadno pozorovatelný.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Otevřete výstupní prezentaci v PowerPointu a spusťte prezentaci. Pokračujte ze snímku 1 na snímek 2 a pak ze snímku 3 na snímek 4. V přehrávání PowerPointu se ověřený počet paprsků 1 projeví jedním pootočením po směru hodinových ručiček; ověřený počet 8 odhalí snímek skrze osm radiálních sektorů najednou. Obsah cílových snímků a časování přechodu jsou identické, rozdíl je v počtu odhalovacích sektorů.

## **Postupné stmívání černou pomocí přechodu Reveal**

Nastavte [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) přechodu cílového snímku na Reveal a potom nastavte [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) na objektu [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/). Příklad vytvoří tyrkysový zdrojový snímek a korálový cílový snímek, poté oba páry zduplikuje. Oba páry používají stejný dvousekundový přechod Reveal. Pouze druhý pár přechází černou.

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Otevřete `reveal-transitions.pptx` v PowerPointu a spusťte prezentaci. Pokračujte ze snímku 1 na snímek 2 a uvidíte, jak tyrkys přechází přímo na korál. Pak pokračujte ze snímku 3 na snímek 4. Obrazovka se na okamžik ztlumená k téměř černé, než se objeví korálový snímek. Oba snímky si zachovají původní barvy pozadí.

Řádky níže zobrazují snímky z PowerPointu v půlsekundových intervalech. Porovnejte prostřední snímek v každém řádku, abyste viděli efekt nastavení.

![Přehrávání v PowerPointu s vypnutým (nahoře) a zapnutým (dole) režimem through_black. Pouze spodní řada prochází téměř černou.](reveal-through-black.png)

## **Přidání pokročilého přechodu snímku**

Můžete nakonfigurovat, jak dlouho snímek zůstane na obrazovce a zda kliknutí myší posune prezentaci dál. Následující vlastnosti řídí toto chování:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) umožňuje uživateli posunout prezentaci kliknutím.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) umožňuje automatické posunutí.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) určuje prodlevu před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak časované posunutí, aby uživatel mohl pokračovat buď kliknutím, nebo čekáním na časovač. Pro použití jen časovače nastavte [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) na `False`. Prodleva řídí, kdy se prezentace posune; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatické posunutí po 3, 5 a 7 sekundách. Kliknutí myší mohou také posunout tyto snímky. Použijte soubor `input.pptx` s alespoň třemi snímky.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Pro ověření, zda je časované posunutí povoleno, přečtěte [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Uložená prodleva sama o sobě neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatické posunutí pro snímky s prodlevou větší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Přesné řízení načasování přechodu**

Použijte [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) k určení přesné délky trvání efektu přechodu v milisekundách. Vlastnost [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) snímku poskytuje tato nastavení prostřednictvím [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Property | Účel |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Nastavuje délku trvání samotného efektu přechodu v milisekundách. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Určuje prodlevu před automatickým posunutím snímku v milisekundách. Pro aktivaci tohoto časovače povolte [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Výběr předdefinované rychlostní kategorie z [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM nebo FAST. Používá se, pokud není zadána přesná délka trvání. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) řídí pouze efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatickou prodlevu posunutí nastavte odděleně. Když není explicitně nastavená délka, Aspose.Slides určuje dobu trvání efektu z typu přechodu a hodnoty [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Samostatné pruhy identifikují 750 ms délku trvání přechodu a 5 000 ms nastavení automatického posunutí.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750‑ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Použít stejnou délku trvání na všechny snímky**

Pro konzistentní tempo použijte stejný efekt a přesnou délku trvání na každý snímek. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) a nastaví každému přechodu délku trvání 750 ms. Samostatně povolí automatické posunutí po 5 000 ms a zakáže posun kliknutím, poté výsledek uloží jako PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Nastavte automatické posunování nezávisle na délce trvání efektu.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Nastavit různé délky trvání pro jednotlivé snímky**

Různé snímky mohou mít různé délky trvání efektu. Například krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Koordinovat přechody s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/python-net/export-to-html5/) nebo [video](/slides/cs/python-net/convert-powerpoint-to-video/) nastavte přesné délky trvání přechodů před exportem, aby odpovídaly zamýšlenému tempu. Například použijte 600 ms fade mezi scénami a upravte prodlevu posunu každého snímku samostatně, aby byl dostatek času na hlasový doprovod nebo obsah.

Pro GIF a video koordinujte výstupní snímkovou frekvenci s délkou trvání efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte podporované efekty a možnosti načasování daného exportního formátu a náhledně ověřte synchronizaci.

### **Načíst existující délku trvání přechodu**

Před úpravou přechodu přečtěte [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že žádná explicitní délka není nastavena; ne­záporná hodnota udává uloženou délku v milisekundách. Nezadaná hodnota není vypočtená doba přehrávání: Aspose.Slides určuje délku na základě typu přechodu a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/). Nastavení typu přechodu může inicializovat délku, proto nejprve zkontrolujte původní nastavení.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph přechod**

Přechod Morph animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph zduplikujte snímek, upravte pozici nebo velikost objektu na duplikátu a použijte přechod Morph na druhý snímek. Tím získáte animaci odpovídajících objektů mezi jejich původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, zduplikuje jej a změní pozici a velikost obdélníku na duplikátu. Pak pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a podívejte se na efekt během prezentace.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Typy Morph přechodu**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) určuje, jak Morph mapuje a animuje obsah:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) zachází s každým tvarem jako s celým objektem.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animuje text porovnáním slov, kde je to možné.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animuje text porovnáním znaků, kde je to možné.

Nastavte [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) přechodu na Morph před přístupem k jeho [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Hodnota pak poskytne objekt [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), jehož vlastnost [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) vybírá režim mapování.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nastaví druhý snímek na animaci Morph založenou na slovech.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Nastavit efekty přechodu**

Některé přechody nabízejí další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na zvoleném [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Nejprve nastavte typ a poté použijte příslušný objekt přechodu získaný z jeho [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Následující příklad použije přechod Cut na první snímek `input.pptx`. Nastaví [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) prostřednictvím [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/), aby přechod začínal z černé obrazovky.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **Často kladené otázky**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), pokud potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/), pokud stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM nebo FAST, a není nastaven explicitní čas. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického posunu.

**Mohu k přechodu připojit zvuk a nechat jej opakovat?**

Ano. Přiřaďte vložený zvuk k [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), nastavte [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) na START_SOUND z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) a povolte [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Zvuk se bude opakovat až do další zvukové události v prezentaci.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Procházejte kolekci [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) prezentace a nastavte každému snímku přechod [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) na stejnou hodnotu. V tomtéž cyklu nastavte jakékoli časování a možnosti efektu, aby chování zůstalo konzistentní napříč snímky.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Přečtěte si vlastnost [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) z [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE znamená, že není aplikován žádný přechod.