---
title: Spravovat přechody snímků v prezentacích pomocí Pythonu přes Java
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/python-java/slide-transition/
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
- Java
- Aspose.Slides
description: "Aplikovat přechody snímků, nakonfigurovat automatické postoupování snímků a přizpůsobit Morph a další efekty přechodu pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Přechody snímků určují, jak se snímky zobrazují během prezentace. S Aspose.Slides for Python via Java můžete pro každý snímek vybrat efekt přechodu, nastavit postupování kliknutím myši nebo časovačem a upravit možnosti specifické pro konkrétní efekt. Tento článek používá příklady v Pythonu k aplikaci přechodů, nastavení přesné doby trvání přechodu, správě časování snímků a vytvoření Morph‑přechodu mezi dvěma snímky. Příklady také ukazují, jak nastavení uložit do souboru PPTX.

## **Přidání přechodu snímku**

K aplikaci přechodu načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a získejte nastavení přechodu snímku přes [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Použijte [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), poté prezentaci uložte.

Následující příklad použije přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Kolečkový přechod**

Pomocí [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) vyberte Wheel z výčtu [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Pak zavolejte [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) a získejte nastavení [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Jeho metoda [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) určuje, kolik radiálních sektorů odhalí cílový snímek.

Příklad vytvoří dva identické páry snímků. Každý pár začíná černým snímkem a končí zlatým obdélníkem na celém snímku. Oba cílové snímky používají stejnou pomalou rychlost nastavenou pomocí [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) a stejnou explicitní dobu trvání 8 000 ms nastavenou pomocí [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Pouze počet koleček (spokes) se mění.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Otevřete `wheel-transitions.pptx` v PowerPointu a spusťte prezentaci. Postupujte ze snímku 1 na snímek 2 a uvidíte jedním po směru hodinových ručiček odhalení zlatého obdélníku. Pak přejděte ze snímku 3 na snímek 4 a uvidíte osm radiálních sektorů odhalujících stejný obdélník současně.

## **Fade Through Black s přechodem Reveal**

Nastavte typ přechodu cílového snímku na Reveal a poté zavolejte [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) na jeho nastavení [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/). Příklad vytvoří teal (modrozelený) zdrojový snímek a korálový cílový snímek, oba zkopíruje. Každý pár používá dvousekundový přechod Reveal. Pouze druhý pár přechází skrze černou.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Otevřete `reveal-transitions.pptx` v PowerPointu a spusťte prezentaci. Přechodem ze snímku 1 na snímek 2 uvidíte, jak teal přímo přechází do korálové barvy. Pak přejděte ze snímku 3 na snímek 4 – obrazovka se na okamžik ztmaví k černé, než se objeví korálový snímek. Oba snímky si zachovají své původní barvy pozadí.

Řádky níže ukazují snímky z PowerPointu po půl sekundě. Porovnejte prostřední snímek v každém řádku, abyste viděli efekt.

![Přehrávání v PowerPointu s vypnutým (nahoře) a zapnutým (dole) přechodem přes černou. Pouze dolní řada prochází téměř černou.](reveal-through-black.png)

## **Přidání pokročilého přechodu snímku**

Můžete nastavit, jak dlouho snímek zůstává na obrazovce a zda kliknutí myší postoupí prezentaci. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umožňuje uživateli postupovat kliknutím myši.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) povoluje automatické postupování.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) určuje zpoždění před automatickým postupem v milisekundách.

Povolte jak kliknutí, tak časovaný postup, aby uživatel mohl přejít kliknutím nebo počkat na časovač. Pro použití jen časovače předávejte `False` do [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Zpoždění určuje, kdy se prezentace posune dál; neovlivňuje délku vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatický postup po 3, 5 a 7 sekundách. Kliknutí myší mohou tyto snímky také posunout. Použijte soubor `input.pptx` s alespoň třemi snímky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Pro kontrolu, zda je časovaný postup povolen, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Pouze uložené zpoždění neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatický postup pro snímky s zpožděním delším než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přesné řízení načasování přechodu**

Pomocí [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) můžete určit přesnou délku efektu přechodu v milisekundách. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) na snímku vystavuje tato nastavení prostřednictvím [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Nastavuje délku trvání samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Nastavuje zpoždění před automatickým postupem snímku v milisekundách. Předejte `True` do [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) pro aktivaci tohoto časovače. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Vybere předdefinovanou rychlost z [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Použije se, když není zadána explicitní doba trvání. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) ovlivňuje pouze efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Zpoždění automatického postupu nastavte samostatně. Když není nastavená explicitní doba, Aspose.Slides určí dobu trvání efektem na základě typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Oddělené úsečky ukazují dobu trvání 750 ms přechodu a nastavení automatického posunu 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Sdílený příklad přiřazuje každému snímku 750 ms Fade přechod a samostatně povoluje automatický posun po 5 000 ms. Délka přechodu řídí efekt; posun určuje, kdy snímek opustit. Tyto úsečky jsou schematické nastavení, nikoli měřená kombinovaná časová osa.*
<!-- visual-explanation:slide-transition:end -->

### **Použít stejnou dobu trvání pro každý snímek**

Pro jednotné tempo použijte stejný efekt a přesnou dobu trvání na všechny snímky. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) a každému přechodu nastaví dobu 750 ms. Samostatně povolí automatický posun po 5 000 ms a zakáže posun kliknutím myši, poté výsledek uloží jako PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Nastavte automatické postoupování nezávisle na délce trvání efektu.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Nastavit různé doby trvání pro jednotlivé snímky**

Různé snímky mohou mít různé doby trvání efektu. Například použijte krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Koordinovat přechody s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/python-java/export-to-html5/) nebo [video](/slides/cs/python-java/convert-powerpoint-to-video/) nastavte přesné doby trvání přechodů před exportem, aby odpovídaly zamýšlenému tempu. Například použijte 600 ms fade mezi scénami a samostatně upravte zpoždění posunu každého snímku, aby byl čas na komentář nebo obsah.

Pro GIF a video koordinujte snímkovou frekvenci výstupu s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a časování podporuje zvolený formát, a předem si výstup prohlédněte, abyste potvrdili synchronizaci.

### **Načíst existující dobu trvání přechodu**

Před úpravou přechodu zavolejte [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) a zjistěte, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že žádná explicitní doba není nastavena; nezáporná hodnota udává uloženou dobu v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) k určení této délky. Nastavení typu přechodu může inicializovat dobu, takže nejprve zkontrolujte původní nastavení.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph přechod**

Morph‑přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph zkopírujte snímek, přesuňte nebo změňte velikost objektu na kopii a na druhý snímek použijte přechod Morph. To umožní animovat odpovídající objekty mezi jejich původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, zkopíruje jej a změní pozici a velikost obdélníku na kopii. Pak pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který Morph podporuje, a podívejte se na efekt během prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Typy Morph přechodu**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) určuje, jak Morph přiřazuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) zpracovává každou tvář jako celý objekt.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) animuje text porovnáním slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) animuje text porovnáním znaků, kde je to možné.

Pomocí [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) vyberte Morph před přístupem k [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Výsledek je pak instance třídy [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), jejíž metoda [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) vybírá režim přiřazení.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nastaví druhý snímek tak, aby používal animaci Morph na úrovni slov.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Nastavit efekty přechodu**

Některé přechody odhalují další možnosti, např. směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu vybraném pomocí [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Nejprve nastavte typ, potom použijte odpovídající třídu z [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Následující příklad použije přechod Cut na první snímek `input.pptx`. Zavolá [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) skrze [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/), aby přechod začínal z černé obrazovky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), pokud potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) – Slow, Medium nebo Fast – a není nastavena explicitní doba. Tato nastavení řídí efekt přechodu nezávisle na zpoždění automatického postupu.

**Mohu k přechodu přiřadit zvuk a nechat jej opakovat?**

Ano. Přiřaďte vložený zvuk pomocí [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), předávejte StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) metodě [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) a povolte [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) s `True`. Zvuk se bude opakovat, dokud nevyvolá další zvuková událost v prezentaci.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Projděte kolekci [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) prezentace a pro každý snímek zavolejte [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) se stejnou hodnotou. V téže smyčce nastavte případné načasování a možnosti efektu, aby chování bylo konzistentní napříč snímky.

**Jak zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) na výsledek [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); None_ znamená, že není aplikován žádný efekt přechodu.