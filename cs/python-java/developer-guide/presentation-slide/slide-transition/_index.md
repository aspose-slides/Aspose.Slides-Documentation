---
title: Správa přechodů snímků v prezentacích pomocí Pythonu přes Java
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/python-java/slide-transition/
keywords:
- přechod snímku
- přidání přechodu snímku
- aplikace přechodu snímku
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
description: "Aplikujte přechody snímků, nastavte automatické postupování snímků a přizpůsobte Morph a další efekty přechodů pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides pro Python přes Java můžete pro každý snímek vybrat efekt přechodu, nastavit postupování kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v Pythonu k aplikaci přechodů, nastavení přesné délky trvání přechodu, správě časování snímků a vytvoření přechodu Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Pro aplikaci přechodu načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a přistupte k nastavení přechodu snímku prostřednictvím [getSlideShowTransition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getSlideShowTransition). Použijte [setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setType) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitiontype/), poté prezentaci uložte.

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

## **Přidání pokročilého přechodu snímku**

Můžete nastavit, jak dlouho snímek zůstane na obrazovce a zda kliknutí myší posune prezentaci dál. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umožňuje divákovi postoupit kliknutím myši.
- [setAdvanceAfter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) povoluje automatické postupování.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) určuje zpoždění před automatickým postupováním v milisekundách.

Povolte jak kliknutí, tak časované postupování, aby divák mohl pokračovat kliknutím nebo čekat na časovač. Pro použití pouze časovače předávejte `False` metodě [setAdvanceOnClick](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Zpoždění řídí, kdy se prezentace posune dál; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatické postupování po 3, 5 a 7 sekundách. Kliknutí myší mohou také tyto snímky posunout. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Pro kontrolu, zda je časované postupování povoleno, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Uložené zpoždění samo o sobě neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatické postupování pro snímky se zpožděním delším než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

## **Přesné řízení časování přechodu**

Použijte [setDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setDuration) ke specifikaci přesné délky trvání efektu přechodu v milisekundách. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getSlideShowTransition) snímku vystavuje tato nastavení prostřednictvím třídy [SlideShowTransition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setDuration) | Nastavuje délku trvání samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Nastavuje zpoždění před automatickým posunutím snímku v milisekundách. Pro aktivaci tohoto časovače předávejte `True` metodě [setAdvanceAfter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter). |
| [setSpeed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setSpeed) | Vybere předdefinovanou rychlostní kategorii z výčtu [TransitionSpeed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána explicitní délka trvání. |

[setDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setDuration) řídí pouze efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Automatické zpoždění postupování se nastavuje samostatně. Když není explicitně nastavená délka, Aspose.Slides určí délku efektu z typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#getSpeed).

### **Použití stejné délky na každý snímek**

Pro konzistentní tempo aplikujte stejný efekt a přesnou délku na všechny snímky. Tento příklad načte `input.pptx`, vybere Fade z výčtu [TransitionType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitiontype/) a přiřadí každému přechodu délku 750 milisekund. Samostatně povolí automatické postupování po 5 000 milisekundách a zakáže postupování kliknutím, poté výsledek uloží jako PPTX.

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

        # Nastavte automatické postupování nezávisle na délce trvání efektu.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Nastavení různých délek pro jednotlivé snímky**

Různé snímky mohou mít různé délky efektu. Například můžete použít krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 milisekund pro první snímek a 1 200 milisekund pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

### **Koordinace přechodů s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/python-java/export-to-html5/) nebo [video](/slides/cs/python-java/convert-powerpoint-to-video/) nastavte přesné délky přechodů před exportem, aby odpovídaly požadovanému tempu. Například použijte 600 ms fade mezi scénami a samostatně upravte zpoždění postupování každého snímku, aby bylo dostatek času na jeho komentář nebo obsah.

Pro GIF a video koordinujte snímkovou rychlost výstupu s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte podporované efekty a časové možnosti zvoleného formátu a proveďte náhled výstupu, abyste potvrdili synchronizaci.

### **Načtení existující délky přechodu**

Před úpravou přechodu zavolejte [getDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#getDuration), abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastavená žádná explicitní délka; ne záporná hodnota udává uloženou délku v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#getSpeed) k určení této délky. Nastavení typu přechodu může inicializovat délku, takže nejprve zkontrolujte původní nastavení.

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

## **Přechod Morph**

Přechod Morph animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph zkopírujte snímek, přesuňte nebo změňte velikost objektu na kopii a použijte přechod Morph na druhý snímek. Tím se při přechodu animují odpovídající objekty mezi jejich původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, zkopíruje snímek a změní pozici a velikost obdélníku na kopii. Poté vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitiontype/) pro druhý snímek. Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a podívejte se na efekt během prezentace.

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

## **Typy přechodu Morph**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitionmorphtype/) určuje, jak Morph páruje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitionmorphtype/#ByObject) zachází s každým tvarem jako s celým objektem.
- [ByWord](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitionmorphtype/#ByWord) animuje text párováním slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitionmorphtype/#ByChar) animuje text párováním znaků, kde je to možné.

Použijte [setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setType) pro výběr Morph před přístupem k [getValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#getValue). Hodnota je potom instance třídy [MorphTransition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/morphtransition/), jejíž metoda [setMorphType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/morphtransition/#setMorphType) vybere režim párování.

Tento příklad otevře prezentaci vytvořenou v předchozí sekci a nastaví druhý snímek tak, aby používal animaci Morph založenou na slovech.

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

## **Nastavení efektů přechodu**

Některé přechody nabízejí další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu vybraném pomocí [setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setType). Nejprve nastavte typ, poté použijte vhodnou třídu z [getValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#getValue).

Následující příklad použije přechod Cut na první snímek souboru `input.pptx`. Volá [setFromBlack](https://reference.aspose.com/slides/cs/python-java/aspose.slides/optionalblacktransition/#setFromBlack) přes [OptionalBlackTransition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/optionalblacktransition/), aby přechod začínal z černé obrazovky.

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

**Can I control the playback speed of a slide transition?**  
**Mohu ovládat rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [setDuration](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setDuration), když potřebujete přesnou délku efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setSpeed), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitionspeed/) – Slow, Medium nebo Fast – a není nastavena explicitní délka. Tato nastavení řídí efekt přechodu nezávisle na zpoždění automatického postupování.

**Can I attach audio to a transition and make it loop?**  
**Mohu k přechodu připojit zvuk a nechat jej smyčkovat?**

Ano. Přiřaďte vložený zvuk pomocí [setSound](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setSound), předávejte `StartSound` z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitionsoundmode/) metodě [setSoundMode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setSoundMode) a povolte [setSoundLoop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setSoundLoop) s hodnotou `True`. Zvuk bude smyčkovat až do dalšího zvukového události v prezentaci.

**What's the fastest way to apply the same transition to every slide?**  
**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na každý snímek?**

Procházejte kolekci [getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides) prezentace a pro každý snímek zavolejte [setType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#setType) se stejnou hodnotou. V tomtéž cyklu nastavte případné časování a možnosti efektu, aby chování bylo konzistentní napříč snímky.

**How can I check which transition is currently set on a slide?**  
**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideshowtransition/#getType) na výsledek [getSlideShowTransition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getSlideShowTransition) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/transitiontype/); `None_` znamená, že není aplikován žádný přechod.