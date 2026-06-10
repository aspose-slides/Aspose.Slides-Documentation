---
title: .NET-ben a diavetítés kezelése
linktitle: Diavetítés
type: docs
weight: 90
url: /hu/net/manage-slide-show/
keywords:
- bemutató típusa
- előadó által bemutatott
- egyéni böngészés
- kioszkban böngészett
- bemutató beállítások
- folyamatos ciklus
- narráció nélkül
- animáció nélkül
- toll szín
- diák megjelenítése
- egyedi bemutató
- diaváltás
- manuálisan
- időzítések használata
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan kezelje a diavetítéseket az Aspose.Slides for .NET-ben. Könnyedén szabályozza a diák átmeneteit, időzítéseit és egyebeket a PPT, PPTX és ODP formátumokban."
---
## **Bevezetés**

A Microsoft PowerPointben a **Slide Show** beállítások kulcsfontosságú eszközök a professzionális prezentációk elkészítéséhez és előadásához. Ennek a szakasznak az egyik legfontosabb funkciója a **Set Up Show**, amely lehetővé teszi a prezentáció testreszabását konkrét feltételekhez és közönségekhez, biztosítva a rugalmasságot és a kényelmet. Ezzel a funkcióval kiválaszthatja a bemutató típusát (például előadó által bemutatott, egyéni böngészésű vagy kioszkban böngészett), engedélyezheti vagy letilthatja a ciklikus lejátszást, meghatározhatja a megjelenítendő diákat, és időzítéseket használhat. Ez a felkészülési lépés elengedhetetlen ahhoz, hogy prezentációja hatékonyabb és professzionálisabb legyen.

`SlideShowSettings` a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály egy **tulajdonsága**, amelynek típusa a [SlideShowSettings](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slideshowsettings/), és lehetővé teszi a diavetítés beállításainak kezelését PowerPoint prezentációban. Ebben a cikkben azt vizsgáljuk meg, hogyan használhatja ezt a tulajdonságot a diavetítési beállítások különböző aspektusainak konfigurálására és vezérlésére. 

## **A bemutató típusának kiválasztása**

`SlideShowSettings.SlideShowType` meghatározza a diavetítés típusát, amely a következő osztályok valamelyikének példánya lehet: [PresentedBySpeaker](https://reference.aspose.com/slides/hu/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hu/net/aspose.slides/browsedbyindividual/), vagy [BrowsedAtKiosk](https://reference.aspose.com/slides/hu/net/aspose.slides/browsedatkiosk/). Ennek a tulajdonságnak a használatával a prezentációt különböző felhasználási szcenáriókhoz igazíthatja, például automatizált kioszkokhoz vagy kézi előadásokhoz.

Az alábbi kódrészlet új prezentációt hoz létre, és a bemutató típusát „Browsed by an individual” értékre állítja anélkül, hogy a görgetősáv megjelenne.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **A bemutató opcióinak engedélyezése**

`SlideShowSettings.Loop` meghatározza, hogy a diavetítés ismétlődjön-e ciklikusan, amíg manuálisan le nem állítják. Ez hasznos automatizált prezentációk esetén, amelyek folyamatosan futniuk kell. `SlideShowSettings.ShowNarration` meghatározza, hogy a hangos narrációk lejátszódjanak-e a diavetítés során. Ez akkor hasznos, ha a prezentáció hangutasítást tartalmaz a közönség számára. `SlideShowSettings.ShowAnimation` meghatározza, hogy a diák objektumaihoz hozzáadott animációk lejátszódjanak-e. Ez a teljes vizuális hatás biztosításához szükséges.

Az alábbi kódrészlet új prezentációt hoz létre, és ciklikusan lejátsza a diavetítést.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **A megjelenítendő diák kiválasztása**

`SlideShowSettings.Slides` tulajdonság lehetővé teszi, hogy a bemutató során megjelenítendő diák tartományát kiválassza. Ez akkor hasznos, amikor csak a prezentáció egy részét szeretné megjeleníteni, nem az összes diát. Az alábbi kódrészlet új prezentációt hoz létre, és a diatartományt a `2`‑től `9`‑ig terjedő diákra állítja.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Az automatikus diaváltás használata**

`SlideShowSettings.UseTimings` tulajdonság lehetővé teszi az egyes diák előre beállított időzítéseinek engedélyezését vagy letiltását. Ez hasznos az automatikus diaváltáshoz előre meghatározott megjelenítési időkkel. Az alábbi kódrészlet új prezentációt hoz létre, és letiltja az időzítések használatát.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Médiavezérlők megjelenítése**

`SlideShowSettings.ShowMediaControls` tulajdonság meghatározza, hogy a médiavezérlők (például lejátszás, szünet, leállítás) megjelenjenek-e a diavetítés során, amikor multimédia tartalom (például videó vagy hang) játszódik. Ez akkor hasznos, amikor a prezentátornak vezérlésre van szüksége a médiá lejátszásához a bemutató alatt.

Az alábbi kódrészlet új prezentációt hoz létre, és engedélyezi a médiavezérlők megjelenítését.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Menthetek-e prezentációt úgy, hogy közvetlenül diavetítési módban nyíljon meg?**

Igen. Mentse a fájlt PPSX vagy PPSM formátumban; ezek a formátumok a PowerPointben megnyitáskor közvetlenül diavetítési módban indulnak. Az Aspose.Slides-ben válassza a megfelelő mentési formátumot [exportálás közben](/slides/hu/net/save-presentation/).

**Kihagyhatok-e egyedi diákat a bemutatóból a fájlból való törlés nélkül?**

Igen. Jelöljön egy diát [Hidden](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/hidden/) állapotba. A rejtett diák a prezentációban maradnak, de a diavetítés során nem jelennek meg.

**Le tud-e az Aspose.Slides diavetítést lejátszani vagy élő prezentációt a képernyőn vezérelni?**

Nem. Az Aspose.Slides a prezentációs fájlok szerkesztésére, elemzésére és konvertálására szolgál; a tényleges lejátszást egy megjelenítő alkalmazás, például a PowerPoint végzi.