---
title: Diaátmenetek kezelése prezentációkban Python segítségével
linktitle: Diaátmenet
type: docs
weight: 90
url: /hu/python-net/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- fejlett diaátmenet
- Morph átmenet
- átmenettípus
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Diaátmenetek alkalmazása, automatikus dia előrehaladás beállítása, valamint a Morph és egyéb átmeneti effektusok testreszabása az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Diaátmenetek szabályozzák, hogy a diák hogyan jelennek meg egy diavetítés során. Az Aspose.Slides for Python via .NET segítségével kiválaszthatja az átmeneti effektust minden egyes diára, beállíthatja az előrehaladást egérkattintással vagy időzítővel, és módosíthatja az effektusra jellemző beállításokat. Ez a cikk Python‑példákat használ a átmenetek alkalmazására, a pontos átmeneti időtartamok beállítására, a diaidőzítés kezelésére, és a Morph átmenet létrehozására két dia között. A példák azt is bemutatják, hogyan kell elmenteni a beállításokat PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztállyal, és érje el a dia [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) tulajdonságát. Állítsa be a [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) felsorolt értéke közül, majd mentse a bemutatót.

Az alábbi példa kör (Circle) átmenetet alkalmaz az első diára, és Comb átmenetet a másodikra. Használjon egy legalább két diát tartalmazó `input.pptx` fájlt.

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

[spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) tulajdonság a [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) osztályban szabályozza, hogy hány sugárirányú szektor fedje fel a cél diát. Állítsa a dia átmenetének [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét WHEEL‑re a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑ból, mielőtt a [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) értékét [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/)‑ként elérné.

Ez a példa két azonos diáspárt hoz létre: egy fekete diát, amelyet egy arany téglalappal rendelkező dia követ. A cél diák 1 és 8 sugárszámmal rendelkeznek, ugyanazzal a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) beállítással és egy 8 000 milliszekundumos [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) értékkel, hogy a különbség könnyen megfigyelhető legyen.

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

Nyissa meg a kimeneti bemutatót PowerPointban, és indítsa el a diavetítést. Haladjon az 1. diáról a 2.-re, majd a 3.-ról a 4.-re. PowerPoint lejátszás során az 1 sugár helyes száma egy óramutató járásával megegyező mozdulattal mutatja fel a diát; a 8 sugár helyes száma nyolc sugárszektor egyszerre fed fel. A cél tartalom és az átmenet időzítése azonos, így a különbség a felfedési szektorok száma.

## **Feketével való áttűnés a Reveal átmenettel**

Állítsa a cél dia átmenetének [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét Reveal‑re, majd állítsa be a [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) tulajdonságot a létrejött [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/) objektumban. A példa egy türkiz forrás diát és egy korall cél diát hoz létre, majd klónozza a párost. Mindkét pár ugyanazt a két másodperces Reveal átmenetet használja. Csak a második pár feketével történő áttűnést alkalmaz.

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

Nyissa meg a `reveal-transitions.pptx` fájlt PowerPointban, és indítsa el a diavetítést. Haladjon az 1. diáról a 2.-re, hogy lássa, ahogy a türkiz közvetlenül a korallba olvad. Ezután lépjen a 3. diáról a 4.-re. A képernyő röviden majdnem feketévé sötétedik, mielőtt a korall dia megjelenik. Mindkét dia megtartja eredeti háttérszínét.

A lenti sorok fél másodpercenkénti PowerPoint‑képkockákat mutatnak. Hasonlítsa össze minden sor középső képkockáját, hogy lássa a beállítás hatását.

![PowerPoint lejátszás a through_black letiltva (felül) és engedélyezve (alul). Csak az alsó sor halad át a közel fekete színűn.](reveal-through-black.png)

## **Fejlett diaátmenet hozzáadása**

Beállíthatja, hogy egy dia mennyi ideig maradjon a képernyőn, és hogy egérkattintás léptesse‑e előre a diavetítést. A következő tulajdonságok szabályozzák ezt a viselkedést:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) lehetővé teszi a néző számára, hogy egérkattintással lépjen tovább.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) automatikus előrehaladást tesz lehetővé.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) megadja az automatikus előrehaladás késleltetését ezredmásodpercben.

Engedélyezze mind a kattintással, mind az időzített előrehaladást, hogy a néző kattintással léphessen tovább vagy a timerre várjon. Ha csak a timert szeretné használni, állítsa a [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) értékét `False`‑ra. A késleltetés szabályozza, mikor lép tovább a diavetítés; nem határozza meg a vizuális átmenet effektus időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus előrehaladást engedélyez 3, 5 és 7 másodperc után, rendre. Egérkattintással is léphet tovább ezeken a diákon. Használjon egy legalább három diát tartalmazó `input.pptx` fájlt.

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

A timed előrehaladás engedélyezésének ellenőrzéséhez olvassa ki a [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) értékét. Egy tárolt késleltetés önmagában nem jelzi, hogy a timer aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett timer‑ről, és letiltja az automatikus előrehaladást azoknál a diáknál, ahol a késleltetés nagyobb mint két másodperc. Ezeknél a diáknál engedélyezi az egérkattintást, majd elmenti a módosított beállításokat.

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

## **Az átmenet időzítésének pontos szabályozása**

A [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) segítségével adható meg egy átmeneti effektus pontos hossza ezredmásodpercben. A dia [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) tulajdonsága ezeket a beállításokat a [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) objektumon keresztül teszi elérhetővé:

| Tulajdonság | Cél |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Beállítja az átmeneti effektus tényleges időtartamát ezredmásodpercben. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Beállítja a késleltetést, mielőtt a dia automatikusan előrehalad, ezredmásodpercben. Engedélyezze a [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) a timer aktiválásához. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Kiválaszt egy előre definiált sebesség kategóriát a [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/)-ból: SLOW, MEDIUM vagy FAST. Akkor használatos, ha nincs megadva konkrét időtartam. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig marad látható a dia. A automatikus előrehaladás késleltetését külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a transition type‑ból és a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) értékből határozza meg a hatás időtartamát.

<!-- visual-explanation:slide-transition:start -->
[![Külön sávok jelzik a 750 ms átmeneti időtartamot és az 5 000 ms automatikus előrehaladási beállítást.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750‑ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Ugyanazon időtartam alkalmazása minden diára**

Az egységes ritmus érdekében ugyanazt az effektust és pontos időtartamot alkalmazza minden diára. Ez a példa betölti az `input.pptx`‑et, a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑ból a Fade‑ot választja, és minden átmenetnek 750 milliszekundumos időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 milliszekundum után, letiltja a kattintásos előrehaladást, majd PPTX‑ként elmenti az eredményt.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Állítsa be az automatikus előrehaladást függetlenül az effektus időtartamától.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Különböző időtartamok beállítása egyedi diákhoz**

Különböző diák különböző effektus időtartamokat használhatnak. Például egy cím dia számára rövid átmenetet, egy szekció bevezető diára hosszabbat alkalmazhat. Ez a példa 500 ms‑t ad az első diához, és 1 200 ms‑t a másodikhoz. Használjon egy legalább két diát tartalmazó `input.pptx` fájlt.

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

### **Átmenetek összehangolása animált kimenettel**

Amikor [animated GIF](/slides/hu/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hu/python-net/export-to-html5/) vagy [video](/slides/hu/python-net/convert-powerpoint-to-video/) exportál, állítsa be a pontos átmeneti időtartamokat a kívánt tempóhoz. Például használjon 600 ms‑os fade‑et a jelenetek között, és külön módosítsa a diaidőzítést, hogy elegendő idő legyen a narrációnak vagy a tartalomnak.

GIF‑ és videó esetén egyeztesse a kimeneti képkockasebességet az effektus időtartamával: 600 ms‑nak megfelelő 18 képkocka 30 fps‑nél. HTML5‑ben engedélyezze az animált átmeneteket az export beállításokban. Ellenőrizze, hogy a kiválasztott exportformátum támogatja‑e a kívánt effektusokat és időzítési beállításokat, és tekintse meg a kimenetet a szinkronizáció ellenőrzéséhez.

### **Létező átmeneti időtartam kiolvasása**

Mielőtt módosítaná az átmenetet, olvassa ki a [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) értékét, hogy megállapítsa, tárolva van‑e explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam beállítva; egy nem negatív érték a tárolt időtartamot jelöli ezredmásodpercben. A nem beállított érték nem a lejátszási időtartam: az Aspose.Slides a transition type‑ból és a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)‑ből számolja ki. Egy átmenettípus beállítása inicializálhat egy időtartamot, ezért előbb ellenőrizze az eredeti beállításokat.

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

A Morph átmenet animálja a tárgyak változását egymást követő diákon. Egyszerű Morph effektus létrehozásához klónozzon egy diát, mozdítsa vagy méretezze át a tárgyat a klónon, és alkalmazza a Morph átmenetet a második diára. Ez az eredeti és a módosított állapotok közötti animációt biztosítja.

Az alábbi példa egy szövegtéglalapot tartalmazó diát hoz létre, klónozza, majd a klónon megváltoztatja a téglalap pozícióját és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/)‑ból a Morph‑ot választja a második diára. Nyissa meg a mentett fájlt egy Morph‑ot támogató megjelenítőben, hogy lássa a hatást a diavetítés során.

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

## **Morph átmenet típusok**

A [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) felsorolt értéke szabályozza, hogy a Morph hogyan illeszti és animálja a tartalmat:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) minden alakzatot egy egész objektumként kezel.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) a szöveget szavak alapján animálja, ahol lehetséges.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) a szöveget karakterek alapján animálja, ahol lehetséges.

Állítsa a transition [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét Morph‑ra, mielőtt elérné a [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/)‑t. A value ezután a [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) objektumot adja, amelynek a [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) tulajdonsága választja ki a match módot.

Ez a példa megnyitja az előző szekcióban létrehozott bemutatót, és a második diát szó‑alapú Morph animációra konfigurálja.

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

Néhány átmenet további opciókat tesz elérhetővé, például irányt vagy hogy az effektus fekete képernyővel induljon‑e. Az elérhető opciók az adott transition [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) függvényei. Előbb állítsa be a típust, majd használja a megfelelő transition objektumot a [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/)‑ból.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) beállítást a [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/)‑on keresztül állítja be, hogy az átmenet fekete képernyőből induljon.

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

## **FAQ**

**Szabályozhatom a diaátmenet lejátszási sebességét?**

Igen. Használja a [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) beállítást, ha pontos effektus időtartamot ezredmásodpercben szükséges megadni. Ha elegendő egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) kategória – SLOW, MEDIUM vagy FAST – és nincs explicit időtartam beállítva, használja a [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) beállítást. Ezek a beállítások függetlenül szabályozzák az átmenet effektust és az automatikus előrehaladási késleltetést.

**Csatolhatok hangot egy átmenethez, és ismételhetem?**

Igen. A beágyazott hangot a [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)‑ben adhatja meg, a [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/)‑t állítsa START_SOUND‑ra a [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) felsorolt értékek közül, és engedélyezze a [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)-t. A hang a következő hangeseményig ismétlődik a diavetítésben.

**Mi a leggyorsabb módja ugyanazon átmenet alkalmazásának minden diára?**

Iteráljon a bemutató [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) gyűjteményén, és állítsa minden dia transition [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét ugyanarra. A időzítési és effektus opciókat ugyanabban a ciklusban állítsa be, hogy a viselkedés minden dián konzisztens legyen.

**Hogyan ellenőrzhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Olvassa ki a [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) tulajdonságot a dia [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/)‑ból. Ez a [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) felsorolt értékét adja vissza; a NONE azt jelenti, hogy nincs alkalmazva átmeneti effektus.