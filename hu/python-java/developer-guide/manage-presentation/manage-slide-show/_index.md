---
title: Diaátverések kezelése Pythonon keresztül Java-val
linktitle: Diavetítés
type: docs
weight: 90
url: /hu/python-java/manage-slide-show/
keywords:
- bemutató típusa
- előadó által bemutatott
- egyéni böngészés
- kioszkban böngészve
- bemutató beállítások
- folyamatos ciklus
- narráció nélkül
- animáció nélkül
- toll színe
- diák megjelenítése
- egyedi bemutató
- diák előrehaladása
- manuálisan
- időzítések használata
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan kezelje a diavetítéseket az Aspose.Slides for Python via Java segítségével. Könnyedén szabályozza a diák átmeneteit, időzítéseit és egyebeket a PPT, PPTX és ODP formátumokban."
---
## **Bevezetés**

A Microsoft PowerPoint **Set Up Show** beállításai lehetővé teszik a bemutató típusának kiválasztását, a ciklus engedélyezését, a diák kiválasztását és a diaváltás módjának szabályozását. Az Aspose.Slides for Python via Java segítségével ezeket a beállításokat programozottan konfigurálhatja, és egy bemutatófájlban elmentheti.

Az [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlideShowSettings) metódus egy [SlideShowSettings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/) objektumot ad vissza, amely ezeket a beállításokat szabályozza. Az alábbi példák az Aspose.Slides for Python via Java és egy kompatibilis Java futtatókörnyezet használatát igénylik. Minden példa szükség esetén elindítja a JVM-et, és a végén felszabadítja a bemutatót.

## **Bemutató típusának kiválasztása**

Az [SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setSlideShowType) meghatározza a diavetítés típusát, amely a következő osztályok egyikének példánya lehet: [PresentedBySpeaker](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hu/python-java/aspose.slides/browsedbyindividual/), vagy [BrowsedAtKiosk](https://reference.aspose.com/slides/hu/python-java/aspose.slides/browsedatkiosk/). Ennek a metódusnak a használatával a bemutatót különböző felhasználási scenáriókhoz igazíthatja, például automatizált kioszkokhoz vagy kézi bemutatókhoz.

Az alábbi kódrészlet új bemutatót hoz létre, és a bemutató típusát „Browsed by an individual” értékre állítja anélkül, hogy a görgetősáv megjelenne.

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

## **Bemutató opciók engedélyezése**

Az [SlideShowSettings.setLoop](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setLoop) meghatározza, hogy a diavetítés ciklusban ismétlődjön-e, amíg manuálisan le nem állítják. Ez hasznos automatikus bemutatók esetén, amelyeknek folyamatosan kell futniuk.  
Az [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setShowNarration) meghatározza, hogy a hangos narrációk lejátszódjanak-e a diavetítés során. Hasznos automatikus bemutatók esetén, amelyek hangutasítást tartalmaznak a közönség számára.  
Az [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setShowAnimation) meghatározza, hogy a diák objektumaihoz hozzáadott animációk le legyenek-e játszva. Ez a teljes vizuális hatás biztosításához hasznos.

Az alábbi kódrészlet új bemutatót hoz létre, és ciklikusan lejátsza a diavetítést.

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

Az [SlideShowSettings.setSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setSlides) metódus lehetővé teszi a bemutató során megjelenítendő diák tartományának kiválasztását. Ez akkor hasznos, ha csak a bemutató egy részét szeretné megjeleníteni, nem az összes diát.  
Az alábbi kódrészlet kilenc diás bemutatót hoz létre, és a 2‑től 9‑ig terjedő diákot választja ki. A tartomány egy‑alapú diaszámokat használ.

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

## **Diaváltás vezérlése**

Az [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setUseTimings) metódus lehetővé teszi az előre beállított időzítések használatának engedélyezését vagy letiltását minden dián. Ez hasznos a diák automatikus, előre meghatározott megjelenítési idejének biztosításához.  
Az alábbi kódrészlet új bemutatót hoz létre, és letiltja az időzítések használatát.

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

## **Médiavezérlők megjelenítése**

Az [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) metódus meghatározza, hogy a médiavezérlők (például lejátszás, szüneteltetés és leállítás) megjelenjenek-e a diavetítés során, amikor multimédia tartalom (pl. videó vagy hang) játszódik le. Ez akkor hasznos, ha a prezentáló számára lehetővé akarja tenni a média lejátszásának vezérlését a bemutató alatt.  
Az alábbi kódrészlet új bemutatót hoz létre, és engedélyezi a médiavezérlők megjelenítését.

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

**Menthetek-e egy bemutatót úgy, hogy közvetlenül diavetítési módban nyílik meg?**  
Igen. Mentse a fájlt PPSX vagy PPSM formátumban; ezek a formátumok a PowerPointban megnyitáskor közvetlenül diavetítési módban indulnak. Az Aspose.Slides-ben válassza a megfelelő mentési formátumot [exportálás során](/slides/hu/python-java/save-presentation/).

**Kizárhatok-e egyes diákat a bemutatóból anélkül, hogy törölném őket a fájlból?**  
Igen. Jelölje meg a diát [hidden](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#setHidden) állapotban. A rejtett diák megmaradnak a bemutatóban, de a diavetítés során nem jelennek meg.

**Le tudja-e az Aspose.Slides lejátszani a diavetítést vagy vezérelni egy élő prezentációt a képernyőn?**  
Nem. Az Aspose.Slides a bemutatófájlok szerkesztésére, elemzésére és konvertálására szolgál; a tényleges lejátszást egy nézőalkalmazás, például a PowerPoint kezeli.