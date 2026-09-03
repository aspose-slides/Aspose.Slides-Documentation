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
- haladó diaátmenet
- Morph átmenet
- átmenettípus
- átmeneti hatás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, konfigurálja az automatikus diaelőrehaladást, és testreszabja a Morph és egyéb átmeneti hatásokat az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

A diavetítési átmenetek szabályozzák, hogy a diák hogyan jelennek meg egy diavetítés során. Az Aspose.Slides for Python via .NET segítségével kiválaszthat egy átmenet hatást minden diához, beállíthatja a haladást egérkattintás vagy időzítő alapján, valamint módosíthatja az effektusra jellemző beállításokat. Ez a cikk Python példákat használ az átmenetek alkalmazására, a pontos átmeneti időtartamok beállítására, a dia időzítésének kezelésére, valamint egy Morph átmenet létrehozására két dia között. A példák azt is bemutatják, hogyan menthetők a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

Az átmenet alkalmazásához töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztállyal, és érje el a dia [slide_show_transition](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/slide_show_transition/) tulajdonságát. Állítsa be a [type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/type/) értékét a [TransitionType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/transitiontype/) felsorolás egy elemére, majd mentse a prezentációt.

A következő példa egy Circle átmenetet alkalmaz az első diára, és egy Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Haladó diaátmenet hozzáadása**

Beállíthatja, hogy a dia mennyi ideig marad a képernyőn, és hogy egérkattintás lépteti-e a diavetítést. A következő tulajdonságok szabályozzák ezt a viselkedést:

- [advance_on_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) lehetővé teszi a nézőnek, hogy egérkattintással lépjen előre.
- [advance_after](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) engedélyezi az automatikus léptetést.
- [advance_after_time](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) megadja az automatikus léptetés előtti késleltetést ezredmásodpercben.

Engedélyezze mind a kattintásos, mind az időzített léptetést, hogy a néző kattintással vagy a várakozással léphessen tovább. Ha csak az időzítőt szeretné használni, állítsa a [advance_on_click] értékét `False`-ra. A késleltetés határozza meg, mikor lép tovább a diavetítés; ez nem állítja be a vizuális átmenet hatás időtartamát.

Ez a példa különböző hatásokat rendel az első három diához, és automatikus léptetést engedélyez 3, 5 és 7 másodperc után, sorrendben. Egérkattintásokkal is léptethetők ezek a diák. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Az időzített léptetés engedélyezett állapotának ellenőrzéséhez olvassa ki a [advance_after] értékét. Egy tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus léptetést azoknál a diáknál, ahol a késleltetés több mint két másodperc. Engedélyezi a kattintást ezeknél a diáknál, majd elmenti a frissített beállításokat.

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

Használja a [duration](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/duration/) beállítást egy átmeneti hatás pontos hosszának ezredmásodpercben való megadásához. A dia [slide_show_transition](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/slide_show_transition/) tulajdonsága ezeket a beállításokat a [SlideShowTransition](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/) révén teszi elérhetővé:

| Tulajdonság | Cél |
| --- | --- |
| [duration](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Beállítja az átmeneti hatás önmagának időtartamát ezredmásodpercben. |
| [advance_after_time](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Beállítja a diák automatikus léptetése előtti késleltetést ezredmásodpercben. Engedélyezze a [advance_after] értéket a timer aktiválásához. |
| [speed](https://reference.aspose.com/slides/hu/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Kiválaszt egy előre meghatározott sebességkategóriát a [TransitionSpeed] felsorolásból: SLOW, MEDIUM vagy FAST. Akkor használják, ha nincs megadva pontos időtartam. |

A [duration] csak az átmenet hatását vezérli; nem határozza meg, mennyi ideig marad látható a dia. Az automatikus léptetés késleltetését külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a hatás időtartamát a átmenet típusából és a [speed] értékből határozza meg.

### **Azonos időtartam alkalmazása minden diára**

A konzisztens tempó érdekében alkalmazzon minden diára ugyanazt a hatást és pontos időtartamot. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType]‑ből a Fade‑et választja, és minden átmenetnek 750 ezredmásodperc időtartamot ad. Ezen felül engedélyezi az automatikus léptetést 5 000 ezredmásodperc után, és letiltja a kattintásos léptetést, majd PPTX‑ként menti az eredményt.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Állítsa be az automatikus léptetést a hatás időtartamától függetlenül.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Különböző időtartamok beállítása egyes diákhoz**

Különböző diák különböző hatásidőket használhatnak. Például egy rövid átmenetet a cím-diára, és egy hosszabbat a szekcióbevezető diára. Ez a példa 500 ezredmásodpercet állít be az első diára, és 1 200 ezredmásodpercet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

A [animated GIF](/slides/hu/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hu/python-net/export-to-html5/), vagy [video](/slides/hu/python-net/convert-powerpoint-to-video/) elkészítésekor állítsa be a pontos átmeneti időtartamokat az exportálás előtt, hogy megfeleljenek az kívánt tempónak. Például használjon 600 ezredmásodperces halványítást a jelenetek között, és külön beállítsa minden dia előrehaladási késleltetését, hogy elegendő idő legyen a narráció vagy tartalom számára.

GIF és videó esetén az eredmény frame rate‑jét koherálja a hatás időtartamával: 600 ezredmásodperc 30 fps‑nél 18 képkockának felel meg. HTML5‑ben engedélyezze az animált átmeneteket az export beállításokban. Ellenőrizze a választott export formátum által támogatott hatásokat és időzítési lehetőségeket, majd tekintse meg az eredményt a szinkronizáció megerősítéséhez.

### **Meglévő átmeneti időtartam kiolvasása**

Olvassa ki a [duration] értéket az átmenet módosítása előtt, hogy meghatározza, tárolva van-e explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam beállítva; egy nemnegatív érték a tárolt időtartamot ezredmásodpercben jelzi. A be nem állított érték nem a számított lejátszási időtartam: az Aspose.Slides a átmenet típusát és a [speed] értéket használja az időtartam meghatározásához. Egy átmenet típus beállítása inicializálhat egy időtartamot, ezért először ellenőrizze az eredeti beállításokat.

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

A Morph átmenet animálja az egymást követő diákon lévő objektumok közötti változásokat. Egy egyszerű Morph effektus létrehozásához klónozza a diát, mozgassa vagy átméretezze az objektumot a klónon, majd alkalmazza a Morph átmenetet a második diára. Ez lehetővé teszi, hogy az átmenet a megfelelő objektumok eredeti és módosított állapota között animáljon.

A következő példa egy szöveges téglalappal rendelkező diát hoz létre, klónozza a diát, és a klónon megváltoztatja a téglalap pozícióját és méretét. Ezután a [TransitionType] felsorolásból a Morph‑ot választja a második diára. Nyissa meg a mentett fájlt egy olyan prezentáció megjelenítőben, amely támogatja a Morph‑ot, hogy lássa a hatást a diavetítés során.

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

## **Morph átmenet típusai**

A [TransitionMorphType] felsorolás szabályozza, hogy a Morph hogyan párosítja és animálja a tartalmat:

- [BY_OBJECT] minden alakzatot egy egész objektumként kezel.
- [BY_WORD] a szöveget szavak egyeztetésével animálja, ahol lehetséges.
- [BY_CHAR] a szöveget karakterek egyeztetésével animálja, ahol lehetséges.

Állítsa be a [type] átmenetet Morph‑ra, mielőtt elérné a [value] tulajdonságot. Az érték ezután a [MorphTransition] objektumot adja vissza, amelynek a [morph_type] tulajdonsága választja ki a párosítási módot.

Ez a példa megnyitja az előző részben létrehozott prezentációt, és beállítja a második diát, hogy szó-alapú Morph animációt használjon.

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

## **Átmeneti hatások beállítása**

Néhány átmenet további beállítási lehetőségeket tár fel, például az irányt vagy azt, hogy a hatás fekete képernyőről indul‑e. Az elérhető opciók a kiválasztott átmenet [type] értékétől függnek. Először állítsa be a típust, majd használja a megfelelő átmenet objektumot a [value]‑ból.

A következő példa a `input.pptx` első diájára egy Cut átmenetet alkalmaz. A [from_black] beállítást az [OptionalBlackTransition] használatával állítja be, hogy a átmenet fekete képernyőről induljon.

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

**Vezérelhetem a diaátmenet lejátszási sebességét?**

Igen. Használja a [duration] beállítást, ha pontos hatásidőt ezredmásodpercben kell megadni. Használja a [speed] beállítást, ha egy előre meghatározott [TransitionSpeed] kategória — SLOW, MEDIUM vagy FAST — elegendő, és nincs explicit időtartam beállítva. Ezek a beállítások az átmeneti hatást szabályozzák az automatikus léptetési késleltetéstől függetlenül.

**Csatolhatok hangot egy átmenethez, és hurkolhatom?**

Igen. A beágyazott hangot a [sound] tulajdonsághoz rendelheti, a [sound_mode] értéket a [TransitionSoundMode] felsorolásból START_SOUND‑ra állíthatja, és engedélyezheti a [sound_loop] beállítást. A hang a diavetítés következő hangeseményéig ismétlődik.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden diára?**

Iteráljon a prezentáció [slides] gyűjteményén, és állítsa be minden dia átmenet [type] értékét ugyanarra az értékre. Állítsa be a timing és hatás beállításokat ugyanabban a ciklusban, hogy a viselkedés minden dián egységes legyen.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Olvassa ki a [type] tulajdonságot a dia [slide_show_transition] értékéből. Ez egy értéket ad vissza a [TransitionType] felsorolásból; a NONE azt jelenti, hogy nincs alkalmazva átmeneti hatás.