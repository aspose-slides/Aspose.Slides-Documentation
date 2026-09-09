---
title: Diavetítések kezelése Pythonon keresztül Java-val
linktitle: Diavetítés
type: docs
weight: 90
url: /hu/python-java/manage-slide-show/
keywords:
- diavetítés típusa
- előadó által bemutatott
- egyéni böngészés
- kioszkos böngészés
- vetítési beállítások
- folyamatos ciklus
- narráció nélküli vetítés
- animáció nélküli vetítés
- toll színe
- diák megjelenítése
- egyéni vetítés
- diák előrehaladása
- kézzel
- időzítések használata
- PowerPoint
- OpenDocument
- bemutató
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diavetítéseket az Aspose.Slides for Python via Java segítségével. Könnyedén szabályozhatja a diaátmeneteket, időzítéseket és egyéb beállításokat a PPT, PPTX és ODP formátumokban."
---
## **Bevezetés**

A Microsoft PowerPoint **Set Up Show** beállításai lehetővé teszik a bemutató típusának kiválasztását, a ciklus engedélyezését, a diák kiválasztását, és a diák előrehaladásának szabályozását. Az Aspose.Slides for Python via Java segítségével ezek a beállítások programozottan konfigurálhatók, és egy bemutatófájlba menthetők.

A [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlideShowSettings) metódus egy [SlideShowSettings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/) objektumot ad vissza, amely szabályozza ezeket a beállításokat. Az alábbi példákhoz az Aspose.Slides for Python via Java és egy kompatibilis Java futtatókörnyezet szükséges. Minden példa elindítja a JVM-et, ha szükséges, és a végén felszabadítja a bemutatót.

## **Bemutató típusának kiválasztása**

[A SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setSlideShowType) meghatározza a diavetítés típusát, amely a következő osztályok valamelyikének példánya lehet: [PresentedBySpeaker](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hu/python-java/aspose.slides/browsedbyindividual/), vagy [BrowsedAtKiosk](https://reference.aspose.com/slides/hu/python-java/aspose.slides/browsedatkiosk/). Ennek a metódusnak a használata lehetővé teszi a bemutató különböző felhasználási forgatókönyvekhez való igazítását, például automatizált kioszkokhoz vagy manuális bemutatókhoz.

Az alábbi kódrészlet egy új bemutatót hoz létre, és a bemutató típusát „Browsed by an individual” értékre állítja a gördítősáv megjelenítése nélkül.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Megjelenítési lehetőségek engedélyezése**

[A SlideShowSettings.setLoop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setLoop) meghatározza, hogy a diavetítés ismétlődjön-e ciklikusan, amíg manuálisan nem állítják le. Ez hasznos automatizált bemutatók esetén, amelyek folyamatos futást igényelnek. A [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setShowNarration) beállítja, hogy a hangos narrációk lejátszódjanak-e a diavetítés során. Ez akkor hasznos, ha a bemutató hangutasítást tartalmaz a közönség számára. A [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setShowAnimation) meghatározza, hogy a diaképekre helyezett animációk lejátszódjanak-e. Ez a bemutató teljes vizuális hatásának biztosításához szükséges.

A következő kódrészlet egy új bemutatót hoz létre, és ciklikusan futtatja a diavetítést.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Megjelenítendő diák kiválasztása**

[A SlideShowSettings.setSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setSlides) metódus lehetővé teszi a bemutató során megjelenítendő diák tartományának kiválasztását. Ez akkor hasznos, ha a teljes bemutató csak egy részét szeretné megjeleníteni, nem minden diát. Az alábbi kódrészlet kilenc diát tartalmazó bemutatót hoz létre, és a 2-9. diát választja ki. A tartomány egy-alapú diaszámozást használ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Hozzon létre kilenc diát, hogy a kiválasztott tartomány létezzen.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Diák előrehaladásának vezérlése**

[A SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setUseTimings) metódus engedélyezi vagy letiltja az előre beállított időzítések használatát minden diára vonatkozóan. Ez hasznos automatikus diavetítéshez, amely előre meghatározott megjelenítési időtartamokkal rendelkezik. Az alábbi kódrészlet egy új bemutatót hoz létre, és letiltja az időzítések használatát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Média vezérlők megjelenítése**

[A SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) metódus meghatározza, hogy a diavetítés során, ha multimédiás tartalom (például videó vagy hang) játszódik, megjelenjenek-e a médiavezérlők (például lejátszás, szünet, stop). Ez akkor hasznos, ha a bemutató során a prezentátornak szeretnénk biztosítani a média lejátszásának irányítását.

A következő kódrészlet egy új bemutatót hoz létre, és engedélyezi a médiavezérlők megjelenítését.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Menthetek egy bemutatót úgy, hogy közvetlenül diavetítési módban nyíljon meg?**

Igen. Mentse a fájlt PPSX vagy PPSM formátumban; ezek a formátumok a PowerPoint megnyitásakor közvetlenül diavetítési módban indulnak. Az Aspose.Slides-ben válassza ki a megfelelő mentési formátumot a [exportálás során](/slides/hu/python-java/save-presentation/).

**Kiválaszthatok egyes diákat a bemutatóból anélkül, hogy törölném őket a fájlból?**

Igen. Jelöljön meg egy diát [rejtettnek](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#setHidden). A rejtett diák a bemutatóban maradnak, de a diavetítés során nem jelennek meg.

**Le tudja-e az Aspose.Slides lejátszani a diavetítést vagy vezérelni egy élő bemutatót a képernyőn?**

Nem. Az Aspose.Slides a bemutatófájlokat szerkeszti, elemzi és konvertálja; a tényleges lejátszást egy megjelenítő alkalmazás, például a PowerPoint kezeli.