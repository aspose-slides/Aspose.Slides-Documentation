---
title: Diagramok formázása PowerPoint prezentációkban C++-ban
linktitle: Diagram formázása
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

Ez a cikk bemutatja, hogyan formázhatók diagramok a PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram kulcsfontosságú elemei, például a tengelyek, rácsvonalak, címek, jelmagyarázatok, a diagramterület és a falak kitöltései a diagram adatok megjelenésének és olvashatóságának javítása érdekében.

Bemutatja továbbá, hogyan állíthatók be a diagram szövegének betűtípus‑tulajdonságai, hogyan alkalmazhatók előre definiált és egyedi numerikus formátumok a diagram adatokra, valamint hogyan engedélyezhetők a lekerekített sarkok a diagram területén. Együtt ezek a példák azt szemléltetik, hogyan szabályozható a diagramok vizuális stílusa és adatmegjelenítése egy prezentációban.

## **Diagramelemek formázása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy saját diagramokat hozzanak létre a diákon. Ez a cikk azt mutatja be, hogyan formázhatók különböző diagramelemek, beleértve a diagram kategória‑ és értéktengelyét.

Az Aspose.Slides for C++ egyszerű API‑t biztosít a különböző diagramelemek kezelésére és saját értékekkel való formázásukra:

1. Hozzon létre egy példányt a **Presentation** osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus egyikével (ebben a példában a **ChartType.LineWithMarkers**‑t használjuk).
1. Nyissa meg a diagram **Value Axis**‑át, és állítsa be a következő tulajdonságokat:
   1. **Line format** beállítása az értéktengely fő rácsvonalaihoz
   1. **Line format** beállítása az értéktengely segéd rácsvonalaihoz
   1. **Number Format** beállítása az értéktengelyhez
   1. **Min, Max, Major and Minor units** beállítása az értéktengelyhez
   1. **Text Properties** beállítása az értéktengely adataihoz
   1. **Title** beállítása az értéktengelyhez
   1. **Line Format** beállítása az értéktengelyhez
1. Nyissa meg a diagram **Category Axis**‑át, és állítsa be a következő tulajdonságokat:
   1. **Line format** beállítása a kategóriatengely fő rácsvonalaihoz
   1. **Line format** beállítása a kategóriatengely segéd rácsvonalaihoz
   1. **Text Properties** beállítása a kategóriatengely adataihoz
   1. **Title** beállítása a kategóriatengelyhez
   1. **Label Positioning** beállítása a kategóriatengelyhez
   1. **Rotation Angle** beállítása a kategóriatengely címkéihez
1. Nyissa meg a diagram **Legend**‑jét, és állítsa be a **Text Properties**‑t számára
1. Állítsa be, hogy a diagram jelmagyarázata ne fedje át a diagramot
1. Nyissa meg a diagram **Secondary Value Axis**‑t, és állítsa be a következő tulajdonságokat:
   1. Engedélyezze a **Secondary Value Axis**‑t
   1. **Line Format** beállítása a másodlagos értéktengelyhez
   1. **Number Format** beállítása a másodlagos értéktengelyhez
   1. **Min, Max, Major and Minor units** beállítása a másodlagos értéktengelyhez
1. Hozza létre az első diagram sorozatot a **Secondary Value Axis**‑en
1. Állítsa be a diagram hátfalat kitöltő színre
1. Állítsa be a diagram ábrázolási területének kitöltő színét
1. Írja a módosított prezentációt egy PPTX fájlba

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Betűtípus‑tulajdonságok beállítása diagramhoz**
Az Aspose.Slides for C++ támogatja a diagram betűtípus‑tulajdonságainak beállítását. Kövesse az alábbi lépéseket a diagram betűtípus‑tulajdonságainak beállításához.

- Hozzon létre egy **Presentation** osztálypéldányt.
- Adjon hozzá egy diagramot a diára.
- Állítsa be a betűmagasságot.
- Mentse a módosított prezentációt.

Az alábbi mintapélda bemutatásra kerül.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Betűtípus‑tulajdonságok beállítása diagram adat táblához**
Az Aspose.Slides for C++ támogatja a sorozat színeiben lévő kategóriák színének módosítását.

1. Hozzon létre egy **Presentation** osztálypéldányt.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a diagram táblát.
1. Állítsa be a betűmagasságot.
1. Mentse a módosított prezentációt.

Az alábbi mintapélda bemutatásra kerül.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Lekerekített szegélyek beállítása a diagram területén**
Az Aspose.Slides for C++ támogatja a diagram területének beállítását. Az **IChart.HasRoundedCorners** és a **Chart.HasRoundedCorners** tulajdonságok kerültnek bevezetésre az Aspose.Slides‑ben.

1. Hozzon létre egy **Presentation** osztálypéldányt.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a diagram kitöltésének típusát és színét.
1. Állítsa a **Round corner** tulajdonságot **True**‑ra.
1. Mentse a módosított prezentációt.

Az alábbi mintapélda bemutatásra kerül.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Számformátum beállítása**
Az Aspose.Slides for C++ egyszerű API‑t biztosít a diagram adatformátum kezelésére:

1. Hozzon létre egy példányt a[Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/)osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus egyikével (ebben a példában a **ChartType.ClusteredColumn**‑t használjuk).
1. Állítsa be az előre definiált számformátumot a lehetséges előre definiált értékek közül.
1. Járja be a diagram adatcella‑kat minden diagram sorozatban, és állítsa be a diagram adat számformátumát.
1. Mentse a prezentációt.
1. Állítsa be az egyedi (custom) számformátumot.
1. Járja be a diagram adatcella‑kat minden diagram sorozatban, és állítson be különböző számformátumot.
1. Mentse a prezentációt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Az alábbiakban a lehetséges előre beállított számformátum‑értékek az előre beállított indexükkel együtt találhatók:**|
| :- | :- |

|**0**|General|
| :- | :- |
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

**Beállíthatok félig átlátszó kitöltést az oszlopok/területek számára, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal különállóan konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációk esetén.

**Hogyan kezeljem a címkéket, ha átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke eltolását/pozícióját, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy váltson „érték + jelmagyarázat” formátumra.

**Alkalmazhatok-e gradient vagy minta kitöltést sorozatokra?**

Igen. Általában elérhetők a homogén és a gradient/minta kitöltések is. Gyakorlatban használjon gradienteket mértékkel, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.