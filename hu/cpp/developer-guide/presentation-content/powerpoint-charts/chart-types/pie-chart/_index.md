---
title: Kördiagramok testreszabása prezentációkban C++ segítségével
linktitle: Kördiagram
type: docs
url: /hu/cpp/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram opciók
- diagram beállítások
- ábrázolási beállítások
- szelet szín
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat kördiagramokat C++-ban az Aspose.Slides használatával, exportálhatóak PowerPoint-ba, és másodpercek alatt növelik adatmesélését."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk kördiagramokkal az Aspose.Slides-ban. Megmutatja, hogyan konfigurálhatók a másodlagos ábrázolási beállítások a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan engedélyezhető az automatikus szeletszínezés egy szabványos kördiagram esetén.

A példák a gyakorlati diagramtestreszabási lépésekre összpontosítanak, például diagram hozzáadása egy diára, sorozatok és címkék beállítása, az alapértelmezett diagramadatok helyettesítése egyéni kategóriákkal és értékekkel, valamint a frissített prezentáció mentése.

## **Másodlagos ábrázolási beállítások a Pie of Pie és Bar of Pie diagramokhoz**
Az Aspose.Slides for C++ most már támogatja a másodlagos ábrázolási beállításokat a Pie of Pie vagy Bar of Pie diagramokhoz. Ebben a témában példával megmutatjuk, hogyan adhatók meg ezek a beállítások az Aspose.Slides segítségével. A tulajdonságok megadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt.
1. Adjon hozzá diagramot a diára.
1. Adja meg a diagram másodlagos ábrázolási beállításait.
1. Írja a prezentációt a lemezre.

Az alábbi példában a Pie of Pie diagram különböző tulajdonságait állítottuk be.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}



## **Automatikus kördiagram szegmensszínek beállítása**
Az Aspose.Slides for C++ egyszerű API-t biztosít az automatikus kördiagram szegmensszínek beállításához. A minta kód a fent említett tulajdonságok beállítását alkalmazza.

1. Hozzon létre egy példányt a Presentation osztályból.
1. Hozzáférés az első diára.
1. Diagram hozzáadása alapértelmezett adatokkal.
1. Állítsa be a diagram címét.
1. Állítsa be az első sorozatot az értékek megjelenítésére.
1. Állítsa be a diagram adatlap indexét.
1. A diagram adatlapjának lekérése.
1. Az alapértelmezés szerint generált sorozatok és kategóriák törlése.
1. Új kategóriák hozzáadása.
1. Új sorozat hozzáadása.

A módosított prezentáció írása PPTX fájlba.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Támogatottak a 'Pie of Pie' és 'Bar of Pie' változatok?**

Igen, a könyvtár [támogatja] a másodlagos ábrázolást a kördiagramoknál, beleértve a 'Pie of Pie' és 'Bar of Pie' típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, a diagramot közvetlenül [exportálhatja képként](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) (például PNG) a teljes prezentáció nélkül.