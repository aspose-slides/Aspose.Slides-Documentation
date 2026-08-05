---
title: Kördiagramok testreszabása prezentációkban C++ használatával
linktitle: Kördiagram
type: docs
url: /hu/cpp/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram beállításai
- diagram beállítások
- ábrázolási beállítások
- szelet színe
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és testreszabhat kördiagramokat C++-ban az Aspose.Slides segítségével, exportálható PowerPointba, ezzel másodpercek alatt erősítve adatmesélését."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk kördiagramokkal az Aspose.Slides-ben. Megmutatja, hogyan konfigurálhatók a másodlagos diagrambeállítások a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan engedélyezhető a szeletek automatikus színezése egy szabványos kördiagramnál.

A példák a gyakorlati diagramtestreszabási lépésekre összpontosítanak, mint például diagram hozzáadása egy diára, sorozat- és címke-beállítások módosítása, az alapértelmezett diagramadatok cseréje egyedi kategóriákra és értékekre, valamint a frissített bemutató mentése.

## **Másodlagos diagrambeállítások a Pie of Pie és Bar of Pie diagramokhoz**
Az Aspose.Slides for C++ most már támogatja a másodlagos diagrambeállításokat a Pie of Pie vagy Bar of Pie diagramokhoz. Ebben a témában példán keresztül megmutatjuk, hogyan adhatók meg ezek a beállítások az Aspose.Slides használatával. A tulajdonságok megadásához kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály objektumát.
1. Adjon hozzá diagramot a diára.
1. Adja meg a diagram másodlagos diagrambeállításait.
1. Írja a bemutatót a lemezre.

Az alább megadott példában különböző tulajdonságokat állítottunk be a Pie of Pie diagramhoz.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Állítsa be a kördiagram szeletek automatikus színeit**
Az Aspose.Slides for C++ egyszerű API-t biztosít a kördiagram szeletek automatikus színbeállításához. A minta kód alkalmazza a fent említett beállításokat.

1. Hozzon létre egy példányt a Presentation osztályból.
1. Érje el az első diát.
1. Adjon hozzá diagramot alapértelmezett adatokkal.
1. Állítsa be a diagram címét.
1. Állítsa be az első sorozatot az értékek megjelenítésére.
1. Állítsa be a diagram adatlap indexét.
1. A diagram adatlapjának lekérése.
1. Törölje az alapértelmezett generált sorozatokat és kategóriákat.
1. Adjon hozzá új kategóriákat.
1. Adjon hozzá új sorozatot.

Mentse a módosított bemutatót PPTX fájlba.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **GYIK**

**Támogatottak a 'Pie of Pie' és 'Bar of Pie' változatok?**

Igen, a könyvtár [támogatja](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) egy másodlagos diagramot a kördiagramokhoz, beleértve a 'Pie of Pie' és 'Bar of Pie' típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, a diagramot [exportálja a diagramot képként](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) (például PNG) anélkül, hogy az egész bemutatót exportálná.