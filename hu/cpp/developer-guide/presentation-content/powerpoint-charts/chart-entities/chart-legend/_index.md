---
title: Diagrammagyarázatok testreszabása prezentációkban C++ használatával
linktitle: Diagrammagyarázat
type: docs
url: /hu/cpp/chart-legend/
keywords:
- diagrammagyarázat
- legend pozíció
- betűméret
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Testreszabja a diagrammagyarázatokat az Aspose.Slides for C++ segítségével, hogy a PowerPoint-prezentációkat egyedi legenda formázással optimalizálja."
---
## **Áttekintés**

Aspose.Slides lehetőséget biztosít a diagrammagyarázatok testreszabására a PowerPoint-prezentációkban. Ez a cikk bemutatja, hogyan állítható be a legenda pozíciója és mérete, hogyan állítható be a teljes legenda betűmérete, valamint hogyan formázható egyedi legenda bejegyzés.

Továbbá a GYIK-ban több kapcsolódó viselkedést is tárgyal, többek között a nem‑fedő mód használatát, amely lehetővé teszi, hogy a rajzterület helyet biztosítson a legendának, a hosszú legenda címkék tördelését vagy sortörésének használatát, valamint azt, hogy a legenda formázása a prezentáció téma beállításaiból öröklődjön, ha nincs megadva explicit szöveg- vagy kitöltésbeállítás.

## **Legenda elhelyezése**
A legenda tulajdonságainak beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálypéldányt.
- Szerezze meg a dia referenciáját.
- Diagram hozzáadása a diára.
- A legenda tulajdonságainak beállítása.
- Mentse a prezentációt PPTX fájlként.

Az alábbi példában a diagrammagyarázat pozícióját és méretét állítottuk be.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **A legenda betűméretének beállítása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára a legenda betűméretének beállítását. Kövesse az alábbi lépéseket:

- Példányosítsa a Presentation osztályt.
- Alapértelmezett diagram létrehozása.
- Állítsa be a betűméretet.
- Állítsa be a minimum tengelyértéket.
- Állítsa be a maximum tengelyértéket.
- Mentse a prezentációt a lemezre.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Egyéni legenda bejegyzés betűméretének beállítása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára egyedi legenda bejegyzések betűméretének beállítását. Kövesse az alábbi lépéseket:

- Példányosítsa a Presentation osztályt.
- Alapértelmezett diagram létrehozása.
- Hozzáférés a legenda bejegyzéséhez.
- Állítsa be a betűméretet.
- Állítsa be a minimum tengelyértéket.
- Állítsa be a maximum tengelyértéket.
- Mentse a prezentációt a lemezre.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **GYIK**

**Engedélyezhetem a legendát úgy, hogy a diagram automatikusan helyet biztosítson számára a felülírás helyett?**

Igen. Használja a nem‑fedő módot ([set_Overlay(false)](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/legend/set_overlay/)); ebben az esetben a diagram területe összezsugorodik, hogy helyet biztosítson a legendának.

**Készíthetek több soros legenda címkéket?**

Igen. A hosszú címkék automatikusan törnek, ha nincs elég hely; a kényszerített sortöréseket a sorozat nevében lévő újsor karakterekkel lehet megadni.

**Hogyan tehetem úgy, hogy a legenda a prezentáció téma színsémáját kövesse?**

Ne állítson be explicit színeket/töltéseket/betűtípusokat a legendához vagy a szövegéhez. Így azok a témából öröklődnek, és a tervezés megváltozása esetén helyesen frissülnek.