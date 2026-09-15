---
title: Diaátmenetek kezelése prezentációkban Python via Java segítségével
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/python-java/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- fejlett diaátmenet
- Morph átmenet
- átmenettípus
- átmeneti hatás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, állítson be automatikus dia előrehaladást, és testreszabja a Morph és egyéb átmeneti hatásokat az Aspose.Slides for Python via Java használatával."
---
## **Áttekintés**

A diavetítés átmenetek szabályozzák, hogyan jelennek meg a diák egy diavetítés során. Az Aspose.Slides for Python via Java segítségével minden diára kiválaszthat egy átmenet‑effektust, beállíthatja a léptetést egérkattintással vagy időzítéssel, és módosíthatja az effektusra jellemző beállításokat. Ez a cikk Python példákat használ az átmenetek alkalmazására, pontos átmenet‑idők beállítására, a diák időzítésének kezelésére, valamint egy Morph átmenet létrehozására két dia között. A példák azt is bemutatják, hogyan menthetőek a beállítások PPTX fájlba.

## **Átmenet hozzáadása diához**

Átmenet alkalmazásához töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztállyal, és érje el a dia átmeneti beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getSlideShowTransition) segítségével. Használja a [setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setType) metódust a [TransitionType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitiontype/) enumeráció egy értékével, majd mentse a bemutatót.

Az alábbi példa Circle átmenetet alkalmaz az első diára és Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Speciális átmenet hozzáadása diához**

Beállíthatja, hogy a dia mennyi ideig maradjon a képernyőn, és hogy egérkattintás lépteti‑e a diavetítést. A következő metódusok vezérlik ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) lehetővé teszi a nézőnek, hogy egérkattintással lépjen tovább.
- [setAdvanceAfter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) automatikus előrehaladást tesz lehetővé.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) a késleltetést adja meg milliszekundumban az automatikus előrehaladás előtt.

Engedélyezze mind a kattintást, mind az időzített előrehaladást, így a néző kattintással vagy a várakozással léphet tovább. Ha csak az időzítőt szeretné használni, adjon át `False` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metódusnak. A késleltetés azt szabályozza, mikor lép tovább a diavetítés; nem a vizuális átmenet időtartamát állítja be.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus előrehaladást állít be 3, 5 és 7 másodperc után. Egérkattintással is léptethetők ezek a diák. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Az időzített előrehaladás engedélyezésének ellenőrzéséhez hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metódust. A tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fenti példában mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást a két másodpercnél nagyobb késleltetésű diák esetén. Ezekhez a diákhoz engedélyezi az egérkattintást, majd elmenti a módosított beállításokat.

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

## **Az átmenet időzítésének pontos szabályozása**

Használja a [setDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setDuration) metódust az átmenet‑effektus pontos hossza milliszekundumban történő megadásához. A dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getSlideShowTransition) metódusa ezekkel a beállításokkal rendelkezik a [SlideShowTransition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/) osztályon keresztül:

| Metódus | Cél |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setDuration) | Beállítja magának az átmenet‑effektusnak az időtartamát milliszekundumban. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Beállítja az automatikus előrehaladás előtti késleltetést milliszekundumban. A [setAdvanceAfter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) meghívásával aktiválható ez az időzítő. |
| [setSpeed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setSpeed) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitionspeed/) enumerációból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [setDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setDuration) csak az átmenet‑effektust befolyásolja; nem határozza meg, mennyi ideig marad a dia látható. Az automatikus előrehaladás késleltetését külön kell beállítani. Ha nincs kifejezett időtartam megadva, az Aspose.Slides a átmenet típusa és a [getSpeed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#getSpeed) értéke alapján határozza meg az effektus időtartamát.

### **Azonos időtartam alkalmazása minden diára**

A konzisztens tempó érdekében alkalmazzon ugyanazt az effektust és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, kiválasztja a Fade átmenetet a [TransitionType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitiontype/) enumerációból, és minden átmenetnek 750 milliszekundumos időt állít be. Külön engedélyezi az automatikus előrehaladást 5 000 milliszekundum után, letiltja az egérkattintásos léptetést, majd az eredményt PPTX‑ként menti.

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

        # Konfigurálja az automatikus előrehaladást az effektus időtartamától függetlenül.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Eltérő időtartamok beállítása egyedi diákhoz**

Különböző diák különböző effektus‑időket használhatnak. Például a címdiára rövid átmenetet, a szekcióbevezetőre hosszabbat alkalmazhat. Ez a példa 500 milliszekundumot állít be az első diára, és 1 200 milliszekundumot a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Átmenetek összehangolása animált kimenettel**

Amikor [animált GIF](/slides/hu/python-java/convert-powerpoint-to-animated-gif/), [HTML5 prezentáció](/slides/hu/python-java/export-to-html5/) vagy [videó](/slides/hu/python-java/convert-powerpoint-to-video/) exportál, állítsa be a pontos átmenet‑időket a kimenet előtt, hogy az ütem a kívánt legyen. Például használjon 600 milliszekundumos fade‑ot a jelenetek között, és külön állítsa be minden dia előrehaladási késleltetését a narráció vagy a tartalom időtartamának megfelelően.

GIF‑nél és videónál a kimeneti képkockasebességet hangolja az effektus időtartamához: 600 milliszekundum 30 fps‑nél 18 képkockának felel meg. HTML5‑ben engedélyezze az animált átmeneteket az exportbeállításokban. Ellenőrizze a kiválasztott exportformátum által támogatott effektusokat és időzítési lehetőségeket, és tekintse meg az előnézetet a szinkronizáció ellenőrzéséhez.

### **Meglévő átmenet‑idő kiolvasása**

Módosítás előtt hívja meg a [getDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#getDuration) metódust, hogy megállapítsa, van‑e tárolt explicite érték. A `-1` érték azt jelenti, hogy nincs megadva explicit időtartam; egy nem negatív érték a tárolt időt milliszekundumban adja vissza. A nem beállított érték nem a lejátszási idő, mivel az Aspose.Slides a TransitionType‑ból és a [getSpeed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#getSpeed) értékéből számolja ki. Egy átmenettípus beállítása inicializálhat egy időtartamot, ezért először ellenőrizze az eredeti beállításokat.

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

## **Morph átmenet**

A Morph átmenet animálja a változásokat az egymást követő diák objektumai között. Egy egyszerű Morph effektus létrehozásához klónozzon egy diát, mozdítsa vagy méretezze át az objektumot a klónon, és alkalmazza a Morph átmenetet a második diára. Így a megfelelő objektumok animálódnak az eredeti és a módosított állapotuk között.

Az alábbi példa egy szövegdobozt tartalmazó diát hoz létre, klónozza a diát, majd a klónon módosítja a téglalap pozícióját és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitiontype/) enumerációból a Morph‑ot választja ki a második diára. Nyissa meg a mentett fájlt egy Morph‑ot támogató prezentációs nézőben, hogy lássa a hatást egy diavetítés során.

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

## **Morph átmenet típusai**

A [TransitionMorphType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitionmorphtype/) enumeráció szabályozza, hogy a Morph hogyan párosítja és animálja a tartalmat:

- [ByObject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egész objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitionmorphtype/#ByWord) a szöveget szavak szerint párosítja, ha lehetséges.
- [ByChar](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitionmorphtype/#ByChar) a szöveget karakterek szerint párosítja, ha lehetséges.

Használja a [setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setType) metódust a Morph kiválasztásához, mielőtt a [getValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#getValue) metódust meghívná. A visszakapott érték ekkor egy [MorphTransition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/morphtransition/) osztálypéldány, amelynek a [setMorphType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/morphtransition/#setMorphType) metódusa a párosítási módot választja ki.

Ez a példa megnyitja az előző szakaszban létrehozott prezentációt, és a második diát szó‑alapú Morph animációra konfigurálja.

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

## **Átmeneti effektusok beállítása**

Néhány átmenet további opciókat is felkínál, például irányt vagy azt, hogy a hatás fekete képernyőből indul-e. A rendelkezésre álló opciók a [setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setType) által kiválasztott átmenettől függenek. Először állítsa be a típust, majd a megfelelő osztályt a [getValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#getValue) segítségével.

Az alábbi példa egy Cut átmenetet alkalmaz a `input.pptx` első diájára. A [setFromBlack](https://reference.aspose.com/slides/hu/python-java/aspose.slides/optionalblacktransition/#setFromBlack) metódust az [OptionalBlackTransition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/optionalblacktransition/) osztályon keresztül hívja meg, hogy a tranzíció fekete képernyőből induljon.

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

## **GYIK**

**Kezelhetem a diák átmeneteinek lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setDuration) metódust, ha pontos effektus‑időt szeretne megadni milliszekundumban. Használja a [setSpeed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setSpeed) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicite beállítva időtartam. Ezek a beállítások csak az átmenet‑effektust szabályozzák, függetlenül az automatikus előrehaladási késleltetéstől.

**Csatolhatok hangot az átmenethez, és hagyhatom, hogy ismétlődjön?**

Igen. A beágyazott hangot a [setSound](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setSound) metódussal adhatja hozzá, a [TransitionSoundMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitionsoundmode/) enumerációból a StartSound‑t a [setSoundMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setSoundMode) metódusnak adja át, és a [setSoundLoop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setSoundLoop) metódussal `True` értéket állít be. A hang addig ismétlődik, amíg a diavetítésben nem következik egy új hangesemény.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden diára?**

Iterálja végig a prezentáció [getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) gyűjteményét, és minden dia átmenetére hívja meg a [setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#setType) metódust ugyanazzal az értékkel. Az időzítési és effektus‑opciókat ugyanabban a ciklusban állítsa be, hogy a viselkedés minden dián konzisztens legyen.

**Hogyan tudom ellenőrizni, hogy jelenleg milyen átmenet van beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowtransition/#getType) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getSlideShowTransition) eredményén. Ez egy értéket ad vissza a [TransitionType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/transitiontype/) enumerációból; a None_ azt jelenti, hogy nincs alkalmazva átmenet‑effektus.