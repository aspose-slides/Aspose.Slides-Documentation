---
title: Diagram legendák testreszabása prezentációkban C++ használatával
linktitle: Diagram legenda
type: docs
url: /hu/cpp/chart-legend/
keywords:
- diagram legenda
- legend pozíciója
- betűméret
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Testreszabhatja a diagram legendákat az Aspose.Slides for C++ segítségével, hogy optimalizálja a PowerPoint prezentációkat a legendák egyedi formázásával."
---
## **Áttekintés**

Az Aspose.Slides lehetőséget biztosít a diagram legendák testreszabására a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni egy legendát, beállítani a teljes legenda betűméretét, valamint formázni egy egyedi legendabejegyzést.  

Az FAQ‑ban további kapcsolódó viselkedéseket is tárgyal, többek között a nem átfedés mód használatát, amely lehetővé teszi, hogy a rajzterület helyet biztosítson a legendának, a hosszú legendacímkék sortörés vagy tördelés lehetőségét, valamint a legenda formázásának öröklődését a prezentáció témájából, ha nem adunk meg kifejezett szöveg‑ és kitöltési beállításokat.

## **Legenda elhelyezése**
A legenda tulajdonságainak beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
- Szerezze be a diára való hivatkozást.
- Diagram hozzáadása a diára.
- A legenda tulajdonságainak beállítása.
- A prezentáció mentése PPTX fájlként.

Az alábbi példában beállítottuk a diagram legenda pozícióját és méretét.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Legenda betűméretének beállítása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára a legenda betűméretének beállítását. Kövesse az alábbi lépéseket:

- Példányosítsa a Presentation osztályt.
- Alapértelmezett diagram létrehozása.
- A betűméret beállítása.
- Az alsó tengely minimum értékének beállítása.
- A felső tengely maximum értékének beállítása.
- A prezentáció mentése lemezre.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Egyedi legendabejegyzés betűméretének beállítása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára az egyes legendabejegyzések betűméretének beállítását. Kövesse az alábbi lépéseket:

- Példányosítsa a Presentation osztályt.
- Alapértelmezett diagram létrehozása.
- A legendabejegyzés elérése.
- A betűméret beállítása.
- Az alsó tengely minimum értékének beállítása.
- A felső tengely maximum értékének beállítása.
- A prezentáció mentése lemezre.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **GYIK**

**Engedélyezhetem a legendát úgy, hogy a diagram automatikusan helyet biztosítson neki ahelyett, hogy átfedné?**

Igen. Használja a nem‑átfedés módot ([set_Overlay(false)](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/legend/set_overlay/)); ebben az esetben a rajzterület összezsugorodik, hogy helyet adjon a legendának.

**Készíthetek több soros legendacímkéket?**

Igen. A hosszú címkék automatikusan törnek, ha nincs elegendő hely; a kényszerített sortörések a sorozat nevében lévő újsor karakterekkel támogatottak.

**Hogyan tudom, hogy a legenda a prezentáció téma színpalettáját kövesse?**

Ne állítson be kifejezett színeket/kitöltéseket/betűtípusokat a legendához vagy annak szövegéhez. Ezek ekkor a témából öröklődnek, és megfelelően frissülnek a tervezés megváltoztatásakor.