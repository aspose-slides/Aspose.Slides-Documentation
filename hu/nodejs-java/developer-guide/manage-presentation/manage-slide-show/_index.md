---
title: Diavetítés kezelése JavaScript-ben
linktitle: Diavetítés
type: docs
weight: 90
url: /hu/nodejs-java/manage-slide-show/
keywords:
- diavetítés típusa
- előadó által bemutatott
- egyéni böngészés
- kioszkban böngészve
- diavetítés beállításai
- folyamatos ismétlés
- narráció nélkül
- animáció nélkül
- toll színe
- diák megjelenítése
- egyedi diavetítés
- diák előrehaladása
- kézi
- időzítések használata
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a diavetítéseket JavaScript-ben az Aspose.Slides for Node.js segítségével. Könnyedén szabályozza a diaátmeneteket, időzítéseket és egyebeket PPT, PPTX és ODP formátumokban."
---
## **Bevezetés**

A Microsoft PowerPoint programban a **Slide Show** beállítások kulcsfontosságú eszközök a professzionális előadások előkészítéséhez és bemutatásához. Ennek a szakasznak az egyik legfontosabb funkciója a **Set Up Show**, amely lehetővé teszi, hogy a bemutatót konkrét feltételekhez és közönséghez igazítsa, biztosítva a rugalmasságot és a kényelmet. Ezzel a funkcióval kiválaszthatja a bemutató típusát (például előadó által bemutatott, egyéni böngészésű vagy kioszkban böngészett), engedélyezheti vagy letilthatja a ciklikus lejátszást, megadhatja a megjelenítendő diákat, valamint időzítéseket használhat. Ez a felkészülési lépés elengedhetetlen a bemutató hatékonyabbá és professzionálisabbá tételéhez.

`getSlideShowSettings` egy metódus a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályban, amely egy [SlideShowSettings](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowsettings/) típusú objektumot ad vissza, amely lehetővé teszi a diavetítés beállításainak kezelését egy PowerPoint bemutatóban. Ebben a cikkben megvizsgáljuk, hogyan használhatjuk ezt a metódust a diavetítés beállításainak különböző aspektusainak konfigurálásához és vezérléséhez. 

## **Diavetítés típusának kiválasztása**

`SlideShowSettings.setSlideShowType` meghatározza a diavetítés típusát, amely a következő osztályok egyikének példánya lehet: [PresentedBySpeaker](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/browsedbyindividual/), vagy [BrowsedAtKiosk](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/browsedatkiosk/). Ennek a metódusnak a használatával a bemutatót különböző felhasználási forgatókönyvekhez igazíthatja, például automatizált kioszkokhoz vagy kézi bemutatókhoz.

Az alábbi kódrészlet új bemutatót hoz létre, és a diavetítés típusát “Browsed by an individual” értékre állítja, anélkül, hogy a görgetősáv megjelenne.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Diavetítési beállítások engedélyezése**

`SlideShowSettings.setLoop` meghatározza, hogy a diavetítés ismétlődjön-e ciklikusan, amíg manuálisan le nem állítják. Ez hasznos automatizált bemutatók esetén, amelyeknek folyamatosan kell futniuk. `SlideShowSettings.setShowNarration` határozza meg, hogy a hangos narrációk lejátszódjanak-e a diavetítés során. Ez hasznos automatizált bemutatók esetén, amelyek hangos útmutatást tartalmaznak a közönség számára. `SlideShowSettings.setShowAnimation` határozza meg, hogy a diaképeken lévő animációk lejátszódjanak-e. Ez a teljes vizuális hatás biztosításához hasznos.

Az alábbi kódrészlet új bemutatót hoz létre, és ciklikusan lejátsza a diavetítést.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Megjelenítendő diák kiválasztása**

`SlideShowSettings.setSlides` metódus lehetővé teszi, hogy a bemutató során megjelenítendő diák tartományát kiválassza. Ez akkor hasznos, ha csak a bemutató egy részét szeretné megjeleníteni, nem pedig az összes diát. Az alábbi kódrészlet új bemutatót hoz létre, és a megjelenítendő diák tartományát a `2`‑től `9`‑ig terjedő diákra állítja.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Dia előrehaladásának használata**

`SlideShowSettings.setUseTimings` metódus lehetővé teszi előre beállított időzítések használatának engedélyezését vagy letiltását az egyes diákhoz. Ez hasznos az automatikus diaváltáshoz előre meghatározott megjelenítési időkkel. Az alábbi kódrészlet új bemutatót hoz létre, és letiltja az időzítések használatát.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Médialejátszó vezérlők megjelenítése**

`SlideShowSettings.setShowMediaControls` metódus meghatározza, hogy a médiavezérlők (például lejátszás, szünet és leállítás) megjelenjenek-e a diavetítés során, amikor multimédiás tartalom (például videó vagy hang) kerül lejátszásra. Ez akkor hasznos, ha a prezentáló számára szeretne vezérlést adni a médiavégrehajtás felett a bemutató során.

Az alábbi kódrészlet új bemutatót hoz létre, és engedélyezi a médiavezérlők megjelenítését.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **GYIK**

**Menthetek-e egy bemutatót úgy, hogy közvetlenül diavetítési módban nyíljon meg?**

Igen. Mentse a fájlt PPSX vagy PPSM formátumban; ezek a formátumok közvetlenül diavetítési módban nyílnak meg PowerPointban. Az Aspose.Slides-ban válassza a megfelelő mentési formátumot [exportálás közben](/slides/hu/nodejs-java/save-presentation/).

**Kizárhatok-e egyes diákat a diavetítésből anélkül, hogy törölném őket a fájlból?**

Igen. Jelöljön egy diát [rejtettként](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/sethidden/). A rejtett diák továbbra is a bemutatóban maradnak, de a diavetítés során nem jelennek meg.

**Le tudja-e az Aspose.Slides lejátszani a diavetítést vagy irányítani egy élő bemutatót a képernyőn?**

Nem. Az Aspose.Slides szerkeszti, elemzi és konvertálja a bemutató fájlokat; a tényleges lejátszást egy megjelenítő alkalmazás, például a PowerPoint kezeli.