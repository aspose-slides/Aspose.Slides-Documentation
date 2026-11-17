---
title: Spravovat přechody snímků v prezentacích pomocí Pythonu přes Java
linktitle: Přechod snímku
type: docs
weight: 80
url: /cs/python-java/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- použít přechod snímku
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
description: "Použijte přechody snímků, nastavte automatické posouvání snímků a přizpůsobte Morph a další efekty přechodů pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Přechody snímků kontrolují, jak se snímky zobrazují během prezentace. S Aspose.Slides pro Python přes Java můžete pro každý snímek vybrat efekt přechodu, nastavit postup pomocí kliknutí myší nebo časovače a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v Pythonu k aplikaci přechodů, nastavení přesných délek přechodů, správě časování snímků a vytvoření Morph přechodu mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Pro aplikaci přechodu načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a přistupte k nastavení přechodu snímku pomocí [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Použijte [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) s hodnotou z výčtu [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), poté prezentaci uložte. Následující příklad použije přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s minimálně dvěma snímky.

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

Použijte [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) k výběru Wheel z [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Poté zavolejte [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) a přistupte k nastavením [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Jeho metoda [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) určuje, kolik radiálních sektorů odhalí cílový snímek. Příklad vytvoří dva identické páry snímků. Každý pár začíná černým snímkem a končí zlatým obdélníkem přes celý snímek. Oba cílové snímky používají stejnou pomalou rychlost nastavenou pomocí [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) a stejnou explicitní dobu trvání 8 000 ms nastavenou pomocí [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Pouze počet paprsků (spokes) se mění.

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

Otevřete `wheel-transitions.pptx` v PowerPointu a spusťte prezentaci. Postupujte ze snímku 1 na snímek 2 a uvidíte, jak jeden pootočený tah odhalí zlatý obdélník. Pak postupujte ze snímku 3 na snímek 4 a uvidíte, jak osm radiálních sektorů odhalí stejný obdélník současně.

## **Přidání pokročilého přechodu snímku**

Můžete nastavit, jak dlouho snímek zůstává na obrazovce a zda kliknutí myší posune prezentaci dál. Následující metody řídí toto chování:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umožňuje divákovi posunout prezentaci kliknutím myši.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) povoluje automatický posun.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) určuje prodlevu před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak časovaný posun, aby mohl divák pokračovat kliknutím nebo čekáním na časovač. Pro použití pouze časovače předávejte `False` metodě [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Prodleva řídí, kdy se prezentace posune; nenastavuje délku vizuálního efektu přechodu. Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatický posun po 3, 5 a 7 sekundách. Kliknutí myší může také posunout tyto snímky. Použijte soubor `input.pptx` s minimálně třemi snímky.

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

Pro kontrolu, zda je časovaný posun povolen, zavolejte [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Uložená prodleva samotná neznamená, že je časovač aktivní. Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatický posun pro snímky s prodlevou delší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

Použijte [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) k určení přesné délky efektu přechodu v milisekundách. Metoda snímku [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) zpřístupní tato nastavení přes [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Metoda | Účel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Nastaví délku samotného efektu přechodu v milisekundách. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Nastaví prodlevu před automatickým posunem snímku v milisekundách. Pro aktivaci časovače předávejte `True` metodě [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter). |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána přesná doba trvání. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) řídí pouze efekt přechodu; neurčuje, jak dlouho snímek zůstává viditelný. Automatickou prodlevu posunu nastavte samostatně. Pokud není zadána explicitní doba, Aspose.Slides určuje délku efektu podle typu přechodu a hodnoty [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Samostatné pruhy označují dobu trvání přechodu 750 ms a nastavení automatického posunu 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Sdílený příklad dává každému snímku přechod Fade 750 ms a samostatně povoluje automatický posun po 5 000 ms. Délka přechodu řídí efekt; posun řídí, kdy snímek opustit. Tyto pruhy jsou schematické nastavení, nikoli měřená kombinovaná časová osa.*
<!-- visual-explanation:slide-transition:end -->

### **Použít stejnou dobu trvání na všechny snímky**

Pro konzistentní tempo aplikujte stejný efekt a přesnou dobu trvání na všechny snímky. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), a každému přechodu přiřadí dobu trvání 750 ms. Samostatně povolí automatický posun po 5 000 ms a zakáže posun kliknutím myši, poté výsledek uloží jako PPTX.

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

        # Nastavte automatické posouvání nezávisle na délce efektu.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Nastavit různé doby trvání pro jednotlivé snímky**

Různé snímky mohou používat různé doby trvání efektů. Například použijte krátký přechod pro úvodní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s minimálně dvěma snímky.

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

Při přípravě [animated GIF](/slides/cs/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/python-java/export-to-html5/) nebo [video](/slides/cs/python-java/convert-powerpoint-to-video/) nastavte přesné doby trvání přechodů před exportem, aby odpovídaly zamýšlenému tempu. Například použijte 600 ms rozmazání (fade) mezi scénami a samostatně upravte prodlevu posunu každého snímku, aby byl dostatek času na jeho komentář nebo obsah.

Pro GIF a video koordinujte výstupní snímkovou frekvenci s délkou efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, které efekty a časové možnosti podporuje vybraný formát exportu, a prohlédněte výstup, abyste potvrdili synchronizaci.

### **Načtení existující doby trvání přechodu**

Zavolejte [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) před úpravou přechodu, abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastavená explicitní doba; nezáporná hodnota určuje uloženou dobu v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a hodnotu [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) k určení této doby. Nastavení typu přechodu může iniciovat dobu, proto nejprve prozkoumejte původní nastavení.

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

Morph přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph duplikujte snímek, přesuňte nebo změňte velikost objektu na duplikátu a na druhý snímek aplikujte Morph přechod. Tento přechod pak poskytne odpovídající objekty k animaci mezi jejich původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, duplikuje snímek a změní pozici a velikost obdélníku na duplikátu. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, abyste viděli efekt během prezentace.

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

Výčtová hodnota [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) řídí, jak Morph odpovídá a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) zachází s každým tvarem jako s celým objektem.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) animuje text tím, že pokud možno odpovídá slovům.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) animuje text tím, že pokud možno odpovídá znakům.

Použijte [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) k výběru Morph před přístupem k [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Výsledek je pak instance třídy [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), jejíž metoda [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) vybere režim odpovídání.

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

Některé přechody odhalují další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na přechodu vybraném pomocí [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Nejprve nastavte typ, poté použijte odpovídající třídu z [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Následující příklad použije přechod Cut na první snímek `input.pptx`. Zavolá [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) přes [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/), aby přechod začínal z černé obrazovky.

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

## **Často kladené dotazy**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), pokud potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed), když je dostačující předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) — Slow, Medium nebo Fast — a není nastavená explicitní doba. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického posunu.

**Mohu k přechodu přiřadit zvuk a nechat jej smyčkovat?**

Ano. Přiřaďte vložený zvuk metodou [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), předávejte StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) metodě [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) a povolte [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) s `True`. Zvuk se smyčkuje, dokud nenastane další zvuková událost v prezentaci.

**Jaký je nejrychlejší způsob, jak použít stejný přechod na všechny snímky?**

Projděte kolekci [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) prezentace a zavolejte [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) se stejnou hodnotou pro přechod každého snímku. V téže smyčce nastavte všechny časové a efektové možnosti, aby chování bylo konzistentní napříč snímky.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Zavolejte [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) na výsledek [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); None_ znamená, že není aplikován žádný efekt přechodu.