---
title: Prezentációs diagramok formázása C++-ban
linktitle: Diagramformázás
type: docs
weight: 60
url: /hu/cpp/chart-formatting/
keywords:
- diagram formázása
- diagram formázás
- diagram elem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for C++-ban, és emelje PowerPoint prezentációját professzionális, figyelemfelkeltő stílussal."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan formázhatja a diagramokat PowerPoint-prezentációkban az Aspose.Slides használatával. Bemutatja, hogyan testreszabhatja a diagramok kulcsfontosságú elemeit, például a tengelyeket, rácsvonalakat, címeket, jelmagyarázatokat, a diagramterületet és a falak kitöltését, hogy javítsa a diagram adatok megjelenését és olvashatóságát.

A cikk azt is bemutatja, hogyan állítható be a diagram szövegének betűtípus tulajdonságai, hogyan alkalmazhatók előre definiált és egyéni numerikus formátumok a diagram adataira, valamint hogyan engedélyezhetők lekerekített sarkok a diagram területén. Ezek a példák együtt megmutatják, hogyan szabályozhatja a diagramok vizuális stílusát és adatmegjelenítését egy prezentációban.

## **Diagramelemek formázása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy saját diagramokat adjanak hozzá a diáikhoz a semmiből. Ez a cikk elmagyarázza, hogyan formázhatók a különböző diagramelemek, beleértve a diagram kategória- és értéktengelyét.

Az Aspose.Slides for C++ egyszerű API-t biztosít a különböző diagramelemek kezeléséhez és egyéni értékekkel történő formázásához:

1. Hozzon létre egy példányt a **Presentation** osztályból.
1. Szerezze meg egy dia hivatkozását az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típusok egyikével (ebben a példában a ChartType.LineWithMarkers típust használjuk).
1. Érje el a diagram Érték tengelyét, és állítsa be a következő tulajdonságokat:
   1. A **Line format** beállítása az Érték tengely fő rácsvonalaihoz
   1. A **Line format** beállítása az Érték tengely alrácsvonalaihoz
   1. A **Number Format** beállítása az Érték tengelyhez
   1. A **Min, Max, Major and Minor units** beállítása az Érték tengelyhez
   1. A **Text Properties** beállítása az Érték tengely adataihoz
   1. A **Title** beállítása az Érték tengelyhez
   1. A **Line Format** beállítása az Érték tengelyhez
1. Érje el a diagram Kategória tengelyét, és állítsa be a következő tulajdonságokat:
   1. A **Line format** beállítása a Kategória tengely fő rácsvonalaihoz
   1. A **Line format** beállítása a Kategória tengely alrácsvonalaihoz
   1. A **Text Properties** beállítása a Kategória tengely adataihoz
   1. A **Title** beállítása a Kategória tengelyhez
   1. A **Label Positioning** beállítása a Kategória tengelyhez
   1. A **Rotation Angle** beállítása a Kategória tengely címkéihez
1. Érje el a diagram Jelmagyarázatát, és állítsa be a **Text Properties** értékét.
1. Állítsa be a diagram Jelmagyarázatának megjelenítését úgy, hogy ne fedje le a diagramot
1. Érje el a diagram **Secondary Value Axis** és állítsa be a következő tulajdonságokat:
   1. A másodlagos **Value Axis** engedélyezése
   1. A **Line Format** beállítása a másodlagos értéktengelyhez
   1. A **Number Format** beállítása a másodlagos értéktengelyhez
   1. A **Min, Max, Major and Minor units** beállítása a másodlagos értéktengelyhez
1. Most ábrázolja az első diagram sorozatot a másodlagos értéktengelyen
1. Állítsa be a diagram hátfalát kitöltő színre
1. Állítsa be a diagram diagramterületének kitöltő színét
1. Írja a módosított prezentációt egy PPTX fájlba

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Diagram betűtípus tulajdonságainak beállítása**
Az Aspose.Slides for C++ támogatja a diagramhoz kapcsolódó betűtípus tulajdonságainak beállítását. Kérjük, kövesse az alábbi lépéseket a diagram betűtípus tulajdonságainak beállításához.

- Példányosítsa a **Presentation** osztályt.
- Adjon hozzá egy diagramot a diahoz.
- Állítsa be a betűmagasságot.
- Mentse a módosított prezentációt.

Az alábbi példa példát mutatja.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Diagram adat táblázat betűtípus tulajdonságainak beállítása**
Az Aspose.Slides for C++ támogatja a sorozat színben lévő kategóriák színének módosítását.

1. Példányosítsa a **Presentation** osztályt.
1. Adjon hozzá egy diagramot a diahoz.
1. Állítsa be a diagram táblázatát.
1. Állítsa be a betűmagasságot.
1. Mentse a módosított prezentációt.

Az alábbi példa példát mutatja. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Diagramterület lekerekített szegélyek beállítása**
Az Aspose.Slides for C++ támogatja a diagram terület beállítását. Az **IChart.HasRoundedCorners** és **Chart.HasRoundedCorners** tulajdonságok hozzá lettek adva az Aspose.Slides-hez. 

1. Példányosítsa a **Presentation** osztályt.
1. Adjon hozzá egy diagramot a diahoz.
1. Állítsa be a diagram kitöltési típusát és kitöltő színét
1. Állítsa a lekerekített sarok tulajdonságot **True**-ra.
1. Mentse a módosított prezentációt. 

Az alábbi példa példát mutatja. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Numerikus formátum beállítása**
Az Aspose.Slides for C++ egyszerű API-t biztosít a diagram adatformátum kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg egy dia hivatkozását az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típusok egyikével (ez a példa a **ChartType.ClusteredColumn** típust használja).
1. Állítsa be az előre definiált számformátumot a lehetséges értékek közül.
1. Iteráljon a diagram adatk celláján minden diagram sorozatban, és állítsa be a diagram adatok számformátumát.
1. Mentse a prezentációt.
1. Állítsa be az egyéni számformátumot.
1. Iteráljon a diagram adatk celláján minden diagram sorozatban, és állítson be eltérő számformátumot.
1. Mentse a prezentációt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Az alábbiakban a lehetséges előre definiált számformátum értékek indexekkel együtt vannak megadva:**|
| :- | :- |
|**0**|Általános|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **GYIK**

**Beállíthatok félátlátszó kitöltéseket oszlopoknak/területeknek, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációk esetén.

**Hogyan kezelhetem az adatcímkéket, ha átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke eltolását/pozícióját, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy váltson a formátumra "érték + jelmagyarázat".

**Alkalmazhatok gradient vagy minta kitöltéseket a sorozatokra?**

Igen. A tömör és a gradient/minta kitöltések is általában elérhetők. Gyakorlatban használjon gradienseket mértékkel, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.