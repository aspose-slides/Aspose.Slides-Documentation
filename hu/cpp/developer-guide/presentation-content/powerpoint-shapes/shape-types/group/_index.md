---
title: C++ csoportos prezentációs alakzatok
linktitle: Alakzatcsoport
type: docs
weight: 40
url: /hu/cpp/group/
keywords:
- csoport alakzat
- alakzatcsoport
- csoport hozzáadása
- alternatív szöveg
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan csoportosíthatja és bontathatja a alakzatokat PowerPoint prezentációkban az Aspose.Slides for C++ segítségével — gyors, lépésről lépésre útmutató ingyenes C++ kóddal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk csoport alakzatokkal az Aspose.Slides‑ben. Megmutatja, hogyan lehet egy csoport alakzatot hozzáadni egy diára, alakzatokat elhelyezni benne, és menteni a frissített prezentációt. Bemutatja továbbá, hogyan lehet elérni a csoporton belül tárolt alakzatokat, és beolvasni azok `AlternativeText` értékeit. Emellett a cikk röviden érinti a kapcsolódó csoport‑alakzat funkciókat, például a beágyazott csoportokat, a z‑rendet és a zárolási beállításokat.

## **Csoport alakzat hozzáadása**
Az Aspose.Slides támogatja a csoport alakzatok használatát a diákon. Ez a funkció segíti a fejlesztőket a gazdagabb prezentációk létrehozásában. Az Aspose.Slides for C++ támogatja a csoport alakzatok hozzáadását vagy elérését. Lehetőség van alakzatokat hozzáadni a létrehozott csoport alakzathoz, vagy a csoport alakzat bármely tulajdonságát elérni. Csoport alakzat hozzáadásához egy diára az Aspose.Slides for C++ segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg a diára való hivatkozást az Index használatával.
1. Adjon hozzá egy csoport alakzatot a diához.
1. Adjon hozzá alakzatokat a létrehozott csoport alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példa csoport alakzatot ad egy diához.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Az AltText tulajdonság elérése**
Ez a téma egyszerű lépéseket mutat be, kódrészletekkel együtt, a csoport alakzat hozzáadásához és a csoport alakzatok AltText tulajdonságának eléréséhez a diákon. A csoport alakzat AltText értékének eléréséhez egy dián az Aspose.Slides for C++ használatával:

1. Hozzon létre egy `Presentation` példányt, amely egy PPTX fájlt képvisel.
1. Szerezze meg a diára való hivatkozást az Index használatával.
1. Érje el a diák alakzatgyűjteményét.
1. Érje el a csoport alakzatot.
1. Olvassa ki az AltText tulajdonságot.

Az alábbi példa a csoport alakzat alternatív szövegét éri el.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **GYIK**

**Támogatott a beágyazott csoportolás (csoport egy csoporton belül)?**

Igen. A [GroupShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/groupshape/) rendelkezik egy [get_ParentGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/get_parentgroup/) metódussal, amely közvetlenül jelzi a hierarchia támogatását (egy csoport lehet egy másik csoport gyermekeként).

**Hogyan szabályozhatom a csoport z‑rendjét a dián lévő egyéb objektumokhoz képest?**

Használja a [GroupShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/groupshape/) [Z‑Order position](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/get_zorderposition/) metódusát a megjelenítési rétegben betöltött pozíció vizsgálatához.

**Megakadályozható a mozgatás/szerkesztés/csoport felbontása?**

Igen. A csoport zárolási részét a [get_GroupShapeLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/groupshape/get_groupshapelock/) metódus teszi elérhetővé, amely lehetővé teszi a műveletek korlátozását az objektumon.