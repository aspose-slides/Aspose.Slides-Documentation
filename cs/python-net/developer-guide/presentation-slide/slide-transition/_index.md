---
title: Spravujte přechody snímků v prezentacích pomocí Pythonu
linktitle: Přechod snímku
type: docs
weight: 90
url: /cs/python-net/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- aplikovat přechod snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Aplikujte přechody snímků, nastavte automatické postoupení snímků a přizpůsobte Morph a další efekty přechodů pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Posuvné přechody řídí, jak se snímky zobrazují během promítání. S Aspose.Slides pro Python přes .NET můžete pro každý snímek zvolit efekt přechodu, nastavit postupování kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v Pythonu k použití přechodů, nastavení přesných délek přechodů, správě časování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Chcete-li použít přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a přistupte k vlastnosti snímku [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Nastavte její [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) na hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/). Poté prezentaci uložte.

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

## **Přechod Wheel**

Vlastnost [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) třídy [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) určuje počet radiálních sektorů, které odhalují cílový snímek. Nastavte [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) přechodu snímku na WHEEL z [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) předtím, než přistoupíte k [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) jako [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Tento příklad vytvoří dva identické páry snímků: černý snímek následovaný snímkem se zlatým obdélníkem. Cílové snímky používají počty spoke 1 a 8, se stejnou [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) a explicitní [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 8 000 ms, aby byl rozdíl snadno pozorovatelný.

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

Otevřete výstupní prezentaci v PowerPointu a spusťte promítání. Přepněte ze snímku 1 na snímek 2 a poté ze snímku 3 na snímek 4. V přehrávání PowerPointu ověřený počet spoke 1 odhalí snímek jedním pootočením po směru hodinových ručiček; ověřený počet 8 odhalí snímek osmi radiálními sektory současně. Obsah cíle i načasování přechodu jsou stejné, rozdíl je tedy v počtu odhalovacích sektorů.

## **Přidání pokročilého přechodu snímku**

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) umožňuje divákovi postoupit kliknutím myši.  
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) umožňuje automatické postoupání.  
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) určuje prodlevu před automatickým postoupáním v milisekundách.

Povolte jak kliknutí, tak časované postoupání, aby divák mohl pokračovat kliknutím nebo čekat na časovač. Chcete‑li použít jen časovač, nastavte [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) na `False`. Prodleva řídí, kdy se promítání posune dál; nenastavuje dobu trvání vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatické postoupání po 3, 5 a 7 sekundách. Kliknutí myší mohou tyto snímky také posunout. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Chcete‑li zjistit, zda je časované postoupání povoleno, přečtěte [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Uložená prodleva sama o sobě neznamená, že je časovač aktivní.

Další příklad otevře soubor uložený výše, nahlásí každý povolený časovač a zakáže automatické postoupání pro snímky s prodlevou delší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

Použijte [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) k zadání přesné délky efektu přechodu v milisekundách. Vlastnost snímku [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) zpřístupňuje tato nastavení prostřednictvím [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Vlastnost | Účel |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Nastavuje dobu trvání samotného efektu přechodu v milisekundách. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Nastavuje prodlevu před tím, než se snímek automaticky posune dál, v milisekundách. Aktivujte [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) pro zapnutí tohoto časovače. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM nebo FAST. Používá se, pokud není zadána přesná doba trvání. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) řídí pouze efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Načasování automatického postupu nastavte samostatně. Když není zadána explicitní doba trvání, Aspose.Slides určí dobu trvání efektu podle typu přechodu a hodnoty [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Samostatné pruhy označují dobu trvání přechodu 750 ms a nastavení automatického postupu 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Sdílený příklad dává každému snímku 750 ms Fade přechod a samostatně povoluje automatický postup po 5 000 ms. Délka přechodu řídí efekt; postup určuje, kdy snímek opustit. Tyto pruhy jsou schematickými nastaveními, nikoli měřenou kombinovanou časovou osou.*
<!-- visual-explanation:slide-transition:end -->

### **Použít stejnou dobu trvání na každý snímek**

Pro konzistentní tempo použijte stejný efekt a přesnou dobu trvání na každý snímek. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) a nastaví každému přechodu dobu trvání 750 ms. Samostatně povolí automatické postoupání po 5 000 ms a zakáže postoupání kliknutím myši, poté výsledek uloží jako PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Nastavte automatické postoupení nezávisle na délce efektu.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Nastavit různé doby trvání pro jednotlivé snímky**

Různé snímky mohou používat různé doby trvání efektu. Například použijte krátký přechod pro titulek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

### **Koordinace přechodů s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/python-net/export-to-html5/) nebo [video](/slides/cs/python-net/convert-powerpoint-to-video/) nastavte přesné doby trvání přechodů před exportem, aby odpovídaly zamýšlenému tempu. Například použijte 600 ms fade mezi scénami a samostatně upravte prodlevu postupu každého snímku, aby byl dostatek času na jeho komentář nebo obsah.

Pro GIF a video koordinujte výstupní snímkovou frekvenci s délkou efektu: 600 ms odpovídá 18 rámcům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a možnosti časování podporuje zvolený exportní formát, a předem si výstup prohlédněte, abyste potvrdili synchronizaci.

### **Načíst existující dobu trvání přechodu**

Přečtěte [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) před úpravou přechodu, abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastavena žádná explicitní doba trvání; nezáporná hodnota určuje uloženou dobu v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) k určení této doby. Nastavení typu přechodu může dobu trvání inicializovat, proto nejprve zkontrolujte původní nastavení.

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

## **Přechod Morph**

Přechod Morph animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph zkopírujte snímek, posuňte nebo změňte velikost objektu v kopii a použijte přechod Morph na druhý snímek. To poskytne přechodu odpovídající objekty, které se animují mezi původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, zkopíruje snímek a změní pozici a velikost obdélníku v kopii. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a zobrazte efekt během promítání.

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

## **Typy přechodu Morph**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) určuje, jak Morph přiřazuje a animuje obsah:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) považuje každý tvar za celý objekt.  
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animuje text shodou slov, kde je to možné.  
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animuje text shodou znaků, kde je to možné.

Nastavte přechod [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) na Morph před přístupem k jeho [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Hodnota pak poskytne objekt [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), jehož vlastnost [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) vybírá režim přiřazení.

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

## **Nastavení efektů přechodu**

Některé přechody nabízejí další možnosti, například směr nebo zda efekt začíná na černé obrazovce. Dostupné možnosti závisí na vybraném přechodu [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Nejprve nastavte typ a poté použijte odpovídající objekt přechodu z jeho [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

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

Ano. Upřednostněte [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), když potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/), pokud stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) – SLOW, MEDIUM nebo FAST – a není nastavena explicitní doba. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického postupu.

**Mohu k přechodu připojit audio a nechat jej smyčkovat?**

Ano. Přiřaďte vložené audio k [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), nastavte [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) na START_SOUND z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) a povolte [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Audio bude smyčkovat až do dalšího zvukového události v promítání.

**Jaký je nejrychlejší způsob, jak použít stejný přechod na všechny snímky?**

Projděte kolekci [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) v prezentaci a pro každý snímek nastavte přechod [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) na stejnou hodnotu. V téže smyčce nastavte případné časování a možnosti efektu, aby chování bylo konzistentní napříč snímky.

**Jak mohu zkontrolovat, který přechod je aktuálně nastaven na snímku?**

Přečtěte vlastnost [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ze snímku [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE znamená, že není aplikován žádný efekt přechodu.