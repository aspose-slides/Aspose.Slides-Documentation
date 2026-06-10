---
title: Betűkészlet kiválasztási sorrend az Aspose.Slides for Python-ban
linktitle: Betűkészlet kiválasztás
type: docs
weight: 80
url: /hu/python-net/font-selection-sequence/
keywords:
- betűkészlet kiválasztás
- betűkészlet helyettesítés
- betűkészlet csere
- helyettesítési szabály
- elérhető betűkészlet
- hiányzó betűkészlet
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan választja ki az Aspose.Slides for Python a .NET-en keresztül a betűkészleteket, biztosítva a PPT, PPTX és ODP fájlok éles, következetes megjelenítését – javítsa most diái minőségét."
---
## **Áttekintés**

Amikor egy prezentációt betöltenek, megjelenítenek vagy egy másik formátumba konvertálnak, az Aspose.Slides ellenőrzi, hogy a prezentációban használt betűkészletek elérhetők-e az operációs rendszerben. Ha egy szükséges betűkészlet hiányzik, az Aspose.Slides egy helyettesítő betűkészletet választ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.

Az Aspose.Slides először az operációs rendszerben keresi a kiválasztott betűkészletet. Ha a betűkészlet megtalálható, azt használja. Ha nem található, egy megfelelő helyettesítő kerül alkalmazásra. Amikor a betűkészlet helyettesítési szabályokat a `FontSubstRule` segítségével definiálják, ezeket a szabályokat is figyelembe veszi.

Betűkészleteket is hozzáadhat az alkalmazás futásidejében, használhat beágyazott betűkészleteket egy prezentációból, vagy betölthet külső betűkészleteket a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűkészlet-kiválasztás**

Bizonyos szabályok vonatkoznak a prezentációban használt betűkészletekre, amikor a prezentációt betöltik, megjelenítik vagy egy másik formátumba konvertálják. Például, amikor megpróbálja a prezentáció (diáit) képekké konvertálni, a prezentáció betűkészleteit ellenőrzik, hogy a választott betűkészletek elérhetők-e az operációs rendszerben. Ha a betűkészletek hiányának megállapítása történik, helyettesítik őket – lásd [**Betűkészlet cseréje**](https://docs.aspose.com/slides/hu/python-net/font-replacement/) és [**Betűkészlet helyettesítése**](https://docs.aspose.com/slides/hu/python-net/font-substitution/).

Ez a folyamat, amelyet az Aspose.Slides a betűkészletekkel való munka során követ:

1. Az Aspose.Slides az operációs rendszerben keresi a betűkészleteket, hogy megtalálja a prezentáció által választott betűkészletnek megfelelő betűkészletet. 
2. Ha a választott betűkészlet megtalálható, az Aspose.Slides azt használja. Ellenkező esetben az Aspose.Slides egy helyettesítő betűkészletet használ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.
3. Ha a betűkészlet helyettesítési szabályok a [FontSubstRule](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsubstrule/) segítségével lettek beállítva, azokat alkalmazzák. 

Az Aspose.Slides lehetővé teszi, hogy betűkészleteket adjon hozzá az alkalmazás futásidejében, majd ezeket a betűkészleteket használja. Lásd [**Egyéni betűkészletek**](https://docs.aspose.com/slides/hu/python-net/custom-font/). 

Amikor további betűkészleteket helyeznek el egy prezentáción belül, ezeket [**Beágyazott betűkészleteknek**](https://docs.aspose.com/slides/hu/python-net/embedded-font/) hívják.

Az Aspose.Slides lehetővé teszi, hogy olyan betűkészleteket adjon hozzá, amelyek csak a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF-re konvertálni kívánt prezentáció olyan betűkészleteket tartalmaz, amelyek hiányoznak a rendszeréből és a beágyazott betűkészletekből, hozzáadhat vagy betölthet a szükséges betűkészleteket **külső betűkészletekként**.

{{% alert title="Note" color="primary" %}} 
Mi nem terjesztünk semmilyen betűkészletet, sem fizetettet, sem ingyeneset. API-nk lehetővé teszi, hogy külső betűkészleteket töltsön be és beágyazza őket a dokumentumokba, de ezt a betűkészleteket saját belátása és felelőssége szerint teszi.
{{% /alert %}}

## **GYIK**

**Hogyan határozhatom meg, hogy mely betűkészletek vannak ténylegesen használatban egy prezentációban a konvertálás előtt?**

Az Aspose.Slides lehetővé teszi, hogy a [betűkészlet-kezelő](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/fonts_manager/) segítségével megvizsgálja a használt betűkészleteket, így eldöntheti, hogy [beágyazza](/slides/hu/python-net/embedded-font/), [lecseréli](/slides/hu/python-net/font-replacement/) vagy hozzáadja a [külső forrásokat](/slides/hu/python-net/custom-font/). Ez segít elkerülni a nem kívánt helyettesítéseket a megjelenítés és exportálás során.

**Hozzáadhatok extra betűkészlet-könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerre?**

Igen. Regisztrálhat [külső betűkészlet-forrásokat](/slides/hu/python-net/custom-font/), például mappákat vagy memóriában tárolt adatfolyamokat a megjelenítéshez és exportáláshoz. Ez eltávolítja a függőséget a gazdarendszer betűkészleteitől és előre jelezhető elrendezést biztosít.

**Hogyan akadályozhatom meg, hogy hiányzó glyph esetén csendes visszaváltás történjen egy nem alkalmas betűkészletre?**

Határozzon meg előre explicit [betűkészlet-cserét](/slides/hu/python-net/font-replacement/) és betűkészlet [fallback szabályokat](/slides/hu/python-net/fallback-font/). A használt betűkészletek elemzésével és a helyettesítők szabályozott prioritásának beállításával biztosíthatja a konzisztens tipográfiát és elkerülheti a váratlan eredményeket.