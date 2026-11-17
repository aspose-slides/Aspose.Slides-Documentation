---
title: Diaátmenetek kezelése prezentációkban Python használatával
linktitle: Diaátmenet
type: docs
weight: 90
url: /hu/python-net/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- speciális diaátmenet
- Morph átmenet
- átmenettípus
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, konfigurálja az automatikus diák előrehaladását, és testreszabja a Morph és egyéb átmeneti effektusokat az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

A diavetítés-átmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for Python via .NET segítségével kiválaszthatja az átmeneti hatást minden egyes diára, beállíthatja az előrehaladást egérkattintással vagy időzítővel, és módosíthatja az effektusra jellemző beállításokat. Ez a cikk Python példákkal mutatja be az átmenetek alkalmazását, a pontos átmeneti időtartamok beállítását, a diák időzítésének kezelését, valamint két dia közötti Morph átmenet létrehozását. A példák azt is bemutatják, hogyan menthetőek a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztállyal, és érje el a dia [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) tulajdonságát. Állítsa be a [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) felsorolásból származó értékre, majd mentse a prezentációt.

A következő példa kör (Circle) átmenetet alkalmaz az első diára és Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Kerékátmenet**

A [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) tulajdonság a [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) osztályban szabályozza a sugárirányú szektorok számát, amelyek feltárják a cél diát. Állítsa be a dia átmenetének [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét WHEEL-re a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) felsorolásból, mielőtt a [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/)‑t [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/)-ként érné el.

Ez a példa két azonos diapárt hoz létre: egy fekete diát, amelyet egy arany téglalappal ellátott dia követ. A cél diák 1 és 8 spurcszámot használnak, ugyanazzal a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) értékkel és egy kifejezett [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 8 000 ms‑mal, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti prezentációt PowerPointban, és indítsa el a diavetítést. Lépjen a 1. diáról a 2.-re, majd a 3.-ról a 4.-re. PowerPoint lejátszás során az 1‑es spurcszám egy óramutató járásával megegyező mozdulattal tárja fel a diát; a 8‑as szám nyolc sugárirányú szektor egyszerre tárja fel. A cél tartalom és az átmenet időzítése azonos, így a különbség a megjelenítő szektorok száma.

## **Speciális diaátmenet hozzáadása**

Beállíthatja, mennyi ideig marad a dia a képernyőn, és hogy egérkattintás előre halad‑e a diavetítést. A következő tulajdonságok szabályozzák ezt a viselkedést:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) lehetővé teszi a nézőnek, hogy egérkattintással haladjon tovább.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) engedélyezi az automatikus előrehaladást.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) meghatározza az automatikus előrehaladás késleltetését ezredmásodpercben.

Engedélyezze mind a kattintásos, mind az időzített előrehaladást, hogy a néző kattintással vagy a várakozási idő lejárta után léphessen tovább. Ha csak az időzítőt szeretné használni, állítsa a [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) értékét `False`‑ra. A késleltetés azt szabályozza, mikor halad előre a diavetítés; nem állítja be a vizuális átmeneti effektus időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus előrehaladást engedélyez 3, 5 és 7 másodperc után, sorrendben. Egérkattintással is előre lehet lépni ezeken a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Az időzített előrehaladás engedélyezésének ellenőrzéséhez olvassa a [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) értékét. A tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azoknál a diáknál, ahol a késleltetés több mint két másodperc. Egérkattintást engedélyez ezeknek a diáknak, és elmenti a frissített beállításokat.

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

## **Az átmeneti időzítés pontos vezérlése**

Használja a [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) beállítást a átmeneti effektus pontos hossza miliszekundumban való megadására. A dia [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) tulajdonsága ezeket a beállításokat a [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) objektumon keresztül teszi elérhetővé:

| Tulajdonság | Cél |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Beállítja maga az átmeneti effektus időtartamát ezredmásodpercben. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Beállítja a késleltetést, mielőtt a dia automatikusan előrehalad, ezredmásodpercben. Engedélyezze a [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) értéket a timer aktiválásához. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) felsorolásból: SLOW, MEDIUM vagy FAST. Akkor használatos, ha nincs megadva pontos időtartam. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig marad látható a dia. A automatikus előrehaladási késleltetést külön kell beállítani. Ha nincs kifejezett időtartam megadva, az Aspose.Slides a hatás időtartamát a átmenet típusából és a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) értékből állapítja meg.

<!-- visual-explanation:slide-transition:start -->
[![A különálló sávok jelölik a 750 ms átmeneti időtartamot és az 5 000 ms automatikus előrehaladási beállítást.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Ugyanazt az időtartamot alkalmazni minden diára**

Az egységes tempó érdekében alkalmazzon ugyanazt az effektust és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) listából a Fade‑et választja, és minden átmenetnek 750 milliszekundumos időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 ms után, és letiltja az egérkattintásos előrehaladást, majd PPTX‑ként menti az eredményt.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Az automatikus előrehaladást a hatás időtartamától függetlenül állítsa be.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Különböző időtartamok beállítása egyedi diákhoz**

Különböző diák különböző effektus időtartamokat használhatnak. Például egy rövid átmenetet a címdián, és hosszabb átmenetet egy szakasz bevezetőjénél. Ez a példa 500 ms‑t állít be az első diához, és 1 200 ms‑t a másodikhoz. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Az átmenetek összehangolása animált kimenettel**

Animált [GIF](/slides/hu/python-net/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/python-net/export-to-html5/) vagy [videó](/slides/hu/python-net/convert-powerpoint-to-video/) előkészítésekor állítsa be a pontos átmeneti időtartamokat exportálás előtt, hogy megfeleljenek a kívánt tempónak. Például használjon 600 ms fade‑átmenetet a jelenetek között, és állítsa be minden dia előrehaladási késleltetését külön‑külön, hogy időt biztosítson a narráció vagy a tartalom számára.

GIF és videó esetén egyeztesse a kimeneti képkockasebességet az effektus időtartamával: 600 ms 18 képkockának felel meg 30 fps‑nél. HTML5‑ben engedélyezze az animált átmeneteket az export beállításokban. Ellenőrizze a kiválasztott exportformátum támogatott effektusait és időzítési beállításait, és tekintse meg a kimenetet a szinkronizáció megerősítéséhez.

### **Meglévő átmeneti időtartam olvasása**

Olvassa el a [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) értékét az átmenet módosítása előtt, hogy meghatározza, van‑e tárolt kifejezett érték. A `-1` érték azt jelenti, hogy nincs beállítva kifejezett időtartam; egy nem negatív érték a tárolt időtartamot adja meg ezredmásodpercben. A be nem állított érték nem a számított lejátszási idő: az Aspose.Slides a átmenet típusát és a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) értéket használja az időtartam meghatározásához. Egy átmenet típus beállítása inicializálhat egy időtartamot, ezért előbb vizsgálja meg az eredeti beállításokat.

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

## **Morph átmenet**

A Morph átmenet animálja a változásokat a szomszédos diákon lévő objektumok között. Egy egyszerű Morph hatás létrehozásához klónozzon egy diát, mozgassa vagy módosítsa a méretét egy objektumnak a klónon, majd alkalmazza a Morph átmenetet a második diára. Ez lehetővé teszi, hogy az átmenet a megfelelő objektumokat animálja az eredeti és a módosított állapot között.

A következő példa egy szöveges téglalappal rendelkező diát hoz létre, klónozza a diát, és megváltoztatja a téglalap pozícióját és méretét a klónon. Ezután a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) felsorolásból a Morph‑ot választja a második diához. Nyissa meg a mentett fájlt egy Morph‑ot támogató prezentációs megjelenítőben, hogy lássa az effektust a diavetítés során.

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

## **Morph átmenettípusok**

Az [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) felsorolás szabályozza, hogy a Morph hogyan párosítja és animálja a tartalmat:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) minden alakzatot egy egész objektumként kezel.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) a szöveget szavak egyezése alapján animálja, ahol lehetséges.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) a szöveget karakterek egyezése alapján animálja, ahol lehetséges.

Állítsa be a transition [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét Morph‑ra, mielőtt a [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/)‑t elérné. Az érték ezután a [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) objektumot adja, amelynek a [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) tulajdonsága választja ki a megfelelő módot.

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

## **Átmeneti effektusok beállítása**

Néhány átmenet további beállítási lehetőségeket tesz elérhetővé, például irányt vagy azt, hogy az effektus fekete képernyőről indul‑e. Az elérhető opciók a kiválasztott transition [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) függvényei. Először állítsa be a típust, majd a megfelelő átmenet objektumot használja a [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/)‑ból.

A következő példa Cut átmenetet alkalmaz az `input.pptx` első diájára. Beállítja a [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) tulajdonságot az [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) segítségével, hogy az átmenet fekete képernyőről induljon.

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

## **GYIK**

**Kezelhetem a diaátmenet lejátszási sebességét?**

Igen. Használja a [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) beállítást, ha pontos effektus időtartamot szeretne ezredmásodpercben. Használja a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) beállítást, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) kategória—SLOW, MEDIUM vagy FAST—elégséges, és nincs explicit időtartam beállítva. Ezek a beállítások az átmeneti effektust szabályozzák az automatikus előrehaladási késleltetéstől függetlenül.

**Csatolhatok hangot egy átmenethez, és hurkolhatom azt?**

Igen. Rendeljen beágyazott hangot a [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) tulajdonsághoz, állítsa a [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) értékét a [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) felsorolásból a START_SOUND‑re, és engedélyezze a [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) beállítást. A hang a diavetítés következő hangeseményéig ismétlődik.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzuk minden diára?**

Iteráljon végig a prezentáció [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) gyűjteményén, és állítsa minden dia átmeneti [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét ugyanarra. Állítson be minden időzítési és effektus opciót ugyanabban a ciklusban, hogy a viselkedés konzisztens maradjon a diák között.

**Hogyan ellenőrizhetem, melyik átmenet van jelenleg beállítva egy dián?**

Olvassa a [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) tulajdonságot a dia [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) objektumából. Egy értéket ad vissza a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) felsorolásból; a NONE azt jelenti, hogy nincs átmeneti effektus alkalmazva.