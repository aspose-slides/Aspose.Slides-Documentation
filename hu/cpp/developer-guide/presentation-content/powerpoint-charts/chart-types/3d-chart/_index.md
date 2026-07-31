---
title: 3D diagramok testreszabása előadásokban C++ használatával
linktitle: 3D diagram
type: docs
url: /hu/cpp/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat 3-D diagramokat az Aspose.Slides C++ verziójában, PPT és PPTX fájlok támogatásával - erősítse meg előadásait még ma."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni egy 3D diagramot az Aspose.Slides-ban a `Rotation3D` beállítások, például a `RotationX`, `RotationY`, `DepthPercents` és `RightAngleAxes` konfigurálásával. Lépésről lépésre bemutatja egy bemutató létrehozását, egy alapértelmezett adatokat tartalmazó 3D diagram hozzáadását, a szükséges 3D nézeti beállítások alkalmazását, és a módosított bemutató mentését PPTX fájlként.

## **A 3D diagram RotationX, RotationY és DepthPercents tulajdonságainak beállítása**
Az Aspose.Slides for C++ egyszerű API-t biztosít ezen tulajdonságok beállításához. Ez a következő cikk segít abban, hogyan állítható be különböző tulajdonság, például X, Y forgatás, **DepthPercents** stb. A mintakód alkalmazza a fent említett tulajdonságok beállítását.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el az első diát.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal.
4. Állítsa be a Rotation3D tulajdonságokat.
5. Írja ki a módosított bemutatót egy PPTX fájlba.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja az oszlopdiagramok 3D változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100 % Stacked Column 3D diagramokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) felsorolás biztosít. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) tagjait az adott verzió API‑referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [chart API](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) segítségével, vagy a [render the entire slide](/slides/hu/cpp/convert-powerpoint-to-png/) útján PNG vagy JPEG formátumba. Ez akkor hasznos, ha pixel‑pontos előnézetre van szüksége, vagy be szeretné ágyazni a diagramot dokumentumokba, irányítópultokba vagy weboldalakba a PowerPoint nélkül.

**Mennyire hatékony a nagy 3D diagramok létrehozása és megjelenítése?**

A teljesítmény az adatvolumen és a vizuális összetettség függvénye. A legjobb eredmény érdekében tartsa a 3D effektusokat minimálisra, kerülje a nehéz textúrákat a falakon és a grafikonterületen, ha lehetséges korlátozza az egy sorban lévő adatpontok számát, valamint rendereljen megfelelő méretű (felbontású és méretű) kimenetre, amely megfelel a céleszköz vagy a nyomtatási igényeknek.