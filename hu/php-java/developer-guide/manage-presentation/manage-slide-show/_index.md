---
title: Slide Show kezelése PHP-ben
linktitle: Diavetítés
type: docs
weight: 90
url: /hu/php-java/manage-slide-show/
keywords:
- bemutató típusa
- előadó által bemutatott
- egyéni böngészés
- kioszkban böngészve
- bemutató beállítások
- folyamatos ismétlés
- narráció nélkül
- animáció nélkül
- toll színe
- diák megjelenítése
- egyéni bemutató
- diák előrehaladása
- manuálisan
- időzítések használata
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg, hogyan kezelje a diavetítéseket az Aspose.Slides for PHP Java segítségével. Könnyedén ellenőrizze a diaátmeneteket, időzítéseket és egyebeket PPT, PPTX és ODP formátumokban."
---
## **Bevezetés**

A Microsoft PowerPointben a **Slide Show** beállítások kulcsfontosságú eszközt jelentenek a professzionális bemutatók előkészítéséhez és előadásához. Ennek a szakasznak az egyik legfontosabb funkciója a **Set Up Show**, amely lehetővé teszi, hogy a bemutatót meghatározott körülményekhez és közönséghez igazítsa, biztosítva a rugalmasságot és kényelmet. Ezzel a funkcióval kiválaszthatja a bemutató típusát (például előadó által bemutatott, egyéni böngészés, vagy kioszkban böngészett), engedélyezheti vagy letilthatja a ciklikus lejátszást, megadhatja a megjelenítendő diákot, és időzítéseket használhat. Ez az előkészítési lépés kulcsfontosságú a bemutató hatékonyabbá és professzionálisabbá tételéhez.

`getSlideShowSettings` egy metódus a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztálynál, amely egy [SlideShowSettings](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideshowsettings/) típusú objektumot ad vissza, amely lehetővé teszi a slide show beállítások kezelését egy PowerPoint bemutatóban. Ebben a cikkben azt vizsgáljuk meg, hogyan használhatjuk ezt a metódust a slide show beállítások különböző aspektusainak konfigurálására és vezérlésére. 

## **Show típus kiválasztása**

`SlideShowSettings->setSlideShowType` meghatározza a slide show típusát, amely a következő osztályok valamelyikének példánya lehet: [PresentedBySpeaker](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hu/php-java/aspose.slides/browsedbyindividual/), vagy [BrowsedAtKiosk](https://reference.aspose.com/slides/hu/php-java/aspose.slides/browsedatkiosk/). Ezzel a metódussal a bemutatót különböző felhasználási forgatókönyvekhez igazíthatja, például automatizált kioszkokhoz vagy kézi prezentációkhoz.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Show opciók engedélyezése**

`SlideShowSettings->setLoop` meghatározza, hogy a slide show ismétlődjön-e ciklikusan, amíg manuálisan le nem állítják. Ez hasznos automatizált prezentációk esetén, amelyek folyamatosan futniuk kell. `SlideShowSettings->setShowNarration` meghatározza, hogy a hangos narrációk lejátszódjanak-e a slide show során. Ez azoknál az automatizált prezentációknál hasznos, amelyek hangutasítást tartalmaznak a közönség számára. `SlideShowSettings->setShowAnimation` meghatározza, hogy a diaobjektumokhoz hozzáadott animációk lejátszódjanak-e. Ez a teljes vizuális hatás biztosításához szükséges.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Megjelenítendő diák kiválasztása**

`SlideShowSettings->setSlides` metódus lehetővé teszi, hogy a bemutató során megjelenítendő diák tartományát válassza ki. Ez akkor hasznos, ha csak a prezentáció egy részét szeretné megjeleníteni, nem az összes diát. Az alábbi kódrészlet egy új prezentációt hoz létre, és a `2`‑tól `9`‑ig terjedő diatartományt állítja be megjelenítésre.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Előrehaladó diákok használata**

`SlideShowSettings->setUseTimings` metódus lehetővé teszi, hogy engedélyezze vagy letiltsa az előre beállított időzítések használatát az egyes diákhoz. Ez automatikus diamegjelenítést tesz lehetővé előre definiált megjelenítési időkkel. Az alábbi kódrészlet egy új prezentációt hoz létre, és letiltja az időzítések használatát.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Médiavezérlők megjelenítése**

`SlideShowSettings->setShowMediaControls` metódus meghatározza, hogy a médiavezérlők (például lejátszás, szünet, leállítás) megjelenjenek‑e a slide show során, amikor multimédiás tartalom (például videó vagy hang) kerül lejátszásra. Ez akkor hasznos, ha a prezentáló számára szeretne médiavezérlést biztosítani a bemutató alatt.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **FAQ**

**Menthetők a prezentációk úgy, hogy közvetlenül slide show módban nyíljanak meg?**

Igen. Mentse a fájlt PPSX vagy PPSM formátumban; ezek a formátumok közvetlenül slide show módban indulnak a PowerPointben megnyitáskor. Az Aspose.Slides-ben válassza a megfelelő mentési formátumot [during export](/slides/hu/php-java/save-presentation/).

**Kizárhatók egyedi diák a bemutatóból a fájlból történő törlés nélkül?**

Igen. Jelölje meg a diát [hidden](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/sethidden/). A rejtett diák a bemutatóban maradnak, de a slide show során nem jelennek meg.

**Le tudja-e az Aspose.Slides lejátszani a slide show‑t vagy vezérelni a képernyőn zajló élő bemutatót?**

Nem. Az Aspose.Slides szerkeszti, elemzi és konvertálja a bemutató fájlokat; a tényleges lejátszást egy megjelenítő alkalmazás, például a PowerPoint végzi.