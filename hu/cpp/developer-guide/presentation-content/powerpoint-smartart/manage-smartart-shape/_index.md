---
title: SmartArt grafika kezelése prezentációkban C++ segítségével
linktitle: SmartArt grafika
type: docs
weight: 20
url: /hu/cpp/manage-smartart-shape/
keywords:
- SmartArt objektum
- SmartArt grafika
- SmartArt stílus
- SmartArt szín
- SmartArt létrehozása
- SmartArt hozzáadása
- SmartArt szerkesztése
- SmartArt módosítása
- SmartArt elérése
- SmartArt elrendezés típusa
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Automatizálja a PowerPoint SmartArt létrehozását, szerkesztését és stílusának beállítását C++-ban az Aspose.Slides használatával, tömör kódrészletekkel és a teljesítményre fókuszáló útmutatóval."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan hozzon létre és kezeljen SmartArt grafikákat PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan adjon SmartArt alakzatot egy diára, hogyan érje el a meglévő SmartArt alakzatokat, hogyan találja meg a SmartArt‑ot egy adott elrendezéstípus szerint, és hogyan frissítse a megjelenését a SmartArt stílus vagy színstílus módosításával.

A példák azt mutatják, hogyan dolgozzunk a SmartArt alakzatokkal a prezentáció dia alakzatelőállításán keresztül, hogyan ellenőrizzük, hogy egy alakzat SmartArt‑e, majd hogyan módosítsuk vagy vizsgáljuk meg tulajdonságait.

## **SmartArt alakzat létrehozása**
Az Aspose.Slides for C++ most már lehetővé teszi egyedi SmartArt alakzatok hozzáadását a diához teljesen az elejétől. Az Aspose.Slides for C++ a legegyszerűbb API‑t biztosítja a SmartArt alakzatok létrehozásához. Egy SmartArt alakzat létrehozásához egy dián kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
- Szerezze meg a dia referencia­ját az indexe segítségével.
- Adjon hozzá egy SmartArt alakzatot a LayoutType beállításával.
- Írja ki a módosított prezentációt PPTX fájlként.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **SmartArt alakzat elérése egy dián**
Az alábbi kódot a prezentációs dián hozzáadott SmartArt alakzatok eléréséhez használjuk. A példakódban végigjárjuk a dia minden alakzatát, és ellenőrizzük, hogy SmartArt‑e. Ha az alakzat SmartArt típusú, típuskonverziót végzünk SmartArt példányra.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **SmartArt alakzat elérése egy meghatározott elrendezéstípussal**
Az alábbi minta kód segít elérni a SmartArt alakzatot egy adott LayoutType‑tal. Ne feledje, a LayoutType csak olvasható, és csak a SmartArt alakzat hozzáadásakor állítható be.

- Hozzon létre egy `Presentation` osztály példányt, és töltse be a SmartArt alakzatot tartalmazó prezentációt.
- Szerezze meg az első dia referencia­ját az indexe alapján.
- Járja be az első dia minden alakzatát.
- Ellenőrizze, hogy az alakzat SmartArt‑e, és ha igen, típuskonvertálja SmartArt‑ra.
- Keresse meg a kívánt LayoutType‑ú SmartArt alakzatot, majd végezze el a szükséges műveleteket.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **SmartArt alakzat stílusának módosítása**
Az alábbi minta kód segít elérni a SmartArt alakzatot egy adott LayoutType‑tal.

- Hozzon létre egy `Presentation` osztály példányt, és töltse be a SmartArt alakzatot tartalmazó prezentációt.
- Szerezze meg az első dia referencia­ját az indexe alapján.
- Járja be az első dia minden alakzatát.
- Ellenőrizze, hogy az alakzat SmartArt‑e, és ha igen, típuskonvertálja SmartArt‑ra.
- Keresse meg a kívánt Style‑ú SmartArt alakzatot.
- Állítsa be az új Style‑t a SmartArt alakzatra.
- Mentse a prezentációt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **SmartArt alakzat színstílusának módosítása**
Ebben a példában megtanuljuk, hogyan változtassuk meg egy SmartArt alakzat színstílusát. Az alábbi minta kód egy meghatározott Color Style‑ú SmartArt alakzatot ér el, és módosítja annak stílusát.

- Hozzon létre egy `Presentation` osztály példányt, és töltse be a SmartArt alakzatot tartalmazó prezentációt.
- Szerezze meg az első dia referencia­ját az indexe alapján.
- Járja be az első dia minden alakzatát.
- Ellenőrizze, hogy az alakzat SmartArt‑e, és ha igen, típuskonvertálja SmartArt‑ra.
- Keresse meg a kívánt Color Style‑ú SmartArt alakzatot.
- Állítsa be az új Color Style‑t a SmartArt alakzatra.
- Mentse a prezentációt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **GYIK**

**Animálhatom-e a SmartArt‑ot egyetlen objektumként?**

Igen. A SmartArt egy alakzat, ezért a [szabványos animációkat](/slides/hu/cpp/powerpoint-animation/) alkalmazhatja az animációs API‑val (belépés, kilépés, hangsúlyozás, mozgáspályák), akárcsak más alakzatoknál.

**Hogyan találhatok meg egy konkrét SmartArt‑ot egy dián, ha nem ismerem a belső azonosítóját?**

Állítson be és használjon alternatív szöveget (AltText), majd keresse meg az alakzatot ezen az értéken – ez a javasolt módszer a célalkalmazás megtalálásához.

**Csoportosíthatom‑e a SmartArt‑ot más alakzatokkal?**

Igen. A SmartArt‑ot csoportosíthatja más alakzatokkal (képek, táblázatok stb.), majd [manipulálhatja a csoportot](/slides/hu/cpp/group/).

**Hogyan kaphatok képet egy konkrét SmartArt‑ról (például előnézethez vagy jelentéshez)?**

Exportáljon egy miniatűr/képet az alakzatról; a könyvtár képes [egyedi alakzatok renderelésére](/slides/hu/cpp/create-shape-thumbnails/) raszter fájlokként (PNG/JPG/TIFF).

**Megmarad‑e a SmartArt megjelenése a teljes prezentáció PDF‑re konvertálásakor?**

Igen. A renderelő motor a [PDF export](/slides/hu/cpp/convert-powerpoint-to-pdf/) esetén magas hűséget céloz meg, több minőség‑ és kompatibilitási beállítással.