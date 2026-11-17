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
- átmenet típusa
- átmenet hatása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, konfigurálja az automatikus dia előrehaladást, és testreszabhatja a Morph és egyéb átmeneti effektusokat az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for Python via Java segítségével kiválaszthat egy átmeneti effektet minden diára, beállíthatja a haladást egérkattintással vagy időzítővel, és módosíthatja az effektusra jellemző opciókat. Ez a cikk Python példákat használ átmenetek alkalmazásához, pontos átmeneti időtartamok beállításához, a diák időzítésének kezeléséhez, valamint egy Morph átmenet létrehozásához két dia között. A példák azt is bemutatják, hogyan menthetőek a beállítások PPTX fájlba.

## **Diaátmenet hozzáadása**

A diaátmenet alkalmazásához töltsön be egy prezentációt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztállyal, és érje el a dia átmenet beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) segítségével. Használja a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) metódust a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) felsorolás egy értékével, majd mentse a prezentációt.

Az alábbi példa egy Circle átmenetet alkalmaz az első diára, és egy Comb átmenetet a másodikra. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

## **Kerék átmenet**

Használja a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) metódust a Wheel kiválasztásához a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) felsorolásból. Ezután hívja a [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) metódust a [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) beállításainak eléréséhez. Ennek a [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) metódusának segítségével állítható, hány radiális szektor fedje fel a cél diát.

A példa két azonos diapárt hoz létre. Minden pár egy fekete diával kezdődik, és egy teljes diát kitöltő arany téglalappal ér véget. Mindkét cél dia ugyanazzal a lassú sebességgel rendelkezik, amelyet a [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) állít be, és ugyanazzal a 8 000 ms explicit időtartammal, amelyet a [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) állít be. Csak a szektorok száma változik.

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

Nyissa meg a `wheel-transitions.pptx` fájlt a PowerPointban, és indítsa el a diavetítést. Haladjon az 1‑es diáról a 2‑es diára, hogy egy óramutató járásával megegyező körív fedje fel az arany téglalapot. Ezután haladjon a 3‑as diáról a 4‑es diára, hogy nyolc radiális szektor fedje fel egyszerre ugyanazt a téglalapot.

## **Fejlett diaátmenet hozzáadása**

Konfigurálhatja, mennyi ideig marad a dia a képernyőn, és hogy egérkattintás-e vagy időzítő hozza-e előre a diavetítést. A következő metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) lehetővé teszi a néző számára, hogy az egérkattintással továbbhaladjon.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) engedélyezi az automatikus előrehaladást.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) határozza meg az automatikus előrehaladás előtti késleltetést ezredmásodpercben.

Engedélyezze mind a kattintást, mind az időzített előrehaladást, hogy a néző kattintással vagy a várakozással léphessen tovább. Ha csak az időzítőt szeretné használni, adja át a `False` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metódusnak. A késleltetés azt szabályozza, mikor halad előre a diavetítés; nem határozza meg a vizuális átmeneti effektus időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus előrehaladást engedélyez 3, 5 és 7 másodperc után, rendre. Egérkattintással is előre lehet lépni ezeken a diákon. Használjon egy `input.pptx` fájlt, amely legalább három diát tartalmaz.

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

Annak ellenőrzéséhez, hogy az időzített előrehaladás engedélyezve van-e, hívja a [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metódust. A tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus előrehaladást azoknál a diáknál, amelyeknél a késleltetés nagyobb mint két másodperc. Ezeknél a diáknál engedélyezi az egérkattintást, majd menti a frissített beállításokat.

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

## **Az átmenet időzítésének pontos vezérlése**

Használja a [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) metódust egy átmeneti effektus pontos hosszának ezredmásodpercben történő megadásához. A dia [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) metódusa ezeket a beállításokat a [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) osztályon keresztül teszi elérhetővé:

| Módszer | Cél |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Beállítja az átmeneti effektus tényleges időtartamát ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Beállítja a diák automatikus előrehaladása előtti késleltetést ezredmásodpercben. Pass `True` to [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) to activate this timer. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) csak az átmeneti effektust irányítja; nem határozza meg, mennyi ideig látható a dia. Az automatikus előrehaladási késleltetést külön kell konfigurálni. Ha nincs explicit időtartam beállítva, az Aspose.Slides a transition type és a [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) érték alapján határozza meg az effektus időtartamát.

<!-- visual-explanation:slide-transition:start -->
[![A különálló sávok a 750‑ms‑es átmeneti időtartamot és az 5 000‑ms‑es automatikus előrehaladási beállítást mutatják.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*A megosztott példa minden diára 750 ms‑es Fade átmenetet ad, és külön engedélyezi az automatikus előrehaladást 5 000 ms‑nél. Az átmeneti időtartam az effektust, az előrehaladás pedig azt szabályozza, hogy mikor lépjünk a következő diára. Ezek a sávok szimbolikus beállítások, nem egy mérő kombinált idővonal.*
<!-- visual-explanation:slide-transition:end -->

### **Azonos időtartam alkalmazása minden diára**

Az egységes ütemezés érdekében alkalmazza ugyanazt az effektust és pontos időtartamot minden diára. Ez a példa betölti a `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) felsorolásból a Fade‑t választja, és minden átmenetnek 750 ms‑es időtartamot ad. Külön engedélyezi az automatikus előrehaladást 5 000 ms után, letiltja az egérkattintást, majd menti az eredményt PPTX‑ként.

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

        # Az automatikus előrehaladást állítsa be függetlenül az effektus időtartamától.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Különböző időtartamok beállítása egyedi diákhoz**

Külön diák különböző effektus időtartamot használhatnak. Például egy cím dián rövid átmenetet, egy szekció bevezetőjénél hosszabb átmenetet alkalmazhat. Ez a példa az első diára 500 ms‑et, a másodikra 1 200 ms‑et állít be. Használjon egy `input.pptx` fájlt, amely legalább két diát tartalmaz.

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

### **Átmenetek koordinálása animált kimenettel**

Ha [animated GIF](/slides/hu/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hu/python-java/export-to-html5/) vagy [video](/slides/hu/python-java/convert-powerpoint-to-video/) készül, állítsa be a pontos átmeneti időtartamokat az exportálás előtt, hogy megfeleljenek a kívánt ütemezésnek. Például használjon 600 ms‑es fade‑et a jelenetek között, és állítsa be minden dia előrehaladási késleltetését külön-külön, hogy elegendő legyen a narráció vagy a tartalom számára.

A GIF és videó esetében szinkronizálja a kimeneti képkocka‑sebességet az effektus időtartamával: 600 ms 18 képkocka 30 fps‑nél. HTML5‑ben engedélyezze az animált átmeneteket az export beállításaiban. Ellenőrizze az adott export formátum támogatott effektusait és időzítési opcióit, és tekintse meg az eredményt a szinkronizáció ellenőrzéséhez.

### **Meglévő átmeneti időtartam beolvasása**

Hívja a [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) metódust az átmenet módosítása előtt, hogy megállapítsa, tárolt‑e explicit érték. A `-1` érték azt jelenti, hogy nincs explicit időtartam beállítva; egy nem negatív érték a tárolt ezredmásodperces időtartamot adja meg. A nem beállított érték nem a számított lejátszási időtartam: az Aspose.Slides a transition type és a [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) érték alapján határozza meg azt. Egy átmenet típus beállítása inicializálhat időtartamot, ezért először vizsgálja meg az eredeti beállításokat.

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

A Morph átmenet animálja az objektumok változását egymást követő diákon. Egy egyszerű Morph effektus létrehozásához klónozzon egy diát, mozdítsa vagy méretezze át egy objektumot a klónon, és alkalmazza a Morph átmenetet a második diára. Így az átmenet az eredeti és a módosított állapot között animálja a megfelelő objektumokat.

Az alábbi példa egy szöveges téglalappal rendelkező diát hoz létre, klónozza azt, majd a klónon megváltoztatja a téglalap pozícióját és méretét. Ezután a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) felsorolásból a Morph‑ot választja a második diához. Nyissa meg a mentett fájlt egy olyan prezentációs megjelenítőben, amely támogatja a Morph‑ot, hogy lássa az effektust diavetítés közben.

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

## **Morph átmenet típusok**

A [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogyan illeszkedik és animálja a Morph a tartalmat:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) az egyes alakzatokat egész objektumként kezeli.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) a szöveget szavak egyezésével animálja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) a szöveget karakterek egyezésével animálja, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) metódust a Morph kiválasztásához, mielőtt hozzáférne a [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) metódushoz. Ekkor a visszatérési érték a [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) osztály egy példánya, amelynek a [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) metódusa választja ki a megfelelő módot.

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

## **Átmeneti effektek beállítása**

Néhány átmenet további opciókat is kínál, például irányt vagy azt, hogy az effektus fekete képernyőről induljon-e. A rendelkezésre álló opciók a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) által kiválasztott átmenettől függnek. Állítsa be először a típust, majd a [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) megfelelő osztályával használja a kapcsolódó beállításokat.

Az alábbi példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) osztály [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) metódusával állítja be, hogy az átmenet fekete képernyőről induljon.

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

**Kezelhetem a diaátmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) metódust, ha pontos effektus-időtartamot szeretne meghatározni ezredmásodpercben. Használja a [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) kategória (Slow, Medium vagy Fast) elegendő, és nincs explicit időtartam beállítva. Ezek a beállítások az átmeneti effektust irányítják, függetlenül az automatikus előrehaladási késleltetéstől.

**Csatolhatok hangot egy átmenethez, és hagyhatom, hogy ismétlődjön?**

Igen. Az [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) metódussal adhat hozzá beágyazott hangot, a [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) felsorolásból a StartSound értéket adja át az [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) metódusnak, és a [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) metódussal `True` értéket állít be. A hang a következő hangeseményig a diavetítésben ismétlődik.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzuk minden diára?**

Iteráljon a prezentáció [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) gyűjteményén, és minden dia átmenetéhez hívja a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) metódust azonos értékkel. A felhasználható időzítési és effektus beállításokat ugyanabban a ciklusban állítsa be, hogy a viselkedés minden dián konzisztens maradjon.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Hívja a [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) eredményén. Ez a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) felsorolásból egy értéket ad vissza; a None_ azt jelenti, hogy nincs átmeneti effektus alkalmazva.