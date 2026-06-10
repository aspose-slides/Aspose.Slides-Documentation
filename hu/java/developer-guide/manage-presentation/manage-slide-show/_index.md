---
title: Diavetítés kezelése Java-ban
linktitle: Diavetítés
type: docs
weight: 90
url: /hu/java/manage-slide-show/
keywords:
- diavetítés típusa
- előadó által bemutatott
- egyéni felhasználó által böngészett
- kioszkban böngészett
- diavetítés beállításai
- folyamatos ciklus
- narráció nélkül
- animáció nélkül
- toll színe
- diák megjelenítése
- egyéni diavetítés
- diák előrehaladása
- kézzel
- időzítések használata
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diavetítéseket az Aspose.Slides for Java segítségével. Könnyedén vezérelheti a diák átmeneteit, időzítéseit és egyebeket a PPT, PPTX és ODP formátumokban."
---
## **Bevezetés**

Microsoft PowerPointban a **Diavetítés** beállítások kulcsfontosságú eszközök a professzionális bemutatók előkészítéséhez és bemutatásához. Ennek a szakasznak az egyik legfontosabb funkciója a **Diavetítés beállítása**, amely lehetővé teszi a bemutató testreszabását adott feltételekhez és közönséghez, biztosítva a rugalmasságot és kényelmet. Ezzel a funkcióval kiválaszthatja a bemutató típusát (például előadó által bemutatott, egyéni felhasználó által böngészett vagy kioszkban böngészett), engedélyezheti vagy letilthatja a ciklikus lejátszást, meghatározhatja a megjelenítendő diákat, és időzítéseket használhat. Ez az előkészítési lépés alapvető a bemutató hatékonyabbá és professzionálisabbá tétele érdekében.

`getSlideShowSettings` a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály egy metódusa, amely egy [SlideShowSettings](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowsettings/) típusú objektumot ad vissza, amellyel kezelheti a diavetítés beállításait egy PowerPoint bemutatóban. Ebben a cikkben megvizsgáljuk, hogyan használhatja ezt a metódust a diavetítés beállításainak különböző aspektusainak konfigurálásához és vezérléséhez. 

## **Diavetítés típusának kiválasztása**

`SlideShowSettings.setSlideShowType` meghatározza a diavetítés típusát, amely a következő osztályok egyikének példánya lehet: [PresentedBySpeaker](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hu/java/com.aspose.slides/browsedbyindividual/), vagy [BrowsedAtKiosk](https://reference.aspose.com/slides/hu/java/com.aspose.slides/browsedatkiosk/). Ennek a metódusnak a használatával a bemutatót különböző felhasználási forgatókönyvekhez, például automatizált kioszkokhoz vagy kézi bemutatókhoz igazíthatja.

A lenti kódpélda új bemutatót hoz létre, és a diavetítés típusát „Browsed by an individual” értékre állítja anélkül, hogy a görgetősávot megjelenítené.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Diavetítés beállításainak engedélyezése**

`SlideShowSettings.setLoop` meghatározza, hogy a diavetítés ciklikusan ismétlődjön‑e, amíg manuálisan le nem állítják. Ez hasznos automatizált bemutatók esetén, amelyeknek folyamatosan kell futniuk. `SlideShowSettings.setShowNarration` meghatározza, hogy a hangos narrációk le legyenek‑e játszva a diavetítés során. Ez hasznos automatizált bemutatók esetén, amelyek tartalmaznak hangú útmutatót a közönségnek. `SlideShowSettings.setShowAnimation` meghatározza, hogy a diaképekhez hozzáadott animációk le legyenek‑e játszva. Ez a teljes vizuális hatás biztosításához hasznos.

A következő kódpélda új bemutatót hoz létre, és ciklikusan lejátsza a diavetítést.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Megjelenítendő diák kiválasztása**

`SlideShowSettings.setSlides` metódus lehetővé teszi a bemutató során megjelenítendő diák tartományának kiválasztását. Ez akkor hasznos, ha a teljes bemutató helyett csak egy részét szeretné megjeleníteni. A következő kódpélda új bemutatót hoz létre, és a megjelenítendő diák tartományát a `2`‑től `9`‑ig terjedő diákra állítja.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Előrehaladó diák használata**

`SlideShowSettings.setUseTimings` metódus lehetővé teszi az egyes diákra beállított előre meghatározott időzítések használatának engedélyezését vagy letiltását. Ez hasznos a diák automatikus megjelenítéséhez előre definiált megjelenítési időkkel. Az alábbi kódpélda új bemutatót hoz létre, és letiltja az időzítések használatát.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Médiavezérlők megjelenítése**

`SlideShowSettings.setShowMediaControls` metódus meghatározza, hogy a diavetítés során a multimédiás tartalom (például videó vagy hang) lejátszása közben megjelenjenek‑e a médiavezérlők (például lejátszás, szünet, leállítás). Ez akkor hasznos, ha a prezentáció során a bemutatónak szeretné biztosítani a média lejátszásának irányítását.

A következő kódpélda új bemutatót hoz létre, és engedélyezi a médiavezérlők megjelenítését.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **GYIK**

**Menthetek‑e egy bemutatót úgy, hogy az közvetlenül diavetítő módban nyíljon meg?**

Igen. Mentse a fájlt PPSX vagy PPSM formátumban; ezek a formátumok a PowerPointban megnyitáskor közvetlenül diavetítő módban indulnak. Az Aspose.Slides‑ben válassza a megfelelő mentési formátumot [exportálás közben](/slides/hu/java/save-presentation/).

**Kiválaszthatok‑e egyedi diákat a diavetítésből a fájlból való törlés nélkül?**

Igen. Jelölje meg a diát [rejtett](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#setHidden-boolean-). A rejtett diák megmaradnak a bemutatóban, de a diavetítés során nem jelennek meg.

**Lehet‑e az Aspose.Slides‑nek lejátszani egy diavetítést vagy vezérelni egy élő prezentációt a képernyőn?**

Nem. Az Aspose.Slides a prezentációs fájlok szerkesztésére, elemzésére és konvertálására szolgál; a tényleges lejátszást egy megjelenítő alkalmazás, például a PowerPoint végzi.