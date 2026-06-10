---
title: Androidon történő diavetítés kezelése
linktitle: Diavetítés
type: docs
weight: 90
url: /hu/androidjava/manage-slide-show/
keywords:
- megjelenítési típus
- előadó által bemutatott
- egyéni böngészés
- kioszkban böngészés
- megjelenítési beállítások
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
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan kezelje a diavetítéseket az Aspose.Slides for Android révén Java használatával. Könnyedén irányíthatja a diaátmeneteket, időzítéseket és egyebeket a PPT, PPTX és ODP formátumokban."
---
## **Bevezetés**

A Microsoft PowerPointban a **Diavetítés** beállításai kulcsfontosságú eszközök a professzionális prezentációk előkészítéséhez és bemutatásához. Ennek a szekciónak az egyik legfontosabb funkciója a **Diavetítés beállítása**, amely lehetővé teszi, hogy a prezentációt adott körülményekhez és közönséghez igazítsa, ezzel rugalmasságot és kényelmet biztosítva. Ezzel a funkcióval kiválaszthatja a bemutató típusát (például előadó által bemutatott, egyéni böngészés vagy kioszkban történő böngészés), engedélyezheti vagy letilthatja a ciklikus lejátszást, meghatározhatja a megjelenítendő diákat, és időzítéseket használhat. Ez az előkészítési lépés elengedhetetlen a prezentáció hatékonyságának és professzionalizmusának növeléséhez.

`getSlideShowSettings` a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály metódusa, amely visszaad egy [SlideShowSettings](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowsettings/) típusú objektumot, és lehetővé teszi a diavetítés beállításainak kezelését egy PowerPoint prezentációban. Ebben a cikkben bemutatjuk, hogyan használhatja ezt a metódust a diavetítés beállításainak különböző aspektusainak konfigurálására és vezérlésére. 

## **Megjelenítési típus kiválasztása**

`SlideShowSettings.setSlideShowType` meghatározza a diavetítés típusát, amely a következő osztályok egyikének példánya lehet: [PresentedBySpeaker](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/browsedbyindividual/), vagy [BrowsedAtKiosk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/browsedatkiosk/). Ennek a metódusnak a használatával a prezentációt különböző felhasználási forgatókönyvekhez igazíthatja, például automatizált kioszkokhoz vagy manuális bemutatókhoz.

Az alábbi kódrészlet egy új prezentációt hoz létre, és a bemutató típusát „Browsed by an individual” –ra állítja a gördítősáv elrejtése mellett.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Megjelenítési beállítások engedélyezése**

`SlideShowSettings.setLoop` meghatározza, hogy a diavetítés ismétlődő ciklusban fusson‑e, amíg manuálisan le nem állítják. Ez hasznos automatizált bemutatók esetén, amelyeknek folyamatosan kell futniuk. `SlideShowSettings.setShowNarration` meghatározza, hogy hangos narrációk legyenek‑e lejátszva a diavetítés során. Ez az automatikus bemutatók esetében hasznos, amelyek hangú útmutatást tartalmaznak a közönségnek. `SlideShowSettings.setShowAnimation` meghatározza, hogy a diák objektumaihoz hozzáadott animációk legyenek‑e lejátszva. Ez a prezentáció teljes vizuális hatásának biztosításához szükséges.

Az alábbi kódrészlet egy új prezentációt hoz létre, és ciklikusan lejátsza a diavetítést.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Megjelenítendő diák kiválasztása**

`SlideShowSettings.setSlides` metódus lehetővé teszi a bemutató során megjelenítendő diák tartományának kiválasztását. Ez akkor hasznos, ha csak a prezentáció egy részét szeretné megjeleníteni, nem az összes diát. Az alábbi kódrészlet egy új prezentációt hoz létre, és a megjelenítendő diák tartományát a `2`‑től `9`‑ig terjedő diákra állítja.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Időzítések használata**

`SlideShowSettings.setUseTimings` metódus lehetővé teszi az egyes diák előre beállított időzítéseinek engedélyezését vagy letiltását. Ez hasznos a diák automatikus megjelenítéséhez előre meghatározott megjelenítési időkkel. Az alábbi kódrészlet egy új prezentációt hoz létre, és letiltja az időzítések használatát.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Média vezérlők megjelenítése**

`SlideShowSettings.setShowMediaControls` metódus meghatározza, hogy a diavetítés során megjelenjenek‑e a média vezérlők (például lejátszás, szünet és stop), amikor multimédia tartalom (például videó vagy hang) játszódik. Ez akkor hasznos, ha a prezentátor számára szeretne média lejátszás feletti irányítást biztosítani a bemutató alatt.

Az alábbi kódrészlet egy új prezentációt hoz létre, és engedélyezi a média vezérlők megjelenítését.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **GYIK**

**Menthetek‑e egy prezentációt úgy, hogy közvetlenül diavetítési módban nyílik meg?**

Igen. Mentse a fájlt PPSX vagy PPSM formátumban; ezek a formátumok közvetlenül diavetítésként indulnak el, ha a PowerPointban nyitják meg. Az Aspose.Slides‑ben válassza ki a megfelelő mentési formátumot [a mentés során](/slides/hu/androidjava/save-presentation/).

**Kizárhatok‑e egyes diákat a bemutatóból anélkül, hogy törölném őket a fájlból?**

Igen. Jelöljön egy diát [rejtett](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#setHidden-boolean-). A rejtett diák a prezentációban maradnak, de a diavetítés során nem jelennek meg.

**Lejátszhatja‑e az Aspose.Slides a diavetítést vagy vezérelheti‑e egy élő prezentációt a képernyőn?**

Nem. Az Aspose.Slides szerkeszti, elemzi és konvertálja a prezentációs fájlokat; a tényleges lejátszást egy megjelenítő alkalmazás, például a PowerPoint végzi.