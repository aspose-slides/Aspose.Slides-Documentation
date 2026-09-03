---
title: Správa přechodů snímků v prezentacích pomocí Pythonu
linktitle: Přechod snímku
type: docs
weight: 90
url: /cs/python-net/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- aplikovat přechod snímku
- pokročilý přechod snímku
- morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Aplikujte přechody snímků, nastavte automatické posouvání snímků a upravte Morph a další efekty přechodu s Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides pro Python přes .NET můžete pro každý snímek zvolit efekt přechodu, nakonfigurovat postupování kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v Pythonu k použití přechodů, nastavení přesných dob trvání přechodu, správě načasování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Chcete-li použít přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a přistupte k vlastnosti [slide_show_transition](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/slide_show_transition/). Nastavte její [type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/type/) na hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitiontype/), poté prezentaci uložte.

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

## **Přidání pokročilého přechodu snímku**

Můžete nastavit, jak dlouho snímek zůstává na obrazovce a zda kliknutí myší posune prezentaci dál. Následující vlastnosti řídí toto chování:

- [advance_on_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) umožňuje divákovi posunout kliknutím myši.
- [advance_after](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) umožňuje automatické posunutí.
- [advance_after_time](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) určuje prodlevu před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak časované posunutí, aby divák mohl pokračovat kliknutím nebo čekáním na časovač. Chcete-li použít pouze časovač, nastavte [advance_on_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) na `False`. Prodleva řídí, kdy se prezentace posune; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty k prvním třem snímkům a povolí automatické posunutí po 3, 5 a 7 sekundách. Kliknutí myší může také posunout tyto snímky. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Chcete‑li zjistit, zda je časované posunutí povoleno, přečtěte [advance_after](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Uložená prodleva sama o sobě neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, vypíše každý povolený časovač a zakáže automatické posunutí pro snímky s prodlevou delší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

## **Přesné řízení časování přechodu**

Pro určení přesné délky efektu přechodu v milisekundách použijte [duration](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/duration/). Vlastnost [slide_show_transition](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/slide_show_transition/) snímku poskytuje tato nastavení přes [SlideShowTransition](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/):

| Vlastnost | Účel |
| --- | --- |
| [duration](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Nastaví dobu trvání samotného efektu přechodu v milisekundách. |
| [advance_after_time](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Nastaví prodlevu před automatickým posunutím snímku v milisekundách. Aktivujte [advance_after](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) k zapnutí tohoto časovače. |
| [speed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM nebo FAST. Používá se, když není zadána přesná doba trvání. |

[duration] řídí pouze efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatickou prodlevu pro posunutí nastavte samostatně. Když není explicitně nastavena doba trvání, Aspose.Slides určuje délku efektu podle typu přechodu a hodnoty [speed].

### **Použít stejnou dobu trvání na každý snímek**

Pro jednotné tempo použijte stejný efekt a přesnou dobu trvání na každý snímek. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitiontype/) a přiřadí každému přechodu dobu 750 ms. Samostatně povolí automatické posunutí po 5 000 ms a zakáže posun kliknutím myši, poté výsledek uloží jako PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Nastavte automatické posunutí nezávisle na době trvání efektu.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Nastavit různé doby trvání pro jednotlivé snímky**

Různé snímky mohou používat různé doby trvání efektu. Například můžete použít krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

Při přípravě [animated GIF](/slides/cs/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/python-net/export-to-html5/) nebo [video](/slides/cs/python-net/convert-powerpoint-to-video/) nastavte přesné doby trvání přechodů před exportem, aby odpovídaly požadovanému tempu. Například použijte 600 ms fade mezi scénami a samostatně upravte prodlevu posunu pro každý snímek, aby byl dostatek času na jeho komentář či obsah.

Pro GIF a video koordinujte výstupní snímkovou frekvenci s dobou trvání efektu: 600 ms odpovídá 18 rámcům při 30 fps. V HTML5 povolte animované přechody v nastaveních exportu. Zkontrolujte, které efekty a časovací možnosti podporuje zvolený formát, a předběžně si prohlédněte výstup, abyste potvrdili synchronizaci.

### **Čtení existující doby trvání přechodu**

Před úpravou přechodu přečtěte [duration](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/duration/), abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že žádná explicitní doba trvání není nastavena; nezáporná hodnota udává uloženou dobu v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a [speed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/speed/) k určení této doby. Nastavení typu přechodu může inicializovat dobu trvání, takže nejprve zkontrolujte původní nastavení.

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

Přechod Morph animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph duplikujte snímek, přesunte nebo změňte velikost objektu na duplikátu a použijte přechod Morph na druhý snímek. Tím získá přechod odpovídající objekty k animaci mezi jejich původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, duplikuje snímek a změní pozici a velikost obdélníku na duplikátu. Pak pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a uvidíte efekt během prezentace.

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

Výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitionmorphtype/) určuje, jak Morph přiřazuje a animuje obsah:

- [BY_OBJECT](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitionmorphtype/) považuje každý tvar za celý objekt.
- [BY_WORD](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitionmorphtype/) animuje text přiřazením slov, kde je to možné.
- [BY_CHAR](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitionmorphtype/) animuje text přiřazením znaků, kde je to možné.

Nastavte přechod [type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/type/) na Morph před přístupem k jeho [value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/value/). Hodnota pak poskytne objekt [MorphTransition](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/morphtransition/), jehož vlastnost [morph_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/morphtransition/morph_type/) vybere režim přiřazení.

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

Některé přechody nabízejí další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na vybraném [type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/type/). Nejprve nastavte typ, pak použijte odpovídající přechodový objekt z jeho [value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Následující příklad použije přechod Cut na první snímek `input.pptx`. Nastaví [from_black](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) přes [OptionalBlackTransition](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/optionalblacktransition/), aby přechod začínal z černé obrazovky.

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

Ano. Upřednostněte [duration](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/duration/), pokud potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [speed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/speed/), pokud stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitionspeed/) – SLOW, MEDIUM nebo FAST – a není nastavena explicitní doba trvání. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického posunu.

**Mohu k přechodu připojit zvuk a nechat ho opakovat?**

Ano. Přiřaďte vložený zvuk k [sound](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/sound/), nastavte [sound_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) na START_SOUND z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitionsoundmode/) a povolte [sound_loop](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Zvuk se bude opakovat až do dalšího zvukového události v prezentaci.

**Jak nejrychleji použít stejný přechod na všechny snímky?**

Projděte kolekci [slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slides/cs/) prezentace a pro každý snímek nastavte přechod [type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/type/) na stejnou hodnotu. V tomtéž cyklu nastavte případné časové a efektové možnosti, aby chování zůstalo konzistentní napříč snímky.

**Jak zjistit, který přechod je aktuálně nastaven na snímku?**

Přečtěte vlastnost [type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/type/) ze snímku's [slide_show_transition](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/slide_show_transition/). Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitiontype/); NONE znamená, že žádný přechod není aplikován.