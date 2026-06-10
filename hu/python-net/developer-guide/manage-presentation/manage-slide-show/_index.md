---
title: Diavetítés kezelése Pythonban
linktitle: Diavetítés
type: docs
weight: 90
url: /hu/python-net/manage-slide-show/
keywords:
- diavetítés típusa
- előadó által prezentált
- egyéni böngészés
- kioszk módban
- diavetítés beállításai
- folyamatos ciklus
- narráció nélkül
- animáció nélkül
- toll színe
- diák megjelenítése
- egyéni diavetítés
- diák előrehaladása
- manuálisan
- időzítések használata
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet diavetítéseket az Aspose.Slides Pythonhoz .NET-en keresztül. Könnyedén szabályozhatja a diák átmeneteit, időzítéseit és egyebeket a PPT, PPTX és ODP formátumokban."
---
## **Bevezetés**

A Microsoft PowerPointban a **Diavetítés** beállítások kulcsfontosságú eszközök a professzionális prezentációk előkészítéséhez és bemutatásához. Az egyik legfontosabb funkció ebben a szakaszban a **Diavetítés beállítása**, amely lehetővé teszi, hogy a prezentációt konkrét körülményekhez és közönséghez igazítsa, biztosítva a rugalmasságot és a kényelmet. Ezzel a funkcióval kiválaszthatja a diavetítés típusát (például előadó által prezentált, egyéni böngészés vagy kioszk módban), engedélyezheti vagy letilthatja a ciklusozást, megadhatja a megjelenítendő diákat, és időzítéseket használhat. Ez a lépés elengedhetetlen ahhoz, hogy a prezentáció hatékonyabb és professzionálisabb legyen.

`slide_show_settings` a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály egy tulajdonsága, típusa [SlideShowSettings](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slideshowsettings/), amely lehetővé teszi a diavetítés beállításainak kezelését egy PowerPoint prezentációban. Ebben a cikkben bemutatjuk, hogyan használhatja ezt a tulajdonságot a diavetítés beállításainak különböző aspektusainak konfigurálására és vezérlésére. 

## **Diavetítés típusának kiválasztása**

`SlideShowSettings.slide_show_type` meghatározza a diavetítés típusát, amely a következő osztályok példánya lehet: [PresentedBySpeaker](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hu/python-net/aspose.slides/browsedbyindividual/) vagy [BrowsedAtKiosk](https://reference.aspose.com/slides/hu/python-net/aspose.slides/browsedatkiosk/). Ennek a tulajdonságnak a használata lehetővé teszi a prezentáció különböző felhasználási forgatókönyvekhez való igazítását, például automatizált kioszkok vagy manuális bemutatók esetén.

Az alábbi kódrészlet új prezentációt hoz létre, és a diavetítés típusát "Böngészett egy egyén által" állítja be, a görgetősáv megjelenítése nélkül.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Diavetítés opcióinak engedélyezése**

`SlideShowSettings.loop` meghatározza, hogy a diavetítés ismétlődjön‑e egy ciklusban, amíg manuálisan le nem állítják. Ez hasznos automatizált prezentációk esetén, amelyek folyamatosan futniuk kell. `SlideShowSettings.show_narration` meghatározza, hogy a hangos narrációk le legyenek‑e játszva a diavetítés során. Ez hasznos olyan automatizált prezentációk esetén, amelyek hangvezetéssel segítik a közönséget. `SlideShowSettings.show_animation` meghatározza, hogy a diákhoz hozzáadott animációk le legyen‑e játszva. Ez a teljes vizuális hatás biztosításához szükséges.

Az alábbi kódrészlet új prezentációt hoz létre, és ciklikussá teszi a diavetítést.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Megjelenítendő diák kiválasztása**

`SlideShowSettings.slides` tulajdonság lehetővé teszi, hogy egy diatartományt válasszon ki a prezentáció során megjelenítendő diák közül. Ez hasznos, ha csak a prezentáció egy részét szeretné megmutatni, nem az összes diát. Az alábbi kódrészlet új prezentációt hoz létre, és a megjelenítendő diatartományt a `2`‑től `9`‑ig terjedő diákra állítja.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Előrehaladó diákok használata**

`SlideShowSettings.use_timings` tulajdonság lehetővé teszi az egyes diák előre beállított időzítéseinek használatát vagy letiltását. Ez hasznos az automatikus diavetítéshez, amely előre meghatározott megjelenítési időkkel rendelkezik. Az alábbi kódrészlet új prezentációt hoz létre, és letiltja az időzítések használatát.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Média vezérlők megjelenítése**

`SlideShowSettings.show_media_controls` tulajdonság meghatározza, hogy a médiavezérlők (például lejátszás, szünet és leállítás) megjelenjenek‑e a diavetítés során, amikor multimédia tartalom (például videó vagy hang) játszódik le. Ez akkor hasznos, ha a prezentáló számára szeretne vezérlő lehetőséget biztosítani a média lejátszásához.

Az alábbi kódrészlet új prezentációt hoz létre, és engedélyezi a médiavezérlők megjelenítését.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Menthetek-e egy prezentációt úgy, hogy közvetlenül diavetítés módban nyíljon meg?**

Igen. Mentse a fájlt PPSX vagy PPSM formátumban; ezek a formátumok a PowerPointban megnyitáskor közvetlenül diavetítés módban indulnak. Az Aspose.Slides‑ben válassza a megfelelő mentési formátumot a [exportálás során](/slides/hu/python-net/save-presentation/).

**Kizárhatok-e egyes diákat a diavetítésből anélkül, hogy törölném őket a fájlból?**

Igen. Jelölje a diát [rejtett]({{guid}})ként. A rejtett diák a prezentációban maradnak, de a diavetítés során nem jelennek meg.

**Le tudja-e játszani az Aspose.Slides a diavetítést, vagy irányíthatja a képernyőn élő prezentációt?**

Nem. Az Aspose.Slides szerkeszti, elemzi és konvertálja a prezentációs fájlokat; a tényleges lejátszást egy megjelenítő alkalmazás, például a PowerPoint végzi.