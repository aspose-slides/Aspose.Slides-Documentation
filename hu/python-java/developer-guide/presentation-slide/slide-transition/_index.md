---
title: Diaátmenetek kezelése prezentációkban Pythonon keresztül Java-val
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
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazzon diaátmeneteket, konfigurálja az automatikus dia előrelépést, és testreszabja a Morph és egyéb átmeneti effektusokat az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

A diaátmenetek szabályozzák, hogyan jelennek meg a diák a diavetítés során. Az Aspose.Slides for Python via Java segítségével minden dia esetén kiválaszthat egy átmeneti effektet, beállíthatja a léptetést egérkattintással vagy időzítővel, valamint testreszabhatja az effektusra jellemző beállításokat. Ez a cikk Python példákkal mutatja be az átmenetek alkalmazását, a pontos átmeneti időtartam beállítását, a dia időzítésének kezelését, valamint egy Morph átmenet létrehozását két dia között. A példák azt is bemutatják, hogyan mentse el a beállításokat PPTX fájlba.

## **Diaátmenet hozzáadása**

Ahhoz, hogy átmenetet alkalmazzunk, töltsünk be egy bemutatót a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztállyal, és érjük el a dia átmenet beállításait a [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) segítségével. Használjuk a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) metódust a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) felsorolt értékei közül, majd mentsük el a bemutatót.

A következő példa egy Circle átmenetet alkalmaz az első diára, és egy Comb átmenetet a másodikra. Használjunk egy `input.pptx` fájlt, amelyben legalább két dia található.

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

## **Kerékátmenet**

Használjuk a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) metódust a Wheel kiválasztásához a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) listáról. Ezután hívjuk meg a [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) metódust a [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) beállításainak eléréséhez. A [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) metódus szabályozza, hány radiális szektor fedje le a cél diát.

A példa két azonos diapárt hoz létre. Minden pár egy fekete diával kezdődik, és egy teljesen sárga téglalappal zárul. Mindkét cél dia ugyanazt a lassú sebességet használja, amelyet a [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) metódussal állítunk be, és ugyanazt a 8 000 ms explicit időtartamot a [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) metódussal. Csak a szektorok száma változik.

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

Nyissa meg a `wheel-transitions.pptx` fájlt a PowerPointban, és indítsa el a diavetítést. Lépjen tovább az 1. diáról a 2. diára, hogy egy óramutató-irányú mozdulattal megjelenjen a sárga téglalap. Ezután lépjen a 3. diáról a 4. diára, hogy nyolc radiális szektor egyszerre fedje le ugyanazt a téglalapot.

## **Fade Through Black a Reveal átmenettel**

Állítsuk be a cél dia átmenet típusát Reveal-re, majd hívjuk meg a [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) metódust a [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/) beállításain. A példa egy türkiz forrás diát és egy korall cél diát hoz létre, majd mindkettőt klónozza. Minden pár ugyanazt a kétszekundumos Reveal átmenetet használja. Csak a második pár áthalad feketének.

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

Nyissa meg a `reveal-transitions.pptx` fájlt a PowerPointban, és indítsa el a diavetítést. Lépjen tovább az 1. diáról a 2. diára, hogy a türkiz közvetlenül a korall színre olvadjon. Ezután lépjen a 3. diáról a 4. diára. A képernyő röviden majdnem fekete lesz, mielőtt a korall dia megjelenik. Mindkét dia megőrzi az eredeti háttérszínét.

Az alábbi sorok félig másodperces intervallumban mutatnak képkockákat a PowerPointból. Hasonlítsa össze minden sor középső képkockáját a hatás megértéséhez.

![PowerPoint lejátszás alt fekete átmenet letiltva (felül) és engedélyezve (alul). Csak az alsó sor halad át a közel feketéig.](reveal-through-black.png)

## **Haladó diaátmenet hozzáadása**

Beállíthatja, hogy egy dia mennyi ideig maradjon a képernyőn, és hogy egérkattintás léptesse-e a diavetítést. A következő metódusok szabályozzák ezt a viselkedést:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) lehetővé teszi a néző számára, hogy egérkattintással léptessen.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) engedélyezi az automatikus léptetést.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) megadja az automatikus léptetés késleltetését ezredmásodpercben.

Engedélyezze mind a kattintást, mind az időzített léptetést, hogy a néző kattintással vagy a időzítő lejárásával léphessen tovább. Ha csak az időzítőt szeretné használni, adja át a `False` értéket a [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) metódusnak. A késleltetés szabályozza, mikor lép tovább a diavetítés; nem állítja be a vizuális átmenet effektus időtartamát.

Ez a példa különböző effektusokat rendel az első három diához, és automatikus léptetést állít be 3, 5 és 7 másodperccel. Egérkattintással is léptethetők ezek a diák. Használjon egy `input.pptx` fájlt, amelyben legalább három dia van.

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

Az automatikus léptetés engedélyezettségének ellenőrzéséhez hívja meg a [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metódust. Egy tárolt késleltetés önmagában nem jelzi, hogy az időzítő aktív.

A következő példa megnyitja a fent mentett fájlt, jelentést készít minden engedélyezett időzítőről, és letiltja az automatikus léptetést azoknál a diáknál, ahol a késleltetés nagyobb, mint két másodperc. Ezeknél a diáknál engedélyezi az egérkattintást, majd elmenti a módosított beállításokat.

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

Használja a [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) metódust a átmeneti effektus pontos hosszak megadásához ezredmásodpercben. A dia [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) metódusa ezeket a beállításokat a [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) osztályon keresztül teszi elérhetővé:

| Módszer | Cél |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Beállítja magának az átmeneti effektusnak az időtartamát ezredmásodpercben. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Beállítja a késleltetést, mielőtt a dia automatikusan tovább lépne, ezredmásodpercben. A [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) `True` értékével aktiválja az időzítőt. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Kiválaszt egy előre definiált sebességkategóriát a [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) felsorolásból: Slow, Medium vagy Fast. Akkor használatos, ha nincs megadva pontos időtartam. |

A [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) csak az átmeneti effektust szabályozza; nem határozza meg, mennyi ideig látható a dia. Az automatikus léptetés késleltetését külön kell beállítani. Ha nincs explicit időtartam megadva, az Aspose.Slides a átmenet típusából és a [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) értékéből számítja ki az effektus hosszát.

<!-- visual-explanation:slide-transition:start -->
[![Külön sávok mutatják a 750 ms átmeneti időtartamot és az 5 000 ms automatikus léptetés beállítást.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Az ebben a példában szereplő diák mindegyikén 750 ms Fade átmenet van, és külön aktiválva van az automatikus léptetés 5 000 ms-re. Az átmenet időtartama az effektust szabályozza; a léptetés azt határozza meg, mikor hagyjuk el a diát. Ezek a sávok vázlatos beállítások, nem egy mért összesített idővonal.* 
<!-- visual-explanation:slide-transition:end -->

### **Azonos időtartam alkalmazása minden diára**

A konzisztens tempó érdekében alkalmazzon ugyanazt az effektust és ugyanazt a pontos időtartamot minden diára. Ez a példa betölti az `input.pptx` fájlt, a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) listáról a Fade-et választja, és minden átmenetnek 750 ms időtartamot ad. Külön engedélyezi az automatikus léptetést 5 000 ms után, és letiltja a kattintással történő léptetést, majd elmenti az eredményt PPTX formátumban.

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

        # Az automatikus előrelépést állítsa be az effektus időtartamától függetlenül.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Különböző időtartamok beállítása egyedi diákra**

Különböző diák használhatnak eltérő effektusidőket. Például egy cím dián rövid átmenet, míg egy szekció bevezetőjén hosszabb átmenet használható. Ez a példa 500 ms időtartamot állít be az első diára, és 1 200 ms-t a másodikra. Használjon egy `input.pptx` fájlt, amelyben legalább két dia van.

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

Animált GIF ([animated GIF](/slides/hu/python-java/convert-powerpoint-to-animated-gif/)), HTML5 prezentáció ([HTML5 presentation](/slides/hu/python-java/export-to-html5/)) vagy videó ([video](/slides/hu/python-java/convert-powerpoint-to-video/)) exportálása előtt állítsa be a pontos átmeneti időtartamokat a kívánt tempóhoz. Például 600 ms-os fade‑t használjon a jelenetek között, és külön szabályozza minden dia léptetési késleltetését, hogy elegendő idő legyen a narrációnak vagy a tartalomnak.

GIF és videó esetén az kimeneti képkockasebességet illessze az effektus időtartamához: 600 ms 30 fps-nél 18 képkockának felel meg. HTML5 esetén engedélyezze az animált átmeneteket az export beállításaiban. Ellenőrizze a választott export formátum által támogatott effektusokat és időzítési lehetőségeket, és tekintse meg az előnézetet a szinkronizáció megerősítéséhez.

### **Létező átmeneti időtartam beolvasása**

A [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) hívása előtt ellenőrizze, hogy egy explicit érték van‑e tárolva. A `-1` érték azt jelenti, hogy nincs explicit időtartam beállítva; a nem negatív érték a tárolt ezredmásodperces időtartamot adja vissza. A nem beállított érték nem a számított lejátszási idő: az Aspose.Slides a tranzíció típusából és a [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) értékéből számítja ki ezt az időt. Egy átmenet típus beállítása inicializálhat egy időtartamot, ezért először vizsgálja meg az eredeti beállításokat.

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

A Morph átmenet animálja a változásokat a szomszédos diák objektumai között. Egyszerű Morph hatás létrehozásához klónozzunk egy diát, mozdítsuk vagy méretezzük át egy objektumot a klónon, majd alkalmazzuk a Morph átmenetet a második diára. Így az átmenet az eredeti és a módosított állapotok közötti megfelelő objektumokat animálja.

A következő példa egy szöveges téglalapot tartalmazó diát hoz létre, klónozza a diát, majd módosítja a téglalap helyzetét és méretét a klónon. Ezután a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) felsorolásból a Morph-ot választja a második diára. Nyissa meg a mentett fájlt egy Morph‑ot támogató prezentációs nézőben, hogy a diavetítés során lássa a hatást.

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

A [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) felsorolás szabályozza, hogyan párosítja és animálja a Morph a tartalmat:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) minden alakzatot egy teljes objektumként kezel.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) a szöveget szavak alapján animálja, ahol lehetséges.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) a szöveget karakterek alapján animálja, ahol lehetséges.

Használja a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) metódust a Morph kiválasztásához, majd hívja meg a [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) metódust. Az érték ekkor a [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) osztály példánya, amelynek a [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) metódusa választja ki a párosítási módot.

Ez a példa megnyitja az előző részben létrehozott prezentációt, és a második diát szó-alapú Morph animációra állítja.

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

Néhány átmenet további opciókat tesz elérhetővé, például irányt vagy azt, hogy az effektus fekete képernyővel induljon-e. Az elérhető opciók a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) által kiválasztott átmenettől függenek. Először állítsa be a típust, majd használja a megfelelő osztályt a [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) eredményéből.

A következő példa egy Cut átmenetet alkalmaz az `input.pptx` első diájára. A [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) osztályon keresztül hívja meg a [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) metódust, hogy az átmenet fekete képernyőről induljon.

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

**Vezérelhetem a diaátmenet lejátszási sebességét?**

Igen. Használja a [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) metódust, ha pontos effektus időtartamra van szüksége ezredmásodpercben. Használja a [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) metódust, ha egy előre definiált [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) kategória – Slow, Medium vagy Fast – elegendő, és nincs explicit időtartam beállítva. Ezek a beállítások a tranzíciós effektust szabályozzák, függetlenül az automatikus léptetés késleltetésétől.

**Csatolhatok hangot egy átmenethez, és beállíthatom, hogy ismétlődjön?**

Igen. Rendeljünk beágyazott hangot a [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) metódussal, a [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) felsorolásból a StartSound értékét adva a [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) metódusnak, és a [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) `True` értékkel engedélyezve. A hang addig ismétlődik, amíg a diavetítésben nem következik egy új hangesemény.

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzuk minden diára?**

Iteráljon a prezentáció [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) gyűjteményén, és hívja meg a [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) metódust ugyanazzal az értékkel minden dia átmenetéhez. Állítson be minden időzítési és effektus opciót ugyanabban a ciklusban, hogy a viselkedés minden dián konzisztens legyen.

**Hogyan ellenőrizhetem, hogy milyen átmenet van jelenleg beállítva egy dián?**

Hívja meg a [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) metódust a dia [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) eredményén. Egy értéket ad vissza a [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) felsorolásból; a None_ azt jelenti, hogy nincs alkalmazott átmeneti effektus.