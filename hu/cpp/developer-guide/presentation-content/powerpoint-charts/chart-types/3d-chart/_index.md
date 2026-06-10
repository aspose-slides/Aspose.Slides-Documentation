---
title: 3D diagramok testreszabása prezentációkban C++ használatával
linktitle: 3D diagram
type: docs
url: /hu/cpp/3d-chart/
keywords:
- 3D diagram
- forgatás
- mélység
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat 3-D diagramokat az Aspose.Slides for C++-ban, PPT és PPTX fájlok támogatásával - növelje prezentációi hatékonyságát még ma."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni egy 3D diagramot az Aspose.Slides-ban a `Rotation3D` beállítások, például a `RotationX`, `RotationY`, `DepthPercents` és `RightAngleAxes` konfigurálásával. Lépésről lépésre végigvezet a bemutató létrehozásán, egy alapértelmezett adatokkal rendelkező 3D diagram hozzáadásán, a szükséges 3D nézeti beállítások alkalmazásán, valamint a módosított bemutató PPTX fájlba mentésén.

## **Állítsa be a RotationX, RotationY és DepthPercents tulajdonságokat egy 3D diagramon**
Az Aspose.Slides for C++ egyszerű API-t biztosít ezen tulajdonságok beállításához. Az alábbi cikk segít különböző tulajdonságok, például az X, Y forgatás, **DepthPercents** stb. beállításában. A mintakód bemutatja a fenti tulajdonságok alkalmazását.

1. Hozzon létre egy példányt a[Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Hozzáférés az első diahoz.
1. Diagram hozzáadása alapértelmezett adatokkal.
1. Rotation3D tulajdonságok beállítása.
1. A módosított prezentáció mentése PPTX fájlba.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a 3D oszlopdiagramok változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100% Stacked Column 3D diagramokat, valamint a kapcsolódó 3D típusokat, amelyek a [ChartType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) felsorolásban érhetők el. A pontos, naprakész listáért tekintse meg a [ChartType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) elemeit az adott telepített verzió API‑referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képfájlba a [diagram API](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) segítségével, vagy renderelheti az egész diát [/slides/hu/cpp/convert-powerpoint-to-png/](/slides/hu/cpp/convert-powerpoint-to-png/) útvonalon PNG vagy JPEG formátumba. Ez akkor hasznos, ha pixelpontos előnézetre van szüksége, vagy a diagramot dokumentumokba, irányítópultokra vagy weboldalakba szeretné beágyazni PowerPoint nélkül.

**Mennyire teljesítményhatékony a nagy 3D diagramok építése és renderelése?**

A teljesítmény az adatvolumen és a vizuális komplexitás függvénye. A legjobb eredmény érdekében tartsa minimalizálva a 3D effektusokat, kerülje a nehéz textúrákat a falakon és ábraterületeken, korlátozza az egyes sorozatok adatpontszámát ahol lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és méretek), amely megfelel a célkijelző vagy nyomtatási igényeknek.