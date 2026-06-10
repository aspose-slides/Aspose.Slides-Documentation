---
title: Dia vetítés kezelése C++-ban
linktitle: Dia vetítés
type: docs
weight: 90
url: /hu/cpp/manage-slide-show/
keywords:
- vetítés típusa
- előadó által bemutatott
- egyéni böngészés
- kioszkban nézett
- vetítés beállításai
- folyamatos hurkolás
- narráció nélkül
- animáció nélkül
- toll színe
- diák megjelenítése
- egyedi vetítés
- diák előrehaladása
- kézzel
- időzítések használata
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diavetítéseket az Aspose.Slides C++ könyvtárban. Könnyedén szabályozhatja a diáátmeneteket, időzítéseket és egyebeket PPT, PPTX és ODP formátumokban."
---
## **Bevezetés**

A Microsoft PowerPoint alkalmazásban a **Slide Show** beállítások kulcsfontosságú eszközei a professzionális bemutatók előkészítésének és előadásának. Ennek a szakasznak az egyik legfontosabb funkciója a **Set Up Show**, amely lehetővé teszi, hogy a bemutatót konkrét körülményekhez és közönséghez igazítsa, biztosítva a rugalmasságot és kényelmet. Ezzel a funkcióval kiválaszthatja a bemutató típusát (például előadó által bemutatott, egyéni böngészésű vagy kioszkban böngészett), engedélyezheti vagy letilthatja a hurkolást, megadhatja a megjelenítendő diákat, és időzítéseket használhat. Ez az előkészítési lépés elengedhetetlen a bemutató hatékonyabbá és professzionálisabbá tételéhez.

`get_SlideShowSettings` a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály metódusa, amely egy [SlideShowSettings](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slideshowsettings/) típusú objektumot ad vissza, lehetővé téve a slide show beállítások kezelését PowerPoint prezentációban. Ebben a cikkben megvizsgáljuk, hogyan használhatjuk ezt a metódust a slide show beállításainak konfigurálására és vezérlésére. 

## **Show típusának kiválasztása**

`SlideShowSettings.set_SlideShowType` határozza meg a slide show típusát, amely a következő osztályok valamelyikének példánya lehet: [PresentedBySpeaker](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hu/cpp/aspose.slides/browsedbyindividual/), vagy [BrowsedAtKiosk](https://reference.aspose.com/slides/hu/cpp/aspose.slides/browsedatkiosk/). Ennek a metódusnak a használatával a prezentációt különböző felhasználási helyzetekhez igazíthatja, például automatizált kioszkokhoz vagy kézi bemutatókhoz.

Az alábbi kódrészlet új prezentációt hoz létre, és a slide show típusát "Browsed by an individual"-re állítja a gördítősáv megjelenítése nélkül.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Show beállításainak engedélyezése**

`SlideShowSettings.set_Loop` határozza meg, hogy a slide show ismétlődjön-e egy ciklusban, amíg manuálisan le nem állítják. Ez hasznos automatizált bemutatók esetén, amelyek folyamatosan futniuk kell. `SlideShowSettings.set_ShowNarration` határozza meg, hogy a hangos narrációk lejátszódjanak-e a slide show során. Ez automatizált, hangos útmutatást tartalmazó prezentációk esetén hasznos. `SlideShowSettings.set_ShowAnimation` határozza meg, hogy a diák objektumaihoz hozzáadott animációk lejátszódjanak-e. Ez a teljes vizuális hatás biztosításához hasznos.

Az alábbi kódrészlet új prezentációt hoz létre, és ciklikusan ismétli a slide show-t.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Megjelenítendő diák kiválasztása**

`SlideShowSettings.set_Slides` metódus lehetővé teszi, hogy egy diatartományt válasszon ki a bemutató során megjelenítendő diák közül. Ez hasznos, ha csak a prezentáció egy részét szeretné megjeleníteni, nem az összes diát. Az alábbi kódrészlet új prezentációt hoz létre, és a diatartományt a `2`-tól `9`-ig terjedő diákra állítja.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dia előrehaladásának használata**

`SlideShowSettings.set_UseTimings` metódus lehetővé teszi, hogy engedélyezze vagy letiltsa előre beállított időzítések használatát az egyes diákhoz. Ez hasznos a diák automatikus megjelenítéséhez előre meghatározott megjelenítési időkkel. Az alábbi kódrészlet új prezentációt hoz létre, és letiltja az időzítések használatát.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Médiavezérlők megjelenítése**

`SlideShowSettings.set_ShowMediaControls` metódus határozza meg, hogy a médiavezérlők (például lejátszás, szünet, leállítás) megjelenjenek-e a slide show során, amikor multimédiás tartalom (például videó vagy hang) kerül lejátszásra. Ez hasznos, ha a bemutató során a prezentáló számára szeretné biztosítani a média lejátszásának vezérlését.

Az alábbi kódrészlet új prezentációt hoz létre, és engedélyezi a médiavezérlők megjelenítését.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**Menthetek-e egy prezentációt úgy, hogy közvetlenül slide show módban nyíljon meg?**

Igen. A fájlt mentse PPSX vagy PPSM formátumban; ezek a formátumok a PowerPointban megnyitáskor közvetlenül slide show módban indulnak. Az Aspose.Slides-ben válassza a megfelelő mentési formátumot [a mentés során](/slides/hu/cpp/save-presentation/).

**Kihagyhatok-e egyedi diákat a bemutatóból a fájlból való törlés nélkül?**

Igen. Jelöljön egy diát [rejtettként](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/set_hidden/). A rejtett diák a prezentációban maradnak, de a slide show során nem jelennek meg.

**Képes-e az Aspose.Slides slide show-t lejátszani vagy élő prezentációt vezérelni a képernyőn?**

Nem. Az Aspose.Slides a prezentációs fájlok szerkesztésére, elemzésére és konvertálására szolgál; a tényleges lejátszást egy megjelenítő alkalmazás, például a PowerPoint végzi.